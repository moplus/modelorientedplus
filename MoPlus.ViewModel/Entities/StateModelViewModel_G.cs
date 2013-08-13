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
	/// <summary>This class provides views for StateModel instances.</summary>
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
	public partial class StateModelViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStateModel.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateModel
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateModel;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlStateModelToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStateModelToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateModelToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewStateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateToolTip;
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
				if (EditStateModel.IsModified == true)
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
				return string.IsNullOrEmpty(StateModelNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private StateModel _editStateModel = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditStateModel.</summary>
		///--------------------------------------------------------------------------------
		public StateModel EditStateModel
		{
			get
			{
				if (_editStateModel == null)
				{
					_editStateModel = new StateModel();
					_editStateModel.PropertyChanged += new PropertyChangedEventHandler(EditStateModel_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (StateModel != null)
					{
						_editStateModel.TransformDataFromObject(StateModel, null, false);
						_editStateModel.Solution = StateModel.Solution;
						_editStateModel.Entity = StateModel.Entity;
					}
					_editStateModel.ResetModified(false);
				}
				return _editStateModel;
			}
			set
			{
				_editStateModel = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditStateModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditStateModel");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StateModelName");
			OnPropertyChanged("StateModelNameCustomized");
			OnPropertyChanged("StateModelNameValidationMessage");
			
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
				return DisplayValues.Edit_StateModelHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StateModelHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StateModelIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StateModelIDLabel
		{
			get
			{
				return DisplayValues.Edit_StateModelIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StateModelNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StateModelNameLabel
		{
			get
			{
				return DisplayValues.Edit_StateModelNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StateModelName.</summary>
		///--------------------------------------------------------------------------------
		public string StateModelName
		{
			get
			{
				return EditStateModel.StateModelName;
			}
			set
			{
				EditStateModel.StateModelName = value;
				OnPropertyChanged("StateModelName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateModelNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StateModelNameCustomized
		{
			get
			{
				if (StateModel.ReverseInstance != null)
				{
					return StateModelName.GetString() != StateModel.ReverseInstance.StateModelName.GetString();
				}
				else if (StateModel.IsAutoUpdated == true)
				{
					return StateModelName.GetString() != StateModel.StateModelName.GetString();
				}
				return StateModelName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateModelNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StateModelNameValidationMessage
		{
			get
			{
				return EditStateModel.ValidateStateModelName();
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
				return EditStateModel.Description;
			}
			set
			{
				EditStateModel.Description = value;
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
				if (StateModel.ReverseInstance != null)
				{
					return Description.GetString() != StateModel.ReverseInstance.Description.GetString();
				}
				else if (StateModel.IsAutoUpdated == true)
				{
					return Description.GetString() != StateModel.Description.GetString();
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
				return EditStateModel.ValidateDescription();
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
				return EditStateModel.SourceName;
			}
			set
			{
				EditStateModel.SourceName = value;
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
				return EditStateModel.SpecSourceName;
			}
			set
			{
				EditStateModel.SpecSourceName = value;
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
				return EditStateModel.Tags;
			}
			set
			{
				EditStateModel.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (StateModel.ReverseInstance != null)
				{
					return Tags != StateModel.ReverseInstance.Tags;
				}
				else if (StateModel.IsAutoUpdated == true)
				{
					return Tags != StateModel.Tags;
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
				return EditStateModel.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditStateModel.Name;
			}
			set
			{
				EditStateModel.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditStateModel.TransformDataFromObject(StateModel, null, false);
			EditStateModel.ResetModified(false);
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
			if (StateModel.ReverseInstance != null)
			{
				EditStateModel.TransformDataFromObject(StateModel.ReverseInstance, null, false);
			}
			else if (StateModel.IsAutoUpdated == true)
			{
				EditStateModel.TransformDataFromObject(StateModel, null, false);
			}
			else
			{
				StateModel newStateModel = new StateModel();
				newStateModel.StateModelID = EditStateModel.StateModelID;
				EditStateModel.TransformDataFromObject(newStateModel, null, false);
			}
			EditStateModel.ResetModified(true);
			foreach (StateViewModel item in Items.OfType<StateViewModel>())
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
		/// <summary>This method processes the new StateModel command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStateModelCommand()
		{
			StateModelEventArgs message = new StateModelEventArgs();
			message.StateModel = new StateModel();
			message.StateModel.StateModelID = Guid.NewGuid();
			message.StateModel.EntityID = EntityID;
			message.StateModel.Entity = Solution.EntityList.FindByID((Guid)EntityID);
			message.StateModel.Solution = Solution;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateModelEventArgs>(MediatorMessages.Command_EditStateModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStateModelCommand()
		{
			StateModelEventArgs message = new StateModelEventArgs();
			message.StateModel = StateModel;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateModelEventArgs>(MediatorMessages.Command_EditStateModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to State adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewState()
		{
			StateViewModel item = new StateViewModel();
			item.State = new State();
			item.State.StateID = Guid.NewGuid();
			item.State.StateModel = EditStateModel;
			item.State.StateModelID = EditStateModel.StateModelID;
			item.State.Solution = Solution;
			item.State.Order = StateModel.StateList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new State command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStateCommand()
		{
			StateEventArgs message = new StateEventArgs();
			message.State = new State();
			message.State.StateID = Guid.NewGuid();
			message.State.StateModel = StateModel;
			message.State.StateModelID = StateModel.StateModelID;
			message.StateModelID = StateModel.StateModelID;
			if (message.State.StateModel != null)
			{
				message.State.Order = message.State.StateModel.StateList.Count + 1;
			}
			message.State.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateEventArgs>(MediatorMessages.Command_EditStateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies State updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStatePerformed(StateEventArgs data)
		{
			if (data != null && data.State != null)
			{
				UpdateEditState(data.State);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of State.</summary>
		/// 
		/// <param name="state">The State to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditState(State state)
		{
			bool isItemMatch = false;
			foreach (StateViewModel item in States)
			{
				if (item.State.StateID == state.StateID)
				{
					isItemMatch = true;
					item.State.TransformDataFromObject(state, null, false);
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new State
				state.StateModel = StateModel;
				StateViewModel newItem = new StateViewModel(state, Solution);
				newItem.Updated += new EventHandler(Children_Updated);
				States.Add(newItem);
				StateModel.StateList.Add(state);
				Solution.StateList.Add(newItem.State);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to State deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedStates(StateViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies State deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStatePerformed(StateEventArgs data)
		{
			if (data != null && data.State != null)
			{
				DeleteState(data.State);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of State.</summary>
		/// 
		/// <param name="state">The State to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteState(State state)
		{
			bool isItemMatch = false;
			foreach (StateViewModel item in States.ToList<StateViewModel>())
			{
				if (item.State.StateID == state.StateID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.State.StateID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete State
					isItemMatch = true;
					States.Remove(item);
					StateModel.StateList.Remove(item.State);
					Solution.StateList.Remove(item.State);
					Items.Remove(item);
					StateModel.ResetModified(true);
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
			ProcessNewStateModelCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (StateModel.ReverseInstance == null && StateModel.IsAutoUpdated == true)
			{
				StateModel.ReverseInstance = new StateModel();
				StateModel.ReverseInstance.TransformDataFromObject(StateModel, null, false);

				// perform the update of EditStateModel back to StateModel
				StateModel.TransformDataFromObject(EditStateModel, null, false);
				StateModel.IsAutoUpdated = false;
			}
			else if (StateModel.ReverseInstance != null)
			{
				EditStateModel.ResetModified(StateModel.ReverseInstance.IsModified);
				if (EditStateModel.Equals(StateModel.ReverseInstance))
				{
					// perform the update of EditStateModel back to StateModel
					StateModel.TransformDataFromObject(EditStateModel, null, false);
					StateModel.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditStateModel back to StateModel
					StateModel.TransformDataFromObject(EditStateModel, null, false);
					StateModel.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditStateModel back to StateModel
				StateModel.TransformDataFromObject(EditStateModel, null, false);
				StateModel.IsAutoUpdated = false;
			}
			StateModel.ForwardInstance = null;
			if (StateModelNameCustomized || DescriptionCustomized || TagsCustomized)
			{
				StateModel.ForwardInstance = new StateModel();
				StateModel.ForwardInstance.StateModelID = EditStateModel.StateModelID;
				StateModel.SpecSourceName = StateModel.DefaultSourceName;
				if (StateModelNameCustomized)
				{
					StateModel.ForwardInstance.StateModelName = EditStateModel.StateModelName;
				}
				if (DescriptionCustomized)
				{
					StateModel.ForwardInstance.Description = EditStateModel.Description;
				}
				if (TagsCustomized)
				{
					StateModel.ForwardInstance.Tags = EditStateModel.Tags;
				}
			}
			EditStateModel.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStateModelPerformed();

			// send update for any updated States
			foreach (StateViewModel item in States)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new States
			foreach (StateViewModel item in ItemsToAdd.OfType<StateViewModel>())
			{
				item.Update();
				States.Add(item);
			}

			// send delete for any deleted States
			foreach (StateViewModel item in ItemsToDelete.OfType<StateViewModel>())
			{
				item.Delete();
				States.Remove(item);
			}

			// reset modified for States
			foreach (StateViewModel item in States)
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
		public void SendEditStateModelPerformed()
		{
			StateModelEventArgs message = new StateModelEventArgs();
			message.StateModel = StateModel;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateModelEventArgs>(MediatorMessages.Command_EditStateModelPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete StateModel command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStateModelCommand()
		{
			StateModelEventArgs message = new StateModelEventArgs();
			message.StateModel = StateModel;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateModelEventArgs>(MediatorMessages.Command_DeleteStateModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStateModelCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets State lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StateViewModel> States { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateModel.</summary>
		///--------------------------------------------------------------------------------
		public StateModel StateModel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateModelID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StateModelID
		{
			get
			{
				return StateModel.StateModelID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return StateModel.Name;
			}
			set
			{
				StateModel.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return StateModel.EntityID;
			}
			set
			{
				StateModel.EntityID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of StateModel into the view model.</summary>
		/// 
		/// <param name="stateModel">The StateModel to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStateModel(StateModel stateModel, bool loadChildren = true)
		{
			// attach the StateModel
			StateModel = stateModel;
			ItemID = StateModel.StateModelID;
			Items.Clear();
			
			// initialize States
			if (States == null)
			{
				States = new EnterpriseDataObjectList<StateViewModel>();
			}
			if (loadChildren == true)
			{
				// attach States
				foreach (State item in stateModel.StateList)
				{
					StateViewModel itemView = new StateViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					States.Add(itemView);
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
				foreach (StateViewModel item in States)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !StateModel.IsValid;
			HasCustomizations = StateModel.IsAutoUpdated == false || StateModel.IsEmptyMetadata(StateModel.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && StateModel.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				StateModel.IsAutoUpdated = true;
				StateModel.SpecSourceName = StateModel.ReverseInstance.SpecSourceName;
				StateModel.ResetModified(StateModel.ReverseInstance.IsModified);
				StateModel.ResetLoaded(StateModel.ReverseInstance.IsLoaded);
				if (!StateModel.IsIdenticalMetadata(StateModel.ReverseInstance))
				{
					HasCustomizations = true;
					StateModel.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				StateModel.ForwardInstance = null;
				StateModel.ReverseInstance = null;
				StateModel.IsAutoUpdated = true;
			}
			foreach (StateViewModel item in States)
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
			if (States != null)
			{
				for (int i = States.Count - 1; i >= 0; i--)
				{
					States[i].Updated -= Children_Updated;
					States[i].Dispose();
					States.Remove(States[i]);
				}
				States = null;
			}
			if (_editStateModel != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditStateModel.PropertyChanged -= EditStateModel_PropertyChanged;
				EditStateModel = null;
			}
			StateModel = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (StateViewModel item in States)
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
			OnPropertyChanged("StateList");
			OnPropertyChanged("StateListCustomized");
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
			if (data is StateEventArgs && (data as StateEventArgs).StateModelID == StateModel.StateModelID)
			{
				return this;
			}
			foreach (StateViewModel model in States)
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
		public StateViewModel PasteState(StateViewModel copyItem, bool savePaste = true)
		{
			State newItem = new State();
			newItem.ReverseInstance = new State();
			newItem.TransformDataFromObject(copyItem.State, null, false);
			newItem.StateID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			newItem.StateModel = StateModel;
			newItem.Solution = Solution;
			StateViewModel newView = new StateViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddState(newView);
			if (savePaste == true)
			{
				Solution.StateList.Add(newItem);
				StateModel.StateList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of State to the view model.</summary>
		/// 
		/// <param name="itemView">The State to add.</param>
		///--------------------------------------------------------------------------------
		public void AddState(StateViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			States.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of State from the view model.</summary>
		/// 
		/// <param name="itemView">The State to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteState(StateViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			States.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StateModelViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="stateModel">The StateModel to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StateModelViewModel(StateModel stateModel, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadStateModel(stateModel, loadChildren);
		}

		#endregion "Constructors"
	}
}
