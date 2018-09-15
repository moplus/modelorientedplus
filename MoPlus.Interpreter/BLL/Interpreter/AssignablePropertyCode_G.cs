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
	/// <CreatedDate>9/15/2018</CreatedDate>
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
		/// <summary>For GroupName assignable property.</summary>
		GroupName = 24,
		/// <summary>For IdentifierTypeCode assignable property.</summary>
		IdentifierTypeCode = 25,
		/// <summary>For Identity assignable property.</summary>
		Identity = 26,
		/// <summary>For IdentityIncrement assignable property.</summary>
		IdentityIncrement = 27,
		/// <summary>For IdentitySeed assignable property.</summary>
		IdentitySeed = 28,
		/// <summary>For IndexID assignable property.</summary>
		IndexID = 29,
		/// <summary>For IndexName assignable property.</summary>
		IndexName = 30,
		/// <summary>For IndexPropertyID assignable property.</summary>
		IndexPropertyID = 31,
		/// <summary>For InitialValue assignable property.</summary>
		InitialValue = 32,
		/// <summary>For IsAddAuditProperty assignable property.</summary>
		IsAddAuditProperty = 33,
		/// <summary>For IsCollection assignable property.</summary>
		IsCollection = 34,
		/// <summary>For IsDisplayProperty assignable property.</summary>
		IsDisplayProperty = 35,
		/// <summary>For IsForeignKeyMember assignable property.</summary>
		IsForeignKeyMember = 36,
		/// <summary>For IsNullable assignable property.</summary>
		IsNullable = 37,
		/// <summary>For IsPrimaryKeyIndex assignable property.</summary>
		IsPrimaryKeyIndex = 38,
		/// <summary>For IsPrimaryKeyMember assignable property.</summary>
		IsPrimaryKeyMember = 39,
		/// <summary>For IsUniqueIndex assignable property.</summary>
		IsUniqueIndex = 40,
		/// <summary>For IsUpdateAuditProperty assignable property.</summary>
		IsUpdateAuditProperty = 41,
		/// <summary>For IsValueGenerated assignable property.</summary>
		IsValueGenerated = 42,
		/// <summary>For ItemsMax assignable property.</summary>
		ItemsMax = 43,
		/// <summary>For ItemsMin assignable property.</summary>
		ItemsMin = 44,
		/// <summary>For Length assignable property.</summary>
		Length = 45,
		/// <summary>For MethodID assignable property.</summary>
		MethodID = 46,
		/// <summary>For MethodName assignable property.</summary>
		MethodName = 47,
		/// <summary>For MethodRelationshipID assignable property.</summary>
		MethodRelationshipID = 48,
		/// <summary>For MethodTypeCode assignable property.</summary>
		MethodTypeCode = 49,
		/// <summary>For MinLength assignable property.</summary>
		MinLength = 50,
		/// <summary>For ModelID assignable property.</summary>
		ModelID = 51,
		/// <summary>For ModelName assignable property.</summary>
		ModelName = 52,
		/// <summary>For ModelObjectID assignable property.</summary>
		ModelObjectID = 53,
		/// <summary>For ModelObjectName assignable property.</summary>
		ModelObjectName = 54,
		/// <summary>For ModelPropertyID assignable property.</summary>
		ModelPropertyID = 55,
		/// <summary>For ModelPropertyName assignable property.</summary>
		ModelPropertyName = 56,
		/// <summary>For Namespace assignable property.</summary>
		Namespace = 57,
		/// <summary>For ObjectInstanceID assignable property.</summary>
		ObjectInstanceID = 58,
		/// <summary>For Order assignable property.</summary>
		Order = 59,
		/// <summary>For OutputSolutionFileName assignable property.</summary>
		OutputSolutionFileName = 60,
		/// <summary>For ParameterID assignable property.</summary>
		ParameterID = 61,
		/// <summary>For ParameterName assignable property.</summary>
		ParameterName = 62,
		/// <summary>For ParentModelObjectID assignable property.</summary>
		ParentModelObjectID = 63,
		/// <summary>For ParentObjectInstanceID assignable property.</summary>
		ParentObjectInstanceID = 64,
		/// <summary>For Precision assignable property.</summary>
		Precision = 65,
		/// <summary>For ProductName assignable property.</summary>
		ProductName = 66,
		/// <summary>For ProductVersion assignable property.</summary>
		ProductVersion = 67,
		/// <summary>For ProjectID assignable property.</summary>
		ProjectID = 68,
		/// <summary>For ProjectName assignable property.</summary>
		ProjectName = 69,
		/// <summary>For PropertyID assignable property.</summary>
		PropertyID = 70,
		/// <summary>For PropertyInstanceID assignable property.</summary>
		PropertyInstanceID = 71,
		/// <summary>For PropertyName assignable property.</summary>
		PropertyName = 72,
		/// <summary>For PropertyReferenceName assignable property.</summary>
		PropertyReferenceName = 73,
		/// <summary>For PropertyRelationshipID assignable property.</summary>
		PropertyRelationshipID = 74,
		/// <summary>For PropertyValue assignable property.</summary>
		PropertyValue = 75,
		/// <summary>For ReferencedEntityID assignable property.</summary>
		ReferencedEntityID = 76,
		/// <summary>For ReferencedItemsMax assignable property.</summary>
		ReferencedItemsMax = 77,
		/// <summary>For ReferencedItemsMin assignable property.</summary>
		ReferencedItemsMin = 78,
		/// <summary>For ReferencedProjectID assignable property.</summary>
		ReferencedProjectID = 79,
		/// <summary>For ReferencedPropertyID assignable property.</summary>
		ReferencedPropertyID = 80,
		/// <summary>For RelationshipID assignable property.</summary>
		RelationshipID = 81,
		/// <summary>For RelationshipName assignable property.</summary>
		RelationshipName = 82,
		/// <summary>For RelationshipPropertyID assignable property.</summary>
		RelationshipPropertyID = 83,
		/// <summary>For Scale assignable property.</summary>
		Scale = 84,
		/// <summary>For SolutionID assignable property.</summary>
		SolutionID = 85,
		/// <summary>For SolutionName assignable property.</summary>
		SolutionName = 86,
		/// <summary>For SpecificationDirectory assignable property.</summary>
		SpecificationDirectory = 87,
		/// <summary>For StageID assignable property.</summary>
		StageID = 88,
		/// <summary>For StageName assignable property.</summary>
		StageName = 89,
		/// <summary>For StageTransitionID assignable property.</summary>
		StageTransitionID = 90,
		/// <summary>For StageTransitionName assignable property.</summary>
		StageTransitionName = 91,
		/// <summary>For StateID assignable property.</summary>
		StateID = 92,
		/// <summary>For StateModelID assignable property.</summary>
		StateModelID = 93,
		/// <summary>For StateModelName assignable property.</summary>
		StateModelName = 94,
		/// <summary>For StateName assignable property.</summary>
		StateName = 95,
		/// <summary>For StateTransitionID assignable property.</summary>
		StateTransitionID = 96,
		/// <summary>For StateTransitionName assignable property.</summary>
		StateTransitionName = 97,
		/// <summary>For StepID assignable property.</summary>
		StepID = 98,
		/// <summary>For StepName assignable property.</summary>
		StepName = 99,
		/// <summary>For StepTransitionID assignable property.</summary>
		StepTransitionID = 100,
		/// <summary>For StepTransitionName assignable property.</summary>
		StepTransitionName = 101,
		/// <summary>For TemplateID assignable property.</summary>
		TemplateID = 102,
		/// <summary>For TemplatePath assignable property.</summary>
		TemplatePath = 103,
		/// <summary>For ToStageID assignable property.</summary>
		ToStageID = 104,
		/// <summary>For ToStateID assignable property.</summary>
		ToStateID = 105,
		/// <summary>For ToStepID assignable property.</summary>
		ToStepID = 106,
		/// <summary>For UseRelativePaths assignable property.</summary>
		UseRelativePaths = 107,
		/// <summary>For ValueConstraint assignable property.</summary>
		ValueConstraint = 108,
		/// <summary>For ValueID assignable property.</summary>
		ValueID = 109,
		/// <summary>For ValueName assignable property.</summary>
		ValueName = 110,
		/// <summary>For ViewID assignable property.</summary>
		ViewID = 111,
		/// <summary>For ViewName assignable property.</summary>
		ViewName = 112,
		/// <summary>For ViewPropertyID assignable property.</summary>
		ViewPropertyID = 113,
		/// <summary>For WorkflowID assignable property.</summary>
		WorkflowID = 114,
		/// <summary>For WorkflowName assignable property.</summary>
		WorkflowName = 115,

		#region protected
		/// <summary>For SourceName assignable property.</summary>
		SourceName = 501,
		/// <summary>For Tags assignable property.</summary>
		Tags = 502,
		#endregion protected
	}
}
