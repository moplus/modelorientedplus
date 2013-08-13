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
	/// read only properties.</summary>
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>3/10/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public enum ReadOnlyPropertyCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For DataTypeName read only property.</summary>
		DataTypeName = 1,
		/// <summary>For MethodTypeName read only property.</summary>
		MethodTypeName = 2,
		/// <summary>For IdentifierTypeName read only property.</summary>
		IdentifierTypeName = 3,
		/// <summary>For EntityTypeName read only property.</summary>
		EntityTypeName = 4,
		/// <summary>For SolutionID read only property.</summary>
		Template = 5,
		/// <summary>For TagName read only property.</summary>
		TagName = 6,
		/// <summary>For ParameterCount read only property.</summary>
		ParameterCount = 7,
		/// <summary>For PropertyReferenceCount read only property.</summary>
		PropertyReferenceCount = 8,
		/// <summary>For PropertyCount read only property.</summary>
		PropertyCount = 9,
		/// <summary>For CollectionCount read only property.</summary>
		CollectionCount = 10,
		/// <summary>For EntityReferenceCount read only property.</summary>
		EntityReferenceCount = 11,
		/// <summary>For MethodCount read only property.</summary>
		MethodCount = 12,
		/// <summary>For EntityCount read only property.</summary>
		EntityCount = 13,
		/// <summary>For ProjectCount read only property.</summary>
		ProjectCount = 14,
		/// <summary>For IsAuditProperty read only property.</summary>
		IsAuditProperty = 15,
		/// <summary>For IsBaseProperty read only property.</summary>
		IsBaseProperty = 16,
		/// <summary>For DefaultSourceName read only property.</summary>
		DefaultSourceName = 17,
		/// <summary>For OriginalName read only property.</summary>
		OriginalName = 18,
		/// <summary>For IsAutoUpdated read only property.</summary>
		IsAutoUpdated = 19,
		/// <summary>For ProjectReferenceCount read only property.</summary>
		ProjectReferenceCount = 20,
		/// <summary>For DatabaseTypeCode read only property.</summary>
		DatabaseTypeCode = 21,
		/// <summary>For UserName read only property.</summary>
		UserName = 22,
		/// <summary>For Password read only property.</summary>
		Password = 23,
		/// <summary>For DatabaseTypeName read only property.</summary>
		DatabaseTypeName = 24,
		/// <summary>For SolutionDirectory read only property.</summary>
		SolutionDirectory = 25,
		/// <summary>For PluralEntityName read only property.</summary>
		//PluralEntityName = 11,
	}
}