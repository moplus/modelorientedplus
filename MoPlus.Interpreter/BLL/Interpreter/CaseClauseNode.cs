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
	/// <summary>This class implements necessary members for interpretation of case clauses.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class CaseClauseNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_CaseClause;
			}
		}

		public List<CaseConditionNode> CaseConditions { get; set; }
		public List<IStatementNode> Statements { get; set; }
		public BreakStatementNode BreakStatement { get; set; }

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
				CaseConditions = new List<CaseConditionNode>();
				Statements = new List<IStatementNode>();
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is CaseConditionListNode)
					{
						foreach (ParseTreeNode childNode in node.ChildNodes)
						{
							if (childNode.AstNode is CaseConditionNode)
							{
								CaseConditions.Add(childNode.AstNode as CaseConditionNode);
								ChildNodes.Add(childNode.AstNode as CaseConditionNode);
							}
						}
					}
					else if (node.AstNode is StatementListNode)
					{
						(node.AstNode as StatementListNode).GetStatements(node, Statements, ChildNodes);
					}
					else if (node.AstNode is BreakStatementNode)
					{
						BreakStatement = node.AstNode as BreakStatementNode;
						ChildNodes.Add(node.AstNode as BreakStatementNode);
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
		/// <summary>Evaluate conditions associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="switchValue">The associated value to test conditions against.</param>
		///--------------------------------------------------------------------------------
		public bool EvaluateConditions(Solution solutionContext, string switchValue)
		{
			foreach (CaseConditionNode condition in CaseConditions)
			{
				if (condition.Literal.StringValue == switchValue)
				{
					return true;
				}
			}
			return false;
		}
	}
}
