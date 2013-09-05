/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

This code is derived from WPF Diagram Designer example on Code Project, posted by sukram (http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part1.aspx).
*</copyright>*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using MoPlus.ViewModel.Entities;
using MoPlus.SolutionBuilder.WpfClient.UserControls.Entities;
using MoPlus.Data;
using MoPlus.ViewModel.Diagrams;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Solutions;
using MoPlus.SolutionBuilder.WpfClient.Resources;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
    public class DesignerCanvas : Canvas
    {
        // start point of the rubberband drag operation
        private Point? rubberbandSelectionStartPoint = null;

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramViewModel.</summary>
		///--------------------------------------------------------------------------------
		private DiagramViewModel DiagramViewModel
		{
			get
			{
				if (DataContext is DiagramViewModel)
				{
					return DataContext as DiagramViewModel;
				}
				return null;
			}
		}

		public DesignerCanvas()
        {
            this.AllowDrop = true;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Source == this)
            {
                // in case that this click is the start for a 
                // drag operation we cache the start point
                this.rubberbandSelectionStartPoint = new Point?(e.GetPosition(this));

                // if you click directly on the canvas all 
                // selected items are 'de-selected'
				if (DiagramViewModel != null)
				{
					DiagramViewModel.ClearSelectedItems();
				}
                e.Handled = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                this.rubberbandSelectionStartPoint = null;

            // ... but if mouse button is pressed and start
            // point value is set we do have one
            if (this.rubberbandSelectionStartPoint.HasValue)
            {
                // create rubberband adorner
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                if (adornerLayer != null)
                {
                    RubberbandAdorner adorner = new RubberbandAdorner(this, rubberbandSelectionStartPoint);
                    if (adorner != null)
                    {
                        adornerLayer.Add(adorner);
                    }
                }
            }
            e.Handled = true;
        }

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);
			e.Handled = true;
		}

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

			if (DiagramViewModel != null)
			{
				// drop entity if present
				EntityViewModel dragEntity = e.Data.GetData(typeof(EntityViewModel)) as EntityViewModel;
				if (dragEntity != null)
				{
					if (dragEntity.Solution.SolutionID == DiagramViewModel.Solution.SolutionID)
					{
						if (DiagramViewModel.DiagramEntities.Find("EntityID", dragEntity.EntityID) == null)
						{
							Point position = e.GetPosition(this);
							DiagramViewModel.AddEntity(dragEntity, position, true);
						}
					}
					else
					{
						// drop from another solution not supported at this time
						MessageBox.Show(DisplayValues.Message_DropFromOtherSolution, DisplayValues.Message_IssueCaption);
					}
					e.Handled = true;
				}
				else
				{
					// drop list of entities if present
					List<object> dragEntities = e.Data.GetData(typeof(List<object>)) as List<object>;
					if (dragEntities != null)
					{
						int delta = 0;
						foreach (object item in dragEntities)
						{
							if (item is EntityViewModel)
							{
								Point position = e.GetPosition(this);
								position.X += delta;
								position.Y += delta;
								DiagramViewModel.AddEntity(item as EntityViewModel, position, true);
								e.Handled = true;
								delta += 50;
							}
						}
					}
					else
					{
						// drop feature if present
						FeatureViewModel dragFeature = e.Data.GetData(typeof(FeatureViewModel)) as FeatureViewModel;
						if (dragFeature != null)
						{
							if (dragFeature.Solution.SolutionID == DiagramViewModel.Solution.SolutionID)
							{
								int delta = 0;
								foreach (EntityViewModel entity in dragFeature.Entities)
								{
									if (DiagramViewModel.DiagramEntities.Find("EntityID", entity.EntityID) == null)
									{
										Point position = e.GetPosition(this);
										position.X += delta;
										position.Y += delta;
										DiagramViewModel.AddEntity(entity, position, true);
										delta += 50;
									}
								}
							}
							else
							{
								// drop from another solution not supported at this time
								MessageBox.Show(DisplayValues.Message_DropFromOtherSolution, DisplayValues.Message_IssueCaption);
							}
							e.Handled = true;
						}
					}
				}
			}
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();
            foreach (UIElement element in base.Children)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            // add margin 
            size.Width += 10;
            size.Height += 10;
            return size;
        }
    }
}
