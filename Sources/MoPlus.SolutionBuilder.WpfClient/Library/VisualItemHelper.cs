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
    /// <summary>This class helps retrieve items up and down the visual tree.</summary>
    ///--------------------------------------------------------------------------------
	public static class VisualItemHelper
    {
        #region "Properties"
		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves a parent up the visual tree from the input source.</summary>
		///--------------------------------------------------------------------------------
		public static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
		{
			try
			{
				while (source != null && source.GetType() != typeof(T))
					source = VisualTreeHelper.GetParent(source);
				return source;
			}
			catch { }
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method retrieves a sibling of the visual tree from the input source.</summary>
		///--------------------------------------------------------------------------------
		public static DependencyObject VisualSiblingSearch<T>(DependencyObject source)
		{
			try
			{
				DependencyObject parent = VisualTreeHelper.GetParent(source);
				int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
				for (int i = 0; i < childrenCount; i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(parent, i);
					if (child.GetType() == typeof(T))
					{
						return child;
					}
				}
				return null;
			}
			catch { }
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Finds a Child of a given item in the visual tree.</summary>
		/// 
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T">The type of the queried item.</typeparam>
		/// <param name="childName">x:Name or Name of child. </param>
		/// <returns>The first parent item that matches the submitted type parameter.
		/// If not matching item can be found, a null parent is being returned.</returns>
		///--------------------------------------------------------------------------------
		public static T FindChild<T>(DependencyObject parent, string childName = null) where T : DependencyObject
		{
			// Confirm parent and childName are valid.
			if (parent == null) return null;
			T foundChild = null;
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				// If the child is not of the request child type child
				T childType = child as T;
				if (childType == null)
				{
					// recursively drill down the tree
					foundChild = FindChild<T>(child, childName);
					// If the child is found, break so we do not overwrite the found child.
					if (foundChild != null) break;
				}
				else if (!string.IsNullOrEmpty(childName))
				{
					var frameworkElement = child as FrameworkElement;
					// If the child's name is set for search
					if (frameworkElement != null && frameworkElement.Name == childName)
					{
						// if the child's name is of the request name
						foundChild = (T)child;
						break;
					}
				}
				else
				{
					// child element found.
					foundChild = (T)child;
					break;
				}
			}
			return foundChild;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Finds a Child of a given item in the visual tree.</summary>
		/// 
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T">The type of the queried item.</typeparam>
		/// <param name="childName">x:Name or Name of child. </param>
		/// <returns>The first parent item that matches the submitted type parameter.
		/// If not matching item can be found, a null parent is being returned.</returns>
		///--------------------------------------------------------------------------------
		public static T FindChild<T>(DependencyObject parent, object dataContext) where T : DependencyObject
		{
			// Confirm parent and childName are valid.
			if (parent == null) return null;
			T foundChild = null;
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				// If the child is not of the request child type child
				T childType = child as T;
				if (childType == null)
				{
					// recursively drill down the tree
					foundChild = FindChild<T>(child, dataContext);
					// If the child is found, break so we do not overwrite the found child.
					if (foundChild != null) break;
				}
				else if (dataContext != null)
				{
					var frameworkElement = child as FrameworkElement;
					// If the child's name is set for search
					if (frameworkElement != null && frameworkElement.DataContext == dataContext)
					{
						// if the child's name is of the request name
						foundChild = (T)child;
						break;
					}
				}
				else
				{
					// child element found.
					foundChild = (T)child;
					break;
				}
			}
			return foundChild;
		}

		/// <summary>
		/// Find a specific parent object type in the visual tree
		/// </summary>
		public static T FindParent<T>(DependencyObject outerDepObj) where T : DependencyObject
		{
			DependencyObject dObj = VisualTreeHelper.GetParent(outerDepObj);
			if (dObj == null)
				return null;

			if (dObj is T)
				return dObj as T;

			while ((dObj = VisualTreeHelper.GetParent(dObj)) != null)
			{
				if (dObj is T)
					return dObj as T;
			}

			return null;
		}

		#endregion "Methods"
    }
}
