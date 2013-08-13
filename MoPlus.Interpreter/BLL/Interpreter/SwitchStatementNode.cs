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
	/// <summary>This class implements necessary members for interpretation of switch statements.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class SwitchStatementNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_SwitchStatement;
			}
		}

		public ModelPropertyNode ModelProperty { get; set; }
		public List<CaseClauseNode> CaseClauses { get; set; }
		public DefaultClauseNode DefaultClause { get; set; }

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
				CaseClauses = new List<CaseClauseNode>();
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is CaseListNode)
					{
						foreach (ParseTreeNode childNode in node.ChildNodes)
						{
							if (childNode.AstNode is CaseClauseNode)
							{
								CaseClauses.Add(childNode.AstNode as CaseClauseNode);
								ChildNodes.Add(childNode.AstNode as CaseClauseNode);
							}
						}
					}
					else if (node.AstNode is DefaultClauseNode)
					{
						DefaultClause = node.AstNode as DefaultClauseNode;
						ChildNodes.Add(node.AstNode as DefaultClauseNode);
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
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
				bool isCaseClauseExecuted = false;
				foreach (CaseClauseNode node in CaseClauses)
				{
					if (node.EvaluateConditions(solutionContext, ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType)) == true)
					{
						isCaseClauseExecuted = true;
						foreach (IStatementNode statement in node.Statements)
						{
							if (statement is BreakStatementNode)
							{
								break;
							}
							statement.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);
						}
						break;
					}
				}
				if (isCaseClauseExecuted == false)
				{
					foreach (IStatementNode statement in DefaultClause.Statements)
					{
						if (statement is BreakStatementNode)
						{
							break;
						}
						statement.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
		}
	}
}
