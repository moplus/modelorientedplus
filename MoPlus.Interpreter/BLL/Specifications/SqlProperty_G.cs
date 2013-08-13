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
	/// specific SqlProperty instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlProperty")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlProperty : BusinessObjectBase
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
			
			error = GetValidationError("SqlPropertyName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlType");
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
			error = GetValidationError("SqlIndexedColumnID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlForeignKeyID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlForeignKeyColumnID");
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
				case "_sqlPropertyName":
				case "SqlPropertyName":
					error = ValidateSqlPropertyName();
					break;
				case "_sqlType":
				case "SqlType":
					error = ValidateSqlType();
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
				case "_sqlIndexedColumnID":
				case "SqlIndexedColumnID":
					error = ValidateSqlIndexedColumnID();
					break;
				case "_sqlForeignKeyID":
				case "SqlForeignKeyID":
					error = ValidateSqlForeignKeyID();
					break;
				case "_sqlForeignKeyColumnID":
				case "SqlForeignKeyColumnID":
					error = ValidateSqlForeignKeyColumnID();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlPropertyName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlPropertyName()
		{
			if (!Regex.IsMatch(SqlPropertyName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlPropertyName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SqlType and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlType()
		{
			if (String.IsNullOrEmpty(SqlType))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "SqlType");
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
		/// <summary>This method validates SqlIndexedColumnID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlIndexedColumnID()
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
		/// <summary>This method validates SqlForeignKeyColumnID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlForeignKeyColumnID()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private SqlProperty _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlProperty ForwardInstance
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
		
		private SqlProperty _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlProperty ReverseInstance
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
				return SqlPropertyID;
			}
			set
			{
				SqlPropertyID = value;
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
				return SqlPropertyName;
			}
			set
			{
				SqlPropertyName = value;
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
				return SourceSqlProperty.SqlPropertyName;
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
						_displayName = SqlDatabaseName + "." + SqlPropertyName;
					}
					else
					{
						_displayName = SqlPropertyName;
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
						_defaultSourceName = SqlDatabase.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlProperty.SqlPropertyName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlProperty.SqlPropertyName;
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
		public SqlProperty SourceSqlProperty
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
		/// <summary>This property gets/sets the OldSqlPropertyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlPropertyID { get; set; }
		
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
		/// <summary>This property gets/sets the OldSqlIndexedColumnID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlIndexedColumnID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlForeignKeyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlForeignKeyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlForeignKeyColumnID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldSqlForeignKeyColumnID { get; set; }
		
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
		
		protected Guid _sqlPropertyID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlPropertyID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlPropertyID
		{
			get
			{
				return _sqlPropertyID;
			}
			set
			{
				if (_sqlPropertyID != value)
				{
					_sqlPropertyID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlPropertyID");
				}
			}
		}
		
		protected string _sqlPropertyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlPropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlPropertyName
		{
			get
			{
				return _sqlPropertyName;
			}
			set
			{
				if (_sqlPropertyName != value)
				{
					_sqlPropertyName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlPropertyName");
				}
			}
		}
		
		protected string _sqlType = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlType.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlType
		{
			get
			{
				return _sqlType;
			}
			set
			{
				if (_sqlType != value)
				{
					_sqlType = value;
					_isModified = true;
					base.OnPropertyChanged("SqlType");
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
		
		protected Guid? _sqlIndexedColumnID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlIndexedColumnID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? SqlIndexedColumnID
		{
			get
			{
				return _sqlIndexedColumnID;
			}
			set
			{
				if (_sqlIndexedColumnID != value)
				{
					_sqlIndexedColumnID = value;
					_isModified = true;
					base.OnPropertyChanged("SqlIndexedColumnID");
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
		
		protected Guid? _sqlForeignKeyColumnID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlForeignKeyColumnID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? SqlForeignKeyColumnID
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
		
		protected string _sqlForeignKeyColumnName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlForeignKeyColumnName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlForeignKeyColumnName
		{
			get
			{
				return _sqlForeignKeyColumnName;
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
		
		protected string _sqlIndexedColumnName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SqlIndexedColumnName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SqlIndexedColumnName
		{
			get
			{
				return _sqlIndexedColumnName;
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
		
		protected BLL.Specifications.SqlForeignKeyColumn _sqlForeignKeyColumn = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlForeignKeyColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlForeignKeyColumn SqlForeignKeyColumn
		{
			get
			{
				return _sqlForeignKeyColumn;
			}
			set
			{
				if (value != null)
				{
					_sqlForeignKeyColumnName = value.SqlForeignKeyColumnName;
					if (_sqlForeignKeyColumn != null && _sqlForeignKeyColumn.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlForeignKeyColumnID = value.SqlForeignKeyColumnID;
				}
				_sqlForeignKeyColumn = value;
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
		
		protected BLL.Specifications.SqlIndexedColumn _sqlIndexedColumn = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the SqlIndexedColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.SqlIndexedColumn SqlIndexedColumn
		{
			get
			{
				return _sqlIndexedColumn;
			}
			set
			{
				if (value != null)
				{
					_sqlIndexedColumnName = value.SqlIndexedColumnName;
					if (_sqlIndexedColumn != null && _sqlIndexedColumn.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					SqlIndexedColumnID = value.SqlIndexedColumnID;
				}
				_sqlIndexedColumn = value;
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
				return "SqlPropertyID";
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
				return SqlPropertyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlPropertyID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new SqlProperty();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlProperty();
				ForwardInstance.SqlPropertyID = SqlPropertyID;
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
		/// <param name="inputSqlProperty">The sqlproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlProperty inputSqlProperty)
		{
			if (SqlPropertyName.GetString() != inputSqlProperty.SqlPropertyName.GetString()) return false;
			if (SqlType.GetString() != inputSqlProperty.SqlType.GetString()) return false;
			if (SqlValue.GetString() != inputSqlProperty.SqlValue.GetString()) return false;
			if (SqlDatabaseID.GetGuid() != inputSqlProperty.SqlDatabaseID.GetGuid()) return false;
			if (SqlTableID.GetGuid() != inputSqlProperty.SqlTableID.GetGuid()) return false;
			if (SqlColumnID.GetGuid() != inputSqlProperty.SqlColumnID.GetGuid()) return false;
			if (SqlIndexID.GetGuid() != inputSqlProperty.SqlIndexID.GetGuid()) return false;
			if (SqlIndexedColumnID.GetGuid() != inputSqlProperty.SqlIndexedColumnID.GetGuid()) return false;
			if (SqlForeignKeyID.GetGuid() != inputSqlProperty.SqlForeignKeyID.GetGuid()) return false;
			if (SqlForeignKeyColumnID.GetGuid() != inputSqlProperty.SqlForeignKeyColumnID.GetGuid()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlProperty">The sqlproperty to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlProperty inputSqlProperty)
		{
			if (inputSqlProperty == null) return true;
			if (inputSqlProperty.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlProperty.SqlPropertyName)) return false;
			if (!String.IsNullOrEmpty(inputSqlProperty.SqlType)) return false;
			if (!String.IsNullOrEmpty(inputSqlProperty.SqlValue)) return false;
			if (SqlDatabaseID != inputSqlProperty.SqlDatabaseID) return false;
			if (SqlTableID != inputSqlProperty.SqlTableID) return false;
			if (SqlColumnID != inputSqlProperty.SqlColumnID) return false;
			if (SqlIndexID != inputSqlProperty.SqlIndexID) return false;
			if (SqlIndexedColumnID != inputSqlProperty.SqlIndexedColumnID) return false;
			if (SqlForeignKeyID != inputSqlProperty.SqlForeignKeyID) return false;
			if (SqlForeignKeyColumnID != inputSqlProperty.SqlForeignKeyColumnID) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlProperty">The sqlproperty to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlProperty inputSqlProperty)
		{
			SqlPropertyName = inputSqlProperty.SqlPropertyName;
			SqlType = inputSqlProperty.SqlType;
			SqlValue = inputSqlProperty.SqlValue;
			SqlDatabaseID = inputSqlProperty.SqlDatabaseID;
			SqlTableID = inputSqlProperty.SqlTableID;
			SqlColumnID = inputSqlProperty.SqlColumnID;
			SqlIndexID = inputSqlProperty.SqlIndexID;
			SqlIndexedColumnID = inputSqlProperty.SqlIndexedColumnID;
			SqlForeignKeyID = inputSqlProperty.SqlForeignKeyID;
			SqlForeignKeyColumnID = inputSqlProperty.SqlForeignKeyColumnID;
			
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
				SqlPropertyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlPropertyID == Guid.Empty)
				{
					SqlPropertyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlPropertyID;
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
			SqlDatabase = null;
			SqlForeignKey = null;
			SqlForeignKeyColumn = null;
			SqlIndex = null;
			SqlIndexedColumn = null;
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
					ReverseInstance = new SqlProperty();
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
			newItem.ItemID = SqlPropertyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlProperty GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlProperty forwardItem = new SqlProperty();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlPropertyID = SqlPropertyID;
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
				if (modelContext is SqlProperty)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlDatabase)
				{
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				#region protected
				else if (solutionContext.IsSampleMode == true && modelContext is SqlIndex)
				{
					SqlIndex parent = modelContext as SqlIndex;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlIndexedColumn)
				{
					SqlIndexedColumn parent = modelContext as SqlIndexedColumn;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlForeignKey)
				{
					SqlForeignKey parent = modelContext as SqlForeignKey;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlForeignKeyColumn)
				{
					SqlForeignKeyColumn parent = modelContext as SqlForeignKeyColumn;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlTable)
				{
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent.SqlPropertyList.Count > 0)
					{
						return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
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
				if (parent.SqlPropertyList.Count > 0)
				{
					return parent.SqlPropertyList[DataHelper.GetRandomInt(0, parent.SqlPropertyList.Count - 1)];
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
					return (nodeContext as SqlDatabase).SqlPropertyList;
				}
				
				#region protected
				else if (nodeContext is SqlColumn)
				{
					return (nodeContext as SqlColumn).SqlPropertyList;
				}
				else if (nodeContext is SqlIndex)
				{
					return (nodeContext as SqlIndex).SqlPropertyList;
				}
				else if (nodeContext is SqlIndexedColumn)
				{
					return (nodeContext as SqlIndexedColumn).SqlPropertyList;
				}
				else if (nodeContext is SqlForeignKey)
				{
					return (nodeContext as SqlForeignKey).SqlPropertyList;
				}
				else if (nodeContext is SqlForeignKeyColumn)
				{
					return (nodeContext as SqlForeignKeyColumn).SqlPropertyList;
				}
				else if (nodeContext is SqlTable)
				{
					return (nodeContext as SqlTable).SqlPropertyList;
				}
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						return (nodeContext as DatabaseSource).SpecDatabase.SqlPropertyList;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						return (nodeContext as Project).OutputDatabase.SqlPropertyList;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlIndex> indexes = new EnterpriseDataObjectList<SqlIndex>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							return source.SpecDatabase.SqlPropertyList;
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
		/// <summary>This method gets the SqlProperty instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlProperty instance to an xml file.</summary>
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
		public SqlProperty(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlProperty instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlProperty(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlProperty instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlPropertyID">The input value for SqlPropertyID.</param>
		///--------------------------------------------------------------------------------
		public SqlProperty(Guid sqlPropertyID)
		{
			SqlPropertyID = sqlPropertyID;
		}
		#endregion "Constructors"
	}
}