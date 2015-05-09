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
	/// specific ObjectInstance instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
    /// 
    /// The validation for parentobjectinstanceid was customized, this can be adjusted
    /// to be regenerated again.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>5/9/2015</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="ObjectInstance")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class ObjectInstance : BusinessObjectBase
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
			
			error = GetValidationError("ParentObjectInstanceID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ModelObjectID");
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
				case "_parentObjectInstanceID":
				case "ParentObjectInstanceID":
					error = ValidateParentObjectInstanceID();
					break;
				case "_modelObjectID":
				case "ModelObjectID":
					error = ValidateModelObjectID();
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
		/// <summary>This method validates ParentObjectInstanceID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateParentObjectInstanceID()
		{
            if (ModelObject != null && ModelObject.ParentModelObjectID != null)
            {
                if (ParentObjectInstanceID == null)
                {
                    return Resources.DisplayValues.Validation_ParentObjectInstance;
                }
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
		
		private ObjectInstance _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ObjectInstance ForwardInstance
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
		
		private ObjectInstance _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new ObjectInstance ReverseInstance
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
				return ObjectInstanceID;
			}
			set
			{
				ObjectInstanceID = value;
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
					_defaultSourceName = ModelObjectName + "." + SourceName;
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
		public ObjectInstance SourceObjectInstance
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
		/// <summary>This property gets/sets the OldObjectInstanceID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldObjectInstanceID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldParentObjectInstanceID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldParentObjectInstanceID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldModelObjectID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelObjectID { get; set; }
		
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
		
		protected Guid? _parentObjectInstanceID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ParentObjectInstanceID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? ParentObjectInstanceID
		{
			get
			{
				return _parentObjectInstanceID;
			}
			set
			{
				if (_parentObjectInstanceID != value)
				{
					_parentObjectInstanceID = value;
					_isModified = true;
					base.OnPropertyChanged("ParentObjectInstanceID");
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
		
		protected EnterpriseDataObjectList<BLL.Models.PropertyInstance> _propertyInstanceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of ObjectInstance.</summary>
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
		
		///-------------------------------------------------------------------------------
		/// <summary>This property gets the primary key properties.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyProperties
		{
			get
			{
				return "ObjectInstanceID";
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
				return ObjectInstanceID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					ObjectInstanceID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new ObjectInstance();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new ObjectInstance();
				ForwardInstance.ObjectInstanceID = ObjectInstanceID;
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
			foreach (PropertyInstance propertyInstance in PropertyInstanceList)
			{
				propertyInstance.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputObjectInstance">The objectinstance to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(ObjectInstance inputObjectInstance)
		{
			if (ParentObjectInstanceID.GetGuid() != inputObjectInstance.ParentObjectInstanceID.GetGuid()) return false;
			if (ModelObjectID.GetGuid() != inputObjectInstance.ModelObjectID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputObjectInstance.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputObjectInstance.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputObjectInstance">The objectinstance to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(ObjectInstance inputObjectInstance)
		{
			if (inputObjectInstance == null) return true;
			if (inputObjectInstance.TagList.Count > 0) return false;
			if (ParentObjectInstanceID != inputObjectInstance.ParentObjectInstanceID) return false;
			if (ModelObjectID != inputObjectInstance.ModelObjectID) return false;
			if (IsAutoUpdated != inputObjectInstance.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputObjectInstance.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputObjectInstance">The objectinstance to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(ObjectInstance inputObjectInstance)
		{
			ParentObjectInstanceID = inputObjectInstance.ParentObjectInstanceID;
			ModelObjectID = inputObjectInstance.ModelObjectID;
			IsAutoUpdated = inputObjectInstance.IsAutoUpdated;
			Description = inputObjectInstance.Description;
			
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
				ObjectInstanceID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (ObjectInstanceID == Guid.Empty)
				{
					ObjectInstanceID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = ObjectInstanceID;
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
			ModelObject = null;
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
					ReverseInstance = new ObjectInstance();
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
			newItem.ItemID = ObjectInstanceID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstance GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			ObjectInstance forwardItem = new ObjectInstance();
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
				forwardItem.ObjectInstanceID = ObjectInstanceID;
			}
			foreach (PropertyInstance item in PropertyInstanceList)
			{
				item.ObjectInstance = this;
				PropertyInstance forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyInstanceList.Add(forwardChildItem);
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
				if (modelContext is ObjectInstance)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is ModelObject)
				{
					solutionContext.NeedsSample = false;
					ModelObject parent = modelContext as ModelObject;
					if (parent.ObjectInstanceList.Count > 0)
					{
						return parent.ObjectInstanceList[DataHelper.GetRandomInt(0, parent.ObjectInstanceList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.ObjectInstanceList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.ObjectInstanceList[DataHelper.GetRandomInt(0, solutionContext.ObjectInstanceList.Count - 1)];
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
					return (nodeContext as ModelObject).ObjectInstanceList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).ObjectInstanceList;
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
				ObjectInstance objectInstance = modelObject.ObjectInstanceList.Find(i => i.ObjectInstanceID == ObjectInstanceID);
				if (objectInstance != null)
				{
					if (objectInstance != this)
					{
						modelObject.ObjectInstanceList.Remove(objectInstance);
						modelObject.ObjectInstanceList.Add(this);
					}
				}
				else
				{
					modelObject.ObjectInstanceList.Add(this);
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
			if (solutionContext.CurrentObjectInstance != null)
			{
				string validationErrors = solutionContext.CurrentObjectInstance.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentObjectInstance, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentObjectInstance.Solution = solutionContext;
				solutionContext.CurrentObjectInstance.AddToParent();
				ObjectInstance existingItem = solutionContext.ObjectInstanceList.Find(i => i.ObjectInstanceID == solutionContext.CurrentObjectInstance.ObjectInstanceID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentObjectInstance.AssignProperty("ObjectInstanceID", solutionContext.CurrentObjectInstance.ObjectInstanceID);
					solutionContext.CurrentObjectInstance.ReverseInstance.ResetModified(false);
					solutionContext.ObjectInstanceList.Add(solutionContext.CurrentObjectInstance);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new ObjectInstance();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentObjectInstance, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("ObjectInstanceID", existingItem.ObjectInstanceID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentObjectInstance = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current ObjectInstance item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentObjectInstance != null)
			{
				ObjectInstance existingItem = solutionContext.ObjectInstanceList.Find(i => i.ObjectInstanceID == solutionContext.CurrentObjectInstance.ObjectInstanceID);
				if (existingItem != null)
				{
					solutionContext.ObjectInstanceList.Remove(solutionContext.CurrentObjectInstance);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the ObjectInstance instance from an xml file.</summary>
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
		/// <summary>This method saves the ObjectInstance instance to an xml file.</summary>
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
		public ObjectInstance(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic ObjectInstance instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public ObjectInstance(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic ObjectInstance instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="objectInstanceID">The input value for ObjectInstanceID.</param>
		///--------------------------------------------------------------------------------
		public ObjectInstance(Guid objectInstanceID)
		{
			ObjectInstanceID = objectInstanceID;
		}
		#endregion "Constructors"
	}
}