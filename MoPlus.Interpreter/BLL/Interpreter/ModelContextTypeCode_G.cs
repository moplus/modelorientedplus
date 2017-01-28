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
	/// model context types.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/22/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public enum ModelContextTypeCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For AuditProperty template types.</summary>
		AuditProperty = 1,
		/// <summary>For Collection template types.</summary>
		Collection = 2,
		/// <summary>For Entity template types.</summary>
		Entity = 3,
		/// <summary>For EntityReference template types.</summary>
		EntityReference = 4,
		/// <summary>For Enumeration template types.</summary>
		Enumeration = 5,
		/// <summary>For Feature template types.</summary>
		Feature = 6,
		/// <summary>For Index template types.</summary>
		Index = 7,
		/// <summary>For IndexProperty template types.</summary>
		IndexProperty = 8,
		/// <summary>For Method template types.</summary>
		Method = 9,
		/// <summary>For MethodRelationship template types.</summary>
		MethodRelationship = 10,
		/// <summary>For Model template types.</summary>
		Model = 11,
		/// <summary>For ModelObject template types.</summary>
		ModelObject = 12,
		/// <summary>For ModelProperty template types.</summary>
		ModelProperty = 13,
		/// <summary>For ObjectInstance template types.</summary>
		ObjectInstance = 14,
		/// <summary>For Parameter template types.</summary>
		Parameter = 15,
		/// <summary>For Project template types.</summary>
		Project = 16,
		/// <summary>For Property template types.</summary>
		Property = 17,
		/// <summary>For PropertyInstance template types.</summary>
		PropertyInstance = 18,
		/// <summary>For PropertyReference template types.</summary>
		PropertyReference = 19,
		/// <summary>For PropertyRelationship template types.</summary>
		PropertyRelationship = 20,
		/// <summary>For Relationship template types.</summary>
		Relationship = 21,
		/// <summary>For RelationshipProperty template types.</summary>
		RelationshipProperty = 22,
		/// <summary>For Solution template types.</summary>
		Solution = 23,
		/// <summary>For Stage template types.</summary>
		Stage = 24,
		/// <summary>For StageTransition template types.</summary>
		StageTransition = 25,
		/// <summary>For State template types.</summary>
		State = 26,
		/// <summary>For StateModel template types.</summary>
		StateModel = 27,
		/// <summary>For StateTransition template types.</summary>
		StateTransition = 28,
		/// <summary>For Step template types.</summary>
		Step = 29,
		/// <summary>For StepTransition template types.</summary>
		StepTransition = 30,
		/// <summary>For Value template types.</summary>
		Value = 31,
		/// <summary>For View template types.</summary>
		View = 32,
		/// <summary>For ViewProperty template types.</summary>
		ViewProperty = 33,
		/// <summary>For Workflow template types.</summary>
		Workflow = 34,

		#region protected
		/// <summary>For Tag template types.</summary>
		Tag = 101,
		#endregion protected
	}
}
