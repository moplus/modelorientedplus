/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.Resources;
using System.Data;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.IO;
using MoPlus.Interpreter.BLL.Diagrams;
using Irony.Parsing;
using MoPlus.IO;
using System.Text;
using MoPlus.Interpreter.BLL.Solutions;
using System.Data.Common;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This file is for metadata management properties and methods to support the
	/// Solution class.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>11/11/2009</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class CodeTemplate : Template, ITemplate
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SuggestedDirectory.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string SuggestedDirectory { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SuggestedFilePath.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string SuggestedFilePath
		{
			get
			{
				if (Solution != null)
				{
					if (NodeName != Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Solution))
					{
						if (!String.IsNullOrEmpty(Solution.TemplatePath))
						{
							return Directory.GetParent(Solution.TemplateAbsolutePath).FullName + "\\" + NodeName + "\\" + TemplateName + ".mpt";
						}
						else if (!String.IsNullOrEmpty(SuggestedDirectory))
						{
							return SuggestedDirectory + "\\" + NodeName + "\\" + TemplateName + ".mpt";
						}
					}
					else
					{
						if (!String.IsNullOrEmpty(Solution.TemplatePath))
						{
							return Directory.GetParent(Solution.TemplateAbsolutePath).FullName + "\\" + TemplateName + ".mpt";
						}
						else if (!String.IsNullOrEmpty(SuggestedDirectory))
						{
							return SuggestedDirectory + "\\" + TemplateName + ".mpt";
						}
					}
				}
				return String.Empty;
			}
		}
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method saves the template to a file.</summary>
		///--------------------------------------------------------------------------------
		public bool SaveTemplateFile()
		{
			try
			{
				// move to new location, if suggest path has changed
				TryMoveToSuggestedFilePath();
				FilePath = SuggestedFilePath;
				if (File.Exists(FilePath))
				{
					FileHelper.ReplaceFile(FilePath, TemplateFileText);
					return true;
				}
				else
				{
					string directory = Directory.GetParent(FilePath).FullName;
					if (Directory.Exists(directory) == false)
					{
						Directory.CreateDirectory(directory);
					}
					FileHelper.CreateFile(FilePath, TemplateFileText);
					return true;
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_TemplateTitle, true);
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method tries to move the file to the suggested location.</summary>
		///--------------------------------------------------------------------------------
		public bool TryMoveToSuggestedFilePath()
		{
			try
			{
				if (!String.IsNullOrEmpty(FilePath) && !String.IsNullOrEmpty(SuggestedFilePath) && FilePath != SuggestedFilePath && !File.Exists(SuggestedFilePath) && File.Exists(FilePath))
				{
					File.Move(FilePath, SuggestedFilePath);
					FilePath = SuggestedFilePath;
					return true;
				}
				return false;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_TemplateTitle, true);
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method parses the template content into an abstract syntax tree.</summary>
		/// 
		/// <returns>Parser error and other messages.</returns>
		///--------------------------------------------------------------------------------
		public bool ParseContent(bool showDialog = true)
		{
			try
			{
				ContentAST = null;
				if (String.IsNullOrEmpty(TemplateContent))
				{
					HasErrors = true;
					Solution.ShowIssue(String.Format(DisplayValues.Exception_NoContent, TemplateName), DisplayValues.Exception_ParsingTitle, showDialog);
					return false;
				}
				ParseTree tree = Solution.CodeTemplateContentParser.Parse(TemplateContent);
				if (tree.ParserMessages.Count == 0 && tree.Root.AstNode is TemplateNode)
				{
					ContentAST = tree.Root.AstNode as TemplateNode;
					if (ContentAST.LineNumber == 0 || TemplateContent.TrimStart().StartsWith("//") == true)
					{
						// TODO: this is a hack, investigate why parsing result line numbers are sometimes zero based and
						// sometimes one based. Need line numbers to be one based in line with text editors.
						ContentAST.ExecuteVisitor(new IncrementLineNumberVisitor());
					}
					if (IsWatchTemplate == false)
					{
						Solution.CodeTemplates[TemplateKey] = this;
					}
				}
				else if (tree.ParserMessages.Count > 0)
				{
					HasErrors = true;
					if (IsWatchTemplate == false)
					{
						StringBuilder messages = new StringBuilder();
						messages.Append(DisplayValues.Exception_Parsing);
						messages.Append("\r\n");
						messages.Append(DisplayValues.Exception_SolutionIntro);
						messages.Append(" ");
						messages.Append(Solution.SolutionName);
						messages.Append("\r\n");
						messages.Append(DisplayValues.Exception_NodeIntro);
						messages.Append(" ");
						messages.Append(NodeName);
						messages.Append("\r\n");
						messages.Append(DisplayValues.Exception_TemplateIntro);
						messages.Append(" ");
						messages.Append(TemplateName);
						messages.Append("\r\n");
						messages.Append(DisplayValues.Exception_InnerMessageIntro);
						messages.Append("\r\n");
						foreach (ParserMessage message in tree.ParserMessages)
						{
							messages.Append(String.Format(DisplayValues.Message_TemplateContentParseError, (message.Location.Line + 1).ToString(), (message.Location.Column + 1).ToString(), message.Message));
						}
						Solution.ShowIssue(messages.ToString(), DisplayValues.Exception_ParsingTitle, showDialog);
					}
					return false;
				}
				return true;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				HasErrors = true;
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_ParsingTitle, showDialog);
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the content for a watch expression.</summary>
		/// 
		/// <param name="watchExpression">Expression to evaluate.</param>
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the watch expression.</returns>
		///--------------------------------------------------------------------------------
		public string GetWatchContent(string watchExpression, IDomainEnterpriseObject parentModelContext)
		{
			try
			{
				CodeTemplate template = Solution.CodeTemplates[TemplateKey] as CodeTemplate;
				if (template == null) return String.Empty;

				// handle special cases
				if (String.IsNullOrEmpty(watchExpression)) return String.Empty;
				if (watchExpression == LanguageTerms.TextProperty) return template.ContentCodeBuilder.ToString();
				if (watchExpression == LanguageTerms.PathProperty) return template.OutputCodeBuilder.ToString();

				// create temporary template
				CodeTemplate watchTemplate = new CodeTemplate();
				watchTemplate.Solution = Solution;
				watchTemplate.NodeName = parentModelContext.GetType().Name;
				watchTemplate.IsWatchTemplate = true;

				// wrap input expression into a template with a single property
				watchTemplate.TemplateContent = LanguageTerms.PropOpenTag + watchExpression + LanguageTerms.CloseTag;

				// push parameters and variables onto watch template
				if (template != null)
				{
					foreach (string key in template.Parameters.AllKeys)
					{
						watchTemplate.Parameters[key] = template.Parameters[key];
					}
					foreach (string key in template.Variables.AllKeys)
					{
						watchTemplate.Variables[key] = template.Variables[key];
					}
				}

				// push template context stack onto watch template as needed
				if (template != null && template.ModelContextStack.Count > 1)
				{
					for (int i = template.ModelContextStack.Count - 1; i > 0; i--)
					{
						watchTemplate.PushModelContext(template.ModelContextStack[i]);
					}
				}

				// get expression value
				string watchValue = watchTemplate.GetContent(parentModelContext, watchExpression);
				if (watchTemplate.HasErrors == true)
				{
					watchValue = DisplayValues.Exception_WatchExpression;
				}
				return watchValue;
			}
			catch (ApplicationAbortException ex)
			{
				return ex.Message;
			}
			catch (System.Exception ex)
			{
				return ex.Message;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the content watch expressions.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		///--------------------------------------------------------------------------------
		public void UpdateContentWatches(IDomainEnterpriseObject parentModelContext)
		{
			foreach (DebugItem item in ContentDebugItems)
			{
				item.DebugValue = GetWatchContent(item.DebugExpression, parentModelContext);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the output watch expressions.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		///--------------------------------------------------------------------------------
		public void UpdateOutputWatches(IDomainEnterpriseObject parentModelContext)
		{
			foreach (DebugItem item in OutputDebugItems)
			{
				item.DebugValue = GetWatchContent(item.DebugExpression, parentModelContext);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the updated content for the template.  By not
		/// supplying a model context, the generated code is generally suitable as a
		/// sample only.</summary>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GetContent()
		{
			try
			{
				return GetContent(Solution);
			}
			catch (ApplicationAbortException)
			{
				// abort with whatever content is available
				ContentCode = ContentCodeBuilder.ToString() + MessageBuilder.ToString();
				return ContentCode;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the updated content for the template.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GetContent(IDomainEnterpriseObject parentModelContext)
		{
			return GetContent(parentModelContext, String.Empty);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the updated content for the template.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GetContent(IDomainEnterpriseObject parentModelContext, string modelContextName  = "")
		{
			try
			{
				ContentCodeBuilder.Clear();
				if (IsWatchTemplate == false)
				{
					// clear parameters and variables if not passed in for temporary watch templates
					Parameters.Clear();
					Variables.Clear();
				}
				if (ContentAST == null && TemplateContent != String.Empty)
				{
					ParseContent(Solution.IsSampleMode);
				}
				if (ContentAST != null && ContentAST.ChildNodes.Count > 0)
				{
					ContentAST.InterpretNode(InterpreterTypeCode.Content, Solution, this, GetTemplateModelContext(parentModelContext, modelContextName), null);
				}
				ContentCode = ContentCodeBuilder.ToString() + MessageBuilder.ToString();
				return ContentCode;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				HasErrors = true;
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_CodeGenerationTitle, Solution.IsSampleMode);
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce content.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="appendToTemplateContext">Flag to append content.</param>
		/// <param name="parameters">Template parameters.</param>
		///--------------------------------------------------------------------------------
		public void GenerateContent(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, bool appendToTemplateContext, NameObjectCollection parameters)
		{
			ModelContextStack = null;
			PopCount = 0;
			PushModelContext(modelContext);
			MessageBuilder.Clear();
			ContentCodeBuilder.Clear();
			Parameters.Clear();
			Variables.Clear();
			CurrentTabIndent = templateContext.CurrentTabIndent;
			if (ContentAST == null && TemplateContent != String.Empty)
			{
				ParseContent(Solution.IsSampleMode);
			}
			if (Solution.UseTemplateCache == true && Solution.IsSampleMode == false && String.IsNullOrEmpty(TemplateOutput) && !String.IsNullOrEmpty(TemplateContent) && modelContext != null && CachedContent[modelContext.ID.ToString()] != null)
			{
				// use cached content
				solutionContext.TemplatesExecuted++;
				solutionContext.CachedTemplatesExecuted++;
				ContentCodeBuilder.Append(CachedContent[modelContext.ID.ToString()] as String);
			}
			else
			{
				if (ContentAST != null)
				{
					ContentAST.InterpretNode(InterpreterTypeCode.Content, solutionContext, this, modelContext, parameters);
				}
				else
				{
					ContentCodeBuilder.Append("<" + TemplateName + ">");
				}
			}
			if (Solution.UseTemplateCache == true && Solution.IsSampleMode == false && String.IsNullOrEmpty(TemplateOutput))
			{
				CachedContent[modelContext.ID.ToString()] = null;

				// only cache smaller content that has no parameters or config settings
				if (Parameters.Count == 0 && HasRelativeSettings == false && ContentCodeBuilder.Length <= Solution.TemplateCacheMaxContentSize)
				{
					CachedContent[modelContext.ID.ToString()] = ContentCodeBuilder.ToString();
				}
			}
			if (appendToTemplateContext == true)
			{
				templateContext.ContentCodeBuilder.Append(ContentCodeBuilder.ToString());
			}
			ModelContextStack = null;
			PopCount = 0;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method parses the template output into a parse tree.</summary>
		/// 
		/// <returns>A ParseTree with the parsing results.</returns>
		///--------------------------------------------------------------------------------
		public bool ParseOutput(bool showDialog = true)
		{
			try
			{
				OutputAST = null;
				if (String.IsNullOrEmpty(TemplateOutput))
				{
					HasErrors = true;
					Solution.ShowIssue(String.Format(DisplayValues.Exception_NoOutput, TemplateName), DisplayValues.Exception_ParsingTitle, showDialog);
					return false;
				}
				ParseTree tree = Solution.CodeTemplatOutputParser.Parse(TemplateOutput);
				if (tree.ParserMessages.Count == 0 && tree.Root.AstNode is TemplateNode)
				{
					OutputAST = tree.Root.AstNode as TemplateNode;
					if (OutputAST.LineNumber == 0 || TemplateOutput.TrimStart().StartsWith("//") == true)
					{
						// TODO: this is a hack, investigate why parsing result line numbers are sometimes zero based and
						// sometimes one based. Need line numbers to be one based in line with text editors.
						OutputAST.ExecuteVisitor(new IncrementLineNumberVisitor());
					}
					Solution.CodeTemplates[TemplateKey] = this;
				}
				else if (tree.ParserMessages.Count > 0)
				{
					HasErrors = true;
					StringBuilder messages = new StringBuilder();
					messages.Append(DisplayValues.Exception_Parsing);
					messages.Append("\r\n");
					messages.Append(DisplayValues.Exception_SolutionIntro);
					messages.Append(" ");
					messages.Append(Solution.SolutionName);
					messages.Append("\r\n");
					messages.Append(DisplayValues.Exception_NodeIntro);
					messages.Append(" ");
					messages.Append(NodeName);
					messages.Append("\r\n");
					messages.Append(DisplayValues.Exception_TemplateIntro);
					messages.Append(" ");
					messages.Append(TemplateName);
					messages.Append("\r\n");
					messages.Append(DisplayValues.Exception_InnerMessageIntro);
					messages.Append("\r\n");
					foreach (ParserMessage message in tree.ParserMessages)
					{
						messages.Append(String.Format(DisplayValues.Message_TemplateOutputParseError, (message.Location.Line + 1).ToString(), (message.Location.Column + 1).ToString(), message.Message));
					}
					Solution.ShowIssue(messages.ToString(), DisplayValues.Exception_ParsingTitle, showDialog);
					return false;
				}
				return true;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				HasErrors = true;
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_ParsingTitle, showDialog);
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method generates the associated output path for the template.  By not
		/// supplying a model context, the generated code is generally suitable as a
		/// sample only.</summary>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GenerateOutput()
		{
			try
			{
				return GenerateOutput(Solution);
			}
			catch (ApplicationAbortException)
			{
				// abort with whatever content is available
				OutputCode = OutputCodeBuilder.ToString() + MessageBuilder.ToString();
				return OutputCode;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method generates the associated output path for the template.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GenerateOutput(IDomainEnterpriseObject parentModelContext)
		{
			try
			{
				MessageBuilder.Clear();
				OutputCodeBuilder.Clear();
				Parameters.Clear();
				Variables.Clear();
				if (OutputAST == null)
				{
					ParseOutput(Solution.IsSampleMode);
				}
				IDomainEnterpriseObject context = GetTemplateModelContext(parentModelContext);
				if (OutputAST != null && OutputAST.ChildNodes.Count > 0)
				{
					OutputAST.InterpretNode(InterpreterTypeCode.Output, Solution, this, context, null);
					OutputCode = OutputCodeBuilder.ToString() + MessageBuilder.ToString();
				}
				return OutputCode;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				HasErrors = true;
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_CodeGenerationTitle, Solution.IsSampleMode);
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method generates the associated output path for the template.  By not
		/// supplying a model context, the generated code is generally suitable as a
		/// sample only.</summary>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GenerateContentAndOutput()
		{
			return GenerateContentAndOutput(Solution);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method generates the associated output path for the code template.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		public string GenerateContentAndOutput(IDomainEnterpriseObject parentModelContext)
		{
			try
			{
				MessageBuilder.Clear();
				ContentCodeBuilder.Clear();
				Parameters.Clear();
				Variables.Clear();
				if (ContentAST == null && TemplateContent != String.Empty)
				{
					ParseContent(Solution.IsSampleMode);
				}
				OutputCodeBuilder.Clear();
				Parameters.Clear();
				Variables.Clear();
				if (OutputAST == null && TemplateOutput != String.Empty)
				{
					ParseOutput(Solution.IsSampleMode);
				}
				IDomainEnterpriseObject context = GetTemplateModelContext(parentModelContext);
				if (ContentAST != null && ContentAST.ChildNodes.Count > 0)
				{
					ContentAST.InterpretNode(InterpreterTypeCode.Content, Solution, this, context, null);
				}
				if (OutputAST != null && OutputAST.ChildNodes.Count > 0)
				{
					OutputAST.InterpretNode(InterpreterTypeCode.Output, Solution, this, context, null);
				}
				ContentCode = ContentCodeBuilder.ToString();
				OutputCode = OutputCodeBuilder.ToString() + MessageBuilder.ToString();
				return OutputCode;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				HasErrors = true;
				Solution.ShowIssue(ex.Message + ex.StackTrace, DisplayValues.Exception_CodeGenerationTitle, Solution.IsSampleMode);
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="appendToTemplateContext">Flag indicating if context should be appended to.</param>
		/// <param name="parameters">Template parameters.</param>
		///--------------------------------------------------------------------------------
		public void GenerateOutput(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, bool appendToTemplateContext, NameObjectCollection parameters)
		{
			ModelContextStack = null;
			PopCount = 0;
			PushModelContext(modelContext);
			OutputCodeBuilder.Clear();
			CurrentTabIndent = templateContext.CurrentTabIndent;
			if (OutputAST == null)
			{
				ParseOutput(Solution.IsSampleMode);
			}
			if (OutputAST != null)
			{
				OutputAST.InterpretNode(InterpreterTypeCode.Output, solutionContext, this, modelContext, parameters);
			}
			else
			{
				OutputCodeBuilder.Append("<" + TemplateName + ">");
			}
			if (appendToTemplateContext == true)
			{
				templateContext.OutputCodeBuilder.Append(ContentCodeBuilder.ToString());
			}
			ModelContextStack = null;
			PopCount = 0;
		}
		#endregion "Methods"
	}
}