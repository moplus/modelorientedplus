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

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Parameter class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>2/1/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Parameter : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the PropertyName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string PropertyName
		{
			get
			{
				if (ReferencedPropertyBase is Property)
				{
					return (ReferencedPropertyBase as Property).PropertyName;
				}
				else if (ReferencedPropertyBase is PropertyReference)
				{
					return (ReferencedPropertyBase as PropertyReference).PropertyReferenceName;
				}
				else if (ReferencedPropertyBase is EntityReference)
				{
					return (ReferencedPropertyBase as EntityReference).EntityReferenceName;
				}
				else if (ReferencedPropertyBase is Collection)
				{
					return (ReferencedPropertyBase as Collection).CollectionName;
				}
				return String.Empty;
			}
		}
		#endregion "Fields and Properties"
		
		#region "Methods"
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}