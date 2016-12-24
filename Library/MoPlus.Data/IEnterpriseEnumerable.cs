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
using System.Collections;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface is used for all sortable object lists, including the ability
	/// to sort instances by a property.</summary>
	///--------------------------------------------------------------------------------
	public interface IEnterpriseEnumerable : ISortableEnumerable
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The value of the property.</param>
		/// 
		/// <returns>An item found.</returns>
		///--------------------------------------------------------------------------------
		IEnterpriseDataObject FindItem(string propertyName, object propertyValue);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by its ID and value.</summary>
		/// 
		///	<param name="propertyValue">The value of the property.</param>
		/// 
		/// <returns>An item found.</returns>
		///--------------------------------------------------------------------------------
		IEnterpriseDataObject FindItemByID(Guid propertyValue);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The property value.</param>
		/// 
		/// <returns>A list of items found.</returns>
		///--------------------------------------------------------------------------------
		IEnterpriseEnumerable FindItems(string propertyName, object propertyValue);
	}
}
