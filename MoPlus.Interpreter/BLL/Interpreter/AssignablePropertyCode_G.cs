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
	/// assignable properties.</summary>
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
	public enum AssignablePropertyCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For BaseEntityID assignable property.</summary>
		BaseEntityID = 1,
		/// <summary>For CollectionName assignable property.</summary>
		CollectionName = 2,
		/// <summary>For CompanyName assignable property.</summary>
		CompanyName = 3,
		/// <summary>For Copyright assignable property.</summary>
		Copyright = 4,
		/// <summary>For DataTypeCode assignable property.</summary>
		DataTypeCode = 5,
		/// <summary>For DbName assignable property.</summary>
		DbName = 6,
		/// <summary>For DbServerName assignable property.</summary>
		DbServerName = 7,
		/// <summary>For DefinedByEnumerationID assignable property.</summary>
		DefinedByEnumerationID = 8,
		/// <summary>For DefinedByModelObjectID assignable property.</summary>
		DefinedByModelObjectID = 9,
		/// <summary>For DefinedByValueID assignable property.</summary>
		DefinedByValueID = 10,
		/// <summary>For Description assignable property.</summary>
		Description = 11,
		/// <summary>For EntityID assignable property.</summary>
		EntityID = 12,
		/// <summary>For EntityName assignable property.</summary>
		EntityName = 13,
		/// <summary>For EntityReferenceName assignable property.</summary>
		EntityReferenceName = 14,
		/// <summary>For EntityTypeCode assignable property.</summary>
		EntityTypeCode = 15,
		/// <summary>For EnumerationID assignable property.</summary>
		EnumerationID = 16,
		/// <summary>For EnumerationName assignable property.</summary>
		EnumerationName = 17,
		/// <summary>For EnumValue assignable property.</summary>
		EnumValue = 18,
		/// <summary>For FeatureID assignable property.</summary>
		FeatureID = 19,
		/// <summary>For FeatureName assignable property.</summary>
		FeatureName = 20,
		/// <summary>For FromStageID assignable property.</summary>
		FromStageID = 21,
		/// <summary>For FromStateID assignable property.</summary>
		FromStateID = 22,
		/// <summary>For FromStepID assignable property.</summary>
		FromStepID = 23,
		/// <summary>For IdentifierTypeCode assignable property.</summary>
		IdentifierTypeCode = 24,
		/// <summary>For Identity assignable property.</summary>
		Identity = 25,
		/// <summary>For IdentityIncrement assignable property.</summary>
		IdentityIncrement = 26,
		/// <summary>For IdentitySeed assignable property.</summary>
		IdentitySeed = 27,
		/// <summary>For IndexID assignable property.</summary>
		IndexID = 28,
		/// <summary>For IndexName assignable property.</summary>
		IndexName = 29,
		/// <summary>For IndexPropertyID assignable property.</summary>
		IndexPropertyID = 30,
		/// <summary>For InitialValue assignable property.</summary>
		InitialValue = 31,
		/// <summary>For IsAddAuditProperty assignable property.</summary>
		IsAddAuditProperty = 32,
		/// <summary>For IsCollection assignable property.</summary>
		IsCollection = 33,
		/// <summary>For IsDisplayProperty assignable property.</summary>
		IsDisplayProperty = 34,
		/// <summary>For IsForeignKeyMember assignable property.</summary>
		IsForeignKeyMember = 35,
		/// <summary>For IsNullable assignable property.</summary>
		IsNullable = 36,
		/// <summary>For IsPrimaryKeyIndex assignable property.</summary>
		IsPrimaryKeyIndex = 37,
		/// <summary>For IsPrimaryKeyMember assignable property.</summary>
		IsPrimaryKeyMember = 38,
		/// <summary>For IsUniqueIndex assignable property.</summary>
		IsUniqueIndex = 39,
		/// <summary>For IsUpdateAuditProperty assignable property.</summary>
		IsUpdateAuditProperty = 40,
		/// <summary>For IsValueGenerated assignable property.</summary>
		IsValueGenerated = 41,
		/// <summary>For ItemsMax assignable property.</summary>
		ItemsMax = 42,
		/// <summary>For ItemsMin assignable property.</summary>
		ItemsMin = 43,
		/// <summary>For Length assignable property.</summary>
		Length = 44,
		/// <summary>For MethodID assignable property.</summary>
		MethodID = 45,
		/// <summary>For MethodName assignable property.</summary>
		MethodName = 46,
		/// <summary>For MethodRelationshipID assignable property.</summary>
		MethodRelationshipID = 47,
		/// <summary>For MethodTypeCode assignable property.</summary>
		MethodTypeCode = 48,
		/// <summary>For ModelID assignable property.</summary>
		ModelID = 49,
		/// <summary>For ModelName assignable property.</summary>
		ModelName = 50,
		/// <summary>For ModelObjectID assignable property.</summary>
		ModelObjectID = 51,
		/// <summary>For ModelObjectName assignable property.</summary>
		ModelObjectName = 52,
		/// <summary>For ModelPropertyID assignable property.</summary>
		ModelPropertyID = 53,
		/// <summary>For ModelPropertyName assignable property.</summary>
		ModelPropertyName = 54,
		/// <summary>For Namespace assignable property.</summary>
		Namespace = 55,
		/// <summary>For ObjectInstanceID assignable property.</summary>
		ObjectInstanceID = 56,
		/// <summary>For Order assignable property.</summary>
		Order = 57,
		/// <summary>For OutputSolutionFileName assignable property.</summary>
		OutputSolutionFileName = 58,
		/// <summary>For ParameterID assignable property.</summary>
		ParameterID = 59,
		/// <summary>For ParameterName assignable property.</summary>
		ParameterName = 60,
		/// <summary>For ParentModelObjectID assignable property.</summary>
		ParentModelObjectID = 61,
		/// <summary>For ParentObjectInstanceID assignable property.</summary>
		ParentObjectInstanceID = 62,
		/// <summary>For Precision assignable property.</summary>
		Precision = 63,
		/// <summary>For ProductName assignable property.</summary>
		ProductName = 64,
		/// <summary>For ProductVersion assignable property.</summary>
		ProductVersion = 65,
		/// <summary>For ProjectID assignable property.</summary>
		ProjectID = 66,
		/// <summary>For ProjectName assignable property.</summary>
		ProjectName = 67,
		/// <summary>For PropertyID assignable property.</summary>
		PropertyID = 68,
		/// <summary>For PropertyInstanceID assignable property.</summary>
		PropertyInstanceID = 69,
		/// <summary>For PropertyName assignable property.</summary>
		PropertyName = 70,
		/// <summary>For PropertyReferenceName assignable property.</summary>
		PropertyReferenceName = 71,
		/// <summary>For PropertyRelationshipID assignable property.</summary>
		PropertyRelationshipID = 72,
		/// <summary>For PropertyValue assignable property.</summary>
		PropertyValue = 73,
		/// <summary>For ReferencedEntityID assignable property.</summary>
		ReferencedEntityID = 74,
		/// <summary>For ReferencedItemsMax assignable property.</summary>
		ReferencedItemsMax = 75,
		/// <summary>For ReferencedItemsMin assignable property.</summary>
		ReferencedItemsMin = 76,
		/// <summary>For ReferencedProjectID assignable property.</summary>
		ReferencedProjectID = 77,
		/// <summary>For ReferencedPropertyID assignable property.</summary>
		ReferencedPropertyID = 78,
		/// <summary>For RelationshipID assignable property.</summary>
		RelationshipID = 79,
		/// <summary>For RelationshipName assignable property.</summary>
		RelationshipName = 80,
		/// <summary>For RelationshipPropertyID assignable property.</summary>
		RelationshipPropertyID = 81,
		/// <summary>For Scale assignable property.</summary>
		Scale = 82,
		/// <summary>For SolutionID assignable property.</summary>
		SolutionID = 83,
		/// <summary>For SolutionName assignable property.</summary>
		SolutionName = 84,
		/// <summary>For SpecificationDirectory assignable property.</summary>
		SpecificationDirectory = 85,
		/// <summary>For StageID assignable property.</summary>
		StageID = 86,
		/// <summary>For StageName assignable property.</summary>
		StageName = 87,
		/// <summary>For StageTransitionID assignable property.</summary>
		StageTransitionID = 88,
		/// <summary>For StageTransitionName assignable property.</summary>
		StageTransitionName = 89,
		/// <summary>For StateID assignable property.</summary>
		StateID = 90,
		/// <summary>For StateModelID assignable property.</summary>
		StateModelID = 91,
		/// <summary>For StateModelName assignable property.</summary>
		StateModelName = 92,
		/// <summary>For StateName assignable property.</summary>
		StateName = 93,
		/// <summary>For StateTransitionID assignable property.</summary>
		StateTransitionID = 94,
		/// <summary>For StateTransitionName assignable property.</summary>
		StateTransitionName = 95,
		/// <summary>For StepID assignable property.</summary>
		StepID = 96,
		/// <summary>For StepName assignable property.</summary>
		StepName = 97,
		/// <summary>For StepTransitionID assignable property.</summary>
		StepTransitionID = 98,
		/// <summary>For StepTransitionName assignable property.</summary>
		StepTransitionName = 99,
		/// <summary>For TemplateID assignable property.</summary>
		TemplateID = 100,
		/// <summary>For TemplatePath assignable property.</summary>
		TemplatePath = 101,
		/// <summary>For ToStageID assignable property.</summary>
		ToStageID = 102,
		/// <summary>For ToStateID assignable property.</summary>
		ToStateID = 103,
		/// <summary>For ToStepID assignable property.</summary>
		ToStepID = 104,
		/// <summary>For ValueID assignable property.</summary>
		ValueID = 105,
		/// <summary>For ValueName assignable property.</summary>
		ValueName = 106,
		/// <summary>For WorkflowID assignable property.</summary>
		WorkflowID = 107,
		/// <summary>For WorkflowName assignable property.</summary>
		WorkflowName = 108,

		#region protected
		/// <summary>For SourceName assignable property.</summary>
		SourceName = 501,
		/// <summary>For Tags assignable property.</summary>
		Tags = 502,
		#endregion protected
	}
}
