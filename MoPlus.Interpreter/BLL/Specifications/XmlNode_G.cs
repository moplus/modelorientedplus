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
	/// specific XmlNode instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="XmlNode")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class XmlNode : BusinessObjectBase
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
			
			error = GetValidationError("XmlNodeName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("XmlDocumentID");
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
			error = GetValidationError("Prefix");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("NamespaceURI");
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
			error = GetValidationError("ParentNodeID");
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
				case "_xmlNodeName":
				case "XmlNodeName":
					error = ValidateXmlNodeName();
					break;
				case "_xmlDocumentID":
				case "XmlDocumentID":
					error = ValidateXmlDocumentID();
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
				case "_prefix":
				case "Prefix":
					error = ValidatePrefix();
					break;
				case "_namespaceURI":
				case "NamespaceURI":
					error = ValidateNamespaceURI();
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
				case "_parentNodeID":
				case "ParentNodeID":
					error = ValidateParentNodeID();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates XmlNodeName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateXmlNodeName()
		{
			if (!Regex.IsMatch(XmlNodeName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "XmlNodeName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates XmlDocumentID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateXmlDocumentID()
		{
			if (XmlDocumentID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "XmlDocumentID");
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
		/// <summary>This method validates Prefix and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePrefix()
		{
			if (String.IsNullOrEmpty(Prefix))
			{
				return String.Format(Resources.DisplayValues.Validation_NullValue, "Prefix");
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
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ParentNodeID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateParentNodeID()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private XmlNode _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlNode ForwardInstance
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
		
		private XmlNode _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new XmlNode ReverseInstance
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
				return XmlNodeID;
			}
			set
			{
				XmlNodeID = value;
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
				return XmlNodeName;
			}
			set
			{
				XmlNodeName = value;
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
				return SourceXmlNode.XmlNodeName;
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
					if (!String.IsNullOrEmpty(XmlDocumentName))
					{
						_displayName = XmlDocumentName + "." + XmlNodeName;
					}
					else
					{
						_displayName = XmlNodeName;
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
					if (XmlDocument != null)
					{
						_defaultSourceName = XmlDocument.DefaultSourceName + "." + DefaultSourcePrefix + SourceXmlNode.XmlNodeName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceXmlNode.XmlNodeName;
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
		public XmlNode SourceXmlNode
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
		/// <summary>This property gets/sets the OldXmlNodeID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldXmlNodeID { get; set; }
		
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
		
		protected Guid _xmlNodeID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlNodeID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid XmlNodeID
		{
			get
			{
				return _xmlNodeID;
			}
			set
			{
				if (_xmlNodeID != value)
				{
					_xmlNodeID = value;
					_isModified = true;
					base.OnPropertyChanged("XmlNodeID");
				}
			}
		}
		
		protected string _xmlNodeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlNodeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string XmlNodeName
		{
			get
			{
				return _xmlNodeName;
			}
			set
			{
				if (_xmlNodeName != value)
				{
					_xmlNodeName = value;
					_isModified = true;
					base.OnPropertyChanged("XmlNodeName");
				}
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
		
		protected string _prefix = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Prefix.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string Prefix
		{
			get
			{
				return _prefix;
			}
			set
			{
				if (_prefix != value)
				{
					_prefix = value;
					_isModified = true;
					base.OnPropertyChanged("Prefix");
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
		
		protected Guid? _parentNodeID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ParentNodeID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? ParentNodeID
		{
			get
			{
				return _parentNodeID;
			}
			set
			{
				if (_parentNodeID != value)
				{
					_parentNodeID = value;
					_isModified = true;
					base.OnPropertyChanged("ParentNodeID");
				}
			}
		}
		
		protected string _xmlDocumentName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the XmlDocumentName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string XmlDocumentName
		{
			get
			{
				return _xmlDocumentName;
			}
		}
		
		protected EnterpriseDataObjectList<BLL.Specifications.XmlAttribute> _xmlAttributeList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of XmlNode.</summary>
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
		
		protected BLL.Specifications.XmlDocument _xmlDocument = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the XmlDocument.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.XmlDocument XmlDocument
		{
			get
			{
				return _xmlDocument;
			}
			set
			{
				if (value != null)
				{
					_xmlDocumentName = value.XmlDocumentName;
					if (_xmlDocument != null && _xmlDocument.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					XmlDocumentID = value.XmlDocumentID;
				}
				_xmlDocument = value;
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
				return "XmlNodeID";
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
				return XmlNodeID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					XmlNodeID = primaryKeyValues[0].GetGuid();
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
				ReverseInstance = new XmlNode();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new XmlNode();
				ForwardInstance.XmlNodeID = XmlNodeID;
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
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputXmlNode">The xmlnode to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(XmlNode inputXmlNode)
		{
			if (XmlNodeName.GetString() != inputXmlNode.XmlNodeName.GetString()) return false;
			if (XmlDocumentID.GetGuid() != inputXmlNode.XmlDocumentID.GetGuid()) return false;
			if (LocalName.GetString() != inputXmlNode.LocalName.GetString()) return false;
			if (Value.GetString() != inputXmlNode.Value.GetString()) return false;
			if (BaseURI.GetString() != inputXmlNode.BaseURI.GetString()) return false;
			if (Prefix.GetString() != inputXmlNode.Prefix.GetString()) return false;
			if (NamespaceURI.GetString() != inputXmlNode.NamespaceURI.GetString()) return false;
			if (NodeType.GetString() != inputXmlNode.NodeType.GetString()) return false;
			if (InnerText.GetString() != inputXmlNode.InnerText.GetString()) return false;
			if (InnerXml.GetString() != inputXmlNode.InnerXml.GetString()) return false;
			if (OuterXml.GetString() != inputXmlNode.OuterXml.GetString()) return false;
			if (SchemaInfo.GetString() != inputXmlNode.SchemaInfo.GetString()) return false;
			if (ParentNodeID.GetGuid() != inputXmlNode.ParentNodeID.GetGuid()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputXmlNode">The xmlnode to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(XmlNode inputXmlNode)
		{
			if (inputXmlNode == null) return true;
			if (inputXmlNode.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.XmlNodeName)) return false;
			if (XmlDocumentID != inputXmlNode.XmlDocumentID) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.LocalName)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.Value)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.BaseURI)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.Prefix)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.NamespaceURI)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.NodeType)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.InnerText)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.InnerXml)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.OuterXml)) return false;
			if (!String.IsNullOrEmpty(inputXmlNode.SchemaInfo)) return false;
			if (ParentNodeID != inputXmlNode.ParentNodeID) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputXmlNode">The xmlnode to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(XmlNode inputXmlNode)
		{
			XmlNodeName = inputXmlNode.XmlNodeName;
			XmlDocumentID = inputXmlNode.XmlDocumentID;
			LocalName = inputXmlNode.LocalName;
			Value = inputXmlNode.Value;
			BaseURI = inputXmlNode.BaseURI;
			Prefix = inputXmlNode.Prefix;
			NamespaceURI = inputXmlNode.NamespaceURI;
			NodeType = inputXmlNode.NodeType;
			InnerText = inputXmlNode.InnerText;
			InnerXml = inputXmlNode.InnerXml;
			OuterXml = inputXmlNode.OuterXml;
			SchemaInfo = inputXmlNode.SchemaInfo;
			ParentNodeID = inputXmlNode.ParentNodeID;
			
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
				XmlNodeID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (XmlNodeID == Guid.Empty)
				{
					XmlNodeID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = XmlNodeID;
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
			XmlDocument = null;
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
					ReverseInstance = new XmlNode();
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
			newItem.ItemID = XmlNodeID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public XmlNode GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			XmlNode forwardItem = new XmlNode();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.XmlNodeID = XmlNodeID;
			}
			foreach (XmlAttribute item in XmlAttributeList)
			{
				item.XmlNode = this;
				XmlAttribute forwardChildItem = item.GetForwardInstance(forwardSolution);
				if (forwardChildItem != null)
				{
					forwardItem.XmlAttributeList.Add(forwardChildItem);
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
				if (modelContext is XmlNode)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is XmlDocument)
				{
					solutionContext.NeedsSample = false;
					XmlDocument parent = modelContext as XmlDocument;
					if (parent.XmlNodeList.Count > 0)
					{
						return parent.XmlNodeList[DataHelper.GetRandomInt(0, parent.XmlNodeList.Count - 1)];
					}
				}
				#region protected
				else if (modelContext is XmlAttribute)
				{
					XmlAttribute parent = modelContext as XmlAttribute;
					if (parent.XmlNode != null)
					{
						return parent.XmlNode;
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is XmlSource)
				{
					XmlSource parent = modelContext as XmlSource;
					if (parent.SpecDocument != null && parent.SpecDocument.XmlNodeList.Count > 0)
					{
						return parent.SpecDocument.XmlNodeList[DataHelper.GetRandomInt(0, parent.SpecDocument.XmlNodeList.Count - 1)];
					}
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			
			#region protected
			if (solutionContext.IsSampleMode == true && solutionContext.XmlSourceList.Count > 0)
			{
				return solutionContext.XmlSourceList[DataHelper.GetRandomInt(0, solutionContext.XmlSourceList.Count - 1)].SpecDocument.XmlNodeList[0];
			}
			#endregion protected
			
			isValidContext = false;
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parent item of this item.</summary>
		///--------------------------------------------------------------------------------
		public override IDomainEnterpriseObject GetParentItem()
		{
			return XmlDocument;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the XmlNode instance from an xml file.</summary>
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
		/// <summary>This method saves the XmlNode instance to an xml file.</summary>
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
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public XmlNode(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic XmlNode instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public XmlNode(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic XmlNode instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="xmlNodeID">The input value for XmlNodeID.</param>
		///--------------------------------------------------------------------------------
		public XmlNode(Guid xmlNodeID)
		{
			XmlNodeID = xmlNodeID;
		}
		#endregion "Constructors"
	}
}