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
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.IO;
using System.IO;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used for strongly typed sortable lists of enterprise
	/// objects (such as data access or business objects).</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[CollectionDataContract]
	public class EnterpriseDataObjectList<T> : SortableDataObjectList<T>, IEnterpriseDataObjectList<T>, IEnterpriseEnumerable
		where T : IEnterpriseDataObject, new()
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets whether an item has been added to the list.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public virtual bool IsItemAdded { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets whether an item has been removed from the list.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public virtual bool IsItemRemoved { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This get property determines if the data has been modified since the
		/// last load from a resource such as a database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public virtual bool IsModified
		{
			get
			{
				if (IsItemAdded == true || IsItemRemoved == true)
				{
					return true;
				}
				foreach (T loopEnterpriseDataObject in this)
				{
					if (loopEnterpriseDataObject.IsModified == true)
					{
						return true;
					}
				}
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This get property determines if the data has all been loaded from a
		/// resource such as a database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public virtual bool IsLoaded
		{
			get
			{
				foreach (T loopEnterpriseDataObject in this)
				{
					if (loopEnterpriseDataObject.IsLoaded == false)
					{
						return false;
					}
				}
				return true;
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

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method finds an item by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The property value.</param>
		/// 
		/// <returns>A T of an item found.</returns>
		///--------------------------------------------------------------------------------
		public virtual IEnterpriseDataObject FindItem(string propertyName, object propertyValue)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0 && this[0].GetType().GetProperty(propertyName) != null)
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
		public virtual IEnterpriseDataObject FindItemByID(Guid propertyValue)
		{
			// if the list is not empty, find an item
			if (this.Count > 0)
			{
				return (Items as List<T>).Find(item => item.ID == propertyValue);
			}
			return default(T);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method finds all items by property and value.</summary>
		/// 
		///	<param name="propertyName">The name of a valid property in the sortable object.</param>
		///	<param name="propertyValue">The property value.</param>
		/// 
		/// <returns>A list of items found.</returns>
		///--------------------------------------------------------------------------------
		public virtual IEnterpriseEnumerable FindItems(string propertyName, object propertyValue)
		{
			// if the list is not empty and the property is valid, find an item
			if (this.Count > 0 && this[0].GetType().GetProperty(propertyName) != null)
			{
				return new EnterpriseDataObjectList<T>((Items as List<T>).FindAll(item => item.IsPropertyValueMatch(propertyName, propertyValue)));
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsLoaded state for the instance.</summary>
		///
		/// <remarks>This should only be used if special business rules override normal loading behavior.</remarks>
		/// 
		/// <param name="isLoaded">The reset value for the IsLoaded property.</param>
		///--------------------------------------------------------------------------------
		public virtual void ResetLoaded(bool isLoaded)
		{
			foreach (T loopEnterpriseDataObject in this)
			{
				loopEnterpriseDataObject.ResetLoaded(isLoaded);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsModified state for the instance.</summary>
		///
		/// <remarks>This should only be used if special business rules override normal modified behavior.</remarks>
		/// 
		/// <param name="isModified">The reset value for the IsModified property.</param>
		///--------------------------------------------------------------------------------
		public virtual void ResetModified(bool isModified)
		{
			IsItemAdded = false;
			IsItemRemoved = false;
			foreach (T loopEnterpriseDataObject in this)
			{
				loopEnterpriseDataObject.ResetModified(isModified);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads the data for this entity from an xml file.</summary>
		/// 
		/// <param name="inputFilePath">The path of the file to load from.</param>
		///--------------------------------------------------------------------------------
		public virtual void Load(string inputFilePath)
		{
			this.RemoveRange(0, this.Count);
			if (File.Exists(inputFilePath))
			{
				foreach (T loopItem in (IEnterpriseDataObjectList<T>)XmlHelper.Deserialize(FileHelper.GetText(inputFilePath), GetType()))
				{
					Add(loopItem);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads the data for this entity from an xml file.</summary>
		/// 
		/// <param name="inputText">The text to load from.</param>
		///--------------------------------------------------------------------------------
		public virtual void LoadFromText(string inputText)
		{
			this.RemoveRange(0, this.Count);
			foreach (T loopItem in (IEnterpriseDataObjectList<T>)XmlHelper.Deserialize(inputText, GetType()))
			{
				Add(loopItem);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method saves the data for this entity as an xml file.</summary>
		/// 
		/// <param name="inputFilePath">The path of the file to save to.</param>
		///--------------------------------------------------------------------------------
		public virtual void Save(string inputFilePath)
		{
			FileHelper.AppendToFile(inputFilePath, XmlHelper.Serialize(this));
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a tracked item to the list.  The list will indicate
		/// that an item has been added to the list.</summary>
		/// 
		/// <param name="item">The item to be added.</param>
		///--------------------------------------------------------------------------------
		public virtual void AddTrackedItem(T item)
		{
			IsItemAdded = true;
			Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method inserts a tracked item to the list at the specified index.
		/// The list will indicate that an item has been added to the list.</summary>
		/// 
		/// <param name="index">The index in the list to insert into.</param>
		/// <param name="item">The item to be added.</param>
		///--------------------------------------------------------------------------------
		public virtual void InsertTrackedItem(int index, T item)
		{
			IsItemAdded = true;
			Insert(index, item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes a tracked item from the list.  The list will indicate
		/// that an item has been added to the list.</summary>
		/// 
		/// <param name="item">The item to be added.</param>
		///--------------------------------------------------------------------------------
		public virtual void RemoveTrackedItem(T item)
		{
			IsItemAdded = true;
			Remove(item);
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This base constructor creates an empty list.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList()
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in a list from which data is copied from.</summary>
		/// 
		///	<param name="sourceDataObjectList">The input List to transform to this list.</param>
		///	<param name="copyItems">Flag indicating whether items in the list should be copied (or retained).</param>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList(IEnumerable<T> sourceDataObjectList, bool copyItems = true)
		{
			if (sourceDataObjectList != null)
			{
				foreach (T loopItem in sourceDataObjectList)
				{
					if (copyItems == true)
					{
						T newItem = new T();
						newItem.TransformDataFromObject(loopItem, null);
						this.Add(newItem);
					}
					else
					{
						this.Add(loopItem);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in an enterprise data object list of the same
		/// type and transforms it to this list.</summary>
		/// 
		///	<param name="inputEnterpriseDataObjectList">The input list to transform to this list.</param>
		///	<param name="filterElements">Field and property values to exclude from transform.</param>
		///	<param name="copyItems">Flag indicating whether items in the list should be copied (or retained).</param>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList(EnterpriseDataObjectList<T> inputEnterpriseDataObjectList, NameObjectCollection filterElements, bool copyItems = true)
		{
			if (inputEnterpriseDataObjectList != null)
			{
				foreach (T loopItem in inputEnterpriseDataObjectList)
				{
					if (copyItems == true)
					{
						T newItem = new T();
						newItem.TransformDataFromObject(loopItem, filterElements);
						Add(newItem);
					}
					else
					{
						Add(loopItem);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor takes in an enterprise (or sortable) data object list of another
		/// type (as an object) and transforms it to this list.</summary>
		/// 
		///	<param name="inputListItemType">The type for the items to be found in the input list.</param>
		///	<param name="inputEnterpriseDataObjectList">The input list (as an object) to transform to this list.</param>
		///	<param name="filterElements">Field and property values to exclude from transform.</param>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList(Type inputListItemType, object inputEnterpriseDataObjectList, NameObjectCollection filterElements)
		{
			if (inputEnterpriseDataObjectList != null)
			{
				if (inputEnterpriseDataObjectList.GetType().Name.Contains("EnterpriseDataObjectList") == true)
				{
					// handle enterprise data object list
					Type inputListType = typeof(EnterpriseDataObjectList<>);
					Type genericListType = inputListType.MakeGenericType(inputListItemType);
					IList items = (IList)Activator.CreateInstance(genericListType, inputEnterpriseDataObjectList, filterElements, true);
					foreach (IEnterpriseDataObject loopItem in items)
					{
						T newItem = new T();
						newItem.TransformDataFromObject(loopItem, filterElements);
						Add(newItem);
					}
				}
				else if (inputEnterpriseDataObjectList.GetType().Name.Contains("SortableDataObjectList") == true)
				{
					// special handling of input sortable data object list
					Type inputListType = typeof(ISortableDataObjectList<>);
					Type genericListType = inputListType.MakeGenericType(inputListItemType);
					IList items = (IList)Activator.CreateInstance(genericListType, inputEnterpriseDataObjectList, filterElements);
					foreach (IDataObject loopItem in items)
					{
						T newItem = new T();
						newItem.TransformDataFromObject(loopItem, filterElements);
						Add(newItem);
					}
				}
				else
				{
					// unsupported input list type
					throw new ApplicationException("EnterpriseDataObjectList constructor given input list of the wrong type: " + inputEnterpriseDataObjectList.GetType().Name);
				}
			}
		}

		#endregion "Constructors"
	}
}
