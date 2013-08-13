/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Diagnostics;

namespace MoPlus.Common
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used as the default exception handler.</summary>
	///--------------------------------------------------------------------------------
	public class ExceptionHandler
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>Execute the library layer exception policy.</summary>
		///
		/// <param name="ex">The exception to handle.</param>
		/// 
		/// <remarks>The recommended policy at this layer is to wrap and rethrow any
		/// exceptions encountered, to be further handled and logged at enterprise layers.</remarks>
		/// 
		/// <returns>True if exception is handled.</returns>
		///--------------------------------------------------------------------------------
		public static bool HandleException(Exception ex)
		{
			return HandleException(ex, Configuration.LIBRARY_EXCEPTION_POLICY);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Execute the library layer exception policy.</summary>
		///
		/// <param name="ex">The exception to handle.</param>
		/// <param name="exceptionPolicyName">The name of the exception policy in the
		/// Microsoft Enterprise Library Configuration.</param>
		/// 
		/// <remarks>The recommended policy at this layer is to wrap and rethrow any
		/// exceptions encountered, to be further handled and logged at enterprise layers.</remarks>
		/// 
		/// <returns>True if a rethrow of the exception is recommended.</returns>
		///--------------------------------------------------------------------------------
		public static bool HandleException(Exception ex, string exceptionPolicyName)
		{
			bool reThrow = true;
			try
			{
				reThrow = ExceptionPolicy.HandleException(ex, exceptionPolicyName);
			}
			catch (Exception exFail)
			{
				// write issue to event log
				EventLog.WriteEntry("MoPlus.Common", "Enterprise Library likely not configured correctly: " + exFail.Message);
			}
			return reThrow;
		}
		#endregion "Methods"
	}
}
