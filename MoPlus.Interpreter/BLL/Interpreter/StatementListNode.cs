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

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of statement lists.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class StatementListNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This methods gets the individual statements from the statement list,
		/// and puts them in the input lists.</summary>
		///--------------------------------------------------------------------------------
		public void GetStatements(ParseTreeNode node, List<IStatementNode> statements, List<IGrammarNode> childNodes)
		{
			foreach (ParseTreeNode childNode in node.ChildNodes)
			{
				if (childNode.AstNode is VarStatementNode)
				{
					statements.Add(childNode.AstNode as VarStatementNode);
					childNodes.Add(childNode.AstNode as VarStatementNode);
				}
				else if (childNode.AstNode is ParamStatementNode)
				{
					statements.Add(childNode.AstNode as ParamStatementNode);
					childNodes.Add(childNode.AstNode as ParamStatementNode);
				}
				else if (childNode.AstNode is AssignmentStatementNode)
				{
					statements.Add(childNode.AstNode as AssignmentStatementNode);
					childNodes.Add(childNode.AstNode as AssignmentStatementNode);
				}
				else if (childNode.AstNode is IfStatementNode)
				{
					statements.Add(childNode.AstNode as IfStatementNode);
					childNodes.Add(childNode.AstNode as IfStatementNode);
				}
				else if (childNode.AstNode is SwitchStatementNode)
				{
					statements.Add(childNode.AstNode as SwitchStatementNode);
					childNodes.Add(childNode.AstNode as SwitchStatementNode);
				}
				else if (childNode.AstNode is ForeachStatementNode)
				{
					statements.Add(childNode.AstNode as ForeachStatementNode);
					childNodes.Add(childNode.AstNode as ForeachStatementNode);
				}
				else if (childNode.AstNode is WhileStatementNode)
				{
					statements.Add(childNode.AstNode as WhileStatementNode);
					childNodes.Add(childNode.AstNode as WhileStatementNode);
				}
				else if (childNode.AstNode is WithStatementNode)
				{
					statements.Add(childNode.AstNode as WithStatementNode);
					childNodes.Add(childNode.AstNode as WithStatementNode);
				}
				else if (childNode.AstNode is BreakStatementNode)
				{
					statements.Add(childNode.AstNode as BreakStatementNode);
					childNodes.Add(childNode.AstNode as BreakStatementNode);
				}
				else if (childNode.AstNode is ContinueStatementNode)
				{
					statements.Add(childNode.AstNode as ContinueStatementNode);
					childNodes.Add(childNode.AstNode as ContinueStatementNode);
				}
				else if (childNode.AstNode is ClearTextStatementNode)
				{
					statements.Add(childNode.AstNode as ClearTextStatementNode);
					childNodes.Add(childNode.AstNode as ClearTextStatementNode);
				}
				else if (childNode.AstNode is ClearPathStatementNode)
				{
					statements.Add(childNode.AstNode as ClearPathStatementNode);
					childNodes.Add(childNode.AstNode as ClearPathStatementNode);
				}
				else if (childNode.AstNode is ReturnStatementNode)
				{
					statements.Add(childNode.AstNode as ReturnStatementNode);
					childNodes.Add(childNode.AstNode as ReturnStatementNode);
				}
				else if (childNode.AstNode is OutputPropertyNode)
				{
					statements.Add(childNode.AstNode as OutputPropertyNode);
					childNodes.Add(childNode.AstNode as OutputPropertyNode);
				}
				else if (childNode.AstNode is TextNode)
				{
					statements.Add(childNode.AstNode as TextNode);
					childNodes.Add(childNode.AstNode as TextNode);
				}
				else if (childNode.AstNode is ConfigurationPropertyNode)
				{
					statements.Add(childNode.AstNode as ConfigurationPropertyNode);
					childNodes.Add(childNode.AstNode as ConfigurationPropertyNode);
				}
				else if (childNode.AstNode is ModelPropertyNode)
				{
					statements.Add(childNode.AstNode as ModelPropertyNode);
					childNodes.Add(childNode.AstNode as ModelPropertyNode);
				}
				else if (childNode.AstNode is ParameterNode)
				{
					statements.Add(childNode.AstNode as ParameterNode);
					childNodes.Add(childNode.AstNode as ParameterNode);
				}
				else if (childNode.AstNode is TemplatePropertyNode)
				{
					statements.Add(childNode.AstNode as TemplatePropertyNode);
					childNodes.Add(childNode.AstNode as TemplatePropertyNode);
				}
				else if (childNode.AstNode is UpdateStatementNode)
				{
					statements.Add(childNode.AstNode as UpdateStatementNode);
					childNodes.Add(childNode.AstNode as UpdateStatementNode);
				}
				else if (childNode.AstNode is DeleteStatementNode)
				{
					statements.Add(childNode.AstNode as DeleteStatementNode);
					childNodes.Add(childNode.AstNode as DeleteStatementNode);
				}
				else if (childNode.AstNode is RemoveStatementNode)
				{
					statements.Add(childNode.AstNode as RemoveStatementNode);
					childNodes.Add(childNode.AstNode as RemoveStatementNode);
				}
				else if (childNode.AstNode is InsertStatementNode)
				{
					statements.Add(childNode.AstNode as InsertStatementNode);
					childNodes.Add(childNode.AstNode as InsertStatementNode);
				}
				else if (childNode.AstNode is ForfilesStatementNode)
				{
					statements.Add(childNode.AstNode as ForfilesStatementNode);
					childNodes.Add(childNode.AstNode as ForfilesStatementNode);
				}
				else if (childNode.AstNode is LogStatementNode)
				{
					statements.Add(childNode.AstNode as LogStatementNode);
					childNodes.Add(childNode.AstNode as LogStatementNode);
				}
				else if (childNode.AstNode is ProgressStatementNode)
				{
					statements.Add(childNode.AstNode as ProgressStatementNode);
					childNodes.Add(childNode.AstNode as ProgressStatementNode);
				}
				else if (childNode.AstNode is CurrentItemAssignmentStatementNode)
				{
					statements.Add(childNode.AstNode as CurrentItemAssignmentStatementNode);
					childNodes.Add(childNode.AstNode as CurrentItemAssignmentStatementNode);
				}
				else if (childNode.AstNode is TemplatePropertyAssignmentStatementNode)
				{
					statements.Add(childNode.AstNode as TemplatePropertyAssignmentStatementNode);
					childNodes.Add(childNode.AstNode as TemplatePropertyAssignmentStatementNode);
				}
				else if (childNode.AstNode is DebugStatementNode)
				{
					statements.Add(childNode.AstNode as DebugStatementNode);
					childNodes.Add(childNode.AstNode as DebugStatementNode);
				}
				else if (childNode.AstNode is TraceStatementNode)
				{
					statements.Add(childNode.AstNode as TraceStatementNode);
					childNodes.Add(childNode.AstNode as TraceStatementNode);
				}
				else if (childNode.AstNode is AddModelItemStatementNode)
				{
					statements.Add(childNode.AstNode as AddModelItemStatementNode);
					childNodes.Add(childNode.AstNode as AddModelItemStatementNode);
				}
				else if (childNode.AstNode is DeleteModelItemStatementNode)
				{
					statements.Add(childNode.AstNode as DeleteModelItemStatementNode);
					childNodes.Add(childNode.AstNode as DeleteModelItemStatementNode);
				}
				if (childNode.Term is TextTerminal)
				{
					TextNode textNode = new TextNode(childNode.FindTokenAndGetText());
					textNode.LineNumber = childNode.Span.Location.Line;
					statements.Add(textNode);
					childNodes.Add(textNode);
				}
			}
		}
	}
}
