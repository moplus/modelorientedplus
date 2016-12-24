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
using MoPlus.Data;
using MoPlus.ViewModel.Entities;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Diagrams;

namespace MoPlus.ViewModel.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the DiagramsViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/27/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class DiagramsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityViewModel> Entities { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Diagrams into the view model.</summary>
		///
		/// <param name="entities">The solution entities that could be added to the diagram.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDiagrams(EnterpriseDataObjectList<EntityViewModel> entities, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Diagrams == null)
			{
				Diagrams = new EnterpriseDataObjectList<DiagramViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Diagram item in solution.DiagramList)
				{
					DiagramViewModel itemView = new DiagramViewModel(item, entities, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Diagrams.Add(itemView);
					Items.Add(itemView);
				}
			}
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		/// 
		/// <param name="entities">The solution entities that could be added to the diagram.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public DiagramsViewModel(EnterpriseDataObjectList<EntityViewModel> entities, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_SolutionDiagrams;
			Entities = entities;
			Solution = solution;
			if (loadChildren == true)
			{
				LoadDiagrams(entities, solution, loadChildren);
			}
		}
		#endregion "Constructors"
	}
}
