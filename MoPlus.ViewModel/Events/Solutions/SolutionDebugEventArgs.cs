/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using MoPlus.ViewModel.Events;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter;

namespace MoPlus.ViewModel.Events.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is for passing messages with debug information.</summary>
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/1/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionDebugEventArgs : SolutionModelEventArgs
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the InterpreterType.</summary>
		///--------------------------------------------------------------------------------
		public InterpreterTypeCode InterpreterType { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateContext.</summary>
		///--------------------------------------------------------------------------------
		public ITemplate TemplateContext { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelContext.</summary>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject ModelContext { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LineNumber.</summary>
		///--------------------------------------------------------------------------------
		public int LineNumber { get; set; }
		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
