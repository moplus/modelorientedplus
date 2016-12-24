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
using MoPlus.Common;
using MoPlus.Data;

namespace MoPlus.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface is used for all enterprise data objects (data access
	/// objects, business objects, etc.).</summary>
	///--------------------------------------------------------------------------------
	public interface IDomainEnterpriseObject : IEnterpriseDataObject
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		string Name { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parent item of this item.</summary>
		///--------------------------------------------------------------------------------
		IDomainEnterpriseObject GetParentItem();

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of TagList.</summary>
		///--------------------------------------------------------------------------------
		EnterpriseDataObjectList<BLL.Solutions.Tag> TagList { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a tag to TagList.</summary>
		///--------------------------------------------------------------------------------
		void AddTag(string tagName);

		///--------------------------------------------------------------------------------
		/// <summary>This method removes a tag from TagList.</summary>
		///--------------------------------------------------------------------------------
		void RemoveTag(string tagName);
	}
}
