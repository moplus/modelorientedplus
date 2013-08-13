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
using MoPlus.Interpreter.BLL.Specifications;

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the IndexProperty class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/21/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class IndexProperty : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DisplayName
		{
			get
			{
				return Name;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override string Name
		{
			get
			{
				if (Property != null)
				{
					return Property.Name;
				}
				return base.Name;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns a default index property based on db indexed column info.</summary>
		/// 
		/// <param name="column">The column information.</param>
		/// <param name="index">The parent index.</param>
		///--------------------------------------------------------------------------------
		public static IndexProperty BuildIndexPropertyFromSqlIndexedColumn(SqlIndexedColumn column, Index index)
		{
			IndexProperty property = new IndexProperty();
			property.IsAutoUpdated = true;
			property.IndexPropertyID = Guid.NewGuid();
			property.Order = column.Order;
			property.Index = index;
			property.Tags = "DB";
			foreach (Property item in index.Entity.PropertyList)
			{
				if (item.OriginalName == column.SqlIndexedColumnName)
				{
					property.Property = item;
					break;
				}
			}

			return property;
		}
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}