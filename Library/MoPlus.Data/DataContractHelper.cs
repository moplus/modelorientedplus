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
using MoPlus.Common;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to help perform typical data contract operations.</summary>
	///--------------------------------------------------------------------------------
	public static class DataContractHelper
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
		public static string Serialize<T>(T inputObject) where T : IDataObject, new()
		{
			string serializedData = string.Empty;
			try
			{
				// set up output stream
				MemoryStream writer = new MemoryStream();

				// serialize
				DataContractSerializer serializer = new DataContractSerializer(typeof(T));
				serializer.WriteObject(writer, inputObject);
				serializedData = System.Text.Encoding.UTF8.GetString(writer.ToArray());
				writer.Close();
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return serializedData;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method serializes an input object into a string.</summary>
		///
		/// <param name="inputObject">The input object to serialize.</param>
		/// 
		/// <returns>The string representing the serialization of the input object</returns>
		/// 
		/// <returns>The serialized output.</returns>
		///--------------------------------------------------------------------------------
		public static string Serialize<T>(ISortableDataObjectList<T> inputObject) where T : IDataObject, new()
		{
			string serializedData = string.Empty;
			try
			{
				// set up output stream
				MemoryStream writer = new MemoryStream();

				// serialize
				DataContractSerializer serializer = new DataContractSerializer(inputObject.GetType());
				serializer.WriteObject(writer, inputObject);
				serializedData = System.Text.Encoding.UTF8.GetString(writer.ToArray());
				writer.Close();
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return serializedData;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method serializes an input object into a string.</summary>
		///
		/// <param name="inputObject">The input object to serialize.</param>
		/// 
		/// <returns>The string representing the serialization of the input object</returns>
		/// 
		/// <returns>The serialized output.</returns>
		///--------------------------------------------------------------------------------
		public static string Serialize<T>(EnterpriseDataObjectList<T> inputObject) where T : IEnterpriseDataObject, new()
		{
			string serializedData = string.Empty;
			try
			{
				// set up output stream
				MemoryStream writer = new MemoryStream();

				// serialize
				DataContractSerializer serializer = new DataContractSerializer(inputObject.GetType());
				serializer.WriteObject(writer, inputObject);
				serializedData = System.Text.Encoding.UTF8.GetString(writer.ToArray());
				writer.Close();
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return serializedData;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deserializes a string into an object.</summary>
		///
		/// <param name="inputString">The input string to deserialize.</param>
		/// 
		/// <returns>The deserialized object.</returns>
		///--------------------------------------------------------------------------------
		public static T Deserialize<T>(string inputString) where T : IDataObject, new()
		{
			T deserializedData = default(T);
			try
			{
				// set up input stream
				XmlReader reader = XmlReader.Create(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(inputString)));

				// deserialize
				DataContractSerializer serializer = new DataContractSerializer(typeof(T));
				deserializedData = (T)serializer.ReadObject(reader);
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return deserializedData;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deserializes a string into an object.</summary>
		///
		/// <param name="inputString">The input string to deserialize.</param>
		/// <param name="inputObject">The object to deserialize into.</param>
		/// 
		/// <returns>The deserialized object.</returns>
		///--------------------------------------------------------------------------------
		public static void Deserialize<T>(string inputString, ref T inputObject) where T : IDataObject, new()
		{
			try
			{
				if (inputObject != null)
				{
					// set up input stream
					XmlReader reader = XmlReader.Create(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(inputString)));

					// deserialize
					DataContractSerializer serializer = new DataContractSerializer(inputObject.GetType());
					inputObject = (T)serializer.ReadObject(reader);
				}
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deserializes a string into an object.</summary>
		///
		/// <param name="inputString">The input string to deserialize.</param>
		/// <param name="inputList">The list to deserialize into.</param>
		/// 
		/// <returns>The deserialized object.</returns>
		///--------------------------------------------------------------------------------
		public static void Deserialize<T>(string inputString, ref EnterpriseDataObjectList<T> inputList) where T : IEnterpriseDataObject, new()
		{
			try
			{
				if (inputList != null)
				{
					// set up input stream
					XmlReader reader = XmlReader.Create(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(inputString)));

					// deserialize
					DataContractSerializer serializer = new DataContractSerializer(inputList.GetType());
					inputList = (EnterpriseDataObjectList<T>)serializer.ReadObject(reader);
				}
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deserializes a string into an object.</summary>
		///
		/// <param name="inputString">The input string to deserialize.</param>
		/// <param name="inputList">The list to deserialize into.</param>
		/// 
		/// <returns>The deserialized object.</returns>
		///--------------------------------------------------------------------------------
		public static void Deserialize<T>(string inputString, ref SortableDataObjectList<T> inputList) where T : IDataObject, new()
		{
			try
			{
				if (inputList != null)
				{
					// set up input stream
					XmlReader reader = XmlReader.Create(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(inputString)));

					// deserialize
					DataContractSerializer serializer = new DataContractSerializer(inputList.GetType());
					inputList = (SortableDataObjectList<T>)serializer.ReadObject(reader);
				}
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
		}

		#endregion "Methods"
	}
}
