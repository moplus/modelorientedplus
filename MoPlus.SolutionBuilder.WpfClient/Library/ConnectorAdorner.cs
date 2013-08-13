/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
*</copyright>*/
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel;
using MoPlus.Interpreter.BLL.Entities;
using System;
using MoPlus.ViewModel.Entities;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    public class ConnectorAdorner : Adorner
    {
        private PathGeometry pathGeometry;
        private DesignerCanvas designerCanvas;
        private Connector sourceConnector;
        private Pen drawingPen;

        private DesignerItem hitDesignerItem;
        private DesignerItem HitDesignerItem
        {
            get { return hitDesignerItem; }
            set
            {
                if (hitDesignerItem != value)
                {
                    if (hitDesignerItem != null)
                        hitDesignerItem.IsDragConnectionOver = false;

                    hitDesignerItem = value;

                    if (hitDesignerItem != null)
                        hitDesignerItem.IsDragConnectionOver = true;
                }
            }
        }

        private Connector hitConnector;
        private Connector HitConnector
        {
            get { return hitConnector; }
            set
            {
                if (hitConnector != value)
                {
                    hitConnector = value;
                }
            }
        }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramViewModel.</summary>
		///--------------------------------------------------------------------------------
		private DiagramViewModel DiagramViewModel
		{
			get
			{
				if (designerCanvas != null && designerCanvas.DataContext is DiagramViewModel)
				{
					return DataContext as DiagramViewModel;
				}
				return null;
			}
		}

		public ConnectorAdorner(DesignerCanvas designer, Connector sourceConnector)
            : base(designer)
        {
            this.designerCanvas = designer;
            this.sourceConnector = sourceConnector;
            drawingPen = new Pen(Brushes.LightSlateGray, 1);
            drawingPen.LineJoin = PenLineJoin.Round;
			//this.Cursor = Cursors.Cross;
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (HitConnector != null)
            {
 				DiagramEntityViewModel sourceView = sourceConnector.DataContext as DiagramEntityViewModel;
				DiagramEntityViewModel sinkView = HitConnector.DataContext as DiagramEntityViewModel;

				if (DiagramViewModel != null && sourceView != null && sinkView != null)
				{
					Relationship relationship = new Relationship();
					relationship.RelationshipID = Guid.NewGuid();
					relationship.EntityID = sourceView.EntityID;
					relationship.ReferencedEntityID = sinkView.EntityID;
					// TODO: bring up dialog to set up new entity relationship properties

					RelationshipViewModel relationshipViewModel = new RelationshipViewModel(relationship, sourceView.Solution);
					DiagramRelationshipViewModel dropDiagramRelationship = new DiagramRelationshipViewModel(sourceView, sinkView, sourceView.Diagram, relationshipViewModel);
					dropDiagramRelationship.ZIndex = 0;
					DiagramViewModel.DiagramRelationships.Add(dropDiagramRelationship);
					DiagramViewModel.ClearSelectedItems();
					dropDiagramRelationship.IsSelected = true;
					DiagramViewModel.Refresh(true);
				}
            }
            if (HitDesignerItem != null)
            {
                this.HitDesignerItem.IsDragConnectionOver = false;
            }

            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.designerCanvas);
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!IsMouseCaptured) CaptureMouse();
				DrawArc(e.GetPosition(this));
			}
            else
            {
                if (IsMouseCaptured) ReleaseMouseCapture();
            }
        }

		public void DrawArc(Point position)
		{
			HitTesting(position);
			pathGeometry = GetPathGeometry(position);
			currentPoint = position;
			InvalidateVisual();
		}

		Point currentPoint = new Point(300, 300);

		protected override void OnRender(DrawingContext dc)
        {
			base.OnRender(dc);
			dc.DrawGeometry(null, drawingPen, this.pathGeometry);

			// without a background the OnMouseMove event would not be fired
			// Alternative: implement a Canvas as a child of this adorner, like
			// the ConnectionAdorner does.
			dc.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));
		}

        private PathGeometry GetPathGeometry(Point position)
        {
            PathGeometry geometry = new PathGeometry();

            ConnectorOrientation targetOrientation;
            if (HitConnector != null)
                targetOrientation = HitConnector.Orientation;
            else
                targetOrientation = ConnectorOrientation.None;

            List<Point> pathPoints = PathFinder.GetConnectionLine(sourceConnector.GetInfo(), position, targetOrientation);

            if (pathPoints.Count > 0)
            {
                PathFigure figure = new PathFigure();
                figure.StartPoint = pathPoints[0];
                pathPoints.Remove(pathPoints[0]);
                figure.Segments.Add(new PolyLineSegment(pathPoints, true));
                geometry.Figures.Add(figure);
            }

            return geometry;
        }

        private void HitTesting(Point hitPoint)
        {
            bool hitConnectorFlag = false;

            DependencyObject hitObject = designerCanvas.InputHitTest(hitPoint) as DependencyObject;
            while (hitObject != null &&
                   hitObject != sourceConnector.ParentDesignerItem &&
                   hitObject.GetType() != typeof(DesignerCanvas))
            {
                if (hitObject is Connector)
                {
                    HitConnector = hitObject as Connector;
                    hitConnectorFlag = true;
                }

                if (hitObject is DesignerItem)
                {
                    HitDesignerItem = hitObject as DesignerItem;
                    if (!hitConnectorFlag)
                        HitConnector = null;
                    return;
                }
                hitObject = VisualTreeHelper.GetParent(hitObject);
            }

            HitConnector = null;
            HitDesignerItem = null;
        }
    }
}
