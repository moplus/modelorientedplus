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
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is a base implementation of the IEnterpriseBusinessObject
	/// interface.  Database related methods are empty and need implementation in actual
	/// enterprise objects.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	public abstract class EnterpriseManagerObjectBase : IEnterpriseManagerObject
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property determines what database this entity is associated with,
		/// and how that database should be accessed.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue(null)]
		public virtual DatabaseOptions DatabaseOptions { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the ConnectionString property of DatabaseOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string ConnectionString
		{
			get
			{
				return DatabaseOptions.ConnectionString;
			}
			set
			{
				DatabaseOptions.ConnectionString = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the CommandTimeout property of DatabaseOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int CommandTimeout
		{
			get
			{
				return DatabaseOptions.CommandTimeout;
			}
			set
			{
				DatabaseOptions.CommandTimeout = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property determines how data for this entity is to be paged and
		/// sorted.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue(null)]
		public virtual DataAccessOptions DataAccessOptions { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the DebugLevel property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int DebugLevel
		{
			get
			{
				return DataAccessOptions.DebugLevel;
			}
			set
			{
				DataAccessOptions.DebugLevel = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the IncludeInactive property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IncludeInactive
		{
			get
			{
				return DataAccessOptions.IncludeInactive;
			}
			set
			{
				DataAccessOptions.IncludeInactive = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the PageSize property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int PageSize
		{
			get
			{
				return DataAccessOptions.PageSize;
			}
			set
			{
				DataAccessOptions.PageSize = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the StartIndex property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int StartIndex
		{
			get
			{
				return DataAccessOptions.StartIndex;
			}
			set
			{
				DataAccessOptions.StartIndex = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the MaximumListSize property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int MaximumListSize
		{
			get
			{
				return DataAccessOptions.MaximumListSize;
			}
			set
			{
				DataAccessOptions.MaximumListSize = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the SortColumn property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string SortColumn
		{
			get
			{
				return DataAccessOptions.SortColumn;
			}
			set
			{
				DataAccessOptions.SortColumn = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the SortDirection property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual SortDirection SortDirection
		{
			get
			{
				return DataAccessOptions.SortDirection;
			}
			set
			{
				DataAccessOptions.SortDirection = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property accesses the FilterElements property of DataAccessOptions.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual NameObjectCollection FilterElements
		{
			get
			{
				return DataAccessOptions.FilterElements;
			}
			set
			{
				DataAccessOptions.FilterElements = value;
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"
	}
}
