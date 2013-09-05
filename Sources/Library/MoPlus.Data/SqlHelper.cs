/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Xml;
using Ent = Microsoft.Practices.EnterpriseLibrary.Data;
using MoPlus.Common;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used for general helper/utility functions relating to
	/// sql databases.</summary>
	///--------------------------------------------------------------------------------
	public static class SqlHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method maps sql server column types (returned by COLUMN_TYPE column)
		/// to System.Data.ParameterDirection.  This mapping is very poor!</summary>
		/// 
		/// <param name="sqlColumnType">The sql column type.</param>
		/// 
		/// <returns>The parameter direction from the column type.</returns>
		///--------------------------------------------------------------------------------
		public static ParameterDirection GetParameterDirectionFromColumnType(int sqlColumnType)
		{
			switch (sqlColumnType)
			{
				case 1:
					return ParameterDirection.Input;
				case 2:
					return ParameterDirection.Output;
				case 5:
					return ParameterDirection.ReturnValue;
				default:
					break;
			}
			return ParameterDirection.InputOutput;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method maps sql server data types (returned by DATA_TYPE column)
		/// to System.Data.DbType.  This mapping is very poor!</summary>
		/// 
		/// <param name="sqlDataType">The sql data type.</param>
		/// 
		/// <returns>The DbType from the sql data type.</returns>
		///--------------------------------------------------------------------------------
		public static DbType GetDbTypeFromSqlDataType(int sqlDataType)
		{
			switch (sqlDataType)
			{
				case -150:
					return DbType.Object;
				case -11:
					return DbType.Guid;
				case -10:
				case -9:
					return DbType.String;
				case -8:
					return DbType.Byte;
				case -7:
					return DbType.Boolean;
				case -6:
					return DbType.Byte;
				case -5:
					return DbType.Int64;
				case -4:
				case -3:
				case -2:
					return DbType.Binary;
				case -1:
					return DbType.AnsiString;
				case 1:
					return DbType.Byte;
				case 2:
					return DbType.VarNumeric;
				case 3:
					return DbType.Currency;
				case 4:
					return DbType.Int32;
				case 5:
					return DbType.Int16;
				case 6:
					return DbType.Single;
				case 7:
					return DbType.Double;
				case 11:
					return DbType.DateTime;
				case 12:
					return DbType.AnsiString;
				default:
					break;
			}
			return DbType.Object;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parameter name from the sql parameter name,
		/// stripping off @ characters, etc.</summary>
		/// 
		/// <param name="inputSqlParameterName">The sql parameter name.</param>
		/// 
		/// <returns>The parameter name.</returns>
		///--------------------------------------------------------------------------------
		public static string GetParameterNameFromSqlParameterName(string inputSqlParameterName)
		{
			string parameterName = inputSqlParameterName;
			if (parameterName.StartsWith("@") == true)
			{
				parameterName = parameterName.Substring(1);
			}
			return parameterName;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method checks for a sql error in the output and throws an exception
		/// if one is found.</summary>
		/// 
		/// <param name="sprocParams">The output stored procedure parameter values.</param>
		/// <param name="sqlErrorName">The parameter name to get a sql error number.</param>
		/// <param name="sqlErrorMessageName">The parameter name to get a sql error message.</param>
		///--------------------------------------------------------------------------------
		public static void ThrowSqlErrorIfFound(NameObjectCollection sprocParams, string sqlErrorName, string sqlErrorMessageName)
		{
			// check for a sql error and throw an exception if one is found
			if (sprocParams[sqlErrorName] != null && sprocParams[sqlErrorName].GetInt() != 0)
			{
				throw new ApplicationException("SQL Error " + sprocParams[sqlErrorName] + " has been encountered: " + sprocParams[sqlErrorMessageName]);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method checks for a sql error in the output and throws an exception
		/// if one is found.</summary>
		///
		/// <param name="sprocParams">The output stored procedure parameter values.</param>
		///--------------------------------------------------------------------------------
		public static void ThrowSqlErrorIfFound(NameObjectCollection sprocParams)
		{
			// check for a sql error and throw an exception if one is found
			ThrowSqlErrorIfFound(sprocParams, "SqlErrorNumber", "SqlErrorMessage");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method wraps wildcards and other special characters that
		/// interfere with a sql search.</summary>
		/// 
		/// <param name="inputString">The input string to wrap special characters with.</param>
		/// 
		/// <returns>The formatted search string.</returns>
		///--------------------------------------------------------------------------------
		public static string WrapSQLSearchCharacters(string inputString)
		{
			if (inputString != null && inputString != String.Empty)
			{
				inputString = inputString.Replace("[", "[[]");
				inputString = inputString.Replace("_", "[_]").Replace("%", "[%]");
			}

			return inputString;
		}
		#endregion "Methods"
	}
}
