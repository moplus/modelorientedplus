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
	/// StateModel instances.</summary>
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
	public partial class StateModelsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStateModel.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateModel
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateModel;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStateModelToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStateModelToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStateModelToolTip;
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
			foreach (StateModelViewModel item in Items.OfType<StateModelViewModel>())
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
			foreach (StateModelViewModel item in StateModels)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (StateModelViewModel item in ItemsToAdd.OfType<StateModelViewModel>())
			{
				item.Update();
				StateModels.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (StateModelViewModel item in ItemsToDelete.OfType<StateModelViewModel>())
			{
				item.Delete();
				StateModels.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (StateModelViewModel item in StateModels)
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
		/// <summary>This method processes the new statemodel command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStateModelCommand()
		{
			StateModelEventArgs message = new StateModelEventArgs();
			message.StateModel = new StateModel();
			message.StateModel.StateModelID = Guid.NewGuid();
			message.StateModel.EntityID = Entity.EntityID;
			message.StateModel.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.StateModel.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StateModelEventArgs>(MediatorMessages.Command_EditStateModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies statemodel updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStateModelPerformed(StateModelEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.StateModel != null)
				{
					foreach (StateModelViewModel item in StateModels)
					{
						if (item.StateModel.StateModelID == data.StateModel.StateModelID)
						{
							isItemMatch = true;
							item.StateModel.TransformDataFromObject(data.StateModel, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new StateModel
						data.StateModel.Entity = Entity;
						StateModelViewModel newItem = new StateModelViewModel(data.StateModel, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						StateModels.Add(newItem);
						Entity.StateModelList.Add(newItem.StateModel);
						Solution.StateModelList.Add(newItem.StateModel);
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
		/// <summary>This method applies statemodel deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStateModelPerformed(StateModelEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.StateModel != null)
				{
					foreach (StateModelViewModel item in StateModels.ToList<StateModelViewModel>())
					{
						if (item.StateModel.StateModelID == data.StateModel.StateModelID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.StateModel.StateModelID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is StateViewModel)
								{
									StateViewModel child = item.Items[i] as StateViewModel;
									StateEventArgs childMessage = new StateEventArgs();
									childMessage.State = child.State;
									childMessage.StateModelID = item.StateModel.StateModelID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteStatePerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							StateModels.Remove(item);
							Entity.StateModelList.Remove(item.StateModel);
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
		/// <summary>This property gets or sets StateModel lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<StateModelViewModel> StateModels { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads StateModels into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStateModels(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (StateModels == null)
			{
				StateModels = new EnterpriseDataObjectList<StateModelViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (StateModel item in entity.StateModelList)
				{
					StateModelViewModel itemView = new StateModelViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					StateModels.Add(itemView);
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
				foreach (StateModelViewModel item in StateModels)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (StateModelViewModel item in StateModels)
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
			if (StateModels != null)
			{
				foreach (StateModelViewModel itemView in StateModels)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				StateModels.Clear();
				StateModels = null;
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
			if (data is StateModelEventArgs && (data as StateModelEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (StateModelViewModel model in StateModels)
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
		public StateModelViewModel PasteStateModel(StateModelViewModel copyItem, bool savePaste = true)
		{
			StateModel newItem = new StateModel();
			newItem.ReverseInstance = new StateModel();
			newItem.TransformDataFromObject(copyItem.StateModel, null, false);
			newItem.StateModelID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			StateModelViewModel newView = new StateModelViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddStateModel(newView);

			// paste children
			foreach (StateViewModel childView in copyItem.States)
			{
				newView.PasteState(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.StateModelList.Add(newItem);
				Entity.StateModelList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of StateModel to the view model.</summary>
		/// 
		/// <param name="itemView">The StateModel to add.</param>
		///--------------------------------------------------------------------------------
		public void AddStateModel(StateModelViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			StateModels.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of StateModel from the view model.</summary>
		/// 
		/// <param name="itemView">The StateModel to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteStateModel(StateModelViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			StateModels.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StateModelsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_StateModels;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public StateModelsViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_StateModels;
			Solution = solution;
			Entity = entity;
			LoadStateModels(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
