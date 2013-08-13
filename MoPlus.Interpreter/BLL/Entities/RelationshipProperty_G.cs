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
	/// specific RelationshipProperty instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/9/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="RelationshipProperty")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class RelationshipProperty : BusinessObjectBase
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
			
			error = GetValidationError("RelationshipID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("PropertyID");
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
				case "_relationshipID":
				case "RelationshipID":
					error = ValidateRelationshipID();
					break;
				case "_propertyID":
				case "PropertyID":
					error = ValidatePropertyID();
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
		/// <summary>This method validates RelationshipID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateRelationshipID()
		{
			if (RelationshipID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "RelationshipID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates PropertyID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePropertyID()
		{
			if (PropertyID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "PropertyID");
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
		
		private RelationshipProperty _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public RelationshipProperty ForwardInstance
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
		
		private RelationshipProperty _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new RelationshipProperty ReverseInstance
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
				return RelationshipPropertyID;
			}
			set
			{
				RelationshipPropertyID = value;
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
					_defaultSourceName = RelationshipName + "." + PropertyName;
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
		public RelationshipProperty SourceRelationshipProperty
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
		/// <summary>This property gets/sets the OldRelationshipPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldRelationshipPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldRelationshipID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldRelationshipID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldPropertyID { get; set; }
		
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
		
		protected Guid _relationshipPropertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the RelationshipPropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid RelationshipPropertyID
		{
			get
			{
				return _relationshipPropertyID;
			}
			set
			{
				if (_relationshipPropertyID != value)
				{
					_relationshipPropertyID = value;
					_isModified = true;
					base.OnPropertyChanged("RelationshipPropertyID");
				}
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
		
		protected string _propertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the PropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string PropertyName
		{
			get
			{
				return _propertyName;
			}
		}
		
		protected int _dataTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DataTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int DataTypeCode
		{
			get
			{
				return _dataTypeCode;
			}
		}
		
		protected string _referencedPropertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedPropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ReferencedPropertyName
		{
			get
			{
				return _referencedPropertyName;
			}
		}
		
		protected int _referencedDataTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedDataTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int ReferencedDataTypeCode
		{
			get
			{
				return _referencedDataTypeCode;
			}
		}
		
		protected string _relationshipName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the RelationshipName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string RelationshipName
		{
			get
			{
				return _relationshipName;
			}
		}
		
		protected BLL.Entities.Property _property = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Property.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Property Property
		{
			get
			{
				return _property;
			}
			set
			{
				if (value != null)
				{
					_propertyName = value.PropertyName;
					_dataTypeCode = value.DataTypeCode;
					if (_property != null && _property.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					PropertyID = value.PropertyID;
				}
				_property = value;
			}
		}
		
		protected BLL.Entities.Property _referencedProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ReferencedProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Property ReferencedProperty
		{
			get
			{
				return _referencedProperty;
			}
			set
			{
				if (value != null)
				{
					_referencedPropertyName = value.PropertyName;
					_referencedDataTypeCode = value.DataTypeCode;
					if (_referencedProperty != null && _referencedProperty.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ReferencedPropertyID = value.PropertyID;
				}
				_referencedProperty = value;
			}
		}
		
		protected BLL.Entities.Relationship _relationship = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Relationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Relationship Relationship
		{
			get
			{
				return _relationship;
			}
			set
			{
				if (value != null)
				{
					_relationshipName = value.RelationshipName;
					if (_relationship != null && _relationship.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					RelationshipID = value.RelationshipID;
				}
				_relationship = value;
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
				return "RelationshipPropertyID";
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
				return RelationshipPropertyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					RelationshipPropertyID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new RelationshipProperty();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new RelationshipProperty();
				ForwardInstance.RelationshipPropertyID = RelationshipPropertyID;
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
		/// <param name="inputRelationshipProperty">The relationshipproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(RelationshipProperty inputRelationshipProperty)
		{
			if (RelationshipID.GetGuid() != inputRelationshipProperty.RelationshipID.GetGuid()) return false;
			if (PropertyID.GetGuid() != inputRelationshipProperty.PropertyID.GetGuid()) return false;
			if (ReferencedPropertyID.GetGuid() != inputRelationshipProperty.ReferencedPropertyID.GetGuid()) return false;
			if (Order.GetInt() != inputRelationshipProperty.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputRelationshipProperty.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputRelationshipProperty.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputRelationshipProperty">The relationshipproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(RelationshipProperty inputRelationshipProperty)
		{
			if (inputRelationshipProperty == null) return true;
			if (inputRelationshipProperty.TagList.Count > 0) return false;
			if (RelationshipID != inputRelationshipProperty.RelationshipID) return false;
			if (PropertyID != inputRelationshipProperty.PropertyID) return false;
			if (ReferencedPropertyID != inputRelationshipProperty.ReferencedPropertyID) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputRelationshipProperty.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputRelationshipProperty.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputRelationshipProperty">The relationshipproperty to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(RelationshipProperty inputRelationshipProperty)
		{
			RelationshipID = inputRelationshipProperty.RelationshipID;
			PropertyID = inputRelationshipProperty.PropertyID;
			ReferencedPropertyID = inputRelationshipProperty.ReferencedPropertyID;
			Order = inputRelationshipProperty.Order;
			IsAutoUpdated = inputRelationshipProperty.IsAutoUpdated;
			Description = inputRelationshipProperty.Description;
			
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
				RelationshipPropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (RelationshipPropertyID == Guid.Empty)
				{
					RelationshipPropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = RelationshipPropertyID;
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
			Property = null;
			ReferencedProperty = null;
			Relationship = null;
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
					ReverseInstance = new RelationshipProperty();
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
			newItem.ItemID = RelationshipPropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public RelationshipProperty GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			RelationshipProperty forwardItem = new RelationshipProperty();
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
				forwardItem.RelationshipPropertyID = RelationshipPropertyID;
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
			if (forwardItem.PropertyID != Guid.Empty)
			{
				forwardItem.Property = Solution.PropertyList.FindByID(forwardItem.PropertyID);
				if (forwardItem.Property != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.Property.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.Property.CreateIDReference());
				}
			}
			if (forwardItem.ReferencedPropertyID != Guid.Empty)
			{
				forwardItem.ReferencedProperty = Solution.PropertyList.FindByID(forwardItem.ReferencedPropertyID);
				if (forwardItem.ReferencedProperty != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.ReferencedProperty.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.ReferencedProperty.CreateIDReference());
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
				if (modelContext is RelationshipProperty)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Relationship)
				{
					Relationship parent = modelContext as Relationship;
					if (parent.RelationshipPropertyList.Count > 0)
					{
						return parent.RelationshipPropertyList[DataHelper.GetRandomInt(0, parent.RelationshipPropertyList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.RelationshipPropertyList.Count > 0)
			{
				return solutionContext.RelationshipPropertyList[DataHelper.GetRandomInt(0, solutionContext.RelationshipPropertyList.Count - 1)];
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
				if (nodeContext is Relationship)
				{
					return (nodeContext as Relationship).RelationshipPropertyList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).RelationshipPropertyList;
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
			return Relationship;
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
			if (solutionContext.CurrentRelationshipProperty != null)
			{
				string validationErrors = solutionContext.CurrentRelationshipProperty.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentRelationshipProperty, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				RelationshipProperty existingItem = solutionContext.RelationshipPropertyList.Find(i => i.RelationshipPropertyID == solutionContext.CurrentRelationshipProperty.RelationshipPropertyID);
				if (existingItem == null)
				{
					solutionContext.CurrentRelationshipProperty.Solution = solutionContext;
					Property property = solutionContext.PropertyList.Find(i => i.PropertyID == solutionContext.CurrentRelationshipProperty.PropertyID);
					if (property != null)
					{
						solutionContext.CurrentRelationshipProperty.Property = property;
						property.RelationshipPropertyList.Add(solutionContext.CurrentRelationshipProperty);
					}
					Property referencedProperty = solutionContext.PropertyList.Find(i => i.PropertyID == solutionContext.CurrentRelationshipProperty.ReferencedPropertyID);
					if (referencedProperty != null)
					{
						solutionContext.CurrentRelationshipProperty.ReferencedProperty = referencedProperty;
						referencedProperty.ReferencedRelationshipPropertyList.Add(solutionContext.CurrentRelationshipProperty);
					}
					Relationship relationship = solutionContext.RelationshipList.Find(i => i.RelationshipID == solutionContext.CurrentRelationshipProperty.RelationshipID);
					if (relationship != null)
					{
						solutionContext.CurrentRelationshipProperty.Relationship = relationship;
						relationship.RelationshipPropertyList.Add(solutionContext.CurrentRelationshipProperty);
					}
					solutionContext.CurrentRelationshipProperty.SetID();
					solutionContext.CurrentRelationshipProperty.AssignProperty("RelationshipPropertyID", solutionContext.CurrentRelationshipProperty.RelationshipPropertyID);
					RelationshipProperty foundItem = solutionContext.RelationshipPropertiesToMerge.Find(i => i.RelationshipPropertyID == solutionContext.CurrentRelationshipProperty.RelationshipPropertyID);
					if (foundItem != null)
					{
						RelationshipProperty forwardItem = new RelationshipProperty();
						forwardItem.TransformDataFromObject(foundItem, null, false);
						solutionContext.CurrentRelationshipProperty.ForwardInstance = forwardItem;
						solutionContext.CurrentRelationshipProperty.TransformDataFromObject(forwardItem, null, false, true);
						solutionContext.RelationshipPropertiesToMerge.Remove(foundItem);
					}
					
					#region protected
					#endregion protected
					
					solutionContext.RelationshipPropertyList.Add(solutionContext.CurrentRelationshipProperty);
					solutionContext.CurrentRelationshipProperty.ReverseInstance.ResetModified(false);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current RelationshipProperty item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentRelationshipProperty != null)
			{
				RelationshipProperty existingItem = solutionContext.RelationshipPropertyList.Find(i => i.RelationshipPropertyID == solutionContext.CurrentRelationshipProperty.RelationshipPropertyID);
				if (existingItem != null)
				{
					solutionContext.RelationshipPropertyList.Remove(solutionContext.CurrentRelationshipProperty);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the RelationshipProperty instance from an xml file.</summary>
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
		/// <summary>This method saves the RelationshipProperty instance to an xml file.</summary>
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
		public RelationshipProperty(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic RelationshipProperty instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public RelationshipProperty(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic RelationshipProperty instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="relationshipPropertyID">The input value for RelationshipPropertyID.</param>
		///--------------------------------------------------------------------------------
		public RelationshipProperty(Guid relationshipPropertyID)
		{
			RelationshipPropertyID = relationshipPropertyID;
		}
		#endregion "Constructors"
	}
}