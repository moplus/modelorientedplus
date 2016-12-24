/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface is used for all sortable objects, including the ability
	/// to find instances by a property value.</summary>
	///--------------------------------------------------------------------------------
	public interface IDataObject : IComparable
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets a convenient unique ID of the instance.  It
		/// does not need to be the primary identifier for the instance.</summary>
		///--------------------------------------------------------------------------------
		Guid ID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets a random integer value, to be used for random
		/// sorting.</summary>
		/// 
		/// <remarks>DataHelper.GetRandomInt() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		int RandomInt { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a string value from a property of the input object,
		/// else returns the default string value.</summary>
		/// 
		/// <param name="propertyName">Name of the property to get value from.</param>
		/// 
		/// <remarks>DataHelper.GetPropertyValueString() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		string GetPropertyValueString(string propertyName);

		///--------------------------------------------------------------------------------
		/// <summary>This method gets an object value from a property of the input object,
		/// else returns the default string value.</summary>
		/// 
		/// <param name="propertyName">Name of the property to get value from.</param>
		/// 
		/// <remarks>DataHelper.GetPropertyValue() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		object GetPropertyValue(string propertyName);

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a string value from a field of the input object,
		/// else returns the default string value.</summary>
		/// 
		/// <param name="fieldName">Name of the field to get value from.</param>
		/// 
		/// <remarks>DataHelper.GetFieldValueString() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		string GetFieldValueString(string fieldName);

		///--------------------------------------------------------------------------------
		/// <summary>This method determine whethers the input value matches the value of the specified
		/// property's value.</summary>
		/// 
		/// <param name="propertyName">Name of the property to determine match.</param>
		/// <param name="propertyValue">Value to use to determine match.</param>
		/// 
		/// <remarks>DataHelper.IsPropertyValueMatch() can be used as a base implementation.</remarks>
		///--------------------------------------------------------------------------------
		bool IsPropertyValueMatch(string propertyName, object propertyValue);

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included.</summary>
		///--------------------------------------------------------------------------------
		string GetDelimitedData();

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included if specified.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		///--------------------------------------------------------------------------------
		string GetDelimitedData(bool includeHeader);

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included if specified.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		/// <param name="includeData">Specifies whether or not to include the data in
		/// the output.</param>
		/// <param name="delimiter">The user specified delimiter.</param>
		///--------------------------------------------------------------------------------
		string GetDelimitedData(bool includeHeader, bool includeData, string delimiter);

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms data from the input object into this instance.</summary>
		///
		/// <param name="inputObject">The input object to get data from.</param>
		/// <param name="filterElements">Properties and fields whose values should be omitted from the transform.</param>
		///--------------------------------------------------------------------------------
		void TransformDataFromObject(IDataObject inputObject, NameObjectCollection filterElements);

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms data from the input object into this instance.</summary>
		///
		/// <param name="inputObject">The input object to get data from.</param>
		/// <param name="filterElements">Properties and fields whose values should be omitted from the transform.</param>
		/// <param name="includeCollections">Flag indicating whether or not to include collections in the transform.</param>
		///--------------------------------------------------------------------------------
		void TransformDataFromObject(IDataObject inputObject, NameObjectCollection filterElements, bool includeCollections);

		///--------------------------------------------------------------------------------
		/// <summary>This method transforms data from the input object into this instance,
		/// with the option to include collections in the transformation.</summary>
		///
		/// <param name="inputObject">The input object to get data from.</param>
		/// <param name="filterElements">Properties and fields whose values should be omitted from the transform.</param>
		/// <param name="includeCollections">Flag indicating whether or not to include collections in the transform.</param>
		/// <param name="getNonDefaultValuesOnly">If true, only return a value if not null and not a default value.</param>
		///--------------------------------------------------------------------------------
		void TransformDataFromObject(IDataObject inputObject, NameObjectCollection filterElements, bool includeCollections, bool getNonDefaultValuesOnly);
	}
}
