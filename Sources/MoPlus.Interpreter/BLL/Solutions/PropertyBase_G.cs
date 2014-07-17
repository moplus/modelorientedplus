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
	/// specific PropertyBase instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/16/2014</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="PropertyBase")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class PropertyBase : BusinessObjectBase
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
		/// <summary>This method validates IsNullable and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsNullable()
		{
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
		
		private PropertyBase _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyBase ForwardInstance
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
		
		private PropertyBase _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new PropertyBase ReverseInstance
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
		
		private string _defaultSourceName;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the default source name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DefaultSourceName
		{
			get
			{
				
				#region protected
				if (String.IsNullOrEmpty(_defaultSourceName))
				{
					_defaultSourceName = SolutionName + "." + PropertyID.ToString();
				}
				#endregion protected
				
				return _defaultSourceName;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the source method, which may be the reverse instance
		/// (to get original values, etc.).</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyBase SourcePropertyBase
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
		/// <summary>This property gets/sets the OldPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSolutionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSolutionID { get; set; }
		
		
		protected Guid _propertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid PropertyID
		{
			get
			{
				return _propertyID;
			}
			set
			{
				if (_propertyID != value)
				{
					_propertyID = value;
					_isModified = true;
					base.OnPropertyChanged("PropertyID");
				}
			}
		}
		
		protected Guid _solutionID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SolutionID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SolutionID
		{
			get
			{
				return _solutionID;
			}
			set
			{
				if (_solutionID != value)
				{
					_solutionID = value;
					_isModified = true;
					base.OnPropertyChanged("SolutionID");
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
		
		protected string _solutionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SolutionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SolutionName
		{
			get
			{
				return _solutionName;
			}
		}
		
		protected string _outputSolutionFileName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the OutputSolutionFileName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string OutputSolutionFileName
		{
			get
			{
				return _outputSolutionFileName;
			}
		}
		
		protected string _companyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the CompanyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string CompanyName
		{
			get
			{
				return _companyName;
			}
		}
		
		protected string _productName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ProductName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ProductName
		{
			get
			{
				return _productName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Parameter> _referencedParameterList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of PropertyBase.</summary>
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
		
		protected EnterpriseDataObjectList<BLL.Entities.PropertyRelationship> _propertyRelationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of PropertyBase.</summary>
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
		
		protected BLL.Solutions.Solution _solution = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Solutions.Solution Solution
		{
			get
			{
				return _solution;
			}
			set
			{
				if (value != null)
				{
					_solutionName = value.SolutionName;
					_outputSolutionFileName = value.OutputSolutionFileName;
					_companyName = value.CompanyName;
					_productName = value.ProductName;
					if (_solution != null && _solution.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SolutionID = value.SolutionID;
				}
				_solution = value;
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
				return "PropertyID";
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
				return PropertyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					PropertyID = primaryKeyValues[0].GetGuid();
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
				if (_referencedParameterList != null && _referencedParameterList.IsModified == true) return true;
				if (_propertyRelationshipList != null && _propertyRelationshipList.IsModified == true) return true;
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
				ReverseInstance = new PropertyBase();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new PropertyBase();
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
		public virtual void AddItemToUsedTags(NameObjectCollection usedTags)
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
		/// <param name="inputPropertyBase">The propertybase to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(PropertyBase inputPropertyBase)
		{
			if (SolutionID.GetGuid() != inputPropertyBase.SolutionID.GetGuid()) return false;
			if (IsNullable.GetBool() != inputPropertyBase.IsNullable.GetBool()) return false;
			if (Order.GetInt() != inputPropertyBase.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputPropertyBase.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputPropertyBase.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputPropertyBase">The propertybase to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(PropertyBase inputPropertyBase)
		{
			if (inputPropertyBase == null) return true;
			if (inputPropertyBase.TagList.Count > 0) return false;
			if (SolutionID != inputPropertyBase.SolutionID) return false;
			if (IsNullable != inputPropertyBase.IsNullable) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputPropertyBase.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputPropertyBase.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputPropertyBase">The propertybase to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(PropertyBase inputPropertyBase)
		{
			SolutionID = inputPropertyBase.SolutionID;
			IsNullable = inputPropertyBase.IsNullable;
			Order = inputPropertyBase.Order;
			IsAutoUpdated = inputPropertyBase.IsAutoUpdated;
			Description = inputPropertyBase.Description;
			
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
			Solution = null;
			Solution = null;
			if (_referencedParameterList != null)
			{
				foreach (Parameter item in ReferencedParameterList)
				{
					item.Dispose();
				}
				ReferencedParameterList.Clear();
				ReferencedParameterList = null;
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
					ReverseInstance = new PropertyBase();
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
			newItem.ItemID = PropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public PropertyBase GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			PropertyBase forwardItem = new PropertyBase();
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
		/// <summary>This method gets the PropertyBase instance from an xml file.</summary>
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
		/// <summary>This method saves the PropertyBase instance to an xml file.</summary>
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
			if (_referencedParameterList != null) _referencedParameterList.ResetLoaded(isLoaded);
			if (_propertyRelationshipList != null) _propertyRelationshipList.ResetLoaded(isLoaded);
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
			if (_referencedParameterList != null) _referencedParameterList.ResetModified(isModified);
			if (_propertyRelationshipList != null) _propertyRelationshipList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public PropertyBase(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic PropertyBase instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public PropertyBase(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic PropertyBase instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="propertyID">The input value for PropertyID.</param>
		///--------------------------------------------------------------------------------
		public PropertyBase(Guid propertyID)
		{
			PropertyID = propertyID;
		}
		#endregion "Constructors"
	}
}