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
using MoPlus.ViewModel;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.SolutionBuilder.WpfClient.Resources;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls
{
	/// <summary>
	/// Interaction logic for Status.xaml
	/// </summary>
	public partial class Status : UserControl
	{
		public Status()
		{
			InitializeComponent();
			StatusViewModel = new StatusViewModel();
			StatusViewModel.ProgressChanged += new ViewModel.StatusViewModel.StatusChangeEventHandler(StatusViewModel_ProgressChanged);
			StatusViewModel.StatusChanged += new ViewModel.StatusViewModel.StatusChangeEventHandler(StatusViewModel_StatusChanged);
			this.Unloaded += new RoutedEventHandler(Status_Unloaded);
		}

		#region "Properties and Fields"

		public StatusViewModel StatusViewModel { get; set; }
		List<OKDialog> dialogs = new List<OKDialog>();
		#endregion "Properties and Fields"

		#region "Methods"
		void Status_Unloaded(object sender, RoutedEventArgs e)
		{
			while (dialogs.Count > 0)
			{
				dialogs[0].Close();
			}
		}

		void StatusViewModel_ProgressChanged(object sender, StatusEventArgs args)
		{
			if (args != null)
			{
				lblStatus.Content = args.Title;
				prgStatus.Value = args.CompletedWork;
				if (args.TotalWork <= 0)
				{
					prgStatus.Visibility = System.Windows.Visibility.Hidden;
				}
				else
				{
					prgStatus.Visibility = System.Windows.Visibility.Visible;
				}
			}
		}

		delegate void StatusViewModel_StatusChangedCallback(object sender, StatusEventArgs args);
		void StatusViewModel_StatusChanged(object sender, StatusEventArgs args)
		{
			if (lblStatus.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
			{
				StatusViewModel_StatusChangedCallback callback = new StatusViewModel_StatusChangedCallback(StatusViewModel_StatusChanged);
				this.Dispatcher.Invoke(callback, new object[] { sender, args });
			}
			else
			{
				if (args != null)
				{
					lblStatus.Content = args.Text;
					if (args.ShowMessageBox == true)
					{
						if (args.ShowMessageBox == true)
						{
							DialogViewModel dialogView = new DialogViewModel();
							dialogView.Text = args.Text;
							if (String.IsNullOrEmpty(args.Title))
							{
								dialogView.Title = DisplayValues.Message_IssueCaption;
							}
							else
							{
								dialogView.Title = args.Title;
							}
							if (dialogs.Count > 0 && dialogs[dialogs.Count - 1].IsVisible == true)
							{
								dialogs[dialogs.Count - 1].LoadViewModel(dialogView);
							}
							else
							{
								OKDialog dialog = new OKDialog(dialogView);
								//dialog.Owner = VisualItemHelper.FindParent<Window>(this);
								dialogs.Add(dialog);
								dialog.Closed += new EventHandler(dialog_Closed);
								dialog.Show();
							}
						}
					}
				}
			}
		}

		void dialog_Closed(object sender, EventArgs e)
		{
			if (sender is OKDialog)
			{
				dialogs.Remove(sender as OKDialog);
			}
		}

		#endregion "Methods"

	}
}
