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
	/// <CreatedDate>7/2/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public enum SpecCurrentItemTypeCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For SqlColumn spec current item types.</summary>
		CurrentSqlColumn = 1,
		/// <summary>For SqlDatabase spec current item types.</summary>
		CurrentSqlDatabase = 2,
		/// <summary>For SqlExtendedProperty spec current item types.</summary>
		CurrentSqlExtendedProperty = 3,
		/// <summary>For SqlForeignKey spec current item types.</summary>
		CurrentSqlForeignKey = 4,
		/// <summary>For SqlForeignKeyColumn spec current item types.</summary>
		CurrentSqlForeignKeyColumn = 5,
		/// <summary>For SqlIndex spec current item types.</summary>
		CurrentSqlIndex = 6,
		/// <summary>For SqlIndexedColumn spec current item types.</summary>
		CurrentSqlIndexedColumn = 7,
		/// <summary>For SqlProperty spec current item types.</summary>
		CurrentSqlProperty = 8,
		/// <summary>For SqlTable spec current item types.</summary>
		CurrentSqlTable = 9,
		/// <summary>For XmlAttribute spec current item types.</summary>
		CurrentXmlAttribute = 10,
		/// <summary>For XmlDocument spec current item types.</summary>
		CurrentXmlDocument = 11,
		/// <summary>For XmlNode spec current item types.</summary>
		CurrentXmlNode = 12,

		#region protected
		#endregion protected
	}
}
