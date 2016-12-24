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
	/// <summary>This class provides views for Enumeration instances.</summary>
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
	public partial class EnumerationViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEnumeration.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEnumeration
		{
			get
			{
				return DisplayValues.ContextMenu_NewEnumeration;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlEnumerationToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEnumerationToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEnumerationToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewValueToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewValueToolTip
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
				if (EditEnumeration.IsModified == true)
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
				return string.IsNullOrEmpty(EnumerationNameValidationMessage + DescriptionValidationMessage + ValueListValidationMessage);
			}
		}
 
		private Enumeration _editEnumeration = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditEnumeration.</summary>
		///--------------------------------------------------------------------------------
		public Enumeration EditEnumeration
		{
			get
			{
				if (_editEnumeration == null)
				{
					_editEnumeration = new Enumeration();
					_editEnumeration.PropertyChanged += new PropertyChangedEventHandler(EditEnumeration_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Enumeration != null)
					{
						_editEnumeration.TransformDataFromObject(Enumeration, null, false);
						_editEnumeration.Solution = Enumeration.Solution;
						_editEnumeration.Model = Enumeration.Model;
					}
					_editEnumeration.ResetModified(false);
				}
				return _editEnumeration;
			}
			set
			{
				_editEnumeration = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditEnumeration_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditEnumeration");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("EnumerationName");
			OnPropertyChanged("EnumerationNameCustomized");
			OnPropertyChanged("EnumerationNameValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ValueList");
			OnPropertyChanged("ValueListCustomized");
			OnPropertyChanged("ValueListValidationMessage");

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
				return DisplayValues.Edit_EnumerationHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_EnumerationHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EnumerationIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EnumerationIDLabel
		{
			get
			{
				return DisplayValues.Edit_EnumerationIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ValueListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ValueListLabel
		{
			get
			{
				return DisplayValues.Edit_ValueListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ValueList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Value> ValueList
		{
			get
			{
				return EditEnumeration.ValueList;
			}
			set
			{
				EditEnumeration.ValueList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValueListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ValueListCustomized
		{
			get
			{
				#region protected
				foreach (ValueViewModel item in Items.OfType<ValueViewModel>())
				{
					if (item.HasCustomizations == true || item.Value.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValueListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ValueListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EnumerationNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EnumerationNameLabel
		{
			get
			{
				return DisplayValues.Edit_EnumerationNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EnumerationName.</summary>
		///--------------------------------------------------------------------------------
		public string EnumerationName
		{
			get
			{
				return EditEnumeration.EnumerationName;
			}
			set
			{
				EditEnumeration.EnumerationName = value;
				OnPropertyChanged("EnumerationName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets EnumerationNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool EnumerationNameCustomized
		{
			get
			{
				if (Enumeration.ReverseInstance != null)
				{
					return EnumerationName.GetString() != Enumeration.ReverseInstance.EnumerationName.GetString();
				}
				else if (Enumeration.IsAutoUpdated == true)
				{
					return EnumerationName.GetString() != Enumeration.EnumerationName.GetString();
				}
				return EnumerationName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EnumerationNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string EnumerationNameValidationMessage
		{
			get
			{
				return EditEnumeration.ValidateEnumerationName();
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
				return EditEnumeration.Description;
			}
			set
			{
				EditEnumeration.Description = value;
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
				if (Enumeration.ReverseInstance != null)
				{
					return Description.GetString() != Enumeration.ReverseInstance.Description.GetString();
				}
				else if (Enumeration.IsAutoUpdated == true)
				{
					return Description.GetString() != Enumeration.Description.GetString();
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
				return EditEnumeration.ValidateDescription();
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
				return EditEnumeration.SourceName;
			}
			set
			{
				EditEnumeration.SourceName = value;
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
				return EditEnumeration.SpecSourceName;
			}
			set
			{
				EditEnumeration.SpecSourceName = value;
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
				return EditEnumeration.Tags;
			}
			set
			{
				EditEnumeration.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Enumeration.ReverseInstance != null)
				{
					return Tags != Enumeration.ReverseInstance.Tags;
				}
				else if (Enumeration.IsAutoUpdated == true)
				{
					return Tags != Enumeration.Tags;
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
				return EditEnumeration.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditEnumeration.Name;
			}
			set
			{
				EditEnumeration.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditEnumeration.TransformDataFromObject(Enumeration, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditEnumeration.ResetModified(false);
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
			if (Enumeration.ReverseInstance != null)
			{
				EditEnumeration.TransformDataFromObject(Enumeration.ReverseInstance, null, false);
			}
			else if (Enumeration.IsAutoUpdated == true)
			{
				EditEnumeration.TransformDataFromObject(Enumeration, null, false);
			}
			else
			{
				Enumeration newEnumeration = new Enumeration();
				newEnumeration.EnumerationID = EditEnumeration.EnumerationID;
				EditEnumeration.TransformDataFromObject(newEnumeration, null, false);
			}
			EditEnumeration.ResetModified(true);
			foreach (ValueViewModel item in Items.OfType<ValueViewModel>())
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
		/// <summary>This method processes the new Enumeration command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewEnumerationCommand()
		{
			EnumerationEventArgs message = new EnumerationEventArgs();
			message.Enumeration = new Enumeration();
			message.Enumeration.EnumerationID = Guid.NewGuid();
			message.Enumeration.ModelID = ModelID;
			message.Enumeration.Model = Solution.ModelList.FindByID((Guid)ModelID);
			message.Enumeration.Solution = Solution;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EnumerationEventArgs>(MediatorMessages.Command_EditEnumerationRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditEnumerationCommand()
		{
			EnumerationEventArgs message = new EnumerationEventArgs();
			message.Enumeration = Enumeration;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EnumerationEventArgs>(MediatorMessages.Command_EditEnumerationRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Value adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewValue()
		{
			ValueViewModel item = new ValueViewModel();
			item.Value = new Value();
			item.Value.ValueID = Guid.NewGuid();
			item.Value.Enumeration = EditEnumeration;
			item.Value.EnumerationID = EditEnumeration.EnumerationID;
			item.Value.Solution = Solution;
			item.Value.Order = Enumeration.ValueList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Value command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewValueCommand()
		{
			ValueEventArgs message = new ValueEventArgs();
			message.Value = new Value();
			message.Value.ValueID = Guid.NewGuid();
			message.Value.Enumeration = Enumeration;
			message.Value.EnumerationID = Enumeration.EnumerationID;
			message.EnumerationID = Enumeration.EnumerationID;
			if (message.Value.Enumeration != null)
			{
				message.Value.Order = message.Value.Enumeration.ValueList.Count + 1;
			}
			message.Value.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ValueEventArgs>(MediatorMessages.Command_EditValueRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Value updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditValuePerformed(ValueEventArgs data)
		{
			if (data != null && data.Value != null)
			{
				UpdateEditValue(data.Value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of Value.</summary>
		/// 
		/// <param name="value">The Value to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditValue(Value value)
		{
			bool isItemMatch = false;
			foreach (ValueViewModel item in Values)
			{
				if (item.Value.ValueID == value.ValueID)
				{
					isItemMatch = true;
					item.Value.TransformDataFromObject(value, null, false);
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new Value
				value.Enumeration = Enumeration;
				ValueViewModel newItem = new ValueViewModel(value, Solution);
				newItem.Updated += new EventHandler(Children_Updated);
				Values.Add(newItem);
				Enumeration.ValueList.Add(value);
				Solution.ValueList.Add(newItem.Value);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Value deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedValues(ValueViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Value deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteValuePerformed(ValueEventArgs data)
		{
			if (data != null && data.Value != null)
			{
				DeleteValue(data.Value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Value.</summary>
		/// 
		/// <param name="value">The Value to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteValue(Value value)
		{
			bool isItemMatch = false;
			foreach (ValueViewModel item in Values.ToList<ValueViewModel>())
			{
				if (item.Value.ValueID == value.ValueID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.Value.ValueID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete Value
					isItemMatch = true;
					Values.Remove(item);
					Enumeration.ValueList.Remove(item.Value);
					Solution.ValueList.Remove(item.Value);
					Items.Remove(item);
					Enumeration.ResetModified(true);
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
			ProcessNewEnumerationCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Enumeration.ReverseInstance == null && Enumeration.IsAutoUpdated == true)
			{
				Enumeration.ReverseInstance = new Enumeration();
				Enumeration.ReverseInstance.TransformDataFromObject(Enumeration, null, false);

				// perform the update of EditEnumeration back to Enumeration
				Enumeration.TransformDataFromObject(EditEnumeration, null, false);
				Enumeration.IsAutoUpdated = false;
			}
			else if (Enumeration.ReverseInstance != null)
			{
				EditEnumeration.ResetModified(Enumeration.ReverseInstance.IsModified);
				if (EditEnumeration.Equals(Enumeration.ReverseInstance))
				{
					// perform the update of EditEnumeration back to Enumeration
					Enumeration.TransformDataFromObject(EditEnumeration, null, false);
					Enumeration.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditEnumeration back to Enumeration
					Enumeration.TransformDataFromObject(EditEnumeration, null, false);
					Enumeration.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditEnumeration back to Enumeration
				Enumeration.TransformDataFromObject(EditEnumeration, null, false);
				Enumeration.IsAutoUpdated = false;
			}
			Enumeration.ForwardInstance = null;
			if (EnumerationNameCustomized || DescriptionCustomized || ValueListCustomized || TagsCustomized)
			{
				Enumeration.ForwardInstance = new Enumeration();
				Enumeration.ForwardInstance.EnumerationID = EditEnumeration.EnumerationID;
				Enumeration.SpecSourceName = Enumeration.DefaultSourceName;
				if (EnumerationNameCustomized)
				{
					Enumeration.ForwardInstance.EnumerationName = EditEnumeration.EnumerationName;
				}
				if (DescriptionCustomized)
				{
					Enumeration.ForwardInstance.Description = EditEnumeration.Description;
				}
				if (ValueListCustomized)
				{
					#region protected
					#endregion protected
					// Enumeration.ValueList = new EnterpriseDataObjectList<Value>(EditEnumeration.ValueList, null);
					// Enumeration.ForwardInstance.ValueList = new EnterpriseDataObjectList<Value>(EditEnumeration.ValueList, null);
				}
				if (TagsCustomized)
				{
					Enumeration.ForwardInstance.Tags = EditEnumeration.Tags;
				}
			}
			EditEnumeration.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditEnumerationPerformed();

			// send update for any updated Values
			foreach (ValueViewModel item in Values)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new Values
			foreach (ValueViewModel item in ItemsToAdd.OfType<ValueViewModel>())
			{
				item.Update();
				Values.Add(item);
			}

			// send delete for any deleted Values
			foreach (ValueViewModel item in ItemsToDelete.OfType<ValueViewModel>())
			{
				item.Delete();
				Values.Remove(item);
			}

			// reset modified for Values
			foreach (ValueViewModel item in Values)
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
		public void SendEditEnumerationPerformed()
		{
			EnumerationEventArgs message = new EnumerationEventArgs();
			message.Enumeration = Enumeration;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EnumerationEventArgs>(MediatorMessages.Command_EditEnumerationPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Enumeration command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteEnumerationCommand()
		{
			EnumerationEventArgs message = new EnumerationEventArgs();
			message.Enumeration = Enumeration;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EnumerationEventArgs>(MediatorMessages.Command_DeleteEnumerationRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteEnumerationCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Value lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ValueViewModel> Values { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Enumeration.</summary>
		///--------------------------------------------------------------------------------
		public Enumeration Enumeration { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EnumerationID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EnumerationID
		{
			get
			{
				return Enumeration.EnumerationID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Enumeration.Name;
			}
			set
			{
				Enumeration.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelID
		{
			get
			{
				return Enumeration.ModelID;
			}
			set
			{
				Enumeration.ModelID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Enumeration into the view model.</summary>
		/// 
		/// <param name="enumeration">The Enumeration to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadEnumeration(Enumeration enumeration, bool loadChildren = true)
		{
			// attach the Enumeration
			Enumeration = enumeration;
			ItemID = Enumeration.EnumerationID;
			Items.Clear();
			
			// initialize Values
			if (Values == null)
			{
				Values = new EnterpriseDataObjectList<ValueViewModel>();
			}
			if (loadChildren == true)
			{
				// attach Values
				foreach (Value item in enumeration.ValueList)
				{
					ValueViewModel itemView = new ValueViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Values.Add(itemView);
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
				foreach (ValueViewModel item in Values)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Enumeration.IsValid;
			HasCustomizations = Enumeration.IsAutoUpdated == false || Enumeration.IsEmptyMetadata(Enumeration.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Enumeration.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Enumeration.IsAutoUpdated = true;
				Enumeration.SpecSourceName = Enumeration.ReverseInstance.SpecSourceName;
				Enumeration.ResetModified(Enumeration.ReverseInstance.IsModified);
				Enumeration.ResetLoaded(Enumeration.ReverseInstance.IsLoaded);
				if (!Enumeration.IsIdenticalMetadata(Enumeration.ReverseInstance))
				{
					HasCustomizations = true;
					Enumeration.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Enumeration.ForwardInstance = null;
				Enumeration.ReverseInstance = null;
				Enumeration.IsAutoUpdated = true;
			}
			foreach (ValueViewModel item in Values)
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
			if (Values != null)
			{
				for (int i = Values.Count - 1; i >= 0; i--)
				{
					Values[i].Updated -= Children_Updated;
					Values[i].Dispose();
					Values.Remove(Values[i]);
				}
				Values = null;
			}
			if (_editEnumeration != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditEnumeration.PropertyChanged -= EditEnumeration_PropertyChanged;
				EditEnumeration = null;
			}
			Enumeration = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (ValueViewModel item in Values)
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
			OnPropertyChanged("ValueList");
			OnPropertyChanged("ValueListCustomized");
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
			if (data is ValueEventArgs && (data as ValueEventArgs).EnumerationID == Enumeration.EnumerationID)
			{
				return this;
			}
			foreach (ValueViewModel model in Values)
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
		public ValueViewModel PasteValue(ValueViewModel copyItem, bool savePaste = true)
		{
			Value newItem = new Value();
			newItem.ReverseInstance = new Value();
			newItem.TransformDataFromObject(copyItem.Value, null, false);
			newItem.ValueID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			newItem.Enumeration = Enumeration;
			newItem.Solution = Solution;
			ValueViewModel newView = new ValueViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddValue(newView);
			if (savePaste == true)
			{
				Solution.ValueList.Add(newItem);
				Enumeration.ValueList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Value to the view model.</summary>
		/// 
		/// <param name="itemView">The Value to add.</param>
		///--------------------------------------------------------------------------------
		public void AddValue(ValueViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Values.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Value from the view model.</summary>
		/// 
		/// <param name="itemView">The Value to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteValue(ValueViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Values.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public EnumerationViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="enumeration">The Enumeration to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public EnumerationViewModel(Enumeration enumeration, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadEnumeration(enumeration, loadChildren);
		}

		#endregion "Constructors"
	}
}
