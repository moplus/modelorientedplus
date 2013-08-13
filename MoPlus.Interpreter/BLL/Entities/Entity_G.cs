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
	/// specific Entity instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/3/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="Entity")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Entity : BusinessObjectBase
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
			
			error = GetValidationError("EntityName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("EntityTypeCode");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IdentifierTypeCode");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("FeatureID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("BaseEntityID");
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
				case "_entityName":
				case "EntityName":
					error = ValidateEntityName();
					break;
				case "_entityTypeCode":
				case "EntityTypeCode":
					error = ValidateEntityTypeCode();
					break;
				case "_identifierTypeCode":
				case "IdentifierTypeCode":
					error = ValidateIdentifierTypeCode();
					break;
				case "_featureID":
				case "FeatureID":
					error = ValidateFeatureID();
					break;
				case "_baseEntityID":
				case "BaseEntityID":
					error = ValidateBaseEntityID();
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
		/// <summary>This method validates EntityName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateEntityName()
		{
			if (!Regex.IsMatch(EntityName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "EntityName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates EntityTypeCode and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateEntityTypeCode()
		{
			if (EntityTypeCode <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "EntityTypeCode");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IdentifierTypeCode and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentifierTypeCode()
		{
			if (IdentifierTypeCode <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "IdentifierTypeCode");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates FeatureID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateFeatureID()
		{
			if (FeatureID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "FeatureID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates BaseEntityID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateBaseEntityID()
		{
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
		
		private Entity _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Entity ForwardInstance
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
		
		private Entity _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Entity ReverseInstance
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
				return EntityID;
			}
			set
			{
				EntityID = value;
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
				return EntityName;
			}
			set
			{
				EntityName = value;
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
				return SourceEntity.EntityName;
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
					if (!String.IsNullOrEmpty(FeatureName))
					{
						_displayName = FeatureName + "." + EntityName;
					}
					else
					{
						_displayName = EntityName;
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
					if (Feature != null)
					{
						_defaultSourceName = Feature.DefaultSourceName + "." + DefaultSourcePrefix + SourceEntity.EntityName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceEntity.EntityName;
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
		public Entity SourceEntity
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
		/// <summary>This property gets/sets the OldEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldEntityID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldEntityTypeCode of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int OldEntityTypeCode { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldIdentifierTypeCode of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int OldIdentifierTypeCode { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldFeatureID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldFeatureID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldBaseEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldBaseEntityID { get; set; }
		
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
		
		protected string _entityName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EntityName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string EntityName
		{
			get
			{
				return _entityName;
			}
			set
			{
				if (_entityName != value)
				{
					_entityName = value;
					_isModified = true;
					base.OnPropertyChanged("EntityName");
				}
			}
		}
		
		protected int _entityTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int EntityTypeCode
		{
			get
			{
				return _entityTypeCode;
			}
			set
			{
				if (_entityTypeCode != value)
				{
					_entityTypeCode = value;
					_isModified = true;
					base.OnPropertyChanged("EntityTypeCode");
				}
			}
		}
		
		protected int _identifierTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int IdentifierTypeCode
		{
			get
			{
				return _identifierTypeCode;
			}
			set
			{
				if (_identifierTypeCode != value)
				{
					_identifierTypeCode = value;
					_isModified = true;
					base.OnPropertyChanged("IdentifierTypeCode");
				}
			}
		}
		
		protected Guid _featureID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FeatureID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid FeatureID
		{
			get
			{
				return _featureID;
			}
			set
			{
				if (_featureID != value)
				{
					_featureID = value;
					_isModified = true;
					base.OnPropertyChanged("FeatureID");
				}
			}
		}
		
		protected Guid? _baseEntityID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BaseEntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? BaseEntityID
		{
			get
			{
				return _baseEntityID;
			}
			set
			{
				if (_baseEntityID != value)
				{
					_baseEntityID = value;
					_isModified = true;
					base.OnPropertyChanged("BaseEntityID");
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
		
		protected string _featureName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the FeatureName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string FeatureName
		{
			get
			{
				return _featureName;
			}
		}
		
		protected string _entityTypeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityTypeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string EntityTypeName
		{
			get
			{
				return _entityTypeName;
			}
		}
		
		protected string _identifierTypeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the IdentifierTypeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string IdentifierTypeName
		{
			get
			{
				return _identifierTypeName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Property> _propertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Property> PropertyList
		{
			get
			{
				if (_propertyList == null)
				{
					_propertyList = new EnterpriseDataObjectList<BLL.Entities.Property>();
				}
				return _propertyList;
			}
			set
			{
				if (_propertyList == null || _propertyList.Equals(value) == false)
				{
					_propertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyList")]
		[XmlArrayItem(typeof(BLL.Entities.Property), ElementName = "Property")]
		[DataMember(Name = "PropertyList")]
		[DataArrayItem(ElementName = "PropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Property> _S_PropertyList
		{
			get
			{
				return _propertyList;
			}
			set
			{
				_propertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Collection> _collectionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Collection> CollectionList
		{
			get
			{
				if (_collectionList == null)
				{
					_collectionList = new EnterpriseDataObjectList<BLL.Entities.Collection>();
				}
				return _collectionList;
			}
			set
			{
				if (_collectionList == null || _collectionList.Equals(value) == false)
				{
					_collectionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "CollectionList")]
		[XmlArrayItem(typeof(BLL.Entities.Collection), ElementName = "Collection")]
		[DataMember(Name = "CollectionList")]
		[DataArrayItem(ElementName = "CollectionList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Collection> _S_CollectionList
		{
			get
			{
				return _collectionList;
			}
			set
			{
				_collectionList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.PropertyReference> _propertyReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> PropertyReferenceList
		{
			get
			{
				if (_propertyReferenceList == null)
				{
					_propertyReferenceList = new EnterpriseDataObjectList<BLL.Entities.PropertyReference>();
				}
				return _propertyReferenceList;
			}
			set
			{
				if (_propertyReferenceList == null || _propertyReferenceList.Equals(value) == false)
				{
					_propertyReferenceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyReferenceList")]
		[XmlArrayItem(typeof(BLL.Entities.PropertyReference), ElementName = "PropertyReference")]
		[DataMember(Name = "PropertyReferenceList")]
		[DataArrayItem(ElementName = "PropertyReferenceList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> _S_PropertyReferenceList
		{
			get
			{
				return _propertyReferenceList;
			}
			set
			{
				_propertyReferenceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Parameter> _referencedParameterList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Parameter> ReferencedParameterList
		{
			get
			{
				if (_referencedParameterList == null)
				{
					_referencedParameterList = new EnterpriseDataObjectList<BLL.Entities.Parameter>();
				}
				return _referencedParameterList;
			}
			set
			{
				if (_referencedParameterList == null || _referencedParameterList.Equals(value) == false)
				{
					_referencedParameterList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ReferencedParameterList")]
		[XmlArrayItem(typeof(BLL.Entities.Parameter), ElementName = "Parameter")]
		[DataMember(Name = "ReferencedParameterList")]
		[DataArrayItem(ElementName = "ReferencedParameterList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Parameter> _S_ReferencedParameterList
		{
			get
			{
				return _referencedParameterList;
			}
			set
			{
				_referencedParameterList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.PropertyReference> _referencedPropertyReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> ReferencedPropertyReferenceList
		{
			get
			{
				if (_referencedPropertyReferenceList == null)
				{
					_referencedPropertyReferenceList = new EnterpriseDataObjectList<BLL.Entities.PropertyReference>();
				}
				return _referencedPropertyReferenceList;
			}
			set
			{
				if (_referencedPropertyReferenceList == null || _referencedPropertyReferenceList.Equals(value) == false)
				{
					_referencedPropertyReferenceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ReferencedPropertyReferenceList")]
		[XmlArrayItem(typeof(BLL.Entities.PropertyReference), ElementName = "PropertyReference")]
		[DataMember(Name = "ReferencedPropertyReferenceList")]
		[DataArrayItem(ElementName = "ReferencedPropertyReferenceList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> _S_ReferencedPropertyReferenceList
		{
			get
			{
				return _referencedPropertyReferenceList;
			}
			set
			{
				_referencedPropertyReferenceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.EntityReference> _entityReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.EntityReference> EntityReferenceList
		{
			get
			{
				if (_entityReferenceList == null)
				{
					_entityReferenceList = new EnterpriseDataObjectList<BLL.Entities.EntityReference>();
				}
				return _entityReferenceList;
			}
			set
			{
				if (_entityReferenceList == null || _entityReferenceList.Equals(value) == false)
				{
					_entityReferenceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "EntityReferenceList")]
		[XmlArrayItem(typeof(BLL.Entities.EntityReference), ElementName = "EntityReference")]
		[DataMember(Name = "EntityReferenceList")]
		[DataArrayItem(ElementName = "EntityReferenceList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.EntityReference> _S_EntityReferenceList
		{
			get
			{
				return _entityReferenceList;
			}
			set
			{
				_entityReferenceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Method> _methodList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Method> MethodList
		{
			get
			{
				if (_methodList == null)
				{
					_methodList = new EnterpriseDataObjectList<BLL.Entities.Method>();
				}
				return _methodList;
			}
			set
			{
				if (_methodList == null || _methodList.Equals(value) == false)
				{
					_methodList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "MethodList")]
		[XmlArrayItem(typeof(BLL.Entities.Method), ElementName = "Method")]
		[DataMember(Name = "MethodList")]
		[DataArrayItem(ElementName = "MethodList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Method> _S_MethodList
		{
			get
			{
				return _methodList;
			}
			set
			{
				_methodList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Index> _indexList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Index> IndexList
		{
			get
			{
				if (_indexList == null)
				{
					_indexList = new EnterpriseDataObjectList<BLL.Entities.Index>();
				}
				return _indexList;
			}
			set
			{
				if (_indexList == null || _indexList.Equals(value) == false)
				{
					_indexList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "IndexList")]
		[XmlArrayItem(typeof(BLL.Entities.Index), ElementName = "Index")]
		[DataMember(Name = "IndexList")]
		[DataArrayItem(ElementName = "IndexList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Index> _S_IndexList
		{
			get
			{
				return _indexList;
			}
			set
			{
				_indexList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Relationship> _relationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Relationship> RelationshipList
		{
			get
			{
				if (_relationshipList == null)
				{
					_relationshipList = new EnterpriseDataObjectList<BLL.Entities.Relationship>();
				}
				return _relationshipList;
			}
			set
			{
				if (_relationshipList == null || _relationshipList.Equals(value) == false)
				{
					_relationshipList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "RelationshipList")]
		[XmlArrayItem(typeof(BLL.Entities.Relationship), ElementName = "Relationship")]
		[DataMember(Name = "RelationshipList")]
		[DataArrayItem(ElementName = "RelationshipList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Relationship> _S_RelationshipList
		{
			get
			{
				return _relationshipList;
			}
			set
			{
				_relationshipList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.StateModel> _stateModelList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.StateModel> StateModelList
		{
			get
			{
				if (_stateModelList == null)
				{
					_stateModelList = new EnterpriseDataObjectList<BLL.Entities.StateModel>();
				}
				return _stateModelList;
			}
			set
			{
				if (_stateModelList == null || _stateModelList.Equals(value) == false)
				{
					_stateModelList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "StateModelList")]
		[XmlArrayItem(typeof(BLL.Entities.StateModel), ElementName = "StateModel")]
		[DataMember(Name = "StateModelList")]
		[DataArrayItem(ElementName = "StateModelList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.StateModel> _S_StateModelList
		{
			get
			{
				return _stateModelList;
			}
			set
			{
				_stateModelList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Diagrams.DiagramEntity> _diagramEntityList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Diagrams.DiagramEntity> DiagramEntityList
		{
			get
			{
				if (_diagramEntityList == null)
				{
					_diagramEntityList = new EnterpriseDataObjectList<BLL.Diagrams.DiagramEntity>();
				}
				return _diagramEntityList;
			}
			set
			{
				if (_diagramEntityList == null || _diagramEntityList.Equals(value) == false)
				{
					_diagramEntityList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "DiagramEntityList")]
		[XmlArrayItem(typeof(BLL.Diagrams.DiagramEntity), ElementName = "DiagramEntity")]
		[DataMember(Name = "DiagramEntityList")]
		[DataArrayItem(ElementName = "DiagramEntityList")]
		public virtual EnterpriseDataObjectList<BLL.Diagrams.DiagramEntity> _S_DiagramEntityList
		{
			get
			{
				return _diagramEntityList;
			}
			set
			{
				_diagramEntityList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Relationship> _referencedRelationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Relationship> ReferencedRelationshipList
		{
			get
			{
				if (_referencedRelationshipList == null)
				{
					_referencedRelationshipList = new EnterpriseDataObjectList<BLL.Entities.Relationship>();
				}
				return _referencedRelationshipList;
			}
			set
			{
				if (_referencedRelationshipList == null || _referencedRelationshipList.Equals(value) == false)
				{
					_referencedRelationshipList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ReferencedRelationshipList")]
		[XmlArrayItem(typeof(BLL.Entities.Relationship), ElementName = "Relationship")]
		[DataMember(Name = "ReferencedRelationshipList")]
		[DataArrayItem(ElementName = "ReferencedRelationshipList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Relationship> _S_ReferencedRelationshipList
		{
			get
			{
				return _referencedRelationshipList;
			}
			set
			{
				_referencedRelationshipList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.EntityReference> _referencedEntityReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.EntityReference> ReferencedEntityReferenceList
		{
			get
			{
				if (_referencedEntityReferenceList == null)
				{
					_referencedEntityReferenceList = new EnterpriseDataObjectList<BLL.Entities.EntityReference>();
				}
				return _referencedEntityReferenceList;
			}
			set
			{
				if (_referencedEntityReferenceList == null || _referencedEntityReferenceList.Equals(value) == false)
				{
					_referencedEntityReferenceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ReferencedEntityReferenceList")]
		[XmlArrayItem(typeof(BLL.Entities.EntityReference), ElementName = "EntityReference")]
		[DataMember(Name = "ReferencedEntityReferenceList")]
		[DataArrayItem(ElementName = "ReferencedEntityReferenceList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.EntityReference> _S_ReferencedEntityReferenceList
		{
			get
			{
				return _referencedEntityReferenceList;
			}
			set
			{
				_referencedEntityReferenceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Collection> _referencedCollectionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Collection> ReferencedCollectionList
		{
			get
			{
				if (_referencedCollectionList == null)
				{
					_referencedCollectionList = new EnterpriseDataObjectList<BLL.Entities.Collection>();
				}
				return _referencedCollectionList;
			}
			set
			{
				if (_referencedCollectionList == null || _referencedCollectionList.Equals(value) == false)
				{
					_referencedCollectionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ReferencedCollectionList")]
		[XmlArrayItem(typeof(BLL.Entities.Collection), ElementName = "Collection")]
		[DataMember(Name = "ReferencedCollectionList")]
		[DataArrayItem(ElementName = "ReferencedCollectionList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Collection> _S_ReferencedCollectionList
		{
			get
			{
				return _referencedCollectionList;
			}
			set
			{
				_referencedCollectionList = value;
			}
		}
		
		protected BLL.Solutions.Feature _feature = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Feature.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Solutions.Feature Feature
		{
			get
			{
				return _feature;
			}
			set
			{
				if (value != null)
				{
					_featureName = value.FeatureName;
					if (_feature != null && _feature.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					FeatureID = value.FeatureID;
				}
				_feature = value;
			}
		}
		
		protected BLL.Config.EntityType _entityType = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the EntityType.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Config.EntityType EntityType
		{
			get
			{
				return _entityType;
			}
			set
			{
				if (value != null)
				{
					_entityTypeName = value.EntityTypeName;
					if (_entityType != null && _entityType.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					EntityTypeCode = value.EntityTypeCode;
				}
				_entityType = value;
			}
		}
		
		protected BLL.Config.IdentifierType _identifierType = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the IdentifierType.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Config.IdentifierType IdentifierType
		{
			get
			{
				return _identifierType;
			}
			set
			{
				if (value != null)
				{
					_identifierTypeName = value.IdentifierTypeName;
					if (_identifierType != null && _identifierType.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					IdentifierTypeCode = value.IdentifierTypeCode;
				}
				_identifierType = value;
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
				return "EntityID";
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
				return EntityID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					EntityID = primaryKeyValues[0].GetGuid();
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
				if (_propertyList != null && _propertyList.IsModified == true) return true;
				if (_collectionList != null && _collectionList.IsModified == true) return true;
				if (_propertyReferenceList != null && _propertyReferenceList.IsModified == true) return true;
				if (_referencedParameterList != null && _referencedParameterList.IsModified == true) return true;
				if (_referencedPropertyReferenceList != null && _referencedPropertyReferenceList.IsModified == true) return true;
				if (_entityReferenceList != null && _entityReferenceList.IsModified == true) return true;
				if (_methodList != null && _methodList.IsModified == true) return true;
				if (_indexList != null && _indexList.IsModified == true) return true;
				if (_relationshipList != null && _relationshipList.IsModified == true) return true;
				if (_stateModelList != null && _stateModelList.IsModified == true) return true;
				if (_diagramEntityList != null && _diagramEntityList.IsModified == true) return true;
				if (_referencedRelationshipList != null && _referencedRelationshipList.IsModified == true) return true;
				if (_referencedEntityReferenceList != null && _referencedEntityReferenceList.IsModified == true) return true;
				if (_referencedCollectionList != null && _referencedCollectionList.IsModified == true) return true;
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
				ReverseInstance = new Entity();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Entity();
				ForwardInstance.EntityID = EntityID;
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
			foreach (Property property in PropertyList)
			{
				property.AddItemToUsedTags(usedTags);
			}
			foreach (Collection collection in CollectionList)
			{
				collection.AddItemToUsedTags(usedTags);
			}
			foreach (PropertyReference propertyReference in PropertyReferenceList)
			{
				propertyReference.AddItemToUsedTags(usedTags);
			}
			foreach (EntityReference entityReference in EntityReferenceList)
			{
				entityReference.AddItemToUsedTags(usedTags);
			}
			foreach (Method method in MethodList)
			{
				method.AddItemToUsedTags(usedTags);
			}
			foreach (Index index in IndexList)
			{
				index.AddItemToUsedTags(usedTags);
			}
			foreach (Relationship relationship in RelationshipList)
			{
				relationship.AddItemToUsedTags(usedTags);
			}
			foreach (StateModel stateModel in StateModelList)
			{
				stateModel.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputEntity">The entity to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Entity inputEntity)
		{
			if (EntityName.GetString() != inputEntity.EntityName.GetString()) return false;
			if (EntityTypeCode.GetInt() != inputEntity.EntityTypeCode.GetInt()) return false;
			if (IdentifierTypeCode.GetInt() != inputEntity.IdentifierTypeCode.GetInt()) return false;
			if (FeatureID.GetGuid() != inputEntity.FeatureID.GetGuid()) return false;
			if (BaseEntityID.GetGuid() != inputEntity.BaseEntityID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputEntity.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputEntity.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputEntity">The entity to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Entity inputEntity)
		{
			if (inputEntity == null) return true;
			if (inputEntity.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputEntity.EntityName)) return false;
			if (EntityTypeCode != DefaultValue.Int) return false;
			if (IdentifierTypeCode != DefaultValue.Int) return false;
			if (FeatureID != inputEntity.FeatureID) return false;
			if (BaseEntityID != inputEntity.BaseEntityID) return false;
			if (IsAutoUpdated != inputEntity.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputEntity.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputEntity">The entity to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Entity inputEntity)
		{
			EntityName = inputEntity.EntityName;
			EntityTypeCode = inputEntity.EntityTypeCode;
			IdentifierTypeCode = inputEntity.IdentifierTypeCode;
			FeatureID = inputEntity.FeatureID;
			BaseEntityID = inputEntity.BaseEntityID;
			IsAutoUpdated = inputEntity.IsAutoUpdated;
			Description = inputEntity.Description;
			
			#region protected
			SqlTable = inputEntity.SqlTable;
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public virtual void SetID()
		{
			if (Solution.UsedModelIDs[DefaultSourceName].GetGuid() != Guid.Empty)
			{
				EntityID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (EntityID == Guid.Empty)
				{
					EntityID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = EntityID;
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
			Feature = null;
			EntityType = null;
			IdentifierType = null;
			Solution = null;
			if (_propertyList != null)
			{
				foreach (Property item in PropertyList)
				{
					item.Dispose();
				}
				PropertyList.Clear();
				PropertyList = null;
			}
			if (_collectionList != null)
			{
				foreach (Collection item in CollectionList)
				{
					item.Dispose();
				}
				CollectionList.Clear();
				CollectionList = null;
			}
			if (_propertyReferenceList != null)
			{
				foreach (PropertyReference item in PropertyReferenceList)
				{
					item.Dispose();
				}
				PropertyReferenceList.Clear();
				PropertyReferenceList = null;
			}
			if (_referencedParameterList != null)
			{
				foreach (Parameter item in ReferencedParameterList)
				{
					item.Dispose();
				}
				ReferencedParameterList.Clear();
				ReferencedParameterList = null;
			}
			if (_referencedPropertyReferenceList != null)
			{
				foreach (PropertyReference item in ReferencedPropertyReferenceList)
				{
					item.Dispose();
				}
				ReferencedPropertyReferenceList.Clear();
				ReferencedPropertyReferenceList = null;
			}
			if (_entityReferenceList != null)
			{
				foreach (EntityReference item in EntityReferenceList)
				{
					item.Dispose();
				}
				EntityReferenceList.Clear();
				EntityReferenceList = null;
			}
			if (_methodList != null)
			{
				foreach (Method item in MethodList)
				{
					item.Dispose();
				}
				MethodList.Clear();
				MethodList = null;
			}
			if (_indexList != null)
			{
				foreach (Index item in IndexList)
				{
					item.Dispose();
				}
				IndexList.Clear();
				IndexList = null;
			}
			if (_relationshipList != null)
			{
				foreach (Relationship item in RelationshipList)
				{
					item.Dispose();
				}
				RelationshipList.Clear();
				RelationshipList = null;
			}
			if (_stateModelList != null)
			{
				foreach (StateModel item in StateModelList)
				{
					item.Dispose();
				}
				StateModelList.Clear();
				StateModelList = null;
			}
			if (_diagramEntityList != null)
			{
				foreach (DiagramEntity item in DiagramEntityList)
				{
					item.Dispose();
				}
				DiagramEntityList.Clear();
				DiagramEntityList = null;
			}
			if (_referencedRelationshipList != null)
			{
				foreach (Relationship item in ReferencedRelationshipList)
				{
					item.Dispose();
				}
				ReferencedRelationshipList.Clear();
				ReferencedRelationshipList = null;
			}
			if (_referencedEntityReferenceList != null)
			{
				foreach (EntityReference item in ReferencedEntityReferenceList)
				{
					item.Dispose();
				}
				ReferencedEntityReferenceList.Clear();
				ReferencedEntityReferenceList = null;
			}
			if (_referencedCollectionList != null)
			{
				foreach (Collection item in ReferencedCollectionList)
				{
					item.Dispose();
				}
				ReferencedCollectionList.Clear();
				ReferencedCollectionList = null;
			}
			
			#region protected
			SqlTable = null;
			BaseEntity = null;
			if (_pathRelationships != null)
			{
				PathRelationships.Clear();
				PathRelationships = null;
			}
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
					ReverseInstance = new Entity();
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
			Guid previousFeatureID = FeatureID;

			// handle moving to customized feature
			if (FeatureID != previousFeatureID && previousFeatureID != Guid.Empty)
			{
				if (Feature != null)
				{
					Feature.EntityList.Remove(this);
				}
				Feature = Solution.FeatureList.FindByID(FeatureID);
				if (Feature != null)
				{
					Feature.EntityList.Add(this);
				}
				else
				{
					if (Solution.FeaturesToMerge != null)
					{
						Feature featureToMerge = Solution.FeaturesToMerge.FindByID(FeatureID);
						if (featureToMerge != null)
						{
							Feature mergedFeature = new Feature();
							mergedFeature.TransformDataFromObject(featureToMerge, null, false);
							Solution.FeaturesToMerge.Remove(featureToMerge);
							Solution.FeatureList.Add(mergedFeature);
							Feature = mergedFeature;
							mergedFeature.EntityList.Add(this);
						}
					}
				}
			}
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
			newItem.ItemID = EntityID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Entity GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Entity forwardItem = new Entity();
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
				forwardItem.EntityID = EntityID;
			}
			foreach (Property item in PropertyList)
			{
				item.Entity = this;
				Property forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Collection item in CollectionList)
			{
				item.Entity = this;
				Collection forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.CollectionList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (PropertyReference item in PropertyReferenceList)
			{
				item.Entity = this;
				PropertyReference forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyReferenceList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (EntityReference item in EntityReferenceList)
			{
				item.Entity = this;
				EntityReference forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.EntityReferenceList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Method item in MethodList)
			{
				item.Entity = this;
				Method forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.MethodList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Index item in IndexList)
			{
				item.Entity = this;
				Index forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.IndexList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Relationship item in RelationshipList)
			{
				item.Entity = this;
				Relationship forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.RelationshipList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (StateModel item in StateModelList)
			{
				item.Entity = this;
				StateModel forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.StateModelList.Add(forwardChildItem);
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
			if (forwardItem.BaseEntityID != Guid.Empty)
			{
				if (forwardItem.BaseEntityID != null)
				{
					forwardItem.BaseEntity = Solution.EntityList.FindByID((Guid)forwardItem.BaseEntityID);
				}
				if (forwardItem.BaseEntity != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.BaseEntity.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.BaseEntity.CreateIDReference());
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
				if (modelContext is Entity)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Feature)
				{
					Feature parent = modelContext as Feature;
					if (parent.EntityList.Count > 0)
					{
						return parent.EntityList[DataHelper.GetRandomInt(0, parent.EntityList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.EntityList.Count > 0)
			{
				return solutionContext.EntityList[DataHelper.GetRandomInt(0, solutionContext.EntityList.Count - 1)];
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
				if (nodeContext is Feature)
				{
					return (nodeContext as Feature).EntityList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).EntityList;
				}
				
				#region protected
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
			return Feature;
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
			if (solutionContext.CurrentEntity != null)
			{
				string validationErrors = solutionContext.CurrentEntity.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentEntity, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				Entity existingItem = solutionContext.EntityList.Find(i => i.EntityID == solutionContext.CurrentEntity.EntityID);
				if (existingItem == null)
				{
					#region protected
					Guid previousFeatureID = solutionContext.CurrentEntity.FeatureID;
					#endregion protected
					
					solutionContext.CurrentEntity.Solution = solutionContext;
					Feature feature = solutionContext.FeatureList.Find(i => i.FeatureID == solutionContext.CurrentEntity.FeatureID);
					if (feature != null)
					{
						solutionContext.CurrentEntity.Feature = feature;
						feature.EntityList.Add(solutionContext.CurrentEntity);
					}
					solutionContext.CurrentEntity.SetID();
					solutionContext.CurrentEntity.AssignProperty("EntityID", solutionContext.CurrentEntity.EntityID);
					Entity foundItem = solutionContext.EntitiesToMerge.Find(i => i.EntityID == solutionContext.CurrentEntity.EntityID);
					if (foundItem != null)
					{
						Entity forwardItem = new Entity();
						forwardItem.TransformDataFromObject(foundItem, null, false);
						solutionContext.CurrentEntity.ForwardInstance = forwardItem;
						solutionContext.CurrentEntity.TransformDataFromObject(forwardItem, null, false, true);
						solutionContext.EntitiesToMerge.Remove(foundItem);
					}
					
					#region protected

						// handle moving of customized feature
						if (solutionContext.CurrentEntity.FeatureID != previousFeatureID && previousFeatureID != Guid.Empty)
						{
							if (feature != null)
							{
								feature.EntityList.Remove(solutionContext.CurrentEntity);
							}
							solutionContext.CurrentEntity.Feature = solutionContext.FeatureList.FindByID(solutionContext.CurrentEntity.FeatureID);
							if (solutionContext.CurrentEntity.Feature != null)
							{
								solutionContext.CurrentEntity.Feature.EntityList.Add(solutionContext.CurrentEntity);
							}
							else
							{
								if (solutionContext.FeaturesToMerge != null)
								{
									Feature featureToMerge = solutionContext.FeaturesToMerge.FindByID(solutionContext.CurrentEntity.FeatureID);
									if (featureToMerge != null)
									{
										Feature mergedFeature = new Feature();
										mergedFeature.TransformDataFromObject(featureToMerge, null, false);
										solutionContext.FeaturesToMerge.Remove(featureToMerge);
										solutionContext.FeatureList.Add(mergedFeature);
										solutionContext.CurrentEntity.Feature = mergedFeature;
										mergedFeature.EntityList.Add(solutionContext.CurrentEntity);
									}
								}
							}
						}
						#endregion protected
					
					solutionContext.EntityList.Add(solutionContext.CurrentEntity);
					solutionContext.CurrentEntity.ReverseInstance.ResetModified(false);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Entity item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentEntity != null)
			{
				Entity existingItem = solutionContext.EntityList.Find(i => i.EntityID == solutionContext.CurrentEntity.EntityID);
				if (existingItem != null)
				{
					solutionContext.EntityList.Remove(solutionContext.CurrentEntity);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Entity instance from an xml file.</summary>
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
		/// <summary>This method saves the Entity instance to an xml file.</summary>
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
			if (_propertyList != null) _propertyList.ResetLoaded(isLoaded);
			if (_collectionList != null) _collectionList.ResetLoaded(isLoaded);
			if (_propertyReferenceList != null) _propertyReferenceList.ResetLoaded(isLoaded);
			if (_referencedParameterList != null) _referencedParameterList.ResetLoaded(isLoaded);
			if (_referencedPropertyReferenceList != null) _referencedPropertyReferenceList.ResetLoaded(isLoaded);
			if (_entityReferenceList != null) _entityReferenceList.ResetLoaded(isLoaded);
			if (_methodList != null) _methodList.ResetLoaded(isLoaded);
			if (_indexList != null) _indexList.ResetLoaded(isLoaded);
			if (_relationshipList != null) _relationshipList.ResetLoaded(isLoaded);
			if (_stateModelList != null) _stateModelList.ResetLoaded(isLoaded);
			if (_diagramEntityList != null) _diagramEntityList.ResetLoaded(isLoaded);
			if (_referencedRelationshipList != null) _referencedRelationshipList.ResetLoaded(isLoaded);
			if (_referencedEntityReferenceList != null) _referencedEntityReferenceList.ResetLoaded(isLoaded);
			if (_referencedCollectionList != null) _referencedCollectionList.ResetLoaded(isLoaded);
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
			if (_propertyList != null) _propertyList.ResetModified(isModified);
			if (_collectionList != null) _collectionList.ResetModified(isModified);
			if (_propertyReferenceList != null) _propertyReferenceList.ResetModified(isModified);
			if (_referencedParameterList != null) _referencedParameterList.ResetModified(isModified);
			if (_referencedPropertyReferenceList != null) _referencedPropertyReferenceList.ResetModified(isModified);
			if (_entityReferenceList != null) _entityReferenceList.ResetModified(isModified);
			if (_methodList != null) _methodList.ResetModified(isModified);
			if (_indexList != null) _indexList.ResetModified(isModified);
			if (_relationshipList != null) _relationshipList.ResetModified(isModified);
			if (_stateModelList != null) _stateModelList.ResetModified(isModified);
			if (_diagramEntityList != null) _diagramEntityList.ResetModified(isModified);
			if (_referencedRelationshipList != null) _referencedRelationshipList.ResetModified(isModified);
			if (_referencedEntityReferenceList != null) _referencedEntityReferenceList.ResetModified(isModified);
			if (_referencedCollectionList != null) _referencedCollectionList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Entity(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Entity instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Entity(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Entity instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="entityID">The input value for EntityID.</param>
		///--------------------------------------------------------------------------------
		public Entity(Guid entityID)
		{
			EntityID = entityID;
		}
		#endregion "Constructors"
	}
}