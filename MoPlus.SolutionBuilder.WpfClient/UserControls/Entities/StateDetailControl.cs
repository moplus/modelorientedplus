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
using MoPlus.SolutionBuilder.WpfClient.Library;
using Microsoft.Win32;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary>Interaction logic for StateDetailControl_G.xaml.</summary>
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/18/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class StateDetailControl : EditControl
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the new command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = DataContext is StateViewModel;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the new command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (DataContext is StateViewModel)
			{
				(DataContext as StateViewModel).AddNewStateTransition();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the delete command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void PreviewDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ItemsGrid.SelectedItem != null;
			e.Handled = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the delete item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (DataContext is IWorkspaceViewModel)
			{
				if (MessageBox.Show(DisplayValues.Message_DeleteItemConfirmation, DisplayValues.Message_DeleteItemConfirmationCaption, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
				{
					if (ItemsGrid.SelectedItem is StateTransitionViewModel && DataContext is StateViewModel)
					{
						(DataContext as StateViewModel).AddToDeletedStateTransitions(ItemsGrid.SelectedItem as StateTransitionViewModel);
					}
				}
			}
		}
	}
}
