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
	/// <summary>This class is used for strongly typed lists of sortable objects.
	/// Sorting is possible by property names and sort directions (ascending,
	/// descending, and random).</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
    public class SortableDataObjectList<T> : ObservableCollection<T>, ISortableDataObjectList<T> where T : IDataObject, new()
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method compares two items by the input property and sort direction.</summary>
		/// 
		///	<param name="item1">The first (left) item to compare.</param>
		///	<param name="item2">The second (right) item to compare.</param>
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="isRandomSort">Flag, indicating whether sort is a random sort.</param>
		/// 
		/// <returns>The result of the compare.</returns>
		///--------------------------------------------------------------------------------
		public virtual int ItemCompare(T item1, T item2, string propertyName, bool isRandomSort)
		{
			// get the values
			string item1Value = item1.GetPropertyValueString(propertyName);
			string item2Value = item2.GetPropertyValueString(propertyName);
			string systemType = this[0].GetPropertyInfo(propertyName).PropertyType.UnderlyingSystemType.Name;

			// return a comparison based on either or both items being null
			if (item1Value == null && item2Value == null)
			{
				return 0;
			}
			else if (item1Value == null)
			{
				return -1;
			}
			else if (item2Value == null)
			{
				return 1;
			}

			if (isRandomSort == true)
			{
				// perform random compare
				return item1.RandomInt.CompareTo(item2.RandomInt);
			}

			// perform data compare
			switch (systemType)
			{
				// handle compare of numeric types
				case "SByte":
				case "Int16":
				case "Int32":
				case "Int64":
					return item1Value.GetLong().CompareTo(item2Value.GetLong());
				case "Byte":
				case "UInt16":
				case "UInt32":
				case "UInt64":
					return item1Value.GetULong().CompareTo(item2Value.GetULong());
				case "Single":
				case "Double":
					return item1Value.GetDouble().CompareTo(item2Value.GetDouble());
				case "Decimal":
					return item1Value.GetDecimal().CompareTo(item2Value.GetDecimal());
				default:
					break;
			}

			// by default, do string compare
			return item1Value.CompareTo(item2Value);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the RandomInt property for each item in the collection,
		/// as an aid for random sorting.</summary>
		///--------------------------------------------------------------------------------
		public virtual void SetRandomInts()
		{
			foreach (T item in this)
			{
				item.RandomInt = DataHelper.GetRandomInt();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input property and sort direction.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="sortDirection">The direction of the sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		public virtual void Sort(string propertyName, SortDirection sortDirection)
		{
			// if the list is not empty and the property is valid, sort the list
			if (this.Count > 0 && this[0].GetPropertyInfo(propertyName) != null)
			{
				switch (sortDirection)
				{
					case SortDirection.Ascending:
						// ascending sort
						(Items as List<T>).Sort((i1, i2) => ItemCompare(i1, i2, propertyName, false));
						break;
					case SortDirection.Descending:
						// descending sort
                        (Items as List<T>).Sort((i1, i2) => ItemCompare(i2, i1, propertyName, false));
						break;
					default:
						// random sort
						SetRandomInts();
                        (Items as List<T>).Sort((i1, i2) => ItemCompare(i2, i1, propertyName, true));
						break;
				}
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by two input properties and sort directions.</summary>
		/// 
		///	<param name="propertyName1">The name of a primary valid property in the sortable object.</param>
		///	<param name="sortDirection1">The direction of the primary sort: ascending, descending, or random.</param>
		///	<param name="propertyName2">The name of a valid secondary property in the sortable object.</param>
		///	<param name="sortDirection2">The direction of the secondary sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		public virtual void Sort(string propertyName1, SortDirection sortDirection1, string propertyName2, SortDirection sortDirection2)
		{
			// if the list is not empty and the property is valid, sort the list
			if (this.Count > 0 && this[0].GetPropertyInfo(propertyName1) != null && this[0].GetPropertyInfo(propertyName2) != null)
			{
				if (sortDirection1 == SortDirection.Random)
				{
					// random sort (don't bother sorting second column)
					SetRandomInts();
                    (Items as List<T>).Sort((i1, i2) => ItemCompare(i1, i2, propertyName1, true));
				}
				else if (sortDirection1 == SortDirection.Ascending)
				{
					switch (sortDirection2)
					{
						case SortDirection.Ascending:
							// ascending primary and secondary sort
                            (Items as List<T>).Sort((i1, i2) => ItemCompare(i1, i2, propertyName1, false) == 0 ? ItemCompare(i1, i2, propertyName2, false) : ItemCompare(i1, i2, propertyName1, false));
							break;
						case SortDirection.Descending:
							// ascending primary and descending secondary sort
                            (Items as List<T>).Sort((i1, i2) => ItemCompare(i1, i2, propertyName1, false) == 0 ? ItemCompare(i2, i1, propertyName2, false) : ItemCompare(i1, i2, propertyName1, false));
							break;
						default:
							// ascending primary and random secondary sort
							SetRandomInts();
                            (Items as List<T>).Sort((i1, i2) => ItemCompare(i1, i2, propertyName1, false) == 0 ? ItemCompare(i1, i2, propertyName2, true) : ItemCompare(i1, i2, propertyName1, false));
							break;
					}
				}
				else
				{
					switch (sortDirection2)
					{
						case SortDirection.Ascending:
							// descending primary and ascending secondary sort
                            (Items as List<T>).Sort((i1, i2) => ItemCompare(i2, i1, propertyName1, false) == 0 ? ItemCompare(i1, i2, propertyName2, false) : ItemCompare(i2, i1, propertyName1, false));
							break;
						case SortDirection.Descending:
							// descending primary and secondary sort
                            (Items as List<T>).Sort((i1, i2) => ItemCompare(i2, i1, propertyName1, false) == 0 ? ItemCompare(i2, i1, propertyName2, false) : ItemCompare(i2, i1, propertyName1, false));
							break;
						default:
							// descending primary and random secondary sort
							SetRandomInts();
                            (Items as List<T>).Sort((i1, i2) => ItemCompare(i2, i1, propertyName1, false) == 0 ? ItemCompare(i1, i2, propertyName2, true) : ItemCompare(i2, i1, propertyName1, false));
							break;
					}
				}
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}


		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the list by the input lamda expression and direction.</summary>
		/// 
		///	<param name="sortProperty">The lamda expression to indicate which property to sort by.</param>
		///	<param name="sortDirection">The direction of the sort: ascending, descending, or random.</param>
		///--------------------------------------------------------------------------------
		public void Sort<TKey>(Func<T, TKey> sortProperty, SortDirection sortDirection)
		{
			switch (sortDirection)
			{
				case SortDirection.Ascending:
					ApplySort(Items.OrderBy(sortProperty));
					break;
				case SortDirection.Descending:
					ApplySort(Items.OrderByDescending(sortProperty));
					break;
				case SortDirection.Random:
					// ignore sort property, just do random sort
					ApplySort(Items.OrderBy(i => i.RandomInt));
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

		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The direction of the sort: ascending, descending, or random.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		public virtual T Find(string propertyName, object propertyValue)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0 && this[0].GetPropertyInfo(propertyName) != null)
			{
                return (Items as List<T>).Find(item => item.IsPropertyValueMatch(propertyName, propertyValue));
			}
			return default(T);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by its ID value.</summary>
		/// 
		///	<param name="propertyValue">The ID value.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		public virtual T FindByID(Guid propertyValue)
		{
			// if the list is not empty, find an item
			if (this.Count > 0)
			{
				return (Items as List<T>).Find(item => item.ID == propertyValue);
			}
			return default(T);
		}

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
		public virtual T Find(string propertyName1, object propertyValue1, string propertyName2, object propertyValue2)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0 && this[0].GetPropertyInfo(propertyName1) != null && this[0].GetPropertyInfo(propertyName2) != null)
			{
                return (Items as List<T>).Find(item => item.IsPropertyValueMatch(propertyName1, propertyValue1) && item.IsPropertyValueMatch(propertyName2, propertyValue2));
			}
			return default(T);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by lamda expression.</summary>
		/// 
		///	<param name="predicate">The lamda expression for the find.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		public virtual T Find(System.Predicate<T> predicate)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0)
			{
				return (Items as List<T>).Find(predicate);
			}
			return default(T);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The direction of the sort: ascending, descending, or random.</param>
		/// 
		/// <returns>A List of all items found.</returns>
		///--------------------------------------------------------------------------------
		public virtual List<T> FindAll(string propertyName, object propertyValue)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0 && this[0].GetPropertyInfo(propertyName) != null)
			{
                return (Items as List<T>).FindAll(item => item.IsPropertyValueMatch(propertyName, propertyValue));
			}
			return null;
		}

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
		public virtual List<T> FindAll(string propertyName1, object propertyValue1, string propertyName2, object propertyValue2)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0 && this[0].GetPropertyInfo(propertyName1) != null && this[0].GetPropertyInfo(propertyName2) != null)
			{
                return (Items as List<T>).FindAll(item => item.IsPropertyValueMatch(propertyName1, propertyValue1) && item.IsPropertyValueMatch(propertyName2, propertyValue2));
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by lamda expression.</summary>
		/// 
		///	<param name="predicate">The lamda expression for the find.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		public virtual List<T> FindAll(System.Predicate<T> predicate)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0)
			{
				return (Items as List<T>).FindAll(predicate);
			}
		    return new List<T>();
		}

		///--------------------------------------------------------------------------------
        /// <summary>This method removes a range of items from the list.</summary>
        /// 
        ///	<param name="index">The beginning position for items to remove.</param>
        ///	<param name="count">The number of items to remove.</param>
        ///--------------------------------------------------------------------------------
        public virtual void RemoveRange(int index, int count)
        {
            (Items as List<T>).RemoveRange(index, count);
        }

		///--------------------------------------------------------------------------------
		/// <summary>This method build a page of items in the overall list.  The items in the
		/// list are references to the items in the overall list.</summary>
		/// 
		///	<param name="pageSize">The size of the page to return.</param>
		///	<param name="pageIndex">The index of the page into the overall list.</param>
		/// 
		/// <returns>A SortableDataObjectList containing a reference page of the original list.</returns>
		///--------------------------------------------------------------------------------
		public virtual SortableDataObjectList<T> ReferencePage(int pageSize, int pageIndex)
		{
			SortableDataObjectList<T> listPage = new SortableDataObjectList<T>();

			// if the list is not empty and the property is valid, find an item
			if ((pageSize > 0) && (pageSize < this.Count))
			{
				for (int i = pageIndex; i < this.Count; i++)
				{
					if (listPage.Count >= pageSize)
					{
						break;
					}
					listPage.Add(this[i]);
				}
			}
			return listPage;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether an item is found in the list, with a corresponding
		/// property value.</summary>
		/// 
		///	<param name="item">The item to look for a match in the list.</param>
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		/// 
		/// <returns>True if item found, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		public virtual bool Contains(T item, string propertyName)
		{
			// if the list is not empty and the property is valid, see if item is in list by matching property value
			if (this.Count > 0 && item.GetPropertyInfo(propertyName) != null)
			{
                return (Items as List<T>).Find(item2 => item2.IsPropertyValueMatch(propertyName, item.GetPropertyValueString(propertyName))) != null;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether an item is found in the list, with corresponding
		/// two property values.</summary>
		/// 
		///	<param name="item">The item to look for a match in the list.</param>
		///	<param name="propertyName1">The name of a valid primary property in the sortable object.</param>
		///	<param name="propertyName2">The name of a valid secondary property in the sortable object.</param>
		/// 
		/// <returns>True if item found, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		public virtual bool Contains(T item, string propertyName1, string propertyName2)
		{
			// if the list is not empty and the property is valid, see if item is in list by matching property value
			if (this.Count > 0 && item.GetPropertyInfo(propertyName1) != null && item.GetPropertyInfo(propertyName2) != null)
			{
                return (Items as List<T>).Find(item2 => (item2.IsPropertyValueMatch(propertyName1, item.GetPropertyValueString(propertyName1)) && item2.IsPropertyValueMatch(propertyName2, item.GetPropertyValueString(propertyName2)))) != null;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This delegate is to be used for the comparison of two items, primarily
		/// for lamda expressions.</summary>
		///--------------------------------------------------------------------------------
		public delegate int Comparison<TItem>(TItem item1, TItem item2);

		///--------------------------------------------------------------------------------
		/// <summary>This delegate is to be used for qualifying an item, primarily for lamda
		/// expressions.</summary>
		///--------------------------------------------------------------------------------
		public delegate int Predicate<TItem>(TItem item);

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves tab delimited data of all serializable public
		/// property elements (non complex or array types).  Header is included.</summary>
		/// 
		/// <returns>Tab delimited data of the list, with a header.</returns>
		///--------------------------------------------------------------------------------
		public string GetDelimitedData()
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
		/// <returns>Tab delimited data of the list, with a header if specified by the user.</returns>
		///--------------------------------------------------------------------------------
		public string GetDelimitedData(bool includeHeader)
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
		/// <returns>Delimited data of the list, with delimiter and header specified by user.</returns>
		///--------------------------------------------------------------------------------
		public string GetDelimitedData(bool includeHeader, bool includeData, string delimiter)
		{
			StringBuilder output = new StringBuilder();

			if (Count > 0)
			{
				if (includeHeader == true)
				{
					output.Append(this[0].GetDelimitedData(true, false, delimiter));
				}
				if (includeData == true)
				{
					foreach (T loopItem in this)
					{
						output.Append(loopItem.GetDelimitedData(false, true, delimiter));
					}
				}
			}
			return output.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves formatted data of all serializable public
		/// property elements (non complex or array types).  Header is included, 80 character
		/// maximum per column.</summary>
		/// 
		/// <returns>Formatted data of the list, with a header.</returns>
		///--------------------------------------------------------------------------------
		public string GetFormattedData()
		{
			return GetFormattedData(true, true, 80);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves formatted data of all serializable public
		/// property elements (non complex or array types).  Header is included, 80 character
		/// maximum per column.</summary>
		/// 
		/// <param name="includeHeader">Specifies whether or not to include the header in
		/// the output.</param>
		/// 
		/// <returns>Formatted data of the list, with a header if specified by the user.</returns>
		///--------------------------------------------------------------------------------
		public string GetFormattedData(bool includeHeader)
		{
			return GetFormattedData(includeHeader, true, 80);
		}

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
		/// 
		/// <remarks>In this version, the output only looks good for fixed width character
		/// fonts such as courier.</remarks>
		/// 
		/// <returns>Formatted data of the list, with options as specified by the user.</returns>
		///--------------------------------------------------------------------------------
		public string GetFormattedData(bool includeHeader, bool includeData, int maxWidthPerColumn)
		{
			StringBuilder output = new StringBuilder();
			NameObjectCollection outputCollection = new NameObjectCollection();
			NameObjectCollection maxColumnWidths = new NameObjectCollection();

			if (Count > 0)
			{
				int row = 0;
				if (includeHeader == true)
				{
					// add titles into collection
					foreach (PropertyInfo loopInfo in this[0].GetType().GetProperties())
					{
						string title = loopInfo.Name;
						if (title.Length > maxWidthPerColumn)
						{
							title = title.Substring(0, maxWidthPerColumn);
						}
						if (loopInfo.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
						{
							outputCollection["title, " + loopInfo.Name] = title;
							maxColumnWidths[loopInfo.Name] = Math.Min(title.Length, maxWidthPerColumn);
						}
					}
				}
				if (includeData == true)
				{
					// add data into collection
					row = 0;
					foreach (T item in this)
					{
						foreach (PropertyInfo loopInfo in item.GetType().GetProperties())
						{
							string value = item.GetPropertyValueString(loopInfo.Name).GetString();
							if (value.Length > maxWidthPerColumn)
							{
								value = value.Substring(0, maxWidthPerColumn);
							}
							if (loopInfo.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
							{
								// output serializable element data into collection
								outputCollection[row.ToString() + ", " + loopInfo.Name] = value;
								maxColumnWidths[loopInfo.Name] = Math.Max((int)maxColumnWidths[loopInfo.Name], value.Length);
								maxColumnWidths[loopInfo.Name] = Math.Min((int)maxColumnWidths[loopInfo.Name], maxWidthPerColumn);
							}
						}
						row++;
					}
				}

				if (includeHeader == true)
				{
					// add padded titles to output
					foreach (PropertyInfo loopInfo in this[0].GetType().GetProperties())
					{
						if (loopInfo.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
						{
							output.Append(DataHelper.PadStringToLength(outputCollection["title, " + loopInfo.Name].ToString(), (int)maxColumnWidths[loopInfo.Name], DataHelper.IsLeftJustifiedSystemType(loopInfo.PropertyType.UnderlyingSystemType.Name)));
							output.Append("  ");
						}
					}
				}
				if (includeData == true)
				{
					// add padded data to output
					row = 0;
					foreach (T item in this)
					{
						output.Append("\r\n");
						foreach (PropertyInfo loopInfo in item.GetType().GetProperties())
						{
							if (loopInfo.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
							{
								output.Append(DataHelper.PadStringToLength(outputCollection[row.ToString() + ", " + loopInfo.Name].ToString(), (int)maxColumnWidths[loopInfo.Name], DataHelper.IsLeftJustifiedSystemType(loopInfo.PropertyType.UnderlyingSystemType.Name)));
								output.Append("  ");
							}
						}
						row++;
					}
				}
			}
			return output.ToString();
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Base constructor.</summary>
		///--------------------------------------------------------------------------------
		public SortableDataObjectList()
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a list from which data is copied from.</summary>
		/// 
		/// <param name="sourceDataObjectList">The source list to copy to this list.</param>
		///--------------------------------------------------------------------------------
		public SortableDataObjectList(List<T> sourceDataObjectList)
		{
			if (sourceDataObjectList != null)
			{
				foreach (T loopItem in sourceDataObjectList)
				{
					T newItem = new T();
					newItem.TransformDataFromObject(loopItem, null);
					this.Add(newItem);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a sortable list from which data is copied from.</summary>
		/// 
		/// <param name="sourceDataObjectList">The source sortable list to copy to this list.</param>
		///--------------------------------------------------------------------------------
		public SortableDataObjectList(ISortableDataObjectList<T> sourceDataObjectList)
		{
			if (sourceDataObjectList != null)
			{
				foreach (T loopItem in sourceDataObjectList)
				{
					T newItem = new T();
					newItem.TransformDataFromObject(loopItem, null);
					this.Add(newItem);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a source list from which data is copied from.
		/// Output properties can be filtered out.</summary>
		/// 
		/// <param name="sourceDataObjectList">The source sortable list to copy to this list.</param>
		///	<param name="filterElements">Field and property values to exclude from transform.</param>
		///--------------------------------------------------------------------------------
		public SortableDataObjectList(ISortableDataObjectList<T> sourceDataObjectList, NameObjectCollection filterElements)
		{
			if (sourceDataObjectList != null)
			{
				foreach (T loopItem in sourceDataObjectList)
				{
					T newItem = new T();
					newItem.TransformDataFromObject(loopItem, filterElements);
					this.Add(newItem);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a sortable (or enterprise) data object list of another
		/// type (as an object) and transforms it to this list.</summary>
		/// 
		///	<param name="inputListItemType">The type for the items to be found in the input list.</param>
		///	<param name="inputEnterpriseDataObjectList">The input list (as an object) to transform to this list.</param>
		///	<param name="filterElements">Field and property values to exclude from transform.</param>
		///--------------------------------------------------------------------------------
		public SortableDataObjectList(Type inputListItemType, object inputSortableDataObjectList, NameObjectCollection filterElements)
		{
			if (inputSortableDataObjectList != null)
			{
				if (inputSortableDataObjectList.GetType().Name.Contains("SortableDataObjectList") == true)
				{
					// handle sortable data object list
					Type inputListType = typeof(ISortableDataObjectList<>);
					Type genericListType = inputListType.MakeGenericType(inputListItemType);
					IList items = (IList)Activator.CreateInstance(genericListType, inputSortableDataObjectList, filterElements);
					foreach (IDataObject loopItem in items)
					{
						T newItem = new T();
						newItem.TransformDataFromObject(loopItem, filterElements);
						Add(newItem);
					}
				}
				else if (inputSortableDataObjectList.GetType().Name.Contains("EnterpriseDataObjectList") == true)
				{
					// special handling of input enterprise data object list
					Type inputListType = typeof(EnterpriseDataObjectList<>);
					Type genericListType = inputListType.MakeGenericType(inputListItemType);
					IList items = (IList)Activator.CreateInstance(genericListType, inputSortableDataObjectList, filterElements);
					foreach (IEnterpriseDataObject loopItem in items)
					{
						T newItem = new T();
						newItem.TransformDataFromObject(loopItem, filterElements);
						Add(newItem);
					}
				}
				else
				{
					// unsupported input list type
					throw new ApplicationException("SortableDataObjectList constructor given input list of the wrong type: " + inputSortableDataObjectList.GetType().Name);
				}
			}
		}

		#endregion "Constructors"

	}
}
