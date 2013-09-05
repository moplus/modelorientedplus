/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage the DataArrayItem attribute for transforming
	/// data between dissimilar objects and other purposes.  For transforming data between
	/// dissimilar objects, there should be a match with either a property name or one of
	/// these attributes defined with a matching name.</summary>
	///--------------------------------------------------------------------------------
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=true, Inherited=false)]
	public class DataArrayItemAttribute : Attribute
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the name of the elements.</summary>
		///--------------------------------------------------------------------------------
		public string ElementName { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"
	}
}
