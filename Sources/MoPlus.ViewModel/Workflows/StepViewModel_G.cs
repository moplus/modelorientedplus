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
	/// <summary>This class provides views for Step instances.</summary>
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
	public partial class StepViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlStepToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStepToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStepTransition.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStepTransition
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepTransition;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStepTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStepTransitionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepTransitionToolTip;
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
				if (EditStep.IsModified == true)
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
				return string.IsNullOrEmpty(StepNameValidationMessage + OrderValidationMessage + DescriptionValidationMessage + ToStepTransitionListValidationMessage);
			}
		}
 
		private Step _editStep = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditStep.</summary>
		///--------------------------------------------------------------------------------
		public Step EditStep
		{
			get
			{
				if (_editStep == null)
				{
					_editStep = new Step();
					_editStep.PropertyChanged += new PropertyChangedEventHandler(EditStep_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Step != null)
					{
						_editStep.TransformDataFromObject(Step, null, false);
						_editStep.Solution = Step.Solution;
						_editStep.Stage = Step.Stage;
					}
					_editStep.ResetModified(false);
				}
				return _editStep;
			}
			set
			{
				_editStep = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditStep_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditStep");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StepName");
			OnPropertyChanged("StepNameCustomized");
			OnPropertyChanged("StepNameValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ToStepTransitionList");
			OnPropertyChanged("ToStepTransitionListCustomized");
			OnPropertyChanged("ToStepTransitionListValidationMessage");

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
				return DisplayValues.Edit_StepHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StepHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StepIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StepIDLabel
		{
			get
			{
				return DisplayValues.Edit_StepIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ToStepTransitionListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ToStepTransitionListLabel
		{
			get
			{
				return DisplayValues.Edit_ToStepTransitionListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ToStepTransitionList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StepTransition> ToStepTransitionList
		{
			get
			{
				return EditStep.ToStepTransitionList;
			}
			set
			{
				EditStep.ToStepTransitionList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToStepTransitionListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ToStepTransitionListCustomized
		{
			get
			{
				#region protected
				foreach (StepTransitionViewModel item in Items.OfType<StepTransitionViewModel>())
				{
					if (item.HasCustomizations == true || item.StepTransition.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToStepTransitionListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ToStepTransitionListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StepNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StepNameLabel
		{
			get
			{
				return DisplayValues.Edit_StepNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StepName.</summary>
		///--------------------------------------------------------------------------------
		public string StepName
		{
			get
			{
				return EditStep.StepName;
			}
			set
			{
				EditStep.StepName = value;
				OnPropertyChanged("StepName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StepNameCustomized
		{
			get
			{
				if (Step.ReverseInstance != null)
				{
					return StepName.GetString() != Step.ReverseInstance.StepName.GetString();
				}
				else if (Step.IsAutoUpdated == true)
				{
					return StepName.GetString() != Step.StepName.GetString();
				}
				return StepName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StepNameValidationMessage
		{
			get
			{
				return EditStep.ValidateStepName();
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
				return EditStep.Order;
			}
			set
			{
				EditStep.Order = value;
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
				if (Step.ReverseInstance != null)
				{
					return Order.GetInt() != Step.ReverseInstance.Order.GetInt();
				}
				else if (Step.IsAutoUpdated == true)
				{
					return Order.GetInt() != Step.Order.GetInt();
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
				return EditStep.ValidateOrder();
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
				return EditStep.Description;
			}
			set
			{
				EditStep.Description = value;
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
				if (Step.ReverseInstance != null)
				{
					return Description.GetString() != Step.ReverseInstance.Description.GetString();
				}
				else if (Step.IsAutoUpdated == true)
				{
					return Description.GetString() != Step.Description.GetString();
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
				return EditStep.ValidateDescription();
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
				return EditStep.SourceName;
			}
			set
			{
				EditStep.SourceName = value;
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
				return EditStep.SpecSourceName;
			}
			set
			{
				EditStep.SpecSourceName = value;
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
				return EditStep.Tags;
			}
			set
			{
				EditStep.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Step.ReverseInstance != null)
				{
					return Tags != Step.ReverseInstance.Tags;
				}
				else if (Step.IsAutoUpdated == true)
				{
					return Tags != Step.Tags;
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
				return EditStep.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditStep.Name;
			}
			set
			{
				EditStep.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditStep.TransformDataFromObject(Step, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditStep.ResetModified(false);
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
			if (Step.ReverseInstance != null)
			{
				EditStep.TransformDataFromObject(Step.ReverseInstance, null, false);
			}
			else if (Step.IsAutoUpdated == true)
			{
				EditStep.TransformDataFromObject(Step, null, false);
			}
			else
			{
				Step newStep = new Step();
				newStep.StepID = EditStep.StepID;
				EditStep.TransformDataFromObject(newStep, null, false);
			}
			EditStep.ResetModified(true);
			foreach (StepTransitionViewModel item in Items.OfType<StepTransitionViewModel>())
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
		/// <summary>This method processes the new Step command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStepCommand()
		{
			StepEventArgs message = new StepEventArgs();
			message.Step = new Step();
			message.Step.StepID = Guid.NewGuid();
			message.Step.StageID = StageID;
			message.Step.Stage = Solution.StageList.FindByID((Guid)StageID);
			if (message.Step.Stage != null)
			{
				message.Step.Order = message.Step.Stage.StepList.Count + 1;
			}
			message.Step.Solution = Solution;
			message.StageID = StageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepEventArgs>(MediatorMessages.Command_EditStepRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStepCommand()
		{
			StepEventArgs message = new StepEventArgs();
			message.Step = Step;
			message.StageID = StageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepEventArgs>(MediatorMessages.Command_EditStepRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to StepTransition adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewStepTransition()
		{
			StepTransitionViewModel item = new StepTransitionViewModel();
			item.StepTransition = new StepTransition();
			item.StepTransition.StepTransitionID = Guid.NewGuid();
			item.StepTransition.ToStep = EditStep;
			item.StepTransition.ToStepID = EditStep.StepID;
			item.StepTransition.Solution = Solution;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new StepTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStepTransitionCommand()
		{
			StepTransitionEventArgs message = new StepTransitionEventArgs();
			message.StepTransition = new StepTransition();
			message.StepTransition.StepTransitionID = Guid.NewGuid();
			message.StepTransition.ToStep = Step;
			message.StepTransition.ToStepID = Step.StepID;
			message.ToStepID = Step.StepID;
			message.StepTransition.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepTransitionEventArgs>(MediatorMessages.Command_EditStepTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StepTransition updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStepTransitionPerformed(StepTransitionEventArgs data)
		{
			if (data != null && data.StepTransition != null)
			{
				UpdateEditStepTransition(data.StepTransition);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of StepTransition.</summary>
		/// 
		/// <param name="stepTransition">The StepTransition to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditStepTransition(StepTransition stepTransition)
		{
			bool isItemMatch = false;
			foreach (StepTransitionViewModel item in StepTransitions)
			{
				if (item.StepTransition.StepTransitionID == stepTransition.StepTransitionID)
				{
					isItemMatch = true;
					item.StepTransition.TransformDataFromObject(stepTransition, null, false);
					if (!item.StepTransition.FromStepID.IsNullOrEmpty())
					{
						item.StepTransition.FromStep = Solution.StepList.FindByID((Guid)item.StepTransition.FromStepID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new StepTransition
				stepTransition.ToStep = Step;
				StepTransitionViewModel newItem = new StepTransitionViewModel(stepTransition, Solution);
				if (!newItem.StepTransition.FromStepID.IsNullOrEmpty())
				{
					newItem.StepTransition.FromStep = Solution.StepList.FindByID((Guid)newItem.StepTransition.FromStepID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				StepTransitions.Add(newItem);
				Step.ToStepTransitionList.Add(stepTransition);
				Solution.StepTransitionList.Add(newItem.StepTransition);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to StepTransition deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedStepTransitions(StepTransitionViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StepTransition deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStepTransitionPerformed(StepTransitionEventArgs data)
		{
			if (data != null && data.StepTransition != null)
			{
				DeleteStepTransition(data.StepTransition);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of StepTransition.</summary>
		/// 
		/// <param name="stepTransition">The StepTransition to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStepTransition(StepTransition stepTransition)
		{
			bool isItemMatch = false;
			foreach (StepTransitionViewModel item in StepTransitions.ToList<StepTransitionViewModel>())
			{
				if (item.StepTransition.StepTransitionID == stepTransition.StepTransitionID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.StepTransition.StepTransitionID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete StepTransition
					isItemMatch = true;
					StepTransitions.Remove(item);
					Step.ToStepTransitionList.Remove(item.StepTransition);
					Solution.StepTransitionList.Remove(item.StepTransition);
					Items.Remove(item);
					Step.ResetModified(true);
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
			ProcessNewStepCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Step.ReverseInstance == null && Step.IsAutoUpdated == true)
			{
				Step.ReverseInstance = new Step();
				Step.ReverseInstance.TransformDataFromObject(Step, null, false);

				// perform the update of EditStep back to Step
				Step.TransformDataFromObject(EditStep, null, false);
				Step.IsAutoUpdated = false;
			}
			else if (Step.ReverseInstance != null)
			{
				EditStep.ResetModified(Step.ReverseInstance.IsModified);
				if (EditStep.Equals(Step.ReverseInstance))
				{
					// perform the update of EditStep back to Step
					Step.TransformDataFromObject(EditStep, null, false);
					Step.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditStep back to Step
					Step.TransformDataFromObject(EditStep, null, false);
					Step.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditStep back to Step
				Step.TransformDataFromObject(EditStep, null, false);
				Step.IsAutoUpdated = false;
			}
			Step.ForwardInstance = null;
			if (StepNameCustomized || OrderCustomized || DescriptionCustomized || ToStepTransitionListCustomized || TagsCustomized)
			{
				Step.ForwardInstance = new Step();
				Step.ForwardInstance.StepID = EditStep.StepID;
				Step.SpecSourceName = Step.DefaultSourceName;
				if (StepNameCustomized)
				{
					Step.ForwardInstance.StepName = EditStep.StepName;
				}
				if (OrderCustomized)
				{
					Step.ForwardInstance.Order = EditStep.Order;
				}
				if (DescriptionCustomized)
				{
					Step.ForwardInstance.Description = EditStep.Description;
				}
				if (ToStepTransitionListCustomized)
				{
					#region protected
					#endregion protected
					// Step.ToStepTransitionList = new EnterpriseDataObjectList<StepTransition>(EditStep.ToStepTransitionList, null);
					// Step.ForwardInstance.ToStepTransitionList = new EnterpriseDataObjectList<StepTransition>(EditStep.ToStepTransitionList, null);
				}
				if (TagsCustomized)
				{
					Step.ForwardInstance.Tags = EditStep.Tags;
				}
			}
			EditStep.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStepPerformed();

			// send update for any updated StepTransitions
			foreach (StepTransitionViewModel item in StepTransitions)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new StepTransitions
			foreach (StepTransitionViewModel item in ItemsToAdd.OfType<StepTransitionViewModel>())
			{
				item.Update();
				StepTransitions.Add(item);
			}

			// send delete for any deleted StepTransitions
			foreach (StepTransitionViewModel item in ItemsToDelete.OfType<StepTransitionViewModel>())
			{
				item.Delete();
				StepTransitions.Remove(item);
			}

			// reset modified for StepTransitions
			foreach (StepTransitionViewModel item in StepTransitions)
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
		public void SendEditStepPerformed()
		{
			StepEventArgs message = new StepEventArgs();
			message.Step = Step;
			message.StageID = StageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepEventArgs>(MediatorMessages.Command_EditStepPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Step command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStepCommand()
		{
			StepEventArgs message = new StepEventArgs();
			message.Step = Step;
			message.StageID = StageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepEventArgs>(MediatorMessages.Command_DeleteStepRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStepCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StepTransition lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StepTransitionViewModel> StepTransitions { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Step.</summary>
		///--------------------------------------------------------------------------------
		public Step Step { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StepID
		{
			get
			{
				return Step.StepID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Step.Name;
			}
			set
			{
				Step.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return Step.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StageID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StageID
		{
			get
			{
				return Step.StageID;
			}
			set
			{
				Step.StageID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Step into the view model.</summary>
		/// 
		/// <param name="step">The Step to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStep(Step step, bool loadChildren = true)
		{
			// attach the Step
			Step = step;
			ItemID = Step.StepID;
			Items.Clear();
			
			// initialize StepTransitions
			if (StepTransitions == null)
			{
				StepTransitions = new EnterpriseDataObjectList<StepTransitionViewModel>();
			}
			if (loadChildren == true)
			{
				// attach StepTransitions
				foreach (StepTransition item in step.ToStepTransitionList)
				{
					StepTransitionViewModel itemView = new StepTransitionViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					StepTransitions.Add(itemView);
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
				foreach (StepTransitionViewModel item in StepTransitions)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Step.IsValid;
			HasCustomizations = Step.IsAutoUpdated == false || Step.IsEmptyMetadata(Step.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Step.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Step.IsAutoUpdated = true;
				Step.SpecSourceName = Step.ReverseInstance.SpecSourceName;
				Step.ResetModified(Step.ReverseInstance.IsModified);
				Step.ResetLoaded(Step.ReverseInstance.IsLoaded);
				if (!Step.IsIdenticalMetadata(Step.ReverseInstance))
				{
					HasCustomizations = true;
					Step.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Step.ForwardInstance = null;
				Step.ReverseInstance = null;
				Step.IsAutoUpdated = true;
			}
			foreach (StepTransitionViewModel item in StepTransitions)
			{
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			Items.Sort("Name", SortDirection.Ascending);
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (StepTransitions != null)
			{
				for (int i = StepTransitions.Count - 1; i >= 0; i--)
				{
					StepTransitions[i].Updated -= Children_Updated;
					StepTransitions[i].Dispose();
					StepTransitions.Remove(StepTransitions[i]);
				}
				StepTransitions = null;
			}
			if (_editStep != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditStep.PropertyChanged -= EditStep_PropertyChanged;
				EditStep = null;
			}
			Step = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (StepTransitionViewModel item in StepTransitions)
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
			OnPropertyChanged("ToStepTransitionList");
			OnPropertyChanged("ToStepTransitionListCustomized");
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
			if (data is StepTransitionEventArgs && (data as StepTransitionEventArgs).ToStepID == Step.StepID)
			{
				return this;
			}
			foreach (StepTransitionViewModel model in StepTransitions)
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
		public StepTransitionViewModel PasteStepTransition(StepTransitionViewModel copyItem, bool savePaste = true)
		{
			StepTransition newItem = new StepTransition();
			newItem.ReverseInstance = new StepTransition();
			newItem.TransformDataFromObject(copyItem.StepTransition, null, false);
			newItem.StepTransitionID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Step by existing id first, second by old id, finally by name
			newItem.FromStep = Step.Stage.StepList.FindByID((Guid)copyItem.StepTransition.FromStepID);
			if (newItem.FromStep == null && Solution.PasteNewGuids[copyItem.StepTransition.FromStepID.ToString()] is Guid)
			{
				newItem.FromStep = Step.Stage.StepList.FindByID((Guid)Solution.PasteNewGuids[copyItem.StepTransition.FromStepID.ToString()]);
			}
			if (newItem.FromStep == null)
			{
				newItem.FromStep = Step.Stage.StepList.Find("Name", copyItem.StepTransition.Name);
			}
			if (newItem.FromStep == null)
			{
				newItem.OldFromStepID = newItem.FromStepID;
				newItem.FromStepID = Guid.Empty;
			}
			newItem.ToStep = Step;
			newItem.Solution = Solution;
			StepTransitionViewModel newView = new StepTransitionViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddStepTransition(newView);
			if (savePaste == true)
			{
				Solution.StepTransitionList.Add(newItem);
				Step.ToStepTransitionList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of StepTransition to the view model.</summary>
		/// 
		/// <param name="itemView">The StepTransition to add.</param>
		///--------------------------------------------------------------------------------
		public void AddStepTransition(StepTransitionViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			StepTransitions.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of StepTransition from the view model.</summary>
		/// 
		/// <param name="itemView">The StepTransition to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStepTransition(StepTransitionViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			StepTransitions.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StepViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="step">The Step to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StepViewModel(Step step, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadStep(step, loadChildren);
		}

		#endregion "Constructors"
	}
}
