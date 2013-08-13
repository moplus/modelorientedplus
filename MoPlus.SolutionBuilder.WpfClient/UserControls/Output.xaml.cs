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
using MoPlus.SolutionBuilder.WpfClient.Library;
using MoPlus.Interpreter;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls
{
	/// <summary>
	/// Interaction logic for Output.xaml
	/// </summary>
	public partial class Output : UserControl
	{
		public Output()
		{
			InitializeComponent();
			OutputViewModel = new OutputViewModel();
			OutputViewModel.OutputChanged += new ViewModel.OutputViewModel.StatusChangeEventHandler(OutputViewModel_OutputChanged);
			DataContext = OutputViewModel;
		}

		#region "Properties and Fields"

		public OutputViewModel OutputViewModel { get; set; }
		#endregion "Properties and Fields"

		#region "Methods"
		delegate void OutputViewModel_OutputChangedCallback(object sender, StatusEventArgs args);
		void OutputViewModel_OutputChanged(object sender, StatusEventArgs args)
		{
			if (txtOutput.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
			{
				OutputViewModel_OutputChangedCallback callback = new OutputViewModel_OutputChangedCallback(OutputViewModel_OutputChanged);
				this.Dispatcher.Invoke(callback, new object[] { sender, args});
			}
			else
			{
				if (args != null)
				{
					ShowOutput(args.Text, args.Title, args.AppendText);
				}
			}
		}

		delegate void ShowOutputCallback(string outputMessage, string outputTitle, bool appendMessage);
		///--------------------------------------------------------------------------------
		/// <summary>This method displays a message in the output area.</summary>
		/// 
		/// <param name="outputMessage">The message to show.</param>
		/// <param name="outputTitle">The title for the message.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		///--------------------------------------------------------------------------------
		public void ShowOutput(string outputMessage, string outputTitle, bool appendMessage)
		{
			if (txtOutput.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
			{
				ShowOutputCallback callback = new ShowOutputCallback(ShowOutput);
				this.Dispatcher.Invoke(callback, new object[] { outputTitle, outputMessage, appendMessage });
			}
			else
			{
				txtOutput.Focusable = false;
				if (txtOutput.Text.Length > BusinessConfiguration.MaxOutputSizeInBytes)
				{
					txtOutput.Text = string.Empty;
				}
				if (!String.IsNullOrEmpty(txtOutput.Text))
				{
					if (appendMessage == false)
					{
						txtOutput.Text = "\r\n";
					}
					else
					{
						txtOutput.Text = txtOutput.Text + "\r\n";
					}
				}
				if (!String.IsNullOrEmpty(outputTitle))
				{
					txtOutput.Text = txtOutput.Text + "\r\n" + outputTitle;
				}
				txtOutput.Text = txtOutput.Text + "\r\n" + outputMessage;
				txtOutput.SelectionStart = txtOutput.Text.Length;
				txtOutput.ScrollToEnd();
				txtOutput.Focusable = true;
			}
		}

		private void ClearTextCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void ClearTextExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			txtOutput.Text = String.Empty;
		}

		#endregion "Methods"
	}
}
