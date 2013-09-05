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
	/// <summary>This class is used to hold global default values for typically used
	/// value types and simple reference types.</summary>
	///--------------------------------------------------------------------------------
	public class DefaultValue
	{
		#region "Constants"
		#region "Reference Types"
		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a string.</summary>
		///--------------------------------------------------------------------------------
		public static string String { get { return String.Empty; } }
		public const string StringStr = "";

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a DateTime.</summary>
		///--------------------------------------------------------------------------------
		public static DateTime DateTime { get { return DateTime.MinValue; } }
		public const string DateTimeStr = "00:00:00.0000000, January 1, 0001";

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a Guid.</summary>
		///--------------------------------------------------------------------------------
		public static Guid Guid { get { return Guid.Empty; } }
		public const string GuidStr = "00000000-0000-0000-0000-000000000000";

		#endregion "Reference Types"

		#region "Value Types
		///--------------------------------------------------------------------------------
		/// <summary>Global default value for an sbyte.</summary>
		///--------------------------------------------------------------------------------
		public const sbyte SByte = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a short.</summary>
		///--------------------------------------------------------------------------------
		public const short Short = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for an int.</summary>
		///--------------------------------------------------------------------------------
		public const int Int = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a long.</summary>
		///--------------------------------------------------------------------------------
		public const long Long = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a byte.</summary>
		///--------------------------------------------------------------------------------
		public const byte Byte = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a ushort.</summary>
		///--------------------------------------------------------------------------------
		public const ushort UShort = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a uint.</summary>
		///--------------------------------------------------------------------------------
		public const uint UInt = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a ulong.</summary>
		///--------------------------------------------------------------------------------
		public const ulong ULong = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a float.</summary>
		///--------------------------------------------------------------------------------
		public const float Float = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a double.</summary>
		///--------------------------------------------------------------------------------
		public const double Double = 0;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a decimal.</summary>
		///--------------------------------------------------------------------------------
		public const decimal Decimal = decimal.Zero;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a bool.</summary>
		///--------------------------------------------------------------------------------
		public const bool Bool = false;

		///--------------------------------------------------------------------------------
		/// <summary>Global default value for a char.</summary>
		///--------------------------------------------------------------------------------
		public const char Char = '\0';

		#endregion "Value Types"
		#endregion "Constants"

		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"
	}
}
