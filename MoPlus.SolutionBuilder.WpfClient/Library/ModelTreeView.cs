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
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class allows the use of a custom tree view item.</summary>
	///--------------------------------------------------------------------------------
	public class ModelTreeView : TreeView
	{
		private ScrollViewer _scrollViewer = null;
		private ScrollViewer ScrollViewer
		{
			get
			{
				if (_scrollViewer == null)
				{
					_scrollViewer = VisualItemHelper.FindChild<ScrollViewer>(this) as ScrollViewer;
				}

				return _scrollViewer;
			}
		}

		private void ScrollIfNeeded(Point mouseLocation)
		{
			if (this.ScrollViewer != null)
			{
				double scrollOffset = 0.0;

				// See if we need to scroll down 
				if (this.ScrollViewer.ViewportHeight - mouseLocation.Y < 20.0)
				{
					scrollOffset = 5.0;
				}
				else if (mouseLocation.Y < 20.0)
				{
					scrollOffset = -5.0;
				}

				// Scroll the tree down or up 
				if (scrollOffset != 0.0)
				{
					scrollOffset += this.ScrollViewer.VerticalOffset;

					if (scrollOffset < 0.0)
					{
						scrollOffset = 0.0;
					}
					else if (scrollOffset > this.ScrollViewer.ScrollableHeight)
					{
						scrollOffset = this.ScrollViewer.ScrollableHeight;
					}

					this.ScrollViewer.ScrollToVerticalOffset(scrollOffset);
				}
			}
		}

		protected override void OnPreviewDragOver(DragEventArgs e)
		{
			base.OnPreviewDragOver(e);
			ScrollIfNeeded(MouseUtilities.GetMousePosition(this));
		}

		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ModelTreeViewItem();
		}

		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is ModelTreeViewItem;
		}

		protected override void OnDragEnter(DragEventArgs e)
		{
			base.OnDragEnter(e);
			e.Handled = true;
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);
			e.Handled = true;
		}

		protected override void OnDragLeave(DragEventArgs e)
		{
			base.OnDragLeave(e);
			e.Handled = true;
		}

		protected override void OnDrop(DragEventArgs e)
		{
			base.OnDrop(e);
			e.Handled = true;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			e.Handled = true;
		}
	}
}
