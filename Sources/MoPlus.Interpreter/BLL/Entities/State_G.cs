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
	/// specific State instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="State")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class State : BusinessObjectBase
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
			
			error = GetValidationError("StateName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("StateModelID");
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
				case "_stateName":
				case "StateName":
					error = ValidateStateName();
					break;
				case "_stateModelID":
				case "StateModelID":
					error = ValidateStateModelID();
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
		/// <summary>This method validates StateName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStateName()
		{
			if (!Regex.IsMatch(StateName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "StateName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates StateModelID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStateModelID()
		{
			if (StateModelID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "StateModelID");
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
		
		private State _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public State ForwardInstance
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
		
		private State _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new State ReverseInstance
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
				return StateID;
			}
			set
			{
				StateID = value;
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
				return StateName;
			}
			set
			{
				StateName = value;
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
				return SourceState.StateName;
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
					if (!String.IsNullOrEmpty(StateModelName))
					{
						_displayName = StateModelName + "." + StateName;
					}
					else
					{
						_displayName = StateName;
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
					if (StateModel != null)
					{
						_defaultSourceName = StateModel.DefaultSourceName + "." + DefaultSourcePrefix + SourceState.StateName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceState.StateName;
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
		public State SourceState
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
		/// <summary>This property gets/sets the OldStateID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStateID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldStateModelID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldStateModelID { get; set; }
		
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
		
		protected Guid _stateID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StateID
		{
			get
			{
				return _stateID;
			}
			set
			{
				if (_stateID != value)
				{
					_stateID = value;
					_isModified = true;
					base.OnPropertyChanged("StateID");
				}
			}
		}
		
		protected string _stateName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string StateName
		{
			get
			{
				return _stateName;
			}
			set
			{
				if (_stateName != value)
				{
					_stateName = value;
					_isModified = true;
					base.OnPropertyChanged("StateName");
				}
			}
		}
		
		protected Guid _stateModelID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateModelID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid StateModelID
		{
			get
			{
				return _stateModelID;
			}
			set
			{
				if (_stateModelID != value)
				{
					_stateModelID = value;
					_isModified = true;
					base.OnPropertyChanged("StateModelID");
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
		
		protected string _stateModelName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the StateModelName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string StateModelName
		{
			get
			{
				return _stateModelName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.StateTransition> _fromStateTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of State.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.StateTransition> FromStateTransitionList
		{
			get
			{
				if (_fromStateTransitionList == null)
				{
					_fromStateTransitionList = new EnterpriseDataObjectList<BLL.Entities.StateTransition>();
				}
				return _fromStateTransitionList;
			}
			set
			{
				if (_fromStateTransitionList == null || _fromStateTransitionList.Equals(value) == false)
				{
					_fromStateTransitionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "FromStateTransitionList")]
		[XmlArrayItem(typeof(BLL.Entities.StateTransition), ElementName = "StateTransition")]
		[DataMember(Name = "FromStateTransitionList")]
		[DataArrayItem(ElementName = "FromStateTransitionList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.StateTransition> _S_FromStateTransitionList
		{
			get
			{
				return _fromStateTransitionList;
			}
			set
			{
				_fromStateTransitionList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.StateTransition> _toStateTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of State.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.StateTransition> ToStateTransitionList
		{
			get
			{
				if (_toStateTransitionList == null)
				{
					_toStateTransitionList = new EnterpriseDataObjectList<BLL.Entities.StateTransition>();
				}
				return _toStateTransitionList;
			}
			set
			{
				if (_toStateTransitionList == null || _toStateTransitionList.Equals(value) == false)
				{
					_toStateTransitionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ToStateTransitionList")]
		[XmlArrayItem(typeof(BLL.Entities.StateTransition), ElementName = "StateTransition")]
		[DataMember(Name = "ToStateTransitionList")]
		[DataArrayItem(ElementName = "ToStateTransitionList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.StateTransition> _S_ToStateTransitionList
		{
			get
			{
				return _toStateTransitionList;
			}
			set
			{
				_toStateTransitionList = value;
			}
		}
		
		protected BLL.Entities.StateModel _stateModel = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the StateModel.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.StateModel StateModel
		{
			get
			{
				return _stateModel;
			}
			set
			{
				if (value != null)
				{
					_stateModelName = value.StateModelName;
					if (_stateModel != null && _stateModel.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					StateModelID = value.StateModelID;
				}
				_stateModel = value;
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
				return "StateID";
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
				return StateID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					StateID = primaryKeyValues[0].GetGuid();
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
				if (_fromStateTransitionList != null && _fromStateTransitionList.IsModified == true) return true;
				if (_toStateTransitionList != null && _toStateTransitionList.IsModified == true) return true;
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
				ReverseInstance = new State();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new State();
				ForwardInstance.StateID = StateID;
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
			foreach (StateTransition stateTransition in ToStateTransitionList)
			{
				stateTransition.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputState">The state to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(State inputState)
		{
			if (StateName.GetString() != inputState.StateName.GetString()) return false;
			if (StateModelID.GetGuid() != inputState.StateModelID.GetGuid()) return false;
			if (Order.GetInt() != inputState.Order.GetInt()) return false;
			if (IsAutoUpdated.GetBool() != inputState.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputState.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputState">The state to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(State inputState)
		{
			if (inputState == null) return true;
			if (inputState.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputState.StateName)) return false;
			if (StateModelID != inputState.StateModelID) return false;
			if (Order != DefaultValue.Int) return false;
			if (IsAutoUpdated != inputState.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputState.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputState">The state to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(State inputState)
		{
			StateName = inputState.StateName;
			StateModelID = inputState.StateModelID;
			Order = inputState.Order;
			IsAutoUpdated = inputState.IsAutoUpdated;
			Description = inputState.Description;
			
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
				StateID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (StateID == Guid.Empty)
				{
					StateID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = StateID;
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
			StateModel = null;
			Solution = null;
			if (_fromStateTransitionList != null)
			{
				foreach (StateTransition item in FromStateTransitionList)
				{
					item.Dispose();
				}
				FromStateTransitionList.Clear();
				FromStateTransitionList = null;
			}
			if (_toStateTransitionList != null)
			{
				foreach (StateTransition item in ToStateTransitionList)
				{
					item.Dispose();
				}
				ToStateTransitionList.Clear();
				ToStateTransitionList = null;
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
					ReverseInstance = new State();
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
			newItem.ItemID = StateID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public State GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			State forwardItem = new State();
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
				forwardItem.StateID = StateID;
			}
			foreach (StateTransition item in ToStateTransitionList)
			{
				item.ToState = this;
				StateTransition forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ToStateTransitionList.Add(forwardChildItem);
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
				if (modelContext is State)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is StateModel)
				{
					solutionContext.NeedsSample = false;
					StateModel parent = modelContext as StateModel;
					if (parent.StateList.Count > 0)
					{
						return parent.StateList[DataHelper.GetRandomInt(0, parent.StateList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.StateList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.StateList[DataHelper.GetRandomInt(0, solutionContext.StateList.Count - 1)];
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
				if (nodeContext is StateModel)
				{
					return (nodeContext as StateModel).StateList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).StateList;
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
			return StateModel;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			StateModel stateModel = Solution.StateModelList.Find(i => i.StateModelID == StateModelID);
			if (stateModel != null)
			{
				StateModel = stateModel;
				SetID();  // id (from saved ids) may change based on parent info
				State state = stateModel.StateList.Find(i => i.StateID == StateID);
				if (state != null)
				{
					if (state != this)
					{
						stateModel.StateList.Remove(state);
						stateModel.StateList.Add(this);
					}
				}
				else
				{
					stateModel.StateList.Add(this);
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
			if (solutionContext.CurrentState != null)
			{
				string validationErrors = solutionContext.CurrentState.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentState, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentState.Solution = solutionContext;
				solutionContext.CurrentState.AddToParent();
				State existingItem = solutionContext.StateList.Find(i => i.StateID == solutionContext.CurrentState.StateID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentState.AssignProperty("StateID", solutionContext.CurrentState.StateID);
					solutionContext.CurrentState.ReverseInstance.ResetModified(false);
					solutionContext.StateList.Add(solutionContext.CurrentState);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new State();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentState, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("StateID", existingItem.StateID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentState = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current State item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentState != null)
			{
				State existingItem = solutionContext.StateList.Find(i => i.StateID == solutionContext.CurrentState.StateID);
				if (existingItem != null)
				{
					solutionContext.StateList.Remove(solutionContext.CurrentState);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the State instance from an xml file.</summary>
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
		/// <summary>This method saves the State instance to an xml file.</summary>
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
			if (_fromStateTransitionList != null) _fromStateTransitionList.ResetLoaded(isLoaded);
			if (_toStateTransitionList != null) _toStateTransitionList.ResetLoaded(isLoaded);
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
			if (_fromStateTransitionList != null) _fromStateTransitionList.ResetModified(isModified);
			if (_toStateTransitionList != null) _toStateTransitionList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public State(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic State instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public State(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic State instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="stateID">The input value for StateID.</param>
		///--------------------------------------------------------------------------------
		public State(Guid stateID)
		{
			StateID = stateID;
		}
		#endregion "Constructors"
	}
}