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
	/// <summary>This class provides views for ModelObject instances.</summary>
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
	public partial class ModelObjectViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlModelObjectToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelModelObjectToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObjectToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelPropertyToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewObjectInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstance;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewObjectInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewObjectInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstanceToolTip;
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
				if (EditModelObject.IsModified == true)
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
				return string.IsNullOrEmpty(ModelObjectNameValidationMessage + ParentModelObjectIDValidationMessage + DescriptionValidationMessage + ModelPropertyListValidationMessage);
			}
		}
 
		private ModelObject _editModelObject = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditModelObject.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject EditModelObject
		{
			get
			{
				if (_editModelObject == null)
				{
					_editModelObject = new ModelObject();
					_editModelObject.PropertyChanged += new PropertyChangedEventHandler(EditModelObject_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (ModelObject != null)
					{
						_editModelObject.TransformDataFromObject(ModelObject, null, false);
						_editModelObject.Solution = ModelObject.Solution;
						_editModelObject.Model = ModelObject.Model;
					}
					_editModelObject.ResetModified(false);
				}
				return _editModelObject;
			}
			set
			{
				_editModelObject = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditModelObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditModelObject");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ModelObjectName");
			OnPropertyChanged("ModelObjectNameCustomized");
			OnPropertyChanged("ModelObjectNameValidationMessage");
			
			OnPropertyChanged("ParentModelObjectID");
			OnPropertyChanged("ParentModelObjectIDCustomized");
			OnPropertyChanged("ParentModelObjectIDValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ModelPropertyList");
			OnPropertyChanged("ModelPropertyListCustomized");
			OnPropertyChanged("ModelPropertyListValidationMessage");

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
				return DisplayValues.Edit_ModelObjectHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ModelObjectHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelObjectIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectIDLabel
		{
			get
			{
				return DisplayValues.Edit_ModelObjectIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyListLabel
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelPropertyList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelProperty> ModelPropertyList
		{
			get
			{
				return EditModelObject.ModelPropertyList;
			}
			set
			{
				EditModelObject.ModelPropertyList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelPropertyListCustomized
		{
			get
			{
				#region protected
				foreach (ModelPropertyViewModel item in Items.OfType<ModelPropertyViewModel>())
				{
					if (item.HasCustomizations == true || item.ModelProperty.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelObjectNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectNameLabel
		{
			get
			{
				return DisplayValues.Edit_ModelObjectNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelObjectName.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectName
		{
			get
			{
				return EditModelObject.ModelObjectName;
			}
			set
			{
				EditModelObject.ModelObjectName = value;
				OnPropertyChanged("ModelObjectName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelObjectNameCustomized
		{
			get
			{
				if (ModelObject.ReverseInstance != null)
				{
					return ModelObjectName.GetString() != ModelObject.ReverseInstance.ModelObjectName.GetString();
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return ModelObjectName.GetString() != ModelObject.ModelObjectName.GetString();
				}
				return ModelObjectName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelObjectNameValidationMessage
		{
			get
			{
				return EditModelObject.ValidateModelObjectName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParentModelObjectIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParentModelObjectIDLabel
		{
			get
			{
				return DisplayValues.Edit_ParentModelObjectIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ParentModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? ParentModelObjectID
		{
			get
			{
				return EditModelObject.ParentModelObjectID;
			}
			set
			{
				EditModelObject.ParentModelObjectID = value;
				OnPropertyChanged("ParentModelObjectID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParentModelObjectIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ParentModelObjectIDCustomized
		{
			get
			{
				if (ModelObject.ReverseInstance != null)
				{
					return ParentModelObjectID.GetGuid() != ModelObject.ReverseInstance.ParentModelObjectID.GetGuid();
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return ParentModelObjectID.GetGuid() != ModelObject.ParentModelObjectID.GetGuid();
				}
				return ParentModelObjectID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParentModelObjectIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ParentModelObjectIDValidationMessage
		{
			get
			{
				return EditModelObject.ValidateParentModelObjectID();
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
				return EditModelObject.Description;
			}
			set
			{
				EditModelObject.Description = value;
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
				if (ModelObject.ReverseInstance != null)
				{
					return Description.GetString() != ModelObject.ReverseInstance.Description.GetString();
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return Description.GetString() != ModelObject.Description.GetString();
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
				return EditModelObject.ValidateDescription();
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
				return EditModelObject.SourceName;
			}
			set
			{
				EditModelObject.SourceName = value;
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
				return EditModelObject.SpecSourceName;
			}
			set
			{
				EditModelObject.SpecSourceName = value;
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
				return EditModelObject.Tags;
			}
			set
			{
				EditModelObject.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (ModelObject.ReverseInstance != null)
				{
					return Tags != ModelObject.ReverseInstance.Tags;
				}
				else if (ModelObject.IsAutoUpdated == true)
				{
					return Tags != ModelObject.Tags;
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
				return EditModelObject.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditModelObject.Name;
			}
			set
			{
				EditModelObject.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditModelObject.TransformDataFromObject(ModelObject, null, false);
			ResetItems();
			
			#region protected
			ModelPropertyItems.Clear();
			_modelPropertyItems = null;
			OnPropertyChanged("ModelPropertyItems");
			#endregion protected

			EditModelObject.ResetModified(false);
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
			if (ModelObject.ReverseInstance != null)
			{
				EditModelObject.TransformDataFromObject(ModelObject.ReverseInstance, null, false);
			}
			else if (ModelObject.IsAutoUpdated == true)
			{
				EditModelObject.TransformDataFromObject(ModelObject, null, false);
			}
			else
			{
				ModelObject newModelObject = new ModelObject();
				newModelObject.ModelObjectID = EditModelObject.ModelObjectID;
				EditModelObject.TransformDataFromObject(newModelObject, null, false);
			}
			EditModelObject.ResetModified(true);
			foreach (ModelPropertyViewModel item in Items.OfType<ModelPropertyViewModel>())
			{
				item.Defaults();
			}
			foreach (ObjectInstanceViewModel item in Items.OfType<ObjectInstanceViewModel>())
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
		/// <summary>This method processes the new ModelObject command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = new ModelObject();
			message.ModelObject.ModelObjectID = Guid.NewGuid();
			message.ModelObject.ModelID = ModelID;
			message.ModelObject.Model = Solution.ModelList.FindByID((Guid)ModelID);
			message.ModelObject.Solution = Solution;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = ModelObject;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewModelObjectCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (ModelObject.ReverseInstance == null && ModelObject.IsAutoUpdated == true)
			{
				ModelObject.ReverseInstance = new ModelObject();
				ModelObject.ReverseInstance.TransformDataFromObject(ModelObject, null, false);

				// perform the update of EditModelObject back to ModelObject
				ModelObject.TransformDataFromObject(EditModelObject, null, false);
				ModelObject.IsAutoUpdated = false;
			}
			else if (ModelObject.ReverseInstance != null)
			{
				EditModelObject.ResetModified(ModelObject.ReverseInstance.IsModified);
				if (EditModelObject.Equals(ModelObject.ReverseInstance))
				{
					// perform the update of EditModelObject back to ModelObject
					ModelObject.TransformDataFromObject(EditModelObject, null, false);
					ModelObject.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditModelObject back to ModelObject
					ModelObject.TransformDataFromObject(EditModelObject, null, false);
					ModelObject.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditModelObject back to ModelObject
				ModelObject.TransformDataFromObject(EditModelObject, null, false);
				ModelObject.IsAutoUpdated = false;
			}
			ModelObject.ForwardInstance = null;
			if (ModelObjectNameCustomized || ParentModelObjectIDCustomized || DescriptionCustomized || ModelPropertyListCustomized || TagsCustomized)
			{
				ModelObject.ForwardInstance = new ModelObject();
				ModelObject.ForwardInstance.ModelObjectID = EditModelObject.ModelObjectID;
				ModelObject.SpecSourceName = ModelObject.DefaultSourceName;
				if (ModelObjectNameCustomized)
				{
					ModelObject.ForwardInstance.ModelObjectName = EditModelObject.ModelObjectName;
				}
				if (ParentModelObjectIDCustomized)
				{
					ModelObject.ForwardInstance.ParentModelObjectID = EditModelObject.ParentModelObjectID;
				}
				if (DescriptionCustomized)
				{
					ModelObject.ForwardInstance.Description = EditModelObject.Description;
				}
				if (ModelPropertyListCustomized)
				{
					#region protected
					#endregion protected
					// ModelObject.ModelPropertyList = new EnterpriseDataObjectList<ModelProperty>(EditModelObject.ModelPropertyList, null);
					// ModelObject.ForwardInstance.ModelPropertyList = new EnterpriseDataObjectList<ModelProperty>(EditModelObject.ModelPropertyList, null);
				}
				if (TagsCustomized)
				{
					ModelObject.ForwardInstance.Tags = EditModelObject.Tags;
				}
			}
			EditModelObject.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditModelObjectPerformed();

			// send update for any updated ModelProperties
			if (ModelPropertiesFolder != null && ModelPropertiesFolder.IsEdited == true)
			{
				ModelPropertiesFolder.Update();
			}

			// send update for any updated ObjectInstances
			if (ObjectInstancesFolder != null && ObjectInstancesFolder.IsEdited == true)
			{
				ObjectInstancesFolder.Update();
			}
			
			#region protected
			Solution.CodeTemplateContentParser = null;
			Solution.CodeTemplatOutputParser = null;
			Solution.ModelObjectNames = null;
			Solution.ModelPropertyNames = null;
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
		public void SendEditModelObjectPerformed()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = ModelObject;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete ModelObject command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = ModelObject;
			message.ModelID = ModelID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_DeleteModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteModelObjectCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public ModelPropertiesViewModel ModelPropertiesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ObjectInstance lists.</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstancesViewModel ObjectInstancesFolder { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelObject.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject ModelObject { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelObjectID
		{
			get
			{
				return ModelObject.ModelObjectID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return ModelObject.Name;
			}
			set
			{
				ModelObject.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelID
		{
			get
			{
				return ModelObject.ModelID;
			}
			set
			{
				ModelObject.ModelID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of ModelObject into the view model.</summary>
		/// 
		/// <param name="modelObject">The ModelObject to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelObject(ModelObject modelObject, bool loadChildren = true)
		{
			// attach the ModelObject
			ModelObject = modelObject;
			ItemID = ModelObject.ModelObjectID;
			Items.Clear();
			if (loadChildren == true)
			{
				// attach ModelProperties
				if (ModelPropertiesFolder == null)
				{
					ModelPropertiesFolder = new ModelPropertiesViewModel(modelObject, Solution);
					ModelPropertiesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(ModelPropertiesFolder);
				}
								
				// attach ObjectInstances
				if (ObjectInstancesFolder == null)
				{
					ObjectInstancesFolder = new ObjectInstancesViewModel(modelObject, Solution);
					ObjectInstancesFolder.Updated += new EventHandler(Children_Updated);
					Items.Add(ObjectInstancesFolder);
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
				ModelPropertiesFolder.Refresh(refreshChildren, refreshLevel - 1);
				ObjectInstancesFolder.Refresh(refreshChildren, refreshLevel - 1);
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !ModelObject.IsValid;
			HasCustomizations = ModelObject.IsAutoUpdated == false || ModelObject.IsEmptyMetadata(ModelObject.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && ModelObject.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				ModelObject.IsAutoUpdated = true;
				ModelObject.SpecSourceName = ModelObject.ReverseInstance.SpecSourceName;
				ModelObject.ResetModified(ModelObject.ReverseInstance.IsModified);
				ModelObject.ResetLoaded(ModelObject.ReverseInstance.IsLoaded);
				if (!ModelObject.IsIdenticalMetadata(ModelObject.ReverseInstance))
				{
					HasCustomizations = true;
					ModelObject.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				ModelObject.ForwardInstance = null;
				ModelObject.ReverseInstance = null;
				ModelObject.IsAutoUpdated = true;
			}
			if (ModelPropertiesFolder.HasErrors == true)
			{
				HasErrors = true;
			}
			if (ObjectInstancesFolder.HasErrors == true)
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
			if (ModelPropertiesFolder != null)
			{
				ModelPropertiesFolder.Updated -= Children_Updated;
				ModelPropertiesFolder.Dispose();
				ModelPropertiesFolder = null;
			}
			if (ObjectInstancesFolder != null)
			{
				ObjectInstancesFolder.Updated -= Children_Updated;
				ObjectInstancesFolder.Dispose();
				ObjectInstancesFolder = null;
			}
			if (_editModelObject != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditModelObject.PropertyChanged -= EditModelObject_PropertyChanged;
				EditModelObject = null;
			}
			ModelObject = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			if (ModelPropertiesFolder != null && ModelPropertiesFolder.HasCustomizations == true)
			{
				return true;
			}
			if (ObjectInstancesFolder != null && ObjectInstancesFolder.HasCustomizations == true)
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
			parentModel = ModelPropertiesFolder.FindParentViewModel(data);
			if (parentModel != null)
			{
				return parentModel;
			}
			parentModel = ObjectInstancesFolder.FindParentViewModel(data);
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
		public ModelObjectViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="modelObject">The ModelObject to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ModelObjectViewModel(ModelObject modelObject, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadModelObject(modelObject, loadChildren);
		}

		#endregion "Constructors"
	}
}
