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
using System.IO;
using MoPlus.IO;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of insert statements.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class InsertStatementNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_InsertStatement;
			}
		}

		public ParameterNode Parameter1 { get; set; }
		public ParameterNode Parameter2 { get; set; }
		public ParameterNode Parameter3 { get; set; }
		public ParameterNode Parameter4 { get; set; }
		public ParameterNode Parameter5 { get; set; }

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
					if (node.AstNode is ParameterNode)
					{
						if (Parameter1 == null)
						{
							Parameter1 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
						else if (Parameter2 == null)
						{
							Parameter2 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
						else if (Parameter3 == null)
						{
							Parameter3 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
						else if (Parameter4 == null)
						{
							Parameter4 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
						else if (Parameter5 == null)
						{
							Parameter5 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
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
				string path = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				if (!String.IsNullOrEmpty(path))
				{
					if (solutionContext.IsSampleMode == true)
					{
						// don't perform removal of output file data, just indicate it would be output
						templateContext.MessageBuilder.Append("\r\n+ ");
						templateContext.MessageBuilder.Append(path);
						templateContext.MessageBuilder.Append(": \"");
						templateContext.MessageBuilder.Append(Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType));
						templateContext.MessageBuilder.Append("\", \"");
						templateContext.MessageBuilder.Append(Parameter3.GetStringValue(solutionContext, templateContext, modelContext, interpreterType));
						if (Parameter4 != null)
						{
							templateContext.MessageBuilder.Append("\", \"");
							templateContext.MessageBuilder.Append(Parameter4.GetStringValue(solutionContext, templateContext, modelContext, interpreterType));
							templateContext.MessageBuilder.Append("\", \"");
							templateContext.MessageBuilder.Append(Parameter5.GetStringValue(solutionContext, templateContext, modelContext, interpreterType));
						}
						templateContext.MessageBuilder.Append("\"");
					}
					else if (solutionContext.LoggedErrors.Count == 0)
					{
						if (File.Exists(path) == true)
						{
							string text = FileHelper.GetText(path);
							if (Parameter4 != null)
							{
								// remove text bounded by begin and end tags
								string beginTag = Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
								string endTag = Parameter3.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
								string matchingText = Parameter4.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
								string insertText = Parameter5.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
								int beginIndex = text.IndexOf(beginTag);
								int previousIndex = -1;
								while (beginIndex >= 0 && beginIndex != previousIndex)
								{
									previousIndex = beginIndex;
									int endIndex = text.IndexOf(endTag, beginIndex + 1);
									if (endIndex < 0) break;
									int matchingIndex = text.IndexOf(matchingText, beginIndex);
									if (matchingIndex < endIndex && matchingIndex + matchingText.Length <= endIndex)
									{
										text = text.Substring(0, beginIndex) + insertText + text.Substring(beginIndex);
										FileHelper.ReplaceFile(path, text);
										break;
									}
									beginIndex = text.IndexOf(beginTag, beginIndex+1);
								}
							}
							else
							{
								// remove text matching input match text
								string matchingText = Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
								string insertText = Parameter3.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
								int index = text.IndexOf(matchingText);
								if (index >= 0)
								{
									text = text.Substring(0, index) + insertText + text.Substring(index);
									FileHelper.ReplaceFile(path, text);
								}
							}
						}
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
