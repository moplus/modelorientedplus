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
	/// This file is for adding customizations to the SqlIndex class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlIndex : BusinessObjectBase
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
				return SqlIndexedColumnList.Count;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SQL index.</summary>
		/// 
		/// <param name="sqlIndex">The input sql index.</param>
		///--------------------------------------------------------------------------------
		public void LoadIndex(Index sqlIndex)
		{
			try
			{
				// load the basic index information
				SqlIndexName = sqlIndex.Name;
				DbID = sqlIndex.ID;
				IsClustered = sqlIndex.IsClustered;
				IsUnique = sqlIndex.IsUnique;
				IsXmlIndex = sqlIndex.IsXmlIndex;
				IsFullTextKey = sqlIndex.IsFullTextKey;
				FileGroup = sqlIndex.FileGroup;
				Urn = sqlIndex.Urn;
				State = sqlIndex.State.ToString();

				// load information for each property
				foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlIndex.Properties)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
					{
						if (loopProperty.Name == "ID" || loopProperty.Name == "IgnoreDuplicateKeys" || loopProperty.Name == "IndexKeyType")
						{
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlIndex = this;
							property.LoadProperty(loopProperty);
							SqlPropertyList.Add(property);
						}
					}
				}

				// load information for each extended property
				//foreach (ExtendedProperty loopProperty in sqlIndex.ExtendedProperties)
				//{
				//    SqlExtendedProperty property = new SqlExtendedProperty();
				//    property.SqlExtendedPropertyID = Guid.NewGuid();
				//    property.SqlIndex = this;
				//    property.LoadExtendedProperty(loopProperty);
				//    SqlExtendedPropertyList.Add(property);
				//}

				// load information for each column
				foreach (IndexedColumn loopColumn in sqlIndex.IndexedColumns)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlIndexedColumn column = new SqlIndexedColumn();
					column.SqlIndexedColumnID = Guid.NewGuid();
					column.SqlIndex = this;
					column.LoadColumn(loopColumn);
					SqlIndexedColumnList.Add(column);
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
		/// <summary>This loads information from a MySQL index.</summary>
		/// 
		/// <param name="sqlConnection">The input sql connection</param>
		/// <param name="variables">Database level variables</param>
		/// <param name="index">The table row data</param>
		/// <param name="indexColumns">The index columns table data</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLIndex(MySqlConnection sqlConnection, NameObjectCollection variables, DataRow index, DataTable indexColumns)
		{
			try
			{
				// load index information
				foreach (DataColumn column in index.Table.Columns)
				{
					// load important properties into index, the rest as additional sql properties
					switch (column.ColumnName)
					{
						case "INDEX_NAME":
							SqlIndexName = index[column.ColumnName].GetString();
							break;
						case "PRIMARY":
							IsClustered = index[column.ColumnName].GetBool(); // may not be a good setting
							break;
						case "UNIQUE":
							IsUnique = index[column.ColumnName].GetBool();
							break;
						default:
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlIndex = this;
							property.LoadMySQLProperty(column.ColumnName, null, index[column.ColumnName].GetString());
							SqlPropertyList.Add(property);
							break;
					}
				}

				// load information for each column
				if (indexColumns != null)
				{
					foreach (DataRow row in indexColumns.Rows)
					{
						if (DebugHelper.DebugAction == DebugAction.Stop) return;
						if (row["TABLE_NAME"].GetString() == SqlTable.SqlTableName && row["INDEX_NAME"].GetString() == SqlIndexName)
						{
							SqlIndexedColumn column = new SqlIndexedColumn();
							column.SqlIndexedColumnID = Guid.NewGuid();
							column.SqlIndex = this;
							column.LoadMySQLColumn(sqlConnection, variables, row);
							SqlIndexedColumnList.Add(column);
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