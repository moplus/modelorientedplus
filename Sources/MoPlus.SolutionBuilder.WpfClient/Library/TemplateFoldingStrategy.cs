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
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class allows the use of a custom tree view item.</summary>
	///--------------------------------------------------------------------------------
	public class TemplateFoldingStrategy : AbstractFoldingStrategy
	{
		/// <summary>
		/// Create <see cref="NewFolding"/>s for the specified document.
		/// </summary>
		public override IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset)
		{
			firstErrorOffset = -1;
			return CreateNewFoldings(document);
		}

		/// <summary>
		/// Create <see cref="NewFolding"/>s for the specified document.
		/// </summary>
		public IEnumerable<NewFolding> CreateNewFoldings(ITextSource document)
		{
			List<NewFolding> newFoldings = new List<NewFolding>();
			if (document == null)
				return newFoldings;

			Stack<int> startOffsets = new Stack<int>();
			Stack<int> startBraceOffsets = new Stack<int>();
			Stack<int> startEvalOffsets = new Stack<int>();
			int lastNewLineOffset = 0;
			for (int i = 0; i < document.TextLength; i++)
			{
				char c = document.GetCharAt(i);
				string openTagTest = i + 3 < document.TextLength ? document.GetText(i, 4) : String.Empty;
				string closeTagTest = i + 2 < document.TextLength ? document.GetText(i, 3) : String.Empty;
				string previousTagTest = i > 0 && i + 2 < document.TextLength ? document.GetText(i - 1, 4) : String.Empty;
				if (c == '{' && startOffsets.Count == 0 && startEvalOffsets.Count > 0)
				{
					startBraceOffsets.Push(i);
				}
				else if (c == '}' && startOffsets.Count == 0 && startEvalOffsets.Count > 0)
				{
					int startOffset = startBraceOffsets.Pop();
					// don't fold if opening and closing brace are on the same line
					//if (startOffset < lastNewLineOffset)
					//{
						newFoldings.Add(new NewFolding(startOffset, i + 1));
					//}
				}
				else if (openTagTest == LanguageTerms.EvalOpenTag)
				{
					startEvalOffsets.Push(i);
				}
				else if (openTagTest == LanguageTerms.OutputOpenTag || openTagTest == LanguageTerms.PropOpenTag || openTagTest == LanguageTerms.TextOpenTag)
				{
					startOffsets.Push(i);
				}
				else if (closeTagTest == LanguageTerms.CloseTag && previousTagTest != LanguageTerms.OutputOpenTag && (startOffsets.Count > 0 || startEvalOffsets.Count > 0))
				{
					if (startOffsets.Count > 0)
					{
						int startOffset = startOffsets.Pop();
						// don't fold if opening and closing brace are on the same line
						if (startOffset < lastNewLineOffset)
						{
							newFoldings.Add(new NewFolding(startOffset, i + 3));
						}
					}
					else if (startEvalOffsets.Count > 0)
					{
						int startOffset = startEvalOffsets.Pop();
						// don't fold if opening and closing brace are on the same line
						//if (startOffset < lastNewLineOffset)
						//{
							newFoldings.Add(new NewFolding(startOffset, i + 3));
						//}
					}
				}
				else if (c == '\n' || c == '\r')
				{
					lastNewLineOffset = i + 1;
				}
			}
			newFoldings.Sort((a, b) => a.StartOffset.CompareTo(b.StartOffset));
			return newFoldings;
		}
	}
}
