/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.IO;
using System.IO;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is a base implementation of the IDataObject interface.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[DataContract]
    public abstract class DataObjectBase : IDataObject, IDataErrorInfo, INotifyPropertyChanged, IDisposable
	{
        #region "IDataErrorInfo Members"

        [XmlIgnore]
        [IgnoreDataMember]
        string IDataErrorInfo.Error { get { return null; } }

        [XmlIgnore]
        [IgnoreDataMember]
        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion "IDataErrorInfo Members"

        #region "INotifyPropertyChanged Members"

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
			if (PropertyChanged != null && this.GetPropertyInfo(propertyName) != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
        }

        #endregion "INotifyPropertyChanged Members"

        #region "IDisposable Members"

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        #endregion "IDisposable Members"

        #region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets a convenient unique ID of the instance.  It
		/// does not need to be the primary identifier for the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual Guid ID { get; set; }

		// get a random int as a default value
		protected int _randomInt = DataHelper.GetRandomInt();
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets a random integer value, to be used for random
		/// sorting.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public int RandomInt
		{
			get
			{
				return _randomInt;
			}
			set
			{
				_randomInt = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the representation of the instance as xml.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public string XmlData
		{
			get
			{
				return XmlHelper.Serialize(this);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the representation of the instance as xml.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public string InnerXmlData
		{
			get
			{
				XmlDocument document = new XmlDocument();
				document.LoadXml(XmlHelper.Serialize(this));
				return document.ChildNodes[1].InnerXml;
			}
		}

		///--------------------------------------------------------------------------------
        /// <summary>This property gets whether validation errors are present.</param>
        ///--------------------------------------------------------------------------------
        public bool IsValid
        {
            get
            {
				GenericEntity inputEntity = null;
				string typeName = GetType().FullName;
				if (DataTransformHelper.EntityPropertyFieldInfoCache.GenericEntityCache[typeName] is GenericEntity)
				{
					inputEntity = DataTransformHelper.EntityPropertyFieldInfoCache.GenericEntityCache[typeName] as GenericEntity;
				}
				else
				{
					inputEntity = DataTransformHelper.EntityPropertyFieldInfoCache.AddNewEntityWithPropertyFieldInfo(this);
				}
				foreach (GenericProperty loopProperty in inputEntity.PropertyList)
				{
					if (GetValidationError(loopProperty.PropertyName) != null)
						return false;
				}
                return true;
            }
        }

        #endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads the data for this entity from an xml file.</summary>
		/// 
		/// <remarks>This method will cause an exception if the input file is not valid
		/// xml for this instance.</remarks>
		/// 
		/// <param name="inputFilePath">The path of the file to load from.</param>
		///--------------------------------------------------------------------------------
		public virtual void Load(string inputFilePath)
		{
			if (File.Exists(inputFilePath))
			{
				TransformDataFromObject((IDataObject)XmlHelper.Deserialize(FileHelper.GetText(inputFilePath), GetType()), null);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method saves the data for this entity as an xml file.</summary>
		/// 
		/// <param name="inputFilePath">The path of the file to save to.</param>
		///--------------------------------------------------------------------------------
		public virtual void Save(string inputFilePath)
		{
			FileHelper.ReplaceFile(inputFilePath, XmlData);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Use RandomInt as basis for default compare (there is no other useful
		/// property for this object).</summary>
		///--------------------------------------------------------------------------------
		public virtual int CompareTo(object obj)
		{
			DataObjectBase baseObj = obj as DataObjectBase;
			if (obj != null)
			{
				return RandomInt.CompareTo(baseObj.RandomInt);
			}
			return 0;
		}

        ///--------------------------------------------------------------------------------
        /// <summary>This method returns a validation error for the input property.</param>
        /// 
        /// <param name="propertyName">The name of the property.</param>
        /// 
        /// <remarks>This should be overridden with actual business rules for validation.</remarks>
        /// 
        /// <returns>Validation error (null by default).</returns>
        ///--------------------------------------------------------------------------------
        public virtual string GetValidationError(string propertyName)
        {
			return null;
        }

        ///--------------------------------------------------------------------------------
		/// <summary>This method gets a string value from a property of the input object,
		/// else returns the default string value.</summary>
		/// 
		/// <param name="propertyName">Name of the property to get value from.</param>
		/// 
		/// <remarks>DataHelper.GetPropertyValueString() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		public virtual string GetPropertyValueString(string propertyName)
		{
			return DataHelper.GetPropertyValueString(this, propertyName);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets an object value from a property of the input object,
		/// else returns the default string value.</summary>
		/// 
		/// <param name="propertyName">Name of the property to get value from.</param>
		/// 
		/// <remarks>DataHelper.GetPropertyValue() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		public virtual object GetPropertyValue(string propertyName)
		{
			return DataHelper.GetPropertyValue(this, propertyName);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a string value from a field of the input object,
		/// else returns the default string value.</summary>
		/// 
		/// <param name="fieldName">Name of the field to get value from.</param>
		/// 
		/// <remarks>DataHelper.GetFieldValueString() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		public virtual string GetFieldValueString(string fieldName)
		{
			return DataHelper.GetFieldValueString(this, fieldName);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determine whethers the input value matches the value of the specified
		/// property's value.</summary>
		/// 
		/// <remarks>DataHelper.IsPropertyValueMatch() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		public virtual bool IsPropertyValueMatch(string propertyName, object propertyValue)
		{
			return DataHelper.IsPropertyValueMatch(this, propertyName, propertyValue);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included.</summary>
		/// 
		/// <returns>Tab delimited data with header for the instance.</returns>
		///--------------------------------------------------------------------------------
		public virtual string GetDelimitedData()
		{
			return GetDelimitedData(true, true, "\t");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included if specified.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		/// 
		/// <returns>Tab delimited data for the instance.</returns>
		///--------------------------------------------------------------------------------
		public virtual string GetDelimitedData(bool includeHeader)
		{
			return GetDelimitedData(includeHeader, true, "\t");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included if specified.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		/// <param name="includeData">Specifies whether or not to include the data in
		/// the output.</param>
		/// <param name="delimiter">The user specified delimiter.</param>
		/// 
		/// <returns>Delimited data for the instance, delimited and header as specified by the user.</returns>
		///--------------------------------------------------------------------------------
		public virtual string GetDelimitedData(bool includeHeader, bool includeData, string delimiter)
		{
			StringBuilder output = new StringBuilder();

			if (includeHeader == true)
			{
				string title = String.Empty;
				foreach (PropertyInfo loopInfo in GetType().GetProperties())
				{
					if (loopInfo.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
					{
						// output serializable element header
						if (title != String.Empty)
						{
							title += delimiter;
						}
						title += loopInfo.Name;
					}
				}
				output.Append(title);
			}
			if (includeData == true)
			{
				string row = String.Empty;
				foreach (PropertyInfo loopInfo in GetType().GetProperties())
				{
					if (loopInfo.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
					{
						// output serializable element data
						if (row != String.Empty)
						{
							row += delimiter;
						}
						row += GetPropertyValueString(loopInfo.Name);
					}
				}
				output.Append("\r\n" + row);
			}

			return output.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms data from the input object into this instance.</summary>
		///
		/// <param name="inputObject">The input object to get data from.</param>
		/// <param name="filterElements">Properties and fields whose values should be omitted from the transform.</param>
		///--------------------------------------------------------------------------------
		public void TransformDataFromObject(IDataObject inputObject, NameObjectCollection filterElements)
		{
			TransformDataFromObject(inputObject, filterElements, true, false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms data from the input object into this instance.</summary>
		///
		/// <param name="inputObject">The input object to get data from.</param>
		/// <param name="filterElements">Properties and fields whose values should be omitted from the transform.</param>
		/// <param name="includeCollections">Flag indicating whether or not to include collections in the transform.</param>
		///--------------------------------------------------------------------------------
		public void TransformDataFromObject(IDataObject inputObject, NameObjectCollection filterElements, bool includeCollections)
		{
			TransformDataFromObject(inputObject, filterElements, includeCollections, false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms data from the input object into this instance,
		/// with the option to include collections in the transformation.</summary>
		///
		/// <param name="inputObject">The input object to get data from.</param>
		/// <param name="filterElements">Properties and fields whose values should be omitted from the transform.</param>
		/// <param name="includeCollections">Flag indicating whether or not to include collections in the transform.</param>
		/// <param name="getNonDefaultValuesOnly">If true, only return a value if not null and not a default value.</param>
		///--------------------------------------------------------------------------------
		public void TransformDataFromObject(IDataObject inputObject, NameObjectCollection filterElements, bool includeCollections, bool getNonDefaultValuesOnly)
		{
			DataTransformHelper.TransformDataFromObject(inputObject, this, filterElements, includeCollections, getNonDefaultValuesOnly);
		}

		#endregion "Methods"
	}
}
