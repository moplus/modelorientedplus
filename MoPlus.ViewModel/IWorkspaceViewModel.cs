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
using MoPlus.ViewModel.Messaging;
using MoPlus.Data;
using System.Windows.Input;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface is used for all workspace view models.</summary>
	///--------------------------------------------------------------------------------
	public interface IWorkspaceViewModel : IEnterpriseDataObject, IDataErrorInfo, INotifyPropertyChanged, IDisposable
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		string Name { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
		///--------------------------------------------------------------------------------
		ICommand CloseCommand { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling general updates.</summary>
		///--------------------------------------------------------------------------------
		event EventHandler Updated;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling initial loads.</summary>
		///--------------------------------------------------------------------------------
		event EventHandler Loaded;

		///--------------------------------------------------------------------------------
		/// <summary>Raised when this workspace should be removed from the UI.</summary>
		///--------------------------------------------------------------------------------
		event EventHandler RequestClose;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for requesting close confirmations.</summary>
		///--------------------------------------------------------------------------------
		event EventHandler ConfirmClose;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for requesting close force confirmations.</summary>
		///--------------------------------------------------------------------------------
		event EventHandler ForceClose;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling selections.</summary>
		///--------------------------------------------------------------------------------
		event EventHandler Selected;

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items (children of any type).</summary>
		///--------------------------------------------------------------------------------
		EnterpriseDataObjectList<WorkspaceViewModel> Items { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of selected items (children of any type).</summary>
		///--------------------------------------------------------------------------------
		EnterpriseDataObjectList<WorkspaceViewModel> SelectedItems { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the view model has errors.</summary>
		///--------------------------------------------------------------------------------
		bool HasErrors { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the view model has customizations.</summary>
		///--------------------------------------------------------------------------------
		bool HasCustomizations { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the workspace id.</summary>
		///--------------------------------------------------------------------------------
		Guid WorkspaceID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the solution id.</summary>
		///--------------------------------------------------------------------------------
		Guid SolutionID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Solution.</summary>
		///--------------------------------------------------------------------------------
		Solution Solution { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the item id.</summary>
		///--------------------------------------------------------------------------------
		Guid ItemID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the mediator for passing messages with data.</summary>
		///--------------------------------------------------------------------------------
		Mediator Mediator { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item is expanded.</summary>
		///--------------------------------------------------------------------------------
		bool IsExpanded { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item is selected.</summary>
		///--------------------------------------------------------------------------------
		bool IsSelected { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropogateCurrentItem.</summary>
		///--------------------------------------------------------------------------------
		bool PropogateCurrentItem { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item needs focus.</summary>
		///--------------------------------------------------------------------------------
		bool NeedsFocus { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		void Reset();

		///--------------------------------------------------------------------------------
		/// <summary>This method handles sets the item as (re)selected and triggers the
		/// OnSelected event.</summary>
		///--------------------------------------------------------------------------------
		void SetSelected();

		///--------------------------------------------------------------------------------
		/// <summary>This method clears selected items.</summary>
		///--------------------------------------------------------------------------------
		void ClearSelectedItems();

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an exception.</summary>
		/// 
		/// <param name="ex">The exception to show.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		void ShowException(Exception ex, bool showMessageBox = true);

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an exception.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="statusTitle">The optional title to display</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		void ShowIssue(string statusMessage, string statusTitle = null, bool showMessageBox = true);

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display a status message.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		///--------------------------------------------------------------------------------
		void ShowStatus(string statusMessage);

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display a status message.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="statusTitle">The title for the message.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		void ShowStatus(string statusMessage, string statusTitle = null, bool appendMessage = true, bool showMessageBox = false);

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an output message.</summary>
		/// 
		/// <param name="outputMessage">The message to show.</param>
		/// <param name="outputTitle">The title for the message.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		void ShowOutput(string outputMessage, string outputTitle, bool appendMessage, bool isException = false, bool showMessageBox = false);

		///--------------------------------------------------------------------------------
		/// <summary>This method reports progress in the status area.</summary>
		/// 
		/// <param name="inProgress">In progress.</param>
		/// <param name="statusLabel">The label for the progress bar.</param>
		/// <param name="completed">The amount of progress completed.</param>
		/// <param name="total">The total amount of work to do.</param>
		///--------------------------------------------------------------------------------
		void ReportProgress(int inProgress, string statusLabel, uint completed, uint total);

		///--------------------------------------------------------------------------------
		/// <summary>This method sets IsExpanded locally.</summary>
		///--------------------------------------------------------------------------------
		void SetExpanded(bool expanded);

		///--------------------------------------------------------------------------------
		/// <summary>This method causes child items to be collapsed.</summary>
		///--------------------------------------------------------------------------------
		void CollapseItems();

	}
}
