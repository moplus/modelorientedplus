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
	/// specific XmlDocument instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/20/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="XmlDocument")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class XmlDocument : BusinessObjectBase
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
			
			error = GetValidationError("XmlDocumentName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("LocalName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Value");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("BaseURI");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("NamespaceURI");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("DocumentType");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("NodeType");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("InnerText");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("InnerXml");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("OuterXml");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("SchemaInfo");
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
				case "_xmlDocumentName":
				case "XmlDocumentName":
					error = ValidateXmlDocumentName();
					break;
				case "_localName":
				case "LocalName":
					error = ValidateLocalName();
					break;
				case "_value":
				case "Value":
					error = ValidateValue();
					break;
				case "_baseURI":
				case "BaseURI":
					error = ValidateBaseURI();
					break;
				case "_namespaceURI":
				case "NamespaceURI":
					error = ValidateNamespaceURI();
					break;
				case "_documentType":
				case "DocumentType":
					error = ValidateDocumentType();
					break;
				case "_nodeType":
				case "NodeType":
					error = ValidateNodeType();
					break;
				case "_innerText":
				case "InnerText":
					error = ValidateInnerText();
					break;
				case "_innerXml":
				case "InnerXml":
					error = ValidateInnerXml();
					break;
				case "_outerXml":
				case "OuterXml":
					error = ValidateOuterXml();
					break;
				case "_schemaInfo":
				case "SchemaInfo":
					error = ValidateSchemaInfo();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates XmlDocumentName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateXmlDocumentName()
		{
			if (!Regex.IsMatch(XmlDocumentName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "XmlDocumentName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates LocalName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateLocalName()
		{
			if (!Regex.IsMatch(LocalName, Resources.DisplayValues.Regex_LooseName))
			{
				return String.Format(Resources.DisplayValues.Validation_LooseNameValue, "LocalName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Value and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateValue()
		{
			if (String.IsNullOrEmpty(Value))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Value");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates BaseURI and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateBaseURI()
		{
			if (String.IsNullOrEmpty(BaseURI))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "BaseURI");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates NamespaceURI and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNamespaceURI()
		{
			if (String.IsNullOrEmpty(NamespaceURI))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "NamespaceURI");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DocumentType and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDocumentType()
		{
			if (String.IsNullOrEmpty(DocumentType))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "DocumentType");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates NodeType and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateNodeType()
		{
			if (String.IsNullOrEmpty(NodeType))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "NodeType");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates InnerText and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateInnerText()
		{
			if (String.IsNullOrEmpty(InnerText))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "InnerText");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates InnerXml and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateInnerXml()
		{
			if (String.IsNullOrEmpty(InnerXml))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "InnerXml");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates OuterXml and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateOuterXml()
		{
			if (String.IsNullOrEmpty(OuterXml))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "OuterXml");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates SchemaInfo and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateSchemaInfo()
		{
			if (String.IsNullOrEmpty(SchemaInfo))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "SchemaInfo");
			}
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private XmlDocument _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlDocument ForwardInstance
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
		
		private XmlDocument _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new XmlDocument ReverseInstance
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
				return XmlDocumentID;
			}
			set
			{
				XmlDocumentID = value;
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
				return XmlDocumentName;
			}
			set
			{
				XmlDocumentName = value;
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
				return SourceXmlDocument.XmlDocumentName;
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
					_displayName = XmlDocumentName;
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
					_defaultSourceName = DefaultSourcePrefix + SourceXmlDocument.XmlDocumentName;
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
		public XmlDocument SourceXmlDocument
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
		/// <summary>This property gets/sets the OldXmlDocumentID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldXmlDocumentID { get; set; }
		
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
		
		protected Guid _xmlDocumentID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlDocumentID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid XmlDocumentID
		{
			get
			{
				return _xmlDocumentID;
			}
			set
			{
				if (_xmlDocumentID != value)
				{
					_xmlDocumentID = value;
					_isModified = true;
					base.OnPropertyChanged("XmlDocumentID");
				}
			}
		}
		
		protected string _xmlDocumentName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlDocumentName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string XmlDocumentName
		{
			get
			{
				return _xmlDocumentName;
			}
			set
			{
				if (_xmlDocumentName != value)
				{
					_xmlDocumentName = value;
					_isModified = true;
					base.OnPropertyChanged("XmlDocumentName");
				}
			}
		}
		
		protected string _localName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LocalName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string LocalName
		{
			get
			{
				return _localName;
			}
			set
			{
				if (_localName != value)
				{
					_localName = value;
					_isModified = true;
					base.OnPropertyChanged("LocalName");
				}
			}
		}
		
		protected string _value = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Value.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (_value != value)
				{
					_value = value;
					_isModified = true;
					base.OnPropertyChanged("Value");
				}
			}
		}
		
		protected string _baseURI = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BaseURI.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string BaseURI
		{
			get
			{
				return _baseURI;
			}
			set
			{
				if (_baseURI != value)
				{
					_baseURI = value;
					_isModified = true;
					base.OnPropertyChanged("BaseURI");
				}
			}
		}
		
		protected string _namespaceURI = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NamespaceURI.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string NamespaceURI
		{
			get
			{
				return _namespaceURI;
			}
			set
			{
				if (_namespaceURI != value)
				{
					_namespaceURI = value;
					_isModified = true;
					base.OnPropertyChanged("NamespaceURI");
				}
			}
		}
		
		protected string _documentType = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DocumentType.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string DocumentType
		{
			get
			{
				return _documentType;
			}
			set
			{
				if (_documentType != value)
				{
					_documentType = value;
					_isModified = true;
					base.OnPropertyChanged("DocumentType");
				}
			}
		}
		
		protected string _nodeType = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NodeType.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string NodeType
		{
			get
			{
				return _nodeType;
			}
			set
			{
				if (_nodeType != value)
				{
					_nodeType = value;
					_isModified = true;
					base.OnPropertyChanged("NodeType");
				}
			}
		}
		
		protected string _innerText = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the InnerText.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string InnerText
		{
			get
			{
				return _innerText;
			}
			set
			{
				if (_innerText != value)
				{
					_innerText = value;
					_isModified = true;
					base.OnPropertyChanged("InnerText");
				}
			}
		}
		
		protected string _innerXml = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the InnerXml.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string InnerXml
		{
			get
			{
				return _innerXml;
			}
			set
			{
				if (_innerXml != value)
				{
					_innerXml = value;
					_isModified = true;
					base.OnPropertyChanged("InnerXml");
				}
			}
		}
		
		protected string _outerXml = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OuterXml.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string OuterXml
		{
			get
			{
				return _outerXml;
			}
			set
			{
				if (_outerXml != value)
				{
					_outerXml = value;
					_isModified = true;
					base.OnPropertyChanged("OuterXml");
				}
			}
		}
		
		protected string _schemaInfo = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SchemaInfo.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SchemaInfo
		{
			get
			{
				return _schemaInfo;
			}
			set
			{
				if (_schemaInfo != value)
				{
					_schemaInfo = value;
					_isModified = true;
					base.OnPropertyChanged("SchemaInfo");
				}
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.XmlAttribute> _xmlAttributeList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of XmlDocument.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.XmlAttribute> XmlAttributeList
		{
			get
			{
				if (_xmlAttributeList == null)
				{
					_xmlAttributeList = new EnterpriseDataObjectList<BLL.Specifications.XmlAttribute>();
				}
				return _xmlAttributeList;
			}
			set
			{
				if (_xmlAttributeList == null || _xmlAttributeList.Equals(value) == false)
				{
					_xmlAttributeList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "XmlAttributeList")]
		[XmlArrayItem(typeof(BLL.Specifications.XmlAttribute), ElementName = "XmlAttribute")]
		[DataMember(Name = "XmlAttributeList")]
		[DataArrayItem(ElementName = "XmlAttributeList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.XmlAttribute> _S_XmlAttributeList
		{
			get
			{
				return _xmlAttributeList;
			}
			set
			{
				_xmlAttributeList = value;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.XmlNode> _xmlNodeList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of XmlDocument.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Specifications.XmlNode> XmlNodeList
		{
			get
			{
				if (_xmlNodeList == null)
				{
					_xmlNodeList = new EnterpriseDataObjectList<BLL.Specifications.XmlNode>();
				}
				return _xmlNodeList;
			}
			set
			{
				if (_xmlNodeList == null || _xmlNodeList.Equals(value) == false)
				{
					_xmlNodeList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}
		[XmlArray(ElementName = "XmlNodeList")]
		[XmlArrayItem(typeof(BLL.Specifications.XmlNode), ElementName = "XmlNode")]
		[DataMember(Name = "XmlNodeList")]
		[DataArrayItem(ElementName = "XmlNodeList")]
		public virtual EnterpriseDataObjectList<BLL.Specifications.XmlNode> _S_XmlNodeList
		{
			get
			{
				return _xmlNodeList;
			}
			set
			{
				_xmlNodeList = value;
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
				return "XmlDocumentID";
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
				return XmlDocumentID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					XmlDocumentID = primaryKeyValues[0].GetGuid();
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
				if (_xmlAttributeList != null && _xmlAttributeList.IsModified == true) return true;
				if (_xmlNodeList != null && _xmlNodeList.IsModified == true) return true;
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
				ReverseInstance = new XmlDocument();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new XmlDocument();
				ForwardInstance.XmlDocumentID = XmlDocumentID;
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
			foreach (XmlAttribute xmlAttribute in XmlAttributeList)
			{
				xmlAttribute.AddItemToUsedTags(usedTags);
			}
			foreach (XmlNode xmlNode in XmlNodeList)
			{
				xmlNode.AddItemToUsedTags(usedTags);
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputXmlDocument">The xmldocument to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(XmlDocument inputXmlDocument)
		{
			if (XmlDocumentName.GetString() != inputXmlDocument.XmlDocumentName.GetString()) return false;
			if (LocalName.GetString() != inputXmlDocument.LocalName.GetString()) return false;
			if (Value.GetString() != inputXmlDocument.Value.GetString()) return false;
			if (BaseURI.GetString() != inputXmlDocument.BaseURI.GetString()) return false;
			if (NamespaceURI.GetString() != inputXmlDocument.NamespaceURI.GetString()) return false;
			if (DocumentType.GetString() != inputXmlDocument.DocumentType.GetString()) return false;
			if (NodeType.GetString() != inputXmlDocument.NodeType.GetString()) return false;
			if (InnerText.GetString() != inputXmlDocument.InnerText.GetString()) return false;
			if (InnerXml.GetString() != inputXmlDocument.InnerXml.GetString()) return false;
			if (OuterXml.GetString() != inputXmlDocument.OuterXml.GetString()) return false;
			if (SchemaInfo.GetString() != inputXmlDocument.SchemaInfo.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputXmlDocument">The xmldocument to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(XmlDocument inputXmlDocument)
		{
			if (inputXmlDocument == null) return true;
			if (inputXmlDocument.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.XmlDocumentName)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.LocalName)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.Value)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.BaseURI)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.NamespaceURI)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.DocumentType)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.NodeType)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.InnerText)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.InnerXml)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.OuterXml)) return false;
			if (!String.IsNullOrEmpty(inputXmlDocument.SchemaInfo)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputXmlDocument">The xmldocument to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(XmlDocument inputXmlDocument)
		{
			XmlDocumentName = inputXmlDocument.XmlDocumentName;
			LocalName = inputXmlDocument.LocalName;
			Value = inputXmlDocument.Value;
			BaseURI = inputXmlDocument.BaseURI;
			NamespaceURI = inputXmlDocument.NamespaceURI;
			DocumentType = inputXmlDocument.DocumentType;
			NodeType = inputXmlDocument.NodeType;
			InnerText = inputXmlDocument.InnerText;
			InnerXml = inputXmlDocument.InnerXml;
			OuterXml = inputXmlDocument.OuterXml;
			SchemaInfo = inputXmlDocument.SchemaInfo;
			
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
				XmlDocumentID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (XmlDocumentID == Guid.Empty)
				{
					XmlDocumentID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = XmlDocumentID;
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
			if (_xmlAttributeList != null)
			{
				foreach (XmlAttribute item in XmlAttributeList)
				{
					item.Dispose();
				}
				XmlAttributeList.Clear();
				XmlAttributeList = null;
			}
			if (_xmlNodeList != null)
			{
				foreach (XmlNode item in XmlNodeList)
				{
					item.Dispose();
				}
				XmlNodeList.Clear();
				XmlNodeList = null;
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
					ReverseInstance = new XmlDocument();
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
			newItem.ItemID = XmlDocumentID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public XmlDocument GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			XmlDocument forwardItem = new XmlDocument();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.XmlDocumentID = XmlDocumentID;
			}
			foreach (XmlAttribute item in XmlAttributeList)
			{
				item.XmlDocument = this;
				XmlAttribute forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.XmlAttributeList.Add(forwardChildItem);
					isCustomized = true;
				}
			}
			foreach (XmlNode item in XmlNodeList)
			{
				item.XmlDocument = this;
				XmlNode forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.XmlNodeList.Add(forwardChildItem);
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
				if (modelContext is XmlDocument)
				{
					return modelContext;
				}
				#region protected
				else if (modelContext is XmlSource)
				{
					XmlSource parent = modelContext as XmlSource;
					return parent.SpecDocument;
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			
			#region protected
			if (solutionContext.IsSampleMode == true && solutionContext.XmlSourceList.Count > 0)
			{
				return solutionContext.XmlSourceList[DataHelper.GetRandomInt(0, solutionContext.XmlSourceList.Count - 1)].SpecDocument;
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
				if (nodeContext is XmlSource)
				{
					EnterpriseDataObjectList<XmlDocument> documents = new EnterpriseDataObjectList<XmlDocument>();
					if ((nodeContext as XmlSource).SpecDocument != null)
					{
						documents.Add((nodeContext as XmlSource).SpecDocument);
					}
					return documents;
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<XmlDocument> documents = new EnterpriseDataObjectList<XmlDocument>();
					foreach (XmlSource source in (nodeContext as Solution).XmlSourceList)
					{
						if (source.SpecDocument != null)
						{
							documents.Add(source.SpecDocument);
						}
					}
					return documents;
				}
				#endregion protected
				
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the XmlDocument instance from an xml file.</summary>
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
		/// <summary>This method saves the XmlDocument instance to an xml file.</summary>
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
			if (_xmlAttributeList != null) _xmlAttributeList.ResetLoaded(isLoaded);
			if (_xmlNodeList != null) _xmlNodeList.ResetLoaded(isLoaded);
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
			if (_xmlAttributeList != null) _xmlAttributeList.ResetModified(isModified);
			if (_xmlNodeList != null) _xmlNodeList.ResetModified(isModified);
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public XmlDocument(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic XmlDocument instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public XmlDocument(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic XmlDocument instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="xmlDocumentID">The input value for XmlDocumentID.</param>
		///--------------------------------------------------------------------------------
		public XmlDocument(Guid xmlDocumentID)
		{
			XmlDocumentID = xmlDocumentID;
		}
		#endregion "Constructors"
	}
}