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
	/// This file is for adding customizations to the SqlForeignKeyColumn class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlForeignKeyColumn : BusinessObjectBase
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
					if (SqlForeignKey != null)
					{
						int order = 0;
						foreach (SqlForeignKeyColumn column in SqlForeignKey.SqlForeignKeyColumnList)
						{
							order++;
							if (column.SqlForeignKeyColumnID == SqlForeignKeyColumnID)
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
		/// <summary>This loads information from a SQL foreign key column.</summary>
		/// 
		/// <param name="sqlForeignKeyColumn">The input sql foreign key column.</param>
		///--------------------------------------------------------------------------------
		public void LoadColumn(ForeignKeyColumn sqlForeignKeyColumn)
		{
			try
			{
				// load the basic foreign key column information
				SqlForeignKeyColumnName = sqlForeignKeyColumn.Name;
				DbID = sqlForeignKeyColumn.ID;
				ReferencedColumn = sqlForeignKeyColumn.ReferencedColumn;
				Urn = sqlForeignKeyColumn.Urn;
				State = sqlForeignKeyColumn.State.ToString();

				// load information for each property
				//foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlForeignKeyColumn.Properties)
				//{
				//    if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
				//    {
				//        SqlProperty property = new SqlProperty();
				//        property.SqlPropertyID = Guid.NewGuid();
				//        property.SqlForeignKeyColumn = this;
				//        property.LoadProperty(loopProperty);
				//        SqlPropertyList.Add(property);
				//    }
				//}
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
		/// <summary>This loads information from a MySQL foreign key.</summary>
		/// 
		/// <param name="sqlConnection">The input sql connection</param>
		/// <param name="variables">Database level variables</param>
		/// <param name="keyColumn">The key column row data</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLColumn(MySqlConnection sqlConnection, NameObjectCollection variables, DataRow keyColumn)
		{
			try
			{
				// load foreign key  information
				foreach (DataColumn column in keyColumn.Table.Columns)
				{
					// load important properties into foreign key, the rest as additional sql properties
					switch (column.ColumnName)
					{
						case "COLUMN_NAME":
							SqlForeignKeyColumnName = keyColumn[column.ColumnName].GetString();
							break;
						case "REFERENCED_COLUMN_NAME":
							ReferencedColumn = keyColumn[column.ColumnName].GetString();
							break;
						case "ORDINAL_POSITION":
							Order = keyColumn[column.ColumnName].GetInt();
							break;
						default:
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlForeignKeyColumn = this;
							property.LoadMySQLProperty(column.ColumnName, null, keyColumn[column.ColumnName].GetString());
							SqlPropertyList.Add(property);
							break;
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