/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to help perform typical xml operations.</summary>
	///--------------------------------------------------------------------------------
	public static class XmlHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method serializes an input object into a string.</summary>
		///
		/// <param name="inputObject">The input object to serialize.</param>
		/// 
		/// <returns>The string representing the serialization of the input object</returns>
		/// 
		/// <returns>The serialized output.</returns>
		///--------------------------------------------------------------------------------
		public static string Serialize(object inputObject)
		{
			// set up output stream
			StringBuilder outputXml = new StringBuilder();
		    var writerSettings = new XmlWriterSettings();
		    writerSettings.Indent = true;
		    using (XmlWriter writer = XmlTextWriter.Create(outputXml))
		    {

		        // serialize
		        //NameObjectCollection propertyTypes = new NameObjectCollection();
		        //foreach (PropertyInfo loopInfo in inputObject.GetType().GetProperties())
		        //{
		        //    if (loopInfo.PropertyType.IsClass == true)
		        //    {
		        //        bool skipProperty = false;
		        //        foreach (object loopAttribute in loopInfo.GetCustomAttributes(true))
		        //        {
		        //            if (loopAttribute is XmlIgnoreAttribute)
		        //            {
		        //                skipProperty = true;
		        //                break;
		        //            }
		        //        }
		        //        if (skipProperty == false)
		        //        {
		        //            propertyTypes[loopInfo.PropertyType.FullName] = loopInfo.PropertyType;
		        //        }
		        //    }
		        //}
		        //Type[] extraTypes = new Type[propertyTypes.Count];
		        //for (int i = 0; i < propertyTypes.Count; i++)
		        //{
		        //    extraTypes[i] = (Type)propertyTypes[i];
		        //}
		        //XmlSerializer serializer = new XmlSerializer(inputObject.GetType(), extraTypes);
		        XmlSerializer serializer = new XmlSerializer(inputObject.GetType());
		        serializer.Serialize(writer, inputObject);
                writer.Flush();
		        return outputXml.ToString();
		    }
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deserializes a string into an object.</summary>
		///
		/// <param name="inputString">The input string to deserialize.</param>
		/// <param name="inputType">The type of object to deserialize.</param>
		/// 
		/// <returns>The deserialized object.</returns>
		///--------------------------------------------------------------------------------
		public static object Deserialize(string inputString, System.Type inputType)
		{
			// set up input stream
			XmlTextReader reader = new XmlTextReader(new MemoryStream(Encoding.Unicode.GetBytes(inputString)));
			reader.Normalization = false;

			// deserialize
			XmlSerializer serializer = new XmlSerializer(inputType);
			return serializer.Deserialize(reader);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deserializes a string into an object.</summary>
		///
		/// <param name="inputString">The input string to deserialize.</param>
		/// <param name="inputType">The type of object to deserialize.</param>
		/// 
		/// <returns>The deserialized object.</returns>
		///--------------------------------------------------------------------------------
		public static void Deserialize(string inputString, ref object inputObject)
		{
			if (inputObject != null)
			{
				// set up input stream
				XmlTextReader reader = new XmlTextReader(new MemoryStream(Encoding.Unicode.GetBytes(inputString)));
				reader.Normalization = false;

				// deserialize
				XmlSerializer serializer = new XmlSerializer(inputObject.GetType());
				inputObject = serializer.Deserialize(reader);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method creates an xml document from input xml.</summary>
		///
		/// <param name="inputXml">The input xml string.</param>
		/// 
		/// <returns>An instance of XmlDocument.</returns>
		///--------------------------------------------------------------------------------
		public static XmlDocument CreateXmlDocument(string inputXml)
		{
			// create and load document
			XmlDocument newXmlDocument = new XmlDocument();
			newXmlDocument.Load(inputXml);

			return newXmlDocument;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms xml based on the input xsl.</summary>
		///
		/// <param name="inputXml">The input xml to transform.</param>
		/// <param name="xslPath">The path to the xsl file.</param>
		/// <param name="xslArguments">Any arguments associated with the xsl.</param>
		/// 
		/// <returns>The xml transformed using the xsl.</returns>
		///--------------------------------------------------------------------------------
		public static string TransformXml(string inputXml, string xslPath, XsltArgumentList xslArguments)
		{
			// set up output stream
			StringBuilder outputXml = new StringBuilder();
			XmlWriter writer = XmlTextWriter.Create(outputXml);

			// create doc and transform
			XmlDocument inputXmlDoc = CreateXmlDocument(inputXml);
			XslCompiledTransform transform = new XslCompiledTransform();
			transform.Load(xslPath);
			transform.Transform(inputXmlDoc.CreateNavigator(), xslArguments, writer);

			return outputXml.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves an xml node from an xml document.</summary>
		///
		/// <param name="inputDocument">The input document to search.</param>
		/// <param name="nodeName">The name of the node to retrieve.</param>
		/// <param name="attributeName">(optional) The name of the attribute the node needs to have.</param>
		/// <param name="attributeValue">(optional) The value of the attribute the node needs to have.</param>
		/// 
		/// <returns>An XmlNode, if found.</returns>
		///--------------------------------------------------------------------------------
		public static XmlNode GetXmlNodeFromDocument(XmlDocument inputDocument, string nodeName, string attributeName, string attributeValue)
		{
			// set up output stream
			foreach (XmlNode loopNode in inputDocument.ChildNodes)
			{
				if (loopNode.Name.Trim().ToLower() == nodeName.Trim().ToLower())
				{
					if (attributeName.Trim().ToLower() == String.Empty)
					{
						// return matching node
						return loopNode;
					}
					else
					{
						foreach (XmlAttribute loopAttribute in loopNode.Attributes)
						{
							if (loopAttribute.Name.Trim().ToLower() == attributeName.Trim().ToLower())
							{
								if (attributeValue.Trim().ToLower() == String.Empty)
								{
									// return matching node and attribute
									return loopNode;
								}
								else if (loopAttribute.Value.Trim().ToLower() == attributeValue.Trim().ToLower())
								{
									// return matching node and attribute and value
									return loopNode;
								}
							}
						}
					}
				}
				XmlNode childNode = GetXmlNodeFromNode(loopNode, nodeName, attributeName, attributeValue);
				if (childNode != null)
				{
					return childNode;
				}
			}

			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves an xml node from an xml node.</summary>
		///
		/// <param name="inputNode">The input node to search.</param>
		/// <param name="nodeName">The name of the node to retrieve.</param>
		/// <param name="attributeName">(optional) The name of the attribute the node needs to have.</param>
		/// <param name="attributeValue">(optional) The value of the attribute the node needs to have.</param>
		/// 
		/// <returns>An XmlNode, if found.</returns>
		///--------------------------------------------------------------------------------
		public static XmlNode GetXmlNodeFromNode(XmlNode inputNode, string nodeName, string attributeName, string attributeValue)
		{
			// set up output stream
			foreach (XmlNode loopNode in inputNode.ChildNodes)
			{
				if (loopNode.Name.Trim().ToLower() == nodeName.Trim().ToLower())
				{
					if (attributeName.Trim().ToLower() == String.Empty)
					{
						// return matching node
						return loopNode;
					}
					else
					{
						foreach (XmlAttribute loopAttribute in loopNode.Attributes)
						{
							if (loopAttribute.Name.Trim().ToLower() == attributeName.Trim().ToLower())
							{
								if (attributeValue.Trim().ToLower() == String.Empty)
								{
									// return matching node and attribute
									return loopNode;
								}
								else if (loopAttribute.Value.Trim().ToLower() == attributeValue.Trim().ToLower())
								{
									// return matching node and attribute and value
									return loopNode;
								}
							}
						}
					}
				}
				XmlNode childNode = GetXmlNodeFromNode(loopNode, nodeName, attributeName, attributeValue);
				if (childNode != null)
				{
					return childNode;
				}
			}

			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes an xml node from an xml document.</summary>
		///
		/// <param name="inputDocument">The input document to search.</param>
		/// <param name="nodeName">The name of the node to retrieve.</param>
		/// <param name="attributeName">(optional) The name of the attribute the node needs to have.</param>
		/// <param name="attributeValue">(optional) The value of the attribute the node needs to have.</param>
		/// 
		/// <returns>True if node is removed, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		public static bool RemoveXmlNodeFromDocument(XmlDocument inputDocument, string nodeName, string attributeName, string attributeValue)
		{
			// set up output stream
			foreach (XmlNode loopNode in inputDocument.ChildNodes)
			{
				if (loopNode.Name.Trim().ToLower() == nodeName.Trim().ToLower())
				{
					if (attributeName.Trim().ToLower() == String.Empty)
					{
						// return matching node
						inputDocument.RemoveChild(loopNode);
						return true;
					}
					else
					{
						foreach (XmlAttribute loopAttribute in loopNode.Attributes)
						{
							if (loopAttribute.Name.Trim().ToLower() == attributeName.Trim().ToLower())
							{
								if (attributeValue.Trim().ToLower() == String.Empty)
								{
									// return matching node and attribute
									inputDocument.RemoveChild(loopNode);
									return true;
								}
								else if (loopAttribute.Value.Trim().ToLower() == attributeValue.Trim().ToLower())
								{
									// return matching node and attribute and value
									inputDocument.RemoveChild(loopNode);
									return true;
								}
							}
						}
					}
				}
				if (RemoveXmlNodeFromNode(loopNode, nodeName, attributeName, attributeValue) == true)
				{
					return true;
				}
			}

			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes an xml node from an xml node.</summary>
		///
		/// <param name="inputDoinputNodecument">The input node to search.</param>
		/// <param name="nodeName">The name of the node to retrieve.</param>
		/// <param name="attributeName">(optional) The name of the attribute the node needs to have.</param>
		/// <param name="attributeValue">(optional) The value of the attribute the node needs to have.</param>
		/// 
		/// <returns>True if node is removed, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		public static bool RemoveXmlNodeFromNode(XmlNode inputNode, string nodeName, string attributeName, string attributeValue)
		{
			// set up output stream
			foreach (XmlNode loopNode in inputNode.ChildNodes)
			{
				if (loopNode.Name.Trim().ToLower() == nodeName.Trim().ToLower())
				{
					if (attributeName.Trim().ToLower() == String.Empty)
					{
						// remove matching node
						inputNode.RemoveChild(loopNode);
						return true;
					}
					else
					{
						foreach (XmlAttribute loopAttribute in loopNode.Attributes)
						{
							if (loopAttribute.Name.Trim().ToLower() == attributeName.Trim().ToLower())
							{
								if (attributeValue.Trim().ToLower() == String.Empty)
								{
									// return matching node and attribute
									inputNode.RemoveChild(loopNode);
									return true;
								}
								else if (loopAttribute.Value.Trim().ToLower() == attributeValue.Trim().ToLower())
								{
									// return matching node and attribute and value
									inputNode.RemoveChild(loopNode);
									return true;
								}
							}
						}
					}
				}
				if (RemoveXmlNodeFromNode(loopNode, nodeName, attributeName, attributeValue) == true)
				{
					return true;
				}
			}

			return false;
		}

		#endregion "Methods"
	}
}
