/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Solutions;
using Microsoft.SqlServer.Management.Smo;
using MySql.Data.MySqlClient;
using System.Data;
using MoPlus.Interpreter.Resources;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SqlDatabase class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlDatabase : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the DatabaseSource.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public DatabaseSource DatabaseSource { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SqlTableCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int SqlTableCount
		{
			get
			{
				if (SqlTableList != null)
				{
					return SqlTableList.Count;
				}
				return 0;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SqlServer database, using SMO.</summary>
		/// 
		/// <param name="sqlDatabase">The input sql database</param>
		///--------------------------------------------------------------------------------
		public void LoadSqlServerDatabase(Database sqlDatabase)
		{
			try
			{
				// load the basic database information
				SqlDatabaseName = sqlDatabase.Name;
				DbID = sqlDatabase.ID;
				Owner = sqlDatabase.Owner;
				PrimaryFilePath = sqlDatabase.PrimaryFilePath;
				DefaultSchema = sqlDatabase.DefaultSchema;
				DefaultFileGroup = sqlDatabase.DefaultFileGroup;
				DefaultFullTextCatalog = sqlDatabase.DefaultFullTextCatalog;
				CreateDate = sqlDatabase.CreateDate;
				Status = sqlDatabase.Status.ToString();
				UserName = sqlDatabase.UserName;
				State = sqlDatabase.State.ToString();

				// load information for each property
				foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlDatabase.Properties)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
					{
						SqlProperty property = new SqlProperty();
						property.SqlPropertyID = Guid.NewGuid();
						property.SqlDatabase = this;
						property.LoadProperty(loopProperty);
						SqlPropertyList.Add(property);
					}
				}

				// load information for each extended property
				foreach (ExtendedProperty loopProperty in sqlDatabase.ExtendedProperties)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlExtendedProperty property = new SqlExtendedProperty();
					property.SqlExtendedPropertyID = Guid.NewGuid();
					property.SqlDatabase = this;
					property.LoadExtendedProperty(loopProperty);
					SqlExtendedPropertyList.Add(property);
				}

				// load information for each table
				foreach (Table loopTable in sqlDatabase.Tables)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlTable table = new SqlTable();
					table.SqlTableID = Guid.NewGuid();
					table.SqlDatabase = this;
					table.LoadTable(loopTable);
					SqlTableList.Add(table);
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a MySQL database.</summary>
		/// 
		/// <param name="sqlConnection">The input sql connection</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLDatabase(MySqlConnection sqlConnection)
		{
			try
			{
				// load the basic database information
				SqlDatabaseName = sqlConnection.Database;
				//Owner = sqlDatabase.Owner;
				//PrimaryFilePath = sqlDatabase.PrimaryFilePath;
				//DefaultSchema = sqlDatabase.DefaultSchema;
				//DefaultFileGroup = sqlDatabase.DefaultFileGroup;
				//CreateDate = sqlDatabase.CreateDate;

				// load variables
				NameObjectCollection variables = new NameObjectCollection();
				MySqlCommand command = sqlConnection.CreateCommand();
				command.CommandText = "SHOW VARIABLES;";
				MySqlDataReader Reader;
				Reader = command.ExecuteReader();
				while (Reader.Read())
				{
					variables[Reader.GetValue(0).ToString()] = Reader.GetValue(1).ToString();
				}
				Reader.Close();

				// add variables to database properties
				foreach (string variable in variables.AllKeys)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlProperty property = new SqlProperty();
					property.SqlPropertyID = Guid.NewGuid();
					property.SqlDatabase = this;
					property.LoadMySQLProperty(variable, null, variables[variable].ToString());
					SqlPropertyList.Add(property);
				}

				// load tables of schema info
				DataTable tables = null;
				DataTable columns = null;
				DataTable indexes = null;
				DataTable indexColumns = null;
				DataTable foreignKeys = null;
				DataTable foreignKeyColumns = null;
				try
				{
					tables = sqlConnection.GetSchema("Tables");
				}
				catch
				{
					Solution.ShowIssue(String.Format(DisplayValues.Exception_MySQLSchemaLoad, "Tables", SqlDatabaseName), null, Solution.IsSampleMode);
				}
				try
				{
					columns = sqlConnection.GetSchema("Columns");
				}
				catch
				{
					Solution.ShowIssue(String.Format(DisplayValues.Exception_MySQLSchemaLoad, "Columns", SqlDatabaseName), null, Solution.IsSampleMode);
				}
				try
				{
					indexes = sqlConnection.GetSchema("Indexes");
				}
				catch
				{
					Solution.ShowIssue(String.Format(DisplayValues.Exception_MySQLSchemaLoad, "Indexes", SqlDatabaseName), null, Solution.IsSampleMode);
				}
				try
				{
					indexColumns = sqlConnection.GetSchema("IndexColumns");
				}
				catch
				{
					Solution.ShowIssue(String.Format(DisplayValues.Exception_MySQLSchemaLoad, "IndexColumns", SqlDatabaseName), null, Solution.IsSampleMode);
				}
				try
				{
					foreignKeys = sqlConnection.GetSchema("Foreign Keys");
				}
				catch
				{
					Solution.ShowIssue(String.Format(DisplayValues.Exception_MySQLSchemaLoad, "Foreign Keys", SqlDatabaseName), null, Solution.IsSampleMode);
				}
				try
				{
					foreignKeyColumns = sqlConnection.GetSchema("Foreign Key Columns");
				}
				catch
				{
					Solution.ShowIssue(String.Format(DisplayValues.Exception_MySQLSchemaLoad, "Foreign Key Columns", SqlDatabaseName), null, Solution.IsSampleMode);
				}

				// load information for each table
				if (tables != null)
				{
					foreach (DataRow row in tables.Rows)
					{
						if (DebugHelper.DebugAction == DebugAction.Stop) return;
						SqlTable table = new SqlTable();
						table.SqlTableID = Guid.NewGuid();
						table.SqlDatabase = this;
						table.LoadMySQLTable(sqlConnection, variables, row, columns, indexes, indexColumns, foreignKeys, foreignKeyColumns);
						SqlTableList.Add(table);
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}