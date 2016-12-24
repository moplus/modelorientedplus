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
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the DiagramEntityViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/19/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class DiagramEntityViewModel : DiagramEntityWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelRemove.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRemove
		{
			get
			{
				return DisplayValues.ContextMenu_RemoveFromDiagram;
			}
		}

		public event EventHandler PositionChanged;
		///--------------------------------------------------------------------------------
		/// <summary>This method handles position change events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnPositionChanged(object sender, EventArgs args)
		{
			if (PositionChanged != null)
			{
				PositionChanged(this, args);
			}
		}

		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets X.</summary>
		///--------------------------------------------------------------------------------
		public override double X
		{
			get
			{
				return EditDiagramEntity.PositionX;
			}
			set
			{
				EditDiagramEntity.PositionX = value;
				OnPropertyChanged("X");
				OnPositionChanged(this, null);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Y.</summary>
		///--------------------------------------------------------------------------------
		public override double Y
		{
			get
			{
				return EditDiagramEntity.PositionY;
			}
			set
			{
				EditDiagramEntity.PositionY = value;
				OnPropertyChanged("Y");
				OnPositionChanged(this, null);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityViewModel.</summary>
		///--------------------------------------------------------------------------------
		public EntityViewModel EntityViewModel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Diagram.</summary>
		///--------------------------------------------------------------------------------
		public DiagramViewModel Diagram { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EntityViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EntityViewModel");
			Refresh(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes the entity from the solution diagram.</summary>
		///--------------------------------------------------------------------------------
		public void RemoveFromDiagram()
		{
			Diagram.RemoveEntity(this);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the entity from the solution.</summary>
		///--------------------------------------------------------------------------------
		public void DeleteFromSolution()
		{
			Diagram.DeleteEntity(this);
		}
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="diagramEntity">The associated diagram entity.</param>
		/// <param name="entityViewModel">The associated entity view model.</param>
		/// <param name="solutionDiagram">The associated solution diagram.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel(DiagramEntity diagramEntity, EntityViewModel entityViewModel, DiagramViewModel solutionDiagram)
		{
			EntityViewModel = entityViewModel;
			EntityViewModel.PropertyChanged += new PropertyChangedEventHandler(EntityViewModel_PropertyChanged);
			Items.Add(EntityViewModel);
			LoadDiagramEntity(diagramEntity, false);
			DiagramEntity.Entity = EntityViewModel.Entity;
			WorkspaceID = Guid.NewGuid();
			Diagram = solutionDiagram;
		}
		#endregion "Constructors"
	}
}
