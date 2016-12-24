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
	/// <summary>This class provides views for collections of
	/// DatabaseSource instances.</summary>
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
	public partial class DatabaseSourcesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDatabaseSource.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDatabaseSource
		{
			get
			{
				return DisplayValues.ContextMenu_NewDatabaseSource;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDatabaseSourceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDatabaseSourceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDatabaseSourceToolTip;
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
			foreach (DatabaseSourceViewModel item in Items.OfType<DatabaseSourceViewModel>())
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
			foreach (DatabaseSourceViewModel item in DatabaseSources)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (DatabaseSourceViewModel item in ItemsToAdd.OfType<DatabaseSourceViewModel>())
			{
				item.Update();
				DatabaseSources.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (DatabaseSourceViewModel item in ItemsToDelete.OfType<DatabaseSourceViewModel>())
			{
				item.Delete();
				DatabaseSources.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (DatabaseSourceViewModel item in DatabaseSources)
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
		/// <summary>This method processes the new databasesource command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDatabaseSourceCommand()
		{
			DatabaseSourceEventArgs message = new DatabaseSourceEventArgs();
			message.DatabaseSource = new DatabaseSource();
			message.DatabaseSource.SpecificationSourceID = Guid.NewGuid();
			message.DatabaseSource.SolutionID = Solution.SolutionID;
			message.DatabaseSource.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.DatabaseSource.Solution = Solution;
			message.Solution = Solution;
			if (message.DatabaseSource.Solution != null)
			{
				message.DatabaseSource.Order = message.DatabaseSource.Solution.DatabaseSourceList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DatabaseSourceEventArgs>(MediatorMessages.Command_EditDatabaseSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies databasesource updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDatabaseSourcePerformed(DatabaseSourceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.DatabaseSource != null)
				{
					foreach (DatabaseSourceViewModel item in DatabaseSources)
					{
						if (item.DatabaseSource.SpecificationSourceID == data.DatabaseSource.SpecificationSourceID)
						{
							isItemMatch = true;
							item.DatabaseSource.TransformDataFromObject(data.DatabaseSource, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new DatabaseSource
						data.DatabaseSource.Solution = Solution;
						DatabaseSourceViewModel newItem = new DatabaseSourceViewModel(data.DatabaseSource, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						DatabaseSources.Add(newItem);
						Solution.DatabaseSourceList.Add(newItem.DatabaseSource);
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
		/// <summary>This method applies databasesource deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDatabaseSourcePerformed(DatabaseSourceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.DatabaseSource != null)
				{
					foreach (DatabaseSourceViewModel item in DatabaseSources.ToList<DatabaseSourceViewModel>())
					{
						if (item.DatabaseSource.SpecificationSourceID == data.DatabaseSource.SpecificationSourceID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.DatabaseSource.SpecificationSourceID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							DatabaseSources.Remove(item);
							Solution.DatabaseSourceList.Remove(item.DatabaseSource);
							Items.Remove(item);
							Solution.ResetModified(true);
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
		/// <summary>This property gets or sets DatabaseSource lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DatabaseSourceViewModel> DatabaseSources { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads DatabaseSources into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDatabaseSources(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (DatabaseSources == null)
			{
				DatabaseSources = new EnterpriseDataObjectList<DatabaseSourceViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (DatabaseSource item in solution.DatabaseSourceList)
				{
					DatabaseSourceViewModel itemView = new DatabaseSourceViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					DatabaseSources.Add(itemView);
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
				foreach (DatabaseSourceViewModel item in DatabaseSources)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (DatabaseSourceViewModel item in DatabaseSources)
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
			if (DatabaseSources != null)
			{
				foreach (DatabaseSourceViewModel itemView in DatabaseSources)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				DatabaseSources.Clear();
				DatabaseSources = null;
			}
			Solution = null;
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
			if (data is DatabaseSourceEventArgs && (data as DatabaseSourceEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public DatabaseSourceViewModel PasteDatabaseSource(DatabaseSourceViewModel copyItem, bool savePaste = true)
		{
			DatabaseSource newItem = new DatabaseSource();
			newItem.ReverseInstance = new DatabaseSource();
			newItem.TransformDataFromObject(copyItem.DatabaseSource, null, false);
			newItem.SpecificationSourceID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			DatabaseSourceViewModel newView = new DatabaseSourceViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddDatabaseSource(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.DatabaseSourceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of DatabaseSource to the view model.</summary>
		/// 
		/// <param name="itemView">The DatabaseSource to add.</param>
		///--------------------------------------------------------------------------------
		public void AddDatabaseSource(DatabaseSourceViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			DatabaseSources.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of DatabaseSource from the view model.</summary>
		/// 
		/// <param name="itemView">The DatabaseSource to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteDatabaseSource(DatabaseSourceViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			DatabaseSources.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public DatabaseSourcesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_DatabaseSources;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public DatabaseSourcesViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_DatabaseSources;
			Solution = solution;
			LoadDatabaseSources(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
