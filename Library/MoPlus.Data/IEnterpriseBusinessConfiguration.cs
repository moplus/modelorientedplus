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
	/// <summary>This interface is used to determine required configuration settings for
	/// enterprise systems.</summary>
	///--------------------------------------------------------------------------------
	public interface IEnterpriseBusinessConfiguration
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database connection string.</summary>
		///--------------------------------------------------------------------------------
		string DbConnectionString { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database command timeout.</summary>
		///--------------------------------------------------------------------------------
		int DbCommandTimeout { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database (search) page size.</summary>
		///--------------------------------------------------------------------------------
		int DbPageSize { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database (search) maximum list size.</summary>
		///--------------------------------------------------------------------------------
		int DbMaximumListSize { get; set; }
	}
}
