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

namespace MoPlus.ViewModel.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for State instances.</summary>
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
	public partial class StateViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewState.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewState
		{
			get
			{
				return DisplayValues.ContextMenu_NewState;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlStateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStateTransition.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateTransition
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateTransition;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStateTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateTransitionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateTransitionToolTip;
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
				if (EditState.IsModified == true)
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
				return string.IsNullOrEmpty(StateNameValidationMessage + OrderValidationMessage + DescriptionValidationMessage + ToStateTransitionListValidationMessage);
			}
		}
 
		private State _editState = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditState.</summary>
		///--------------------------------------------------------------------------------
		public State EditState
		{
			get
			{
				if (_editState == null)
				{
					_editState = new State();
					_editState.PropertyChanged += new PropertyChangedEventHandler(EditState_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (State != null)
					{
						_editState.TransformDataFromObject(State, null, false);
						_editState.Solution = State.Solution;
						_editState.StateModel = State.StateModel;
					}
					_editState.ResetModified(false);
				}
				return _editState;
			}
			set
			{
				_editState = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditState_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditState");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StateName");
			OnPropertyChanged("StateNameCustomized");
			OnPropertyChanged("StateNameValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ToStateTransitionList");
			OnPropertyChanged("ToStateTransitionListCustomized");
			OnPropertyChanged("ToStateTransitionListValidationMessage");

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
				return DisplayValues.Edit_StateHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StateHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StateIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StateIDLabel
		{
			get
			{
				return DisplayValues.Edit_StateIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ToStateTransitionListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ToStateTransitionListLabel
		{
			get
			{
				return DisplayValues.Edit_ToStateTransitionListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ToStateTransitionList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StateTransition> ToStateTransitionList
		{
			get
			{
				return EditState.ToStateTransitionList;
			}
			set
			{
				EditState.ToStateTransitionList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToStateTransitionListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ToStateTransitionListCustomized
		{
			get
			{
				#region protected
				foreach (StateTransitionViewModel item in Items.OfType<StateTransitionViewModel>())
				{
					if (item.HasCustomizations == true || item.StateTransition.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToStateTransitionListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ToStateTransitionListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StateNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StateNameLabel
		{
			get
			{
				return DisplayValues.Edit_StateNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StateName.</summary>
		///--------------------------------------------------------------------------------
		public string StateName
		{
			get
			{
				return EditState.StateName;
			}
			set
			{
				EditState.StateName = value;
				OnPropertyChanged("StateName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StateNameCustomized
		{
			get
			{
				if (State.ReverseInstance != null)
				{
					return StateName.GetString() != State.ReverseInstance.StateName.GetString();
				}
				else if (State.IsAutoUpdated == true)
				{
					return StateName.GetString() != State.StateName.GetString();
				}
				return StateName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StateNameValidationMessage
		{
			get
			{
				return EditState.ValidateStateName();
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
				return EditState.Order;
			}
			set
			{
				EditState.Order = value;
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
				if (State.ReverseInstance != null)
				{
					return Order.GetInt() != State.ReverseInstance.Order.GetInt();
				}
				else if (State.IsAutoUpdated == true)
				{
					return Order.GetInt() != State.Order.GetInt();
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
				return EditState.ValidateOrder();
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
				return EditState.Description;
			}
			set
			{
				EditState.Description = value;
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
				if (State.ReverseInstance != null)
				{
					return Description.GetString() != State.ReverseInstance.Description.GetString();
				}
				else if (State.IsAutoUpdated == true)
				{
					return Description.GetString() != State.Description.GetString();
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
				return EditState.ValidateDescription();
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
				return EditState.SourceName;
			}
			set
			{
				EditState.SourceName = value;
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
				return EditState.SpecSourceName;
			}
			set
			{
				EditState.SpecSourceName = value;
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
				return EditState.Tags;
			}
			set
			{
				EditState.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (State.ReverseInstance != null)
				{
					return Tags != State.ReverseInstance.Tags;
				}
				else if (State.IsAutoUpdated == true)
				{
					return Tags != State.Tags;
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
				return EditState.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditState.Name;
			}
			set
			{
				EditState.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditState.TransformDataFromObject(State, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditState.ResetModified(false);
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
			if (State.ReverseInstance != null)
			{
				EditState.TransformDataFromObject(State.ReverseInstance, null, false);
			}
			else if (State.IsAutoUpdated == true)
			{
				EditState.TransformDataFromObject(State, null, false);
			}
			else
			{
				State newState = new State();
				newState.StateID = EditState.StateID;
				EditState.TransformDataFromObject(newState, null, false);
			}
			EditState.ResetModified(true);
			foreach (StateTransitionViewModel item in Items.OfType<StateTransitionViewModel>())
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
		/// <summary>This method processes the new State command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStateCommand()
		{
			StateEventArgs message = new StateEventArgs();
			message.State = new State();
			message.State.StateID = Guid.NewGuid();
			message.State.StateModelID = StateModelID;
			message.State.StateModel = Solution.StateModelList.FindByID((Guid)StateModelID);
			if (message.State.StateModel != null)
			{
				message.State.Order = message.State.StateModel.StateList.Count + 1;
			}
			message.State.Solution = Solution;
			message.StateModelID = StateModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateEventArgs>(MediatorMessages.Command_EditStateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStateCommand()
		{
			StateEventArgs message = new StateEventArgs();
			message.State = State;
			message.StateModelID = StateModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateEventArgs>(MediatorMessages.Command_EditStateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to StateTransition adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewStateTransition()
		{
			StateTransitionViewModel item = new StateTransitionViewModel();
			item.StateTransition = new StateTransition();
			item.StateTransition.StateTransitionID = Guid.NewGuid();
			item.StateTransition.ToState = EditState;
			item.StateTransition.ToStateID = EditState.StateID;
			item.StateTransition.Solution = Solution;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new StateTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStateTransitionCommand()
		{
			StateTransitionEventArgs message = new StateTransitionEventArgs();
			message.StateTransition = new StateTransition();
			message.StateTransition.StateTransitionID = Guid.NewGuid();
			message.StateTransition.ToState = State;
			message.StateTransition.ToStateID = State.StateID;
			message.ToStateID = State.StateID;
			message.StateTransition.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateTransitionEventArgs>(MediatorMessages.Command_EditStateTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StateTransition updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStateTransitionPerformed(StateTransitionEventArgs data)
		{
			if (data != null && data.StateTransition != null)
			{
				UpdateEditStateTransition(data.StateTransition);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of StateTransition.</summary>
		/// 
		/// <param name="stateTransition">The StateTransition to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditStateTransition(StateTransition stateTransition)
		{
			bool isItemMatch = false;
			foreach (StateTransitionViewModel item in StateTransitions)
			{
				if (item.StateTransition.StateTransitionID == stateTransition.StateTransitionID)
				{
					isItemMatch = true;
					item.StateTransition.TransformDataFromObject(stateTransition, null, false);
					if (!item.StateTransition.FromStateID.IsNullOrEmpty())
					{
						item.StateTransition.FromState = Solution.StateList.FindByID((Guid)item.StateTransition.FromStateID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new StateTransition
				stateTransition.ToState = State;
				StateTransitionViewModel newItem = new StateTransitionViewModel(stateTransition, Solution);
				if (!newItem.StateTransition.FromStateID.IsNullOrEmpty())
				{
					newItem.StateTransition.FromState = Solution.StateList.FindByID((Guid)newItem.StateTransition.FromStateID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				StateTransitions.Add(newItem);
				State.ToStateTransitionList.Add(stateTransition);
				Solution.StateTransitionList.Add(newItem.StateTransition);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to StateTransition deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedStateTransitions(StateTransitionViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies StateTransition deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStateTransitionPerformed(StateTransitionEventArgs data)
		{
			if (data != null && data.StateTransition != null)
			{
				DeleteStateTransition(data.StateTransition);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of StateTransition.</summary>
		/// 
		/// <param name="stateTransition">The StateTransition to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStateTransition(StateTransition stateTransition)
		{
			bool isItemMatch = false;
			foreach (StateTransitionViewModel item in StateTransitions.ToList<StateTransitionViewModel>())
			{
				if (item.StateTransition.StateTransitionID == stateTransition.StateTransitionID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.StateTransition.StateTransitionID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete StateTransition
					isItemMatch = true;
					StateTransitions.Remove(item);
					State.ToStateTransitionList.Remove(item.StateTransition);
					Solution.StateTransitionList.Remove(item.StateTransition);
					Items.Remove(item);
					State.ResetModified(true);
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
			ProcessNewStateCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (State.ReverseInstance == null && State.IsAutoUpdated == true)
			{
				State.ReverseInstance = new State();
				State.ReverseInstance.TransformDataFromObject(State, null, false);

				// perform the update of EditState back to State
				State.TransformDataFromObject(EditState, null, false);
				State.IsAutoUpdated = false;
			}
			else if (State.ReverseInstance != null)
			{
				EditState.ResetModified(State.ReverseInstance.IsModified);
				if (EditState.Equals(State.ReverseInstance))
				{
					// perform the update of EditState back to State
					State.TransformDataFromObject(EditState, null, false);
					State.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditState back to State
					State.TransformDataFromObject(EditState, null, false);
					State.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditState back to State
				State.TransformDataFromObject(EditState, null, false);
				State.IsAutoUpdated = false;
			}
			State.ForwardInstance = null;
			if (StateNameCustomized || OrderCustomized || DescriptionCustomized || ToStateTransitionListCustomized || TagsCustomized)
			{
				State.ForwardInstance = new State();
				State.ForwardInstance.StateID = EditState.StateID;
				State.SpecSourceName = State.DefaultSourceName;
				if (StateNameCustomized)
				{
					State.ForwardInstance.StateName = EditState.StateName;
				}
				if (OrderCustomized)
				{
					State.ForwardInstance.Order = EditState.Order;
				}
				if (DescriptionCustomized)
				{
					State.ForwardInstance.Description = EditState.Description;
				}
				if (ToStateTransitionListCustomized)
				{
					#region protected
					#endregion protected
					// State.ToStateTransitionList = new EnterpriseDataObjectList<StateTransition>(EditState.ToStateTransitionList, null);
					// State.ForwardInstance.ToStateTransitionList = new EnterpriseDataObjectList<StateTransition>(EditState.ToStateTransitionList, null);
				}
				if (TagsCustomized)
				{
					State.ForwardInstance.Tags = EditState.Tags;
				}
			}
			EditState.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStatePerformed();

			// send update for any updated StateTransitions
			foreach (StateTransitionViewModel item in StateTransitions)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new StateTransitions
			foreach (StateTransitionViewModel item in ItemsToAdd.OfType<StateTransitionViewModel>())
			{
				item.Update();
				StateTransitions.Add(item);
			}

			// send delete for any deleted StateTransitions
			foreach (StateTransitionViewModel item in ItemsToDelete.OfType<StateTransitionViewModel>())
			{
				item.Delete();
				StateTransitions.Remove(item);
			}

			// reset modified for StateTransitions
			foreach (StateTransitionViewModel item in StateTransitions)
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
		public void SendEditStatePerformed()
		{
			StateEventArgs message = new StateEventArgs();
			message.State = State;
			message.StateModelID = StateModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateEventArgs>(MediatorMessages.Command_EditStatePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete State command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStateCommand()
		{
			StateEventArgs message = new StateEventArgs();
			message.State = State;
			message.StateModelID = StateModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateEventArgs>(MediatorMessages.Command_DeleteStateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStateCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateTransition lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StateTransitionViewModel> StateTransitions { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the State.</summary>
		///--------------------------------------------------------------------------------
		public State State { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StateID
		{
			get
			{
				return State.StateID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return State.Name;
			}
			set
			{
				State.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return State.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateModelID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StateModelID
		{
			get
			{
				return State.StateModelID;
			}
			set
			{
				State.StateModelID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of State into the view model.</summary>
		/// 
		/// <param name="state">The State to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadState(State state, bool loadChildren = true)
		{
			// attach the State
			State = state;
			ItemID = State.StateID;
			Items.Clear();
			
			// initialize StateTransitions
			if (StateTransitions == null)
			{
				StateTransitions = new EnterpriseDataObjectList<StateTransitionViewModel>();
			}
			if (loadChildren == true)
			{
				// attach StateTransitions
				foreach (StateTransition item in state.ToStateTransitionList)
				{
					StateTransitionViewModel itemView = new StateTransitionViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					StateTransitions.Add(itemView);
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
				foreach (StateTransitionViewModel item in StateTransitions)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !State.IsValid;
			HasCustomizations = State.IsAutoUpdated == false || State.IsEmptyMetadata(State.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && State.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				State.IsAutoUpdated = true;
				State.SpecSourceName = State.ReverseInstance.SpecSourceName;
				State.ResetModified(State.ReverseInstance.IsModified);
				State.ResetLoaded(State.ReverseInstance.IsLoaded);
				if (!State.IsIdenticalMetadata(State.ReverseInstance))
				{
					HasCustomizations = true;
					State.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				State.ForwardInstance = null;
				State.ReverseInstance = null;
				State.IsAutoUpdated = true;
			}
			foreach (StateTransitionViewModel item in StateTransitions)
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
			if (StateTransitions != null)
			{
				for (int i = StateTransitions.Count - 1; i >= 0; i--)
				{
					StateTransitions[i].Updated -= Children_Updated;
					StateTransitions[i].Dispose();
					StateTransitions.Remove(StateTransitions[i]);
				}
				StateTransitions = null;
			}
			if (_editState != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditState.PropertyChanged -= EditState_PropertyChanged;
				EditState = null;
			}
			State = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (StateTransitionViewModel item in StateTransitions)
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
			OnPropertyChanged("ToStateTransitionList");
			OnPropertyChanged("ToStateTransitionListCustomized");
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
			if (data is StateTransitionEventArgs && (data as StateTransitionEventArgs).ToStateID == State.StateID)
			{
				return this;
			}
			foreach (StateTransitionViewModel model in StateTransitions)
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
		public StateTransitionViewModel PasteStateTransition(StateTransitionViewModel copyItem, bool savePaste = true)
		{
			StateTransition newItem = new StateTransition();
			newItem.ReverseInstance = new StateTransition();
			newItem.TransformDataFromObject(copyItem.StateTransition, null, false);
			newItem.StateTransitionID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find State by existing id first, second by old id, finally by name
			newItem.FromState = State.StateModel.StateList.FindByID((Guid)copyItem.StateTransition.FromStateID);
			if (newItem.FromState == null && Solution.PasteNewGuids[copyItem.StateTransition.FromStateID.ToString()] is Guid)
			{
				newItem.FromState = State.StateModel.StateList.FindByID((Guid)Solution.PasteNewGuids[copyItem.StateTransition.FromStateID.ToString()]);
			}
			if (newItem.FromState == null)
			{
				newItem.FromState = State.StateModel.StateList.Find("Name", copyItem.StateTransition.Name);
			}
			if (newItem.FromState == null)
			{
				newItem.OldFromStateID = newItem.FromStateID;
				newItem.FromStateID = Guid.Empty;
			}
			newItem.ToState = State;
			newItem.Solution = Solution;
			StateTransitionViewModel newView = new StateTransitionViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddStateTransition(newView);
			if (savePaste == true)
			{
				Solution.StateTransitionList.Add(newItem);
				State.ToStateTransitionList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of StateTransition to the view model.</summary>
		/// 
		/// <param name="itemView">The StateTransition to add.</param>
		///--------------------------------------------------------------------------------
		public void AddStateTransition(StateTransitionViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			StateTransitions.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of StateTransition from the view model.</summary>
		/// 
		/// <param name="itemView">The StateTransition to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStateTransition(StateTransitionViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			StateTransitions.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StateViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="state">The State to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StateViewModel(State state, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadState(state, loadChildren);
		}

		#endregion "Constructors"
	}
}
