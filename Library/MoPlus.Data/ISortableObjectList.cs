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
	public interface ISortableObjectList<T> : IEnumerable<T>, ICollection<T>, IList<T>, ISortableEnumerable
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The direction of the sort: ascending, descending, or random.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		T Find(string propertyName, object propertyValue);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by two properties and values.</summary>
		/// 
		///	<param name="propertyName1">The name of a valid primary property in the sortable object.</param>
		///	<param name="propertyValue1">The value for the primary property.</param>
		///	<param name="propertyName2">The name of a valid secondary property in the sortable object.</param>
		///	<param name="propertyValue2">The value for the secondary property.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		T Find(string propertyName1, object propertyValue1, string propertyName2, object propertyValue2);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by lamda expression.</summary>
		/// 
		///	<param name="predicate">The lamda expression for the find.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		T Find(System.Predicate<T> predicate);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The direction of the sort: ascending, descending, or random.</param>
		/// 
		/// <returns>A List of all items found.</returns>
		///--------------------------------------------------------------------------------
		List<T> FindAll(string propertyName, object propertyValue);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by two properties and values.</summary>
		/// 
		///	<param name="propertyName1">The name of a valid primary property in the sortable object.</param>
		///	<param name="propertyValue1">The value for the primary property.</param>
		///	<param name="propertyName2">The name of a valid secondary property in the sortable object.</param>
		///	<param name="propertyValue2">The value for the secondary property.</param>
		/// 
		/// <returns>A List of all items found.</returns>
		///--------------------------------------------------------------------------------
		List<T> FindAll(string propertyName1, object propertyValue1, string propertyName2, object propertyValue2);

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by lamda expression.</summary>
		/// 
		///	<param name="predicate">The lamda expression for the find.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		List<T> FindAll(System.Predicate<T> predicate);

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input lamda expression and direction.</summary>
		/// 
		///	<param name="sortProperty">The lamda expression to indicate which property to sort by.</param>
		///	<param name="sortDirection">The direction of the sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		void Sort<TKey>(Func<T, TKey> sortProperty, SortDirection sortDirection);

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input lamda expression and comparer.</summary>
		/// 
		///	<param name="sortProperty">The lamda expression to indicate which property to sort by.</param>
		///	<param name="comparer">The comparer for the sort.</param>
		///--------------------------------------------------------------------------------
		void Sort<TKey>(Func<T, TKey> sortProperty, IComparer<TKey> comparer);
	}
}
