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
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used for storing and retrieving object values by name
	/// in a case sensitive fashion.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	public class StrongNameObjectCollection : Dictionary<string, object>
	{
		#region "Fields and Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This indexer gets or sets the value associated with the specified key.</summary>
		/// 
		/// <param name="key">Key of item to get or set.</param>
		///--------------------------------------------------------------------------------
		public new Object this[String key]
		{
			get
			{
				if (HasKey(key))
				{
					return base[key];
				}
				else
				{
					return null;
				}
			}
			set
			{
				base[key] = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This indexer gets or sets the value associated with the specified index.</summary>
		/// 
		/// <param name="index">Index of item to get or set.</param>
		///--------------------------------------------------------------------------------
		public Object this[int index]
		{
			get
			{
				return AllValues.GetValue(index);
			}
			set
			{
				AllValues.SetValue(value, index);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets a String array that contains all the keys in the collection.</summary>
		/// 
		///--------------------------------------------------------------------------------
		public String[] AllKeys
		{
			get
			{
				return Keys.ToArray<string>();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets an Object array that contains all the values in the collection.</summary>
		/// 
		///--------------------------------------------------------------------------------
		public Array AllValues
		{
			get
			{
				return Values.ToArray();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets a String array that contains all the values in the collection.</summary>
		/// 
		///--------------------------------------------------------------------------------
		public String[] AllStringValues
		{
			get
			{
				return ((String[])Values.Where(v => v.GetType() == typeof(string)));
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets a value indicating if the collection contains keys that are not null.</summary>
		/// 
		///--------------------------------------------------------------------------------
		public Boolean HasKeys
		{
			get
			{
				return Keys != null && Keys.Count > 0;
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method determines if a given key is in the collection.</summary>
		/// 
		///	<param name="key">Key to check.</param>
		///--------------------------------------------------------------------------------
		public bool HasKey(String key)
		{
			return !String.IsNullOrEmpty(Keys.Where(i => i == key).FirstOrDefault<string>());
		}

		///--------------------------------------------------------------------------------
		///--------------------------------------------------------------------------------
		/// <summary>This method removes an entry in the specified index from the collection.</summary>
		///
		///	<param name="index">Index of item to remove.</param>
		///--------------------------------------------------------------------------------
		public void Remove(int index)
		{
			Remove(AllKeys.GetValue(index) as String);
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates an empty collection.</summary>
		///--------------------------------------------------------------------------------
		public StrongNameObjectCollection()
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor adds elements from an IDictionary into the new collection.</summary>
		/// 
		///	<param name="d">Input IDictionary.</param>
		///--------------------------------------------------------------------------------
		public StrongNameObjectCollection(IDictionary d)
		{
			foreach (DictionaryEntry de in d)
			{
				Add((String)de.Key, de.Value);
			}
		}

		#endregion "Constructors"

	}
}


