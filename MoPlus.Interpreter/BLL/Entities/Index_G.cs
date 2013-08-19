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
	/// specific Index instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Index")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Index : BusinessObjectBase
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
			
			error = GetValidationError("IndexName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("EntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsPrimaryKeyIndex");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsUniqueIndex");
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
				case "_indexName":
				case "IndexName":
					error = ValidateIndexName();
					break;
				case "_entityID":
				case "EntityID":
					error = ValidateEntityID();
					break;
				case "_isPrimaryKeyIndex":
				case "IsPrimaryKeyIndex":
					error = ValidateIsPrimaryKeyIndex();
					break;
				case "_isUniqueIndex":
				case "IsUniqueIndex":
					error = ValidateIsUniqueIndex();
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
		/// <summary>This method validates IndexName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIndexName()
		{
			if (!Regex.IsMatch(IndexName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "IndexName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates EntityID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateEntityID()
		{
			if (EntityID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "EntityID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsPrimaryKeyIndex and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsPrimaryKeyIndex()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsUniqueIndex and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsUniqueIndex()
		{
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
		
		private Index _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Index ForwardInstance
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
		
		private Index _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Index ReverseInstance
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
				return IndexID;
			}
			set
			{
				IndexID = value;
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
				return IndexName;
			}
			set
			{
				IndexName = value;
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
				return SourceIndex.IndexName;
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
					if (!String.IsNullOrEmpty(EntityName))
					{
						_displayName = EntityName + "." + IndexName;
					}
					else
					{
						_displayName = IndexName;
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
					if (Entity != null)
					{
						_defaultSourceName = Entity.DefaultSourceName + "." + DefaultSourcePrefix + SourceIndex.IndexName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceIndex.IndexName;
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
		public Index SourceIndex
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
		/// <summary>This property gets/sets the OldIndexID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldIndexID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldEntityID { get; set; }
		
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
		
		protected Guid _indexID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IndexID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid IndexID
		{
			get
			{
				return _indexID;
			}
			set
			{
				if (_indexID != value)
				{
					_indexID = value;
					_isModified = true;
					base.OnPropertyChanged("IndexID");
				}
			}
		}
		
		protected string _indexName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IndexName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string IndexName
		{
			get
			{
				return _indexName;
			}
			set
			{
				if (_indexName != value)
				{
					_indexName = value;
					_isModified = true;
					base.OnPropertyChanged("IndexName");
				}
			}
		}
		
		protected Guid _entityID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid EntityID
		{
			get
			{
				return _entityID;
			}
			set
			{
				if (_entityID != value)
				{
					_entityID = value;
					_isModified = true;
					base.OnPropertyChanged("EntityID");
				}
			}
		}
		
		protected bool _isPrimaryKeyIndex = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsPrimaryKeyIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsPrimaryKeyIndex
		{
			get
			{
				return _isPrimaryKeyIndex;
			}
			set
			{
				if (_isPrimaryKeyIndex != value)
				{
					_isPrimaryKeyIndex = value;
					_isModified = true;
					base.OnPropertyChanged("IsPrimaryKeyIndex");
				}
			}
		}
		
		protected bool _isUniqueIndex = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsUniqueIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsUniqueIndex
		{
			get
			{
				return _isUniqueIndex;
			}
			set
			{
				if (_isUniqueIndex != value)
				{
					_isUniqueIndex = value;
					_isModified = true;
					base.OnPropertyChanged("IsUniqueIndex");
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
		
		protected string _entityName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string EntityName
		{
			get
			{
				return _entityName;
			}
		}
		
		protected int _entityTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int EntityTypeCode
		{
			get
			{
				return _entityTypeCode;
			}
		}
		
		protected int _identifierTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the IdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int IdentifierTypeCode
		{
			get
			{
				return _identifierTypeCode;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.IndexProperty> _indexPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Index.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.IndexProperty> IndexPropertyList
		{
			get
			{
				if (_indexPropertyList == null)
				{
					_indexPropertyList = new EnterpriseDataObjectList<BLL.Entities.IndexProperty>();
				}
				return _indexPropertyList;
			}
			set
			{
				if (_indexPropertyList == null || _indexPropertyList.Equals(value) == false)
				{
					_indexPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "IndexPropertyList")]
		[XmlArrayItem(typeof(BLL.Entities.IndexProperty), ElementName = "IndexProperty")]
		[DataMember(Name = "IndexPropertyList")]
		[DataArrayItem(ElementName = "IndexPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.IndexProperty> _S_IndexPropertyList
		{
			get
			{
				return _indexPropertyList;
			}
			set
			{
				_indexPropertyList = value;
			}
		}
		
		protected BLL.Entities.Entity _entity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Entity Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				if (value != null)
				{
					_entityName = value.EntityName;
					_entityTypeCode = value.EntityTypeCode;
					_identifierTypeCode = value.IdentifierTypeCode;
					if (_entity != null && _entity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					EntityID = value.EntityID;
				}
				_entity = value;
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
				return "IndexID";
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
				return IndexID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					IndexID = primaryKeyValues[0].GetGuid();
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
				if (_indexPropertyList != null && _indexPropertyList.IsModified == true) return true;
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
				ReverseInstance = new Index();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Index();
				ForwardInstance.IndexID = IndexID;
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
			foreach (IndexProperty indexProperty in IndexPropertyList)
			{
				indexProperty.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputIndex">The index to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Index inputIndex)
		{
			if (IndexName.GetString() != inputIndex.IndexName.GetString()) return false;
			if (EntityID.GetGuid() != inputIndex.EntityID.GetGuid()) return false;
			if (IsPrimaryKeyIndex.GetBool() != inputIndex.IsPrimaryKeyIndex.GetBool()) return false;
			if (IsUniqueIndex.GetBool() != inputIndex.IsUniqueIndex.GetBool()) return false;
			if (IsAutoUpdated.GetBool() != inputIndex.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputIndex.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputIndex">The index to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Index inputIndex)
		{
			if (inputIndex == null) return true;
			if (inputIndex.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputIndex.IndexName)) return false;
			if (EntityID != inputIndex.EntityID) return false;
			if (IsPrimaryKeyIndex != inputIndex.IsPrimaryKeyIndex) return false;
			if (IsUniqueIndex != inputIndex.IsUniqueIndex) return false;
			if (IsAutoUpdated != inputIndex.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputIndex.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputIndex">The index to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Index inputIndex)
		{
			IndexName = inputIndex.IndexName;
			EntityID = inputIndex.EntityID;
			IsPrimaryKeyIndex = inputIndex.IsPrimaryKeyIndex;
			IsUniqueIndex = inputIndex.IsUniqueIndex;
			IsAutoUpdated = inputIndex.IsAutoUpdated;
			Description = inputIndex.Description;
			
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
				IndexID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (IndexID == Guid.Empty)
				{
					IndexID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = IndexID;
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
			Entity = null;
			Solution = null;
			if (_indexPropertyList != null)
			{
				foreach (IndexProperty item in IndexPropertyList)
				{
					item.Dispose();
				}
				IndexPropertyList.Clear();
				IndexPropertyList = null;
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
					ReverseInstance = new Index();
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
			newItem.ItemID = IndexID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Index GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Index forwardItem = new Index();
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
				forwardItem.IndexID = IndexID;
			}
			foreach (IndexProperty item in IndexPropertyList)
			{
				item.Index = this;
				IndexProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.IndexPropertyList.Add(forwardChildItem);
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
				if (modelContext is Index)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Entity)
				{
					solutionContext.NeedsSample = false;
					Entity parent = modelContext as Entity;
					if (parent.IndexList.Count > 0)
					{
						return parent.IndexList[DataHelper.GetRandomInt(0, parent.IndexList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.IndexList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.IndexList[DataHelper.GetRandomInt(0, solutionContext.IndexList.Count - 1)];
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
				if (nodeContext is Entity)
				{
					return (nodeContext as Entity).IndexList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).IndexList;
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
			return Entity;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Entity entity = Solution.EntityList.Find(i => i.EntityID == EntityID);
			if (entity != null)
			{
				Entity = entity;
				SetID();  // id (from saved ids) may change based on parent info
				Index index = entity.IndexList.Find(i => i.IndexID == IndexID);
				if (index != null)
				{
					if (index != this)
					{
						entity.IndexList.Remove(index);
						entity.IndexList.Add(this);
					}
				}
				else
				{
					entity.IndexList.Add(this);
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
			if (solutionContext.CurrentIndex != null)
			{
				string validationErrors = solutionContext.CurrentIndex.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentIndex, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentIndex.Solution = solutionContext;
				solutionContext.CurrentIndex.AddToParent();
				Index existingItem = solutionContext.IndexList.Find(i => i.IndexID == solutionContext.CurrentIndex.IndexID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentIndex.AssignProperty("IndexID", solutionContext.CurrentIndex.IndexID);
					solutionContext.CurrentIndex.ReverseInstance.ResetModified(false);
					solutionContext.IndexList.Add(solutionContext.CurrentIndex);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Index();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentIndex, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("IndexID", existingItem.IndexID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentIndex = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Index item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentIndex != null)
			{
				Index existingItem = solutionContext.IndexList.Find(i => i.IndexID == solutionContext.CurrentIndex.IndexID);
				if (existingItem != null)
				{
					solutionContext.IndexList.Remove(solutionContext.CurrentIndex);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Index instance from an xml file.</summary>
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
		/// <summary>This method saves the Index instance to an xml file.</summary>
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
			if (_indexPropertyList != null) _indexPropertyList.ResetLoaded(isLoaded);
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
			if (_indexPropertyList != null) _indexPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Index(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Index instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Index(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Index instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="indexID">The input value for IndexID.</param>
		///--------------------------------------------------------------------------------
		public Index(Guid indexID)
		{
			IndexID = indexID;
		}
		#endregion "Constructors"
	}
}