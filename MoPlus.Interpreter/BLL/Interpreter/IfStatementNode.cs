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
	/// <summary>This class implements necessary members for interpretation of if statements.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class IfStatementNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_IfStatement;
			}
		}

		public ExpressionNode Expression { get; set; }
		public List<IStatementNode> Statements { get; set; }
		public List<ElseIfClauseNode> ElseIfClauses { get; set; }
		public ElseClauseNode ElseClause { get; set; }

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
				ElseIfClauses = new List<ElseIfClauseNode>();
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is ExpressionNode)
					{
						Expression = node.AstNode as ExpressionNode;
						ChildNodes.Add(node.AstNode as ExpressionNode);
					}
					else if (node.AstNode is StatementListNode)
					{
						(node.AstNode as StatementListNode).GetStatements(node, Statements, ChildNodes);
					}
					else if (node.AstNode is ElseIfListNode)
					{
						foreach (ParseTreeNode childNode in node.ChildNodes)
						{
							if (childNode.AstNode is ElseIfClauseNode)
							{
								ElseIfClauses.Add(childNode.AstNode as ElseIfClauseNode);
								ChildNodes.Add(childNode.AstNode as ElseIfClauseNode);
							}
						}
					}
					else if (node.AstNode is ElseClauseNode && node.ChildNodes.Count > 0)
					{
						ElseClause = node.AstNode as ElseClauseNode;
						ChildNodes.Add(node.AstNode as ElseClauseNode);
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
				bool clausePassed = false;
				if (Expression.EvaluateExpression(solutionContext, templateContext, modelContext, interpreterType) == true)
				{
					clausePassed = true;
					templateContext.IsBreaking = false;
					foreach (IStatementNode node in Statements)
					{
						if (node.HandleDebug(interpreterType, solutionContext, templateContext, modelContext) == false) return;
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
						if (node is ContinueStatementNode)
						{
							templateContext.IsContinuing = true;
						}
						if (node is ReturnStatementNode)
						{
							templateContext.IsReturning = true;
							break;
						}
						node.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);
					}
				}
				else
				{
					foreach (ElseIfClauseNode node in ElseIfClauses)
					{
						if (node.Expression.EvaluateExpression(solutionContext, templateContext, modelContext, interpreterType) == true)
						{
							clausePassed = true;
							templateContext.IsBreaking = false;
							foreach (IStatementNode elseIfNode in node.Statements)
							{
								if (templateContext.IsBreaking == true || templateContext.IsReturning == true)
								{
									templateContext.IsBreaking = false;
									break;
								}
								if (elseIfNode is BreakStatementNode)
								{
									templateContext.IsBreaking = true;
									break;
								}
								if (elseIfNode is ContinueStatementNode)
								{
									templateContext.IsContinuing = true;
								}
								if (elseIfNode is ReturnStatementNode)
								{
									templateContext.IsReturning = true;
									break;
								}
								elseIfNode.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);
							}
							break;
						}
					}
				}
				if (clausePassed == false && ElseClause != null)
				{
					templateContext.IsBreaking = false;
					foreach (IStatementNode node in ElseClause.Statements)
					{
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
						if (node is ContinueStatementNode)
						{
							templateContext.IsContinuing = true;
						}
						if (node is ReturnStatementNode)
						{
							templateContext.IsReturning = true;
							break;
						}
						node.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);
					}
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
	}
}
