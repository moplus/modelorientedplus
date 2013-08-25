using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Solutions;
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
            var solutionVM = ViewModelHelper.NewSolution(builder,
                                             solutionDesigner,
                                             "TestSolution",
                                             "TestNamespace",
                                             "TestSolution.sln",
                                             "TestCompany",
                                             "TestProduct",
                                             "0.1",
                                             Path.Combine(playground, "TestSolution.xml"),
                                             Path.Combine(playground, "NorthwindSolutionFile.mpt"));

            solutionVM.Solution.OutputRequested += SolutionOnOutputRequested;
            
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
            ViewModelHelper.SaveSolution(solutionVM);
            solutionVM.CodeTemplatesFolder.LoadTemplates(solutionVM.Solution);

            #endregion create solution template

            ViewModelHelper.NewDatabaseSource(builder,
                                              solutionDesigner,
                                              solutionVM,
                                              @"(localdb)\v11.0",
                                              mDatabaseFileName,
                                              Path.Combine(gettingStartedPath, @"GettingStarted\Specifications\SQLServer\MDLSqlModel.mps"));

            ViewModelHelper.BuildSolution(solutionVM);

            ViewModelHelper.UpdateOutputSolution(solutionVM);

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