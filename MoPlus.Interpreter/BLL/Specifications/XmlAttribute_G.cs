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
	/// specific XmlAttribute instances.</summary>
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
	[XmlRoot(Namespace="", ElementName="XmlAttribute")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class XmlAttribute : BusinessObjectBase
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
			
			error = GetValidationError("XmlAttributeName");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("XmlNodeID");
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
			error = GetValidationError("XmlDocumentID");
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
				case "_xmlAttributeName":
				case "XmlAttributeName":
					error = ValidateXmlAttributeName();
					break;
				case "_xmlNodeID":
				case "XmlNodeID":
					error = ValidateXmlNodeID();
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
				case "_xmlDocumentID":
				case "XmlDocumentID":
					error = ValidateXmlDocumentID();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates XmlAttributeName and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateXmlAttributeName()
		{
			if (!Regex.IsMatch(XmlAttributeName, Resources.DisplayValues.Regex_Name))
			{
				return String.Format(Resources.DisplayValues.Validation_AlphanumericValue, "XmlAttributeName");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates XmlNodeID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateXmlNodeID()
		{
			if (XmlNodeID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "XmlNodeID");
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
		/// <summary>This method validates XmlDocumentID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateXmlDocumentID()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private XmlAttribute _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlAttribute ForwardInstance
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
		
		private XmlAttribute _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new XmlAttribute ReverseInstance
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
				return XmlAttributeID;
			}
			set
			{
				XmlAttributeID = value;
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
				return XmlAttributeName;
			}
			set
			{
				XmlAttributeName = value;
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
				return SourceXmlAttribute.XmlAttributeName;
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
					if (!String.IsNullOrEmpty(XmlNodeName))
					{
						_displayName = XmlNodeName + "." + XmlAttributeName;
					}
					else
					{
						_displayName = XmlAttributeName;
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
					if (XmlNode != null)
					{
						_defaultSourceName = XmlNode.DefaultSourceName + "." + DefaultSourcePrefix + SourceXmlAttribute.XmlAttributeName;
					}
					else
					{
						_defaultSourceName = DefaultSourcePrefix + SourceXmlAttribute.XmlAttributeName;
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
		public XmlAttribute SourceXmlAttribute
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
		/// <summary>This property gets/sets the OldXmlAttributeID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldXmlAttributeID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldXmlNodeID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldXmlNodeID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldXmlDocumentID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid? OldXmlDocumentID { get; set; }
		
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
		
		protected Guid _xmlAttributeID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlAttributeID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid XmlAttributeID
		{
			get
			{
				return _xmlAttributeID;
			}
			set
			{
				if (_xmlAttributeID != value)
				{
					_xmlAttributeID = value;
					_isModified = true;
					base.OnPropertyChanged("XmlAttributeID");
				}
			}
		}
		
		protected string _xmlAttributeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlAttributeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string XmlAttributeName
		{
			get
			{
				return _xmlAttributeName;
			}
			set
			{
				if (_xmlAttributeName != value)
				{
					_xmlAttributeName = value;
					_isModified = true;
					base.OnPropertyChanged("XmlAttributeName");
				}
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
		
		protected Guid? _xmlDocumentID = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlDocumentID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid? XmlDocumentID
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
		
		protected string _xmlNodeName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the XmlNodeName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string XmlNodeName
		{
			get
			{
				return _xmlNodeName;
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
		
		protected BLL.Specifications.XmlNode _xmlNode = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the XmlNode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.XmlNode XmlNode
		{
			get
			{
				return _xmlNode;
			}
			set
			{
				if (value != null)
				{
					_xmlNodeName = value.XmlNodeName;
					if (_xmlNode != null && _xmlNode.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					XmlNodeID = value.XmlNodeID;
				}
				_xmlNode = value;
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
				return "XmlAttributeID";
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
				return XmlAttributeID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					XmlAttributeID = primaryKeyValues[0].GetGuid();
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
			if (ReverseInstance == null)
			{
				ReverseInstance = new XmlAttribute();
				ReverseInstance.TransformDataFromObject(this, null, false);
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new XmlAttribute();
				ForwardInstance.XmlAttributeID = XmlAttributeID;
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
		/// <param name="inputXmlAttribute">The xmlattribute to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(XmlAttribute inputXmlAttribute)
		{
			if (XmlAttributeName.GetString() != inputXmlAttribute.XmlAttributeName.GetString()) return false;
			if (XmlNodeID.GetGuid() != inputXmlAttribute.XmlNodeID.GetGuid()) return false;
			if (LocalName.GetString() != inputXmlAttribute.LocalName.GetString()) return false;
			if (Value.GetString() != inputXmlAttribute.Value.GetString()) return false;
			if (BaseURI.GetString() != inputXmlAttribute.BaseURI.GetString()) return false;
			if (Prefix.GetString() != inputXmlAttribute.Prefix.GetString()) return false;
			if (NamespaceURI.GetString() != inputXmlAttribute.NamespaceURI.GetString()) return false;
			if (NodeType.GetString() != inputXmlAttribute.NodeType.GetString()) return false;
			if (InnerText.GetString() != inputXmlAttribute.InnerText.GetString()) return false;
			if (InnerXml.GetString() != inputXmlAttribute.InnerXml.GetString()) return false;
			if (OuterXml.GetString() != inputXmlAttribute.OuterXml.GetString()) return false;
			if (SchemaInfo.GetString() != inputXmlAttribute.SchemaInfo.GetString()) return false;
			if (XmlDocumentID.GetGuid() != inputXmlAttribute.XmlDocumentID.GetGuid()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputXmlAttribute">The xmlattribute to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(XmlAttribute inputXmlAttribute)
		{
			if (inputXmlAttribute == null) return true;
			if (inputXmlAttribute.TagList.Count > 0) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.XmlAttributeName)) return false;
			if (XmlNodeID != inputXmlAttribute.XmlNodeID) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.LocalName)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.Value)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.BaseURI)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.Prefix)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.NamespaceURI)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.NodeType)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.InnerText)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.InnerXml)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.OuterXml)) return false;
			if (!String.IsNullOrEmpty(inputXmlAttribute.SchemaInfo)) return false;
			if (XmlDocumentID != inputXmlAttribute.XmlDocumentID) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputXmlAttribute">The xmlattribute to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(XmlAttribute inputXmlAttribute)
		{
			XmlAttributeName = inputXmlAttribute.XmlAttributeName;
			XmlNodeID = inputXmlAttribute.XmlNodeID;
			LocalName = inputXmlAttribute.LocalName;
			Value = inputXmlAttribute.Value;
			BaseURI = inputXmlAttribute.BaseURI;
			Prefix = inputXmlAttribute.Prefix;
			NamespaceURI = inputXmlAttribute.NamespaceURI;
			NodeType = inputXmlAttribute.NodeType;
			InnerText = inputXmlAttribute.InnerText;
			InnerXml = inputXmlAttribute.InnerXml;
			OuterXml = inputXmlAttribute.OuterXml;
			SchemaInfo = inputXmlAttribute.SchemaInfo;
			XmlDocumentID = inputXmlAttribute.XmlDocumentID;
			
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
				XmlAttributeID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (XmlAttributeID == Guid.Empty)
				{
					XmlAttributeID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = XmlAttributeID;
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
			XmlNode = null;
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
		public virtual bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new XmlAttribute();
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
			newItem.ItemID = XmlAttributeID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public XmlAttribute GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			XmlAttribute forwardItem = new XmlAttribute();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.XmlAttributeID = XmlAttributeID;
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
				if (modelContext is XmlAttribute)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is XmlNode)
				{
					solutionContext.NeedsSample = false;
					XmlNode parent = modelContext as XmlNode;
					if (parent.XmlAttributeList.Count > 0)
					{
						return parent.XmlAttributeList[DataHelper.GetRandomInt(0, parent.XmlAttributeList.Count - 1)];
					}
				}
				#region protected
				else if (solutionContext.IsSampleMode == true && modelContext is XmlDocument)
				{
					XmlDocument parent = modelContext as XmlDocument;
					if (parent.XmlAttributeList.Count > 0)
					{
						return parent.XmlAttributeList[DataHelper.GetRandomInt(0, parent.XmlAttributeList.Count - 1)];
					}
				}
				else if (solutionContext.IsSampleMode == true && modelContext is XmlSource)
				{
					XmlSource parent = modelContext as XmlSource;
					if (parent.SpecDocument != null && parent.SpecDocument.XmlAttributeList.Count > 0)
					{
						return parent.SpecDocument.XmlAttributeList[DataHelper.GetRandomInt(0, parent.SpecDocument.XmlAttributeList.Count - 1)];
					}
				}
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			
			#region protected
			if (solutionContext.IsSampleMode == true && solutionContext.XmlSourceList.Count > 0)
			{
				return solutionContext.XmlSourceList[DataHelper.GetRandomInt(0, solutionContext.XmlSourceList.Count - 1)].SpecDocument.XmlAttributeList[0];
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
			return XmlNode;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the XmlAttribute instance from an xml file.</summary>
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
		/// <summary>This method saves the XmlAttribute instance to an xml file.</summary>
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
		public XmlAttribute(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic XmlAttribute instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public XmlAttribute(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic XmlAttribute instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="xmlAttributeID">The input value for XmlAttributeID.</param>
		///--------------------------------------------------------------------------------
		public XmlAttribute(Guid xmlAttributeID)
		{
			XmlAttributeID = xmlAttributeID;
		}
		#endregion "Constructors"
	}
}