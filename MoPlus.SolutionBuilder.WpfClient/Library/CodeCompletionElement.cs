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
using MoPlus.ViewModel;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using System.Windows.Input;
using System.Text.RegularExpressions;
using MoPlus.ViewModel.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Interpreter;
using Irony.Parsing;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Document;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements AvalonEdit ICompletionData interface to provide the entries in the
	/// completion drop down.</summary>
	///--------------------------------------------------------------------------------
	public class CodeCompletionElement : ICompletionData
	{
		///--------------------------------------------------------------------------------
		/// <summary>This contructor sets up a CodeCompletionElement.</summary>
		/// 
		/// <param name="text">Input text.</param>
		///--------------------------------------------------------------------------------
		public CodeCompletionElement(string text)
		{
			this.Text = text;
		}

		/// <summary>
		/// Gets the image.
		/// </summary>
		public System.Windows.Media.ImageSource Image
		{
			get { return null; }
		}

		/// <summary>
		/// Gets the priority. This property is used in the selection logic. You can use it to prefer selecting those items
		/// which the user is accessing most frequently.
		/// </summary>
		public double Priority
		{
			get
			{
				return 0.0;
			}
		}

		public string Text { get; private set; }

		/// <summary>
		/// The displayed content. This can be the same as 'Text', or a WPF UIElement if
		/// you want to display rich content.
		/// </summary>
		// Use this property if you want to show a fancy UIElement in the list.
		public object Content
		{
			get { return this.Text; }
		}

		/// <summary>
		/// Gets the description.
		/// </summary>
		public object Description
		{
			get { return "Description for " + this.Text; }
		}

		/// <summary>
		/// Perform the completion.
		/// </summary>
		/// <param name="textArea">The text area on which completion is performed.</param>
		/// <param name="completionSegment">The text segment that was used by the completion window if
		/// the user types (segment between CompletionWindow.StartOffset and CompletionWindow.EndOffset).</param>
		/// <param name="insertionRequestEventArgs">The EventArgs used for the insertion request.
		/// These can be TextCompositionEventArgs, KeyEventArgs, MouseEventArgs, depending on how
		/// the insertion was triggered.</param>
		public void Complete(TextArea textArea, ISegment completionSegment,
			EventArgs insertionRequestEventArgs)
		{
			textArea.Document.Replace(completionSegment, this.Text);
		}
	}
}
