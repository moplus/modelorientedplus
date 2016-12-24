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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoPlus.SolutionBuilder.WpfClient.Library;
using Microsoft.Win32;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.ViewModel.Solutions;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary>Interaction logic for XmlSourceDetailControl_G.xaml.</summary>
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/31/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class XmlSourceDetailControl : EditControl
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method executes the open command for the xml file.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SourceOpenExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = ".xml";
			dialog.Filter = DisplayValues.FileFilter_XmlFiles;
			bool? result = dialog.ShowDialog();
			if (result == true)
			{
				if (DataContext is XmlSourceViewModel)
				{
					XmlSourceViewModel viewModel = DataContext as XmlSourceViewModel;
					viewModel.SourceFilePath = dialog.FileName;
					if (viewModel.SourceFilePath.LastIndexOf("\\") > 0)
					{
						viewModel.SourceFileName = viewModel.SourceFilePath.Substring(viewModel.SourceFilePath.LastIndexOf("\\") + 1);
					}
					else
					{
						viewModel.SourceFileName = viewModel.SourceFilePath;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the open command for the template file.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = ".mps";
			dialog.Filter = DisplayValues.FileFilter_SpecTemplates;
			bool? result = dialog.ShowDialog();
			if (result == true)
			{
				if (DataContext is XmlSourceViewModel)
				{
					(DataContext as XmlSourceViewModel).TemplatePath = dialog.FileName;
				}
			}
		}

	}
}
