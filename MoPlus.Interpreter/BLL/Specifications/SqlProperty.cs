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

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SqlProperty class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlProperty : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SQL property.</summary>
		/// 
		/// <param name="sqlProperty">The input sql property.</param>
		///--------------------------------------------------------------------------------
		public void LoadProperty(Property sqlProperty)
		{
			try
			{
				// load the basic property information
				SqlPropertyName = sqlProperty.Name;
				SqlType = sqlProperty.Type.ToString();
				SqlValue = sqlProperty.Value.ToString();
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
		/// <summary>This loads information for a MySQL property.</summary>
		/// 
		/// <param name="propertyName">The input property name.</param>
		/// <param name="propertyType">The input property type.</param>
		/// <param name="propertyValue">The input property value.</param>
		///--------------------------------------------------------------------------------
		public void LoadMySQLProperty(string propertyName, string propertyType, string propertyValue)
		{
			try
			{
				// load the basic property information
				SqlPropertyName = propertyName;
				SqlType = propertyType;
				SqlValue = propertyValue;
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