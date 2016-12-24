/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter;

namespace MoPlus.Interpreter.Events
{
	///--------------------------------------------------------------------------------
	/// <summary>This class defines event arguments for status and progress changes.</summary>
	///--------------------------------------------------------------------------------
	public class StatusEventArgs : EventArgs
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Text.</summary>
		///--------------------------------------------------------------------------------
		public string Text { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsException.</summary>
		///--------------------------------------------------------------------------------
		public bool IsException { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ShowMessageBox.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowMessageBox { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AppendText.</summary>
		///--------------------------------------------------------------------------------
		public bool AppendText { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Progress.</summary>
		///--------------------------------------------------------------------------------
		public int Progress { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CompletedWork.</summary>
		///--------------------------------------------------------------------------------
		public uint CompletedWork { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TotalWork.</summary>
		///--------------------------------------------------------------------------------
		public uint TotalWork { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
