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
	/// <summary>This class provides views for StateTransition instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/7/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class StateTransitionViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlStateTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStateTransitionToolTip
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
				if (EditStateTransition.IsModified == true)
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
				return string.IsNullOrEmpty(StateTransitionNameValidationMessage + FromStateIDValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private StateTransition _editStateTransition = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditStateTransition.</summary>
		///--------------------------------------------------------------------------------
		public StateTransition EditStateTransition
		{
			get
			{
				if (_editStateTransition == null)
				{
					_editStateTransition = new StateTransition();
					_editStateTransition.PropertyChanged += new PropertyChangedEventHandler(EditStateTransition_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (StateTransition != null)
					{
						_editStateTransition.TransformDataFromObject(StateTransition, null, false);
						_editStateTransition.Solution = StateTransition.Solution;
						_editStateTransition.FromState = StateTransition.FromState;
						_editStateTransition.ToState = StateTransition.ToState;
					}
					_editStateTransition.ResetModified(false);
				}
				return _editStateTransition;
			}
			set
			{
				_editStateTransition = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditStateTransition_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditStateTransition");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StateTransitionName");
			OnPropertyChanged("StateTransitionNameCustomized");
			OnPropertyChanged("StateTransitionNameValidationMessage");
			
			OnPropertyChanged("FromStateID");
			OnPropertyChanged("FromStateIDCustomized");
			OnPropertyChanged("FromStateIDValidationMessage");
			
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
				return DisplayValues.Edit_StateTransitionHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StateTransitionHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StateTransitionIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StateTransitionIDLabel
		{
			get
			{
				return DisplayValues.Edit_StateTransitionIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StateTransitionNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StateTransitionNameLabel
		{
			get
			{
				return DisplayValues.Edit_StateTransitionNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StateTransitionName.</summary>
		///--------------------------------------------------------------------------------
		public string StateTransitionName
		{
			get
			{
				return EditStateTransition.StateTransitionName;
			}
			set
			{
				EditStateTransition.StateTransitionName = value;
				OnPropertyChanged("StateTransitionName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateTransitionNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StateTransitionNameCustomized
		{
			get
			{
				if (StateTransition.ReverseInstance != null)
				{
					return StateTransitionName.GetString() != StateTransition.ReverseInstance.StateTransitionName.GetString();
				}
				else if (StateTransition.IsAutoUpdated == true)
				{
					return StateTransitionName.GetString() != StateTransition.StateTransitionName.GetString();
				}
				return StateTransitionName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateTransitionNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StateTransitionNameValidationMessage
		{
			get
			{
				return EditStateTransition.ValidateStateTransitionName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the FromStateIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string FromStateIDLabel
		{
			get
			{
				return DisplayValues.Edit_FromStateIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets FromStateID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? FromStateID
		{
			get
			{
				return EditStateTransition.FromStateID;
			}
			set
			{
				EditStateTransition.FromStateID = value;
				OnPropertyChanged("FromStateID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStateIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool FromStateIDCustomized
		{
			get
			{
				if (StateTransition.ReverseInstance != null)
				{
					return FromStateID.GetGuid() != StateTransition.ReverseInstance.FromStateID.GetGuid();
				}
				else if (StateTransition.IsAutoUpdated == true)
				{
					return FromStateID.GetGuid() != StateTransition.FromStateID.GetGuid();
				}
				return FromStateID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStateIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string FromStateIDValidationMessage
		{
			get
			{
				return EditStateTransition.ValidateFromStateID();
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
				return EditStateTransition.Description;
			}
			set
			{
				EditStateTransition.Description = value;
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
				if (StateTransition.ReverseInstance != null)
				{
					return Description.GetString() != StateTransition.ReverseInstance.Description.GetString();
				}
				else if (StateTransition.IsAutoUpdated == true)
				{
					return Description.GetString() != StateTransition.Description.GetString();
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
				return EditStateTransition.ValidateDescription();
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
				return EditStateTransition.SourceName;
			}
			set
			{
				EditStateTransition.SourceName = value;
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
				return EditStateTransition.SpecSourceName;
			}
			set
			{
				EditStateTransition.SpecSourceName = value;
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
				return EditStateTransition.Tags;
			}
			set
			{
				EditStateTransition.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (StateTransition.ReverseInstance != null)
				{
					return Tags != StateTransition.ReverseInstance.Tags;
				}
				else if (StateTransition.IsAutoUpdated == true)
				{
					return Tags != StateTransition.Tags;
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
				return EditStateTransition.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditStateTransition.Name;
			}
			set
			{
				EditStateTransition.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditStateTransition.TransformDataFromObject(StateTransition, null, false);
			EditStateTransition.ResetModified(false);
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
			if (StateTransition.ReverseInstance != null)
			{
				EditStateTransition.TransformDataFromObject(StateTransition.ReverseInstance, null, false);
			}
			else if (StateTransition.IsAutoUpdated == true)
			{
				EditStateTransition.TransformDataFromObject(StateTransition, null, false);
			}
			else
			{
				StateTransition newStateTransition = new StateTransition();
				newStateTransition.StateTransitionID = EditStateTransition.StateTransitionID;
				EditStateTransition.TransformDataFromObject(newStateTransition, null, false);
			}
			EditStateTransition.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new StateTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStateTransitionCommand()
		{
			StateTransitionEventArgs message = new StateTransitionEventArgs();
			message.StateTransition = new StateTransition();
			message.StateTransition.StateTransitionID = Guid.NewGuid();
			message.StateTransition.ToStateID = ToStateID;
			message.StateTransition.ToState = Solution.StateList.FindByID((Guid)ToStateID);
			message.StateTransition.Solution = Solution;
			message.ToStateID = ToStateID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateTransitionEventArgs>(MediatorMessages.Command_EditStateTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStateTransitionCommand()
		{
			StateTransitionEventArgs message = new StateTransitionEventArgs();
			message.StateTransition = StateTransition;
			message.ToStateID = ToStateID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateTransitionEventArgs>(MediatorMessages.Command_EditStateTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewStateTransitionCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (StateTransition.ReverseInstance == null && StateTransition.IsAutoUpdated == true)
			{
				StateTransition.ReverseInstance = new StateTransition();
				StateTransition.ReverseInstance.TransformDataFromObject(StateTransition, null, false);

				// perform the update of EditStateTransition back to StateTransition
				StateTransition.TransformDataFromObject(EditStateTransition, null, false);
				StateTransition.IsAutoUpdated = false;
			}
			else if (StateTransition.ReverseInstance != null)
			{
				EditStateTransition.ResetModified(StateTransition.ReverseInstance.IsModified);
				if (EditStateTransition.Equals(StateTransition.ReverseInstance))
				{
					// perform the update of EditStateTransition back to StateTransition
					StateTransition.TransformDataFromObject(EditStateTransition, null, false);
					StateTransition.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditStateTransition back to StateTransition
					StateTransition.TransformDataFromObject(EditStateTransition, null, false);
					StateTransition.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditStateTransition back to StateTransition
				StateTransition.TransformDataFromObject(EditStateTransition, null, false);
				StateTransition.IsAutoUpdated = false;
			}
			StateTransition.ForwardInstance = null;
			if (StateTransitionNameCustomized || FromStateIDCustomized || DescriptionCustomized || TagsCustomized)
			{
				StateTransition.ForwardInstance = new StateTransition();
				StateTransition.ForwardInstance.StateTransitionID = EditStateTransition.StateTransitionID;
				StateTransition.SpecSourceName = StateTransition.DefaultSourceName;
				if (StateTransitionNameCustomized)
				{
					StateTransition.ForwardInstance.StateTransitionName = EditStateTransition.StateTransitionName;
				}
				if (FromStateIDCustomized)
				{
					StateTransition.ForwardInstance.FromStateID = EditStateTransition.FromStateID;
				}
				if (DescriptionCustomized)
				{
					StateTransition.ForwardInstance.Description = EditStateTransition.Description;
				}
				if (TagsCustomized)
				{
					StateTransition.ForwardInstance.Tags = EditStateTransition.Tags;
				}
			}
			EditStateTransition.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStateTransitionPerformed();
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
		public void SendEditStateTransitionPerformed()
		{
			StateTransitionEventArgs message = new StateTransitionEventArgs();
			message.StateTransition = StateTransition;
			message.ToStateID = ToStateID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateTransitionEventArgs>(MediatorMessages.Command_EditStateTransitionPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete StateTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStateTransitionCommand()
		{
			StateTransitionEventArgs message = new StateTransitionEventArgs();
			message.StateTransition = StateTransition;
			message.ToStateID = ToStateID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateTransitionEventArgs>(MediatorMessages.Command_DeleteStateTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStateTransitionCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateTransition.</summary>
		///--------------------------------------------------------------------------------
		public StateTransition StateTransition { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateTransitionID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StateTransitionID
		{
			get
			{
				return StateTransition.StateTransitionID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return StateTransition.Name;
			}
			set
			{
				StateTransition.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ToStateID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ToStateID
		{
			get
			{
				return StateTransition.ToStateID;
			}
			set
			{
				StateTransition.ToStateID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of StateTransition into the view model.</summary>
		/// 
		/// <param name="stateTransition">The StateTransition to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStateTransition(StateTransition stateTransition, bool loadChildren = true)
		{
			// attach the StateTransition
			StateTransition = stateTransition;
			ItemID = StateTransition.StateTransitionID;
			Items.Clear();
			if (loadChildren == true)
			{
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
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !StateTransition.IsValid;
			HasCustomizations = StateTransition.IsAutoUpdated == false || StateTransition.IsEmptyMetadata(StateTransition.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && StateTransition.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				StateTransition.IsAutoUpdated = true;
				StateTransition.SpecSourceName = StateTransition.ReverseInstance.SpecSourceName;
				StateTransition.ResetModified(StateTransition.ReverseInstance.IsModified);
				StateTransition.ResetLoaded(StateTransition.ReverseInstance.IsLoaded);
				if (!StateTransition.IsIdenticalMetadata(StateTransition.ReverseInstance))
				{
					HasCustomizations = true;
					StateTransition.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				StateTransition.ForwardInstance = null;
				StateTransition.ReverseInstance = null;
				StateTransition.IsAutoUpdated = true;
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
			if (_editStateTransition != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditStateTransition.PropertyChanged -= EditStateTransition_PropertyChanged;
				EditStateTransition = null;
			}
			StateTransition = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
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
			#region protected
			#endregion protected
		
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StateTransitionViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="stateTransition">The StateTransition to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StateTransitionViewModel(StateTransition stateTransition, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadStateTransition(stateTransition, loadChildren);
		}

		#endregion "Constructors"
	}
}
