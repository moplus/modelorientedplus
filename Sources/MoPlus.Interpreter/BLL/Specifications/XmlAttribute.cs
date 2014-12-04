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
	/// This file is for adding customizations to the XmlAttribute class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>2/7/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class XmlAttribute : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this item.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public static IEnterpriseEnumerable GetCollectionContext(Solution solutionContext, IDomainEnterpriseObject modelContext, bool getChildItems = false)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			while (nodeContext != null)
			{
				if (nodeContext is XmlNode)
				{
					if (getChildItems == true)
					{
						EnterpriseDataObjectList<XmlAttribute> attributes = new EnterpriseDataObjectList<XmlAttribute>();
						foreach (XmlAttribute attribute in (nodeContext as XmlNode).XmlAttributeList)
						{
							attributes.Add(attribute);
						}
						foreach (XmlNode node in (nodeContext as XmlNode).XmlNodeList)
						{
							foreach (IDomainEnterpriseObject childNode in GetCollectionContext(solutionContext, node, getChildItems))
							{
								if (childNode is XmlAttribute)
								{
									attributes.Add(childNode as XmlAttribute);
								}
							}
						}
						return attributes;
					}
					return (nodeContext as XmlNode).XmlAttributeList;
				}
				else if (nodeContext is XmlDocument)
				{
					if (getChildItems == true)
					{
						EnterpriseDataObjectList<XmlAttribute> attributes = new EnterpriseDataObjectList<XmlAttribute>();
						foreach (XmlAttribute attribute in (nodeContext as XmlDocument).XmlAttributeList)
						{
							attributes.Add(attribute);
						}
						foreach (XmlNode node in (nodeContext as XmlSource).SpecDocument.XmlNodeList)
						{
							foreach (IDomainEnterpriseObject attribute in GetCollectionContext(solutionContext, node, getChildItems))
							{
								if (attribute is XmlAttribute)
								{
									attributes.Add(attribute as XmlAttribute);
								}
							}
						}
						return attributes;
					}
					return (nodeContext as XmlDocument).XmlAttributeList;
				}
				else if (nodeContext is XmlSource)
				{
					EnterpriseDataObjectList<XmlAttribute> attributes = new EnterpriseDataObjectList<XmlAttribute>();
					if ((nodeContext as XmlSource).SpecDocument != null)
					{
						foreach (XmlAttribute attribute in (nodeContext as XmlSource).SpecDocument.XmlAttributeList)
						{
							attributes.Add(attribute);
						}
						foreach (XmlNode node in (nodeContext as XmlSource).SpecDocument.XmlNodeList)
						{
							foreach (IDomainEnterpriseObject attribute in GetCollectionContext(solutionContext, node, true))
							{
								if (attribute is XmlAttribute)
								{
									attributes.Add(attribute as XmlAttribute);
								}
							}
						}
					}
					return attributes;
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<XmlAttribute> attributes = new EnterpriseDataObjectList<XmlAttribute>();
					foreach (XmlSource source in (nodeContext as Solution).XmlSourceList)
					{
						if (source.SpecDocument != null)
						{
							foreach (XmlAttribute attribute in (nodeContext as XmlSource).SpecDocument.XmlAttributeList)
							{
								attributes.Add(attribute);
							}
							foreach (XmlNode node in (nodeContext as XmlSource).SpecDocument.XmlNodeList)
							{
								foreach (IDomainEnterpriseObject attribute in GetCollectionContext(solutionContext, node, true))
								{
									if (attribute is XmlAttribute)
									{
										attributes.Add(attribute as XmlAttribute);
									}
								}
							}
						}
					}
					return attributes;
				}
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads information from an
		/// xml attribute.</summary>
		/// 
		/// <param name="xmlAttribute">The attribute to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadAttribute(System.Xml.XmlAttribute xmlAttribute)
		{
			try
			{
                XmlAttributeID = Guid.NewGuid();
                XmlAttributeName = xmlAttribute.Name;
				LocalName = xmlAttribute.LocalName;
				Value = xmlAttribute.Value;
				BaseURI = xmlAttribute.BaseURI;
				Prefix = xmlAttribute.Prefix;
				NamespaceURI = xmlAttribute.NamespaceURI;
				NodeType = xmlAttribute.NodeType.ToString();
				InnerText = xmlAttribute.InnerText;
				InnerXml = xmlAttribute.InnerXml;
				OuterXml = xmlAttribute.OuterXml;
				SchemaInfo = xmlAttribute.SchemaInfo.ToString();
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