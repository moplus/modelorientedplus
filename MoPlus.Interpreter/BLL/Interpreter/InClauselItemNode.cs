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
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Data;
using System.Collections;
using MoPlus.Interpreter.Resources;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of in clauses.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class InClauselItemNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_InClause;
			}
		}

		public ModelContextNode ModelContext { get; set; }
		public CurrentItemNode CurrentItem { get; set; }
		public SpecCurrentItemNode SpecCurrentItem { get; set; }
		public CollectionHelperNode CollectionHelper { get; set; }

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
					else if (node.AstNode is CollectionHelperNode)
					{
						CollectionHelper = node.AstNode as CollectionHelperNode;
						ChildNodes.Add(node.AstNode as CollectionHelperNode);
					}
				}
			}
			catch (ApplicationAbortException ex)
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
		///--------------------------------------------------------------------------------
		public IEnterpriseEnumerable GetCollection(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, ModelContextNode collectionType, InterpreterTypeCode interpreterType)
		{
			IDomainEnterpriseObject collectionContext = modelContext;
			if (ModelContext != null)
			{
				bool isValidContext;
				collectionContext = ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
				return collectionType.GetCollection(solutionContext, templateContext, collectionContext);
			}
			else if (CurrentItem != null)
			{
				collectionContext = CurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
				return collectionType.GetCollection(solutionContext, templateContext, collectionContext);
			}
			else if (SpecCurrentItem != null)
			{
				collectionContext = SpecCurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
				return collectionType.GetCollection(solutionContext, templateContext, collectionContext);
			}
			else if (CollectionHelper != null)
			{
				return CollectionHelper.GetCollection(solutionContext, templateContext, modelContext, collectionType, interpreterType);
			}
			return null;
		}
	}
}
