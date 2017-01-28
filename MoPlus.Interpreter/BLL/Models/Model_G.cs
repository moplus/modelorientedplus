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
	/// specific Model instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Model")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Model : BusinessObjectBase
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
			
			error = GetValidationError("ModelName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SolutionID");
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
				case "_modelName":
				case "ModelName":
					error = ValidateModelName();
					break;
				case "_solutionID":
				case "SolutionID":
					error = ValidateSolutionID();
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
		/// <summary>This method validates ModelName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateModelName()
		{
			if (!Regex.IsMatch(ModelName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "ModelName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SolutionID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSolutionID()
		{
			if (SolutionID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "SolutionID");
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
		
		private Model _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Model ForwardInstance
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
		
		private Model _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Model ReverseInstance
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
				return ModelID;
			}
			set
			{
				ModelID = value;
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
				return ModelName;
			}
			set
			{
				ModelName = value;
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
				return SourceModel.ModelName;
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
						_displayName = SolutionName + "." + ModelName;
					}
					else
					{
						_displayName = ModelName;
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
					_defaultSourceName = DefaultSourcePrefix + SourceModel.ModelName;
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
		public Model SourceModel
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
		/// <summary>This property gets/sets the OldModelID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldModelID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSolutionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSolutionID { get; set; }
		
		
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
		
		protected string _modelName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ModelName
		{
			get
			{
				return _modelName;
			}
			set
			{
				if (_modelName != value)
				{
					_modelName = value;
					_isModified = true;
					base.OnPropertyChanged("ModelName");
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
		
		protected EnterpriseDataObjectList<BLL.Models.Enumeration> _enumerationList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Model.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.Enumeration> EnumerationList
		{
			get
			{
				if (_enumerationList == null)
				{
					_enumerationList = new EnterpriseDataObjectList<BLL.Models.Enumeration>();
				}
				return _enumerationList;
			}
			set
			{
				if (_enumerationList == null || _enumerationList.Equals(value) == false)
				{
					_enumerationList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "EnumerationList")]
		[XmlArrayItem(typeof(BLL.Models.Enumeration), ElementName = "Enumeration")]
		[DataMember(Name = "EnumerationList")]
		[DataArrayItem(ElementName = "EnumerationList")]
		public virtual EnterpriseDataObjectList<BLL.Models.Enumeration> _S_EnumerationList
		{
			get
			{
				return _enumerationList;
			}
			set
			{
				_enumerationList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.ModelObject> _modelObjectList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Model.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.ModelObject> ModelObjectList
		{
			get
			{
				if (_modelObjectList == null)
				{
					_modelObjectList = new EnterpriseDataObjectList<BLL.Models.ModelObject>();
				}
				return _modelObjectList;
			}
			set
			{
				if (_modelObjectList == null || _modelObjectList.Equals(value) == false)
				{
					_modelObjectList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ModelObjectList")]
		[XmlArrayItem(typeof(BLL.Models.ModelObject), ElementName = "ModelObject")]
		[DataMember(Name = "ModelObjectList")]
		[DataArrayItem(ElementName = "ModelObjectList")]
		public virtual EnterpriseDataObjectList<BLL.Models.ModelObject> _S_ModelObjectList
		{
			get
			{
				return _modelObjectList;
			}
			set
			{
				_modelObjectList = value;
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
				return "ModelID";
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
				return ModelID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					ModelID = primaryKeyValues[0].GetGuid();
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
				if (_enumerationList != null && _enumerationList.IsModified == true) return true;
				if (_modelObjectList != null && _modelObjectList.IsModified == true) return true;
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
				ReverseInstance = new Model();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Model();
				ForwardInstance.ModelID = ModelID;
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
			foreach (Enumeration enumeration in EnumerationList)
			{
				enumeration.AddItemToUsedTags(usedTags);
			}
			foreach (ModelObject modelObject in ModelObjectList)
			{
				modelObject.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputModel">The model to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Model inputModel)
		{
			if (ModelName.GetString() != inputModel.ModelName.GetString()) return false;
			if (SolutionID.GetGuid() != inputModel.SolutionID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputModel.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputModel.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputModel">The model to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Model inputModel)
		{
			if (inputModel == null) return true;
			if (inputModel.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputModel.ModelName)) return false;
			if (SolutionID != inputModel.SolutionID) return false;
			if (IsAutoUpdated != inputModel.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputModel.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputModel">The model to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Model inputModel)
		{
			ModelName = inputModel.ModelName;
			SolutionID = inputModel.SolutionID;
			IsAutoUpdated = inputModel.IsAutoUpdated;
			Description = inputModel.Description;
			
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
				ModelID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (ModelID == Guid.Empty)
				{
					ModelID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = ModelID;
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
			if (_enumerationList != null)
			{
				foreach (Enumeration item in EnumerationList)
				{
					item.Dispose();
				}
				EnumerationList.Clear();
				EnumerationList = null;
			}
			if (_modelObjectList != null)
			{
				foreach (ModelObject item in ModelObjectList)
				{
					item.Dispose();
				}
				ModelObjectList.Clear();
				ModelObjectList = null;
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
					ReverseInstance = new Model();
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
			newItem.ItemID = ModelID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Model GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Model forwardItem = new Model();
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
				forwardItem.ModelID = ModelID;
			}
			foreach (Enumeration item in EnumerationList)
			{
				item.Model = this;
				Enumeration forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.EnumerationList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (ModelObject item in ModelObjectList)
			{
				item.Model = this;
				ModelObject forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ModelObjectList.Add(forwardChildItem);
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
				if (modelContext is Model)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Solution)
				{
					solutionContext.NeedsSample = false;
					Solution parent = modelContext as Solution;
					if (parent.ModelList.Count > 0)
					{
						return parent.ModelList[DataHelper.GetRandomInt(0, parent.ModelList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.ModelList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.ModelList[DataHelper.GetRandomInt(0, solutionContext.ModelList.Count - 1)];
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
					return (nodeContext as Solution).ModelList;
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
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			SetID();
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
			if (solutionContext.CurrentModel != null)
			{
				string validationErrors = solutionContext.CurrentModel.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentModel, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentModel.Solution = solutionContext;
				solutionContext.CurrentModel.AddToParent();
				Model existingItem = solutionContext.ModelList.Find(i => i.ModelID == solutionContext.CurrentModel.ModelID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentModel.AssignProperty("ModelID", solutionContext.CurrentModel.ModelID);
					solutionContext.CurrentModel.ReverseInstance.ResetModified(false);
					solutionContext.ModelList.Add(solutionContext.CurrentModel);
				}
				else
				{
					// update existing item in solution
					if (existingItem.Solution == null) existingItem.Solution = solutionContext;
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Model();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentModel, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("ModelID", existingItem.ModelID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentModel = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Model item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentModel != null)
			{
				Model existingItem = solutionContext.ModelList.Find(i => i.ModelID == solutionContext.CurrentModel.ModelID);
				if (existingItem != null)
				{
					solutionContext.ModelList.Remove(solutionContext.CurrentModel);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Model instance from an xml file.</summary>
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
		/// <summary>This method saves the Model instance to an xml file.</summary>
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
			if (_enumerationList != null) _enumerationList.ResetLoaded(isLoaded);
			if (_modelObjectList != null) _modelObjectList.ResetLoaded(isLoaded);
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
			if (_enumerationList != null) _enumerationList.ResetModified(isModified);
			if (_modelObjectList != null) _modelObjectList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Model(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Model instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Model(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Model instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="modelID">The input value for ModelID.</param>
		///--------------------------------------------------------------------------------
		public Model(Guid modelID)
		{
			ModelID = modelID;
		}
		#endregion "Constructors"
	}
}