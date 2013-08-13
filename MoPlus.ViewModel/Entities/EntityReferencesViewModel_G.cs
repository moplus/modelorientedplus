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

namespace MoPlus.ViewModel.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for collections of
	/// EntityReference instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/12/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class EntityReferencesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
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

		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			ResetItems();
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
			foreach (EntityReferenceViewModel item in Items.OfType<EntityReferenceViewModel>())
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
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// send update for any updated children
			foreach (EntityReferenceViewModel item in EntityReferences)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (EntityReferenceViewModel item in ItemsToAdd.OfType<EntityReferenceViewModel>())
			{
				item.Update();
				EntityReferences.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (EntityReferenceViewModel item in ItemsToDelete.OfType<EntityReferenceViewModel>())
			{
				item.Delete();
				EntityReferences.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (EntityReferenceViewModel item in EntityReferences)
			{
				item.ResetModified(false);
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
		/// <summary>This method processes the new entityreference command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewEntityReferenceCommand()
		{
			EntityReferenceEventArgs message = new EntityReferenceEventArgs();
			message.EntityReference = new EntityReference();
			message.EntityReference.PropertyID = Guid.NewGuid();
			message.EntityReference.EntityID = Entity.EntityID;
			message.EntityReference.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.EntityReference.Solution = Solution;
			message.Solution = Solution;
			if (message.EntityReference.Entity != null)
			{
				message.EntityReference.Order = message.EntityReference.Entity.EntityReferenceList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EntityReferenceEventArgs>(MediatorMessages.Command_EditEntityReferenceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies entityreference updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditEntityReferencePerformed(EntityReferenceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.EntityReference != null)
				{
					foreach (EntityReferenceViewModel item in EntityReferences)
					{
						if (item.EntityReference.PropertyID == data.EntityReference.PropertyID)
						{
							isItemMatch = true;
							item.EntityReference.TransformDataFromObject(data.EntityReference, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new EntityReference
						data.EntityReference.Entity = Entity;
						EntityReferenceViewModel newItem = new EntityReferenceViewModel(data.EntityReference, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						EntityReferences.Add(newItem);
						Entity.EntityReferenceList.Add(newItem.EntityReference);
						Solution.EntityReferenceList.Add(newItem.EntityReference);
						Items.Add(newItem);
						OnUpdated(this, null);
						newItem.ShowInTreeView();
					}
				}
			}
			catch (Exception ex)
			{
				ShowIssue(ex.Message + ex.StackTrace);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies entityreference deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteEntityReferencePerformed(EntityReferenceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.EntityReference != null)
				{
					foreach (EntityReferenceViewModel item in EntityReferences.ToList<EntityReferenceViewModel>())
					{
						if (item.EntityReference.PropertyID == data.EntityReference.PropertyID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.EntityReference.PropertyID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							EntityReferences.Remove(item);
							Entity.EntityReferenceList.Remove(item.EntityReference);
							Items.Remove(item);
							Entity.ResetModified(true);
							OnUpdated(this, null);
							break;
						}
					}
					if (isItemMatch == false)
					{
						ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
					}
				}
			}
			catch (Exception ex)
			{
				ShowIssue(ex.Message + ex.StackTrace);
			}
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityReference lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityReferenceViewModel> EntityReferences { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads EntityReferences into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadEntityReferences(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (EntityReferences == null)
			{
				EntityReferences = new EnterpriseDataObjectList<EntityReferenceViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (EntityReference item in entity.EntityReferenceList)
				{
					EntityReferenceViewModel itemView = new EntityReferenceViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					EntityReferences.Add(itemView);
					Items.Add(itemView);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			HasErrors = !IsValid;
			HasCustomizations = false;
			if (refreshChildren == true || refreshLevel > 0)
			{
				foreach (EntityReferenceViewModel item in EntityReferences)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (EntityReferenceViewModel item in EntityReferences)
			{
				if (item.HasCustomizations == true)
				{
					HasCustomizations = true;
				}
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			Items.Sort("ItemOrder", SortDirection.Ascending);
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (EntityReferences != null)
			{
				foreach (EntityReferenceViewModel itemView in EntityReferences)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				EntityReferences.Clear();
				EntityReferences = null;
			}
			Entity = null;
			base.OnDispose();
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
		/// <summary>This method returns the parent view model corresponding to
		/// the input message.</summary>
		///
		/// <param name="data">The message data to find parent for.</param>
		///--------------------------------------------------------------------------------
		public EditWorkspaceViewModel FindParentViewModel(SolutionModelEventArgs data)
		{
			if (data is EntityReferenceEventArgs && (data as EntityReferenceEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (EntityReferenceViewModel model in EntityReferences)
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
		public EntityReferenceViewModel PasteEntityReference(EntityReferenceViewModel copyItem, bool savePaste = true)
		{
			EntityReference newItem = new EntityReference();
			newItem.ReverseInstance = new EntityReference();
			newItem.TransformDataFromObject(copyItem.EntityReference, null, false);
			newItem.PropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			EntityReferenceViewModel newView = new EntityReferenceViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddEntityReference(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.EntityReferenceList.Add(newItem);
				Entity.EntityReferenceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of EntityReference to the view model.</summary>
		/// 
		/// <param name="itemView">The EntityReference to add.</param>
		///--------------------------------------------------------------------------------
		public void AddEntityReference(EntityReferenceViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			EntityReferences.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of EntityReference from the view model.</summary>
		/// 
		/// <param name="itemView">The EntityReference to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteEntityReference(EntityReferenceViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			EntityReferences.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public EntityReferencesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_EntityReferences;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public EntityReferencesViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_EntityReferences;
			Solution = solution;
			Entity = entity;
			LoadEntityReferences(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
