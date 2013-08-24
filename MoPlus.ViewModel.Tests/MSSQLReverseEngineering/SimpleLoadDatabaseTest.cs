using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.Events;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Tests.SamplePacks;
using MoPlus.ViewModel.Tests.Staging;

namespace MoPlus.ViewModel.Tests.MSSQLReverseEngineering
{
    [TestClass]
    public class SimpleLoadDatabaseTest: BaseTest
    {
        /*
         * This test creates a database, and loads that database into an Mo+ solution.
         */

        private string mDatabaseFileName;
        private string mDatabaseLogFileName;
        private string mTemplatesPath;

        protected override void DoExecute(string playground)
        {
            TestLocaldb.Execute("sqllocaldb.exe", "stop v11.0");
            TestLocaldb.Execute("sqllocaldb.exe", "start v11.0");

            var dbName = "Northwind-" + Guid.NewGuid();
            mDatabaseFileName = Path.Combine(playground, dbName + ".mdf");
            mDatabaseLogFileName = Path.Combine(playground, dbName + "_log.ldf");
            mTemplatesPath = Path.Combine(playground, "Templates");

            // setup database
            NorthwindUtility.Create(dbName, mDatabaseFileName, mDatabaseLogFileName);
            var gettingStartedPath = Path.Combine(playground, "GettingStartedPack");
            Directory.CreateDirectory(gettingStartedPath);

            // unpack sapmle pack to <Playground>\GettingStartedPack
            SamplePacksUtility.ExtractGettingStartedTo(gettingStartedPath);

            var solutionDesigner = new DesignerViewModel();
            var builder = new BuilderViewModel();

            #region create solution
            builder.ProcessNewCommand(builder.SolutionsFolder);
            var solutionVM = solutionDesigner.SelectedItem as SolutionViewModel;
            if (solutionVM == null)
            {
                throw new InvalidOperationException("Couldn't find SolutionViewModel");
            }
            solutionVM.SolutionName = "TestSolution";
            solutionVM.Namespace = "TestNamespace";
            solutionVM.OutputSolutionFileName = "TestSolution.sln";
            solutionVM.CompanyName = "TestCompany";
            solutionVM.ProductName = "TestProduct";
            solutionVM.ProductVersion = "0.1";
            solutionVM.SolutionPath = Path.Combine(playground, "TestSolution.xml");
            solutionVM.TemplatePath = Path.Combine(playground, "NorthwindSolutionFile.mpt");
            solutionVM.Update();
            var solution = solutionVM.Solution;
            if (solution == null)
            {
                throw new InvalidOperationException("Couldn't find Solution!");
            }
            solutionVM.UpdateCommand.Execute(null);
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            solution.OutputRequested += SolutionOnOutputRequested;
            
            #endregion create solution

            #region create solution template
            if (solutionVM.CodeTemplatesFolder == null)
            {
                throw new InvalidOperationException("Couldn't find CodeTemplatesFolder");
            }

            solutionVM.CodeTemplatesFolder.ProcessNewCodeTemplateCommand();
            var newSolTpl = new CodeTemplateViewModel();
            var solutionTemplate = solutionDesigner.SelectedItem as CodeTemplateViewModel ?? newSolTpl;
            Assert.AreNotSame(solutionTemplate, newSolTpl, "Couldn't find template!");

            solutionTemplate.TemplateName = "NorthwindSolutionFile";
            solutionTemplate.IsTopLevelTemplate = true;
            solutionTemplate.TemplateOutput = "<%%=Solution.SolutionDirectory%%><%%-\\%%><%%=Solution.OutputSolutionFileName%%>\r\n" +
                                              "<%%:\r\n" +
                                              "    update(Path)\r\n" +
                                              "%%>";
            solutionTemplate.TemplateContent = "<%%-Entities:\r\n" +
                                               "%%><%%:\r\n" +
                                               "foreach(Entity)\r\n" +
                                               "{\r\n" +
                                               "    <%%- - %%><%%=Feature.FeatureName%%><%%--%%><%%=Entity.EntityName%%><%%-\r\n" +
                                               "%%>\r\n" +
                                               "}%%>";
            solutionTemplate.Update();
            solutionVM.TemplatePath = Path.Combine(playground, solutionTemplate.TemplateName + ".mpt");
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            solutionVM.CodeTemplatesFolder.LoadTemplates(solutionVM.Solution);
            
            #endregion create solution template

            #region create spec source
            solutionVM.SpecificationSourcesFolder.ProcessNewDatabaseSourceCommand();

            var newDBSource = new DatabaseSourceViewModel();
            var dbSource = solutionDesigner.SelectedItem as DatabaseSourceViewModel ?? newDBSource;
            Assert.AreNotSame(dbSource, newDBSource, "Couldn't find database source");
            dbSource.DatabaseTypeCode = (int)DatabaseTypeCode.SqlServer;
            dbSource.SourceDbServerName = @"(localdb)\v11.0";
            dbSource.SourceDbName = mDatabaseFileName;
            //dbSource.SourceDbServerName = "nts1";
            //dbSource.SourceDbName = "Hofstede&Essink";
            dbSource.TemplatePath = Path.Combine(gettingStartedPath, @"GettingStarted\Specifications\SQLServer\MDLSqlModel.mps");
            Assert.IsTrue(File.Exists(dbSource.TemplatePath), "File MDLSqlModel.mps not found!");
            dbSource.Order = 1;

            dbSource.Update();
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            solutionVM.SpecTemplatesFolder.LoadSpecTemplates(solution);
            
            #endregion create spec source

            #region load model from database
            //Console.WriteLine("Call LoadSpecificationSource");
            //dbSource.DatabaseSource.LoadSpecificationSource();
            //Assert.IsTrue(dbSource.DatabaseSource.SpecDatabase.SqlTableCount > 0, "No tables found in created database");

            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            using (var resetEvent = new AutoResetEvent(false))
            {
                var updated = new EventHandler((sender, args) =>
                {
                    Console.WriteLine("Solution built!");
                    resetEvent.Set();
                });
                solutionVM.Updated += updated;
                Console.WriteLine("Call BuildSolution");
                solutionVM.BuildSolution(true);
                Assert.IsTrue(resetEvent.WaitOne(EventWaitTimeout), "Timeout waiting for solution update!");
                solutionVM.Updated -= updated;
            }
            #endregion load model from database

            using (var resetEvent = new AutoResetEvent(false))
            {
                var updated = new EventHandler((sender, args) =>
                {
                    Console.WriteLine("Solution updated!");
                    resetEvent.Set();
                });
                solutionVM.Updated += updated;
                solutionVM.UpdateOutputSolution();
                Assert.IsTrue(resetEvent.WaitOne(EventWaitTimeout), "Timeout waiting for solution update!");
                solutionVM.Updated -= updated;
            }
            var expectedOutput = "Entities:\r\n" +
                                 " - Domain-Category\r\n" +
                                 " - Domain-CustomerCustomerDemo\r\n" +
                                 " - Domain-CustomerDemographic\r\n" +
                                 " - Domain-Customer\r\n" +
                                 " - Domain-Employee\r\n" +
                                 " - Domain-EmployeeTerritory\r\n" +
                                 " - Domain-OrderDetail\r\n" +
                                 " - Domain-Order\r\n" +
                                 " - Domain-Product\r\n" +
                                 " - Domain-Region\r\n" +
                                 " - Domain-Shipper\r\n" +
                                 " - Domain-Supplier\r\n" +
                                 " - Domain-Territory\r\n";
            var output = File.ReadAllText(Path.Combine(playground, "TestSolution.sln"));
            Assert.AreEqual(expectedOutput, output);
        }

        private void SolutionOnOutputRequested(object sender, StatusEventArgs args)
        {
            base.OutputChanged(new Events.StatusEventArgs
                               {
                                   AppendText = args.AppendText,
                                   CompletedWork = args.CompletedWork,
                                   IsException=args.IsException,
                                   Progress=args.Progress,
                                   ShowMessageBox=args.ShowMessageBox,
                                   Text=args.Text,
                                   Title=args.Title,
                                   TotalWork = args.TotalWork
                               });
        }
    }
}