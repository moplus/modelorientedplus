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
using MoPlus.Data;
using Irony.Parsing;
using Irony.Interpreter.Ast;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of helper properties.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ConfigurationPropertyNode : NonLeafGrammarNode, IPropertyNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				if (!String.IsNullOrEmpty(ParameterValue))
				{
					return LineNumber.ToString() + ": " + MethodName + " " + ParameterValue;
				}
				return LineNumber.ToString() + ": " + MethodName;
			}
		}

		public string MethodName { get; set; }
		public ModelPropertyNode ModelProperty { get; set; }
		public TemplatePropertyNode TemplateProperty { get; set; }
		public string ParameterValue { get; set; }

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
					if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is TemplatePropertyNode)
					{
						TemplateProperty = node.AstNode as TemplatePropertyNode;
						ChildNodes.Add(node.AstNode as TemplatePropertyNode);
					}
					else if (node.AstNode is LiteralValueNode)
					{
						ParameterValue = node.FindToken().ValueString;
					}
					else
					{
						string term = node.FindTokenAndGetText();
						if (term == "true" || term == "false")
						{
							ParameterValue = term;
						}
						else
						{
							MethodName = term;
						}
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
				StringBuilder output = null;
				if (interpreterType == InterpreterTypeCode.Output)
				{
					output = templateContext.OutputCodeBuilder;
				}
				else
				{
					output = templateContext.ContentCodeBuilder;
				}
				if (MethodName == LanguageTerms.TabMethod)
				{
					solutionContext.CurrentTabIndent += ParameterValue.GetInt();
				}
				else if (MethodName == LanguageTerms.UseTabsMethod)
				{
					if (ParameterValue == "true")
					{
						solutionContext.UseTabs = true;
					}
					else
					{
						solutionContext.UseTabs = false;
					}
				}
				else if (MethodName == LanguageTerms.TabStringMethod)
				{
					solutionContext.TabString = ParameterValue;
				}
				else if (MethodName == LanguageTerms.UseProtectedAreasMethod)
				{
					if (ParameterValue == "true")
					{
						solutionContext.UseProtectedAreas = true;
					}
					else
					{
						solutionContext.UseProtectedAreas = false;
					}
				}
				else if (MethodName == LanguageTerms.ProtectedAreaStartMethod)
				{
					solutionContext.ProtectedAreaStart = ParameterValue;
				}
				else if (MethodName == LanguageTerms.ProtectedAreaEndMethod)
				{
					solutionContext.ProtectedAreaEnd = ParameterValue;
				}
				else if (MethodName == LanguageTerms.UseIgnoredAreasMethod)
				{
					if (ParameterValue == "true")
					{
						solutionContext.UseIgnoredAreas = true;
					}
					else
					{
						solutionContext.UseIgnoredAreas = false;
					}
				}
				else if (MethodName == LanguageTerms.IgnoredAreaStartMethod)
				{
					solutionContext.IgnoredAreaStart = ParameterValue;
				}
				else if (MethodName == LanguageTerms.IgnoredAreaEndMethod)
				{
					solutionContext.IgnoredAreaEnd = ParameterValue;
				}
				else if (MethodName == LanguageTerms.UserMethod)
				{
					output.Append(solutionContext.CurrentUserName);
				}
				else if (MethodName == LanguageTerms.NowMethod)
				{
					output.Append(System.DateTime.Now.ToShortDateString());
				}
				else if (MethodName == LanguageTerms.StringCamelCase)
				{
					output.Append((ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType)).CamelCase());
				}
				else if (MethodName == LanguageTerms.StringCapitalCase)
				{
					output.Append((ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType)).CapitalCase());
				}
				else if (MethodName == LanguageTerms.StringCapitalWordCase)
				{
					output.Append((ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType)).CapitalWordCase());
				}
				else if (MethodName == LanguageTerms.StringUnderscoreCase)
				{
					output.Append((ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType)).UnderscoreCase());
				}
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
	}
}
