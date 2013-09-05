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
using MoPlus.ViewModel;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides base functionality for toolbox user controls.</summary>
	///--------------------------------------------------------------------------------
	public class ToolBoxControl : EditControl
	{
		private bool _isDocked = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsDocked.</summary>
		///--------------------------------------------------------------------------------
		public bool IsDocked
		{
			get
			{
				return _isDocked;
			}
			set
			{
				_isDocked = value;
			}
		}
	}
}
