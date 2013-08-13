/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
*</copyright>*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Diagrams;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams;
using System.Windows.Data;
using MoPlus.Interpreter.BLL.Entities;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	public class Connection : ContentControl, ISelectable, INotifyPropertyChanged
    {
        private Adorner connectionAdorner;

        #region Properties

        // source connector
        private Connector source;
        public Connector Source
        {
            get
            {
                return source;
            }
            set
            {
                if (source != value)
                {
                    if (source != null)
                    {
                        source.PropertyChanged -= new PropertyChangedEventHandler(OnConnectorPositionChanged);
                        source.Connections.Remove(this);
                    }

                    source = value;

                    if (source != null)
                    {
                        source.Connections.Add(this);
                        source.PropertyChanged += new PropertyChangedEventHandler(OnConnectorPositionChanged);
                    }

                    UpdatePathGeometry();
                }
            }
        }

        // sink connector
        private Connector sink;
        public Connector Sink
        {
            get { return sink; }
            set
            {
                if (sink != value)
                {
                    if (sink != null)
                    {
                        sink.PropertyChanged -= new PropertyChangedEventHandler(OnConnectorPositionChanged);
                        sink.Connections.Remove(this);
                    }

                    sink = value;

                    if (sink != null)
                    {
                        sink.Connections.Add(this);
                        sink.PropertyChanged += new PropertyChangedEventHandler(OnConnectorPositionChanged);
                    }
                    UpdatePathGeometry();
                }
            }
        }

        // connection path geometry
        private PathGeometry pathGeometry;
        public PathGeometry PathGeometry
        {
            get { return pathGeometry; }
            set
            {
                if (pathGeometry != value)
                {
                    pathGeometry = value;
                    UpdateAnchorPosition();
                    OnPropertyChanged("PathGeometry");
                }
            }
        }

        // between source connector position and the beginning 
        // of the path geometry we leave some space for visual reasons; 
        // so the anchor position source really marks the beginning 
        // of the path geometry on the source side
        private Point anchorPositionSource;
        public Point AnchorPositionSource
        {
            get { return anchorPositionSource; }
            set
            {
                if (anchorPositionSource != value)
                {
                    anchorPositionSource = value;
                    OnPropertyChanged("AnchorPositionSource");
                }
            }
        }

        // slope of the path at the anchor position
        // needed for the rotation angle of the arrow
        private double anchorAngleSource = 0;
        public double AnchorAngleSource
        {
            get { return anchorAngleSource; }
            set
            {
                if (anchorAngleSource != value)
                {
                    anchorAngleSource = value;
                    OnPropertyChanged("AnchorAngleSource");
                }
            }
        }

        // analogue to source side
        private Point anchorPositionSink;
        public Point AnchorPositionSink
        {
            get { return anchorPositionSink; }
            set
            {
                if (anchorPositionSink != value)
                {
                    anchorPositionSink = value;
                    OnPropertyChanged("AnchorPositionSink");
                }
            }
        }
        // analogue to source side
        private double anchorAngleSink = 0;
        public double AnchorAngleSink
        {
            get { return anchorAngleSink; }
            set
            {
                if (anchorAngleSink != value)
                {
                    anchorAngleSink = value;
                    OnPropertyChanged("AnchorAngleSink");
                }
            }
        }

        private ArrowSymbol sourceArrowSymbol = ArrowSymbol.DoubleArrow;
        public ArrowSymbol SourceArrowSymbol
        {
            get { return sourceArrowSymbol; }
            set
            {
                if (sourceArrowSymbol != value)
                {
                    sourceArrowSymbol = value;
                    OnPropertyChanged("SourceArrowSymbol");
                }
            }
        }

        public ArrowSymbol sinkArrowSymbol = ArrowSymbol.Arrow;
        public ArrowSymbol SinkArrowSymbol
        {
            get { return sinkArrowSymbol; }
            set
            {
                if (sinkArrowSymbol != value)
                {
                    sinkArrowSymbol = value;
                    OnPropertyChanged("SinkArrowSymbol");
                }
            }
        }

		// specifies a point near the source
		private string _sourceLabel;
		public string SourceLabel
		{
			get { return _sourceLabel; }
			set
			{
				if (_sourceLabel != value)
				{
					_sourceLabel = value;
					OnPropertyChanged("SourceLabel");
				}
			}
		}

		// specifies a point near the source
        private Point _sourceLabelPosition;
        public Point SourceLabelPosition
        {
			get { return _sourceLabelPosition; }
            set
            {
				if (_sourceLabelPosition != value)
                {
					_sourceLabelPosition = value;
					OnPropertyChanged("SourceLabelPosition");
                }
            }
        }

		// specifies a label near the sink
		private string _sinkLabel;
		public string SinkLabel
		{
			get { return _sinkLabel; }
			set
			{
				if (_sinkLabel != value)
				{
					_sinkLabel = value;
					OnPropertyChanged("SinkLabel");
				}
			}
		}

		// specifies a point near the sink
		private Point _sinkLabelPosition;
		public Point SinkLabelPosition
		{
			get { return _sinkLabelPosition; }
			set
			{
				if (_sinkLabelPosition != value)
				{
					_sinkLabelPosition = value;
					OnPropertyChanged("SinkLabelPosition");
				}
			}
		}

		// pattern of dashes and gaps that is used to outline the connection path
        private DoubleCollection strokeDashArray;
        public DoubleCollection StrokeDashArray
        {
            get
            {
                return strokeDashArray;
            }
            set
            {
                if (strokeDashArray != value)
                {
                    strokeDashArray = value;
                    OnPropertyChanged("StrokeDashArray");
                }
            }
        }

		public bool IsSelected
		{
			get
			{
				return (bool)GetValue(IsSelectedProperty);
			}
			set
			{
				if (IsSelected != value)
				{
					// TODO: dual binding of IsSelected doesn't call this property for some reason
					SetValue(IsSelectedProperty, value);
					OnPropertyChanged("IsSelected");

					// below is disabled, not allowing user to move arcs for now
					//if (IsSelected)
					//    ShowAdorner();
					//else
					//    HideAdorner();
				}
			}
		}
		public static readonly DependencyProperty IsSelectedProperty =
		  DependencyProperty.Register("IsSelected",
									   typeof(bool),
									   typeof(Connection),
									   new FrameworkPropertyMetadata(false));

        #endregion

		public Connection()
		{
			base.Unloaded += new RoutedEventHandler(Connection_Unloaded);
			this.DataContextChanged += new DependencyPropertyChangedEventHandler(Connection_DataContextChanged);
			this.Loaded += new RoutedEventHandler(Connection_Loaded);
		}

		void Connection_Loaded(object sender, RoutedEventArgs e)
		{
			UpdateSourceAndSink();
		}

		public void UpdateSourceAndSink()
		{
			DiagramRelationshipViewModel view = DataContext as DiagramRelationshipViewModel;
			if (view != null)
			{
				DesignerCanvas designer = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(this) as DesignerCanvas;
				EntityDiagramControl sourceControl = VisualItemHelper.FindChild<EntityDiagramControl>(designer, view.SourceDiagramEntityViewModel) as EntityDiagramControl;
				EntityDiagramControl sinkControl = VisualItemHelper.FindChild<EntityDiagramControl>(designer, view.SinkDiagramEntityViewModel) as EntityDiagramControl;
				if (sourceControl != null && sinkControl != null)
				{
					Source = sourceControl.GetBestConnector(sinkControl, false);
					Sink = sinkControl.GetBestConnector(sourceControl, true);
				}
			}
		}

		void Connection_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DiagramRelationshipViewModel view = DataContext as DiagramRelationshipViewModel;
			SourceArrowSymbol = ArrowSymbol.Arrow;
			SinkArrowSymbol = ArrowSymbol.Arrow;
			string sourceMin = String.Empty, sourceMax = String.Empty, sinkMin = String.Empty, sinkMax = String.Empty;
			if (view != null)
			{
				// set labels
				if (view.RelationshipViewModel.EditRelationship.EntityID != view.RelationshipViewModel.EditRelationship.ReferencedEntityID)
				{
					sourceMin = view.RelationshipViewModel.EditRelationship.ItemsMin == -1 ? "*" : view.RelationshipViewModel.EditRelationship.ItemsMin.ToString();
					sourceMax = view.RelationshipViewModel.EditRelationship.ItemsMax == -1 ? "*" : view.RelationshipViewModel.EditRelationship.ItemsMax.ToString();
					sinkMin = view.RelationshipViewModel.EditRelationship.ReferencedItemsMin == -1 ? "*" : view.RelationshipViewModel.EditRelationship.ReferencedItemsMin.ToString();
					sinkMax = view.RelationshipViewModel.EditRelationship.ReferencedItemsMax == -1 ? "*" : view.RelationshipViewModel.EditRelationship.ReferencedItemsMax.ToString();
					SourceLabel = sourceMin == sourceMax ? sourceMin : sourceMin + ".." + sourceMax;
					SinkLabel = sinkMin == sinkMax ? sinkMin : sinkMin + ".." + sinkMax;
				}

				// set many relationship
				if (view.RelationshipViewModel.EditRelationship.ItemsMax == -1 || view.RelationshipViewModel.EditRelationship.ItemsMax > 0)
				{
					SourceArrowSymbol = ArrowSymbol.DoubleArrow;
				}

				// if primary key relationship, make diamond headed arrows
				bool isPrimaryKeyRelationship = true;
				if (view.RelationshipViewModel.Relationship.PropertyCount == 0 || view.RelationshipViewModel.Relationship.PropertyCount != view.RelationshipViewModel.Relationship.Entity.PrimaryKeyCount)
				{
					isPrimaryKeyRelationship = false;
				}
				else
				{
					foreach (RelationshipProperty property in view.RelationshipViewModel.Relationship.RelationshipPropertyList)
					{
						if (property.Property.IsPrimaryKeyMember == false || property.ReferencedProperty.IsPrimaryKeyMember == false)
						{
							isPrimaryKeyRelationship = false;
							break;
						}
					}
				}
				if (isPrimaryKeyRelationship == true)
				{
					SourceArrowSymbol = ArrowSymbol.None;
					SinkArrowSymbol = ArrowSymbol.Diamond;
					SourceLabel = String.Empty;
					SinkLabel = String.Empty;
				}
				UpdateSourceAndSink();
			}
		}

		public Connection(Connector source, Connector sink)
		{
			DataContext = new DiagramRelationshipViewModel();
			this.Source = source;
			this.Sink = sink;
			base.Unloaded += new RoutedEventHandler(Connection_Unloaded);
		}

		protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            // usual selection business
			DesignerCanvas designer = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(this) as DesignerCanvas;
			IDiagramWorkspaceViewModel designerView = null;
			if (designer != null)
			{
				designerView = designer.DataContext as IDiagramWorkspaceViewModel;
			}

			// update selection
			if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) != ModifierKeys.None)
				if (IsSelected)
				{
					IsSelected = false;
				}
				else
				{
					IsSelected = true;
				}
			else
			{
				if (designerView != null)
					designerView.ClearSelectedItems();
				IsSelected = true;
			}
			e.Handled = false;
        }

        void OnConnectorPositionChanged(object sender, PropertyChangedEventArgs e)
        {
            // whenever the 'Position' property of the source or sink Connector 
            // changes we must update the connection path geometry
            if (e.PropertyName.Equals("Position"))
            {
                UpdatePathGeometry();
            }
        }

        private void UpdatePathGeometry()
        {
            if (Source != null && Sink != null)
            {
                PathGeometry geometry = new PathGeometry();
                List<Point> linePoints = PathFinder.GetConnectionLine(Source.GetInfo(), Sink.GetInfo(), true);
                if (linePoints.Count > 0)
                {
                    PathFigure figure = new PathFigure();
                    figure.StartPoint = linePoints[0];
                    linePoints.Remove(linePoints[0]);
                    figure.Segments.Add(new PolyLineSegment(linePoints, true));
                    geometry.Figures.Add(figure);

                    this.PathGeometry = geometry;
                }
            }
        }

        private void UpdateAnchorPosition()
        {
            Point pathStartPoint, pathTangentAtStartPoint;
            Point pathEndPoint, pathTangentAtEndPoint;
            Point pathMidPoint, pathTangentAtMidPoint;

            // the PathGeometry.GetPointAtFractionLength method gets the point and a tangent vector 
            // on PathGeometry at the specified fraction of its length
            this.PathGeometry.GetPointAtFractionLength(0, out pathStartPoint, out pathTangentAtStartPoint);
            this.PathGeometry.GetPointAtFractionLength(1, out pathEndPoint, out pathTangentAtEndPoint);
            this.PathGeometry.GetPointAtFractionLength(0.5, out pathMidPoint, out pathTangentAtMidPoint);

            // get angle from tangent vector
            this.AnchorAngleSource = Math.Atan2(-pathTangentAtStartPoint.Y, -pathTangentAtStartPoint.X) * (180 / Math.PI);
            this.AnchorAngleSink = Math.Atan2(pathTangentAtEndPoint.Y, pathTangentAtEndPoint.X) * (180 / Math.PI);

            // add some margin on source and sink side for visual reasons only
			pathStartPoint.Offset(-pathTangentAtStartPoint.X * -3, -pathTangentAtStartPoint.Y * -3);
			pathEndPoint.Offset(pathTangentAtEndPoint.X * 5, pathTangentAtEndPoint.Y * 5);

            this.AnchorPositionSource = pathStartPoint;
            this.AnchorPositionSink = pathEndPoint;
			if (pathEndPoint.X > pathStartPoint.X)
			{
				if ((pathStartPoint.Y - pathEndPoint.Y) > (pathEndPoint.X - pathStartPoint.X))
				{
					this.SourceLabelPosition = new Point(pathStartPoint.X, pathStartPoint.Y - 20);
				}
				else
				{
					this.SourceLabelPosition = pathStartPoint;
				}
			}
			else
			{
				if ((pathStartPoint.Y - pathEndPoint.Y) > (pathEndPoint.X - pathStartPoint.X))
				{
					this.SourceLabelPosition = new Point(pathStartPoint.X - 30, pathStartPoint.Y - 25);
				}
				else
				{
					this.SourceLabelPosition = new Point(pathStartPoint.X - 30, pathStartPoint.Y - 5);
				}
			}
			if (pathStartPoint.X > pathEndPoint.X)
			{
				if ((pathEndPoint.Y - pathStartPoint.Y) > (pathStartPoint.X - pathEndPoint.X))
				{
					this.SinkLabelPosition = new Point(pathEndPoint.X, pathEndPoint.Y - 20);
				}
				else
				{
					this.SinkLabelPosition = pathEndPoint;
				}
			}
			else
			{
				if ((pathEndPoint.Y - pathStartPoint.Y) > (pathStartPoint.X - pathEndPoint.X))
				{
					this.SinkLabelPosition = new Point(pathEndPoint.X - 30, pathEndPoint.Y - 25);
				}
				else
				{
					this.SinkLabelPosition = new Point(pathEndPoint.X - 30, pathEndPoint.Y - 5);
				}
			}
		}

        private void ShowAdorner()
        {
            // the ConnectionAdorner is created once for each Connection
            if (this.connectionAdorner == null)
            {
				DesignerCanvas designer = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(this) as DesignerCanvas;

                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(designer);
                if (adornerLayer != null)
                {
                    this.connectionAdorner = new ConnectionAdorner(designer, this);
                    adornerLayer.Add(this.connectionAdorner);
                }
            }
            this.connectionAdorner.Visibility = Visibility.Visible;
        }

        internal void HideAdorner()
        {
            if (this.connectionAdorner != null)
                this.connectionAdorner.Visibility = Visibility.Collapsed;
        }

        void Connection_Unloaded(object sender, RoutedEventArgs e)
        {
            // do some housekeeping when Connection is unloaded

            // remove event handler
			if (source != null)
			{
				source.PropertyChanged -= new PropertyChangedEventHandler(OnConnectorPositionChanged);
			}
			if (sink != null)
			{
				sink.PropertyChanged -= new PropertyChangedEventHandler(OnConnectorPositionChanged);
			}

            // remove adorner
            if (this.connectionAdorner != null)
            {
				DesignerCanvas designer = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(this) as DesignerCanvas;
				if (designer != null)
				{
					AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(designer);
					if (adornerLayer != null)
					{
						adornerLayer.Remove(this.connectionAdorner);
						this.connectionAdorner = null;
					}
				}
            }
        }

        #region INotifyPropertyChanged Members

        // we could use DependencyProperties as well to inform others of property changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }

    public enum ArrowSymbol
    {
        None,
        Arrow,
		DoubleArrow,
        Diamond
    }
}
