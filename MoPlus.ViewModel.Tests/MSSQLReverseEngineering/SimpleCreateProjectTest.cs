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
    public class SimpleCreateProjectTest: BaseTest
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
            var gettingStartedPath = Path.Combine(playground, "Pack");
            Directory.CreateDirectory(gettingStartedPath);

            // unpack sapmle pack to <Playground>\GettingStartedPack
            SamplePacksUtility.ExtractSampleCSharpSQLServerXmlTo(gettingStartedPath);
            var templateBaseDir = Path.Combine(playground, "Pack", "Sample_CSharp_SQLServer_MySQL_Xml", "Templates", "CSharp_VS2010");

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
            solutionVM.TemplatePath = Path.Combine(templateBaseDir, "SolutionFile.mpt");
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
            dbSource.TemplatePath = Path.Combine(gettingStartedPath, @"Sample_CSharp_SQLServer_MySQL_Xml\Specifications\SQLServer\MDLSqlModel.mps");
            Assert.IsTrue(File.Exists(dbSource.TemplatePath), "File MDLSqlModel.mps not found!");
            dbSource.Order = 1;

            dbSource.Update();
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            solutionVM.SpecTemplatesFolder.LoadSpecTemplates(solution);
            
            #endregion create spec source

            #region load model from database
            
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

            #region generate EF BLL project

            solutionVM.ProjectsFolder.ProcessNewProjectCommand();
            var newProject = new ProjectViewModel();
            var project = solutionDesigner.SelectedItem as ProjectViewModel ?? newProject;
            Assert.AreNotSame(project, newProject, "Couldn't find project");
            project.Name = "EFBLL";
            project.Namespace = "EFBLL";
            project.TemplatePath = Path.Combine(templateBaseDir, "EntityFramework.mpt");
            project.Tags = "BLL";
            Assert.IsTrue(project.IsValid, "EFBLL project has errors!");
            
            project.Update();
            
            solutionVM.Update();
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            solutionVM.ProjectsFolder.LoadProjects(solution);
            
            #endregion generate EF BLL project

            // generate project: 
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
            Assert.IsTrue(File.Exists(Path.Combine(playground, "TestSolution.sln")), "Solution file has not been created!");

            MSBuildUtility.Execute(Path.Combine(playground, "TestSolution.sln"),
                                   multiThreaded: true);
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