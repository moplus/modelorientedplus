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
	/// specific PropertyInstance instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/27/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="PropertyInstance")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class PropertyInstance : BusinessObjectBase
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
			
			error = GetValidationError("ModelPropertyID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ObjectInstanceID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Order");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("PropertyValue");
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
				case "_modelPropertyID":
				case "ModelPropertyID":
					error = ValidateModelPropertyID();
					break;
				case "_objectInstanceID":
				case "ObjectInstanceID":
					error = ValidateObjectInstanceID();
					break;
				case "_order":
				case "Order":
					error = ValidateOrder();
					break;
				case "_propertyValue":
				case "PropertyValue":
					error = ValidatePropertyValue();
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
		/// <summary>This method validates ModelPropertyID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateModelPropertyID()
		{
			if (ModelPropertyID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ModelPropertyID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ObjectInstanceID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateObjectInstanceID()
		{
			if (ObjectInstanceID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ObjectInstanceID");
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
		/// <summary>This method validates PropertyValue and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePropertyValue()
		{
			if (String.IsNullOrEmpty(PropertyValue))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "PropertyValue");
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
		
		private PropertyInstance _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyInstance ForwardInstance
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
		
		private PropertyInstance _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new PropertyInstance ReverseInstance
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
				return PropertyInstanceID;
			}
			set
			{
				PropertyInstanceID = value;
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
				if (_defaultSourceName == null)
				{
					if (ModelProperty == null)
					{
						ModelProperty = Solution.ModelPropertyList.Find(i => i.ModelPropertyID == ModelPropertyID);
					}
					if (ObjectInstance != null)
					{
						_defaultSourceName = ObjectInstance.DefaultSourceName + "." + ModelPropertyName + "." + SourceName;
					}
					else
					{
						_defaultSourceName = ModelPropertyName + "." + SourceName;
					}
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
		public PropertyInstance SourcePropertyInstance
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
		/// <summary>This property gets/sets the OldPropertyInstanceID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldPropertyInstanceID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldModelPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldObjectInstanceID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldObjectInstanceID { get; set; }
		
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
		
		protected Guid _propertyInstanceID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyInstanceID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid PropertyInstanceID
		{
			get
			{
				return _propertyInstanceID;
			}
			set
			{
				if (_propertyInstanceID != value)
				{
					_propertyInstanceID = value;
					_isModified = true;
					base.OnPropertyChanged("PropertyInstanceID");
				}
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
		
		protected Guid _objectInstanceID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ObjectInstanceID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ObjectInstanceID
		{
			get
			{
				return _objectInstanceID;
			}
			set
			{
				if (_objectInstanceID != value)
				{
					_objectInstanceID = value;
					_isModified = true;
					base.OnPropertyChanged("ObjectInstanceID");
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
		
		protected string _propertyValue = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyValue.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string PropertyValue
		{
			get
			{
				return _propertyValue;
			}
			set
			{
				if (_propertyValue != value)
				{
					_propertyValue = value;
					_isModified = true;
					base.OnPropertyChanged("PropertyValue");
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
		
		protected string _modelPropertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ModelPropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ModelPropertyName
		{
			get
			{
				return _modelPropertyName;
			}
		}
		
		protected BLL.Models.ModelProperty _modelProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ModelProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.ModelProperty ModelProperty
		{
			get
			{
				return _modelProperty;
			}
			set
			{
				if (value != null)
				{
					_modelPropertyName = value.ModelPropertyName;
					if (_modelProperty != null && _modelProperty.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ModelPropertyID = value.ModelPropertyID;
				}
				_modelProperty = value;
			}
		}
		
		protected BLL.Models.ObjectInstance _objectInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.ObjectInstance ObjectInstance
		{
			get
			{
				return _objectInstance;
			}
			set
			{
				if (value != null)
				{
					if (_objectInstance != null && _objectInstance.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ObjectInstanceID = value.ObjectInstanceID;
				}
				_objectInstance = value;
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
				return "PropertyInstanceID";
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
				return PropertyInstanceID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					PropertyInstanceID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new PropertyInstance();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new PropertyInstance();
				ForwardInstance.PropertyInstanceID = PropertyInstanceID;
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
		/// <param name="inputPropertyInstance">The propertyinstance to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(PropertyInstance inputPropertyInstance)
		{
			if (ModelPropertyID.GetGuid() != inputPropertyInstance.ModelPropertyID.GetGuid()) return false;
			if (ObjectInstanceID.GetGuid() != inputPropertyInstance.ObjectInstanceID.GetGuid()) return false;
			if (Order.GetInt() != inputPropertyInstance.Order.GetInt()) return false;
			if (PropertyValue.GetString() != inputPropertyInstance.PropertyValue.GetString()) return false;
			if (IsAutoUpdated.GetBool() != inputPropertyInstance.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputPropertyInstance.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputPropertyInstance">The propertyinstance to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(PropertyInstance inputPropertyInstance)
		{
			if (inputPropertyInstance == null) return true;
			if (inputPropertyInstance.TagList.Count > 0) return false;
			if (ModelPropertyID != inputPropertyInstance.ModelPropertyID) return false;
			if (ObjectInstanceID != inputPropertyInstance.ObjectInstanceID) return false;
			if (Order != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputPropertyInstance.PropertyValue)) return false;
			if (IsAutoUpdated != inputPropertyInstance.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputPropertyInstance.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputPropertyInstance">The propertyinstance to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(PropertyInstance inputPropertyInstance)
		{
			ModelPropertyID = inputPropertyInstance.ModelPropertyID;
			ObjectInstanceID = inputPropertyInstance.ObjectInstanceID;
			Order = inputPropertyInstance.Order;
			PropertyValue = inputPropertyInstance.PropertyValue;
			IsAutoUpdated = inputPropertyInstance.IsAutoUpdated;
			Description = inputPropertyInstance.Description;
			
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
				PropertyInstanceID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (PropertyInstanceID == Guid.Empty)
				{
					PropertyInstanceID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = PropertyInstanceID;
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
			ModelProperty = null;
			ObjectInstance = null;
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
					ReverseInstance = new PropertyInstance();
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
			newItem.ItemID = PropertyInstanceID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public PropertyInstance GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			PropertyInstance forwardItem = new PropertyInstance();
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
				forwardItem.PropertyInstanceID = PropertyInstanceID;
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
			if (forwardItem.ModelPropertyID != Guid.Empty)
			{
				forwardItem.ModelProperty = Solution.ModelPropertyList.Find(p => p.ModelPropertyID == forwardItem.ModelPropertyID);
				if (forwardItem.ModelProperty != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.ModelProperty.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.ModelProperty.CreateIDReference());
				}
			}
			if (forwardItem.ModelProperty != null)
			{
				if (forwardItem.ModelProperty.DefinedByModelObjectID != null)
				{
					Guid objectID = Guid.Empty;
					Guid.TryParse(forwardItem.PropertyValue, out objectID);
					if (objectID != Guid.Empty)
					{
						ObjectInstance instance = Solution.ObjectInstanceList.Find(i => i.ObjectInstanceID == objectID);
						if (instance != null && forwardSolution.ReferencedModelIDs.Find("ItemName", instance.DefaultSourceName) == null)
						{
							forwardSolution.ReferencedModelIDs.Add(instance.CreateIDReference());
						}
					}
				}
				else if (forwardItem.ModelProperty.DefinedByEnumerationID != null && forwardItem.ModelProperty.DefinedByValueID == null)
				{
					Value value = Solution.ValueList.Find(v => v.EnumerationID == forwardItem.ModelProperty.DefinedByEnumerationID && v.EnumValue == forwardItem.PropertyValue);
					if (value != null && forwardSolution.ReferencedModelIDs.Find("ItemName", value.DefaultSourceName) == null)
					{
						forwardSolution.ReferencedModelIDs.Add(value.CreateIDReference());
					}
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
				if (modelContext is PropertyInstance)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is ObjectInstance)
				{
					solutionContext.NeedsSample = false;
					ObjectInstance parent = modelContext as ObjectInstance;
					if (parent.PropertyInstanceList.Count > 0)
					{
						return parent.PropertyInstanceList[DataHelper.GetRandomInt(0, parent.PropertyInstanceList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.PropertyInstanceList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.PropertyInstanceList[DataHelper.GetRandomInt(0, solutionContext.PropertyInstanceList.Count - 1)];
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
				if (nodeContext is ObjectInstance)
				{
					return (nodeContext as ObjectInstance).PropertyInstanceList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).PropertyInstanceList;
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
			return ObjectInstance;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			ObjectInstance objectInstance = Solution.ObjectInstanceList.Find(i => i.ObjectInstanceID == ObjectInstanceID);
			if (objectInstance != null)
			{
				ObjectInstance = objectInstance;
				SetID();  // id (from saved ids) may change based on parent info
				PropertyInstance propertyInstance = objectInstance.PropertyInstanceList.Find(i => i.PropertyInstanceID == PropertyInstanceID);
				if (propertyInstance != null)
				{
					if (propertyInstance != this)
					{
						objectInstance.PropertyInstanceList.Remove(propertyInstance);
						objectInstance.PropertyInstanceList.Add(this);
					}
				}
				else
				{
					objectInstance.PropertyInstanceList.Add(this);
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
			if (solutionContext.CurrentPropertyInstance != null)
			{
				string validationErrors = solutionContext.CurrentPropertyInstance.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentPropertyInstance, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentPropertyInstance.Solution = solutionContext;
				solutionContext.CurrentPropertyInstance.AddToParent();
				PropertyInstance existingItem = solutionContext.PropertyInstanceList.Find(i => i.PropertyInstanceID == solutionContext.CurrentPropertyInstance.PropertyInstanceID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentPropertyInstance.AssignProperty("PropertyInstanceID", solutionContext.CurrentPropertyInstance.PropertyInstanceID);
					solutionContext.CurrentPropertyInstance.ReverseInstance.ResetModified(false);
					solutionContext.PropertyInstanceList.Add(solutionContext.CurrentPropertyInstance);
				}
				else
				{
					// update existing item in solution
					if (existingItem.Solution == null) existingItem.Solution = solutionContext;
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new PropertyInstance();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentPropertyInstance, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("PropertyInstanceID", existingItem.PropertyInstanceID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentPropertyInstance = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current PropertyInstance item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentPropertyInstance != null)
			{
				PropertyInstance existingItem = solutionContext.PropertyInstanceList.Find(i => i.PropertyInstanceID == solutionContext.CurrentPropertyInstance.PropertyInstanceID);
				if (existingItem != null)
				{
					solutionContext.PropertyInstanceList.Remove(solutionContext.CurrentPropertyInstance);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the PropertyInstance instance from an xml file.</summary>
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
		/// <summary>This method saves the PropertyInstance instance to an xml file.</summary>
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
		public PropertyInstance(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic PropertyInstance instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public PropertyInstance(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic PropertyInstance instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="propertyInstanceID">The input value for PropertyInstanceID.</param>
		///--------------------------------------------------------------------------------
		public PropertyInstance(Guid propertyInstanceID)
		{
			PropertyInstanceID = propertyInstanceID;
		}
		#endregion "Constructors"
	}
}