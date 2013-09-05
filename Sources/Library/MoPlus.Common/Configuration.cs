/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Configuration;

namespace MoPlus.Common
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to hold library configuration values.</summary>
	///--------------------------------------------------------------------------------
	public abstract class Configuration
	{
		#region "Constants"
		// This requires deployment of Microsoft Enterprise Library 4.1, with an exception policy
		// of "Library Layer Policy" defined.
		public const string LIBRARY_EXCEPTION_POLICY = "Library Layer Policy";
		#endregion "Constants"

		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"
	}
}
