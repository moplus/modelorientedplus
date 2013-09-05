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
using System.Windows.Data;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides a datagrid combo box column that you can bind to.</summary>
	///--------------------------------------------------------------------------------
	public class BindableDataGridComboBoxColumn : DataGridComboBoxColumn
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ParentGrid.</summary>
		///--------------------------------------------------------------------------------
		RoutableDataGrid _parentGrid = null;
		public RoutableDataGrid ParentGrid
		{
			get
			{
				if (_parentGrid == null)
				{
					_parentGrid = VisualItemHelper.VisualUpwardSearch<RoutableDataGrid>(Element as DependencyObject) as RoutableDataGrid;

				}
				return _parentGrid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ui Element.</summary>
		///--------------------------------------------------------------------------------
		protected FrameworkElement Element { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method generates the editing element.</summary>
		///--------------------------------------------------------------------------------
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			Element = base.GenerateEditingElement(cell, dataItem);
			Element.MouseEnter += new System.Windows.Input.MouseEventHandler(element_MouseEnter);
			Element.MouseLeave += new System.Windows.Input.MouseEventHandler(element_MouseLeave);
			CopyItemsSource(Element);
			return Element;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Raise the ElementClosed event on mouse leave.</summary>
		/// 
		/// <param name="sender">The sender</param>
		/// <param name="e">Event args</param>
		///--------------------------------------------------------------------------------
		void element_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (ParentGrid != null)
			{
				ParentGrid.RaiseElementClosed();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Raise the ElementOpened event on mouse enter.</summary>
		/// 
		/// <param name="sender">The sender</param>
		/// <param name="e">Event args</param>
		///--------------------------------------------------------------------------------
		void element_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (ParentGrid != null)
			{
				ParentGrid.RaiseElementOpened();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method generates the element.</summary>
		///--------------------------------------------------------------------------------
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			Element = base.GenerateElement(cell, dataItem);
			CopyItemsSource(Element);
			return Element;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method copies the element to the source.</summary>
		///--------------------------------------------------------------------------------
		private void CopyItemsSource(FrameworkElement element)
		{
			BindingOperations.SetBinding(element, ComboBox.ItemsSourceProperty,
			  BindingOperations.GetBinding(this, ComboBox.ItemsSourceProperty));
		}
	}
}
