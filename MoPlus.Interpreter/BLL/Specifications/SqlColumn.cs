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
using System.Data;
using MySql.Data.MySqlClient;

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SqlColumn class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlColumn : BusinessObjectBase
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
					if (SqlTable != null)
					{
						int order = 0;
						foreach (SqlColumn column in SqlTable.SqlColumnList)
						{
							order++;
							if (column.SqlColumnID == SqlColumnID)
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
		/// <summary>This loads information from a SQL column.</summary>
		/// 
		/// <param name="sqlColumn">The input sql column.</param>
		///--------------------------------------------------------------------------------
		public void LoadColumn(Column sqlColumn)
		{
			try
			{
				// load the basic column information
				SqlColumnName = sqlColumn.Name;
				DbID = sqlColumn.ID;
				DataType = sqlColumn.DataType.ToString();
				MaximumLength = sqlColumn.DataType.MaximumLength;
				NumericPrecision = sqlColumn.DataType.NumericPrecision;
				NumericScale = sqlColumn.DataType.NumericScale;
				Default = sqlColumn.Default;
				DefaultSchema = sqlColumn.DefaultSchema;
				IsFullTextIndexed = sqlColumn.IsFullTextIndexed;
				IsForeignKey = sqlColumn.IsForeignKey;
				InPrimaryKey = sqlColumn.InPrimaryKey;
				Nullable = sqlColumn.Nullable;
				Identity = sqlColumn.Identity;
				IdentitySeed = sqlColumn.IdentitySeed;
				IdentityIncrement = sqlColumn.IdentityIncrement;
				Urn = sqlColumn.Urn;
				State = sqlColumn.State.ToString();

				// load information for each property
				foreach (Microsoft.SqlServer.Management.Smo.Property loopProperty in sqlColumn.Properties)
				{
					if (loopProperty.Expensive == false && loopProperty.IsNull == false && !String.IsNullOrEmpty(loopProperty.Value.ToString()))
					{
						if (loopProperty.Name == "ID" || loopProperty.Name == "Length")
						{
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlColumn = this;
							property.LoadProperty(loopProperty);
							SqlPropertyList.Add(property);
						}
					}
				}

				// load information for each extended property
				//foreach (ExtendedProperty loopProperty in sqlColumn.ExtendedProperties)
				//{
				//    SqlExtendedProperty property = new SqlExtendedProperty();
				//    property.SqlExtendedPropertyID = Guid.NewGuid();
				//    property.SqlColumn = this;
				//    property.LoadExtendedProperty(loopProperty);
				//    SqlExtendedPropertyList.Add(property);
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
		/// <summary>This loads information from a MySQL column.</summary>
		/// 
		/// <param name="sqlConnection">The input sql connection</param>
		/// <param name="variables">Database level variables</param>
		/// <param name="column">The column row data</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLColumn(MySqlConnection sqlConnection, NameObjectCollection variables, DataRow column)
		{
			try
			{
				// doesn't seem to be a column property for these...
				IdentitySeed = variables["auto_increment_offset"].GetInt();
				IdentityIncrement = variables["auto_increment_increment"].GetInt();
				//IsForeignKey = sqlColumn.IsForeignKey;

				// load column information
				foreach (DataColumn item in column.Table.Columns)
				{
					// load important properties into column, the rest as additional sql properties
					switch (item.ColumnName)
					{
						case "COLUMN_NAME":
							SqlColumnName = column[item.ColumnName].GetString();
							break;
						case "DATA_TYPE":
							DataType = column[item.ColumnName].GetString();
							break;
						case "CHARACTER_MAXIMUM_LENGTH":
							MaximumLength = column[item.ColumnName].GetInt();
							break;
						case "NUMERIC_PRECISION":
							NumericPrecision = column[item.ColumnName].GetInt();
							break;
						case "NUMERIC_SCALE":
							NumericScale = column[item.ColumnName].GetInt();
							break;
						case "COLUMN_DEFAULT":
							Default = column[item.ColumnName].GetString();
							break;
						case "COLUMN_KEY":
							InPrimaryKey = column[item.ColumnName].GetString() == "PRI";
							break;
						case "IS_NULLABLE":
							Nullable = column[item.ColumnName].GetBool();
							break;
						case "ORDINAL_POSITION":
							Order = column[item.ColumnName].GetInt();
							break;
						case "EXTRA":
							Identity = column[item.ColumnName].GetString().Contains("auto_increment");
							break;
						default:
							SqlProperty property = new SqlProperty();
							property.SqlPropertyID = Guid.NewGuid();
							property.SqlColumn = this;
							property.LoadMySQLProperty(item.ColumnName, null, column[item.ColumnName].GetString());
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