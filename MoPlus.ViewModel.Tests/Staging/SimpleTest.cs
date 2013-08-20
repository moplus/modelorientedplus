using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Solutions;

namespace MoPlus.ViewModel.Tests.Staging
{
    [TestClass]
    public class SimpleTest
    {
        /* This tests creates a simple solution containing 1 feature and 1 entity (forward-engineered). There's 1
         * solution template, which iterates the entities and outputs a simple text file containing - featurename-entityname
         */

        [TestMethod]
        public void DoTest()
        {
            var tempPath = Path.GetTempPath();
            var Playground = Path.Combine(tempPath, "MoPlus-TestRun-" + Guid.NewGuid().ToString());

            if (Directory.Exists(Playground))
            {
                // cleanup potential leftovers
                Directory.Delete(Playground, true);
            }
            Directory.CreateDirectory(Playground);

            var solutionDesigner = new DesignerViewModel();

            solutionDesigner.Mediator.Register(MediatorMessages.Event_OutputChanged, new Action<StatusEventArgs>(OutputChanged));
            solutionDesigner.Mediator.Register(MediatorMessages.Event_StatusChanged, new Action<StatusEventArgs>(StatusChanged));

            var builder = new BuilderViewModel();
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
            solutionVM.SolutionPath = Path.Combine(Playground, "TestSolution.xml");
            solutionVM.TemplatePath = Path.Combine(Playground, "SolutionFile.mpt");
            solutionVM.Update();
            var solution = solutionVM.Solution;
            if (solution == null)
            {
                throw new InvalidOperationException("Couldn't find Solution!");
            }
            solutionVM.UpdateCommand.Execute(null);
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, true);
            //solutionVM.Refresh(true, 3);
            if (solutionVM.CodeTemplatesFolder == null)
            {
                throw new InvalidOperationException("Couldn't find CodeTemplatesFolder");
            }
            solutionVM.CodeTemplatesFolder.ProcessNewCodeTemplateCommand();
            var newSolTpl = new CodeTemplateViewModel();
            var solutionTemplate = solutionDesigner.SelectedItem as CodeTemplateViewModel ?? newSolTpl;
            Assert.AreNotSame(solutionTemplate, newSolTpl, "Couldn't find template!");
        
            solutionTemplate.TemplateName = "SolutionFile";
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

            solutionVM.FeaturesFolder.ProcessNewFeatureCommand();

            var newFeature = new FeatureViewModel();
            var feature = solutionDesigner.SelectedItem as FeatureViewModel ?? newFeature;
            Assert.AreNotSame(feature, newFeature, "Couldn't find feature!");

            feature.Solution = solution;
            feature.FeatureName = "TestFeature";
            feature.UpdateCommand.Execute(null);
            solutionDesigner.ShowItemInTreeView(feature);


            feature.ProcessNewEntityCommand();

            var newEntity = new EntityViewModel();
            var entity = solutionDesigner.SelectedItem as EntityViewModel ?? newEntity;
            Assert.AreNotSame(entity, newEntity, "Couldn't find entity!");

            entity.EntityName = "TestEntity";
            entity.EntityTypeCode = 3; // primary
            entity.IdentifierTypeCode = 1; // generated
            entity.Update();
            entity.LoadEntity(entity.Entity);

            entity.PropertiesFolder.ProcessNewPropertyCommand();

            var newProperty = new PropertyViewModel();
            var property = solutionDesigner.SelectedItem as PropertyViewModel ?? newProperty;
            Assert.AreNotSame(property, newProperty, "Couldn't find Property!");
        
            solutionVM.UpdateCommand.Execute(null);
            solutionVM.SaveSolution();
            using (var resetEvent = new AutoResetEvent(false))
            {
                var updated = new EventHandler((sender, args) =>
                {
                    Console.WriteLine("Solution updated!");
                    resetEvent.Set();
                });
                solutionVM.Updated += updated;
                solutionVM.UpdateOutputSolution();
                Assert.IsTrue(resetEvent.WaitOne(60000), "Timeout waiting for solution update!");
                solutionVM.Updated -= updated;
            }
            var expectedOutput = "Entities:\r\n" +
                                 " - TestFeature-TestEntity\r\n";
            var output = File.ReadAllText(Path.Combine(Playground, "TestSolution.sln"));
            Assert.AreEqual(expectedOutput, output);
            Directory.Delete(Playground, true);
        }

        private void StatusChanged(StatusEventArgs statusEventArgs)
        {
            Console.WriteLine("Status: {0}", statusEventArgs.Text);
        }

        private void OutputChanged(StatusEventArgs statusEventArgs)
        {
            if (statusEventArgs.IsException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            try
            {
                Console.WriteLine("{0}: {1}", statusEventArgs.Title, statusEventArgs.Text);
            }
            finally
            {
                if (statusEventArgs.IsException)
                {
                    Console.ResetColor();
                }
            }
        }
    }
}
