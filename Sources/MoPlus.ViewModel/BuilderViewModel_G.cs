/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.Server;
using System.IO;
using MoPlus.Data;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Conventions;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Events.Models;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Workflows;
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides the view for the entire model.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/16/2014</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class BuilderViewModel : WorkspaceViewModel
	{
		#region "Command Processing"

		///--------------------------------------------------------------------------------
		/// <summary>This method processes show Help messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ShowHelpRequested, ParameterType = typeof(HelpEventArgs))]
		public void ProcessShowHelpRequested(HelpEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes show item messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ShowItemRequested, ParameterType = typeof(WorkspaceEventArgs))]
		public void ProcessShowItemRequested(WorkspaceEventArgs args)
		{
			if (args != null && args.Workspace != null)
			{
				// find and select item
				if (SelectItem(this, args) == true)
				{
					IsExpanded = true;
					IsSelected = false;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method selects an item in the tree.</summary>
		/// 
		/// <param name="item">The item to compare recursively.</param>
		/// <param name="args">The arguments containing the item to select.</param>
		///--------------------------------------------------------------------------------
		private bool SelectItem(IWorkspaceViewModel item, WorkspaceEventArgs args)
		{
			if (args.ItemID == item.ItemID)
			{
				item.IsSelected = true;
				if (args.NeedsFocus == true)
				{
					item.NeedsFocus = true;
				}
				return true;
			}
			else if (item.Items != null)
			{
				foreach (IWorkspaceViewModel childItem in item.Items)
				{
					if (SelectItem(childItem, args) == true)
					{
						item.IsExpanded = true;
						item.IsSelected = false;
						return true;
					}
				}
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes refresh solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_RefreshSolutionRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessRefreshSolutionRequested(SolutionEventArgs args)
		{
			if (args != null && args.Solution != null)
			{
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.Solution.SolutionID == args.Solution.SolutionID)
					{
						item.Refresh(true);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes compile solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_CompileSolutionRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessCompileSolutionRequested(SolutionEventArgs data)
		{
			if (data != null && data.Solution != null)
			{
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.Solution.SolutionID == data.Solution.SolutionID)
					{
						item.BuildSolution();
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes update output solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_UpdateSolutionRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessUpdateSolutionRequested(SolutionEventArgs data)
		{
			if (data != null && data.Solution != null)
			{
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.Solution.SolutionID == data.Solution.SolutionID)
					{
						item.UpdateOutputSolution();
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes compile solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_SolutionEditItemCount, ParameterType = typeof(SolutionEditEventArgs))]
		public void ProcessSolutionEditItemCount(SolutionEditEventArgs data)
		{
			if (data != null && data.SolutionID != Guid.Empty)
			{
				int tabItemCount = 0;
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.SolutionID == data.SolutionID)
					{
						item.EditItemsCount = data.EditItemsCount;
					}
					tabItemCount += item.EditItemsCount;
				}
				if (tabItemCount == 0)
				{
					OnFocusRequested(this, null);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes refresh spec template messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_RefreshSpecTemplatesRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessRefreshSpecTemplatesRequested(SolutionEventArgs data)
		{
			if (data != null && data.Solution != null)
			{
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.Solution.SolutionID == data.Solution.SolutionID)
					{
						item.SpecTemplatesFolder.Refresh(true);
						SolutionsFolder.Refresh(false, 1);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes refresh code template messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_RefreshCodeTemplatesRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessRefreshCodeTemplatesRequested(SolutionEventArgs data)
		{
			if (data != null && data.Solution != null)
			{
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.Solution.SolutionID == data.Solution.SolutionID)
					{
						item.CodeTemplatesFolder.Refresh(true);
						SolutionsFolder.Refresh(false, 1);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling focus requests.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler FocusRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles focus requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnFocusRequested(object sender, EventArgs args)
		{
			if (FocusRequested != null)
			{
				FocusRequested(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new command.</summary>
		/// 
		/// <param name="viewModel">View model to process command for.</param>
		///--------------------------------------------------------------------------------
		public void ProcessNewCommand(IWorkspaceViewModel viewModel)
		{
			if (viewModel is AuditPropertiesViewModel)
			{
				(viewModel as AuditPropertiesViewModel).ProcessNewAuditPropertyCommand();
				return;
			}
			else if (viewModel is AuditPropertyViewModel)
			{
				(viewModel as AuditPropertyViewModel).ProcessNewAuditPropertyCommand();
				return;
			}
			else if (viewModel is CodeTemplatesViewModel)
			{
				(viewModel as CodeTemplatesViewModel).ProcessNewCodeTemplateCommand();
				return;
			}
			else if (viewModel is CodeTemplateViewModel)
			{
				(viewModel as CodeTemplateViewModel).ProcessNewCodeTemplateCommand();
				return;
			}
			else if (viewModel is CollectionsViewModel)
			{
				(viewModel as CollectionsViewModel).ProcessNewCollectionCommand();
				return;
			}
			else if (viewModel is CollectionViewModel)
			{
				(viewModel as CollectionViewModel).ProcessNewCollectionCommand();
				return;
			}
			else if (viewModel is DatabaseSourcesViewModel)
			{
				(viewModel as DatabaseSourcesViewModel).ProcessNewDatabaseSourceCommand();
				return;
			}
			else if (viewModel is DatabaseSourceViewModel)
			{
				(viewModel as DatabaseSourceViewModel).ProcessNewDatabaseSourceCommand();
				return;
			}
			else if (viewModel is DiagramsViewModel)
			{
				(viewModel as DiagramsViewModel).ProcessNewDiagramCommand();
				return;
			}
			else if (viewModel is DiagramViewModel)
			{
				(viewModel as DiagramViewModel).ProcessNewDiagramCommand();
				return;
			}
			else if (viewModel is EntityViewModel)
			{
				(viewModel as EntityViewModel).ProcessNewEntityCommand();
				return;
			}
			else if (viewModel is EntityReferencesViewModel)
			{
				(viewModel as EntityReferencesViewModel).ProcessNewEntityReferenceCommand();
				return;
			}
			else if (viewModel is EntityReferenceViewModel)
			{
				(viewModel as EntityReferenceViewModel).ProcessNewEntityReferenceCommand();
				return;
			}
			else if (viewModel is EnumerationsViewModel)
			{
				(viewModel as EnumerationsViewModel).ProcessNewEnumerationCommand();
				return;
			}
			else if (viewModel is EnumerationViewModel)
			{
				(viewModel as EnumerationViewModel).ProcessNewEnumerationCommand();
				return;
			}
			else if (viewModel is FeaturesViewModel)
			{
				(viewModel as FeaturesViewModel).ProcessNewFeatureCommand();
				return;
			}
			else if (viewModel is FeatureViewModel)
			{
				(viewModel as FeatureViewModel).ProcessNewFeatureCommand();
				return;
			}
			else if (viewModel is IndexesViewModel)
			{
				(viewModel as IndexesViewModel).ProcessNewIndexCommand();
				return;
			}
			else if (viewModel is IndexViewModel)
			{
				(viewModel as IndexViewModel).ProcessNewIndexCommand();
				return;
			}
			else if (viewModel is IndexPropertyViewModel)
			{
				(viewModel as IndexPropertyViewModel).ProcessNewIndexPropertyCommand();
				return;
			}
			else if (viewModel is MethodsViewModel)
			{
				(viewModel as MethodsViewModel).ProcessNewMethodCommand();
				return;
			}
			else if (viewModel is MethodViewModel)
			{
				(viewModel as MethodViewModel).ProcessNewMethodCommand();
				return;
			}
			else if (viewModel is MethodRelationshipViewModel)
			{
				(viewModel as MethodRelationshipViewModel).ProcessNewMethodRelationshipCommand();
				return;
			}
			else if (viewModel is ModelsViewModel)
			{
				(viewModel as ModelsViewModel).ProcessNewModelCommand();
				return;
			}
			else if (viewModel is ModelViewModel)
			{
				(viewModel as ModelViewModel).ProcessNewModelCommand();
				return;
			}
			else if (viewModel is ModelObjectsViewModel)
			{
				(viewModel as ModelObjectsViewModel).ProcessNewModelObjectCommand();
				return;
			}
			else if (viewModel is ModelObjectViewModel)
			{
				(viewModel as ModelObjectViewModel).ProcessNewModelObjectCommand();
				return;
			}
			else if (viewModel is ModelPropertyViewModel)
			{
				(viewModel as ModelPropertyViewModel).ProcessNewModelPropertyCommand();
				return;
			}
			else if (viewModel is ObjectInstanceViewModel)
			{
				(viewModel as ObjectInstanceViewModel).ProcessNewObjectInstanceCommand();
				return;
			}
			else if (viewModel is ParameterViewModel)
			{
				(viewModel as ParameterViewModel).ProcessNewParameterCommand();
				return;
			}
			else if (viewModel is ProjectsViewModel)
			{
				(viewModel as ProjectsViewModel).ProcessNewProjectCommand();
				return;
			}
			else if (viewModel is ProjectViewModel)
			{
				(viewModel as ProjectViewModel).ProcessNewProjectCommand();
				return;
			}
			else if (viewModel is PropertiesViewModel)
			{
				(viewModel as PropertiesViewModel).ProcessNewPropertyCommand();
				return;
			}
			else if (viewModel is PropertyViewModel)
			{
				(viewModel as PropertyViewModel).ProcessNewPropertyCommand();
				return;
			}
			else if (viewModel is PropertyInstanceViewModel)
			{
				(viewModel as PropertyInstanceViewModel).ProcessNewPropertyInstanceCommand();
				return;
			}
			else if (viewModel is PropertyReferencesViewModel)
			{
				(viewModel as PropertyReferencesViewModel).ProcessNewPropertyReferenceCommand();
				return;
			}
			else if (viewModel is PropertyReferenceViewModel)
			{
				(viewModel as PropertyReferenceViewModel).ProcessNewPropertyReferenceCommand();
				return;
			}
			else if (viewModel is PropertyRelationshipViewModel)
			{
				(viewModel as PropertyRelationshipViewModel).ProcessNewPropertyRelationshipCommand();
				return;
			}
			else if (viewModel is RelationshipsViewModel)
			{
				(viewModel as RelationshipsViewModel).ProcessNewRelationshipCommand();
				return;
			}
			else if (viewModel is RelationshipViewModel)
			{
				(viewModel as RelationshipViewModel).ProcessNewRelationshipCommand();
				return;
			}
			else if (viewModel is RelationshipPropertyViewModel)
			{
				(viewModel as RelationshipPropertyViewModel).ProcessNewRelationshipPropertyCommand();
				return;
			}
			else if (viewModel is SpecTemplatesViewModel)
			{
				(viewModel as SpecTemplatesViewModel).ProcessNewSpecTemplateCommand();
				return;
			}
			else if (viewModel is SpecTemplateViewModel)
			{
				(viewModel as SpecTemplateViewModel).ProcessNewSpecTemplateCommand();
				return;
			}
			else if (viewModel is StageViewModel)
			{
				(viewModel as StageViewModel).ProcessNewStageCommand();
				return;
			}
			else if (viewModel is StageTransitionsViewModel)
			{
				(viewModel as StageTransitionsViewModel).ProcessNewStageTransitionCommand();
				return;
			}
			else if (viewModel is StageTransitionViewModel)
			{
				(viewModel as StageTransitionViewModel).ProcessNewStageTransitionCommand();
				return;
			}
			else if (viewModel is StateViewModel)
			{
				(viewModel as StateViewModel).ProcessNewStateCommand();
				return;
			}
			else if (viewModel is StateModelsViewModel)
			{
				(viewModel as StateModelsViewModel).ProcessNewStateModelCommand();
				return;
			}
			else if (viewModel is StateModelViewModel)
			{
				(viewModel as StateModelViewModel).ProcessNewStateModelCommand();
				return;
			}
			else if (viewModel is StateTransitionViewModel)
			{
				(viewModel as StateTransitionViewModel).ProcessNewStateTransitionCommand();
				return;
			}
			else if (viewModel is StepsViewModel)
			{
				(viewModel as StepsViewModel).ProcessNewStepCommand();
				return;
			}
			else if (viewModel is StepViewModel)
			{
				(viewModel as StepViewModel).ProcessNewStepCommand();
				return;
			}
			else if (viewModel is StepTransitionViewModel)
			{
				(viewModel as StepTransitionViewModel).ProcessNewStepTransitionCommand();
				return;
			}
			else if (viewModel is ValueViewModel)
			{
				(viewModel as ValueViewModel).ProcessNewValueCommand();
				return;
			}
			else if (viewModel is WorkflowsViewModel)
			{
				(viewModel as WorkflowsViewModel).ProcessNewWorkflowCommand();
				return;
			}
			else if (viewModel is WorkflowViewModel)
			{
				(viewModel as WorkflowViewModel).ProcessNewWorkflowCommand();
				return;
			}
			else if (viewModel is XmlSourcesViewModel)
			{
				(viewModel as XmlSourcesViewModel).ProcessNewXmlSourceCommand();
				return;
			}
			else if (viewModel is XmlSourceViewModel)
			{
				(viewModel as XmlSourceViewModel).ProcessNewXmlSourceCommand();
				return;
			}
			
			#region protected
			else if (viewModel is SpecificationSourcesViewModel)
			{
				(viewModel as SpecificationSourcesViewModel).ProcessNewDatabaseSourceCommand();
				return;
			}
			else if (viewModel is ModelObjectDataViewModel)
			{
				(viewModel as ModelObjectDataViewModel).ProcessNewObjectInstanceCommand();
				return;
			}
			#endregion protected
			
			SolutionsFolder.ProcessNewSolutionCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new child item command.</summary>
		/// 
		/// <param name="viewModel">View model to process command for.</param>
		///--------------------------------------------------------------------------------
		public void ProcessNewChildItemCommand(IWorkspaceViewModel viewModel)
		{
			if (viewModel is DiagramViewModel)
			{
				(viewModel as DiagramViewModel).ProcessNewDiagramEntityCommand();
				return;
			}
			else if (viewModel is EnumerationViewModel)
			{
				(viewModel as EnumerationViewModel).ProcessNewValueCommand();
				return;
			}
			else if (viewModel is FeatureViewModel)
			{
				(viewModel as FeatureViewModel).ProcessNewEntityCommand();
				return;
			}
			else if (viewModel is IndexViewModel)
			{
				(viewModel as IndexViewModel).ProcessNewIndexPropertyCommand();
				return;
			}
			else if (viewModel is MethodViewModel)
			{
				(viewModel as MethodViewModel).ProcessNewParameterCommand();
				return;
			}
			else if (viewModel is ModelObjectViewModel)
			{
				(viewModel as ModelObjectViewModel).ProcessNewModelPropertyCommand();
				return;
			}
			else if (viewModel is ObjectInstanceViewModel)
			{
				(viewModel as ObjectInstanceViewModel).ProcessNewPropertyInstanceCommand();
				return;
			}
			else if (viewModel is RelationshipViewModel)
			{
				(viewModel as RelationshipViewModel).ProcessNewRelationshipPropertyCommand();
				return;
			}
			else if (viewModel is StateViewModel)
			{
				(viewModel as StateViewModel).ProcessNewStateTransitionCommand();
				return;
			}
			else if (viewModel is StateModelViewModel)
			{
				(viewModel as StateModelViewModel).ProcessNewStateCommand();
				return;
			}
			else if (viewModel is StepViewModel)
			{
				(viewModel as StepViewModel).ProcessNewStepTransitionCommand();
				return;
			}
			else if (viewModel is WorkflowViewModel)
			{
				(viewModel as WorkflowViewModel).ProcessNewStageCommand();
				return;
			}
			
			#region protected
			else if (viewModel is SpecificationSourcesViewModel)
			{
				(viewModel as SpecificationSourcesViewModel).ProcessNewXmlSourceCommand();
				return;
			}
			#endregion protected
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete command.</summary>
		/// 
		/// <param name="viewModel">View model to process command for.</param>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteCommand(IWorkspaceViewModel viewModel)
		{
			if (viewModel is AuditPropertyViewModel)
			{
				(viewModel as AuditPropertyViewModel).ProcessDeleteAuditPropertyCommand();
				return;
			}
			else if (viewModel is CodeTemplateViewModel)
			{
				(viewModel as CodeTemplateViewModel).ProcessDeleteCodeTemplateCommand();
				return;
			}
			else if (viewModel is CollectionViewModel)
			{
				(viewModel as CollectionViewModel).ProcessDeleteCollectionCommand();
				return;
			}
			else if (viewModel is DatabaseSourceViewModel)
			{
				(viewModel as DatabaseSourceViewModel).ProcessDeleteDatabaseSourceCommand();
				return;
			}
			else if (viewModel is DiagramViewModel)
			{
				(viewModel as DiagramViewModel).ProcessDeleteDiagramCommand();
				return;
			}
			else if (viewModel is EntityViewModel)
			{
				(viewModel as EntityViewModel).ProcessDeleteEntityCommand();
				return;
			}
			else if (viewModel is EntityReferenceViewModel)
			{
				(viewModel as EntityReferenceViewModel).ProcessDeleteEntityReferenceCommand();
				return;
			}
			else if (viewModel is EnumerationViewModel)
			{
				(viewModel as EnumerationViewModel).ProcessDeleteEnumerationCommand();
				return;
			}
			else if (viewModel is FeatureViewModel)
			{
				(viewModel as FeatureViewModel).ProcessDeleteFeatureCommand();
				return;
			}
			else if (viewModel is IndexViewModel)
			{
				(viewModel as IndexViewModel).ProcessDeleteIndexCommand();
				return;
			}
			else if (viewModel is IndexPropertyViewModel)
			{
				(viewModel as IndexPropertyViewModel).ProcessDeleteIndexPropertyCommand();
				return;
			}
			else if (viewModel is MethodViewModel)
			{
				(viewModel as MethodViewModel).ProcessDeleteMethodCommand();
				return;
			}
			else if (viewModel is MethodRelationshipViewModel)
			{
				(viewModel as MethodRelationshipViewModel).ProcessDeleteMethodRelationshipCommand();
				return;
			}
			else if (viewModel is ModelViewModel)
			{
				(viewModel as ModelViewModel).ProcessDeleteModelCommand();
				return;
			}
			else if (viewModel is ModelObjectViewModel)
			{
				(viewModel as ModelObjectViewModel).ProcessDeleteModelObjectCommand();
				return;
			}
			else if (viewModel is ModelPropertyViewModel)
			{
				(viewModel as ModelPropertyViewModel).ProcessDeleteModelPropertyCommand();
				return;
			}
			else if (viewModel is ObjectInstanceViewModel)
			{
				(viewModel as ObjectInstanceViewModel).ProcessDeleteObjectInstanceCommand();
				return;
			}
			else if (viewModel is ParameterViewModel)
			{
				(viewModel as ParameterViewModel).ProcessDeleteParameterCommand();
				return;
			}
			else if (viewModel is ProjectViewModel)
			{
				(viewModel as ProjectViewModel).ProcessDeleteProjectCommand();
				return;
			}
			else if (viewModel is PropertyViewModel)
			{
				(viewModel as PropertyViewModel).ProcessDeletePropertyCommand();
				return;
			}
			else if (viewModel is PropertyInstanceViewModel)
			{
				(viewModel as PropertyInstanceViewModel).ProcessDeletePropertyInstanceCommand();
				return;
			}
			else if (viewModel is PropertyReferenceViewModel)
			{
				(viewModel as PropertyReferenceViewModel).ProcessDeletePropertyReferenceCommand();
				return;
			}
			else if (viewModel is PropertyRelationshipViewModel)
			{
				(viewModel as PropertyRelationshipViewModel).ProcessDeletePropertyRelationshipCommand();
				return;
			}
			else if (viewModel is RelationshipViewModel)
			{
				(viewModel as RelationshipViewModel).ProcessDeleteRelationshipCommand();
				return;
			}
			else if (viewModel is RelationshipPropertyViewModel)
			{
				(viewModel as RelationshipPropertyViewModel).ProcessDeleteRelationshipPropertyCommand();
				return;
			}
			else if (viewModel is SpecTemplateViewModel)
			{
				(viewModel as SpecTemplateViewModel).ProcessDeleteSpecTemplateCommand();
				return;
			}
			else if (viewModel is StageViewModel)
			{
				(viewModel as StageViewModel).ProcessDeleteStageCommand();
				return;
			}
			else if (viewModel is StageTransitionViewModel)
			{
				(viewModel as StageTransitionViewModel).ProcessDeleteStageTransitionCommand();
				return;
			}
			else if (viewModel is StateViewModel)
			{
				(viewModel as StateViewModel).ProcessDeleteStateCommand();
				return;
			}
			else if (viewModel is StateModelViewModel)
			{
				(viewModel as StateModelViewModel).ProcessDeleteStateModelCommand();
				return;
			}
			else if (viewModel is StateTransitionViewModel)
			{
				(viewModel as StateTransitionViewModel).ProcessDeleteStateTransitionCommand();
				return;
			}
			else if (viewModel is StepViewModel)
			{
				(viewModel as StepViewModel).ProcessDeleteStepCommand();
				return;
			}
			else if (viewModel is StepTransitionViewModel)
			{
				(viewModel as StepTransitionViewModel).ProcessDeleteStepTransitionCommand();
				return;
			}
			else if (viewModel is ValueViewModel)
			{
				(viewModel as ValueViewModel).ProcessDeleteValueCommand();
				return;
			}
			else if (viewModel is WorkflowViewModel)
			{
				(viewModel as WorkflowViewModel).ProcessDeleteWorkflowCommand();
				return;
			}
			else if (viewModel is XmlSourceViewModel)
			{
				(viewModel as XmlSourceViewModel).ProcessDeleteXmlSourceCommand();
				return;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies solution updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditSolutionPerformed, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessEditSolutionPerformed(SolutionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				SolutionsFolder.ProcessEditSolutionPerformed(data);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies AuditProperty updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditAuditPropertyPerformed, ParameterType = typeof(AuditPropertyEventArgs))]
		public void ProcessEditAuditPropertyPerformed(AuditPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is AuditPropertiesViewModel)
						{
							(parentView as AuditPropertiesViewModel).ProcessEditAuditPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete AuditProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteAuditPropertyRequested, ParameterType = typeof(AuditPropertyEventArgs))]
		public void ProcessDeleteAuditPropertyRequested(AuditPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is AuditPropertiesViewModel)
						{
							(parentView as AuditPropertiesViewModel).ProcessDeleteAuditPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies CodeTemplate updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditCodeTemplatePerformed, ParameterType = typeof(CodeTemplateEventArgs))]
		public void ProcessEditCodeTemplatePerformed(CodeTemplateEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is CodeTemplatesViewModel)
						{
							(parentView as CodeTemplatesViewModel).ProcessEditCodeTemplatePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete CodeTemplate messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteCodeTemplateRequested, ParameterType = typeof(CodeTemplateEventArgs))]
		public void ProcessDeleteCodeTemplateRequested(CodeTemplateEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is CodeTemplatesViewModel)
						{
							(parentView as CodeTemplatesViewModel).ProcessDeleteCodeTemplatePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Collection updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditCollectionPerformed, ParameterType = typeof(CollectionEventArgs))]
		public void ProcessEditCollectionPerformed(CollectionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is CollectionsViewModel)
						{
							(parentView as CollectionsViewModel).ProcessEditCollectionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Collection messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteCollectionRequested, ParameterType = typeof(CollectionEventArgs))]
		public void ProcessDeleteCollectionRequested(CollectionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is CollectionsViewModel)
						{
							(parentView as CollectionsViewModel).ProcessDeleteCollectionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Diagram updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditDiagramPerformed, ParameterType = typeof(DiagramEventArgs))]
		public void ProcessEditDiagramPerformed(DiagramEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is DiagramsViewModel)
						{
							(parentView as DiagramsViewModel).ProcessEditDiagramPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Diagram messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteDiagramRequested, ParameterType = typeof(DiagramEventArgs))]
		public void ProcessDeleteDiagramRequested(DiagramEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is DiagramsViewModel)
						{
							(parentView as DiagramsViewModel).ProcessDeleteDiagramPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Entity updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEntityPerformed, ParameterType = typeof(EntityEventArgs))]
		public void ProcessEditEntityPerformed(EntityEventArgs data)
		{
			#region protected
			Guid featureID = data.FeatureID;
			if (data.PreviousFeatureID != null && data.PreviousFeatureID != Guid.Empty)
			{
				featureID = (Guid)data.PreviousFeatureID;
			}
			#endregion protected

			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is FeatureViewModel)
						{
							(parentView as FeatureViewModel).ProcessEditEntityPerformed(data);

							#region protected
							if (data.PreviousFeatureID != null)
							{
								foreach (FeatureViewModel oldFeature in solution.FeaturesFolder.Features)
								{
									if (oldFeature.Feature.FeatureID == data.PreviousFeatureID)
									{
										EntityViewModel entityView = null;
										foreach (EntityViewModel view in oldFeature.Entities)
										{
											if (view.EntityID == data.Entity.EntityID)
											{
												entityView = view;
												break;
											}
										}
										oldFeature.RemoveEntityView(entityView);
										oldFeature.Refresh(false, 1);
										if (data.ShowItemInTreeView == true)
										{
											entityView.ShowInTreeView();
										}
										break;
									}
								}
								if (data.ShowItemInTreeView == true)
								{
									foreach (EntityViewModel view in (parentView as FeatureViewModel).Entities)
									{
										if (view.EntityID == data.Entity.EntityID)
										{
											view.ShowInTreeView();
											break;
										}
									}
								}
							}
							#endregion protected

						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Entity messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteEntityRequested, ParameterType = typeof(EntityEventArgs))]
		public void ProcessDeleteEntityRequested(EntityEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is FeatureViewModel)
						{
							(parentView as FeatureViewModel).ProcessDeleteEntityPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies EntityReference updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEntityReferencePerformed, ParameterType = typeof(EntityReferenceEventArgs))]
		public void ProcessEditEntityReferencePerformed(EntityReferenceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is EntityReferencesViewModel)
						{
							(parentView as EntityReferencesViewModel).ProcessEditEntityReferencePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete EntityReference messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteEntityReferenceRequested, ParameterType = typeof(EntityReferenceEventArgs))]
		public void ProcessDeleteEntityReferenceRequested(EntityReferenceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is EntityReferencesViewModel)
						{
							(parentView as EntityReferencesViewModel).ProcessDeleteEntityReferencePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Enumeration updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEnumerationPerformed, ParameterType = typeof(EnumerationEventArgs))]
		public void ProcessEditEnumerationPerformed(EnumerationEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is EnumerationsViewModel)
						{
							(parentView as EnumerationsViewModel).ProcessEditEnumerationPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Enumeration messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteEnumerationRequested, ParameterType = typeof(EnumerationEventArgs))]
		public void ProcessDeleteEnumerationRequested(EnumerationEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is EnumerationsViewModel)
						{
							(parentView as EnumerationsViewModel).ProcessDeleteEnumerationPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Feature updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditFeaturePerformed, ParameterType = typeof(FeatureEventArgs))]
		public void ProcessEditFeaturePerformed(FeatureEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is FeaturesViewModel)
						{
							(parentView as FeaturesViewModel).ProcessEditFeaturePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Feature messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteFeatureRequested, ParameterType = typeof(FeatureEventArgs))]
		public void ProcessDeleteFeatureRequested(FeatureEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is FeaturesViewModel)
						{
							(parentView as FeaturesViewModel).ProcessDeleteFeaturePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Index updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditIndexPerformed, ParameterType = typeof(IndexEventArgs))]
		public void ProcessEditIndexPerformed(IndexEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is IndexesViewModel)
						{
							(parentView as IndexesViewModel).ProcessEditIndexPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Index messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteIndexRequested, ParameterType = typeof(IndexEventArgs))]
		public void ProcessDeleteIndexRequested(IndexEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is IndexesViewModel)
						{
							(parentView as IndexesViewModel).ProcessDeleteIndexPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies IndexProperty updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditIndexPropertyPerformed, ParameterType = typeof(IndexPropertyEventArgs))]
		public void ProcessEditIndexPropertyPerformed(IndexPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is IndexViewModel)
						{
							(parentView as IndexViewModel).ProcessEditIndexPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete IndexProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteIndexPropertyRequested, ParameterType = typeof(IndexPropertyEventArgs))]
		public void ProcessDeleteIndexPropertyRequested(IndexPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is IndexViewModel)
						{
							(parentView as IndexViewModel).ProcessDeleteIndexPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Method updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditMethodPerformed, ParameterType = typeof(MethodEventArgs))]
		public void ProcessEditMethodPerformed(MethodEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is MethodsViewModel)
						{
							(parentView as MethodsViewModel).ProcessEditMethodPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Method messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteMethodRequested, ParameterType = typeof(MethodEventArgs))]
		public void ProcessDeleteMethodRequested(MethodEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is MethodsViewModel)
						{
							(parentView as MethodsViewModel).ProcessDeleteMethodPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies MethodRelationship updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditMethodRelationshipPerformed, ParameterType = typeof(MethodRelationshipEventArgs))]
		public void ProcessEditMethodRelationshipPerformed(MethodRelationshipEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);

						#region protected
						if (parentView is MethodViewModel)
						{
							(parentView as MethodViewModel).ProcessEditMethodRelationshipPerformed(data);
						}
						#endregion protected
						
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete MethodRelationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteMethodRelationshipRequested, ParameterType = typeof(MethodRelationshipEventArgs))]
		public void ProcessDeleteMethodRelationshipRequested(MethodRelationshipEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						#region protected
						if (parentView is MethodViewModel)
						{
							(parentView as MethodViewModel).ProcessDeleteMethodRelationshipPerformed(data);
						}
						#endregion protected
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Model updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelPerformed, ParameterType = typeof(ModelEventArgs))]
		public void ProcessEditModelPerformed(ModelEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelsViewModel)
						{
							(parentView as ModelsViewModel).ProcessEditModelPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Model messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteModelRequested, ParameterType = typeof(ModelEventArgs))]
		public void ProcessDeleteModelRequested(ModelEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelsViewModel)
						{
							(parentView as ModelsViewModel).ProcessDeleteModelPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ModelObject updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelObjectPerformed, ParameterType = typeof(ModelObjectEventArgs))]
		public void ProcessEditModelObjectPerformed(ModelObjectEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelObjectsViewModel)
						{
							(parentView as ModelObjectsViewModel).ProcessEditModelObjectPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete ModelObject messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteModelObjectRequested, ParameterType = typeof(ModelObjectEventArgs))]
		public void ProcessDeleteModelObjectRequested(ModelObjectEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelObjectsViewModel)
						{
							(parentView as ModelObjectsViewModel).ProcessDeleteModelObjectPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ModelProperty updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelPropertyPerformed, ParameterType = typeof(ModelPropertyEventArgs))]
		public void ProcessEditModelPropertyPerformed(ModelPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelObjectViewModel)
						{
							(parentView as ModelObjectViewModel).ProcessEditModelPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete ModelProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteModelPropertyRequested, ParameterType = typeof(ModelPropertyEventArgs))]
		public void ProcessDeleteModelPropertyRequested(ModelPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelObjectViewModel)
						{
							(parentView as ModelObjectViewModel).ProcessDeleteModelPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Parameter updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditParameterPerformed, ParameterType = typeof(ParameterEventArgs))]
		public void ProcessEditParameterPerformed(ParameterEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is MethodViewModel)
						{
							(parentView as MethodViewModel).ProcessEditParameterPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Parameter messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteParameterRequested, ParameterType = typeof(ParameterEventArgs))]
		public void ProcessDeleteParameterRequested(ParameterEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is MethodViewModel)
						{
							(parentView as MethodViewModel).ProcessDeleteParameterPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Project updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditProjectPerformed, ParameterType = typeof(ProjectEventArgs))]
		public void ProcessEditProjectPerformed(ProjectEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ProjectsViewModel)
						{
							(parentView as ProjectsViewModel).ProcessEditProjectPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Project messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteProjectRequested, ParameterType = typeof(ProjectEventArgs))]
		public void ProcessDeleteProjectRequested(ProjectEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ProjectsViewModel)
						{
							(parentView as ProjectsViewModel).ProcessDeleteProjectPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Property updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyPerformed, ParameterType = typeof(PropertyEventArgs))]
		public void ProcessEditPropertyPerformed(PropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is PropertiesViewModel)
						{
							(parentView as PropertiesViewModel).ProcessEditPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Property messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeletePropertyRequested, ParameterType = typeof(PropertyEventArgs))]
		public void ProcessDeletePropertyRequested(PropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is PropertiesViewModel)
						{
							(parentView as PropertiesViewModel).ProcessDeletePropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyInstance updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyInstancePerformed, ParameterType = typeof(PropertyInstanceEventArgs))]
		public void ProcessEditPropertyInstancePerformed(PropertyInstanceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ObjectInstanceViewModel)
						{
							(parentView as ObjectInstanceViewModel).ProcessEditPropertyInstancePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete PropertyInstance messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeletePropertyInstanceRequested, ParameterType = typeof(PropertyInstanceEventArgs))]
		public void ProcessDeletePropertyInstanceRequested(PropertyInstanceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ObjectInstanceViewModel)
						{
							(parentView as ObjectInstanceViewModel).ProcessDeletePropertyInstancePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyReference updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyReferencePerformed, ParameterType = typeof(PropertyReferenceEventArgs))]
		public void ProcessEditPropertyReferencePerformed(PropertyReferenceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is PropertyReferencesViewModel)
						{
							(parentView as PropertyReferencesViewModel).ProcessEditPropertyReferencePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete PropertyReference messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeletePropertyReferenceRequested, ParameterType = typeof(PropertyReferenceEventArgs))]
		public void ProcessDeletePropertyReferenceRequested(PropertyReferenceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is PropertyReferencesViewModel)
						{
							(parentView as PropertyReferencesViewModel).ProcessDeletePropertyReferencePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyRelationship updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyRelationshipPerformed, ParameterType = typeof(PropertyRelationshipEventArgs))]
		public void ProcessEditPropertyRelationshipPerformed(PropertyRelationshipEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);

						#region protected
						if (parentView is CollectionViewModel)
						{
							(parentView as CollectionViewModel).ProcessEditPropertyRelationshipPerformed(data);
						}
						else if (parentView is PropertyReferenceViewModel)
						{
							(parentView as PropertyReferenceViewModel).ProcessEditPropertyRelationshipPerformed(data);
						}
						else if (parentView is EntityReferenceViewModel)
						{
							(parentView as EntityReferenceViewModel).ProcessEditPropertyRelationshipPerformed(data);
						}
						#endregion protected
						
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete PropertyRelationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeletePropertyRelationshipRequested, ParameterType = typeof(PropertyRelationshipEventArgs))]
		public void ProcessDeletePropertyRelationshipRequested(PropertyRelationshipEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						#region protected
						if (parentView is CollectionViewModel)
						{
							(parentView as CollectionViewModel).ProcessDeletePropertyRelationshipPerformed(data);
						}
						else if (parentView is PropertyReferenceViewModel)
						{
							(parentView as PropertyReferenceViewModel).ProcessDeletePropertyRelationshipPerformed(data);
						}
						else if (parentView is EntityReferenceViewModel)
						{
							(parentView as EntityReferenceViewModel).ProcessDeletePropertyRelationshipPerformed(data);
						}
						#endregion protected
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Relationship updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditRelationshipPerformed, ParameterType = typeof(RelationshipEventArgs))]
		public void ProcessEditRelationshipPerformed(RelationshipEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is RelationshipsViewModel)
						{
							(parentView as RelationshipsViewModel).ProcessEditRelationshipPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Relationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteRelationshipRequested, ParameterType = typeof(RelationshipEventArgs))]
		public void ProcessDeleteRelationshipRequested(RelationshipEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is RelationshipsViewModel)
						{
							(parentView as RelationshipsViewModel).ProcessDeleteRelationshipPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies RelationshipProperty updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditRelationshipPropertyPerformed, ParameterType = typeof(RelationshipPropertyEventArgs))]
		public void ProcessEditRelationshipPropertyPerformed(RelationshipPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is RelationshipViewModel)
						{
							(parentView as RelationshipViewModel).ProcessEditRelationshipPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete RelationshipProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteRelationshipPropertyRequested, ParameterType = typeof(RelationshipPropertyEventArgs))]
		public void ProcessDeleteRelationshipPropertyRequested(RelationshipPropertyEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is RelationshipViewModel)
						{
							(parentView as RelationshipViewModel).ProcessDeleteRelationshipPropertyPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies SpecTemplate updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditSpecTemplatePerformed, ParameterType = typeof(SpecTemplateEventArgs))]
		public void ProcessEditSpecTemplatePerformed(SpecTemplateEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is SpecTemplatesViewModel)
						{
							(parentView as SpecTemplatesViewModel).ProcessEditSpecTemplatePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete SpecTemplate messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteSpecTemplateRequested, ParameterType = typeof(SpecTemplateEventArgs))]
		public void ProcessDeleteSpecTemplateRequested(SpecTemplateEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is SpecTemplatesViewModel)
						{
							(parentView as SpecTemplatesViewModel).ProcessDeleteSpecTemplatePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Stage updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStagePerformed, ParameterType = typeof(StageEventArgs))]
		public void ProcessEditStagePerformed(StageEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is WorkflowViewModel)
						{
							(parentView as WorkflowViewModel).ProcessEditStagePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Stage messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStageRequested, ParameterType = typeof(StageEventArgs))]
		public void ProcessDeleteStageRequested(StageEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is WorkflowViewModel)
						{
							(parentView as WorkflowViewModel).ProcessDeleteStagePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StageTransition updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStageTransitionPerformed, ParameterType = typeof(StageTransitionEventArgs))]
		public void ProcessEditStageTransitionPerformed(StageTransitionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StageTransitionsViewModel)
						{
							(parentView as StageTransitionsViewModel).ProcessEditStageTransitionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete StageTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStageTransitionRequested, ParameterType = typeof(StageTransitionEventArgs))]
		public void ProcessDeleteStageTransitionRequested(StageTransitionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StageTransitionsViewModel)
						{
							(parentView as StageTransitionsViewModel).ProcessDeleteStageTransitionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies State updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStatePerformed, ParameterType = typeof(StateEventArgs))]
		public void ProcessEditStatePerformed(StateEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StateModelViewModel)
						{
							(parentView as StateModelViewModel).ProcessEditStatePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete State messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStateRequested, ParameterType = typeof(StateEventArgs))]
		public void ProcessDeleteStateRequested(StateEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StateModelViewModel)
						{
							(parentView as StateModelViewModel).ProcessDeleteStatePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StateModel updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateModelPerformed, ParameterType = typeof(StateModelEventArgs))]
		public void ProcessEditStateModelPerformed(StateModelEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StateModelsViewModel)
						{
							(parentView as StateModelsViewModel).ProcessEditStateModelPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete StateModel messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStateModelRequested, ParameterType = typeof(StateModelEventArgs))]
		public void ProcessDeleteStateModelRequested(StateModelEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StateModelsViewModel)
						{
							(parentView as StateModelsViewModel).ProcessDeleteStateModelPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StateTransition updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateTransitionPerformed, ParameterType = typeof(StateTransitionEventArgs))]
		public void ProcessEditStateTransitionPerformed(StateTransitionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StateViewModel)
						{
							(parentView as StateViewModel).ProcessEditStateTransitionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete StateTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStateTransitionRequested, ParameterType = typeof(StateTransitionEventArgs))]
		public void ProcessDeleteStateTransitionRequested(StateTransitionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StateViewModel)
						{
							(parentView as StateViewModel).ProcessDeleteStateTransitionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Step updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStepPerformed, ParameterType = typeof(StepEventArgs))]
		public void ProcessEditStepPerformed(StepEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StepsViewModel)
						{
							(parentView as StepsViewModel).ProcessEditStepPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Step messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStepRequested, ParameterType = typeof(StepEventArgs))]
		public void ProcessDeleteStepRequested(StepEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StepsViewModel)
						{
							(parentView as StepsViewModel).ProcessDeleteStepPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StepTransition updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStepTransitionPerformed, ParameterType = typeof(StepTransitionEventArgs))]
		public void ProcessEditStepTransitionPerformed(StepTransitionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StepViewModel)
						{
							(parentView as StepViewModel).ProcessEditStepTransitionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete StepTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteStepTransitionRequested, ParameterType = typeof(StepTransitionEventArgs))]
		public void ProcessDeleteStepTransitionRequested(StepTransitionEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is StepViewModel)
						{
							(parentView as StepViewModel).ProcessDeleteStepTransitionPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Value updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditValuePerformed, ParameterType = typeof(ValueEventArgs))]
		public void ProcessEditValuePerformed(ValueEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is EnumerationViewModel)
						{
							(parentView as EnumerationViewModel).ProcessEditValuePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Value messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteValueRequested, ParameterType = typeof(ValueEventArgs))]
		public void ProcessDeleteValueRequested(ValueEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is EnumerationViewModel)
						{
							(parentView as EnumerationViewModel).ProcessDeleteValuePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Workflow updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditWorkflowPerformed, ParameterType = typeof(WorkflowEventArgs))]
		public void ProcessEditWorkflowPerformed(WorkflowEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is WorkflowsViewModel)
						{
							(parentView as WorkflowsViewModel).ProcessEditWorkflowPerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete Workflow messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteWorkflowRequested, ParameterType = typeof(WorkflowEventArgs))]
		public void ProcessDeleteWorkflowRequested(WorkflowEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is WorkflowsViewModel)
						{
							(parentView as WorkflowsViewModel).ProcessDeleteWorkflowPerformed(data);
						}
						break;
					}
				}
			}
		}

		#endregion "Command Processing"

		#region "Events"
		public delegate void SolutionEventHandler(object sender, SolutionEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to show the solution designer.</summary>
		///--------------------------------------------------------------------------------
		public event SolutionEventHandler ShowSolutionDesignerRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles show solution designer requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnShowSolutionDesignerRequested(object sender, SolutionEventArgs args)
		{
			if (ShowSolutionDesignerRequested != null)
			{
				ShowSolutionDesignerRequested(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditSolutionRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessEditSolutionRequested(SolutionEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit AuditProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditAuditPropertyRequested, ParameterType = typeof(AuditPropertyEventArgs))]
		public void ProcessEditAuditPropertyRequested(AuditPropertyEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit CodeTemplate messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditCodeTemplateRequested, ParameterType = typeof(CodeTemplateEventArgs))]
		public void ProcessEditCodeTemplateRequested(CodeTemplateEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Collection messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditCollectionRequested, ParameterType = typeof(CollectionEventArgs))]
		public void ProcessEditCollectionRequested(CollectionEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit DatabaseSource messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditDatabaseSourceRequested, ParameterType = typeof(DatabaseSourceEventArgs))]
		public void ProcessEditDatabaseSourceRequested(DatabaseSourceEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Diagram messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditDiagramRequested, ParameterType = typeof(DiagramEventArgs))]
		public void ProcessEditDiagramRequested(DiagramEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Entity messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEntityRequested, ParameterType = typeof(EntityEventArgs))]
		public void ProcessEditEntityRequested(EntityEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit EntityReference messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEntityReferenceRequested, ParameterType = typeof(EntityReferenceEventArgs))]
		public void ProcessEditEntityReferenceRequested(EntityReferenceEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Enumeration messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEnumerationRequested, ParameterType = typeof(EnumerationEventArgs))]
		public void ProcessEditEnumerationRequested(EnumerationEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Feature messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditFeatureRequested, ParameterType = typeof(FeatureEventArgs))]
		public void ProcessEditFeatureRequested(FeatureEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Index messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditIndexRequested, ParameterType = typeof(IndexEventArgs))]
		public void ProcessEditIndexRequested(IndexEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit IndexProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditIndexPropertyRequested, ParameterType = typeof(IndexPropertyEventArgs))]
		public void ProcessEditIndexPropertyRequested(IndexPropertyEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Method messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditMethodRequested, ParameterType = typeof(MethodEventArgs))]
		public void ProcessEditMethodRequested(MethodEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit MethodRelationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditMethodRelationshipRequested, ParameterType = typeof(MethodRelationshipEventArgs))]
		public void ProcessEditMethodRelationshipRequested(MethodRelationshipEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Model messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelRequested, ParameterType = typeof(ModelEventArgs))]
		public void ProcessEditModelRequested(ModelEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ModelObject messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelObjectRequested, ParameterType = typeof(ModelObjectEventArgs))]
		public void ProcessEditModelObjectRequested(ModelObjectEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ModelProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelPropertyRequested, ParameterType = typeof(ModelPropertyEventArgs))]
		public void ProcessEditModelPropertyRequested(ModelPropertyEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ObjectInstance messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditObjectInstanceRequested, ParameterType = typeof(ObjectInstanceEventArgs))]
		public void ProcessEditObjectInstanceRequested(ObjectInstanceEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Parameter messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditParameterRequested, ParameterType = typeof(ParameterEventArgs))]
		public void ProcessEditParameterRequested(ParameterEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Project messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditProjectRequested, ParameterType = typeof(ProjectEventArgs))]
		public void ProcessEditProjectRequested(ProjectEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Property messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyRequested, ParameterType = typeof(PropertyEventArgs))]
		public void ProcessEditPropertyRequested(PropertyEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit PropertyInstance messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyInstanceRequested, ParameterType = typeof(PropertyInstanceEventArgs))]
		public void ProcessEditPropertyInstanceRequested(PropertyInstanceEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit PropertyReference messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyReferenceRequested, ParameterType = typeof(PropertyReferenceEventArgs))]
		public void ProcessEditPropertyReferenceRequested(PropertyReferenceEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit PropertyRelationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyRelationshipRequested, ParameterType = typeof(PropertyRelationshipEventArgs))]
		public void ProcessEditPropertyRelationshipRequested(PropertyRelationshipEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Relationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditRelationshipRequested, ParameterType = typeof(RelationshipEventArgs))]
		public void ProcessEditRelationshipRequested(RelationshipEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit RelationshipProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditRelationshipPropertyRequested, ParameterType = typeof(RelationshipPropertyEventArgs))]
		public void ProcessEditRelationshipPropertyRequested(RelationshipPropertyEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit SpecTemplate messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditSpecTemplateRequested, ParameterType = typeof(SpecTemplateEventArgs))]
		public void ProcessEditSpecTemplateRequested(SpecTemplateEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Stage messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStageRequested, ParameterType = typeof(StageEventArgs))]
		public void ProcessEditStageRequested(StageEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StageTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStageTransitionRequested, ParameterType = typeof(StageTransitionEventArgs))]
		public void ProcessEditStageTransitionRequested(StageTransitionEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit State messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateRequested, ParameterType = typeof(StateEventArgs))]
		public void ProcessEditStateRequested(StateEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StateModel messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateModelRequested, ParameterType = typeof(StateModelEventArgs))]
		public void ProcessEditStateModelRequested(StateModelEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StateTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateTransitionRequested, ParameterType = typeof(StateTransitionEventArgs))]
		public void ProcessEditStateTransitionRequested(StateTransitionEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Step messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStepRequested, ParameterType = typeof(StepEventArgs))]
		public void ProcessEditStepRequested(StepEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StepTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStepTransitionRequested, ParameterType = typeof(StepTransitionEventArgs))]
		public void ProcessEditStepTransitionRequested(StepTransitionEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Value messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditValueRequested, ParameterType = typeof(ValueEventArgs))]
		public void ProcessEditValueRequested(ValueEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Workflow messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditWorkflowRequested, ParameterType = typeof(WorkflowEventArgs))]
		public void ProcessEditWorkflowRequested(WorkflowEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit XmlSource messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditXmlSourceRequested, ParameterType = typeof(XmlSourceEventArgs))]
		public void ProcessEditXmlSourceRequested(XmlSourceEventArgs data)
		{
			OnShowSolutionDesignerRequested(this, null);
		}

		#endregion "Events"

		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Solutions folder.</summary>
		///--------------------------------------------------------------------------------
		public SolutionsViewModel SolutionsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Resources folder.</summary>
		///--------------------------------------------------------------------------------
		public ResourcesViewModel ResourcesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PasteViewModel folder.</summary>
		///--------------------------------------------------------------------------------
		public IWorkspaceViewModel PasteViewModel { get; set; }

		BackgroundWorker _initializationWorker = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the initialization worker.</summary>
		///--------------------------------------------------------------------------------
		BackgroundWorker InitializationWorker
		{
			get
			{
				if (_initializationWorker == null)
				{
					_initializationWorker = new BackgroundWorker();
					_initializationWorker.WorkerReportsProgress = true;
					_initializationWorker.WorkerSupportsCancellation = true;
					_initializationWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(InitializationWorker_RunWorkerCompleted);
					_initializationWorker.Disposed += new EventHandler(InitializationWorker_Disposed);
					_initializationWorker.ProgressChanged += new ProgressChangedEventHandler(InitializationWorker_ProgressChanged);
				}
				return _initializationWorker;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the initialization work handler.</summary>
		///--------------------------------------------------------------------------------
		protected DoWorkEventHandler InitializationWorkHandler { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the initialization work completed handler.</summary>
		///--------------------------------------------------------------------------------
		protected RunWorkerCompletedEventHandler InitializationWorkCompletedHandler { get; set; }

		#endregion "Fields and Properties"

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
			if (refreshChildren == true || refreshLevel > 0)
			{
				SolutionsFolder.Refresh(refreshChildren, refreshLevel-1);
				ResourcesFolder.Refresh(refreshChildren, refreshLevel-1);
			}
			if (SolutionsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (SolutionsFolder.HasCustomizations == true)
			{
				HasCustomizations = true;
			}
			if (ResourcesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (ResourcesFolder.HasCustomizations == true)
			{
				HasCustomizations = true;
			}
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			SolutionsFolder.Updated -= Children_Updated;
			SolutionsFolder = null;
			ResourcesFolder.Updated -= Children_Updated;
			ResourcesFolder = null;
			PasteViewModel = null;
			_initializationWorker = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method manages the update of this view when children are updated.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_Updated(object sender, EventArgs e)
		{
			Refresh(false, 1);
			OnUpdated(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method runs initialization on the initialization background worker.</summary>
		///--------------------------------------------------------------------------------
		protected void RunInitializationJob()
		{
			try
			{
				if (InitializationWorker.IsBusy == false)
				{
					if (InitializationWorkHandler != null)
					{
						// remove previous work
						InitializationWorker.DoWork -= InitializationWorkHandler;
						InitializationWorkHandler = null;
					}
					if (InitializationWorkCompletedHandler != null)
					{
						// remove completed handler
						InitializationWorker.RunWorkerCompleted -= InitializationWorkCompletedHandler;
						InitializationWorkCompletedHandler = null;
					}
					InitializationWorkHandler = new DoWorkEventHandler(InitializeData);
					InitializationWorker.DoWork += InitializationWorkHandler;

					InitializationWorker.RunWorkerAsync(InitializationWorker);
				}
				else
				{
					ShowIssue(Resources.DisplayValues.Thread_InitializationThreadBusy);
				}
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initializes data needed by the application.</summary>
		///--------------------------------------------------------------------------------
		protected void InitializeData(object sender, DoWorkEventArgs e)
		{
			try
			{
				// transform some data to set up cache
				Solution testSolution = new Solution();
				Solution testSolution2 = new Solution();
				testSolution2.AuditPropertyList.Add(new AuditProperty());
				testSolution2.CollectionList.Add(new Collection());
				testSolution2.PropertyReferenceList.Add(new PropertyReference());
				testSolution2.DatabaseSourceList.Add(new DatabaseSource());
				testSolution2.XmlSourceList.Add(new XmlSource());
				testSolution2.ProjectList.Add(new Project());
				testSolution2.PropertyList.Add(new Property());
				testSolution2.IndexList.Add(new Index());
				testSolution2.IndexPropertyList.Add(new IndexProperty());
				testSolution2.EntityList.Add(new Entity());
				testSolution2.RelationshipList.Add(new Relationship());
				testSolution2.RelationshipPropertyList.Add(new RelationshipProperty());
				testSolution2.FeatureList.Add(new Feature());
				testSolution2.MethodList.Add(new Method());
				testSolution2.ParameterList.Add(new Parameter());
				testSolution2.MethodRelationshipList.Add(new MethodRelationship());
				testSolution2.PropertyRelationshipList.Add(new PropertyRelationship());
				testSolution2.EntityReferenceList.Add(new EntityReference());
				testSolution.TransformDataFromObject(testSolution2, null);

				// load a recent solution (TODO: look for initial load slowdown)
				foreach (RecentSolution loopSolution in BusinessConfiguration.RecentSolutionList)
				{
					testSolution.Load(loopSolution.RecentSolutionLocation);
					break;
				}
				testSolution2 = null;
				testSolution = null;

				// load library convention data
				int i = 0;
				i += DataConventionHelper.DataTypes.Count;
				i += DataConventionHelper.EntityTypes.Count;
				i += DataConventionHelper.IdentifierTypes.Count;
				i += DataConventionHelper.MethodTypes.Count;
				if (i == 0)
				{
					ShowIssue(Resources.DisplayValues.Issue_LibraryResourcesMissing);
				}
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reporting ongoing progress of the initialization job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void InitializationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles disposing of the background worker.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void InitializationWorker_Disposed(object sender, EventArgs e)
		{
			_initializationWorker = null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reporting completed progress of the initialization job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void InitializationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ShowOutput(Resources.DisplayValues.Thread_InitializationDone, Resources.DisplayValues.Task_InitializationTitle, true);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor.</summary>
		///--------------------------------------------------------------------------------
		public BuilderViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Root;

			// Register all decorated methods to the Mediator
			Mediator.Register(this);

			// create the solutions folder
			SolutionsFolder = new SolutionsViewModel(true);
			SolutionsFolder.Updated += new EventHandler(Children_Updated);

			// create the resources folder
			ResourcesFolder = new ResourcesViewModel();
			ResourcesFolder.Updated += new EventHandler(Children_Updated);

			Refresh(false);
			Items.Add(SolutionsFolder);
			Items.Add(ResourcesFolder);

			// initialize data
			RunInitializationJob();
		}

		#endregion "Constructors"
	}
}
