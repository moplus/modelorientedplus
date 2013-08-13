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
using MoPlus.Data;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Events.Models;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.ViewModel.Workflows;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for Project instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/7/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ProjectViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewProject.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewProject
		{
			get
			{
				return DisplayValues.ContextMenu_NewProject;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlProjectToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelProjectToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewProjectToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEdit.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEdit
		{
			get
			{
				return DisplayValues.ContextMenu_Edit;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEditToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEditToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_EditToolTip;
			}
		}

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

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelDeleteToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDeleteToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_DeleteToolTip;
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
				if (EditProject.IsModified == true)
				{
					return true;
				}
				if (ItemsToAdd.Count > 0)
				{
					return true;
				}
				if (ItemsToDelete.Count > 0)
				{
					return true;
				}
				foreach (IEditWorkspaceViewModel item in Items)
				{
					if (item.IsEdited == true)
					{
						return true;
					}
				}
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEditItemValid.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEditItemValid
		{
			get
			{
				return string.IsNullOrEmpty(ProjectNameValidationMessage + NamespaceValidationMessage + DbServerNameValidationMessage + DbNameValidationMessage + TemplatePathValidationMessage + DescriptionValidationMessage + ProjectReferenceListValidationMessage);
			}
		}
 
		private Project _editProject = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditProject.</summary>
		///--------------------------------------------------------------------------------
		public Project EditProject
		{
			get
			{
				if (_editProject == null)
				{
					_editProject = new Project();
					_editProject.PropertyChanged += new PropertyChangedEventHandler(EditProject_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Project != null)
					{
						_editProject.TransformDataFromObject(Project, null, false);
						_editProject.Solution = Project.Solution;
					}
					_editProject.ResetModified(false);
				}
				return _editProject;
			}
			set
			{
				_editProject = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditProject_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditProject");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ProjectName");
			OnPropertyChanged("ProjectNameCustomized");
			OnPropertyChanged("ProjectNameValidationMessage");
			
			OnPropertyChanged("Namespace");
			OnPropertyChanged("NamespaceCustomized");
			OnPropertyChanged("NamespaceValidationMessage");
			
			OnPropertyChanged("DbServerName");
			OnPropertyChanged("DbServerNameCustomized");
			OnPropertyChanged("DbServerNameValidationMessage");
			
			OnPropertyChanged("DbName");
			OnPropertyChanged("DbNameCustomized");
			OnPropertyChanged("DbNameValidationMessage");
			
			OnPropertyChanged("TemplatePath");
			OnPropertyChanged("TemplatePathCustomized");
			OnPropertyChanged("TemplatePathValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ProjectReferenceList");
			OnPropertyChanged("ProjectReferenceListCustomized");
			OnPropertyChanged("ProjectReferenceListValidationMessage");

			OnPropertyChanged("Tags");
			OnPropertyChanged("TagsCustomized");
			OnPropertyChanged("TagsValidationMessage");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title
		{
			get
			{
				return DisplayValues.Edit_ProjectHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ProjectHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProjectIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectIDLabel
		{
			get
			{
				return DisplayValues.Edit_ProjectIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProjectReferenceListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectReferenceListLabel
		{
			get
			{
				return DisplayValues.Edit_ProjectReferenceListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProjectReferenceList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ProjectReference> ProjectReferenceList
		{
			get
			{
				return EditProject.ProjectReferenceList;
			}
			set
			{
				EditProject.ProjectReferenceList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectReferenceListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ProjectReferenceListCustomized
		{
			get
			{
				#region protected
				if (ProjectReferencesModified == true) return true;
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectReferenceListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectReferenceListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProjectNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectNameLabel
		{
			get
			{
				return DisplayValues.Edit_ProjectNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProjectName.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectName
		{
			get
			{
				return EditProject.ProjectName;
			}
			set
			{
				EditProject.ProjectName = value;
				OnPropertyChanged("ProjectName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ProjectNameCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return ProjectName.GetString() != Project.ReverseInstance.ProjectName.GetString();
				}
				else if (Project.IsAutoUpdated == true)
				{
					return ProjectName.GetString() != Project.ProjectName.GetString();
				}
				return ProjectName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ProjectNameValidationMessage
		{
			get
			{
				return EditProject.ValidateProjectName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the NamespaceLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NamespaceLabel
		{
			get
			{
				return DisplayValues.Edit_NamespaceProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Namespace.</summary>
		///--------------------------------------------------------------------------------
		public string Namespace
		{
			get
			{
				return EditProject.Namespace;
			}
			set
			{
				EditProject.Namespace = value;
				OnPropertyChanged("Namespace");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets NamespaceCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool NamespaceCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return Namespace.GetString() != Project.ReverseInstance.Namespace.GetString();
				}
				else if (Project.IsAutoUpdated == true)
				{
					return Namespace.GetString() != Project.Namespace.GetString();
				}
				return Namespace != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NamespaceValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string NamespaceValidationMessage
		{
			get
			{
				return EditProject.ValidateNamespace();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DbServerNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DbServerNameLabel
		{
			get
			{
				return DisplayValues.Edit_DbServerNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DbServerName.</summary>
		///--------------------------------------------------------------------------------
		public string DbServerName
		{
			get
			{
				return EditProject.DbServerName;
			}
			set
			{
				EditProject.DbServerName = value;
				OnPropertyChanged("DbServerName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DbServerNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DbServerNameCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return DbServerName.GetString() != Project.ReverseInstance.DbServerName.GetString();
				}
				else if (Project.IsAutoUpdated == true)
				{
					return DbServerName.GetString() != Project.DbServerName.GetString();
				}
				return DbServerName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DbServerNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DbServerNameValidationMessage
		{
			get
			{
				return EditProject.ValidateDbServerName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DbNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DbNameLabel
		{
			get
			{
				return DisplayValues.Edit_DbNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DbName.</summary>
		///--------------------------------------------------------------------------------
		public string DbName
		{
			get
			{
				return EditProject.DbName;
			}
			set
			{
				EditProject.DbName = value;
				OnPropertyChanged("DbName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DbNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DbNameCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return DbName.GetString() != Project.ReverseInstance.DbName.GetString();
				}
				else if (Project.IsAutoUpdated == true)
				{
					return DbName.GetString() != Project.DbName.GetString();
				}
				return DbName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DbNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DbNameValidationMessage
		{
			get
			{
				return EditProject.ValidateDbName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplatePathLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePathLabel
		{
			get
			{
				return DisplayValues.Edit_TemplatePathProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplatePath.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePath
		{
			get
			{
				return EditProject.TemplatePath;
			}
			set
			{
				EditProject.TemplatePath = value;
				OnPropertyChanged("TemplatePath");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplatePathCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TemplatePathCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return TemplatePath.GetString() != Project.ReverseInstance.TemplatePath.GetString();
				}
				else if (Project.IsAutoUpdated == true)
				{
					return TemplatePath.GetString() != Project.TemplatePath.GetString();
				}
				return TemplatePath != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplatePathValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePathValidationMessage
		{
			get
			{
				return EditProject.ValidateTemplatePath();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DescriptionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionLabel
		{
			get
			{
				return DisplayValues.Edit_DescriptionProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Description.</summary>
		///--------------------------------------------------------------------------------
		public string Description
		{
			get
			{
				return EditProject.Description;
			}
			set
			{
				EditProject.Description = value;
				OnPropertyChanged("Description");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DescriptionCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return Description.GetString() != Project.ReverseInstance.Description.GetString();
				}
				else if (Project.IsAutoUpdated == true)
				{
					return Description.GetString() != Project.Description.GetString();
				}
				return Description != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionValidationMessage
		{
			get
			{
				return EditProject.ValidateDescription();
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SourceName
		{
			get
			{
				return EditProject.SourceName;
			}
			set
			{
				EditProject.SourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SpecSourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SpecSourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SpecSourceName
		{
			get
			{
				return EditProject.SpecSourceName;
			}
			set
			{
				EditProject.SpecSourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SpecSourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SpecSourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TagsLabel
		{
			get
			{
				return DisplayValues.Edit_TagsProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Tags.</summary>
		///--------------------------------------------------------------------------------
		public override string Tags
		{
			get
			{
				return EditProject.Tags;
			}
			set
			{
				EditProject.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Project.ReverseInstance != null)
				{
					return Tags != Project.ReverseInstance.Tags;
				}
				else if (Project.IsAutoUpdated == true)
				{
					return Tags != Project.Tags;
				}
				return Tags != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TagsValidationMessage
		{
			get
			{
				return EditProject.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditProject.Name;
			}
			set
			{
				EditProject.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditProject.TransformDataFromObject(Project, null, false);
			ResetItems();
			
			#region protected
			OnPropertyChanged("ProjectReferenceListItems");
			#endregion protected

			EditProject.ResetModified(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		public override void Reset()
		{
			OnReset();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnSetDefaults()
		{
			if (Project.ReverseInstance != null)
			{
				EditProject.TransformDataFromObject(Project.ReverseInstance, null, false);
			}
			else if (Project.IsAutoUpdated == true)
			{
				EditProject.TransformDataFromObject(Project, null, false);
			}
			else
			{
				Project newProject = new Project();
				newProject.ProjectID = EditProject.ProjectID;
				EditProject.TransformDataFromObject(newProject, null, false);
			}
			EditProject.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Project command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewProjectCommand()
		{
			ProjectEventArgs message = new ProjectEventArgs();
			message.Project = new Project();
			message.Project.ProjectID = Guid.NewGuid();
			message.Project.SolutionID = SolutionID;
			message.Project.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ProjectEventArgs>(MediatorMessages.Command_EditProjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditProjectCommand()
		{
			ProjectEventArgs message = new ProjectEventArgs();
			message.Project = Project;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ProjectEventArgs>(MediatorMessages.Command_EditProjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewProjectCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Project.ReverseInstance == null && Project.IsAutoUpdated == true)
			{
				Project.ReverseInstance = new Project();
				Project.ReverseInstance.TransformDataFromObject(Project, null, false);

				// perform the update of EditProject back to Project
				Project.TransformDataFromObject(EditProject, null, false);
				Project.IsAutoUpdated = false;
			}
			else if (Project.ReverseInstance != null)
			{
				EditProject.ResetModified(Project.ReverseInstance.IsModified);
				if (EditProject.Equals(Project.ReverseInstance))
				{
					// perform the update of EditProject back to Project
					Project.TransformDataFromObject(EditProject, null, false);
					Project.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditProject back to Project
					Project.TransformDataFromObject(EditProject, null, false);
					Project.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditProject back to Project
				Project.TransformDataFromObject(EditProject, null, false);
				Project.IsAutoUpdated = false;
			}
			Project.ForwardInstance = null;
			if (ProjectNameCustomized || NamespaceCustomized || DbServerNameCustomized || DbNameCustomized || TemplatePathCustomized || DescriptionCustomized || ProjectReferenceListCustomized || TagsCustomized)
			{
				Project.ForwardInstance = new Project();
				Project.ForwardInstance.ProjectID = EditProject.ProjectID;
				Project.SpecSourceName = Project.DefaultSourceName;
				if (ProjectNameCustomized)
				{
					Project.ForwardInstance.ProjectName = EditProject.ProjectName;
				}
				if (NamespaceCustomized)
				{
					Project.ForwardInstance.Namespace = EditProject.Namespace;
				}
				if (DbServerNameCustomized)
				{
					Project.ForwardInstance.DbServerName = EditProject.DbServerName;
				}
				if (DbNameCustomized)
				{
					Project.ForwardInstance.DbName = EditProject.DbName;
				}
				if (TemplatePathCustomized)
				{
					Project.ForwardInstance.TemplatePath = EditProject.TemplatePath;
				}
				if (DescriptionCustomized)
				{
					Project.ForwardInstance.Description = EditProject.Description;
				}
				if (ProjectReferenceListCustomized)
				{
					#region protected
					Project.ProjectReferenceList = new EnterpriseDataObjectList<ProjectReference>(EditProject.ProjectReferenceList, null);
					Project.ForwardInstance.ProjectReferenceList = new EnterpriseDataObjectList<ProjectReference>(EditProject.ProjectReferenceList, null);
					#endregion protected
					// Project.ProjectReferenceList = new EnterpriseDataObjectList<ProjectReference>(EditProject.ProjectReferenceList, null);
					// Project.ForwardInstance.ProjectReferenceList = new EnterpriseDataObjectList<ProjectReference>(EditProject.ProjectReferenceList, null);
				}
				if (TagsCustomized)
				{
					Project.ForwardInstance.Tags = EditProject.Tags;
				}
			}
			EditProject.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditProjectPerformed();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		public void Update()
		{
			OnUpdate();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends the edit item performed message to have the
		/// update applied.</summary>
		///--------------------------------------------------------------------------------
		public void SendEditProjectPerformed()
		{
			ProjectEventArgs message = new ProjectEventArgs();
			message.Project = Project;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ProjectEventArgs>(MediatorMessages.Command_EditProjectPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Project command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteProjectCommand()
		{
			ProjectEventArgs message = new ProjectEventArgs();
			message.Project = Project;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ProjectEventArgs>(MediatorMessages.Command_DeleteProjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteProjectCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Project.</summary>
		///--------------------------------------------------------------------------------
		public Project Project { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ProjectID
		{
			get
			{
				return Project.ProjectID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Project.Name;
			}
			set
			{
				Project.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Project into the view model.</summary>
		/// 
		/// <param name="project">The Project to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadProject(Project project, bool loadChildren = true)
		{
			// attach the Project
			Project = project;
			ItemID = Project.ProjectID;
			Items.Clear();
			if (loadChildren == true)
			{
				#region protected
				#endregion protected
				
				Refresh(false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			if (refreshChildren == true || refreshLevel > 0)
			{
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Project.IsValid;
			HasCustomizations = Project.IsAutoUpdated == false || Project.IsEmptyMetadata(Project.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Project.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Project.IsAutoUpdated = true;
				Project.SpecSourceName = Project.ReverseInstance.SpecSourceName;
				Project.ResetModified(Project.ReverseInstance.IsModified);
				Project.ResetLoaded(Project.ReverseInstance.IsLoaded);
				if (!Project.IsIdenticalMetadata(Project.ReverseInstance))
				{
					HasCustomizations = true;
					Project.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Project.ForwardInstance = null;
				Project.ReverseInstance = null;
				Project.IsAutoUpdated = true;
			}
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (_editProject != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditProject.PropertyChanged -= EditProject_PropertyChanged;
				EditProject = null;
			}
			Project = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			return false;
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
			OnUpdated(this, e);
		}
	
		///--------------------------------------------------------------------------------
		/// <summary>This method manages when changes occur to child collections.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns the parent view model corresponding to
		/// the input message.</summary>
		///
		/// <param name="data">The message data to find parent for.</param>
		///--------------------------------------------------------------------------------
		public EditWorkspaceViewModel FindParentViewModel(SolutionModelEventArgs data)
		{
			#region protected
			#endregion protected
		
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ProjectViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="project">The Project to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ProjectViewModel(Project project, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadProject(project, loadChildren);
		}

		#endregion "Constructors"
	}
}
