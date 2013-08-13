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
	/// Index instances.</summary>
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
	public partial class IndexesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewIndex.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndex
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndex;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewIndexToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndexToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndexToolTip;
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
			foreach (IndexViewModel item in Items.OfType<IndexViewModel>())
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
			foreach (IndexViewModel item in Indexes)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (IndexViewModel item in ItemsToAdd.OfType<IndexViewModel>())
			{
				item.Update();
				Indexes.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (IndexViewModel item in ItemsToDelete.OfType<IndexViewModel>())
			{
				item.Delete();
				Indexes.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (IndexViewModel item in Indexes)
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
		/// <summary>This method processes the new index command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewIndexCommand()
		{
			IndexEventArgs message = new IndexEventArgs();
			message.Index = new Index();
			message.Index.IndexID = Guid.NewGuid();
			message.Index.EntityID = Entity.EntityID;
			message.Index.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.Index.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexEventArgs>(MediatorMessages.Command_EditIndexRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies index updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditIndexPerformed(IndexEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Index != null)
				{
					foreach (IndexViewModel item in Indexes)
					{
						if (item.Index.IndexID == data.Index.IndexID)
						{
							isItemMatch = true;
							item.Index.TransformDataFromObject(data.Index, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Index
						data.Index.Entity = Entity;
						IndexViewModel newItem = new IndexViewModel(data.Index, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Indexes.Add(newItem);
						Entity.IndexList.Add(newItem.Index);
						Solution.IndexList.Add(newItem.Index);
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
		/// <summary>This method applies index deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteIndexPerformed(IndexEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Index != null)
				{
					foreach (IndexViewModel item in Indexes.ToList<IndexViewModel>())
					{
						if (item.Index.IndexID == data.Index.IndexID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Index.IndexID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is IndexPropertyViewModel)
								{
									IndexPropertyViewModel child = item.Items[i] as IndexPropertyViewModel;
									IndexPropertyEventArgs childMessage = new IndexPropertyEventArgs();
									childMessage.IndexProperty = child.IndexProperty;
									childMessage.IndexID = item.Index.IndexID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteIndexPropertyPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Indexes.Remove(item);
							Entity.IndexList.Remove(item.Index);
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
		/// <summary>This property gets or sets Index lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<IndexViewModel> Indexes { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Indexes into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadIndexes(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Indexes == null)
			{
				Indexes = new EnterpriseDataObjectList<IndexViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Index item in entity.IndexList)
				{
					IndexViewModel itemView = new IndexViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Indexes.Add(itemView);
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
				foreach (IndexViewModel item in Indexes)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (IndexViewModel item in Indexes)
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
			if (Indexes != null)
			{
				foreach (IndexViewModel itemView in Indexes)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Indexes.Clear();
				Indexes = null;
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
			if (data is IndexEventArgs && (data as IndexEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (IndexViewModel model in Indexes)
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
		public IndexViewModel PasteIndex(IndexViewModel copyItem, bool savePaste = true)
		{
			Index newItem = new Index();
			newItem.ReverseInstance = new Index();
			newItem.TransformDataFromObject(copyItem.Index, null, false);
			newItem.IndexID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			IndexViewModel newView = new IndexViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddIndex(newView);

			// paste children
			foreach (IndexPropertyViewModel childView in copyItem.IndexProperties)
			{
				newView.PasteIndexProperty(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.IndexList.Add(newItem);
				Entity.IndexList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Index to the view model.</summary>
		/// 
		/// <param name="itemView">The Index to add.</param>
		///--------------------------------------------------------------------------------
		public void AddIndex(IndexViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Indexes.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Index from the view model.</summary>
		/// 
		/// <param name="itemView">The Index to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteIndex(IndexViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Indexes.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public IndexesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Indexes;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public IndexesViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Indexes;
			Solution = solution;
			Entity = entity;
			LoadIndexes(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
