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
	/// specific StepTransition instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="StepTransition")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class StepTransition : BusinessObjectBase
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
			
			error = GetValidationError("StepTransitionName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("FromStepID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ToStepID");
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
				case "_stepTransitionName":
				case "StepTransitionName":
					error = ValidateStepTransitionName();
					break;
				case "_fromStepID":
				case "FromStepID":
					error = ValidateFromStepID();
					break;
				case "_toStepID":
				case "ToStepID":
					error = ValidateToStepID();
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
		/// <summary>This method validates StepTransitionName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStepTransitionName()
		{
			if (!Regex.IsMatch(StepTransitionName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "StepTransitionName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates FromStepID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateFromStepID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ToStepID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateToStepID()
		{
			if (ToStepID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ToStepID");
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
		
		private StepTransition _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StepTransition ForwardInstance
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
		
		private StepTransition _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new StepTransition ReverseInstance
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
				return StepTransitionID;
			}
			set
			{
				StepTransitionID = value;
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
				return StepTransitionName;
			}
			set
			{
				StepTransitionName = value;
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
				return SourceStepTransition.StepTransitionName;
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
					if (!String.IsNullOrEmpty(ToStepName))
					{
						_displayName = ToStepName + "." + StepTransitionName;
					}
					else
					{
						_displayName = StepTransitionName;
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
					if (ToStep != null)
					{
						_defaultSourceName = ToStep.DefaultSourceName + "." + DefaultSourcePrefix + SourceStepTransition.StepTransitionName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceStepTransition.StepTransitionName;
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
		public StepTransition SourceStepTransition
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
		/// <summary>This property gets/sets the OldStepTransitionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStepTransitionID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldFromStepID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldFromStepID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldToStepID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldToStepID { get; set; }
		
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
		
		protected Guid _stepTransitionID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StepTransitionID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StepTransitionID
		{
			get
			{
				return _stepTransitionID;
			}
			set
			{
				if (_stepTransitionID != value)
				{
					_stepTransitionID = value;
					_isModified = true;
					base.OnPropertyChanged("StepTransitionID");
				}
			}
		}
		
		protected string _stepTransitionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StepTransitionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string StepTransitionName
		{
			get
			{
				return _stepTransitionName;
			}
			set
			{
				if (_stepTransitionName != value)
				{
					_stepTransitionName = value;
					_isModified = true;
					base.OnPropertyChanged("StepTransitionName");
				}
			}
		}
		
		protected Guid? _fromStepID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FromStepID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? FromStepID
		{
			get
			{
				return _fromStepID;
			}
			set
			{
				if (_fromStepID != value)
				{
					_fromStepID = value;
					_isModified = true;
					base.OnPropertyChanged("FromStepID");
				}
			}
		}
		
		protected Guid _toStepID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ToStepID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ToStepID
		{
			get
			{
				return _toStepID;
			}
			set
			{
				if (_toStepID != value)
				{
					_toStepID = value;
					_isModified = true;
					base.OnPropertyChanged("ToStepID");
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
		
		protected string _fromStepName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the FromStepName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string FromStepName
		{
			get
			{
				return _fromStepName;
			}
		}
		
		protected string _toStepName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ToStepName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ToStepName
		{
			get
			{
				return _toStepName;
			}
		}
		
		protected BLL.Workflows.Step _fromStep = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the FromStep.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Workflows.Step FromStep
		{
			get
			{
				return _fromStep;
			}
			set
			{
				if (value != null)
				{
					_fromStepName = value.StepName;
					if (_fromStep != null && _fromStep.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					FromStepID = value.StepID;
				}
				_fromStep = value;
			}
		}
		
		protected BLL.Workflows.Step _toStep = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ToStep.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Workflows.Step ToStep
		{
			get
			{
				return _toStep;
			}
			set
			{
				if (value != null)
				{
					_toStepName = value.StepName;
					if (_toStep != null && _toStep.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ToStepID = value.StepID;
				}
				_toStep = value;
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
				return "StepTransitionID";
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
				return StepTransitionID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					StepTransitionID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new StepTransition();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new StepTransition();
				ForwardInstance.StepTransitionID = StepTransitionID;
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
		/// <param name="inputStepTransition">The steptransition to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(StepTransition inputStepTransition)
		{
			if (StepTransitionName.GetString() != inputStepTransition.StepTransitionName.GetString()) return false;
			if (FromStepID.GetGuid() != inputStepTransition.FromStepID.GetGuid()) return false;
			if (ToStepID.GetGuid() != inputStepTransition.ToStepID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputStepTransition.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputStepTransition.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputStepTransition">The steptransition to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(StepTransition inputStepTransition)
		{
			if (inputStepTransition == null) return true;
			if (inputStepTransition.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputStepTransition.StepTransitionName)) return false;
			if (FromStepID != inputStepTransition.FromStepID) return false;
			if (ToStepID != inputStepTransition.ToStepID) return false;
			if (IsAutoUpdated != inputStepTransition.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputStepTransition.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputStepTransition">The steptransition to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(StepTransition inputStepTransition)
		{
			StepTransitionName = inputStepTransition.StepTransitionName;
			FromStepID = inputStepTransition.FromStepID;
			ToStepID = inputStepTransition.ToStepID;
			IsAutoUpdated = inputStepTransition.IsAutoUpdated;
			Description = inputStepTransition.Description;
			
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
				StepTransitionID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (StepTransitionID == Guid.Empty)
				{
					StepTransitionID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = StepTransitionID;
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
			FromStep = null;
			ToStep = null;
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
					ReverseInstance = new StepTransition();
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
			newItem.ItemID = StepTransitionID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public StepTransition GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			StepTransition forwardItem = new StepTransition();
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
				forwardItem.StepTransitionID = StepTransitionID;
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
				if (modelContext is StepTransition)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Step)
				{
					solutionContext.NeedsSample = false;
					Step parent = modelContext as Step;
					if (parent.ToStepTransitionList.Count > 0)
					{
						return parent.ToStepTransitionList[DataHelper.GetRandomInt(0, parent.ToStepTransitionList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.StepTransitionList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.StepTransitionList[DataHelper.GetRandomInt(0, solutionContext.StepTransitionList.Count - 1)];
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
				if (nodeContext is Step)
				{
					return (nodeContext as Step).ToStepTransitionList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).StepTransitionList;
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
			return ToStep;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Step step = Solution.StepList.Find(i => i.StepID == ToStepID);
			if (step != null)
			{
				ToStep = step;
				SetID();  // id (from saved ids) may change based on parent info
				StepTransition stepTransition = step.ToStepTransitionList.Find(i => i.StepTransitionID == StepTransitionID);
				if (stepTransition != null)
				{
					if (stepTransition != this)
					{
						step.ToStepTransitionList.Remove(stepTransition);
						step.ToStepTransitionList.Add(this);
					}
				}
				else
				{
					step.ToStepTransitionList.Add(this);
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
			if (solutionContext.CurrentStepTransition != null)
			{
				string validationErrors = solutionContext.CurrentStepTransition.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentStepTransition, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentStepTransition.Solution = solutionContext;
				solutionContext.CurrentStepTransition.AddToParent();
				StepTransition existingItem = solutionContext.StepTransitionList.Find(i => i.StepTransitionID == solutionContext.CurrentStepTransition.StepTransitionID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentStepTransition.AssignProperty("StepTransitionID", solutionContext.CurrentStepTransition.StepTransitionID);
					solutionContext.CurrentStepTransition.ReverseInstance.ResetModified(false);
					solutionContext.StepTransitionList.Add(solutionContext.CurrentStepTransition);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new StepTransition();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentStepTransition, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("StepTransitionID", existingItem.StepTransitionID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentStepTransition = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current StepTransition item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentStepTransition != null)
			{
				StepTransition existingItem = solutionContext.StepTransitionList.Find(i => i.StepTransitionID == solutionContext.CurrentStepTransition.StepTransitionID);
				if (existingItem != null)
				{
					solutionContext.StepTransitionList.Remove(solutionContext.CurrentStepTransition);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the StepTransition instance from an xml file.</summary>
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
		/// <summary>This method saves the StepTransition instance to an xml file.</summary>
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
		public StepTransition(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic StepTransition instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public StepTransition(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic StepTransition instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="stepTransitionID">The input value for StepTransitionID.</param>
		///--------------------------------------------------------------------------------
		public StepTransition(Guid stepTransitionID)
		{
			StepTransitionID = stepTransitionID;
		}
		#endregion "Constructors"
	}
}