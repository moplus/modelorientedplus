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
	/// <summary>This class provides views for Entity instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/22/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class EntityViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntity.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntity
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntity;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlEntityToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEntityToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntityToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewCollectionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCollectionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewCollectionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyReference.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyReference
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyReference;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyReferenceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyReferenceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyReferenceToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntityReference.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntityReference
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntityReference;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntityReferenceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntityReferenceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntityReferenceToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewMethod.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethod
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethod;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewMethodToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethodToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethodToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewIndex.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndex
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndex;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewIndexToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndexToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndexToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewRelationshipToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationshipToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewStateModelToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateModelToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateModelToolTip;
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
				if (EditEntity.IsModified == true)
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
				return string.IsNullOrEmpty(EntityNameValidationMessage + EntityTypeCodeValidationMessage + IdentifierTypeCodeValidationMessage + SelectFeatureIDValidationMessage + BaseEntityIDValidationMessage + GroupNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Entity _editEntity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditEntity.</summary>
		///--------------------------------------------------------------------------------
		public Entity EditEntity
		{
			get
			{
				if (_editEntity == null)
				{
					_editEntity = new Entity();
					_editEntity.PropertyChanged += new PropertyChangedEventHandler(EditEntity_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Entity != null)
					{
						_editEntity.TransformDataFromObject(Entity, null, false);
						_editEntity.Solution = Entity.Solution;
						_editEntity.EntityType = Entity.EntityType;
						_editEntity.Feature = Entity.Feature;
						_editEntity.IdentifierType = Entity.IdentifierType;
					}
					_editEntity.ResetModified(false);
				}
				return _editEntity;
			}
			set
			{
				_editEntity = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditEntity");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("EntityName");
			OnPropertyChanged("EntityNameCustomized");
			OnPropertyChanged("EntityNameValidationMessage");
			
			OnPropertyChanged("EntityTypeCode");
			OnPropertyChanged("EntityTypeCodeCustomized");
			OnPropertyChanged("EntityTypeCodeValidationMessage");
			
			OnPropertyChanged("IdentifierTypeCode");
			OnPropertyChanged("IdentifierTypeCodeCustomized");
			OnPropertyChanged("IdentifierTypeCodeValidationMessage");
			
			OnPropertyChanged("SelectFeatureID");
			OnPropertyChanged("SelectFeatureIDCustomized");
			OnPropertyChanged("SelectFeatureIDValidationMessage");
			
			OnPropertyChanged("BaseEntityID");
			OnPropertyChanged("BaseEntityIDCustomized");
			OnPropertyChanged("BaseEntityIDValidationMessage");
			
			OnPropertyChanged("GroupName");
			OnPropertyChanged("GroupNameCustomized");
			OnPropertyChanged("GroupNameValidationMessage");
			
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
				return DisplayValues.Edit_EntityHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_EntityHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EntityIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EntityIDLabel
		{
			get
			{
				return DisplayValues.Edit_EntityIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EntityNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EntityNameLabel
		{
			get
			{
				return DisplayValues.Edit_EntityNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EntityName.</summary>
		///--------------------------------------------------------------------------------
		public string EntityName
		{
			get
			{
				return EditEntity.EntityName;
			}
			set
			{
				EditEntity.EntityName = value;
				OnPropertyChanged("EntityName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool EntityNameCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return EntityName.GetString() != Entity.ReverseInstance.EntityName.GetString();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return EntityName.GetString() != Entity.EntityName.GetString();
				}
				return EntityName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string EntityNameValidationMessage
		{
			get
			{
				return EditEntity.ValidateEntityName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EntityTypeCodeLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EntityTypeCodeLabel
		{
			get
			{
				return DisplayValues.Edit_EntityTypeCodeSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		public int EntityTypeCode
		{
			get
			{
				return EditEntity.EntityTypeCode;
			}
			set
			{
				EditEntity.EntityTypeCode = value;
				OnPropertyChanged("EntityTypeCode");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityTypeCodeCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool EntityTypeCodeCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return EntityTypeCode.GetInt() != Entity.ReverseInstance.EntityTypeCode.GetInt();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return EntityTypeCode.GetInt() != Entity.EntityTypeCode.GetInt();
				}
				return EntityTypeCode != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityTypeCodeValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string EntityTypeCodeValidationMessage
		{
			get
			{
				return EditEntity.ValidateEntityTypeCode();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IdentifierTypeCodeLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IdentifierTypeCodeLabel
		{
			get
			{
				return DisplayValues.Edit_IdentifierTypeCodeSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		public int IdentifierTypeCode
		{
			get
			{
				return EditEntity.IdentifierTypeCode;
			}
			set
			{
				EditEntity.IdentifierTypeCode = value;
				OnPropertyChanged("IdentifierTypeCode");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentifierTypeCodeCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IdentifierTypeCodeCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return IdentifierTypeCode.GetInt() != Entity.ReverseInstance.IdentifierTypeCode.GetInt();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return IdentifierTypeCode.GetInt() != Entity.IdentifierTypeCode.GetInt();
				}
				return IdentifierTypeCode != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentifierTypeCodeValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IdentifierTypeCodeValidationMessage
		{
			get
			{
				return EditEntity.ValidateIdentifierTypeCode();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SelectFeatureIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SelectFeatureIDLabel
		{
			get
			{
				return DisplayValues.Edit_FeatureIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SelectFeatureID.</summary>
		///--------------------------------------------------------------------------------
		public Guid SelectFeatureID
		{
			get
			{
				return EditEntity.FeatureID;
			}
			set
			{
				EditEntity.FeatureID = value;
				OnPropertyChanged("SelectFeatureID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SelectFeatureIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SelectFeatureIDCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return SelectFeatureID.GetGuid() != Entity.ReverseInstance.FeatureID.GetGuid();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return SelectFeatureID.GetGuid() != Entity.FeatureID.GetGuid();
				}
				return SelectFeatureID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SelectFeatureIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SelectFeatureIDValidationMessage
		{
			get
			{
				return EditEntity.ValidateFeatureID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the BaseEntityIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string BaseEntityIDLabel
		{
			get
			{
				return DisplayValues.Edit_BaseEntityIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets BaseEntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? BaseEntityID
		{
			get
			{
				return EditEntity.BaseEntityID;
			}
			set
			{
				EditEntity.BaseEntityID = value;
				OnPropertyChanged("BaseEntityID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets BaseEntityIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool BaseEntityIDCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return BaseEntityID.GetGuid() != Entity.ReverseInstance.BaseEntityID.GetGuid();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return BaseEntityID.GetGuid() != Entity.BaseEntityID.GetGuid();
				}
				return BaseEntityID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets BaseEntityIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string BaseEntityIDValidationMessage
		{
			get
			{
				return EditEntity.ValidateBaseEntityID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the GroupNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string GroupNameLabel
		{
			get
			{
				return DisplayValues.Edit_GroupNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets GroupName.</summary>
		///--------------------------------------------------------------------------------
		public string GroupName
		{
			get
			{
				return EditEntity.GroupName;
			}
			set
			{
				EditEntity.GroupName = value;
				OnPropertyChanged("GroupName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets GroupNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool GroupNameCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return GroupName.GetString() != Entity.ReverseInstance.GroupName.GetString();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return GroupName.GetString() != Entity.GroupName.GetString();
				}
				return GroupName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets GroupNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string GroupNameValidationMessage
		{
			get
			{
				return EditEntity.ValidateGroupName();
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
				return EditEntity.Description;
			}
			set
			{
				EditEntity.Description = value;
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
				if (Entity.ReverseInstance != null)
				{
					return Description.GetString() != Entity.ReverseInstance.Description.GetString();
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return Description.GetString() != Entity.Description.GetString();
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
				return EditEntity.ValidateDescription();
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
				return EditEntity.SourceName;
			}
			set
			{
				EditEntity.SourceName = value;
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
				return EditEntity.SpecSourceName;
			}
			set
			{
				EditEntity.SpecSourceName = value;
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
				return EditEntity.Tags;
			}
			set
			{
				EditEntity.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Entity.ReverseInstance != null)
				{
					return Tags != Entity.ReverseInstance.Tags;
				}
				else if (Entity.IsAutoUpdated == true)
				{
					return Tags != Entity.Tags;
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
				return EditEntity.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditEntity.Name;
			}
			set
			{
				EditEntity.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditEntity.TransformDataFromObject(Entity, null, false);
			EditEntity.ResetModified(false);
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
			if (Entity.ReverseInstance != null)
			{
				EditEntity.TransformDataFromObject(Entity.ReverseInstance, null, false);
			}
			else if (Entity.IsAutoUpdated == true)
			{
				EditEntity.TransformDataFromObject(Entity, null, false);
			}
			else
			{
				Entity newEntity = new Entity();
				newEntity.EntityID = EditEntity.EntityID;
				EditEntity.TransformDataFromObject(newEntity, null, false);
			}
			EditEntity.ResetModified(true);
			foreach (PropertyViewModel item in Items.OfType<PropertyViewModel>())
			{
				item.Defaults();
			}
			foreach (CollectionViewModel item in Items.OfType<CollectionViewModel>())
			{
				item.Defaults();
			}
			foreach (PropertyReferenceViewModel item in Items.OfType<PropertyReferenceViewModel>())
			{
				item.Defaults();
			}
			foreach (EntityReferenceViewModel item in Items.OfType<EntityReferenceViewModel>())
			{
				item.Defaults();
			}
			foreach (MethodViewModel item in Items.OfType<MethodViewModel>())
			{
				item.Defaults();
			}
			foreach (IndexViewModel item in Items.OfType<IndexViewModel>())
			{
				item.Defaults();
			}
			foreach (RelationshipViewModel item in Items.OfType<RelationshipViewModel>())
			{
				item.Defaults();
			}
			foreach (StateModelViewModel item in Items.OfType<StateModelViewModel>())
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
		/// <summary>This method processes the new Entity command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewEntityCommand()
		{
			EntityEventArgs message = new EntityEventArgs();
			message.Entity = new Entity();
			message.Entity.EntityID = Guid.NewGuid();
			message.Entity.FeatureID = FeatureID;
			message.Entity.Feature = Solution.FeatureList.FindByID((Guid)FeatureID);
			message.Entity.Solution = Solution;
			message.FeatureID = FeatureID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EntityEventArgs>(MediatorMessages.Command_EditEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditEntityCommand()
		{
			EntityEventArgs message = new EntityEventArgs();
			message.Entity = Entity;
			message.FeatureID = FeatureID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EntityEventArgs>(MediatorMessages.Command_EditEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewEntityCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			#region protected
			PreviousFeatureID = null;
			if (EditEntity.FeatureID != Entity.FeatureID)
			{
				PreviousFeatureID = Entity.FeatureID;
			}
			#endregion protected

			// set up reverse engineering instance if not present
			if (Entity.ReverseInstance == null && Entity.IsAutoUpdated == true)
			{
				Entity.ReverseInstance = new Entity();
				Entity.ReverseInstance.TransformDataFromObject(Entity, null, false);

				// perform the update of EditEntity back to Entity
				Entity.TransformDataFromObject(EditEntity, null, false);
				Entity.IsAutoUpdated = false;
			}
			else if (Entity.ReverseInstance != null)
			{
				EditEntity.ResetModified(Entity.ReverseInstance.IsModified);
				if (EditEntity.Equals(Entity.ReverseInstance))
				{
					// perform the update of EditEntity back to Entity
					Entity.TransformDataFromObject(EditEntity, null, false);
					Entity.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditEntity back to Entity
					Entity.TransformDataFromObject(EditEntity, null, false);
					Entity.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditEntity back to Entity
				Entity.TransformDataFromObject(EditEntity, null, false);
				Entity.IsAutoUpdated = false;
			}
			Entity.ForwardInstance = null;
			if (EntityNameCustomized || EntityTypeCodeCustomized || IdentifierTypeCodeCustomized || SelectFeatureIDCustomized || BaseEntityIDCustomized || GroupNameCustomized || DescriptionCustomized || TagsCustomized)
			{
				Entity.ForwardInstance = new Entity();
				Entity.ForwardInstance.EntityID = EditEntity.EntityID;
				Entity.SpecSourceName = Entity.DefaultSourceName;
				if (EntityNameCustomized)
				{
					Entity.ForwardInstance.EntityName = EditEntity.EntityName;
				}
				if (EntityTypeCodeCustomized)
				{
					Entity.ForwardInstance.EntityTypeCode = EditEntity.EntityTypeCode;
				}
				if (IdentifierTypeCodeCustomized)
				{
					Entity.ForwardInstance.IdentifierTypeCode = EditEntity.IdentifierTypeCode;
				}
				if (SelectFeatureIDCustomized)
				{
					Entity.ForwardInstance.FeatureID = EditEntity.FeatureID;
				}
				if (BaseEntityIDCustomized)
				{
					Entity.ForwardInstance.BaseEntityID = EditEntity.BaseEntityID;
				}
				if (GroupNameCustomized)
				{
					Entity.ForwardInstance.GroupName = EditEntity.GroupName;
				}
				if (DescriptionCustomized)
				{
					Entity.ForwardInstance.Description = EditEntity.Description;
				}
				if (TagsCustomized)
				{
					Entity.ForwardInstance.Tags = EditEntity.Tags;
				}
			}
			EditEntity.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditEntityPerformed();

			// send update for any updated Properties
			if (PropertiesFolder != null && PropertiesFolder.IsEdited == true)
			{
				PropertiesFolder.Update();
			}

			// send update for any updated Collections
			if (CollectionsFolder != null && CollectionsFolder.IsEdited == true)
			{
				CollectionsFolder.Update();
			}

			// send update for any updated PropertyReferences
			if (PropertyReferencesFolder != null && PropertyReferencesFolder.IsEdited == true)
			{
				PropertyReferencesFolder.Update();
			}

			// send update for any updated EntityReferences
			if (EntityReferencesFolder != null && EntityReferencesFolder.IsEdited == true)
			{
				EntityReferencesFolder.Update();
			}

			// send update for any updated Methods
			if (MethodsFolder != null && MethodsFolder.IsEdited == true)
			{
				MethodsFolder.Update();
			}

			// send update for any updated Indexes
			if (IndexesFolder != null && IndexesFolder.IsEdited == true)
			{
				IndexesFolder.Update();
			}

			// send update for any updated Relationships
			if (RelationshipsFolder != null && RelationshipsFolder.IsEdited == true)
			{
				RelationshipsFolder.Update();
			}

			// send update for any updated StateModels
			if (StateModelsFolder != null && StateModelsFolder.IsEdited == true)
			{
				StateModelsFolder.Update();
			}
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
		public void SendEditEntityPerformed()
		{
			EntityEventArgs message = new EntityEventArgs();

			#region protected
			message.PreviousFeatureID = PreviousFeatureID;
			#endregion protected

			message.Entity = Entity;
			message.FeatureID = FeatureID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EntityEventArgs>(MediatorMessages.Command_EditEntityPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Entity command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteEntityCommand()
		{
			EntityEventArgs message = new EntityEventArgs();
			message.Entity = Entity;
			message.FeatureID = FeatureID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EntityEventArgs>(MediatorMessages.Command_DeleteEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteEntityCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Property lists.</summary>
		///--------------------------------------------------------------------------------
		public PropertiesViewModel PropertiesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Collection lists.</summary>
		///--------------------------------------------------------------------------------
		public CollectionsViewModel CollectionsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyReference lists.</summary>
		///--------------------------------------------------------------------------------
		public PropertyReferencesViewModel PropertyReferencesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityReference lists.</summary>
		///--------------------------------------------------------------------------------
		public EntityReferencesViewModel EntityReferencesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Method lists.</summary>
		///--------------------------------------------------------------------------------
		public MethodsViewModel MethodsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Index lists.</summary>
		///--------------------------------------------------------------------------------
		public IndexesViewModel IndexesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Relationship lists.</summary>
		///--------------------------------------------------------------------------------
		public RelationshipsViewModel RelationshipsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateModel lists.</summary>
		///--------------------------------------------------------------------------------
		public StateModelsViewModel StateModelsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return Entity.EntityID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Entity.Name;
			}
			set
			{
				Entity.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets FeatureID.</summary>
		///--------------------------------------------------------------------------------
		public Guid FeatureID
		{
			get
			{
				return Entity.FeatureID;
			}
			set
			{
				Entity.FeatureID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Entity into the view model.</summary>
		/// 
		/// <param name="entity">The Entity to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadEntity(Entity entity, bool loadChildren = true)
		{
			// attach the Entity
			Entity = entity;
			ItemID = Entity.EntityID;
			Items.Clear();
			if (loadChildren == true)
			{
				// attach Properties
				if (PropertiesFolder == null)
				{
					PropertiesFolder = new PropertiesViewModel(entity, Solution);
					PropertiesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(PropertiesFolder);
				}
								
				// attach Collections
				if (CollectionsFolder == null)
				{
					CollectionsFolder = new CollectionsViewModel(entity, Solution);
					CollectionsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(CollectionsFolder);
				}
								
				// attach PropertyReferences
				if (PropertyReferencesFolder == null)
				{
					PropertyReferencesFolder = new PropertyReferencesViewModel(entity, Solution);
					PropertyReferencesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(PropertyReferencesFolder);
				}
								
				// attach EntityReferences
				if (EntityReferencesFolder == null)
				{
					EntityReferencesFolder = new EntityReferencesViewModel(entity, Solution);
					EntityReferencesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(EntityReferencesFolder);
				}
								
				// attach Methods
				if (MethodsFolder == null)
				{
					MethodsFolder = new MethodsViewModel(entity, Solution);
					MethodsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(MethodsFolder);
				}
								
				// attach Indexes
				if (IndexesFolder == null)
				{
					IndexesFolder = new IndexesViewModel(entity, Solution);
					IndexesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(IndexesFolder);
				}
								
				// attach Relationships
				if (RelationshipsFolder == null)
				{
					RelationshipsFolder = new RelationshipsViewModel(entity, Solution);
					RelationshipsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(RelationshipsFolder);
				}
								
				// attach StateModels
				if (StateModelsFolder == null)
				{
					StateModelsFolder = new StateModelsViewModel(entity, Solution);
					StateModelsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(StateModelsFolder);
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
				PropertiesFolder.Refresh(refreshChildren, refreshLevel - 1);
				CollectionsFolder.Refresh(refreshChildren, refreshLevel - 1);
				PropertyReferencesFolder.Refresh(refreshChildren, refreshLevel - 1);
				EntityReferencesFolder.Refresh(refreshChildren, refreshLevel - 1);
				MethodsFolder.Refresh(refreshChildren, refreshLevel - 1);
				IndexesFolder.Refresh(refreshChildren, refreshLevel - 1);
				RelationshipsFolder.Refresh(refreshChildren, refreshLevel - 1);
				StateModelsFolder.Refresh(refreshChildren, refreshLevel - 1);
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Entity.IsValid;
			HasCustomizations = Entity.IsAutoUpdated == false || Entity.IsEmptyMetadata(Entity.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Entity.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Entity.IsAutoUpdated = true;
				Entity.SpecSourceName = Entity.ReverseInstance.SpecSourceName;
				Entity.ResetModified(Entity.ReverseInstance.IsModified);
				Entity.ResetLoaded(Entity.ReverseInstance.IsLoaded);
				if (!Entity.IsIdenticalMetadata(Entity.ReverseInstance))
				{
					HasCustomizations = true;
					Entity.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Entity.ForwardInstance = null;
				Entity.ReverseInstance = null;
				Entity.IsAutoUpdated = true;
			}
			if (PropertiesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (CollectionsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (PropertyReferencesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (EntityReferencesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (MethodsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (IndexesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (RelationshipsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (StateModelsFolder.HasErrors == true)
			{
				HasErrors = true;
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
			if (PropertiesFolder != null)
			{
				PropertiesFolder.Updated -= Children_Updated;
				PropertiesFolder.Dispose();
				PropertiesFolder = null;
			}
			if (CollectionsFolder != null)
			{
				CollectionsFolder.Updated -= Children_Updated;
				CollectionsFolder.Dispose();
				CollectionsFolder = null;
			}
			if (PropertyReferencesFolder != null)
			{
				PropertyReferencesFolder.Updated -= Children_Updated;
				PropertyReferencesFolder.Dispose();
				PropertyReferencesFolder = null;
			}
			if (EntityReferencesFolder != null)
			{
				EntityReferencesFolder.Updated -= Children_Updated;
				EntityReferencesFolder.Dispose();
				EntityReferencesFolder = null;
			}
			if (MethodsFolder != null)
			{
				MethodsFolder.Updated -= Children_Updated;
				MethodsFolder.Dispose();
				MethodsFolder = null;
			}
			if (IndexesFolder != null)
			{
				IndexesFolder.Updated -= Children_Updated;
				IndexesFolder.Dispose();
				IndexesFolder = null;
			}
			if (RelationshipsFolder != null)
			{
				RelationshipsFolder.Updated -= Children_Updated;
				RelationshipsFolder.Dispose();
				RelationshipsFolder = null;
			}
			if (StateModelsFolder != null)
			{
				StateModelsFolder.Updated -= Children_Updated;
				StateModelsFolder.Dispose();
				StateModelsFolder = null;
			}
			if (_editEntity != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditEntity.PropertyChanged -= EditEntity_PropertyChanged;
				EditEntity = null;
			}
			Entity = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			if (PropertiesFolder != null && PropertiesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (CollectionsFolder != null && CollectionsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (PropertyReferencesFolder != null && PropertyReferencesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (EntityReferencesFolder != null && EntityReferencesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (MethodsFolder != null && MethodsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (IndexesFolder != null && IndexesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (RelationshipsFolder != null && RelationshipsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (StateModelsFolder != null && StateModelsFolder.HasCustomizations == true)
			{
				return true;
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
			parentModel = PropertiesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = CollectionsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = PropertyReferencesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = EntityReferencesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = MethodsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = IndexesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = RelationshipsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = StateModelsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public EntityViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="entity">The Entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public EntityViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadEntity(entity, loadChildren);
		}

		#endregion "Constructors"
	}
}
