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
	/// specific Parameter instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/2/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="Parameter")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Parameter : BusinessObjectBase
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
			
			error = GetValidationError("ParameterName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("MethodID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedEntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedPropertyID");
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
				case "_parameterName":
				case "ParameterName":
					error = ValidateParameterName();
					break;
				case "_methodID":
				case "MethodID":
					error = ValidateMethodID();
					break;
				case "_referencedEntityID":
				case "ReferencedEntityID":
					error = ValidateReferencedEntityID();
					break;
				case "_referencedPropertyID":
				case "ReferencedPropertyID":
					error = ValidateReferencedPropertyID();
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
		/// <summary>This method validates ParameterName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateParameterName()
		{
			if (!Regex.IsMatch(ParameterName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "ParameterName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates MethodID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateMethodID()
		{
			if (MethodID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "MethodID");
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
		/// <summary>This method validates ReferencedPropertyID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedPropertyID()
		{
			if (ReferencedPropertyID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ReferencedPropertyID");
			}
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
		
		private Parameter _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Parameter ForwardInstance
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
		
		private Parameter _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Parameter ReverseInstance
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
				return ParameterID;
			}
			set
			{
				ParameterID = value;
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
				return ParameterName;
			}
			set
			{
				ParameterName = value;
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
				return SourceParameter.ParameterName;
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
					if (!String.IsNullOrEmpty(MethodName))
					{
						_displayName = MethodName + "." + ParameterName;
					}
					else
					{
						_displayName = ParameterName;
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
					if (Method != null)
					{
						_defaultSourceName = Method.DefaultSourceName + "." + DefaultSourcePrefix + SourceParameter.ParameterName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceParameter.ParameterName;
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
		public Parameter SourceParameter
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
		/// <summary>This property gets/sets the OldParameterID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldParameterID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldMethodID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldMethodID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldReferencedEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldReferencedEntityID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldReferencedPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldReferencedPropertyID { get; set; }
		
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
		
		protected Guid _parameterID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ParameterID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ParameterID
		{
			get
			{
				return _parameterID;
			}
			set
			{
				if (_parameterID != value)
				{
					_parameterID = value;
					_isModified = true;
					base.OnPropertyChanged("ParameterID");
				}
			}
		}
		
		protected string _parameterName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ParameterName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ParameterName
		{
			get
			{
				return _parameterName;
			}
			set
			{
				if (_parameterName != value)
				{
					_parameterName = value;
					_isModified = true;
					base.OnPropertyChanged("ParameterName");
				}
			}
		}
		
		protected Guid _methodID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MethodID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid MethodID
		{
			get
			{
				return _methodID;
			}
			set
			{
				if (_methodID != value)
				{
					_methodID = value;
					_isModified = true;
					base.OnPropertyChanged("MethodID");
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
		
		protected Guid _referencedPropertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedPropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ReferencedPropertyID
		{
			get
			{
				return _referencedPropertyID;
			}
			set
			{
				if (_referencedPropertyID != value)
				{
					_referencedPropertyID = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedPropertyID");
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
		
		protected string _methodName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the MethodName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string MethodName
		{
			get
			{
				return _methodName;
			}
		}
		
		protected int _methodTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the MethodTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int MethodTypeCode
		{
			get
			{
				return _methodTypeCode;
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
		
		protected BLL.Entities.Method _method = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Method.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Method Method
		{
			get
			{
				return _method;
			}
			set
			{
				if (value != null)
				{
					_methodName = value.MethodName;
					_methodTypeCode = value.MethodTypeCode;
					if (_method != null && _method.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					MethodID = value.MethodID;
				}
				_method = value;
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
					if (_referencedEntity != null && _referencedEntity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ReferencedEntityID = value.EntityID;
				}
				_referencedEntity = value;
			}
		}
		
		protected BLL.Solutions.PropertyBase _referencedPropertyBase = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ReferencedPropertyBase.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Solutions.PropertyBase ReferencedPropertyBase
		{
			get
			{
				return _referencedPropertyBase;
			}
			set
			{
				if (value != null)
				{
					if (_referencedPropertyBase != null && _referencedPropertyBase.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ReferencedPropertyID = value.PropertyID;
				}
				_referencedPropertyBase = value;
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
				return "ParameterID";
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
				return ParameterID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					ParameterID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new Parameter();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Parameter();
				ForwardInstance.ParameterID = ParameterID;
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
		/// <param name="inputParameter">The parameter to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Parameter inputParameter)
		{
			if (ParameterName.GetString() != inputParameter.ParameterName.GetString()) return false;
			if (MethodID.GetGuid() != inputParameter.MethodID.GetGuid()) return false;
			if (ReferencedEntityID.GetGuid() != inputParameter.ReferencedEntityID.GetGuid()) return false;
			if (ReferencedPropertyID.GetGuid() != inputParameter.ReferencedPropertyID.GetGuid()) return false;
			if (Order.GetInt() != inputParameter.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputParameter.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputParameter.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputParameter">The parameter to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Parameter inputParameter)
		{
			if (inputParameter == null) return true;
			if (inputParameter.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputParameter.ParameterName)) return false;
			if (MethodID != inputParameter.MethodID) return false;
			if (ReferencedEntityID != inputParameter.ReferencedEntityID) return false;
			if (ReferencedPropertyID != inputParameter.ReferencedPropertyID) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputParameter.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputParameter.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputParameter">The parameter to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Parameter inputParameter)
		{
			ParameterName = inputParameter.ParameterName;
			MethodID = inputParameter.MethodID;
			ReferencedEntityID = inputParameter.ReferencedEntityID;
			ReferencedPropertyID = inputParameter.ReferencedPropertyID;
			Order = inputParameter.Order;
			IsAutoUpdated = inputParameter.IsAutoUpdated;
			Description = inputParameter.Description;
			
			#region protected
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
				ParameterID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (ParameterID == Guid.Empty)
				{
					ParameterID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = ParameterID;
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
			Method = null;
			ReferencedEntity = null;
			ReferencedPropertyBase = null;
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
		public virtual bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new Parameter();
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
			newItem.ItemID = ParameterID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Parameter GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Parameter forwardItem = new Parameter();
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
				forwardItem.ParameterID = ParameterID;
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
			if (forwardItem.ReferencedPropertyID != Guid.Empty)
			{
				forwardItem.ReferencedPropertyBase = Solution.PropertyList.FindByID(forwardItem.ReferencedPropertyID);
				if (forwardItem.ReferencedPropertyBase != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.ReferencedPropertyBase.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.ReferencedPropertyBase.CreateIDReference());
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
				if (modelContext is Parameter)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Method)
				{
					Method parent = modelContext as Method;
					if (parent.ParameterList.Count > 0)
					{
						return parent.ParameterList[DataHelper.GetRandomInt(0, parent.ParameterList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.ParameterList.Count > 0)
			{
				return solutionContext.ParameterList[DataHelper.GetRandomInt(0, solutionContext.ParameterList.Count - 1)];
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
				if (nodeContext is Method)
				{
					return (nodeContext as Method).ParameterList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).ParameterList;
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
			return Method;
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
			if (solutionContext.CurrentParameter != null)
			{
				string validationErrors = solutionContext.CurrentParameter.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentParameter, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				Parameter existingItem = solutionContext.ParameterList.Find(i => i.ParameterID == solutionContext.CurrentParameter.ParameterID);
				if (existingItem == null)
				{
					solutionContext.CurrentParameter.Solution = solutionContext;
					Method method = solutionContext.MethodList.Find(i => i.MethodID == solutionContext.CurrentParameter.MethodID);
					if (method != null)
					{
						solutionContext.CurrentParameter.Method = method;
						method.ParameterList.Add(solutionContext.CurrentParameter);
					}
					Entity referencedEntity = solutionContext.EntityList.Find(i => i.EntityID == solutionContext.CurrentParameter.ReferencedEntityID);
					if (referencedEntity != null)
					{
						solutionContext.CurrentParameter.ReferencedEntity = referencedEntity;
						referencedEntity.ReferencedParameterList.Add(solutionContext.CurrentParameter);
					}
					PropertyBase referencedPropertyBase = solutionContext.PropertyBaseList.Find(i => i.PropertyID == solutionContext.CurrentParameter.ReferencedPropertyID);
					if (referencedPropertyBase != null)
					{
						solutionContext.CurrentParameter.ReferencedPropertyBase = referencedPropertyBase;
						referencedPropertyBase.ReferencedParameterList.Add(solutionContext.CurrentParameter);
					}
					solutionContext.CurrentParameter.SetID();
					solutionContext.CurrentParameter.AssignProperty("ParameterID", solutionContext.CurrentParameter.ParameterID);
					Parameter foundItem = solutionContext.ParametersToMerge.Find(i => i.ParameterID == solutionContext.CurrentParameter.ParameterID);
					if (foundItem != null)
					{
						Parameter forwardItem = new Parameter();
						forwardItem.TransformDataFromObject(foundItem, null, false);
						solutionContext.CurrentParameter.ForwardInstance = forwardItem;
						solutionContext.CurrentParameter.TransformDataFromObject(forwardItem, null, false, true);
						solutionContext.ParametersToMerge.Remove(foundItem);
					}
					
					#region protected
					#endregion protected
					
					solutionContext.ParameterList.Add(solutionContext.CurrentParameter);
					solutionContext.CurrentParameter.ReverseInstance.ResetModified(false);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Parameter item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentParameter != null)
			{
				Parameter existingItem = solutionContext.ParameterList.Find(i => i.ParameterID == solutionContext.CurrentParameter.ParameterID);
				if (existingItem != null)
				{
					solutionContext.ParameterList.Remove(solutionContext.CurrentParameter);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Parameter instance from an xml file.</summary>
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
		/// <summary>This method saves the Parameter instance to an xml file.</summary>
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
		public Parameter(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Parameter instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Parameter(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Parameter instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="parameterID">The input value for ParameterID.</param>
		///--------------------------------------------------------------------------------
		public Parameter(Guid parameterID)
		{
			ParameterID = parameterID;
		}
		#endregion "Constructors"
	}
}