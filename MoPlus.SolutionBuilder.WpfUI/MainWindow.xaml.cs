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
using System.Diagnostics;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter;
using MoPlus.Data;
using System.IO;
using MoPlus.SolutionBuilder.WpfClient.Library;

namespace MoPlus.SolutionBuilder.WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			solutionModel.OpenOutputSolutionRequested += new WpfClient.UserControls.SolutionBuilderControl.SolutionEventHandler(solutionModel_OpenOutputSolutionRequested);
			LocationChanged += new EventHandler(MainWindow_LocationChanged);
			SizeChanged += new SizeChangedEventHandler(MainWindow_SizeChanged);
			Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
			mainMenu.ExitRequested += new EventHandler(mainMenu_ExitRequested);

			// get window settings from registry right away
			bool maximizeWindow = BusinessConfiguration.IsWindowMaximized;
			double width = BusinessConfiguration.WindowWidth;
			double height = BusinessConfiguration.WindowHeight;
			double x = BusinessConfiguration.WindowX;
			if (x < 0) x = 0;
			double y = BusinessConfiguration.WindowY;
			if (y < 0) y = 0;

			// reset the window size from registry settings
			if (maximizeWindow == true)
			{
				// keep window maximized
				WindowState = WindowState.Maximized;
			}
			else
			{
				// resize by width and height
				if (width != DefaultValue.Int)
				{
					Width = width;
				}
				if (height != DefaultValue.Int)
				{
					Height = height;
				}
				if (x != DefaultValue.Int && y != DefaultValue.Int)
				{
					Left = x;
					Top = y;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles exiting the application via the menu.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void mainMenu_ExitRequested(object sender, EventArgs e)
		{
			if (WindowCanClose() == true)
			{
				// close any open dialogs
				FindReplaceMgr.Instance.CloseWindow();
				Application.Current.Shutdown();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles exiting the application.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (WindowCanClose() == false)
			{
				e.Cancel = true;
			}
			else
			{
				// close any open dialogs
				FindReplaceMgr.Instance.CloseWindow();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method tries to close all open solutions.</summary>
		/// 
		/// <returns>Returns true if all solutions closed, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		bool WindowCanClose()
		{
			return solutionModel.CloseAllSolutions(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles saving the window resize settings.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				BusinessConfiguration.IsWindowMaximized = true;
			}
			else
			{
				BusinessConfiguration.IsWindowMaximized = false;
				BusinessConfiguration.WindowWidth = Width;
				BusinessConfiguration.WindowHeight = Height;
				BusinessConfiguration.WindowX = Left;
				BusinessConfiguration.WindowY = Top;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles saving the window move settings.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void MainWindow_LocationChanged(object sender, EventArgs e)
		{
			BusinessConfiguration.WindowWidth = Width;
			BusinessConfiguration.WindowHeight = Height;
			BusinessConfiguration.WindowX = Left;
			BusinessConfiguration.WindowY = Top;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles opening an output solution.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="args">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void solutionModel_OpenOutputSolutionRequested(object sender, ViewModel.Events.Solutions.SolutionEventArgs args)
		{
			try
			{
				if (File.Exists(args.Path))
				{
					ProcessStartInfo info = new ProcessStartInfo();
					info.FileName = args.Path;
					Process p = new Process();
					p.StartInfo = info;
					p.Start();
					//Process.Start(@"devenv", "/ranu /rootsuffix Exp " + solutionPath);
					//Process.Start(@"devenv", "\"" + args.Path + "\"");
				}
			}
			catch { }
		}
    }
}
