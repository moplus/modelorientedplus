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
	/// <summary>This class implements necessary members for interpretation of model context nodes.</summary>
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
	public partial class ModelContextNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the model context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="isValidContext">Output flag, signifying whether context returned is a valid one.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, out bool isValidContext)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			IDomainEnterpriseObject currentContext = modelContext;
			ModelContextNode leafModelContext = ModelContext;
			isValidContext = false;
			if (ThisContext != null)
			{
				templateContext.PopCount = templateContext.ModelContextStack.Count - 1;
			}
			else if (PopContext != null)
			{
				// go through pop context nodes directly here
				ModelContextNode contextNode = this;
				while (contextNode != null)
				{
					if (contextNode.PopContext != null)
					{
						leafModelContext = contextNode.ModelContext;
						templateContext.PopCount++;
					}
					contextNode = contextNode.ModelContext;
				}
			}
			if (templateContext.PopCount > 0)
			{
				// pop context executes first
				nodeContext = templateContext.GetModelContext(templateContext.PopCount);
				templateContext.PopCount = 0;
			}
			if (leafModelContext != null)
			{
				// model context nodes execute next (then, nodes are evaluated)
				nodeContext = leafModelContext.GetModelContext(solutionContext, templateContext, nodeContext, out isValidContext);
			}
			if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.AuditProperty))
			{
				nodeContext = AuditProperty.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Collection))
			{
				nodeContext = Collection.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Entity))
			{
				nodeContext = Entity.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.EntityReference))
			{
				nodeContext = EntityReference.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Enumeration))
			{
				nodeContext = Enumeration.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Feature))
			{
				nodeContext = Feature.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Index))
			{
				nodeContext = Index.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.IndexProperty))
			{
				nodeContext = IndexProperty.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Method))
			{
				nodeContext = Method.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.MethodRelationship))
			{
				nodeContext = MethodRelationship.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Model))
			{
				nodeContext = Model.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelObject))
			{
				nodeContext = ModelObject.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelProperty))
			{
				nodeContext = ModelProperty.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ObjectInstance))
			{
				nodeContext = ObjectInstance.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Parameter))
			{
				nodeContext = Parameter.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Project))
			{
				nodeContext = Project.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Property))
			{
				nodeContext = Property.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyInstance))
			{
				nodeContext = PropertyInstance.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyReference))
			{
				nodeContext = PropertyReference.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyRelationship))
			{
				nodeContext = PropertyRelationship.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Relationship))
			{
				nodeContext = Relationship.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.RelationshipProperty))
			{
				nodeContext = RelationshipProperty.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Solution))
			{
				nodeContext = Solution.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Stage))
			{
				nodeContext = Stage.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StageTransition))
			{
				nodeContext = StageTransition.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.State))
			{
				nodeContext = State.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateModel))
			{
				nodeContext = StateModel.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateTransition))
			{
				nodeContext = StateTransition.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Step))
			{
				nodeContext = Step.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StepTransition))
			{
				nodeContext = StepTransition.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Value))
			{
				nodeContext = Value.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Workflow))
			{
				nodeContext = Workflow.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlColumn))
			{
				nodeContext = SqlColumn.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlDatabase))
			{
				nodeContext = SqlDatabase.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlExtendedProperty))
			{
				nodeContext = SqlExtendedProperty.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKey))
			{
				nodeContext = SqlForeignKey.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKeyColumn))
			{
				nodeContext = SqlForeignKeyColumn.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndex))
			{
				nodeContext = SqlIndex.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndexedColumn))
			{
				nodeContext = SqlIndexedColumn.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlProperty))
			{
				nodeContext = SqlProperty.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlTable))
			{
				nodeContext = SqlTable.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlAttribute))
			{
				nodeContext = XmlAttribute.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlDocument))
			{
				nodeContext = XmlDocument.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlNode))
			{
				nodeContext = XmlNode.GetModelContext(solutionContext, nodeContext, out isValidContext);
			}
			#region protected
			else if (ModelContextName == "ReferencedEntity")
			{
				currentContext = nodeContext;
				nodeContext = Collection.GetModelContext(solutionContext, currentContext, out isValidContext);
				if (nodeContext is Collection)
				{
					nodeContext = (nodeContext as Collection).ReferencedEntity;
				}
				else
				{
					nodeContext = EntityReference.GetModelContext(solutionContext, currentContext, out isValidContext);
					if (nodeContext is EntityReference)
					{
						nodeContext = (nodeContext as EntityReference).ReferencedEntity;
					}
					else
					{
						nodeContext = Relationship.GetModelContext(solutionContext, currentContext, out isValidContext);
						if (nodeContext is Relationship)
						{
							nodeContext = (nodeContext as Relationship).ReferencedEntity;
						}
						else
						{
							nodeContext = Parameter.GetModelContext(solutionContext, currentContext, out isValidContext);
							if (nodeContext is Parameter)
							{
								nodeContext = (nodeContext as Parameter).ReferencedEntity;
							}
						}
					}
				}
			}
			else if (ModelContextName == "ReferencedProperty")
			{
				currentContext = nodeContext;
				nodeContext = RelationshipProperty.GetModelContext(solutionContext, currentContext, out isValidContext);
				if (nodeContext is RelationshipProperty)
				{
					nodeContext = (nodeContext as RelationshipProperty).ReferencedProperty;
				}
				else
				{
					nodeContext = PropertyReference.GetModelContext(solutionContext, currentContext, out isValidContext);
					if (nodeContext is PropertyReference)
					{
						nodeContext = (nodeContext as PropertyReference).ReferencedProperty;
					}
					else
					{
						nodeContext = Parameter.GetModelContext(solutionContext, currentContext, out isValidContext);
						if (nodeContext is Parameter)
						{
							nodeContext = (nodeContext as Parameter).ReferencedPropertyBase as Property;
						}
					}
				}
			}
			else if (ModelContextName == "BaseEntity")
			{
				nodeContext = Entity.GetModelContext(solutionContext, nodeContext, out isValidContext);
				if (nodeContext is Entity)
				{
					nodeContext = (nodeContext as Entity).BaseEntity;
				}
			}
			#endregion protected
			else if (solutionContext.ModelObjectNames.AllKeys.Contains(ModelContextName) == true)
			{
				return ObjectInstance.GetModelContext(solutionContext, ModelContextName, nodeContext, out isValidContext);
			}
			if (nodeContext == null && isValidContext == false)
			{
				LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Exception_InvalidModelContext, ModelContextName, modelContext.Name, modelContext.GetType().Name), InterpreterTypeCode.None);
			}
			return nodeContext;
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
			bool isValidContext;
			if (ModelContext != null)
			{
				nodeContext = ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
			}
			if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.AuditProperty))
			{
				return AuditProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Collection))
			{
				return Collection.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Entity))
			{
				return Entity.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.EntityReference))
			{
				return EntityReference.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Enumeration))
			{
				return Enumeration.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Feature))
			{
				return Feature.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Index))
			{
				return Index.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.IndexProperty))
			{
				return IndexProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Method))
			{
				return Method.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.MethodRelationship))
			{
				return MethodRelationship.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Model))
			{
				return Model.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelObject))
			{
				return ModelObject.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelProperty))
			{
				return ModelProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ObjectInstance))
			{
				return ObjectInstance.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Parameter))
			{
				return Parameter.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Project))
			{
				return Project.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Property))
			{
				return Property.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyInstance))
			{
				return PropertyInstance.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyReference))
			{
				return PropertyReference.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyRelationship))
			{
				return PropertyRelationship.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Relationship))
			{
				return Relationship.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.RelationshipProperty))
			{
				return RelationshipProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Solution))
			{
				return Solution.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Stage))
			{
				return Stage.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StageTransition))
			{
				return StageTransition.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.State))
			{
				return State.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateModel))
			{
				return StateModel.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateTransition))
			{
				return StateTransition.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Step))
			{
				return Step.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StepTransition))
			{
				return StepTransition.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Value))
			{
				return Value.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Workflow))
			{
				return Workflow.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlColumn))
			{
				return SqlColumn.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlDatabase))
			{
				return SqlDatabase.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlExtendedProperty))
			{
				return SqlExtendedProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKey))
			{
				return SqlForeignKey.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKeyColumn))
			{
				return SqlForeignKeyColumn.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndex))
			{
				return SqlIndex.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndexedColumn))
			{
				return SqlIndexedColumn.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlProperty))
			{
				return SqlProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlTable))
			{
				return SqlTable.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlAttribute))
			{
				return XmlAttribute.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlDocument))
			{
				return XmlDocument.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (ModelContextName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlNode))
			{
				return XmlNode.GetCollectionContext(solutionContext, nodeContext);
			}
			#region protected
			else if (ModelContextName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Tag))
			{
				return Tag.GetCollectionContext(solutionContext, modelContext);
			}
			#endregion protected
			else if (solutionContext.ModelObjectNames.AllKeys.Contains(ModelContextName) == true)
			{
				return ObjectInstance.GetCollectionContext(solutionContext, ModelContextName, nodeContext);
			}
			LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Exception_InvalidModelContext, ModelContextName, modelContext.GetType().Name), InterpreterTypeCode.None);
			return null;
		}
	}
}
