/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific Relationship instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/30/2014</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="Relationship")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Relationship : BusinessObjectBase
	{
		#region "Validation"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns validation errors for the input item.</param>
		/// 
		/// <returns>Validation errors (null by default).</returns>
		///--------------------------------------------------------------------------------
		public virtual string GetValidationErrors()
		{
			StringBuilder errors = new StringBuilder();
			string error = null;
			
			error = GetValidationError("RelationshipName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("EntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedEntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsNullable");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ItemsMin");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ItemsMax");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedItemsMin");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedItemsMax");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsAutoUpdated");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Description");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			
			return errors.ToString();
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method returns a validation error for the input property.</param>
		/// 
		/// <param name="fieldName">The name of the property.</param>
		/// <returns>Validation error (null by default).</returns>
		///--------------------------------------------------------------------------------
		public override string GetValidationError(string fieldName)
		{
			if (this.GetFieldInfo(fieldName) == null && this.GetPropertyInfo(fieldName) == null) return null;
			
			string error = null;
			
			switch (fieldName)
			{
				case "_relationshipName":
				case "RelationshipName":
					error = ValidateRelationshipName();
					break;
				case "_entityID":
				case "EntityID":
					error = ValidateEntityID();
					break;
				case "_referencedEntityID":
				case "ReferencedEntityID":
					error = ValidateReferencedEntityID();
					break;
				case "_isNullable":
				case "IsNullable":
					error = ValidateIsNullable();
					break;
				case "_itemsMin":
				case "ItemsMin":
					error = ValidateItemsMin();
					break;
				case "_itemsMax":
				case "ItemsMax":
					error = ValidateItemsMax();
					break;
				case "_referencedItemsMin":
				case "ReferencedItemsMin":
					error = ValidateReferencedItemsMin();
					break;
				case "_referencedItemsMax":
				case "ReferencedItemsMax":
					error = ValidateReferencedItemsMax();
					break;
				case "_isAutoUpdated":
				case "IsAutoUpdated":
					error = ValidateIsAutoUpdated();
					break;
				case "_description":
				case "Description":
					error = ValidateDescription();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates RelationshipName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateRelationshipName()
		{
			if (!Regex.IsMatch(RelationshipName, Resources.DisplayValues.Regex_DbPropertyName))
			{
				return String.Format(Resources.DisplayValues.Validation_DbPropertyNameValue, "RelationshipName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates EntityID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateEntityID()
		{
			if (EntityID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "EntityID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ReferencedEntityID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedEntityID()
		{
			if (ReferencedEntityID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ReferencedEntityID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsNullable and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsNullable()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ItemsMin and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateItemsMin()
		{
			if (ItemsMin < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_MinusOneOrMoreValue, "ItemsMin");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ItemsMax and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateItemsMax()
		{
			if (ItemsMax < -1 || ItemsMax == 0)
			{
				return String.Format(Resources.DisplayValues.Validation_ZeroOrMoreValue, "ItemsMax");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ReferencedItemsMin and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedItemsMin()
		{
			if (ReferencedItemsMin < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_MinusOneOrMoreValue, "ReferencedItemsMin");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ReferencedItemsMax and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedItemsMax()
		{
			if (ReferencedItemsMax < -1 || ReferencedItemsMax == 0)
			{
				return String.Format(Resources.DisplayValues.Validation_ZeroOrMoreValue, "ReferencedItemsMax");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsAutoUpdated and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsAutoUpdated()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Description and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDescription()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private Relationship _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Relationship ForwardInstance
		{
			get
			{
				return _forwardInstance;
			}
			set
			{
				_forwardInstance = value;
			}
		}
		
		private Relationship _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Relationship ReverseInstance
		{
			get
			{
				return _reverseInstance;
			}
			set
			{
				_reverseInstance = value;
				base.ReverseInstance = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override Guid ID
		{
			get
			{
				return RelationshipID;
			}
			set
			{
				RelationshipID = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override string Name
		{
			get
			{
				return RelationshipName;
			}
			set
			{
				RelationshipName = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the OriginalName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string OriginalName
		{
			get
			{
				return SourceRelationship.RelationshipName;
			}
		}
		
		protected string _displayName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the display name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DisplayName
		{
			get
			{
				if (_displayName == null)
				{
					if (!String.IsNullOrEmpty(EntityName))
					{
						_displayName = EntityName + "." + RelationshipName;
					}
					else
					{
						_displayName = RelationshipName;
					}
				}
				
				#region protected
				#endregion protected
				
				return _displayName;
			}
			set
			{
				_displayName = value;
			}
		}
		
		private string _defaultSourceName;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the default source name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DefaultSourceName
		{
			get
			{
				if (_defaultSourceName == null)
				{
					if (Entity != null)
					{
						_defaultSourceName = Entity.DefaultSourceName + "." + DefaultSourcePrefix + SourceRelationship.RelationshipName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceRelationship.RelationshipName;
					}
				}
				
				#region protected
				#endregion protected
				
				return _defaultSourceName;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the source method, which may be the reverse instance
		/// (to get original values, etc.).</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Relationship SourceRelationship
		{
			get
			{
				if (ReverseInstance != null)
				{
					return ReverseInstance;
				}
				return this;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldRelationshipID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldRelationshipID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldEntityID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldReferencedEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldReferencedEntityID { get; set; }
		
		private Solutions.Solution _solution;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Solutions.Solution Solution
		{
			get
			{
				return _solution;
			}
			set
			{
				_solution = value;
			}
		}
		
		protected Guid _relationshipID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the RelationshipID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid RelationshipID
		{
			get
			{
				return _relationshipID;
			}
			set
			{
				if (_relationshipID != value)
				{
					_relationshipID = value;
					_isModified = true;
					base.OnPropertyChanged("RelationshipID");
				}
			}
		}
		
		protected string _relationshipName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the RelationshipName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string RelationshipName
		{
			get
			{
				return _relationshipName;
			}
			set
			{
				if (_relationshipName != value)
				{
					_relationshipName = value;
					_isModified = true;
					base.OnPropertyChanged("RelationshipName");
				}
			}
		}
		
		protected Guid _entityID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid EntityID
		{
			get
			{
				return _entityID;
			}
			set
			{
				if (_entityID != value)
				{
					_entityID = value;
					_isModified = true;
					base.OnPropertyChanged("EntityID");
				}
			}
		}
		
		protected Guid _referencedEntityID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedEntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ReferencedEntityID
		{
			get
			{
				return _referencedEntityID;
			}
			set
			{
				if (_referencedEntityID != value)
				{
					_referencedEntityID = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedEntityID");
				}
			}
		}
		
		protected bool _isNullable = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsNullable.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsNullable
		{
			get
			{
				return _isNullable;
			}
			set
			{
				if (_isNullable != value)
				{
					_isNullable = value;
					_isModified = true;
					base.OnPropertyChanged("IsNullable");
				}
			}
		}
		
		protected int _itemsMin = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ItemsMin.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int ItemsMin
		{
			get
			{
				return _itemsMin;
			}
			set
			{
				if (_itemsMin != value)
				{
					_itemsMin = value;
					_isModified = true;
					base.OnPropertyChanged("ItemsMin");
				}
			}
		}
		
		protected int _itemsMax = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ItemsMax.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int ItemsMax
		{
			get
			{
				return _itemsMax;
			}
			set
			{
				if (_itemsMax != value)
				{
					_itemsMax = value;
					_isModified = true;
					base.OnPropertyChanged("ItemsMax");
				}
			}
		}
		
		protected int _referencedItemsMin = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedItemsMin.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int ReferencedItemsMin
		{
			get
			{
				return _referencedItemsMin;
			}
			set
			{
				if (_referencedItemsMin != value)
				{
					_referencedItemsMin = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedItemsMin");
				}
			}
		}
		
		protected int _referencedItemsMax = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedItemsMax.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int ReferencedItemsMax
		{
			get
			{
				return _referencedItemsMax;
			}
			set
			{
				if (_referencedItemsMax != value)
				{
					_referencedItemsMax = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedItemsMax");
				}
			}
		}
		
		protected bool _isAutoUpdated = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsAutoUpdated.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsAutoUpdated
		{
			get
			{
				return _isAutoUpdated;
			}
			set
			{
				if (_isAutoUpdated != value)
				{
					_isAutoUpdated = value;
					base.OnPropertyChanged("IsAutoUpdated");
				}
			}
		}
		
		protected string _description = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Description.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				if (_description != value)
				{
					_description = value;
					_isModified = true;
					base.OnPropertyChanged("Description");
				}
			}
		}
		
		protected string _entityName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string EntityName
		{
			get
			{
				return _entityName;
			}
		}
		
		protected int _entityTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int EntityTypeCode
		{
			get
			{
				return _entityTypeCode;
			}
		}
		
		protected int _identifierTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the IdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int IdentifierTypeCode
		{
			get
			{
				return _identifierTypeCode;
			}
		}
		
		protected string _groupName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the GroupName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string GroupName
		{
			get
			{
				return _groupName;
			}
		}
		
		protected string _referencedEntityName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedEntityName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ReferencedEntityName
		{
			get
			{
				return _referencedEntityName;
			}
		}
		
		protected int _referencedEntityTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedEntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int ReferencedEntityTypeCode
		{
			get
			{
				return _referencedEntityTypeCode;
			}
		}
		
		protected int _referencedIdentifierTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedIdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int ReferencedIdentifierTypeCode
		{
			get
			{
				return _referencedIdentifierTypeCode;
			}
		}
		
		protected string _referencedGroupName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedGroupName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ReferencedGroupName
		{
			get
			{
				return _referencedGroupName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> _relationshipPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Relationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> RelationshipPropertyList
		{
			get
			{
				if (_relationshipPropertyList == null)
				{
					_relationshipPropertyList = new EnterpriseDataObjectList<BLL.Entities.RelationshipProperty>();
				}
				return _relationshipPropertyList;
			}
			set
			{
				if (_relationshipPropertyList == null || _relationshipPropertyList.Equals(value) == false)
				{
					_relationshipPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "RelationshipPropertyList")]
		[XmlArrayItem(typeof(BLL.Entities.RelationshipProperty), ElementName = "RelationshipProperty")]
		[DataMember(Name = "RelationshipPropertyList")]
		[DataArrayItem(ElementName = "RelationshipPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> _S_RelationshipPropertyList
		{
			get
			{
				return _relationshipPropertyList;
			}
			set
			{
				_relationshipPropertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.PropertyRelationship> _propertyRelationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Relationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyRelationship> PropertyRelationshipList
		{
			get
			{
				if (_propertyRelationshipList == null)
				{
					_propertyRelationshipList = new EnterpriseDataObjectList<BLL.Entities.PropertyRelationship>();
				}
				return _propertyRelationshipList;
			}
			set
			{
				if (_propertyRelationshipList == null || _propertyRelationshipList.Equals(value) == false)
				{
					_propertyRelationshipList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyRelationshipList")]
		[XmlArrayItem(typeof(BLL.Entities.PropertyRelationship), ElementName = "PropertyRelationship")]
		[DataMember(Name = "PropertyRelationshipList")]
		[DataArrayItem(ElementName = "PropertyRelationshipList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyRelationship> _S_PropertyRelationshipList
		{
			get
			{
				return _propertyRelationshipList;
			}
			set
			{
				_propertyRelationshipList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.MethodRelationship> _methodRelationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Relationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.MethodRelationship> MethodRelationshipList
		{
			get
			{
				if (_methodRelationshipList == null)
				{
					_methodRelationshipList = new EnterpriseDataObjectList<BLL.Entities.MethodRelationship>();
				}
				return _methodRelationshipList;
			}
			set
			{
				if (_methodRelationshipList == null || _methodRelationshipList.Equals(value) == false)
				{
					_methodRelationshipList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "MethodRelationshipList")]
		[XmlArrayItem(typeof(BLL.Entities.MethodRelationship), ElementName = "MethodRelationship")]
		[DataMember(Name = "MethodRelationshipList")]
		[DataArrayItem(ElementName = "MethodRelationshipList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.MethodRelationship> _S_MethodRelationshipList
		{
			get
			{
				return _methodRelationshipList;
			}
			set
			{
				_methodRelationshipList = value;
			}
		}
		
		protected BLL.Entities.Entity _referencedEntity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ReferencedEntity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Entity ReferencedEntity
		{
			get
			{
				return _referencedEntity;
			}
			set
			{
				if (value != null)
				{
					_referencedEntityName = value.EntityName;
					_referencedEntityTypeCode = value.EntityTypeCode;
					_referencedIdentifierTypeCode = value.IdentifierTypeCode;
					_referencedGroupName = value.GroupName;
					if (_referencedEntity != null && _referencedEntity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ReferencedEntityID = value.EntityID;
				}
				_referencedEntity = value;
			}
		}
		
		protected BLL.Entities.Entity _entity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Entity Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				if (value != null)
				{
					_entityName = value.EntityName;
					_entityTypeCode = value.EntityTypeCode;
					_identifierTypeCode = value.IdentifierTypeCode;
					_groupName = value.GroupName;
					if (_entity != null && _entity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					EntityID = value.EntityID;
				}
				_entity = value;
			}
		}
		
		///-------------------------------------------------------------------------------
		/// <summary>This property gets the primary key properties.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyProperties
		{
			get
			{
				return "RelationshipID";
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary key values.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyValues
		{
			get
			{
				return RelationshipID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					RelationshipID = primaryKeyValues[0].GetGuid();
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been modified since the
		/// last load from a resource such as a database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.Bool)]
		public override bool IsModified
		{
			get
			{
				if (base.IsModified == true) return true;
				if (_isModified == true) return true;
				if (_relationshipPropertyList != null && _relationshipPropertyList.IsModified == true) return true;
				if (_propertyRelationshipList != null && _propertyRelationshipList.IsModified == true) return true;
				if (_methodRelationshipList != null && _methodRelationshipList.IsModified == true) return true;
				return false;
			}
		}
		
		#region protected
		#endregion protected
		
		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method adds a tag to TagList.</summary>
		///--------------------------------------------------------------------------------
		public override void AddTag(string tagName)
		{
			if (ReverseInstance == null && IsAutoUpdated == true)
			{
				ReverseInstance = new Relationship();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Relationship();
				ForwardInstance.RelationshipID = RelationshipID;
			}
			if (ForwardInstance.TagList.Find(t => t.TagName == tagName) == null)
			{
				ForwardInstance.TagList.Add(new Tag(Guid.NewGuid(), tagName));
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method removes a tag from TagList.</summary>
		///--------------------------------------------------------------------------------
		public override void RemoveTag(string tagName)
		{
			base.RemoveTag(tagName);
			if (ForwardInstance != null)
			{
				Tag tag = ForwardInstance.TagList.Find(t => t.TagName == tagName);
				if (tag != null)
				{
					ForwardInstance.TagList.Remove(tag);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item's tags into a named tag dictionary.</summary>
		/// 
		/// <param name="usedTags">Input named tag dictionary.</param>
		///--------------------------------------------------------------------------------
		public virtual void AddItemToUsedTags(NameObjectCollection usedTags)
		{
			AddTagsToUsedTags(usedTags);
			foreach (RelationshipProperty relationshipProperty in RelationshipPropertyList)
			{
				relationshipProperty.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputRelationship">The relationship to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Relationship inputRelationship)
		{
			if (RelationshipName.GetString() != inputRelationship.RelationshipName.GetString()) return false;
			if (EntityID.GetGuid() != inputRelationship.EntityID.GetGuid()) return false;
			if (ReferencedEntityID.GetGuid() != inputRelationship.ReferencedEntityID.GetGuid()) return false;
			if (IsNullable.GetBool() != inputRelationship.IsNullable.GetBool()) return false;
			if (ItemsMin.GetInt() != inputRelationship.ItemsMin.GetInt()) return false;
			if (ItemsMax.GetInt() != inputRelationship.ItemsMax.GetInt()) return false;
			if (ReferencedItemsMin.GetInt() != inputRelationship.ReferencedItemsMin.GetInt()) return false;
			if (ReferencedItemsMax.GetInt() != inputRelationship.ReferencedItemsMax.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputRelationship.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputRelationship.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputRelationship">The relationship to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Relationship inputRelationship)
		{
			if (inputRelationship == null) return true;
			if (inputRelationship.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputRelationship.RelationshipName)) return false;
			if (EntityID != inputRelationship.EntityID) return false;
			if (ReferencedEntityID != inputRelationship.ReferencedEntityID) return false;
			if (IsNullable != inputRelationship.IsNullable) return false;
			if (ItemsMin != DefaultValue.Int) return false;
			if (ItemsMax != DefaultValue.Int) return false;
			if (ReferencedItemsMin != DefaultValue.Int) return false;
			if (ReferencedItemsMax != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputRelationship.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputRelationship.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputRelationship">The relationship to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Relationship inputRelationship)
		{
			RelationshipName = inputRelationship.RelationshipName;
			EntityID = inputRelationship.EntityID;
			ReferencedEntityID = inputRelationship.ReferencedEntityID;
			IsNullable = inputRelationship.IsNullable;
			ItemsMin = inputRelationship.ItemsMin;
			ItemsMax = inputRelationship.ItemsMax;
			ReferencedItemsMin = inputRelationship.ReferencedItemsMin;
			ReferencedItemsMax = inputRelationship.ReferencedItemsMax;
			IsAutoUpdated = inputRelationship.IsAutoUpdated;
			Description = inputRelationship.Description;
			
			#region protected
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public virtual void SetID()
		{
			_defaultSourceName = null;
			if (Solution.UsedModelIDs[DefaultSourceName].GetGuid() != Guid.Empty)
			{
				RelationshipID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (RelationshipID == Guid.Empty)
				{
					RelationshipID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = RelationshipID;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (ReverseInstance != null)
			{
				ReverseInstance.Dispose();
				ReverseInstance = null;
			}
			if (ForwardInstance != null)
			{
				ForwardInstance.Dispose();
				ForwardInstance = null;
			}
			ReferencedEntity = null;
			Entity = null;
			Solution = null;
			if (_relationshipPropertyList != null)
			{
				foreach (RelationshipProperty item in RelationshipPropertyList)
				{
					item.Dispose();
				}
				RelationshipPropertyList.Clear();
				RelationshipPropertyList = null;
			}
			if (_propertyRelationshipList != null)
			{
				foreach (PropertyRelationship item in PropertyRelationshipList)
				{
					item.Dispose();
				}
				PropertyRelationshipList.Clear();
				PropertyRelationshipList = null;
			}
			if (_methodRelationshipList != null)
			{
				foreach (MethodRelationship item in MethodRelationshipList)
				{
					item.Dispose();
				}
				MethodRelationshipList.Clear();
				MethodRelationshipList = null;
			}
			
			#region protected
			#endregion protected
			
			base.OnDispose();
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method assigns a value to a property, and updates corresponding
		/// forward and reverse engineering data.</summary>
		/// 
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		///--------------------------------------------------------------------------------
		public virtual bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new Relationship();
					ReverseInstance.TransformDataFromObject(this, null, false);
				}
				else
				{
					ReverseInstance.SetPropertyValue(propertyName, propertyValue);
				}
				if (ForwardInstance != null)
				{
					this.TransformDataFromObject(ForwardInstance, null, false, true);
				}
			}
			else
			{
				return false;
			}
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method creates a collection item to be used as an ID reference that
		/// will be saved, so the ID of this instance is maintained.</summary>
		///--------------------------------------------------------------------------------
		public virtual CollectionItem CreateIDReference()
		{
			CollectionItem newItem = new CollectionItem();
			newItem.ItemID = RelationshipID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Relationship GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Relationship forwardItem = new Relationship();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else if (IsAutoUpdated == false)
			{
				forwardItem.TransformDataFromObject(this, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.RelationshipID = RelationshipID;
			}
			foreach (RelationshipProperty item in RelationshipPropertyList)
			{
				item.Relationship = this;
				RelationshipProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.RelationshipPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			if (isCustomized == false)
			{
				return null;
			}
			forwardItem.SpecSourceName = DefaultSourceName;
			if (forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.SpecSourceName) == null)
			{
				forwardSolution.ReferencedModelIDs.Add(CreateIDReference());
			}
			
			#region protected
			if (forwardItem.ReferencedEntityID != Guid.Empty)
			{
				forwardItem.ReferencedEntity = Solution.EntityList.FindByID(forwardItem.ReferencedEntityID);
				if (forwardItem.ReferencedEntity != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.ReferencedEntity.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.ReferencedEntity.CreateIDReference());
				}
			}
			#endregion protected
			
			return forwardItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the current model context for the item.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to get current model context.</param>
		/// <param name="isValidContext">Output flag, signifying whether context returned is a valid one.</param>
		///--------------------------------------------------------------------------------
		public static IDomainEnterpriseObject GetModelContext(Solution solutionContext, IDomainEnterpriseObject parentModelContext, out bool isValidContext)
		{
			isValidContext = true;
			IDomainEnterpriseObject modelContext = parentModelContext;
			while (modelContext != null)
			{
				if (modelContext is Relationship)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Entity)
				{
					solutionContext.NeedsSample = false;
					Entity parent = modelContext as Entity;
					if (parent.RelationshipList.Count > 0)
					{
						return parent.RelationshipList[DataHelper.GetRandomInt(0, parent.RelationshipList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is RelationshipProperty)
				{
					RelationshipProperty parent = modelContext as RelationshipProperty;
					return parent.Relationship;
				}
				else if (modelContext is EntityReference)
				{
					EntityReference parent = modelContext as EntityReference;
					return parent.Relationship;
				}
				else if (modelContext is PropertyReference)
				{
					PropertyReference parent = modelContext as PropertyReference;
					return parent.Relationship;
				}
				else if (modelContext is Collection)
				{
					Collection parent = modelContext as Collection;
					return parent.Relationship;
				}
				else if (modelContext is MethodRelationship)
				{
					MethodRelationship parent = modelContext as MethodRelationship;
					return parent.Relationship;
				}
				else if (modelContext is PropertyRelationship)
				{
					PropertyRelationship parent = modelContext as PropertyRelationship;
					return parent.Relationship;
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.RelationshipList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.RelationshipList[DataHelper.GetRandomInt(0, solutionContext.RelationshipList.Count - 1)];
			}
			isValidContext = false;
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this item.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public static IEnterpriseEnumerable GetCollectionContext(Solution solutionContext, IDomainEnterpriseObject modelContext)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			while (nodeContext != null)
			{
				if (nodeContext is Entity)
				{
					return (nodeContext as Entity).RelationshipList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).RelationshipList;
				}
				
				#region protected
				else if (nodeContext is Relationship)
				{
					return (nodeContext as Relationship).Relationships;
				}
				#endregion protected
				
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parent item of this item.</summary>
		///--------------------------------------------------------------------------------
		public override IDomainEnterpriseObject GetParentItem()
		{
			return Entity;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Entity entity = Solution.EntityList.Find(i => i.EntityID == EntityID);
			if (entity != null)
			{
				Entity = entity;
				SetID();  // id (from saved ids) may change based on parent info
				Relationship relationship = entity.RelationshipList.Find(i => i.RelationshipID == RelationshipID);
				if (relationship != null)
				{
					if (relationship != this)
					{
						entity.RelationshipList.Remove(relationship);
						entity.RelationshipList.Add(this);
					}
				}
				else
				{
					entity.RelationshipList.Add(this);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds the current item to the solution, if it is valid
		/// and not already present in the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		///--------------------------------------------------------------------------------
		public static void AddCurrentItemToSolution(Solution solutionContext, ITemplate templateContext, int lineNumber)
		{
			if (solutionContext.CurrentRelationship != null)
			{
				string validationErrors = solutionContext.CurrentRelationship.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentRelationship, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentRelationship.Solution = solutionContext;
				solutionContext.CurrentRelationship.AddToParent();
				Relationship existingItem = solutionContext.RelationshipList.Find(i => i.RelationshipID == solutionContext.CurrentRelationship.RelationshipID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentRelationship.AssignProperty("RelationshipID", solutionContext.CurrentRelationship.RelationshipID);
					solutionContext.CurrentRelationship.ReverseInstance.ResetModified(false);
					solutionContext.RelationshipList.Add(solutionContext.CurrentRelationship);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Relationship();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentRelationship, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("RelationshipID", existingItem.RelationshipID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentRelationship = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Relationship item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentRelationship != null)
			{
				Relationship existingItem = solutionContext.RelationshipList.Find(i => i.RelationshipID == solutionContext.CurrentRelationship.RelationshipID);
				if (existingItem != null)
				{
					solutionContext.RelationshipList.Remove(solutionContext.CurrentRelationship);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Relationship instance from an xml file.</summary>
		///
		/// <param name="inputFilePath">The path of the file to load from.</param>
		///--------------------------------------------------------------------------------
		public override void Load(string inputFilePath)
		{
			base.Load(inputFilePath);
			ResetLoaded(true);
			ResetModified(false);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method saves the Relationship instance to an xml file.</summary>
		///
		/// <param name="inputFilePath">The path of the file to save to.</param>
		///--------------------------------------------------------------------------------
		public override void Save(string inputFilePath)
		{
			base.Save(inputFilePath);
			ResetLoaded(true);
			ResetModified(false);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsLoaded state for the instance.</summary>
		///
		/// <param name="isLoaded">The reset value for the IsLoaded property.</param>
		///--------------------------------------------------------------------------------
		public override void ResetLoaded(bool isLoaded)
		{
			_isLoaded = isLoaded;
			if (_relationshipPropertyList != null) _relationshipPropertyList.ResetLoaded(isLoaded);
			if (_propertyRelationshipList != null) _propertyRelationshipList.ResetLoaded(isLoaded);
			if (_methodRelationshipList != null) _methodRelationshipList.ResetLoaded(isLoaded);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsModified state for the instance.</summary>
		///
		/// <param name="isLoaded">The reset value for the IsModified property.</param>
		///--------------------------------------------------------------------------------
		public override void ResetModified(bool isModified)
		{
			base.ResetModified(isModified);
			_isModified = isModified;
			if (_relationshipPropertyList != null) _relationshipPropertyList.ResetModified(isModified);
			if (_propertyRelationshipList != null) _propertyRelationshipList.ResetModified(isModified);
			if (_methodRelationshipList != null) _methodRelationshipList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Relationship(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Relationship instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Relationship(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Relationship instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="relationshipID">The input value for RelationshipID.</param>
		///--------------------------------------------------------------------------------
		public Relationship(Guid relationshipID)
		{
			RelationshipID = relationshipID;
		}
		#endregion "Constructors"
	}
}