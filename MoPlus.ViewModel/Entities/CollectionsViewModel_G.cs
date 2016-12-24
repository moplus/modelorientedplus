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
	/// Collection instances.</summary>
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
	public partial class CollectionsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
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
			foreach (CollectionViewModel item in Items.OfType<CollectionViewModel>())
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
			foreach (CollectionViewModel item in Collections)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (CollectionViewModel item in ItemsToAdd.OfType<CollectionViewModel>())
			{
				item.Update();
				Collections.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (CollectionViewModel item in ItemsToDelete.OfType<CollectionViewModel>())
			{
				item.Delete();
				Collections.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (CollectionViewModel item in Collections)
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
		/// <summary>This method processes the new collection command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewCollectionCommand()
		{
			CollectionEventArgs message = new CollectionEventArgs();
			message.Collection = new Collection();
			message.Collection.PropertyID = Guid.NewGuid();
			message.Collection.EntityID = Entity.EntityID;
			message.Collection.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.Collection.Solution = Solution;
			message.Solution = Solution;
			if (message.Collection.Entity != null)
			{
				message.Collection.Order = message.Collection.Entity.CollectionList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<CollectionEventArgs>(MediatorMessages.Command_EditCollectionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies collection updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditCollectionPerformed(CollectionEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Collection != null)
				{
					foreach (CollectionViewModel item in Collections)
					{
						if (item.Collection.PropertyID == data.Collection.PropertyID)
						{
							isItemMatch = true;
							item.Collection.TransformDataFromObject(data.Collection, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Collection
						data.Collection.Entity = Entity;
						CollectionViewModel newItem = new CollectionViewModel(data.Collection, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Collections.Add(newItem);
						Entity.CollectionList.Add(newItem.Collection);
						Solution.CollectionList.Add(newItem.Collection);
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
		/// <summary>This method applies collection deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteCollectionPerformed(CollectionEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Collection != null)
				{
					foreach (CollectionViewModel item in Collections.ToList<CollectionViewModel>())
					{
						if (item.Collection.PropertyID == data.Collection.PropertyID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Collection.PropertyID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							Collections.Remove(item);
							Entity.CollectionList.Remove(item.Collection);
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
		/// <summary>This property gets or sets Collection lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<CollectionViewModel> Collections { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Collections into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadCollections(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Collections == null)
			{
				Collections = new EnterpriseDataObjectList<CollectionViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Collection item in entity.CollectionList)
				{
					CollectionViewModel itemView = new CollectionViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Collections.Add(itemView);
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
				foreach (CollectionViewModel item in Collections)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (CollectionViewModel item in Collections)
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
			if (Collections != null)
			{
				foreach (CollectionViewModel itemView in Collections)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Collections.Clear();
				Collections = null;
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
			if (data is CollectionEventArgs && (data as CollectionEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (CollectionViewModel model in Collections)
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
		public CollectionViewModel PasteCollection(CollectionViewModel copyItem, bool savePaste = true)
		{
			Collection newItem = new Collection();
			newItem.ReverseInstance = new Collection();
			newItem.TransformDataFromObject(copyItem.Collection, null, false);
			newItem.PropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			CollectionViewModel newView = new CollectionViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddCollection(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.CollectionList.Add(newItem);
				Entity.CollectionList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Collection to the view model.</summary>
		/// 
		/// <param name="itemView">The Collection to add.</param>
		///--------------------------------------------------------------------------------
		public void AddCollection(CollectionViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Collections.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Collection from the view model.</summary>
		/// 
		/// <param name="itemView">The Collection to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteCollection(CollectionViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Collections.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public CollectionsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Collections;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public CollectionsViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Collections;
			Solution = solution;
			Entity = entity;
			LoadCollections(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
