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
	/// specific Collection instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>9/4/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="Collection")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Collection : Solutions.PropertyBase
	{
		#region "Validation"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns validation errors for the input item.</param>
		/// 
		/// <returns>Validation errors (null by default).</returns>
		///--------------------------------------------------------------------------------
		public override string GetValidationErrors()
		{
			StringBuilder errors = new StringBuilder();
			string error = null;
			
			error = GetValidationError("CollectionName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("EntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedEntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsNullable");
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
				case "_collectionName":
				case "CollectionName":
					error = ValidateCollectionName();
					break;
				case "_entityID":
				case "EntityID":
					error = ValidateEntityID();
					break;
				case "_referencedEntityID":
				case "ReferencedEntityID":
					error = ValidateReferencedEntityID();
					break;
				case "_isNullable":
				case "IsNullable":
					error = ValidateIsNullable();
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
		/// <summary>This method validates CollectionName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateCollectionName()
		{
			if (!Regex.IsMatch(CollectionName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "CollectionName");
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
		/// <summary>This method validates ReferencedEntityID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedEntityID()
		{
			if (ReferencedEntityID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "ReferencedEntityID");
			}
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private Collection _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Collection ForwardInstance
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
		
		private Collection _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Collection ReverseInstance
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
				return PropertyID;
			}
			set
			{
				PropertyID = value;
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
				return CollectionName;
			}
			set
			{
				CollectionName = value;
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
				return SourceCollection.CollectionName;
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
						_displayName = EntityName + "." + CollectionName;
					}
					else
					{
						_displayName = CollectionName;
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
		public override string DefaultSourceName
		{
			get
			{
				if (_defaultSourceName == null)
				{
					if (Entity != null)
					{
						_defaultSourceName = Entity.DefaultSourceName + "." + DefaultSourcePrefix + SourceCollection.CollectionName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceCollection.CollectionName;
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
		public Collection SourceCollection
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
		/// <summary>This property gets/sets the OldEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldEntityID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldReferencedEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldReferencedEntityID { get; set; }
		
		
		protected string _collectionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CollectionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string CollectionName
		{
			get
			{
				return _collectionName;
			}
			set
			{
				if (_collectionName != value)
				{
					_collectionName = value;
					_isModified = true;
					base.OnPropertyChanged("CollectionName");
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
		
		protected Guid _referencedEntityID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedEntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid ReferencedEntityID
		{
			get
			{
				return _referencedEntityID;
			}
			set
			{
				if (_referencedEntityID != value)
				{
					_referencedEntityID = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedEntityID");
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
		
		protected string _groupName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the GroupName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string GroupName
		{
			get
			{
				return _groupName;
			}
		}
		
		protected string _referencedEntityName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedEntityName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ReferencedEntityName
		{
			get
			{
				return _referencedEntityName;
			}
		}
		
		protected int _referencedEntityTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedEntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int ReferencedEntityTypeCode
		{
			get
			{
				return _referencedEntityTypeCode;
			}
		}
		
		protected int _referencedIdentifierTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedIdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int ReferencedIdentifierTypeCode
		{
			get
			{
				return _referencedIdentifierTypeCode;
			}
		}
		
		protected string _referencedGroupName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ReferencedGroupName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ReferencedGroupName
		{
			get
			{
				return _referencedGroupName;
			}
		}
		
		protected BLL.Entities.Entity _referencedEntity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ReferencedEntity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Entity ReferencedEntity
		{
			get
			{
				return _referencedEntity;
			}
			set
			{
				if (value != null)
				{
					_referencedEntityName = value.EntityName;
					_referencedEntityTypeCode = value.EntityTypeCode;
					_referencedIdentifierTypeCode = value.IdentifierTypeCode;
					_referencedGroupName = value.GroupName;
					if (_referencedEntity != null && _referencedEntity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					ReferencedEntityID = value.EntityID;
				}
				_referencedEntity = value;
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
					_groupName = value.GroupName;
					if (_entity != null && _entity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					EntityID = value.EntityID;
				}
				_entity = value;
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
				ReverseInstance = new Collection();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Collection();
				ForwardInstance.PropertyID = PropertyID;
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
		public override void AddItemToUsedTags(NameObjectCollection usedTags)
		{
			AddTagsToUsedTags(usedTags);
			foreach (PropertyRelationship propertyRelationship in PropertyRelationshipList)
			{
				propertyRelationship.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputCollection">The collection to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Collection inputCollection)
		{
			if (CollectionName.GetString() != inputCollection.CollectionName.GetString()) return false;
			if (EntityID.GetGuid() != inputCollection.EntityID.GetGuid()) return false;
			if (ReferencedEntityID.GetGuid() != inputCollection.ReferencedEntityID.GetGuid()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputCollection">The collection to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Collection inputCollection)
		{
			if (inputCollection == null) return true;
			if (inputCollection.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputCollection.CollectionName)) return false;
			if (EntityID != inputCollection.EntityID) return false;
			if (ReferencedEntityID != inputCollection.ReferencedEntityID) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputCollection">The collection to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Collection inputCollection)
		{
			CollectionName = inputCollection.CollectionName;
			EntityID = inputCollection.EntityID;
			ReferencedEntityID = inputCollection.ReferencedEntityID;
			
			#region protected
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public override void SetID()
		{
			_defaultSourceName = null;
			if (Solution.UsedModelIDs[DefaultSourceName].GetGuid() != Guid.Empty)
			{
				PropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (PropertyID == Guid.Empty)
				{
					PropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = PropertyID;
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
			ReferencedEntity = null;
			Entity = null;
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
		public override bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new Collection();
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
		public override CollectionItem CreateIDReference()
		{
			CollectionItem newItem = new CollectionItem();
			newItem.ItemID = PropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public new Collection GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Collection forwardItem = new Collection();
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
				forwardItem.PropertyID = PropertyID;
			}
			foreach (PropertyRelationship item in PropertyRelationshipList)
			{
				item.PropertyBase = this;
				PropertyRelationship forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyRelationshipList.Add(forwardChildItem);
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
			if (forwardItem.ReferencedEntityID != Guid.Empty)
			{
				forwardItem.ReferencedEntity = Solution.EntityList.FindByID(forwardItem.ReferencedEntityID);
				if (forwardItem.ReferencedEntity != null && forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.ReferencedEntity.DefaultSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(forwardItem.ReferencedEntity.CreateIDReference());
				}
			}
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
				if (modelContext is Collection)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Entity)
				{
					solutionContext.NeedsSample = false;
					Entity parent = modelContext as Entity;
					if (parent.CollectionList.Count > 0)
					{
						return parent.CollectionList[DataHelper.GetRandomInt(0, parent.CollectionList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.CollectionList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.CollectionList[DataHelper.GetRandomInt(0, solutionContext.CollectionList.Count - 1)];
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
					return (nodeContext as Entity).CollectionList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).CollectionList;
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
				Collection collection = entity.CollectionList.Find(i => i.PropertyID == PropertyID);
				if (collection != null)
				{
					if (collection != this)
					{
						entity.CollectionList.Remove(collection);
						entity.CollectionList.Add(this);
					}
				}
				else
				{
					entity.CollectionList.Add(this);
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
			if (solutionContext.CurrentCollection != null)
			{
				string validationErrors = solutionContext.CurrentCollection.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentCollection, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentCollection.Solution = solutionContext;
				solutionContext.CurrentCollection.AddToParent();
				Collection existingItem = solutionContext.CollectionList.Find(i => i.PropertyID == solutionContext.CurrentCollection.PropertyID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentCollection.AssignProperty("PropertyID", solutionContext.CurrentCollection.PropertyID);
					solutionContext.CurrentCollection.ReverseInstance.ResetModified(false);
					solutionContext.CollectionList.Add(solutionContext.CurrentCollection);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new Collection();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentCollection, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("PropertyID", existingItem.PropertyID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentCollection = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current Collection item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentCollection != null)
			{
				Collection existingItem = solutionContext.CollectionList.Find(i => i.PropertyID == solutionContext.CurrentCollection.PropertyID);
				if (existingItem != null)
				{
					solutionContext.CollectionList.Remove(solutionContext.CurrentCollection);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Collection instance from an xml file.</summary>
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
		/// <summary>This method saves the Collection instance to an xml file.</summary>
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
			base.ResetLoaded(isLoaded);
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
		public Collection(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Collection instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Collection(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Collection instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="propertyID">The input value for PropertyID.</param>
		///--------------------------------------------------------------------------------
		public Collection(Guid propertyID)
		{
			PropertyID = propertyID;
		}
		#endregion "Constructors"
	}
}