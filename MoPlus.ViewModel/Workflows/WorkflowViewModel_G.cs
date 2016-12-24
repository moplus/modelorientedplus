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
using System.Windows.Input;
using System.ComponentModel;
using MoPlus.Data;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Events.Models;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.ViewModel.Workflows;

namespace MoPlus.ViewModel.Workflows
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for Workflow instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/12/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class WorkflowViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewWorkflow.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewWorkflow
		{
			get
			{
				return DisplayValues.ContextMenu_NewWorkflow;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlWorkflowToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelWorkflowToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewWorkflowToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStage.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStage
		{
			get
			{
				return DisplayValues.ContextMenu_NewStage;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStageToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStageToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEdit.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEdit
		{
			get
			{
				return DisplayValues.ContextMenu_Edit;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEditToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEditToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_EditToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelDelete.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDelete
		{
			get
			{
				return DisplayValues.ContextMenu_Delete;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelDeleteToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDeleteToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_DeleteToolTip;
			}
		}

		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEdited.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEdited
		{
			get
			{
				if (EditWorkflow.IsModified == true)
				{
					return true;
				}
				if (ItemsToAdd.Count > 0)
				{
					return true;
				}
				if (ItemsToDelete.Count > 0)
				{
					return true;
				}
				foreach (IEditWorkspaceViewModel item in Items)
				{
					if (item.IsEdited == true)
					{
						return true;
					}
				}
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEditItemValid.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEditItemValid
		{
			get
			{
				return string.IsNullOrEmpty(WorkflowNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Workflow _editWorkflow = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditWorkflow.</summary>
		///--------------------------------------------------------------------------------
		public Workflow EditWorkflow
		{
			get
			{
				if (_editWorkflow == null)
				{
					_editWorkflow = new Workflow();
					_editWorkflow.PropertyChanged += new PropertyChangedEventHandler(EditWorkflow_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Workflow != null)
					{
						_editWorkflow.TransformDataFromObject(Workflow, null, false);
						_editWorkflow.Solution = Workflow.Solution;
					}
					_editWorkflow.ResetModified(false);
				}
				return _editWorkflow;
			}
			set
			{
				_editWorkflow = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditWorkflow_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditWorkflow");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("WorkflowName");
			OnPropertyChanged("WorkflowNameCustomized");
			OnPropertyChanged("WorkflowNameValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");

			OnPropertyChanged("Tags");
			OnPropertyChanged("TagsCustomized");
			OnPropertyChanged("TagsValidationMessage");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title
		{
			get
			{
				return DisplayValues.Edit_WorkflowHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_WorkflowHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the WorkflowIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string WorkflowIDLabel
		{
			get
			{
				return DisplayValues.Edit_WorkflowIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the WorkflowNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string WorkflowNameLabel
		{
			get
			{
				return DisplayValues.Edit_WorkflowNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets WorkflowName.</summary>
		///--------------------------------------------------------------------------------
		public string WorkflowName
		{
			get
			{
				return EditWorkflow.WorkflowName;
			}
			set
			{
				EditWorkflow.WorkflowName = value;
				OnPropertyChanged("WorkflowName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets WorkflowNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool WorkflowNameCustomized
		{
			get
			{
				if (Workflow.ReverseInstance != null)
				{
					return WorkflowName.GetString() != Workflow.ReverseInstance.WorkflowName.GetString();
				}
				else if (Workflow.IsAutoUpdated == true)
				{
					return WorkflowName.GetString() != Workflow.WorkflowName.GetString();
				}
				return WorkflowName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets WorkflowNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string WorkflowNameValidationMessage
		{
			get
			{
				return EditWorkflow.ValidateWorkflowName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DescriptionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionLabel
		{
			get
			{
				return DisplayValues.Edit_DescriptionProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Description.</summary>
		///--------------------------------------------------------------------------------
		public string Description
		{
			get
			{
				return EditWorkflow.Description;
			}
			set
			{
				EditWorkflow.Description = value;
				OnPropertyChanged("Description");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DescriptionCustomized
		{
			get
			{
				if (Workflow.ReverseInstance != null)
				{
					return Description.GetString() != Workflow.ReverseInstance.Description.GetString();
				}
				else if (Workflow.IsAutoUpdated == true)
				{
					return Description.GetString() != Workflow.Description.GetString();
				}
				return Description != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionValidationMessage
		{
			get
			{
				return EditWorkflow.ValidateDescription();
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SourceName
		{
			get
			{
				return EditWorkflow.SourceName;
			}
			set
			{
				EditWorkflow.SourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SpecSourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SpecSourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SpecSourceName
		{
			get
			{
				return EditWorkflow.SpecSourceName;
			}
			set
			{
				EditWorkflow.SpecSourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SpecSourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SpecSourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TagsLabel
		{
			get
			{
				return DisplayValues.Edit_TagsProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Tags.</summary>
		///--------------------------------------------------------------------------------
		public override string Tags
		{
			get
			{
				return EditWorkflow.Tags;
			}
			set
			{
				EditWorkflow.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Workflow.ReverseInstance != null)
				{
					return Tags != Workflow.ReverseInstance.Tags;
				}
				else if (Workflow.IsAutoUpdated == true)
				{
					return Tags != Workflow.Tags;
				}
				return Tags != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TagsValidationMessage
		{
			get
			{
				return EditWorkflow.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditWorkflow.Name;
			}
			set
			{
				EditWorkflow.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditWorkflow.TransformDataFromObject(Workflow, null, false);
			EditWorkflow.ResetModified(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		public override void Reset()
		{
			OnReset();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnSetDefaults()
		{
			if (Workflow.ReverseInstance != null)
			{
				EditWorkflow.TransformDataFromObject(Workflow.ReverseInstance, null, false);
			}
			else if (Workflow.IsAutoUpdated == true)
			{
				EditWorkflow.TransformDataFromObject(Workflow, null, false);
			}
			else
			{
				Workflow newWorkflow = new Workflow();
				newWorkflow.WorkflowID = EditWorkflow.WorkflowID;
				EditWorkflow.TransformDataFromObject(newWorkflow, null, false);
			}
			EditWorkflow.ResetModified(true);
			foreach (StageViewModel item in Items.OfType<StageViewModel>())
			{
				item.Defaults();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Workflow command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewWorkflowCommand()
		{
			WorkflowEventArgs message = new WorkflowEventArgs();
			message.Workflow = new Workflow();
			message.Workflow.WorkflowID = Guid.NewGuid();
			message.Workflow.SolutionID = SolutionID;
			message.Workflow.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<WorkflowEventArgs>(MediatorMessages.Command_EditWorkflowRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditWorkflowCommand()
		{
			WorkflowEventArgs message = new WorkflowEventArgs();
			message.Workflow = Workflow;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<WorkflowEventArgs>(MediatorMessages.Command_EditWorkflowRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Stage adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewStage()
		{
			StageViewModel item = new StageViewModel();
			item.Stage = new Stage();
			item.Stage.StageID = Guid.NewGuid();
			item.Stage.Workflow = EditWorkflow;
			item.Stage.WorkflowID = EditWorkflow.WorkflowID;
			item.Stage.Solution = Solution;
			item.Stage.Order = Workflow.StageList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Stage command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStageCommand()
		{
			StageEventArgs message = new StageEventArgs();
			message.Stage = new Stage();
			message.Stage.StageID = Guid.NewGuid();
			message.Stage.Workflow = Workflow;
			message.Stage.WorkflowID = Workflow.WorkflowID;
			message.WorkflowID = Workflow.WorkflowID;
			if (message.Stage.Workflow != null)
			{
				message.Stage.Order = message.Stage.Workflow.StageList.Count + 1;
			}
			message.Stage.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageEventArgs>(MediatorMessages.Command_EditStageRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Stage updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStagePerformed(StageEventArgs data)
		{
			if (data != null && data.Stage != null)
			{
				UpdateEditStage(data.Stage);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of Stage.</summary>
		/// 
		/// <param name="stage">The Stage to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditStage(Stage stage)
		{
			bool isItemMatch = false;
			foreach (StageViewModel item in Stages)
			{
				if (item.Stage.StageID == stage.StageID)
				{
					isItemMatch = true;
					item.Stage.TransformDataFromObject(stage, null, false);
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new Stage
				stage.Workflow = Workflow;
				StageViewModel newItem = new StageViewModel(stage, Solution);
				newItem.Updated += new EventHandler(Children_Updated);
				Stages.Add(newItem);
				Workflow.StageList.Add(stage);
				Solution.StageList.Add(newItem.Stage);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Stage deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedStages(StageViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Stage deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStagePerformed(StageEventArgs data)
		{
			if (data != null && data.Stage != null)
			{
				DeleteStage(data.Stage);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Stage.</summary>
		/// 
		/// <param name="stage">The Stage to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStage(Stage stage)
		{
			bool isItemMatch = false;
			foreach (StageViewModel item in Stages.ToList<StageViewModel>())
			{
				if (item.Stage.StageID == stage.StageID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.Stage.StageID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete Stage
					isItemMatch = true;
					Stages.Remove(item);
					Workflow.StageList.Remove(item.Stage);
					Solution.StageList.Remove(item.Stage);
					Items.Remove(item);
					Workflow.ResetModified(true);
					OnUpdated(this, null);
					break;
				}
			}
			if (isItemMatch == false)
			{
				ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewWorkflowCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Workflow.ReverseInstance == null && Workflow.IsAutoUpdated == true)
			{
				Workflow.ReverseInstance = new Workflow();
				Workflow.ReverseInstance.TransformDataFromObject(Workflow, null, false);

				// perform the update of EditWorkflow back to Workflow
				Workflow.TransformDataFromObject(EditWorkflow, null, false);
				Workflow.IsAutoUpdated = false;
			}
			else if (Workflow.ReverseInstance != null)
			{
				EditWorkflow.ResetModified(Workflow.ReverseInstance.IsModified);
				if (EditWorkflow.Equals(Workflow.ReverseInstance))
				{
					// perform the update of EditWorkflow back to Workflow
					Workflow.TransformDataFromObject(EditWorkflow, null, false);
					Workflow.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditWorkflow back to Workflow
					Workflow.TransformDataFromObject(EditWorkflow, null, false);
					Workflow.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditWorkflow back to Workflow
				Workflow.TransformDataFromObject(EditWorkflow, null, false);
				Workflow.IsAutoUpdated = false;
			}
			Workflow.ForwardInstance = null;
			if (WorkflowNameCustomized || DescriptionCustomized || TagsCustomized)
			{
				Workflow.ForwardInstance = new Workflow();
				Workflow.ForwardInstance.WorkflowID = EditWorkflow.WorkflowID;
				Workflow.SpecSourceName = Workflow.DefaultSourceName;
				if (WorkflowNameCustomized)
				{
					Workflow.ForwardInstance.WorkflowName = EditWorkflow.WorkflowName;
				}
				if (DescriptionCustomized)
				{
					Workflow.ForwardInstance.Description = EditWorkflow.Description;
				}
				if (TagsCustomized)
				{
					Workflow.ForwardInstance.Tags = EditWorkflow.Tags;
				}
			}
			EditWorkflow.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditWorkflowPerformed();

			// send update for any updated Stages
			foreach (StageViewModel item in Stages)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new Stages
			foreach (StageViewModel item in ItemsToAdd.OfType<StageViewModel>())
			{
				item.Update();
				Stages.Add(item);
			}

			// send delete for any deleted Stages
			foreach (StageViewModel item in ItemsToDelete.OfType<StageViewModel>())
			{
				item.Delete();
				Stages.Remove(item);
			}

			// reset modified for Stages
			foreach (StageViewModel item in Stages)
			{
				item.ResetModified(false);
			}
			ItemsToAdd.Clear();
			ItemsToDelete.Clear();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		public void Update()
		{
			OnUpdate();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends the edit item performed message to have the
		/// update applied.</summary>
		///--------------------------------------------------------------------------------
		public void SendEditWorkflowPerformed()
		{
			WorkflowEventArgs message = new WorkflowEventArgs();
			message.Workflow = Workflow;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<WorkflowEventArgs>(MediatorMessages.Command_EditWorkflowPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Workflow command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteWorkflowCommand()
		{
			WorkflowEventArgs message = new WorkflowEventArgs();
			message.Workflow = Workflow;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<WorkflowEventArgs>(MediatorMessages.Command_DeleteWorkflowRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteWorkflowCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Stage lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StageViewModel> Stages { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Workflow.</summary>
		///--------------------------------------------------------------------------------
		public Workflow Workflow { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets WorkflowID.</summary>
		///--------------------------------------------------------------------------------
		public Guid WorkflowID
		{
			get
			{
				return Workflow.WorkflowID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Workflow.Name;
			}
			set
			{
				Workflow.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Workflow into the view model.</summary>
		/// 
		/// <param name="workflow">The Workflow to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadWorkflow(Workflow workflow, bool loadChildren = true)
		{
			// attach the Workflow
			Workflow = workflow;
			ItemID = Workflow.WorkflowID;
			Items.Clear();
			
			// initialize Stages
			if (Stages == null)
			{
				Stages = new EnterpriseDataObjectList<StageViewModel>();
			}
			if (loadChildren == true)
			{
				// attach Stages
				foreach (Stage item in workflow.StageList)
				{
					StageViewModel itemView = new StageViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Stages.Add(itemView);
					Items.Add(itemView);
				}
				#region protected
				#endregion protected
				
				Refresh(false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			if (refreshChildren == true || refreshLevel > 0)
			{
				foreach (StageViewModel item in Stages)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Workflow.IsValid;
			HasCustomizations = Workflow.IsAutoUpdated == false || Workflow.IsEmptyMetadata(Workflow.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Workflow.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Workflow.IsAutoUpdated = true;
				Workflow.SpecSourceName = Workflow.ReverseInstance.SpecSourceName;
				Workflow.ResetModified(Workflow.ReverseInstance.IsModified);
				Workflow.ResetLoaded(Workflow.ReverseInstance.IsLoaded);
				if (!Workflow.IsIdenticalMetadata(Workflow.ReverseInstance))
				{
					HasCustomizations = true;
					Workflow.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Workflow.ForwardInstance = null;
				Workflow.ReverseInstance = null;
				Workflow.IsAutoUpdated = true;
			}
			foreach (StageViewModel item in Stages)
			{
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			Items.Sort("ItemOrder", SortDirection.Ascending);
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (Stages != null)
			{
				for (int i = Stages.Count - 1; i >= 0; i--)
				{
					Stages[i].Updated -= Children_Updated;
					Stages[i].Dispose();
					Stages.Remove(Stages[i]);
				}
				Stages = null;
			}
			if (_editWorkflow != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditWorkflow.PropertyChanged -= EditWorkflow_PropertyChanged;
				EditWorkflow = null;
			}
			Workflow = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (StageViewModel item in Stages)
			{
				if (item.HasCustomizations == true)
				{
					return true;
				}
			}
			return false;
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
			OnUpdated(this, e);
		}
	
		///--------------------------------------------------------------------------------
		/// <summary>This method manages when changes occur to child collections.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("StageList");
			OnPropertyChanged("StageListCustomized");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns the parent view model corresponding to
		/// the input message.</summary>
		///
		/// <param name="data">The message data to find parent for.</param>
		///--------------------------------------------------------------------------------
		public EditWorkspaceViewModel FindParentViewModel(SolutionModelEventArgs data)
		{
			EditWorkspaceViewModel parentModel = null;
			if (data is StageEventArgs && (data as StageEventArgs).WorkflowID == Workflow.WorkflowID)
			{
				return this;
			}
			foreach (StageViewModel model in Stages)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public StageViewModel PasteStage(StageViewModel copyItem, bool savePaste = true)
		{
			Stage newItem = new Stage();
			newItem.ReverseInstance = new Stage();
			newItem.TransformDataFromObject(copyItem.Stage, null, false);
			newItem.StageID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			newItem.Workflow = Workflow;
			newItem.Solution = Solution;
			StageViewModel newView = new StageViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddStage(newView);
			if (savePaste == true)
			{
				Solution.StageList.Add(newItem);
				Workflow.StageList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Stage to the view model.</summary>
		/// 
		/// <param name="itemView">The Stage to add.</param>
		///--------------------------------------------------------------------------------
		public void AddStage(StageViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Stages.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Stage from the view model.</summary>
		/// 
		/// <param name="itemView">The Stage to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStage(StageViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Stages.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public WorkflowViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="workflow">The Workflow to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public WorkflowViewModel(Workflow workflow, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadWorkflow(workflow, loadChildren);
		}

		#endregion "Constructors"
	}
}
