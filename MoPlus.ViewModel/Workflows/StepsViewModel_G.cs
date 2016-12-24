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
	/// Step instances.</summary>
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
	public partial class StepsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStep.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStep
		{
			get
			{
				return DisplayValues.ContextMenu_NewStep;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStepToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStepToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepToolTip;
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
			foreach (StepViewModel item in Items.OfType<StepViewModel>())
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
			foreach (StepViewModel item in Steps)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (StepViewModel item in ItemsToAdd.OfType<StepViewModel>())
			{
				item.Update();
				Steps.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (StepViewModel item in ItemsToDelete.OfType<StepViewModel>())
			{
				item.Delete();
				Steps.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (StepViewModel item in Steps)
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
		/// <summary>This method processes the new step command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStepCommand()
		{
			StepEventArgs message = new StepEventArgs();
			message.Step = new Step();
			message.Step.StepID = Guid.NewGuid();
			message.Step.StageID = Stage.StageID;
			message.Step.Stage = Stage;
			message.StageID = Stage.StageID;
			message.Step.Solution = Solution;
			message.Solution = Solution;
			if (message.Step.Stage != null)
			{
				message.Step.Order = message.Step.Stage.StepList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepEventArgs>(MediatorMessages.Command_EditStepRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies step updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStepPerformed(StepEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Step != null)
				{
					foreach (StepViewModel item in Steps)
					{
						if (item.Step.StepID == data.Step.StepID)
						{
							isItemMatch = true;
							item.Step.TransformDataFromObject(data.Step, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Step
						data.Step.Stage = Stage;
						StepViewModel newItem = new StepViewModel(data.Step, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Steps.Add(newItem);
						Stage.StepList.Add(newItem.Step);
						Solution.StepList.Add(newItem.Step);
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
		/// <summary>This method applies step deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStepPerformed(StepEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Step != null)
				{
					foreach (StepViewModel item in Steps.ToList<StepViewModel>())
					{
						if (item.Step.StepID == data.Step.StepID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Step.StepID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is StepTransitionViewModel)
								{
									StepTransitionViewModel child = item.Items[i] as StepTransitionViewModel;
									StepTransitionEventArgs childMessage = new StepTransitionEventArgs();
									childMessage.StepTransition = child.StepTransition;
									childMessage.ToStepID = item.Step.StepID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteStepTransitionPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Steps.Remove(item);
							Stage.StepList.Remove(item.Step);
							Items.Remove(item);
							Stage.ResetModified(true);
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
		/// <summary>This property gets or sets Step lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StepViewModel> Steps { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Stage.</summary>
		///--------------------------------------------------------------------------------
		public Stage Stage { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Steps into the view model.</summary>
		///
		/// <param name="stage">The stage to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadSteps(Stage stage, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Steps == null)
			{
				Steps = new EnterpriseDataObjectList<StepViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Step item in stage.StepList)
				{
					StepViewModel itemView = new StepViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Steps.Add(itemView);
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
				foreach (StepViewModel item in Steps)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (StepViewModel item in Steps)
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
			if (Steps != null)
			{
				foreach (StepViewModel itemView in Steps)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Steps.Clear();
				Steps = null;
			}
			Stage = null;
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
			if (data is StepEventArgs && (data as StepEventArgs).StageID == Stage.StageID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (StepViewModel model in Steps)
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
		public StepViewModel PasteStep(StepViewModel copyItem, bool savePaste = true)
		{
			Step newItem = new Step();
			newItem.ReverseInstance = new Step();
			newItem.TransformDataFromObject(copyItem.Step, null, false);
			newItem.StepID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Stage = Stage;
			newItem.Solution = Solution;
			StepViewModel newView = new StepViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddStep(newView);

			// paste children
			foreach (StepTransitionViewModel childView in copyItem.StepTransitions)
			{
				newView.PasteStepTransition(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.StepList.Add(newItem);
				Stage.StepList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Step to the view model.</summary>
		/// 
		/// <param name="itemView">The Step to add.</param>
		///--------------------------------------------------------------------------------
		public void AddStep(StepViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Steps.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Step from the view model.</summary>
		/// 
		/// <param name="itemView">The Step to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStep(StepViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Steps.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StepsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Steps;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="stage">The stage to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public StepsViewModel(Stage stage, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Steps;
			Solution = solution;
			Stage = stage;
			LoadSteps(stage, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
