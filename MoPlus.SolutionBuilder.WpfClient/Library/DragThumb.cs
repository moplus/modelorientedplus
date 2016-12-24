/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
*</copyright>*/
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Diagrams;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    public class DragThumb : Thumb
    {
        public DragThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(DragThumb_DragDelta);
			base.DragCompleted += new DragCompletedEventHandler(DragThumb_DragCompleted);
        }

		protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
		{
			base.OnMouseDown(e);
			if (DataContext is IWorkspaceViewModel)
			{
				(DataContext as IWorkspaceViewModel).SetSelected();
				DesignerItem control = VisualItemHelper.VisualUpwardSearch<DesignerItem>(this) as DesignerItem;
				if (control != null)
				{
					control.Focus();
				}
			}
		}

		void DragThumb_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			DesignerItem designerItem = VisualItemHelper.VisualUpwardSearch<DesignerItem>(this) as DesignerItem;
			if (designerItem != null)
			{
				EntityDiagramControl entityControl = VisualItemHelper.FindChild<EntityDiagramControl>(designerItem);
				if (entityControl != null)
				{
					entityControl.UpdateConnections();
				}
			}
		}

        void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
			DesignerItem designerItem = VisualItemHelper.VisualUpwardSearch<DesignerItem>(this) as DesignerItem;
			DesignerCanvas designer = VisualItemHelper.VisualUpwardSearch<DesignerCanvas>(designerItem) as DesignerCanvas;
            if (designerItem != null && designer != null && designerItem.IsSelected)
            {
				IDiagramWorkspaceViewModel designerView = designer.DataContext as IDiagramWorkspaceViewModel;
				if (designerView != null)
				{
					double minLeft = double.MaxValue;
					double minTop = double.MaxValue;

					foreach (IDiagramWorkspaceViewModel item in designerView.SelectedItems.OfType<IDiagramEntityWorkspaceViewModel>())
					{
						minLeft = double.IsNaN(item.X) ? 0 : Math.Min(item.X, minLeft);
						minTop = double.IsNaN(item.Y) ? 0 : Math.Min(item.Y, minTop);
					}

					double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
					double deltaVertical = Math.Max(-minTop, e.VerticalChange);

					// move diagram entities (TODO: handle arcs later or a separate view model interface for arcs)
					foreach (IDiagramEntityWorkspaceViewModel item in designerView.SelectedItems.OfType<IDiagramEntityWorkspaceViewModel>())
					{
						item.X += deltaHorizontal;
						item.Y += deltaVertical;
						if (item.ZIndex < designerView.ZIndex)
						{
							item.ZIndex = ++designerView.ZIndex;
						}
					}

					designer.InvalidateMeasure();
					e.Handled = true;
				}
            }
        }
    }
}
