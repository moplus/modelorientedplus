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

namespace MoPlus.ViewModel.Workflows
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for collections of
	/// Workflow instances.</summary>
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
	public partial class WorkflowsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewWorkflow.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewWorkflow
		{
			get
			{
				return DisplayValues.ContextMenu_NewWorkflow;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewWorkflowToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewWorkflowToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewWorkflowToolTip;
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
			foreach (WorkflowViewModel item in Items.OfType<WorkflowViewModel>())
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
			foreach (WorkflowViewModel item in Workflows)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (WorkflowViewModel item in ItemsToAdd.OfType<WorkflowViewModel>())
			{
				item.Update();
				Workflows.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (WorkflowViewModel item in ItemsToDelete.OfType<WorkflowViewModel>())
			{
				item.Delete();
				Workflows.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (WorkflowViewModel item in Workflows)
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
		/// <summary>This method processes the new workflow command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewWorkflowCommand()
		{
			WorkflowEventArgs message = new WorkflowEventArgs();
			message.Workflow = new Workflow();
			message.Workflow.WorkflowID = Guid.NewGuid();
			message.Workflow.SolutionID = Solution.SolutionID;
			message.Workflow.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.Workflow.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<WorkflowEventArgs>(MediatorMessages.Command_EditWorkflowRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies workflow updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditWorkflowPerformed(WorkflowEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Workflow != null)
				{
					foreach (WorkflowViewModel item in Workflows)
					{
						if (item.Workflow.WorkflowID == data.Workflow.WorkflowID)
						{
							isItemMatch = true;
							item.Workflow.TransformDataFromObject(data.Workflow, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Workflow
						data.Workflow.Solution = Solution;
						WorkflowViewModel newItem = new WorkflowViewModel(data.Workflow, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Workflows.Add(newItem);
						Solution.WorkflowList.Add(newItem.Workflow);
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
		/// <summary>This method applies workflow deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteWorkflowPerformed(WorkflowEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Workflow != null)
				{
					foreach (WorkflowViewModel item in Workflows.ToList<WorkflowViewModel>())
					{
						if (item.Workflow.WorkflowID == data.Workflow.WorkflowID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Workflow.WorkflowID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is StageViewModel)
								{
									StageViewModel child = item.Items[i] as StageViewModel;
									StageEventArgs childMessage = new StageEventArgs();
									childMessage.Stage = child.Stage;
									childMessage.WorkflowID = item.Workflow.WorkflowID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteStagePerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Workflows.Remove(item);
							Solution.WorkflowList.Remove(item.Workflow);
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
		/// <summary>This property gets or sets Workflow lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<WorkflowViewModel> Workflows { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Workflows into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadWorkflows(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Workflows == null)
			{
				Workflows = new EnterpriseDataObjectList<WorkflowViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Workflow item in solution.WorkflowList)
				{
					WorkflowViewModel itemView = new WorkflowViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Workflows.Add(itemView);
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
				foreach (WorkflowViewModel item in Workflows)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (WorkflowViewModel item in Workflows)
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
			if (Workflows != null)
			{
				foreach (WorkflowViewModel itemView in Workflows)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Workflows.Clear();
				Workflows = null;
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
			if (data is WorkflowEventArgs && (data as WorkflowEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (WorkflowViewModel model in Workflows)
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
		public WorkflowViewModel PasteWorkflow(WorkflowViewModel copyItem, bool savePaste = true)
		{
			Workflow newItem = new Workflow();
			newItem.ReverseInstance = new Workflow();
			newItem.TransformDataFromObject(copyItem.Workflow, null, false);
			newItem.WorkflowID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			WorkflowViewModel newView = new WorkflowViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddWorkflow(newView);

			// paste children
			foreach (StageViewModel childView in copyItem.Stages)
			{
				newView.PasteStage(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.WorkflowList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Workflow to the view model.</summary>
		/// 
		/// <param name="itemView">The Workflow to add.</param>
		///--------------------------------------------------------------------------------
		public void AddWorkflow(WorkflowViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Workflows.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Workflow from the view model.</summary>
		/// 
		/// <param name="itemView">The Workflow to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteWorkflow(WorkflowViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Workflows.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public WorkflowsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Workflows;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public WorkflowsViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Workflows;
			Solution = solution;
			LoadWorkflows(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
