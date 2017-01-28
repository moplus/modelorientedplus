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
using MoPlus.Interpreter.Resources;
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
	/// <summary>This class implements necessary members for interpretation of current item assignment statements.</summary>
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
	public partial class CurrentItemAssignmentStatementNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public void InterpretNode(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			try
			{
				if (ModelContext != null || !String.IsNullOrEmpty(NewItem) || !String.IsNullOrEmpty(NullItem))
				{
					IDomainEnterpriseObject currentContext = null;
					if (ModelContext != null)
					{
						bool isValidContext;
						currentContext = ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
					}
					if (CurrentItem != null)
					{
						if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentAuditProperty))
						{
							if (currentContext is AuditProperty)
							{
								solutionContext.CurrentAuditProperty = currentContext as AuditProperty;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentAuditProperty = new AuditProperty();
								solutionContext.CurrentAuditProperty.PropertyID = Guid.NewGuid();
								solutionContext.CurrentAuditProperty.IsAutoUpdated = true;
								solutionContext.CurrentAuditProperty.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentAuditProperty = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentCollection))
						{
							if (currentContext is Collection)
							{
								solutionContext.CurrentCollection = currentContext as Collection;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentCollection = new Collection();
								solutionContext.CurrentCollection.PropertyID = Guid.NewGuid();
								solutionContext.CurrentCollection.IsAutoUpdated = true;
								solutionContext.CurrentCollection.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentCollection = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntity))
						{
							if (currentContext is Entity)
							{
								solutionContext.CurrentEntity = currentContext as Entity;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentEntity = new Entity();
								solutionContext.CurrentEntity.EntityID = Guid.NewGuid();
								solutionContext.CurrentEntity.IsAutoUpdated = true;
								solutionContext.CurrentEntity.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentEntity = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntityReference))
						{
							if (currentContext is EntityReference)
							{
								solutionContext.CurrentEntityReference = currentContext as EntityReference;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentEntityReference = new EntityReference();
								solutionContext.CurrentEntityReference.PropertyID = Guid.NewGuid();
								solutionContext.CurrentEntityReference.IsAutoUpdated = true;
								solutionContext.CurrentEntityReference.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentEntityReference = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEnumeration))
						{
							if (currentContext is Enumeration)
							{
								solutionContext.CurrentEnumeration = currentContext as Enumeration;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentEnumeration = new Enumeration();
								solutionContext.CurrentEnumeration.EnumerationID = Guid.NewGuid();
								solutionContext.CurrentEnumeration.IsAutoUpdated = true;
								solutionContext.CurrentEnumeration.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentEnumeration = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentFeature))
						{
							if (currentContext is Feature)
							{
								solutionContext.CurrentFeature = currentContext as Feature;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentFeature = new Feature();
								solutionContext.CurrentFeature.FeatureID = Guid.NewGuid();
								solutionContext.CurrentFeature.IsAutoUpdated = true;
								solutionContext.CurrentFeature.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentFeature = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndex))
						{
							if (currentContext is Index)
							{
								solutionContext.CurrentIndex = currentContext as Index;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentIndex = new Index();
								solutionContext.CurrentIndex.IndexID = Guid.NewGuid();
								solutionContext.CurrentIndex.IsAutoUpdated = true;
								solutionContext.CurrentIndex.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentIndex = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndexProperty))
						{
							if (currentContext is IndexProperty)
							{
								solutionContext.CurrentIndexProperty = currentContext as IndexProperty;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentIndexProperty = new IndexProperty();
								solutionContext.CurrentIndexProperty.IndexPropertyID = Guid.NewGuid();
								solutionContext.CurrentIndexProperty.IsAutoUpdated = true;
								solutionContext.CurrentIndexProperty.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentIndexProperty = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethod))
						{
							if (currentContext is Method)
							{
								solutionContext.CurrentMethod = currentContext as Method;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentMethod = new Method();
								solutionContext.CurrentMethod.MethodID = Guid.NewGuid();
								solutionContext.CurrentMethod.IsAutoUpdated = true;
								solutionContext.CurrentMethod.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentMethod = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethodRelationship))
						{
							if (currentContext is MethodRelationship)
							{
								solutionContext.CurrentMethodRelationship = currentContext as MethodRelationship;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentMethodRelationship = new MethodRelationship();
								solutionContext.CurrentMethodRelationship.MethodRelationshipID = Guid.NewGuid();
								solutionContext.CurrentMethodRelationship.IsAutoUpdated = true;
								solutionContext.CurrentMethodRelationship.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentMethodRelationship = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModel))
						{
							if (currentContext is Model)
							{
								solutionContext.CurrentModel = currentContext as Model;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentModel = new Model();
								solutionContext.CurrentModel.ModelID = Guid.NewGuid();
								solutionContext.CurrentModel.IsAutoUpdated = true;
								solutionContext.CurrentModel.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentModel = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelObject))
						{
							if (currentContext is ModelObject)
							{
								solutionContext.CurrentModelObject = currentContext as ModelObject;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentModelObject = new ModelObject();
								solutionContext.CurrentModelObject.ModelObjectID = Guid.NewGuid();
								solutionContext.CurrentModelObject.IsAutoUpdated = true;
								solutionContext.CurrentModelObject.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentModelObject = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelProperty))
						{
							if (currentContext is ModelProperty)
							{
								solutionContext.CurrentModelProperty = currentContext as ModelProperty;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentModelProperty = new ModelProperty();
								solutionContext.CurrentModelProperty.ModelPropertyID = Guid.NewGuid();
								solutionContext.CurrentModelProperty.IsAutoUpdated = true;
								solutionContext.CurrentModelProperty.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentModelProperty = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentObjectInstance))
						{
							if (currentContext is ObjectInstance)
							{
								solutionContext.CurrentObjectInstance = currentContext as ObjectInstance;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentObjectInstance = new ObjectInstance();
								solutionContext.CurrentObjectInstance.ObjectInstanceID = Guid.NewGuid();
								solutionContext.CurrentObjectInstance.IsAutoUpdated = true;
								solutionContext.CurrentObjectInstance.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentObjectInstance = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentParameter))
						{
							if (currentContext is Parameter)
							{
								solutionContext.CurrentParameter = currentContext as Parameter;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentParameter = new Parameter();
								solutionContext.CurrentParameter.ParameterID = Guid.NewGuid();
								solutionContext.CurrentParameter.IsAutoUpdated = true;
								solutionContext.CurrentParameter.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentParameter = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProject))
						{
							if (currentContext is Project)
							{
								solutionContext.CurrentProject = currentContext as Project;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentProject = new Project();
								solutionContext.CurrentProject.ProjectID = Guid.NewGuid();
								solutionContext.CurrentProject.IsAutoUpdated = true;
								solutionContext.CurrentProject.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentProject = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProperty))
						{
							if (currentContext is Property)
							{
								solutionContext.CurrentProperty = currentContext as Property;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentProperty = new Property();
								solutionContext.CurrentProperty.PropertyID = Guid.NewGuid();
								solutionContext.CurrentProperty.IsAutoUpdated = true;
								solutionContext.CurrentProperty.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentProperty = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyInstance))
						{
							if (currentContext is PropertyInstance)
							{
								solutionContext.CurrentPropertyInstance = currentContext as PropertyInstance;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentPropertyInstance = new PropertyInstance();
								solutionContext.CurrentPropertyInstance.PropertyInstanceID = Guid.NewGuid();
								solutionContext.CurrentPropertyInstance.IsAutoUpdated = true;
								solutionContext.CurrentPropertyInstance.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentPropertyInstance = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyReference))
						{
							if (currentContext is PropertyReference)
							{
								solutionContext.CurrentPropertyReference = currentContext as PropertyReference;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentPropertyReference = new PropertyReference();
								solutionContext.CurrentPropertyReference.PropertyID = Guid.NewGuid();
								solutionContext.CurrentPropertyReference.IsAutoUpdated = true;
								solutionContext.CurrentPropertyReference.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentPropertyReference = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyRelationship))
						{
							if (currentContext is PropertyRelationship)
							{
								solutionContext.CurrentPropertyRelationship = currentContext as PropertyRelationship;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentPropertyRelationship = new PropertyRelationship();
								solutionContext.CurrentPropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
								solutionContext.CurrentPropertyRelationship.IsAutoUpdated = true;
								solutionContext.CurrentPropertyRelationship.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentPropertyRelationship = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationship))
						{
							if (currentContext is Relationship)
							{
								solutionContext.CurrentRelationship = currentContext as Relationship;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentRelationship = new Relationship();
								solutionContext.CurrentRelationship.RelationshipID = Guid.NewGuid();
								solutionContext.CurrentRelationship.IsAutoUpdated = true;
								solutionContext.CurrentRelationship.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentRelationship = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationshipProperty))
						{
							if (currentContext is RelationshipProperty)
							{
								solutionContext.CurrentRelationshipProperty = currentContext as RelationshipProperty;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentRelationshipProperty = new RelationshipProperty();
								solutionContext.CurrentRelationshipProperty.RelationshipPropertyID = Guid.NewGuid();
								solutionContext.CurrentRelationshipProperty.IsAutoUpdated = true;
								solutionContext.CurrentRelationshipProperty.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentRelationshipProperty = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStage))
						{
							if (currentContext is Stage)
							{
								solutionContext.CurrentStage = currentContext as Stage;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentStage = new Stage();
								solutionContext.CurrentStage.StageID = Guid.NewGuid();
								solutionContext.CurrentStage.IsAutoUpdated = true;
								solutionContext.CurrentStage.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentStage = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStageTransition))
						{
							if (currentContext is StageTransition)
							{
								solutionContext.CurrentStageTransition = currentContext as StageTransition;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentStageTransition = new StageTransition();
								solutionContext.CurrentStageTransition.StageTransitionID = Guid.NewGuid();
								solutionContext.CurrentStageTransition.IsAutoUpdated = true;
								solutionContext.CurrentStageTransition.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentStageTransition = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentState))
						{
							if (currentContext is State)
							{
								solutionContext.CurrentState = currentContext as State;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentState = new State();
								solutionContext.CurrentState.StateID = Guid.NewGuid();
								solutionContext.CurrentState.IsAutoUpdated = true;
								solutionContext.CurrentState.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentState = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateModel))
						{
							if (currentContext is StateModel)
							{
								solutionContext.CurrentStateModel = currentContext as StateModel;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentStateModel = new StateModel();
								solutionContext.CurrentStateModel.StateModelID = Guid.NewGuid();
								solutionContext.CurrentStateModel.IsAutoUpdated = true;
								solutionContext.CurrentStateModel.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentStateModel = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateTransition))
						{
							if (currentContext is StateTransition)
							{
								solutionContext.CurrentStateTransition = currentContext as StateTransition;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentStateTransition = new StateTransition();
								solutionContext.CurrentStateTransition.StateTransitionID = Guid.NewGuid();
								solutionContext.CurrentStateTransition.IsAutoUpdated = true;
								solutionContext.CurrentStateTransition.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentStateTransition = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStep))
						{
							if (currentContext is Step)
							{
								solutionContext.CurrentStep = currentContext as Step;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentStep = new Step();
								solutionContext.CurrentStep.StepID = Guid.NewGuid();
								solutionContext.CurrentStep.IsAutoUpdated = true;
								solutionContext.CurrentStep.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentStep = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStepTransition))
						{
							if (currentContext is StepTransition)
							{
								solutionContext.CurrentStepTransition = currentContext as StepTransition;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentStepTransition = new StepTransition();
								solutionContext.CurrentStepTransition.StepTransitionID = Guid.NewGuid();
								solutionContext.CurrentStepTransition.IsAutoUpdated = true;
								solutionContext.CurrentStepTransition.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentStepTransition = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentValue))
						{
							if (currentContext is Value)
							{
								solutionContext.CurrentValue = currentContext as Value;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentValue = new Value();
								solutionContext.CurrentValue.ValueID = Guid.NewGuid();
								solutionContext.CurrentValue.IsAutoUpdated = true;
								solutionContext.CurrentValue.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentValue = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentView))
						{
							if (currentContext is View)
							{
								solutionContext.CurrentView = currentContext as View;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentView = new View();
								solutionContext.CurrentView.ViewID = Guid.NewGuid();
								solutionContext.CurrentView.IsAutoUpdated = true;
								solutionContext.CurrentView.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentView = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentViewProperty))
						{
							if (currentContext is ViewProperty)
							{
								solutionContext.CurrentViewProperty = currentContext as ViewProperty;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentViewProperty = new ViewProperty();
								solutionContext.CurrentViewProperty.ViewPropertyID = Guid.NewGuid();
								solutionContext.CurrentViewProperty.IsAutoUpdated = true;
								solutionContext.CurrentViewProperty.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentViewProperty = null;
							}
						}
						else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentWorkflow))
						{
							if (currentContext is Workflow)
							{
								solutionContext.CurrentWorkflow = currentContext as Workflow;
							}
							else if (!String.IsNullOrEmpty(NewItem))
							{
								solutionContext.CurrentWorkflow = new Workflow();
								solutionContext.CurrentWorkflow.WorkflowID = Guid.NewGuid();
								solutionContext.CurrentWorkflow.IsAutoUpdated = true;
								solutionContext.CurrentWorkflow.Solution = solutionContext;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentWorkflow = null;
							}
						}
						#region protected
						#endregion protected
					}
					else if (SpecCurrentItem != null)
					{
						if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlColumn))
						{
							if (currentContext is SqlColumn)
							{
								solutionContext.CurrentSqlColumn = currentContext as SqlColumn;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlColumn = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlDatabase))
						{
							if (currentContext is SqlDatabase)
							{
								solutionContext.CurrentSqlDatabase = currentContext as SqlDatabase;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlDatabase = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlExtendedProperty))
						{
							if (currentContext is SqlExtendedProperty)
							{
								solutionContext.CurrentSqlExtendedProperty = currentContext as SqlExtendedProperty;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlExtendedProperty = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKey))
						{
							if (currentContext is SqlForeignKey)
							{
								solutionContext.CurrentSqlForeignKey = currentContext as SqlForeignKey;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlForeignKey = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKeyColumn))
						{
							if (currentContext is SqlForeignKeyColumn)
							{
								solutionContext.CurrentSqlForeignKeyColumn = currentContext as SqlForeignKeyColumn;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlForeignKeyColumn = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndex))
						{
							if (currentContext is SqlIndex)
							{
								solutionContext.CurrentSqlIndex = currentContext as SqlIndex;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlIndex = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndexedColumn))
						{
							if (currentContext is SqlIndexedColumn)
							{
								solutionContext.CurrentSqlIndexedColumn = currentContext as SqlIndexedColumn;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlIndexedColumn = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlProperty))
						{
							if (currentContext is SqlProperty)
							{
								solutionContext.CurrentSqlProperty = currentContext as SqlProperty;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlProperty = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlTable))
						{
							if (currentContext is SqlTable)
							{
								solutionContext.CurrentSqlTable = currentContext as SqlTable;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlTable = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlView))
						{
							if (currentContext is SqlView)
							{
								solutionContext.CurrentSqlView = currentContext as SqlView;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlView = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlViewProperty))
						{
							if (currentContext is SqlViewProperty)
							{
								solutionContext.CurrentSqlViewProperty = currentContext as SqlViewProperty;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentSqlViewProperty = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlAttribute))
						{
							if (currentContext is XmlAttribute)
							{
								solutionContext.CurrentXmlAttribute = currentContext as XmlAttribute;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentXmlAttribute = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlDocument))
						{
							if (currentContext is XmlDocument)
							{
								solutionContext.CurrentXmlDocument = currentContext as XmlDocument;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentXmlDocument = null;
							}
						}
						else if (SpecCurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlNode))
						{
							if (currentContext is XmlNode)
							{
								solutionContext.CurrentXmlNode = currentContext as XmlNode;
							}
							else if (!String.IsNullOrEmpty(NullItem))
							{
								solutionContext.CurrentXmlNode = null;
							}
						}
						#region protected
						#endregion protected
					}
				}
				else
				{
					AssignProperty(interpreterType, solutionContext, templateContext, modelContext);
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method assigns a property value to the current item.</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		protected void AssignProperty(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			object propertyValue = Parameter.GetObjectValue(solutionContext, templateContext, modelContext, interpreterType);
			bool propertyAssigned = false;
			if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentAuditProperty))
			{
				propertyAssigned = solutionContext.CurrentAuditProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentCollection))
			{
				propertyAssigned = solutionContext.CurrentCollection.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntity))
			{
				propertyAssigned = solutionContext.CurrentEntity.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntityReference))
			{
				propertyAssigned = solutionContext.CurrentEntityReference.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEnumeration))
			{
				propertyAssigned = solutionContext.CurrentEnumeration.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentFeature))
			{
				propertyAssigned = solutionContext.CurrentFeature.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndex))
			{
				propertyAssigned = solutionContext.CurrentIndex.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndexProperty))
			{
				propertyAssigned = solutionContext.CurrentIndexProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethod))
			{
				propertyAssigned = solutionContext.CurrentMethod.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethodRelationship))
			{
				propertyAssigned = solutionContext.CurrentMethodRelationship.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModel))
			{
				propertyAssigned = solutionContext.CurrentModel.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelObject))
			{
				propertyAssigned = solutionContext.CurrentModelObject.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelProperty))
			{
				propertyAssigned = solutionContext.CurrentModelProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentObjectInstance))
			{
				propertyAssigned = solutionContext.CurrentObjectInstance.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentParameter))
			{
				propertyAssigned = solutionContext.CurrentParameter.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProject))
			{
				propertyAssigned = solutionContext.CurrentProject.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProperty))
			{
				propertyAssigned = solutionContext.CurrentProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyInstance))
			{
				propertyAssigned = solutionContext.CurrentPropertyInstance.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyReference))
			{
				propertyAssigned = solutionContext.CurrentPropertyReference.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyRelationship))
			{
				propertyAssigned = solutionContext.CurrentPropertyRelationship.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationship))
			{
				propertyAssigned = solutionContext.CurrentRelationship.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationshipProperty))
			{
				propertyAssigned = solutionContext.CurrentRelationshipProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStage))
			{
				propertyAssigned = solutionContext.CurrentStage.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStageTransition))
			{
				propertyAssigned = solutionContext.CurrentStageTransition.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentState))
			{
				propertyAssigned = solutionContext.CurrentState.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateModel))
			{
				propertyAssigned = solutionContext.CurrentStateModel.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateTransition))
			{
				propertyAssigned = solutionContext.CurrentStateTransition.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStep))
			{
				propertyAssigned = solutionContext.CurrentStep.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStepTransition))
			{
				propertyAssigned = solutionContext.CurrentStepTransition.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentValue))
			{
				propertyAssigned = solutionContext.CurrentValue.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentView))
			{
				propertyAssigned = solutionContext.CurrentView.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentViewProperty))
			{
				propertyAssigned = solutionContext.CurrentViewProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentWorkflow))
			{
				propertyAssigned = solutionContext.CurrentWorkflow.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlColumn))
			{
				propertyAssigned = solutionContext.CurrentSqlColumn.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlDatabase))
			{
				propertyAssigned = solutionContext.CurrentSqlDatabase.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlExtendedProperty))
			{
				propertyAssigned = solutionContext.CurrentSqlExtendedProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKey))
			{
				propertyAssigned = solutionContext.CurrentSqlForeignKey.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKeyColumn))
			{
				propertyAssigned = solutionContext.CurrentSqlForeignKeyColumn.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndex))
			{
				propertyAssigned = solutionContext.CurrentSqlIndex.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndexedColumn))
			{
				propertyAssigned = solutionContext.CurrentSqlIndexedColumn.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlProperty))
			{
				propertyAssigned = solutionContext.CurrentSqlProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlTable))
			{
				propertyAssigned = solutionContext.CurrentSqlTable.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlView))
			{
				propertyAssigned = solutionContext.CurrentSqlView.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlViewProperty))
			{
				propertyAssigned = solutionContext.CurrentSqlViewProperty.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlAttribute))
			{
				propertyAssigned = solutionContext.CurrentXmlAttribute.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlDocument))
			{
				propertyAssigned = solutionContext.CurrentXmlDocument.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlNode))
			{
				propertyAssigned = solutionContext.CurrentXmlNode.AssignProperty(AssignableProperty.PropertyName, propertyValue);
			}
			#region protected
			#endregion protected
			if (propertyAssigned == false)
			{
				LogException(solutionContext, templateContext, modelContext, new Exception(String.Format(DisplayValues.Exception_InvalidPropertyAssignment, CurrentItem.CurrentItemName, AssignableProperty.PropertyName, propertyValue.GetString())), interpreterType);
			}
		}
	}
}
