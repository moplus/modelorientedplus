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

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for Model instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/20/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlModelToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelModelToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEnumeration.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEnumeration
		{
			get
			{
				return DisplayValues.ContextMenu_NewEnumeration;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEnumerationToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEnumerationToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEnumerationToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelObject.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelObject
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObject;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelObjectToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelObjectToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObjectToolTip;
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
				if (EditModel.IsModified == true)
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
				return string.IsNullOrEmpty(ModelNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Model _editModel = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditModel.</summary>
		///--------------------------------------------------------------------------------
		public Model EditModel
		{
			get
			{
				if (_editModel == null)
				{
					_editModel = new Model();
					_editModel.PropertyChanged += new PropertyChangedEventHandler(EditModel_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Model != null)
					{
						_editModel.TransformDataFromObject(Model, null, false);
						_editModel.Solution = Model.Solution;
					}
					_editModel.ResetModified(false);
				}
				return _editModel;
			}
			set
			{
				_editModel = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditModel");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ModelName");
			OnPropertyChanged("ModelNameCustomized");
			OnPropertyChanged("ModelNameValidationMessage");
			
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
				return DisplayValues.Edit_ModelHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ModelHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelIDLabel
		{
			get
			{
				return DisplayValues.Edit_ModelIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelNameLabel
		{
			get
			{
				return DisplayValues.Edit_ModelNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelName.</summary>
		///--------------------------------------------------------------------------------
		public string ModelName
		{
			get
			{
				return EditModel.ModelName;
			}
			set
			{
				EditModel.ModelName = value;
				OnPropertyChanged("ModelName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelNameCustomized
		{
			get
			{
				if (Model.ReverseInstance != null)
				{
					return ModelName.GetString() != Model.ReverseInstance.ModelName.GetString();
				}
				else if (Model.IsAutoUpdated == true)
				{
					return ModelName.GetString() != Model.ModelName.GetString();
				}
				return ModelName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelNameValidationMessage
		{
			get
			{
				return EditModel.ValidateModelName();
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
				return EditModel.Description;
			}
			set
			{
				EditModel.Description = value;
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
				if (Model.ReverseInstance != null)
				{
					return Description.GetString() != Model.ReverseInstance.Description.GetString();
				}
				else if (Model.IsAutoUpdated == true)
				{
					return Description.GetString() != Model.Description.GetString();
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
				return EditModel.ValidateDescription();
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
				return EditModel.SourceName;
			}
			set
			{
				EditModel.SourceName = value;
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
				return EditModel.SpecSourceName;
			}
			set
			{
				EditModel.SpecSourceName = value;
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
				return EditModel.Tags;
			}
			set
			{
				EditModel.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Model.ReverseInstance != null)
				{
					return Tags != Model.ReverseInstance.Tags;
				}
				else if (Model.IsAutoUpdated == true)
				{
					return Tags != Model.Tags;
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
				return EditModel.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditModel.Name;
			}
			set
			{
				EditModel.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditModel.TransformDataFromObject(Model, null, false);
			EditModel.ResetModified(false);
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
			if (Model.ReverseInstance != null)
			{
				EditModel.TransformDataFromObject(Model.ReverseInstance, null, false);
			}
			else if (Model.IsAutoUpdated == true)
			{
				EditModel.TransformDataFromObject(Model, null, false);
			}
			else
			{
				Model newModel = new Model();
				newModel.ModelID = EditModel.ModelID;
				EditModel.TransformDataFromObject(newModel, null, false);
			}
			EditModel.ResetModified(true);
			foreach (EnumerationViewModel item in Items.OfType<EnumerationViewModel>())
			{
				item.Defaults();
			}
			foreach (ModelObjectViewModel item in Items.OfType<ModelObjectViewModel>())
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
		/// <summary>This method processes the new Model command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelCommand()
		{
			ModelEventArgs message = new ModelEventArgs();
			message.Model = new Model();
			message.Model.ModelID = Guid.NewGuid();
			message.Model.SolutionID = SolutionID;
			message.Model.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_EditModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelCommand()
		{
			ModelEventArgs message = new ModelEventArgs();
			message.Model = Model;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_EditModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewModelCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Model.ReverseInstance == null && Model.IsAutoUpdated == true)
			{
				Model.ReverseInstance = new Model();
				Model.ReverseInstance.TransformDataFromObject(Model, null, false);

				// perform the update of EditModel back to Model
				Model.TransformDataFromObject(EditModel, null, false);
				Model.IsAutoUpdated = false;
			}
			else if (Model.ReverseInstance != null)
			{
				EditModel.ResetModified(Model.ReverseInstance.IsModified);
				if (EditModel.Equals(Model.ReverseInstance))
				{
					// perform the update of EditModel back to Model
					Model.TransformDataFromObject(EditModel, null, false);
					Model.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditModel back to Model
					Model.TransformDataFromObject(EditModel, null, false);
					Model.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditModel back to Model
				Model.TransformDataFromObject(EditModel, null, false);
				Model.IsAutoUpdated = false;
			}
			Model.ForwardInstance = null;
			if (ModelNameCustomized || DescriptionCustomized || TagsCustomized)
			{
				Model.ForwardInstance = new Model();
				Model.ForwardInstance.ModelID = EditModel.ModelID;
				Model.SpecSourceName = Model.DefaultSourceName;
				if (ModelNameCustomized)
				{
					Model.ForwardInstance.ModelName = EditModel.ModelName;
				}
				if (DescriptionCustomized)
				{
					Model.ForwardInstance.Description = EditModel.Description;
				}
				if (TagsCustomized)
				{
					Model.ForwardInstance.Tags = EditModel.Tags;
				}
			}
			EditModel.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditModelPerformed();

			// send update for any updated Enumerations
			if (EnumerationsFolder != null && EnumerationsFolder.IsEdited == true)
			{
				EnumerationsFolder.Update();
			}

			// send update for any updated ModelObjects
			if (ModelObjectsFolder != null && ModelObjectsFolder.IsEdited == true)
			{
				ModelObjectsFolder.Update();
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
		public void SendEditModelPerformed()
		{
			ModelEventArgs message = new ModelEventArgs();
			message.Model = Model;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_EditModelPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Model command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelCommand()
		{
			ModelEventArgs message = new ModelEventArgs();
			message.Model = Model;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_DeleteModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteModelCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Enumeration lists.</summary>
		///--------------------------------------------------------------------------------
		public EnumerationsViewModel EnumerationsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObject lists.</summary>
		///--------------------------------------------------------------------------------
		public ModelObjectsViewModel ModelObjectsFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Model.</summary>
		///--------------------------------------------------------------------------------
		public Model Model { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelID
		{
			get
			{
				return Model.ModelID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Model.Name;
			}
			set
			{
				Model.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Model into the view model.</summary>
		/// 
		/// <param name="model">The Model to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModel(Model model, bool loadChildren = true)
		{
			// attach the Model
			Model = model;
			ItemID = Model.ModelID;
			Items.Clear();
			if (loadChildren == true)
			{
				// attach Enumerations
				if (EnumerationsFolder == null)
				{
					EnumerationsFolder = new EnumerationsViewModel(model, Solution);
					EnumerationsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(EnumerationsFolder);
				}
								
				// attach ModelObjects
				if (ModelObjectsFolder == null)
				{
					ModelObjectsFolder = new ModelObjectsViewModel(model, Solution);
					ModelObjectsFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(ModelObjectsFolder);
				}
				#region protected
				// attach ModelData
				if (ModelDataFolder == null)
				{
					ModelDataFolder = new ModelDataViewModel(model, Solution);
					ModelDataFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(ModelDataFolder);
				}
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
				EnumerationsFolder.Refresh(refreshChildren, refreshLevel - 1);
				ModelObjectsFolder.Refresh(refreshChildren, refreshLevel - 1);
			}
			
			#region protected
			if (refreshChildren == true || refreshLevel > 0)
			{
				ModelDataFolder.Refresh(refreshChildren, refreshLevel - 1);
			}

			#endregion protected
			
			HasErrors = !Model.IsValid;
			HasCustomizations = Model.IsAutoUpdated == false || Model.IsEmptyMetadata(Model.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Model.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Model.IsAutoUpdated = true;
				Model.SpecSourceName = Model.ReverseInstance.SpecSourceName;
				Model.ResetModified(Model.ReverseInstance.IsModified);
				Model.ResetLoaded(Model.ReverseInstance.IsLoaded);
				if (!Model.IsIdenticalMetadata(Model.ReverseInstance))
				{
					HasCustomizations = true;
					Model.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Model.ForwardInstance = null;
				Model.ReverseInstance = null;
				Model.IsAutoUpdated = true;
			}
			if (EnumerationsFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (ModelObjectsFolder.HasErrors == true)
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
			if (EnumerationsFolder != null)
			{
				EnumerationsFolder.Updated -= Children_Updated;
				EnumerationsFolder.Dispose();
				EnumerationsFolder = null;
			}
			if (ModelObjectsFolder != null)
			{
				ModelObjectsFolder.Updated -= Children_Updated;
				ModelObjectsFolder.Dispose();
				ModelObjectsFolder = null;
			}
			if (_editModel != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditModel.PropertyChanged -= EditModel_PropertyChanged;
				EditModel = null;
			}
			Model = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			if (EnumerationsFolder != null && EnumerationsFolder.HasCustomizations == true)
			{
				return true;
			}
			if (ModelObjectsFolder != null && ModelObjectsFolder.HasCustomizations == true)
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
			parentModel = EnumerationsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = ModelObjectsFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			#region protected
			parentModel = ModelDataFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			#endregion protected
		
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="model">The Model to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ModelViewModel(Model model, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadModel(model, loadChildren);
		}

		#endregion "Constructors"
	}
}
