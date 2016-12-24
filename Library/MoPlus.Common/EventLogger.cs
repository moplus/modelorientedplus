/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Diagnostics;
using System.Text;

namespace MoPlus.Common
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help with event logging operations.</summary>
	///--------------------------------------------------------------------------------
	public class EventLogger
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method creates an event log.  This method may not be useful.</summary>
		///
		/// <param name="eventLogName">The name of the event log.</param>
		/// 
		/// <returns>An instance of EventLog.</returns>
		///--------------------------------------------------------------------------------
		public static EventLog CreateEventLog(string eventLogName)
		{
			// create event log
			EventLog log = new EventLog();
			log.Log = eventLogName;
			return log;
		}
		#endregion "Methods"
	}
}
