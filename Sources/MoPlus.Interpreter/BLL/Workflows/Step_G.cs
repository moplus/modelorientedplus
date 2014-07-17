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

namespace MoPlus.Interpreter.BLL.Workflows
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific Step instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Step")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Step : BusinessObjectBase
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
			
			error = GetValidationError("StepName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("StageID");
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
				case "_stepName":
				case "StepName":
					error = ValidateStepName();
					break;
				case "_stageID":
				case "StageID":
					error = ValidateStageID();
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
		/// <summary>This method validates StepName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStepName()
		{
			if (!Regex.IsMatch(StepName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "StepName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates StageID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStageID()
		{
			if (StageID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "StageID");
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
		
		private Step _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Step ForwardInstance
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
		
		private Step _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Step ReverseInstance
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
				return StepID;
			}
			set
			{
				StepID = value;
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
				return StepName;
			}
			set
			{
				StepName = value;
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
				return SourceStep.StepName;
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
					if (!String.IsNullOrEmpty(StageName))
					{
						_displayName = StageName + "." + StepName;
					}
					else
					{
						_displayName = StepName;
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
					if (Stage != null)
					{
						_defaultSourceName = Stage.DefaultSourceName + "." + DefaultSourcePrefix + SourceStep.StepName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceStep.StepName;
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
		public Step SourceStep
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
		/// <summary>This property gets/sets the OldStepID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStepID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldStageID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStageID { get; set; }
		
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
		
		protected Guid _stepID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StepID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StepID
		{
			get
			{
				return _stepID;
			}
			set
			{
				if (_stepID != value)
				{
					_stepID = value;
					_isModified = true;
					base.OnPropertyChanged("StepID");
				}
			}
		}
		
		protected string _stepName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StepName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string StepName
		{
			get
			{
				return _stepName;
			}
			set
			{
				if (_stepName != value)
				{
					_stepName = value;
					_isModified = true;
					base.OnPropertyChanged("StepName");
				}
			}
		}
		
		protected Guid _stageID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StageID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StageID
		{
			get
			{
				return _stageID;
			}
			set
			{
				if (_stageID != value)
				{
					_stageID = value;
					_isModified = true;
					base.OnPropertyChanged("StageID");
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
		
		protected string _stageName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the StageName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string StageName
		{
			get
			{
				return _stageName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Workflows.StepTransition> _fromStepTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Step.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StepTransition> FromStepTransitionList
		{
			get
			{
				if (_fromStepTransitionList == null)
				{
					_fromStepTransitionList = new EnterpriseDataObjectList<BLL.Workflows.StepTransition>();
				}
				return _fromStepTransitionList;
			}
			set
			{
				if (_fromStepTransitionList == null || _fromStepTransitionList.Equals(value) == false)
				{
					_fromStepTransitionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "FromStepTransitionList")]
		[XmlArrayItem(typeof(BLL.Workflows.StepTransition), ElementName = "StepTransition")]
		[DataMember(Name = "FromStepTransitionList")]
		[DataArrayItem(ElementName = "FromStepTransitionList")]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StepTransition> _S_FromStepTransitionList
		{
			get
			{
				return _fromStepTransitionList;
			}
			set
			{
				_fromStepTransitionList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Workflows.StepTransition> _toStepTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Step.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StepTransition> ToStepTransitionList
		{
			get
			{
				if (_toStepTransitionList == null)
				{
					_toStepTransitionList = new EnterpriseDataObjectList<BLL.Workflows.StepTransition>();
				}
				return _toStepTransitionList;
			}
			set
			{
				if (_toStepTransitionList == null || _toStepTransitionList.Equals(value) == false)
				{
					_toStepTransitionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ToStepTransitionList")]
		[XmlArrayItem(typeof(BLL.Workflows.StepTransition), ElementName = "StepTransition")]
		[DataMember(Name = "ToStepTransitionList")]
		[DataArrayItem(ElementName = "ToStepTransitionList")]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StepTransition> _S_ToStepTransitionList
		{
			get
			{
				return _toStepTransitionList;
			}
			set
			{
				_toStepTransitionList = value;
			}
		}
		
		protected BLL.Workflows.Stage _stage = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Stage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Workflows.Stage Stage
		{
			get
			{
				return _stage;
			}
			set
			{
				if (value != null)
				{
					_stageName = value.StageName;
					if (_stage != null && _stage.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					StageID = value.StageID;
				}
				_stage = value;
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
				return "StepID";
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
				return StepID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					StepID = primaryKeyValues[0].GetGuid();
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
				if (_fromStepTransitionList != null && _fromStepTransitionList.IsModified == true) return true;
				if (_toStepTransitionList != null && _toStepTransitionList.IsModified == true) return true;
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
				ReverseInstance = new Step();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Step();
				ForwardInstance.StepID = StepID;
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
			foreach (StepTransition stepTransition in ToStepTransitionList)
			{
				stepTransition.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputStep">The step to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Step inputStep)
		{
			if (StepName.GetString() != inputStep.StepName.GetString()) return false;
			if (StageID.GetGuid() != inputStep.StageID.GetGuid()) return false;
			if (Order.GetInt() != inputStep.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputStep.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputStep.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputStep">The step to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Step inputStep)
		{
			if (inputStep == null) return true;
			if (inputStep.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputStep.StepName)) return false;
			if (StageID != inputStep.StageID) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputStep.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputStep.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputStep">The step to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Step inputStep)
		{
			StepName = inputStep.StepName;
			StageID = inputStep.StageID;
			Order = inputStep.Order;
			IsAutoUpdated = inputStep.IsAutoUpdated;
			Description = inputStep.Description;
			
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
				StepID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (StepID == Guid.Empty)
				{
					StepID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = StepID;
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
			Stage = null;
			Solution = null;
			if (_fromStepTransitionList != null)
			{
				foreach (StepTransition item in FromStepTransitionList)
				{
					item.Dispose();
				}
				FromStepTransitionList.Clear();
				FromStepTransitionList = null;
			}
			if (_toStepTransitionList != null)
			{
				foreach (StepTransition item in ToStepTransitionList)
				{
					item.Dispose();
				}
				ToStepTransitionList.Clear();
				ToStepTransitionList = null;
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
					ReverseInstance = new Step();
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
			newItem.ItemID = StepID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Step GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Step forwardItem = new Step();
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
				forwardItem.StepID = StepID;
			}
			foreach (StepTransition item in ToStepTransitionList)
			{
				item.ToStep = this;
				StepTransition forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ToStepTransitionList.Add(forwardChildItem);
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
				if (modelContext is Step)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Stage)
				{
					solutionContext.NeedsSample = false;
					Stage parent = modelContext as Stage;
					if (parent.StepList.Count > 0)
					{
						return parent.StepList[DataHelper.GetRandomInt(0, parent.StepList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.StepList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.StepList[DataHelper.GetRandomInt(0, solutionContext.StepList.Count - 1)];
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
				if (nodeContext is Stage)
				{
					return (nodeContext as Stage).StepList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).StepList;
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
			return Stage;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Stage stage = Solution.StageList.Find(i => i.StageID == StageID);
			if (stage != null)
			{
				Stage = stage;
				SetID();  // id (from saved ids) may change based on parent info
				Step step = stage.StepList.Find(i => i.StepID == StepID);
				if (step != null)
				{
					if (step != this)
					{
						stage.StepList.Remove(step);
						stage.StepList.Add(this);
					}
				}
				else
				{
					stage.StepList.Add(this);
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
			if (solutionContext.CurrentStep != null)
			{
				string validationErrors = solutionContext.CurrentStep.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentStep, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentStep.Solution = solutionContext;
				solutionContext.CurrentStep.AddToParent();
				Step existingItem = solutionContext.StepList.Find(i => i.StepID == solutionContext.CurrentStep.StepID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentStep.AssignProperty("StepID", solutionContext.CurrentStep.StepID);
					solutionContext.CurrentStep.ReverseInstance.ResetModified(false);
					solutionContext.StepList.Add(solutionContext.CurrentStep);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Step();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentStep, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("StepID", existingItem.StepID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentStep = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Step item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentStep != null)
			{
				Step existingItem = solutionContext.StepList.Find(i => i.StepID == solutionContext.CurrentStep.StepID);
				if (existingItem != null)
				{
					solutionContext.StepList.Remove(solutionContext.CurrentStep);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Step instance from an xml file.</summary>
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
		/// <summary>This method saves the Step instance to an xml file.</summary>
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
			if (_fromStepTransitionList != null) _fromStepTransitionList.ResetLoaded(isLoaded);
			if (_toStepTransitionList != null) _toStepTransitionList.ResetLoaded(isLoaded);
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
			if (_fromStepTransitionList != null) _fromStepTransitionList.ResetModified(isModified);
			if (_toStepTransitionList != null) _toStepTransitionList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Step(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Step instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Step(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Step instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="stepID">The input value for StepID.</param>
		///--------------------------------------------------------------------------------
		public Step(Guid stepID)
		{
			StepID = stepID;
		}
		#endregion "Constructors"
	}
}