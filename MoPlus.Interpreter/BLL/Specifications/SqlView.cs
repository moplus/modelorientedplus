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
using System.Text.RegularExpressions;
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using Microsoft.SqlServer.Management.Smo;

namespace MoPlus.Interpreter.BLL.Specifications
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific SqlView instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2017</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SqlView : BusinessObjectBase
	{
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This loads information from a SQL view.</summary>
		/// 
		/// <param name="sqlView">The input sql view.</param>
		///--------------------------------------------------------------------------------
		public void LoadView(Microsoft.SqlServer.Management.Smo.View sqlView)
		{
			try
			{
				// load the basic view information
				SqlViewName = sqlView.Name;
				CreateDate = sqlView.CreateDate;
				DateLastModified = sqlView.DateLastModified;
				Urn = sqlView.Urn;
				State = sqlView.State.ToString();

				// load information for each property
				foreach (Column loopColumn in sqlView.Columns)
				{
					if (DebugHelper.DebugAction == DebugAction.Stop) return;
					SqlViewProperty property = new SqlViewProperty();
					property.SqlViewPropertyID = Guid.NewGuid();
					property.SqlView = this;
					property.LoadViewProperty(loopColumn, sqlView.TextBody);
					SqlViewPropertyList.Add(property);
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		#endregion "Methods"
	}
}