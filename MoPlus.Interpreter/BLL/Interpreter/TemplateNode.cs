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
using MoPlus.Data;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of templates.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class TemplateNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_Template;
			}
		}

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
					if (node.AstNode is StatementListNode)
					{
						(node.AstNode as StatementListNode).GetStatements(node, Statements, ChildNodes);
					}
					else if (node.AstNode is OutputPropertyNode)
					{
						Statements.Add(node.AstNode as OutputPropertyNode);
						ChildNodes.Add(node.AstNode as OutputPropertyNode);
					}
					else if (node.AstNode is TextNode)
					{
						Statements.Add(node.AstNode as TextNode);
						ChildNodes.Add(node.AstNode as TextNode);
					}
					else if (node.AstNode is ConfigurationPropertyNode)
					{
						Statements.Add(node.AstNode as ConfigurationPropertyNode);
						ChildNodes.Add(node.AstNode as ConfigurationPropertyNode);
					}
					else if (node.AstNode is ModelPropertyNode)
					{
						Statements.Add(node.AstNode as ModelPropertyNode);
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is ParameterNode)
					{
						Statements.Add(node.AstNode as ParameterNode);
						ChildNodes.Add(node.AstNode as ParameterNode);
					}
					else if (node.AstNode is TemplatePropertyNode)
					{
						Statements.Add(node.AstNode as TemplatePropertyNode);
						ChildNodes.Add(node.AstNode as TemplatePropertyNode);
					}
					if (node.Term is TextTerminal)
					{
						TextNode textNode = new TextNode(node.FindTokenAndGetText());
						textNode.LineNumber = node.Span.Location.Line;
						Statements.Add(textNode);
						ChildNodes.Add(textNode);
					}
				}

				//if (LineNumber == 0	|| (treeNode.ChildNodes.Count > 0 && treeNode.ChildNodes[0].AstNode	== null))
				//{
				//    // TODO: this is a hack, investigate why parsing result line numbers are sometimes zero based and
				//    // sometimes one based. Need line numbers to be one based in line with text editors.
				//    ExecuteVisitor(new IncrementLineNumberVisitor());
				//}
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
			InterpretNode(interpreterType, solutionContext, templateContext, modelContext, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="parameters">Template parameters.</param>
		///--------------------------------------------------------------------------------
		public void InterpretNode(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, NameObjectCollection parameters)
		{
			try
			{
				if (templateContext.IsWatchTemplate == false)
				{
					solutionContext.TemplatesExecuted++;
					solutionContext.TemplatesUsed[templateContext.TemplateName] = true;
				}
				templateContext.IsBreaking = false;
				templateContext.IsReturning = false;
				if (templateContext.IsWatchTemplate == false)
				{
					// clear context stack if not temporary watch template
					templateContext.ModelContextStack = null;
				}
				templateContext.PushModelContext(modelContext);
				templateContext.PopCount = 0;
				foreach (IStatementNode childNode in ChildNodes.OfType<IStatementNode>())
				{
					if (childNode.HandleDebug(interpreterType, solutionContext, templateContext, modelContext) == false) return;
					if (templateContext.IsBreaking == true || templateContext.IsReturning == true)
					{
						templateContext.IsBreaking = false;
						break;
					}
					if (childNode is BreakStatementNode || childNode is ReturnStatementNode)
					{
						break;
					}
					childNode.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);

					if (childNode is ParamStatementNode && parameters != null)
					{
						string variableName = (childNode as ParamStatementNode).VariableName;
						if (parameters.HasKey(variableName) == true)
						{
							// apply parameter value
							templateContext.Parameters[variableName] = parameters[variableName];
							parameters.Remove(variableName);
						}
					}
				}
				templateContext.IsBreaking = false;
				templateContext.IsReturning = false;
				templateContext.ModelContextStack = null;
				templateContext.PopCount = 0;
				templateContext.IsTemplateUtilized = true;
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
