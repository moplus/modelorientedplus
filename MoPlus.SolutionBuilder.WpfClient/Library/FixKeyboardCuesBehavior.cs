/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Provided by user oatkins on code plex (https://wpftoolkit.codeplex.com/workitem/20882).
</copyright>*/
using System.Windows;
using System.Diagnostics;
using System;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Interactivity;
namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	public class FixKeyboardCuesBehavior : Behavior<UIElement>
	{
		private static readonly DependencyProperty ShowKeyboardCuesProperty;

		static FixKeyboardCuesBehavior()
		{
			Type keyboardNavigation = typeof(KeyboardNavigation);
			var field = keyboardNavigation.GetField("ShowKeyboardCuesProperty", BindingFlags.NonPublic | BindingFlags.Static);

			Debug.Assert(field != null, "field != null");

			ShowKeyboardCuesProperty = (DependencyProperty)field.GetValue(null);
		}

		protected override void OnAttached()
		{
			base.OnAttached();

			Window rootWindow = Window.GetWindow(this.AssociatedObject);
			if (rootWindow == null)
			{
				return;
			}

			BindingOperations.SetBinding(
				this.AssociatedObject,
				ShowKeyboardCuesProperty,
				new Binding("(KeyboardNavigation.ShowKeyboardCues)") { Source = rootWindow });
		}
	}
}