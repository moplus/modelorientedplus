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
	/// specific Solution instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="Solution")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class Solution : BusinessObjectBase
	{
		#region "Interpreter"
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public AuditProperty CurrentAuditProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentCollection.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Collection CurrentCollection { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentEntity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Entity CurrentEntity { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentEntityReference.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public EntityReference CurrentEntityReference { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentEnumeration.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Enumeration CurrentEnumeration { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentFeature.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Feature CurrentFeature { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Index CurrentIndex { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentIndexProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public IndexProperty CurrentIndexProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentMethod.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Method CurrentMethod { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentMethodRelationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public MethodRelationship CurrentMethodRelationship { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentModel.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Model CurrentModel { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentModelObject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ModelObject CurrentModelObject { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentModelProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ModelProperty CurrentModelProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ObjectInstance CurrentObjectInstance { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentParameter.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Parameter CurrentParameter { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Property CurrentProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentPropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyInstance CurrentPropertyInstance { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentPropertyReference.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyReference CurrentPropertyReference { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentPropertyRelationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyRelationship CurrentPropertyRelationship { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentRelationship.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Relationship CurrentRelationship { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentRelationshipProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public RelationshipProperty CurrentRelationshipProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSolution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Solution CurrentSolution { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlColumn CurrentSqlColumn { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlDatabase.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlDatabase CurrentSqlDatabase { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlExtendedProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlExtendedProperty CurrentSqlExtendedProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlForeignKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlForeignKey CurrentSqlForeignKey { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlForeignKeyColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlForeignKeyColumn CurrentSqlForeignKeyColumn { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlIndex CurrentSqlIndex { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlIndexedColumn.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlIndexedColumn CurrentSqlIndexedColumn { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlProperty CurrentSqlProperty { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlTable CurrentSqlTable { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentStage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Stage CurrentStage { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentStageTransition.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StageTransition CurrentStageTransition { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentState.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public State CurrentState { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentStateModel.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StateModel CurrentStateModel { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentStateTransition.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StateTransition CurrentStateTransition { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentStep.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Step CurrentStep { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentStepTransition.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StepTransition CurrentStepTransition { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentValue.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Value CurrentValue { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentWorkflow.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Workflow CurrentWorkflow { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentXmlAttribute.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlAttribute CurrentXmlAttribute { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentXmlDocument.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlDocument CurrentXmlDocument { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentXmlNode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlNode CurrentXmlNode { get; set; }
		#endregion "Interpreter"
		
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
			
			error = GetValidationError("SolutionName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Namespace");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("OutputSolutionFileName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("CompanyName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ProductName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ProductVersion");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("TemplatePath");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("UseRelativePaths");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsAutoUpdated");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Copyright");
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
				case "_solutionName":
				case "SolutionName":
					error = ValidateSolutionName();
					break;
				case "_namespace":
				case "Namespace":
					error = ValidateNamespace();
					break;
				case "_outputSolutionFileName":
				case "OutputSolutionFileName":
					error = ValidateOutputSolutionFileName();
					break;
				case "_companyName":
				case "CompanyName":
					error = ValidateCompanyName();
					break;
				case "_productName":
				case "ProductName":
					error = ValidateProductName();
					break;
				case "_productVersion":
				case "ProductVersion":
					error = ValidateProductVersion();
					break;
				case "_templatePath":
				case "TemplatePath":
					error = ValidateTemplatePath();
					break;
				case "_useRelativePaths":
				case "UseRelativePaths":
					error = ValidateUseRelativePaths();
					break;
				case "_isAutoUpdated":
				case "IsAutoUpdated":
					error = ValidateIsAutoUpdated();
					break;
				case "_copyright":
				case "Copyright":
					error = ValidateCopyright();
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
		/// <summary>This method validates SolutionName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSolutionName()
		{
			if (!Regex.IsMatch(SolutionName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "SolutionName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Namespace and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNamespace()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates OutputSolutionFileName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateOutputSolutionFileName()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates CompanyName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateCompanyName()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ProductName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateProductName()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ProductVersion and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateProductVersion()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates TemplatePath and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateTemplatePath()
		{
			if (!String.IsNullOrEmpty(TemplatePath) && !Regex.IsMatch(TemplatePath, Resources.DisplayValues.Regex_FilePath))
			{
				return String.Format(Resources.DisplayValues.Validation_PathValue, "TemplatePath");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates UseRelativePaths and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateUseRelativePaths()
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
		/// <summary>This method validates Copyright and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateCopyright()
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
		
		private Solution _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Solution ForwardInstance
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
		
		private Solution _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new Solution ReverseInstance
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
				return SolutionID;
			}
			set
			{
				SolutionID = value;
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
				return SolutionName;
			}
			set
			{
				SolutionName = value;
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
				return SourceSolution.SolutionName;
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
					_displayName = SolutionName;
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
					_defaultSourceName = DefaultSourcePrefix + SourceSolution.SolutionName;
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
		public Solution SourceSolution
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
		/// <summary>This property gets/sets the OldSolutionID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldSolutionID { get; set; }
		
		
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
					_isModified = true;
					base.OnPropertyChanged("SolutionID");
				}
			}
		}
		
		protected string _solutionName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SolutionName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SolutionName
		{
			get
			{
				return _solutionName;
			}
			set
			{
				if (_solutionName != value)
				{
					_solutionName = value;
					_isModified = true;
					base.OnPropertyChanged("SolutionName");
				}
			}
		}
		
		protected string _namespace = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Namespace.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string Namespace
		{
			get
			{
				return _namespace;
			}
			set
			{
				if (_namespace != value)
				{
					_namespace = value;
					_isModified = true;
					base.OnPropertyChanged("Namespace");
				}
			}
		}
		
		protected string _outputSolutionFileName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OutputSolutionFileName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string OutputSolutionFileName
		{
			get
			{
				return _outputSolutionFileName;
			}
			set
			{
				if (_outputSolutionFileName != value)
				{
					_outputSolutionFileName = value;
					_isModified = true;
					base.OnPropertyChanged("OutputSolutionFileName");
				}
			}
		}
		
		protected string _companyName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CompanyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string CompanyName
		{
			get
			{
				return _companyName;
			}
			set
			{
				if (_companyName != value)
				{
					_companyName = value;
					_isModified = true;
					base.OnPropertyChanged("CompanyName");
				}
			}
		}
		
		protected string _productName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ProductName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string ProductName
		{
			get
			{
				return _productName;
			}
			set
			{
				if (_productName != value)
				{
					_productName = value;
					_isModified = true;
					base.OnPropertyChanged("ProductName");
				}
			}
		}
		
		protected string _productVersion = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ProductVersion.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string ProductVersion
		{
			get
			{
				return _productVersion;
			}
			set
			{
				if (_productVersion != value)
				{
					_productVersion = value;
					_isModified = true;
					base.OnPropertyChanged("ProductVersion");
				}
			}
		}
		
		protected string _templatePath = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplatePath.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string TemplatePath
		{
			get
			{
				return _templatePath;
			}
			set
			{
				if (_templatePath != value)
				{
					#region protected
					if (UseRelativePaths == true && !String.IsNullOrEmpty(SolutionDirectory) && System.IO.File.Exists(value) == true)
					{
						try
						{
							System.Uri uri1 = new Uri(value);
							System.Uri uri2 = new Uri(SolutionDirectory + "\\");

							Uri relativeUri = uri2.MakeRelativeUri(uri1);
							_templatePath = relativeUri.ToString().Replace("/", "\\");
						}
						catch
						{
							_templatePath = value;
						}
					}
					else
					{
						_templatePath = value;
					}
					_isModified = true;
					#endregion protected
					base.OnPropertyChanged("TemplatePath");
				}
			}
		}
		
		protected bool _useRelativePaths = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UseRelativePaths.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool UseRelativePaths
		{
			get
			{
				return _useRelativePaths;
			}
			set
			{
				if (_useRelativePaths != value)
				{
					_useRelativePaths = value;
					_isModified = true;
					base.OnPropertyChanged("UseRelativePaths");
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
		
		protected string _copyright = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Copyright.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string Copyright
		{
			get
			{
				return _copyright;
			}
			set
			{
				if (_copyright != value)
				{
					_copyright = value;
					_isModified = true;
					base.OnPropertyChanged("Copyright");
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
		
		protected EnterpriseDataObjectList<BLL.Solutions.SpecificationSource> _specificationSourceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.SpecificationSource> SpecificationSourceList
		{
			get
			{
				if (_specificationSourceList == null)
				{
					_specificationSourceList = new EnterpriseDataObjectList<BLL.Solutions.SpecificationSource>();
				}
				return _specificationSourceList;
			}
			set
			{
				if (_specificationSourceList == null || _specificationSourceList.Equals(value) == false)
				{
					_specificationSourceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "SpecificationSourceList")]
		[XmlArrayItem(typeof(BLL.Solutions.SpecificationSource), ElementName = "SpecificationSource")]
		[DataMember(Name = "SpecificationSourceList")]
		[DataArrayItem(ElementName = "SpecificationSourceList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.SpecificationSource> _S_SpecificationSourceList
		{
			get
			{
				return _specificationSourceList;
			}
			set
			{
				_specificationSourceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Interpreter.Template> _templateList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Interpreter.Template> TemplateList
		{
			get
			{
				if (_templateList == null)
				{
					_templateList = new EnterpriseDataObjectList<BLL.Interpreter.Template>();
				}
				return _templateList;
			}
			set
			{
				if (_templateList == null || _templateList.Equals(value) == false)
				{
					_templateList = value;
				}
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Collection> _collectionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Collection> CollectionList
		{
			get
			{
				if (_collectionList == null)
				{
					_collectionList = new EnterpriseDataObjectList<BLL.Entities.Collection>();
				}
				return _collectionList;
			}
			set
			{
				if (_collectionList == null || _collectionList.Equals(value) == false)
				{
					_collectionList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "CollectionList")]
		[XmlArrayItem(typeof(BLL.Entities.Collection), ElementName = "Collection")]
		[DataMember(Name = "CollectionList")]
		[DataArrayItem(ElementName = "CollectionList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Collection> _S_CollectionList
		{
			get
			{
				return _collectionList;
			}
			set
			{
				_collectionList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.PropertyReference> _propertyReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> PropertyReferenceList
		{
			get
			{
				if (_propertyReferenceList == null)
				{
					_propertyReferenceList = new EnterpriseDataObjectList<BLL.Entities.PropertyReference>();
				}
				return _propertyReferenceList;
			}
			set
			{
				if (_propertyReferenceList == null || _propertyReferenceList.Equals(value) == false)
				{
					_propertyReferenceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyReferenceList")]
		[XmlArrayItem(typeof(BLL.Entities.PropertyReference), ElementName = "PropertyReference")]
		[DataMember(Name = "PropertyReferenceList")]
		[DataArrayItem(ElementName = "PropertyReferenceList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> _S_PropertyReferenceList
		{
			get
			{
				return _propertyReferenceList;
			}
			set
			{
				_propertyReferenceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Solutions.PropertyBase> _propertyBaseList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.PropertyBase> PropertyBaseList
		{
			get
			{
				if (_propertyBaseList == null)
				{
					_propertyBaseList = new EnterpriseDataObjectList<BLL.Solutions.PropertyBase>();
				}
				return _propertyBaseList;
			}
			set
			{
				if (_propertyBaseList == null || _propertyBaseList.Equals(value) == false)
				{
					_propertyBaseList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyBaseList")]
		[XmlArrayItem(typeof(BLL.Solutions.PropertyBase), ElementName = "PropertyBase")]
		[DataMember(Name = "PropertyBaseList")]
		[DataArrayItem(ElementName = "PropertyBaseList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.PropertyBase> _S_PropertyBaseList
		{
			get
			{
				return _propertyBaseList;
			}
			set
			{
				_propertyBaseList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.Property> _propertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Property> PropertyList
		{
			get
			{
				if (_propertyList == null)
				{
					_propertyList = new EnterpriseDataObjectList<BLL.Entities.Property>();
				}
				return _propertyList;
			}
			set
			{
				if (_propertyList == null || _propertyList.Equals(value) == false)
				{
					_propertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "PropertyList")]
		[XmlArrayItem(typeof(BLL.Entities.Property), ElementName = "Property")]
		[DataMember(Name = "PropertyList")]
		[DataArrayItem(ElementName = "PropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.Property> _S_PropertyList
		{
			get
			{
				return _propertyList;
			}
			set
			{
				_propertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Entities.EntityReference> _entityReferenceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.EntityReference> EntityReferenceList
		{
			get
			{
				if (_entityReferenceList == null)
				{
					_entityReferenceList = new EnterpriseDataObjectList<BLL.Entities.EntityReference>();
				}
				return _entityReferenceList;
			}
			set
			{
				if (_entityReferenceList == null || _entityReferenceList.Equals(value) == false)
				{
					_entityReferenceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "EntityReferenceList")]
		[XmlArrayItem(typeof(BLL.Entities.EntityReference), ElementName = "EntityReference")]
		[DataMember(Name = "EntityReferenceList")]
		[DataArrayItem(ElementName = "EntityReferenceList")]
		public virtual EnterpriseDataObjectList<BLL.Entities.EntityReference> _S_EntityReferenceList
		{
			get
			{
				return _entityReferenceList;
			}
			set
			{
				_entityReferenceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Solutions.DatabaseSource> _databaseSourceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.DatabaseSource> DatabaseSourceList
		{
			get
			{
				if (_databaseSourceList == null)
				{
					_databaseSourceList = new EnterpriseDataObjectList<BLL.Solutions.DatabaseSource>();
				}
				return _databaseSourceList;
			}
			set
			{
				if (_databaseSourceList == null || _databaseSourceList.Equals(value) == false)
				{
					_databaseSourceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "DatabaseSourceList")]
		[XmlArrayItem(typeof(BLL.Solutions.DatabaseSource), ElementName = "DatabaseSource")]
		[DataMember(Name = "DatabaseSourceList")]
		[DataArrayItem(ElementName = "DatabaseSourceList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.DatabaseSource> _S_DatabaseSourceList
		{
			get
			{
				return _databaseSourceList;
			}
			set
			{
				_databaseSourceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Solutions.XmlSource> _xmlSourceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.XmlSource> XmlSourceList
		{
			get
			{
				if (_xmlSourceList == null)
				{
					_xmlSourceList = new EnterpriseDataObjectList<BLL.Solutions.XmlSource>();
				}
				return _xmlSourceList;
			}
			set
			{
				if (_xmlSourceList == null || _xmlSourceList.Equals(value) == false)
				{
					_xmlSourceList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "XmlSourceList")]
		[XmlArrayItem(typeof(BLL.Solutions.XmlSource), ElementName = "XmlSource")]
		[DataMember(Name = "XmlSourceList")]
		[DataArrayItem(ElementName = "XmlSourceList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.XmlSource> _S_XmlSourceList
		{
			get
			{
				return _xmlSourceList;
			}
			set
			{
				_xmlSourceList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Solutions.Project> _projectList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.Project> ProjectList
		{
			get
			{
				if (_projectList == null)
				{
					_projectList = new EnterpriseDataObjectList<BLL.Solutions.Project>();
				}
				return _projectList;
			}
			set
			{
				if (_projectList == null || _projectList.Equals(value) == false)
				{
					_projectList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ProjectList")]
		[XmlArrayItem(typeof(BLL.Solutions.Project), ElementName = "Project")]
		[DataMember(Name = "ProjectList")]
		[DataArrayItem(ElementName = "ProjectList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.Project> _S_ProjectList
		{
			get
			{
				return _projectList;
			}
			set
			{
				_projectList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Solutions.Feature> _featureList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.Feature> FeatureList
		{
			get
			{
				if (_featureList == null)
				{
					_featureList = new EnterpriseDataObjectList<BLL.Solutions.Feature>();
				}
				return _featureList;
			}
			set
			{
				if (_featureList == null || _featureList.Equals(value) == false)
				{
					_featureList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "FeatureList")]
		[XmlArrayItem(typeof(BLL.Solutions.Feature), ElementName = "Feature")]
		[DataMember(Name = "FeatureList")]
		[DataArrayItem(ElementName = "FeatureList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.Feature> _S_FeatureList
		{
			get
			{
				return _featureList;
			}
			set
			{
				_featureList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Workflows.Workflow> _workflowList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Workflows.Workflow> WorkflowList
		{
			get
			{
				if (_workflowList == null)
				{
					_workflowList = new EnterpriseDataObjectList<BLL.Workflows.Workflow>();
				}
				return _workflowList;
			}
			set
			{
				if (_workflowList == null || _workflowList.Equals(value) == false)
				{
					_workflowList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "WorkflowList")]
		[XmlArrayItem(typeof(BLL.Workflows.Workflow), ElementName = "Workflow")]
		[DataMember(Name = "WorkflowList")]
		[DataArrayItem(ElementName = "WorkflowList")]
		public virtual EnterpriseDataObjectList<BLL.Workflows.Workflow> _S_WorkflowList
		{
			get
			{
				return _workflowList;
			}
			set
			{
				_workflowList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Models.Model> _modelList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Models.Model> ModelList
		{
			get
			{
				if (_modelList == null)
				{
					_modelList = new EnterpriseDataObjectList<BLL.Models.Model>();
				}
				return _modelList;
			}
			set
			{
				if (_modelList == null || _modelList.Equals(value) == false)
				{
					_modelList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "ModelList")]
		[XmlArrayItem(typeof(BLL.Models.Model), ElementName = "Model")]
		[DataMember(Name = "ModelList")]
		[DataArrayItem(ElementName = "ModelList")]
		public virtual EnterpriseDataObjectList<BLL.Models.Model> _S_ModelList
		{
			get
			{
				return _modelList;
			}
			set
			{
				_modelList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Diagrams.Diagram> _diagramList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Diagrams.Diagram> DiagramList
		{
			get
			{
				if (_diagramList == null)
				{
					_diagramList = new EnterpriseDataObjectList<BLL.Diagrams.Diagram>();
				}
				return _diagramList;
			}
			set
			{
				if (_diagramList == null || _diagramList.Equals(value) == false)
				{
					_diagramList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "DiagramList")]
		[XmlArrayItem(typeof(BLL.Diagrams.Diagram), ElementName = "Diagram")]
		[DataMember(Name = "DiagramList")]
		[DataArrayItem(ElementName = "DiagramList")]
		public virtual EnterpriseDataObjectList<BLL.Diagrams.Diagram> _S_DiagramList
		{
			get
			{
				return _diagramList;
			}
			set
			{
				_diagramList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Solutions.AuditProperty> _auditPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.AuditProperty> AuditPropertyList
		{
			get
			{
				if (_auditPropertyList == null)
				{
					_auditPropertyList = new EnterpriseDataObjectList<BLL.Solutions.AuditProperty>();
				}
				return _auditPropertyList;
			}
			set
			{
				if (_auditPropertyList == null || _auditPropertyList.Equals(value) == false)
				{
					_auditPropertyList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "AuditPropertyList")]
		[XmlArrayItem(typeof(BLL.Solutions.AuditProperty), ElementName = "AuditProperty")]
		[DataMember(Name = "AuditPropertyList")]
		[DataArrayItem(ElementName = "AuditPropertyList")]
		public virtual EnterpriseDataObjectList<BLL.Solutions.AuditProperty> _S_AuditPropertyList
		{
			get
			{
				return _auditPropertyList;
			}
			set
			{
				_auditPropertyList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Interpreter.SpecTemplate> _specTemplateList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Interpreter.SpecTemplate> SpecTemplateList
		{
			get
			{
				if (_specTemplateList == null)
				{
					_specTemplateList = new EnterpriseDataObjectList<BLL.Interpreter.SpecTemplate>();
				}
				return _specTemplateList;
			}
			set
			{
				if (_specTemplateList == null || _specTemplateList.Equals(value) == false)
				{
					_specTemplateList = value;
				}
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Interpreter.CodeTemplate> _codeTemplateList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Interpreter.CodeTemplate> CodeTemplateList
		{
			get
			{
				if (_codeTemplateList == null)
				{
					_codeTemplateList = new EnterpriseDataObjectList<BLL.Interpreter.CodeTemplate>();
				}
				return _codeTemplateList;
			}
			set
			{
				if (_codeTemplateList == null || _codeTemplateList.Equals(value) == false)
				{
					_codeTemplateList = value;
				}
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
				return "SolutionID";
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
				return SolutionID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					SolutionID = primaryKeyValues[0].GetGuid();
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
				if (_specificationSourceList != null && _specificationSourceList.IsModified == true) return true;
				if (_collectionList != null && _collectionList.IsModified == true) return true;
				if (_propertyReferenceList != null && _propertyReferenceList.IsModified == true) return true;
				if (_propertyBaseList != null && _propertyBaseList.IsModified == true) return true;
				if (_propertyList != null && _propertyList.IsModified == true) return true;
				if (_entityReferenceList != null && _entityReferenceList.IsModified == true) return true;
				if (_databaseSourceList != null && _databaseSourceList.IsModified == true) return true;
				if (_xmlSourceList != null && _xmlSourceList.IsModified == true) return true;
				if (_projectList != null && _projectList.IsModified == true) return true;
				if (_featureList != null && _featureList.IsModified == true) return true;
				if (_workflowList != null && _workflowList.IsModified == true) return true;
				if (_modelList != null && _modelList.IsModified == true) return true;
				if (_diagramList != null && _diagramList.IsModified == true) return true;
				if (_auditPropertyList != null && _auditPropertyList.IsModified == true) return true;
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
				ReverseInstance = new Solution();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new Solution();
				ForwardInstance.SolutionID = SolutionID;
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
			foreach (Collection collection in CollectionList)
			{
				collection.AddItemToUsedTags(usedTags);
			}
			foreach (PropertyReference propertyReference in PropertyReferenceList)
			{
				propertyReference.AddItemToUsedTags(usedTags);
			}
			foreach (Property property in PropertyList)
			{
				property.AddItemToUsedTags(usedTags);
			}
			foreach (EntityReference entityReference in EntityReferenceList)
			{
				entityReference.AddItemToUsedTags(usedTags);
			}
			foreach (DatabaseSource databaseSource in DatabaseSourceList)
			{
				databaseSource.AddItemToUsedTags(usedTags);
			}
			foreach (XmlSource xmlSource in XmlSourceList)
			{
				xmlSource.AddItemToUsedTags(usedTags);
			}
			foreach (Project project in ProjectList)
			{
				project.AddItemToUsedTags(usedTags);
			}
			foreach (Feature feature in FeatureList)
			{
				feature.AddItemToUsedTags(usedTags);
			}
			foreach (Workflow workflow in WorkflowList)
			{
				workflow.AddItemToUsedTags(usedTags);
			}
			foreach (Model model in ModelList)
			{
				model.AddItemToUsedTags(usedTags);
			}
			foreach (Diagram diagram in DiagramList)
			{
				diagram.AddItemToUsedTags(usedTags);
			}
			foreach (AuditProperty auditProperty in AuditPropertyList)
			{
				auditProperty.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputSolution">The solution to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(Solution inputSolution)
		{
			if (SolutionName.GetString() != inputSolution.SolutionName.GetString()) return false;
			if (Namespace.GetString() != inputSolution.Namespace.GetString()) return false;
			if (OutputSolutionFileName.GetString() != inputSolution.OutputSolutionFileName.GetString()) return false;
			if (CompanyName.GetString() != inputSolution.CompanyName.GetString()) return false;
			if (ProductName.GetString() != inputSolution.ProductName.GetString()) return false;
			if (ProductVersion.GetString() != inputSolution.ProductVersion.GetString()) return false;
			if (TemplatePath.GetString() != inputSolution.TemplatePath.GetString()) return false;
			if (UseRelativePaths.GetBool() != inputSolution.UseRelativePaths.GetBool()) return false;
			if (IsAutoUpdated.GetBool() != inputSolution.IsAutoUpdated.GetBool()) return false;
			if (Copyright.GetString() != inputSolution.Copyright.GetString()) return false;
			if (Description.GetString() != inputSolution.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputSolution">The solution to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(Solution inputSolution)
		{
			if (inputSolution == null) return true;
			if (inputSolution.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputSolution.SolutionName)) return false;
			if (!String.IsNullOrEmpty(inputSolution.Namespace)) return false;
			if (!String.IsNullOrEmpty(inputSolution.OutputSolutionFileName)) return false;
			if (!String.IsNullOrEmpty(inputSolution.CompanyName)) return false;
			if (!String.IsNullOrEmpty(inputSolution.ProductName)) return false;
			if (!String.IsNullOrEmpty(inputSolution.ProductVersion)) return false;
			if (!String.IsNullOrEmpty(inputSolution.TemplatePath)) return false;
			if (UseRelativePaths != inputSolution.UseRelativePaths) return false;
			if (IsAutoUpdated != inputSolution.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputSolution.Copyright)) return false;
			if (!String.IsNullOrEmpty(inputSolution.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputSolution">The solution to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(Solution inputSolution)
		{
			SolutionName = inputSolution.SolutionName;
			Namespace = inputSolution.Namespace;
			OutputSolutionFileName = inputSolution.OutputSolutionFileName;
			CompanyName = inputSolution.CompanyName;
			ProductName = inputSolution.ProductName;
			ProductVersion = inputSolution.ProductVersion;
			TemplatePath = inputSolution.TemplatePath;
			UseRelativePaths = inputSolution.UseRelativePaths;
			IsAutoUpdated = inputSolution.IsAutoUpdated;
			Copyright = inputSolution.Copyright;
			Description = inputSolution.Description;
			
			#region protected
			#endregion protected
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
			if (_specificationSourceList != null)
			{
				foreach (SpecificationSource item in SpecificationSourceList)
				{
					item.Dispose();
				}
				SpecificationSourceList.Clear();
				SpecificationSourceList = null;
			}
			if (_templateList != null)
			{
				foreach (Template item in TemplateList)
				{
					item.Dispose();
				}
				TemplateList.Clear();
				TemplateList = null;
			}
			if (_collectionList != null)
			{
				foreach (Collection item in CollectionList)
				{
					item.Dispose();
				}
				CollectionList.Clear();
				CollectionList = null;
			}
			if (_propertyReferenceList != null)
			{
				foreach (PropertyReference item in PropertyReferenceList)
				{
					item.Dispose();
				}
				PropertyReferenceList.Clear();
				PropertyReferenceList = null;
			}
			if (_propertyBaseList != null)
			{
				foreach (PropertyBase item in PropertyBaseList)
				{
					item.Dispose();
				}
				PropertyBaseList.Clear();
				PropertyBaseList = null;
			}
			if (_propertyList != null)
			{
				foreach (Property item in PropertyList)
				{
					item.Dispose();
				}
				PropertyList.Clear();
				PropertyList = null;
			}
			if (_entityReferenceList != null)
			{
				foreach (EntityReference item in EntityReferenceList)
				{
					item.Dispose();
				}
				EntityReferenceList.Clear();
				EntityReferenceList = null;
			}
			if (_databaseSourceList != null)
			{
				foreach (DatabaseSource item in DatabaseSourceList)
				{
					item.Dispose();
				}
				DatabaseSourceList.Clear();
				DatabaseSourceList = null;
			}
			if (_xmlSourceList != null)
			{
				foreach (XmlSource item in XmlSourceList)
				{
					item.Dispose();
				}
				XmlSourceList.Clear();
				XmlSourceList = null;
			}
			if (_projectList != null)
			{
				foreach (Project item in ProjectList)
				{
					item.Dispose();
				}
				ProjectList.Clear();
				ProjectList = null;
			}
			if (_featureList != null)
			{
				foreach (Feature item in FeatureList)
				{
					item.Dispose();
				}
				FeatureList.Clear();
				FeatureList = null;
			}
			if (_workflowList != null)
			{
				foreach (Workflow item in WorkflowList)
				{
					item.Dispose();
				}
				WorkflowList.Clear();
				WorkflowList = null;
			}
			if (_modelList != null)
			{
				foreach (Model item in ModelList)
				{
					item.Dispose();
				}
				ModelList.Clear();
				ModelList = null;
			}
			if (_diagramList != null)
			{
				foreach (Diagram item in DiagramList)
				{
					item.Dispose();
				}
				DiagramList.Clear();
				DiagramList = null;
			}
			if (_auditPropertyList != null)
			{
				foreach (AuditProperty item in AuditPropertyList)
				{
					item.Dispose();
				}
				AuditPropertyList.Clear();
				AuditPropertyList = null;
			}
			if (_specTemplateList != null)
			{
				foreach (SpecTemplate item in SpecTemplateList)
				{
					item.Dispose();
				}
				SpecTemplateList.Clear();
				SpecTemplateList = null;
			}
			if (_codeTemplateList != null)
			{
				foreach (CodeTemplate item in CodeTemplateList)
				{
					item.Dispose();
				}
				CodeTemplateList.Clear();
				CodeTemplateList = null;
			}
			
			#region protected
			if (SpecTemplates != null)
			{
				for (int i = 0; i < SpecTemplates.Count; i++)
				{
					if (SpecTemplates[i] is SpecTemplate)
					{
						(SpecTemplates[i] as SpecTemplate).Dispose();
					}
				}
				SpecTemplates.Clear();
			}
			if (CodeTemplates != null)
			{
				for (int i = 0; i < CodeTemplates.Count; i++)
				{
					if (CodeTemplates[i] is CodeTemplate)
					{
						(CodeTemplates[i] as CodeTemplate).Dispose();
					}
				}
				CodeTemplates.Clear();
			}
			DisposeCore();
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
					ReverseInstance = new Solution();
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
			newItem.ItemID = SolutionID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Solution GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			Solution forwardItem = new Solution();
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
				forwardItem.SolutionID = SolutionID;
			}
			foreach (Collection item in CollectionList)
			{
				Collection forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.CollectionList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (PropertyReference item in PropertyReferenceList)
			{
				PropertyReference forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyReferenceList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Property item in PropertyList)
			{
				Property forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.PropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (EntityReference item in EntityReferenceList)
			{
				EntityReference forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.EntityReferenceList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (DatabaseSource item in DatabaseSourceList)
			{
				DatabaseSource forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.DatabaseSourceList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (XmlSource item in XmlSourceList)
			{
				XmlSource forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.XmlSourceList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Project item in ProjectList)
			{
				item.Solution = this;
				Project forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ProjectList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Feature item in FeatureList)
			{
				item.Solution = this;
				Feature forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.FeatureList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Workflow item in WorkflowList)
			{
				item.Solution = this;
				Workflow forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.WorkflowList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Model item in ModelList)
			{
				item.Solution = this;
				Model forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.ModelList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (Diagram item in DiagramList)
			{
				item.Solution = this;
				Diagram forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.DiagramList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (AuditProperty item in AuditPropertyList)
			{
				AuditProperty forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.AuditPropertyList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (SpecTemplate item in SpecTemplateList)
			{
				SpecTemplate forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.SpecTemplateList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (CodeTemplate item in CodeTemplateList)
			{
				CodeTemplate forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.CodeTemplateList.Add(forwardChildItem);
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
			isValidContext = true;
			return solutionContext;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this item.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public static IEnterpriseEnumerable GetCollectionContext(Solution solutionContext, IDomainEnterpriseObject modelContext)
		{
			EnterpriseDataObjectList<Solution> solutions = new EnterpriseDataObjectList<Solution>();
			solutions.Add(solutionContext);
			return solutions;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the Solution instance from an xml file.</summary>
		///
		/// <param name="inputFilePath">The path of the file to load from.</param>
		///--------------------------------------------------------------------------------
		public override void Load(string inputFilePath)
		{
			base.Load(inputFilePath);
			SolutionDirectory = System.IO.Directory.GetParent(inputFilePath).FullName;
			ResetLoaded(true);
			ResetModified(false);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method saves the Solution instance to an xml file.</summary>
		///
		/// <param name="inputFilePath">The path of the file to save to.</param>
		///--------------------------------------------------------------------------------
		public override void Save(string inputFilePath)
		{
			base.Save(inputFilePath);
			SolutionDirectory = System.IO.Directory.GetParent(inputFilePath).FullName;
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
			if (_specificationSourceList != null) _specificationSourceList.ResetLoaded(isLoaded);
			if (_templateList != null) _templateList.ResetLoaded(isLoaded);
			if (_collectionList != null) _collectionList.ResetLoaded(isLoaded);
			if (_propertyReferenceList != null) _propertyReferenceList.ResetLoaded(isLoaded);
			if (_propertyBaseList != null) _propertyBaseList.ResetLoaded(isLoaded);
			if (_propertyList != null) _propertyList.ResetLoaded(isLoaded);
			if (_entityReferenceList != null) _entityReferenceList.ResetLoaded(isLoaded);
			if (_databaseSourceList != null) _databaseSourceList.ResetLoaded(isLoaded);
			if (_xmlSourceList != null) _xmlSourceList.ResetLoaded(isLoaded);
			if (_projectList != null) _projectList.ResetLoaded(isLoaded);
			if (_featureList != null) _featureList.ResetLoaded(isLoaded);
			if (_workflowList != null) _workflowList.ResetLoaded(isLoaded);
			if (_modelList != null) _modelList.ResetLoaded(isLoaded);
			if (_diagramList != null) _diagramList.ResetLoaded(isLoaded);
			if (_auditPropertyList != null) _auditPropertyList.ResetLoaded(isLoaded);
			if (_specTemplateList != null) _specTemplateList.ResetLoaded(isLoaded);
			if (_codeTemplateList != null) _codeTemplateList.ResetLoaded(isLoaded);
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
			if (_specificationSourceList != null) _specificationSourceList.ResetModified(isModified);
			if (_templateList != null) _templateList.ResetModified(isModified);
			if (_collectionList != null) _collectionList.ResetModified(isModified);
			if (_propertyReferenceList != null) _propertyReferenceList.ResetModified(isModified);
			if (_propertyBaseList != null) _propertyBaseList.ResetModified(isModified);
			if (_propertyList != null) _propertyList.ResetModified(isModified);
			if (_entityReferenceList != null) _entityReferenceList.ResetModified(isModified);
			if (_databaseSourceList != null) _databaseSourceList.ResetModified(isModified);
			if (_xmlSourceList != null) _xmlSourceList.ResetModified(isModified);
			if (_projectList != null) _projectList.ResetModified(isModified);
			if (_featureList != null) _featureList.ResetModified(isModified);
			if (_workflowList != null) _workflowList.ResetModified(isModified);
			if (_modelList != null) _modelList.ResetModified(isModified);
			if (_diagramList != null) _diagramList.ResetModified(isModified);
			if (_auditPropertyList != null) _auditPropertyList.ResetModified(isModified);
			if (_specTemplateList != null) _specTemplateList.ResetModified(isModified);
			if (_codeTemplateList != null) _codeTemplateList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public Solution(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Solution instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public Solution(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic Solution instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="solutionID">The input value for SolutionID.</param>
		///--------------------------------------------------------------------------------
		public Solution(Guid solutionID)
		{
			SolutionID = solutionID;
		}
		#endregion "Constructors"
	}
}