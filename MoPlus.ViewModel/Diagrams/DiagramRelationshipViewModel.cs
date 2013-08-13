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
using System.Windows.Input;
using System.ComponentModel;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Workflows;
using MoPlus.Data;
using System.Collections.ObjectModel;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using System.Data;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Diagrams;

namespace MoPlus.ViewModel.Diagrams
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for the relationship diagram.</summary>
    /// 
    ///--------------------------------------------------------------------------------
	public class DiagramRelationshipViewModel : DiagramRelationshipWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelDelete.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDelete
		{
			get
			{
				return DisplayValues.ContextMenu_Delete;
			}
		}
		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEdited.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEdited
		{
			get
			{
				return RelationshipViewModel.IsEdited;
			}
		}
		#endregion "Editing Support"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SourceDiagramEntityViewModel.</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel SourceDiagramEntityViewModel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SinkDiagramEntityViewModel.</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel SinkDiagramEntityViewModel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Diagram.</summary>
		///--------------------------------------------------------------------------------
		public DiagramViewModel Diagram { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets RelationshipViewModel.</summary>
		///--------------------------------------------------------------------------------
		public RelationshipViewModel RelationshipViewModel { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads a diagram entity into the view model.</summary>
		/// 
		/// <param name="sourceDiagramEntityViewModel">The associated source entity view model.</param>
		/// <param name="sinkDiagramEntityViewModel">The associated sink entity view model.</param>
		/// <param name="entityRelationship">The associated entity relationship.</param>
		///--------------------------------------------------------------------------------
		public void LoadDiagramRelationship(DiagramEntityViewModel sourceDiagramEntityViewModel, DiagramEntityViewModel sinkDiagramEntityViewModel, RelationshipViewModel entityRelationship)
		{
			try
			{
				// attach the entities
				SourceDiagramEntityViewModel = sourceDiagramEntityViewModel;
				SinkDiagramEntityViewModel = sinkDiagramEntityViewModel;
				RelationshipViewModel = entityRelationship;
				HasCustomizations = true;
				IsSelected = true;
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			HasErrors = !IsValid;
			HasCustomizations = true;
			if (refreshChildren == true || refreshLevel > 0)
			{
			}
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			SourceDiagramEntityViewModel = null;
			SinkDiagramEntityViewModel = null;
			Diagram = null;
			RelationshipViewModel = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method manages the update of this view when children are updated.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_Updated(object sender, EventArgs e)
		{
			Refresh(false, 1);
			OnUpdated(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the entity from the solution.</summary>
		///--------------------------------------------------------------------------------
		public void DeleteFromSolution()
		{
			Diagram.DeleteRelationship(this);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public DiagramRelationshipViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="sourceDiagramEntityViewModel">The associated source entity view model.</param>
		/// <param name="sinkDiagramEntityViewModel">The associated sink entity view model.</param>
		/// <param name="solutionDiagram">The associated solution diagram.</param>
		/// <param name="entityRelationship">The associated entity relationship.</param>
		///--------------------------------------------------------------------------------
		public DiagramRelationshipViewModel(DiagramEntityViewModel sourceDiagramEntityViewModel, DiagramEntityViewModel sinkDiagramEntityViewModel, DiagramViewModel solutionDiagram, RelationshipViewModel entityRelationship)
		{
			LoadDiagramRelationship(sourceDiagramEntityViewModel, sinkDiagramEntityViewModel, entityRelationship);
			WorkspaceID = Guid.NewGuid();
			Diagram = solutionDiagram;
		}
		#endregion "Constructors"
    }
}
