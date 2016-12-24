/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel
{
    ///--------------------------------------------------------------------------------
    /// <summary>This abstract class is for any view model corresponding to an item
	/// to be placed on a diagram.</summary>
    ///--------------------------------------------------------------------------------
	public abstract class DiagramWorkspaceViewModel : EditWorkspaceViewModel, IDiagramWorkspaceViewModel
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets X.</summary>
		///--------------------------------------------------------------------------------
		double _x = 0;
		public virtual double X
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
				OnPropertyChanged("X");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Y.</summary>
		///--------------------------------------------------------------------------------
		double _y = 0;
		public virtual double Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
				OnPropertyChanged("Y");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Width.</summary>
		///--------------------------------------------------------------------------------
		double _width = 0;
		public virtual double Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
				OnPropertyChanged("Width");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Height.</summary>
		///--------------------------------------------------------------------------------
		double _height = 0;
		public virtual double Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
				OnPropertyChanged("Height");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ZIndex.</summary>
		///--------------------------------------------------------------------------------
		int _zIndex = 0;
		public int ZIndex
		{
			get
			{
				return _zIndex;
			}
			set
			{
				_zIndex = value;
				OnPropertyChanged("ZIndex");
			}
		}

		#endregion "Properties"
    }
}
