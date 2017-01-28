/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.ViewModel.Conventions
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for overall resources.</summary>
     ///--------------------------------------------------------------------------------
    public class ResourcesViewModel : WorkspaceViewModel
    {
        #region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets AboutHelp.</summary>
		///--------------------------------------------------------------------------------
		public HelpViewModel AboutHelp { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets GettingStartedHelp.</summary>
		///--------------------------------------------------------------------------------
		public HelpViewModel GettingStartedHelp { get; set; }
		#endregion "Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			HasErrors = !IsValid;
			HasCustomizations = false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads help content.</summary>
		///--------------------------------------------------------------------------------
		public void LoadHelp()
		{
			LoadGettingStartedHelp();
			LoadHowItWorksHelp();
			LoadUIReferenceHelp();
			LoadModelReferenceHelp();
			LoadLanguageReferenceHelp();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method shows the about help page.</summary>
		///--------------------------------------------------------------------------------
		public void ShowAboutHelp()
		{
			ShowHelp(AboutHelp);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method shows the getting started help page.</summary>
		///--------------------------------------------------------------------------------
		public void ShowGettingStartedHelp()
		{
			ShowHelp(GettingStartedHelp);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method shows a help page.</summary>
		///--------------------------------------------------------------------------------
		public void ShowHelp(HelpViewModel help)
		{
			help.IsSelected = true;
			help.ProcessShowHelpCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads getting started help content.</summary>
		///--------------------------------------------------------------------------------
		public void LoadGettingStartedHelp()
		{
			HelpViewModel help = null;
			HelpViewModel helpSub = null;
			HelpViewModel helpSubSub = null;

			// create getting started help and show it
			help = new HelpViewModel(DisplayValues.Help_StartupHeader, DisplayValues.Help_StartupParagraph1, DisplayValues.Help_StartupParagraph2, DisplayValues.Help_StartupParagraph3);
			Items.Add(help);
			GettingStartedHelp = help;
			ShowGettingStartedHelp();

			// add what is Mo+ subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupWhatIsMoPlusHeader, DisplayValues.Help_StartupWhatIsMoPlusParagraph1, null, null, null, null, null, DisplayValues.Product);
			help.Items.Add(helpSub);

			// add what is Mo+ model subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupWhatIsMoPlusModelHeader, DisplayValues.Help_StartupWhatIsMoPlusModelParagraph1, DisplayValues.Help_StartupWhatIsMoPlusModelParagraph2, null, null, null, null, DisplayValues.MoPlusModel);
			help.Items.Add(helpSub);

			// add what is Mo+ Solution Builder subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupWhatIsMoPlusSolutionBuildeHeader, DisplayValues.Help_StartupWhatIsMoPlusSolutionBuilderParagraph1, DisplayValues.Help_StartupWhatIsMoPlusSolutionBuilderParagraph2, null, null, null, null, DisplayValues.MoPlusUI);
			help.Items.Add(helpSub);

			// add tutorial subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupTutorialHeader, DisplayValues.Help_StartupTutorialParagraph1, null, null, null, null, null, DisplayValues.Product);
			help.Items.Add(helpSub);

			// add ongoing materials subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupResourcesHeader, DisplayValues.Help_StartupResourcesParagraph1, null, null, null, null, null, DisplayValues.Product);
			help.Items.Add(helpSub);

			// add working with templates subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupWorkingWithTemplatesHeader, DisplayValues.Help_StartupWorkingWithTemplatesParagraph1, null, null, null, null, null, DisplayValues.Product);
			help.Items.Add(helpSub);

			// add frequently asked questions subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupFAQHeader, DisplayValues.Help_StartupFAQParagraph1, null, null, null, null, null, DisplayValues.Product);
			help.Items.Add(helpSub);

			// add FAQ templates sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_StartupFAQTemplatesHeader, DisplayValues.Help_StartupFAQTemplatesParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add about Mo+ Solution Builder subsection
			helpSub = new HelpViewModel(DisplayValues.Help_StartupAboutMoPlusSolutionBuildeHeader, DisplayValues.Help_StartupAboutMoPlusSolutionBuilderParagraph1, null, null, null, null, null, DisplayValues.Product);
			help.Items.Add(helpSub);
			AboutHelp = helpSub;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads how it works help content.</summary>
		///--------------------------------------------------------------------------------
		public void LoadHowItWorksHelp()
		{
			HelpViewModel help = null;
			HelpViewModel helpSub = null;

			// add How It Works Section
			help = new HelpViewModel(DisplayValues.Help_HowItWorksHeader, DisplayValues.Help_HowItWorksParagraph1, DisplayValues.Help_HowItWorksParagraph2, null, null, null, null, DisplayValues.MoPlusWorkflow);
			Items.Add(help);

			// add creating a model from scratch subsection
			helpSub = new HelpViewModel(DisplayValues.Help_HowItWorksCreateModelHeader, DisplayValues.Help_HowItWorksCreateModelParagraph1, null, null, null, null, null, DisplayValues.CreateModel);
			help.Items.Add(helpSub);

			// add loading a model subsection
			helpSub = new HelpViewModel(DisplayValues.Help_HowItWorksLoadModelHeader, DisplayValues.Help_HowItWorksLoadModelParagraph1, null, null, null, null, null, DisplayValues.LoadModel);
			help.Items.Add(helpSub);

			// add create code subsection
			helpSub = new HelpViewModel(DisplayValues.Help_HowItWorksCreateCodelHeader, DisplayValues.Help_HowItWorksCreateCodelParagraph1, null, null, null, null, null, DisplayValues.CreateCode);
			help.Items.Add(helpSub);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads UI reference help content.</summary>
		///--------------------------------------------------------------------------------
		public void LoadUIReferenceHelp()
		{
			HelpViewModel help = null;
			HelpViewModel helpSub = null;
			HelpViewModel helpSubSub = null;

			// add UI Reference Section
			help = new HelpViewModel(DisplayValues.Help_UIReferenceHeader, DisplayValues.Help_UIReferenceParagraph1, DisplayValues.Help_UIReferenceParagraph2, null, null, null, null, DisplayValues.MoPlusUI);
			Items.Add(help);

			// add UI Reference Solution Builder Window subsection
			helpSub = new HelpViewModel(DisplayValues.Help_UIReferenceTreeViewHeader, DisplayValues.Help_UIReferenceTreeViewParagraph1, DisplayValues.Help_UIReferenceTreeViewParagraph2, null, null, null, null, DisplayValues.SolutionBuilderTreeView);
			help.Items.Add(helpSub);

			// add UI Reference Solutions Node sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceSolutionsNodeHeader, DisplayValues.Help_UIReferenceSolutionsNodeParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Solution Node sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceSolutionNodeHeader, DisplayValues.Help_UIReferenceSolutionNodeParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Other Nodea sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceOtherNodesHeader, DisplayValues.Help_UIReferenceOtherNodesParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Solution Designer Window subsection
			helpSub = new HelpViewModel(DisplayValues.Help_UIReferenceSolutionDesignerHeader, DisplayValues.Help_UIReferenceSolutionDesignerParagraph1, DisplayValues.Help_UIReferenceSolutionDesignerParagraph2, null, null, null, null, DisplayValues.MoPlusSolutionDesignerWindow);
			help.Items.Add(helpSub);

			// add UI Reference Edit Item sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceEditItemHeader, DisplayValues.Help_UIReferenceEditItemParagraph1, DisplayValues.Help_UIReferenceEditItemParagraph2, null, null, null, null, DisplayValues.MoPlusEditItem);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Diagramming sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceDiagrammingHeader, DisplayValues.Help_UIReferenceDiagrammingParagraph1, DisplayValues.Help_UIReferenceDiagrammingParagraph2, null, null, null, null, DisplayValues.MoPlusDiagram);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Status and Output subsection
			helpSub = new HelpViewModel(DisplayValues.Help_UIReferenceStatusOutputHeader, DisplayValues.Help_UIReferenceStatusOutputParagraph1);
			help.Items.Add(helpSub);

			// add UI Reference Templates subsection
			helpSub = new HelpViewModel(DisplayValues.Help_UIReferenceTemplatesHeader, DisplayValues.Help_UIReferenceTemplatesParagraph1, DisplayValues.Help_UIReferenceTemplatesParagraph2, null, null, null, null, DisplayValues.MoPlusDebugWindow);
			help.Items.Add(helpSub);

			// add UI Reference Code Templates sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceTemplatesCodeHeader, DisplayValues.Help_UIReferenceTemplatesCodeParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Spec Templates sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceTemplatesSpecHeader, DisplayValues.Help_UIReferenceTemplatesSpecParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Editing Templates sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceTemplatesEditingHeader, DisplayValues.Help_UIReferenceTemplatesEditingParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference Debugging Templates sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_UIReferenceTemplatesDebuggingHeader, DisplayValues.Help_UIReferenceTemplatesDebuggingParagraph1, DisplayValues.Help_UIReferenceTemplatesDebuggingParagraph2, null, null, null, null, DisplayValues.MoPlusDebugWindow);
			helpSub.Items.Add(helpSubSub);

			// add UI Reference drag drop copy paste subsection
			helpSub = new HelpViewModel(DisplayValues.Help_UIReferenceDragDropHeader, DisplayValues.Help_UIReferenceDragDropParagraph1);
			help.Items.Add(helpSub);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads model reference help content.</summary>
		///--------------------------------------------------------------------------------
		public void LoadModelReferenceHelp()
		{
			HelpViewModel help = null;
			HelpViewModel helpSub = null;
			HelpViewModel helpSubSub = null;

			// add Model Reference Section
			help = new HelpViewModel(DisplayValues.Help_ModelReferenceHeader, DisplayValues.Help_ModelReferenceParagraph1);
			Items.Add(help);

			// add Model Reference model elements subsection
			helpSub = new HelpViewModel(DisplayValues.Help_ModelReferenceModelElementsHeader, DisplayValues.Help_ModelReferenceModelElementsParagraph1, DisplayValues.Help_ModelReferenceModelElementsParagraph2, null, null, null, null, DisplayValues.ModelElements);
			help.Items.Add(helpSub);

			// add Model Reference AuditProperty model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.AuditProperty.ToString(), DisplayValues.Help_ModelReferenceModelElementAuditPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Collection model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Collection.ToString(), DisplayValues.Help_ModelReferenceModelElementCollectionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Entity model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Entity.ToString(), DisplayValues.Help_ModelReferenceModelElementEntityParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference EntityReference model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.EntityReference.ToString(), DisplayValues.Help_ModelReferenceModelElementEntityReferenceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Enumeration model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Enumeration.ToString(), DisplayValues.Help_ModelReferenceModelElementEnumerationParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Feature model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Feature.ToString(), DisplayValues.Help_ModelReferenceModelElementFeatureParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Index model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Index.ToString(), DisplayValues.Help_ModelReferenceModelElementIndexParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference IndexProperty model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.IndexProperty.ToString(), DisplayValues.Help_ModelReferenceModelElementIndexPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Method model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Method.ToString(), DisplayValues.Help_ModelReferenceModelElementMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference MethodRelationship model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.MethodRelationship.ToString(), DisplayValues.Help_ModelReferenceModelElementMethodRelationshipParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Model model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Model.ToString(), DisplayValues.Help_ModelReferenceModelElementModelParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference ModelObject model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.ModelObject.ToString(), DisplayValues.Help_ModelReferenceModelElementModelObjectParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference ModelProperty model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.ModelProperty.ToString(), DisplayValues.Help_ModelReferenceModelElementModelPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference ObjectInstance model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.ObjectInstance.ToString(), DisplayValues.Help_ModelReferenceModelElementObjectInstanceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Parameter model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Parameter.ToString(), DisplayValues.Help_ModelReferenceModelElementParameterParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Project model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Project.ToString(), DisplayValues.Help_ModelReferenceModelElementProjectParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Property model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Property.ToString(), DisplayValues.Help_ModelReferenceModelElementPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference PropertyInstance model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.PropertyInstance.ToString(), DisplayValues.Help_ModelReferenceModelElementPropertyInstanceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference PropertyReference model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.PropertyReference.ToString(), DisplayValues.Help_ModelReferenceModelElementPropertyReferenceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference PropertyRelationship model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.PropertyRelationship.ToString(), DisplayValues.Help_ModelReferenceModelElementPropertyRelationshipParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Relationship model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Relationship.ToString(), DisplayValues.Help_ModelReferenceModelElementRelationshipParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference RelationshipProperty model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.RelationshipProperty.ToString(), DisplayValues.Help_ModelReferenceModelElementRelationshipPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Solution model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Solution.ToString(), DisplayValues.Help_ModelReferenceModelElementSolutionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Stage model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Stage.ToString(), DisplayValues.Help_ModelReferenceModelElementStageParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference StageTransition model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.StageTransition.ToString(), DisplayValues.Help_ModelReferenceModelElementStageTransitionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference State model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.State.ToString(), DisplayValues.Help_ModelReferenceModelElementStateParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference StateModel model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.StateModel.ToString(), DisplayValues.Help_ModelReferenceModelElementStateModelParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference StateTransition model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.StateTransition.ToString(), DisplayValues.Help_ModelReferenceModelElementStateTransitionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Step model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Step.ToString(), DisplayValues.Help_ModelReferenceModelElementStepParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference StepTransition model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.StepTransition.ToString(), DisplayValues.Help_ModelReferenceModelElementStepTransitionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Tag model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Tag.ToString(), DisplayValues.Help_ModelReferenceModelElementTagParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Value model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Value.ToString(), DisplayValues.Help_ModelReferenceModelElementValueParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference View model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.View.ToString(), DisplayValues.Help_ModelReferenceModelElementViewParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference ViewProperty model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.ViewProperty.ToString(), DisplayValues.Help_ModelReferenceModelElementViewPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference Workflow model element sub subsection
			helpSubSub = new HelpViewModel(ModelContextTypeCode.Workflow.ToString(), DisplayValues.Help_ModelReferenceModelElementWorkflowParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference spec elements subsection
			helpSub = new HelpViewModel(DisplayValues.Help_ModelReferenceSpecElementsHeader, DisplayValues.Help_ModelReferenceSpecElementsParagraph1, DisplayValues.Help_ModelReferenceSpecElementsParagraph2, null, null, null, null, DisplayValues.SpecificationElements);
			help.Items.Add(helpSub);

			// add Model Reference SpecificationSource spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SpecificationSource.ToString(), DisplayValues.Help_ModelReferenceSpecElementSpecificationSourceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlColumn spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlColumn.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlColumnParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlDatabase spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlDatabase.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlDatabaseParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlExtendedProperty spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlExtendedProperty.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlExtendedPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlForeignKey spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlForeignKey.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlForeignKeyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlForeignKeyColumn spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlForeignKeyColumn.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlForeignKeyColumnParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlIndex spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlIndex.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlIndexParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlIndexedColumn spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlIndexedColumn.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlIndexedColumnParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlProperty spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlProperty.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlTable spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlTable.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlTableParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlView spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlView.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlViewParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference SqlViewProperty spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.SqlViewProperty.ToString(), DisplayValues.Help_ModelReferenceSpecElementSqlViewPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference XmlAttribute spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.XmlAttribute.ToString(), DisplayValues.Help_ModelReferenceSpecElementXmlAttributeParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference XmlDocument spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.XmlDocument.ToString(), DisplayValues.Help_ModelReferenceSpecElementXmlDocumentParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Model Reference XmlNode spec element sub subsection
			helpSubSub = new HelpViewModel(SpecModelContextTypeCode.XmlNode.ToString(), DisplayValues.Help_ModelReferenceSpecElementXmlNodeParagraph1);
			helpSub.Items.Add(helpSubSub);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads language reference help content.</summary>
		///--------------------------------------------------------------------------------
		public void LoadLanguageReferenceHelp()
		{
			HelpViewModel help = null;
			HelpViewModel helpSub = null;
			HelpViewModel helpSubSub = null;

			// add Language Reference Section
			help = new HelpViewModel(DisplayValues.Help_LanguageReferenceHeader, DisplayValues.Help_LanguageReferenceParagraph1);
			Items.Add(help);

			// add Language Reference features subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceFeaturesHeader, DisplayValues.Help_LanguageReferenceFeaturesParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference features OO sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceFeaturesOOHeader, DisplayValues.Help_LanguageReferenceFeaturesOOParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference features model context sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceFeaturesModelContextHeader, DisplayValues.Help_LanguageReferenceFeaturesModelContextParagraph1, DisplayValues.Help_LanguageReferenceFeaturesModelContextParagraph2, null, null, null, null, DisplayValues.ModelContext);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference features models and code sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceFeaturesModelsAndCodeHeader, DisplayValues.Help_LanguageReferenceFeaturesModelsAndCodeParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference templates subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTemplatesHeader, DisplayValues.Help_LanguageReferenceTemplatesParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference templates types sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTemplatesTypesHeader, DisplayValues.Help_LanguageReferenceTemplatesTypesParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference templates sections sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTemplatesSectionsHeader, DisplayValues.Help_LanguageReferenceTemplatesSectionsParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference templates calling sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTemplatesCallingHeader, DisplayValues.Help_LanguageReferenceTemplatesCallingParagraph1, DisplayValues.Help_LanguageReferenceTemplatesCallingParagraph2, null, null, null, null, DisplayValues.TemplateCalls);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference templates code workflow sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTemplatesCodeWorkflowHeader, DisplayValues.Help_LanguageReferenceTemplatesCodeWorkflowParagraph1, DisplayValues.Help_LanguageReferenceTemplatesCodeWorkflowParagraph2, null, null, null, null, DisplayValues.CreateCode);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference templates spec workflow sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTemplatesSpecWorkflowHeader, DisplayValues.Help_LanguageReferenceTemplatesSpecWorkflowParagraph1, DisplayValues.Help_LanguageReferenceTemplatesSpecWorkflowParagraph2, null, null, null, null, DisplayValues.LoadModel);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference tags subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTagsHeader, DisplayValues.Help_LanguageReferenceTagsParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference tags evaluation sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTagsEvaluationHeader, DisplayValues.Help_LanguageReferenceTagsEvaluationParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference tags text sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTagsTextHeader, DisplayValues.Help_LanguageReferenceTagsTextParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference tags property sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTagsPropertyHeader, DisplayValues.Help_LanguageReferenceTagsPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference tags output sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceTagsOutputHeader, DisplayValues.Help_LanguageReferenceTagsOutputParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceStatementsHeader, DisplayValues.Help_LanguageReferenceStatementsParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference statements AddTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.AddTerm, DisplayValues.Help_LanguageReferenceStatementsAddTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements BreakTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.BreakTerm, DisplayValues.Help_LanguageReferenceStatementsBreakTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ClearTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ClearTerm, DisplayValues.Help_LanguageReferenceStatementsClearTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ContinueTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ContinueTerm, DisplayValues.Help_LanguageReferenceStatementsContinueTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements DeleteTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.DeleteTerm, DisplayValues.Help_LanguageReferenceStatementsDeleteTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ForeachTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ForeachTerm, DisplayValues.Help_LanguageReferenceStatementsForeachTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ForfilesTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ForfilesTerm, DisplayValues.Help_LanguageReferenceStatementsForfilesTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements IfTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.IfTerm, DisplayValues.Help_LanguageReferenceStatementsIfTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements InsertTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.InsertTerm, DisplayValues.Help_LanguageReferenceStatementsInsertTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements LogTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.LogTerm, DisplayValues.Help_LanguageReferenceStatementsLogTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ParamTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ParamTerm, DisplayValues.Help_LanguageReferenceStatementsParamTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ProgressTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ProgressTerm, DisplayValues.Help_LanguageReferenceStatementsProgressTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements RemoveTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.RemoveTerm, DisplayValues.Help_LanguageReferenceStatementsRemoveTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements ReturnTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ReturnTerm, DisplayValues.Help_LanguageReferenceStatementsReturnTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements SwitchTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.SwitchTerm, DisplayValues.Help_LanguageReferenceStatementsSwitchTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements TraceTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.TraceTerm, DisplayValues.Help_LanguageReferenceStatementsTraceTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements UpdateTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.UpdateTerm, DisplayValues.Help_LanguageReferenceStatementsUpdateTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements VarTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.VarTerm, DisplayValues.Help_LanguageReferenceStatementsVarTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements WhileTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.WhileTerm, DisplayValues.Help_LanguageReferenceStatementsWhileTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference statements WithTerm sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.WithTerm, DisplayValues.Help_LanguageReferenceStatementsWithTermParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference operators subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceOperatorsHeader, DisplayValues.Help_LanguageReferenceOperatorsParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference operators assignment sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceOperatorsAssignmentHeader, DisplayValues.Help_LanguageReferenceOperatorsAssignmentParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference operators relational sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceOperatorsRelationalHeader, DisplayValues.Help_LanguageReferenceOperatorsRelationalParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference operators arithmetic sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceOperatorsArithmeticHeader, DisplayValues.Help_LanguageReferenceOperatorsArithmeticParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference operators logical sub subsection
			helpSubSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceOperatorsLogicalHeader, DisplayValues.Help_LanguageReferenceOperatorsLogicalParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceFunctionsHeader, DisplayValues.Help_LanguageReferenceFunctionsParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference functions StringCamelCase sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringCamelCase, DisplayValues.Help_LanguageReferenceFunctionsStringCamelCaseParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringCapitalCase sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringCapitalCase, DisplayValues.Help_LanguageReferenceFunctionsStringCapitalCaseParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringCapitalWordCase sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringCapitalWordCase, DisplayValues.Help_LanguageReferenceFunctionsStringCapitalWordCaseParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions ColumnMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ColumnMethod, DisplayValues.Help_LanguageReferenceFunctionsColumnMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringContains sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringContains, DisplayValues.Help_LanguageReferenceFunctionsStringContainsParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringEndsWith sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringEndsWith, DisplayValues.Help_LanguageReferenceFunctionsStringEndsWithParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions FileMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.FileMethod, DisplayValues.Help_LanguageReferenceFunctionsFileMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions FileExistsMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.FileExistsMethod, DisplayValues.Help_LanguageReferenceFunctionsFileExistsMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringFilter sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringFilter, DisplayValues.Help_LanguageReferenceFunctionsStringFilterParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringFilterIgnored sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringFilterIgnored, DisplayValues.Help_LanguageReferenceFunctionsStringFilterIgnoredParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringFilterProtected sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringFilterProtected, DisplayValues.Help_LanguageReferenceFunctionsStringFilterProtectedParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions FindAllMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.FindAllMethod, DisplayValues.Help_LanguageReferenceFunctionsFindAllMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions FindMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.FindMethod, DisplayValues.Help_LanguageReferenceFunctionsFindMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringIndexOf sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringIndexOf, DisplayValues.Help_LanguageReferenceFunctionsStringIndexOfParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions LogMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.LogMethod, DisplayValues.Help_LanguageReferenceFunctionsLogMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringRegexIsMatch sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringRegexIsMatch, DisplayValues.Help_LanguageReferenceFunctionsStringRegexIsMatchParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringRegexReplace sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringRegexReplace, DisplayValues.Help_LanguageReferenceFunctionsStringRegexReplaceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringReplace sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringReplace, DisplayValues.Help_LanguageReferenceFunctionsStringReplaceParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringStartsWith sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringStartsWith, DisplayValues.Help_LanguageReferenceFunctionsStringStartsWithParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringSubstring sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringSubstring, DisplayValues.Help_LanguageReferenceFunctionsStringSubstringParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringToLower sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringToLower, DisplayValues.Help_LanguageReferenceFunctionsStringToLowerParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringToUpper sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringToUpper, DisplayValues.Help_LanguageReferenceFunctionsStringToUpperParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringTrim sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringTrim, DisplayValues.Help_LanguageReferenceFunctionsStringTrimParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringTrimEnd sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringTrimEnd, DisplayValues.Help_LanguageReferenceFunctionsStringTrimEndParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringTrimStart sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringTrimStart, DisplayValues.Help_LanguageReferenceFunctionsStringTrimStartParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference functions StringUnderscoreCase sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.StringUnderscoreCase, DisplayValues.Help_LanguageReferenceFunctionsStringUnderscoreCaseParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceConfigurationPropertiesHeader, DisplayValues.Help_LanguageReferenceConfigurationPropertiesParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference configuration properties IgnoredAreaEndMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.IgnoredAreaEndMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesIgnoredAreaEndMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties IgnoredAreaStartMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.IgnoredAreaStartMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesIgnoredAreaStartMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties NowMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.NowMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesNowMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties ProtectedAreaEndMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ProtectedAreaEndMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesProtectedAreaEndMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties ProtectedAreaStartMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ProtectedAreaStartMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesProtectedAreaStartMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties TabMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.TabMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesTabMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties TabStringMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.TabStringMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesTabStringMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties UseIgnoredAreasMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.UseIgnoredAreasMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesUseIgnoredAreasMethodaragraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties UseProtectedAreasMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.UseProtectedAreasMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesUseProtectedAreasMethodaragraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties UserMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.UserMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesUserMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference configuration properties UseTabsMethod sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.UseTabsMethod, DisplayValues.Help_LanguageReferenceConfigurationPropertiesUseTabsMethodParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties subsection
			helpSub = new HelpViewModel(DisplayValues.Help_LanguageReferenceSpecialPropertiesHeader, DisplayValues.Help_LanguageReferenceSpecialPropertiesParagraph1);
			help.Items.Add(helpSub);

			// add Language Reference special properties GetBaseAndEntitiesCollection sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.GetBaseAndEntitiesCollection, DisplayValues.Help_LanguageReferenceSpecialPropertiesGetBaseAndEntitiesCollectionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties GetEntityAndBasesCollection sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.GetEntityAndBasesCollection, DisplayValues.Help_LanguageReferenceSpecialPropertiesGetEntityAndBasesCollectionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties ExtendingEntitiesCollection sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ExtendingEntitiesCollection, DisplayValues.Help_LanguageReferenceSpecialPropertiesExtendingEntitiesCollectionParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties ItemFileProperty sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ItemFileProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesItemFilePropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties ItemIndexProperty sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ItemIndexProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesItemIndexPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties ItemPathProperty sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ItemPathProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesItemPathPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			//// add Language Reference special properties LibraryDirectoryProperty sub subsection
			//helpSubSub = new HelpViewModel(LanguageTerms.LibraryDirectoryProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesLibraryDirectoryPropertyParagraph1);
			//helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties PathProperty sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.PathProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesPathPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties PathRelationships sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.PathRelationships, DisplayValues.Help_LanguageReferenceSpecialPropertiesPathRelationshipsParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties RecordItem sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.RecordItem, DisplayValues.Help_LanguageReferenceSpecialPropertiesRecordItemParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties TemplateProperty sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.TemplateProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesTemplatePropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties TextProperty sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.TextProperty, DisplayValues.Help_LanguageReferenceSpecialPropertiesTextPropertyParagraph1);
			helpSub.Items.Add(helpSubSub);

			// add Language Reference special properties this sub subsection
			helpSubSub = new HelpViewModel(LanguageTerms.ThisTerm, DisplayValues.Help_LanguageReferenceSpecialPropertiesThisKeywordParagraph1);
			helpSub.Items.Add(helpSubSub);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
        public ResourcesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Resources;
			LoadHelp();
		}

		#endregion "Constructors"
    }
}
