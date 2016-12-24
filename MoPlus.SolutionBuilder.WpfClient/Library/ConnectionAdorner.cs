/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
 *</copyright>*/
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    public class ConnectionAdorner : Adorner
    {
        private DesignerCanvas designerCanvas;
        private Canvas adornerCanvas;
        private Connection connection;
        private PathGeometry pathGeometry;
        private Connector fixConnector, dragConnector;
        private Thumb sourceDragThumb, sinkDragThumb;
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

        private VisualCollection visualChildren;
        protected override int VisualChildrenCount
        {
            get
            {
                return this.visualChildren.Count;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.visualChildren[index];
        }

        public ConnectionAdorner(DesignerCanvas designer, Connection connection)
            : base(designer)
        {
            this.designerCanvas = designer;
            adornerCanvas = new Canvas();
            this.visualChildren = new VisualCollection(this);
            this.visualChildren.Add(adornerCanvas);

            this.connection = connection;
            this.connection.PropertyChanged += new PropertyChangedEventHandler(AnchorPositionChanged);

            InitializeDragThumbs();

            drawingPen = new Pen(Brushes.LightSlateGray, 1);
            drawingPen.LineJoin = PenLineJoin.Round;
        }

        private void InitializeDragThumbs()
        {
            Style dragThumbStyle = connection.FindResource("ConnectionAdornerThumbStyle") as Style;

            //source drag thumb
            sourceDragThumb = new Thumb();
            Canvas.SetLeft(sourceDragThumb, connection.AnchorPositionSource.X);
            Canvas.SetTop(sourceDragThumb, connection.AnchorPositionSource.Y);
            this.adornerCanvas.Children.Add(sourceDragThumb);
            if (dragThumbStyle != null)
                sourceDragThumb.Style = dragThumbStyle;

            sourceDragThumb.DragDelta += new DragDeltaEventHandler(thumbDragThumb_DragDelta);
            sourceDragThumb.DragStarted += new DragStartedEventHandler(thumbDragThumb_DragStarted);
            sourceDragThumb.DragCompleted += new DragCompletedEventHandler(thumbDragThumb_DragCompleted);

            // sink drag thumb
            sinkDragThumb = new Thumb();
            Canvas.SetLeft(sinkDragThumb, connection.AnchorPositionSink.X);
            Canvas.SetTop(sinkDragThumb, connection.AnchorPositionSink.Y);
            this.adornerCanvas.Children.Add(sinkDragThumb);
            if (dragThumbStyle != null)
                sinkDragThumb.Style = dragThumbStyle;

            sinkDragThumb.DragDelta += new DragDeltaEventHandler(thumbDragThumb_DragDelta);
            sinkDragThumb.DragStarted += new DragStartedEventHandler(thumbDragThumb_DragStarted);
            sinkDragThumb.DragCompleted += new DragCompletedEventHandler(thumbDragThumb_DragCompleted);
        }
        void AnchorPositionChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("AnchorPositionSource"))
            {
                Canvas.SetLeft(sourceDragThumb, connection.AnchorPositionSource.X);
                Canvas.SetTop(sourceDragThumb, connection.AnchorPositionSource.Y);
            }

            if (e.PropertyName.Equals("AnchorPositionSink"))
            {
                Canvas.SetLeft(sinkDragThumb, connection.AnchorPositionSink.X);
                Canvas.SetTop(sinkDragThumb, connection.AnchorPositionSink.Y);
            }
        }

        void thumbDragThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (HitConnector != null)
            {
                if (connection != null)
                {
                    if (connection.Source == fixConnector)
                        connection.Sink = this.HitConnector;
                    else
                        connection.Source = this.HitConnector;
                }
            }

            this.HitDesignerItem = null;
            this.HitConnector = null;
            this.pathGeometry = null;
            this.connection.StrokeDashArray = null;
            this.InvalidateVisual();
        }

        void thumbDragThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.HitDesignerItem = null;
            this.HitConnector = null;
            this.pathGeometry = null;
			this.Cursor = Cursors.Cross;
            this.connection.StrokeDashArray = new DoubleCollection(new double[] { 1, 2 });

            if (sender == sourceDragThumb)
            {
                fixConnector = connection.Sink;
                dragConnector = connection.Source;
            }
            else if (sender == sinkDragThumb)
            {
                dragConnector = connection.Sink;
                fixConnector = connection.Source;
            }
        }

        void thumbDragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Point currentPosition = Mouse.GetPosition(this);
            this.HitTesting(currentPosition);
            this.pathGeometry = UpdatePathGeometry(currentPosition);
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            dc.DrawGeometry(null, drawingPen, this.pathGeometry);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            adornerCanvas.Arrange(new Rect(0, 0, this.designerCanvas.ActualWidth, this.designerCanvas.ActualHeight));
            return finalSize;
        }

        private PathGeometry UpdatePathGeometry(Point position)
        {
            PathGeometry geometry = new PathGeometry();

            ConnectorOrientation targetOrientation;
            if (HitConnector != null)
                targetOrientation = HitConnector.Orientation;
            else
                targetOrientation = dragConnector.Orientation;

            List<Point> linePoints = PathFinder.GetConnectionLine(fixConnector.GetInfo(), position, targetOrientation);

            if (linePoints.Count > 0)
            {
                PathFigure figure = new PathFigure();
                figure.StartPoint = linePoints[0];
                linePoints.Remove(linePoints[0]);
                figure.Segments.Add(new PolyLineSegment(linePoints, true));
                geometry.Figures.Add(figure);
            }

            return geometry;
        }

        private void HitTesting(Point hitPoint)
        {
            bool hitConnectorFlag = false;

            DependencyObject hitObject = designerCanvas.InputHitTest(hitPoint) as DependencyObject;
            while (hitObject != null &&
                   hitObject != fixConnector.ParentDesignerItem &&
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
