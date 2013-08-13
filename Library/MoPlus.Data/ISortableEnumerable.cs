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
	public interface ISortableEnumerable : IEnumerable
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input property and sort direction.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="sortDirection">The direction of the sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		void Sort(string propertyName, SortDirection sortDirection);

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by two input properties and sort directions.</summary>
		/// 
		///	<param name="propertyName1">The name of a primary valid property in the sortable object.</param>
		///	<param name="sortDirection1">The direction of the primary sort: ascending, descending, or random.</param>
		///	<param name="propertyName2">The name of a valid secondary property in the sortable object.</param>
		///	<param name="sortDirection2">The direction of the secondary sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		void Sort(string propertyName1, SortDirection sortDirection1, string propertyName2, SortDirection sortDirection2);
	}
}
