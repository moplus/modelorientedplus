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
	/// specific SqlTable instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlTable")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlTable : BusinessObjectBase
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
			
			error = GetValidationError("SqlTableName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DbID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlDatabaseID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Owner");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Schema");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("FileGroup");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("CreateDate");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DateLastModified");
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
				case "_sqlTableName":
				case "SqlTableName":
					error = ValidateSqlTableName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlDatabaseID":
				case "SqlDatabaseID":
					error = ValidateSqlDatabaseID();
					break;
				case "_owner":
				case "Owner":
					error = ValidateOwner();
					break;
				case "_schema":
				case "Schema":
					error = ValidateSchema();
					break;
				case "_fileGroup":
				case "FileGroup":
					error = ValidateFileGroup();
					break;
				case "_createDate":
				case "CreateDate":
					error = ValidateCreateDate();
					break;
				case "_dateLastModified":
				case "DateLastModified":
					error = ValidateDateLastModified();
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
		/// <summary>This method validates SqlTableName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlTableName()
		{
			if (!Regex.IsMatch(SqlTableName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlTableName");
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
		/// <summary>This method validates Owner and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateOwner()
		{
			if (String.IsNullOrEmpty(Owner))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Owner");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Schema and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSchema()
		{
			if (String.IsNullOrEmpty(Schema))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Schema");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates FileGroup and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateFileGroup()
		{
			if (String.IsNullOrEmpty(FileGroup))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "FileGroup");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates CreateDate and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateCreateDate()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DateLastModified and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDateLastModified()
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
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Description and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDescription()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private SqlTable _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlTable ForwardInstance
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
		
		private SqlTable _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlTable ReverseInstance
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
				return SqlTableID;
			}
			set
			{
				SqlTableID = value;
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
				return SqlTableName;
			}
			set
			{
				SqlTableName = value;
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
				return SourceSqlTable.SqlTableName;
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
						_displayName = SqlDatabaseName + "." + SqlTableName;
					}
					else
					{
						_displayName = SqlTableName;
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
						_defaultSourceName = SqlDatabase.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlTable.SqlTableName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlTable.SqlTableName;
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
		public SqlTable SourceSqlTable
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
		/// <summary>This property gets/sets the OldSqlTableID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlTableID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlDatabaseID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlDatabaseID { get; set; }
		
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
		
		protected Guid _sqlTableID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlTableID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlTableID
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
		
		protected string _sqlTableName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlTableName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlTableName
		{
			get
			{
				return _sqlTableName;
			}
			set
			{
				if (_sqlTableName != value)
				{
					_sqlTableName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlTableName");
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
		
		protected string _owner = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Owner.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Owner
		{
			get
			{
				return _owner;
			}
			set
			{
				if (_owner != value)
				{
					_owner = value;
					_isModified = true;
					base.OnPropertyChanged("Owner");
				}
			}
		}
		
		protected string _schema = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Schema.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Schema
		{
			get
			{
				return _schema;
			}
			set
			{
				if (_schema != value)
				{
					_schema = value;
					_isModified = true;
					base.OnPropertyChanged("Schema");
				}
			}
		}
		
		protected string _fileGroup = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FileGroup.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string FileGroup
		{
			get
			{
				return _fileGroup;
			}
			set
			{
				if (_fileGroup != value)
				{
					_fileGroup = value;
					_isModified = true;
					base.OnPropertyChanged("FileGroup");
				}
			}
		}
		
		protected DateTime? _createDate = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CreateDate.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual DateTime? CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				if (_createDate != value)
				{
					_createDate = value;
					_isModified = true;
					base.OnPropertyChanged("CreateDate");
				}
			}
		}
		
		protected DateTime? _dateLastModified = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DateLastModified.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual DateTime? DateLastModified
		{
			get
			{
				return _dateLastModified;
			}
			set
			{
				if (_dateLastModified != value)
				{
					_dateLastModified = value;
					_isModified = true;
					base.OnPropertyChanged("DateLastModified");
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlColumn> _sqlColumnList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlColumn> SqlColumnList
		{
			get
			{
				if (_sqlColumnList == null)
				{
					_sqlColumnList = new EnterpriseDataObjectList<BLL.Specifications.SqlColumn>();
				}
				return _sqlColumnList;
			}
			set
			{
				if (_sqlColumnList == null || _sqlColumnList.Equals(value) == false)
				{
					_sqlColumnList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlColumnList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlColumn), ElementName = "SqlColumn")]
		[DataMember(Name = "SqlColumnList")]
		[DataArrayItem(ElementName = "SqlColumnList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlColumn> _S_SqlColumnList
		{
			get
			{
				return _sqlColumnList;
			}
			set
			{
				_sqlColumnList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlExtendedProperty> _sqlExtendedPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlExtendedProperty> SqlExtendedPropertyList
		{
			get
			{
				if (_sqlExtendedPropertyList == null)
				{
					_sqlExtendedPropertyList = new EnterpriseDataObjectList<BLL.Specifications.SqlExtendedProperty>();
				}
				return _sqlExtendedPropertyList;
			}
			set
			{
				if (_sqlExtendedPropertyList == null || _sqlExtendedPropertyList.Equals(value) == false)
				{
					_sqlExtendedPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlExtendedPropertyList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlExtendedProperty), ElementName = "SqlExtendedProperty")]
		[DataMember(Name = "SqlExtendedPropertyList")]
		[DataArrayItem(ElementName = "SqlExtendedPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlExtendedProperty> _S_SqlExtendedPropertyList
		{
			get
			{
				return _sqlExtendedPropertyList;
			}
			set
			{
				_sqlExtendedPropertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlForeignKey> _sqlForeignKeyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlForeignKey> SqlForeignKeyList
		{
			get
			{
				if (_sqlForeignKeyList == null)
				{
					_sqlForeignKeyList = new EnterpriseDataObjectList<BLL.Specifications.SqlForeignKey>();
				}
				return _sqlForeignKeyList;
			}
			set
			{
				if (_sqlForeignKeyList == null || _sqlForeignKeyList.Equals(value) == false)
				{
					_sqlForeignKeyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlForeignKeyList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlForeignKey), ElementName = "SqlForeignKey")]
		[DataMember(Name = "SqlForeignKeyList")]
		[DataArrayItem(ElementName = "SqlForeignKeyList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlForeignKey> _S_SqlForeignKeyList
		{
			get
			{
				return _sqlForeignKeyList;
			}
			set
			{
				_sqlForeignKeyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlIndex> _sqlIndexList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlIndex> SqlIndexList
		{
			get
			{
				if (_sqlIndexList == null)
				{
					_sqlIndexList = new EnterpriseDataObjectList<BLL.Specifications.SqlIndex>();
				}
				return _sqlIndexList;
			}
			set
			{
				if (_sqlIndexList == null || _sqlIndexList.Equals(value) == false)
				{
					_sqlIndexList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlIndexList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlIndex), ElementName = "SqlIndex")]
		[DataMember(Name = "SqlIndexList")]
		[DataArrayItem(ElementName = "SqlIndexList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlIndex> _S_SqlIndexList
		{
			get
			{
				return _sqlIndexList;
			}
			set
			{
				_sqlIndexList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _sqlPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlTable.</summary>
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
		
		///-------------------------------------------------------------------------------
		/// <summary>This property gets the primary key properties.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyProperties
		{
			get
			{
				return "SqlTableID";
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
				return SqlTableID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlTableID = primaryKeyValues[0].GetGuid();
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
				if (_sqlColumnList != null && _sqlColumnList.IsModified == true) return true;
				if (_sqlExtendedPropertyList != null && _sqlExtendedPropertyList.IsModified == true) return true;
				if (_sqlForeignKeyList != null && _sqlForeignKeyList.IsModified == true) return true;
				if (_sqlIndexList != null && _sqlIndexList.IsModified == true) return true;
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
				ReverseInstance = new SqlTable();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlTable();
				ForwardInstance.SqlTableID = SqlTableID;
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
			foreach (SqlColumn sqlColumn in SqlColumnList)
			{
				sqlColumn.AddItemToUsedTags(usedTags);
			}
			foreach (SqlExtendedProperty sqlExtendedProperty in SqlExtendedPropertyList)
			{
				sqlExtendedProperty.AddItemToUsedTags(usedTags);
			}
			foreach (SqlForeignKey sqlForeignKey in SqlForeignKeyList)
			{
				sqlForeignKey.AddItemToUsedTags(usedTags);
			}
			foreach (SqlIndex sqlIndex in SqlIndexList)
			{
				sqlIndex.AddItemToUsedTags(usedTags);
			}
			foreach (SqlProperty sqlProperty in SqlPropertyList)
			{
				sqlProperty.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputSqlTable">The sqltable to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlTable inputSqlTable)
		{
			if (SqlTableName.GetString() != inputSqlTable.SqlTableName.GetString()) return false;
			if (DbID.GetInt() != inputSqlTable.DbID.GetInt()) return false;
			if (SqlDatabaseID.GetGuid() != inputSqlTable.SqlDatabaseID.GetGuid()) return false;
			if (Owner.GetString() != inputSqlTable.Owner.GetString()) return false;
			if (Schema.GetString() != inputSqlTable.Schema.GetString()) return false;
			if (FileGroup.GetString() != inputSqlTable.FileGroup.GetString()) return false;
			if (CreateDate.GetDateTime() != inputSqlTable.CreateDate.GetDateTime()) return false;
			if (DateLastModified.GetDateTime() != inputSqlTable.DateLastModified.GetDateTime()) return false;
			if (Urn.GetString() != inputSqlTable.Urn.GetString()) return false;
			if (State.GetString() != inputSqlTable.State.GetString()) return false;
			if (Description.GetString() != inputSqlTable.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlTable">The sqltable to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlTable inputSqlTable)
		{
			if (inputSqlTable == null) return true;
			if (inputSqlTable.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.SqlTableName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlDatabaseID != inputSqlTable.SqlDatabaseID) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.Owner)) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.Schema)) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.FileGroup)) return false;
			if (CreateDate != inputSqlTable.CreateDate) return false;
			if (DateLastModified != inputSqlTable.DateLastModified) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlTable.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlTable">The sqltable to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlTable inputSqlTable)
		{
			SqlTableName = inputSqlTable.SqlTableName;
			DbID = inputSqlTable.DbID;
			SqlDatabaseID = inputSqlTable.SqlDatabaseID;
			Owner = inputSqlTable.Owner;
			Schema = inputSqlTable.Schema;
			FileGroup = inputSqlTable.FileGroup;
			CreateDate = inputSqlTable.CreateDate;
			DateLastModified = inputSqlTable.DateLastModified;
			Urn = inputSqlTable.Urn;
			State = inputSqlTable.State;
			Description = inputSqlTable.Description;
			
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
				SqlTableID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlTableID == Guid.Empty)
				{
					SqlTableID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlTableID;
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
			SqlDatabase = null;
			Solution = null;
			if (_sqlColumnList != null)
			{
				foreach (SqlColumn item in SqlColumnList)
				{
					item.Dispose();
				}
				SqlColumnList.Clear();
				SqlColumnList = null;
			}
			if (_sqlExtendedPropertyList != null)
			{
				foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
				{
					item.Dispose();
				}
				SqlExtendedPropertyList.Clear();
				SqlExtendedPropertyList = null;
			}
			if (_sqlForeignKeyList != null)
			{
				foreach (SqlForeignKey item in SqlForeignKeyList)
				{
					item.Dispose();
				}
				SqlForeignKeyList.Clear();
				SqlForeignKeyList = null;
			}
			if (_sqlIndexList != null)
			{
				foreach (SqlIndex item in SqlIndexList)
				{
					item.Dispose();
				}
				SqlIndexList.Clear();
				SqlIndexList = null;
			}
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
					ReverseInstance = new SqlTable();
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
			newItem.ItemID = SqlTableID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlTable GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlTable forwardItem = new SqlTable();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlTableID = SqlTableID;
			}
			foreach (SqlColumn item in SqlColumnList)
			{
				item.SqlTable = this;
				SqlColumn forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlColumnList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
			{
				item.SqlTable = this;
				SqlExtendedProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlExtendedPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlForeignKey item in SqlForeignKeyList)
			{
				item.SqlTable = this;
				SqlForeignKey forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlForeignKeyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlIndex item in SqlIndexList)
			{
				item.SqlTable = this;
				SqlIndex forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlIndexList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlTable = this;
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
				if (modelContext is SqlTable)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlDatabase)
				{
					solutionContext.NeedsSample = false;
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						return parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlIndex)
				{
					return (modelContext as SqlIndex).SqlTable;
				}
				else if (modelContext is SqlIndexedColumn)
				{
					return (modelContext as SqlIndexedColumn).SqlIndex.SqlTable;
				}
				else if (modelContext is SqlForeignKey)
				{
					return (modelContext as SqlForeignKey).SqlTable;
				}
				else if (modelContext is SqlForeignKeyColumn)
				{
					return (modelContext as SqlForeignKeyColumn).SqlForeignKey.SqlTable;
				}
				else if (modelContext is SqlProperty)
				{
					if ((modelContext as SqlProperty).SqlTable != null)
					{
						return (modelContext as SqlProperty).SqlTable;
					}
				}
				else if (modelContext is SqlExtendedProperty)
				{
					if ((modelContext as SqlExtendedProperty).SqlTable != null)
					{
						return (modelContext as SqlExtendedProperty).SqlTable;
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent != null && parent.SqlTableList.Count > 0)
					{
						return parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent != null && parent.SqlTableList.Count > 0)
					{
						return parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
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
				if (parent != null && parent.SqlTableList.Count > 0)
				{
					return parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
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
					return (nodeContext as SqlDatabase).SqlTableList;
				}
				
				#region protected
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						return (nodeContext as DatabaseSource).SpecDatabase.SqlTableList;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						return (nodeContext as Project).OutputDatabase.SqlTableList;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlTable> tables = new EnterpriseDataObjectList<SqlTable>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlTable table in source.SpecDatabase.SqlTableList)
							{
								tables.Add(table);
							}
						}
					}
					return tables;
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
		/// <summary>This method gets the SqlTable instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlTable instance to an xml file.</summary>
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
			if (_sqlColumnList != null) _sqlColumnList.ResetLoaded(isLoaded);
			if (_sqlExtendedPropertyList != null) _sqlExtendedPropertyList.ResetLoaded(isLoaded);
			if (_sqlForeignKeyList != null) _sqlForeignKeyList.ResetLoaded(isLoaded);
			if (_sqlIndexList != null) _sqlIndexList.ResetLoaded(isLoaded);
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
			if (_sqlColumnList != null) _sqlColumnList.ResetModified(isModified);
			if (_sqlExtendedPropertyList != null) _sqlExtendedPropertyList.ResetModified(isModified);
			if (_sqlForeignKeyList != null) _sqlForeignKeyList.ResetModified(isModified);
			if (_sqlIndexList != null) _sqlIndexList.ResetModified(isModified);
			if (_sqlPropertyList != null) _sqlPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlTable(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlTable instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlTable(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlTable instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlTableID">The input value for SqlTableID.</param>
		///--------------------------------------------------------------------------------
		public SqlTable(Guid sqlTableID)
		{
			SqlTableID = sqlTableID;
		}
		#endregion "Constructors"
	}
}