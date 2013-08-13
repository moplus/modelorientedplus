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
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class manages underscores for disabled buttons.</summary>
    ///--------------------------------------------------------------------------------
	public class DisableButtonStringConverter : IValueConverter
    {
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method replaces underscores from a string for disabled buttons.</summary>
		///--------------------------------------------------------------------------------
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(string))
				throw new InvalidOperationException("The target type must be a string.");

			if (value != null)
			{
				return value.ToString().Replace("_", "");
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method restores underscores from a string for disabled buttons.</summary>
		///--------------------------------------------------------------------------------
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		#endregion "Methods"
    }
}
