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
using MoPlus.Interpreter.Resources;
using System.IO;
using MoPlus.IO;
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
	/// <summary>This class implements necessary members for interpretation of add model item statements.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/3/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class AddModelItemStatementNode : NonLeafGrammarNode, IStatementNode
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
				if (CurrentItem != null)
				{
					if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentAuditProperty))
					{
						if (solutionContext.CurrentAuditProperty != null)
						{
							AuditProperty.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ AuditProperty: ").Append(solutionContext.CurrentAuditProperty.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentCollection))
					{
						if (solutionContext.CurrentCollection != null)
						{
							Collection.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Collection: ").Append(solutionContext.CurrentCollection.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntity))
					{
						if (solutionContext.CurrentEntity != null)
						{
							Entity.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Entity: ").Append(solutionContext.CurrentEntity.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEntityReference))
					{
						if (solutionContext.CurrentEntityReference != null)
						{
							EntityReference.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ EntityReference: ").Append(solutionContext.CurrentEntityReference.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentEnumeration))
					{
						if (solutionContext.CurrentEnumeration != null)
						{
							Enumeration.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Enumeration: ").Append(solutionContext.CurrentEnumeration.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentFeature))
					{
						if (solutionContext.CurrentFeature != null)
						{
							Feature.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Feature: ").Append(solutionContext.CurrentFeature.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndex))
					{
						if (solutionContext.CurrentIndex != null)
						{
							Index.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Index: ").Append(solutionContext.CurrentIndex.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentIndexProperty))
					{
						if (solutionContext.CurrentIndexProperty != null)
						{
							IndexProperty.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ IndexProperty: ").Append(solutionContext.CurrentIndexProperty.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethod))
					{
						if (solutionContext.CurrentMethod != null)
						{
							Method.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Method: ").Append(solutionContext.CurrentMethod.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentMethodRelationship))
					{
						if (solutionContext.CurrentMethodRelationship != null)
						{
							MethodRelationship.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ MethodRelationship: ").Append(solutionContext.CurrentMethodRelationship.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModel))
					{
						if (solutionContext.CurrentModel != null)
						{
							Model.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Model: ").Append(solutionContext.CurrentModel.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelObject))
					{
						if (solutionContext.CurrentModelObject != null)
						{
							ModelObject.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ ModelObject: ").Append(solutionContext.CurrentModelObject.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentModelProperty))
					{
						if (solutionContext.CurrentModelProperty != null)
						{
							ModelProperty.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ ModelProperty: ").Append(solutionContext.CurrentModelProperty.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentObjectInstance))
					{
						if (solutionContext.CurrentObjectInstance != null)
						{
							ObjectInstance.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ ObjectInstance: ").Append(solutionContext.CurrentObjectInstance.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentParameter))
					{
						if (solutionContext.CurrentParameter != null)
						{
							Parameter.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Parameter: ").Append(solutionContext.CurrentParameter.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProject))
					{
						if (solutionContext.CurrentProject != null)
						{
							Project.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Project: ").Append(solutionContext.CurrentProject.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentProperty))
					{
						if (solutionContext.CurrentProperty != null)
						{
							Property.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Property: ").Append(solutionContext.CurrentProperty.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyInstance))
					{
						if (solutionContext.CurrentPropertyInstance != null)
						{
							PropertyInstance.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ PropertyInstance: ").Append(solutionContext.CurrentPropertyInstance.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyReference))
					{
						if (solutionContext.CurrentPropertyReference != null)
						{
							PropertyReference.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ PropertyReference: ").Append(solutionContext.CurrentPropertyReference.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentPropertyRelationship))
					{
						if (solutionContext.CurrentPropertyRelationship != null)
						{
							PropertyRelationship.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ PropertyRelationship: ").Append(solutionContext.CurrentPropertyRelationship.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationship))
					{
						if (solutionContext.CurrentRelationship != null)
						{
							Relationship.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Relationship: ").Append(solutionContext.CurrentRelationship.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentRelationshipProperty))
					{
						if (solutionContext.CurrentRelationshipProperty != null)
						{
							RelationshipProperty.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ RelationshipProperty: ").Append(solutionContext.CurrentRelationshipProperty.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStage))
					{
						if (solutionContext.CurrentStage != null)
						{
							Stage.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Stage: ").Append(solutionContext.CurrentStage.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStageTransition))
					{
						if (solutionContext.CurrentStageTransition != null)
						{
							StageTransition.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ StageTransition: ").Append(solutionContext.CurrentStageTransition.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentState))
					{
						if (solutionContext.CurrentState != null)
						{
							State.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ State: ").Append(solutionContext.CurrentState.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateModel))
					{
						if (solutionContext.CurrentStateModel != null)
						{
							StateModel.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ StateModel: ").Append(solutionContext.CurrentStateModel.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStateTransition))
					{
						if (solutionContext.CurrentStateTransition != null)
						{
							StateTransition.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ StateTransition: ").Append(solutionContext.CurrentStateTransition.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStep))
					{
						if (solutionContext.CurrentStep != null)
						{
							Step.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Step: ").Append(solutionContext.CurrentStep.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentStepTransition))
					{
						if (solutionContext.CurrentStepTransition != null)
						{
							StepTransition.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ StepTransition: ").Append(solutionContext.CurrentStepTransition.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentValue))
					{
						if (solutionContext.CurrentValue != null)
						{
							Value.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Value: ").Append(solutionContext.CurrentValue.InnerXmlData);
							}
						}
					}
					else if (CurrentItem.CurrentItemName == Enum.GetName(typeof(CurrentItemTypeCode), CurrentItemTypeCode.CurrentWorkflow))
					{
						if (solutionContext.CurrentWorkflow != null)
						{
							Workflow.AddCurrentItemToSolution(solutionContext, templateContext, LineNumber);
							if (solutionContext.IsSampleMode == true)
							{
								templateContext.MessageBuilder.Append("\r\n+ Workflow: ").Append(solutionContext.CurrentWorkflow.InnerXmlData);
							}
						}
					}
					#region protected
					#endregion protected
					else
					{
						LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Exception_CouldNotAddItem, CurrentItem.CurrentItemName), interpreterType);
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
		}
	}
}