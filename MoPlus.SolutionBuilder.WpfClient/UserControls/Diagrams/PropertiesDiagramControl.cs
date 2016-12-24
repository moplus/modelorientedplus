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
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Diagrams;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary>Interaction logic for PropertiesDiagramControl_G.xaml.</summary>
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/28/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class PropertiesDiagramControl : EditControl
	{
		private DiagramControl ParentDiagramControl
		{
			get
			{
				return VisualItemHelper.VisualUpwardSearch<DiagramControl>(this) as DiagramControl;
			}
		}

		protected override void OnPreviewMouseMove(MouseEventArgs e)
		{
			if (e.LeftButton != MouseButtonState.Pressed)
			{
				dragStartPoint = null;
				isDragging = false;
			}
			else if (dragStartPoint.HasValue && isDragging == false)
			{
				Point? currentPosition = new Point?(e.GetPosition(this));
				if (currentPosition.HasValue && (Math.Abs(currentPosition.Value.X - dragStartPoint.Value.X) > 10 || Math.Abs(currentPosition.Value.Y - dragStartPoint.Value.Y) > 10))
				{
					isDragging = true;
					DiagramRelationshipViewModel diagramView = new DiagramRelationshipViewModel();
					diagramView.SourceItem = DataContext as PropertiesViewModel;
					diagramView.Solution = diagramView.SourceItem.Solution;
					diagramView.SourceDiagramEntityViewModel = ParentEntityDiagramControl.DataContext as DiagramEntityViewModel;

					// custom drag/drop is disabled
					//ParentDiagramControl.IsDragging = true;
					//ParentDiagramControl.DragItem = diagramView;
					//ParentEntityDiagramControl.HandleAdorner();

					// DoDragDrop would be disabled if custom drag/drop approach with arc drawing adorner is utilized
					DragDrop.DoDragDrop(this, diagramView, DragDropEffects.Link);
					e.Handled = true;
				}
			}
		}

	}
}
