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
	/// This file is for adding customizations to the XmlNode class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>2/7/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class XmlNode : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		protected BLL.Specifications.XmlNode _xmlNode = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the ParentXmlNode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Specifications.XmlNode ParentXmlNode
		{
			get
			{
				return _xmlNode;
			}
			set
			{
				if (_xmlNode == null || _xmlNode.Equals(value) == false)
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
		}

		protected EnterpriseDataObjectList<BLL.Specifications.XmlNode> _xmlNodeList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of XmlNodeList.</summary>
		///--------------------------------------------------------------------------------
		[XmlArray(ElementName = "XmlNodeList")]
		[XmlArrayItem(typeof(BLL.Specifications.XmlNode), ElementName = "XmlNode")]
		[DataMember(Name = "XmlNodeList")]
		[DataArrayItem(ElementName = "XmlNodeList")]
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

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads information from an
		/// xml node.</summary>
		/// 
		/// <param name="xmlNode">The node to load.,</param>
		///--------------------------------------------------------------------------------
		public void LoadNode(System.Xml.XmlNode xmlNode)
		{
			try
			{
                XmlNodeID = Guid.NewGuid();
				XmlNodeName = xmlNode.Name;
				LocalName = xmlNode.LocalName;
				Value = xmlNode.Value;
				BaseURI = xmlNode.BaseURI;
				Prefix = xmlNode.Prefix;
				NamespaceURI = xmlNode.NamespaceURI;
				NodeType = xmlNode.NodeType.ToString();
				InnerText = xmlNode.InnerText;
				InnerXml = xmlNode.InnerXml;
				OuterXml = xmlNode.OuterXml;
				SchemaInfo = xmlNode.SchemaInfo.ToString();

				// load nodes
				if (xmlNode.ChildNodes != null)
				{
					foreach (System.Xml.XmlNode loopNode in xmlNode.ChildNodes)
					{
						XmlNode node = new XmlNode();
						node.ParentXmlNode = this;
						node.LoadNode(loopNode);
						XmlNodeList.Add(node);
					}
				}

				// load attributes
				if (xmlNode.Attributes != null)
				{
					foreach (System.Xml.XmlAttribute loopAttribute in xmlNode.Attributes)
					{
						XmlAttribute attribute = new XmlAttribute();
						attribute.XmlNode = this;
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
						EnterpriseDataObjectList<XmlNode> nodes = new EnterpriseDataObjectList<XmlNode>();
						foreach (XmlNode node in (nodeContext as XmlNode).XmlNodeList)
						{
							foreach (IDomainEnterpriseObject childNode in GetCollectionContext(solutionContext, node, getChildItems))
							{
								if (childNode is XmlNode)
								{
									nodes.Add(childNode as XmlNode);
								}
							}
						}
						return nodes;
					}
					return (nodeContext as XmlNode).XmlNodeList;
				}
				else if (nodeContext is XmlDocument)
				{
					if (getChildItems == true)
					{
						EnterpriseDataObjectList<XmlNode> nodes = new EnterpriseDataObjectList<XmlNode>();
						foreach (XmlNode node in (nodeContext as XmlDocument).XmlNodeList)
						{
							nodes.Add(node);
							foreach (IDomainEnterpriseObject childNode in GetCollectionContext(solutionContext, node, getChildItems))
							{
								if (childNode is XmlNode)
								{
									nodes.Add(childNode as XmlNode);
								}
							}
						}
						return nodes;
					}
					return (nodeContext as XmlDocument).XmlNodeList;
				}
				else if (nodeContext is XmlSource)
				{
					EnterpriseDataObjectList<XmlNode> nodes = new EnterpriseDataObjectList<XmlNode>();
					if ((nodeContext as XmlSource).SpecDocument != null)
					{
						foreach (XmlNode node in (nodeContext as XmlSource).SpecDocument.XmlNodeList)
						{
							nodes.Add(node);
							foreach (IDomainEnterpriseObject childNode in GetCollectionContext(solutionContext, node, true))
							{
								if (childNode is XmlNode)
								{
									nodes.Add(childNode as XmlNode);
								}
							}
						}
					}
					return nodes;
				}
				else if (nodeContext is Solution)
				{
					EnterpriseDataObjectList<XmlNode> nodes = new EnterpriseDataObjectList<XmlNode>();
					foreach (XmlSource source in (nodeContext as Solution).XmlSourceList)
					{
						if (source.SpecDocument != null)
						{
							foreach (XmlNode node in source.SpecDocument.XmlNodeList)
							{
								nodes.Add(node);
								foreach (IDomainEnterpriseObject childNode in GetCollectionContext(solutionContext, node, true))
								{
									if (childNode is XmlNode)
									{
										nodes.Add(childNode as XmlNode);
									}
								}
							}
						}
					}
					return nodes;
				}
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}