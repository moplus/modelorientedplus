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
	/// specific SqlForeignKey instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlForeignKey")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlForeignKey : BusinessObjectBase
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
			
			error = GetValidationError("SqlForeignKeyName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DbID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlTableID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedKey");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedTable");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ReferencedTableSchema");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsChecked");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsSystemNamed");
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
				case "_sqlForeignKeyName":
				case "SqlForeignKeyName":
					error = ValidateSqlForeignKeyName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlTableID":
				case "SqlTableID":
					error = ValidateSqlTableID();
					break;
				case "_referencedKey":
				case "ReferencedKey":
					error = ValidateReferencedKey();
					break;
				case "_referencedTable":
				case "ReferencedTable":
					error = ValidateReferencedTable();
					break;
				case "_referencedTableSchema":
				case "ReferencedTableSchema":
					error = ValidateReferencedTableSchema();
					break;
				case "_isChecked":
				case "IsChecked":
					error = ValidateIsChecked();
					break;
				case "_isSystemNamed":
				case "IsSystemNamed":
					error = ValidateIsSystemNamed();
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
		/// <summary>This method validates SqlForeignKeyName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlForeignKeyName()
		{
			if (!Regex.IsMatch(SqlForeignKeyName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlForeignKeyName");
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
		/// <summary>This method validates SqlTableID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlTableID()
		{
			if (SqlTableID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "SqlTableID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ReferencedKey and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedKey()
		{
			if (String.IsNullOrEmpty(ReferencedKey))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "ReferencedKey");
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
		/// <summary>This method validates ReferencedTableSchema and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateReferencedTableSchema()
		{
			if (String.IsNullOrEmpty(ReferencedTableSchema))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "ReferencedTableSchema");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsChecked and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsChecked()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsSystemNamed and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsSystemNamed()
		{
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
		
		private SqlForeignKey _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlForeignKey ForwardInstance
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
		
		private SqlForeignKey _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlForeignKey ReverseInstance
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
				return SqlForeignKeyID;
			}
			set
			{
				SqlForeignKeyID = value;
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
				return SqlForeignKeyName;
			}
			set
			{
				SqlForeignKeyName = value;
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
				return SourceSqlForeignKey.SqlForeignKeyName;
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
					if (!String.IsNullOrEmpty(SqlTableName))
					{
						_displayName = SqlTableName + "." + SqlForeignKeyName;
					}
					else
					{
						_displayName = SqlForeignKeyName;
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
					if (SqlTable != null)
					{
						_defaultSourceName = SqlTable.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlForeignKey.SqlForeignKeyName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlForeignKey.SqlForeignKeyName;
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
		public SqlForeignKey SourceSqlForeignKey
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
		/// <summary>This property gets/sets the OldSqlForeignKeyID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlForeignKeyID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlTableID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlTableID { get; set; }
		
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
		
		protected string _sqlForeignKeyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlForeignKeyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlForeignKeyName
		{
			get
			{
				return _sqlForeignKeyName;
			}
			set
			{
				if (_sqlForeignKeyName != value)
				{
					_sqlForeignKeyName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlForeignKeyName");
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
		
		protected string _referencedKey = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ReferencedKey
		{
			get
			{
				return _referencedKey;
			}
			set
			{
				if (_referencedKey != value)
				{
					_referencedKey = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedKey");
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
		
		protected string _referencedTableSchema = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ReferencedTableSchema.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string ReferencedTableSchema
		{
			get
			{
				return _referencedTableSchema;
			}
			set
			{
				if (_referencedTableSchema != value)
				{
					_referencedTableSchema = value;
					_isModified = true;
					base.OnPropertyChanged("ReferencedTableSchema");
				}
			}
		}
		
		protected bool? _isChecked = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsChecked.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsChecked
		{
			get
			{
				return _isChecked;
			}
			set
			{
				if (_isChecked != value)
				{
					_isChecked = value;
					_isModified = true;
					base.OnPropertyChanged("IsChecked");
				}
			}
		}
		
		protected bool? _isSystemNamed = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsSystemNamed.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsSystemNamed
		{
			get
			{
				return _isSystemNamed;
			}
			set
			{
				if (_isSystemNamed != value)
				{
					_isSystemNamed = value;
					_isModified = true;
					base.OnPropertyChanged("IsSystemNamed");
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlExtendedProperty> _sqlExtendedPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlForeignKey.</summary>
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlForeignKeyColumn> _sqlForeignKeyColumnList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlForeignKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlForeignKeyColumn> SqlForeignKeyColumnList
		{
			get
			{
				if (_sqlForeignKeyColumnList == null)
				{
					_sqlForeignKeyColumnList = new EnterpriseDataObjectList<BLL.Specifications.SqlForeignKeyColumn>();
				}
				return _sqlForeignKeyColumnList;
			}
			set
			{
				if (_sqlForeignKeyColumnList == null || _sqlForeignKeyColumnList.Equals(value) == false)
				{
					_sqlForeignKeyColumnList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlForeignKeyColumnList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlForeignKeyColumn), ElementName = "SqlForeignKeyColumn")]
		[DataMember(Name = "SqlForeignKeyColumnList")]
		[DataArrayItem(ElementName = "SqlForeignKeyColumnList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlForeignKeyColumn> _S_SqlForeignKeyColumnList
		{
			get
			{
				return _sqlForeignKeyColumnList;
			}
			set
			{
				_sqlForeignKeyColumnList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _sqlPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlForeignKey.</summary>
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
				return "SqlForeignKeyID";
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
				return SqlForeignKeyID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlForeignKeyID = primaryKeyValues[0].GetGuid();
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
				if (_sqlExtendedPropertyList != null && _sqlExtendedPropertyList.IsModified == true) return true;
				if (_sqlForeignKeyColumnList != null && _sqlForeignKeyColumnList.IsModified == true) return true;
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
				ReverseInstance = new SqlForeignKey();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlForeignKey();
				ForwardInstance.SqlForeignKeyID = SqlForeignKeyID;
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
			foreach (SqlExtendedProperty sqlExtendedProperty in SqlExtendedPropertyList)
			{
				sqlExtendedProperty.AddItemToUsedTags(usedTags);
			}
			foreach (SqlForeignKeyColumn sqlForeignKeyColumn in SqlForeignKeyColumnList)
			{
				sqlForeignKeyColumn.AddItemToUsedTags(usedTags);
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
		/// <param name="inputSqlForeignKey">The sqlforeignkey to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlForeignKey inputSqlForeignKey)
		{
			if (SqlForeignKeyName.GetString() != inputSqlForeignKey.SqlForeignKeyName.GetString()) return false;
			if (DbID.GetInt() != inputSqlForeignKey.DbID.GetInt()) return false;
			if (SqlTableID.GetGuid() != inputSqlForeignKey.SqlTableID.GetGuid()) return false;
			if (ReferencedKey.GetString() != inputSqlForeignKey.ReferencedKey.GetString()) return false;
			if (ReferencedTable.GetString() != inputSqlForeignKey.ReferencedTable.GetString()) return false;
			if (ReferencedTableSchema.GetString() != inputSqlForeignKey.ReferencedTableSchema.GetString()) return false;
			if (IsChecked.GetBool() != inputSqlForeignKey.IsChecked.GetBool()) return false;
			if (IsSystemNamed.GetBool() != inputSqlForeignKey.IsSystemNamed.GetBool()) return false;
			if (CreateDate.GetDateTime() != inputSqlForeignKey.CreateDate.GetDateTime()) return false;
			if (DateLastModified.GetDateTime() != inputSqlForeignKey.DateLastModified.GetDateTime()) return false;
			if (Urn.GetString() != inputSqlForeignKey.Urn.GetString()) return false;
			if (State.GetString() != inputSqlForeignKey.State.GetString()) return false;
			if (Description.GetString() != inputSqlForeignKey.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlForeignKey">The sqlforeignkey to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlForeignKey inputSqlForeignKey)
		{
			if (inputSqlForeignKey == null) return true;
			if (inputSqlForeignKey.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.SqlForeignKeyName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlTableID != inputSqlForeignKey.SqlTableID) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.ReferencedKey)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.ReferencedTable)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.ReferencedTableSchema)) return false;
			if (IsChecked != inputSqlForeignKey.IsChecked) return false;
			if (IsSystemNamed != inputSqlForeignKey.IsSystemNamed) return false;
			if (CreateDate != inputSqlForeignKey.CreateDate) return false;
			if (DateLastModified != inputSqlForeignKey.DateLastModified) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlForeignKey.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlForeignKey">The sqlforeignkey to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlForeignKey inputSqlForeignKey)
		{
			SqlForeignKeyName = inputSqlForeignKey.SqlForeignKeyName;
			DbID = inputSqlForeignKey.DbID;
			SqlTableID = inputSqlForeignKey.SqlTableID;
			ReferencedKey = inputSqlForeignKey.ReferencedKey;
			ReferencedTable = inputSqlForeignKey.ReferencedTable;
			ReferencedTableSchema = inputSqlForeignKey.ReferencedTableSchema;
			IsChecked = inputSqlForeignKey.IsChecked;
			IsSystemNamed = inputSqlForeignKey.IsSystemNamed;
			CreateDate = inputSqlForeignKey.CreateDate;
			DateLastModified = inputSqlForeignKey.DateLastModified;
			Urn = inputSqlForeignKey.Urn;
			State = inputSqlForeignKey.State;
			Description = inputSqlForeignKey.Description;
			
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
				SqlForeignKeyID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlForeignKeyID == Guid.Empty)
				{
					SqlForeignKeyID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlForeignKeyID;
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
			SqlTable = null;
			Solution = null;
			if (_sqlExtendedPropertyList != null)
			{
				foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
				{
					item.Dispose();
				}
				SqlExtendedPropertyList.Clear();
				SqlExtendedPropertyList = null;
			}
			if (_sqlForeignKeyColumnList != null)
			{
				foreach (SqlForeignKeyColumn item in SqlForeignKeyColumnList)
				{
					item.Dispose();
				}
				SqlForeignKeyColumnList.Clear();
				SqlForeignKeyColumnList = null;
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
					ReverseInstance = new SqlForeignKey();
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
			newItem.ItemID = SqlForeignKeyID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlForeignKey GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlForeignKey forwardItem = new SqlForeignKey();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlForeignKeyID = SqlForeignKeyID;
			}
			foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
			{
				item.SqlForeignKey = this;
				SqlExtendedProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlExtendedPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlForeignKeyColumn item in SqlForeignKeyColumnList)
			{
				item.SqlForeignKey = this;
				SqlForeignKeyColumn forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlForeignKeyColumnList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlForeignKey = this;
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
				if (modelContext is SqlForeignKey)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlTable)
				{
					solutionContext.NeedsSample = false;
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlForeignKeyList.Count > 0)
					{
						return parent.SqlForeignKeyList[DataHelper.GetRandomInt(0, parent.SqlForeignKeyList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlForeignKeyColumn)
				{
					return (modelContext as SqlForeignKeyColumn).SqlForeignKey;
				}
				else if (modelContext is SqlProperty)
				{
					if ((modelContext as SqlProperty).SqlForeignKey != null)
					{
						return (modelContext as SqlProperty).SqlForeignKey;
					}
				}
				else if (modelContext is SqlExtendedProperty)
				{
					if ((modelContext as SqlExtendedProperty).SqlForeignKey != null)
					{
						return (modelContext as SqlExtendedProperty).SqlForeignKey;
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
							return table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
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
							return table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
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
							return table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
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
						return table.SqlForeignKeyList[DataHelper.GetRandomInt(0, table.SqlForeignKeyList.Count - 1)];
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
				if (nodeContext is SqlTable)
				{
					return (nodeContext as SqlTable).SqlForeignKeyList;
				}
				
				#region protected
				else if (nodeContext is SqlDatabase)
				{
					EnterpriseDataObjectList<SqlForeignKey> keys = new EnterpriseDataObjectList<SqlForeignKey>();
					foreach (SqlTable table in (nodeContext as SqlDatabase).SqlTableList)
					{
						foreach (SqlForeignKey index in table.SqlForeignKeyList)
						{
							keys.Add(index);
						}
					}
					return keys;
				}
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						EnterpriseDataObjectList<SqlForeignKey> keys = new EnterpriseDataObjectList<SqlForeignKey>();
						foreach (SqlTable table in (nodeContext as DatabaseSource).SpecDatabase.SqlTableList)
						{
							foreach (SqlForeignKey index in table.SqlForeignKeyList)
							{
								keys.Add(index);
							}
						}
						return keys;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						EnterpriseDataObjectList<SqlForeignKey> keys = new EnterpriseDataObjectList<SqlForeignKey>();
						foreach (SqlTable table in (nodeContext as Project).OutputDatabase.SqlTableList)
						{
							foreach (SqlForeignKey index in table.SqlForeignKeyList)
							{
								keys.Add(index);
							}
						}
						return keys;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlForeignKey> keys = new EnterpriseDataObjectList<SqlForeignKey>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlTable table in source.SpecDatabase.SqlTableList)
							{
								foreach (SqlForeignKey index in table.SqlForeignKeyList)
								{
									keys.Add(index);
								}
							}
						}
					}
					return keys;
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
			return SqlTable;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlForeignKey instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlForeignKey instance to an xml file.</summary>
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
			if (_sqlExtendedPropertyList != null) _sqlExtendedPropertyList.ResetLoaded(isLoaded);
			if (_sqlForeignKeyColumnList != null) _sqlForeignKeyColumnList.ResetLoaded(isLoaded);
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
			if (_sqlExtendedPropertyList != null) _sqlExtendedPropertyList.ResetModified(isModified);
			if (_sqlForeignKeyColumnList != null) _sqlForeignKeyColumnList.ResetModified(isModified);
			if (_sqlPropertyList != null) _sqlPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlForeignKey(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlForeignKey instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlForeignKey(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlForeignKey instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlForeignKeyID">The input value for SqlForeignKeyID.</param>
		///--------------------------------------------------------------------------------
		public SqlForeignKey(Guid sqlForeignKeyID)
		{
			SqlForeignKeyID = sqlForeignKeyID;
		}
		#endregion "Constructors"
	}
}