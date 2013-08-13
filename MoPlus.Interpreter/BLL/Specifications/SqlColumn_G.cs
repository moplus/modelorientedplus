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
	/// specific SqlColumn instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/3/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="SqlColumn")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlColumn : BusinessObjectBase
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
			
			error = GetValidationError("SqlColumnName");
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
			error = GetValidationError("DataType");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("MaximumLength");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("NumericPrecision");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("NumericScale");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Default");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DefaultSchema");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsFullTextIndexed");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsForeignKey");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("InPrimaryKey");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Nullable");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Identity");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IdentitySeed");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IdentityIncrement");
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
				case "_sqlColumnName":
				case "SqlColumnName":
					error = ValidateSqlColumnName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlTableID":
				case "SqlTableID":
					error = ValidateSqlTableID();
					break;
				case "_dataType":
				case "DataType":
					error = ValidateDataType();
					break;
				case "_maximumLength":
				case "MaximumLength":
					error = ValidateMaximumLength();
					break;
				case "_numericPrecision":
				case "NumericPrecision":
					error = ValidateNumericPrecision();
					break;
				case "_numericScale":
				case "NumericScale":
					error = ValidateNumericScale();
					break;
				case "_default":
				case "Default":
					error = ValidateDefault();
					break;
				case "_defaultSchema":
				case "DefaultSchema":
					error = ValidateDefaultSchema();
					break;
				case "_isFullTextIndexed":
				case "IsFullTextIndexed":
					error = ValidateIsFullTextIndexed();
					break;
				case "_isForeignKey":
				case "IsForeignKey":
					error = ValidateIsForeignKey();
					break;
				case "_inPrimaryKey":
				case "InPrimaryKey":
					error = ValidateInPrimaryKey();
					break;
				case "_nullable":
				case "Nullable":
					error = ValidateNullable();
					break;
				case "_identity":
				case "Identity":
					error = ValidateIdentity();
					break;
				case "_identitySeed":
				case "IdentitySeed":
					error = ValidateIdentitySeed();
					break;
				case "_identityIncrement":
				case "IdentityIncrement":
					error = ValidateIdentityIncrement();
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
		/// <summary>This method validates SqlColumnName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlColumnName()
		{
			if (!Regex.IsMatch(SqlColumnName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlColumnName");
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
		/// <summary>This method validates DataType and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDataType()
		{
			if (String.IsNullOrEmpty(DataType))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "DataType");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates MaximumLength and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateMaximumLength()
		{
			if (MaximumLength <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "MaximumLength");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates NumericPrecision and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNumericPrecision()
		{
			if (NumericPrecision <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "NumericPrecision");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates NumericScale and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNumericScale()
		{
			if (NumericScale <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "NumericScale");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Default and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDefault()
		{
			if (String.IsNullOrEmpty(Default))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Default");
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
		/// <summary>This method validates IsFullTextIndexed and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsFullTextIndexed()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsForeignKey and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsForeignKey()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates InPrimaryKey and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateInPrimaryKey()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Nullable and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNullable()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Identity and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentity()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IdentitySeed and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentitySeed()
		{
			if (IdentitySeed != null && IdentitySeed < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "IdentitySeed");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IdentityIncrement and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIdentityIncrement()
		{
			if (IdentityIncrement != null && IdentityIncrement < 0)
			{
				return String.Format(Resources.DisplayValues.Validation_NonNegativeNumericValue, "IdentityIncrement");
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
		
		private SqlColumn _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlColumn ForwardInstance
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
		
		private SqlColumn _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlColumn ReverseInstance
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
				return SqlColumnID;
			}
			set
			{
				SqlColumnID = value;
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
				return SqlColumnName;
			}
			set
			{
				SqlColumnName = value;
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
				return SourceSqlColumn.SqlColumnName;
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
						_displayName = SqlTableName + "." + SqlColumnName;
					}
					else
					{
						_displayName = SqlColumnName;
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
						_defaultSourceName = SqlTable.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlColumn.SqlColumnName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlColumn.SqlColumnName;
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
		public SqlColumn SourceSqlColumn
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
		/// <summary>This property gets/sets the OldSqlColumnID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlColumnID { get; set; }
		
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
		
		protected Guid _sqlColumnID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlColumnID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlColumnID
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
		
		protected string _sqlColumnName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlColumnName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlColumnName
		{
			get
			{
				return _sqlColumnName;
			}
			set
			{
				if (_sqlColumnName != value)
				{
					_sqlColumnName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlColumnName");
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
		
		protected string _dataType = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DataType.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string DataType
		{
			get
			{
				return _dataType;
			}
			set
			{
				if (_dataType != value)
				{
					_dataType = value;
					_isModified = true;
					base.OnPropertyChanged("DataType");
				}
			}
		}
		
		protected int _maximumLength = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MaximumLength.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int MaximumLength
		{
			get
			{
				return _maximumLength;
			}
			set
			{
				if (_maximumLength != value)
				{
					_maximumLength = value;
					_isModified = true;
					base.OnPropertyChanged("MaximumLength");
				}
			}
		}
		
		protected int _numericPrecision = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NumericPrecision.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int NumericPrecision
		{
			get
			{
				return _numericPrecision;
			}
			set
			{
				if (_numericPrecision != value)
				{
					_numericPrecision = value;
					_isModified = true;
					base.OnPropertyChanged("NumericPrecision");
				}
			}
		}
		
		protected int _numericScale = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NumericScale.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int NumericScale
		{
			get
			{
				return _numericScale;
			}
			set
			{
				if (_numericScale != value)
				{
					_numericScale = value;
					_isModified = true;
					base.OnPropertyChanged("NumericScale");
				}
			}
		}
		
		protected string _default = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Default.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Default
		{
			get
			{
				return _default;
			}
			set
			{
				if (_default != value)
				{
					_default = value;
					_isModified = true;
					base.OnPropertyChanged("Default");
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
		
		protected bool? _isFullTextIndexed = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsFullTextIndexed.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsFullTextIndexed
		{
			get
			{
				return _isFullTextIndexed;
			}
			set
			{
				if (_isFullTextIndexed != value)
				{
					_isFullTextIndexed = value;
					_isModified = true;
					base.OnPropertyChanged("IsFullTextIndexed");
				}
			}
		}
		
		protected bool? _isForeignKey = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsForeignKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsForeignKey
		{
			get
			{
				return _isForeignKey;
			}
			set
			{
				if (_isForeignKey != value)
				{
					_isForeignKey = value;
					_isModified = true;
					base.OnPropertyChanged("IsForeignKey");
				}
			}
		}
		
		protected bool? _inPrimaryKey = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the InPrimaryKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? InPrimaryKey
		{
			get
			{
				return _inPrimaryKey;
			}
			set
			{
				if (_inPrimaryKey != value)
				{
					_inPrimaryKey = value;
					_isModified = true;
					base.OnPropertyChanged("InPrimaryKey");
				}
			}
		}
		
		protected bool? _nullable = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Nullable.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? Nullable
		{
			get
			{
				return _nullable;
			}
			set
			{
				if (_nullable != value)
				{
					_nullable = value;
					_isModified = true;
					base.OnPropertyChanged("Nullable");
				}
			}
		}
		
		protected bool? _identity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Identity.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? Identity
		{
			get
			{
				return _identity;
			}
			set
			{
				if (_identity != value)
				{
					_identity = value;
					_isModified = true;
					base.OnPropertyChanged("Identity");
				}
			}
		}
		
		protected long? _identitySeed = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IdentitySeed.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual long? IdentitySeed
		{
			get
			{
				return _identitySeed;
			}
			set
			{
				if (_identitySeed != value)
				{
					_identitySeed = value;
					_isModified = true;
					base.OnPropertyChanged("IdentitySeed");
				}
			}
		}
		
		protected long? _identityIncrement = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IdentityIncrement.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual long? IdentityIncrement
		{
			get
			{
				return _identityIncrement;
			}
			set
			{
				if (_identityIncrement != value)
				{
					_identityIncrement = value;
					_isModified = true;
					base.OnPropertyChanged("IdentityIncrement");
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
		/// <summary>This property gets or sets a collection of SqlColumn.</summary>
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
		/// <summary>This property gets or sets a collection of SqlColumn.</summary>
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
				return "SqlColumnID";
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
				return SqlColumnID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlColumnID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new SqlColumn();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlColumn();
				ForwardInstance.SqlColumnID = SqlColumnID;
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
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputSqlColumn">The sqlcolumn to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlColumn inputSqlColumn)
		{
			if (SqlColumnName.GetString() != inputSqlColumn.SqlColumnName.GetString()) return false;
			if (DbID.GetInt() != inputSqlColumn.DbID.GetInt()) return false;
			if (SqlTableID.GetGuid() != inputSqlColumn.SqlTableID.GetGuid()) return false;
			if (DataType.GetString() != inputSqlColumn.DataType.GetString()) return false;
			if (MaximumLength.GetInt() != inputSqlColumn.MaximumLength.GetInt()) return false;
			if (NumericPrecision.GetInt() != inputSqlColumn.NumericPrecision.GetInt()) return false;
			if (NumericScale.GetInt() != inputSqlColumn.NumericScale.GetInt()) return false;
			if (Default.GetString() != inputSqlColumn.Default.GetString()) return false;
			if (DefaultSchema.GetString() != inputSqlColumn.DefaultSchema.GetString()) return false;
			if (IsFullTextIndexed.GetBool() != inputSqlColumn.IsFullTextIndexed.GetBool()) return false;
			if (IsForeignKey.GetBool() != inputSqlColumn.IsForeignKey.GetBool()) return false;
			if (InPrimaryKey.GetBool() != inputSqlColumn.InPrimaryKey.GetBool()) return false;
			if (Nullable.GetBool() != inputSqlColumn.Nullable.GetBool()) return false;
			if (Identity.GetBool() != inputSqlColumn.Identity.GetBool()) return false;
			if (IdentitySeed.GetLong() != inputSqlColumn.IdentitySeed.GetLong()) return false;
			if (IdentityIncrement.GetLong() != inputSqlColumn.IdentityIncrement.GetLong()) return false;
			if (Urn.GetString() != inputSqlColumn.Urn.GetString()) return false;
			if (State.GetString() != inputSqlColumn.State.GetString()) return false;
			if (Description.GetString() != inputSqlColumn.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlColumn">The sqlcolumn to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlColumn inputSqlColumn)
		{
			if (inputSqlColumn == null) return true;
			if (inputSqlColumn.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.SqlColumnName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlTableID != inputSqlColumn.SqlTableID) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.DataType)) return false;
			if (MaximumLength != DefaultValue.Int) return false;
			if (NumericPrecision != DefaultValue.Int) return false;
			if (NumericScale != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.Default)) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.DefaultSchema)) return false;
			if (IsFullTextIndexed != inputSqlColumn.IsFullTextIndexed) return false;
			if (IsForeignKey != inputSqlColumn.IsForeignKey) return false;
			if (InPrimaryKey != inputSqlColumn.InPrimaryKey) return false;
			if (Nullable != inputSqlColumn.Nullable) return false;
			if (Identity != inputSqlColumn.Identity) return false;
			if (IdentitySeed != DefaultValue.Int) return false;
			if (IdentityIncrement != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlColumn.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlColumn">The sqlcolumn to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlColumn inputSqlColumn)
		{
			SqlColumnName = inputSqlColumn.SqlColumnName;
			DbID = inputSqlColumn.DbID;
			SqlTableID = inputSqlColumn.SqlTableID;
			DataType = inputSqlColumn.DataType;
			MaximumLength = inputSqlColumn.MaximumLength;
			NumericPrecision = inputSqlColumn.NumericPrecision;
			NumericScale = inputSqlColumn.NumericScale;
			Default = inputSqlColumn.Default;
			DefaultSchema = inputSqlColumn.DefaultSchema;
			IsFullTextIndexed = inputSqlColumn.IsFullTextIndexed;
			IsForeignKey = inputSqlColumn.IsForeignKey;
			InPrimaryKey = inputSqlColumn.InPrimaryKey;
			Nullable = inputSqlColumn.Nullable;
			Identity = inputSqlColumn.Identity;
			IdentitySeed = inputSqlColumn.IdentitySeed;
			IdentityIncrement = inputSqlColumn.IdentityIncrement;
			Urn = inputSqlColumn.Urn;
			State = inputSqlColumn.State;
			Description = inputSqlColumn.Description;
			
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
				SqlColumnID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlColumnID == Guid.Empty)
				{
					SqlColumnID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlColumnID;
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
					ReverseInstance = new SqlColumn();
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
			newItem.ItemID = SqlColumnID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlColumn GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlColumn forwardItem = new SqlColumn();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlColumnID = SqlColumnID;
			}
			foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
			{
				item.SqlColumn = this;
				SqlExtendedProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlExtendedPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlColumn = this;
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
				if (modelContext is SqlColumn)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlTable)
				{
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlColumnList.Count > 0)
					{
						return parent.SqlColumnList[DataHelper.GetRandomInt(0, parent.SqlColumnList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlProperty)
				{
					if ((modelContext as SqlProperty).SqlColumn != null)
					{
						return (modelContext as SqlProperty).SqlColumn;
					}
				}
				else if (modelContext is SqlExtendedProperty)
				{
					if ((modelContext as SqlExtendedProperty).SqlColumn != null)
					{
						return (modelContext as SqlExtendedProperty).SqlColumn;
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlDatabase)
				{
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlColumnList.Count > 0)
						{
							return table.SqlColumnList[DataHelper.GetRandomInt(0, table.SqlColumnList.Count - 1)];
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlColumnList.Count > 0)
						{
							return table.SqlColumnList[DataHelper.GetRandomInt(0, table.SqlColumnList.Count - 1)];
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlColumnList.Count > 0)
						{
							return table.SqlColumnList[DataHelper.GetRandomInt(0, table.SqlColumnList.Count - 1)];
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
					if (table.SqlColumnList.Count > 0)
					{
						return table.SqlColumnList[DataHelper.GetRandomInt(0, table.SqlColumnList.Count - 1)];
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
					return (nodeContext as SqlTable).SqlColumnList;
				}
				
				#region protected
				else if (nodeContext is SqlDatabase)
				{
					EnterpriseDataObjectList<SqlColumn> indexes = new EnterpriseDataObjectList<SqlColumn>();
					foreach (SqlTable table in (nodeContext as SqlDatabase).SqlTableList)
					{
						foreach (SqlColumn index in table.SqlColumnList)
						{
							indexes.Add(index);
						}
					}
					return indexes;
				}
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						EnterpriseDataObjectList<SqlColumn> indexes = new EnterpriseDataObjectList<SqlColumn>();
						foreach (SqlTable table in (nodeContext as DatabaseSource).SpecDatabase.SqlTableList)
						{
							foreach (SqlColumn index in table.SqlColumnList)
							{
								indexes.Add(index);
							}
						}
						return indexes;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						EnterpriseDataObjectList<SqlColumn> indexes = new EnterpriseDataObjectList<SqlColumn>();
						foreach (SqlTable table in (nodeContext as Project).OutputDatabase.SqlTableList)
						{
							foreach (SqlColumn index in table.SqlColumnList)
							{
								indexes.Add(index);
							}
						}
						return indexes;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlColumn> indexes = new EnterpriseDataObjectList<SqlColumn>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlTable table in source.SpecDatabase.SqlTableList)
							{
								foreach (SqlColumn index in table.SqlColumnList)
								{
									indexes.Add(index);
								}
							}
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
			return SqlTable;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlColumn instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlColumn instance to an xml file.</summary>
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
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlColumn(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlColumn instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlColumn(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlColumn instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlColumnID">The input value for SqlColumnID.</param>
		///--------------------------------------------------------------------------------
		public SqlColumn(Guid sqlColumnID)
		{
			SqlColumnID = sqlColumnID;
		}
		#endregion "Constructors"
	}
}