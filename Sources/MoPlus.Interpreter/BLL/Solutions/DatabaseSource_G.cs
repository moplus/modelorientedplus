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

namespace MoPlus.Interpreter.BLL.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific DatabaseSource instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="DatabaseSource")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class DatabaseSource : Solutions.SpecificationSource
	{
		#region "Validation"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns validation errors for the input item.</param>
		/// 
		/// <returns>Validation errors (null by default).</returns>
		///--------------------------------------------------------------------------------
		public override string GetValidationErrors()
		{
			StringBuilder errors = new StringBuilder();
			string error = null;
			
			error = GetValidationError("SourceDbServerName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SourceDbName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DatabaseTypeCode");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("UserName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Password");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SolutionID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("TemplatePath");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Order");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsAutoUpdated");
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
				case "_sourceDbServerName":
				case "SourceDbServerName":
					error = ValidateSourceDbServerName();
					break;
				case "_sourceDbName":
				case "SourceDbName":
					error = ValidateSourceDbName();
					break;
				case "_databaseTypeCode":
				case "DatabaseTypeCode":
					error = ValidateDatabaseTypeCode();
					break;
				case "_userName":
				case "UserName":
					error = ValidateUserName();
					break;
				case "_password":
				case "Password":
					error = ValidatePassword();
					break;
				case "_solutionID":
				case "SolutionID":
					error = ValidateSolutionID();
					break;
				case "_templatePath":
				case "TemplatePath":
					error = ValidateTemplatePath();
					break;
				case "_order":
				case "Order":
					error = ValidateOrder();
					break;
				case "_isAutoUpdated":
				case "IsAutoUpdated":
					error = ValidateIsAutoUpdated();
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
		/// <summary>This method validates SourceDbServerName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSourceDbServerName()
		{
			if (!Regex.IsMatch(SourceDbServerName, Resources.DisplayValues.Regex_PathName))
			{
				return String.Format(Resources.DisplayValues.Validation_PathNameValue, "SourceDbServerName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SourceDbName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSourceDbName()
		{
			if (!Regex.IsMatch(SourceDbName, Resources.DisplayValues.Regex_DbName))
			{
				return String.Format(Resources.DisplayValues.Validation_DbNameValue, "SourceDbName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DatabaseTypeCode and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDatabaseTypeCode()
		{
			if (DatabaseTypeCode <= 0)
			{
				return String.Format(Resources.DisplayValues.Validation_PositiveNumericValue, "DatabaseTypeCode");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates UserName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateUserName()
		{
			if (!String.IsNullOrEmpty(UserName) && !Regex.IsMatch(UserName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "UserName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Password and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePassword()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private DatabaseSource _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new DatabaseSource ForwardInstance
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
		
		private DatabaseSource _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new DatabaseSource ReverseInstance
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
				return SpecificationSourceID;
			}
			set
			{
				SpecificationSourceID = value;
			}
		}
		
		private string _defaultSourceName;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the default source name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override string DefaultSourceName
		{
			get
			{
				if (_defaultSourceName == null)
				{
					_defaultSourceName = DefaultSourcePrefix + SourceDatabaseSource.SourceDbServerName;
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
		public DatabaseSource SourceDatabaseSource
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
		/// <summary>This property gets/sets the OldDatabaseTypeCode of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int OldDatabaseTypeCode { get; set; }
		
		
		protected string _sourceDbServerName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SourceDbServerName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SourceDbServerName
		{
			get
			{
				return _sourceDbServerName;
			}
			set
			{
				if (_sourceDbServerName != value)
				{
					_sourceDbServerName = value;
					_isModified = true;
					base.OnPropertyChanged("SourceDbServerName");
				}
			}
		}
		
		protected string _sourceDbName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SourceDbName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SourceDbName
		{
			get
			{
				return _sourceDbName;
			}
			set
			{
				if (_sourceDbName != value)
				{
					_sourceDbName = value;
					_isModified = true;
					base.OnPropertyChanged("SourceDbName");
				}
			}
		}
		
		protected int _databaseTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DatabaseTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Int)]
		public virtual int DatabaseTypeCode
		{
			get
			{
				return _databaseTypeCode;
			}
			set
			{
				if (_databaseTypeCode != value)
				{
					_databaseTypeCode = value;
					_isModified = true;
					base.OnPropertyChanged("DatabaseTypeCode");
				}
			}
		}
		
		protected string _userName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UserName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
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
		
		protected string _password = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Password.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if (_password != value)
				{
					_password = value;
					_isModified = true;
					base.OnPropertyChanged("Password");
				}
			}
		}
		[XmlIgnore]
		public string PasswordClearText
		{
			get
			{
				return SecurityHelper.DecryptStringAES(_password, BusinessConfiguration.EncryptionKey);
			}
			set
			{
				if (value != SecurityHelper.DecryptStringAES(_password, BusinessConfiguration.EncryptionKey))
				{
					_password = SecurityHelper.EncryptStringAES(value, BusinessConfiguration.EncryptionKey);
					_isModified = true;
					base.OnPropertyChanged("Password");
				}
			}
		}
		
		protected string _databaseTypeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DatabaseTypeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DatabaseTypeName
		{
			get
			{
				return _databaseTypeName;
			}
		}
		
		protected BLL.Config.DatabaseType _databaseType = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the DatabaseType.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Config.DatabaseType DatabaseType
		{
			get
			{
				return _databaseType;
			}
			set
			{
				if (value != null)
				{
					_databaseTypeName = value.DatabaseTypeName;
					if (_databaseType != null && _databaseType.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					DatabaseTypeCode = value.DatabaseTypeCode;
				}
				_databaseType = value;
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
			if (ReverseInstance == null && IsAutoUpdated == true)
			{
				ReverseInstance = new DatabaseSource();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new DatabaseSource();
				ForwardInstance.SpecificationSourceID = SpecificationSourceID;
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
		public override void AddItemToUsedTags(NameObjectCollection usedTags)
		{
			AddTagsToUsedTags(usedTags);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputDatabaseSource">The databasesource to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(DatabaseSource inputDatabaseSource)
		{
			if (SourceDbServerName.GetString() != inputDatabaseSource.SourceDbServerName.GetString()) return false;
			if (SourceDbName.GetString() != inputDatabaseSource.SourceDbName.GetString()) return false;
			if (DatabaseTypeCode.GetInt() != inputDatabaseSource.DatabaseTypeCode.GetInt()) return false;
			if (UserName.GetString() != inputDatabaseSource.UserName.GetString()) return false;
			if (Password.GetString() != inputDatabaseSource.Password.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputDatabaseSource">The databasesource to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(DatabaseSource inputDatabaseSource)
		{
			if (inputDatabaseSource == null) return true;
			if (inputDatabaseSource.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputDatabaseSource.SourceDbServerName)) return false;
			if (!String.IsNullOrEmpty(inputDatabaseSource.SourceDbName)) return false;
			if (DatabaseTypeCode != DefaultValue.Int) return false;
			if (!String.IsNullOrEmpty(inputDatabaseSource.UserName)) return false;
			if (!String.IsNullOrEmpty(inputDatabaseSource.Password)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputDatabaseSource">The databasesource to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(DatabaseSource inputDatabaseSource)
		{
			SourceDbServerName = inputDatabaseSource.SourceDbServerName;
			SourceDbName = inputDatabaseSource.SourceDbName;
			DatabaseTypeCode = inputDatabaseSource.DatabaseTypeCode;
			UserName = inputDatabaseSource.UserName;
			Password = inputDatabaseSource.Password;
			
			#region protected
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public override void SetID()
		{
			_defaultSourceName = null;
			if (Solution.UsedModelIDs[DefaultSourceName].GetGuid() != Guid.Empty)
			{
				SpecificationSourceID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (SpecificationSourceID == Guid.Empty)
				{
					SpecificationSourceID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = SpecificationSourceID;
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
			DatabaseType = null;
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
		public override bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new DatabaseSource();
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
		public override CollectionItem CreateIDReference()
		{
			CollectionItem newItem = new CollectionItem();
			newItem.ItemID = SpecificationSourceID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public new DatabaseSource GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			DatabaseSource forwardItem = new DatabaseSource();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else if (IsAutoUpdated == false)
			{
				forwardItem.TransformDataFromObject(this, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.SpecificationSourceID = SpecificationSourceID;
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
				if (modelContext is DatabaseSource)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Solution)
				{
					solutionContext.NeedsSample = false;
					Solution parent = modelContext as Solution;
					if (parent.DatabaseSourceList.Count > 0)
					{
						return parent.DatabaseSourceList[DataHelper.GetRandomInt(0, parent.DatabaseSourceList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.DatabaseSourceList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.DatabaseSourceList[DataHelper.GetRandomInt(0, solutionContext.DatabaseSourceList.Count - 1)];
			}
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
				if (nodeContext is Solution)
				{
					return (nodeContext as Solution).DatabaseSourceList;
				}
				
				#region protected
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
			return Solution;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			SetID();
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds the current item to the solution, if it is valid
		/// and not already present in the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		///--------------------------------------------------------------------------------
		public static void AddCurrentItemToSolution(Solution solutionContext, ITemplate templateContext, int lineNumber)
		{
			if (solutionContext.CurrentDatabaseSource != null)
			{
				string validationErrors = solutionContext.CurrentDatabaseSource.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentDatabaseSource, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentDatabaseSource.Solution = solutionContext;
				solutionContext.CurrentDatabaseSource.AddToParent();
				DatabaseSource existingItem = solutionContext.DatabaseSourceList.Find(i => i.SpecificationSourceID == solutionContext.CurrentDatabaseSource.SpecificationSourceID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentDatabaseSource.AssignProperty("SpecificationSourceID", solutionContext.CurrentDatabaseSource.SpecificationSourceID);
					solutionContext.CurrentDatabaseSource.ReverseInstance.ResetModified(false);
					solutionContext.DatabaseSourceList.Add(solutionContext.CurrentDatabaseSource);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new DatabaseSource();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentDatabaseSource, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("SpecificationSourceID", existingItem.SpecificationSourceID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentDatabaseSource = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current DatabaseSource item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentDatabaseSource != null)
			{
				DatabaseSource existingItem = solutionContext.DatabaseSourceList.Find(i => i.SpecificationSourceID == solutionContext.CurrentDatabaseSource.SpecificationSourceID);
				if (existingItem != null)
				{
					solutionContext.DatabaseSourceList.Remove(solutionContext.CurrentDatabaseSource);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the DatabaseSource instance from an xml file.</summary>
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
		/// <summary>This method saves the DatabaseSource instance to an xml file.</summary>
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
			base.ResetLoaded(isLoaded);
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
		public DatabaseSource(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic DatabaseSource instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public DatabaseSource(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic DatabaseSource instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="specificationSourceID">The input value for SpecificationSourceID.</param>
		///--------------------------------------------------------------------------------
		public DatabaseSource(Guid specificationSourceID)
		{
			SpecificationSourceID = specificationSourceID;
		}
		#endregion "Constructors"
	}
}