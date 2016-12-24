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
	/// <summary>This class provides views for ObjectInstance instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize, change the Status value below to something
	/// other than Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>3/28/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ObjectInstanceViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewObjectInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstance;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlObjectInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelObjectInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstanceToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstance;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstanceToolTip;
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
				if (EditObjectInstance.IsModified == true)
				{
					return true;
				}
				// the ItemsToAdd pattern was modified from the standard pattern due to prepopulation of properties
				foreach (PropertyItemViewModel item in PropertyItems.OfType<PropertyItemViewModel>())
				{
					if (item.PropertyInstanceViewModel.IsEdited == true) return true;
				}
				foreach (PropertyCollectionItemViewModel item in PropertyItems.OfType<PropertyCollectionItemViewModel>())
				{
					foreach (PropertyInstanceViewModel view in item.PropertyInstances)
					{
						if (view.IsEdited == true) return true;
					}
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
				return string.IsNullOrEmpty(ParentObjectInstanceIDValidationMessage + DescriptionValidationMessage + PropertyInstanceListValidationMessage);
			}
		}
 
		private ObjectInstance _editObjectInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstance EditObjectInstance
		{
			get
			{
				if (_editObjectInstance == null)
				{
					_editObjectInstance = new ObjectInstance();
					_editObjectInstance.PropertyChanged += new PropertyChangedEventHandler(EditObjectInstance_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (ObjectInstance != null)
					{
						_editObjectInstance.TransformDataFromObject(ObjectInstance, null, false);
						_editObjectInstance.Solution = ObjectInstance.Solution;
						_editObjectInstance.ModelObject = ObjectInstance.ModelObject;
					}
					_editObjectInstance.ResetModified(false);
				}
				return _editObjectInstance;
			}
			set
			{
				_editObjectInstance = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditObjectInstance_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditObjectInstance");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ParentObjectInstanceID");
			OnPropertyChanged("ParentObjectInstanceIDCustomized");
			OnPropertyChanged("ParentObjectInstanceIDValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("PropertyInstanceList");
			OnPropertyChanged("PropertyInstanceListCustomized");
			OnPropertyChanged("PropertyInstanceListValidationMessage");

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
				if (ObjectInstance != null && ObjectInstance.ModelObject != null)
				{
					return ObjectInstance.ModelObject.ModelObjectName;
				}
				return DisplayValues.Edit_ObjectInstanceHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return Title + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ObjectInstanceIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ObjectInstanceIDLabel
		{
			get
			{
				return DisplayValues.Edit_ObjectInstanceIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyInstanceListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyInstanceListLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyInstanceListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertyInstanceList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyInstance> PropertyInstanceList
		{
			get
			{
				return EditObjectInstance.PropertyInstanceList;
			}
			set
			{
				EditObjectInstance.PropertyInstanceList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyInstanceListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PropertyInstanceListCustomized
		{
			get
			{
				#region protected
				foreach (PropertyItemViewModel item in PropertyItems.OfType<PropertyItemViewModel>())
				{
					if (item.PropertyInstanceViewModel.HasCustomizations == true || item.PropertyInstanceViewModel.PropertyInstance.IsAutoUpdated == false)
					{
						return true;
					}
				}
				foreach (PropertyCollectionItemViewModel item in PropertyItems.OfType<PropertyCollectionItemViewModel>())
				{
					foreach (PropertyInstanceViewModel view in item.PropertyInstances)
					{
						if (view.HasCustomizations == true || view.PropertyInstance.IsAutoUpdated == false)
						{
							return true;
						}
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyInstanceListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyInstanceListValidationMessage
		{
			get
			{
				#region protected
				StringBuilder sb = new StringBuilder();
				foreach (PropertyItemViewModel item in PropertyItems.OfType<PropertyItemViewModel>())
				{
					sb.Append(item.PropertyInstanceViewModel.EditPropertyInstance.GetValidationErrors());
				}
				foreach (PropertyCollectionItemViewModel item in PropertyItems.OfType<PropertyCollectionItemViewModel>())
				{
					foreach (PropertyInstanceViewModel view in item.PropertyInstances)
					{
						sb.Append(view.EditPropertyInstance.GetValidationErrors());
					}
				}
				if (!String.IsNullOrEmpty(sb.ToString())) return sb.ToString();
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParentObjectInstanceIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParentObjectInstanceIDLabel
		{
			get
			{
				return DisplayValues.Edit_ParentObjectInstanceIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ParentObjectInstanceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? ParentObjectInstanceID
		{
			get
			{
				return EditObjectInstance.ParentObjectInstanceID;
			}
			set
			{
				EditObjectInstance.ParentObjectInstanceID = value;
				OnPropertyChanged("ParentObjectInstanceID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParentObjectInstanceIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ParentObjectInstanceIDCustomized
		{
			get
			{
				if (ObjectInstance.ReverseInstance != null)
				{
					return ParentObjectInstanceID.GetGuid() != ObjectInstance.ReverseInstance.ParentObjectInstanceID.GetGuid();
				}
				else if (ObjectInstance.IsAutoUpdated == true)
				{
					return ParentObjectInstanceID.GetGuid() != ObjectInstance.ParentObjectInstanceID.GetGuid();
				}
				return ParentObjectInstanceID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParentObjectInstanceIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ParentObjectInstanceIDValidationMessage
		{
			get
			{
				return EditObjectInstance.ValidateParentObjectInstanceID();
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
				return EditObjectInstance.Description;
			}
			set
			{
				EditObjectInstance.Description = value;
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
				if (ObjectInstance.ReverseInstance != null)
				{
					return Description.GetString() != ObjectInstance.ReverseInstance.Description.GetString();
				}
				else if (ObjectInstance.IsAutoUpdated == true)
				{
					return Description.GetString() != ObjectInstance.Description.GetString();
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
				return EditObjectInstance.ValidateDescription();
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
				return EditObjectInstance.SourceName;
			}
			set
			{
				EditObjectInstance.SourceName = value;
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
				return EditObjectInstance.SpecSourceName;
			}
			set
			{
				EditObjectInstance.SpecSourceName = value;
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
				return EditObjectInstance.Tags;
			}
			set
			{
				EditObjectInstance.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (ObjectInstance.ReverseInstance != null)
				{
					return Tags != ObjectInstance.ReverseInstance.Tags;
				}
				else if (ObjectInstance.IsAutoUpdated == true)
				{
					return Tags != ObjectInstance.Tags;
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
				return EditObjectInstance.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				#region protected
				return ObjectInstance.Name;
				#endregion protected
			}
			set
			{
				EditObjectInstance.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditObjectInstance.TransformDataFromObject(ObjectInstance, null, false);
			ResetItems();
			
			#region protected
			PropertyItems.Clear();
			_propertyItems = null;
			OnPropertyChanged("PropertyItems");
			#endregion protected

			EditObjectInstance.ResetModified(false);
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
			if (ObjectInstance.ReverseInstance != null)
			{
				EditObjectInstance.TransformDataFromObject(ObjectInstance.ReverseInstance, null, false);
			}
			else if (ObjectInstance.IsAutoUpdated == true)
			{
				EditObjectInstance.TransformDataFromObject(ObjectInstance, null, false);
			}
			else
			{
				ObjectInstance newObjectInstance = new ObjectInstance();
				newObjectInstance.ObjectInstanceID = EditObjectInstance.ObjectInstanceID;
				EditObjectInstance.TransformDataFromObject(newObjectInstance, null, false);
			}
			EditObjectInstance.ResetModified(true);
			foreach (PropertyInstanceViewModel item in Items.OfType<PropertyInstanceViewModel>())
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
		/// <summary>This method processes the new ObjectInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewObjectInstanceCommand()
		{
			ObjectInstanceEventArgs message = new ObjectInstanceEventArgs();
			message.ObjectInstance = new ObjectInstance();
			message.ObjectInstance.ObjectInstanceID = Guid.NewGuid();
			message.ObjectInstance.ModelObjectID = ModelObjectID;
			message.ObjectInstance.ModelObject = Solution.ModelObjectList.FindByID((Guid)ModelObjectID);
			message.ObjectInstance.Solution = Solution;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ObjectInstanceEventArgs>(MediatorMessages.Command_EditObjectInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditObjectInstanceCommand()
		{
			ObjectInstanceEventArgs message = new ObjectInstanceEventArgs();
			message.ObjectInstance = ObjectInstance;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ObjectInstanceEventArgs>(MediatorMessages.Command_EditObjectInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyInstance adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewPropertyInstance()
		{
			PropertyInstanceViewModel item = new PropertyInstanceViewModel();
			item.PropertyInstance = new PropertyInstance();
			item.PropertyInstance.PropertyInstanceID = Guid.NewGuid();
			item.PropertyInstance.ObjectInstance = EditObjectInstance;
			item.PropertyInstance.ObjectInstanceID = EditObjectInstance.ObjectInstanceID;
			item.PropertyInstance.Solution = Solution;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new PropertyInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyInstanceCommand()
		{
			PropertyInstanceEventArgs message = new PropertyInstanceEventArgs();
			message.PropertyInstance = new PropertyInstance();
			message.PropertyInstance.PropertyInstanceID = Guid.NewGuid();
			message.PropertyInstance.ObjectInstance = ObjectInstance;
			message.PropertyInstance.ObjectInstanceID = ObjectInstance.ObjectInstanceID;
			message.ObjectInstanceID = ObjectInstance.ObjectInstanceID;
			message.PropertyInstance.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyInstanceEventArgs>(MediatorMessages.Command_EditPropertyInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyInstance updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyInstancePerformed(PropertyInstanceEventArgs data)
		{
			if (data != null && data.PropertyInstance != null)
			{
				UpdateEditPropertyInstance(data.PropertyInstance);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of PropertyInstance.</summary>
		/// 
		/// <param name="propertyInstance">The PropertyInstance to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditPropertyInstance(PropertyInstance propertyInstance)
		{
			bool isItemMatch = false;
			foreach (PropertyInstanceViewModel item in PropertyInstances)
			{
				if (item.PropertyInstance.PropertyInstanceID == propertyInstance.PropertyInstanceID)
				{
					isItemMatch = true;
					item.PropertyInstance.TransformDataFromObject(propertyInstance, null, false);
					if (!item.PropertyInstance.ModelPropertyID.IsNullOrEmpty())
					{
						item.PropertyInstance.ModelProperty = Solution.ModelPropertyList.FindByID((Guid)item.PropertyInstance.ModelPropertyID);
					}
					item.OnUpdated(item, null);
					break;
				}
			}
			if (isItemMatch == false)
			{
				foreach (PropertyInstanceCollectionViewModel collection in Collections)
				{
					foreach (PropertyInstanceViewModel item in collection.PropertyInstances)
					{
						if (item.PropertyInstance.PropertyInstanceID == propertyInstance.PropertyInstanceID)
						{
							isItemMatch = true;
							item.PropertyInstance.TransformDataFromObject(propertyInstance, null, false);
							if (!item.PropertyInstance.ModelPropertyID.IsNullOrEmpty())
							{
								item.PropertyInstance.ModelProperty = Solution.ModelPropertyList.FindByID((Guid)item.PropertyInstance.ModelPropertyID);
							}
							item.OnUpdated(item, null);
							break;
						}
					}
				}
			}
			if (isItemMatch == false)
			{
				if (propertyInstance.ModelProperty == null || propertyInstance.ModelProperty.IsCollection == false)
				{
					// add new PropertyInstance
					propertyInstance.ObjectInstance = ObjectInstance;
					PropertyInstanceViewModel newItem = new PropertyInstanceViewModel(propertyInstance, Solution);
					if (!newItem.PropertyInstance.ModelPropertyID.IsNullOrEmpty())
					{
						newItem.PropertyInstance.ModelProperty = Solution.ModelPropertyList.FindByID((Guid)newItem.PropertyInstance.ModelPropertyID);
					}
					newItem.Updated += new EventHandler(Children_Updated);
					PropertyInstances.Add(newItem);
					ObjectInstance.PropertyInstanceList.Add(propertyInstance);
					Solution.PropertyInstanceList.Add(newItem.PropertyInstance);
					Items.Add(newItem);
					OnUpdated(this, null);
				}
				else
				{
					foreach (PropertyInstanceCollectionViewModel collection in Collections)
					{
						if (collection.ModelProperty.ModelPropertyID == propertyInstance.ModelPropertyID)
						{
							// add new PropertyInstance
							propertyInstance.ObjectInstance = ObjectInstance;
							PropertyInstanceViewModel newItem = new PropertyInstanceViewModel(propertyInstance, Solution);
							if (!newItem.PropertyInstance.ModelPropertyID.IsNullOrEmpty())
							{
								newItem.PropertyInstance.ModelProperty = Solution.ModelPropertyList.FindByID((Guid)newItem.PropertyInstance.ModelPropertyID);
							}
							newItem.Updated += new EventHandler(Children_Updated);
							collection.PropertyInstances.Add(newItem);
							ObjectInstance.PropertyInstanceList.Add(propertyInstance);
							Solution.PropertyInstanceList.Add(newItem.PropertyInstance);
							collection.Items.Add(newItem);
							OnUpdated(this, null);
							break;
						}
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyInstance deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedPropertyInstances(PropertyInstanceViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyInstance deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyInstancePerformed(PropertyInstanceEventArgs data)
		{
			if (data != null && data.PropertyInstance != null)
			{
				DeletePropertyInstance(data.PropertyInstance);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of PropertyInstance.</summary>
		/// 
		/// <param name="propertyInstance">The PropertyInstance to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeletePropertyInstance(PropertyInstance propertyInstance)
		{
			bool isItemMatch = false;
			foreach (PropertyInstanceViewModel item in PropertyInstances.ToList<PropertyInstanceViewModel>())
			{
				if (item.PropertyInstance.PropertyInstanceID == propertyInstance.PropertyInstanceID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.PropertyInstance.PropertyInstanceID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete PropertyInstance
					isItemMatch = true;
					PropertyInstances.Remove(item);
					ObjectInstance.PropertyInstanceList.Remove(item.PropertyInstance);
					Solution.PropertyInstanceList.Remove(item.PropertyInstance);
					Items.Remove(item);
					ObjectInstance.ResetModified(true);
					OnUpdated(this, null);
					break;
				}
			}
			foreach (PropertyInstanceCollectionViewModel collection in Collections)
			{
				foreach (PropertyInstanceViewModel item in collection.PropertyInstances)
				{
					if (item.PropertyInstance.PropertyInstanceID == propertyInstance.PropertyInstanceID)
					{
						// remove item from tabs, if present
						WorkspaceEventArgs message = new WorkspaceEventArgs();
						message.ItemID = item.PropertyInstance.PropertyInstanceID;
						Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

						// delete PropertyInstance
						isItemMatch = true;
						collection.PropertyInstances.Remove(item);
						ObjectInstance.PropertyInstanceList.Remove(item.PropertyInstance);
						Solution.PropertyInstanceList.Remove(item.PropertyInstance);
						collection.Items.Remove(item);
						ObjectInstance.ResetModified(true);
						OnUpdated(this, null);
						break;
					}
				}
			}
			if (isItemMatch == false)
			{
				ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (ObjectInstance.ReverseInstance == null && ObjectInstance.IsAutoUpdated == true)
			{
				ObjectInstance.ReverseInstance = new ObjectInstance();
				ObjectInstance.ReverseInstance.TransformDataFromObject(ObjectInstance, null, false);

				// perform the update of EditObjectInstance back to ObjectInstance
				ObjectInstance.TransformDataFromObject(EditObjectInstance, null, false);
				ObjectInstance.IsAutoUpdated = false;
			}
			else if (ObjectInstance.ReverseInstance != null)
			{
				EditObjectInstance.ResetModified(ObjectInstance.ReverseInstance.IsModified);
				if (EditObjectInstance.Equals(ObjectInstance.ReverseInstance))
				{
					// perform the update of EditObjectInstance back to ObjectInstance
					ObjectInstance.TransformDataFromObject(EditObjectInstance, null, false);
					ObjectInstance.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditObjectInstance back to ObjectInstance
					ObjectInstance.TransformDataFromObject(EditObjectInstance, null, false);
					ObjectInstance.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditObjectInstance back to ObjectInstance
				ObjectInstance.TransformDataFromObject(EditObjectInstance, null, false);
				ObjectInstance.IsAutoUpdated = false;
			}
			ObjectInstance.ForwardInstance = null;
			if (ParentObjectInstanceIDCustomized || DescriptionCustomized || PropertyInstanceListCustomized || TagsCustomized)
			{
				ObjectInstance.ForwardInstance = new ObjectInstance();
				ObjectInstance.ForwardInstance.ObjectInstanceID = EditObjectInstance.ObjectInstanceID;
				ObjectInstance.SpecSourceName = ObjectInstance.DefaultSourceName;
				if (ParentObjectInstanceIDCustomized)
				{
					ObjectInstance.ForwardInstance.ParentObjectInstanceID = EditObjectInstance.ParentObjectInstanceID;
				}
				if (DescriptionCustomized)
				{
					ObjectInstance.ForwardInstance.Description = EditObjectInstance.Description;
				}
				if (PropertyInstanceListCustomized)
				{
					// ObjectInstance.PropertyInstanceList = new EnterpriseDataObjectList<PropertyInstance>(EditObjectInstance.PropertyInstanceList, null);
					// ObjectInstance.ForwardInstance.PropertyInstanceList = new EnterpriseDataObjectList<PropertyInstance>(EditObjectInstance.PropertyInstanceList, null);
				}
				if (TagsCustomized)
				{
					ObjectInstance.ForwardInstance.Tags = EditObjectInstance.Tags;
				}
			}
			EditObjectInstance.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditObjectInstancePerformed();

			// send update for any updated PropertyInstances
			foreach (PropertyInstanceViewModel item in PropertyInstances)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new PropertyInstances
			foreach (PropertyInstanceViewModel item in ItemsToAdd.OfType<PropertyInstanceViewModel>())
			{
				item.Update();
				PropertyInstances.Add(item);
			}

			// send delete for any deleted PropertyInstances
			foreach (PropertyInstanceViewModel item in ItemsToDelete.OfType<PropertyInstanceViewModel>())
			{
				item.Delete();
				PropertyInstances.Remove(item);
			}

			// reset modified for PropertyInstances
			foreach (PropertyInstanceViewModel item in PropertyInstances)
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
		public void SendEditObjectInstancePerformed()
		{
			ObjectInstanceEventArgs message = new ObjectInstanceEventArgs();
			message.ObjectInstance = ObjectInstance;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ObjectInstanceEventArgs>(MediatorMessages.Command_EditObjectInstancePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete ObjectInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteObjectInstanceCommand()
		{
			ObjectInstanceEventArgs message = new ObjectInstanceEventArgs();
			message.ObjectInstance = ObjectInstance;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ObjectInstanceEventArgs>(MediatorMessages.Command_DeleteObjectInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteObjectInstanceCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyInstance lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyInstanceViewModel> PropertyInstances { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstance ObjectInstance { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ObjectInstanceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ObjectInstanceID
		{
			get
			{
				return ObjectInstance.ObjectInstanceID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return ObjectInstance.Name;
			}
			set
			{
				ObjectInstance.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelObjectID
		{
			get
			{
				return ObjectInstance.ModelObjectID;
			}
			set
			{
				ObjectInstance.ModelObjectID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of ObjectInstance into the view model.</summary>
		/// 
		/// <param name="objectInstance">The ObjectInstance to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadObjectInstance(ObjectInstance objectInstance, bool loadChildren = true)
		{
			// attach the ObjectInstance
			ObjectInstance = objectInstance;
			ItemID = ObjectInstance.ObjectInstanceID;
			Items.Clear();
			
			// initialize PropertyInstances
			if (PropertyInstances == null)
			{
				PropertyInstances = new EnterpriseDataObjectList<PropertyInstanceViewModel>();
			}
			if (loadChildren == true)
			{
				// attach PropertyInstances
				foreach (PropertyInstance item in objectInstance.PropertyInstanceList)
				{
					#region protected
					if (item.ModelProperty == null || item.ModelProperty.IsCollection == true)
					{
						continue;
					}
					#endregion protected
					PropertyInstanceViewModel itemView = new PropertyInstanceViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					PropertyInstances.Add(itemView);
					Items.Add(itemView);
				}
				#region protected
				// attach Collections
				if (Collections == null && ObjectInstance.ModelObject != null)
				{
					Collections = new EnterpriseDataObjectList<PropertyInstanceCollectionViewModel>();
					foreach (ModelProperty property in ObjectInstance.ModelObject.ModelPropertyList)
					{
						if (property.IsCollection == true)
						{
							PropertyInstanceCollectionViewModel propertyInstanceCollectionViewModel = new PropertyInstanceCollectionViewModel(ObjectInstance.ModelObject.Model, ObjectInstance.ModelObject, property, ObjectInstance, Solution, loadChildren);
							propertyInstanceCollectionViewModel.Updated += new EventHandler(Children_Updated);
							Collections.Add(propertyInstanceCollectionViewModel);
							Items.Add(propertyInstanceCollectionViewModel);
						}
					}
				}

				// attach ModelObjectDataItems
				if (ModelObjectDataItems == null)
				{
					ModelObjectDataItems = new EnterpriseDataObjectList<ModelObjectDataViewModel>();
					foreach (ModelObject loopObject in Solution.ModelObjectList)
					{
						if (loopObject.ParentModelObjectID == ModelObjectID)
						{
							ModelObjectDataViewModel modelObjectDataViewModel = new ModelObjectDataViewModel(loopObject.Model, loopObject, ObjectInstance, Solution, loadChildren);
							modelObjectDataViewModel.Updated += new EventHandler(Children_Updated);
							ModelObjectDataItems.Add(modelObjectDataViewModel);
							Items.Add(modelObjectDataViewModel);
						}
					}
				}
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
				foreach (PropertyInstanceViewModel item in PropertyInstances)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			if (refreshChildren == true || refreshLevel > 0)
			{
				foreach (ModelObjectDataViewModel item in ModelObjectDataItems)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			foreach (ModelObjectDataViewModel item in ModelObjectDataItems)
			{
				if (item.HasCustomizations == true)
				{
					HasCustomizations = true;
				}
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			#endregion protected
			
			HasErrors = !ObjectInstance.IsValid;
			HasCustomizations = ObjectInstance.IsAutoUpdated == false || ObjectInstance.IsEmptyMetadata(ObjectInstance.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && ObjectInstance.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				ObjectInstance.IsAutoUpdated = true;
				ObjectInstance.SpecSourceName = ObjectInstance.ReverseInstance.SpecSourceName;
				ObjectInstance.ResetModified(ObjectInstance.ReverseInstance.IsModified);
				ObjectInstance.ResetLoaded(ObjectInstance.ReverseInstance.IsLoaded);
				if (!ObjectInstance.IsIdenticalMetadata(ObjectInstance.ReverseInstance))
				{
					HasCustomizations = true;
					ObjectInstance.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				ObjectInstance.ForwardInstance = null;
				ObjectInstance.ReverseInstance = null;
				ObjectInstance.IsAutoUpdated = true;
			}
			foreach (PropertyInstanceViewModel item in PropertyInstances)
			{
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
            if (Collections != null)
            {
                foreach (PropertyInstanceCollectionViewModel item in Collections)
                {
                    if (item.HasErrors == true)
                    {
                        HasErrors = true;
                    }
                }
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
			if (PropertyInstances != null)
			{
				for (int i = PropertyInstances.Count - 1; i >= 0; i--)
				{
					PropertyInstances[i].Updated -= Children_Updated;
					PropertyInstances[i].Dispose();
					PropertyInstances.Remove(PropertyInstances[i]);
				}
				PropertyInstances = null;
			}
			if (_editObjectInstance != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditObjectInstance.PropertyChanged -= EditObjectInstance_PropertyChanged;
				EditObjectInstance = null;
			}
			ObjectInstance = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (PropertyInstanceViewModel item in PropertyInstances)
			{
				if (item.HasCustomizations == true)
				{
					return true;
				}
			}
            if (Collections != null)
            {
                foreach (PropertyInstanceCollectionViewModel item in Collections)
                {
                    if (item.HasCustomizations == true)
                    {
                        return true;
                    }
                }
            }
            if (ModelObjectDataItems != null)
            {
                foreach (ModelObjectDataViewModel item in ModelObjectDataItems)
                {
                    if (item.HasCustomizations == true)
                    {
                        return true;
                    }
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
			OnPropertyChanged("PropertyInstanceList");
			OnPropertyChanged("PropertyInstanceListCustomized");
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
			if (data is PropertyInstanceEventArgs && (data as PropertyInstanceEventArgs).ObjectInstanceID == ObjectInstance.ObjectInstanceID)
			{
				return this;
			}
			foreach (PropertyInstanceViewModel model in PropertyInstances)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			foreach (ModelObjectDataViewModel model in ModelObjectDataItems)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			foreach (PropertyInstanceCollectionViewModel model in Collections)
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
		public PropertyInstanceViewModel PastePropertyInstance(PropertyInstanceViewModel copyItem, bool savePaste = true)
		{
			PropertyInstance newItem = new PropertyInstance();
			newItem.ReverseInstance = new PropertyInstance();
			newItem.TransformDataFromObject(copyItem.PropertyInstance, null, false);
			newItem.PropertyInstanceID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find ModelProperty by existing id first, second by old id, finally by name
			newItem.ModelProperty = ObjectInstance.ModelObject.ModelPropertyList.FindByID((Guid)copyItem.PropertyInstance.ModelPropertyID);
			if (newItem.ModelProperty == null && Solution.PasteNewGuids[copyItem.PropertyInstance.ModelPropertyID.ToString()] is Guid)
			{
				newItem.ModelProperty = ObjectInstance.ModelObject.ModelPropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.PropertyInstance.ModelPropertyID.ToString()]);
			}
			if (newItem.ModelProperty == null)
			{
				newItem.ModelProperty = ObjectInstance.ModelObject.ModelPropertyList.Find("Name", copyItem.PropertyInstance.Name);
			}
			if (newItem.ModelProperty == null)
			{
				newItem.OldModelPropertyID = newItem.ModelPropertyID;
				newItem.ModelPropertyID = Guid.Empty;
			}
			newItem.ObjectInstance = ObjectInstance;
			newItem.Solution = Solution;
			PropertyInstanceViewModel newView = new PropertyInstanceViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddPropertyInstance(newView);
			if (savePaste == true)
			{
				Solution.PropertyInstanceList.Add(newItem);
				ObjectInstance.PropertyInstanceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of PropertyInstance to the view model.</summary>
		/// 
		/// <param name="itemView">The PropertyInstance to add.</param>
		///--------------------------------------------------------------------------------
		public void AddPropertyInstance(PropertyInstanceViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			PropertyInstances.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of PropertyInstance from the view model.</summary>
		/// 
		/// <param name="itemView">The PropertyInstance to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeletePropertyInstance(PropertyInstanceViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			PropertyInstances.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstanceViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="objectInstance">The ObjectInstance to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ObjectInstanceViewModel(ObjectInstance objectInstance, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadObjectInstance(objectInstance, loadChildren);
		}

		#endregion "Constructors"
	}
}
