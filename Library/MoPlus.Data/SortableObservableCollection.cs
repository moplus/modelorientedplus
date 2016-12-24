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
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used for sortable observable collections, with no restriction on T.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	public class SortableObservableCollection<T> : ObservableCollection<T>
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input lamda expression and direction.</summary>
		/// 
		///	<param name="sortProperty">The lamda expression to indicate which property to sort by.</param>
		///	<param name="sortDirection">The direction of the sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		public void Sort<TKey>(Func<T, TKey> sortProperty, System.ComponentModel.ListSortDirection sortDirection)
		{
			switch (sortDirection)
			{
				case System.ComponentModel.ListSortDirection.Ascending:
					ApplySort(Items.OrderBy(sortProperty));
					break;
				case System.ComponentModel.ListSortDirection.Descending:
					ApplySort(Items.OrderByDescending(sortProperty));
					break;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input lamda expression and comparer.</summary>
		/// 
		///	<param name="sortProperty">The lamda expression to indicate which property to sort by.</param>
		///	<param name="comparer">The comparer for the sort.</param>
		///--------------------------------------------------------------------------------
		public void Sort<TKey>(Func<T, TKey> sortProperty, IComparer<TKey> comparer)
		{
			ApplySort(Items.OrderBy(sortProperty, comparer));
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by input sorted order.</summary>
		/// 
		///	<param name="sortedItems">The desired order of the items.</param>
		///--------------------------------------------------------------------------------
		private void ApplySort(IEnumerable<T> sortedItems)
		{
			var items = sortedItems.ToList();

			foreach (var item in items)
			{
				Move(IndexOf(item), items.IndexOf(item));
			}
		}
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Base constructor.</summary>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection() : base()
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a list from which data is copied from.</summary>
		/// 
		/// <param name="sourceList">The source list to copy to this list.</param>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection(List<T> sourceList) : base(sourceList)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a list from which data is copied from.</summary>
		/// 
		/// <param name="sourceList">The source list to copy to this list.</param>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection(IEnumerable<T> collection) : base(collection)
		{
		}

		#endregion "Constructors"
	}
}
