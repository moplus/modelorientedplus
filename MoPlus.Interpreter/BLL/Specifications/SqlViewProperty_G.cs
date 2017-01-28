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

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific SqlViewProperty instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="SqlViewProperty")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlViewProperty : BusinessObjectBase
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
			
			error = GetValidationError("DbID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlViewID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedTable");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedColumn");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Urn");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("State");
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
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlViewID":
				case "SqlViewID":
					error = ValidateSqlViewID();
					break;
				case "_referencedTable":
				case "ReferencedTable":
					error = ValidateReferencedTable();
					break;
				case "_referencedColumn":
				case "ReferencedColumn":
					error = ValidateReferencedColumn();
					break;
				case "_urn":
				case "Urn":
					error = ValidateUrn();
					break;
				case "_state":
				case "State":
					error = ValidateState();
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
		/// <summary>This method validates DbID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDbID()
		{
			if (DbID != null && DbID < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "DbID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlViewID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlViewID()
		{
			if (SqlViewID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "SqlViewID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ReferencedTable and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedTable()
		{
			if (String.IsNullOrEmpty(ReferencedTable))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "ReferencedTable");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ReferencedColumn and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedColumn()
		{
			if (String.IsNullOrEmpty(ReferencedColumn))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "ReferencedColumn");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Urn and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateUrn()
		{
			if (String.IsNullOrEmpty(Urn))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Urn");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates State and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateState()
		{
			if (String.IsNullOrEmpty(State))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "State");
			}
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
		
		private SqlViewProperty _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlViewProperty ForwardInstance
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
		
		private SqlViewProperty _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlViewProperty ReverseInstance
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
				return SqlViewPropertyID;
			}
			set
			{
				SqlViewPropertyID = value;
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
		public SqlViewProperty SourceSqlViewProperty
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
		/// <summary>This property gets/sets the OldSqlViewPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlViewPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlViewID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlViewID { get; set; }
		
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
		
		protected Guid _sqlViewPropertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlViewPropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlViewPropertyID
		{
			get
			{
				return _sqlViewPropertyID;
			}
			set
			{
				if (_sqlViewPropertyID != value)
				{
					_sqlViewPropertyID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlViewPropertyID");
				}
			}
		}
		
		protected int? _dbID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DbID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual int? DbID
		{
			get
			{
				return _dbID;
			}
			set
			{
				if (_dbID != value)
				{
					_dbID = value;
					_isModified = true;
					base.OnPropertyChanged("DbID");
				}
			}
		}
		
		protected Guid _sqlViewID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlViewID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlViewID
		{
			get
			{
				return _sqlViewID;
			}
			set
			{
				if (_sqlViewID != value)
				{
					_sqlViewID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlViewID");
				}
			}
		}
		
		protected string _referencedTable = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ReferencedTable
		{
			get
			{
				return _referencedTable;
			}
			set
			{
				if (_referencedTable != value)
				{
					_referencedTable = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedTable");
				}
			}
		}
		
		protected string _referencedColumn = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ReferencedColumn
		{
			get
			{
				return _referencedColumn;
			}
			set
			{
				if (_referencedColumn != value)
				{
					_referencedColumn = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedColumn");
				}
			}
		}
		
		protected string _urn = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Urn.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Urn
		{
			get
			{
				return _urn;
			}
			set
			{
				if (_urn != value)
				{
					_urn = value;
					_isModified = true;
					base.OnPropertyChanged("Urn");
				}
			}
		}
		
		protected string _state = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the State.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string State
		{
			get
			{
				return _state;
			}
			set
			{
				if (_state != value)
				{
					_state = value;
					_isModified = true;
					base.OnPropertyChanged("State");
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
		
		protected string _sqlViewName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlViewName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlViewName
		{
			get
			{
				return _sqlViewName;
			}
		}
		
		protected BLL.Specifications.SqlView _sqlView = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlView.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlView SqlView
		{
			get
			{
				return _sqlView;
			}
			set
			{
				if (value != null)
				{
					_sqlViewName = value.SqlViewName;
					if (_sqlView != null && _sqlView.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlViewID = value.SqlViewID;
				}
				_sqlView = value;
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
				return "SqlViewPropertyID";
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
				return SqlViewPropertyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlViewPropertyID = primaryKeyValues[0].GetGuid();
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
			if (ReverseInstance == null)
			{
				ReverseInstance = new SqlViewProperty();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlViewProperty();
				ForwardInstance.SqlViewPropertyID = SqlViewPropertyID;
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
		/// <param name="inputSqlViewProperty">The sqlviewproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlViewProperty inputSqlViewProperty)
		{
			if (DbID.GetInt() != inputSqlViewProperty.DbID.GetInt()) return false;
			if (SqlViewID.GetGuid() != inputSqlViewProperty.SqlViewID.GetGuid()) return false;
			if (ReferencedTable.GetString() != inputSqlViewProperty.ReferencedTable.GetString()) return false;
			if (ReferencedColumn.GetString() != inputSqlViewProperty.ReferencedColumn.GetString()) return false;
			if (Urn.GetString() != inputSqlViewProperty.Urn.GetString()) return false;
			if (State.GetString() != inputSqlViewProperty.State.GetString()) return false;
			if (Description.GetString() != inputSqlViewProperty.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlViewProperty">The sqlviewproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlViewProperty inputSqlViewProperty)
		{
			if (inputSqlViewProperty == null) return true;
			if (inputSqlViewProperty.TagList.Count > 0) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlViewID != inputSqlViewProperty.SqlViewID) return false;
			if (!String.IsNullOrEmpty(inputSqlViewProperty.ReferencedTable)) return false;
			if (!String.IsNullOrEmpty(inputSqlViewProperty.ReferencedColumn)) return false;
			if (!String.IsNullOrEmpty(inputSqlViewProperty.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlViewProperty.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlViewProperty.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlViewProperty">The sqlviewproperty to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlViewProperty inputSqlViewProperty)
		{
			DbID = inputSqlViewProperty.DbID;
			SqlViewID = inputSqlViewProperty.SqlViewID;
			ReferencedTable = inputSqlViewProperty.ReferencedTable;
			ReferencedColumn = inputSqlViewProperty.ReferencedColumn;
			Urn = inputSqlViewProperty.Urn;
			State = inputSqlViewProperty.State;
			Description = inputSqlViewProperty.Description;
			
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
				SqlViewPropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlViewPropertyID == Guid.Empty)
				{
					SqlViewPropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlViewPropertyID;
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
			SqlView = null;
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
					ReverseInstance = new SqlViewProperty();
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
			newItem.ItemID = SqlViewPropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlViewProperty GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlViewProperty forwardItem = new SqlViewProperty();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlViewPropertyID = SqlViewPropertyID;
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
				if (modelContext is SqlViewProperty)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlView)
				{
					solutionContext.NeedsSample = false;
					SqlView parent = modelContext as SqlView;
					if (parent.SqlViewPropertyList.Count > 0)
					{
						return parent.SqlViewPropertyList[DataHelper.GetRandomInt(0, parent.SqlViewPropertyList.Count - 1)];
					}
				}
				#region protected
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent != null && parent.SqlViewList.Count > 0)
					{
						return parent.SqlViewList[0].SqlViewPropertyList[DataHelper.GetRandomInt(0, parent.SqlViewList[0].SqlViewPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent != null && parent.SqlViewList.Count > 0)
					{
						return parent.SqlViewList[0].SqlViewPropertyList[DataHelper.GetRandomInt(0, parent.SqlViewList[0].SqlViewPropertyList.Count - 1)];
					}
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			
			#region protected
			#endregion protected
			
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
				if (nodeContext is SqlView)
				{
					return (nodeContext as SqlView).SqlViewPropertyList;
				}
				
				#region protected
				else if (nodeContext is SqlDatabase)
				{
					EnterpriseDataObjectList<SqlViewProperty> properties = new EnterpriseDataObjectList<SqlViewProperty>();
					foreach (SqlView view in (nodeContext as SqlDatabase).SqlViewList)
					{
						foreach (SqlViewProperty property in view.SqlViewPropertyList)
						{
							properties.Add(property);
						}
					}
					return properties;
				}
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						EnterpriseDataObjectList<SqlViewProperty> properties = new EnterpriseDataObjectList<SqlViewProperty>();
						foreach (SqlView view in (nodeContext as DatabaseSource).SpecDatabase.SqlViewList)
						{
							foreach (SqlViewProperty property in view.SqlViewPropertyList)
							{
								properties.Add(property);
							}
						}
						return properties;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						EnterpriseDataObjectList<SqlViewProperty> properties = new EnterpriseDataObjectList<SqlViewProperty>();
						foreach (SqlView view in (nodeContext as Project).OutputDatabase.SqlViewList)
						{
							foreach (SqlViewProperty property in view.SqlViewPropertyList)
							{
								properties.Add(property);
							}
						}
						return properties;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlViewProperty> properties = new EnterpriseDataObjectList<SqlViewProperty>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlView view in source.SpecDatabase.SqlViewList)
							{
								foreach (SqlViewProperty property in view.SqlViewPropertyList)
								{
									properties.Add(property);
								}
							}
						}
					}
					return properties;
				}
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
			return SqlView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlViewProperty instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlViewProperty instance to an xml file.</summary>
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
		public SqlViewProperty(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlViewProperty instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlViewProperty(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlViewProperty instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlViewPropertyID">The input value for SqlViewPropertyID.</param>
		///--------------------------------------------------------------------------------
		public SqlViewProperty(Guid sqlViewPropertyID)
		{
			SqlViewPropertyID = sqlViewPropertyID;
		}
		#endregion "Constructors"
	}
}