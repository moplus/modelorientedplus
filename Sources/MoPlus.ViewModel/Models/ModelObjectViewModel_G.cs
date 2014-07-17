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
	/// <summary>This class provides views for ModelObject instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/15/2014</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelObjectViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelObject.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelObject
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObject;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlModelObjectToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelModelObjectToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObjectToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelPropertyToolTip;
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
				if (EditModelObject.IsModified == true)
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
				return string.IsNullOrEmpty(ModelObjectNameValidationMessage + ParentModelObjectIDValidationMessage + DescriptionValidationMessage + ModelPropertyListValidationMessage);
			}
		}
 
		private ModelObject _editModelObject = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditModelObject.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject EditModelObject
		{
			get
			{
				if (_editModelObject == null)
				{
					_editModelObject = new ModelObject();
					_editModelObject.PropertyChanged += new PropertyChangedEventHandler(EditModelObject_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (ModelObject != null)
					{
						_editModelObject.TransformDataFromObject(ModelObject, null, false);
						_editModelObject.Solution = ModelObject.Solution;
						_editModelObject.Model = ModelObject.Model;
					}
					_editModelObject.ResetModified(false);
				}
				return _editModelObject;
			}
			set
			{
				_editModelObject = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditModelObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditModelObject");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ModelObjectName");
			OnPropertyChanged("ModelObjectNameCustomized");
			OnPropertyChanged("ModelObjectNameValidationMessage");
			
			OnPropertyChanged("ParentModelObjectID");
			OnPropertyChanged("ParentModelObjectIDCustomized");
			OnPropertyChanged("ParentModelObjectIDValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ModelPropertyList");
			OnPropertyChanged("ModelPropertyListCustomized");
			OnPropertyChanged("ModelPropertyListValidationMessage");

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
				return DisplayValues.Edit_ModelObjectHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ModelObjectHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelObjectIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectIDLabel
		{
			get
			{
				return DisplayValues.Edit_ModelObjectIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyListLabel
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelPropertyList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelProperty> ModelPropertyList
		{
			get
			{
				return EditModelObject.ModelPropertyList;
			}
			set
			{
				EditModelObject.ModelPropertyList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelPropertyListCustomized
		{
			get
			{
				#region protected
				foreach (ModelPropertyViewModel item in Items.OfType<ModelPropertyViewModel>())
				{
					if (item.HasCustomizations == true || item.ModelProperty.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelObjectNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectNameLabel
		{
			get
			{
				return DisplayValues.Edit_ModelObjectNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelObjectName.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectName
		{
			get
			{
				return EditModelObject.ModelObjectName;
			}
			set
			{
				EditModelObject.ModelObjectName = value;
				OnPropertyChanged("ModelObjectName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelObjectNameCustomized
		{
			get
			{
				if (ModelObject.ReverseInstance != null)
				{
					return ModelObjectName.GetString() != ModelObject.ReverseInstance.ModelObjectName.GetString();
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return ModelObjectName.GetString() != ModelObject.ModelObjectName.GetString();
				}
				return ModelObjectName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectNameValidationMessage
		{
			get
			{
				return EditModelObject.ValidateModelObjectName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParentModelObjectIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParentModelObjectIDLabel
		{
			get
			{
				return DisplayValues.Edit_ParentModelObjectIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ParentModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? ParentModelObjectID
		{
			get
			{
				return EditModelObject.ParentModelObjectID;
			}
			set
			{
				EditModelObject.ParentModelObjectID = value;
				OnPropertyChanged("ParentModelObjectID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParentModelObjectIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ParentModelObjectIDCustomized
		{
			get
			{
				if (ModelObject.ReverseInstance != null)
				{
					return ParentModelObjectID.GetGuid() != ModelObject.ReverseInstance.ParentModelObjectID.GetGuid();
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return ParentModelObjectID.GetGuid() != ModelObject.ParentModelObjectID.GetGuid();
				}
				return ParentModelObjectID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParentModelObjectIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ParentModelObjectIDValidationMessage
		{
			get
			{
				return EditModelObject.ValidateParentModelObjectID();
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
				return EditModelObject.Description;
			}
			set
			{
				EditModelObject.Description = value;
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
				if (ModelObject.ReverseInstance != null)
				{
					return Description.GetString() != ModelObject.ReverseInstance.Description.GetString();
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return Description.GetString() != ModelObject.Description.GetString();
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
				return EditModelObject.ValidateDescription();
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
				return EditModelObject.SourceName;
			}
			set
			{
				EditModelObject.SourceName = value;
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
				return EditModelObject.SpecSourceName;
			}
			set
			{
				EditModelObject.SpecSourceName = value;
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
				return EditModelObject.Tags;
			}
			set
			{
				EditModelObject.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (ModelObject.ReverseInstance != null)
				{
					return Tags != ModelObject.ReverseInstance.Tags;
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return Tags != ModelObject.Tags;
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
				return EditModelObject.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditModelObject.Name;
			}
			set
			{
				EditModelObject.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditModelObject.TransformDataFromObject(ModelObject, null, false);
			ResetItems();
			
			#region protected
			ModelPropertyItems.Clear();
			_modelPropertyItems = null;
			OnPropertyChanged("ModelPropertyItems");
			#endregion protected

			EditModelObject.ResetModified(false);
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
			if (ModelObject.ReverseInstance != null)
			{
				EditModelObject.TransformDataFromObject(ModelObject.ReverseInstance, null, false);
			}
			else if (ModelObject.IsAutoUpdated == true)
			{
				EditModelObject.TransformDataFromObject(ModelObject, null, false);
			}
			else
			{
				ModelObject newModelObject = new ModelObject();
				newModelObject.ModelObjectID = EditModelObject.ModelObjectID;
				EditModelObject.TransformDataFromObject(newModelObject, null, false);
			}
			EditModelObject.ResetModified(true);
			foreach (ModelPropertyViewModel item in Items.OfType<ModelPropertyViewModel>())
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
		/// <summary>This method processes the new ModelObject command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = new ModelObject();
			message.ModelObject.ModelObjectID = Guid.NewGuid();
			message.ModelObject.ModelID = ModelID;
			message.ModelObject.Model = Solution.ModelList.FindByID((Guid)ModelID);
			message.ModelObject.Solution = Solution;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = ModelObject;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to ModelProperty adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewModelProperty()
		{
			ModelPropertyViewModel item = new ModelPropertyViewModel();
			item.ModelProperty = new ModelProperty();
			item.ModelProperty.ModelPropertyID = Guid.NewGuid();
			item.ModelProperty.ModelObject = EditModelObject;
			item.ModelProperty.ModelObjectID = EditModelObject.ModelObjectID;
			item.ModelProperty.Solution = Solution;
			item.ModelProperty.Order = ModelObject.ModelPropertyList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new ModelProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelPropertyCommand()
		{
			ModelPropertyEventArgs message = new ModelPropertyEventArgs();
			message.ModelProperty = new ModelProperty();
			message.ModelProperty.ModelPropertyID = Guid.NewGuid();
			message.ModelProperty.ModelObject = ModelObject;
			message.ModelProperty.ModelObjectID = ModelObject.ModelObjectID;
			message.ModelObjectID = ModelObject.ModelObjectID;
			if (message.ModelProperty.ModelObject != null)
			{
				message.ModelProperty.Order = message.ModelProperty.ModelObject.ModelPropertyList.Count + 1;
			}
			message.ModelProperty.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelPropertyEventArgs>(MediatorMessages.Command_EditModelPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ModelProperty updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelPropertyPerformed(ModelPropertyEventArgs data)
		{
			if (data != null && data.ModelProperty != null)
			{
				UpdateEditModelProperty(data.ModelProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of ModelProperty.</summary>
		/// 
		/// <param name="modelProperty">The ModelProperty to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditModelProperty(ModelProperty modelProperty)
		{
			bool isItemMatch = false;
			foreach (ModelPropertyViewModel item in ModelProperties)
			{
				if (item.ModelProperty.ModelPropertyID == modelProperty.ModelPropertyID)
				{
					isItemMatch = true;
					item.ModelProperty.TransformDataFromObject(modelProperty, null, false);
					if (!item.ModelProperty.DefinedByEnumerationID.IsNullOrEmpty())
					{
						item.ModelProperty.DefinedByEnumeration = Solution.EnumerationList.FindByID((Guid)item.ModelProperty.DefinedByEnumerationID);
					}
					if (!item.ModelProperty.DefinedByModelObjectID.IsNullOrEmpty())
					{
						item.ModelProperty.DefinedByModelObject = Solution.ModelObjectList.FindByID((Guid)item.ModelProperty.DefinedByModelObjectID);
					}
					if (!item.ModelProperty.DefinedByValueID.IsNullOrEmpty())
					{
						item.ModelProperty.DefinedByValue = Solution.ValueList.FindByID((Guid)item.ModelProperty.DefinedByValueID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new ModelProperty
				modelProperty.ModelObject = ModelObject;
				ModelPropertyViewModel newItem = new ModelPropertyViewModel(modelProperty, Solution);
				if (!newItem.ModelProperty.DefinedByEnumerationID.IsNullOrEmpty())
				{
					newItem.ModelProperty.DefinedByEnumeration = Solution.EnumerationList.FindByID((Guid)newItem.ModelProperty.DefinedByEnumerationID);
				}
				if (!newItem.ModelProperty.DefinedByModelObjectID.IsNullOrEmpty())
				{
					newItem.ModelProperty.DefinedByModelObject = Solution.ModelObjectList.FindByID((Guid)newItem.ModelProperty.DefinedByModelObjectID);
				}
				if (!newItem.ModelProperty.DefinedByValueID.IsNullOrEmpty())
				{
					newItem.ModelProperty.DefinedByValue = Solution.ValueList.FindByID((Guid)newItem.ModelProperty.DefinedByValueID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				ModelProperties.Add(newItem);
				ModelObject.ModelPropertyList.Add(modelProperty);
				Solution.ModelPropertyList.Add(newItem.ModelProperty);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to ModelProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedModelProperties(ModelPropertyViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ModelProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelPropertyPerformed(ModelPropertyEventArgs data)
		{
			if (data != null && data.ModelProperty != null)
			{
				DeleteModelProperty(data.ModelProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of ModelProperty.</summary>
		/// 
		/// <param name="modelProperty">The ModelProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteModelProperty(ModelProperty modelProperty)
		{
			bool isItemMatch = false;
			foreach (ModelPropertyViewModel item in ModelProperties.ToList<ModelPropertyViewModel>())
			{
				if (item.ModelProperty.ModelPropertyID == modelProperty.ModelPropertyID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.ModelProperty.ModelPropertyID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete ModelProperty
					isItemMatch = true;
					ModelProperties.Remove(item);
					ModelObject.ModelPropertyList.Remove(item.ModelProperty);
					Solution.ModelPropertyList.Remove(item.ModelProperty);
					Items.Remove(item);
					ModelObject.ResetModified(true);
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
			ProcessNewModelObjectCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (ModelObject.ReverseInstance == null && ModelObject.IsAutoUpdated == true)
			{
				ModelObject.ReverseInstance = new ModelObject();
				ModelObject.ReverseInstance.TransformDataFromObject(ModelObject, null, false);

				// perform the update of EditModelObject back to ModelObject
				ModelObject.TransformDataFromObject(EditModelObject, null, false);
				ModelObject.IsAutoUpdated = false;
			}
			else if (ModelObject.ReverseInstance != null)
			{
				EditModelObject.ResetModified(ModelObject.ReverseInstance.IsModified);
				if (EditModelObject.Equals(ModelObject.ReverseInstance))
				{
					// perform the update of EditModelObject back to ModelObject
					ModelObject.TransformDataFromObject(EditModelObject, null, false);
					ModelObject.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditModelObject back to ModelObject
					ModelObject.TransformDataFromObject(EditModelObject, null, false);
					ModelObject.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditModelObject back to ModelObject
				ModelObject.TransformDataFromObject(EditModelObject, null, false);
				ModelObject.IsAutoUpdated = false;
			}
			ModelObject.ForwardInstance = null;
			if (ModelObjectNameCustomized || ParentModelObjectIDCustomized || DescriptionCustomized || ModelPropertyListCustomized || TagsCustomized)
			{
				ModelObject.ForwardInstance = new ModelObject();
				ModelObject.ForwardInstance.ModelObjectID = EditModelObject.ModelObjectID;
				ModelObject.SpecSourceName = ModelObject.DefaultSourceName;
				if (ModelObjectNameCustomized)
				{
					ModelObject.ForwardInstance.ModelObjectName = EditModelObject.ModelObjectName;
				}
				if (ParentModelObjectIDCustomized)
				{
					ModelObject.ForwardInstance.ParentModelObjectID = EditModelObject.ParentModelObjectID;
				}
				if (DescriptionCustomized)
				{
					ModelObject.ForwardInstance.Description = EditModelObject.Description;
				}
				if (ModelPropertyListCustomized)
				{
					#region protected
			Solution.CodeTemplateContentParser = null;
			Solution.CodeTemplatOutputParser = null;
			Solution.ModelObjectNames = null;
			Solution.ModelPropertyNames = null;
			#endregion protected
					// ModelObject.ModelPropertyList = new EnterpriseDataObjectList<ModelProperty>(EditModelObject.ModelPropertyList, null);
					// ModelObject.ForwardInstance.ModelPropertyList = new EnterpriseDataObjectList<ModelProperty>(EditModelObject.ModelPropertyList, null);
				}
				if (TagsCustomized)
				{
					ModelObject.ForwardInstance.Tags = EditModelObject.Tags;
				}
			}
			EditModelObject.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditModelObjectPerformed();

			// send update for any updated ModelProperties
			foreach (ModelPropertyViewModel item in ModelProperties)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new ModelProperties
			foreach (ModelPropertyViewModel item in ItemsToAdd.OfType<ModelPropertyViewModel>())
			{
				item.Update();
				ModelProperties.Add(item);
			}

			// send delete for any deleted ModelProperties
			foreach (ModelPropertyViewModel item in ItemsToDelete.OfType<ModelPropertyViewModel>())
			{
				item.Delete();
				ModelProperties.Remove(item);
			}

			// reset modified for ModelProperties
			foreach (ModelPropertyViewModel item in ModelProperties)
			{
				item.ResetModified(false);
			}
			ItemsToAdd.Clear();
			ItemsToDelete.Clear();
			
			#region protected
			#endregion protected
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
		public void SendEditModelObjectPerformed()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = ModelObject;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete ModelObject command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = ModelObject;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_DeleteModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteModelObjectCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelPropertyViewModel> ModelProperties { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelObject.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject ModelObject { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelObjectID
		{
			get
			{
				return ModelObject.ModelObjectID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return ModelObject.Name;
			}
			set
			{
				ModelObject.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelID
		{
			get
			{
				return ModelObject.ModelID;
			}
			set
			{
				ModelObject.ModelID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of ModelObject into the view model.</summary>
		/// 
		/// <param name="modelObject">The ModelObject to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelObject(ModelObject modelObject, bool loadChildren = true)
		{
			// attach the ModelObject
			ModelObject = modelObject;
			ItemID = ModelObject.ModelObjectID;
			Items.Clear();
			
			// initialize ModelProperties
			if (ModelProperties == null)
			{
				ModelProperties = new EnterpriseDataObjectList<ModelPropertyViewModel>();
			}
			if (loadChildren == true)
			{
				// attach ModelProperties
				foreach (ModelProperty item in modelObject.ModelPropertyList)
				{
					ModelPropertyViewModel itemView = new ModelPropertyViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					ModelProperties.Add(itemView);
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
				foreach (ModelPropertyViewModel item in ModelProperties)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !ModelObject.IsValid;
			HasCustomizations = ModelObject.IsAutoUpdated == false || ModelObject.IsEmptyMetadata(ModelObject.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && ModelObject.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				ModelObject.IsAutoUpdated = true;
				ModelObject.SpecSourceName = ModelObject.ReverseInstance.SpecSourceName;
				ModelObject.ResetModified(ModelObject.ReverseInstance.IsModified);
				ModelObject.ResetLoaded(ModelObject.ReverseInstance.IsLoaded);
				if (!ModelObject.IsIdenticalMetadata(ModelObject.ReverseInstance))
				{
					HasCustomizations = true;
					ModelObject.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				ModelObject.ForwardInstance = null;
				ModelObject.ReverseInstance = null;
				ModelObject.IsAutoUpdated = true;
			}
			foreach (ModelPropertyViewModel item in ModelProperties)
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
			if (ModelProperties != null)
			{
				for (int i = ModelProperties.Count - 1; i >= 0; i--)
				{
					ModelProperties[i].Updated -= Children_Updated;
					ModelProperties[i].Dispose();
					ModelProperties.Remove(ModelProperties[i]);
				}
				ModelProperties = null;
			}
			if (_editModelObject != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditModelObject.PropertyChanged -= EditModelObject_PropertyChanged;
				EditModelObject = null;
			}
			ModelObject = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (ModelPropertyViewModel item in ModelProperties)
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
			OnPropertyChanged("ModelPropertyList");
			OnPropertyChanged("ModelPropertyListCustomized");
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
			if (data is ModelPropertyEventArgs && (data as ModelPropertyEventArgs).ModelObjectID == ModelObject.ModelObjectID)
			{
				return this;
			}
			foreach (ModelPropertyViewModel model in ModelProperties)
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
		public ModelPropertyViewModel PasteModelProperty(ModelPropertyViewModel copyItem, bool savePaste = true)
		{
			ModelProperty newItem = new ModelProperty();
			newItem.ReverseInstance = new ModelProperty();
			newItem.TransformDataFromObject(copyItem.ModelProperty, null, false);
			newItem.ModelPropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Enumeration by existing id first, second by old id, finally by name
			newItem.DefinedByEnumeration = ModelObject.Model.EnumerationList.FindByID((Guid)copyItem.ModelProperty.DefinedByEnumerationID);
			if (newItem.DefinedByEnumeration == null && Solution.PasteNewGuids[copyItem.ModelProperty.DefinedByEnumerationID.ToString()] is Guid)
			{
				newItem.DefinedByEnumeration = ModelObject.Model.EnumerationList.FindByID((Guid)Solution.PasteNewGuids[copyItem.ModelProperty.DefinedByEnumerationID.ToString()]);
			}
			if (newItem.DefinedByEnumeration == null)
			{
				newItem.DefinedByEnumeration = ModelObject.Model.EnumerationList.Find("Name", copyItem.ModelProperty.Name);
			}
			if (newItem.DefinedByEnumeration == null)
			{
				newItem.OldDefinedByEnumerationID = newItem.DefinedByEnumerationID;
				newItem.DefinedByEnumerationID = Guid.Empty;
			}

			// try to find ModelObject by existing id first, second by old id, finally by name
			newItem.DefinedByModelObject = ModelObject.Model.ModelObjectList.FindByID((Guid)copyItem.ModelProperty.DefinedByModelObjectID);
			if (newItem.DefinedByModelObject == null && Solution.PasteNewGuids[copyItem.ModelProperty.DefinedByModelObjectID.ToString()] is Guid)
			{
				newItem.DefinedByModelObject = ModelObject.Model.ModelObjectList.FindByID((Guid)Solution.PasteNewGuids[copyItem.ModelProperty.DefinedByModelObjectID.ToString()]);
			}
			if (newItem.DefinedByModelObject == null)
			{
				newItem.DefinedByModelObject = ModelObject.Model.ModelObjectList.Find("Name", copyItem.ModelProperty.Name);
			}
			if (newItem.DefinedByModelObject == null)
			{
				newItem.OldDefinedByModelObjectID = newItem.DefinedByModelObjectID;
				newItem.DefinedByModelObjectID = Guid.Empty;
			}

			// try to find Value by existing id first, second by old id, finally by name
			newItem.DefinedByValue = Solution.ValueList.FindByID((Guid)copyItem.ModelProperty.DefinedByValueID);
			if (newItem.DefinedByValue == null && Solution.PasteNewGuids[copyItem.ModelProperty.DefinedByValueID.ToString()] is Guid)
			{
				newItem.DefinedByValue = Solution.ValueList.FindByID((Guid)Solution.PasteNewGuids[copyItem.ModelProperty.DefinedByValueID.ToString()]);
			}
			if (newItem.DefinedByValue == null)
			{
				newItem.DefinedByValue = Solution.ValueList.Find("Name", copyItem.ModelProperty.Name);
			}
			if (newItem.DefinedByValue == null)
			{
				newItem.OldDefinedByValueID = newItem.DefinedByValueID;
				newItem.DefinedByValueID = Guid.Empty;
			}
			newItem.ModelObject = ModelObject;
			newItem.Solution = Solution;
			ModelPropertyViewModel newView = new ModelPropertyViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddModelProperty(newView);
			if (savePaste == true)
			{
				Solution.ModelPropertyList.Add(newItem);
				ModelObject.ModelPropertyList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of ModelProperty to the view model.</summary>
		/// 
		/// <param name="itemView">The ModelProperty to add.</param>
		///--------------------------------------------------------------------------------
		public void AddModelProperty(ModelPropertyViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			ModelProperties.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of ModelProperty from the view model.</summary>
		/// 
		/// <param name="itemView">The ModelProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteModelProperty(ModelPropertyViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			ModelProperties.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelObjectViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="modelObject">The ModelObject to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ModelObjectViewModel(ModelObject modelObject, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadModelObject(modelObject, loadChildren);
		}

		#endregion "Constructors"
	}
}
