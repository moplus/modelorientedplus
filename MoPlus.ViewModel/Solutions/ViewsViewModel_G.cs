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
	/// View instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/24/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ViewsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewView.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewView
		{
			get
			{
				return DisplayValues.ContextMenu_NewView;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewViewToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewViewToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewViewToolTip;
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
			foreach (ViewViewModel item in Items.OfType<ViewViewModel>())
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
			foreach (ViewViewModel item in Views)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (ViewViewModel item in ItemsToAdd.OfType<ViewViewModel>())
			{
				item.Update();
				Views.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (ViewViewModel item in ItemsToDelete.OfType<ViewViewModel>())
			{
				item.Delete();
				Views.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (ViewViewModel item in Views)
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
		/// <summary>This method processes the new view command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewViewCommand()
		{
			ViewEventArgs message = new ViewEventArgs();
			message.View = new View();
			message.View.ViewID = Guid.NewGuid();
			message.View.SolutionID = Solution.SolutionID;
			message.View.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.View.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ViewEventArgs>(MediatorMessages.Command_EditViewRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies view updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditViewPerformed(ViewEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.View != null)
				{
					foreach (ViewViewModel item in Views)
					{
						if (item.View.ViewID == data.View.ViewID)
						{
							isItemMatch = true;
							item.View.TransformDataFromObject(data.View, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new View
						data.View.Solution = Solution;
						ViewViewModel newItem = new ViewViewModel(data.View, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Views.Add(newItem);
						Solution.ViewList.Add(newItem.View);
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
		/// <summary>This method applies view deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteViewPerformed(ViewEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.View != null)
				{
					foreach (ViewViewModel item in Views.ToList<ViewViewModel>())
					{
						if (item.View.ViewID == data.View.ViewID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.View.ViewID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is ViewPropertyViewModel)
								{
									ViewPropertyViewModel child = item.Items[i] as ViewPropertyViewModel;
									ViewPropertyEventArgs childMessage = new ViewPropertyEventArgs();
									childMessage.ViewProperty = child.ViewProperty;
									childMessage.ViewID = item.View.ViewID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteViewPropertyPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Views.Remove(item);
							Solution.ViewList.Remove(item.View);
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
		/// <summary>This property gets or sets View lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ViewViewModel> Views { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Views into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadViews(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Views == null)
			{
				Views = new EnterpriseDataObjectList<ViewViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (View item in solution.ViewList)
				{
					ViewViewModel itemView = new ViewViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Views.Add(itemView);
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
				foreach (ViewViewModel item in Views)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (ViewViewModel item in Views)
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
			if (Views != null)
			{
				foreach (ViewViewModel itemView in Views)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Views.Clear();
				Views = null;
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
			if (data is ViewEventArgs && (data as ViewEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (ViewViewModel model in Views)
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
		public ViewViewModel PasteView(ViewViewModel copyItem, bool savePaste = true)
		{
			View newItem = new View();
			newItem.ReverseInstance = new View();
			newItem.TransformDataFromObject(copyItem.View, null, false);
			newItem.ViewID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			ViewViewModel newView = new ViewViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddView(newView);

			// paste children
			foreach (ViewPropertyViewModel childView in copyItem.ViewProperties)
			{
				newView.PasteViewProperty(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.ViewList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of View to the view model.</summary>
		/// 
		/// <param name="itemView">The View to add.</param>
		///--------------------------------------------------------------------------------
		public void AddView(ViewViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Views.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of View from the view model.</summary>
		/// 
		/// <param name="itemView">The View to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteView(ViewViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Views.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ViewsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Views;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public ViewsViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Views;
			Solution = solution;
			LoadViews(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
