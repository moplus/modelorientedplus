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
	/// This file is for adding customizations to the Index class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>2/4/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Index : BusinessObjectBase
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
				if (IndexPropertyList != null)
				{
					return IndexPropertyList.Count;
				}
				return 0;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns a default index based on db index info.</summary>
		/// 
		/// <param name="index">The index information.</param>
		/// <param name="entity">The parent entity.</param>
		///--------------------------------------------------------------------------------
		public static Index BuildIndexFromSqlIndex(SqlIndex sqlIndex, Entity entity)
		{
			Index index = new Index();
			index.IsAutoUpdated = true;
			index.IndexID = Guid.NewGuid();
			index.IndexName = sqlIndex.SqlIndexName.Replace(" ", "_");
			index.Entity = entity;
			index.Tags = "DB";
			index.SourceName = sqlIndex.SqlIndexName;
			index.IsUniqueIndex = sqlIndex.IsUnique ?? false;
			index.IsPrimaryKeyIndex = sqlIndex.IsClustered  ?? false;

			return index;
		}
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}