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
using System.ComponentModel;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Data;
using System.Collections.ObjectModel;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Events;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using MoPlus.Interpreter.BLL.Interpreter;
using System.Threading;

namespace MoPlus.ViewModel.Conventions
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for some menu operations.</summary>
    ///--------------------------------------------------------------------------------
	public class MenuViewModel : EditWorkspaceViewModel
    {
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSolution
		{
			get
			{
				return DisplayValues.Menu_NewSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelOpenSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelOpenSolution
		{
			get
			{
				return DisplayValues.Menu_OpenSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelRecentSolutions.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRecentSolutions
		{
			get
			{
				return DisplayValues.Menu_RecentSolutions;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSaveAll.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSaveAll
		{
			get
			{
				return DisplayValues.Menu_SaveAll;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelCancelJobs.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCancelJobs
		{
			get
			{
				return DisplayValues.Menu_CancelJobs;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelExit.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelExit
		{
			get
			{
				return DisplayValues.Menu_Exit;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelFile.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelFile
		{
			get
			{
				return DisplayValues.Menu_File;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelHelp.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelHelp
		{
			get
			{
				return DisplayValues.Menu_Help;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelHelpGettingStarted.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelHelpGettingStarted
		{
			get
			{
				return DisplayValues.Menu_HelpGettingStarted;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelHelpAbout.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelHelpAbout
		{
			get
			{
				return DisplayValues.Menu_HelpAbout;
			}
		}

		#endregion "Menus"

		#region "Events"
		public delegate void StatusEventHandler(object sender, StatusEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to open the solution.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler OpenSolutionRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles open solution requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnOpenSolutionRequested(object sender, EventArgs args)
		{
			if (OpenSolutionRequested != null)
			{
				OpenSolutionRequested(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to exit.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler ExitRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles exit requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnExitRequested(object sender, EventArgs args)
		{
			if (ExitRequested != null)
			{
				ExitRequested(this, args);
			}
		}

		#endregion "Events"

		#region "Command Processing"
		private RelayCommand _helpGettingStartedCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to open getting started help.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand HelpGettingStartedCommand
		{
			get
			{
				if (_helpGettingStartedCommand == null)
					_helpGettingStartedCommand = new RelayCommand(param => this.OnHelpGettingStarted());

				return _helpGettingStartedCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method opens the getting started help.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnHelpGettingStarted()
		{
			Mediator.NotifyColleagues<EventArgs>(MediatorMessages.Command_ShowGettingStartedHelpRequested, null);
		}

		private RelayCommand _helpAboutCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to open about help.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand HelpAboutCommand
		{
			get
			{
				if (_helpAboutCommand == null)
					_helpAboutCommand = new RelayCommand(param => this.OnHelpAbout());

				return _helpAboutCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method opens the about help.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnHelpAbout()
		{
			Mediator.NotifyColleagues<EventArgs>(MediatorMessages.Command_ShowAboutHelpRequested, null);
		}

		private RelayCommand _newSolutionCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to start a new solution.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand NewSolutionCommand
		{
			get
			{
				if (_newSolutionCommand == null)
					_newSolutionCommand = new RelayCommand(param => this.OnNewSolution());

				return _newSolutionCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method starts a new solution.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnNewSolution()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = new Solution();
			message.Solution.SolutionID = Guid.NewGuid();
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_EditSolutionRequested, message);
		}

		private RelayCommand _openSolutionCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to open solution.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand OpenSolutionCommand
		{
			get
			{
				if (_openSolutionCommand == null)
					_openSolutionCommand = new RelayCommand(param => this.OnOpenSolution());

				return _openSolutionCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method opens a solution.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnOpenSolution()
		{
			OnOpenSolutionRequested(this, null);
		}

		private RelayCommand _saveAllCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to save all solutions.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand SaveAllCommand
		{
			get
			{
				if (_saveAllCommand == null)
					_saveAllCommand = new RelayCommand(param => this.OnSaveAll());

				return _saveAllCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method saves all solutions.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnSaveAll()
		{
			Mediator.NotifyColleagues<EventArgs>(MediatorMessages.Command_SaveAllSolutionsRequested, null);
		}

		private RelayCommand _exitCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to exit the application.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand ExitCommand
		{
			get
			{
				if (_exitCommand == null)
					_exitCommand = new RelayCommand(param => this.OnExit());

				return _exitCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method exits the application.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnExit()
		{
			OnExitRequested(this, null);
		}

		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelShow.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelShow
		{
			get
			{
				return DisplayValues.Help_Show;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RecentSolution lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<RecentSolution> RecentSolutions
		{
			get
			{
				return BusinessConfiguration.RecentSolutionList;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method opens a solution.</summary>
		///--------------------------------------------------------------------------------
		public void OpenSolution(string path)
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Path = path;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_OpenSolutionRequested, message);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public MenuViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		#endregion "Constructors"
    }
}
