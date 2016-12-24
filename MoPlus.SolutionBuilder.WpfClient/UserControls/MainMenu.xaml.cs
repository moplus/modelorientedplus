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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoPlus.ViewModel.Conventions;
using Microsoft.Win32;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
			DataContext = MenuView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DesignerView.</summary>
		///--------------------------------------------------------------------------------
		protected MenuViewModel _menuView = null;
		public MenuViewModel MenuView
		{
			get
			{
				if (_menuView == null)
				{
					_menuView = new MenuViewModel();
					_menuView.OpenSolutionRequested += new EventHandler(_menuView_OpenSolutionRequested);
					_menuView.ExitRequested += new EventHandler(_menuView_ExitRequested);
				}
				return _menuView;
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

		void _menuView_ExitRequested(object sender, EventArgs e)
		{
			OnExitRequested(sender, e);
		}

		void _menuView_OpenSolutionRequested(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = ".xml";
			dialog.Filter = "Xml Documents (.xml)|*.xml";
			bool? result = dialog.ShowDialog();
			if (result == true)
			{
				MenuView.OpenSolution(dialog.FileName);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the open command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the open command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (e != null && e.Parameter is String && DataContext is MenuViewModel)
			{
				Mouse.OverrideCursor = Cursors.Wait;
				(DataContext as MenuViewModel).OpenSolution(e.Parameter as String);
				Mouse.OverrideCursor = null;
			}
		}

	}
}
