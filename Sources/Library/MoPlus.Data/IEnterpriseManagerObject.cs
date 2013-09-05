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
	/// <summary>This interface is used for all enterprise manager objects that don't hold
	/// data directly.</summary>
	///--------------------------------------------------------------------------------
	public interface IEnterpriseManagerObject
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property determines what database this entity is associated with,
		/// and how that database should be accessed.</summary>
		///--------------------------------------------------------------------------------
		DatabaseOptions DatabaseOptions { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property determines how data for this entity is to be paged and
		/// sorted.</summary>
		///--------------------------------------------------------------------------------
		DataAccessOptions DataAccessOptions { get; set; }
	}
}
