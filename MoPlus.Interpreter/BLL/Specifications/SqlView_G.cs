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
	/// specific SqlView instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/27/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="SqlView")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class SqlView : BusinessObjectBase
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
			
			error = GetValidationError("SqlViewName");
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
				case "_sqlViewName":
				case "SqlViewName":
					error = ValidateSqlViewName();
					break;
				case "_dbID":
				case "DbID":
					error = ValidateDbID();
					break;
				case "_sqlDatabaseID":
				case "SqlDatabaseID":
					error = ValidateSqlDatabaseID();
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
		/// <summary>This method validates SqlViewName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSqlViewName()
		{
			if (String.IsNullOrEmpty(SqlViewName))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "SqlViewName");
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
		
		private SqlView _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlView ForwardInstance
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
		
		private SqlView _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new SqlView ReverseInstance
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
				return SqlViewID;
			}
			set
			{
				SqlViewID = value;
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
				return SqlViewName;
			}
			set
			{
				SqlViewName = value;
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
				return SourceSqlView.SqlViewName;
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
						_displayName = SqlDatabaseName + "." + SqlViewName;
					}
					else
					{
						_displayName = SqlViewName;
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
						_defaultSourceName = SqlDatabase.DefaultSourceName + "." + DefaultSourcePrefix + SourceSqlView.SqlViewName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceSqlView.SqlViewName;
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
		public SqlView SourceSqlView
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
		/// <summary>This property gets/sets the OldSqlViewID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSqlViewID { get; set; }
		
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
		
		protected string _sqlViewName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlViewName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SqlViewName
		{
			get
			{
				return _sqlViewName;
			}
			set
			{
				if (_sqlViewName != value)
				{
					_sqlViewName = value;
					_isModified = true;
					base.OnPropertyChanged("SqlViewName");
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
		
		protected EnterpriseDataObjectList<BLL.Specifications.SqlViewProperty> _sqlViewPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of SqlView.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlViewProperty> SqlViewPropertyList
		{
			get
			{
				if (_sqlViewPropertyList == null)
				{
					_sqlViewPropertyList = new EnterpriseDataObjectList<BLL.Specifications.SqlViewProperty>();
				}
				return _sqlViewPropertyList;
			}
			set
			{
				if (_sqlViewPropertyList == null || _sqlViewPropertyList.Equals(value) == false)
				{
					_sqlViewPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SqlViewPropertyList")]
		[XmlArrayItem(typeof(BLL.Specifications.SqlViewProperty), ElementName = "SqlViewProperty")]
		[DataMember(Name = "SqlViewPropertyList")]
		[DataArrayItem(ElementName = "SqlViewPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.SqlViewProperty> _S_SqlViewPropertyList
		{
			get
			{
				return _sqlViewPropertyList;
			}
			set
			{
				_sqlViewPropertyList = value;
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
				return "SqlViewID";
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
				return SqlViewID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SqlViewID = primaryKeyValues[0].GetGuid();
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
				if (_sqlViewPropertyList != null && _sqlViewPropertyList.IsModified == true) return true;
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
				ReverseInstance = new SqlView();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new SqlView();
				ForwardInstance.SqlViewID = SqlViewID;
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
			foreach (SqlViewProperty sqlViewProperty in SqlViewPropertyList)
			{
				sqlViewProperty.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputSqlView">The sqlview to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(SqlView inputSqlView)
		{
			if (SqlViewName.GetString() != inputSqlView.SqlViewName.GetString()) return false;
			if (DbID.GetInt() != inputSqlView.DbID.GetInt()) return false;
			if (SqlDatabaseID.GetGuid() != inputSqlView.SqlDatabaseID.GetGuid()) return false;
			if (CreateDate.GetDateTime() != inputSqlView.CreateDate.GetDateTime()) return false;
			if (DateLastModified.GetDateTime() != inputSqlView.DateLastModified.GetDateTime()) return false;
			if (Urn.GetString() != inputSqlView.Urn.GetString()) return false;
			if (State.GetString() != inputSqlView.State.GetString()) return false;
			if (Description.GetString() != inputSqlView.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSqlView">The sqlview to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(SqlView inputSqlView)
		{
			if (inputSqlView == null) return true;
			if (inputSqlView.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSqlView.SqlViewName)) return false;
			if (DbID != DefaultValue.Int) return false;
			if (SqlDatabaseID != inputSqlView.SqlDatabaseID) return false;
			if (CreateDate != inputSqlView.CreateDate) return false;
			if (DateLastModified != inputSqlView.DateLastModified) return false;
			if (!String.IsNullOrEmpty(inputSqlView.Urn)) return false;
			if (!String.IsNullOrEmpty(inputSqlView.State)) return false;
			if (!String.IsNullOrEmpty(inputSqlView.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSqlView">The sqlview to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(SqlView inputSqlView)
		{
			SqlViewName = inputSqlView.SqlViewName;
			DbID = inputSqlView.DbID;
			SqlDatabaseID = inputSqlView.SqlDatabaseID;
			CreateDate = inputSqlView.CreateDate;
			DateLastModified = inputSqlView.DateLastModified;
			Urn = inputSqlView.Urn;
			State = inputSqlView.State;
			Description = inputSqlView.Description;
			
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
				SqlViewID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SqlViewID == Guid.Empty)
				{
					SqlViewID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SqlViewID;
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
			if (_sqlViewPropertyList != null)
			{
				foreach (SqlViewProperty item in SqlViewPropertyList)
				{
					item.Dispose();
				}
				SqlViewPropertyList.Clear();
				SqlViewPropertyList = null;
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
					ReverseInstance = new SqlView();
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
			newItem.ItemID = SqlViewID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public SqlView GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			SqlView forwardItem = new SqlView();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SqlViewID = SqlViewID;
			}
			foreach (SqlViewProperty item in SqlViewPropertyList)
			{
				item.SqlView = this;
				SqlViewProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SqlViewPropertyList.Add(forwardChildItem);
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
				if (modelContext is SqlView)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is SqlDatabase)
				{
					solutionContext.NeedsSample = false;
					SqlDatabase parent = modelContext as SqlDatabase;
					if (parent.SqlViewList.Count > 0)
					{
						return parent.SqlViewList[DataHelper.GetRandomInt(0, parent.SqlViewList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is SqlViewProperty)
				{
					return (modelContext as SqlViewProperty).SqlView;
				}
				else if (solutionContext.IsSampleMode == true && modelContext is DatabaseSource)
				{
					SqlDatabase parent = (modelContext as DatabaseSource).SpecDatabase;
					if (parent != null && parent.SqlViewList.Count > 0)
					{
						return parent.SqlViewList[DataHelper.GetRandomInt(0, parent.SqlViewList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is Project)
				{
					SqlDatabase parent = (modelContext as Project).OutputDatabase;
					if (parent != null && parent.SqlViewList.Count > 0)
					{
						return parent.SqlViewList[DataHelper.GetRandomInt(0, parent.SqlViewList.Count - 1)];
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
				if (nodeContext is SqlDatabase)
				{
					return (nodeContext as SqlDatabase).SqlViewList;
				}
				
				#region protected
				else if (nodeContext is DatabaseSource)
				{
					if ((nodeContext as DatabaseSource).SpecDatabase != null)
					{
						return (nodeContext as DatabaseSource).SpecDatabase.SqlViewList;
					}
				}
				else if (nodeContext is Project)
				{
					if ((nodeContext as Project).OutputDatabase != null)
					{
						return (nodeContext as Project).OutputDatabase.SqlViewList;
					}
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<SqlView> views = new EnterpriseDataObjectList<SqlView>();
					foreach (DatabaseSource source in (nodeContext as Solution).DatabaseSourceList)
					{
						if (source.SpecDatabase != null)
						{
							foreach (SqlView view in source.SpecDatabase.SqlViewList)
							{
								views.Add(view);
							}
						}
					}
					return views;
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
		/// <summary>This method gets the SqlView instance from an xml file.</summary>
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
		/// <summary>This method saves the SqlView instance to an xml file.</summary>
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
			if (_sqlViewPropertyList != null) _sqlViewPropertyList.ResetLoaded(isLoaded);
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
			if (_sqlViewPropertyList != null) _sqlViewPropertyList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SqlView(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlView instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public SqlView(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic SqlView instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="sqlViewID">The input value for SqlViewID.</param>
		///--------------------------------------------------------------------------------
		public SqlView(Guid sqlViewID)
		{
			SqlViewID = sqlViewID;
		}
		#endregion "Constructors"
	}
}