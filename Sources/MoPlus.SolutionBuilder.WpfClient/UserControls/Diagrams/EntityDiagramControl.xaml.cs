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
using MoPlus.ViewModel.Entities;
using MoPlus.SolutionBuilder.WpfClient.Library;
using MoPlus.ViewModel.Diagrams;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Entities;
using MoPlus.Interpreter.BLL.Entities;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams
{
	/// <summary>
	/// Interaction logic for EntityDiagramControl.xaml
	/// </summary>
	public partial class EntityDiagramControl : EditControl
	{
		public EntityDiagramControl()
		{
			InitializeComponent();
			SizeChanged += new SizeChangedEventHandler(EntityDiagramControl_SizeChanged);
		}

		void EntityDiagramControl_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			// reset relative position of right and bottom connectors due to resize
			foreach (Connector connector in (from c in RightPanel.Children.OfType<Connector>()
											 select c).ToList<Connector>())
			{
				connector.ResetRelativePosition = true;
			}
			foreach (Connector connector in (from c in BottomPanel.Children.OfType<Connector>()
											 select c).ToList<Connector>())
			{
				connector.ResetRelativePosition = true;
			}
		}

		protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
		{
			base.OnGiveFeedback(e);
			if (CurrentAdorner != null)
			{
				CurrentAdorner.DrawArc(MouseUtilities.GetMousePosition(ParentCanvas));
			}
		}
		ConnectorAdorner CurrentAdorner { get; set; }

		protected override void OnDragLeave(DragEventArgs e)
		{
			base.OnDragLeave(e);
			EntityViewModel dragEntity = e.Data.GetData(typeof(EntityViewModel)) as EntityViewModel;
			if (dragEntity == null)
			{
				HandleAdorner();
				e.Handled = true;
			}
		}
		private DiagramControl ParentDiagramControl
		{
			get
			{
				return VisualItemHelper.VisualUpwardSearch<DiagramControl>(this) as DiagramControl;
			}
		}

		protected override void OnMouseLeave(MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			HandleAdorner();
		}

		public void HandleAdorner()
		{
			//if (ParentDiagramControl != null && ParentDiagramControl.DragItem != null)
			//{
			//    CreateConnectorAdorner();
			//}
		}

		public void CreateConnectorAdorner()
		{
			if (ParentCanvas != null)
			{
				AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(ParentCanvas);
				if (adornerLayer != null)
				{
					CurrentAdorner = new ConnectorAdorner(ParentCanvas, BestExitConnector);
					if (CurrentAdorner != null)
					{
						adornerLayer.Add(CurrentAdorner);
					}
				}
			}
		}

		private Connector BestExitConnector
		{
			get
			{
				DiagramEntityViewModel view = DataContext as DiagramEntityViewModel;
				if (view != null)
				{
					Point mousePosition = MouseUtilities.GetMousePosition(ParentCanvas);
					if (mousePosition.X < view.X)
					{
						// mouse is to the left
						return GetConnector(LeftPanel, view.X, view.Y);
					}
					else if (mousePosition.Y < view.Y)
					{
						// mouse is above
						return GetConnector(TopPanel, view.X, view.Y);
					}
					else if (mousePosition.X > view.X + ActualWidth)
					{
						// mouse is to the right
						return GetConnector(RightPanel, view.X, view.Y);
					}
					else if (mousePosition.Y > view.Y + ActualHeight)
					{
						// mouse is below
						return GetConnector(BottomPanel, view.X, view.Y);
					}
				}
				return GetConnector(RightPanel, view.X, view.Y);
			}
		}

		private DesignerCanvas ParentCanvas
		{
			get
			{
				return VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(this) as DesignerCanvas;
			}
		}

		public Connector GetBestConnector(EntityDiagramControl otherControl, bool isSinkConnector)
		{
			DiagramEntityViewModel view = DataContext as DiagramEntityViewModel;
			DiagramEntityViewModel otherView = otherControl.DataContext as DiagramEntityViewModel;
			if (view != null && otherView != null)
			{
				double deltaX = otherView.X - view.X;
				double deltaY = otherView.Y - view.Y;
				bool deltaYBigger = Math.Abs(deltaY) > Math.Abs(deltaX);
				if (isSinkConnector == true)
				{
					// weight the sink connector towards the left/right side
					deltaYBigger = Math.Abs(deltaY) > 2*Math.Abs(deltaX);
				}
				if (deltaYBigger == true)
				{
					// item is to the top or bottom
					if (deltaY > 0)
					{
						// item is to the bottom
						return GetConnector(BottomPanel, otherView.X, otherView.Y);
					}
					else
					{
						// item is to the top
						return GetConnector(TopPanel, otherView.X, otherView.Y);
					}
				}
				else
				{
					// item is to the left or right
					if (deltaX > 0)
					{
						// item is to the right
						return GetConnector(RightPanel, otherView.X, otherView.Y);
					}
					else
					{
						// item is to the left
						return GetConnector(LeftPanel, otherView.X, otherView.Y);
					}
				}
			}
			return GetConnector(LeftPanel, otherView.X, otherView.Y);
		}

		private Connector GetConnector(StackPanel panel, double x, double y)
		{
			// get an available connector with the fewest number of connections
			int numConnections = 0;
			while (numConnections < 100)
			{
				IList<Connector> connectors = (from c in panel.Children.OfType<Connector>()
											   where c.Connections.Count <= numConnections
											   select c).ToList<Connector>();
				if (connectors != null && connectors.Count > 0)
				{
					Connector nearestConnector = null;
					double nearestConnectorDistance = 0;
					int xAdjust = 0;
					int yAdjust = 0;
					foreach (Connector connector in connectors)
					{
						if (panel == LeftPanel || panel == RightPanel)
						{
							yAdjust--;
						}
						else
						{
							xAdjust--;
						}
						double connectorDistance = Math.Abs(connector.Position.X + xAdjust - x) + Math.Abs(connector.Position.Y + yAdjust - y);
						if (nearestConnector == null || connectorDistance < nearestConnectorDistance)
						{
							nearestConnector = connector;
							nearestConnectorDistance = connectorDistance;
						}
					}
					return nearestConnector;
				}
				numConnections++;
			}
			return null;
		}

		public void UpdateConnections()
		{
			List<Connection> connections = null;
			foreach (Connector connector in LeftPanel.Children.OfType<Connector>())
			{
				connections = connector.Connections.ToList<Connection>();
				foreach (Connection connection in connections)
				{
					connection.UpdateSourceAndSink();
				}
			}
			foreach (Connector connector in RightPanel.Children.OfType<Connector>())
			{
				connections = connector.Connections.ToList<Connection>();
				foreach (Connection connection in connections)
				{
					connection.UpdateSourceAndSink();
				}
			}
			foreach (Connector connector in TopPanel.Children.OfType<Connector>())
			{
				connections = connector.Connections.ToList<Connection>();
				foreach (Connection connection in connections)
				{
					connection.UpdateSourceAndSink();
				}
			}
			foreach (Connector connector in BottomPanel.Children.OfType<Connector>())
			{
				connections = connector.Connections.ToList<Connection>();
				foreach (Connection connection in connections)
				{
					connection.UpdateSourceAndSink();
				}
			}
		}

		protected override void OnDrop(DragEventArgs e)
		{
			base.OnDrop(e);

			Point currentPosition = MouseUtilities.GetMousePosition(this);
			DiagramViewModel diagramView = ParentCanvas.DataContext as DiagramViewModel;
			DiagramEntityViewModel diagramEntityView = DataContext as DiagramEntityViewModel;
			if (diagramView != null && diagramEntityView != null)
			{
				// try drop as diagram relationship
				DiagramRelationshipViewModel dragRelationship = e.Data.GetData(typeof(DiagramRelationshipViewModel)) as DiagramRelationshipViewModel;
				if (dragRelationship != null)
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
					e.Handled = true;
					return;
				}

				// try drop as collection
				CollectionsViewModel dragCollections = e.Data.GetData(typeof(CollectionsViewModel)) as CollectionsViewModel;
				if (dragCollections != null)
				{
					dialog = new Window();
					dialog.Height = 450 * UserSettingsHelper.Instance.ControlSize;
					dialog.Width = 400 * UserSettingsHelper.Instance.ControlSize;
					dialog.Left = Math.Max(currentPosition.X, 20);
					dialog.Top = Math.Max(currentPosition.Y, 20);
					dialog.Content = new CollectionDialogControl();
					Collection newProperty = new Collection();
					newProperty.PropertyID = Guid.NewGuid();
					newProperty.Solution = dragCollections.Solution;
					newProperty.Entity = dragCollections.Entity;
					newProperty.ReferencedEntity = diagramEntityView.DiagramEntity.Entity;
					CollectionViewModel newPropertyView = new CollectionViewModel(newProperty, dragCollections.Solution);
					dialog.DataContext = newPropertyView;
					dialog.Title = newPropertyView.Title;
					newPropertyView.RequestClose += new EventHandler(Item_RequestClose);

					dialog.ShowDialog();
					if (newPropertyView.IsOK == true)
					{
						dragCollections.AddCollection(newPropertyView);
					}
					dialog.Close();
					dialog = null;
					e.Handled = true;
					return;
				}

				// try drop as property reference
				PropertyReferencesViewModel dragPropertyReferences = e.Data.GetData(typeof(PropertyReferencesViewModel)) as PropertyReferencesViewModel;
				if (dragPropertyReferences != null)
				{
					dialog = new Window();
					dialog.Height = 450 * UserSettingsHelper.Instance.ControlSize;
					dialog.Width = 400 * UserSettingsHelper.Instance.ControlSize;
					dialog.Left = Math.Max(currentPosition.X, 20);
					dialog.Top = Math.Max(currentPosition.Y, 20);
					dialog.Content = new PropertyReferenceDialogControl();
					PropertyReference newProperty = new PropertyReference();
					newProperty.PropertyID = Guid.NewGuid();
					newProperty.Solution = dragPropertyReferences.Solution;
					newProperty.Entity = dragPropertyReferences.Entity;
					PropertyReferenceViewModel newPropertyView = new PropertyReferenceViewModel(newProperty, dragPropertyReferences.Solution);
					newPropertyView.ReferencedEntityID = diagramEntityView.EntityViewModel.EntityID;
					newPropertyView.RefreshProperties();
					dialog.DataContext = newPropertyView;
					dialog.Title = newPropertyView.Title;
					newPropertyView.RequestClose += new EventHandler(Item_RequestClose);

					dialog.ShowDialog();
					if (newPropertyView.IsOK == true)
					{
						dragPropertyReferences.AddPropertyReference(newPropertyView);
					}
					dialog.Close();
					dialog = null;
					e.Handled = true;
					return;
				}

				// try drop as entity reference
				EntityReferencesViewModel dragEntityReferences = e.Data.GetData(typeof(EntityReferencesViewModel)) as EntityReferencesViewModel;
				if (dragEntityReferences != null)
				{
					dialog = new Window();
					dialog.Height = 450 * UserSettingsHelper.Instance.ControlSize;
					dialog.Width = 400 * UserSettingsHelper.Instance.ControlSize;
					dialog.Left = Math.Max(currentPosition.X, 20);
					dialog.Top = Math.Max(currentPosition.Y, 20);
					dialog.Content = new EntityReferenceDialogControl();
					EntityReference newProperty = new EntityReference();
					newProperty.PropertyID = Guid.NewGuid();
					newProperty.Solution = dragEntityReferences.Solution;
					newProperty.Entity = dragEntityReferences.Entity;
					newProperty.ReferencedEntity = diagramEntityView.DiagramEntity.Entity;
					EntityReferenceViewModel newPropertyView = new EntityReferenceViewModel(newProperty, dragEntityReferences.Solution);
					dialog.DataContext = newPropertyView;
					dialog.Title = newPropertyView.Title;
					newPropertyView.RequestClose += new EventHandler(Item_RequestClose);

					dialog.ShowDialog();
					if (newPropertyView.IsOK == true)
					{
						dragEntityReferences.AddEntityReference(newPropertyView);
					}
					dialog.Close();
					dialog = null;
					e.Handled = true;
					return;
				}
			}
		}

		private Window dialog;
		void Item_RequestClose(object sender, EventArgs e)
		{
			dialog.Close();
		}

		private void EditControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (DataContext is IWorkspaceViewModel)
			{
				(DataContext as IWorkspaceViewModel).SetSelected();
			}
		}
	}
}
