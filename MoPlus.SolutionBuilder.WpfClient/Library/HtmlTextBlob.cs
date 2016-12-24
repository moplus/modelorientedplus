/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Based on example by Diederik Krols (http://blogs.u2u.be/diederik/post/2010/08/31/A-Rich-HTML-TextBlock-for-WPF.aspx).
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
using System.Windows.Markup;
using System.Windows.Documents;
using System.IO;
using System.Windows.Data;
using System.Windows.Threading;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    /// <summary>
    /// This class provides an HTML formatted textblock.
    /// </summary>
	public class HtmlTextBlob : RichTextBox
	{
        bool isInvokePending;

        public HtmlTextBlob()
        {
            Loaded += HtmlTextBox_Loaded;
            this.IsReadOnly = true;
            this.Focusable = false;
			this.Background = null;
			this.BorderBrush = null;
			this.IsHitTestVisible = false;
        }

		public HtmlTextBlob(System.Windows.Documents.FlowDocument document)
            : base(document)
        {
        }

		private void HtmlTextBox_Loaded(object sender, RoutedEventArgs e)
		{
			Binding binding = BindingOperations.GetBinding(this, HtmlProperty);

			if (binding != null)
			{
				if (binding.UpdateSourceTrigger == UpdateSourceTrigger.Default || binding.UpdateSourceTrigger == UpdateSourceTrigger.LostFocus)
				{
					LostFocus += (o, ea) => UpdateHtml();
				}
				else
				{
					TextChanged += (o, ea) => InvokeUpdateHtml();
				}
			}
		}

		private void InvokeUpdateHtml()
		{
			if (!isInvokePending)
			{
				Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(UpdateHtml));
				isInvokePending = true;
			}
		}

		private void UpdateHtml()
		{
			Html = GetText();

			isInvokePending = false;
		}

		public static readonly DependencyProperty HtmlProperty = DependencyProperty.Register("Html", typeof(string), typeof(HtmlTextBlob), new UIPropertyMetadata(null, new PropertyChangedCallback(OnHtmlChanged)));

		public string Html
		{
			get { return GetValue(HtmlProperty) as string; }
			set { SetValue(HtmlProperty, value); }
		}

		static void OnHtmlChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
		{
			HtmlTextBlob control = target as HtmlTextBlob;
			control.UpdateText(e.NewValue as string);
		}

		public string GetText()
		{
			TextRange tr = new TextRange(Document.ContentStart, Document.ContentEnd);
			using (MemoryStream ms = new MemoryStream())
			{
				tr.Save(ms, DataFormats.Xaml);
				return ASCIIEncoding.Default.GetString(ms.ToArray());
			}
		}

		void UpdateText(string text)
		{
			try
			{
				string xaml = HtmlToXamlConverter.ConvertHtmlToXaml(text, false);
				TextRange tr = new TextRange(Document.ContentStart, Document.ContentEnd);
				using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(xaml)))
				{
					tr.Load(ms, DataFormats.Xaml);
				}
			}
			catch
			{
			}
		}
	}
}
