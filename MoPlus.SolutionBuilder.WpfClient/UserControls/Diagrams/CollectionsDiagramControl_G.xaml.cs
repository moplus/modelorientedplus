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
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Workflows;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Entities;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary>Interaction logic for CollectionsDiagramControl_G.xaml.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize, change the Status value below to something
	/// other than Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>5/31/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class CollectionsDiagramControl : EditControl
	{
		#region "Properties"

		// the start point of the drag operation
		private Point? dragStartPoint = null;
		bool isDragging = false;
		private Window dialog;

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the parent entity diagram control.</summary>
		///--------------------------------------------------------------------------------
		private EntityDiagramControl ParentEntityDiagramControl
		{
			get
			{
				return VisualItemHelper.VisualUpwardSearch<EntityDiagramControl>(this) as EntityDiagramControl; ;
			}
		}
		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method handles the preview mouse down event.</summary>
		///
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				dragStartPoint = new Point?(e.GetPosition(this));
			}
			else
			{
				dragStartPoint = null;
				isDragging = false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the drag leave event.</summary>
		///
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected override void OnDragLeave(DragEventArgs e)
		{
			base.OnDragLeave(e);
			e.Handled = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the preview mouse move event.</summary>
		///
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected override void OnPreviewMouseMove(MouseEventArgs e)
		{
			if (e.LeftButton != MouseButtonState.Pressed)
			{
				dragStartPoint = null;
				isDragging = false;
			}
			else if (dragStartPoint.HasValue && isDragging == false)
			{
				Point? currentPosition = new Point?(e.GetPosition(this));
				if (currentPosition.HasValue && (Math.Abs(currentPosition.Value.X - dragStartPoint.Value.X) > 10 || Math.Abs(currentPosition.Value.Y - dragStartPoint.Value.Y) > 10))
				{
					isDragging = true;
					DragDrop.DoDragDrop(this, DataContext, DragDropEffects.Link);
					e.Handled = true;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the datagrid mouse down event.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (MainGrid.SelectedItem is IWorkspaceViewModel)
			{
				(MainGrid.SelectedItem as IWorkspaceViewModel).SetSelected();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the request close event.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void Item_RequestClose(object sender, EventArgs e)
		{
			dialog.Close();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the new command can execute.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the execution of the new command.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			Point currentPosition = MouseUtilities.GetMousePosition(this);
			CollectionsViewModel items = DataContext as CollectionsViewModel;
			EntityDiagramControl diagram = VisualItemHelper.VisualUpwardSearch<EntityDiagramControl>(this) as EntityDiagramControl;
			DiagramEntityViewModel diagramEntityView = diagram.DataContext as DiagramEntityViewModel;
			if (items != null && diagramEntityView != null)
			{
				dialog = new Window();
				dialog.Height = 450 * UserSettingsHelper.Instance.ControlSize;
				dialog.Width = 400 * UserSettingsHelper.Instance.ControlSize;
				dialog.Left = Math.Max(currentPosition.X, 20);
				dialog.Top = Math.Max(currentPosition.Y, 20);
				dialog.Content = new CollectionDialogControl();
				Collection newItem = new Collection();
				newItem.PropertyID = Guid.NewGuid();
				newItem.Solution = items.Solution;
				newItem.Entity = items.Entity;
				//newItem.ReferenceEntity = diagramEntityView.DiagramEntity.Entity;
				CollectionViewModel newItemView = new CollectionViewModel(newItem, items.Solution);
				newItemView.IsFreeDialog = true;
				dialog.DataContext = newItemView;
				dialog.Title = newItemView.Title;
				newItemView.RequestClose += new EventHandler(Item_RequestClose);
				#region protected
				#endregion protected
				dialog.ShowDialog();
				if (newItemView.IsOK == true)
				{
					items.AddCollection(newItemView);
				}
				dialog.Close();
				dialog = null;
				e.Handled = true;
				return;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the delete command can execute.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void PreviewDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			CollectionsViewModel items = DataContext as CollectionsViewModel;
			if (items != null)
			{
				foreach (CollectionViewModel item in items.Collections)
				{
					if (item.IsSelected == true)
					{
						e.CanExecute = true;
						return;
					}
				}
			}
			e.CanExecute = false;
			e.Handled = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the execution of the delete command.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			CollectionsViewModel items = DataContext as CollectionsViewModel;
			if (items != null)
			{
				foreach (CollectionViewModel item in items.Collections)
				{
					if (item.IsSelected == true)
					{
						if (MessageBox.Show(DisplayValues.Message_DeleteItemConfirmation, DisplayValues.Message_DeleteItemConfirmationCaption, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
						{
							items.DeleteCollection(item);
						}
						return;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles preview right mouse button down.</summary>
		///
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Expander_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			MainExpander.Focus();
		}
		#endregion "Methods"

		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor, calling InitializeComponent().</summary>
		///--------------------------------------------------------------------------------
		public CollectionsDiagramControl()
		{
			InitializeComponent();
		}
		#endregion "Constructors"
	}
}
