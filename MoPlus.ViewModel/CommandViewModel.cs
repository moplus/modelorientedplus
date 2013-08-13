/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from the Microsoft MVVM design pattern example (http://msdn.microsoft.com/en-us/magazine/dd419663.aspx).
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MoPlus.Interpreter;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class represents an actionable item displayed by a View.</summary>
	/// 
	/// <remarks>Derived from Microsoft MVVM design pattern example (http://msdn.microsoft.com/en-us/magazine/dd419663.aspx).</remarks>
	///--------------------------------------------------------------------------------
	public class CommandViewModel : BusinessObjectBase
	{
		public CommandViewModel(string displayName, ICommand command)
		{
			if (command == null)
				throw new ArgumentNullException("command");
			
			base.Name = displayName;
			this.Command = command;
		}

		public ICommand Command { get; private set; }
	}
}
