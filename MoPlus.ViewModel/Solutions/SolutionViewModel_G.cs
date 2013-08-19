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
	/// <summary>This class provides views for Solution instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/18/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSolution
		{
			get
			{
				return DisplayValues.ContextMenu_NewSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlSolutionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSolutionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewSolutionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSpecificationSource.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSpecificationSource
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecificationSource;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSpecificationSourceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSpecificationSourceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecificationSourceToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCollection.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCollection
		{
			get
			{
				return DisplayValues.ContextMenu_NewCollection;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCollectionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCollectionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewCollectionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyReference.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyReference
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyReference;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyReferenceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyReferenceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyReferenceToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntityReference.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntityReference
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntityReference;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntityReferenceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntityReferenceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntityReferenceToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewProjectToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewProjectToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewProjectToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewFeature.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewFeature
		{
			get
			{
				return DisplayValues.ContextMenu_NewFeature;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewFeatureToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewFeatureToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewFeatureToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewWorkflow.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewWorkflow
		{
			get
			{
				return DisplayValues.ContextMenu_NewWorkflow;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewWorkflowToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewWorkflowToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewWorkflowToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModel.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModel
		{
			get
			{
				return DisplayValues.ContextMenu_NewModel;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagram.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagram
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagram;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagramToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagramToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewAuditProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewAuditProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewAuditPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewAuditPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewAuditPropertyToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewSpecTemplateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSpecTemplateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecTemplateToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCodeTemplate.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCodeTemplate
		{
			get
			{
				return DisplayValues.ContextMenu_NewCodeTemplate;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCodeTemplateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCodeTemplateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewCodeTemplateToolTip;
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
				if (EditSolution.IsModified == true)
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
				return string.IsNullOrEmpty(SolutionNameValidationMessage + NamespaceValidationMessage + OutputSolutionFileNameValidationMessage + CompanyNameValidationMessage + ProductNameValidationMessage + ProductVersionValidationMessage + TemplatePathValidationMessage + CopyrightValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Solution _editSolution = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditSolution.</summary>
		///--------------------------------------------------------------------------------
		public Solution EditSolution
		{
			get
			{
				if (_editSolution == null)
				{
					_editSolution = new Solution();
					_editSolution.PropertyChanged += new PropertyChangedEventHandler(EditSolution_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Solution != null)
					{
						_editSolution.TransformDataFromObject(Solution, null, false);
					}
					_editSolution.ResetModified(false);
				}
				return _editSolution;
			}
			set
			{
				_editSolution = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditSolution_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditSolution");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("SolutionName");
			OnPropertyChanged("SolutionNameCustomized");
			OnPropertyChanged("SolutionNameValidationMessage");
			
			OnPropertyChanged("Namespace");
			OnPropertyChanged("NamespaceCustomized");
			OnPropertyChanged("NamespaceValidationMessage");
			
			OnPropertyChanged("OutputSolutionFileName");
			OnPropertyChanged("OutputSolutionFileNameCustomized");
			OnPropertyChanged("OutputSolutionFileNameValidationMessage");
			
			OnPropertyChanged("CompanyName");
			OnPropertyChanged("CompanyNameCustomized");
			OnPropertyChanged("CompanyNameValidationMessage");
			
			OnPropertyChanged("ProductName");
			OnPropertyChanged("ProductNameCustomized");
			OnPropertyChanged("ProductNameValidationMessage");
			
			OnPropertyChanged("ProductVersion");
			OnPropertyChanged("ProductVersionCustomized");
			OnPropertyChanged("ProductVersionValidationMessage");
			
			OnPropertyChanged("TemplatePath");
			OnPropertyChanged("TemplatePathCustomized");
			OnPropertyChanged("TemplatePathValidationMessage");
			
			OnPropertyChanged("Copyright");
			OnPropertyChanged("CopyrightCustomized");
			OnPropertyChanged("CopyrightValidationMessage");
			
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
				return DisplayValues.Edit_SolutionHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_SolutionHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SolutionIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SolutionIDLabel
		{
			get
			{
				return DisplayValues.Edit_SolutionIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SolutionNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SolutionNameLabel
		{
			get
			{
				return DisplayValues.Edit_SolutionNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SolutionName.</summary>
		///--------------------------------------------------------------------------------
		public string SolutionName
		{
			get
			{
				return EditSolution.SolutionName;
			}
			set
			{
				EditSolution.SolutionName = value;
				OnPropertyChanged("SolutionName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SolutionNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SolutionNameCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return SolutionName.GetString() != Solution.ReverseInstance.SolutionName.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return SolutionName.GetString() != Solution.SolutionName.GetString();
				}
				return SolutionName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SolutionNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SolutionNameValidationMessage
		{
			get
			{
				return EditSolution.ValidateSolutionName();
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
				return EditSolution.Namespace;
			}
			set
			{
				EditSolution.Namespace = value;
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
				if (Solution.ReverseInstance != null)
				{
					return Namespace.GetString() != Solution.ReverseInstance.Namespace.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return Namespace.GetString() != Solution.Namespace.GetString();
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
				return EditSolution.ValidateNamespace();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the OutputSolutionFileNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string OutputSolutionFileNameLabel
		{
			get
			{
				return DisplayValues.Edit_OutputSolutionFileNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets OutputSolutionFileName.</summary>
		///--------------------------------------------------------------------------------
		public string OutputSolutionFileName
		{
			get
			{
				return EditSolution.OutputSolutionFileName;
			}
			set
			{
				EditSolution.OutputSolutionFileName = value;
				OnPropertyChanged("OutputSolutionFileName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets OutputSolutionFileNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool OutputSolutionFileNameCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return OutputSolutionFileName.GetString() != Solution.ReverseInstance.OutputSolutionFileName.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return OutputSolutionFileName.GetString() != Solution.OutputSolutionFileName.GetString();
				}
				return OutputSolutionFileName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets OutputSolutionFileNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string OutputSolutionFileNameValidationMessage
		{
			get
			{
				return EditSolution.ValidateOutputSolutionFileName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the CompanyNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CompanyNameLabel
		{
			get
			{
				return DisplayValues.Edit_CompanyNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CompanyName.</summary>
		///--------------------------------------------------------------------------------
		public string CompanyName
		{
			get
			{
				return EditSolution.CompanyName;
			}
			set
			{
				EditSolution.CompanyName = value;
				OnPropertyChanged("CompanyName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets CompanyNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool CompanyNameCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return CompanyName.GetString() != Solution.ReverseInstance.CompanyName.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return CompanyName.GetString() != Solution.CompanyName.GetString();
				}
				return CompanyName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CompanyNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string CompanyNameValidationMessage
		{
			get
			{
				return EditSolution.ValidateCompanyName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProductNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ProductNameLabel
		{
			get
			{
				return DisplayValues.Edit_ProductNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProductName.</summary>
		///--------------------------------------------------------------------------------
		public string ProductName
		{
			get
			{
				return EditSolution.ProductName;
			}
			set
			{
				EditSolution.ProductName = value;
				OnPropertyChanged("ProductName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProductNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ProductNameCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return ProductName.GetString() != Solution.ReverseInstance.ProductName.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return ProductName.GetString() != Solution.ProductName.GetString();
				}
				return ProductName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProductNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ProductNameValidationMessage
		{
			get
			{
				return EditSolution.ValidateProductName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProductVersionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ProductVersionLabel
		{
			get
			{
				return DisplayValues.Edit_ProductVersionProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProductVersion.</summary>
		///--------------------------------------------------------------------------------
		public string ProductVersion
		{
			get
			{
				return EditSolution.ProductVersion;
			}
			set
			{
				EditSolution.ProductVersion = value;
				OnPropertyChanged("ProductVersion");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProductVersionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ProductVersionCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return ProductVersion.GetString() != Solution.ReverseInstance.ProductVersion.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return ProductVersion.GetString() != Solution.ProductVersion.GetString();
				}
				return ProductVersion != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ProductVersionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ProductVersionValidationMessage
		{
			get
			{
				return EditSolution.ValidateProductVersion();
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
				return EditSolution.TemplatePath;
			}
			set
			{
				EditSolution.TemplatePath = value;
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
				if (Solution.ReverseInstance != null)
				{
					return TemplatePath.GetString() != Solution.ReverseInstance.TemplatePath.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return TemplatePath.GetString() != Solution.TemplatePath.GetString();
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
				return EditSolution.ValidateTemplatePath();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the CopyrightLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CopyrightLabel
		{
			get
			{
				return DisplayValues.Edit_CopyrightProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Copyright.</summary>
		///--------------------------------------------------------------------------------
		public string Copyright
		{
			get
			{
				return EditSolution.Copyright;
			}
			set
			{
				EditSolution.Copyright = value;
				OnPropertyChanged("Copyright");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets CopyrightCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool CopyrightCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return Copyright.GetString() != Solution.ReverseInstance.Copyright.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return Copyright.GetString() != Solution.Copyright.GetString();
				}
				return Copyright != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CopyrightValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string CopyrightValidationMessage
		{
			get
			{
				return EditSolution.ValidateCopyright();
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
				return EditSolution.Description;
			}
			set
			{
				EditSolution.Description = value;
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
				if (Solution.ReverseInstance != null)
				{
					return Description.GetString() != Solution.ReverseInstance.Description.GetString();
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return Description.GetString() != Solution.Description.GetString();
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
				return EditSolution.ValidateDescription();
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
				return EditSolution.SourceName;
			}
			set
			{
				EditSolution.SourceName = value;
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
				return EditSolution.SpecSourceName;
			}
			set
			{
				EditSolution.SpecSourceName = value;
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
				return EditSolution.Tags;
			}
			set
			{
				EditSolution.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Solution.ReverseInstance != null)
				{
					return Tags != Solution.ReverseInstance.Tags;
				}
				else if (Solution.IsAutoUpdated == true)
				{
					return Tags != Solution.Tags;
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
				return EditSolution.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditSolution.Name;
			}
			set
			{
				EditSolution.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditSolution.TransformDataFromObject(Solution, null, false);
			EditSolution.ResetModified(false);
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
			if (Solution.ReverseInstance != null)
			{
				EditSolution.TransformDataFromObject(Solution.ReverseInstance, null, false);
			}
			else if (Solution.IsAutoUpdated == true)
			{
				EditSolution.TransformDataFromObject(Solution, null, false);
			}
			else
			{
				Solution newSolution = new Solution();
				newSolution.SolutionID = EditSolution.SolutionID;
				EditSolution.TransformDataFromObject(newSolution, null, false);
			}
			EditSolution.ResetModified(true);
			foreach (CollectionViewModel item in Items.OfType<CollectionViewModel>())
			{
				item.Defaults();
			}
			foreach (PropertyReferenceViewModel item in Items.OfType<PropertyReferenceViewModel>())
			{
				item.Defaults();
			}
			foreach (PropertyViewModel item in Items.OfType<PropertyViewModel>())
			{
				item.Defaults();
			}
			foreach (EntityReferenceViewModel item in Items.OfType<EntityReferenceViewModel>())
			{
				item.Defaults();
			}
			foreach (DatabaseSourceViewModel item in Items.OfType<DatabaseSourceViewModel>())
			{
				item.Defaults();
			}
			foreach (XmlSourceViewModel item in Items.OfType<XmlSourceViewModel>())
			{
				item.Defaults();
			}
			foreach (ProjectViewModel item in Items.OfType<ProjectViewModel>())
			{
				item.Defaults();
			}
			foreach (FeatureViewModel item in Items.OfType<FeatureViewModel>())
			{
				item.Defaults();
			}
			foreach (WorkflowViewModel item in Items.OfType<WorkflowViewModel>())
			{
				item.Defaults();
			}
			foreach (ModelViewModel item in Items.OfType<ModelViewModel>())
			{
				item.Defaults();
			}
			foreach (DiagramViewModel item in Items.OfType<DiagramViewModel>())
			{
				item.Defaults();
			}
			foreach (AuditPropertyViewModel item in Items.OfType<AuditPropertyViewModel>())
			{
				item.Defaults();
			}
			foreach (SpecTemplateViewModel item in Items.OfType<SpecTemplateViewModel>())
			{
				item.Defaults();
			}
			foreach (CodeTemplateViewModel item in Items.OfType<CodeTemplateViewModel>())
			{
				item.Defaults();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Solution command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewSolutionCommand()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = new Solution();
			message.Solution.SolutionID = Guid.NewGuid();
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_EditSolutionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditSolutionCommand()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_EditSolutionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewSolutionCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Solution.ReverseInstance == null && Solution.IsAutoUpdated == true)
			{
				Solution.ReverseInstance = new Solution();
				Solution.ReverseInstance.TransformDataFromObject(Solution, null, false);

				// perform the update of EditSolution back to Solution
				Solution.TransformDataFromObject(EditSolution, null, false);
				Solution.IsAutoUpdated = false;
			}
			else if (Solution.ReverseInstance != null)
			{
				EditSolution.ResetModified(Solution.ReverseInstance.IsModified);
				if (EditSolution.Equals(Solution.ReverseInstance))
				{
					// perform the update of EditSolution back to Solution
					Solution.TransformDataFromObject(EditSolution, null, false);
					Solution.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditSolution back to Solution
					Solution.TransformDataFromObject(EditSolution, null, false);
					Solution.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditSolution back to Solution
				Solution.TransformDataFromObject(EditSolution, null, false);
				Solution.IsAutoUpdated = false;
			}
			Solution.ForwardInstance = null;
			if (SolutionNameCustomized || NamespaceCustomized || OutputSolutionFileNameCustomized || CompanyNameCustomized || ProductNameCustomized || ProductVersionCustomized || TemplatePathCustomized || CopyrightCustomized || DescriptionCustomized || TagsCustomized)
			{
				Solution.ForwardInstance = new Solution();
				Solution.ForwardInstance.SolutionID = EditSolution.SolutionID;
				Solution.SpecSourceName = Solution.DefaultSourceName;
				if (SolutionNameCustomized)
				{
					Solution.ForwardInstance.SolutionName = EditSolution.SolutionName;
				}
				if (NamespaceCustomized)
				{
					Solution.ForwardInstance.Namespace = EditSolution.Namespace;
				}
				if (OutputSolutionFileNameCustomized)
				{
					Solution.ForwardInstance.OutputSolutionFileName = EditSolution.OutputSolutionFileName;
				}
				if (CompanyNameCustomized)
				{
					Solution.ForwardInstance.CompanyName = EditSolution.CompanyName;
				}
				if (ProductNameCustomized)
				{
					Solution.ForwardInstance.ProductName = EditSolution.ProductName;
				}
				if (ProductVersionCustomized)
				{
					Solution.ForwardInstance.ProductVersion = EditSolution.ProductVersion;
				}
				if (TemplatePathCustomized)
				{
					Solution.ForwardInstance.TemplatePath = EditSolution.TemplatePath;
				}
				if (CopyrightCustomized)
				{
					Solution.ForwardInstance.Copyright = EditSolution.Copyright;
				}
				if (DescriptionCustomized)
				{
					Solution.ForwardInstance.Description = EditSolution.Description;
				}
				if (TagsCustomized)
				{
					Solution.ForwardInstance.Tags = EditSolution.Tags;
				}
			}
			EditSolution.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditSolutionPerformed();

			// send update for any updated Projects
			if (ProjectsFolder != null && ProjectsFolder.IsEdited == true)
			{
				ProjectsFolder.Update();
			}

			// send update for any updated Features
			if (FeaturesFolder != null && FeaturesFolder.IsEdited == true)
			{
				FeaturesFolder.Update();
			}

			// send update for any updated Workflows
			if (WorkflowsFolder != null && WorkflowsFolder.IsEdited == true)
			{
				WorkflowsFolder.Update();
			}

			// send update for any updated Models
			if (ModelsFolder != null && ModelsFolder.IsEdited == true)
			{
				ModelsFolder.Update();
			}

			// send update for any updated Diagrams
			if (DiagramsFolder != null && DiagramsFolder.IsEdited == true)
			{
				DiagramsFolder.Update();
			}

			// send update for any updated AuditProperties
			if (AuditPropertiesFolder != null && AuditPropertiesFolder.IsEdited == true)
			{
				AuditPropertiesFolder.Update();
			}

			// send update for any updated SpecTemplates
			if (SpecTemplatesFolder != null && SpecTemplatesFolder.IsEdited == true)
			{
				SpecTemplatesFolder.Update();
			}

			// send update for any updated CodeTemplates
			if (CodeTemplatesFolder != null && CodeTemplatesFolder.IsEdited == true)
			{
				CodeTemplatesFolder.Update();
			}
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
		public void SendEditSolutionPerformed()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_EditSolutionPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Solution command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteSolutionCommand()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_DeleteSolutionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteSolutionCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SpecificationSource lists.</summary>
		///--------------------------------------------------------------------------------
		public SpecificationSourcesViewModel SpecificationSourcesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Project lists.</summary>
		///--------------------------------------------------------------------------------
		public ProjectsViewModel ProjectsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Feature lists.</summary>
		///--------------------------------------------------------------------------------
		public FeaturesViewModel FeaturesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Workflow lists.</summary>
		///--------------------------------------------------------------------------------
		public WorkflowsViewModel WorkflowsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Model lists.</summary>
		///--------------------------------------------------------------------------------
		public ModelsViewModel ModelsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Diagram lists.</summary>
		///--------------------------------------------------------------------------------
		public DiagramsViewModel DiagramsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets AuditProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public AuditPropertiesViewModel AuditPropertiesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SpecTemplate lists.</summary>
		///--------------------------------------------------------------------------------
		public SpecTemplatesViewModel SpecTemplatesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets CodeTemplate lists.</summary>
		///--------------------------------------------------------------------------------
		public CodeTemplatesViewModel CodeTemplatesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Solution.Name;
			}
			set
			{
				Solution.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Solution into the view model.</summary>
		/// 
		/// <param name="solution">The Solution to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadSolution(Solution solution, bool loadChildren = true)
		{
			// attach the Solution
			Solution = solution;
			ItemID = Solution.SolutionID;
			Items.Clear();
			if (loadChildren == true)
			{
				// attach SpecificationSources
				if (SpecificationSourcesFolder == null)
				{
					SpecificationSourcesFolder = new SpecificationSourcesViewModel(solution);
					SpecificationSourcesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(SpecificationSourcesFolder);
				}
								
				// attach Projects
				if (ProjectsFolder == null)
				{
					ProjectsFolder = new ProjectsViewModel(solution);
					ProjectsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(ProjectsFolder);
				}
								
				// attach Features
				if (FeaturesFolder == null)
				{
					FeaturesFolder = new FeaturesViewModel(solution);
					FeaturesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(FeaturesFolder);
				}
								
				// attach Workflows
				if (WorkflowsFolder == null)
				{
					WorkflowsFolder = new WorkflowsViewModel(solution);
					WorkflowsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(WorkflowsFolder);
				}
								
				// attach Models
				if (ModelsFolder == null)
				{
					ModelsFolder = new ModelsViewModel(solution);
					ModelsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(ModelsFolder);
				}
								
				// attach Diagrams
				if (DiagramsFolder == null)
				{
					DiagramsFolder = new DiagramsViewModel(solution);
					DiagramsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(DiagramsFolder);
				}
								
				// attach AuditProperties
				if (AuditPropertiesFolder == null)
				{
					AuditPropertiesFolder = new AuditPropertiesViewModel(solution);
					AuditPropertiesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(AuditPropertiesFolder);
				}
								
				// attach SpecTemplates
				if (SpecTemplatesFolder == null)
				{
					SpecTemplatesFolder = new SpecTemplatesViewModel(solution, ModelContextTypeCode.Solution.ToString());
					SpecTemplatesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(SpecTemplatesFolder);
				}
								
				// attach CodeTemplates
				if (CodeTemplatesFolder == null)
				{
					CodeTemplatesFolder = new CodeTemplatesViewModel(solution, ModelContextTypeCode.Solution.ToString());
					CodeTemplatesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(CodeTemplatesFolder);
				}
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
				SpecificationSourcesFolder.Refresh(refreshChildren, refreshLevel - 1);
				ProjectsFolder.Refresh(refreshChildren, refreshLevel - 1);
				FeaturesFolder.Refresh(refreshChildren, refreshLevel - 1);
				WorkflowsFolder.Refresh(refreshChildren, refreshLevel - 1);
				ModelsFolder.Refresh(refreshChildren, refreshLevel - 1);
				DiagramsFolder.Refresh(refreshChildren, refreshLevel - 1);
				AuditPropertiesFolder.Refresh(refreshChildren, refreshLevel - 1);
				SpecTemplatesFolder.Refresh(refreshChildren, refreshLevel - 1);
				CodeTemplatesFolder.Refresh(refreshChildren, refreshLevel - 1);
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Solution.IsValid;
			HasCustomizations = Solution.IsAutoUpdated == false || Solution.IsEmptyMetadata(Solution.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Solution.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Solution.IsAutoUpdated = true;
				Solution.SpecSourceName = Solution.ReverseInstance.SpecSourceName;
				Solution.ResetModified(Solution.ReverseInstance.IsModified);
				Solution.ResetLoaded(Solution.ReverseInstance.IsLoaded);
				if (!Solution.IsIdenticalMetadata(Solution.ReverseInstance))
				{
					HasCustomizations = true;
					Solution.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Solution.ForwardInstance = null;
				Solution.ReverseInstance = null;
				Solution.IsAutoUpdated = true;
			}
			if (SpecificationSourcesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (ProjectsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (FeaturesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (WorkflowsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (ModelsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (DiagramsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (AuditPropertiesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (SpecTemplatesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (CodeTemplatesFolder.HasErrors == true)
			{
				HasErrors = true;
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
			#region protected
			if (Solution != null)
			{
				Solution.StatusChanged -= Solution_StatusChanged;
				Solution.OutputRequested -= Solution_OutputRequested;
				Solution.BreakpointReached -= Solution_BreakpointReached;
			}
			#endregion protected
			
			if (SpecificationSourcesFolder != null)
			{
				SpecificationSourcesFolder.Updated -= Children_Updated;
				SpecificationSourcesFolder.Dispose();
				SpecificationSourcesFolder = null;
			}
			if (ProjectsFolder != null)
			{
				ProjectsFolder.Updated -= Children_Updated;
				ProjectsFolder.Dispose();
				ProjectsFolder = null;
			}
			if (FeaturesFolder != null)
			{
				FeaturesFolder.Updated -= Children_Updated;
				FeaturesFolder.Dispose();
				FeaturesFolder = null;
			}
			if (WorkflowsFolder != null)
			{
				WorkflowsFolder.Updated -= Children_Updated;
				WorkflowsFolder.Dispose();
				WorkflowsFolder = null;
			}
			if (ModelsFolder != null)
			{
				ModelsFolder.Updated -= Children_Updated;
				ModelsFolder.Dispose();
				ModelsFolder = null;
			}
			if (DiagramsFolder != null)
			{
				DiagramsFolder.Updated -= Children_Updated;
				DiagramsFolder.Dispose();
				DiagramsFolder = null;
			}
			if (AuditPropertiesFolder != null)
			{
				AuditPropertiesFolder.Updated -= Children_Updated;
				AuditPropertiesFolder.Dispose();
				AuditPropertiesFolder = null;
			}
			if (SpecTemplatesFolder != null)
			{
				SpecTemplatesFolder.Updated -= Children_Updated;
				SpecTemplatesFolder.Dispose();
				SpecTemplatesFolder = null;
			}
			if (CodeTemplatesFolder != null)
			{
				CodeTemplatesFolder.Updated -= Children_Updated;
				CodeTemplatesFolder.Dispose();
				CodeTemplatesFolder = null;
			}
			if (_editSolution != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditSolution.PropertyChanged -= EditSolution_PropertyChanged;
				EditSolution = null;
			}
			Solution = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			if (SpecificationSourcesFolder != null && SpecificationSourcesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (ProjectsFolder != null && ProjectsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (FeaturesFolder != null && FeaturesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (WorkflowsFolder != null && WorkflowsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (ModelsFolder != null && ModelsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (DiagramsFolder != null && DiagramsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (AuditPropertiesFolder != null && AuditPropertiesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (SpecTemplatesFolder != null && SpecTemplatesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (CodeTemplatesFolder != null && CodeTemplatesFolder.HasCustomizations == true)
			{
				return true;
			}
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
			EditWorkspaceViewModel parentModel = null;
			parentModel = SpecificationSourcesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = ProjectsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = FeaturesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = WorkflowsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = ModelsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = DiagramsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = AuditPropertiesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = SpecTemplatesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = CodeTemplatesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SolutionViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public SolutionViewModel(Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadSolution(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
