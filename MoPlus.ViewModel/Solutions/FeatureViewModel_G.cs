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
	/// <summary>This class provides views for Feature instances.</summary>
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
	public partial class FeatureViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlFeatureToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelFeatureToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewFeatureToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntity.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntity
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntity;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntityToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntityToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntityToolTip;
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
				if (EditFeature.IsModified == true)
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
				return string.IsNullOrEmpty(FeatureNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Feature _editFeature = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditFeature.</summary>
		///--------------------------------------------------------------------------------
		public Feature EditFeature
		{
			get
			{
				if (_editFeature == null)
				{
					_editFeature = new Feature();
					_editFeature.PropertyChanged += new PropertyChangedEventHandler(EditFeature_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Feature != null)
					{
						_editFeature.TransformDataFromObject(Feature, null, false);
						_editFeature.Solution = Feature.Solution;
					}
					_editFeature.ResetModified(false);
				}
				return _editFeature;
			}
			set
			{
				_editFeature = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditFeature_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditFeature");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("FeatureName");
			OnPropertyChanged("FeatureNameCustomized");
			OnPropertyChanged("FeatureNameValidationMessage");
			
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
				return DisplayValues.Edit_FeatureHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_FeatureHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the FeatureIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string FeatureIDLabel
		{
			get
			{
				return DisplayValues.Edit_FeatureIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the FeatureNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string FeatureNameLabel
		{
			get
			{
				return DisplayValues.Edit_FeatureNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets FeatureName.</summary>
		///--------------------------------------------------------------------------------
		public string FeatureName
		{
			get
			{
				return EditFeature.FeatureName;
			}
			set
			{
				EditFeature.FeatureName = value;
				OnPropertyChanged("FeatureName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets FeatureNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool FeatureNameCustomized
		{
			get
			{
				if (Feature.ReverseInstance != null)
				{
					return FeatureName.GetString() != Feature.ReverseInstance.FeatureName.GetString();
				}
				else if (Feature.IsAutoUpdated == true)
				{
					return FeatureName.GetString() != Feature.FeatureName.GetString();
				}
				return FeatureName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FeatureNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string FeatureNameValidationMessage
		{
			get
			{
				return EditFeature.ValidateFeatureName();
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
				return EditFeature.Description;
			}
			set
			{
				EditFeature.Description = value;
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
				if (Feature.ReverseInstance != null)
				{
					return Description.GetString() != Feature.ReverseInstance.Description.GetString();
				}
				else if (Feature.IsAutoUpdated == true)
				{
					return Description.GetString() != Feature.Description.GetString();
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
				return EditFeature.ValidateDescription();
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
				return EditFeature.SourceName;
			}
			set
			{
				EditFeature.SourceName = value;
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
				return EditFeature.SpecSourceName;
			}
			set
			{
				EditFeature.SpecSourceName = value;
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
				return EditFeature.Tags;
			}
			set
			{
				EditFeature.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Feature.ReverseInstance != null)
				{
					return Tags != Feature.ReverseInstance.Tags;
				}
				else if (Feature.IsAutoUpdated == true)
				{
					return Tags != Feature.Tags;
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
				return EditFeature.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditFeature.Name;
			}
			set
			{
				EditFeature.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditFeature.TransformDataFromObject(Feature, null, false);
			EditFeature.ResetModified(false);
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
			if (Feature.ReverseInstance != null)
			{
				EditFeature.TransformDataFromObject(Feature.ReverseInstance, null, false);
			}
			else if (Feature.IsAutoUpdated == true)
			{
				EditFeature.TransformDataFromObject(Feature, null, false);
			}
			else
			{
				Feature newFeature = new Feature();
				newFeature.FeatureID = EditFeature.FeatureID;
				EditFeature.TransformDataFromObject(newFeature, null, false);
			}
			EditFeature.ResetModified(true);
			foreach (EntityViewModel item in Items.OfType<EntityViewModel>())
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
		/// <summary>This method processes the new Feature command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewFeatureCommand()
		{
			FeatureEventArgs message = new FeatureEventArgs();
			message.Feature = new Feature();
			message.Feature.FeatureID = Guid.NewGuid();
			message.Feature.SolutionID = SolutionID;
			message.Feature.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<FeatureEventArgs>(MediatorMessages.Command_EditFeatureRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditFeatureCommand()
		{
			FeatureEventArgs message = new FeatureEventArgs();
			message.Feature = Feature;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<FeatureEventArgs>(MediatorMessages.Command_EditFeatureRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Entity adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewEntity()
		{
			EntityViewModel item = new EntityViewModel();
			item.Entity = new Entity();
			item.Entity.EntityID = Guid.NewGuid();
			item.Entity.Feature = EditFeature;
			item.Entity.FeatureID = EditFeature.FeatureID;
			item.Entity.Solution = Solution;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Entity command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewEntityCommand()
		{
			EntityEventArgs message = new EntityEventArgs();
			message.Entity = new Entity();
			message.Entity.EntityID = Guid.NewGuid();
			message.Entity.Feature = Feature;
			message.Entity.FeatureID = Feature.FeatureID;
			message.FeatureID = Feature.FeatureID;
			message.Entity.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EntityEventArgs>(MediatorMessages.Command_EditEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Entity updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditEntityPerformed(EntityEventArgs data)
		{
			if (data != null && data.Entity != null)
			{
				UpdateEditEntity(data.Entity);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of Entity.</summary>
		/// 
		/// <param name="entity">The Entity to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditEntity(Entity entity)
		{
			bool isItemMatch = false;
			foreach (EntityViewModel item in Entities)
			{
				if (item.Entity.EntityID == entity.EntityID)
				{
					isItemMatch = true;
					item.Entity.TransformDataFromObject(entity, null, false);
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new Entity
				entity.Feature = Feature;
				EntityViewModel newItem = new EntityViewModel(entity, Solution);
				newItem.Updated += new EventHandler(Children_Updated);
				Entities.Add(newItem);
				Feature.EntityList.Add(entity);
				Solution.EntityList.Add(newItem.Entity);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Entity deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedEntities(EntityViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Entity deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteEntityPerformed(EntityEventArgs data)
		{
			if (data != null && data.Entity != null)
			{
				DeleteEntity(data.Entity);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Entity.</summary>
		/// 
		/// <param name="entity">The Entity to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteEntity(Entity entity)
		{
			bool isItemMatch = false;
			foreach (EntityViewModel item in Entities.ToList<EntityViewModel>())
			{
				if (item.Entity.EntityID == entity.EntityID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.Entity.EntityID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete Entity
					isItemMatch = true;
					Entities.Remove(item);
					Feature.EntityList.Remove(item.Entity);
					Solution.EntityList.Remove(item.Entity);
					Items.Remove(item);
					Feature.ResetModified(true);
					OnUpdated(this, null);
					break;
				}
			}
			if (isItemMatch == false)
			{
				ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewFeatureCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Feature.ReverseInstance == null && Feature.IsAutoUpdated == true)
			{
				Feature.ReverseInstance = new Feature();
				Feature.ReverseInstance.TransformDataFromObject(Feature, null, false);

				// perform the update of EditFeature back to Feature
				Feature.TransformDataFromObject(EditFeature, null, false);
				Feature.IsAutoUpdated = false;
			}
			else if (Feature.ReverseInstance != null)
			{
				EditFeature.ResetModified(Feature.ReverseInstance.IsModified);
				if (EditFeature.Equals(Feature.ReverseInstance))
				{
					// perform the update of EditFeature back to Feature
					Feature.TransformDataFromObject(EditFeature, null, false);
					Feature.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditFeature back to Feature
					Feature.TransformDataFromObject(EditFeature, null, false);
					Feature.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditFeature back to Feature
				Feature.TransformDataFromObject(EditFeature, null, false);
				Feature.IsAutoUpdated = false;
			}
			Feature.ForwardInstance = null;
			if (FeatureNameCustomized || DescriptionCustomized || TagsCustomized)
			{
				Feature.ForwardInstance = new Feature();
				Feature.ForwardInstance.FeatureID = EditFeature.FeatureID;
				Feature.SpecSourceName = Feature.DefaultSourceName;
				if (FeatureNameCustomized)
				{
					Feature.ForwardInstance.FeatureName = EditFeature.FeatureName;
				}
				if (DescriptionCustomized)
				{
					Feature.ForwardInstance.Description = EditFeature.Description;
				}
				if (TagsCustomized)
				{
					Feature.ForwardInstance.Tags = EditFeature.Tags;
				}
			}
			EditFeature.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditFeaturePerformed();

			// send update for any updated Entities
			foreach (EntityViewModel item in Entities)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new Entities
			foreach (EntityViewModel item in ItemsToAdd.OfType<EntityViewModel>())
			{
				item.Update();
				Entities.Add(item);
			}

			// send delete for any deleted Entities
			foreach (EntityViewModel item in ItemsToDelete.OfType<EntityViewModel>())
			{
				item.Delete();
				Entities.Remove(item);
			}

			// reset modified for Entities
			foreach (EntityViewModel item in Entities)
			{
				item.ResetModified(false);
			}
			ItemsToAdd.Clear();
			ItemsToDelete.Clear();
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
		public void SendEditFeaturePerformed()
		{
			FeatureEventArgs message = new FeatureEventArgs();
			message.Feature = Feature;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<FeatureEventArgs>(MediatorMessages.Command_EditFeaturePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Feature command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteFeatureCommand()
		{
			FeatureEventArgs message = new FeatureEventArgs();
			message.Feature = Feature;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<FeatureEventArgs>(MediatorMessages.Command_DeleteFeatureRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteFeatureCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityViewModel> Entities { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Feature.</summary>
		///--------------------------------------------------------------------------------
		public Feature Feature { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FeatureID.</summary>
		///--------------------------------------------------------------------------------
		public Guid FeatureID
		{
			get
			{
				return Feature.FeatureID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Feature.Name;
			}
			set
			{
				Feature.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Feature into the view model.</summary>
		/// 
		/// <param name="feature">The Feature to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadFeature(Feature feature, bool loadChildren = true)
		{
			// attach the Feature
			Feature = feature;
			ItemID = Feature.FeatureID;
			Items.Clear();
			
			// initialize Entities
			if (Entities == null)
			{
				Entities = new EnterpriseDataObjectList<EntityViewModel>();
			}
			if (loadChildren == true)
			{
				// attach Entities
				foreach (Entity item in feature.EntityList)
				{
					EntityViewModel itemView = new EntityViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Entities.Add(itemView);
					Items.Add(itemView);
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
				foreach (EntityViewModel item in Entities)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Feature.IsValid;
			HasCustomizations = Feature.IsAutoUpdated == false || Feature.IsEmptyMetadata(Feature.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Feature.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Feature.IsAutoUpdated = true;
				Feature.SpecSourceName = Feature.ReverseInstance.SpecSourceName;
				Feature.ResetModified(Feature.ReverseInstance.IsModified);
				Feature.ResetLoaded(Feature.ReverseInstance.IsLoaded);
				if (!Feature.IsIdenticalMetadata(Feature.ReverseInstance))
				{
					HasCustomizations = true;
					Feature.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Feature.ForwardInstance = null;
				Feature.ReverseInstance = null;
				Feature.IsAutoUpdated = true;
			}
			foreach (EntityViewModel item in Entities)
			{
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			Items.Sort("Name", SortDirection.Ascending);
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (Entities != null)
			{
				for (int i = Entities.Count - 1; i >= 0; i--)
				{
					Entities[i].Updated -= Children_Updated;
					Entities[i].Dispose();
					Entities.Remove(Entities[i]);
				}
				Entities = null;
			}
			if (_editFeature != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditFeature.PropertyChanged -= EditFeature_PropertyChanged;
				EditFeature = null;
			}
			Feature = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (EntityViewModel item in Entities)
			{
				if (item.HasCustomizations == true)
				{
					return true;
				}
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
			OnPropertyChanged("EntityList");
			OnPropertyChanged("EntityListCustomized");
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
			if (data is EntityEventArgs && (data as EntityEventArgs).FeatureID == Feature.FeatureID)
			{
				return this;
			}
			foreach (EntityViewModel model in Entities)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Entity to the view model.</summary>
		/// 
		/// <param name="itemView">The Entity to add.</param>
		///--------------------------------------------------------------------------------
		public void AddEntity(EntityViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Entities.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Entity from the view model.</summary>
		/// 
		/// <param name="itemView">The Entity to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteEntity(EntityViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Entities.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public FeatureViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="feature">The Feature to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public FeatureViewModel(Feature feature, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadFeature(feature, loadChildren);
		}

		#endregion "Constructors"
	}
}
