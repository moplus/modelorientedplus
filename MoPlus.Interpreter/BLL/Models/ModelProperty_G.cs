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

namespace MoPlus.Interpreter.BLL.Models
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific ModelProperty instances.</summary>
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
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="ModelProperty")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class ModelProperty : BusinessObjectBase
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
			
			error = GetValidationError("ModelPropertyName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Order");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ModelObjectID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefinedByModelObjectID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefinedByEnumerationID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefinedByValueID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsCollection");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsDisplayProperty");
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
				case "_modelPropertyName":
				case "ModelPropertyName":
					error = ValidateModelPropertyName();
					break;
				case "_order":
				case "Order":
					error = ValidateOrder();
					break;
				case "_modelObjectID":
				case "ModelObjectID":
					error = ValidateModelObjectID();
					break;
				case "_definedByModelObjectID":
				case "DefinedByModelObjectID":
					error = ValidateDefinedByModelObjectID();
					break;
				case "_definedByEnumerationID":
				case "DefinedByEnumerationID":
					error = ValidateDefinedByEnumerationID();
					break;
				case "_definedByValueID":
				case "DefinedByValueID":
					error = ValidateDefinedByValueID();
					break;
				case "_isCollection":
				case "IsCollection":
					error = ValidateIsCollection();
					break;
				case "_isDisplayProperty":
				case "IsDisplayProperty":
					error = ValidateIsDisplayProperty();
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
		/// <summary>This method validates ModelPropertyName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateModelPropertyName()
		{
			if (!Regex.IsMatch(ModelPropertyName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "ModelPropertyName");
			}
			#region protected
			if (Solution != null && Solution.ModelPropertyList.Find(p => p.ModelPropertyName == ModelPropertyName && p.ModelObjectID == ModelObjectID && p.ModelPropertyID != ModelPropertyID) != null)
			{
				return String.Format(Resources.DisplayValues.Validation_DuplicateModelPropertyFound, ModelPropertyName);
			}
			if (GrammarHelper.IsReservedWord(ModelPropertyName) == true)
			{
				return String.Format(Resources.DisplayValues.Validation_ModelPropertyReservedWordConflict, ModelPropertyName);
			}
			#endregion protected
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Order and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateOrder()
		{
			if (Order <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "Order");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ModelObjectID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateModelObjectID()
		{
			if (ModelObjectID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ModelObjectID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DefinedByModelObjectID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefinedByModelObjectID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DefinedByEnumerationID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefinedByEnumerationID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DefinedByValueID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefinedByValueID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsCollection and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsCollection()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsDisplayProperty and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsDisplayProperty()
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
		
		private ModelProperty _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ModelProperty ForwardInstance
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
		
		private ModelProperty _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new ModelProperty ReverseInstance
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
				return ModelPropertyID;
			}
			set
			{
				ModelPropertyID = value;
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
				return ModelPropertyName;
			}
			set
			{
				ModelPropertyName = value;
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
				return SourceModelProperty.ModelPropertyName;
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
					if (!String.IsNullOrEmpty(ModelObjectName))
					{
						_displayName = ModelObjectName + "." + ModelPropertyName;
					}
					else
					{
						_displayName = ModelPropertyName;
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
					if (ModelObject != null)
					{
						_defaultSourceName = ModelObject.DefaultSourceName + "." + DefaultSourcePrefix + SourceModelProperty.ModelPropertyName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceModelProperty.ModelPropertyName;
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
		public ModelProperty SourceModelProperty
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
		/// <summary>This property gets/sets the OldModelPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldModelObjectID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelObjectID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldDefinedByModelObjectID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldDefinedByModelObjectID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldDefinedByEnumerationID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldDefinedByEnumerationID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldDefinedByValueID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldDefinedByValueID { get; set; }
		
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
		
		protected Guid _modelPropertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelPropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ModelPropertyID
		{
			get
			{
				return _modelPropertyID;
			}
			set
			{
				if (_modelPropertyID != value)
				{
					_modelPropertyID = value;
					_isModified = true;
					base.OnPropertyChanged("ModelPropertyID");
				}
			}
		}
		
		protected string _modelPropertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelPropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ModelPropertyName
		{
			get
			{
				return _modelPropertyName;
			}
			set
			{
				if (_modelPropertyName != value)
				{
					_modelPropertyName = value;
					_isModified = true;
					base.OnPropertyChanged("ModelPropertyName");
				}
			}
		}
		
		protected int _order = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Order.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int Order
		{
			get
			{
				return _order;
			}
			set
			{
				if (_order != value)
				{
					_order = value;
					_isModified = true;
					base.OnPropertyChanged("Order");
				}
			}
		}
		
		protected Guid _modelObjectID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ModelObjectID
		{
			get
			{
				return _modelObjectID;
			}
			set
			{
				if (_modelObjectID != value)
				{
					_modelObjectID = value;
					_isModified = true;
					base.OnPropertyChanged("ModelObjectID");
				}
			}
		}
		
		protected Guid? _definedByModelObjectID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefinedByModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? DefinedByModelObjectID
		{
			get
			{
				return _definedByModelObjectID;
			}
			set
			{
				if (_definedByModelObjectID != value)
				{
					_definedByModelObjectID = value;
					_isModified = true;
					base.OnPropertyChanged("DefinedByModelObjectID");
				}
			}
		}
		
		protected Guid? _definedByEnumerationID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefinedByEnumerationID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? DefinedByEnumerationID
		{
			get
			{
				return _definedByEnumerationID;
			}
			set
			{
				if (_definedByEnumerationID != value)
				{
					_definedByEnumerationID = value;
					_isModified = true;
					base.OnPropertyChanged("DefinedByEnumerationID");
				}
			}
		}
		
		protected Guid? _definedByValueID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefinedByValueID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? DefinedByValueID
		{
			get
			{
				return _definedByValueID;
			}
			set
			{
				if (_definedByValueID != value)
				{
					_definedByValueID = value;
					_isModified = true;
					base.OnPropertyChanged("DefinedByValueID");
				}
			}
		}
		
		protected bool _isCollection = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsCollection.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsCollection
		{
			get
			{
				return _isCollection;
			}
			set
			{
				if (_isCollection != value)
				{
					_isCollection = value;
					_isModified = true;
					base.OnPropertyChanged("IsCollection");
				}
			}
		}
		
		protected bool _isDisplayProperty = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsDisplayProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsDisplayProperty
		{
			get
			{
				return _isDisplayProperty;
			}
			set
			{
				if (_isDisplayProperty != value)
				{
					_isDisplayProperty = value;
					_isModified = true;
					base.OnPropertyChanged("IsDisplayProperty");
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
		
		protected string _definedByEnumerationName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DefinedByEnumerationName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DefinedByEnumerationName
		{
			get
			{
				return _definedByEnumerationName;
			}
		}
		
		protected string _modelObjectName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ModelObjectName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ModelObjectName
		{
			get
			{
				return _modelObjectName;
			}
		}
		
		protected string _definedByModelObjectName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DefinedByModelObjectName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DefinedByModelObjectName
		{
			get
			{
				return _definedByModelObjectName;
			}
		}
		
		protected string _definedByValueName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DefinedByValueName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DefinedByValueName
		{
			get
			{
				return _definedByValueName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.PropertyInstance> _propertyInstanceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of ModelProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.PropertyInstance> PropertyInstanceList
		{
			get
			{
				if (_propertyInstanceList == null)
				{
					_propertyInstanceList = new EnterpriseDataObjectList<BLL.Models.PropertyInstance>();
				}
				return _propertyInstanceList;
			}
			set
			{
				if (_propertyInstanceList == null || _propertyInstanceList.Equals(value) == false)
				{
					_propertyInstanceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyInstanceList")]
		[XmlArrayItem(typeof(BLL.Models.PropertyInstance), ElementName = "PropertyInstance")]
		[DataMember(Name = "PropertyInstanceList")]
		[DataArrayItem(ElementName = "PropertyInstanceList")]
		public virtual EnterpriseDataObjectList<BLL.Models.PropertyInstance> _S_PropertyInstanceList
		{
			get
			{
				return _propertyInstanceList;
			}
			set
			{
				_propertyInstanceList = value;
			}
		}
		
		protected BLL.Models.Enumeration _definedByEnumeration = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the DefinedByEnumeration.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.Enumeration DefinedByEnumeration
		{
			get
			{
				return _definedByEnumeration;
			}
			set
			{
				if (value != null)
				{
					_definedByEnumerationName = value.EnumerationName;
					if (_definedByEnumeration != null && _definedByEnumeration.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					DefinedByEnumerationID = value.EnumerationID;
				}
				_definedByEnumeration = value;
			}
		}
		
		protected BLL.Models.ModelObject _definedByModelObject = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the DefinedByModelObject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.ModelObject DefinedByModelObject
		{
			get
			{
				return _definedByModelObject;
			}
			set
			{
				if (value != null)
				{
					_definedByModelObjectName = value.ModelObjectName;
					if (_definedByModelObject != null && _definedByModelObject.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					DefinedByModelObjectID = value.ModelObjectID;
				}
				_definedByModelObject = value;
			}
		}
		
		protected BLL.Models.ModelObject _modelObject = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ModelObject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.ModelObject ModelObject
		{
			get
			{
				return _modelObject;
			}
			set
			{
				if (value != null)
				{
					_modelObjectName = value.ModelObjectName;
					if (_modelObject != null && _modelObject.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ModelObjectID = value.ModelObjectID;
				}
				_modelObject = value;
			}
		}
		
		protected BLL.Models.Value _definedByValue = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the DefinedByValue.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.Value DefinedByValue
		{
			get
			{
				return _definedByValue;
			}
			set
			{
				if (value != null)
				{
					_definedByValueName = value.ValueName;
					if (_definedByValue != null && _definedByValue.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					DefinedByValueID = value.ValueID;
				}
				_definedByValue = value;
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
				return "ModelPropertyID";
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
				return ModelPropertyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					ModelPropertyID = primaryKeyValues[0].GetGuid();
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
				if (_propertyInstanceList != null && _propertyInstanceList.IsModified == true) return true;
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
				ReverseInstance = new ModelProperty();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new ModelProperty();
				ForwardInstance.ModelPropertyID = ModelPropertyID;
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
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputModelProperty">The modelproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(ModelProperty inputModelProperty)
		{
			if (ModelPropertyName.GetString() != inputModelProperty.ModelPropertyName.GetString()) return false;
			if (Order.GetInt() != inputModelProperty.Order.GetInt()) return false;
			if (ModelObjectID.GetGuid() != inputModelProperty.ModelObjectID.GetGuid()) return false;
			if (DefinedByModelObjectID.GetGuid() != inputModelProperty.DefinedByModelObjectID.GetGuid()) return false;
			if (DefinedByEnumerationID.GetGuid() != inputModelProperty.DefinedByEnumerationID.GetGuid()) return false;
			if (DefinedByValueID.GetGuid() != inputModelProperty.DefinedByValueID.GetGuid()) return false;
			if (IsCollection.GetBool() != inputModelProperty.IsCollection.GetBool()) return false;
			if (IsDisplayProperty.GetBool() != inputModelProperty.IsDisplayProperty.GetBool()) return false;
			if (IsAutoUpdated.GetBool() != inputModelProperty.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputModelProperty.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputModelProperty">The modelproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(ModelProperty inputModelProperty)
		{
			if (inputModelProperty == null) return true;
			if (inputModelProperty.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputModelProperty.ModelPropertyName)) return false;
			if (Order != DefaultValue.Int) return false;
			if (ModelObjectID != inputModelProperty.ModelObjectID) return false;
			if (DefinedByModelObjectID != inputModelProperty.DefinedByModelObjectID) return false;
			if (DefinedByEnumerationID != inputModelProperty.DefinedByEnumerationID) return false;
			if (DefinedByValueID != inputModelProperty.DefinedByValueID) return false;
			if (IsCollection != inputModelProperty.IsCollection) return false;
			if (IsDisplayProperty != inputModelProperty.IsDisplayProperty) return false;
			if (IsAutoUpdated != inputModelProperty.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputModelProperty.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputModelProperty">The modelproperty to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(ModelProperty inputModelProperty)
		{
			ModelPropertyName = inputModelProperty.ModelPropertyName;
			Order = inputModelProperty.Order;
			ModelObjectID = inputModelProperty.ModelObjectID;
			DefinedByModelObjectID = inputModelProperty.DefinedByModelObjectID;
			DefinedByEnumerationID = inputModelProperty.DefinedByEnumerationID;
			DefinedByValueID = inputModelProperty.DefinedByValueID;
			IsCollection = inputModelProperty.IsCollection;
			IsDisplayProperty = inputModelProperty.IsDisplayProperty;
			IsAutoUpdated = inputModelProperty.IsAutoUpdated;
			Description = inputModelProperty.Description;
			
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
				ModelPropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (ModelPropertyID == Guid.Empty)
				{
					ModelPropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = ModelPropertyID;
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
			DefinedByEnumeration = null;
			DefinedByModelObject = null;
			ModelObject = null;
			DefinedByValue = null;
			Solution = null;
			if (_propertyInstanceList != null)
			{
				foreach (PropertyInstance item in PropertyInstanceList)
				{
					item.Dispose();
				}
				PropertyInstanceList.Clear();
				PropertyInstanceList = null;
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
					ReverseInstance = new ModelProperty();
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
			newItem.ItemID = ModelPropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public ModelProperty GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			ModelProperty forwardItem = new ModelProperty();
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
				forwardItem.ModelPropertyID = ModelPropertyID;
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
			if (forwardItem.DefinedByEnumerationID != Guid.Empty)
			{
				forwardItem.DefinedByEnumeration = Solution.EnumerationList.Find(e => e.EnumerationID == forwardItem.DefinedByEnumerationID);
				if (forwardItem.DefinedByEnumeration != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.DefinedByEnumeration.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.DefinedByEnumeration.CreateIDReference());
				}
			}
			if (forwardItem.DefinedByModelObjectID != Guid.Empty)
			{
				forwardItem.DefinedByModelObject = Solution.ModelObjectList.Find(o => o.ModelObjectID == forwardItem.DefinedByModelObjectID);
				if (forwardItem.DefinedByModelObject != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.DefinedByModelObject.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.DefinedByModelObject.CreateIDReference());
				}
			}
			if (forwardItem.DefinedByValueID != Guid.Empty)
			{
				forwardItem.DefinedByValue = Solution.ValueList.Find(v => v.ValueID == forwardItem.DefinedByValueID);
				if (forwardItem.DefinedByValue != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.DefinedByValue.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.DefinedByValue.CreateIDReference());
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
				if (modelContext is ModelProperty)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is ModelObject)
				{
					solutionContext.NeedsSample = false;
					ModelObject parent = modelContext as ModelObject;
					if (parent.ModelPropertyList.Count > 0)
					{
						return parent.ModelPropertyList[DataHelper.GetRandomInt(0, parent.ModelPropertyList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.ModelPropertyList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.ModelPropertyList[DataHelper.GetRandomInt(0, solutionContext.ModelPropertyList.Count - 1)];
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
				if (nodeContext is ModelObject)
				{
					return (nodeContext as ModelObject).ModelPropertyList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).ModelPropertyList;
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
			return ModelObject;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			ModelObject modelObject = Solution.ModelObjectList.Find(i => i.ModelObjectID == ModelObjectID);
			if (modelObject != null)
			{
				ModelObject = modelObject;
				SetID();  // id (from saved ids) may change based on parent info
				ModelProperty modelProperty = modelObject.ModelPropertyList.Find(i => i.ModelPropertyID == ModelPropertyID);
				if (modelProperty != null)
				{
					if (modelProperty != this)
					{
						modelObject.ModelPropertyList.Remove(modelProperty);
						modelObject.ModelPropertyList.Add(this);
					}
				}
				else
				{
					modelObject.ModelPropertyList.Add(this);
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
			if (solutionContext.CurrentModelProperty != null)
			{
				string validationErrors = solutionContext.CurrentModelProperty.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentModelProperty, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentModelProperty.Solution = solutionContext;
				solutionContext.CurrentModelProperty.AddToParent();
				ModelProperty existingItem = solutionContext.ModelPropertyList.Find(i => i.ModelPropertyID == solutionContext.CurrentModelProperty.ModelPropertyID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentModelProperty.AssignProperty("ModelPropertyID", solutionContext.CurrentModelProperty.ModelPropertyID);
					solutionContext.CurrentModelProperty.ReverseInstance.ResetModified(false);
					solutionContext.ModelPropertyList.Add(solutionContext.CurrentModelProperty);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new ModelProperty();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentModelProperty, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("ModelPropertyID", existingItem.ModelPropertyID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentModelProperty = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current ModelProperty item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentModelProperty != null)
			{
				ModelProperty existingItem = solutionContext.ModelPropertyList.Find(i => i.ModelPropertyID == solutionContext.CurrentModelProperty.ModelPropertyID);
				if (existingItem != null)
				{
					solutionContext.ModelPropertyList.Remove(solutionContext.CurrentModelProperty);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the ModelProperty instance from an xml file.</summary>
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
		/// <summary>This method saves the ModelProperty instance to an xml file.</summary>
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
			if (_propertyInstanceList != null) _propertyInstanceList.ResetLoaded(isLoaded);
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
			if (_propertyInstanceList != null) _propertyInstanceList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelProperty(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic ModelProperty instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public ModelProperty(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic ModelProperty instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="modelPropertyID">The input value for ModelPropertyID.</param>
		///--------------------------------------------------------------------------------
		public ModelProperty(Guid modelPropertyID)
		{
			ModelPropertyID = modelPropertyID;
		}
		#endregion "Constructors"
	}
}