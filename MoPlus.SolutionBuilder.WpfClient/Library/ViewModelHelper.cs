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
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using MoPlus.ViewModel;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class helps manage view models and binding to view models.</summary>
    ///--------------------------------------------------------------------------------
	public static class ViewModelHelper
    {
        #region "Properties"
		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves a new tree view model.</summary>
		///--------------------------------------------------------------------------------
		public static BuilderViewModel GetTreeViewModel()
		{
			return new BuilderViewModel();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Finds a child view model of a given type in the visual tree.</summary>
		/// 
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T1">The type of the queried item.</typeparam>
		/// <typeparam name="T2">The type of the view model to return.</typeparam>
		/// <param name="childName">x:Name or Name of child. </param>
		/// <returns>The first child view model that matches the submitted type parameters.
		/// If not matching item can be found, a null child is being returned.</returns>
		///--------------------------------------------------------------------------------
		public static T2 FindChildView<T1, T2>(DependencyObject parent, string childName = null)
			where T1 : DependencyObject
			where T2 : IWorkspaceViewModel
		{
			// Confirm parent and childName are valid.
			if (parent == null) return default(T2);
			T2 foundView = default(T2);
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				// If the child is not of the request child type child
				T1 childType = child as T1;
				if (childType == null)
				{
					// recursively drill down the tree
					foundView = FindChildView<T1, T2>(child, childName);
					if (foundView != null)
						return foundView;
				}
				else
				{
					var frameworkElement = child as FrameworkElement;
					if (frameworkElement != null && (string.IsNullOrEmpty(childName) || frameworkElement.Name == childName))
					{
						// test child for view model type
						foundView = (T2)frameworkElement.DataContext;
						if (foundView != null)
							return foundView;
					}
				}
			}
			return default(T2);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Finds a child view model of a given type in the visual tree.</summary>
		/// 
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T2">The type of the view model to return.</typeparam>
		/// <param name="childName">x:Name or Name of child. </param>
		/// <returns>The first child view model that matches the submitted type parameters.
		/// If not matching item can be found, a null child is being returned.</returns>
		///--------------------------------------------------------------------------------
		public static T2 FindChildView<T2>(DependencyObject parent, string childName = null)
			where T2 : IWorkspaceViewModel
		{
			// Confirm parent and childName are valid.
			if (parent == null) return default(T2);
			T2 foundView = default(T2);
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				var frameworkElement = child as FrameworkElement;
				if (frameworkElement != null && (string.IsNullOrEmpty(childName) || frameworkElement.Name == childName))
				{
					// test child for view model type
					foundView = (T2)frameworkElement.DataContext;
					if (foundView != null)
						return foundView;
				}
				// recursively drill down the tree
				foundView = FindChildView<T2>(child, childName);
				if (foundView != null)
					return foundView;
			}
			return default(T2);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Finds a parent view model of a given type in the visual tree.</summary>
		/// 
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T1">The type of the queried item.</typeparam>
		/// <typeparam name="T2">The type of the view model to return.</typeparam>
		/// <returns>The first parent view model that matches the submitted type parameters.
		/// If not matching item can be found, a null parent is being returned.</returns>
		///--------------------------------------------------------------------------------
		public static T2 FindParentView<T1, T2>(DependencyObject outerDepObj)
			where T1 : DependencyObject
			where T2 : IWorkspaceViewModel
		{
			DependencyObject dObj = VisualTreeHelper.GetParent(outerDepObj);
			if (dObj == null)
				return default(T2);

			T2 foundView = default(T2);
			if (dObj is T1)
			{
				var frameworkElement = dObj as FrameworkElement;
				if (frameworkElement != null && frameworkElement.DataContext is T2)
				{
					// test child for view model type
					foundView = (T2)frameworkElement.DataContext;
					if (foundView != null)
						return foundView;
				}
			}

			while ((dObj = VisualTreeHelper.GetParent(dObj)) != null)
			{
				if (dObj is T1)
				{
					var frameworkElement = dObj as FrameworkElement;
					if (frameworkElement != null && frameworkElement.DataContext is T2)
					{
						// test child for view model type
						foundView = (T2)frameworkElement.DataContext;
						if (foundView != null)
							return foundView;
					}
				}
			}

			return default(T2);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Finds a parent view model of a given type in the visual tree.</summary>
		/// 
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T2">The type of the view model to return.</typeparam>
		/// <returns>The first parent view model that matches the submitted type parameters.
		/// If not matching item can be found, a null parent is being returned.</returns>
		///--------------------------------------------------------------------------------
		public static T2 FindParentView<T2>(DependencyObject outerDepObj)
			where T2 : IWorkspaceViewModel
		{
			DependencyObject dObj = VisualTreeHelper.GetParent(outerDepObj);
			if (dObj == null)
				return default(T2);

			T2 foundView = default(T2);
			var frameworkElement = dObj as FrameworkElement;
			if (frameworkElement != null && frameworkElement.DataContext is T2)
			{
				// test child for view model type
				foundView = (T2)frameworkElement.DataContext;
				if (foundView != null)
					return foundView;
			}

			while ((dObj = VisualTreeHelper.GetParent(dObj)) != null)
			{
				frameworkElement = dObj as FrameworkElement;
				if (frameworkElement != null && frameworkElement.DataContext is T2)
				{
					// test child for view model type
					foundView = (T2)frameworkElement.DataContext;
					if (foundView != null)
						return foundView;
				}
			}

			return default(T2);
		}

		#endregion "Methods"
    }
}
