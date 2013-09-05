/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using MoPlus.ViewModel.Messaging;
using MoPlus.Data;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface is used for all editable workspace view models.</summary>
	///--------------------------------------------------------------------------------
	public interface IEditWorkspaceViewModel : IWorkspaceViewModel
	{
		///--------------------------------------------------------------------------------
		/// <summary>Close if there are no outstanding edits, otherwise request a confirmation.</summary>
		///--------------------------------------------------------------------------------
		ICommand CloseConfirmCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>Close, forcing a save or lose change of edits.</summary>
		///--------------------------------------------------------------------------------
		ICommand CloseForceSaveCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate resets.</summary>
		///--------------------------------------------------------------------------------
		ICommand ResetCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate default values.</summary>
		///--------------------------------------------------------------------------------
		ICommand DefaultsCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate updates.</summary>
		///--------------------------------------------------------------------------------
		ICommand UpdateCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate new items.</summary>
		///--------------------------------------------------------------------------------
		ICommand NewCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items to add (children of any type).</summary>
		///--------------------------------------------------------------------------------
		EnterpriseDataObjectList<WorkspaceViewModel> ItemsToAdd { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items to delete (children of any type).</summary>
		///--------------------------------------------------------------------------------
		EnterpriseDataObjectList<WorkspaceViewModel> ItemsToDelete { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EditItemsCount.</summary>
		///--------------------------------------------------------------------------------
		int EditItemsCount { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEdited.</summary>
		///--------------------------------------------------------------------------------
		bool IsEdited { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEditItemValid.</summary>
		///--------------------------------------------------------------------------------
		bool IsEditItemValid { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		string TabTitle { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This method puts an item into the add queue.</summary>
		/// 
		/// <param name="item">The item to add.</param>
		///--------------------------------------------------------------------------------
		void Add(WorkspaceViewModel item);

		///--------------------------------------------------------------------------------
		/// <summary>This method puts an item into the delete queue.</summary>
		/// 
		/// <param name="item">The item to delete.</param>
		///--------------------------------------------------------------------------------
		void Delete(WorkspaceViewModel item);
	}
}
