/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Pulled off of an example from stack overflow (http://stackoverflow.com/questions/11556427/coloring-a-margin-on-avalonedit).
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
    /// This class manages the breakpoint margin bar.
    /// </summary>
	public class BreakPointMargin : AbstractMargin, IWeakEventListener
	{
		protected readonly int MARGIN = 18;
		protected TextArea TextArea { get; set; }
		protected bool IsContentMargin { get; set; }
		protected int CurrentLineCount { get; set; }

		protected List<int> Breakpoints
		{
			get
			{
				if (DataContext is CodeTemplateViewModel)
				{
					if (IsContentMargin == true)
					{
						return (DataContext as CodeTemplateViewModel).CodeTemplate.ContentBreakpoints;
					}
					else
					{
						return (DataContext as CodeTemplateViewModel).CodeTemplate.OutputBreakpoints;
					}
				}
				else if (DataContext is SpecTemplateViewModel)
				{
					if (IsContentMargin == true)
					{
						return (DataContext as SpecTemplateViewModel).SpecTemplate.ContentBreakpoints;
					}
					else
					{
						return (DataContext as SpecTemplateViewModel).SpecTemplate.OutputBreakpoints;
					}
				}
				return null;
			}
		}

		public BreakPointMargin(bool isContentMargin)
		{
			IsContentMargin = isContentMargin;
		}

		/// <inheritdoc/>
		protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
		{
			return new PointHitTestResult(this, hitTestParameters.HitPoint);
		}

		/// <inheritdoc/>
		protected override Size MeasureOverride(Size availableSize)
		{
			return new Size(MARGIN, 0);
		}

		/// <inheritdoc/>
		protected override void OnRender(DrawingContext drawingContext)
		{
			if (TextView != null && TextView.VisualLinesValid)
			{
				// draw breakpoint bar
				drawingContext.DrawRectangle(SystemColors.ControlLightBrush, null, new Rect(0, 0, RenderSize.Width, RenderSize.Height));

				List<int> breakpoints = Breakpoints;
				if (breakpoints != null)
				{
					// draw breakpoints within visual lines
					foreach (VisualLine line in TextView.VisualLines)
					{
						if (breakpoints.Contains(line.FirstDocumentLine.LineNumber))
						{
							
							BitmapImage image = new BitmapImage();
							image.BeginInit();
							image.UriSource = new Uri("pack://application:,,,/MoPlus.SolutionBuilder.WpfClient;component/Resources/Images/Breakpoint.png");
							image.EndInit();
							drawingContext.DrawImage(image, new Rect((RenderSize.Width - image.Width)/2,
																	 line.VisualTop - TextView.VerticalOffset + (line.Height - image.Height) / 2,
																	 image.Width, image.Height));
						}
					}
				}
				base.OnRender(drawingContext);
			}
		}

		/// <inheritdoc/>
		protected override void OnDocumentChanged(TextDocument oldDocument, TextDocument newDocument)
		{
			if (oldDocument != null)
			{
				PropertyChangedEventManager.RemoveListener(oldDocument, this, "LineCount");
			}
			base.OnDocumentChanged(oldDocument, newDocument);
			if (newDocument != null)
			{
				PropertyChangedEventManager.AddListener(newDocument, this, "LineCount");
			}
			OnDocumentLineCountChanged();
		}

		/// <inheritdoc cref="IWeakEventListener.ReceiveWeakEvent"/>
		protected virtual bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
		{
			if (managerType == typeof(PropertyChangedEventManager))
			{
				OnDocumentLineCountChanged();
				return true;
			}
			return false;
		}

		bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
		{
			return ReceiveWeakEvent(managerType, sender, e);
		}

		void OnDocumentLineCountChanged()
		{
			int documentLineCount = Document != null ? Document.LineCount : 1;
			List<int> breakpoints = Breakpoints;

			if (breakpoints != null && breakpoints.Count > 0 && TextArea != null)
			{
				int caretLine = TextArea.Caret.Line;
				bool breakpointsChanged = false;

				if (documentLineCount > CurrentLineCount)
				{
					for (int i = 0; i < breakpoints.Count; i++)
					{
						if (breakpoints[i] >= caretLine)
						{
							breakpoints[i]++;
							breakpointsChanged = true;
						}
					}
				}
				else
				{
					for (int i = 0; i < breakpoints.Count; i++)
					{
						if (breakpoints[i] > caretLine)
						{
							breakpoints[i]--;
							breakpointsChanged = true;
						}
					}
				}

				if (breakpointsChanged)
				{
					InvalidateVisual();
				}
			}
			CurrentLineCount = documentLineCount;
		}

		/// <inheritdoc/>
		protected override void OnTextViewChanged(TextView oldTextView, TextView newTextView)
		{
			if (oldTextView != null)
			{
				oldTextView.VisualLinesChanged -= TextViewVisualLinesChanged;
			}
			base.OnTextViewChanged(oldTextView, newTextView);
			if (newTextView != null)
			{
				newTextView.VisualLinesChanged += TextViewVisualLinesChanged;

				// find the text area belonging to the new text view
				TextArea = newTextView.Services.GetService(typeof(TextArea)) as TextArea;
			}
			else
			{
				TextArea = null;
			}
			InvalidateVisual();
		}

		void TextViewVisualLinesChanged(object sender, EventArgs e)
		{
			InvalidateVisual();
		}

		/// <inheritdoc/>
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			int lineNumber = 0;
			Point pos = e.GetPosition(TextView);
			pos.X = 0;
			pos.Y += TextView.VerticalOffset;
			VisualLine vl = TextView.GetVisualLineFromVisualTop(pos.Y);
			if (vl != null)
			{
				TextLine tl = vl.GetTextLineByVisualYPosition(pos.Y);
				int visualStartColumn = vl.GetTextLineVisualStartColumn(tl);
				int relStart = vl.FirstDocumentLine.Offset;
				int startOffset = vl.GetRelativeOffset(visualStartColumn) + relStart;
				lineNumber = TextView.Document.GetLineByOffset(startOffset).LineNumber;
			}
			List<int> breakpoints = Breakpoints;
			if (breakpoints != null && lineNumber > 0)
			{
				if (breakpoints.Contains(lineNumber))
				{
					breakpoints.Remove(lineNumber);
				}
				else
				{
					breakpoints.Add(lineNumber);
				}
				InvalidateVisual();
			}
			base.OnMouseDown(e);
		}
	}
}
