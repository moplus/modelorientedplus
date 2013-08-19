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
	/// specific SqlDatabase instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/18/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="SqlDatabase")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlDatabase : BusinessObjectBase
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
			
			error = GetValidationError("SqlDatabaseName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DbID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Owner");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("PrimaryFilePath");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefaultSchema");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefaultFileGroup");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefaultFullTextCatalog");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("CreateDate");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Status");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("UserName");
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
				case "_sqlDatabaseName":
				case "SqlDatabaseName":
					error = ValidateSqlDatabaseName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_owner":
				case "Owner":
					error = ValidateOwner();
					break;
				case "_primaryFilePath":
				case "PrimaryFilePath":
					error = ValidatePrimaryFilePath();
					break;
				case "_defaultSchema":
				case "DefaultSchema":
					error = ValidateDefaultSchema();
					break;
				case "_defaultFileGroup":
				case "DefaultFileGroup":
					error = ValidateDefaultFileGroup();
					break;
				case "_defaultFullTextCatalog":
				case "DefaultFullTextCatalog":
					error = ValidateDefaultFullTextCatalog();
					break;
				case "_createDate":
				case "CreateDate":
					error = ValidateCreateDate();
					break;
				case "_status":
				case "Status":
					error = ValidateStatus();
					break;
				case "_userName":
				case "UserName":
					error = ValidateUserName();
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
		/// <summary>This method validates SqlDatabaseName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlDatabaseName()
		{
			if (!Regex.IsMatch(SqlDatabaseName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlDatabaseName");
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
		/// <summary>This method validates PrimaryFilePath and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePrimaryFilePath()
		{
			if (!Regex.IsMatch(PrimaryFilePath, Resources.DisplayValues.Regex_FilePath))
			{
				return String.Format(Resources.DisplayValues.Validation_PathValue, "PrimaryFilePath");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DefaultSchema and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefaultSchema()
		{
			if (String.IsNullOrEmpty(DefaultSchema))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "DefaultSchema");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DefaultFileGroup and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefaultFileGroup()
		{
			if (String.IsNullOrEmpty(DefaultFileGroup))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "DefaultFileGroup");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DefaultFullTextCatalog and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefaultFullTextCatalog()
		{
			if (String.IsNullOrEmpty(DefaultFullTextCatalog))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "DefaultFullTextCatalog");
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
		/// <summary>This method validates Status and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateStatus()
		{
			if (String.IsNullOrEmpty(Status))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Status");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates UserName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateUserName()
		{
			if (!Regex.IsMatch(UserName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "UserName");
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
		
		private SqlDatabase _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlDatabase ForwardInstance
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
		
		private SqlDatabase _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlDatabase ReverseInstance
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
				return SqlDatabaseID;
			}
			set
			{
				SqlDatabaseID = value;
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
				return SqlDatabaseName;
			}
			set
			{
				SqlDatabaseName = value;
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
				return SourceSqlDatabase.SqlDatabaseName;
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
					_displayName = SqlDatabaseName;
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
					_defaultSourceName = DefaultSourcePrefix + SourceSqlDatabase.SqlDatabaseName;
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
		public SqlDatabase SourceSqlDatabase
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
		
		protected string _sqlDatabaseName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlDatabaseName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlDatabaseName
		{
			get
			{
				return _sqlDatabaseName;
			}
			set
			{
				if (_sqlDatabaseName != value)
				{
					_sqlDatabaseName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlDatabaseName");
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
		
		protected string _primaryFilePath = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PrimaryFilePath.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string PrimaryFilePath
		{
			get
			{
				return _primaryFilePath;
			}
			set
			{
				if (_primaryFilePath != value)
				{
					_primaryFilePath = value;
					_isModified = true;
					base.OnPropertyChanged("PrimaryFilePath");
				}
			}
		}
		
		protected string _defaultSchema = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefaultSchema.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string DefaultSchema
		{
			get
			{
				return _defaultSchema;
			}
			set
			{
				if (_defaultSchema != value)
				{
					_defaultSchema = value;
					_isModified = true;
					base.OnPropertyChanged("DefaultSchema");
				}
			}
		}
		
		protected string _defaultFileGroup = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefaultFileGroup.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string DefaultFileGroup
		{
			get
			{
				return _defaultFileGroup;
			}
			set
			{
				if (_defaultFileGroup != value)
				{
					_defaultFileGroup = value;
					_isModified = true;
					base.OnPropertyChanged("DefaultFileGroup");
				}
			}
		}
		
		protected string _defaultFullTextCatalog = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefaultFullTextCatalog.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string DefaultFullTextCatalog
		{
			get
			{
				return _defaultFullTextCatalog;
			}
			set
			{
				if (_defaultFullTextCatalog != value)
				{
					_defaultFullTextCatalog = value;
					_isModified = true;
					base.OnPropertyChanged("DefaultFullTextCatalog");
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
		
		protected string _status = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Status.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Status
		{
			get
			{
				return _status;
			}
			set
			{
				if (_status != value)
				{
					_status = value;
					_isModified = true;
					base.OnPropertyChanged("Status");
				}
			}
		}
		
		protected string _userName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UserName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				if (_userName != value)
				{
					_userName = value;
					_isModified = true;
					base.OnPropertyChanged("UserName");
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlExtendedProperty> _sqlExtendedPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlDatabase.</summary>
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _sqlPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlDatabase.</summary>
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlTable> _sqlTableList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlDatabase.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlTable> SqlTableList
		{
			get
			{
				if (_sqlTableList == null)
				{
					_sqlTableList = new EnterpriseDataObjectList<BLL.Specifications.SqlTable>();
				}
				return _sqlTableList;
			}
			set
			{
				if (_sqlTableList == null || _sqlTableList.Equals(value) == false)
				{
					_sqlTableList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlTableList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlTable), ElementName = "SqlTable")]
		[DataMember(Name = "SqlTableList")]
		[DataArrayItem(ElementName = "SqlTableList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlTable> _S_SqlTableList
		{
			get
			{
				return _sqlTableList;
			}
			set
			{
				_sqlTableList = value;
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
				return "SqlDatabaseID";
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
				return SqlDatabaseID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlDatabaseID = primaryKeyValues[0].GetGuid();
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
				if (_sqlPropertyList != null && _sqlPropertyList.IsModified == true) return true;
				if (_sqlTableList != null && _sqlTableList.IsModified == true) return true;
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
				ReverseInstance = new SqlDatabase();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlDatabase();
				ForwardInstance.SqlDatabaseID = SqlDatabaseID;
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
			foreach (SqlProperty sqlProperty in SqlPropertyList)
			{
				sqlProperty.AddItemToUsedTags(usedTags);
			}
			foreach (SqlTable sqlTable in SqlTableList)
			{
				sqlTable.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputSqlDatabase">The sqldatabase to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlDatabase inputSqlDatabase)
		{
			if (SqlDatabaseName.GetString() != inputSqlDatabase.SqlDatabaseName.GetString()) return false;
			if (DbID.GetInt() != inputSqlDatabase.DbID.GetInt()) return false;
			if (Owner.GetString() != inputSqlDatabase.Owner.GetString()) return false;
			if (PrimaryFilePath.GetString() != inputSqlDatabase.PrimaryFilePath.GetString()) return false;
			if (DefaultSchema.GetString() != inputSqlDatabase.DefaultSchema.GetString()) return false;
			if (DefaultFileGroup.GetString() != inputSqlDatabase.DefaultFileGroup.GetString()) return false;
			if (DefaultFullTextCatalog.GetString() != inputSqlDatabase.DefaultFullTextCatalog.GetString()) return false;
			if (CreateDate.GetDateTime() != inputSqlDatabase.CreateDate.GetDateTime()) return false;
			if (Status.GetString() != inputSqlDatabase.Status.GetString()) return false;
			if (UserName.GetString() != inputSqlDatabase.UserName.GetString()) return false;
			if (Urn.GetString() != inputSqlDatabase.Urn.GetString()) return false;
			if (State.GetString() != inputSqlDatabase.State.GetString()) return false;
			if (Description.GetString() != inputSqlDatabase.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlDatabase">The sqldatabase to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlDatabase inputSqlDatabase)
		{
			if (inputSqlDatabase == null) return true;
			if (inputSqlDatabase.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.SqlDatabaseName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.Owner)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.PrimaryFilePath)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.DefaultSchema)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.DefaultFileGroup)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.DefaultFullTextCatalog)) return false;
			if (CreateDate != inputSqlDatabase.CreateDate) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.Status)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.UserName)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlDatabase.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlDatabase">The sqldatabase to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlDatabase inputSqlDatabase)
		{
			SqlDatabaseName = inputSqlDatabase.SqlDatabaseName;
			DbID = inputSqlDatabase.DbID;
			Owner = inputSqlDatabase.Owner;
			PrimaryFilePath = inputSqlDatabase.PrimaryFilePath;
			DefaultSchema = inputSqlDatabase.DefaultSchema;
			DefaultFileGroup = inputSqlDatabase.DefaultFileGroup;
			DefaultFullTextCatalog = inputSqlDatabase.DefaultFullTextCatalog;
			CreateDate = inputSqlDatabase.CreateDate;
			Status = inputSqlDatabase.Status;
			UserName = inputSqlDatabase.UserName;
			Urn = inputSqlDatabase.Urn;
			State = inputSqlDatabase.State;
			Description = inputSqlDatabase.Description;
			
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
				SqlDatabaseID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlDatabaseID == Guid.Empty)
				{
					SqlDatabaseID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlDatabaseID;
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
			if (_sqlPropertyList != null)
			{
				foreach (SqlProperty item in SqlPropertyList)
				{
					item.Dispose();
				}
				SqlPropertyList.Clear();
				SqlPropertyList = null;
			}
			if (_sqlTableList != null)
			{
				foreach (SqlTable item in SqlTableList)
				{
					item.Dispose();
				}
				SqlTableList.Clear();
				SqlTableList = null;
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
					ReverseInstance = new SqlDatabase();
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
			newItem.ItemID = SqlDatabaseID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlDatabase GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlDatabase forwardItem = new SqlDatabase();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlDatabaseID = SqlDatabaseID;
			}
			foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
			{
				item.SqlDatabase = this;
				SqlExtendedProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlExtendedPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlDatabase = this;
				SqlProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlTable item in SqlTableList)
			{
				item.SqlDatabase = this;
				SqlTable forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlTableList.Add(forwardChildItem);
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
				if (modelContext is SqlDatabase)
				{
					return modelContext;
				}
				#region protected
				else if (modelContext is DatabaseSource)
				{
					DatabaseSource parent = modelContext as DatabaseSource;
					return parent.SpecDatabase;
				}
				else if (modelContext is Project)
				{
					Project parent = modelContext as Project;
					if (parent.OutputDatabase != null)
					{
						return parent.OutputDatabase;
					}
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			
			#region protected
			if (solutionContext.IsSampleMode == true && solutionContext.DatabaseSourceList.Count > 0)
			{
				return solutionContext.DatabaseSourceList[DataHelper.GetRandomInt(0, solutionContext.DatabaseSourceList.Count - 1)].SpecDatabase;
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
				
				
				#region protected
				if (nodeContext is DatabaseSource)
				{
					EnterpriseDataObjectList<SqlDatabase> databases = new EnterpriseDataObjectList<SqlDatabase>();
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						databases.Add((nodeContext as DatabaseSource).SpecDatabase);
					}
					return databases;
				}
				if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						EnterpriseDataObjectList<SqlDatabase> databases = new EnterpriseDataObjectList<SqlDatabase>();
						databases.Add((nodeContext as Project).OutputDatabase);
						return databases;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlDatabase> databases = new EnterpriseDataObjectList<SqlDatabase>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							databases.Add(source.SpecDatabase);
						}
					}
					return databases;
				}
				#endregion protected
				
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlDatabase instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlDatabase instance to an xml file.</summary>
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
			if (_sqlPropertyList != null) _sqlPropertyList.ResetLoaded(isLoaded);
			if (_sqlTableList != null) _sqlTableList.ResetLoaded(isLoaded);
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
			if (_sqlPropertyList != null) _sqlPropertyList.ResetModified(isModified);
			if (_sqlTableList != null) _sqlTableList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlDatabase(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlDatabase instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlDatabase(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlDatabase instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlDatabaseID">The input value for SqlDatabaseID.</param>
		///--------------------------------------------------------------------------------
		public SqlDatabase(Guid sqlDatabaseID)
		{
			SqlDatabaseID = sqlDatabaseID;
		}
		#endregion "Constructors"
	}
}