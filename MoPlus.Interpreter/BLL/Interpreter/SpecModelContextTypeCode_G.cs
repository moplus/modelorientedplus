/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This enumeration is used to hold values used by business rules for
	/// spec current item types.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public enum SpecModelContextTypeCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For SqlColumn spec template types.</summary>
		SqlColumn = 1,
		/// <summary>For SqlDatabase spec template types.</summary>
		SqlDatabase = 2,
		/// <summary>For SqlExtendedProperty spec template types.</summary>
		SqlExtendedProperty = 3,
		/// <summary>For SqlForeignKey spec template types.</summary>
		SqlForeignKey = 4,
		/// <summary>For SqlForeignKeyColumn spec template types.</summary>
		SqlForeignKeyColumn = 5,
		/// <summary>For SqlIndex spec template types.</summary>
		SqlIndex = 6,
		/// <summary>For SqlIndexedColumn spec template types.</summary>
		SqlIndexedColumn = 7,
		/// <summary>For SqlProperty spec template types.</summary>
		SqlProperty = 8,
		/// <summary>For SqlTable spec template types.</summary>
		SqlTable = 9,
		/// <summary>For SqlView spec template types.</summary>
		SqlView = 10,
		/// <summary>For SqlViewProperty spec template types.</summary>
		SqlViewProperty = 11,
		/// <summary>For XmlAttribute spec template types.</summary>
		XmlAttribute = 12,
		/// <summary>For XmlDocument spec template types.</summary>
		XmlDocument = 13,
		/// <summary>For XmlNode spec template types.</summary>
		XmlNode = 14,

		#region protected
		/// <summary>For SpecificationSource template types.</summary>
		SpecificationSource = 101,
		#endregion protected
	}
}
