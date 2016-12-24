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
using System.Windows.Controls;
using System.Windows;
using MoPlus.ViewModel;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using System.Windows.Input;
using System.Text.RegularExpressions;
using MoPlus.ViewModel.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Interpreter;
using Irony.Parsing;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides base functionality for edit user controls.</summary>
	///--------------------------------------------------------------------------------
	public class EditControl : UserControl
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method handles the textbox loaded event to set focus.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void TextBox_Loaded(object sender, RoutedEventArgs e)
		{
			if (sender != null && sender is TextBox)
			{
				(sender as TextBox).Focus();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method enforces input to be numeric only.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void TextBox_PreviewNumericInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !String.IsNullOrEmpty(e.Text) && !IsTextNumeric(e.Text);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input text is numeric.</summary>
		/// 
		/// <param name="text">Input text to test.</param>
		///--------------------------------------------------------------------------------
		private bool IsTextNumeric(string text)
		{   
			Regex regex = new Regex("[^0-9.-]+");
			return !regex.IsMatch(text);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method enforces input to be numeric only.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void TextBox_NumericPasting(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(typeof(String)))
			{
				String text = (String)e.DataObject.GetData(typeof(String));
				if (!IsTextNumeric(text)) e.CancelCommand();
			}
			else e.CancelCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method subscribes to the event to confirm closes if thre are any
		/// outstanding changes, and to the event to force closes.</summary>
		///--------------------------------------------------------------------------------
		protected void Grid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (DataContext is IEditWorkspaceViewModel)
			{
				(DataContext as IEditWorkspaceViewModel).ConfirmClose -= new EventHandler(Control_ConfirmClose);
				(DataContext as IEditWorkspaceViewModel).ForceClose -= new EventHandler(Control_ForceClose);
				(DataContext as IEditWorkspaceViewModel).ConfirmClose += new EventHandler(Control_ConfirmClose);
				(DataContext as IEditWorkspaceViewModel).ForceClose += new EventHandler(Control_ForceClose);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method forces the close of the control.</summary>
		///--------------------------------------------------------------------------------
		private void Control_ForceClose(object sender, EventArgs e)
		{
			if (sender is IEditWorkspaceViewModel)
			{
				if (MessageBox.Show(DisplayValues.Message_ForceClosingItemIntro + (sender as IEditWorkspaceViewModel).TabTitle + DisplayValues.Message_ForceClosingItemEnd, DisplayValues.Message_CloseCaption, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					(sender as IEditWorkspaceViewModel).UpdateCommand.Execute(null);
				}
				(sender as IEditWorkspaceViewModel).CloseCommand.Execute(null);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method confirms the close of the control.</summary>
		///--------------------------------------------------------------------------------
		private void Control_ConfirmClose(object sender, EventArgs e)
		{
			if (sender is IEditWorkspaceViewModel)
			{
				if (MessageBox.Show(DisplayValues.Message_ClosingItemIntro + (sender as IEditWorkspaceViewModel).TabTitle + DisplayValues.Message_ClosingItemEnd, DisplayValues.Message_CloseCaption, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
				{
					(sender as IEditWorkspaceViewModel).CloseCommand.Execute(null);
				}
			}
		}
	}
}
