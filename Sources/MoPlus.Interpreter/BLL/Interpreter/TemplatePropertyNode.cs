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
using MoPlus.Interpreter.Resources;
using MoPlus.Data;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of template properties.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class TemplatePropertyNode : NonLeafGrammarNode, IPropertyNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + TemplateName;
			}
		}

		public string TemplateName { get; set; }
		public List<TemplateParameterNode> Parameters { get; set; }
		public NameObjectCollection ParameterValues { get; set; }

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
				Parameters = new List<TemplateParameterNode>();
				ParameterValues = new NameObjectCollection();
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is IdentifierNode)
					{
						TemplateName = node.FindTokenAndGetText();
					}
					else if (node.AstNode is TemplateParameterListNode)
					{
						foreach (ParseTreeNode childNode in node.ChildNodes)
						{
							if (childNode.AstNode is TemplateParameterNode)
							{
								Parameters.Add(childNode.AstNode as TemplateParameterNode);
								ChildNodes.Add(childNode.AstNode as TemplateParameterNode);
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
				ThrowASTException(ex, true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="parameterModelContext">The associated model context for parameters.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public string GetCode(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, IDomainEnterpriseObject parameterModelContext, InterpreterTypeCode interpreterType)
		{
			try
			{
				ITemplate template = null;
				if (templateContext is SpecTemplate)
				{
					template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as SpecTemplate;
				}
				else
				{
					template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as CodeTemplate;
				}
				if (template != null)
				{
					template.MessageBuilder.Clear();
					template.PopCount = 0;
					template.PushModelContext(modelContext);
					template.ContentCodeBuilder.Clear();
					template.CurrentTabIndent = templateContext.CurrentTabIndent;
					InterpretNode(InterpreterTypeCode.Content, solutionContext, template, templateContext, modelContext, parameterModelContext, false);
					if (template.HasErrors == true)
					{
						templateContext.HasErrors = true;
					}
					templateContext.AddToTemplateCalls(template);
					template.AddToTemplateCalledBy(templateContext);
					if (ParameterValues.Count > 0)
					{
						int parameterCount = 0;
						string parameters = String.Empty;
						foreach (string parameter in ParameterValues.AllKeys)
						{
							if (parameterCount > 0) parameters += ", ";
							parameters += parameter;
							parameterCount++;
						}
						if (parameterCount > 1)
						{
							LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateParametersNotFoundError, parameters, TemplateName), interpreterType);
						}
						else
						{
							LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateParameterNotFoundError, parameters, TemplateName), interpreterType);
						}
					}
					return template.ContentCodeBuilder.ToString();
				}
				LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateNotFoundError, TemplateName), interpreterType);
				return "<" + TemplateName + ">";
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
			return String.Empty;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to get the associated output path to place the code.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="parameterModelContext">The associated model context for parameters.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public string GetOutputPath(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, IDomainEnterpriseObject parameterModelContext, InterpreterTypeCode interpreterType)
		{
			try
			{
				ITemplate template = null;
				if (templateContext is SpecTemplate)
				{
					template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as SpecTemplate;
				}
				else
				{
					template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as CodeTemplate;
				}
				if (template != null)
				{
					template.MessageBuilder.Clear();
					template.PopCount = 0;
					template.PushModelContext(modelContext);
					template.OutputCodeBuilder.Clear();
					template.CurrentTabIndent = templateContext.CurrentTabIndent;
					InterpretNode(InterpreterTypeCode.Output, solutionContext, template, templateContext, modelContext, parameterModelContext, false);
					if (template.HasErrors == true)
					{
						templateContext.HasErrors = true;
					}
					templateContext.AddToTemplateCalls(template);
					template.AddToTemplateCalledBy(templateContext);
					if (ParameterValues.Count > 0)
					{
						int parameterCount = 0;
						string parameters = String.Empty;
						foreach (string parameter in ParameterValues.AllKeys)
						{
							if (parameterCount > 0) parameters += ", ";
							parameters += parameter;
							parameterCount++;
						}
						if (parameterCount > 1)
						{
							LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateParametersNotFoundError, parameters, TemplateName), interpreterType);
						}
						else
						{
							LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateParameterNotFoundError, parameters, TemplateName), interpreterType);
						}
					}
					return template.OutputCodeBuilder.ToString();
				}
				else
				{
					LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateNotFoundError, TemplateName), interpreterType);
				}
				return String.Empty;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
			return String.Empty;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to get the associated template and interpret the content and output.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="parameterModelContext">The associated model context for parameters.</param>
		///--------------------------------------------------------------------------------
		public void InterpretContentAndOutput(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, IDomainEnterpriseObject parameterModelContext)
		{
			InterpreterTypeCode interpreterType = InterpreterTypeCode.Content;
			try
			{
				ITemplate template = null;
				if (TemplateName == LanguageTerms.TemplateProperty && modelContext is Project)
				{
					if (templateContext is SpecTemplate)
					{
						template = new SpecTemplate();
					}
					else
					{
						template = new CodeTemplate();
					}
					template.FilePath = (modelContext as Project).TemplateAbsolutePath;
					template.LoadTemplateFileData(false);
					string templateName = template.TemplateName;
					string code = String.Empty;
					if (templateContext is SpecTemplate)
					{
						template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(modelContext, templateName)] as SpecTemplate;
					}
					else
					{
						template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(modelContext, templateName)] as CodeTemplate;
					}
				}
				else
				{
					if (templateContext is SpecTemplate)
					{
						template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as SpecTemplate;
					}
					else
					{
						template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as CodeTemplate;
					}
				}
				if (template != null)
				{
					template.MessageBuilder.Clear();
					template.PopCount = 0;
					template.PushModelContext(modelContext);
					template.ContentCodeBuilder.Clear();
					template.CurrentTabIndent = templateContext.CurrentTabIndent;
					InterpretNode(interpreterType, solutionContext, template, templateContext, modelContext, parameterModelContext, false);
					template.PopCount = 0;
					template.PushModelContext(modelContext);
					template.OutputCodeBuilder.Clear();
					template.CurrentTabIndent = templateContext.CurrentTabIndent;
					interpreterType = InterpreterTypeCode.Output;
					InterpretNode(interpreterType, solutionContext, template, templateContext, modelContext, parameterModelContext, false);
					templateContext.AddToTemplateCalls(template);
					template.AddToTemplateCalledBy(templateContext);
					if (ParameterValues.Count > 0)
					{
						int parameterCount = 0;
						string parameters = String.Empty;
						foreach (string parameter in ParameterValues.AllKeys)
						{
							if (parameterCount > 0) parameters += ", ";
							parameters += parameter;
							parameterCount++;
						}
						if (parameterCount > 1)
						{
							LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateParametersNotFoundError, parameters, TemplateName), interpreterType);
						}
						else
						{
							LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateParameterNotFoundError, parameters, TemplateName), interpreterType);
						}
					}
					if (solutionContext.IsSampleMode == true)
					{
						templateContext.MessageBuilder.Append(template.MessageBuilder.ToString());
					}
				}
				else
				{
					LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateNotFoundError, TemplateName), interpreterType);
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
			InterpretNode(interpreterType, solutionContext, templateContext, null, modelContext, modelContext, true);
		}
		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="parentTemplateContext">The associated parent template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="parameterModelContext">The associated model context for parameters.</param>
		///--------------------------------------------------------------------------------
		public void InterpretNode(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, ITemplate parentTemplateContext, IDomainEnterpriseObject modelContext, IDomainEnterpriseObject parameterModelContext, bool appendToTemplateContext)
		{
			try
			{
				ITemplate template = null;
				if (TemplateName == LanguageTerms.TemplateProperty && modelContext is Project)
				{
					if (templateContext is SpecTemplate)
					{
						template = new SpecTemplate();
					}
					else
					{
						template = new CodeTemplate();
					}
					template.FilePath = (modelContext as Project).TemplateAbsolutePath;
					template.LoadTemplateFileData(false);
					string templateName = template.TemplateName;
					string code = String.Empty;
					if (templateContext is SpecTemplate)
					{
						template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(modelContext, templateName)] as SpecTemplate;
					}
					else
					{
						template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(modelContext, templateName)] as CodeTemplate;
					}
				}
				else
				{
					if (templateContext is SpecTemplate)
					{
						template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as SpecTemplate;
					}
					else
					{
						template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(modelContext, TemplateName)] as CodeTemplate;
					}
				}

				// add parameters
				foreach (TemplateParameterNode parameter in Parameters)
				{
					ParameterValues[parameter.VariableName] = parameter.Parameter.GetObjectValue(solutionContext, parentTemplateContext, parameterModelContext, interpreterType);
				}

				if (interpreterType == InterpreterTypeCode.Output)
				{
					if (template != null)
					{
						template.GenerateOutput(solutionContext, templateContext, modelContext, appendToTemplateContext, ParameterValues);
					}
				}
				else
				{
					if (template != null)
					{
						template.GenerateContent(solutionContext, templateContext, modelContext, appendToTemplateContext, ParameterValues);
					}
					else
					{
						templateContext.ContentCodeBuilder.Append("<" + TemplateName + ">");
						LogException(solutionContext, templateContext, modelContext, String.Format(DisplayValues.Message_TemplateNotFoundError, TemplateName, interpreterType));
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
