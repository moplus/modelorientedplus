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
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the ProjectViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/1/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ProjectViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectReferences.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ProjectReferenceViewModel> ProjectReferenceListItems
		{
			get
			{
				ProjectReferenceList = new EnterpriseDataObjectList<ProjectReference>(Project.ProjectReferenceList, null);
				_editProject.ResetModified(false);

				EnterpriseDataObjectList<ProjectReferenceViewModel> references = new EnterpriseDataObjectList<ProjectReferenceViewModel>();

				IList<Project> assemblies = (from a in Solution.ProjectList
											  where a.ProjectID != Project.ProjectID
											  select a).ToList<Project>();
				foreach (Project assembly in assemblies)
				{
					ProjectReference reference = new ProjectReference();
					reference.TransformDataFromObject(assembly, null, false);
					reference.ReferencedProject = assembly;
					reference.Project = Project;
					ProjectReferenceViewModel view = new ProjectReferenceViewModel(reference, Solution);
					if (Project.ProjectReferenceList.Find("ReferencedProjectID", reference.ReferencedProjectID) != null)
					{
						view.IsSelected = true;
					}
					view.PropertyChanged += new PropertyChangedEventHandler(ProjectReference_PropertyChanged);
					references.Add(view);
				}
				return references;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles selection changes in assembly references.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		void ProjectReference_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is ProjectReferenceViewModel)
			{
				// TODO: figure out why IsSelected isn't synching up with two way binding between multi select listbox and ProjectReferenceList
				// by the time OnUpdate is called, which is the reason for this workaround method
				ProjectReferenceViewModel changedView = sender as ProjectReferenceViewModel;
				ProjectReference existingReference = ProjectReferenceList.Find("ReferencedProjectID", changedView.ReferencedProjectID);
				if (existingReference == null && changedView.IsSelected == true)
				{
					ProjectReferenceList.Add(changedView.ProjectReference);
				}
				else if (changedView.IsSelected == false)
				{
					ProjectReferenceList.Remove(existingReference);
				}
				ProjectReferencesModified = true;
				OnPropertyChanged("ProjectReferenceList");
				OnPropertyChanged("EditProject");
				EditProject.ResetModified(true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProjectReferencesModified.</summary>
		///--------------------------------------------------------------------------------
		public bool ProjectReferencesModified { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplatePathItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Template> TemplatePathItems
		{
			get
			{
				return Solution.ProjectTemplates;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplateAbsolutePath.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateAbsolutePath
		{
			get
			{
				return EditProject.TemplateAbsolutePath;
			}
			set
			{
				EditProject.TemplateAbsolutePath = value;
				OnPropertyChanged("TemplatePath");
				OnPropertyChanged("TabTitle");
			}
		}

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
