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
	/// specific Stage instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/19/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="Stage")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Stage : BusinessObjectBase
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
			
			error = GetValidationError("StageName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("WorkflowID");
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
				case "_stageName":
				case "StageName":
					error = ValidateStageName();
					break;
				case "_workflowID":
				case "WorkflowID":
					error = ValidateWorkflowID();
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
		/// <summary>This method validates StageName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStageName()
		{
			if (!Regex.IsMatch(StageName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "StageName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates WorkflowID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateWorkflowID()
		{
			if (WorkflowID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "WorkflowID");
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
		
		private Stage _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Stage ForwardInstance
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
		
		private Stage _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Stage ReverseInstance
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
				return StageID;
			}
			set
			{
				StageID = value;
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
				return StageName;
			}
			set
			{
				StageName = value;
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
				return SourceStage.StageName;
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
					if (!String.IsNullOrEmpty(WorkflowName))
					{
						_displayName = WorkflowName + "." + StageName;
					}
					else
					{
						_displayName = StageName;
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
					if (Workflow != null)
					{
						_defaultSourceName = Workflow.DefaultSourceName + "." + DefaultSourcePrefix + SourceStage.StageName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceStage.StageName;
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
		public Stage SourceStage
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
		/// <summary>This property gets/sets the OldStageID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStageID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldWorkflowID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldWorkflowID { get; set; }
		
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
		
		protected string _stageName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StageName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string StageName
		{
			get
			{
				return _stageName;
			}
			set
			{
				if (_stageName != value)
				{
					_stageName = value;
					_isModified = true;
					base.OnPropertyChanged("StageName");
				}
			}
		}
		
		protected Guid _workflowID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the WorkflowID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid WorkflowID
		{
			get
			{
				return _workflowID;
			}
			set
			{
				if (_workflowID != value)
				{
					_workflowID = value;
					_isModified = true;
					base.OnPropertyChanged("WorkflowID");
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
		
		protected string _workflowName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the WorkflowName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string WorkflowName
		{
			get
			{
				return _workflowName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Workflows.StageTransition> _fromStageTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Stage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StageTransition> FromStageTransitionList
		{
			get
			{
				if (_fromStageTransitionList == null)
				{
					_fromStageTransitionList = new EnterpriseDataObjectList<BLL.Workflows.StageTransition>();
				}
				return _fromStageTransitionList;
			}
			set
			{
				if (_fromStageTransitionList == null || _fromStageTransitionList.Equals(value) == false)
				{
					_fromStageTransitionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "FromStageTransitionList")]
		[XmlArrayItem(typeof(BLL.Workflows.StageTransition), ElementName = "StageTransition")]
		[DataMember(Name = "FromStageTransitionList")]
		[DataArrayItem(ElementName = "FromStageTransitionList")]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StageTransition> _S_FromStageTransitionList
		{
			get
			{
				return _fromStageTransitionList;
			}
			set
			{
				_fromStageTransitionList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Workflows.StageTransition> _toStageTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Stage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StageTransition> ToStageTransitionList
		{
			get
			{
				if (_toStageTransitionList == null)
				{
					_toStageTransitionList = new EnterpriseDataObjectList<BLL.Workflows.StageTransition>();
				}
				return _toStageTransitionList;
			}
			set
			{
				if (_toStageTransitionList == null || _toStageTransitionList.Equals(value) == false)
				{
					_toStageTransitionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ToStageTransitionList")]
		[XmlArrayItem(typeof(BLL.Workflows.StageTransition), ElementName = "StageTransition")]
		[DataMember(Name = "ToStageTransitionList")]
		[DataArrayItem(ElementName = "ToStageTransitionList")]
		public virtual EnterpriseDataObjectList<BLL.Workflows.StageTransition> _S_ToStageTransitionList
		{
			get
			{
				return _toStageTransitionList;
			}
			set
			{
				_toStageTransitionList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Workflows.Step> _stepList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Stage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Workflows.Step> StepList
		{
			get
			{
				if (_stepList == null)
				{
					_stepList = new EnterpriseDataObjectList<BLL.Workflows.Step>();
				}
				return _stepList;
			}
			set
			{
				if (_stepList == null || _stepList.Equals(value) == false)
				{
					_stepList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "StepList")]
		[XmlArrayItem(typeof(BLL.Workflows.Step), ElementName = "Step")]
		[DataMember(Name = "StepList")]
		[DataArrayItem(ElementName = "StepList")]
		public virtual EnterpriseDataObjectList<BLL.Workflows.Step> _S_StepList
		{
			get
			{
				return _stepList;
			}
			set
			{
				_stepList = value;
			}
		}
		
		protected BLL.Workflows.Workflow _workflow = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Workflow.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Workflows.Workflow Workflow
		{
			get
			{
				return _workflow;
			}
			set
			{
				if (value != null)
				{
					_workflowName = value.WorkflowName;
					if (_workflow != null && _workflow.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					WorkflowID = value.WorkflowID;
				}
				_workflow = value;
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
				return "StageID";
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
				return StageID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					StageID = primaryKeyValues[0].GetGuid();
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
				if (_fromStageTransitionList != null && _fromStageTransitionList.IsModified == true) return true;
				if (_toStageTransitionList != null && _toStageTransitionList.IsModified == true) return true;
				if (_stepList != null && _stepList.IsModified == true) return true;
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
				ReverseInstance = new Stage();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Stage();
				ForwardInstance.StageID = StageID;
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
			foreach (StageTransition stageTransition in ToStageTransitionList)
			{
				stageTransition.AddItemToUsedTags(usedTags);
			}
			foreach (Step step in StepList)
			{
				step.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputStage">The stage to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Stage inputStage)
		{
			if (StageName.GetString() != inputStage.StageName.GetString()) return false;
			if (WorkflowID.GetGuid() != inputStage.WorkflowID.GetGuid()) return false;
			if (Order.GetInt() != inputStage.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputStage.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputStage.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputStage">The stage to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Stage inputStage)
		{
			if (inputStage == null) return true;
			if (inputStage.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputStage.StageName)) return false;
			if (WorkflowID != inputStage.WorkflowID) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputStage.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputStage.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputStage">The stage to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Stage inputStage)
		{
			StageName = inputStage.StageName;
			WorkflowID = inputStage.WorkflowID;
			Order = inputStage.Order;
			IsAutoUpdated = inputStage.IsAutoUpdated;
			Description = inputStage.Description;
			
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
				StageID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (StageID == Guid.Empty)
				{
					StageID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = StageID;
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
			Workflow = null;
			Solution = null;
			if (_fromStageTransitionList != null)
			{
				foreach (StageTransition item in FromStageTransitionList)
				{
					item.Dispose();
				}
				FromStageTransitionList.Clear();
				FromStageTransitionList = null;
			}
			if (_toStageTransitionList != null)
			{
				foreach (StageTransition item in ToStageTransitionList)
				{
					item.Dispose();
				}
				ToStageTransitionList.Clear();
				ToStageTransitionList = null;
			}
			if (_stepList != null)
			{
				foreach (Step item in StepList)
				{
					item.Dispose();
				}
				StepList.Clear();
				StepList = null;
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
					ReverseInstance = new Stage();
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
			newItem.ItemID = StageID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Stage GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Stage forwardItem = new Stage();
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
				forwardItem.StageID = StageID;
			}
			foreach (StageTransition item in ToStageTransitionList)
			{
				item.ToStage = this;
				StageTransition forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ToStageTransitionList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Step item in StepList)
			{
				item.Stage = this;
				Step forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.StepList.Add(forwardChildItem);
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
				if (modelContext is Stage)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Workflow)
				{
					solutionContext.NeedsSample = false;
					Workflow parent = modelContext as Workflow;
					if (parent.StageList.Count > 0)
					{
						return parent.StageList[DataHelper.GetRandomInt(0, parent.StageList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.StageList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.StageList[DataHelper.GetRandomInt(0, solutionContext.StageList.Count - 1)];
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
				if (nodeContext is Workflow)
				{
					return (nodeContext as Workflow).StageList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).StageList;
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
			return Workflow;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Workflow workflow = Solution.WorkflowList.Find(i => i.WorkflowID == WorkflowID);
			if (workflow != null)
			{
				Workflow = workflow;
				SetID();  // id (from saved ids) may change based on parent info
				Stage stage = workflow.StageList.Find(i => i.StageID == StageID);
				if (stage != null)
				{
					if (stage != this)
					{
						workflow.StageList.Remove(stage);
						workflow.StageList.Add(this);
					}
				}
				else
				{
					workflow.StageList.Add(this);
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
			if (solutionContext.CurrentStage != null)
			{
				string validationErrors = solutionContext.CurrentStage.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentStage, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentStage.Solution = solutionContext;
				solutionContext.CurrentStage.AddToParent();
				Stage existingItem = solutionContext.StageList.Find(i => i.StageID == solutionContext.CurrentStage.StageID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentStage.AssignProperty("StageID", solutionContext.CurrentStage.StageID);
					solutionContext.CurrentStage.ReverseInstance.ResetModified(false);
					solutionContext.StageList.Add(solutionContext.CurrentStage);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Stage();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentStage, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("StageID", existingItem.StageID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentStage = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Stage item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentStage != null)
			{
				Stage existingItem = solutionContext.StageList.Find(i => i.StageID == solutionContext.CurrentStage.StageID);
				if (existingItem != null)
				{
					solutionContext.StageList.Remove(solutionContext.CurrentStage);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Stage instance from an xml file.</summary>
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
		/// <summary>This method saves the Stage instance to an xml file.</summary>
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
			if (_fromStageTransitionList != null) _fromStageTransitionList.ResetLoaded(isLoaded);
			if (_toStageTransitionList != null) _toStageTransitionList.ResetLoaded(isLoaded);
			if (_stepList != null) _stepList.ResetLoaded(isLoaded);
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
			if (_fromStageTransitionList != null) _fromStageTransitionList.ResetModified(isModified);
			if (_toStageTransitionList != null) _toStageTransitionList.ResetModified(isModified);
			if (_stepList != null) _stepList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Stage(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Stage instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Stage(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Stage instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="stageID">The input value for StageID.</param>
		///--------------------------------------------------------------------------------
		public Stage(Guid stageID)
		{
			StageID = stageID;
		}
		#endregion "Constructors"
	}
}