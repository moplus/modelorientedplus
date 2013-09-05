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
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.ViewModel.Events
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides a container for model related messages.</summary>
    ///--------------------------------------------------------------------------------
	public class SolutionModelEventArgs : EventArgs
    {
        #region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the WorkspaceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid WorkspaceID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the solution id.</summary>
		///--------------------------------------------------------------------------------
		public Guid SolutionID { get; set; }

		private Solution _solution;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Solution.</summary>
		///--------------------------------------------------------------------------------
		public Solution Solution
		{
			get
			{
				return _solution;
			}
			set
			{
				_solution = value;
				if (_solution != null && _solution.SolutionID != Guid.Empty)
				{
					SolutionID = _solution.SolutionID;
				}
			}
		}

		private bool _showItemInTreeView = true;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ShowItemInTreeView.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowItemInTreeView
		{
			get
			{
				return _showItemInTreeView;
			}
			set
			{
				_showItemInTreeView = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SolutionModelEventArgs() { }

		#endregion "Constructors"
	}
}
