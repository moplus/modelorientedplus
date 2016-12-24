/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
*</copyright>*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using MoPlus.ViewModel.Diagrams;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	public class ZoomBox : Control
	{
		private Thumb zoomThumb;
		private Canvas zoomCanvas;
		private Slider zoomSlider;
		private ScaleTransform scaleTransform;

		public ScrollViewer ScrollViewer
		{
			get { return (ScrollViewer)GetValue(ScrollViewerProperty); }
			set { SetValue(ScrollViewerProperty, value); }
		}

		public static readonly DependencyProperty ScrollViewerProperty =
			DependencyProperty.Register("ScrollViewer", typeof(ScrollViewer), typeof(ZoomBox));

		public DesignerCanvas DesignerCanvas
		{
			get { return (DesignerCanvas)GetValue(DesignerCanvasProperty); }
			set { SetValue(DesignerCanvasProperty, value); }
		}

		public static readonly DependencyProperty DesignerCanvasProperty =
			DependencyProperty.Register("DesignerCanvas", typeof(DesignerCanvas), typeof(ZoomBox));

		public double HorizontalOffset
		{
			get { return (double)GetValue(HorizontalOffsetProperty); }
			set { SetValue(HorizontalOffsetProperty, value); }
		}

		public static readonly DependencyProperty HorizontalOffsetProperty =
			DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(ZoomBox));

		public double VerticalOffset
		{
			get { return (double)GetValue(VerticalOffsetProperty); }
			set { SetValue(VerticalOffsetProperty, value); }
		}

		public static readonly DependencyProperty VerticalOffsetProperty =
			DependencyProperty.Register("VerticalOffset", typeof(double), typeof(ZoomBox));

		public double Scale
		{
			get
			{
				return (double)GetValue(ScaleProperty);
			}
			set
			{
				if (Scale != value)
				{
					SetValue(ScaleProperty, value);
				}
			}
		}

		public static readonly DependencyProperty ScaleProperty =
			DependencyProperty.Register("Scale", typeof(double), typeof(ZoomBox));

		public double GlobalScale
		{
			get
			{
				return (double)GetValue(GlobalScaleProperty);
			}
			set
			{
				if (GlobalScale != value)
				{
					SetValue(GlobalScaleProperty, value);
				}
			}
		}

		public static readonly DependencyProperty GlobalScaleProperty =
			DependencyProperty.Register("GlobalScale", typeof(double), typeof(ZoomBox));

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (this.ScrollViewer == null)
				return;

			if (this.DesignerCanvas == null)
				return;

			this.zoomThumb = Template.FindName("PART_ZoomThumb", this) as Thumb;
			if (this.zoomThumb == null)
				throw new Exception("PART_ZoomThumb template is missing!");

			this.zoomCanvas = Template.FindName("PART_ZoomCanvas", this) as Canvas;
			if (this.zoomCanvas == null)
				throw new Exception("PART_ZoomCanvas template is missing!");

			this.zoomSlider = Template.FindName("PART_ZoomSlider", this) as Slider;
			if (this.zoomSlider == null)
				throw new Exception("PART_ZoomSlider template is missing!");

			this.DesignerCanvas.LayoutUpdated += new EventHandler(this.DesignerCanvas_LayoutUpdated);

			this.zoomThumb.DragDelta += new DragDeltaEventHandler(this.Thumb_DragDelta);

			this.zoomSlider.ValueChanged += ZoomSlider_ValueChanged;

			this.scaleTransform = new ScaleTransform();
			this.DesignerCanvas.LayoutTransform = this.scaleTransform;
		}

		private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Scale = scaleTransform.ScaleX * (e.NewValue / e.OldValue);

			double halfViewportHeight = this.ScrollViewer.ViewportHeight / 2;
			VerticalOffset = ((this.ScrollViewer.VerticalOffset + halfViewportHeight) * Scale - halfViewportHeight);

			double halfViewportWidth = this.ScrollViewer.ViewportWidth / 2;
			HorizontalOffset = ((this.ScrollViewer.HorizontalOffset + halfViewportWidth) * Scale - halfViewportWidth);

			this.scaleTransform.ScaleX = Scale;
			this.scaleTransform.ScaleY = Scale;

			this.ScrollViewer.ScrollToHorizontalOffset(HorizontalOffset);
			this.ScrollViewer.ScrollToVerticalOffset(VerticalOffset);
		}

		private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
		{
			double scale, xOffset, yOffset;
			this.InvalidateScale(out scale, out xOffset, out yOffset);
			HorizontalOffset += e.HorizontalChange / scale;
			VerticalOffset += e.VerticalChange / scale;
			ScrollViewer.ScrollToHorizontalOffset(HorizontalOffset);
			ScrollViewer.ScrollToVerticalOffset(VerticalOffset);
		}

		private void DesignerCanvas_LayoutUpdated(object sender, EventArgs e)
		{
			double scale, xOffset, yOffset;
			this.InvalidateScale(out scale, out xOffset, out yOffset);

			this.zoomThumb.Width = this.ScrollViewer.ViewportWidth * scale;
			this.zoomThumb.Height = this.ScrollViewer.ViewportHeight * scale;

			Canvas.SetLeft(this.zoomThumb, xOffset + this.ScrollViewer.HorizontalOffset * scale);
			Canvas.SetTop(this.zoomThumb, yOffset + this.ScrollViewer.VerticalOffset * scale);
		}

		private void InvalidateScale(out double scale, out double xOffset, out double yOffset)
		{
			// designer canvas size
			double w = this.DesignerCanvas.ActualWidth * this.scaleTransform.ScaleX;
			double h = this.DesignerCanvas.ActualHeight * this.scaleTransform.ScaleY;

			// zoom canvas size
			double x = this.zoomCanvas.ActualWidth;
			double y = this.zoomCanvas.ActualHeight;

			double scaleX = x / w ;
			double scaleY = y / h ;

			scale = (scaleX < scaleY) ? scaleX : scaleY;

			xOffset = (x - scale * w) / 2;
			yOffset = (y - scale * h) / 2;

			scale = scale / UserSettingsHelper.Instance.ControlSize;
		}

		public ZoomBox()
		{
			this.DataContextChanged += new DependencyPropertyChangedEventHandler(ZoomBox_DataContextChanged);
		}

		void ZoomBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (DataContext is DiagramViewModel)
			{
				DiagramViewModel view = DataContext as DiagramViewModel;
				Scale = view.Scale;
				HorizontalOffset = view.HorizontalOffset;
				VerticalOffset = view.VerticalOffset;
				if (zoomSlider == null)
				{
					zoomSlider = Template.FindName("PART_ZoomSlider", this) as Slider;
				}
				if (zoomSlider != null)
				{
					zoomSlider.ValueChanged -= ZoomSlider_ValueChanged;
					zoomSlider.Value = Scale * 100;
					zoomSlider.ValueChanged += ZoomSlider_ValueChanged;
				}
				if (Scale > 0 && scaleTransform != null)
				{
					this.scaleTransform.ScaleX = Scale;
					this.scaleTransform.ScaleY = Scale;

					this.ScrollViewer.ScrollToHorizontalOffset(HorizontalOffset);
					this.ScrollViewer.ScrollToVerticalOffset(VerticalOffset);
				}
			}
		}
	}
}
