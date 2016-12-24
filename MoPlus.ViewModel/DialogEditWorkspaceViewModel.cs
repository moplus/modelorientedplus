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
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel
{
    ///--------------------------------------------------------------------------------
    /// <summary>This abstract class requests is for dialog edit workspaces.</summary>
    ///--------------------------------------------------------------------------------
	public abstract class DialogEditWorkspaceViewModel : EditWorkspaceViewModel, IDialogEditWorkspaceViewModel
	{
		#region "Command Processing"
		private RelayCommand _okCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate OK.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand OKCommand
		{
			get
			{
				if (_okCommand == null)
					_okCommand = new RelayCommand(param => this.OnOK(), param => this.CanOK());

				return _okCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method closes the view model with an OK.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnOK()
		{
			IsOK = true;
			Close();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if an ok can be done.</summary>
		///--------------------------------------------------------------------------------
		protected virtual bool CanOK()
		{
			return IsEdited && IsEditItemValid;
		}

		private RelayCommand _cancelCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate cancel.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand CancelCommand
		{
			get
			{
				if (_cancelCommand == null)
					_cancelCommand = new RelayCommand(param => this.OnCancel());

				return _cancelCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method cancels the edit.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnCancel()
		{
			IsOK = false;
			Close();
		}

		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsOK.</summary>
		///--------------------------------------------------------------------------------
		public bool IsOK { get; set; }

		private bool _isFreeDialog = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsFreeDialog.</summary>
		///--------------------------------------------------------------------------------
		public bool IsFreeDialog
		{
			get
			{
				return _isFreeDialog;
			}
			set
			{
				_isFreeDialog = value;
			}
		}
		#endregion "Properties"
    }
}
