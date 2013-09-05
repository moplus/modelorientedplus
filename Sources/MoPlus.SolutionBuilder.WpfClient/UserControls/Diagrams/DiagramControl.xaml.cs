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
using MoPlus.ViewModel.Diagrams;
using MoPlus.SolutionBuilder.WpfClient.Library;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Entities;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Entities;
using MoPlus.Interpreter.BLL.Entities;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams
{
	/// <summary>
	/// Interaction logic for DiagramControl.xaml
	/// </summary>
	public partial class DiagramControl : EditControl
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ToolBoxDiagramControl.</summary>
		///--------------------------------------------------------------------------------
		private ToolBoxDiagramControl ToolBoxDiagramControl { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EntitiesControl.</summary>
		///--------------------------------------------------------------------------------
		private ToolBoxEntitiesControl EntitiesControl { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertiesControl.</summary>
		///--------------------------------------------------------------------------------
		private ToolBoxPropertiesControl PropertiesControl { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ZoomControl.</summary>
		///--------------------------------------------------------------------------------
		private ToolBoxZoomControl ZoomControl { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets NeedsFocus.</summary>
		///--------------------------------------------------------------------------------
		private bool NeedsFocus { get; set; }

		public DiagramControl()
		{
			InitializeComponent();

			ToolBoxDiagramControl = new ToolBoxDiagramControl();
			EntitiesControl = new ToolBoxEntitiesControl();
			PropertiesControl = new ToolBoxPropertiesControl();
			ZoomControl = new ToolBoxZoomControl();
			ZoomControl.ScrollViewer = DesignerScrollViewer;
			DataContextChanged += new DependencyPropertyChangedEventHandler(DiagramControl_DataContextChanged);
			NeedsFocus = true;
		}

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);

			// handling custom drop is disabled until there is a more stable way
			// to utilize the draw arc adorner and identify the entity being dropped
			// upon in all diagram scale scenarios
			//HandleCustomDrop();
		}

		public void HandleCustomDrop()
		{
			// handle "drop" of relationship in custom drag/drop approach with arc drawing adorner
			if (DragItem is DiagramRelationshipViewModel)
			{
				DiagramViewModel diagramView = DataContext as DiagramViewModel;
				DiagramEntityViewModel diagramEntityView = GetMouseOverEntity();
				DiagramRelationshipViewModel dragRelationship = DragItem as DiagramRelationshipViewModel;
				Point currentPosition = MouseUtilities.GetMousePosition(this);
				if (dragRelationship != null && diagramEntityView != null)
				{
					dragRelationship.SinkDiagramEntityViewModel = diagramEntityView;
					dragRelationship.Diagram = diagramView;
					dialog = new Window();
					dialog.Height = 450 * UserSettingsHelper.Instance.ControlSize;
					dialog.Width = 650 * UserSettingsHelper.Instance.ControlSize;
					dialog.Left = Math.Max(currentPosition.X, 20);
					dialog.Top = Math.Max(currentPosition.Y, 20);
					dialog.Content = new RelationshipDialogControl();
					Relationship newRelationship = new Relationship();
					newRelationship.RelationshipID = Guid.NewGuid();
					newRelationship.Solution = dragRelationship.Solution;
					newRelationship.ReferencedEntity = dragRelationship.SinkDiagramEntityViewModel.DiagramEntity.Entity;
					newRelationship.Entity = dragRelationship.SourceDiagramEntityViewModel.DiagramEntity.Entity;
					RelationshipViewModel newRelationshipView = new RelationshipViewModel(newRelationship, dragRelationship.Solution);
					dialog.DataContext = newRelationshipView;
					dialog.Title = newRelationshipView.Title;
					newRelationshipView.RequestClose += new EventHandler(Item_RequestClose);

					dialog.ShowDialog();
					if (newRelationshipView.IsOK == true)
					{
						dragRelationship.RelationshipViewModel = newRelationshipView;
						diagramView.CreateRelationship(dragRelationship);
					}
					dialog.Close();
					dialog = null;
				}
			}
			IsDragging = false;
			DragItem = null;
		}
		DiagramEntityViewModel GetMouseOverEntity()
		{
			Point currentPosition = MouseUtilities.GetMousePosition(this);
			DiagramViewModel diagramView = DataContext as DiagramViewModel;
			foreach (DiagramEntityViewModel entity in diagramView.Items.OfType<DiagramEntityViewModel>())
			{
				EntityDiagramControl entityControl = VisualItemHelper.FindChild<EntityDiagramControl>(this, entity);
				if (entityControl != null)
				{
					if (entity.X < currentPosition.X
						&& currentPosition.X < (entity.X + entityControl.ActualWidth)
						&& entity.Y < currentPosition.Y
						&& currentPosition.Y < (entity.Y + entityControl.ActualHeight))
					{
						return entity;
					}
				}
			}
			return null;
		}
		void Item_RequestClose(object sender, EventArgs e)
		{
			dialog.Close();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.LeftButton != MouseButtonState.Pressed)
			{
				IsDragging = false;
				//DragItem = null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether an item is being dragged.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty IsDraggingProperty = DependencyProperty.Register("IsDragging", typeof(bool), typeof(DiagramControl));
		public bool IsDragging
		{
			get
			{
				return (bool)GetValue(IsDraggingProperty);
			}
			set
			{
				SetValue(IsDraggingProperty, value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether an item is being dragged.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty DragItemProperty = DependencyProperty.Register("DragItem", typeof(IWorkspaceViewModel), typeof(DiagramControl));
		public IWorkspaceViewModel DragItem
		{
			get
			{
				return (IWorkspaceViewModel)GetValue(DragItemProperty);
			}
			set
			{
				SetValue(DragItemProperty, value);
			}
		}

		void DiagramControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (DataContext != null)
			{
				DesignerCanvas canvas = VisualItemHelper.FindChild<DesignerCanvas>(DesignerScrollViewer);
				UpdateScrollAndScale(canvas);
			}
			NeedsFocus = true;
		}

		private void btnZoomBox_Click(object sender, RoutedEventArgs e)
		{
			if (ToolBoxPanel.Children.Contains(ZoomControl) == true)
			{
				Undock(ZoomControl);
				ZoomBoxUndocked.Visibility = System.Windows.Visibility.Visible;
				ZoomBoxDocked.Visibility = System.Windows.Visibility.Collapsed;
				HideUndockedPane();
			}
			else if (ToolBoxUndockedPanel.Children.Contains(ZoomControl) == true)
			{
				Dock(ZoomControl);
				ZoomBoxDocked.Visibility = System.Windows.Visibility.Visible;
				ZoomBoxUndocked.Visibility = System.Windows.Visibility.Collapsed;
			}
			else
			{
				Undock(ZoomControl);
				ZoomBoxUndocked.Visibility = System.Windows.Visibility.Visible;
				ZoomBoxDocked.Visibility = System.Windows.Visibility.Collapsed;
			}
		}

		private void btnDiagramToolBox_Click(object sender, RoutedEventArgs e)
		{
			if (ToolBoxPanel.Children.Contains(ToolBoxDiagramControl) == true)
			{
				Undock(ToolBoxDiagramControl);
				DiagramUndocked.Visibility = System.Windows.Visibility.Visible;
				DiagramDocked.Visibility = System.Windows.Visibility.Collapsed;
				HideUndockedPane();
			}
			else if (ToolBoxUndockedPanel.Children.Contains(ToolBoxDiagramControl) == true)
			{
				Dock(ToolBoxDiagramControl);
				DiagramDocked.Visibility = System.Windows.Visibility.Visible;
				DiagramUndocked.Visibility = System.Windows.Visibility.Collapsed;
			}
			else
			{
				Undock(ToolBoxDiagramControl);
				DiagramUndocked.Visibility = System.Windows.Visibility.Visible;
				DiagramDocked.Visibility = System.Windows.Visibility.Collapsed;
			}
		}

		private void btnPropertiesToolBox_Click(object sender, RoutedEventArgs e)
		{
			if (ToolBoxPanel.Children.Contains(PropertiesControl) == true)
			{
				Undock(PropertiesControl);
				PropertiesDocked.Visibility = System.Windows.Visibility.Collapsed;
				PropertiesUndocked.Visibility = System.Windows.Visibility.Visible;
				HideUndockedPane();
			}
			else if (ToolBoxUndockedPanel.Children.Contains(PropertiesControl) == true)
			{
				Dock(PropertiesControl);
				PropertiesDocked.Visibility = System.Windows.Visibility.Visible;
				PropertiesUndocked.Visibility = System.Windows.Visibility.Collapsed;
			}
			else
			{
				Undock(PropertiesControl);
				PropertiesDocked.Visibility = System.Windows.Visibility.Collapsed;
				PropertiesUndocked.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void btnEntitiesToolBox_Click(object sender, RoutedEventArgs e)
		{
			if (ToolBoxPanel.Children.Contains(EntitiesControl) == true)
			{
				Undock(EntitiesControl);
				EntitiesDocked.Visibility = System.Windows.Visibility.Collapsed;
				EntitiesUndocked.Visibility = System.Windows.Visibility.Visible;
				HideUndockedPane();
			}
			else if (ToolBoxUndockedPanel.Children.Contains(EntitiesControl) == true)
			{
				Dock(EntitiesControl);
				EntitiesDocked.Visibility = System.Windows.Visibility.Visible;
				EntitiesUndocked.Visibility = System.Windows.Visibility.Collapsed;
			}
			else
			{
				Undock(EntitiesControl);
				EntitiesDocked.Visibility = System.Windows.Visibility.Collapsed;
				EntitiesUndocked.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void btnZoomBox_MouseEnter(object sender, MouseEventArgs e)
		{
			HideUndockedPane();
			if (ToolBoxPanel.Children.Contains(ZoomControl) == false)
			{
				Undock(ZoomControl);
				ZoomBoxUndocked.Visibility = System.Windows.Visibility.Visible;
				ZoomBoxDocked.Visibility = System.Windows.Visibility.Collapsed;
			}
		}

		private void btnDiagramToolBox_MouseEnter(object sender, MouseEventArgs e)
		{
			HideUndockedPane();
			if (ToolBoxPanel.Children.Contains(ToolBoxDiagramControl) == false)
			{
				Undock(ToolBoxDiagramControl);
				DiagramUndocked.Visibility = System.Windows.Visibility.Visible;
				DiagramDocked.Visibility = System.Windows.Visibility.Collapsed;
			}
		}

		private void btnPropertiesToolBox_MouseEnter(object sender, MouseEventArgs e)
		{
			HideUndockedPane();
			if (ToolBoxPanel.Children.Contains(PropertiesControl) == false)
			{
				Undock(PropertiesControl);
				PropertiesDocked.Visibility = System.Windows.Visibility.Collapsed;
				PropertiesUndocked.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void btnEntitiesToolBox_MouseEnter(object sender, MouseEventArgs e)
		{
			HideUndockedPane();
			if (ToolBoxPanel.Children.Contains(EntitiesControl) == false)
			{
				Undock(EntitiesControl);
				EntitiesDocked.Visibility = System.Windows.Visibility.Collapsed;
				EntitiesUndocked.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void Dock(ToolBoxControl control)
		{
			ToolBoxUndockedPanel.Children.Remove(control);
			if (ToolBoxUndockedPanel.Children.Count == 0)
			{
				ToolBoxUndockedViewer.Visibility = System.Windows.Visibility.Collapsed;
			}
			if (ToolBoxPanel.Children.Contains(control) == false)
			{
				ToolBoxPanel.Children.Add(control);
				ToolBoxViewer.Visibility = System.Windows.Visibility.Visible;
				ToolBoxSplitter.Visibility = System.Windows.Visibility.Visible;
				ToolBoxColumn.Width = GridLength.Auto;
				control.IsDocked = true;
			}
		}

		private void Undock(ToolBoxControl control)
		{
			ToolBoxPanel.Children.Remove(control);
			if (ToolBoxPanel.Children.Count == 0)
			{
				ToolBoxViewer.Visibility = System.Windows.Visibility.Collapsed;
				ToolBoxSplitter.Visibility = System.Windows.Visibility.Collapsed;
				ToolBoxColumn.Width = GridLength.Auto;
			}
			if (ToolBoxUndockedPanel.Children.Contains(control) == false)
			{
				while (ToolBoxUndockedPanel.Children.Count > 0)
				{
					ToolBoxUndockedPanel.Children.Remove(ToolBoxUndockedPanel.Children[0]);
				}
				ToolBoxUndockedPanel.Children.Add(control);
				ToolBoxUndockedViewer.Visibility = System.Windows.Visibility.Visible;
				control.IsDocked = false;
			}
			NeedsFocus = true;
		}

		private void HideUndockedPane()
		{
			while (ToolBoxUndockedPanel.Children.Count > 0)
			{
				ToolBoxUndockedPanel.Children.Remove(ToolBoxUndockedPanel.Children[0]);
			}
			ToolBoxUndockedViewer.Visibility = System.Windows.Visibility.Collapsed;
			ZoomBoxUndocked.Visibility = System.Windows.Visibility.Collapsed;
			DiagramUndocked.Visibility = System.Windows.Visibility.Collapsed;
			EntitiesUndocked.Visibility = System.Windows.Visibility.Collapsed;
			PropertiesUndocked.Visibility = System.Windows.Visibility.Collapsed;
		}

		private void Grid_MouseLeave(object sender, MouseEventArgs e)
		{
			if (canUndock == true)
			{
				HideUndockedPane();
			}
			canUndock = true;
		}

		private bool canUndock = true;

		private void Grid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			canUndock = false;
		}

		private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
		{
			canUndock = true;
		}

		private void Grid_ElementOpened(object sender, RoutedEventArgs e)
		{
			canUndock = false;
		}

		private void ToolBoxUndockedViewer_MouseLeave(object sender, MouseEventArgs e)
		{
			e.Handled = true;
		}

		private void UpdateScrollAndScale(DesignerCanvas canvas)
		{
			if (DataContext is DiagramViewModel && canvas != null)
			{
				if (canvas != null)
				{
					DiagramViewModel view = DataContext as DiagramViewModel;
					ScaleTransform transform = null;
					if (canvas.LayoutTransform is ScaleTransform)
					{
						transform = canvas.LayoutTransform as ScaleTransform;
					}
					else
					{
						transform = new ScaleTransform();
						canvas.LayoutTransform = transform;
					}
					transform.ScaleX = view.Scale;
					transform.ScaleY = view.Scale;
					DesignerScrollViewer.ScrollToHorizontalOffset(view.HorizontalOffset);
					DesignerScrollViewer.ScrollToVerticalOffset(view.VerticalOffset);
				}
			}
		}

		private void EditControl_Loaded(object sender, RoutedEventArgs e)
		{
			DesignerCanvas canvas = VisualItemHelper.FindChild<DesignerCanvas>(DesignerScrollViewer);
			ZoomControl.DesignerCanvas = canvas;
			UpdateScrollAndScale(canvas);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the close command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CloseCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			DiagramViewModel view = DataContext as DiagramViewModel;
			if (view != null)
			{
				foreach (IWorkspaceViewModel item in view.Items)
				{
					if (item.IsSelected == true)
					{
						e.CanExecute = true;
						return;
					}
				}
				e.CanExecute = false;
			}
			else
			{
				e.CanExecute = false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the close item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			DiagramViewModel view = DataContext as DiagramViewModel;
			if (view != null)
			{
				IList<DiagramEntityViewModel> itemsToClose = new List<DiagramEntityViewModel>();
				foreach (IWorkspaceViewModel item in view.Items)
				{
					if (item.IsSelected == true && item is DiagramEntityViewModel)
					{
						itemsToClose.Add(item as DiagramEntityViewModel);
					}
				}
				foreach (DiagramEntityViewModel item in itemsToClose)
				{
					item.RemoveFromDiagram();
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the new command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the new command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			DiagramViewModel view = DataContext as DiagramViewModel;
			if (view != null)
			{
				Point currentPosition = MouseUtilities.GetMousePosition(this);
				dialog = new Window();
				dialog.Height = 350 * UserSettingsHelper.Instance.ControlSize;
				dialog.Width = 300 * UserSettingsHelper.Instance.ControlSize;
				dialog.Left = Math.Max(currentPosition.X, 20);
				dialog.Top = Math.Max(currentPosition.Y, 20);
				dialog.Content = new EntityDialogControl();
				Entity newEntity = new Entity();
				newEntity.EntityID = Guid.NewGuid();
				newEntity.Solution = view.Solution;
				EntityViewModel newEntityView = new EntityViewModel(newEntity, view.Solution);
				dialog.DataContext = newEntityView;
				dialog.Title = newEntityView.Title;
				newEntityView.RequestClose += new EventHandler(newEntityView_RequestClose);

				dialog.ShowDialog();
				if (newEntityView.IsOK == true)
				{
					// TODO: investigate why this workflow needs to be different than other elements in the model
					newEntityView.Entity.TransformDataFromObject(newEntityView.EditEntity, null, false);
					newEntityView.EditEntity = null;
					view.AddEntity(newEntityView, currentPosition, true);
				}
			}
		}

		private Window dialog;
		void newEntityView_RequestClose(object sender, EventArgs e)
		{
			dialog.Close();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the delete command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			DiagramViewModel view = DataContext as DiagramViewModel;
			if (view != null)
			{
				foreach (IWorkspaceViewModel item in view.Items)
				{
					if (item.IsSelected == true)
					{
						e.CanExecute = true;
						return;
					}
				}
				e.CanExecute = false;
			}
			else
			{
				e.CanExecute = false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the delete item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			DiagramViewModel view = DataContext as DiagramViewModel;
			if (view != null)
			{
				bool performDelete = false;
				int itemCountToDelete = 0;
				foreach (IWorkspaceViewModel item in view.Items)
				{
					if (item.IsSelected == true)
					{
						itemCountToDelete++;
					}
				}
				if (itemCountToDelete > 0)
				{
					if (itemCountToDelete > 1)
					{
						if (MessageBox.Show(DisplayValues.Message_DeleteSelectedItems, DisplayValues.Message_DeleteItemConfirmationCaption, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
						{
							performDelete = true;
						}
					}
					else
					{
						if (MessageBox.Show(DisplayValues.Message_DeleteSelectedItem, DisplayValues.Message_DeleteItemConfirmationCaption, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
						{
							performDelete = true;
						}
					}
					if (performDelete == true)
					{
						IList<IWorkspaceViewModel> itemsToDelete = new List<IWorkspaceViewModel>();
						foreach (IWorkspaceViewModel item in view.Items)
						{
							if (item.IsSelected == true)
							{
								itemsToDelete.Add(item);
							}
						}
						foreach (IWorkspaceViewModel item in itemsToDelete)
						{
							if (item is DiagramEntityViewModel)
							{
								(item as DiagramEntityViewModel).DeleteFromSolution();
							}
							else if (item is DiagramRelationshipViewModel)
							{
								(item as DiagramRelationshipViewModel).DeleteFromSolution();
							}
						}
					}
				}
			}
		}

		private void DesignerScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			if (DataContext is DiagramViewModel)
			{
				DiagramViewModel view = DataContext as DiagramViewModel;
				view.HorizontalOffset = e.HorizontalOffset;
				view.VerticalOffset = e.VerticalOffset;
			}
		}

		private void entityItems_Focus(object sender, MouseButtonEventArgs e)
		{
			if (NeedsFocus == true)
			{
				entityItems.Focus();
				NeedsFocus = false;
			}
		}

		private void entityItems_MouseEnter(object sender, MouseEventArgs e)
		{
			if (NeedsFocus == true)
			{
				entityItems.Focus();
				NeedsFocus = false;
			}
		}

		private void DesignerCanvas_GotFocus(object sender, RoutedEventArgs e)
		{
			NeedsFocus = false;
		}

		private void DesignerCanvas_LostFocus(object sender, RoutedEventArgs e)
		{
			NeedsFocus = true;
		}
	}
}
