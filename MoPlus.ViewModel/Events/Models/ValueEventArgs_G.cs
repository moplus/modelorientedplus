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
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Models;

namespace MoPlus.ViewModel.Events.Models
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides a container for Value related messages.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/9/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ValueEventArgs : SolutionModelEventArgs
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ValueID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ValueID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the EnumerationID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EnumerationID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Value.</summary>
		///--------------------------------------------------------------------------------
		public Value Value { get; set; }

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ValueEventArgs() { }

		#endregion "Constructors"
	}
}
