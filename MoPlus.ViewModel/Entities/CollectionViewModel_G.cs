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
	/// <summary>This class provides views for Collection instances.</summary>
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
	public partial class CollectionViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCollection.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCollection
		{
			get
			{
				return DisplayValues.ContextMenu_NewCollection;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlCollectionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCollectionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewCollectionToolTip;
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
				if (EditCollection.IsModified == true)
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
				return string.IsNullOrEmpty(CollectionNameValidationMessage + ReferencedEntityIDValidationMessage + IsNullableValidationMessage + OrderValidationMessage + DescriptionValidationMessage + PropertyRelationshipListValidationMessage);
			}
		}
 
		private Collection _editCollection = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditCollection.</summary>
		///--------------------------------------------------------------------------------
		public Collection EditCollection
		{
			get
			{
				if (_editCollection == null)
				{
					_editCollection = new Collection();
					_editCollection.PropertyChanged += new PropertyChangedEventHandler(EditCollection_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Collection != null)
					{
						_editCollection.TransformDataFromObject(Collection, null, false);
						_editCollection.Solution = Collection.Solution;
						_editCollection.Entity = Collection.Entity;
						_editCollection.ReferencedEntity = Collection.ReferencedEntity;
					}
					_editCollection.ResetModified(false);
				}
				return _editCollection;
			}
			set
			{
				_editCollection = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditCollection_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditCollection");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("CollectionName");
			OnPropertyChanged("CollectionNameCustomized");
			OnPropertyChanged("CollectionNameValidationMessage");
			
			OnPropertyChanged("ReferencedEntityID");
			OnPropertyChanged("ReferencedEntityIDCustomized");
			OnPropertyChanged("ReferencedEntityIDValidationMessage");
			
			OnPropertyChanged("IsNullable");
			OnPropertyChanged("IsNullableCustomized");
			OnPropertyChanged("IsNullableValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("PropertyRelationshipList");
			OnPropertyChanged("PropertyRelationshipListCustomized");
			OnPropertyChanged("PropertyRelationshipListValidationMessage");

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
				return DisplayValues.Edit_CollectionHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_CollectionHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyRelationshipListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyRelationshipListLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyRelationshipListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertyRelationshipList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyRelationship> PropertyRelationshipList
		{
			get
			{
				return EditCollection.PropertyRelationshipList;
			}
			set
			{
				EditCollection.PropertyRelationshipList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyRelationshipListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PropertyRelationshipListCustomized
		{
			get
			{
				#region protected
				foreach (PropertyRelationshipViewModel item in Items.OfType<PropertyRelationshipViewModel>())
				{
					if (item.HasCustomizations == true || item.PropertyRelationship.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyRelationshipListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyRelationshipListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the CollectionNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CollectionNameLabel
		{
			get
			{
				return DisplayValues.Edit_CollectionNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CollectionName.</summary>
		///--------------------------------------------------------------------------------
		public string CollectionName
		{
			get
			{
				return EditCollection.CollectionName;
			}
			set
			{
				EditCollection.CollectionName = value;
				OnPropertyChanged("CollectionName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets CollectionNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool CollectionNameCustomized
		{
			get
			{
				if (Collection.ReverseInstance != null)
				{
					return CollectionName.GetString() != Collection.ReverseInstance.CollectionName.GetString();
				}
				else if (Collection.IsAutoUpdated == true)
				{
					return CollectionName.GetString() != Collection.CollectionName.GetString();
				}
				return CollectionName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CollectionNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string CollectionNameValidationMessage
		{
			get
			{
				return EditCollection.ValidateCollectionName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ReferencedEntityIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedEntityIDLabel
		{
			get
			{
				return DisplayValues.Edit_ReferencedEntityIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ReferencedEntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ReferencedEntityID
		{
			get
			{
				return EditCollection.ReferencedEntityID;
			}
			set
			{
				EditCollection.ReferencedEntityID = value;
				OnPropertyChanged("ReferencedEntityID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedEntityIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ReferencedEntityIDCustomized
		{
			get
			{
				if (Collection.ReverseInstance != null)
				{
					return ReferencedEntityID.GetGuid() != Collection.ReverseInstance.ReferencedEntityID.GetGuid();
				}
				else if (Collection.IsAutoUpdated == true)
				{
					return ReferencedEntityID.GetGuid() != Collection.ReferencedEntityID.GetGuid();
				}
				return ReferencedEntityID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedEntityIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedEntityIDValidationMessage
		{
			get
			{
				return EditCollection.ValidateReferencedEntityID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsNullableLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsNullableLabel
		{
			get
			{
				return DisplayValues.Edit_IsNullableProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsNullable.</summary>
		///--------------------------------------------------------------------------------
		public bool IsNullable
		{
			get
			{
				return EditCollection.IsNullable;
			}
			set
			{
				EditCollection.IsNullable = value;
				OnPropertyChanged("IsNullable");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsNullableCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsNullableCustomized
		{
			get
			{
				if (Collection.ReverseInstance != null)
				{
					return IsNullable.GetBool() != Collection.ReverseInstance.IsNullable.GetBool();
				}
				else if (Collection.IsAutoUpdated == true)
				{
					return IsNullable.GetBool() != Collection.IsNullable.GetBool();
				}
				return IsNullable != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsNullableValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsNullableValidationMessage
		{
			get
			{
				return EditCollection.ValidateIsNullable();
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
				return EditCollection.Order;
			}
			set
			{
				EditCollection.Order = value;
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
				if (Collection.ReverseInstance != null)
				{
					return Order.GetInt() != Collection.ReverseInstance.Order.GetInt();
				}
				else if (Collection.IsAutoUpdated == true)
				{
					return Order.GetInt() != Collection.Order.GetInt();
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
				return EditCollection.ValidateOrder();
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
				return EditCollection.Description;
			}
			set
			{
				EditCollection.Description = value;
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
				if (Collection.ReverseInstance != null)
				{
					return Description.GetString() != Collection.ReverseInstance.Description.GetString();
				}
				else if (Collection.IsAutoUpdated == true)
				{
					return Description.GetString() != Collection.Description.GetString();
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
				return EditCollection.ValidateDescription();
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
				return EditCollection.SourceName;
			}
			set
			{
				EditCollection.SourceName = value;
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
				return EditCollection.SpecSourceName;
			}
			set
			{
				EditCollection.SpecSourceName = value;
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
				return EditCollection.Tags;
			}
			set
			{
				EditCollection.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Collection.ReverseInstance != null)
				{
					return Tags != Collection.ReverseInstance.Tags;
				}
				else if (Collection.IsAutoUpdated == true)
				{
					return Tags != Collection.Tags;
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
				return EditCollection.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditCollection.Name;
			}
			set
			{
				EditCollection.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditCollection.TransformDataFromObject(Collection, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditCollection.ResetModified(false);
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
			if (Collection.ReverseInstance != null)
			{
				EditCollection.TransformDataFromObject(Collection.ReverseInstance, null, false);
			}
			else if (Collection.IsAutoUpdated == true)
			{
				EditCollection.TransformDataFromObject(Collection, null, false);
			}
			else
			{
				Collection newCollection = new Collection();
				newCollection.PropertyID = EditCollection.PropertyID;
				EditCollection.TransformDataFromObject(newCollection, null, false);
			}
			EditCollection.ResetModified(true);
			foreach (PropertyRelationshipViewModel item in Items.OfType<PropertyRelationshipViewModel>())
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
		/// <summary>This method processes the new Collection command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewCollectionCommand()
		{
			CollectionEventArgs message = new CollectionEventArgs();
			message.Collection = new Collection();
			message.Collection.PropertyID = Guid.NewGuid();
			message.Collection.EntityID = EntityID;
			message.Collection.Entity = Solution.EntityList.FindByID((Guid)EntityID);
			if (message.Collection.Entity != null)
			{
				message.Collection.Order = message.Collection.Entity.CollectionList.Count + 1;
			}
			message.Collection.Solution = Solution;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<CollectionEventArgs>(MediatorMessages.Command_EditCollectionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditCollectionCommand()
		{
			CollectionEventArgs message = new CollectionEventArgs();
			message.Collection = Collection;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<CollectionEventArgs>(MediatorMessages.Command_EditCollectionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyRelationship adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewPropertyRelationship()
		{
			PropertyRelationshipViewModel item = new PropertyRelationshipViewModel();
			item.PropertyRelationship = new PropertyRelationship();
			item.PropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
			item.PropertyRelationship.PropertyBase = EditCollection;
			item.PropertyRelationship.PropertyID = EditCollection.PropertyID;
			item.PropertyRelationship.Solution = Solution;
			item.PropertyRelationship.Order = Collection.PropertyRelationshipList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new PropertyRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyRelationshipCommand()
		{
			PropertyRelationshipEventArgs message = new PropertyRelationshipEventArgs();
			message.PropertyRelationship = new PropertyRelationship();
			message.PropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
			message.PropertyRelationship.PropertyBase = Collection;
			message.PropertyRelationship.PropertyID = Collection.PropertyID;
			message.PropertyID = Collection.PropertyID;
			if (message.PropertyRelationship.PropertyBase != null)
			{
				message.PropertyRelationship.Order = message.PropertyRelationship.PropertyBase.PropertyRelationshipList.Count + 1;
			}
			message.PropertyRelationship.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyRelationshipEventArgs>(MediatorMessages.Command_EditPropertyRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyRelationship updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyRelationshipPerformed(PropertyRelationshipEventArgs data)
		{
			if (data != null && data.PropertyRelationship != null)
			{
				UpdateEditPropertyRelationship(data.PropertyRelationship);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of PropertyRelationship.</summary>
		/// 
		/// <param name="propertyRelationship">The PropertyRelationship to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditPropertyRelationship(PropertyRelationship propertyRelationship)
		{
			bool isItemMatch = false;
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
			{
				if (item.PropertyRelationship.PropertyRelationshipID == propertyRelationship.PropertyRelationshipID)
				{
					isItemMatch = true;
					item.PropertyRelationship.TransformDataFromObject(propertyRelationship, null, false);
					if (!item.PropertyRelationship.RelationshipID.IsNullOrEmpty())
					{
						item.PropertyRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)item.PropertyRelationship.RelationshipID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new PropertyRelationship
				propertyRelationship.PropertyBase = Collection;
				PropertyRelationshipViewModel newItem = new PropertyRelationshipViewModel(propertyRelationship, Solution);
				if (!newItem.PropertyRelationship.RelationshipID.IsNullOrEmpty())
				{
					newItem.PropertyRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)newItem.PropertyRelationship.RelationshipID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				PropertyRelationships.Add(newItem);
				Collection.PropertyRelationshipList.Add(propertyRelationship);
				Solution.PropertyRelationshipList.Add(newItem.PropertyRelationship);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyRelationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedPropertyRelationships(PropertyRelationshipViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyRelationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyRelationshipPerformed(PropertyRelationshipEventArgs data)
		{
			if (data != null && data.PropertyRelationship != null)
			{
				DeletePropertyRelationship(data.PropertyRelationship);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of PropertyRelationship.</summary>
		/// 
		/// <param name="propertyRelationship">The PropertyRelationship to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeletePropertyRelationship(PropertyRelationship propertyRelationship)
		{
			bool isItemMatch = false;
			foreach (PropertyRelationshipViewModel item in PropertyRelationships.ToList<PropertyRelationshipViewModel>())
			{
				if (item.PropertyRelationship.PropertyRelationshipID == propertyRelationship.PropertyRelationshipID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.PropertyRelationship.PropertyRelationshipID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete PropertyRelationship
					isItemMatch = true;
					PropertyRelationships.Remove(item);
					Collection.PropertyRelationshipList.Remove(item.PropertyRelationship);
					Solution.PropertyRelationshipList.Remove(item.PropertyRelationship);
					Items.Remove(item);
					Collection.ResetModified(true);
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
			ProcessNewCollectionCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Collection.ReverseInstance == null && Collection.IsAutoUpdated == true)
			{
				Collection.ReverseInstance = new Collection();
				Collection.ReverseInstance.TransformDataFromObject(Collection, null, false);

				// perform the update of EditCollection back to Collection
				Collection.TransformDataFromObject(EditCollection, null, false);
				Collection.IsAutoUpdated = false;
			}
			else if (Collection.ReverseInstance != null)
			{
				EditCollection.ResetModified(Collection.ReverseInstance.IsModified);
				if (EditCollection.Equals(Collection.ReverseInstance))
				{
					// perform the update of EditCollection back to Collection
					Collection.TransformDataFromObject(EditCollection, null, false);
					Collection.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditCollection back to Collection
					Collection.TransformDataFromObject(EditCollection, null, false);
					Collection.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditCollection back to Collection
				Collection.TransformDataFromObject(EditCollection, null, false);
				Collection.IsAutoUpdated = false;
			}
			Collection.ForwardInstance = null;
			if (CollectionNameCustomized || ReferencedEntityIDCustomized || IsNullableCustomized || OrderCustomized || DescriptionCustomized || PropertyRelationshipListCustomized || TagsCustomized)
			{
				Collection.ForwardInstance = new Collection();
				Collection.ForwardInstance.PropertyID = EditCollection.PropertyID;
				Collection.SpecSourceName = Collection.DefaultSourceName;
				if (CollectionNameCustomized)
				{
					Collection.ForwardInstance.CollectionName = EditCollection.CollectionName;
				}
				if (ReferencedEntityIDCustomized)
				{
					Collection.ForwardInstance.ReferencedEntityID = EditCollection.ReferencedEntityID;
				}
				if (IsNullableCustomized)
				{
					Collection.ForwardInstance.IsNullable = EditCollection.IsNullable;
				}
				if (OrderCustomized)
				{
					Collection.ForwardInstance.Order = EditCollection.Order;
				}
				if (DescriptionCustomized)
				{
					Collection.ForwardInstance.Description = EditCollection.Description;
				}
				if (PropertyRelationshipListCustomized)
				{
					#region protected
					#endregion protected
					// Collection.PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>(EditCollection.PropertyRelationshipList, null);
					// Collection.ForwardInstance.PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>(EditCollection.PropertyRelationshipList, null);
				}
				if (TagsCustomized)
				{
					Collection.ForwardInstance.Tags = EditCollection.Tags;
				}
			}
			EditCollection.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditCollectionPerformed();

			// send update for any updated PropertyRelationships
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new PropertyRelationships
			foreach (PropertyRelationshipViewModel item in ItemsToAdd.OfType<PropertyRelationshipViewModel>())
			{
				item.Update();
				PropertyRelationships.Add(item);
			}

			// send delete for any deleted PropertyRelationships
			foreach (PropertyRelationshipViewModel item in ItemsToDelete.OfType<PropertyRelationshipViewModel>())
			{
				item.Delete();
				PropertyRelationships.Remove(item);
			}

			// reset modified for PropertyRelationships
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
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
		public void SendEditCollectionPerformed()
		{
			CollectionEventArgs message = new CollectionEventArgs();
			message.Collection = Collection;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<CollectionEventArgs>(MediatorMessages.Command_EditCollectionPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Collection command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteCollectionCommand()
		{
			CollectionEventArgs message = new CollectionEventArgs();
			message.Collection = Collection;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<CollectionEventArgs>(MediatorMessages.Command_DeleteCollectionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteCollectionCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyRelationshipViewModel> PropertyRelationships { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Collection.</summary>
		///--------------------------------------------------------------------------------
		public Collection Collection { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyID
		{
			get
			{
				return Collection.PropertyID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Collection.Name;
			}
			set
			{
				Collection.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return Collection.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return Collection.EntityID;
			}
			set
			{
				Collection.EntityID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Collection into the view model.</summary>
		/// 
		/// <param name="collection">The Collection to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadCollection(Collection collection, bool loadChildren = true)
		{
			// attach the Collection
			Collection = collection;
			ItemID = Collection.PropertyID;
			Items.Clear();
			
			// initialize PropertyRelationships
			if (PropertyRelationships == null)
			{
				PropertyRelationships = new EnterpriseDataObjectList<PropertyRelationshipViewModel>();
			}
			if (loadChildren == true)
			{
				// attach PropertyRelationships
				foreach (PropertyRelationship item in collection.PropertyRelationshipList)
				{
					PropertyRelationshipViewModel itemView = new PropertyRelationshipViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					PropertyRelationships.Add(itemView);
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
				foreach (PropertyRelationshipViewModel item in PropertyRelationships)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Collection.IsValid;
			HasCustomizations = Collection.IsAutoUpdated == false || Collection.IsEmptyMetadata(Collection.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Collection.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Collection.IsAutoUpdated = true;
				Collection.SpecSourceName = Collection.ReverseInstance.SpecSourceName;
				Collection.ResetModified(Collection.ReverseInstance.IsModified);
				Collection.ResetLoaded(Collection.ReverseInstance.IsLoaded);
				if (!Collection.IsIdenticalMetadata(Collection.ReverseInstance))
				{
					HasCustomizations = true;
					Collection.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Collection.ForwardInstance = null;
				Collection.ReverseInstance = null;
				Collection.IsAutoUpdated = true;
			}
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
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
			if (PropertyRelationships != null)
			{
				for (int i = PropertyRelationships.Count - 1; i >= 0; i--)
				{
					PropertyRelationships[i].Updated -= Children_Updated;
					PropertyRelationships[i].Dispose();
					PropertyRelationships.Remove(PropertyRelationships[i]);
				}
				PropertyRelationships = null;
			}
			if (_editCollection != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditCollection.PropertyChanged -= EditCollection_PropertyChanged;
				EditCollection = null;
			}
			Collection = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
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
			OnPropertyChanged("PropertyRelationshipList");
			OnPropertyChanged("PropertyRelationshipListCustomized");
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
			if (data is PropertyRelationshipEventArgs && (data as PropertyRelationshipEventArgs).PropertyID == Collection.PropertyID)
			{
				return this;
			}
			foreach (PropertyRelationshipViewModel model in PropertyRelationships)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public CollectionViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="collection">The Collection to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public CollectionViewModel(Collection collection, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadCollection(collection, loadChildren);
		}

		#endregion "Constructors"
	}
}
