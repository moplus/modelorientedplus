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
	/// specific SqlForeignKeyColumn instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlForeignKeyColumn")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlForeignKeyColumn : BusinessObjectBase
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
			
			error = GetValidationError("SqlForeignKeyColumnName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DbID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlForeignKeyID");
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
				case "_sqlForeignKeyColumnName":
				case "SqlForeignKeyColumnName":
					error = ValidateSqlForeignKeyColumnName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlForeignKeyID":
				case "SqlForeignKeyID":
					error = ValidateSqlForeignKeyID();
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
		/// <summary>This method validates SqlForeignKeyColumnName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlForeignKeyColumnName()
		{
			if (!Regex.IsMatch(SqlForeignKeyColumnName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlForeignKeyColumnName");
			}
			return null;
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
		/// <summary>This method validates SqlForeignKeyID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlForeignKeyID()
		{
			if (SqlForeignKeyID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "SqlForeignKeyID");
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
		
		private SqlForeignKeyColumn _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlForeignKeyColumn ForwardInstance
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
		
		private SqlForeignKeyColumn _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlForeignKeyColumn ReverseInstance
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
				return SqlForeignKeyColumnID;
			}
			set
			{
				SqlForeignKeyColumnID = value;
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
				return SqlForeignKeyColumnName;
			}
			set
			{
				SqlForeignKeyColumnName = value;
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
				return SourceSqlForeignKeyColumn.SqlForeignKeyColumnName;
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
					if (!String.IsNullOrEmpty(SqlForeignKeyName))
					{
						_displayName = SqlForeignKeyName + "." + SqlForeignKeyColumnName;
					}
					else
					{
						_displayName = SqlForeignKeyColumnName;
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
					if (SqlForeignKey != null)
					{
						_defaultSourceName = SqlForeignKey.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlForeignKeyColumn.SqlForeignKeyColumnName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlForeignKeyColumn.SqlForeignKeyColumnName;
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
		public SqlForeignKeyColumn SourceSqlForeignKeyColumn
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
		/// <summary>This property gets/sets the OldSqlForeignKeyColumnID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlForeignKeyColumnID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlForeignKeyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlForeignKeyID { get; set; }
		
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
		
		protected Guid _sqlForeignKeyColumnID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlForeignKeyColumnID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlForeignKeyColumnID
		{
			get
			{
				return _sqlForeignKeyColumnID;
			}
			set
			{
				if (_sqlForeignKeyColumnID != value)
				{
					_sqlForeignKeyColumnID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlForeignKeyColumnID");
				}
			}
		}
		
		protected string _sqlForeignKeyColumnName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlForeignKeyColumnName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlForeignKeyColumnName
		{
			get
			{
				return _sqlForeignKeyColumnName;
			}
			set
			{
				if (_sqlForeignKeyColumnName != value)
				{
					_sqlForeignKeyColumnName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlForeignKeyColumnName");
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
		
		protected Guid _sqlForeignKeyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlForeignKeyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlForeignKeyID
		{
			get
			{
				return _sqlForeignKeyID;
			}
			set
			{
				if (_sqlForeignKeyID != value)
				{
					_sqlForeignKeyID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlForeignKeyID");
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
		
		protected string _sqlForeignKeyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlForeignKeyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlForeignKeyName
		{
			get
			{
				return _sqlForeignKeyName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _sqlPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlForeignKeyColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlProperty> SqlPropertyList
		{
			get
			{
				if (_sqlPropertyList == null)
				{
					_sqlPropertyList = new EnterpriseDataObjectList<BLL.Specifications.SqlProperty>();
				}
				return _sqlPropertyList;
			}
			set
			{
				if (_sqlPropertyList == null || _sqlPropertyList.Equals(value) == false)
				{
					_sqlPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlPropertyList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlProperty), ElementName = "SqlProperty")]
		[DataMember(Name = "SqlPropertyList")]
		[DataArrayItem(ElementName = "SqlPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _S_SqlPropertyList
		{
			get
			{
				return _sqlPropertyList;
			}
			set
			{
				_sqlPropertyList = value;
			}
		}
		
		protected BLL.Specifications.SqlForeignKey _sqlForeignKey = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlForeignKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlForeignKey SqlForeignKey
		{
			get
			{
				return _sqlForeignKey;
			}
			set
			{
				if (value != null)
				{
					_sqlForeignKeyName = value.SqlForeignKeyName;
					if (_sqlForeignKey != null && _sqlForeignKey.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlForeignKeyID = value.SqlForeignKeyID;
				}
				_sqlForeignKey = value;
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
				return "SqlForeignKeyColumnID";
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
				return SqlForeignKeyColumnID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlForeignKeyColumnID = primaryKeyValues[0].GetGuid();
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
				if (_sqlPropertyList != null && _sqlPropertyList.IsModified == true) return true;
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
				ReverseInstance = new SqlForeignKeyColumn();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlForeignKeyColumn();
				ForwardInstance.SqlForeignKeyColumnID = SqlForeignKeyColumnID;
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
			foreach (SqlProperty sqlProperty in SqlPropertyList)
			{
				sqlProperty.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputSqlForeignKeyColumn">The sqlforeignkeycolumn to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlForeignKeyColumn inputSqlForeignKeyColumn)
		{
			if (SqlForeignKeyColumnName.GetString() != inputSqlForeignKeyColumn.SqlForeignKeyColumnName.GetString()) return false;
			if (DbID.GetInt() != inputSqlForeignKeyColumn.DbID.GetInt()) return false;
			if (SqlForeignKeyID.GetGuid() != inputSqlForeignKeyColumn.SqlForeignKeyID.GetGuid()) return false;
			if (ReferencedColumn.GetString() != inputSqlForeignKeyColumn.ReferencedColumn.GetString()) return false;
			if (Urn.GetString() != inputSqlForeignKeyColumn.Urn.GetString()) return false;
			if (State.GetString() != inputSqlForeignKeyColumn.State.GetString()) return false;
			if (Description.GetString() != inputSqlForeignKeyColumn.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlForeignKeyColumn">The sqlforeignkeycolumn to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlForeignKeyColumn inputSqlForeignKeyColumn)
		{
			if (inputSqlForeignKeyColumn == null) return true;
			if (inputSqlForeignKeyColumn.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKeyColumn.SqlForeignKeyColumnName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlForeignKeyID != inputSqlForeignKeyColumn.SqlForeignKeyID) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKeyColumn.ReferencedColumn)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKeyColumn.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKeyColumn.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKeyColumn.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlForeignKeyColumn">The sqlforeignkeycolumn to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlForeignKeyColumn inputSqlForeignKeyColumn)
		{
			SqlForeignKeyColumnName = inputSqlForeignKeyColumn.SqlForeignKeyColumnName;
			DbID = inputSqlForeignKeyColumn.DbID;
			SqlForeignKeyID = inputSqlForeignKeyColumn.SqlForeignKeyID;
			ReferencedColumn = inputSqlForeignKeyColumn.ReferencedColumn;
			Urn = inputSqlForeignKeyColumn.Urn;
			State = inputSqlForeignKeyColumn.State;
			Description = inputSqlForeignKeyColumn.Description;
			
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
				SqlForeignKeyColumnID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlForeignKeyColumnID == Guid.Empty)
				{
					SqlForeignKeyColumnID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlForeignKeyColumnID;
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
			SqlForeignKey = null;
			Solution = null;
			if (_sqlPropertyList != null)
			{
				foreach (SqlProperty item in SqlPropertyList)
				{
					item.Dispose();
				}
				SqlPropertyList.Clear();
				SqlPropertyList = null;
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
					ReverseInstance = new SqlForeignKeyColumn();
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
			newItem.ItemID = SqlForeignKeyColumnID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlForeignKeyColumn GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlForeignKeyColumn forwardItem = new SqlForeignKeyColumn();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlForeignKeyColumnID = SqlForeignKeyColumnID;
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlForeignKeyColumn = this;
				SqlProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlPropertyList.Add(forwardChildItem);
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
				if (modelContext is SqlForeignKeyColumn)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlForeignKey)
				{
					solutionContext.NeedsSample = false;
					SqlForeignKey parent = modelContext as SqlForeignKey;
					if (parent.SqlForeignKeyColumnList.Count > 0)
					{
						return parent.SqlForeignKeyColumnList[DataHelper.GetRandomInt(0, parent.SqlForeignKeyColumnList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlProperty)
				{
					if ((modelContext as SqlProperty).SqlForeignKeyColumn != null)
					{
						return (modelContext as SqlProperty).SqlForeignKeyColumn;
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlTable)
				{
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlForeignKeyList.Count > 0)
					{
						SqlForeignKey key = parent.SqlForeignKeyList[DataHelper.GetRandomInt(0, parent.SqlForeignKeyList.Count - 1)];
						if (key.SqlForeignKeyColumnList.Count > 0)
						{
							return key.SqlForeignKeyColumnList[DataHelper.GetRandomInt(0, key.SqlForeignKeyColumnList.Count - 1)];
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlDatabase)
				{
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlForeignKeyList.Count > 0)
						{
							SqlForeignKey key = table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
							if (key.SqlForeignKeyColumnList.Count > 0)
							{
								return key.SqlForeignKeyColumnList[DataHelper.GetRandomInt(0, key.SqlForeignKeyColumnList.Count - 1)];
							}
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlForeignKeyList.Count > 0)
						{
							SqlForeignKey key = table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
							if (key.SqlForeignKeyColumnList.Count > 0)
							{
								return key.SqlForeignKeyColumnList[DataHelper.GetRandomInt(0, key.SqlForeignKeyColumnList.Count - 1)];
							}
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlForeignKeyList.Count > 0)
						{
							SqlForeignKey key = table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
							if (key.SqlForeignKeyColumnList.Count > 0)
							{
								return key.SqlForeignKeyColumnList[DataHelper.GetRandomInt(0, key.SqlForeignKeyColumnList.Count - 1)];
							}
						}
					}
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			
			#region protected
			if (solutionContext.IsSampleMode == true && solutionContext.DatabaseSourceList.Count > 0)
			{
				SqlDatabase parent = solutionContext.DatabaseSourceList[DataHelper.GetRandomInt(0, solutionContext.DatabaseSourceList.Count - 1)].SpecDatabase;
				if (parent.SqlTableList.Count > 0)
				{
					SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
					if (table.SqlForeignKeyList.Count > 0)
					{
						SqlForeignKey key = table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
						if (key.SqlForeignKeyColumnList.Count > 0)
						{
							return key.SqlForeignKeyColumnList[DataHelper.GetRandomInt(0, key.SqlForeignKeyColumnList.Count - 1)];
						}
					}
				}
			}
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
				if (nodeContext is SqlForeignKey)
				{
					return (nodeContext as SqlForeignKey).SqlForeignKeyColumnList;
				}
				
				#region protected
				else if (nodeContext is SqlTable)
				{
					EnterpriseDataObjectList<SqlForeignKeyColumn> columns = new EnterpriseDataObjectList<SqlForeignKeyColumn>();
					foreach (SqlForeignKey key in (nodeContext as SqlTable).SqlForeignKeyList)
					{
						foreach (SqlForeignKeyColumn column in key.SqlForeignKeyColumnList)
						{
							columns.Add(column);
						}
					}
					return columns;
				}
				else if (nodeContext is SqlDatabase)
				{
					EnterpriseDataObjectList<SqlForeignKeyColumn> columns = new EnterpriseDataObjectList<SqlForeignKeyColumn>();
					foreach (SqlTable table in (nodeContext as SqlDatabase).SqlTableList)
					{
						foreach (SqlForeignKey key in table.SqlForeignKeyList)
						{
							foreach (SqlForeignKeyColumn column in key.SqlForeignKeyColumnList)
							{
								columns.Add(column);
							}
						}
					}
					return columns;
				}
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						EnterpriseDataObjectList<SqlForeignKeyColumn> columns = new EnterpriseDataObjectList<SqlForeignKeyColumn>();
						foreach (SqlTable table in (nodeContext as DatabaseSource).SpecDatabase.SqlTableList)
						{
							foreach (SqlForeignKey key in table.SqlForeignKeyList)
							{
								foreach (SqlForeignKeyColumn column in key.SqlForeignKeyColumnList)
								{
									columns.Add(column);
								}
							}
						}
						return columns;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						EnterpriseDataObjectList<SqlForeignKeyColumn> columns = new EnterpriseDataObjectList<SqlForeignKeyColumn>();
						foreach (SqlTable table in (nodeContext as Project).OutputDatabase.SqlTableList)
						{
							foreach (SqlForeignKey key in table.SqlForeignKeyList)
							{
								foreach (SqlForeignKeyColumn column in key.SqlForeignKeyColumnList)
								{
									columns.Add(column);
								}
							}
						}
						return columns;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlForeignKeyColumn> columns = new EnterpriseDataObjectList<SqlForeignKeyColumn>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlTable table in source.SpecDatabase.SqlTableList)
							{
								foreach (SqlForeignKey key in table.SqlForeignKeyList)
								{
									foreach (SqlForeignKeyColumn column in key.SqlForeignKeyColumnList)
									{
										columns.Add(column);
									}
								}
							}
						}
					}
					return columns;
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
			return SqlForeignKey;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlForeignKeyColumn instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlForeignKeyColumn instance to an xml file.</summary>
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
			if (_sqlPropertyList != null) _sqlPropertyList.ResetLoaded(isLoaded);
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
			if (_sqlPropertyList != null) _sqlPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlForeignKeyColumn(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlForeignKeyColumn instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlForeignKeyColumn(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlForeignKeyColumn instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlForeignKeyColumnID">The input value for SqlForeignKeyColumnID.</param>
		///--------------------------------------------------------------------------------
		public SqlForeignKeyColumn(Guid sqlForeignKeyColumnID)
		{
			SqlForeignKeyColumnID = sqlForeignKeyColumnID;
		}
		#endregion "Constructors"
	}
}