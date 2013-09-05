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

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific Template instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Template")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Template : BusinessObjectBase
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
			
			error = GetValidationError("TemplateName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("CategoryName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("NodeName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsTopLevelTemplate");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("HasErrors");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsTemplateUtilized");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("TemplateContent");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("TemplateOutput");
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
				case "_templateName":
				case "TemplateName":
					error = ValidateTemplateName();
					break;
				case "_categoryName":
				case "CategoryName":
					error = ValidateCategoryName();
					break;
				case "_nodeName":
				case "NodeName":
					error = ValidateNodeName();
					break;
				case "_isTopLevelTemplate":
				case "IsTopLevelTemplate":
					error = ValidateIsTopLevelTemplate();
					break;
				case "_hasErrors":
				case "HasErrors":
					error = ValidateHasErrors();
					break;
				case "_isTemplateUtilized":
				case "IsTemplateUtilized":
					error = ValidateIsTemplateUtilized();
					break;
				case "_templateContent":
				case "TemplateContent":
					error = ValidateTemplateContent();
					break;
				case "_templateOutput":
				case "TemplateOutput":
					error = ValidateTemplateOutput();
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
		/// <summary>This method validates TemplateName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateTemplateName()
		{
			if (!Regex.IsMatch(TemplateName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "TemplateName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates CategoryName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateCategoryName()
		{
			if (!String.IsNullOrEmpty(CategoryName) && !Regex.IsMatch(CategoryName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "CategoryName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates NodeName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNodeName()
		{
			if (!Regex.IsMatch(NodeName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "NodeName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsTopLevelTemplate and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsTopLevelTemplate()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates HasErrors and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateHasErrors()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsTemplateUtilized and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsTemplateUtilized()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates TemplateContent and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateTemplateContent()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates TemplateOutput and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateTemplateOutput()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsAutoUpdated and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsAutoUpdated()
		{
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
		
		private Template _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Template ForwardInstance
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
		
		private Template _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Template ReverseInstance
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
				return TemplateID;
			}
			set
			{
				TemplateID = value;
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
				return TemplateName;
			}
			set
			{
				TemplateName = value;
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
				return SourceTemplate.TemplateName;
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
				
				#region protected
				if (_displayName == null)
				{
					if (!String.IsNullOrEmpty(CategoryName))
					{
						_displayName = NodeName + "." + CategoryName + "." + TemplateName;
					}
					else
					{
						_displayName = NodeName + "." + TemplateName;
					}
				}
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
					_defaultSourceName = DefaultSourcePrefix + SourceTemplate.TemplateName;
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
		public Template SourceTemplate
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
		/// <summary>This property gets/sets the OldTemplateID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldTemplateID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldSolutionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSolutionID { get; set; }
		
		
		protected Guid _templateID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid TemplateID
		{
			get
			{
				return _templateID;
			}
			set
			{
				if (_templateID != value)
				{
					_templateID = value;
					_isModified = true;
					base.OnPropertyChanged("TemplateID");
				}
			}
		}
		
		protected string _templateName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string TemplateName
		{
			get
			{
				return _templateName;
			}
			set
			{
				if (_templateName != value)
				{
					_templateName = value;
					_isModified = true;
					base.OnPropertyChanged("TemplateName");
				}
			}
		}
		
		protected string _filePath = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FilePath.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string FilePath
		{
			get
			{
				return _filePath;
			}
			set
			{
				if (_filePath != value)
				{
					_filePath = value;
					_isModified = true;
					base.OnPropertyChanged("FilePath");
				}
			}
		}
		
		protected string _categoryName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CategoryName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string CategoryName
		{
			get
			{
				return _categoryName;
			}
			set
			{
				if (_categoryName != value)
				{
					_categoryName = value;
					_isModified = true;
					base.OnPropertyChanged("CategoryName");
				}
			}
		}
		
		protected string _nodeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NodeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string NodeName
		{
			get
			{
				return _nodeName;
			}
			set
			{
				if (_nodeName != value)
				{
					_nodeName = value;
					_isModified = true;
					base.OnPropertyChanged("NodeName");
				}
			}
		}
		
		protected Guid _solutionID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SolutionID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid SolutionID
		{
			get
			{
				return _solutionID;
			}
			set
			{
				if (_solutionID != value)
				{
					_solutionID = value;
					base.OnPropertyChanged("SolutionID");
				}
			}
		}
		
		protected bool _isTopLevelTemplate = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsTopLevelTemplate.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsTopLevelTemplate
		{
			get
			{
				return _isTopLevelTemplate;
			}
			set
			{
				if (_isTopLevelTemplate != value)
				{
					_isTopLevelTemplate = value;
					_isModified = true;
					base.OnPropertyChanged("IsTopLevelTemplate");
				}
			}
		}
		
		protected bool _hasErrors = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the HasErrors.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool HasErrors
		{
			get
			{
				return _hasErrors;
			}
			set
			{
				if (_hasErrors != value)
				{
					_hasErrors = value;
					base.OnPropertyChanged("HasErrors");
				}
			}
		}
		
		protected bool _isTemplateUtilized = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsTemplateUtilized.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsTemplateUtilized
		{
			get
			{
				return _isTemplateUtilized;
			}
			set
			{
				if (_isTemplateUtilized != value)
				{
					_isTemplateUtilized = value;
					base.OnPropertyChanged("IsTemplateUtilized");
				}
			}
		}
		
		protected string _templateCallInfo = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateCallInfo.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string TemplateCallInfo
		{
			get
			{
				return _templateCallInfo;
			}
			set
			{
				if (_templateCallInfo != value)
				{
					_templateCallInfo = value;
					base.OnPropertyChanged("TemplateCallInfo");
				}
			}
		}
		
		protected string _templateContent = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateContent.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string TemplateContent
		{
			get
			{
				return _templateContent;
			}
			set
			{
				if (_templateContent != value)
				{
					_templateContent = value;
					_isModified = true;
					base.OnPropertyChanged("TemplateContent");
				}
			}
		}
		
		protected string _templateOutput = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateOutput.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string TemplateOutput
		{
			get
			{
				return _templateOutput;
			}
			set
			{
				if (_templateOutput != value)
				{
					_templateOutput = value;
					_isModified = true;
					base.OnPropertyChanged("TemplateOutput");
				}
			}
		}
		
		protected bool _isAutoUpdated = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsAutoUpdated.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsAutoUpdated
		{
			get
			{
				return _isAutoUpdated;
			}
			set
			{
				if (_isAutoUpdated != value)
				{
					_isAutoUpdated = value;
					base.OnPropertyChanged("IsAutoUpdated");
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
		
		protected string _solutionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the SolutionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SolutionName
		{
			get
			{
				return _solutionName;
			}
		}
		
		protected string _outputSolutionFileName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the OutputSolutionFileName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string OutputSolutionFileName
		{
			get
			{
				return _outputSolutionFileName;
			}
		}
		
		protected string _companyName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the CompanyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string CompanyName
		{
			get
			{
				return _companyName;
			}
		}
		
		protected string _productName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the ProductName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ProductName
		{
			get
			{
				return _productName;
			}
		}
		
		protected BLL.Solutions.Solution _solution = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Solutions.Solution Solution
		{
			get
			{
				return _solution;
			}
			set
			{
				if (value != null)
				{
					_solutionName = value.SolutionName;
					_outputSolutionFileName = value.OutputSolutionFileName;
					_companyName = value.CompanyName;
					_productName = value.ProductName;
					SolutionID = value.SolutionID;
				}
				_solution = value;
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
				return "TemplateID";
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
				return TemplateID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					TemplateID = primaryKeyValues[0].GetGuid();
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
			if (ReverseInstance == null && IsAutoUpdated == true)
			{
				ReverseInstance = new Template();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Template();
				ForwardInstance.TemplateID = TemplateID;
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
		/// <param name="inputTemplate">The template to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Template inputTemplate)
		{
			if (TemplateName.GetString() != inputTemplate.TemplateName.GetString()) return false;
			if (FilePath.GetString() != inputTemplate.FilePath.GetString()) return false;
			if (CategoryName.GetString() != inputTemplate.CategoryName.GetString()) return false;
			if (NodeName.GetString() != inputTemplate.NodeName.GetString()) return false;
			if (SolutionID.GetGuid() != inputTemplate.SolutionID.GetGuid()) return false;
			if (IsTopLevelTemplate.GetBool() != inputTemplate.IsTopLevelTemplate.GetBool()) return false;
			if (HasErrors.GetBool() != inputTemplate.HasErrors.GetBool()) return false;
			if (IsTemplateUtilized.GetBool() != inputTemplate.IsTemplateUtilized.GetBool()) return false;
			if (TemplateCallInfo.GetString() != inputTemplate.TemplateCallInfo.GetString()) return false;
			if (TemplateContent.GetString() != inputTemplate.TemplateContent.GetString()) return false;
			if (TemplateOutput.GetString() != inputTemplate.TemplateOutput.GetString()) return false;
			if (IsAutoUpdated.GetBool() != inputTemplate.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputTemplate.Description.GetString()) return false;
			
			#region protected
			if (_cachedContent != null)
			{
				CachedContent.Clear();
				CachedContent = null;
			}
			if (_modelContextStack != null)
			{
				ModelContextStack.Clear();
				ModelContextStack = null;
			}
			_messageBuilder = null;
			_outputCodeBuilder = null;
			OutputAST = null;
			ContentCode = null;
			_contentCodeBuilder = null;
			ContentAST = null;
			Solution = null;
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputTemplate">The template to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Template inputTemplate)
		{
			if (inputTemplate == null) return true;
			if (inputTemplate.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputTemplate.TemplateName)) return false;
			if (!String.IsNullOrEmpty(inputTemplate.FilePath)) return false;
			if (!String.IsNullOrEmpty(inputTemplate.CategoryName)) return false;
			if (!String.IsNullOrEmpty(inputTemplate.NodeName)) return false;
			if (SolutionID != inputTemplate.SolutionID) return false;
			if (IsTopLevelTemplate != inputTemplate.IsTopLevelTemplate) return false;
			if (HasErrors != inputTemplate.HasErrors) return false;
			if (IsTemplateUtilized != inputTemplate.IsTemplateUtilized) return false;
			if (!String.IsNullOrEmpty(inputTemplate.TemplateCallInfo)) return false;
			if (!String.IsNullOrEmpty(inputTemplate.TemplateContent)) return false;
			if (!String.IsNullOrEmpty(inputTemplate.TemplateOutput)) return false;
			if (IsAutoUpdated != inputTemplate.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputTemplate.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputTemplate">The template to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Template inputTemplate)
		{
			TemplateName = inputTemplate.TemplateName;
			FilePath = inputTemplate.FilePath;
			CategoryName = inputTemplate.CategoryName;
			NodeName = inputTemplate.NodeName;
			SolutionID = inputTemplate.SolutionID;
			IsTopLevelTemplate = inputTemplate.IsTopLevelTemplate;
			HasErrors = inputTemplate.HasErrors;
			IsTemplateUtilized = inputTemplate.IsTemplateUtilized;
			TemplateCallInfo = inputTemplate.TemplateCallInfo;
			TemplateContent = inputTemplate.TemplateContent;
			TemplateOutput = inputTemplate.TemplateOutput;
			IsAutoUpdated = inputTemplate.IsAutoUpdated;
			Description = inputTemplate.Description;
			
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
				TemplateID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (TemplateID == Guid.Empty)
				{
					TemplateID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = TemplateID;
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
			Solution = null;
			
			#region protected
			if (ContentAST != null)
			{
				ContentAST.ChildNodes.Clear();
				ContentAST = null;
			}
			if (OutputAST != null)
			{
				OutputAST.ChildNodes.Clear();
				OutputAST = null;
			}
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
					ReverseInstance = new Template();
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
			newItem.ItemID = TemplateID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Template GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Template forwardItem = new Template();
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
				forwardItem.TemplateID = TemplateID;
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
		/// <summary>This method gets the Template instance from an xml file.</summary>
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
		/// <summary>This method saves the Template instance to an xml file.</summary>
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
		public Template(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Template instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Template(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Template instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="templateID">The input value for TemplateID.</param>
		///--------------------------------------------------------------------------------
		public Template(Guid templateID)
		{
			TemplateID = templateID;
		}
		#endregion "Constructors"
	}
}