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
	/// Relationship instances.</summary>
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
	public partial class RelationshipsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewRelationship.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationship
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationship;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewRelationshipToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationshipToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipToolTip;
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
			foreach (RelationshipViewModel item in Items.OfType<RelationshipViewModel>())
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
			foreach (RelationshipViewModel item in Relationships)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (RelationshipViewModel item in ItemsToAdd.OfType<RelationshipViewModel>())
			{
				item.Update();
				Relationships.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (RelationshipViewModel item in ItemsToDelete.OfType<RelationshipViewModel>())
			{
				item.Delete();
				Relationships.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (RelationshipViewModel item in Relationships)
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
		/// <summary>This method processes the new relationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewRelationshipCommand()
		{
			RelationshipEventArgs message = new RelationshipEventArgs();
			message.Relationship = new Relationship();
			message.Relationship.RelationshipID = Guid.NewGuid();
			message.Relationship.EntityID = Entity.EntityID;
			message.Relationship.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.Relationship.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipEventArgs>(MediatorMessages.Command_EditRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies relationship updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditRelationshipPerformed(RelationshipEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Relationship != null)
				{
					foreach (RelationshipViewModel item in Relationships)
					{
						if (item.Relationship.RelationshipID == data.Relationship.RelationshipID)
						{
							isItemMatch = true;
							item.Relationship.TransformDataFromObject(data.Relationship, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Relationship
						data.Relationship.Entity = Entity;
						RelationshipViewModel newItem = new RelationshipViewModel(data.Relationship, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Relationships.Add(newItem);
						Entity.RelationshipList.Add(newItem.Relationship);
						Solution.RelationshipList.Add(newItem.Relationship);
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
		/// <summary>This method applies relationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteRelationshipPerformed(RelationshipEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Relationship != null)
				{
					foreach (RelationshipViewModel item in Relationships.ToList<RelationshipViewModel>())
					{
						if (item.Relationship.RelationshipID == data.Relationship.RelationshipID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Relationship.RelationshipID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is RelationshipPropertyViewModel)
								{
									RelationshipPropertyViewModel child = item.Items[i] as RelationshipPropertyViewModel;
									RelationshipPropertyEventArgs childMessage = new RelationshipPropertyEventArgs();
									childMessage.RelationshipProperty = child.RelationshipProperty;
									childMessage.RelationshipID = item.Relationship.RelationshipID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteRelationshipPropertyPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Relationships.Remove(item);
							Entity.RelationshipList.Remove(item.Relationship);
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
		/// <summary>This property gets or sets Relationship lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<RelationshipViewModel> Relationships { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Relationships into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadRelationships(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Relationships == null)
			{
				Relationships = new EnterpriseDataObjectList<RelationshipViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Relationship item in entity.RelationshipList)
				{
					RelationshipViewModel itemView = new RelationshipViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Relationships.Add(itemView);
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
				foreach (RelationshipViewModel item in Relationships)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (RelationshipViewModel item in Relationships)
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
			if (Relationships != null)
			{
				foreach (RelationshipViewModel itemView in Relationships)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Relationships.Clear();
				Relationships = null;
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
			if (data is RelationshipEventArgs && (data as RelationshipEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (RelationshipViewModel model in Relationships)
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
		public RelationshipViewModel PasteRelationship(RelationshipViewModel copyItem, bool savePaste = true)
		{
			Relationship newItem = new Relationship();
			newItem.ReverseInstance = new Relationship();
			newItem.TransformDataFromObject(copyItem.Relationship, null, false);
			newItem.RelationshipID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			RelationshipViewModel newView = new RelationshipViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddRelationship(newView);

			// paste children
			foreach (RelationshipPropertyViewModel childView in copyItem.RelationshipProperties)
			{
				newView.PasteRelationshipProperty(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.RelationshipList.Add(newItem);
				Entity.RelationshipList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Relationship to the view model.</summary>
		/// 
		/// <param name="itemView">The Relationship to add.</param>
		///--------------------------------------------------------------------------------
		public void AddRelationship(RelationshipViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Relationships.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Relationship from the view model.</summary>
		/// 
		/// <param name="itemView">The Relationship to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteRelationship(RelationshipViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Relationships.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public RelationshipsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Relationships;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public RelationshipsViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Relationships;
			Solution = solution;
			Entity = entity;
			LoadRelationships(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
