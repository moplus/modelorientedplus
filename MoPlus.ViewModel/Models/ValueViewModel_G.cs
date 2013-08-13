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

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for Value instances.</summary>
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
	public partial class ValueViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewValue.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewValue
		{
			get
			{
				return DisplayValues.ContextMenu_NewValue;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlValueToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelValueToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewValueToolTip;
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
				if (EditValue.IsModified == true)
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
				return string.IsNullOrEmpty(ValueNameValidationMessage + EnumValueValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Value _editValue = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditValue.</summary>
		///--------------------------------------------------------------------------------
		public Value EditValue
		{
			get
			{
				if (_editValue == null)
				{
					_editValue = new Value();
					_editValue.PropertyChanged += new PropertyChangedEventHandler(EditValue_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Value != null)
					{
						_editValue.TransformDataFromObject(Value, null, false);
						_editValue.Solution = Value.Solution;
						_editValue.Enumeration = Value.Enumeration;
					}
					_editValue.ResetModified(false);
				}
				return _editValue;
			}
			set
			{
				_editValue = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditValue_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditValue");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ValueName");
			OnPropertyChanged("ValueNameCustomized");
			OnPropertyChanged("ValueNameValidationMessage");
			
			OnPropertyChanged("EnumValue");
			OnPropertyChanged("EnumValueCustomized");
			OnPropertyChanged("EnumValueValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
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
				return DisplayValues.Edit_ValueHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ValueHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ValueIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ValueIDLabel
		{
			get
			{
				return DisplayValues.Edit_ValueIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ValueNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ValueNameLabel
		{
			get
			{
				return DisplayValues.Edit_ValueNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ValueName.</summary>
		///--------------------------------------------------------------------------------
		public string ValueName
		{
			get
			{
				return EditValue.ValueName;
			}
			set
			{
				EditValue.ValueName = value;
				OnPropertyChanged("ValueName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValueNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ValueNameCustomized
		{
			get
			{
				if (Value.ReverseInstance != null)
				{
					return ValueName.GetString() != Value.ReverseInstance.ValueName.GetString();
				}
				else if (Value.IsAutoUpdated == true)
				{
					return ValueName.GetString() != Value.ValueName.GetString();
				}
				return ValueName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValueNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ValueNameValidationMessage
		{
			get
			{
				return EditValue.ValidateValueName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EnumValueLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EnumValueLabel
		{
			get
			{
				return DisplayValues.Edit_EnumValueProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EnumValue.</summary>
		///--------------------------------------------------------------------------------
		public string EnumValue
		{
			get
			{
				return EditValue.EnumValue;
			}
			set
			{
				EditValue.EnumValue = value;
				OnPropertyChanged("EnumValue");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets EnumValueCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool EnumValueCustomized
		{
			get
			{
				if (Value.ReverseInstance != null)
				{
					return EnumValue.GetString() != Value.ReverseInstance.EnumValue.GetString();
				}
				else if (Value.IsAutoUpdated == true)
				{
					return EnumValue.GetString() != Value.EnumValue.GetString();
				}
				return EnumValue != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EnumValueValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string EnumValueValidationMessage
		{
			get
			{
				return EditValue.ValidateEnumValue();
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
				return EditValue.Order;
			}
			set
			{
				EditValue.Order = value;
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
				if (Value.ReverseInstance != null)
				{
					return Order.GetInt() != Value.ReverseInstance.Order.GetInt();
				}
				else if (Value.IsAutoUpdated == true)
				{
					return Order.GetInt() != Value.Order.GetInt();
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
				return EditValue.ValidateOrder();
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
				return EditValue.Description;
			}
			set
			{
				EditValue.Description = value;
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
				if (Value.ReverseInstance != null)
				{
					return Description.GetString() != Value.ReverseInstance.Description.GetString();
				}
				else if (Value.IsAutoUpdated == true)
				{
					return Description.GetString() != Value.Description.GetString();
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
				return EditValue.ValidateDescription();
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
				return EditValue.SourceName;
			}
			set
			{
				EditValue.SourceName = value;
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
				return EditValue.SpecSourceName;
			}
			set
			{
				EditValue.SpecSourceName = value;
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
				return EditValue.Tags;
			}
			set
			{
				EditValue.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Value.ReverseInstance != null)
				{
					return Tags != Value.ReverseInstance.Tags;
				}
				else if (Value.IsAutoUpdated == true)
				{
					return Tags != Value.Tags;
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
				return EditValue.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditValue.Name;
			}
			set
			{
				EditValue.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditValue.TransformDataFromObject(Value, null, false);
			EditValue.ResetModified(false);
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
			if (Value.ReverseInstance != null)
			{
				EditValue.TransformDataFromObject(Value.ReverseInstance, null, false);
			}
			else if (Value.IsAutoUpdated == true)
			{
				EditValue.TransformDataFromObject(Value, null, false);
			}
			else
			{
				Value newValue = new Value();
				newValue.ValueID = EditValue.ValueID;
				EditValue.TransformDataFromObject(newValue, null, false);
			}
			EditValue.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Value command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewValueCommand()
		{
			ValueEventArgs message = new ValueEventArgs();
			message.Value = new Value();
			message.Value.ValueID = Guid.NewGuid();
			message.Value.EnumerationID = EnumerationID;
			message.Value.Enumeration = Solution.EnumerationList.FindByID((Guid)EnumerationID);
			if (message.Value.Enumeration != null)
			{
				message.Value.Order = message.Value.Enumeration.ValueList.Count + 1;
			}
			message.Value.Solution = Solution;
			message.EnumerationID = EnumerationID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ValueEventArgs>(MediatorMessages.Command_EditValueRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditValueCommand()
		{
			ValueEventArgs message = new ValueEventArgs();
			message.Value = Value;
			message.EnumerationID = EnumerationID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ValueEventArgs>(MediatorMessages.Command_EditValueRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewValueCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Value.ReverseInstance == null && Value.IsAutoUpdated == true)
			{
				Value.ReverseInstance = new Value();
				Value.ReverseInstance.TransformDataFromObject(Value, null, false);

				// perform the update of EditValue back to Value
				Value.TransformDataFromObject(EditValue, null, false);
				Value.IsAutoUpdated = false;
			}
			else if (Value.ReverseInstance != null)
			{
				EditValue.ResetModified(Value.ReverseInstance.IsModified);
				if (EditValue.Equals(Value.ReverseInstance))
				{
					// perform the update of EditValue back to Value
					Value.TransformDataFromObject(EditValue, null, false);
					Value.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditValue back to Value
					Value.TransformDataFromObject(EditValue, null, false);
					Value.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditValue back to Value
				Value.TransformDataFromObject(EditValue, null, false);
				Value.IsAutoUpdated = false;
			}
			Value.ForwardInstance = null;
			if (ValueNameCustomized || EnumValueCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				Value.ForwardInstance = new Value();
				Value.ForwardInstance.ValueID = EditValue.ValueID;
				Value.SpecSourceName = Value.DefaultSourceName;
				if (ValueNameCustomized)
				{
					Value.ForwardInstance.ValueName = EditValue.ValueName;
				}
				if (EnumValueCustomized)
				{
					Value.ForwardInstance.EnumValue = EditValue.EnumValue;
				}
				if (OrderCustomized)
				{
					Value.ForwardInstance.Order = EditValue.Order;
				}
				if (DescriptionCustomized)
				{
					Value.ForwardInstance.Description = EditValue.Description;
				}
				if (TagsCustomized)
				{
					Value.ForwardInstance.Tags = EditValue.Tags;
				}
			}
			EditValue.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditValuePerformed();
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
		public void SendEditValuePerformed()
		{
			ValueEventArgs message = new ValueEventArgs();
			message.Value = Value;
			message.EnumerationID = EnumerationID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ValueEventArgs>(MediatorMessages.Command_EditValuePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Value command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteValueCommand()
		{
			ValueEventArgs message = new ValueEventArgs();
			message.Value = Value;
			message.EnumerationID = EnumerationID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ValueEventArgs>(MediatorMessages.Command_DeleteValueRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteValueCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Value.</summary>
		///--------------------------------------------------------------------------------
		public Value Value { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValueID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ValueID
		{
			get
			{
				return Value.ValueID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Value.Name;
			}
			set
			{
				Value.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return Value.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EnumerationID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EnumerationID
		{
			get
			{
				return Value.EnumerationID;
			}
			set
			{
				Value.EnumerationID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Value into the view model.</summary>
		/// 
		/// <param name="value">The Value to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadValue(Value value, bool loadChildren = true)
		{
			// attach the Value
			Value = value;
			ItemID = Value.ValueID;
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
			
			HasErrors = !Value.IsValid;
			HasCustomizations = Value.IsAutoUpdated == false || Value.IsEmptyMetadata(Value.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Value.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Value.IsAutoUpdated = true;
				Value.SpecSourceName = Value.ReverseInstance.SpecSourceName;
				Value.ResetModified(Value.ReverseInstance.IsModified);
				Value.ResetLoaded(Value.ReverseInstance.IsLoaded);
				if (!Value.IsIdenticalMetadata(Value.ReverseInstance))
				{
					HasCustomizations = true;
					Value.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Value.ForwardInstance = null;
				Value.ReverseInstance = null;
				Value.IsAutoUpdated = true;
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
			if (_editValue != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditValue.PropertyChanged -= EditValue_PropertyChanged;
				EditValue = null;
			}
			Value = null;
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
		public ValueViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="value">The Value to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ValueViewModel(Value value, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadValue(value, loadChildren);
		}

		#endregion "Constructors"
	}
}
