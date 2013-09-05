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
	/// <summary>This class provides the view for the status workspace.</summary>
	/// 
	/// <remarks>Derived from Microsoft MVVM design pattern example (http://msdn.microsoft.com/en-us/magazine/dd419663.aspx).</remarks>
	///--------------------------------------------------------------------------------
	public class StatusViewModel : WorkspaceViewModel
	{
		#region "Properties"
		public delegate void StatusChangeEventHandler(object sender, StatusEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling progress changes.</summary>
		///--------------------------------------------------------------------------------
		public event StatusChangeEventHandler ProgressChanged;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling status changes.</summary>
		///--------------------------------------------------------------------------------
		public event StatusChangeEventHandler StatusChanged;

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method processes progress changes.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Event_ProgressChanged, ParameterType = typeof(StatusEventArgs))]
		private void ProcessReportProgress(StatusEventArgs data)
		{
			OnProgressChanged(this, data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles progress changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnProgressChanged(object sender, StatusEventArgs args)
		{
			if (ProgressChanged != null)
			{
				ProgressChanged(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes status changes.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Event_StatusChanged, ParameterType = typeof(StatusEventArgs))]
		private void ProcessStatusChange(StatusEventArgs data)
		{
			OnStatusChanged(this, data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles status changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnStatusChanged(object sender, StatusEventArgs args)
		{
			if (StatusChanged != null)
			{
				StatusChanged(this, args);
			}
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor.</summary>
		///--------------------------------------------------------------------------------
		public StatusViewModel()
		{
			// Register all decorated methods to the Mediator
			Mediator.Register(this);
		}

		#endregion "Constructors"
	}
}
