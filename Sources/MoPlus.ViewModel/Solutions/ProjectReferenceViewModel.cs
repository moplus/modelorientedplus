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
using MoPlus.Data;
using System.Collections.ObjectModel;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.Interpreter.BLL.Config;

namespace MoPlus.ViewModel.Solutions
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for an project reference reference in a solution.</summary>
    /// 
    ///--------------------------------------------------------------------------------
	public class ProjectReferenceViewModel : EditWorkspaceViewModel
    {
		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ProjectReference.</summary>
		///--------------------------------------------------------------------------------
		public ProjectReference ProjectReference { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectName.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectName
		{
			get
			{
				return ProjectReference.ProjectName;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedProjectName.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedProjectName
		{
			get
			{
				return ProjectReference.ReferencedProjectName;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedProjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ReferencedProjectID
		{
			get
			{
				return ProjectReference.ReferencedProjectID;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads project reference into the view model.</summary>
		/// 
		/// <param name="projectReference">The project reference to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadProjectReference(ProjectReference projectReference)
		{
			// attach the project reference
			ProjectReference = projectReference;
			ItemID = ProjectReference.ReferencedProjectID;
			HasCustomizations = true;
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
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			ProjectReference = null;
			base.OnDispose();
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ProjectReferenceViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="projectReference">The project reference to load.</param>
		/// <param name="solution">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public ProjectReferenceViewModel(ProjectReference projectReference, Solution solution)
		{
			LoadProjectReference(projectReference);
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
		}

		#endregion "Constructors"
    }
}
