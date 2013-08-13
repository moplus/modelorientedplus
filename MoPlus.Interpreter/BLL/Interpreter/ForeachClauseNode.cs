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
	/// <summary>This class implements necessary members for interpretation of foreach items.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>10/23/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ForeachClauseNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_ForeachClause; ;
			}
		}

		public string ForeachHelperName { get; set; }
		public ModelContextNode ModelContext { get; set; }
		public InClauseNode InClause { get; set; }
		public WhereClauseNode WhereClause { get; set; }
		public LimitClauseNode LimitClause { get; set; }
		public SortClauseNode SortClause { get; set; }

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
					else if (node.AstNode is InClauseNode)
					{
						if (node.ChildNodes.Count > 0)
						{
							InClause = node.AstNode as InClauseNode;
							ChildNodes.Add(node.AstNode as InClauseNode);
						}
					}
					else if (node.AstNode is WhereClauseNode)
					{
						if (node.ChildNodes.Count > 0)
						{
							WhereClause = node.AstNode as WhereClauseNode;
							ChildNodes.Add(node.AstNode as WhereClauseNode);
						}
					}
					else if (node.AstNode is LimitClauseNode)
					{
						if (node.ChildNodes.Count > 0)
						{
							LimitClause = node.AstNode as LimitClauseNode;
							ChildNodes.Add(node.AstNode as LimitClauseNode);
						}
					}
					else if (node.AstNode is SortClauseNode)
					{
						if (node.ChildNodes.Count > 0)
						{
							SortClause = node.AstNode as SortClauseNode;
							ChildNodes.Add(node.AstNode as SortClauseNode);
						}
					}
					else
					{
						ForeachHelperName = node.FindTokenAndGetText();
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
	}
}
