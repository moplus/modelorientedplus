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
using ICSharpCode.AvalonEdit.Editing;
using System.Windows.Media;
using System.Windows;
using ICSharpCode.AvalonEdit.Rendering;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MoPlus.ViewModel.Interpreter;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using System.ComponentModel;
using ICSharpCode.AvalonEdit.Document;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    /// <summary>
    /// This class manages colorizing a breakpoint line.
    /// </summary>
	public class BreakPointLineColorizer : DocumentColorizingTransformer
	{
		public int LineNumber { get; set; }

		public BreakPointLineColorizer(int lineNumber)
		{
			LineNumber = lineNumber;
		}
    
		protected override void ColorizeLine(ICSharpCode.AvalonEdit.Document.DocumentLine line)
		{
			if (LineNumber > 0 && !line.IsDeleted && line.LineNumber == LineNumber)
			{
				ChangeLinePart(line.Offset, line.EndOffset, ApplyChanges);
			}
		}

		protected void ApplyChanges(VisualLineElement element)
		{
			element.BackgroundBrush = Brushes.Gold;
			element.TextRunProperties.SetForegroundBrush(Brushes.Red);
			//element.TextRunProperties.SetBackgroundBrush(Brushes.Gold);
		}
	}
}
