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
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the XmlDocument class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>2/7/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class XmlDocument : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the XmlSource.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlSource XmlSource { get; set; }

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads information from an
		/// xml document.</summary>
		/// 
		/// <param name="xmlDocument">The document to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDocument(System.Xml.XmlDocument xmlDocument)
		{
			try
			{
                XmlDocumentID = Guid.NewGuid();
                XmlDocumentName = xmlDocument.Name;
				LocalName = xmlDocument.LocalName;
				Value = xmlDocument.Value;
				BaseURI = xmlDocument.BaseURI;
				NamespaceURI = xmlDocument.NamespaceURI;
				if (xmlDocument.DocumentType != null)
				{
					DocumentType = xmlDocument.DocumentType.ToString();
				}
				NodeType = xmlDocument.NodeType.ToString();
				InnerText = xmlDocument.InnerText;
				InnerXml = xmlDocument.InnerXml;
				OuterXml = xmlDocument.OuterXml;
				SchemaInfo = xmlDocument.SchemaInfo.ToString();

				// load nodes
				if (xmlDocument.ChildNodes != null)
				{
					foreach (System.Xml.XmlNode loopNode in xmlDocument.ChildNodes)
					{
						XmlNode node = new XmlNode();
						node.XmlDocument = this;
						node.LoadNode(loopNode);
						XmlNodeList.Add(node);
					}
				}

				// load attributes
				if (xmlDocument.Attributes != null)
				{
					foreach (System.Xml.XmlAttribute loopAttribute in xmlDocument.Attributes)
					{
						XmlAttribute attribute = new XmlAttribute();
						attribute.XmlDocument = this;
						attribute.LoadAttribute(loopAttribute);
						XmlAttributeList.Add(attribute);
					}
				}
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}