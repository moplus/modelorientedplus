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
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Data;
using System.Collections.ObjectModel;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using System.Data;

namespace MoPlus.ViewModel.Solutions
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for the specification sources in a solution.</summary>
     ///--------------------------------------------------------------------------------
	public class SpecificationSourcesViewModel : EditWorkspaceViewModel
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
		/// <summary>This property gets MenuLabelNewXmlSource.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewXmlSource
		{
			get
			{
				return DisplayValues.ContextMenu_NewXmlSource;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewXmlSourceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewXmlSourceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewXmlSourceToolTip;
			}
		}

		#endregion "Menus"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new database specification source command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDatabaseSourceCommand()
		{
			DatabaseSourceEventArgs message = new DatabaseSourceEventArgs();
			message.DatabaseSource = new DatabaseSource();
			message.DatabaseSource.SpecificationSourceID = Guid.NewGuid();
			message.DatabaseSource.SolutionID = Solution.SolutionID;
			message.DatabaseSource.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DatabaseSourceEventArgs>(MediatorMessages.Command_EditDatabaseSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies database specification source updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDatabaseSourcePerformed(DatabaseSourceEventArgs data)
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
						if (data.ShowItemInTreeView == true)
						{
							item.ShowInTreeView();
						}
						break;
					}
				}
				if (isItemMatch == false)
				{
					// add new database specification source
					data.DatabaseSource.Solution = Solution;
					DatabaseSourceViewModel newItem = new DatabaseSourceViewModel(data.DatabaseSource, Solution);
					newItem.Updated += new EventHandler(Children_Updated);
					DatabaseSources.Add(newItem);
					Solution.DatabaseSourceList.Add(data.DatabaseSource);
					Items.Add(newItem);
					OnUpdated(this, null);
					if (data.ShowItemInTreeView == true)
					{
						newItem.ShowInTreeView();
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies database specification source deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDatabaseSourcePerformed(DatabaseSourceEventArgs data)
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

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new xml specification source command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewXmlSourceCommand()
		{
			XmlSourceEventArgs message = new XmlSourceEventArgs();
			message.XmlSource = new XmlSource();
			message.XmlSource.SpecificationSourceID = Guid.NewGuid();
			message.XmlSource.SolutionID = Solution.SolutionID;
			message.XmlSource.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<XmlSourceEventArgs>(MediatorMessages.Command_EditXmlSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies xml specification source updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditXmlSourcePerformed(XmlSourceEventArgs data)
		{
			bool isItemMatch = false;
			if (data != null && data.XmlSource != null)
			{
				foreach (XmlSourceViewModel item in XmlSources)
				{
					if (item.XmlSource.SpecificationSourceID == data.XmlSource.SpecificationSourceID)
					{
						isItemMatch = true;
						item.XmlSource.TransformDataFromObject(data.XmlSource, null, false);
						item.OnUpdated(item, null);
						if (data.ShowItemInTreeView == true)
						{
							item.ShowInTreeView();
						}
						break;
					}
				}
				if (isItemMatch == false)
				{
					// add new xml specification source
					data.XmlSource.Solution = Solution;
					XmlSourceViewModel newItem = new XmlSourceViewModel(data.XmlSource, Solution);
					newItem.Updated += new EventHandler(Children_Updated);
					XmlSources.Add(newItem);
					Solution.XmlSourceList.Add(data.XmlSource);
					Items.Add(newItem);
					OnUpdated(this, null);
					if (data.ShowItemInTreeView == true)
					{
						newItem.ShowInTreeView();
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies xml specification source deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteXmlSourcePerformed(XmlSourceEventArgs data)
		{
			bool isItemMatch = false;
			if (data != null && data.XmlSource != null)
			{
				foreach (XmlSourceViewModel item in XmlSources.ToList<XmlSourceViewModel>())
				{
					if (item.XmlSource.SpecificationSourceID == data.XmlSource.SpecificationSourceID)
					{
						// remove item from tabs, if present
						WorkspaceEventArgs message = new WorkspaceEventArgs();
						message.ItemID = item.XmlSource.SpecificationSourceID;
						Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

						// delete item
						isItemMatch = true;
						XmlSources.Remove(item);
						Solution.XmlSourceList.Remove(item.XmlSource);
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

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DatabaseSource lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DatabaseSourceViewModel> DatabaseSources { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets XmlSource lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<XmlSourceViewModel> XmlSources { get; set; }

		#endregion "Properties"

		#region "Methods"
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

			if (data is XmlSourceEventArgs && (data as XmlSourceEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}

			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the corresponding solution.</summary>
		/// 
		/// <param name="solution">The corresponding solution.</param>
		///--------------------------------------------------------------------------------
		public void UpdateSolution(Solution solution)
		{
			Solution = solution;
			foreach (XmlSourceViewModel spec in Items.OfType<XmlSourceViewModel>())
			{
				spec.Solution = solution;
				spec.XmlSource.Solution = solution;
			}
			foreach (DatabaseSourceViewModel spec in Items.OfType<DatabaseSourceViewModel>())
			{
				spec.Solution = solution;
				spec.DatabaseSource.Solution = solution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads specification sources into the view model.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadSpecificationSources(Solution solution)
		{
			// attach the specification sources
			Items.Clear();
			if (DatabaseSources == null)
			{
				DatabaseSources = new EnterpriseDataObjectList<DatabaseSourceViewModel>();
			}
			if (XmlSources == null)
			{
				XmlSources = new EnterpriseDataObjectList<XmlSourceViewModel>();
			}
			foreach (DatabaseSource source in solution.DatabaseSourceList)
			{
				DatabaseSourceViewModel sourceView = new DatabaseSourceViewModel(source, solution);
				sourceView.Updated += new EventHandler(Children_Updated);
				DatabaseSources.Add(sourceView);
				Items.Add(sourceView);
			}
			foreach (XmlSource source in solution.XmlSourceList)
			{
				XmlSourceViewModel sourceView = new XmlSourceViewModel(source, solution);
				sourceView.Updated += new EventHandler(Children_Updated);
				XmlSources.Add(sourceView);
				Items.Add(sourceView);
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
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
				foreach (XmlSourceViewModel item in XmlSources)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
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
			foreach (XmlSourceViewModel item in XmlSources)
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
				foreach (DatabaseSourceViewModel sourceView in DatabaseSources)
				{
					sourceView.Updated -= Children_Updated;
					sourceView.Dispose();
				}
				DatabaseSources.Clear();
				DatabaseSources = null;
			}
			if (XmlSources != null)
			{
				foreach (XmlSourceViewModel sourceView in XmlSources)
				{
					sourceView.Updated -= Children_Updated;
					sourceView.Dispose();
				}
				XmlSources.Clear();
				XmlSources = null;
			}
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
			OnUpdated(this, null);
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
			newItem.TransformDataFromObject(copyItem.DatabaseSource, null, false);
			newItem.SpecificationSourceID = Guid.NewGuid();
			newItem.Solution = Solution;
			DatabaseSourceViewModel newView = new DatabaseSourceViewModel(newItem, Solution);
			newView.ResetModified(true);
			DatabaseSources.Add(newView);
			Items.Add(newView);

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
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public XmlSourceViewModel PasteXmlSource(XmlSourceViewModel copyItem, bool savePaste = true)
		{
			XmlSource newItem = new XmlSource();
			newItem.TransformDataFromObject(copyItem.XmlSource, null, false);
			newItem.SpecificationSourceID = Guid.NewGuid();
			newItem.Solution = Solution;
			XmlSourceViewModel newView = new XmlSourceViewModel(newItem, Solution);
			newView.ResetModified(true);
			XmlSources.Add(newView);
			Items.Add(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.XmlSourceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SpecificationSourcesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_SpecificationSources;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		///--------------------------------------------------------------------------------
		public SpecificationSourcesViewModel(Solution solution)
		{
			Name = Resources.DisplayValues.NodeName_SpecificationSources;
			Solution = solution;
			LoadSpecificationSources(solution);
		}
		#endregion "Constructors"
    }
}
