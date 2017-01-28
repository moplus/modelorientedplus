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
	/// current item types.</summary>
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
	public enum CurrentItemTypeCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For AuditProperty current item types.</summary>
		CurrentAuditProperty = 1,
		/// <summary>For Collection current item types.</summary>
		CurrentCollection = 2,
		/// <summary>For Entity current item types.</summary>
		CurrentEntity = 3,
		/// <summary>For EntityReference current item types.</summary>
		CurrentEntityReference = 4,
		/// <summary>For Enumeration current item types.</summary>
		CurrentEnumeration = 5,
		/// <summary>For Feature current item types.</summary>
		CurrentFeature = 6,
		/// <summary>For Index current item types.</summary>
		CurrentIndex = 7,
		/// <summary>For IndexProperty current item types.</summary>
		CurrentIndexProperty = 8,
		/// <summary>For Method current item types.</summary>
		CurrentMethod = 9,
		/// <summary>For MethodRelationship current item types.</summary>
		CurrentMethodRelationship = 10,
		/// <summary>For Model current item types.</summary>
		CurrentModel = 11,
		/// <summary>For ModelObject current item types.</summary>
		CurrentModelObject = 12,
		/// <summary>For ModelProperty current item types.</summary>
		CurrentModelProperty = 13,
		/// <summary>For ObjectInstance current item types.</summary>
		CurrentObjectInstance = 14,
		/// <summary>For Parameter current item types.</summary>
		CurrentParameter = 15,
		/// <summary>For Project current item types.</summary>
		CurrentProject = 16,
		/// <summary>For Property current item types.</summary>
		CurrentProperty = 17,
		/// <summary>For PropertyInstance current item types.</summary>
		CurrentPropertyInstance = 18,
		/// <summary>For PropertyReference current item types.</summary>
		CurrentPropertyReference = 19,
		/// <summary>For PropertyRelationship current item types.</summary>
		CurrentPropertyRelationship = 20,
		/// <summary>For Relationship current item types.</summary>
		CurrentRelationship = 21,
		/// <summary>For RelationshipProperty current item types.</summary>
		CurrentRelationshipProperty = 22,
		/// <summary>For Stage current item types.</summary>
		CurrentStage = 23,
		/// <summary>For StageTransition current item types.</summary>
		CurrentStageTransition = 24,
		/// <summary>For State current item types.</summary>
		CurrentState = 25,
		/// <summary>For StateModel current item types.</summary>
		CurrentStateModel = 26,
		/// <summary>For StateTransition current item types.</summary>
		CurrentStateTransition = 27,
		/// <summary>For Step current item types.</summary>
		CurrentStep = 28,
		/// <summary>For StepTransition current item types.</summary>
		CurrentStepTransition = 29,
		/// <summary>For Value current item types.</summary>
		CurrentValue = 30,
		/// <summary>For View current item types.</summary>
		CurrentView = 31,
		/// <summary>For ViewProperty current item types.</summary>
		CurrentViewProperty = 32,
		/// <summary>For Workflow current item types.</summary>
		CurrentWorkflow = 33,

		#region protected
		#endregion protected
	}
}
