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

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of text.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class TextNode : LeafGrammarNode, IPropertyNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				if (!String.IsNullOrEmpty(Text))
				{
					string text = Text.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");
					if (text.Length > 200)
					{
						text = text.Substring(0, 197) + "...";
					}
					return LineNumber.ToString() + ": \"" + text + "\"";
				}
				return LineNumber.ToString() + ": \"" + String.Empty+ "\"";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the text.</summary>
		///--------------------------------------------------------------------------------
		public String Text { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This constructor sets up the node text.</summary>
		/// 
		/// <param name="text">The associated text.</param>
		///--------------------------------------------------------------------------------
		public TextNode(string text)
		{
			Text = text;
			if (Text.StartsWith(LanguageTerms.TextOpenTag))
			{
				Text = Text.Substring(LanguageTerms.TextOpenTag.Length);
			}
			if (Text.EndsWith(LanguageTerms.CloseTag))
			{
				Text = Text.Substring(0, Text.Length - LanguageTerms.CloseTag.Length);
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
				output.Append(FormatTemplateText(solutionContext, Text));
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

		///--------------------------------------------------------------------------------
		/// <summary>This method formats the input template text in the format for code
		/// generation.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="text">The text to format.</param>
		/// 
		/// <returns>A string with formatted template text.</returns>
		///--------------------------------------------------------------------------------
		public string FormatTemplateText(Solution solutionContext, string text)
		{
			StringBuilder code = new StringBuilder();
			int startIndex = 0;
			int endIndex = text.Length;
			bool removeWhiteSpace = false;
			for (int i = startIndex; i < endIndex; i++)
			{
				if (i + 1 < endIndex && text.Substring(i, 2) == solutionContext.NewlineString)
				{
					removeWhiteSpace = solutionContext.UseTabs;
					code.Append(solutionContext.NewlineString);
					if (solutionContext.UseTabs == true)
					{
						for (int j = 0; j < solutionContext.CurrentTabIndent; j++)
						{
							code.Append(solutionContext.TabString);
						}
					}
					i++;
				}
				else if (removeWhiteSpace == true)
				{
					if (Char.IsWhiteSpace(text[i]) == false)
					{
						code.Append(text[i]);
						removeWhiteSpace = false;
					}
				}
				else
				{
					code.Append(text[i]);
				}
			}
			return code.ToString();
		}

	}
}
