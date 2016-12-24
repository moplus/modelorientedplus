/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
*</copyright>*/
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	public class DraggableListBox : ListBox
    {
		private Point? dragStartPoint = null;

		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
			dragStartPoint = new Point?(e.GetPosition(this));
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.LeftButton != MouseButtonState.Pressed)
				dragStartPoint = null;

			if (dragStartPoint.HasValue)
			{
				if (SelectionMode == SelectionMode.Single)
				{
					DragDrop.DoDragDrop(this, SelectedItem, DragDropEffects.Copy);
				}
				else
				{
					List<object> items = new List<object>();
					foreach (object item in SelectedItems)
					{
						items.Add(item);
					}
					DragDrop.DoDragDrop(this, items, DragDropEffects.Copy);
				}
				e.Handled = true;
			}
		}
    }
}
