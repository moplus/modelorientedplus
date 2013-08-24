using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Interpreter;
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

            Solution solution;
            var solutionVM = ViewModelHelper.NewSolution(builder,
                                                         solutionDesigner,
                                                         "TestSolution",
                                                         "TestNamespace",
                                                         "TestSolution.sln",
                                                         "TestCompany",
                                                         "TestProduct",
                                                         "0.1",
                                                         Path.Combine(playground, "TestSolution.xml"),
                                                         Path.Combine(templateBaseDir, "SolutionFile.mpt"),
                                                         out solution);
            
            solution.OutputRequested += SolutionOnOutputRequested;

            ViewModelHelper.NewDatabaseSource(builder,
                                              solutionDesigner,
                                              solutionVM,
                                              solution,
                                              @"(localdb)\v11.0",
                                              mDatabaseFileName,
                                              Path.Combine(gettingStartedPath, @"Sample_CSharp_SQLServer_MySQL_Xml\Specifications\SQLServer\MDLSqlModel.mps"));
            
            ViewModelHelper.BuildSolution(solutionVM, solution);

            ViewModelHelper.CreateNewProject(solutionVM,
                                             solutionDesigner,
                                             solution,
                                             "EFBLL",
                                             "EFBLL",
                                             Path.Combine(templateBaseDir, "Project", "EntityFramework.mpt"),
                                             null);

            ViewModelHelper.UpdateOutputSolution(solutionVM);

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