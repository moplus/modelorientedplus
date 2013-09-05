/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using MoPlus.Common;
using MoPlus.Data;
using System.Data;
using System.IO;
using System.Text;
using MoPlus.Interpreter.BLL.Solutions;
using System.Collections.Generic;
using System.Linq;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is for managing various debug operations.</summary>
	///--------------------------------------------------------------------------------
	public static class DebugHelper
	{
		#region "Fields and Properties"
		public static readonly object DEBUG_OBJECT = new object();
		public static DebugAction DebugAction = DebugAction.None;

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"
	}
}