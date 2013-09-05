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
	/// <summary>This interface is used for all sortable object lists, including the ability
	/// to sort instances by a property.</summary>
	///--------------------------------------------------------------------------------
	public interface ISortableDataObjectList<T> : ISortableObjectList<T> where T : IDataObject
	{
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
		/// <summary>This method retrieves formatted data of all serializable public
		/// property elements (non complex or array types).  Header is included, 80 character
		/// maximum per column.</summary>
		///--------------------------------------------------------------------------------
		string GetFormattedData();

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves formatted data of all serializable public
		/// property elements (non complex or array types).  Header is included, 80 character
		/// maximum per column.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		///--------------------------------------------------------------------------------
		string GetFormattedData(bool includeHeader);

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves formatted data of all serializable public
		/// property elements (non complex or array types).  Header and maximum characters
		/// per column is input.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		/// <param name="includeData">Specifies whether or not to include the data in
		/// the output.</param>
		/// <param name="maxWidthPerColumn">The maximum number of characters per column.</param>
		///--------------------------------------------------------------------------------
		string GetFormattedData(bool includeHeader, bool includeData, int maxWidthPerColumn);

	}
}
