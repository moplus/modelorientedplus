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
	/// <summary>This class provides views for Stage instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/20/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class StageViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlStageToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStageToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStageTransition.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStageTransition
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageTransition;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStageTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStageTransitionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageTransitionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStep.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStep
		{
			get
			{
				return DisplayValues.ContextMenu_NewStep;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStepToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStepToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepToolTip;
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
				if (EditStage.IsModified == true)
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
				return string.IsNullOrEmpty(StageNameValidationMessage + OrderValidationMessage + DescriptionValidationMessage + ToStageTransitionListValidationMessage);
			}
		}
 
		private Stage _editStage = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditStage.</summary>
		///--------------------------------------------------------------------------------
		public Stage EditStage
		{
			get
			{
				if (_editStage == null)
				{
					_editStage = new Stage();
					_editStage.PropertyChanged += new PropertyChangedEventHandler(EditStage_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Stage != null)
					{
						_editStage.TransformDataFromObject(Stage, null, false);
						_editStage.Solution = Stage.Solution;
						_editStage.Workflow = Stage.Workflow;
					}
					_editStage.ResetModified(false);
				}
				return _editStage;
			}
			set
			{
				_editStage = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditStage_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditStage");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StageName");
			OnPropertyChanged("StageNameCustomized");
			OnPropertyChanged("StageNameValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ToStageTransitionList");
			OnPropertyChanged("ToStageTransitionListCustomized");
			OnPropertyChanged("ToStageTransitionListValidationMessage");

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
				return DisplayValues.Edit_StageHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StageHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StageIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StageIDLabel
		{
			get
			{
				return DisplayValues.Edit_StageIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ToStageTransitionListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ToStageTransitionListLabel
		{
			get
			{
				return DisplayValues.Edit_ToStageTransitionListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ToStageTransitionList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StageTransition> ToStageTransitionList
		{
			get
			{
				return EditStage.ToStageTransitionList;
			}
			set
			{
				EditStage.ToStageTransitionList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToStageTransitionListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ToStageTransitionListCustomized
		{
			get
			{
				#region protected
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToStageTransitionListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ToStageTransitionListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StageNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StageNameLabel
		{
			get
			{
				return DisplayValues.Edit_StageNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StageName.</summary>
		///--------------------------------------------------------------------------------
		public string StageName
		{
			get
			{
				return EditStage.StageName;
			}
			set
			{
				EditStage.StageName = value;
				OnPropertyChanged("StageName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StageNameCustomized
		{
			get
			{
				if (Stage.ReverseInstance != null)
				{
					return StageName.GetString() != Stage.ReverseInstance.StageName.GetString();
				}
				else if (Stage.IsAutoUpdated == true)
				{
					return StageName.GetString() != Stage.StageName.GetString();
				}
				return StageName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StageNameValidationMessage
		{
			get
			{
				return EditStage.ValidateStageName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the OrderLabel.</summary>
		///--------------------------------------------------------------------------------
		public string OrderLabel
		{
			get
			{
				return DisplayValues.Edit_OrderProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Order.</summary>
		///--------------------------------------------------------------------------------
		public int Order
		{
			get
			{
				return EditStage.Order;
			}
			set
			{
				EditStage.Order = value;
				OnPropertyChanged("Order");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets OrderCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool OrderCustomized
		{
			get
			{
				if (Stage.ReverseInstance != null)
				{
					return Order.GetInt() != Stage.ReverseInstance.Order.GetInt();
				}
				else if (Stage.IsAutoUpdated == true)
				{
					return Order.GetInt() != Stage.Order.GetInt();
				}
				return Order != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets OrderValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string OrderValidationMessage
		{
			get
			{
				return EditStage.ValidateOrder();
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
				return EditStage.Description;
			}
			set
			{
				EditStage.Description = value;
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
				if (Stage.ReverseInstance != null)
				{
					return Description.GetString() != Stage.ReverseInstance.Description.GetString();
				}
				else if (Stage.IsAutoUpdated == true)
				{
					return Description.GetString() != Stage.Description.GetString();
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
				return EditStage.ValidateDescription();
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
				return EditStage.SourceName;
			}
			set
			{
				EditStage.SourceName = value;
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
				return EditStage.SpecSourceName;
			}
			set
			{
				EditStage.SpecSourceName = value;
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
				return EditStage.Tags;
			}
			set
			{
				EditStage.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Stage.ReverseInstance != null)
				{
					return Tags != Stage.ReverseInstance.Tags;
				}
				else if (Stage.IsAutoUpdated == true)
				{
					return Tags != Stage.Tags;
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
				return EditStage.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditStage.Name;
			}
			set
			{
				EditStage.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditStage.TransformDataFromObject(Stage, null, false);
			ResetItems();
			
			#region protected
			foreach (StageTransitionViewModel transition in StageTransitionsFolder.Items.OfType<StageTransitionViewModel>())
			{
				transition.Reset();
			}
			if (ItemsToDelete.Count > 0)
			{
				foreach (StageTransitionViewModel transition in StageTransitionsFolder.ItemsToDelete.OfType<StageTransitionViewModel>())
				{
					transition.Reset();
					StageTransitionsFolder.Items.Add(transition);
				}
				ItemsToDelete.Clear();
			}
			if (ItemsToAdd.Count > 0)
			{
				foreach (StageTransitionViewModel transition in StageTransitionsFolder.ItemsToAdd.OfType<StageTransitionViewModel>())
				{
					StageTransitionsFolder.Items.Remove(transition);
				}
				ItemsToAdd.Clear();
			}
			#endregion protected

			EditStage.ResetModified(false);
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
			if (Stage.ReverseInstance != null)
			{
				EditStage.TransformDataFromObject(Stage.ReverseInstance, null, false);
			}
			else if (Stage.IsAutoUpdated == true)
			{
				EditStage.TransformDataFromObject(Stage, null, false);
			}
			else
			{
				Stage newStage = new Stage();
				newStage.StageID = EditStage.StageID;
				EditStage.TransformDataFromObject(newStage, null, false);
			}
			EditStage.ResetModified(true);
			foreach (StageTransitionViewModel item in Items.OfType<StageTransitionViewModel>())
			{
				item.Defaults();
			}
			foreach (StepViewModel item in Items.OfType<StepViewModel>())
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
		/// <summary>This method processes the new Stage command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStageCommand()
		{
			StageEventArgs message = new StageEventArgs();
			message.Stage = new Stage();
			message.Stage.StageID = Guid.NewGuid();
			message.Stage.WorkflowID = WorkflowID;
			message.Stage.Workflow = Solution.WorkflowList.FindByID((Guid)WorkflowID);
			if (message.Stage.Workflow != null)
			{
				message.Stage.Order = message.Stage.Workflow.StageList.Count + 1;
			}
			message.Stage.Solution = Solution;
			message.WorkflowID = WorkflowID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageEventArgs>(MediatorMessages.Command_EditStageRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStageCommand()
		{
			StageEventArgs message = new StageEventArgs();
			message.Stage = Stage;
			message.WorkflowID = WorkflowID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageEventArgs>(MediatorMessages.Command_EditStageRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewStageCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Stage.ReverseInstance == null && Stage.IsAutoUpdated == true)
			{
				Stage.ReverseInstance = new Stage();
				Stage.ReverseInstance.TransformDataFromObject(Stage, null, false);

				// perform the update of EditStage back to Stage
				Stage.TransformDataFromObject(EditStage, null, false);
				Stage.IsAutoUpdated = false;
			}
			else if (Stage.ReverseInstance != null)
			{
				EditStage.ResetModified(Stage.ReverseInstance.IsModified);
				if (EditStage.Equals(Stage.ReverseInstance))
				{
					// perform the update of EditStage back to Stage
					Stage.TransformDataFromObject(EditStage, null, false);
					Stage.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditStage back to Stage
					Stage.TransformDataFromObject(EditStage, null, false);
					Stage.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditStage back to Stage
				Stage.TransformDataFromObject(EditStage, null, false);
				Stage.IsAutoUpdated = false;
			}
			Stage.ForwardInstance = null;
			if (StageNameCustomized || OrderCustomized || DescriptionCustomized || ToStageTransitionListCustomized || TagsCustomized)
			{
				Stage.ForwardInstance = new Stage();
				Stage.ForwardInstance.StageID = EditStage.StageID;
				Stage.SpecSourceName = Stage.DefaultSourceName;
				if (StageNameCustomized)
				{
					Stage.ForwardInstance.StageName = EditStage.StageName;
				}
				if (OrderCustomized)
				{
					Stage.ForwardInstance.Order = EditStage.Order;
				}
				if (DescriptionCustomized)
				{
					Stage.ForwardInstance.Description = EditStage.Description;
				}
				if (ToStageTransitionListCustomized)
				{
					#region protected
					#endregion protected
					// Stage.ToStageTransitionList = new EnterpriseDataObjectList<StageTransition>(EditStage.ToStageTransitionList, null);
					// Stage.ForwardInstance.ToStageTransitionList = new EnterpriseDataObjectList<StageTransition>(EditStage.ToStageTransitionList, null);
				}
				if (TagsCustomized)
				{
					Stage.ForwardInstance.Tags = EditStage.Tags;
				}
			}
			EditStage.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStagePerformed();

			// send update for any updated StageTransitions
			if (StageTransitionsFolder != null && StageTransitionsFolder.IsEdited == true)
			{
				StageTransitionsFolder.Update();
			}

			// send update for any updated Steps
			if (StepsFolder != null && StepsFolder.IsEdited == true)
			{
				StepsFolder.Update();
			}
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
		public void SendEditStagePerformed()
		{
			StageEventArgs message = new StageEventArgs();
			message.Stage = Stage;
			message.WorkflowID = WorkflowID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageEventArgs>(MediatorMessages.Command_EditStagePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Stage command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStageCommand()
		{
			StageEventArgs message = new StageEventArgs();
			message.Stage = Stage;
			message.WorkflowID = WorkflowID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageEventArgs>(MediatorMessages.Command_DeleteStageRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStageCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StageTransition lists.</summary>
		///--------------------------------------------------------------------------------
		public StageTransitionsViewModel StageTransitionsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Step lists.</summary>
		///--------------------------------------------------------------------------------
		public StepsViewModel StepsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Stage.</summary>
		///--------------------------------------------------------------------------------
		public Stage Stage { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StageID
		{
			get
			{
				return Stage.StageID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Stage.Name;
			}
			set
			{
				Stage.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return Stage.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets WorkflowID.</summary>
		///--------------------------------------------------------------------------------
		public Guid WorkflowID
		{
			get
			{
				return Stage.WorkflowID;
			}
			set
			{
				Stage.WorkflowID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Stage into the view model.</summary>
		/// 
		/// <param name="stage">The Stage to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStage(Stage stage, bool loadChildren = true)
		{
			// attach the Stage
			Stage = stage;
			ItemID = Stage.StageID;
			Items.Clear();
			if (loadChildren == true)
			{
				// attach StageTransitions
				if (StageTransitionsFolder == null)
				{
					StageTransitionsFolder = new StageTransitionsViewModel(stage, Solution);
					StageTransitionsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(StageTransitionsFolder);
				}
								
				// attach Steps
				if (StepsFolder == null)
				{
					StepsFolder = new StepsViewModel(stage, Solution);
					StepsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(StepsFolder);
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
				StageTransitionsFolder.Refresh(refreshChildren, refreshLevel - 1);
				StepsFolder.Refresh(refreshChildren, refreshLevel - 1);
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Stage.IsValid;
			HasCustomizations = Stage.IsAutoUpdated == false || Stage.IsEmptyMetadata(Stage.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Stage.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Stage.IsAutoUpdated = true;
				Stage.SpecSourceName = Stage.ReverseInstance.SpecSourceName;
				Stage.ResetModified(Stage.ReverseInstance.IsModified);
				Stage.ResetLoaded(Stage.ReverseInstance.IsLoaded);
				if (!Stage.IsIdenticalMetadata(Stage.ReverseInstance))
				{
					HasCustomizations = true;
					Stage.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Stage.ForwardInstance = null;
				Stage.ReverseInstance = null;
				Stage.IsAutoUpdated = true;
			}
			if (StageTransitionsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (StepsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (StageTransitionsFolder != null)
			{
				StageTransitionsFolder.Updated -= Children_Updated;
				StageTransitionsFolder.Dispose();
				StageTransitionsFolder = null;
			}
			if (StepsFolder != null)
			{
				StepsFolder.Updated -= Children_Updated;
				StepsFolder.Dispose();
				StepsFolder = null;
			}
			if (_editStage != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditStage.PropertyChanged -= EditStage_PropertyChanged;
				EditStage = null;
			}
			Stage = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			if (StageTransitionsFolder != null && StageTransitionsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (StepsFolder != null && StepsFolder.HasCustomizations == true)
			{
				return true;
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
			parentModel = StageTransitionsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = StepsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StageViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="stage">The Stage to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StageViewModel(Stage stage, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadStage(stage, loadChildren);
		}

		#endregion "Constructors"
	}
}
