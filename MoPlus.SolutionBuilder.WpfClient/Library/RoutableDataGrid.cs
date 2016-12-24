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
using MoPlus.SolutionBuilder.WpfClient.Resources;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class adds some routed events to the datagrid.</summary>
	///--------------------------------------------------------------------------------
	public class RoutableDataGrid : DataGrid
	{
		public static readonly RoutedEvent ElementOpenedEvent = EventManager.RegisterRoutedEvent("ElementOpened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RoutableDataGrid));

		public event RoutedEventHandler ElementOpened
		{
			add { AddHandler(ElementOpenedEvent, value); }
			remove { RemoveHandler(ElementOpenedEvent, value); }
		}

		public static readonly RoutedEvent ElementClosedEvent = EventManager.RegisterRoutedEvent("ElementClosed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RoutableDataGrid));

		public event RoutedEventHandler ElementClosed
		{
			add { AddHandler(ElementClosedEvent, value); }
			remove { RemoveHandler(ElementClosedEvent, value); }
		}

		public void RaiseElementOpened()
		{
			RaiseEvent(new RoutedEventArgs(RoutableDataGrid.ElementOpenedEvent, this));
		}

		public void RaiseElementClosed()
		{
			RaiseEvent(new RoutedEventArgs(RoutableDataGrid.ElementClosedEvent, this));
		}
	}
}
