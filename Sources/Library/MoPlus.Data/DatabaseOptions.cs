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

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to hold options for accessing a database.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	public class DatabaseOptions
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the database connection string.</summary>
		///--------------------------------------------------------------------------------
		public virtual string ConnectionString { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the database command timeout.</summary>
		///--------------------------------------------------------------------------------
		public virtual int CommandTimeout { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a default DataOptions instance with
		/// default values.</summary>
		///--------------------------------------------------------------------------------
		public DatabaseOptions()
		{
			// initialize a default DataOptions instance
			ConnectionString = String.Empty;
			CommandTimeout = 200;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a default DataOptions instance with
		/// the connection string.</summary>
		/// 
		/// <param name="connectionString">The connection string for connecting to the database.</param>
		///--------------------------------------------------------------------------------
		public DatabaseOptions(string connectionString)
		{
			// initialize a default DataOptions instance
			ConnectionString = connectionString;
			CommandTimeout = 200;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a default DataOptions instance with
		/// the server and database name.</summary>
		/// 
		/// <param name="serverName">The name of the database server to connect to.</param>
		/// <param name="databaseName">The name of the database to connect to.</param>
		///--------------------------------------------------------------------------------
		public DatabaseOptions(string serverName, string databaseName)
		{
			// initialize a default DataOptions instance
			ConnectionString = "Server=" + serverName + ";Database=" + databaseName + ";Trusted_Connection=true";
			CommandTimeout = 200;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a default DataOptions instance with
		/// the connection string and command timeout.</summary>
		/// 
		/// <param name="connectionString">The connection string for connecting to the database.</param>
		/// <param name="commandTimeout">The timeout for database commands.</param>
		///--------------------------------------------------------------------------------
		public DatabaseOptions(string connectionString, int commandTimeout)
		{
			// initialize a default DataOptions instance
			ConnectionString = connectionString;
			CommandTimeout = commandTimeout;
			if (CommandTimeout == DefaultValue.Int)
			{
				CommandTimeout = 200;
			}
		}
		#endregion "Constructors"
	}
}
