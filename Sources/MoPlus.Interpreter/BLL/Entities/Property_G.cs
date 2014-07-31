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
	/// specific Property instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Property")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Property : Solutions.PropertyBase
	{
		#region "Validation"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns validation errors for the input item.</param>
		/// 
		/// <returns>Validation errors (null by default).</returns>
		///--------------------------------------------------------------------------------
		public override string GetValidationErrors()
		{
			StringBuilder errors = new StringBuilder();
			string error = null;
			
			error = GetValidationError("PropertyName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("EntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsPrimaryKeyMember");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsForeignKeyMember");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DataTypeCode");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Length");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Precision");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Scale");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("InitialValue");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Identity");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IdentitySeed");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IdentityIncrement");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsNullable");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Order");
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
				case "_propertyName":
				case "PropertyName":
					error = ValidatePropertyName();
					break;
				case "_entityID":
				case "EntityID":
					error = ValidateEntityID();
					break;
				case "_isPrimaryKeyMember":
				case "IsPrimaryKeyMember":
					error = ValidateIsPrimaryKeyMember();
					break;
				case "_isForeignKeyMember":
				case "IsForeignKeyMember":
					error = ValidateIsForeignKeyMember();
					break;
				case "_dataTypeCode":
				case "DataTypeCode":
					error = ValidateDataTypeCode();
					break;
				case "_length":
				case "Length":
					error = ValidateLength();
					break;
				case "_precision":
				case "Precision":
					error = ValidatePrecision();
					break;
				case "_scale":
				case "Scale":
					error = ValidateScale();
					break;
				case "_initialValue":
				case "InitialValue":
					error = ValidateInitialValue();
					break;
				case "_identity":
				case "Identity":
					error = ValidateIdentity();
					break;
				case "_identitySeed":
				case "IdentitySeed":
					error = ValidateIdentitySeed();
					break;
				case "_identityIncrement":
				case "IdentityIncrement":
					error = ValidateIdentityIncrement();
					break;
				case "_isNullable":
				case "IsNullable":
					error = ValidateIsNullable();
					break;
				case "_order":
				case "Order":
					error = ValidateOrder();
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
		/// <summary>This method validates PropertyName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePropertyName()
		{
			if (!Regex.IsMatch(PropertyName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "PropertyName");
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
		/// <summary>This method validates IsPrimaryKeyMember and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsPrimaryKeyMember()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsForeignKeyMember and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsForeignKeyMember()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DataTypeCode and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDataTypeCode()
		{
			if (DataTypeCode <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "DataTypeCode");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Length and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateLength()
		{
			if (Length != null && Length < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "Length");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Precision and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePrecision()
		{
			if (Precision != null && Precision < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "Precision");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Scale and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateScale()
		{
			if (Scale != null && Scale < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "Scale");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates InitialValue and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateInitialValue()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Identity and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentity()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IdentitySeed and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentitySeed()
		{
			if (IdentitySeed != null && IdentitySeed < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "IdentitySeed");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IdentityIncrement and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentityIncrement()
		{
			if (IdentityIncrement != null && IdentityIncrement < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "IdentityIncrement");
			}
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private Property _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Property ForwardInstance
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
		
		private Property _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Property ReverseInstance
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
				return PropertyID;
			}
			set
			{
				PropertyID = value;
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
				return PropertyName;
			}
			set
			{
				PropertyName = value;
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
				return SourceProperty.PropertyName;
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
						_displayName = EntityName + "." + PropertyName;
					}
					else
					{
						_displayName = PropertyName;
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
		public override string DefaultSourceName
		{
			get
			{
				if (_defaultSourceName == null)
				{
					if (Entity != null)
					{
						_defaultSourceName = Entity.DefaultSourceName + "." + DefaultSourcePrefix + SourceProperty.PropertyName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceProperty.PropertyName;
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
		public Property SourceProperty
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
		/// <summary>This property gets/sets the OldDataTypeCode of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int OldDataTypeCode { get; set; }
		
		
		protected string _propertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string PropertyName
		{
			get
			{
				return _propertyName;
			}
			set
			{
				if (_propertyName != value)
				{
					_propertyName = value;
					_isModified = true;
					base.OnPropertyChanged("PropertyName");
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
		
		protected bool _isPrimaryKeyMember = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsPrimaryKeyMember.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsPrimaryKeyMember
		{
			get
			{
				return _isPrimaryKeyMember;
			}
			set
			{
				if (_isPrimaryKeyMember != value)
				{
					_isPrimaryKeyMember = value;
					_isModified = true;
					base.OnPropertyChanged("IsPrimaryKeyMember");
				}
			}
		}
		
		protected bool _isForeignKeyMember = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsForeignKeyMember.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsForeignKeyMember
		{
			get
			{
				return _isForeignKeyMember;
			}
			set
			{
				if (_isForeignKeyMember != value)
				{
					_isForeignKeyMember = value;
					_isModified = true;
					base.OnPropertyChanged("IsForeignKeyMember");
				}
			}
		}
		
		protected int _dataTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DataTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int DataTypeCode
		{
			get
			{
				return _dataTypeCode;
			}
			set
			{
				if (_dataTypeCode != value)
				{
					_dataTypeCode = value;
					_isModified = true;
					base.OnPropertyChanged("DataTypeCode");
				}
			}
		}
		
		protected int? _length = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Length.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual int? Length
		{
			get
			{
				return _length;
			}
			set
			{
				if (_length != value)
				{
					_length = value;
					_isModified = true;
					base.OnPropertyChanged("Length");
				}
			}
		}
		
		protected int? _precision = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Precision.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual int? Precision
		{
			get
			{
				return _precision;
			}
			set
			{
				if (_precision != value)
				{
					_precision = value;
					_isModified = true;
					base.OnPropertyChanged("Precision");
				}
			}
		}
		
		protected int? _scale = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Scale.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual int? Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (_scale != value)
				{
					_scale = value;
					_isModified = true;
					base.OnPropertyChanged("Scale");
				}
			}
		}
		
		protected string _initialValue = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the InitialValue.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string InitialValue
		{
			get
			{
				return _initialValue;
			}
			set
			{
				if (_initialValue != value)
				{
					_initialValue = value;
					_isModified = true;
					base.OnPropertyChanged("InitialValue");
				}
			}
		}
		
		protected bool? _identity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Identity.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? Identity
		{
			get
			{
				return _identity;
			}
			set
			{
				if (_identity != value)
				{
					_identity = value;
					_isModified = true;
					base.OnPropertyChanged("Identity");
				}
			}
		}
		
		protected long? _identitySeed = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IdentitySeed.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual long? IdentitySeed
		{
			get
			{
				return _identitySeed;
			}
			set
			{
				if (_identitySeed != value)
				{
					_identitySeed = value;
					_isModified = true;
					base.OnPropertyChanged("IdentitySeed");
				}
			}
		}
		
		protected long? _identityIncrement = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IdentityIncrement.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual long? IdentityIncrement
		{
			get
			{
				return _identityIncrement;
			}
			set
			{
				if (_identityIncrement != value)
				{
					_identityIncrement = value;
					_isModified = true;
					base.OnPropertyChanged("IdentityIncrement");
				}
			}
		}
		
		protected string _dataTypeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DataTypeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DataTypeName
		{
			get
			{
				return _dataTypeName;
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
		
		protected EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> _relationshipPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Property.</summary>
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
		
		protected EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> _referencedRelationshipPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Property.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> ReferencedRelationshipPropertyList
		{
			get
			{
				if (_referencedRelationshipPropertyList == null)
				{
					_referencedRelationshipPropertyList = new EnterpriseDataObjectList<BLL.Entities.RelationshipProperty>();
				}
				return _referencedRelationshipPropertyList;
			}
			set
			{
				if (_referencedRelationshipPropertyList == null || _referencedRelationshipPropertyList.Equals(value) == false)
				{
					_referencedRelationshipPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ReferencedRelationshipPropertyList")]
		[XmlArrayItem(typeof(BLL.Entities.RelationshipProperty), ElementName = "RelationshipProperty")]
		[DataMember(Name = "ReferencedRelationshipPropertyList")]
		[DataArrayItem(ElementName = "ReferencedRelationshipPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.RelationshipProperty> _S_ReferencedRelationshipPropertyList
		{
			get
			{
				return _referencedRelationshipPropertyList;
			}
			set
			{
				_referencedRelationshipPropertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.IndexProperty> _indexPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Property.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.IndexProperty> IndexPropertyList
		{
			get
			{
				if (_indexPropertyList == null)
				{
					_indexPropertyList = new EnterpriseDataObjectList<BLL.Entities.IndexProperty>();
				}
				return _indexPropertyList;
			}
			set
			{
				if (_indexPropertyList == null || _indexPropertyList.Equals(value) == false)
				{
					_indexPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "IndexPropertyList")]
		[XmlArrayItem(typeof(BLL.Entities.IndexProperty), ElementName = "IndexProperty")]
		[DataMember(Name = "IndexPropertyList")]
		[DataArrayItem(ElementName = "IndexPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.IndexProperty> _S_IndexPropertyList
		{
			get
			{
				return _indexPropertyList;
			}
			set
			{
				_indexPropertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.PropertyReference> _referencedPropertyReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Property.</summary>
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
		
		protected BLL.Config.DataType _dataType = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the DataType.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Config.DataType DataType
		{
			get
			{
				return _dataType;
			}
			set
			{
				if (value != null)
				{
					_dataTypeName = value.DataTypeName;
					if (_dataType != null && _dataType.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					DataTypeCode = value.DataTypeCode;
				}
				_dataType = value;
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
				if (_referencedRelationshipPropertyList != null && _referencedRelationshipPropertyList.IsModified == true) return true;
				if (_indexPropertyList != null && _indexPropertyList.IsModified == true) return true;
				if (_referencedPropertyReferenceList != null && _referencedPropertyReferenceList.IsModified == true) return true;
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
				ReverseInstance = new Property();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Property();
				ForwardInstance.PropertyID = PropertyID;
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
		public override void AddItemToUsedTags(NameObjectCollection usedTags)
		{
			AddTagsToUsedTags(usedTags);
			foreach (PropertyRelationship propertyRelationship in PropertyRelationshipList)
			{
				propertyRelationship.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputProperty">The property to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Property inputProperty)
		{
			if (PropertyName.GetString() != inputProperty.PropertyName.GetString()) return false;
			if (EntityID.GetGuid() != inputProperty.EntityID.GetGuid()) return false;
			if (IsPrimaryKeyMember.GetBool() != inputProperty.IsPrimaryKeyMember.GetBool()) return false;
			if (IsForeignKeyMember.GetBool() != inputProperty.IsForeignKeyMember.GetBool()) return false;
			if (DataTypeCode.GetInt() != inputProperty.DataTypeCode.GetInt()) return false;
			if (Length.GetInt() != inputProperty.Length.GetInt()) return false;
			if (Precision.GetInt() != inputProperty.Precision.GetInt()) return false;
			if (Scale.GetInt() != inputProperty.Scale.GetInt()) return false;
			if (InitialValue.GetString() != inputProperty.InitialValue.GetString()) return false;
			if (Identity.GetBool() != inputProperty.Identity.GetBool()) return false;
			if (IdentitySeed.GetLong() != inputProperty.IdentitySeed.GetLong()) return false;
			if (IdentityIncrement.GetLong() != inputProperty.IdentityIncrement.GetLong()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputProperty">The property to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Property inputProperty)
		{
			if (inputProperty == null) return true;
			if (inputProperty.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputProperty.PropertyName)) return false;
			if (EntityID != inputProperty.EntityID) return false;
			if (IsPrimaryKeyMember != inputProperty.IsPrimaryKeyMember) return false;
			if (IsForeignKeyMember != inputProperty.IsForeignKeyMember) return false;
			if (DataTypeCode != DefaultValue.Int) return false;
			if (Length != DefaultValue.Int) return false;
			if (Precision != DefaultValue.Int) return false;
			if (Scale != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputProperty.InitialValue)) return false;
			if (Identity != inputProperty.Identity) return false;
			if (IdentitySeed != DefaultValue.Int) return false;
			if (IdentityIncrement != DefaultValue.Int) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputProperty">The property to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Property inputProperty)
		{
			PropertyName = inputProperty.PropertyName;
			EntityID = inputProperty.EntityID;
			IsPrimaryKeyMember = inputProperty.IsPrimaryKeyMember;
			IsForeignKeyMember = inputProperty.IsForeignKeyMember;
			DataTypeCode = inputProperty.DataTypeCode;
			Length = inputProperty.Length;
			Precision = inputProperty.Precision;
			Scale = inputProperty.Scale;
			InitialValue = inputProperty.InitialValue;
			Identity = inputProperty.Identity;
			IdentitySeed = inputProperty.IdentitySeed;
			IdentityIncrement = inputProperty.IdentityIncrement;
			
			#region protected
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public override void SetID()
		{
			_defaultSourceName = null;
			if (Solution.UsedModelIDs[DefaultSourceName].GetGuid() != Guid.Empty)
			{
				PropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (PropertyID == Guid.Empty)
				{
					PropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = PropertyID;
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
			DataType = null;
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
			if (_referencedRelationshipPropertyList != null)
			{
				foreach (RelationshipProperty item in ReferencedRelationshipPropertyList)
				{
					item.Dispose();
				}
				ReferencedRelationshipPropertyList.Clear();
				ReferencedRelationshipPropertyList = null;
			}
			if (_indexPropertyList != null)
			{
				foreach (IndexProperty item in IndexPropertyList)
				{
					item.Dispose();
				}
				IndexPropertyList.Clear();
				IndexPropertyList = null;
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
		public override bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new Property();
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
		public override CollectionItem CreateIDReference()
		{
			CollectionItem newItem = new CollectionItem();
			newItem.ItemID = PropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public new Property GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Property forwardItem = new Property();
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
				forwardItem.PropertyID = PropertyID;
			}
			foreach (PropertyRelationship item in PropertyRelationshipList)
			{
				item.PropertyBase = this;
				PropertyRelationship forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyRelationshipList.Add(forwardChildItem);
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
				if (modelContext is Property)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Entity)
				{
					solutionContext.NeedsSample = false;
					Entity parent = modelContext as Entity;
					if (parent.PropertyList.Count > 0)
					{
						return parent.PropertyList[DataHelper.GetRandomInt(0, parent.PropertyList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is RelationshipProperty)
				{
					return (modelContext as RelationshipProperty).Property;
				}
				else if (modelContext is IndexProperty)
				{
					return (modelContext as IndexProperty).Property;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Feature)
				{
					Feature parent = modelContext as Feature;
					if (parent.EntityList.Count > 0 && parent.EntityList[0].PropertyList.Count > 0)
					{
						return parent.EntityList[0].PropertyList[0];
					}
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.PropertyList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.PropertyList[DataHelper.GetRandomInt(0, solutionContext.PropertyList.Count - 1)];
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
					return (nodeContext as Entity).PropertyList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).PropertyList;
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
				Property property = entity.PropertyList.Find(i => i.PropertyID == PropertyID);
				if (property != null)
				{
					if (property != this)
					{
						entity.PropertyList.Remove(property);
						entity.PropertyList.Add(this);
					}
				}
				else
				{
					entity.PropertyList.Add(this);
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
			if (solutionContext.CurrentProperty != null)
			{
				string validationErrors = solutionContext.CurrentProperty.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentProperty, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentProperty.Solution = solutionContext;
				solutionContext.CurrentProperty.AddToParent();
				Property existingItem = solutionContext.PropertyList.Find(i => i.PropertyID == solutionContext.CurrentProperty.PropertyID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentProperty.AssignProperty("PropertyID", solutionContext.CurrentProperty.PropertyID);
					solutionContext.CurrentProperty.ReverseInstance.ResetModified(false);
					solutionContext.PropertyList.Add(solutionContext.CurrentProperty);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Property();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentProperty, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("PropertyID", existingItem.PropertyID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentProperty = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Property item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentProperty != null)
			{
				Property existingItem = solutionContext.PropertyList.Find(i => i.PropertyID == solutionContext.CurrentProperty.PropertyID);
				if (existingItem != null)
				{
					solutionContext.PropertyList.Remove(solutionContext.CurrentProperty);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Property instance from an xml file.</summary>
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
		/// <summary>This method saves the Property instance to an xml file.</summary>
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
			base.ResetLoaded(isLoaded);
			if (_relationshipPropertyList != null) _relationshipPropertyList.ResetLoaded(isLoaded);
			if (_referencedRelationshipPropertyList != null) _referencedRelationshipPropertyList.ResetLoaded(isLoaded);
			if (_indexPropertyList != null) _indexPropertyList.ResetLoaded(isLoaded);
			if (_referencedPropertyReferenceList != null) _referencedPropertyReferenceList.ResetLoaded(isLoaded);
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
			if (_referencedRelationshipPropertyList != null) _referencedRelationshipPropertyList.ResetModified(isModified);
			if (_indexPropertyList != null) _indexPropertyList.ResetModified(isModified);
			if (_referencedPropertyReferenceList != null) _referencedPropertyReferenceList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Property(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Property instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Property(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Property instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="propertyID">The input value for PropertyID.</param>
		///--------------------------------------------------------------------------------
		public Property(Guid propertyID)
		{
			PropertyID = propertyID;
		}
		#endregion "Constructors"
	}
}