/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;
using Irony.Interpreter.Ast;
using MoPlus.Data;
using System.Collections;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of current item nodes.</summary>
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
	public partial class CurrentItemNode : LeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the model context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentAuditProperty))
			{
				modelContext = solutionContext.CurrentAuditProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentCollection))
			{
				modelContext = solutionContext.CurrentCollection;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntity))
			{
				modelContext = solutionContext.CurrentEntity;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntityReference))
			{
				modelContext = solutionContext.CurrentEntityReference;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEnumeration))
			{
				modelContext = solutionContext.CurrentEnumeration;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentFeature))
			{
				modelContext = solutionContext.CurrentFeature;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndex))
			{
				modelContext = solutionContext.CurrentIndex;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndexProperty))
			{
				modelContext = solutionContext.CurrentIndexProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethod))
			{
				modelContext = solutionContext.CurrentMethod;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethodRelationship))
			{
				modelContext = solutionContext.CurrentMethodRelationship;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModel))
			{
				modelContext = solutionContext.CurrentModel;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelObject))
			{
				modelContext = solutionContext.CurrentModelObject;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelProperty))
			{
				modelContext = solutionContext.CurrentModelProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentObjectInstance))
			{
				modelContext = solutionContext.CurrentObjectInstance;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentParameter))
			{
				modelContext = solutionContext.CurrentParameter;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProject))
			{
				modelContext = solutionContext.CurrentProject;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProperty))
			{
				modelContext = solutionContext.CurrentProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyInstance))
			{
				modelContext = solutionContext.CurrentPropertyInstance;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyReference))
			{
				modelContext = solutionContext.CurrentPropertyReference;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyRelationship))
			{
				modelContext = solutionContext.CurrentPropertyRelationship;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationship))
			{
				modelContext = solutionContext.CurrentRelationship;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationshipProperty))
			{
				modelContext = solutionContext.CurrentRelationshipProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStage))
			{
				modelContext = solutionContext.CurrentStage;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStageTransition))
			{
				modelContext = solutionContext.CurrentStageTransition;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentState))
			{
				modelContext = solutionContext.CurrentState;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateModel))
			{
				modelContext = solutionContext.CurrentStateModel;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateTransition))
			{
				modelContext = solutionContext.CurrentStateTransition;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStep))
			{
				modelContext = solutionContext.CurrentStep;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStepTransition))
			{
				modelContext = solutionContext.CurrentStepTransition;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentValue))
			{
				modelContext = solutionContext.CurrentValue;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentView))
			{
				modelContext = solutionContext.CurrentView;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentViewProperty))
			{
				modelContext = solutionContext.CurrentViewProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentWorkflow))
			{
				modelContext = solutionContext.CurrentWorkflow;
			}
			#region protected
			#endregion protected
			else if (solutionContext.ModelObjectNames.AllKeys.Contains(CurrentItemName.Substring(7)) == true)
			{
				return solutionContext.CurrentModelObject;
			}
			return modelContext;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public IEnterpriseEnumerable GetCollection(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentAuditProperty))
			{
				return AuditProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentCollection))
			{
				return Collection.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntity))
			{
				return Entity.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntityReference))
			{
				return EntityReference.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEnumeration))
			{
				return Enumeration.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentFeature))
			{
				return Feature.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndex))
			{
				return Index.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndexProperty))
			{
				return IndexProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethod))
			{
				return Method.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethodRelationship))
			{
				return MethodRelationship.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModel))
			{
				return Model.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelObject))
			{
				return ModelObject.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelProperty))
			{
				return ModelProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentObjectInstance))
			{
				return ObjectInstance.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentParameter))
			{
				return Parameter.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProject))
			{
				return Project.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProperty))
			{
				return Property.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyInstance))
			{
				return PropertyInstance.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyReference))
			{
				return PropertyReference.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyRelationship))
			{
				return PropertyRelationship.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationship))
			{
				return Relationship.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationshipProperty))
			{
				return RelationshipProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStage))
			{
				return Stage.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStageTransition))
			{
				return StageTransition.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentState))
			{
				return State.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateModel))
			{
				return StateModel.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateTransition))
			{
				return StateTransition.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStep))
			{
				return Step.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStepTransition))
			{
				return StepTransition.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentValue))
			{
				return Value.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentView))
			{
				return View.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentViewProperty))
			{
				return ViewProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentWorkflow))
			{
				return Workflow.GetCollectionContext(solutionContext, nodeContext);
			}
			#region protected
			#endregion protected
			else if (solutionContext.ModelObjectNames.AllKeys.Contains(CurrentItemName.Substring(7)) == true)
			{
				return ObjectInstance.GetCollectionContext(solutionContext, CurrentItemName.Substring(7), nodeContext);
			}
			return null;
		}
	}
}
