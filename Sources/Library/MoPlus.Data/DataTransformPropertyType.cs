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
	/// <summary>This enumeration is used to hold the supported data transform property types.</summary>
	///--------------------------------------------------------------------------------
	public enum DataTransformPropertyType
	{
        /// <summary>Element property (contains property info).</summary>
        ElementProperty = 1,
        /// <summary>Element field (contains field info).</summary>
        ElementField = 2,
		/// <summary>Element property (contains property info).</summary>
		ArrayItemProperty = 3,
		/// <summary>Element field (contains field info).</summary>
		ArrayItemField = 4,
	}
}
