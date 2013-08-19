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
	/// specific SqlIndex instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlIndex")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlIndex : BusinessObjectBase
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
			
			error = GetValidationError("SqlIndexName");
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
			error = GetValidationError("IsClustered");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsUnique");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsXmlIndex");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsFullTextKey");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("FileGroup");
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
				case "_sqlIndexName":
				case "SqlIndexName":
					error = ValidateSqlIndexName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlTableID":
				case "SqlTableID":
					error = ValidateSqlTableID();
					break;
				case "_isClustered":
				case "IsClustered":
					error = ValidateIsClustered();
					break;
				case "_isUnique":
				case "IsUnique":
					error = ValidateIsUnique();
					break;
				case "_isXmlIndex":
				case "IsXmlIndex":
					error = ValidateIsXmlIndex();
					break;
				case "_isFullTextKey":
				case "IsFullTextKey":
					error = ValidateIsFullTextKey();
					break;
				case "_fileGroup":
				case "FileGroup":
					error = ValidateFileGroup();
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
		/// <summary>This method validates SqlIndexName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlIndexName()
		{
			if (!Regex.IsMatch(SqlIndexName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlIndexName");
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
		/// <summary>This method validates IsClustered and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsClustered()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsUnique and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsUnique()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsXmlIndex and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsXmlIndex()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsFullTextKey and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsFullTextKey()
		{
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
		
		private SqlIndex _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlIndex ForwardInstance
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
		
		private SqlIndex _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlIndex ReverseInstance
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
				return SqlIndexID;
			}
			set
			{
				SqlIndexID = value;
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
				return SqlIndexName;
			}
			set
			{
				SqlIndexName = value;
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
				return SourceSqlIndex.SqlIndexName;
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
						_displayName = SqlTableName + "." + SqlIndexName;
					}
					else
					{
						_displayName = SqlIndexName;
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
						_defaultSourceName = SqlTable.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlIndex.SqlIndexName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlIndex.SqlIndexName;
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
		public SqlIndex SourceSqlIndex
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
		/// <summary>This property gets/sets the OldSqlIndexID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlIndexID { get; set; }
		
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
		
		protected Guid _sqlIndexID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlIndexID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlIndexID
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
		
		protected string _sqlIndexName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlIndexName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlIndexName
		{
			get
			{
				return _sqlIndexName;
			}
			set
			{
				if (_sqlIndexName != value)
				{
					_sqlIndexName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlIndexName");
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
		
		protected bool? _isClustered = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsClustered.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsClustered
		{
			get
			{
				return _isClustered;
			}
			set
			{
				if (_isClustered != value)
				{
					_isClustered = value;
					_isModified = true;
					base.OnPropertyChanged("IsClustered");
				}
			}
		}
		
		protected bool? _isUnique = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsUnique.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsUnique
		{
			get
			{
				return _isUnique;
			}
			set
			{
				if (_isUnique != value)
				{
					_isUnique = value;
					_isModified = true;
					base.OnPropertyChanged("IsUnique");
				}
			}
		}
		
		protected bool? _isXmlIndex = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsXmlIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsXmlIndex
		{
			get
			{
				return _isXmlIndex;
			}
			set
			{
				if (_isXmlIndex != value)
				{
					_isXmlIndex = value;
					_isModified = true;
					base.OnPropertyChanged("IsXmlIndex");
				}
			}
		}
		
		protected bool? _isFullTextKey = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsFullTextKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsFullTextKey
		{
			get
			{
				return _isFullTextKey;
			}
			set
			{
				if (_isFullTextKey != value)
				{
					_isFullTextKey = value;
					_isModified = true;
					base.OnPropertyChanged("IsFullTextKey");
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
		/// <summary>This property gets or sets a collection of SqlIndex.</summary>
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlIndexedColumn> _sqlIndexedColumnList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlIndexedColumn> SqlIndexedColumnList
		{
			get
			{
				if (_sqlIndexedColumnList == null)
				{
					_sqlIndexedColumnList = new EnterpriseDataObjectList<BLL.Specifications.SqlIndexedColumn>();
				}
				return _sqlIndexedColumnList;
			}
			set
			{
				if (_sqlIndexedColumnList == null || _sqlIndexedColumnList.Equals(value) == false)
				{
					_sqlIndexedColumnList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlIndexedColumnList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlIndexedColumn), ElementName = "SqlIndexedColumn")]
		[DataMember(Name = "SqlIndexedColumnList")]
		[DataArrayItem(ElementName = "SqlIndexedColumnList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlIndexedColumn> _S_SqlIndexedColumnList
		{
			get
			{
				return _sqlIndexedColumnList;
			}
			set
			{
				_sqlIndexedColumnList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _sqlPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlIndex.</summary>
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
				return "SqlIndexID";
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
				return SqlIndexID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlIndexID = primaryKeyValues[0].GetGuid();
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
				if (_sqlIndexedColumnList != null && _sqlIndexedColumnList.IsModified == true) return true;
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
				ReverseInstance = new SqlIndex();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlIndex();
				ForwardInstance.SqlIndexID = SqlIndexID;
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
			foreach (SqlIndexedColumn sqlIndexedColumn in SqlIndexedColumnList)
			{
				sqlIndexedColumn.AddItemToUsedTags(usedTags);
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
		/// <param name="inputSqlIndex">The sqlindex to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlIndex inputSqlIndex)
		{
			if (SqlIndexName.GetString() != inputSqlIndex.SqlIndexName.GetString()) return false;
			if (DbID.GetInt() != inputSqlIndex.DbID.GetInt()) return false;
			if (SqlTableID.GetGuid() != inputSqlIndex.SqlTableID.GetGuid()) return false;
			if (IsClustered.GetBool() != inputSqlIndex.IsClustered.GetBool()) return false;
			if (IsUnique.GetBool() != inputSqlIndex.IsUnique.GetBool()) return false;
			if (IsXmlIndex.GetBool() != inputSqlIndex.IsXmlIndex.GetBool()) return false;
			if (IsFullTextKey.GetBool() != inputSqlIndex.IsFullTextKey.GetBool()) return false;
			if (FileGroup.GetString() != inputSqlIndex.FileGroup.GetString()) return false;
			if (Urn.GetString() != inputSqlIndex.Urn.GetString()) return false;
			if (State.GetString() != inputSqlIndex.State.GetString()) return false;
			if (Description.GetString() != inputSqlIndex.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlIndex">The sqlindex to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlIndex inputSqlIndex)
		{
			if (inputSqlIndex == null) return true;
			if (inputSqlIndex.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlIndex.SqlIndexName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlTableID != inputSqlIndex.SqlTableID) return false;
			if (IsClustered != inputSqlIndex.IsClustered) return false;
			if (IsUnique != inputSqlIndex.IsUnique) return false;
			if (IsXmlIndex != inputSqlIndex.IsXmlIndex) return false;
			if (IsFullTextKey != inputSqlIndex.IsFullTextKey) return false;
			if (!String.IsNullOrEmpty(inputSqlIndex.FileGroup)) return false;
			if (!String.IsNullOrEmpty(inputSqlIndex.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlIndex.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlIndex.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlIndex">The sqlindex to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlIndex inputSqlIndex)
		{
			SqlIndexName = inputSqlIndex.SqlIndexName;
			DbID = inputSqlIndex.DbID;
			SqlTableID = inputSqlIndex.SqlTableID;
			IsClustered = inputSqlIndex.IsClustered;
			IsUnique = inputSqlIndex.IsUnique;
			IsXmlIndex = inputSqlIndex.IsXmlIndex;
			IsFullTextKey = inputSqlIndex.IsFullTextKey;
			FileGroup = inputSqlIndex.FileGroup;
			Urn = inputSqlIndex.Urn;
			State = inputSqlIndex.State;
			Description = inputSqlIndex.Description;
			
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
				SqlIndexID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlIndexID == Guid.Empty)
				{
					SqlIndexID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlIndexID;
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
			if (_sqlIndexedColumnList != null)
			{
				foreach (SqlIndexedColumn item in SqlIndexedColumnList)
				{
					item.Dispose();
				}
				SqlIndexedColumnList.Clear();
				SqlIndexedColumnList = null;
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
					ReverseInstance = new SqlIndex();
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
			newItem.ItemID = SqlIndexID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlIndex GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlIndex forwardItem = new SqlIndex();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlIndexID = SqlIndexID;
			}
			foreach (SqlExtendedProperty item in SqlExtendedPropertyList)
			{
				item.SqlIndex = this;
				SqlExtendedProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlExtendedPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlIndexedColumn item in SqlIndexedColumnList)
			{
				item.SqlIndex = this;
				SqlIndexedColumn forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlIndexedColumnList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlIndex = this;
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
				if (modelContext is SqlIndex)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlTable)
				{
					solutionContext.NeedsSample = false;
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlIndexList.Count > 0)
					{
						return parent.SqlIndexList[DataHelper.GetRandomInt(0, parent.SqlIndexList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlIndexedColumn)
				{
					return (modelContext as SqlIndexedColumn).SqlIndex;
				}
				else if (modelContext is SqlProperty)
				{
					if ((modelContext as SqlProperty).SqlIndex != null)
					{
						return (modelContext as SqlProperty).SqlIndex;
					}
				}
				else if (modelContext is SqlExtendedProperty)
				{
					if ((modelContext as SqlExtendedProperty).SqlIndex != null)
					{
						return (modelContext as SqlExtendedProperty).SqlIndex;
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlDatabase)
				{
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlIndexList.Count > 0)
						{
							return table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlIndexList.Count > 0)
						{
							return table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
						}
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent.SqlTableList.Count > 0)
					{
						SqlTable table = parent.SqlTableList[DataHelper.GetRandomInt(0, parent.SqlTableList.Count - 1)];
						if (table.SqlIndexList.Count > 0)
						{
							return table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
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
					if (table.SqlIndexList.Count > 0)
					{
						return table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
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
					return (nodeContext as SqlTable).SqlIndexList;
				}
				
				#region protected
				else if (nodeContext is SqlDatabase)
				{
					EnterpriseDataObjectList<SqlIndex> indexes = new EnterpriseDataObjectList<SqlIndex>();
					foreach (SqlTable table in (nodeContext as SqlDatabase).SqlTableList)
					{
						foreach (SqlIndex index in table.SqlIndexList)
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
						EnterpriseDataObjectList<SqlIndex> indexes = new EnterpriseDataObjectList<SqlIndex>();
						foreach (SqlTable table in (nodeContext as DatabaseSource).SpecDatabase.SqlTableList)
						{
							foreach (SqlIndex index in table.SqlIndexList)
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
						EnterpriseDataObjectList<SqlIndex> indexes = new EnterpriseDataObjectList<SqlIndex>();
						foreach (SqlTable table in (nodeContext as Project).OutputDatabase.SqlTableList)
						{
							foreach (SqlIndex index in table.SqlIndexList)
							{
								indexes.Add(index);
							}
						}
						return indexes;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlIndex> indexes = new EnterpriseDataObjectList<SqlIndex>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlTable table in source.SpecDatabase.SqlTableList)
							{
								foreach (SqlIndex index in table.SqlIndexList)
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
		/// <summary>This method gets the SqlIndex instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlIndex instance to an xml file.</summary>
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
			if (_sqlIndexedColumnList != null) _sqlIndexedColumnList.ResetLoaded(isLoaded);
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
			if (_sqlIndexedColumnList != null) _sqlIndexedColumnList.ResetModified(isModified);
			if (_sqlPropertyList != null) _sqlPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlIndex(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlIndex instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlIndex(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlIndex instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlIndexID">The input value for SqlIndexID.</param>
		///--------------------------------------------------------------------------------
		public SqlIndex(Guid sqlIndexID)
		{
			SqlIndexID = sqlIndexID;
		}
		#endregion "Constructors"
	}
}