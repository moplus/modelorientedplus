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
using MoPlus.ViewModel;
using MoPlus.ViewModel.Diagrams;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls
{
	///--------------------------------------------------------------------------------
	/// Interaction logic for SolutionDesignerControl.xaml
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/12/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionDesignerControl : UserControl
	{
		public SolutionDesignerControl()
		{
			InitializeComponent();
			DataContext = DesignerView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DesignerView.</summary>
		///--------------------------------------------------------------------------------
		protected DesignerViewModel _designerView = null;
		public DesignerViewModel DesignerView
		{
			get
			{
				if (_designerView == null)
				{
					_designerView = new DesignerViewModel();
				}
				return _designerView;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the close tab command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CloseTabExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (tabDesigner.ActiveContent is IEditWorkspaceViewModel)
			{
				(tabDesigner.ActiveContent as IEditWorkspaceViewModel).CloseConfirmCommand.Execute(null);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the close other tabs command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CloseOtherTabsExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (tabDesigner.ActiveContent is IEditWorkspaceViewModel)
			{
				DesignerView.CloseAllItemsButThis((tabDesigner.ActiveContent as IEditWorkspaceViewModel));
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method selects a tree view item on right mouse down.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			TabItem tabItem = VisualItemHelper.VisualUpwardSearch<TabItem>(e.OriginalSource as DependencyObject) as TabItem;
			if (tabItem != null)
			{
				tabItem.Focus();
				e.Handled = true;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method causes the currently selected item in the designer to be
		/// selected and shown in the tree view.</summary>
		/// 
		/// <param name="itemToShow">The item to show in the tree view.</param>
		///--------------------------------------------------------------------------------
		private void ShowItem()
		{
			if (tabDesigner.ActiveContent is IEditWorkspaceViewModel)
			{
				DesignerView.ShowItemInTreeView(tabDesigner.ActiveContent as IEditWorkspaceViewModel);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method shows the current tab item in the tree view.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void tabDesigner_PreviewMouseDown(object sender, MouseEventArgs e)
		{
			ShowItem();
			DesignerView.SelectedItem = null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method shows the current tab item in the tree view.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void tabDesigner_SelectionChanged(object sender, EventArgs e)
		{
			if (DesignerView.SelectedItem != null && DesignerView.SelectedItem.IsSelected == false)
			{
				// TODO: this is to get around an AvalonDock issue only, remove SelectedItem property when AvalonDock issue resolved
				DesignerView.SelectedItem.IsSelected = true;
			}
			else
			{
				if (tabDesigner.ActiveContent is DiagramViewModel)
				{
					// wait cursor to load diagrams
					Mouse.OverrideCursor = Cursors.Wait;
				}
				ShowItem();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the cursor after layout.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void tabDesigner_LayoutUpdated(object sender, EventArgs e)
		{
			Mouse.OverrideCursor = null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method moves selection/focus to next tab or document.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NextTabExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			bool foundItem = false;
			foreach (var document in tabDesigner.DocumentsSource)
			{
				if (foundItem == true && document is IEditWorkspaceViewModel)
				{
					(document as IEditWorkspaceViewModel).IsSelected = true;
					tabDesigner.ActiveContent = document;
					return;
				}
				if (document == tabDesigner.ActiveContent)
				{
					foundItem = true;
				}
			}
			foreach (var document in tabDesigner.DocumentsSource)
			{
				if (document is IEditWorkspaceViewModel)
				{
					(document as IEditWorkspaceViewModel).IsSelected = true;
					tabDesigner.ActiveContent = document;
					return;
				}
			}
		}
	}
}
