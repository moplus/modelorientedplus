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
using System.Diagnostics;
using System.Windows.Input;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class represents command whose sole purpose is to relay its functionality
	/// to other objects by invoking delegates. The default return value for the CanExecute
	/// method is 'true'.</summary>
	/// 
	/// <remarks>Derived from Microsoft MVVM design pattern example (http://msdn.microsoft.com/en-us/magazine/dd419663.aspx).</remarks>
	///--------------------------------------------------------------------------------
	public class RelayCommand : ICommand
	{
		#region Fields
		
		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute;
		
		#endregion // Fields
		
		#region Constructors
		
		/// <summary>
		/// Creates a new command that can always execute.
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		public RelayCommand(Action<object> execute) : this(execute, null)
		{
		}

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		/// <param name="canExecute">The execution status logic.</param>
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
			    throw new ArgumentNullException("execute");
			
			_execute = execute;
			_canExecute = canExecute;
		}
		
		#endregion // Constructors
		
		#region ICommand Members
		
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}
		
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		
		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		#endregion // ICommand Members
	}
}
