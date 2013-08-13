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

namespace MoPlus.Interpreter.BLL.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific AuditProperty instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="AuditProperty")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class AuditProperty : Solutions.PropertyBase
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
			error = GetValidationError("IsAddAuditProperty");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsUpdateAuditProperty");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsValueGenerated");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DataTypeCode");
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
				case "_isAddAuditProperty":
				case "IsAddAuditProperty":
					error = ValidateIsAddAuditProperty();
					break;
				case "_isUpdateAuditProperty":
				case "IsUpdateAuditProperty":
					error = ValidateIsUpdateAuditProperty();
					break;
				case "_isValueGenerated":
				case "IsValueGenerated":
					error = ValidateIsValueGenerated();
					break;
				case "_dataTypeCode":
				case "DataTypeCode":
					error = ValidateDataTypeCode();
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
		/// <summary>This method validates IsAddAuditProperty and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsAddAuditProperty()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsUpdateAuditProperty and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsUpdateAuditProperty()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsValueGenerated and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsValueGenerated()
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
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private AuditProperty _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new AuditProperty ForwardInstance
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
		
		private AuditProperty _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new AuditProperty ReverseInstance
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
				return SourceAuditProperty.PropertyName;
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
					if (!String.IsNullOrEmpty(SolutionName))
					{
						_displayName = SolutionName + "." + PropertyName;
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
					_defaultSourceName = DefaultSourcePrefix + SourceAuditProperty.PropertyName;
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
		public AuditProperty SourceAuditProperty
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
		
		protected bool _isAddAuditProperty = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsAddAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsAddAuditProperty
		{
			get
			{
				return _isAddAuditProperty;
			}
			set
			{
				if (_isAddAuditProperty != value)
				{
					_isAddAuditProperty = value;
					_isModified = true;
					base.OnPropertyChanged("IsAddAuditProperty");
				}
			}
		}
		
		protected bool _isUpdateAuditProperty = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsUpdateAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsUpdateAuditProperty
		{
			get
			{
				return _isUpdateAuditProperty;
			}
			set
			{
				if (_isUpdateAuditProperty != value)
				{
					_isUpdateAuditProperty = value;
					_isModified = true;
					base.OnPropertyChanged("IsUpdateAuditProperty");
				}
			}
		}
		
		protected bool _isValueGenerated = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsValueGenerated.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsValueGenerated
		{
			get
			{
				return _isValueGenerated;
			}
			set
			{
				if (_isValueGenerated != value)
				{
					_isValueGenerated = value;
					_isModified = true;
					base.OnPropertyChanged("IsValueGenerated");
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
				ReverseInstance = new AuditProperty();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new AuditProperty();
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
		/// <param name="inputAuditProperty">The auditproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(AuditProperty inputAuditProperty)
		{
			if (PropertyName.GetString() != inputAuditProperty.PropertyName.GetString()) return false;
			if (IsAddAuditProperty.GetBool() != inputAuditProperty.IsAddAuditProperty.GetBool()) return false;
			if (IsUpdateAuditProperty.GetBool() != inputAuditProperty.IsUpdateAuditProperty.GetBool()) return false;
			if (IsValueGenerated.GetBool() != inputAuditProperty.IsValueGenerated.GetBool()) return false;
			if (DataTypeCode.GetInt() != inputAuditProperty.DataTypeCode.GetInt()) return false;
			if (Precision.GetInt() != inputAuditProperty.Precision.GetInt()) return false;
			if (Scale.GetInt() != inputAuditProperty.Scale.GetInt()) return false;
			if (InitialValue.GetString() != inputAuditProperty.InitialValue.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputAuditProperty">The auditproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(AuditProperty inputAuditProperty)
		{
			if (inputAuditProperty == null) return true;
			if (inputAuditProperty.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputAuditProperty.PropertyName)) return false;
			if (IsAddAuditProperty != inputAuditProperty.IsAddAuditProperty) return false;
			if (IsUpdateAuditProperty != inputAuditProperty.IsUpdateAuditProperty) return false;
			if (IsValueGenerated != inputAuditProperty.IsValueGenerated) return false;
			if (DataTypeCode != DefaultValue.Int) return false;
			if (Precision != DefaultValue.Int) return false;
			if (Scale != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputAuditProperty.InitialValue)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputAuditProperty">The auditproperty to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(AuditProperty inputAuditProperty)
		{
			PropertyName = inputAuditProperty.PropertyName;
			IsAddAuditProperty = inputAuditProperty.IsAddAuditProperty;
			IsUpdateAuditProperty = inputAuditProperty.IsUpdateAuditProperty;
			IsValueGenerated = inputAuditProperty.IsValueGenerated;
			DataTypeCode = inputAuditProperty.DataTypeCode;
			Precision = inputAuditProperty.Precision;
			Scale = inputAuditProperty.Scale;
			InitialValue = inputAuditProperty.InitialValue;
			
			#region protected
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public override void SetID()
		{
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
			Solution = null;
			
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
					ReverseInstance = new AuditProperty();
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
		public new AuditProperty GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			AuditProperty forwardItem = new AuditProperty();
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
				if (modelContext is AuditProperty)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Solution)
				{
					Solution parent = modelContext as Solution;
					if (parent.AuditPropertyList.Count > 0)
					{
						return parent.AuditPropertyList[DataHelper.GetRandomInt(0, parent.AuditPropertyList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.AuditPropertyList.Count > 0)
			{
				return solutionContext.AuditPropertyList[DataHelper.GetRandomInt(0, solutionContext.AuditPropertyList.Count - 1)];
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
				if (nodeContext is Solution)
				{
					return (nodeContext as Solution).AuditPropertyList;
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
			return Solution;
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
			if (solutionContext.CurrentAuditProperty != null)
			{
				string validationErrors = solutionContext.CurrentAuditProperty.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentAuditProperty, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				AuditProperty existingItem = solutionContext.AuditPropertyList.Find(i => i.PropertyID == solutionContext.CurrentAuditProperty.PropertyID);
				if (existingItem == null)
				{
					solutionContext.CurrentAuditProperty.Solution = solutionContext;
					solutionContext.CurrentAuditProperty.SetID();
					solutionContext.CurrentAuditProperty.AssignProperty("PropertyID", solutionContext.CurrentAuditProperty.PropertyID);
					AuditProperty foundItem = solutionContext.AuditPropertiesToMerge.Find(i => i.PropertyID == solutionContext.CurrentAuditProperty.PropertyID);
					if (foundItem != null)
					{
						AuditProperty forwardItem = new AuditProperty();
						forwardItem.TransformDataFromObject(foundItem, null, false);
						solutionContext.CurrentAuditProperty.ForwardInstance = forwardItem;
						solutionContext.CurrentAuditProperty.TransformDataFromObject(forwardItem, null, false, true);
						solutionContext.AuditPropertiesToMerge.Remove(foundItem);
					}
					
					#region protected
					#endregion protected
					
					solutionContext.AuditPropertyList.Add(solutionContext.CurrentAuditProperty);
					solutionContext.CurrentAuditProperty.ReverseInstance.ResetModified(false);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current AuditProperty item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentAuditProperty != null)
			{
				AuditProperty existingItem = solutionContext.AuditPropertyList.Find(i => i.PropertyID == solutionContext.CurrentAuditProperty.PropertyID);
				if (existingItem != null)
				{
					solutionContext.AuditPropertyList.Remove(solutionContext.CurrentAuditProperty);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the AuditProperty instance from an xml file.</summary>
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
		/// <summary>This method saves the AuditProperty instance to an xml file.</summary>
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
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public AuditProperty(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic AuditProperty instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public AuditProperty(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic AuditProperty instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="propertyID">The input value for PropertyID.</param>
		///--------------------------------------------------------------------------------
		public AuditProperty(Guid propertyID)
		{
			PropertyID = propertyID;
		}
		#endregion "Constructors"
	}
}