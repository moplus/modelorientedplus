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
	/// specific SqlIndexedColumn instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="SqlIndexedColumn")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlIndexedColumn : BusinessObjectBase
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
			
			error = GetValidationError("SqlIndexedColumnName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DbID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SqlIndexID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsIncluded");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsComputed");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Descending");
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
				case "_sqlIndexedColumnName":
				case "SqlIndexedColumnName":
					error = ValidateSqlIndexedColumnName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlIndexID":
				case "SqlIndexID":
					error = ValidateSqlIndexID();
					break;
				case "_isIncluded":
				case "IsIncluded":
					error = ValidateIsIncluded();
					break;
				case "_isComputed":
				case "IsComputed":
					error = ValidateIsComputed();
					break;
				case "_descending":
				case "Descending":
					error = ValidateDescending();
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
		/// <summary>This method validates SqlIndexedColumnName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlIndexedColumnName()
		{
			if (!Regex.IsMatch(SqlIndexedColumnName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "SqlIndexedColumnName");
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
		/// <summary>This method validates SqlIndexID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlIndexID()
		{
			if (SqlIndexID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "SqlIndexID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsIncluded and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsIncluded()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsComputed and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsComputed()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Descending and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDescending()
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
		
		private SqlIndexedColumn _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlIndexedColumn ForwardInstance
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
		
		private SqlIndexedColumn _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlIndexedColumn ReverseInstance
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
				return SqlIndexedColumnID;
			}
			set
			{
				SqlIndexedColumnID = value;
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
				return SqlIndexedColumnName;
			}
			set
			{
				SqlIndexedColumnName = value;
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
				return SourceSqlIndexedColumn.SqlIndexedColumnName;
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
					if (!String.IsNullOrEmpty(SqlIndexName))
					{
						_displayName = SqlIndexName + "." + SqlIndexedColumnName;
					}
					else
					{
						_displayName = SqlIndexedColumnName;
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
					if (SqlIndex != null)
					{
						_defaultSourceName = SqlIndex.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlIndexedColumn.SqlIndexedColumnName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlIndexedColumn.SqlIndexedColumnName;
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
		public SqlIndexedColumn SourceSqlIndexedColumn
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
		/// <summary>This property gets/sets the OldSqlIndexedColumnID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlIndexedColumnID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSqlIndexID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlIndexID { get; set; }
		
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
		
		protected Guid _sqlIndexedColumnID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlIndexedColumnID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SqlIndexedColumnID
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
		
		protected string _sqlIndexedColumnName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlIndexedColumnName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlIndexedColumnName
		{
			get
			{
				return _sqlIndexedColumnName;
			}
			set
			{
				if (_sqlIndexedColumnName != value)
				{
					_sqlIndexedColumnName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlIndexedColumnName");
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
		
		protected bool? _isIncluded = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsIncluded.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsIncluded
		{
			get
			{
				return _isIncluded;
			}
			set
			{
				if (_isIncluded != value)
				{
					_isIncluded = value;
					_isModified = true;
					base.OnPropertyChanged("IsIncluded");
				}
			}
		}
		
		protected bool? _isComputed = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsComputed.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? IsComputed
		{
			get
			{
				return _isComputed;
			}
			set
			{
				if (_isComputed != value)
				{
					_isComputed = value;
					_isModified = true;
					base.OnPropertyChanged("IsComputed");
				}
			}
		}
		
		protected bool? _descending = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Descending.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual bool? Descending
		{
			get
			{
				return _descending;
			}
			set
			{
				if (_descending != value)
				{
					_descending = value;
					_isModified = true;
					base.OnPropertyChanged("Descending");
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlProperty> _sqlPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlIndexedColumn.</summary>
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
		
		///-------------------------------------------------------------------------------
		/// <summary>This property gets the primary key properties.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyProperties
		{
			get
			{
				return "SqlIndexedColumnID";
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
				return SqlIndexedColumnID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlIndexedColumnID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new SqlIndexedColumn();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlIndexedColumn();
				ForwardInstance.SqlIndexedColumnID = SqlIndexedColumnID;
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
		/// <param name="inputSqlIndexedColumn">The sqlindexedcolumn to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlIndexedColumn inputSqlIndexedColumn)
		{
			if (SqlIndexedColumnName.GetString() != inputSqlIndexedColumn.SqlIndexedColumnName.GetString()) return false;
			if (DbID.GetInt() != inputSqlIndexedColumn.DbID.GetInt()) return false;
			if (SqlIndexID.GetGuid() != inputSqlIndexedColumn.SqlIndexID.GetGuid()) return false;
			if (IsIncluded.GetBool() != inputSqlIndexedColumn.IsIncluded.GetBool()) return false;
			if (IsComputed.GetBool() != inputSqlIndexedColumn.IsComputed.GetBool()) return false;
			if (Descending.GetBool() != inputSqlIndexedColumn.Descending.GetBool()) return false;
			if (Urn.GetString() != inputSqlIndexedColumn.Urn.GetString()) return false;
			if (State.GetString() != inputSqlIndexedColumn.State.GetString()) return false;
			if (Description.GetString() != inputSqlIndexedColumn.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlIndexedColumn">The sqlindexedcolumn to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlIndexedColumn inputSqlIndexedColumn)
		{
			if (inputSqlIndexedColumn == null) return true;
			if (inputSqlIndexedColumn.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlIndexedColumn.SqlIndexedColumnName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlIndexID != inputSqlIndexedColumn.SqlIndexID) return false;
			if (IsIncluded != inputSqlIndexedColumn.IsIncluded) return false;
			if (IsComputed != inputSqlIndexedColumn.IsComputed) return false;
			if (Descending != inputSqlIndexedColumn.Descending) return false;
			if (!String.IsNullOrEmpty(inputSqlIndexedColumn.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlIndexedColumn.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlIndexedColumn.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlIndexedColumn">The sqlindexedcolumn to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlIndexedColumn inputSqlIndexedColumn)
		{
			SqlIndexedColumnName = inputSqlIndexedColumn.SqlIndexedColumnName;
			DbID = inputSqlIndexedColumn.DbID;
			SqlIndexID = inputSqlIndexedColumn.SqlIndexID;
			IsIncluded = inputSqlIndexedColumn.IsIncluded;
			IsComputed = inputSqlIndexedColumn.IsComputed;
			Descending = inputSqlIndexedColumn.Descending;
			Urn = inputSqlIndexedColumn.Urn;
			State = inputSqlIndexedColumn.State;
			Description = inputSqlIndexedColumn.Description;
			
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
				SqlIndexedColumnID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlIndexedColumnID == Guid.Empty)
				{
					SqlIndexedColumnID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlIndexedColumnID;
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
			SqlIndex = null;
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
					ReverseInstance = new SqlIndexedColumn();
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
			newItem.ItemID = SqlIndexedColumnID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlIndexedColumn GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlIndexedColumn forwardItem = new SqlIndexedColumn();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlIndexedColumnID = SqlIndexedColumnID;
			}
			foreach (SqlProperty item in SqlPropertyList)
			{
				item.SqlIndexedColumn = this;
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
				if (modelContext is SqlIndexedColumn)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlIndex)
				{
					solutionContext.NeedsSample = false;
					SqlIndex parent = modelContext as SqlIndex;
					if (parent.SqlIndexedColumnList.Count > 0)
					{
						return parent.SqlIndexedColumnList[DataHelper.GetRandomInt(0, parent.SqlIndexedColumnList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlProperty)
				{
					if ((modelContext as SqlProperty).SqlIndexedColumn != null)
					{
						return (modelContext as SqlProperty).SqlIndexedColumn;
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is SqlTable)
				{
					SqlTable parent = modelContext as SqlTable;
					if (parent.SqlIndexList.Count > 0)
					{
						SqlIndex index = parent.SqlIndexList[DataHelper.GetRandomInt(0, parent.SqlIndexList.Count - 1)];
						if (index.SqlIndexedColumnList.Count > 0)
						{
							return index.SqlIndexedColumnList[DataHelper.GetRandomInt(0, index.SqlIndexedColumnList.Count - 1)];
						}
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
							SqlIndex index = table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
							if (index.SqlIndexedColumnList.Count > 0)
							{
								return index.SqlIndexedColumnList[DataHelper.GetRandomInt(0, index.SqlIndexedColumnList.Count - 1)];
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
						if (table.SqlIndexList.Count > 0)
						{
							SqlIndex index = table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
							if (index.SqlIndexedColumnList.Count > 0)
							{
								return index.SqlIndexedColumnList[DataHelper.GetRandomInt(0, index.SqlIndexedColumnList.Count - 1)];
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
						if (table.SqlIndexList.Count > 0)
						{
							SqlIndex index = table.SqlIndexList[DataHelper.GetRandomInt(0, table.SqlIndexList.Count - 1)];
							if (index.SqlIndexedColumnList.Count > 0)
							{
								return index.SqlIndexedColumnList[DataHelper.GetRandomInt(0, index.SqlIndexedColumnList.Count - 1)];
							}
						}
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
				if (nodeContext is SqlIndex)
				{
					return (nodeContext as SqlIndex).SqlIndexedColumnList;
				}
				
				#region protected
				else if (nodeContext is SqlTable)
				{
					EnterpriseDataObjectList<SqlIndexedColumn> columns = new EnterpriseDataObjectList<SqlIndexedColumn>();
					foreach (SqlIndex index in (nodeContext as SqlTable).SqlIndexList)
					{
						foreach (SqlIndexedColumn column in index.SqlIndexedColumnList)
						{
							columns.Add(column);
						}
					}
					return columns;
				}
				else if (nodeContext is SqlDatabase)
				{
					EnterpriseDataObjectList<SqlIndexedColumn> columns = new EnterpriseDataObjectList<SqlIndexedColumn>();
					foreach (SqlTable table in (nodeContext as SqlDatabase).SqlTableList)
					{
						foreach (SqlIndex index in table.SqlIndexList)
						{
							foreach (SqlIndexedColumn column in index.SqlIndexedColumnList)
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
						EnterpriseDataObjectList<SqlIndexedColumn> columns = new EnterpriseDataObjectList<SqlIndexedColumn>();
						foreach (SqlTable table in (nodeContext as DatabaseSource).SpecDatabase.SqlTableList)
						{
							foreach (SqlIndex index in table.SqlIndexList)
							{
								foreach (SqlIndexedColumn column in index.SqlIndexedColumnList)
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
						EnterpriseDataObjectList<SqlIndexedColumn> columns = new EnterpriseDataObjectList<SqlIndexedColumn>();
						foreach (SqlTable table in (nodeContext as Project).OutputDatabase.SqlTableList)
						{
							foreach (SqlIndex index in table.SqlIndexList)
							{
								foreach (SqlIndexedColumn column in index.SqlIndexedColumnList)
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
					EnterpriseDataObjectList<SqlIndexedColumn> columns = new EnterpriseDataObjectList<SqlIndexedColumn>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlTable table in source.SpecDatabase.SqlTableList)
							{
								foreach (SqlIndex index in table.SqlIndexList)
								{
									foreach (SqlIndexedColumn column in index.SqlIndexedColumnList)
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
			return SqlIndex;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the SqlIndexedColumn instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlIndexedColumn instance to an xml file.</summary>
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
		public SqlIndexedColumn(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlIndexedColumn instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlIndexedColumn(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlIndexedColumn instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlIndexedColumnID">The input value for SqlIndexedColumnID.</param>
		///--------------------------------------------------------------------------------
		public SqlIndexedColumn(Guid sqlIndexedColumnID)
		{
			SqlIndexedColumnID = sqlIndexedColumnID;
		}
		#endregion "Constructors"
	}
}