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

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface is used for all enterprise data objects (data access
	/// objects, business objects, etc.).</summary>
	///--------------------------------------------------------------------------------
	public interface IEnterpriseDataObject : IDataObject
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been modified since the
		/// last load from a resource such as a database.</summary>
		///--------------------------------------------------------------------------------
		bool IsModified { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been loaded from a resource
		/// such as a database.</summary>
		///--------------------------------------------------------------------------------
		bool IsLoaded { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property is used to get the set of properties that comprise the
		/// primary key.</summary>
		///--------------------------------------------------------------------------------
		string PrimaryKeyProperties { get;}

		///--------------------------------------------------------------------------------
		/// <summary>This property is used to get a reliable unique value for each instance
		/// of the data object.</summary>
		///--------------------------------------------------------------------------------
		string PrimaryKeyValues { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsLoaded state for the instance.</summary>
		///
		/// <remarks>This should only be used if special business rules override normal loading behavior.</remarks>
		/// 
		/// <param name="isLoaded">The reset value for the IsLoaded property.</param>
		///--------------------------------------------------------------------------------
		void ResetLoaded(bool isLoaded);

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsModified state for the instance.</summary>
		///
		/// <remarks>This should only be used if special business rules override normal modified behavior.</remarks>
		/// 
		/// <param name="isModified">The reset value for the IsModified property.</param>
		///--------------------------------------------------------------------------------
		void ResetModified(bool isModified);

	}
}
