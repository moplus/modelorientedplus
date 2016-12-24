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
	/// specific SqlExtendedProperty instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlExtendedProperty")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlExtendedProperty : BusinessObjectBase
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
			
			error = GetValidationError("SqlExtendedPropertyName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlValue");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlDatabaseID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlTableID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlColumnID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlIndexID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlForeignKeyID");
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
				case "_sqlExtendedPropertyName":
				case "SqlExtendedPropertyName":
					error = ValidateSqlExtendedPropertyName();
					break;
				case "_sqlValue":
				case "SqlValue":
					error = ValidateSqlValue();
					break;
				case "_sqlDatabaseID":
				case "SqlDatabaseID":
					error = ValidateSqlDatabaseID();
					break;
				case "_sqlTableID":
				case "SqlTableID":
					error = ValidateSqlTableID();
					break;
				case "_sqlColumnID":
				case "SqlColumnID":
					error = ValidateSqlColumnID();
					break;
				case "_sqlIndexID":
				case "SqlIndexID":
					error = ValidateSqlIndexID();
					break;
				case "_sqlForeignKeyID":
				case "SqlForeignKeyID":
					error = ValidateSqlForeignKeyID();
					break;
				case "_urn":
				case "Urn":
					error = ValidateUrn();
					break;
				case "_state":
				case "State":
					error = ValidateState();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlExtendedPropertyName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlExtendedPropertyName()
		{
			if (!Regex.IsMatch(SqlExtendedPropertyName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlExtendedPropertyName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlValue and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlValue()
		{
			if (String.IsNullOrEmpty(SqlValue))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "SqlValue");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlDatabaseID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlDatabaseID()
		{
			if (SqlDatabaseID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "SqlDatabaseID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlTableID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlTableID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlColumnID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlColumnID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlIndexID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlIndexID()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlForeignKeyID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlForeignKeyID()
		{
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
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private SqlExtendedProperty _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlExtendedProperty ForwardInstance
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
		
		private SqlExtendedProperty _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlExtendedProperty ReverseInstance
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
				return SqlExtendedPropertyID;
			}
			set
			{
				SqlExtendedPropertyID = value;
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
				return SqlExtendedPropertyName;
			}
			set
			{
				SqlExtendedPropertyName = value;
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
				return SourceSqlExtendedProperty.SqlExtendedPropertyName;
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
					if (!String.IsNullOrEmpty(SqlDatabaseName))
					{
						_displayName = SqlDatabaseName + "." + SqlExtendedPropertyName;
					}
					else
					{
						_displayName = SqlExtendedPropertyName;
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
					if (SqlDatabase != null)
					{
						_defaultSourceName = SqlDatabase.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlExtendedProperty.SqlExtendedPropertyName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlExtendedProperty.SqlExtendedPropertyName;
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
		public SqlExtendedProperty SourceSqlExtendedProperty
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
		/// <summary>This property gets/sets the OldSqlExtendedPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlExtendedPropertyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlDatabaseID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlDatabaseID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlTableID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlTableID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlColumnID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlColumnID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlIndexID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlIndexID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlForeignKeyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlForeignKeyID { get; set; }
		
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
		
		protected Guid _sqlExtendedPropertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlExtendedPropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlExtendedPropertyID
		{
			get
			{
				return _sqlExtendedPropertyID;
			}
			set
			{
				if (_sqlExtendedPropertyID != value)
				{
					_sqlExtendedPropertyID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlExtendedPropertyID");
				}
			}
		}
		
		protected string _sqlExtendedPropertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlExtendedPropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlExtendedPropertyName
		{
			get
			{
				return _sqlExtendedPropertyName;
			}
			set
			{
				if (_sqlExtendedPropertyName != value)
				{
					_sqlExtendedPropertyName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlExtendedPropertyName");
				}
			}
		}
		
		protected string _sqlValue = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlValue.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlValue
		{
			get
			{
				return _sqlValue;
			}
			set
			{
				if (_sqlValue != value)
				{
					_sqlValue = value;
					_isModified = true;
					base.OnPropertyChanged("SqlValue");
				}
			}
		}
		
		protected Guid _sqlDatabaseID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlDatabaseID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlDatabaseID
		{
			get
			{
				return _sqlDatabaseID;
			}
			set
			{
				if (_sqlDatabaseID != value)
				{
					_sqlDatabaseID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlDatabaseID");
				}
			}
		}
		
		protected Guid? _sqlTableID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlTableID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? SqlTableID
		{
			get
			{
				return _sqlTableID;
			}
			set
			{
				if (_sqlTableID != value)
				{
					_sqlTableID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlTableID");
				}
			}
		}
		
		protected Guid? _sqlColumnID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlColumnID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? SqlColumnID
		{
			get
			{
				return _sqlColumnID;
			}
			set
			{
				if (_sqlColumnID != value)
				{
					_sqlColumnID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlColumnID");
				}
			}
		}
		
		protected Guid? _sqlIndexID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlIndexID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? SqlIndexID
		{
			get
			{
				return _sqlIndexID;
			}
			set
			{
				if (_sqlIndexID != value)
				{
					_sqlIndexID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlIndexID");
				}
			}
		}
		
		protected Guid? _sqlForeignKeyID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlForeignKeyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? SqlForeignKeyID
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
		
		protected string _sqlColumnName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlColumnName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlColumnName
		{
			get
			{
				return _sqlColumnName;
			}
		}
		
		protected string _sqlDatabaseName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlDatabaseName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlDatabaseName
		{
			get
			{
				return _sqlDatabaseName;
			}
		}
		
		protected string _userName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the UserName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string UserName
		{
			get
			{
				return _userName;
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
		
		protected string _sqlIndexName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlIndexName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlIndexName
		{
			get
			{
				return _sqlIndexName;
			}
		}
		
		protected string _sqlTableName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlTableName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlTableName
		{
			get
			{
				return _sqlTableName;
			}
		}
		
		protected BLL.Specifications.SqlColumn _sqlColumn = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlColumn SqlColumn
		{
			get
			{
				return _sqlColumn;
			}
			set
			{
				if (value != null)
				{
					_sqlColumnName = value.SqlColumnName;
					if (_sqlColumn != null && _sqlColumn.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlColumnID = value.SqlColumnID;
				}
				_sqlColumn = value;
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
		
		protected BLL.Specifications.SqlDatabase _sqlDatabase = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlDatabase.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlDatabase SqlDatabase
		{
			get
			{
				return _sqlDatabase;
			}
			set
			{
				if (value != null)
				{
					_sqlDatabaseName = value.SqlDatabaseName;
					_userName = value.UserName;
					if (_sqlDatabase != null && _sqlDatabase.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlDatabaseID = value.SqlDatabaseID;
				}
				_sqlDatabase = value;
			}
		}
		
		protected BLL.Specifications.SqlIndex _sqlIndex = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlIndex SqlIndex
		{
			get
			{
				return _sqlIndex;
			}
			set
			{
				if (value != null)
				{
					_sqlIndexName = value.SqlIndexName;
					if (_sqlIndex != null && _sqlIndex.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlIndexID = value.SqlIndexID;
				}
				_sqlIndex = value;
			}
		}
		
		protected BLL.Specifications.SqlTable _sqlTable = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlTable SqlTable
		{
			get
			{
				return _sqlTable;
			}
			set
			{
				if (value != null)
				{
					_sqlTableName = value.SqlTableName;
					if (_sqlTable != null && _sqlTable.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlTableID = value.SqlTableID;
				}
				_sqlTable = value;
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
				return "SqlExtendedPropertyID";
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
				return SqlExtendedPropertyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlExtendedPropertyID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new SqlExtendedProperty();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlExtendedProperty();
				ForwardInstance.SqlExtendedPropertyID = SqlExtendedPropertyID;
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
		/// <param name="inputSqlExtendedProperty">The sqlextendedproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlExtendedProperty inputSqlExtendedProperty)
		{
			if (SqlExtendedPropertyName.GetString() != inputSqlExtendedProperty.SqlExtendedPropertyName.GetString()) return false;
			if (SqlValue.GetString() != inputSqlExtendedProperty.SqlValue.GetString()) return false;
			if (SqlDatabaseID.GetGuid() != inputSqlExtendedProperty.SqlDatabaseID.GetGuid()) return false;
			if (SqlTableID.GetGuid() != inputSqlExtendedProperty.SqlTableID.GetGuid()) return false;
			if (SqlColumnID.GetGuid() != inputSqlExtendedProperty.SqlColumnID.GetGuid()) return false;
			if (SqlIndexID.GetGuid() != inputSqlExtendedProperty.SqlIndexID.GetGuid()) return false;
			if (SqlForeignKeyID.GetGuid() != inputSqlExtendedProperty.SqlForeignKeyID.GetGuid()) return false;
			if (Urn.GetString() != inputSqlExtendedProperty.Urn.GetString()) return false;
			if (State.GetString() != inputSqlExtendedProperty.State.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlExtendedProperty">The sqlextendedproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlExtendedProperty inputSqlExtendedProperty)
		{
			if (inputSqlExtendedProperty == null) return true;
			if (inputSqlExtendedProperty.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlExtendedProperty.SqlExtendedPropertyName)) return false;
			if (!String.IsNullOrEmpty(inputSqlExtendedProperty.SqlValue)) return false;
			if (SqlDatabaseID != inputSqlExtendedProperty.SqlDatabaseID) return false;
			if (SqlTableID != inputSqlExtendedProperty.SqlTableID) return false;
			if (SqlColumnID != inputSqlExtendedProperty.SqlColumnID) return false;
			if (SqlIndexID != inputSqlExtendedProperty.SqlIndexID) return false;
			if (SqlForeignKeyID != inputSqlExtendedProperty.SqlForeignKeyID) return false;
			if (!String.IsNullOrEmpty(inputSqlExtendedProperty.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlExtendedProperty.State)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlExtendedProperty">The sqlextendedproperty to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlExtendedProperty inputSqlExtendedProperty)
		{
			SqlExtendedPropertyName = inputSqlExtendedProperty.SqlExtendedPropertyName;
			SqlValue = inputSqlExtendedProperty.SqlValue;
			SqlDatabaseID = inputSqlExtendedProperty.SqlDatabaseID;
			SqlTableID = inputSqlExtendedProperty.SqlTableID;
			SqlColumnID = inputSqlExtendedProperty.SqlColumnID;
			SqlIndexID = inputSqlExtendedProperty.SqlIndexID;
			SqlForeignKeyID = inputSqlExtendedProperty.SqlForeignKeyID;
			Urn = inputSqlExtendedProperty.Urn;
			State = inputSqlExtendedProperty.State;
			
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
				SqlExtendedPropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlExtendedPropertyID == Guid.Empty)
				{
					SqlExtendedPropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlExtendedPropertyID;
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
			SqlColumn = null;
			SqlForeignKey = null;
			SqlDatabase = null;
			SqlIndex = null;
			SqlTable = null;
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
					ReverseInstance = new SqlExtendedProperty();
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
			newItem.ItemID = SqlExtendedPropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlExtendedProperty GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlExtendedProperty forwardItem = new SqlExtendedProperty();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlExtendedPropertyID = SqlExtendedPropertyID;
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
				if (modelContext is SqlExtendedProperty)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlDatabase)
				{
					solutionContext.NeedsSample = false;
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlExtendedPropertyList.Count > 0)
					{
						return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
					}
				}
				#region protected
				else if (solutionContext.IsSampleMode == true && modelContext is SqlIndex)
				{
					SqlIndex parent = modelContext as SqlIndex;
					if (parent.SqlExtendedPropertyList.Count > 0)
					{
						return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlForeignKey)
				{
					SqlForeignKey parent = modelContext as SqlForeignKey;
					if (parent.SqlExtendedPropertyList.Count > 0)
					{
						return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlTable)
				{
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlExtendedPropertyList.Count > 0)
					{
						return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent.SqlExtendedPropertyList.Count > 0)
					{
						return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent.SqlExtendedPropertyList.Count > 0)
					{
						return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
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
				if (parent.SqlExtendedPropertyList.Count > 0)
				{
					return parent.SqlExtendedPropertyList[DataHelper.GetRandomInt(0, parent.SqlExtendedPropertyList.Count - 1)];
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
				if (nodeContext is SqlDatabase)
				{
					return (nodeContext as SqlDatabase).SqlExtendedPropertyList;
				}
				
				#region protected
				if (nodeContext is SqlColumn)
				{
					return (nodeContext as SqlColumn).SqlExtendedPropertyList;
				}
				else if (nodeContext is SqlIndex)
				{
					return (nodeContext as SqlIndex).SqlExtendedPropertyList;
				}
				else if (nodeContext is SqlForeignKey)
				{
					return (nodeContext as SqlForeignKey).SqlExtendedPropertyList;
				}
				else if (nodeContext is SqlTable)
				{
					return (nodeContext as SqlTable).SqlExtendedPropertyList;
				}
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						return (nodeContext as DatabaseSource).SpecDatabase.SqlExtendedPropertyList;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						return (nodeContext as Project).OutputDatabase.SqlExtendedPropertyList;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlIndex> indexes = new EnterpriseDataObjectList<SqlIndex>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							return source.SpecDatabase.SqlExtendedPropertyList;
						}
					}
					return indexes;
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
			return SqlDatabase;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlExtendedProperty instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlExtendedProperty instance to an xml file.</summary>
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
		public SqlExtendedProperty(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlExtendedProperty instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlExtendedProperty(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlExtendedProperty instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlExtendedPropertyID">The input value for SqlExtendedPropertyID.</param>
		///--------------------------------------------------------------------------------
		public SqlExtendedProperty(Guid sqlExtendedPropertyID)
		{
			SqlExtendedPropertyID = sqlExtendedPropertyID;
		}
		#endregion "Constructors"
	}
}