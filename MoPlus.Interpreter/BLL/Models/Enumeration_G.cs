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
	/// specific Enumeration instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Enumeration")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Enumeration : BusinessObjectBase
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
			
			error = GetValidationError("EnumerationName");
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
				case "_enumerationName":
				case "EnumerationName":
					error = ValidateEnumerationName();
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
		/// <summary>This method validates EnumerationName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateEnumerationName()
		{
			if (!Regex.IsMatch(EnumerationName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "EnumerationName");
			}
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
		
		private Enumeration _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Enumeration ForwardInstance
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
		
		private Enumeration _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Enumeration ReverseInstance
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
				return EnumerationID;
			}
			set
			{
				EnumerationID = value;
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
				return EnumerationName;
			}
			set
			{
				EnumerationName = value;
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
				return SourceEnumeration.EnumerationName;
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
						_displayName = ModelName + "." + EnumerationName;
					}
					else
					{
						_displayName = EnumerationName;
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
						_defaultSourceName = Model.DefaultSourceName + "." + DefaultSourcePrefix + SourceEnumeration.EnumerationName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceEnumeration.EnumerationName;
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
		public Enumeration SourceEnumeration
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
		/// <summary>This property gets/sets the OldEnumerationID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldEnumerationID { get; set; }
		
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
		
		protected Guid _enumerationID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EnumerationID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid EnumerationID
		{
			get
			{
				return _enumerationID;
			}
			set
			{
				if (_enumerationID != value)
				{
					_enumerationID = value;
					_isModified = true;
					base.OnPropertyChanged("EnumerationID");
				}
			}
		}
		
		protected string _enumerationName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EnumerationName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string EnumerationName
		{
			get
			{
				return _enumerationName;
			}
			set
			{
				if (_enumerationName != value)
				{
					_enumerationName = value;
					_isModified = true;
					base.OnPropertyChanged("EnumerationName");
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
		
		protected EnterpriseDataObjectList<BLL.Models.Value> _valueList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Enumeration.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.Value> ValueList
		{
			get
			{
				if (_valueList == null)
				{
					_valueList = new EnterpriseDataObjectList<BLL.Models.Value>();
				}
				return _valueList;
			}
			set
			{
				if (_valueList == null || _valueList.Equals(value) == false)
				{
					_valueList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ValueList")]
		[XmlArrayItem(typeof(BLL.Models.Value), ElementName = "Value")]
		[DataMember(Name = "ValueList")]
		[DataArrayItem(ElementName = "ValueList")]
		public virtual EnterpriseDataObjectList<BLL.Models.Value> _S_ValueList
		{
			get
			{
				return _valueList;
			}
			set
			{
				_valueList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.ModelProperty> _definedByModelPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Enumeration.</summary>
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
				return "EnumerationID";
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
				return EnumerationID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					EnumerationID = primaryKeyValues[0].GetGuid();
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
				if (_valueList != null && _valueList.IsModified == true) return true;
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
				ReverseInstance = new Enumeration();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Enumeration();
				ForwardInstance.EnumerationID = EnumerationID;
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
			foreach (Value value in ValueList)
			{
				value.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputEnumeration">The enumeration to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Enumeration inputEnumeration)
		{
			if (EnumerationName.GetString() != inputEnumeration.EnumerationName.GetString()) return false;
			if (ModelID.GetGuid() != inputEnumeration.ModelID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputEnumeration.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputEnumeration.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputEnumeration">The enumeration to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Enumeration inputEnumeration)
		{
			if (inputEnumeration == null) return true;
			if (inputEnumeration.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputEnumeration.EnumerationName)) return false;
			if (ModelID != inputEnumeration.ModelID) return false;
			if (IsAutoUpdated != inputEnumeration.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputEnumeration.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputEnumeration">The enumeration to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Enumeration inputEnumeration)
		{
			EnumerationName = inputEnumeration.EnumerationName;
			ModelID = inputEnumeration.ModelID;
			IsAutoUpdated = inputEnumeration.IsAutoUpdated;
			Description = inputEnumeration.Description;
			
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
				EnumerationID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (EnumerationID == Guid.Empty)
				{
					EnumerationID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = EnumerationID;
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
			if (_valueList != null)
			{
				foreach (Value item in ValueList)
				{
					item.Dispose();
				}
				ValueList.Clear();
				ValueList = null;
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
					ReverseInstance = new Enumeration();
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
			newItem.ItemID = EnumerationID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Enumeration GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Enumeration forwardItem = new Enumeration();
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
				forwardItem.EnumerationID = EnumerationID;
			}
			foreach (Value item in ValueList)
			{
				item.Enumeration = this;
				Value forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ValueList.Add(forwardChildItem);
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
				if (modelContext is Enumeration)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Model)
				{
					solutionContext.NeedsSample = false;
					Model parent = modelContext as Model;
					if (parent.EnumerationList.Count > 0)
					{
						return parent.EnumerationList[DataHelper.GetRandomInt(0, parent.EnumerationList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.EnumerationList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.EnumerationList[DataHelper.GetRandomInt(0, solutionContext.EnumerationList.Count - 1)];
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
					return (nodeContext as Model).EnumerationList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).EnumerationList;
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
				Enumeration enumeration = model.EnumerationList.Find(i => i.EnumerationID == EnumerationID);
				if (enumeration != null)
				{
					if (enumeration != this)
					{
						model.EnumerationList.Remove(enumeration);
						model.EnumerationList.Add(this);
					}
				}
				else
				{
					model.EnumerationList.Add(this);
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
			if (solutionContext.CurrentEnumeration != null)
			{
				string validationErrors = solutionContext.CurrentEnumeration.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentEnumeration, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentEnumeration.Solution = solutionContext;
				solutionContext.CurrentEnumeration.AddToParent();
				Enumeration existingItem = solutionContext.EnumerationList.Find(i => i.EnumerationID == solutionContext.CurrentEnumeration.EnumerationID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentEnumeration.AssignProperty("EnumerationID", solutionContext.CurrentEnumeration.EnumerationID);
					solutionContext.CurrentEnumeration.ReverseInstance.ResetModified(false);
					solutionContext.EnumerationList.Add(solutionContext.CurrentEnumeration);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Enumeration();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentEnumeration, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("EnumerationID", existingItem.EnumerationID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentEnumeration = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Enumeration item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentEnumeration != null)
			{
				Enumeration existingItem = solutionContext.EnumerationList.Find(i => i.EnumerationID == solutionContext.CurrentEnumeration.EnumerationID);
				if (existingItem != null)
				{
					solutionContext.EnumerationList.Remove(solutionContext.CurrentEnumeration);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Enumeration instance from an xml file.</summary>
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
		/// <summary>This method saves the Enumeration instance to an xml file.</summary>
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
			if (_valueList != null) _valueList.ResetLoaded(isLoaded);
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
			if (_valueList != null) _valueList.ResetModified(isModified);
			if (_definedByModelPropertyList != null) _definedByModelPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Enumeration(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Enumeration instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Enumeration(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Enumeration instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="enumerationID">The input value for EnumerationID.</param>
		///--------------------------------------------------------------------------------
		public Enumeration(Guid enumerationID)
		{
			EnumerationID = enumerationID;
		}
		#endregion "Constructors"
	}
}