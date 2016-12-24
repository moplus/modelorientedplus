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
	/// <summary>This class provides views for Relationship instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/19/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class RelationshipViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewRelationship.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationship
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationship;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlRelationshipToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRelationshipToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewRelationshipProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationshipProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewRelationshipPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationshipPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipPropertyToolTip;
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
				if (EditRelationship.IsModified == true)
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
				return string.IsNullOrEmpty(RelationshipNameValidationMessage + ReferencedEntityIDValidationMessage + IsNullableValidationMessage + ItemsMinValidationMessage + ItemsMaxValidationMessage + ReferencedItemsMinValidationMessage + ReferencedItemsMaxValidationMessage + DescriptionValidationMessage + RelationshipPropertyListValidationMessage);
			}
		}
 
		private Relationship _editRelationship = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditRelationship.</summary>
		///--------------------------------------------------------------------------------
		public Relationship EditRelationship
		{
			get
			{
				if (_editRelationship == null)
				{
					_editRelationship = new Relationship();
					_editRelationship.PropertyChanged += new PropertyChangedEventHandler(EditRelationship_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Relationship != null)
					{
						_editRelationship.TransformDataFromObject(Relationship, null, false);
						_editRelationship.Solution = Relationship.Solution;
						_editRelationship.ReferencedEntity = Relationship.ReferencedEntity;
						_editRelationship.Entity = Relationship.Entity;
					}
					_editRelationship.ResetModified(false);
				}
				return _editRelationship;
			}
			set
			{
				_editRelationship = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditRelationship_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditRelationship");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("RelationshipName");
			OnPropertyChanged("RelationshipNameCustomized");
			OnPropertyChanged("RelationshipNameValidationMessage");
			
			OnPropertyChanged("ReferencedEntityID");
			OnPropertyChanged("ReferencedEntityIDCustomized");
			OnPropertyChanged("ReferencedEntityIDValidationMessage");
			
			OnPropertyChanged("IsNullable");
			OnPropertyChanged("IsNullableCustomized");
			OnPropertyChanged("IsNullableValidationMessage");
			
			OnPropertyChanged("ItemsMin");
			OnPropertyChanged("ItemsMinCustomized");
			OnPropertyChanged("ItemsMinValidationMessage");
			
			OnPropertyChanged("ItemsMax");
			OnPropertyChanged("ItemsMaxCustomized");
			OnPropertyChanged("ItemsMaxValidationMessage");
			
			OnPropertyChanged("ReferencedItemsMin");
			OnPropertyChanged("ReferencedItemsMinCustomized");
			OnPropertyChanged("ReferencedItemsMinValidationMessage");
			
			OnPropertyChanged("ReferencedItemsMax");
			OnPropertyChanged("ReferencedItemsMaxCustomized");
			OnPropertyChanged("ReferencedItemsMaxValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("RelationshipPropertyList");
			OnPropertyChanged("RelationshipPropertyListCustomized");
			OnPropertyChanged("RelationshipPropertyListValidationMessage");

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
				return DisplayValues.Edit_RelationshipHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_RelationshipHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the RelationshipIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipIDLabel
		{
			get
			{
				return DisplayValues.Edit_RelationshipIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the RelationshipPropertyListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipPropertyListLabel
		{
			get
			{
				return DisplayValues.Edit_RelationshipPropertyListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets RelationshipPropertyList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<RelationshipProperty> RelationshipPropertyList
		{
			get
			{
				return EditRelationship.RelationshipPropertyList;
			}
			set
			{
				EditRelationship.RelationshipPropertyList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipPropertyListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool RelationshipPropertyListCustomized
		{
			get
			{
				#region protected
				foreach (RelationshipPropertyViewModel item in Items.OfType<RelationshipPropertyViewModel>())
				{
					if (item.HasCustomizations == true || item.RelationshipProperty.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipPropertyListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipPropertyListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the RelationshipNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipNameLabel
		{
			get
			{
				return DisplayValues.Edit_RelationshipNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets RelationshipName.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipName
		{
			get
			{
				return EditRelationship.RelationshipName;
			}
			set
			{
				EditRelationship.RelationshipName = value;
				OnPropertyChanged("RelationshipName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool RelationshipNameCustomized
		{
			get
			{
				if (Relationship.ReverseInstance != null)
				{
					return RelationshipName.GetString() != Relationship.ReverseInstance.RelationshipName.GetString();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return RelationshipName.GetString() != Relationship.RelationshipName.GetString();
				}
				return RelationshipName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipNameValidationMessage
		{
			get
			{
				return EditRelationship.ValidateRelationshipName();
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
				return EditRelationship.ReferencedEntityID;
			}
			set
			{
				EditRelationship.ReferencedEntityID = value;
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
				if (Relationship.ReverseInstance != null)
				{
					return ReferencedEntityID.GetGuid() != Relationship.ReverseInstance.ReferencedEntityID.GetGuid();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return ReferencedEntityID.GetGuid() != Relationship.ReferencedEntityID.GetGuid();
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
				return EditRelationship.ValidateReferencedEntityID();
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
				return EditRelationship.IsNullable;
			}
			set
			{
				EditRelationship.IsNullable = value;
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
				if (Relationship.ReverseInstance != null)
				{
					return IsNullable.GetBool() != Relationship.ReverseInstance.IsNullable.GetBool();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return IsNullable.GetBool() != Relationship.IsNullable.GetBool();
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
				return EditRelationship.ValidateIsNullable();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ItemsMinLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ItemsMinLabel
		{
			get
			{
				return DisplayValues.Edit_ItemsMinProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ItemsMin.</summary>
		///--------------------------------------------------------------------------------
		public int ItemsMin
		{
			get
			{
				return EditRelationship.ItemsMin;
			}
			set
			{
				EditRelationship.ItemsMin = value;
				OnPropertyChanged("ItemsMin");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemsMinCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ItemsMinCustomized
		{
			get
			{
				if (Relationship.ReverseInstance != null)
				{
					return ItemsMin.GetInt() != Relationship.ReverseInstance.ItemsMin.GetInt();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return ItemsMin.GetInt() != Relationship.ItemsMin.GetInt();
				}
				return ItemsMin != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemsMinValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ItemsMinValidationMessage
		{
			get
			{
				return EditRelationship.ValidateItemsMin();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ItemsMaxLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ItemsMaxLabel
		{
			get
			{
				return DisplayValues.Edit_ItemsMaxProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ItemsMax.</summary>
		///--------------------------------------------------------------------------------
		public int ItemsMax
		{
			get
			{
				return EditRelationship.ItemsMax;
			}
			set
			{
				EditRelationship.ItemsMax = value;
				OnPropertyChanged("ItemsMax");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemsMaxCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ItemsMaxCustomized
		{
			get
			{
				if (Relationship.ReverseInstance != null)
				{
					return ItemsMax.GetInt() != Relationship.ReverseInstance.ItemsMax.GetInt();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return ItemsMax.GetInt() != Relationship.ItemsMax.GetInt();
				}
				return ItemsMax != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemsMaxValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ItemsMaxValidationMessage
		{
			get
			{
				return EditRelationship.ValidateItemsMax();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ReferencedItemsMinLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedItemsMinLabel
		{
			get
			{
				return DisplayValues.Edit_ReferencedItemsMinProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ReferencedItemsMin.</summary>
		///--------------------------------------------------------------------------------
		public int ReferencedItemsMin
		{
			get
			{
				return EditRelationship.ReferencedItemsMin;
			}
			set
			{
				EditRelationship.ReferencedItemsMin = value;
				OnPropertyChanged("ReferencedItemsMin");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedItemsMinCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ReferencedItemsMinCustomized
		{
			get
			{
				if (Relationship.ReverseInstance != null)
				{
					return ReferencedItemsMin.GetInt() != Relationship.ReverseInstance.ReferencedItemsMin.GetInt();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return ReferencedItemsMin.GetInt() != Relationship.ReferencedItemsMin.GetInt();
				}
				return ReferencedItemsMin != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedItemsMinValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedItemsMinValidationMessage
		{
			get
			{
				return EditRelationship.ValidateReferencedItemsMin();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ReferencedItemsMaxLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedItemsMaxLabel
		{
			get
			{
				return DisplayValues.Edit_ReferencedItemsMaxProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ReferencedItemsMax.</summary>
		///--------------------------------------------------------------------------------
		public int ReferencedItemsMax
		{
			get
			{
				return EditRelationship.ReferencedItemsMax;
			}
			set
			{
				EditRelationship.ReferencedItemsMax = value;
				OnPropertyChanged("ReferencedItemsMax");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedItemsMaxCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ReferencedItemsMaxCustomized
		{
			get
			{
				if (Relationship.ReverseInstance != null)
				{
					return ReferencedItemsMax.GetInt() != Relationship.ReverseInstance.ReferencedItemsMax.GetInt();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return ReferencedItemsMax.GetInt() != Relationship.ReferencedItemsMax.GetInt();
				}
				return ReferencedItemsMax != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedItemsMaxValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedItemsMaxValidationMessage
		{
			get
			{
				return EditRelationship.ValidateReferencedItemsMax();
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
				return EditRelationship.Description;
			}
			set
			{
				EditRelationship.Description = value;
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
				if (Relationship.ReverseInstance != null)
				{
					return Description.GetString() != Relationship.ReverseInstance.Description.GetString();
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return Description.GetString() != Relationship.Description.GetString();
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
				return EditRelationship.ValidateDescription();
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
				return EditRelationship.SourceName;
			}
			set
			{
				EditRelationship.SourceName = value;
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
				return EditRelationship.SpecSourceName;
			}
			set
			{
				EditRelationship.SpecSourceName = value;
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
				return EditRelationship.Tags;
			}
			set
			{
				EditRelationship.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Relationship.ReverseInstance != null)
				{
					return Tags != Relationship.ReverseInstance.Tags;
				}
				else if (Relationship.IsAutoUpdated == true)
				{
					return Tags != Relationship.Tags;
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
				return EditRelationship.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditRelationship.Name;
			}
			set
			{
				EditRelationship.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditRelationship.TransformDataFromObject(Relationship, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditRelationship.ResetModified(false);
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
			if (Relationship.ReverseInstance != null)
			{
				EditRelationship.TransformDataFromObject(Relationship.ReverseInstance, null, false);
			}
			else if (Relationship.IsAutoUpdated == true)
			{
				EditRelationship.TransformDataFromObject(Relationship, null, false);
			}
			else
			{
				Relationship newRelationship = new Relationship();
				newRelationship.RelationshipID = EditRelationship.RelationshipID;
				EditRelationship.TransformDataFromObject(newRelationship, null, false);
			}
			EditRelationship.ResetModified(true);
			foreach (RelationshipPropertyViewModel item in Items.OfType<RelationshipPropertyViewModel>())
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
		/// <summary>This method processes the new Relationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewRelationshipCommand()
		{
			RelationshipEventArgs message = new RelationshipEventArgs();
			message.Relationship = new Relationship();
			message.Relationship.RelationshipID = Guid.NewGuid();
			message.Relationship.EntityID = EntityID;
			message.Relationship.Entity = Solution.EntityList.FindByID((Guid)EntityID);
			message.Relationship.Solution = Solution;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipEventArgs>(MediatorMessages.Command_EditRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditRelationshipCommand()
		{
			RelationshipEventArgs message = new RelationshipEventArgs();
			message.Relationship = Relationship;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipEventArgs>(MediatorMessages.Command_EditRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to RelationshipProperty adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewRelationshipProperty()
		{
			RelationshipPropertyViewModel item = new RelationshipPropertyViewModel();
			item.RelationshipProperty = new RelationshipProperty();
			item.RelationshipProperty.RelationshipPropertyID = Guid.NewGuid();
			item.RelationshipProperty.Relationship = EditRelationship;
			item.RelationshipProperty.RelationshipID = EditRelationship.RelationshipID;
			item.RelationshipProperty.Solution = Solution;
			item.RelationshipProperty.Order = Relationship.RelationshipPropertyList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new RelationshipProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewRelationshipPropertyCommand()
		{
			RelationshipPropertyEventArgs message = new RelationshipPropertyEventArgs();
			message.RelationshipProperty = new RelationshipProperty();
			message.RelationshipProperty.RelationshipPropertyID = Guid.NewGuid();
			message.RelationshipProperty.Relationship = Relationship;
			message.RelationshipProperty.RelationshipID = Relationship.RelationshipID;
			message.RelationshipID = Relationship.RelationshipID;
			if (message.RelationshipProperty.Relationship != null)
			{
				message.RelationshipProperty.Order = message.RelationshipProperty.Relationship.RelationshipPropertyList.Count + 1;
			}
			message.RelationshipProperty.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipPropertyEventArgs>(MediatorMessages.Command_EditRelationshipPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies RelationshipProperty updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditRelationshipPropertyPerformed(RelationshipPropertyEventArgs data)
		{
			if (data != null && data.RelationshipProperty != null)
			{
				UpdateEditRelationshipProperty(data.RelationshipProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of RelationshipProperty.</summary>
		/// 
		/// <param name="relationshipProperty">The RelationshipProperty to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditRelationshipProperty(RelationshipProperty relationshipProperty)
		{
			bool isItemMatch = false;
			foreach (RelationshipPropertyViewModel item in RelationshipProperties)
			{
				if (item.RelationshipProperty.RelationshipPropertyID == relationshipProperty.RelationshipPropertyID)
				{
					isItemMatch = true;
					item.RelationshipProperty.TransformDataFromObject(relationshipProperty, null, false);
					if (!item.RelationshipProperty.PropertyID.IsNullOrEmpty())
					{
						item.RelationshipProperty.Property = Solution.PropertyList.FindByID((Guid)item.RelationshipProperty.PropertyID);
					}
					if (!item.RelationshipProperty.ReferencedPropertyID.IsNullOrEmpty())
					{
						item.RelationshipProperty.ReferencedProperty = Solution.PropertyList.FindByID((Guid)item.RelationshipProperty.ReferencedPropertyID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new RelationshipProperty
				relationshipProperty.Relationship = Relationship;
				RelationshipPropertyViewModel newItem = new RelationshipPropertyViewModel(relationshipProperty, Solution);
				if (!newItem.RelationshipProperty.PropertyID.IsNullOrEmpty())
				{
					newItem.RelationshipProperty.Property = Solution.PropertyList.FindByID((Guid)newItem.RelationshipProperty.PropertyID);
				}
				if (!newItem.RelationshipProperty.ReferencedPropertyID.IsNullOrEmpty())
				{
					newItem.RelationshipProperty.ReferencedProperty = Solution.PropertyList.FindByID((Guid)newItem.RelationshipProperty.ReferencedPropertyID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				RelationshipProperties.Add(newItem);
				Relationship.RelationshipPropertyList.Add(relationshipProperty);
				Solution.RelationshipPropertyList.Add(newItem.RelationshipProperty);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to RelationshipProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedRelationshipProperties(RelationshipPropertyViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies RelationshipProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteRelationshipPropertyPerformed(RelationshipPropertyEventArgs data)
		{
			if (data != null && data.RelationshipProperty != null)
			{
				DeleteRelationshipProperty(data.RelationshipProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of RelationshipProperty.</summary>
		/// 
		/// <param name="relationshipProperty">The RelationshipProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteRelationshipProperty(RelationshipProperty relationshipProperty)
		{
			bool isItemMatch = false;
			foreach (RelationshipPropertyViewModel item in RelationshipProperties.ToList<RelationshipPropertyViewModel>())
			{
				if (item.RelationshipProperty.RelationshipPropertyID == relationshipProperty.RelationshipPropertyID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.RelationshipProperty.RelationshipPropertyID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete RelationshipProperty
					isItemMatch = true;
					RelationshipProperties.Remove(item);
					Relationship.RelationshipPropertyList.Remove(item.RelationshipProperty);
					Solution.RelationshipPropertyList.Remove(item.RelationshipProperty);
					Items.Remove(item);
					Relationship.ResetModified(true);
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
			ProcessNewRelationshipCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Relationship.ReverseInstance == null && Relationship.IsAutoUpdated == true)
			{
				Relationship.ReverseInstance = new Relationship();
				Relationship.ReverseInstance.TransformDataFromObject(Relationship, null, false);

				// perform the update of EditRelationship back to Relationship
				Relationship.TransformDataFromObject(EditRelationship, null, false);
				Relationship.IsAutoUpdated = false;
			}
			else if (Relationship.ReverseInstance != null)
			{
				EditRelationship.ResetModified(Relationship.ReverseInstance.IsModified);
				if (EditRelationship.Equals(Relationship.ReverseInstance))
				{
					// perform the update of EditRelationship back to Relationship
					Relationship.TransformDataFromObject(EditRelationship, null, false);
					Relationship.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditRelationship back to Relationship
					Relationship.TransformDataFromObject(EditRelationship, null, false);
					Relationship.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditRelationship back to Relationship
				Relationship.TransformDataFromObject(EditRelationship, null, false);
				Relationship.IsAutoUpdated = false;
			}
			Relationship.ForwardInstance = null;
			if (RelationshipNameCustomized || ReferencedEntityIDCustomized || IsNullableCustomized || ItemsMinCustomized || ItemsMaxCustomized || ReferencedItemsMinCustomized || ReferencedItemsMaxCustomized || DescriptionCustomized || RelationshipPropertyListCustomized || TagsCustomized)
			{
				Relationship.ForwardInstance = new Relationship();
				Relationship.ForwardInstance.RelationshipID = EditRelationship.RelationshipID;
				Relationship.SpecSourceName = Relationship.DefaultSourceName;
				if (RelationshipNameCustomized)
				{
					Relationship.ForwardInstance.RelationshipName = EditRelationship.RelationshipName;
				}
				if (ReferencedEntityIDCustomized)
				{
					Relationship.ForwardInstance.ReferencedEntityID = EditRelationship.ReferencedEntityID;
				}
				if (IsNullableCustomized)
				{
					Relationship.ForwardInstance.IsNullable = EditRelationship.IsNullable;
				}
				if (ItemsMinCustomized)
				{
					Relationship.ForwardInstance.ItemsMin = EditRelationship.ItemsMin;
				}
				if (ItemsMaxCustomized)
				{
					Relationship.ForwardInstance.ItemsMax = EditRelationship.ItemsMax;
				}
				if (ReferencedItemsMinCustomized)
				{
					Relationship.ForwardInstance.ReferencedItemsMin = EditRelationship.ReferencedItemsMin;
				}
				if (ReferencedItemsMaxCustomized)
				{
					Relationship.ForwardInstance.ReferencedItemsMax = EditRelationship.ReferencedItemsMax;
				}
				if (DescriptionCustomized)
				{
					Relationship.ForwardInstance.Description = EditRelationship.Description;
				}
				if (RelationshipPropertyListCustomized)
				{
					#region protected
					#endregion protected
					// Relationship.RelationshipPropertyList = new EnterpriseDataObjectList<RelationshipProperty>(EditRelationship.RelationshipPropertyList, null);
					// Relationship.ForwardInstance.RelationshipPropertyList = new EnterpriseDataObjectList<RelationshipProperty>(EditRelationship.RelationshipPropertyList, null);
				}
				if (TagsCustomized)
				{
					Relationship.ForwardInstance.Tags = EditRelationship.Tags;
				}
			}
			EditRelationship.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditRelationshipPerformed();

			// send update for any updated RelationshipProperties
			foreach (RelationshipPropertyViewModel item in RelationshipProperties)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new RelationshipProperties
			foreach (RelationshipPropertyViewModel item in ItemsToAdd.OfType<RelationshipPropertyViewModel>())
			{
				item.Update();
				RelationshipProperties.Add(item);
			}

			// send delete for any deleted RelationshipProperties
			foreach (RelationshipPropertyViewModel item in ItemsToDelete.OfType<RelationshipPropertyViewModel>())
			{
				item.Delete();
				RelationshipProperties.Remove(item);
			}

			// reset modified for RelationshipProperties
			foreach (RelationshipPropertyViewModel item in RelationshipProperties)
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
		public void SendEditRelationshipPerformed()
		{
			RelationshipEventArgs message = new RelationshipEventArgs();
			message.Relationship = Relationship;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipEventArgs>(MediatorMessages.Command_EditRelationshipPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Relationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteRelationshipCommand()
		{
			RelationshipEventArgs message = new RelationshipEventArgs();
			message.Relationship = Relationship;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipEventArgs>(MediatorMessages.Command_DeleteRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteRelationshipCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RelationshipProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<RelationshipPropertyViewModel> RelationshipProperties { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Relationship.</summary>
		///--------------------------------------------------------------------------------
		public Relationship Relationship { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipID.</summary>
		///--------------------------------------------------------------------------------
		public Guid RelationshipID
		{
			get
			{
				return Relationship.RelationshipID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Relationship.Name;
			}
			set
			{
				Relationship.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return Relationship.EntityID;
			}
			set
			{
				Relationship.EntityID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Relationship into the view model.</summary>
		/// 
		/// <param name="relationship">The Relationship to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadRelationship(Relationship relationship, bool loadChildren = true)
		{
			// attach the Relationship
			Relationship = relationship;
			ItemID = Relationship.RelationshipID;
			Items.Clear();
			
			// initialize RelationshipProperties
			if (RelationshipProperties == null)
			{
				RelationshipProperties = new EnterpriseDataObjectList<RelationshipPropertyViewModel>();
			}
			if (loadChildren == true)
			{
				// attach RelationshipProperties
				foreach (RelationshipProperty item in relationship.RelationshipPropertyList)
				{
					RelationshipPropertyViewModel itemView = new RelationshipPropertyViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					RelationshipProperties.Add(itemView);
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
				foreach (RelationshipPropertyViewModel item in RelationshipProperties)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Relationship.IsValid;
			HasCustomizations = Relationship.IsAutoUpdated == false || Relationship.IsEmptyMetadata(Relationship.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Relationship.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Relationship.IsAutoUpdated = true;
				Relationship.SpecSourceName = Relationship.ReverseInstance.SpecSourceName;
				Relationship.ResetModified(Relationship.ReverseInstance.IsModified);
				Relationship.ResetLoaded(Relationship.ReverseInstance.IsLoaded);
				if (!Relationship.IsIdenticalMetadata(Relationship.ReverseInstance))
				{
					HasCustomizations = true;
					Relationship.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Relationship.ForwardInstance = null;
				Relationship.ReverseInstance = null;
				Relationship.IsAutoUpdated = true;
			}
			foreach (RelationshipPropertyViewModel item in RelationshipProperties)
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
			if (RelationshipProperties != null)
			{
				for (int i = RelationshipProperties.Count - 1; i >= 0; i--)
				{
					RelationshipProperties[i].Updated -= Children_Updated;
					RelationshipProperties[i].Dispose();
					RelationshipProperties.Remove(RelationshipProperties[i]);
				}
				RelationshipProperties = null;
			}
			if (_editRelationship != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditRelationship.PropertyChanged -= EditRelationship_PropertyChanged;
				EditRelationship = null;
			}
			Relationship = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (RelationshipPropertyViewModel item in RelationshipProperties)
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
			OnPropertyChanged("RelationshipPropertyList");
			OnPropertyChanged("RelationshipPropertyListCustomized");
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
			if (data is RelationshipPropertyEventArgs && (data as RelationshipPropertyEventArgs).RelationshipID == Relationship.RelationshipID)
			{
				return this;
			}
			foreach (RelationshipPropertyViewModel model in RelationshipProperties)
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
		/// <summary>This method adds an instance of RelationshipProperty to the view model.</summary>
		/// 
		/// <param name="itemView">The RelationshipProperty to add.</param>
		///--------------------------------------------------------------------------------
		public void AddRelationshipProperty(RelationshipPropertyViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			RelationshipProperties.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of RelationshipProperty from the view model.</summary>
		/// 
		/// <param name="itemView">The RelationshipProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteRelationshipProperty(RelationshipPropertyViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			RelationshipProperties.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public RelationshipViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="relationship">The Relationship to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public RelationshipViewModel(Relationship relationship, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadRelationship(relationship, loadChildren);
		}

		#endregion "Constructors"
	}
}
