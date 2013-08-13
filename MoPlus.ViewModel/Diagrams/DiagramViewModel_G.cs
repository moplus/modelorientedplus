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

namespace MoPlus.ViewModel.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for Diagram instances.</summary>
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
	public partial class DiagramViewModel : DiagramWorkspaceViewModel
	{
		#region "Menus"
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
		/// <summary>This property gets MenuLabeNewlDiagramToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDiagramToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagramEntity.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagramEntity
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramEntity;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagramEntityToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagramEntityToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramEntityToolTip;
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
				if (EditDiagram.IsModified == true)
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

				#region protected
				if (IsDiagramEdited == true)
				{
					return true;
				}
				#endregion protected
				
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
				return string.IsNullOrEmpty(DiagramNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Diagram _editDiagram = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditDiagram.</summary>
		///--------------------------------------------------------------------------------
		public Diagram EditDiagram
		{
			get
			{
				if (_editDiagram == null)
				{
					_editDiagram = new Diagram();
					_editDiagram.PropertyChanged += new PropertyChangedEventHandler(EditDiagram_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Diagram != null)
					{
						_editDiagram.TransformDataFromObject(Diagram, null, false);
						_editDiagram.Solution = Diagram.Solution;
					}
					_editDiagram.ResetModified(false);
				}
				return _editDiagram;
			}
			set
			{
				_editDiagram = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditDiagram_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditDiagram");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("DiagramName");
			OnPropertyChanged("DiagramNameCustomized");
			OnPropertyChanged("DiagramNameValidationMessage");
			
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
				return DisplayValues.Edit_DiagramHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_DiagramHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DiagramIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DiagramIDLabel
		{
			get
			{
				return DisplayValues.Edit_DiagramIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DiagramNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DiagramNameLabel
		{
			get
			{
				return DisplayValues.Edit_DiagramNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DiagramName.</summary>
		///--------------------------------------------------------------------------------
		public string DiagramName
		{
			get
			{
				return EditDiagram.DiagramName;
			}
			set
			{
				EditDiagram.DiagramName = value;
				OnPropertyChanged("DiagramName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DiagramNameCustomized
		{
			get
			{
				if (Diagram.ReverseInstance != null)
				{
					return DiagramName.GetString() != Diagram.ReverseInstance.DiagramName.GetString();
				}
				else if (Diagram.IsAutoUpdated == true)
				{
					return DiagramName.GetString() != Diagram.DiagramName.GetString();
				}
				return DiagramName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DiagramNameValidationMessage
		{
			get
			{
				return EditDiagram.ValidateDiagramName();
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
				return EditDiagram.Description;
			}
			set
			{
				EditDiagram.Description = value;
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
				if (Diagram.ReverseInstance != null)
				{
					return Description.GetString() != Diagram.ReverseInstance.Description.GetString();
				}
				else if (Diagram.IsAutoUpdated == true)
				{
					return Description.GetString() != Diagram.Description.GetString();
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
				return EditDiagram.ValidateDescription();
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
				return EditDiagram.SourceName;
			}
			set
			{
				EditDiagram.SourceName = value;
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
				return EditDiagram.SpecSourceName;
			}
			set
			{
				EditDiagram.SpecSourceName = value;
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
				return EditDiagram.Tags;
			}
			set
			{
				EditDiagram.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Diagram.ReverseInstance != null)
				{
					return Tags != Diagram.ReverseInstance.Tags;
				}
				else if (Diagram.IsAutoUpdated == true)
				{
					return Tags != Diagram.Tags;
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
				return EditDiagram.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditDiagram.Name;
			}
			set
			{
				EditDiagram.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			#region protected
			EditDiagram.TransformDataFromObject(Diagram, null, false);
			EditDiagram.ResetModified(false);
			foreach (DiagramEntityViewModel entity in DiagramEntities)
			{
				if (Entities.Contains(entity.EntityViewModel) == false)
				{
					Entities.Add(entity.EntityViewModel);
				}
			}
			for (int i = Entities.Count - 1; i >= 0; i--)
			{
				Entities[i] = new EntityViewModel(Entities[i].Entity, Solution, true);
			}
			Entities.Sort("DisplayName", SortDirection.Ascending);
			ItemsToAdd.Clear();
			ItemsToDelete.Clear();
			LoadDiagram(Diagram);
			IsDiagramEdited = false;
			Refresh(true);
			#endregion protected
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
			if (Diagram.ReverseInstance != null)
			{
				EditDiagram.TransformDataFromObject(Diagram.ReverseInstance, null, false);
			}
			else if (Diagram.IsAutoUpdated == true)
			{
				EditDiagram.TransformDataFromObject(Diagram, null, false);
			}
			else
			{
				Diagram newDiagram = new Diagram();
				newDiagram.DiagramID = EditDiagram.DiagramID;
				EditDiagram.TransformDataFromObject(newDiagram, null, false);
			}
			EditDiagram.ResetModified(true);
			foreach (DiagramEntityViewModel item in Items.OfType<DiagramEntityViewModel>())
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
		/// <summary>This method processes the new Diagram command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDiagramCommand()
		{
			DiagramEventArgs message = new DiagramEventArgs();
			message.Diagram = new Diagram();
			message.Diagram.DiagramID = Guid.NewGuid();
			message.Diagram.SolutionID = SolutionID;
			message.Diagram.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			
			#region protected
			message.Entities = Entities;
			#endregion protected
			
			Mediator.NotifyColleagues<DiagramEventArgs>(MediatorMessages.Command_EditDiagramRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDiagramCommand()
		{
			DiagramEventArgs message = new DiagramEventArgs();
			message.Diagram = Diagram;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			
			#region protected
			message.Entities = Entities;
			#endregion protected
			
			Mediator.NotifyColleagues<DiagramEventArgs>(MediatorMessages.Command_EditDiagramRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to DiagramEntity adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewDiagramEntity()
		{
			DiagramEntityViewModel item = new DiagramEntityViewModel();
			item.DiagramEntity = new DiagramEntity();
			item.DiagramEntity.DiagramEntityID = Guid.NewGuid();
			item.DiagramEntity.Diagram = EditDiagram;
			item.DiagramEntity.DiagramID = EditDiagram.DiagramID;
			item.DiagramEntity.Solution = Solution;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new DiagramEntity command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDiagramEntityCommand()
		{
			DiagramEntityEventArgs message = new DiagramEntityEventArgs();
			message.DiagramEntity = new DiagramEntity();
			message.DiagramEntity.DiagramEntityID = Guid.NewGuid();
			message.DiagramEntity.Diagram = Diagram;
			message.DiagramEntity.DiagramID = Diagram.DiagramID;
			message.DiagramID = Diagram.DiagramID;
			message.DiagramEntity.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEntityEventArgs>(MediatorMessages.Command_EditDiagramEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies DiagramEntity updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDiagramEntityPerformed(DiagramEntityEventArgs data)
		{
			if (data != null && data.DiagramEntity != null)
			{
				UpdateEditDiagramEntity(data.DiagramEntity);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of DiagramEntity.</summary>
		/// 
		/// <param name="diagramEntity">The DiagramEntity to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditDiagramEntity(DiagramEntity diagramEntity)
		{
			bool isItemMatch = false;
			foreach (DiagramEntityViewModel item in DiagramEntities)
			{
				if (item.DiagramEntity.DiagramEntityID == diagramEntity.DiagramEntityID)
				{
					isItemMatch = true;
					item.DiagramEntity.TransformDataFromObject(diagramEntity, null, false);
					if (!item.DiagramEntity.EntityID.IsNullOrEmpty())
					{
						item.DiagramEntity.Entity = Solution.EntityList.FindByID((Guid)item.DiagramEntity.EntityID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new DiagramEntity
				diagramEntity.Diagram = Diagram;
				DiagramEntityViewModel newItem = new DiagramEntityViewModel(diagramEntity, Solution);
				if (!newItem.DiagramEntity.EntityID.IsNullOrEmpty())
				{
					newItem.DiagramEntity.Entity = Solution.EntityList.FindByID((Guid)newItem.DiagramEntity.EntityID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				DiagramEntities.Add(newItem);
				Diagram.DiagramEntityList.Add(diagramEntity);
				Solution.DiagramEntityList.Add(newItem.DiagramEntity);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to DiagramEntity deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedDiagramEntities(DiagramEntityViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies DiagramEntity deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDiagramEntityPerformed(DiagramEntityEventArgs data)
		{
			if (data != null && data.DiagramEntity != null)
			{
				DeleteDiagramEntity(data.DiagramEntity);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of DiagramEntity.</summary>
		/// 
		/// <param name="diagramEntity">The DiagramEntity to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteDiagramEntity(DiagramEntity diagramEntity)
		{
			bool isItemMatch = false;
			foreach (DiagramEntityViewModel item in DiagramEntities.ToList<DiagramEntityViewModel>())
			{
				if (item.DiagramEntity.DiagramEntityID == diagramEntity.DiagramEntityID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.DiagramEntity.DiagramEntityID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete DiagramEntity
					isItemMatch = true;
					DiagramEntities.Remove(item);
					Diagram.DiagramEntityList.Remove(item.DiagramEntity);
					Solution.DiagramEntityList.Remove(item.DiagramEntity);
					Items.Remove(item);
					Diagram.ResetModified(true);
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
			ProcessNewDiagramCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			#region protected
			// perform the update of EditDiagram back to Diagram
			Diagram.TransformDataFromObject(EditDiagram, null, false);

			// update the solution diagram diagram entity list

			EnterpriseDataObjectList<DiagramEntity> entitiesToAdd = new EnterpriseDataObjectList<DiagramEntity>();
			EnterpriseDataObjectList<DiagramEntity> entitiesToRemove = new EnterpriseDataObjectList<DiagramEntity>();
			foreach (DiagramEntity entity in Diagram.DiagramEntityList)
			{
				bool isFound = false;
				foreach (DiagramEntityViewModel entityView in DiagramEntities)
				{
					if (entity.EntityID == entityView.EntityViewModel.EntityID)
					{
						isFound = true;
						entity.PositionX = entityView.X;
						entity.PositionY = entityView.Y;
						break;
					}
				}
				if (isFound == false)
				{
					entitiesToRemove.Add(entity);
				}
			}
			foreach (DiagramEntityViewModel entityView in DiagramEntities)
			{
				bool isFound = false;
				foreach (DiagramEntity entity in Diagram.DiagramEntityList)
				{
					if (entity.EntityID == entityView.EntityViewModel.EntityID)
					{
						isFound = true;
						break;
					}
				}
				if (isFound == false)
				{
					entityView.DiagramEntity.PositionX = entityView.X;
					entityView.DiagramEntity.PositionY = entityView.Y;
					entitiesToAdd.Add(entityView.DiagramEntity);
				}
			}
			foreach (DiagramEntity entity in entitiesToAdd)
			{
				Diagram.DiagramEntityList.Add(entity);
			}
			foreach (DiagramEntity entity in entitiesToRemove)
			{
				Diagram.DiagramEntityList.Remove(entity);
			}

			EditDiagram.ResetModified(false);

			// send update for any updated children
			foreach (DiagramEntityViewModel entity in DiagramEntities)
			{
				if (entity.EntityViewModel.IsEdited == true)
				{
					entity.EntityViewModel.Update();
				}
				if (entity.IsEdited == true)
				{
					entity.EditDiagramEntity.ResetModified(false);
					entity.ResetModified(false);
				}
			}
			// send update for any new children
			foreach (DiagramEntityViewModel entity in ItemsToAdd.OfType<DiagramEntityViewModel>())
			{
				if (entity.EntityViewModel.IsEdited == true || Solution.EntityList.Find(e => e.EntityID == entity.EntityViewModel.EntityID) == null)
				{
					entity.EntityViewModel.Update();
				}
				entity.EditDiagramEntity.ResetModified(false);
				entity.ResetModified(false);
				//DiagramEntities.Add(entity);
			}

			// send delete for any deleted children
			foreach (DiagramEntityViewModel entity in ItemsToDelete.OfType<DiagramEntityViewModel>())
			{
				entity.EntityViewModel.Delete();
				DiagramEntities.Remove(entity);
			}

			// reset modified for children
			foreach (DiagramEntityViewModel entity in DiagramEntities)
			{
				entity.ResetModified(false);
			}

			// send update for any updated children
			foreach (DiagramRelationshipViewModel relationship in DiagramRelationships)
			{
				if (relationship.IsEdited == true)
				{
					relationship.RelationshipViewModel.Update();
					relationship.ResetModified(false);
				}
			}
			// send update for any new children
			foreach (DiagramRelationshipViewModel relationship in ItemsToAdd.OfType<DiagramRelationshipViewModel>())
			{
				relationship.RelationshipViewModel.Update();
				relationship.ResetModified(false);
				DiagramRelationships.Add(relationship);
			}

			// send delete for any deleted children
			foreach (DiagramRelationshipViewModel relationship in ItemsToDelete.OfType<DiagramRelationshipViewModel>())
			{
				relationship.RelationshipViewModel.Delete();
				DiagramRelationships.Remove(relationship);
			}

			// reset modified for children
			foreach (DiagramRelationshipViewModel relationship in DiagramRelationships)
			{
				relationship.ResetModified(false);
			}

			// send update back to solution builder
			SendEditDiagramPerformed();
			ItemsToAdd.Clear();
			ItemsToDelete.Clear();
			IsDiagramEdited = false;

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
		public void SendEditDiagramPerformed()
		{
			DiagramEventArgs message = new DiagramEventArgs();

			#region protected
			message.DiagramEntitiesToAdd = new EnterpriseDataObjectList<DiagramEntityViewModel>(ItemsToAdd.OfType<DiagramEntityViewModel>().ToList<DiagramEntityViewModel>());
			message.DiagramEntitiesToDelete = new EnterpriseDataObjectList<DiagramEntityViewModel>(ItemsToDelete.OfType<DiagramEntityViewModel>().ToList<DiagramEntityViewModel>());
			message.DiagramRelationshipsToAdd = new EnterpriseDataObjectList<DiagramRelationshipViewModel>(ItemsToAdd.OfType<DiagramRelationshipViewModel>().ToList<DiagramRelationshipViewModel>());
			message.DiagramRelationshipsToDelete = new EnterpriseDataObjectList<DiagramRelationshipViewModel>(ItemsToDelete.OfType<DiagramRelationshipViewModel>().ToList<DiagramRelationshipViewModel>());
			#endregion protected

			message.Diagram = Diagram;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEventArgs>(MediatorMessages.Command_EditDiagramPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Diagram command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDiagramCommand()
		{
			DiagramEventArgs message = new DiagramEventArgs();
			message.Diagram = Diagram;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEventArgs>(MediatorMessages.Command_DeleteDiagramRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteDiagramCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramEntity lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramEntityViewModel> DiagramEntities { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Diagram.</summary>
		///--------------------------------------------------------------------------------
		public Diagram Diagram { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramID.</summary>
		///--------------------------------------------------------------------------------
		public Guid DiagramID
		{
			get
			{
				return Diagram.DiagramID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Diagram.Name;
			}
			set
			{
				Diagram.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Diagram into the view model.</summary>
		/// 
		/// <param name="diagram">The Diagram to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDiagram(Diagram diagram, bool loadChildren = true)
		{
			// attach the Diagram
			Diagram = diagram;
			ItemID = Diagram.DiagramID;
			Items.Clear();
			
			// initialize DiagramEntities
			if (DiagramEntities == null)
			{
				DiagramEntities = new EnterpriseDataObjectList<DiagramEntityViewModel>();
			}
			if (loadChildren == true)
			{
				// attach DiagramEntities
				foreach (DiagramEntity item in diagram.DiagramEntityList)
				{
					DiagramEntityViewModel itemView = new DiagramEntityViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					DiagramEntities.Add(itemView);
					Items.Add(itemView);
				}
				#region protected
				Items.Clear();
				DiagramRelationships.Clear();
				DiagramEntities.Clear();
				if (Entities.Count > 0)
				{
					IList<DiagramEntity> missingEntities = new List<DiagramEntity>();
					foreach (DiagramEntity entity in diagram.DiagramEntityList)
					{
						if (entity.Entity == null)
						{
							entity.Entity = Solution.EntityList.FindByID(entity.EntityID);
						}
						if (entity.Entity != null)
						{
							EntityViewModel entityView = Entities.Find("EntityID", entity.EntityID);
							if (entityView != null)
							{
								System.Windows.Point position = new System.Windows.Point();
								position.X = entity.PositionX;
								position.Y = entity.PositionY;
								AddEntity(entityView, position);
							}
							else
							{
								missingEntities.Add(entity);
							}
						}
						else
						{
							missingEntities.Add(entity);
						}
					}

					// remove missing entities
					if (missingEntities.Count > 0)
					{
						foreach (DiagramEntity entity in missingEntities)
						{
							diagram.DiagramEntityList.Remove(entity);
							Solution.ResetModified(true);
						}
						ShowIssue(DisplayValues.Issue_MissingDiagramEntities);
					}
				}

				Items.Clear();
				foreach (var item in DiagramEntities)
				{
					Items.Add(item);
				}
				foreach (var item in DiagramRelationships)
				{
					Items.Add(item);
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
				foreach (DiagramEntityViewModel item in DiagramEntities)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Diagram.IsValid;
			HasCustomizations = Diagram.IsAutoUpdated == false || Diagram.IsEmptyMetadata(Diagram.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Diagram.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Diagram.IsAutoUpdated = true;
				Diagram.SpecSourceName = Diagram.ReverseInstance.SpecSourceName;
				Diagram.ResetModified(Diagram.ReverseInstance.IsModified);
				Diagram.ResetLoaded(Diagram.ReverseInstance.IsLoaded);
				if (!Diagram.IsIdenticalMetadata(Diagram.ReverseInstance))
				{
					HasCustomizations = true;
					Diagram.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Diagram.ForwardInstance = null;
				Diagram.ReverseInstance = null;
				Diagram.IsAutoUpdated = true;
			}
			foreach (DiagramEntityViewModel item in DiagramEntities)
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
			#region protected
			if (DiagramEntities != null)
			{
				DiagramEntities.CollectionChanged -= DiagramEntities_CollectionChanged;
			}
			#endregion protected
			
			if (DiagramEntities != null)
			{
				for (int i = DiagramEntities.Count - 1; i >= 0; i--)
				{
					DiagramEntities[i].Updated -= Children_Updated;
					DiagramEntities[i].Dispose();
					DiagramEntities.Remove(DiagramEntities[i]);
				}
				DiagramEntities = null;
			}
			if (_editDiagram != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditDiagram.PropertyChanged -= EditDiagram_PropertyChanged;
				EditDiagram = null;
			}
			Diagram = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (DiagramEntityViewModel item in DiagramEntities)
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
			OnPropertyChanged("DiagramEntityList");
			OnPropertyChanged("DiagramEntityListCustomized");
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
			if (data is DiagramEntityEventArgs && (data as DiagramEntityEventArgs).DiagramID == Diagram.DiagramID)
			{
				return this;
			}
			foreach (DiagramEntityViewModel model in DiagramEntities)
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
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel PasteDiagramEntity(DiagramEntityViewModel copyItem, bool savePaste = true)
		{
			DiagramEntity newItem = new DiagramEntity();
			newItem.ReverseInstance = new DiagramEntity();
			newItem.TransformDataFromObject(copyItem.DiagramEntity, null, false);
			newItem.DiagramEntityID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Entity by existing id first, second by old id, finally by name
			newItem.Entity = Solution.EntityList.FindByID((Guid)copyItem.DiagramEntity.EntityID);
			if (newItem.Entity == null && Solution.PasteNewGuids[copyItem.DiagramEntity.EntityID.ToString()] is Guid)
			{
				newItem.Entity = Solution.EntityList.FindByID((Guid)Solution.PasteNewGuids[copyItem.DiagramEntity.EntityID.ToString()]);
			}
			if (newItem.Entity == null)
			{
				newItem.Entity = Solution.EntityList.Find("Name", copyItem.DiagramEntity.Name);
			}
			if (newItem.Entity == null)
			{
				newItem.OldEntityID = newItem.EntityID;
				newItem.EntityID = Guid.Empty;
			}
			newItem.Diagram = Diagram;
			newItem.Solution = Solution;
			DiagramEntityViewModel newView = new DiagramEntityViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddDiagramEntity(newView);
			if (savePaste == true)
			{
				Solution.DiagramEntityList.Add(newItem);
				Diagram.DiagramEntityList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of DiagramEntity to the view model.</summary>
		/// 
		/// <param name="itemView">The DiagramEntity to add.</param>
		///--------------------------------------------------------------------------------
		public void AddDiagramEntity(DiagramEntityViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			DiagramEntities.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of DiagramEntity from the view model.</summary>
		/// 
		/// <param name="itemView">The DiagramEntity to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteDiagramEntity(DiagramEntityViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			DiagramEntities.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public DiagramViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="diagram">The Diagram to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public DiagramViewModel(Diagram diagram, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadDiagram(diagram, loadChildren);
		}

		#endregion "Constructors"
	}
}
