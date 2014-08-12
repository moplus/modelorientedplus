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

namespace MoPlus.ViewModel.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for SpecTemplate instances.</summary>
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
	public partial class SpecTemplateViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSpecTemplate.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSpecTemplate
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecTemplate;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlSpecTemplateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSpecTemplateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecTemplateToolTip;
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
				if (EditSpecTemplate.IsModified == true)
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
				return string.IsNullOrEmpty(TemplateNameValidationMessage + CategoryNameValidationMessage + NodeNameValidationMessage + IsTopLevelTemplateValidationMessage + TemplateContentValidationMessage + TemplateOutputValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private SpecTemplate _editSpecTemplate = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditSpecTemplate.</summary>
		///--------------------------------------------------------------------------------
		public SpecTemplate EditSpecTemplate
		{
			get
			{
				if (_editSpecTemplate == null)
				{
					_editSpecTemplate = new SpecTemplate();
					_editSpecTemplate.PropertyChanged += new PropertyChangedEventHandler(EditSpecTemplate_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (SpecTemplate != null)
					{
						_editSpecTemplate.TransformDataFromObject(SpecTemplate, null, false);
						_editSpecTemplate.Solution = SpecTemplate.Solution;
					}
					_editSpecTemplate.ResetModified(false);
				}
				return _editSpecTemplate;
			}
			set
			{
				_editSpecTemplate = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditSpecTemplate_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditSpecTemplate");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("TemplateName");
			OnPropertyChanged("TemplateNameCustomized");
			OnPropertyChanged("TemplateNameValidationMessage");
			
			OnPropertyChanged("FilePath");
			OnPropertyChanged("FilePathCustomized");
			
			OnPropertyChanged("CategoryName");
			OnPropertyChanged("CategoryNameCustomized");
			OnPropertyChanged("CategoryNameValidationMessage");
			
			OnPropertyChanged("NodeName");
			OnPropertyChanged("NodeNameCustomized");
			OnPropertyChanged("NodeNameValidationMessage");
			
			OnPropertyChanged("IsTopLevelTemplate");
			OnPropertyChanged("IsTopLevelTemplateCustomized");
			OnPropertyChanged("IsTopLevelTemplateValidationMessage");
			
			OnPropertyChanged("TemplateContent");
			OnPropertyChanged("TemplateContentCustomized");
			OnPropertyChanged("TemplateContentValidationMessage");
			
			OnPropertyChanged("TemplateOutput");
			OnPropertyChanged("TemplateOutputCustomized");
			OnPropertyChanged("TemplateOutputValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");

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
				return DisplayValues.Edit_SpecTemplateHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_SpecTemplateHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateIDLabel
		{
			get
			{
				return DisplayValues.Edit_TemplateIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateNameLabel
		{
			get
			{
				return DisplayValues.Edit_TemplateNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplateName.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateName
		{
			get
			{
				return EditSpecTemplate.TemplateName;
			}
			set
			{
				EditSpecTemplate.TemplateName = value;
				OnPropertyChanged("TemplateName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TemplateNameCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return TemplateName.GetString() != SpecTemplate.ReverseInstance.TemplateName.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return TemplateName.GetString() != SpecTemplate.TemplateName.GetString();
				}
				return TemplateName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateNameValidationMessage
		{
			get
			{
				return EditSpecTemplate.ValidateTemplateName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the FilePathLabel.</summary>
		///--------------------------------------------------------------------------------
		public string FilePathLabel
		{
			get
			{
				return DisplayValues.Edit_FilePathProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets FilePath.</summary>
		///--------------------------------------------------------------------------------
		public string FilePath
		{
			get
			{
				return EditSpecTemplate.FilePath;
			}
			set
			{
				EditSpecTemplate.FilePath = value;
				OnPropertyChanged("FilePath");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets FilePathCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool FilePathCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return FilePath.GetString() != SpecTemplate.ReverseInstance.FilePath.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return FilePath.GetString() != SpecTemplate.FilePath.GetString();
				}
				return FilePath != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the CategoryNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CategoryNameLabel
		{
			get
			{
				return DisplayValues.Edit_CategoryNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CategoryName.</summary>
		///--------------------------------------------------------------------------------
		public string CategoryName
		{
			get
			{
				return EditSpecTemplate.CategoryName;
			}
			set
			{
				EditSpecTemplate.CategoryName = value;
				OnPropertyChanged("CategoryName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets CategoryNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool CategoryNameCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return CategoryName.GetString() != SpecTemplate.ReverseInstance.CategoryName.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return CategoryName.GetString() != SpecTemplate.CategoryName.GetString();
				}
				return CategoryName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CategoryNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string CategoryNameValidationMessage
		{
			get
			{
				return EditSpecTemplate.ValidateCategoryName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the NodeNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NodeNameLabel
		{
			get
			{
				return DisplayValues.Edit_NodeNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets NodeName.</summary>
		///--------------------------------------------------------------------------------
		public string NodeName
		{
			get
			{
				return EditSpecTemplate.NodeName;
			}
			set
			{
				EditSpecTemplate.NodeName = value;
				OnPropertyChanged("NodeName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets NodeNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool NodeNameCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return NodeName.GetString() != SpecTemplate.ReverseInstance.NodeName.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return NodeName.GetString() != SpecTemplate.NodeName.GetString();
				}
				return NodeName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NodeNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string NodeNameValidationMessage
		{
			get
			{
				return EditSpecTemplate.ValidateNodeName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsTopLevelTemplateLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsTopLevelTemplateLabel
		{
			get
			{
				return DisplayValues.Edit_IsTopLevelTemplateProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsTopLevelTemplate.</summary>
		///--------------------------------------------------------------------------------
		public bool IsTopLevelTemplate
		{
			get
			{
				return EditSpecTemplate.IsTopLevelTemplate;
			}
			set
			{
				EditSpecTemplate.IsTopLevelTemplate = value;
				OnPropertyChanged("IsTopLevelTemplate");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsTopLevelTemplateCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsTopLevelTemplateCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return IsTopLevelTemplate.GetBool() != SpecTemplate.ReverseInstance.IsTopLevelTemplate.GetBool();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return IsTopLevelTemplate.GetBool() != SpecTemplate.IsTopLevelTemplate.GetBool();
				}
				return IsTopLevelTemplate != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsTopLevelTemplateValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsTopLevelTemplateValidationMessage
		{
			get
			{
				return EditSpecTemplate.ValidateIsTopLevelTemplate();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateContentLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateContentLabel
		{
			get
			{
				return DisplayValues.Edit_TemplateContentProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplateContent.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateContent
		{
			get
			{
				return EditSpecTemplate.TemplateContent;
			}
			set
			{
				EditSpecTemplate.TemplateContent = value;
				OnPropertyChanged("TemplateContent");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateContentCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TemplateContentCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return TemplateContent.GetString() != SpecTemplate.ReverseInstance.TemplateContent.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return TemplateContent.GetString() != SpecTemplate.TemplateContent.GetString();
				}
				return TemplateContent != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateContentValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateContentValidationMessage
		{
			get
			{
				return EditSpecTemplate.ValidateTemplateContent();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateOutputLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateOutputLabel
		{
			get
			{
				return DisplayValues.Edit_TemplateOutputProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplateOutput.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateOutput
		{
			get
			{
				return EditSpecTemplate.TemplateOutput;
			}
			set
			{
				EditSpecTemplate.TemplateOutput = value;
				OnPropertyChanged("TemplateOutput");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateOutputCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TemplateOutputCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return TemplateOutput.GetString() != SpecTemplate.ReverseInstance.TemplateOutput.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return TemplateOutput.GetString() != SpecTemplate.TemplateOutput.GetString();
				}
				return TemplateOutput != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateOutputValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateOutputValidationMessage
		{
			get
			{
				return EditSpecTemplate.ValidateTemplateOutput();
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
				return EditSpecTemplate.Description;
			}
			set
			{
				EditSpecTemplate.Description = value;
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
				if (SpecTemplate.ReverseInstance != null)
				{
					return Description.GetString() != SpecTemplate.ReverseInstance.Description.GetString();
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return Description.GetString() != SpecTemplate.Description.GetString();
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
				return EditSpecTemplate.ValidateDescription();
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
				return EditSpecTemplate.SourceName;
			}
			set
			{
				EditSpecTemplate.SourceName = value;
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
				return EditSpecTemplate.SpecSourceName;
			}
			set
			{
				EditSpecTemplate.SpecSourceName = value;
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
				return EditSpecTemplate.Tags;
			}
			set
			{
				EditSpecTemplate.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (SpecTemplate.ReverseInstance != null)
				{
					return Tags != SpecTemplate.ReverseInstance.Tags;
				}
				else if (SpecTemplate.IsAutoUpdated == true)
				{
					return Tags != SpecTemplate.Tags;
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
				return EditSpecTemplate.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditSpecTemplate.Name;
			}
			set
			{
				EditSpecTemplate.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditSpecTemplate.TransformDataFromObject(SpecTemplate, null, false);
			ResetItems();
			
			#region protected
			TemplateContentDocument.Text = TemplateContent;
			TemplateOutputDocument.Text = TemplateOutput;
			SpecTemplate.ContentBreakpoints.Clear();
			SpecTemplate.OutputBreakpoints.Clear();
			#endregion protected

			EditSpecTemplate.ResetModified(false);
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
			if (SpecTemplate.ReverseInstance != null)
			{
				EditSpecTemplate.TransformDataFromObject(SpecTemplate.ReverseInstance, null, false);
			}
			else if (SpecTemplate.IsAutoUpdated == true)
			{
				EditSpecTemplate.TransformDataFromObject(SpecTemplate, null, false);
			}
			else
			{
				SpecTemplate newSpecTemplate = new SpecTemplate();
				newSpecTemplate.TemplateID = EditSpecTemplate.TemplateID;
				EditSpecTemplate.TransformDataFromObject(newSpecTemplate, null, false);
			}
			EditSpecTemplate.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new SpecTemplate command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewSpecTemplateCommand()
		{
			SpecTemplateEventArgs message = new SpecTemplateEventArgs();
			message.SpecTemplate = new SpecTemplate();
			message.SpecTemplate.TemplateID = Guid.NewGuid();
			message.SpecTemplate.SolutionID = SolutionID;
			message.SpecTemplate.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			
			#region protected
			message.SpecTemplate.SpecificationDirectory = SpecificationDirectory;
            if (String.IsNullOrEmpty(message.SpecTemplate.SpecificationDirectory))
            {
                message.SpecTemplate.SpecificationDirectory = Solution.SpecTemplatesDirectory;
            }
			message.SpecTemplate.NodeName = SpecTemplate.NodeName;
			message.SpecTemplate.CategoryName = SpecTemplate.CategoryName;
			#endregion protected
			
			Mediator.NotifyColleagues<SpecTemplateEventArgs>(MediatorMessages.Command_EditSpecTemplateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditSpecTemplateCommand()
		{
			SpecTemplateEventArgs message = new SpecTemplateEventArgs();
			message.SpecTemplate = SpecTemplate;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SpecTemplateEventArgs>(MediatorMessages.Command_EditSpecTemplateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewSpecTemplateCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			#region protected
			if (String.IsNullOrEmpty(SpecTemplate.SuggestedFilePath))
			{
				RequestShowDialogCommand.Execute(null);
				return;
			}

			// perform the update of EditSpecTemplate back to SpecTemplate
			TemplateContent = TemplateContentDocument.Text;
			TemplateOutput = TemplateOutputDocument.Text;
			if (SpecTemplate.TemplateName != EditSpecTemplate.TemplateName || SpecTemplate.NodeName != EditSpecTemplate.NodeName)
			{
				if (System.IO.File.Exists(SpecTemplate.FilePath))
				{
					System.IO.File.Delete(SpecTemplate.FilePath);
				}
			}
			SpecTemplate.TransformDataFromObject(EditSpecTemplate, null, false);
			EditSpecTemplate.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditSpecTemplatePerformed();
			#endregion protected
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
		public void SendEditSpecTemplatePerformed()
		{
			SpecTemplateEventArgs message = new SpecTemplateEventArgs();
			message.SpecTemplate = SpecTemplate;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SpecTemplateEventArgs>(MediatorMessages.Command_EditSpecTemplatePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete SpecTemplate command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteSpecTemplateCommand()
		{
			SpecTemplateEventArgs message = new SpecTemplateEventArgs();
			message.SpecTemplate = SpecTemplate;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SpecTemplateEventArgs>(MediatorMessages.Command_DeleteSpecTemplateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteSpecTemplateCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SpecTemplate.</summary>
		///--------------------------------------------------------------------------------
		public SpecTemplate SpecTemplate { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateID.</summary>
		///--------------------------------------------------------------------------------
		public Guid TemplateID
		{
			get
			{
				return SpecTemplate.TemplateID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return SpecTemplate.Name;
			}
			set
			{
				SpecTemplate.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of SpecTemplate into the view model.</summary>
		/// 
		/// <param name="specTemplate">The SpecTemplate to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadSpecTemplate(SpecTemplate specTemplate, bool loadChildren = true)
		{
			// attach the SpecTemplate
			SpecTemplate = specTemplate;
			ItemID = SpecTemplate.TemplateID;
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
			#region protected
			if (Solution.SpecTemplates[SpecTemplate.TemplateKey] is SpecTemplate)
			{
				// TODO: this assignment shouldn't be necessary, may be a reference issue elsewhere
				SpecTemplate = Solution.SpecTemplates[SpecTemplate.TemplateKey] as SpecTemplate;
			}
			HasErrors = !SpecTemplate.IsValid || SpecTemplate.HasErrors;
			HasCustomizations = true;
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
			OnPropertyChanged("IsTemplateUtilized");
			OnPropertyChanged("ToolTipText");
			#endregion protected
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			#region protected
			// clear breakpoints (only maintain if in designer window)
			SpecTemplate.ContentBreakpoints.Clear();
			SpecTemplate.OutputBreakpoints.Clear();
			#endregion protected
			
			if (_editSpecTemplate != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditSpecTemplate.PropertyChanged -= EditSpecTemplate_PropertyChanged;
				EditSpecTemplate = null;
			}
			SpecTemplate = null;
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
		public SpecTemplateViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="specTemplate">The SpecTemplate to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public SpecTemplateViewModel(SpecTemplate specTemplate, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadSpecTemplate(specTemplate, loadChildren);
		}

		#endregion "Constructors"
	}
}
