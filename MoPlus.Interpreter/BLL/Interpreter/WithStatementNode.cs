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
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of with statements.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class WithStatementNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_WithStatement;
			}
		}

		public ModelContextNode ModelContext { get; set; }
		public CurrentItemNode CurrentItem { get; set; }
		public FromClauseNode FromClause { get; set; }
		public List<IStatementNode> Statements { get; set; }

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
				Statements = new List<IStatementNode>();
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
					// TODO: investigate why empty from clause node is being created
					else if (node.AstNode is FromClauseNode && node.FindTokenAndGetText() != null)
					{
						FromClause = node.AstNode as FromClauseNode;
						ChildNodes.Add(node.AstNode as FromClauseNode);
					}
					else if (node.AstNode is StatementListNode)
					{
						(node.AstNode as StatementListNode).GetStatements(node, Statements, ChildNodes);
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
				IDomainEnterpriseObject withModelContext = GetModelContext(solutionContext, templateContext, modelContext, interpreterType);
				templateContext.PushModelContext(withModelContext);
				templateContext.IsBreaking = false;
				if (withModelContext != null)
				{
					foreach (IStatementNode node in Statements)
					{
						if (node.HandleDebug(interpreterType, solutionContext, templateContext, withModelContext) == false) return;
						if (templateContext.IsBreaking == true || templateContext.IsReturning == true)
						{
							templateContext.IsBreaking = false;
							break;
						}
						if (node is BreakStatementNode)
						{
							templateContext.IsBreaking = true;
							break;
						}
						if (node is ReturnStatementNode)
						{
							templateContext.IsReturning = true;
							break;
						}
						node.InterpretNode(interpreterType, solutionContext, templateContext, withModelContext);
					}
				}
				templateContext.PopModelContext();
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

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the model context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, InterpreterTypeCode interpreterType)
		{
			if (ModelContext != null)
			{
				if (FromClause != null)
				{
					return FromClause.ContextHelper.GetModelContext(solutionContext, templateContext, modelContext, ModelContext, interpreterType);
				}
				else
				{
					bool isValidContext;
					return ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
				}
			}
			else if (CurrentItem != null)
			{
				return CurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
			}
			return modelContext;
		}
	}
}
