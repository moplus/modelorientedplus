/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code was developed by Thomas Willwacher and posted on Code Project (http://www.codeproject.com/Articles/173509/A-Universal-WPF-Find-Replace-Dialog).
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using MoPlus.SolutionBuilder.WpfClient.Library;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls
{

    /// <summary>
    /// Interaction logic for FindReplaceDialog.xaml
    /// </summary>
    public partial class FindReplaceDialog : Window
    {
        FindReplaceMgr TheVM;

        public FindReplaceDialog(FindReplaceMgr theVM)
        {            
            InitializeComponent();
            DataContext = TheVM = theVM;             
        }

        private void FindNextClick(object sender, RoutedEventArgs e)
        {
            TheVM.FindNext();
        }

        private void ReplaceClick(object sender, RoutedEventArgs e)
        {
            TheVM.Replace();
        }

        private void ReplaceAllClick(object sender, RoutedEventArgs e)
        {
            TheVM.ReplaceAll();
        }
  
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

    }
}
