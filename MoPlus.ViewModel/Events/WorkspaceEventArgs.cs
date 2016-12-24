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

namespace MoPlus.ViewModel.Events
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides a container for workspace related messages.</summary>
	///--------------------------------------------------------------------------------
	public class WorkspaceEventArgs : EventArgs
	{
		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Workspace.</summary>
		///--------------------------------------------------------------------------------
		public IWorkspaceViewModel Workspace { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ItemID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ItemID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the WorkspaceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid WorkspaceID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets NeedsFocus.</summary>
		///--------------------------------------------------------------------------------
		public bool NeedsFocus { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ShowItemInTreeView.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowItemInTreeView { get; set; }

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public WorkspaceEventArgs() { }

		#endregion "Constructors"
	}
}
