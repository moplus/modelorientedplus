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
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	public class DataGridHelper
	{
		#region DataGridCommitOnUnfocusedBehaviour

		public static bool GetDataGridCommitOnUnfocused(DataGrid datagrid)
		{
			return (bool)datagrid.GetValue(DataGridCommitOnUnfocusedProperty);
		}

		public static void SetDataGridCommitOnUnfocused(
		 DataGrid datagrid, bool value)
		{
			datagrid.SetValue(DataGridCommitOnUnfocusedProperty, value);
		}

		public static readonly DependencyProperty DataGridCommitOnUnfocusedProperty =
			DependencyProperty.RegisterAttached(
			"DataGridCommitOnUnfocused",
			typeof(bool),
			typeof(DataGridHelper),
			new UIPropertyMetadata(false, OnDataGridCommitOnUnfocusedChanged));

		static void OnDataGridCommitOnUnfocusedChanged(
		 DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			DataGrid datagrid = depObj as DataGrid;
			if (datagrid == null)
				return;

			if (e.NewValue is bool == false)
				return;

			if ((bool)e.NewValue)
			{
				datagrid.LostKeyboardFocus += CommitDataGridOnLostFocus;
				datagrid.DataContextChanged += CommitDataGridOnDataContextChanged;
			}
			else
			{
				datagrid.LostKeyboardFocus -= CommitDataGridOnLostFocus;
				datagrid.DataContextChanged -= CommitDataGridOnDataContextChanged;
			}
		}

		static void CommitDataGridOnLostFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			DataGrid senderDatagrid = sender as DataGrid;

			if (senderDatagrid == null)
				return;

			UIElement focusedElement = Keyboard.FocusedElement as UIElement;
			if (focusedElement == null)
				return;

			DataGrid focusedDatagrid = GetParentDatagrid(focusedElement); //let's see if the new focused element is inside a datagrid
			if (focusedDatagrid == senderDatagrid)
			{
				return;
				//if the new focused element is inside the same datagrid, then we don't need to do anything;
				//this happens, for instance, when we enter in edit-mode: the DataGrid element loses keyboard-focus, which passes to the selected DataGridCell child
			}

			//otherwise, the focus went outside the datagrid; in order to avoid exceptions like ("DeferRefresh' is not allowed during an AddNew or EditItem transaction")
			//or ("CommitNew is not allowed for this view"), we undo the possible pending changes, if any
			IEditableCollectionView collection = senderDatagrid.Items as IEditableCollectionView;

			try
			{
				collection.CommitEdit();
			}
			catch { }
		}

		private static DataGrid GetParentDatagrid(UIElement element)
		{
			UIElement childElement; //element from which to start the tree navigation, looking for a Datagrid parent

			if (element is ComboBoxItem) //since ComboBoxItem.Parent is null, we must pass through ItemsPresenter in order to get the parent ComboBox
			{
				ItemsPresenter parentItemsPresenter = VisualItemHelper.FindParent<ItemsPresenter>((element as ComboBoxItem));
				ComboBox combobox = parentItemsPresenter.TemplatedParent as ComboBox;
				childElement = combobox;
			}
			else
			{
				childElement = element;
			}

			DataGrid parentDatagrid = VisualItemHelper.FindParent<DataGrid>(childElement); //let's see if the new focused element is inside a datagrid
			return parentDatagrid;
		}

		static void CommitDataGridOnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DataGrid senderDatagrid = sender as DataGrid;

			if (senderDatagrid == null)
				return;

			IEditableCollectionView collection = senderDatagrid.Items as IEditableCollectionView;

			try
			{
				collection.CommitEdit();
			}
			catch { }
		}

		#endregion DataGridCommitOnUnfocusedBehaviour
	}
}
