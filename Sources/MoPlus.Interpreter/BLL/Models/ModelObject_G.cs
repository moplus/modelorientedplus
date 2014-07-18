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
	/// specific ModelObject instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/18/2014</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="ModelObject")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class ModelObject : BusinessObjectBase
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
			
			error = GetValidationError("ModelObjectName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ParentModelObjectID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ModelID");
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
				case "_modelObjectName":
				case "ModelObjectName":
					error = ValidateModelObjectName();
					break;
				case "_parentModelObjectID":
				case "ParentModelObjectID":
					error = ValidateParentModelObjectID();
					break;
				case "_modelID":
				case "ModelID":
					error = ValidateModelID();
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
		/// <summary>This method validates ModelObjectName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateModelObjectName()
		{
			if (!Regex.IsMatch(ModelObjectName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "ModelObjectName");
			}
			#region protected
			if (Solution != null && Solution.ModelObjectList.Find(o => o.ModelObjectName == ModelObjectName && o.ModelObjectID != ModelObjectID) != null)
			{
				return String.Format(Resources.DisplayValues.Validation_DuplicateModelObjectFound, ModelObjectName);
			}
			if (GrammarHelper.IsReservedWord(ModelObjectName) == true)
			{
				return String.Format(Resources.DisplayValues.Validation_ModelObjectReservedWordConflict, ModelObjectName);
			}
			#endregion protected
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ParentModelObjectID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateParentModelObjectID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ModelID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateModelID()
		{
			if (ModelID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ModelID");
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
		
		private ModelObject _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ModelObject ForwardInstance
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
		
		private ModelObject _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new ModelObject ReverseInstance
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
				return ModelObjectID;
			}
			set
			{
				ModelObjectID = value;
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
				return ModelObjectName;
			}
			set
			{
				ModelObjectName = value;
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
				return SourceModelObject.ModelObjectName;
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
					if (!String.IsNullOrEmpty(ModelName))
					{
						_displayName = ModelName + "." + ModelObjectName;
					}
					else
					{
						_displayName = ModelObjectName;
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
					if (Model != null)
					{
						_defaultSourceName = Model.DefaultSourceName + "." + DefaultSourcePrefix + SourceModelObject.ModelObjectName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceModelObject.ModelObjectName;
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
		public ModelObject SourceModelObject
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
		/// <summary>This property gets/sets the OldModelObjectID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelObjectID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldParentModelObjectID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldParentModelObjectID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldModelID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelID { get; set; }
		
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
		
		protected string _modelObjectName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelObjectName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ModelObjectName
		{
			get
			{
				return _modelObjectName;
			}
			set
			{
				if (_modelObjectName != value)
				{
					_modelObjectName = value;
					_isModified = true;
					base.OnPropertyChanged("ModelObjectName");
				}
			}
		}
		
		protected Guid? _parentModelObjectID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ParentModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? ParentModelObjectID
		{
			get
			{
				return _parentModelObjectID;
			}
			set
			{
				if (_parentModelObjectID != value)
				{
					_parentModelObjectID = value;
					_isModified = true;
					base.OnPropertyChanged("ParentModelObjectID");
				}
			}
		}
		
		protected Guid _modelID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ModelID
		{
			get
			{
				return _modelID;
			}
			set
			{
				if (_modelID != value)
				{
					_modelID = value;
					_isModified = true;
					base.OnPropertyChanged("ModelID");
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
		
		protected string _modelName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ModelName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ModelName
		{
			get
			{
				return _modelName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.ModelProperty> _modelPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of ModelObject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.ModelProperty> ModelPropertyList
		{
			get
			{
				if (_modelPropertyList == null)
				{
					_modelPropertyList = new EnterpriseDataObjectList<BLL.Models.ModelProperty>();
				}
				return _modelPropertyList;
			}
			set
			{
				if (_modelPropertyList == null || _modelPropertyList.Equals(value) == false)
				{
					_modelPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ModelPropertyList")]
		[XmlArrayItem(typeof(BLL.Models.ModelProperty), ElementName = "ModelProperty")]
		[DataMember(Name = "ModelPropertyList")]
		[DataArrayItem(ElementName = "ModelPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Models.ModelProperty> _S_ModelPropertyList
		{
			get
			{
				return _modelPropertyList;
			}
			set
			{
				_modelPropertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.ObjectInstance> _objectInstanceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of ModelObject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.ObjectInstance> ObjectInstanceList
		{
			get
			{
				if (_objectInstanceList == null)
				{
					_objectInstanceList = new EnterpriseDataObjectList<BLL.Models.ObjectInstance>();
				}
				return _objectInstanceList;
			}
			set
			{
				if (_objectInstanceList == null || _objectInstanceList.Equals(value) == false)
				{
					_objectInstanceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ObjectInstanceList")]
		[XmlArrayItem(typeof(BLL.Models.ObjectInstance), ElementName = "ObjectInstance")]
		[DataMember(Name = "ObjectInstanceList")]
		[DataArrayItem(ElementName = "ObjectInstanceList")]
		public virtual EnterpriseDataObjectList<BLL.Models.ObjectInstance> _S_ObjectInstanceList
		{
			get
			{
				return _objectInstanceList;
			}
			set
			{
				_objectInstanceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.ModelProperty> _definedByModelPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of ModelObject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.ModelProperty> DefinedByModelPropertyList
		{
			get
			{
				if (_definedByModelPropertyList == null)
				{
					_definedByModelPropertyList = new EnterpriseDataObjectList<BLL.Models.ModelProperty>();
				}
				return _definedByModelPropertyList;
			}
			set
			{
				if (_definedByModelPropertyList == null || _definedByModelPropertyList.Equals(value) == false)
				{
					_definedByModelPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "DefinedByModelPropertyList")]
		[XmlArrayItem(typeof(BLL.Models.ModelProperty), ElementName = "ModelProperty")]
		[DataMember(Name = "DefinedByModelPropertyList")]
		[DataArrayItem(ElementName = "DefinedByModelPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Models.ModelProperty> _S_DefinedByModelPropertyList
		{
			get
			{
				return _definedByModelPropertyList;
			}
			set
			{
				_definedByModelPropertyList = value;
			}
		}
		
		protected BLL.Models.Model _model = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Model.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Models.Model Model
		{
			get
			{
				return _model;
			}
			set
			{
				if (value != null)
				{
					_modelName = value.ModelName;
					if (_model != null && _model.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ModelID = value.ModelID;
				}
				_model = value;
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
				return "ModelObjectID";
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
				return ModelObjectID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					ModelObjectID = primaryKeyValues[0].GetGuid();
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
				if (_modelPropertyList != null && _modelPropertyList.IsModified == true) return true;
				if (_objectInstanceList != null && _objectInstanceList.IsModified == true) return true;
				if (_definedByModelPropertyList != null && _definedByModelPropertyList.IsModified == true) return true;
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
				ReverseInstance = new ModelObject();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new ModelObject();
				ForwardInstance.ModelObjectID = ModelObjectID;
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
			foreach (ModelProperty modelProperty in ModelPropertyList)
			{
				modelProperty.AddItemToUsedTags(usedTags);
			}
			foreach (ObjectInstance objectInstance in ObjectInstanceList)
			{
				objectInstance.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputModelObject">The modelobject to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(ModelObject inputModelObject)
		{
			if (ModelObjectName.GetString() != inputModelObject.ModelObjectName.GetString()) return false;
			if (ParentModelObjectID.GetGuid() != inputModelObject.ParentModelObjectID.GetGuid()) return false;
			if (ModelID.GetGuid() != inputModelObject.ModelID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputModelObject.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputModelObject.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputModelObject">The modelobject to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(ModelObject inputModelObject)
		{
			if (inputModelObject == null) return true;
			if (inputModelObject.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputModelObject.ModelObjectName)) return false;
			if (ParentModelObjectID != inputModelObject.ParentModelObjectID) return false;
			if (ModelID != inputModelObject.ModelID) return false;
			if (IsAutoUpdated != inputModelObject.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputModelObject.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputModelObject">The modelobject to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(ModelObject inputModelObject)
		{
			ModelObjectName = inputModelObject.ModelObjectName;
			ParentModelObjectID = inputModelObject.ParentModelObjectID;
			ModelID = inputModelObject.ModelID;
			IsAutoUpdated = inputModelObject.IsAutoUpdated;
			Description = inputModelObject.Description;
			
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
				ModelObjectID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (ModelObjectID == Guid.Empty)
				{
					ModelObjectID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = ModelObjectID;
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
			Model = null;
			Solution = null;
			if (_modelPropertyList != null)
			{
				foreach (ModelProperty item in ModelPropertyList)
				{
					item.Dispose();
				}
				ModelPropertyList.Clear();
				ModelPropertyList = null;
			}
			if (_objectInstanceList != null)
			{
				foreach (ObjectInstance item in ObjectInstanceList)
				{
					item.Dispose();
				}
				ObjectInstanceList.Clear();
				ObjectInstanceList = null;
			}
			if (_definedByModelPropertyList != null)
			{
				foreach (ModelProperty item in DefinedByModelPropertyList)
				{
					item.Dispose();
				}
				DefinedByModelPropertyList.Clear();
				DefinedByModelPropertyList = null;
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
					ReverseInstance = new ModelObject();
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
			newItem.ItemID = ModelObjectID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			ModelObject forwardItem = new ModelObject();
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
				forwardItem.ModelObjectID = ModelObjectID;
			}
			foreach (ModelProperty item in ModelPropertyList)
			{
				item.ModelObject = this;
				ModelProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ModelPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (ObjectInstance item in ObjectInstanceList)
			{
				item.ModelObject = this;
				ObjectInstance forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ObjectInstanceList.Add(forwardChildItem);
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
				if (modelContext is ModelObject)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Model)
				{
					solutionContext.NeedsSample = false;
					Model parent = modelContext as Model;
					if (parent.ModelObjectList.Count > 0)
					{
						return parent.ModelObjectList[DataHelper.GetRandomInt(0, parent.ModelObjectList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.ModelObjectList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.ModelObjectList[DataHelper.GetRandomInt(0, solutionContext.ModelObjectList.Count - 1)];
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
				if (nodeContext is Model)
				{
					return (nodeContext as Model).ModelObjectList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).ModelObjectList;
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
			return Model;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Model model = Solution.ModelList.Find(i => i.ModelID == ModelID);
			if (model != null)
			{
				Model = model;
				SetID();  // id (from saved ids) may change based on parent info
				ModelObject modelObject = model.ModelObjectList.Find(i => i.ModelObjectID == ModelObjectID);
				if (modelObject != null)
				{
					if (modelObject != this)
					{
						model.ModelObjectList.Remove(modelObject);
						model.ModelObjectList.Add(this);
					}
				}
				else
				{
					model.ModelObjectList.Add(this);
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
			if (solutionContext.CurrentModelObject != null)
			{
				string validationErrors = solutionContext.CurrentModelObject.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentModelObject, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentModelObject.Solution = solutionContext;
				solutionContext.CurrentModelObject.AddToParent();
				ModelObject existingItem = solutionContext.ModelObjectList.Find(i => i.ModelObjectID == solutionContext.CurrentModelObject.ModelObjectID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentModelObject.AssignProperty("ModelObjectID", solutionContext.CurrentModelObject.ModelObjectID);
					solutionContext.CurrentModelObject.ReverseInstance.ResetModified(false);
					solutionContext.ModelObjectList.Add(solutionContext.CurrentModelObject);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new ModelObject();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentModelObject, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("ModelObjectID", existingItem.ModelObjectID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentModelObject = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current ModelObject item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentModelObject != null)
			{
				ModelObject existingItem = solutionContext.ModelObjectList.Find(i => i.ModelObjectID == solutionContext.CurrentModelObject.ModelObjectID);
				if (existingItem != null)
				{
					solutionContext.ModelObjectList.Remove(solutionContext.CurrentModelObject);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the ModelObject instance from an xml file.</summary>
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
		/// <summary>This method saves the ModelObject instance to an xml file.</summary>
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
			if (_modelPropertyList != null) _modelPropertyList.ResetLoaded(isLoaded);
			if (_objectInstanceList != null) _objectInstanceList.ResetLoaded(isLoaded);
			if (_definedByModelPropertyList != null) _definedByModelPropertyList.ResetLoaded(isLoaded);
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
			if (_modelPropertyList != null) _modelPropertyList.ResetModified(isModified);
			if (_objectInstanceList != null) _objectInstanceList.ResetModified(isModified);
			if (_definedByModelPropertyList != null) _definedByModelPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelObject(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic ModelObject instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public ModelObject(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic ModelObject instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="modelObjectID">The input value for ModelObjectID.</param>
		///--------------------------------------------------------------------------------
		public ModelObject(Guid modelObjectID)
		{
			ModelObjectID = modelObjectID;
		}
		#endregion "Constructors"
	}
}