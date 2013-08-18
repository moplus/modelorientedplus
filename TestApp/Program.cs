using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Solutions;

namespace TestApp
{
    public class Program
    {
        private const string Playground = @"e:\OpenSource\MoPlusPlayground";
        static void Main(string[] args)
        {
            new Program().Execute();
        }

        private void Execute()
        {
            Directory.Delete(Playground, true);
            Directory.CreateDirectory(Playground);
            var solutionDesigner = new DesignerViewModel();
            solutionDesigner.Mediator.Register(MediatorMessages.Event_OutputChanged, new Action<StatusEventArgs>(OutputChanged));
            var treeViewModel = new BuilderViewModel();
            treeViewModel.ProcessNewCommand(treeViewModel.SolutionsFolder);
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
            var solution = solutionVM.EditSolution;
            if (solution == null)
            {
                throw new InvalidOperationException("Couldn't find Solution!");
            }
            solutionVM.SaveSolution();
            solutionVM.LoadSolution(solution, false, true);
            if (solutionVM.CodeTemplatesFolder == null)
            {
                throw new InvalidOperationException("Couldn't find CodeTemplatesFolder");
            }
            solutionVM.CodeTemplatesFolder.ProcessNewCodeTemplateCommand();
            var newSolTpl = new CodeTemplateViewModel();
            var solutionTemplate = solutionDesigner.SelectedItem as CodeTemplateViewModel ?? newSolTpl;
            if (object.ReferenceEquals(solutionTemplate, newSolTpl))
            {
                throw new InvalidOperationException("Couldn't find template!");
            }
            solutionTemplate.TemplateName = "SolutionFile";
            solutionTemplate.IsTopLevelTemplate = true;
            solutionTemplate.TemplateOutput = @"<%%=Solution.SolutionDirectory%%><%%-\%%><%%=Solution.OutputSolutionFileName%%>
<%%:
    update(Path)
%%>";
            solutionTemplate.TemplateContent= @"<%%-Entities:
%%><%%:
foreach(Entity)
{
    <%%=- Entity.EntityName%%><%%-
%%>
}%%>";
            solutionTemplate.Update();

            solutionVM.FeaturesFolder.ProcessNewFeatureCommand();

            var newFeature = new FeatureViewModel();
            var feature = solutionDesigner.SelectedItem as FeatureViewModel ?? newFeature;
            if (object.ReferenceEquals(feature, newFeature))
            {
                throw new InvalidOperationException("Couldn't find feature!");
            }
            feature.Solution = solution;
            feature.FeatureName = "TestFeature";
            feature.Update();
            feature.Feature.Save();
            
            feature.ProcessNewEntityCommand();

            //var newEntity = new EntityViewModel();
            //var entity = solutionDesigner.SelectedItem as EntityViewModel ?? newEntity;
            //if (object.ReferenceEquals(entity, newEntity))
            //{
            //    throw new InvalidOperationException("Couldn't find entity!");
            //}
            //entity.EntityName = "TestEntity";
            //entity.EntityTypeCode = 3; // primary
            //entity.IdentifierTypeCode = 1; // generated
            //entity.Update();
            //entity.LoadEntity(entity.Entity);

            //entity.PropertiesFolder.ProcessNewPropertyCommand();

            //var newProperty = new PropertyViewModel();
            //var property = solutionDesigner.SelectedItem as PropertyViewModel ?? newProperty;
            //if (object.ReferenceEquals(property, newProperty))
            //{
            //    throw new InvalidOperationException("Couldn't find Property!");
            //}




            solutionVM.SaveSolution();



            Console.Write("");
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