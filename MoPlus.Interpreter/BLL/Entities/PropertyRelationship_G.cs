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
	/// specific PropertyRelationship instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>9/4/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="PropertyRelationship")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class PropertyRelationship : BusinessObjectBase
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
			
			error = GetValidationError("PropertyID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("RelationshipID");
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
				case "_propertyID":
				case "PropertyID":
					error = ValidatePropertyID();
					break;
				case "_relationshipID":
				case "RelationshipID":
					error = ValidateRelationshipID();
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
		
		private PropertyRelationship _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyRelationship ForwardInstance
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
		
		private PropertyRelationship _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new PropertyRelationship ReverseInstance
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
				return PropertyRelationshipID;
			}
			set
			{
				PropertyRelationshipID = value;
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
					_defaultSourceName =  PropertyID.ToString() + "." + RelationshipName;
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
		public PropertyRelationship SourcePropertyRelationship
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
		/// <summary>This property gets/sets the OldPropertyRelationshipID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldPropertyRelationshipID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldRelationshipID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldRelationshipID { get; set; }
		
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
		
		protected Guid _propertyRelationshipID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyRelationshipID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid PropertyRelationshipID
		{
			get
			{
				return _propertyRelationshipID;
			}
			set
			{
				if (_propertyRelationshipID != value)
				{
					_propertyRelationshipID = value;
					_isModified = true;
					base.OnPropertyChanged("PropertyRelationshipID");
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
		
		protected BLL.Solutions.PropertyBase _propertyBase = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the PropertyBase.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Solutions.PropertyBase PropertyBase
		{
			get
			{
				return _propertyBase;
			}
			set
			{
				if (value != null)
				{
					if (_propertyBase != null && _propertyBase.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					PropertyID = value.PropertyID;
				}
				_propertyBase = value;
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
				return "PropertyRelationshipID";
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
				return PropertyRelationshipID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					PropertyRelationshipID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new PropertyRelationship();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new PropertyRelationship();
				ForwardInstance.PropertyRelationshipID = PropertyRelationshipID;
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
		/// <param name="inputPropertyRelationship">The propertyrelationship to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(PropertyRelationship inputPropertyRelationship)
		{
			if (PropertyID.GetGuid() != inputPropertyRelationship.PropertyID.GetGuid()) return false;
			if (RelationshipID.GetGuid() != inputPropertyRelationship.RelationshipID.GetGuid()) return false;
			if (Order.GetInt() != inputPropertyRelationship.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputPropertyRelationship.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputPropertyRelationship.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputPropertyRelationship">The propertyrelationship to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(PropertyRelationship inputPropertyRelationship)
		{
			if (inputPropertyRelationship == null) return true;
			if (inputPropertyRelationship.TagList.Count > 0) return false;
			if (PropertyID != inputPropertyRelationship.PropertyID) return false;
			if (RelationshipID != inputPropertyRelationship.RelationshipID) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputPropertyRelationship.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputPropertyRelationship.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputPropertyRelationship">The propertyrelationship to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(PropertyRelationship inputPropertyRelationship)
		{
			PropertyID = inputPropertyRelationship.PropertyID;
			RelationshipID = inputPropertyRelationship.RelationshipID;
			Order = inputPropertyRelationship.Order;
			IsAutoUpdated = inputPropertyRelationship.IsAutoUpdated;
			Description = inputPropertyRelationship.Description;
			
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
				PropertyRelationshipID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (PropertyRelationshipID == Guid.Empty)
				{
					PropertyRelationshipID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = PropertyRelationshipID;
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
			Relationship = null;
			PropertyBase = null;
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
					ReverseInstance = new PropertyRelationship();
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
			newItem.ItemID = PropertyRelationshipID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public PropertyRelationship GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			PropertyRelationship forwardItem = new PropertyRelationship();
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
				forwardItem.PropertyRelationshipID = PropertyRelationshipID;
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
			if (forwardItem.RelationshipID != Guid.Empty)
			{
				forwardItem.Relationship = Solution.RelationshipList.FindByID(forwardItem.RelationshipID);
				if (forwardItem.Relationship != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.Relationship.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.Relationship.CreateIDReference());
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
				if (modelContext is PropertyRelationship)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is PropertyBase)
				{
					solutionContext.NeedsSample = false;
					PropertyBase parent = modelContext as PropertyBase;
					if (parent.PropertyRelationshipList.Count > 0)
					{
						return parent.PropertyRelationshipList[DataHelper.GetRandomInt(0, parent.PropertyRelationshipList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.PropertyRelationshipList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.PropertyRelationshipList[DataHelper.GetRandomInt(0, solutionContext.PropertyRelationshipList.Count - 1)];
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
				if (nodeContext is PropertyBase)
				{
					return (nodeContext as PropertyBase).PropertyRelationshipList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).PropertyRelationshipList;
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
			return PropertyBase;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			PropertyBase propertyBase = Solution.PropertyBaseList.Find(i => i.PropertyID == PropertyID);
			if (propertyBase != null)
			{
				PropertyBase = propertyBase;
				SetID();  // id (from saved ids) may change based on parent info
				PropertyRelationship propertyRelationship = propertyBase.PropertyRelationshipList.Find(i => i.PropertyRelationshipID == PropertyRelationshipID);
				if (propertyRelationship != null)
				{
					if (propertyRelationship != this)
					{
						propertyBase.PropertyRelationshipList.Remove(propertyRelationship);
						propertyBase.PropertyRelationshipList.Add(this);
					}
				}
				else
				{
					propertyBase.PropertyRelationshipList.Add(this);
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
			if (solutionContext.CurrentPropertyRelationship != null)
			{
				string validationErrors = solutionContext.CurrentPropertyRelationship.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentPropertyRelationship, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentPropertyRelationship.Solution = solutionContext;
				solutionContext.CurrentPropertyRelationship.AddToParent();
				PropertyRelationship existingItem = solutionContext.PropertyRelationshipList.Find(i => i.PropertyRelationshipID == solutionContext.CurrentPropertyRelationship.PropertyRelationshipID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentPropertyRelationship.AssignProperty("PropertyRelationshipID", solutionContext.CurrentPropertyRelationship.PropertyRelationshipID);
					solutionContext.CurrentPropertyRelationship.ReverseInstance.ResetModified(false);
					solutionContext.PropertyRelationshipList.Add(solutionContext.CurrentPropertyRelationship);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new PropertyRelationship();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentPropertyRelationship, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("PropertyRelationshipID", existingItem.PropertyRelationshipID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentPropertyRelationship = existingItem;
				}
				#region protected
						PropertyReference parentProperty = solutionContext.PropertyReferenceList.FindByID(solutionContext.CurrentPropertyRelationship.PropertyID);
						if (parentProperty != null)
						{
							solutionContext.CurrentPropertyRelationship.PropertyBase = parentProperty;
							parentProperty.PropertyRelationshipList.Add(solutionContext.CurrentPropertyRelationship);
						}
						else
						{
							Collection parentProperty2 = solutionContext.CollectionList.FindByID(solutionContext.CurrentPropertyRelationship.PropertyID);
							if (parentProperty2 != null)
							{
								solutionContext.CurrentPropertyRelationship.PropertyBase = parentProperty2;
								parentProperty2.PropertyRelationshipList.Add(solutionContext.CurrentPropertyRelationship);
							}
							else
							{
								EntityReference parentProperty3 = solutionContext.EntityReferenceList.FindByID(solutionContext.CurrentPropertyRelationship.PropertyID);
								if (parentProperty3 != null)
								{
									solutionContext.CurrentPropertyRelationship.PropertyBase = parentProperty3;
									parentProperty3.PropertyRelationshipList.Add(solutionContext.CurrentPropertyRelationship);
								}
							}
						}
						#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current PropertyRelationship item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentPropertyRelationship != null)
			{
				PropertyRelationship existingItem = solutionContext.PropertyRelationshipList.Find(i => i.PropertyRelationshipID == solutionContext.CurrentPropertyRelationship.PropertyRelationshipID);
				if (existingItem != null)
				{
					solutionContext.PropertyRelationshipList.Remove(solutionContext.CurrentPropertyRelationship);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the PropertyRelationship instance from an xml file.</summary>
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
		/// <summary>This method saves the PropertyRelationship instance to an xml file.</summary>
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
		public PropertyRelationship(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic PropertyRelationship instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public PropertyRelationship(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic PropertyRelationship instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="propertyRelationshipID">The input value for PropertyRelationshipID.</param>
		///--------------------------------------------------------------------------------
		public PropertyRelationship(Guid propertyRelationshipID)
		{
			PropertyRelationshipID = propertyRelationshipID;
		}
		#endregion "Constructors"
	}
}