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
using System.Collections.ObjectModel;
using MoPlus.Data;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides the view for message output.</summary>
	///--------------------------------------------------------------------------------
	public class OutputViewModel : WorkspaceViewModel
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelClearText.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelClearText
		{
			get
			{
				return "Clear Text";
			}
		}

		public delegate void StatusChangeEventHandler(object sender, StatusEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling output changes.</summary>
		///--------------------------------------------------------------------------------
		public event StatusChangeEventHandler OutputChanged;

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method processes output changes.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Event_OutputChanged, ParameterType = typeof(StatusEventArgs))]
		public void ProcessOutputChange(StatusEventArgs data)
		{
			OnOutputChanged(this, data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles output changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnOutputChanged(object sender, StatusEventArgs args)
		{
			if (OutputChanged != null)
			{
				OutputChanged(this, args);
			}
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor.</summary>
		///--------------------------------------------------------------------------------
		public OutputViewModel()
		{
			// Register all decorated methods to the Mediator
			Mediator.Register(this);
		}

		#endregion "Constructors"
	}
}
