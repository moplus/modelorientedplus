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
	/// StageTransition instances.</summary>
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
	public partial class StageTransitionsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStageTransition.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStageTransition
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageTransition;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStageTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStageTransitionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageTransitionToolTip;
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
			foreach (StageTransitionViewModel item in Items.OfType<StageTransitionViewModel>())
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
			foreach (StageTransitionViewModel item in StageTransitions)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (StageTransitionViewModel item in ItemsToAdd.OfType<StageTransitionViewModel>())
			{
				item.Update();
				StageTransitions.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (StageTransitionViewModel item in ItemsToDelete.OfType<StageTransitionViewModel>())
			{
				item.Delete();
				StageTransitions.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (StageTransitionViewModel item in StageTransitions)
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
		/// <summary>This method processes the new stagetransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStageTransitionCommand()
		{
			StageTransitionEventArgs message = new StageTransitionEventArgs();
			message.StageTransition = new StageTransition();
			message.StageTransition.StageTransitionID = Guid.NewGuid();
			message.StageTransition.ToStageID = Stage.StageID;
			message.StageTransition.ToStage = Stage;
			message.ToStageID = Stage.StageID;
			message.StageTransition.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageTransitionEventArgs>(MediatorMessages.Command_EditStageTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies stagetransition updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStageTransitionPerformed(StageTransitionEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.StageTransition != null)
				{
					foreach (StageTransitionViewModel item in StageTransitions)
					{
						if (item.StageTransition.StageTransitionID == data.StageTransition.StageTransitionID)
						{
							isItemMatch = true;
							item.StageTransition.TransformDataFromObject(data.StageTransition, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new StageTransition
						data.StageTransition.ToStage = Stage;
						StageTransitionViewModel newItem = new StageTransitionViewModel(data.StageTransition, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						StageTransitions.Add(newItem);
						Stage.ToStageTransitionList.Add(newItem.StageTransition);
						Solution.StageTransitionList.Add(newItem.StageTransition);
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
		/// <summary>This method applies stagetransition deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStageTransitionPerformed(StageTransitionEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.StageTransition != null)
				{
					foreach (StageTransitionViewModel item in StageTransitions.ToList<StageTransitionViewModel>())
					{
						if (item.StageTransition.StageTransitionID == data.StageTransition.StageTransitionID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.StageTransition.StageTransitionID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							StageTransitions.Remove(item);
							Stage.ToStageTransitionList.Remove(item.StageTransition);
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
		/// <summary>This property gets or sets StageTransition lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StageTransitionViewModel> StageTransitions { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Stage.</summary>
		///--------------------------------------------------------------------------------
		public Stage Stage { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads StageTransitions into the view model.</summary>
		///
		/// <param name="stage">The stage to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStageTransitions(Stage stage, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (StageTransitions == null)
			{
				StageTransitions = new EnterpriseDataObjectList<StageTransitionViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (StageTransition item in stage.ToStageTransitionList)
				{
					StageTransitionViewModel itemView = new StageTransitionViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					StageTransitions.Add(itemView);
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
				foreach (StageTransitionViewModel item in StageTransitions)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (StageTransitionViewModel item in StageTransitions)
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
			if (StageTransitions != null)
			{
				foreach (StageTransitionViewModel itemView in StageTransitions)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				StageTransitions.Clear();
				StageTransitions = null;
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
			if (data is StageTransitionEventArgs && (data as StageTransitionEventArgs).ToStageID == Stage.StageID)
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
		public StageTransitionViewModel PasteStageTransition(StageTransitionViewModel copyItem, bool savePaste = true)
		{
			StageTransition newItem = new StageTransition();
			newItem.ReverseInstance = new StageTransition();
			newItem.TransformDataFromObject(copyItem.StageTransition, null, false);
			newItem.StageTransitionID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.ToStage = Stage;
			newItem.Solution = Solution;
			StageTransitionViewModel newView = new StageTransitionViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddStageTransition(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.StageTransitionList.Add(newItem);
				Stage.ToStageTransitionList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of StageTransition to the view model.</summary>
		/// 
		/// <param name="itemView">The StageTransition to add.</param>
		///--------------------------------------------------------------------------------
		public void AddStageTransition(StageTransitionViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			StageTransitions.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of StageTransition from the view model.</summary>
		/// 
		/// <param name="itemView">The StageTransition to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStageTransition(StageTransitionViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			StageTransitions.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StageTransitionsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_StageTransitions;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="stage">The stage to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public StageTransitionsViewModel(Stage stage, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_StageTransitions;
			Solution = solution;
			Stage = stage;
			LoadStageTransitions(stage, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
