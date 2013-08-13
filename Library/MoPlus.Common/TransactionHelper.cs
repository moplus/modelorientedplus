/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Transactions;

namespace MoPlus.Common
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help with transactions.</summary>
	///--------------------------------------------------------------------------------
	public static class TransactionHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method creates a transaction.  This method may not be useful.</summary>
		///
		/// <param name="timeout">The time for the transaction to be active.</param>
		/// 
		/// <returns>An instance of CommittableTransaction.</returns>
		///--------------------------------------------------------------------------------
		public static CommittableTransaction CreateTransaction(TimeSpan timeout)
		{
			// create transaction
			if (timeout != null)
			{
				return new CommittableTransaction(timeout);
			}
			return new CommittableTransaction();
		}

		#endregion "Methods"
	}
}
