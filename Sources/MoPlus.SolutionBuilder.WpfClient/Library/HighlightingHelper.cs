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
using System.Windows;
using System.Windows.Controls;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides the ability to add model specific elements to text highlighting.</summary>
	///--------------------------------------------------------------------------------
	public static class HighlightingHelper
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method updates recognized highlighting words based on the
		/// standard code template rules.</summary>
		/// 
		/// <param name="highlightingSpec">Input highlighting spec.</param>
		/// <param name="solution">Input solution containing objects and properties to highlight.</param>
		///--------------------------------------------------------------------------------
		public static string AddCodeHighlighting(string highlightingSpec, Solution solution)
		{
			StringBuilder languageWords = new StringBuilder();

			// add all code related highlighting
			foreach (string key in GrammarHelper.ModelContextTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.OtherModelContextTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.CurrentItemTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.AssignableProperties.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.ReadOnlyProperties.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}

			// stuff words into highlighting spec
			highlightingSpec = highlightingSpec.Replace("<Keywords color=\"ContentPropertyRecognized\">", "<Keywords color=\"ContentPropertyRecognized\">" + languageWords.ToString());
			highlightingSpec = highlightingSpec.Replace("<Keywords color=\"Property\">", "<Keywords color=\"Property\">" + languageWords.ToString());

			// add model highlighting and return
			return AddModelHighlighting(highlightingSpec, solution);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates recognized highlighting words based on the
		/// standard spec template rules.</summary>
		/// 
		/// <param name="highlightingSpec">Input highlighting spec.</param>
		/// <param name="solution">Input solution containing objects and properties to highlight.</param>
		///--------------------------------------------------------------------------------
		public static string AddSpecHighlighting(string highlightingSpec, Solution solution)
		{
			StringBuilder languageWords = new StringBuilder();

			// add all code and spec related highlighting
			foreach (string key in GrammarHelper.ModelContextTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.OtherModelContextTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.CurrentItemTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.AssignableProperties.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.ReadOnlyProperties.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}
			foreach (string key in GrammarHelper.SpecCurrentItemTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}

			foreach (string key in GrammarHelper.SpecModelContextTypes.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}

			foreach (string key in GrammarHelper.SpecProperties.AllKeys)
			{
				languageWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
			}

			// stuff words into highlighting spec
			highlightingSpec = highlightingSpec.Replace("<Keywords color=\"ContentPropertyRecognized\">", "<Keywords color=\"ContentPropertyRecognized\">" + languageWords.ToString());
			highlightingSpec = highlightingSpec.Replace("<Keywords color=\"Property\">", "<Keywords color=\"Property\">" + languageWords.ToString());

			return highlightingSpec;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates recognized highlighting words based on the
		/// input model.</summary>
		/// 
		/// <param name="highlightingSpec">Input highlighting spec.</param>
		/// <param name="solution">Input solution containing objects and properties to highlight.</param>
		///--------------------------------------------------------------------------------
		public static string AddModelHighlighting(string highlightingSpec, Solution solution)
		{
			if (solution != null)
			{
				StringBuilder modelWords = new StringBuilder();

				// add all model objects and "current" model objects to highlighting words
				foreach (string key in solution.ModelObjectNames.AllKeys)
				{
					modelWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
					modelWords.Append("\r\n\t<Word>Current").Append(key).Append("</Word>");
				}

				// add all model properties to highlighting words
				foreach (string key in solution.ModelPropertyNames.AllKeys)
				{
					modelWords.Append("\r\n\t<Word>").Append(key).Append("</Word>");
				}

				// stuff words into highlighting spec
				highlightingSpec = highlightingSpec.Replace("<Keywords color=\"ContentPropertyRecognized\">", "<Keywords color=\"ContentPropertyRecognized\">" + modelWords.ToString());
				highlightingSpec = highlightingSpec.Replace("<Keywords color=\"Property\">", "<Keywords color=\"Property\">" + modelWords.ToString());
			}
			return highlightingSpec;
		}
	}
}
