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
using System.Linq;
using System.Text;
using System.Windows.Input;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.Data;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This abstract class is for editable workspaces.</summary>
	///--------------------------------------------------------------------------------
	public abstract class EditWorkspaceViewModel : WorkspaceViewModel, IEditWorkspaceViewModel
	{
		#region "Command Processing"
		private RelayCommand _closeConfirmCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Close if there are no outstanding edits, otherwise request a confirmation.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand CloseConfirmCommand
		{
			get
			{
				if (_closeConfirmCommand == null)
					_closeConfirmCommand = new RelayCommand(param => this.OnRequestCloseConfirm());
				
				return _closeConfirmCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method closes the view model if there are no outstanding edits,
		/// otherwise it requests a confirmation to close.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnRequestCloseConfirm()
		{
			if (IsEdited == true)
			{
				OnConfirmClose(this, null);
			}
			else
			{
				Close();
			}
		}

		private RelayCommand _closeForceSaveCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Close, forcing a save or lose change of edits.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand CloseForceSaveCommand
		{
			get
			{
				if (_closeForceSaveCommand == null)
					_closeForceSaveCommand = new RelayCommand(param => this.OnCloseForceSaveCommand());

				return _closeForceSaveCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method closes the view model, saving changes if there are any
		/// outstanding edits.
		///--------------------------------------------------------------------------------
		protected virtual void OnCloseForceSaveCommand()
		{
			if (IsEdited == true)
			{
				OnForceClose(this, null);
			}
			else
			{
				Close();
			}
		}

		private RelayCommand _resetCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate resets.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand ResetCommand
		{
			get
			{
				if (_resetCommand == null)
					_resetCommand = new RelayCommand(param => this.OnReset(), param => this.CanReset());

				return _resetCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if a reset can be done.</summary>
		///--------------------------------------------------------------------------------
		protected virtual bool CanReset()
		{
			return IsEdited;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnReset()
		{
		}

		private RelayCommand _defaultsCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate default values.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand DefaultsCommand
		{
			get
			{
				if (_defaultsCommand == null)
					_defaultsCommand = new RelayCommand(param => this.OnSetDefaults(), param => this.CanSetDefaults());

				return _defaultsCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if a default value setting can be done.</summary>
		///--------------------------------------------------------------------------------
		protected virtual bool CanSetDefaults()
		{
			return true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnSetDefaults()
		{
		}

		private RelayCommand _updateCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate updates.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand UpdateCommand
		{
			get
			{
				if (_updateCommand == null)
				{
					_updateCommand = new RelayCommand(param => this.OnUpdate(), param => this.CanUpdate());
				}

				return _updateCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if an update can be done.</summary>
		///--------------------------------------------------------------------------------
		protected virtual bool CanUpdate()
		{
			return IsEdited && IsEditItemValid;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnUpdate()
		{
		}

		private RelayCommand _newCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate new items.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand NewCommand
		{
			get
			{
				if (_newCommand == null)
				{
					_newCommand = new RelayCommand(param => this.OnNew());
				}

				return _newCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnNew()
		{
		}
	
		private RelayCommand _requestShowDialogCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Close if there are no outstanding edits, otherwise request a confirmation.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand RequestShowDialogCommand
		{
			get
			{
				if (_requestShowDialogCommand == null)
				{
					_requestShowDialogCommand = new RelayCommand(param => this.OnShowDialog(this, new EventArgs()));
				}
				return _requestShowDialogCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for showing dialogs.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler ShowDialog;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles confirm close events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnShowDialog(object sender, EventArgs args)
		{
			if (ShowDialog != null)
			{
				ShowDialog(this, args);
			}
		}

		#endregion "Command Processing"

		#region "Properties"
		private readonly EnterpriseDataObjectList<WorkspaceViewModel> _itemsToAdd = new EnterpriseDataObjectList<WorkspaceViewModel>();
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items to add (children of any type).</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<WorkspaceViewModel> ItemsToAdd
		{
			get
			{
				return _itemsToAdd;
			}
		}

		private readonly EnterpriseDataObjectList<WorkspaceViewModel> _itemsToDelete = new EnterpriseDataObjectList<WorkspaceViewModel>();
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items to delete (children of any type).</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<WorkspaceViewModel> ItemsToDelete
		{
			get
			{
				return _itemsToDelete;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SourceItem.</summary>
		///--------------------------------------------------------------------------------
		public IWorkspaceViewModel SourceItem { get; set; }

		private int _editItemsCount = 0;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EditItemsCount.</summary>
		///--------------------------------------------------------------------------------
		public int EditItemsCount
		{
			get
			{
				return _editItemsCount;
			}
			set
			{
				_editItemsCount = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEdited.</summary>
		///--------------------------------------------------------------------------------
		public virtual bool IsEdited
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEditItemValid.</summary>
		///--------------------------------------------------------------------------------
		public virtual bool IsEditItemValid
		{
			get
			{
				return true;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public virtual string TabTitle
		{
			get
			{
				return Name;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method puts an item into the add queue.</summary>
		/// 
		/// <param name="item">The item to add.</param>
		///--------------------------------------------------------------------------------
		public virtual void Add(WorkspaceViewModel item)
		{
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method puts an item into the delete queue.</summary>
		/// 
		/// <param name="item">The item to delete.</param>
		///--------------------------------------------------------------------------------
		public virtual void Delete(WorkspaceViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the items.</summary>
		///--------------------------------------------------------------------------------
		public void ResetItems()
		{
			if (ItemsToAdd.Count > 0)
			{
				foreach (WorkspaceViewModel item in ItemsToAdd)
				{
					Items.Remove(item);
					item.Dispose();
				}
				ItemsToAdd.Clear();
			}
			if (ItemsToDelete.Count > 0)
			{
				foreach (WorkspaceViewModel item in ItemsToDelete)
				{
					Items.Add(item);
				}
				ItemsToDelete.Clear();
			}
			foreach (WorkspaceViewModel item in Items)
			{
				item.Reset();
			}
		}

		#endregion "Methods"
	}
}
