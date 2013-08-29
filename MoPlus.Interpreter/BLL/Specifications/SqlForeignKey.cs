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
	/// This file is for adding customizations to the SqlForeignKey class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlForeignKey : BusinessObjectBase
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
				return SqlForeignKeyColumnList.Count;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SQL foreign key.</summary>
		/// 
		/// <param name="sqlForeignKey">The input sql foreign key.</param>
		///--------------------------------------------------------------------------------
		public void LoadForeignKey(ForeignKey sqlForeignKey)
		{
			try
			{
				// load the basic foreign key information
				SqlForeignKeyName = sqlForeignKey.Name;
				DbID = sqlForeignKey.ID;
				ReferencedKey = sqlForeignKey.ReferencedKey;
				ReferencedTable = sqlForeignKey.ReferencedTable;
				ReferencedTableSchema = sqlForeignKey.ReferencedTableSchema;
				IsChecked = sqlForeignKey.IsChecked;
				IsSystemNamed = sqlForeignKey.IsSystemNamed;
				CreateDate = sqlForeignKey.CreateDate;
				DateLastModified = sqlForeignKey.DateLastModified;
				Urn = sqlForeignKey.Urn;
				State = sqlForeignKey.State.ToString();

				// load information for each property
				foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlForeignKey.Properties)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
					{
						if (loopProperty.Name == "ID" || loopProperty.Name == "IsEnabled")
						{
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlForeignKey = this;
							property.LoadProperty(loopProperty);
							SqlPropertyList.Add(property);
						}
					}
				}

				// load information for each extended property
				//foreach (ExtendedProperty loopProperty in sqlForeignKey.ExtendedProperties)
				//{
				//    SqlExtendedProperty property = new SqlExtendedProperty();
				//    property.SqlExtendedPropertyID = Guid.NewGuid();
				//    property.SqlForeignKey = this;
				//    property.LoadExtendedProperty(loopProperty);
				//    SqlExtendedPropertyList.Add(property);
				//}

				// load information for each column
				foreach (ForeignKeyColumn loopColumn in sqlForeignKey.Columns)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlForeignKeyColumn column = new SqlForeignKeyColumn();
					column.SqlForeignKeyColumnID = Guid.NewGuid();
					column.SqlForeignKey = this;
					column.LoadColumn(loopColumn);
					SqlForeignKeyColumnList.Add(column);
				}
			}
			catch (ApplicationAbortException)
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
		/// <summary>This loads information from a MySQL foreign key.</summary>
		/// 
		/// <param name="sqlConnection">The input sql connection</param>
		/// <param name="variables">Database level variables</param>
		/// <param name="key">The key row data</param>
		/// <param name="keyColumns">The key columns table data</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLForeignKey(MySqlConnection sqlConnection, NameObjectCollection variables, DataRow key, DataTable keyColumns)
		{
			try
			{
				// load foreign key  information
				foreach (DataColumn column in key.Table.Columns)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					// load important properties into foreign key, the rest as additional sql properties
					switch (column.ColumnName)
					{
						case "constraint_name":
							SqlForeignKeyName = key[column.ColumnName].GetString();
							break;
						case "referenced_table_name":
							ReferencedTable = key[column.ColumnName].GetString();
						    break;
						case "referenced_table_schema":
							ReferencedTableSchema = key[column.ColumnName].GetString();
							break;
						default:
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlForeignKey = this;
							property.LoadMySQLProperty(column.ColumnName, null, key[column.ColumnName].GetString());
							SqlPropertyList.Add(property);
							break;
					}
				}

				// load information for each column
				if (keyColumns != null)
				{
					foreach (DataRow row in keyColumns.Rows)
					{
						if (DebugHelper.DebugAction == DebugAction.Stop) return;
						if (row["TABLE_NAME"].GetString() == SqlTable.SqlTableName && row["CONSTRAINT_NAME"].GetString() == SqlForeignKeyName)
						{
							SqlForeignKeyColumn column = new SqlForeignKeyColumn();
							column.SqlForeignKeyColumnID = Guid.NewGuid();
							column.SqlForeignKey = this;
							column.LoadMySQLColumn(sqlConnection, variables, row);
							SqlForeignKeyColumnList.Add(column);
						}
					}
				}
			}
			catch (ApplicationAbortException)
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