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
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.Resources;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for getting special collections.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>2/11/13</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class CollectionHelperNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + MethodName;
			}
		}

		public string MethodName { get; set; }
		public ModelContextNode ModelContext { get; set; }
		public CurrentItemNode CurrentItem { get; set; }
		public SpecCurrentItemNode SpecCurrentItem { get; set; }
		public ModelPropertyNode ModelProperty { get; set; }
		public ParameterNode Parameter { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method sets up the AST node and its children in the AST.</summary>
		/// 
		/// <param name="context">The parsing context.</param>
		/// <param name="treeNode">The corresponding node in the parse tree.</param>
		///--------------------------------------------------------------------------------
		public override void Init(ParsingContext context, ParseTreeNode treeNode)
		{
			try
			{
				base.Init(context, treeNode);
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is ModelContextNode)
					{
						ModelContext = node.AstNode as ModelContextNode;
						ChildNodes.Add(node.AstNode as ModelContextNode);
					}
					else if (node.AstNode is CurrentItemNode)
					{
						CurrentItem = node.AstNode as CurrentItemNode;
						ChildNodes.Add(node.AstNode as CurrentItemNode);
					}
					else if (node.AstNode is SpecCurrentItemNode)
					{
						SpecCurrentItem = node.AstNode as SpecCurrentItemNode;
						ChildNodes.Add(node.AstNode as SpecCurrentItemNode);
					}
					else if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is ParameterNode)
					{
						Parameter = node.AstNode as ParameterNode;
						ChildNodes.Add(node.AstNode as ParameterNode);
					}
					else
					{
						MethodName = node.FindTokenAndGetText();
					}
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				ThrowASTException(ex, true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="collectionType">The type of collection to get.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public IEnterpriseEnumerable GetCollection(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, ModelContextNode collectionType, InterpreterTypeCode interpreterType)
		{
			IDomainEnterpriseObject collectionContext = modelContext;
			if (ModelContext != null)
			{
				bool isValidContext;
				collectionContext = ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
			}
			else if (CurrentItem != null)
			{
				collectionContext = CurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
			}
			else if (SpecCurrentItem != null)
			{
				collectionContext = SpecCurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
			}
			if (MethodName == LanguageTerms.FindAllMethod && ModelProperty != null)
			{
				IEnterpriseEnumerable collection = collectionType.GetCollection(solutionContext, templateContext, collectionContext);
				if (collection != null)
				{
					return collection.FindItems(ModelProperty.ModelPropertyName, Parameter.GetObjectValue(solutionContext, templateContext, modelContext, interpreterType));
				}
			}
			else if (MethodName == LanguageTerms.GetEntityAndBasesCollection)
			{
				// TODO: condense ability to get extended collections
				if (collectionType.ModelContextName == "Entity" && collectionContext is Entity)
				{
					EnterpriseDataObjectList<Entity> entities = new EnterpriseDataObjectList<Entity>();
					Entity currentEntity = collectionContext as Entity;
					while (currentEntity != null)
					{
						entities.Add(currentEntity);
						currentEntity = currentEntity.BaseEntity;
					}
					return entities;
				}
				else if (collectionType.ModelContextName == "Property")
				{
					EnterpriseDataObjectList<Property> items = new EnterpriseDataObjectList<Property>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Property loopItem in currentEntity.PropertyList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "PropertyReference")
				{
					EnterpriseDataObjectList<PropertyReference> items = new EnterpriseDataObjectList<PropertyReference>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (PropertyReference loopItem in currentEntity.PropertyReferenceList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "EntityReference")
				{
					EnterpriseDataObjectList<EntityReference> items = new EnterpriseDataObjectList<EntityReference>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (EntityReference loopItem in currentEntity.EntityReferenceList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Collection")
				{
					EnterpriseDataObjectList<Collection> items = new EnterpriseDataObjectList<Collection>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Collection loopItem in currentEntity.CollectionList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Relationship")
				{
					EnterpriseDataObjectList<Relationship> items = new EnterpriseDataObjectList<Relationship>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Relationship loopItem in currentEntity.RelationshipList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Index")
				{
					EnterpriseDataObjectList<Index> items = new EnterpriseDataObjectList<Index>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Index loopItem in currentEntity.IndexList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Method")
				{
					EnterpriseDataObjectList<Method> items = new EnterpriseDataObjectList<Method>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Method loopItem in currentEntity.MethodList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
			}
			else if (MethodName == LanguageTerms.GetBaseAndEntitiesCollection)
			{
				// TODO: condense ability to get extended collections
				if (collectionType.ModelContextName == "Entity" && collectionContext is Entity)
				{
					EnterpriseDataObjectList<Entity> items = new EnterpriseDataObjectList<Entity>();
					Entity currentEntity = collectionContext as Entity;
					while (currentEntity != null)
					{
						items.Insert(0, currentEntity);
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Property")
				{
					EnterpriseDataObjectList<Property> items = new EnterpriseDataObjectList<Property>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Property loopItem in currentEntity.PropertyList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "PropertyReference")
				{
					EnterpriseDataObjectList<PropertyReference> items = new EnterpriseDataObjectList<PropertyReference>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (PropertyReference loopItem in currentEntity.PropertyReferenceList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "EntityReference")
				{
					EnterpriseDataObjectList<EntityReference> items = new EnterpriseDataObjectList<EntityReference>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (EntityReference loopItem in currentEntity.EntityReferenceList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Collection")
				{
					EnterpriseDataObjectList<Collection> items = new EnterpriseDataObjectList<Collection>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Collection loopItem in currentEntity.CollectionList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Relationship")
				{
					EnterpriseDataObjectList<Relationship> items = new EnterpriseDataObjectList<Relationship>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Relationship loopItem in currentEntity.RelationshipList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Index")
				{
					EnterpriseDataObjectList<Index> items = new EnterpriseDataObjectList<Index>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Index loopItem in currentEntity.IndexList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Method")
				{
					EnterpriseDataObjectList<Method> items = new EnterpriseDataObjectList<Method>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					while (currentEntity != null)
					{
						foreach (Method loopItem in currentEntity.MethodList)
						{
							items.Add(loopItem);
						}
						currentEntity = currentEntity.BaseEntity;
					}
					return items;
				}
			}
			else if (MethodName == LanguageTerms.ExtendingEntitiesCollection)
			{
				if (collectionType.ModelContextName == "Entity" && collectionContext is Entity)
				{
					return (collectionContext as Entity).ExtendingEntites;
				}
				else if (collectionType.ModelContextName == "Property")
				{
					EnterpriseDataObjectList<Property> items = new EnterpriseDataObjectList<Property>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (Property loopItem in loopEntity.PropertyList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
				else if (collectionType.ModelContextName == "PropertyReference")
				{
					EnterpriseDataObjectList<PropertyReference> items = new EnterpriseDataObjectList<PropertyReference>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (PropertyReference loopItem in loopEntity.PropertyReferenceList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
				else if (collectionType.ModelContextName == "EntityReference")
				{
					EnterpriseDataObjectList<EntityReference> items = new EnterpriseDataObjectList<EntityReference>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (EntityReference loopItem in loopEntity.EntityReferenceList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Collection")
				{
					EnterpriseDataObjectList<Collection> items = new EnterpriseDataObjectList<Collection>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (Collection loopItem in loopEntity.CollectionList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Relationship")
				{
					EnterpriseDataObjectList<Relationship> items = new EnterpriseDataObjectList<Relationship>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (Relationship loopItem in loopEntity.RelationshipList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Index")
				{
					EnterpriseDataObjectList<Index> items = new EnterpriseDataObjectList<Index>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (Index loopItem in loopEntity.IndexList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
				else if (collectionType.ModelContextName == "Method")
				{
					EnterpriseDataObjectList<Method> items = new EnterpriseDataObjectList<Method>();
					bool isValidContext;
					Entity currentEntity = Entity.GetModelContext(solutionContext, collectionContext, out isValidContext) as Entity;
					if (currentEntity != null)
					{
						foreach (Entity loopEntity in currentEntity.ExtendingEntites)
						{
							foreach (Method loopItem in loopEntity.MethodList)
							{
								items.Add(loopItem);
							}
						}
					}
					return items;
				}
			}
			else if (MethodName == LanguageTerms.PathRelationships)
			{
				if (collectionType.ModelContextName == "Relationship" && collectionContext is Entity)
				{
					return (collectionContext as Entity).PathRelationships;
				}
			}
			return null;
		}
	}
}
