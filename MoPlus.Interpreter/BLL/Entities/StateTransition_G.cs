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
	/// specific StateTransition instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="StateTransition")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class StateTransition : BusinessObjectBase
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
			
			error = GetValidationError("StateTransitionName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("FromStateID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ToStateID");
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
				case "_stateTransitionName":
				case "StateTransitionName":
					error = ValidateStateTransitionName();
					break;
				case "_fromStateID":
				case "FromStateID":
					error = ValidateFromStateID();
					break;
				case "_toStateID":
				case "ToStateID":
					error = ValidateToStateID();
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
		/// <summary>This method validates StateTransitionName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStateTransitionName()
		{
			if (!Regex.IsMatch(StateTransitionName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "StateTransitionName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates FromStateID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateFromStateID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ToStateID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateToStateID()
		{
			if (ToStateID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ToStateID");
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
		
		private StateTransition _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StateTransition ForwardInstance
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
		
		private StateTransition _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new StateTransition ReverseInstance
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
				return StateTransitionID;
			}
			set
			{
				StateTransitionID = value;
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
				return StateTransitionName;
			}
			set
			{
				StateTransitionName = value;
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
				return SourceStateTransition.StateTransitionName;
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
					if (!String.IsNullOrEmpty(ToStateName))
					{
						_displayName = ToStateName + "." + StateTransitionName;
					}
					else
					{
						_displayName = StateTransitionName;
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
					if (ToState != null)
					{
						_defaultSourceName = ToState.DefaultSourceName + "." + DefaultSourcePrefix + SourceStateTransition.StateTransitionName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceStateTransition.StateTransitionName;
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
		public StateTransition SourceStateTransition
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
		/// <summary>This property gets/sets the OldStateTransitionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStateTransitionID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldFromStateID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldFromStateID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldToStateID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldToStateID { get; set; }
		
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
		
		protected Guid _stateTransitionID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateTransitionID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StateTransitionID
		{
			get
			{
				return _stateTransitionID;
			}
			set
			{
				if (_stateTransitionID != value)
				{
					_stateTransitionID = value;
					_isModified = true;
					base.OnPropertyChanged("StateTransitionID");
				}
			}
		}
		
		protected string _stateTransitionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateTransitionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string StateTransitionName
		{
			get
			{
				return _stateTransitionName;
			}
			set
			{
				if (_stateTransitionName != value)
				{
					_stateTransitionName = value;
					_isModified = true;
					base.OnPropertyChanged("StateTransitionName");
				}
			}
		}
		
		protected Guid? _fromStateID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FromStateID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? FromStateID
		{
			get
			{
				return _fromStateID;
			}
			set
			{
				if (_fromStateID != value)
				{
					_fromStateID = value;
					_isModified = true;
					base.OnPropertyChanged("FromStateID");
				}
			}
		}
		
		protected Guid _toStateID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ToStateID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ToStateID
		{
			get
			{
				return _toStateID;
			}
			set
			{
				if (_toStateID != value)
				{
					_toStateID = value;
					_isModified = true;
					base.OnPropertyChanged("ToStateID");
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
		
		protected string _fromStateName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the FromStateName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string FromStateName
		{
			get
			{
				return _fromStateName;
			}
		}
		
		protected string _toStateName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ToStateName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ToStateName
		{
			get
			{
				return _toStateName;
			}
		}
		
		protected BLL.Entities.State _fromState = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the FromState.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.State FromState
		{
			get
			{
				return _fromState;
			}
			set
			{
				if (value != null)
				{
					_fromStateName = value.StateName;
					if (_fromState != null && _fromState.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					FromStateID = value.StateID;
				}
				_fromState = value;
			}
		}
		
		protected BLL.Entities.State _toState = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ToState.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.State ToState
		{
			get
			{
				return _toState;
			}
			set
			{
				if (value != null)
				{
					_toStateName = value.StateName;
					if (_toState != null && _toState.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ToStateID = value.StateID;
				}
				_toState = value;
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
				return "StateTransitionID";
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
				return StateTransitionID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					StateTransitionID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new StateTransition();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new StateTransition();
				ForwardInstance.StateTransitionID = StateTransitionID;
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
		/// <param name="inputStateTransition">The statetransition to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(StateTransition inputStateTransition)
		{
			if (StateTransitionName.GetString() != inputStateTransition.StateTransitionName.GetString()) return false;
			if (FromStateID.GetGuid() != inputStateTransition.FromStateID.GetGuid()) return false;
			if (ToStateID.GetGuid() != inputStateTransition.ToStateID.GetGuid()) return false;
			if (IsAutoUpdated.GetBool() != inputStateTransition.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputStateTransition.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputStateTransition">The statetransition to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(StateTransition inputStateTransition)
		{
			if (inputStateTransition == null) return true;
			if (inputStateTransition.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputStateTransition.StateTransitionName)) return false;
			if (FromStateID != inputStateTransition.FromStateID) return false;
			if (ToStateID != inputStateTransition.ToStateID) return false;
			if (IsAutoUpdated != inputStateTransition.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputStateTransition.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputStateTransition">The statetransition to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(StateTransition inputStateTransition)
		{
			StateTransitionName = inputStateTransition.StateTransitionName;
			FromStateID = inputStateTransition.FromStateID;
			ToStateID = inputStateTransition.ToStateID;
			IsAutoUpdated = inputStateTransition.IsAutoUpdated;
			Description = inputStateTransition.Description;
			
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
				StateTransitionID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (StateTransitionID == Guid.Empty)
				{
					StateTransitionID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = StateTransitionID;
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
			FromState = null;
			ToState = null;
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
					ReverseInstance = new StateTransition();
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
			newItem.ItemID = StateTransitionID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public StateTransition GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			StateTransition forwardItem = new StateTransition();
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
				forwardItem.StateTransitionID = StateTransitionID;
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
				if (modelContext is StateTransition)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is State)
				{
					State parent = modelContext as State;
					if (parent.ToStateTransitionList.Count > 0)
					{
						return parent.ToStateTransitionList[DataHelper.GetRandomInt(0, parent.ToStateTransitionList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.StateTransitionList.Count > 0)
			{
				return solutionContext.StateTransitionList[DataHelper.GetRandomInt(0, solutionContext.StateTransitionList.Count - 1)];
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
				if (nodeContext is State)
				{
					return (nodeContext as State).ToStateTransitionList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).StateTransitionList;
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
			return ToState;
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
			if (solutionContext.CurrentStateTransition != null)
			{
				string validationErrors = solutionContext.CurrentStateTransition.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentStateTransition, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				StateTransition existingItem = solutionContext.StateTransitionList.Find(i => i.StateTransitionID == solutionContext.CurrentStateTransition.StateTransitionID);
				if (existingItem == null)
				{
					solutionContext.CurrentStateTransition.Solution = solutionContext;
					State fromState = solutionContext.StateList.Find(i => i.StateID == solutionContext.CurrentStateTransition.FromStateID);
					if (fromState != null)
					{
						solutionContext.CurrentStateTransition.FromState = fromState;
						fromState.FromStateTransitionList.Add(solutionContext.CurrentStateTransition);
					}
					State toState = solutionContext.StateList.Find(i => i.StateID == solutionContext.CurrentStateTransition.ToStateID);
					if (toState != null)
					{
						solutionContext.CurrentStateTransition.ToState = toState;
						toState.ToStateTransitionList.Add(solutionContext.CurrentStateTransition);
					}
					solutionContext.CurrentStateTransition.SetID();
					solutionContext.CurrentStateTransition.AssignProperty("StateTransitionID", solutionContext.CurrentStateTransition.StateTransitionID);
					StateTransition foundItem = solutionContext.StateTransitionsToMerge.Find(i => i.StateTransitionID == solutionContext.CurrentStateTransition.StateTransitionID);
					if (foundItem != null)
					{
						StateTransition forwardItem = new StateTransition();
						forwardItem.TransformDataFromObject(foundItem, null, false);
						solutionContext.CurrentStateTransition.ForwardInstance = forwardItem;
						solutionContext.CurrentStateTransition.TransformDataFromObject(forwardItem, null, false, true);
						solutionContext.StateTransitionsToMerge.Remove(foundItem);
					}
					
					#region protected
					#endregion protected
					
					solutionContext.StateTransitionList.Add(solutionContext.CurrentStateTransition);
					solutionContext.CurrentStateTransition.ReverseInstance.ResetModified(false);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current StateTransition item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentStateTransition != null)
			{
				StateTransition existingItem = solutionContext.StateTransitionList.Find(i => i.StateTransitionID == solutionContext.CurrentStateTransition.StateTransitionID);
				if (existingItem != null)
				{
					solutionContext.StateTransitionList.Remove(solutionContext.CurrentStateTransition);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the StateTransition instance from an xml file.</summary>
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
		/// <summary>This method saves the StateTransition instance to an xml file.</summary>
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
		public StateTransition(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic StateTransition instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public StateTransition(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic StateTransition instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="stateTransitionID">The input value for StateTransitionID.</param>
		///--------------------------------------------------------------------------------
		public StateTransition(Guid stateTransitionID)
		{
			StateTransitionID = stateTransitionID;
		}
		#endregion "Constructors"
	}
}