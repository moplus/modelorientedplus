/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.Services;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to hold options for filtering, sorting, and presenting
	/// data in conjuction with retrieving and/or modifying data.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[IgnoreProperties("SortDirection", "FilterElements")]
	public class DataAccessOptions
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the debug level (for trace operations).</summary>
		///--------------------------------------------------------------------------------
		public virtual int DebugLevel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property determines whether or not active records should be returned
		/// in multi instance get operations.</summary>
		///--------------------------------------------------------------------------------
		public virtual bool IncludeInactive { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the index for the first page of data.</summary>
		///--------------------------------------------------------------------------------
		public virtual int StartIndex { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the size of the page of data.</summary>
		///--------------------------------------------------------------------------------
		public virtual int PageSize { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the maximum amount of data.</summary>
		///--------------------------------------------------------------------------------
		public virtual int MaximumListSize { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the sort column.</summary>
		///--------------------------------------------------------------------------------
		public virtual string SortColumn { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the sort direction.</summary>
		///--------------------------------------------------------------------------------
		public virtual SortDirection SortDirection { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property determines what elements (fields, properties, etc. get
		/// filtered out of results).</summary>
		///--------------------------------------------------------------------------------
		public virtual NameObjectCollection FilterElements { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method sets the sort direction based on the input string.</summary>
		/// 
		/// <param name="sortDirection">The input sort direction as a string.</param>
		///--------------------------------------------------------------------------------
		public void SetSortDirection(string sortDirection)
		{
			if (sortDirection.ToLower().StartsWith("des") == true)
			{
				SortDirection = SortDirection.Descending;
			}
			else if (sortDirection.ToLower().StartsWith("ran") == true)
			{
				SortDirection = SortDirection.Random;
			}
			else
			{
				SortDirection = SortDirection.Ascending;
			}
		}
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a default DataOptions instance with
		/// default values.</summary>
		///--------------------------------------------------------------------------------
		public DataAccessOptions()
		{
			// initialize a default DataOptions instance
			StartIndex = 0;
			PageSize = 50;
			MaximumListSize = 2000;
			SortColumn = String.Empty;
			SortDirection = SortDirection.Ascending;
		}

		#endregion "Constructors"
	}
}
