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
using Microsoft.SqlServer.Management.Smo;
using MySql.Data.MySqlClient;
using System.Data;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SqlTable class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlTable : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PropertyCount
		{
			get
			{
				return SqlColumnList.Count;
			}
		}

		private int? _primaryKeyColumnCount = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PrimaryKeyColumnCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PrimaryKeyColumnCount
		{
			get
			{
				if (_primaryKeyColumnCount == null)
				{
					_primaryKeyColumnCount = 0;
					foreach (SqlColumn column in SqlColumnList)
					{
						if (column.InPrimaryKey == true)
						{
							_primaryKeyColumnCount++;
						}
					}
				}
				return (int)_primaryKeyColumnCount;
			}
		}

		private int? _foreignKeyColumnCount = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ForeignKeyColumnCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int ForeignKeyColumnCount
		{
			get
			{
				if (_foreignKeyColumnCount == null)
				{
					_foreignKeyColumnCount = 0;
					foreach (SqlColumn column in SqlColumnList)
					{
						if (column.IsForeignKey == true)
						{
							_foreignKeyColumnCount++;
						}
					}
				}
				return (int)_foreignKeyColumnCount;
			}
		}

		private int? _primaryAndForeignKeyColumnCount = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PrimaryAndForeignKeyColumnCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PrimaryAndForeignKeyColumnCount
		{
			get
			{
				if (_primaryAndForeignKeyColumnCount == null)
				{
					_primaryAndForeignKeyColumnCount = 0;
					foreach (SqlColumn column in SqlColumnList)
					{
						if (column.InPrimaryKey == true && column.IsForeignKey == true)
						{
							_primaryAndForeignKeyColumnCount++;
						}
					}
				}
				return (int)_primaryAndForeignKeyColumnCount;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SQL table.</summary>
		/// 
		/// <param name="sqlTable">The input sql table.</param>
		///--------------------------------------------------------------------------------
		public void LoadTable(Table sqlTable)
		{
			try
			{
				// load the basic table information
				SqlTableName = sqlTable.Name;
				DbID = sqlTable.ID;
				Owner = sqlTable.Owner;
				Schema = sqlTable.Schema;
				FileGroup = sqlTable.FileGroup;
				CreateDate = sqlTable.CreateDate;
				DateLastModified = sqlTable.DateLastModified;
				Urn = sqlTable.Urn;
				State = sqlTable.State.ToString();

				// load information for each property
				foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlTable.Properties)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
					{
						if (loopProperty.Name == "ID" || loopProperty.Name == "RowCount" || loopProperty.Name == "HasClusteredIndex" || loopProperty.Name == "HasIndex")
						{
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlTable = this;
							property.LoadProperty(loopProperty);
							SqlPropertyList.Add(property);
						}
					}
				}

				// load information for each extended property
				foreach (ExtendedProperty loopProperty in sqlTable.ExtendedProperties)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlExtendedProperty property = new SqlExtendedProperty();
					property.SqlExtendedPropertyID = Guid.NewGuid();
					property.SqlTable = this;
					property.LoadExtendedProperty(loopProperty);
					SqlExtendedPropertyList.Add(property);
				}

				// load information for each column
				foreach (Column loopColumn in sqlTable.Columns)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlColumn column = new SqlColumn();
					column.SqlColumnID = Guid.NewGuid();
					column.SqlTable = this;
					column.LoadColumn(loopColumn);
					SqlColumnList.Add(column);
				}

				// load information for each index
				foreach (Index loopIndex in sqlTable.Indexes)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlIndex index = new SqlIndex();
					index.SqlIndexID = Guid.NewGuid();
					index.SqlTable = this;
					index.LoadIndex(loopIndex);
					SqlIndexList.Add(index);
				}

				// load information for each foreign key
				foreach (ForeignKey loopKey in sqlTable.ForeignKeys)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlForeignKey key = new SqlForeignKey();
					key.SqlForeignKeyID = Guid.NewGuid();
					key.SqlTable = this;
					key.LoadForeignKey(loopKey);
					SqlForeignKeyList.Add(key);
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw;
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a MySQL table.</summary>
		/// 
		/// <param name="sqlConnection">The input sql connection</param>
		/// <param name="variables">Database level variables</param>
		/// <param name="table">The table row data</param>
		/// <param name="columns">The columns table data</param>
		/// <param name="indexes">The indexes table data</param>
		/// <param name="indexColumns">The index columns table data</param>
		/// <param name="keys">The keys table data</param>
		/// <param name="keyColumns">The key columns table data</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLTable(MySqlConnection sqlConnection, NameObjectCollection variables, DataRow table, DataTable columns, DataTable indexes, DataTable indexColumns, DataTable keys, DataTable keyColumns)
		{
			try
			{
				// load table information
				foreach (DataColumn column in table.Table.Columns)
				{
					// load important properties into table, the rest as additional sql properties
					switch (column.ColumnName)
					{
						case "TABLE_NAME":
							SqlTableName = table[column.ColumnName].GetString();
							break;
						case "CREATE_TIME":
							CreateDate = table[column.ColumnName].GetDateTime();
							break;
						case "UPDATE_TIME":
							DateLastModified = table[column.ColumnName].GetDateTime();
							break;
						default:
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlTable = this;
							property.LoadMySQLProperty(column.ColumnName, null, table[column.ColumnName].GetString());
							SqlPropertyList.Add(property);
							break;
					}
				}

				// load information for each column
				if (columns != null)
				{
					foreach (DataRow row in columns.Rows)
					{
						if (DebugHelper.DebugAction == DebugAction.Stop) return;
						if (row["TABLE_NAME"].GetString() == SqlTableName)
						{
							SqlColumn column = new SqlColumn();
							column.SqlColumnID = Guid.NewGuid();
							column.SqlTable = this;
							column.LoadMySQLColumn(sqlConnection, variables, row);
							SqlColumnList.Add(column);
						}
					}
				}

				// load information for each index
				if (indexes != null)
				{
					foreach (DataRow row in indexes.Rows)
					{
						if (DebugHelper.DebugAction == DebugAction.Stop) return;
						if (row["TABLE_NAME"].GetString() == SqlTableName)
						{
							SqlIndex index = new SqlIndex();
							index.SqlIndexID = Guid.NewGuid();
							index.SqlTable = this;
							index.LoadMySQLIndex(sqlConnection, variables, row, indexColumns);
							SqlIndexList.Add(index);
						}
					}
				}

				// load information for each foreign key
				if (keys != null)
				{
					foreach (DataRow row in keys.Rows)
					{
						if (DebugHelper.DebugAction == DebugAction.Stop) return;
						if (row["table_name"].GetString() == SqlTableName)
						{
							SqlForeignKey key = new SqlForeignKey();
							key.SqlForeignKeyID = Guid.NewGuid();
							key.SqlTable = this;
							key.LoadMySQLForeignKey(sqlConnection, variables, row, keyColumns);
							SqlForeignKeyList.Add(key);
						}
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw;
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