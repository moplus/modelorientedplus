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
	/// specific StageTransition instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="StageTransition")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class StageTransition : BusinessObjectBase
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
			
			error = GetValidationError("StageTransitionName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("FromStageID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ToStageID");
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
				case "_stageTransitionName":
				case "StageTransitionName":
					error = ValidateStageTransitionName();
					break;
				case "_fromStageID":
				case "FromStageID":
					error = ValidateFromStageID();
					break;
				case "_toStageID":
				case "ToStageID":
					error = ValidateToStageID();
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
		/// <summary>This method validates StageTransitionName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStageTransitionName()
		{
			if (!Regex.IsMatch(StageTransitionName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "StageTransitionName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates FromStageID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateFromStageID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ToStageID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateToStageID()
		{
			if (ToStageID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ToStageID");
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
		
		private StageTransition _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StageTransition ForwardInstance
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
		
		private StageTransition _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new StageTransition ReverseInstance
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
				return StageTransitionID;
			}
			set
			{
				StageTransitionID = value;
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
				return StageTransitionName;
			}
			set
			{
				StageTransitionName = value;
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
				return SourceStageTransition.StageTransitionName;
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
					if (!String.IsNullOrEmpty(ToStageName))
					{
						_displayName = ToStageName + "." + StageTransitionName;
					}
					else
					{
						_displayName = StageTransitionName;
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
					if (ToStage != null)
					{
						_defaultSourceName = ToStage.DefaultSourceName + "." + DefaultSourcePrefix + SourceStageTransition.StageTransitionName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceStageTransition.StageTransitionName;
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
		public StageTransition SourceStageTransition
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
		/// <summary>This property gets/sets the OldStageTransitionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStageTransitionID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldFromStageID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldFromStageID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldToStageID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldToStageID { get; set; }
		
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
		
		protected Guid _stageTransitionID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StageTransitionID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StageTransitionID
		{
			get
			{
				return _stageTransitionID;
			}
			set
			{
				if (_stageTransitionID != value)
				{
					_stageTransitionID = value;
					_isModified = true;
					base.OnPropertyChanged("StageTransitionID");
				}
			}
		}
		
		protected string _stageTransitionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StageTransitionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string StageTransitionName
		{
			get
			{
				return _stageTransitionName;
			}
			set
			{
				if (_stageTransitionName != value)
				{
					_stageTransitionName = value;
					_isModified = true;
					base.OnPropertyChanged("StageTransitionName");
				}
			}
		}
		
		protected Guid? _fromStageID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FromStageID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? FromStageID
		{
			get
			{
				return _fromStageID;
			}
			set
			{
				if (_fromStageID != value)
				{
					_fromStageID = value;
					_isModified = true;
					base.OnPropertyChanged("FromStageID");
				}
			}
		}
		
		protected Guid _toStageID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ToStageID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ToStageID
		{
			get
			{
				return _toStageID;
			}
			set
			{
				if (_toStageID != value)
				{
					_toStageID = value;
					_isModified = true;
					base.OnPropertyChanged("ToStageID");
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
		
		protected string _fromStageName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the FromStageName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string FromStageName
		{
			get
			{
				return _fromStageName;
			}
		}
		
		protected string _toStageName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ToStageName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ToStageName
		{
			get
			{
				return _toStageName;
			}
		}
		
		protected BLL.Workflows.Stage _fromStage = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the FromStage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Workflows.Stage FromStage
		{
			get
			{
				return _fromStage;
			}
			set
			{
				if (value != null)
				{
					_fromStageName = value.StageName;
					if (_fromStage != null && _fromStage.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					FromStageID = value.StageID;
				}
				_fromStage = value;
			}
		}
		
		protected BLL.Workflows.Stage _toStage = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ToStage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Workflows.Stage ToStage
		{
			get
			{
				return _toStage;
			}
			set
			{
				if (value != null)
				{
					_toStageName = value.StageName;
					if (_toStage != null && _toStage.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ToStageID = value.StageID;
				}
				_toStage = value;
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
				return "StageTransitionID";
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
				return StageTransitionID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					StageTransitionID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new StageTransition();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new StageTransition();
				ForwardInstance.StageTransitionID = StageTransitionID;
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
		/// <param name="inputStageTransition">The stagetransition to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(StageTransition inputStageTransition)
		{
			if (StageTransitionName.GetString() != inputStageTransition.StageTransitionName.GetString()) return false;
			if (FromStageID.GetGuid() != inputStageTransition.FromStageID.GetGuid()) return false;
			if (ToStageID.GetGuid() != inputStageTransition.ToStageID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputStageTransition.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputStageTransition.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputStageTransition">The stagetransition to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(StageTransition inputStageTransition)
		{
			if (inputStageTransition == null) return true;
			if (inputStageTransition.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputStageTransition.StageTransitionName)) return false;
			if (FromStageID != inputStageTransition.FromStageID) return false;
			if (ToStageID != inputStageTransition.ToStageID) return false;
			if (IsAutoUpdated != inputStageTransition.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputStageTransition.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputStageTransition">The stagetransition to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(StageTransition inputStageTransition)
		{
			StageTransitionName = inputStageTransition.StageTransitionName;
			FromStageID = inputStageTransition.FromStageID;
			ToStageID = inputStageTransition.ToStageID;
			IsAutoUpdated = inputStageTransition.IsAutoUpdated;
			Description = inputStageTransition.Description;
			
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
				StageTransitionID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (StageTransitionID == Guid.Empty)
				{
					StageTransitionID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = StageTransitionID;
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
			FromStage = null;
			ToStage = null;
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
					ReverseInstance = new StageTransition();
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
			newItem.ItemID = StageTransitionID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public StageTransition GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			StageTransition forwardItem = new StageTransition();
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
				forwardItem.StageTransitionID = StageTransitionID;
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
				if (modelContext is StageTransition)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Stage)
				{
					solutionContext.NeedsSample = false;
					Stage parent = modelContext as Stage;
					if (parent.ToStageTransitionList.Count > 0)
					{
						return parent.ToStageTransitionList[DataHelper.GetRandomInt(0, parent.ToStageTransitionList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.StageTransitionList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.StageTransitionList[DataHelper.GetRandomInt(0, solutionContext.StageTransitionList.Count - 1)];
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
					return (nodeContext as Stage).ToStageTransitionList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).StageTransitionList;
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
			return ToStage;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Stage stage = Solution.StageList.Find(i => i.StageID == ToStageID);
			if (stage != null)
			{
				ToStage = stage;
				SetID();  // id (from saved ids) may change based on parent info
				StageTransition stageTransition = stage.ToStageTransitionList.Find(i => i.StageTransitionID == StageTransitionID);
				if (stageTransition != null)
				{
					if (stageTransition != this)
					{
						stage.ToStageTransitionList.Remove(stageTransition);
						stage.ToStageTransitionList.Add(this);
					}
				}
				else
				{
					stage.ToStageTransitionList.Add(this);
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
			if (solutionContext.CurrentStageTransition != null)
			{
				string validationErrors = solutionContext.CurrentStageTransition.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentStageTransition, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentStageTransition.Solution = solutionContext;
				solutionContext.CurrentStageTransition.AddToParent();
				StageTransition existingItem = solutionContext.StageTransitionList.Find(i => i.StageTransitionID == solutionContext.CurrentStageTransition.StageTransitionID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentStageTransition.AssignProperty("StageTransitionID", solutionContext.CurrentStageTransition.StageTransitionID);
					solutionContext.CurrentStageTransition.ReverseInstance.ResetModified(false);
					solutionContext.StageTransitionList.Add(solutionContext.CurrentStageTransition);
				}
				else
				{
					// update existing item in solution
					if (existingItem.Solution == null) existingItem.Solution = solutionContext;
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new StageTransition();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentStageTransition, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("StageTransitionID", existingItem.StageTransitionID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentStageTransition = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current StageTransition item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentStageTransition != null)
			{
				StageTransition existingItem = solutionContext.StageTransitionList.Find(i => i.StageTransitionID == solutionContext.CurrentStageTransition.StageTransitionID);
				if (existingItem != null)
				{
					solutionContext.StageTransitionList.Remove(solutionContext.CurrentStageTransition);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the StageTransition instance from an xml file.</summary>
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
		/// <summary>This method saves the StageTransition instance to an xml file.</summary>
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
		public StageTransition(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic StageTransition instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public StageTransition(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic StageTransition instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="stageTransitionID">The input value for StageTransitionID.</param>
		///--------------------------------------------------------------------------------
		public StageTransition(Guid stageTransitionID)
		{
			StageTransitionID = stageTransitionID;
		}
		#endregion "Constructors"
	}
}