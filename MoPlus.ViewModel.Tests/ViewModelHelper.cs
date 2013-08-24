using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Tests.Staging;

namespace MoPlus.ViewModel.Tests
{
    /// <summary>
    /// Helper class which makes it easier to make tests. Some methods do "magic" for making async methods sync, etc.
    /// </summary>
    public static class ViewModelHelper
    {
        public static void SaveSolution(SolutionViewModel solutionVM, Solution solution)
        {
            if (solutionVM == null)
            {
                throw new ArgumentNullException("solutionVM");
            }

            //var solution = solutionVM.Solution;
            Assert.IsNotNull(solution, "Couldn't find Solution!");

            //solutionVM.UpdateCommand.Execute(null);
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
        }

        public static SolutionViewModel NewSolution(BuilderViewModel builder, DesignerViewModel designer, string solutionName, string solutionNamespace, string outputFilename, string company, string product, string version, 
            string solutionPath, string templatePath, out Solution solution)
        {
            builder.ProcessNewCommand(builder.SolutionsFolder);
            var solutionVM = designer.SelectedItem as SolutionViewModel;
            Assert.IsNotNull(solutionVM, "Couldn't find SolutionViewModel");
            
            solutionVM.SolutionName = solutionName;
            solutionVM.Namespace = solutionNamespace;
            solutionVM.OutputSolutionFileName = outputFilename;
            solutionVM.CompanyName = company;
            solutionVM.ProductName = product;
            solutionVM.ProductVersion = version;
            solutionVM.SolutionPath = solutionPath;
            solutionVM.TemplatePath = templatePath;
            solutionVM.Update();
            solution = solutionVM.Solution;
            SaveSolution(solutionVM, solution);
            return solutionVM;
        }

        public static void NewDatabaseSource(BuilderViewModel builder, DesignerViewModel designer, SolutionViewModel solutionVM, Solution solution, string serverName, string databaseName, string templatePath)
        {
            solutionVM.SpecificationSourcesFolder.ProcessNewDatabaseSourceCommand();

            var newDBSource = new DatabaseSourceViewModel();
            var dbSource = designer.SelectedItem as DatabaseSourceViewModel ?? newDBSource;
            Assert.AreNotSame(dbSource, newDBSource, "Couldn't find database source");
            dbSource.DatabaseTypeCode = (int)DatabaseTypeCode.SqlServer;
            dbSource.SourceDbServerName = serverName;
            dbSource.SourceDbName = databaseName;
            dbSource.TemplatePath = templatePath;
            Assert.IsTrue(File.Exists(dbSource.TemplatePath), "Solution template not found!");
            dbSource.Order = 1;

            dbSource.Update();
            solutionVM.Update();
            SaveSolution(solutionVM, solution);
            solutionVM.SpecTemplatesFolder.LoadSpecTemplates(solution);
        }

        public static void CreateNewProject(SolutionViewModel solutionVM, DesignerViewModel solutionDesigner, Solution solution, string projectName, string projectNamespace, string templateFilename, string tags)
        {
            solutionVM.ProjectsFolder.ProcessNewProjectCommand();
            var newProject = new ProjectViewModel();
            var project = solutionDesigner.SelectedItem as ProjectViewModel ?? newProject;
            Assert.AreNotSame(project, newProject, "Couldn't find project");
            project.Name = projectName;
            project.Namespace = projectNamespace;
            project.TemplatePath = templateFilename;
            project.Tags = tags;
            Assert.IsTrue(project.IsValid, "Project has errors!");
            project.Update();

            SaveSolution(solutionVM, solution);
            solutionVM.ProjectsFolder.LoadProjects(solution);
        }

        public static void BuildSolution(SolutionViewModel solutionVM, Solution solution)
        {
            SaveSolution(solutionVM, solution);
            using (var resetEvent = new AutoResetEvent(false))
            {
                var updated = new EventHandler((sender, args) =>
                                               {
                                                   Console.WriteLine("Solution built!");
                                                   resetEvent.Set();
                                               });
                solutionVM.Updated += updated;
                //Console.WriteLine("Call BuildSolution");
                solutionVM.BuildSolution(true);
                Assert.IsTrue(resetEvent.WaitOne(BaseTest.EventWaitTimeout), "Timeout waiting for solution update!");
                solutionVM.Updated -= updated;
            }
            //SaveSolution(solutionVM);
        }

        public static void UpdateOutputSolution(SolutionViewModel solutionVM)
        {
            using (var resetEvent = new AutoResetEvent(false))
            {
                var updated = new EventHandler((sender, args) =>
                                               {
                                                   Console.WriteLine("Solution updated!");
                                                   resetEvent.Set();
                                               });
                solutionVM.Updated += updated;
                solutionVM.UpdateOutputSolution();
                Assert.IsTrue(resetEvent.WaitOne(BaseTest.EventWaitTimeout), "Timeout waiting for solution update!");
                solutionVM.Updated -= updated;
            }
        }
    }
}