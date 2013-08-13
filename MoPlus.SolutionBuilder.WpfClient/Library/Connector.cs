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

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    public class Connector : Control, INotifyPropertyChanged
    {
        // drag start point, relative to the DesignerCanvas
        private Point? dragStartPoint = null;

        public ConnectorOrientation Orientation { get; set; }

        // center position of this Connector relative to the DesignerCanvas
        private Point position;
        public Point Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged("Position");
                }
            }
        }

		// get the parent designer item
		private DesignerItem _parentDesignerItem;
		public DesignerItem ParentDesignerItem
		{
			get
			{
				if (_parentDesignerItem == null)
				{
					_parentDesignerItem = VisualItemHelper.VisualUpwardSearch<DesignerItem>(this) as DesignerItem;
				}

				return _parentDesignerItem;
			}
		}

		// get the parent canvas
		private DesignerCanvas _parentCanvas;
		public DesignerCanvas ParentCanvas
		{
			get
			{
				if (_parentCanvas == null)
				{
					_parentCanvas = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(this) as DesignerCanvas;
				}

				return _parentCanvas;
			}
		}

		// get the parent designer item
		private IDiagramWorkspaceViewModel _parentViewModel;
		public IDiagramWorkspaceViewModel ParentViewModel
		{
			get
			{
				if (_parentViewModel == null)
				{
					if (ParentDesignerItem != null)
					{
						_parentViewModel = ParentDesignerItem.DataContext as IDiagramWorkspaceViewModel;
					}
				}

				return _parentViewModel;
			}
		}

		// keep track of connections that link to this connector
        private List<Connection> connections;
        public List<Connection> Connections
        {
            get
            {
                if (connections == null)
                    connections = new List<Connection>();
                return connections;
            }
        }

		// get/set the diagram entity workspace
		DiagramEntityWorkspaceViewModel DiagramEntityWorkspace { get; set; }

		// get/set the relative position to the diagram entity
		Point RelativePosition { get; set; }
		public bool ResetRelativePosition { get; set; }

		public Connector()
        {
            // fired when layout changes
			base.LayoutUpdated += new EventHandler(Connector_LayoutUpdated);
			base.Loaded += new RoutedEventHandler(Connector_Loaded);
			base.DataContextChanged += new DependencyPropertyChangedEventHandler(Connector_DataContextChanged);
			ResetRelativePosition = true;
        }

		void Connector_Loaded(object sender, RoutedEventArgs e)
		{
			UpdatePosition();
		}

		void Connector_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DiagramEntityWorkspace = DataContext as DiagramEntityWorkspaceViewModel;
		}

		void UpdatePosition()
		{
			if (DiagramEntityWorkspace != null && ParentCanvas != null)
			{
				if (ResetRelativePosition == true || (RelativePosition.X == 0 && RelativePosition.Y == 0))
				{
					//get centre position of this Connector relative to the DesignerCanvas
					Position = this.TransformToAncestor(ParentCanvas).Transform(new Point(this.Width / 2, this.Height / 2));
					RelativePosition = new Point(Position.X - DiagramEntityWorkspace.X, Position.Y - DiagramEntityWorkspace.Y);
					ResetRelativePosition = false;
				}
				else
				{
				    Position = new Point(RelativePosition.X + DiagramEntityWorkspace.X, RelativePosition.Y + DiagramEntityWorkspace.Y);
				}
			}
		}

        // when the layout changes we update the position property
        void Connector_LayoutUpdated(object sender, EventArgs e)
        {
			if (IsLoaded == true)
			{
				UpdatePosition();
			}
       }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
			if (ParentCanvas != null)
            {
                // position relative to DesignerCanvas
				this.dragStartPoint = new Point?(e.GetPosition(ParentCanvas));
                e.Handled = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                this.dragStartPoint = null;

            // but if mouse button is pressed and start point value is set we do have one
            if (this.dragStartPoint.HasValue)
            {
                // create connection adorner 
				if (ParentCanvas != null)
                {
					AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(ParentCanvas);
                    if (adornerLayer != null)
                    {
						ConnectorAdorner adorner = new ConnectorAdorner(ParentCanvas, this);
                        if (adorner != null)
                        {
                            adornerLayer.Add(adorner);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        internal ConnectorInfo GetInfo()
        {
            ConnectorInfo info = new ConnectorInfo();
			if (ParentViewModel != null)
			{
				info.DesignerItemLeft = ParentViewModel.X;
				info.DesignerItemTop = ParentViewModel.Y;
			}
			if (ParentDesignerItem != null)
			{
				info.DesignerItemSize = new Size(ParentDesignerItem.ActualWidth, ParentDesignerItem.ActualHeight);
			}
            info.Orientation = this.Orientation;
            info.Position = this.Position;
            return info;
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

    // provides compact info about a connector; used for the 
    // routing algorithm, instead of hand over a full fledged Connector
    internal struct ConnectorInfo
    {
        public double DesignerItemLeft { get; set; }
        public double DesignerItemTop { get; set; }
        public Size DesignerItemSize { get; set; }
        public Point Position { get; set; }
        public ConnectorOrientation Orientation { get; set; }
    }

    public enum ConnectorOrientation
    {
        None,
        Left,
        Top,
        Right,
        Bottom
    }
}
