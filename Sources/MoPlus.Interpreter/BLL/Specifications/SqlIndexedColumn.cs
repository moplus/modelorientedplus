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

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SqlIndexedColumn class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlIndexedColumn : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		private int? _order = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the Order.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int Order
		{
			get
			{
				if (_order == null)
				{
					_order = 0;
					if (SqlIndex != null)
					{
						int order = 0;
						foreach (SqlIndexedColumn column in SqlIndex.SqlIndexedColumnList)
						{
							order++;
							if (column.SqlIndexedColumnID == SqlIndexedColumnID)
							{
								_order = order;
								break;
							}
						}
					}
				}
				return (int)_order;
			}
			set
			{
				_order = value;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SQL indexed column.</summary>
		/// 
		/// <param name="sqlIndexedColumn">The input sql indexed column.</param>
		///--------------------------------------------------------------------------------
		public void LoadColumn(IndexedColumn sqlIndexedColumn)
		{
			try
			{
				// load the basic index column information
				SqlIndexedColumnName = sqlIndexedColumn.Name;
				DbID = sqlIndexedColumn.ID;
				IsIncluded = sqlIndexedColumn.IsIncluded;
				IsComputed = sqlIndexedColumn.IsComputed;
				Descending = sqlIndexedColumn.Descending;
				Urn = sqlIndexedColumn.Urn;
				State = sqlIndexedColumn.State.ToString();

				// load information for each property
				//foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlIndexedColumn.Properties)
				//{
				//    if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
				//    {
				//        SqlProperty property = new SqlProperty();
				//        property.SqlPropertyID = Guid.NewGuid();
				//        property.SqlIndexedColumn = this;
				//        property.LoadProperty(loopProperty);
				//        SqlPropertyList.Add(property);
				//    }
				//}
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
		/// <param name="indexedColumn">The index column row data</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLColumn(MySqlConnection sqlConnection, NameObjectCollection variables, DataRow indexedColumn)
		{
			try
			{
				// load index information
				foreach (DataColumn column in indexedColumn.Table.Columns)
				{
					// load important properties into index, the rest as additional sql properties
					switch (column.ColumnName)
					{
						case "COLUMN_NAME":
							SqlIndexedColumnName = indexedColumn[column.ColumnName].GetString();
							break;
						case "ORDINAL_POSITION":
							Order = indexedColumn[column.ColumnName].GetInt();
							break;
						default:
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlIndexedColumn = this;
							property.LoadMySQLProperty(column.ColumnName, null, indexedColumn[column.ColumnName].GetString());
							SqlPropertyList.Add(property);
							break;
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