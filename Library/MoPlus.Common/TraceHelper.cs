/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MoPlus.Common
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help with tracing operations.</summary>
	///--------------------------------------------------------------------------------
	public static class TraceHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method adds a trace listener to console out.</summary>
		///--------------------------------------------------------------------------------
		public static void AddTraceListener()
		{
			Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a trace listener to the specified file path.</summary>
		/// 
		/// <param name="traceFilePath">The file to trace to.</param>
		///--------------------------------------------------------------------------------
		public static void AddTraceListener(string traceFilePath)
		{
			Trace.Listeners.Add(new TextWriterTraceListener(traceFilePath));
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method writes a message to the trace.</summary>
		/// 
		/// <param name="message">The trace message.</param>
		/// <param name="category">The trace category.</param>
		///--------------------------------------------------------------------------------
		public static void WriteTrace(string message, string category)
		{
			Trace.WriteLine(message, category);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method writes a message to the trace (if condition is true).</summary>
		/// 
		/// <param name="message">The trace message.</param>
		/// <param name="category">The trace category.</param>
		/// <param name="condition">The trace condition.</param>
		///--------------------------------------------------------------------------------
		public static void WriteTrace(string message, string category, bool condition)
		{
			Trace.WriteLineIf(condition, message, category);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method issues a trace assert if the condition is false.</summary>
		/// 
		/// <param name="condition">The trace condition.</param>
		/// <param name="message">The trace message.</param>
		/// <param name="category">The detailed message.</param>
		///--------------------------------------------------------------------------------
		public static void AssertTrace(bool condition, string message, string detailedMessage)
		{
			Trace.Assert(condition, message, detailedMessage);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method issues a trace fail.</summary>
		/// 
		/// <param name="message">The trace message.</param>
		/// <param name="category">The detailed message.</param>
		///--------------------------------------------------------------------------------
		public static void FailTrace(string message, string detailedMessage)
		{
			Trace.Fail(message, detailedMessage);
		}

		#endregion "Methods"
	}
}
