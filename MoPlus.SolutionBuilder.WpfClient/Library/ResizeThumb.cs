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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Diagrams;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    public class ResizeThumb : Thumb
    {
        public ResizeThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(ResizeThumb_DragDelta);
        }

		void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
			DesignerItem designerItem = VisualItemHelper.VisualUpwardSearch<DesignerItem>(this) as DesignerItem;
			DesignerCanvas designer = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(designerItem) as DesignerCanvas;

			if (designerItem != null && designer != null && designerItem.IsSelected)
			{
				IDiagramWorkspaceViewModel designerView = designer.DataContext as IDiagramWorkspaceViewModel;
				if (designerView != null)
				{
					double minLeft, minTop, minDeltaHorizontal, minDeltaVertical;
					double dragDeltaVertical, dragDeltaHorizontal;

					CalculateDragLimits(designer, designerView.SelectedItems.OfType<DiagramEntityViewModel>(), out minLeft, out minTop,
										out minDeltaHorizontal, out minDeltaVertical);

					// resize diagram entities (TODO: handle arcs later or a separate view model interface for arcs)
					foreach (IDiagramEntityWorkspaceViewModel item in designerView.SelectedItems.OfType<IDiagramEntityWorkspaceViewModel>())
					{
						DesignerItem itemControl = VisualItemHelper.FindChild<DesignerItem>(designer, item) as DesignerItem;
						if (itemControl != null)
						{
							switch (base.VerticalAlignment)
							{
								case VerticalAlignment.Bottom:
									dragDeltaVertical = Math.Min(-e.VerticalChange, minDeltaVertical);
									item.Height = Math.Max(MinHeight, itemControl.ActualHeight - dragDeltaVertical);
									break;
								case VerticalAlignment.Top:
									dragDeltaVertical = Math.Min(Math.Max(-minTop, e.VerticalChange), minDeltaVertical);
									item.Y += dragDeltaVertical;
									item.Height = Math.Max(MinHeight, itemControl.ActualHeight - dragDeltaVertical);
									break;
								default:
									break;
							}

							switch (base.HorizontalAlignment)
							{
								case HorizontalAlignment.Left:
									dragDeltaHorizontal = Math.Min(Math.Max(-minLeft, e.HorizontalChange), minDeltaHorizontal);
									item.X += dragDeltaHorizontal;
									item.Width = Math.Max(MinWidth, itemControl.ActualWidth - dragDeltaHorizontal);
									break;
								case HorizontalAlignment.Right:
									dragDeltaHorizontal = Math.Min(-e.HorizontalChange, minDeltaHorizontal);
									item.Width = Math.Max(MinWidth, itemControl.ActualWidth - dragDeltaHorizontal);
									break;
								default:
									break;
							}
						}
					}
					e.Handled = true;
				}
			}
        }

		private static void CalculateDragLimits(DesignerCanvas designer, IEnumerable<IDiagramWorkspaceViewModel> selectedDesignerItems, out double minLeft, out double minTop, out double minDeltaHorizontal, out double minDeltaVertical)
        {
            minLeft = double.MaxValue;
            minTop = double.MaxValue;
            minDeltaHorizontal = double.MaxValue;
            minDeltaVertical = double.MaxValue;

            // drag limits are set by these parameters: canvas top, canvas left, minHeight, minWidth
            // calculate min value for each parameter for each item
			foreach (IDiagramWorkspaceViewModel item in selectedDesignerItems)
			{
				DesignerItem itemControl = VisualItemHelper.FindChild<DesignerItem>(designer, item) as DesignerItem;
				if (itemControl != null)
				{
					minLeft = double.IsNaN(item.X) ? 0 : Math.Min(item.X, minLeft);
					minTop = double.IsNaN(item.Y) ? 0 : Math.Min(item.Y, minTop);

					minDeltaVertical = Math.Min(minDeltaVertical, itemControl.ActualHeight - itemControl.MinHeight);
					minDeltaHorizontal = Math.Min(minDeltaHorizontal, itemControl.ActualWidth - itemControl.MinWidth);
				}
			}
        }
    }
}
