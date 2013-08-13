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

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for collections of
	/// Model instances.</summary>
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
	public partial class ModelsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModel.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModel
		{
			get
			{
				return DisplayValues.ContextMenu_NewModel;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelToolTip;
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
			foreach (ModelViewModel item in Items.OfType<ModelViewModel>())
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
			foreach (ModelViewModel item in Models)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (ModelViewModel item in ItemsToAdd.OfType<ModelViewModel>())
			{
				item.Update();
				Models.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (ModelViewModel item in ItemsToDelete.OfType<ModelViewModel>())
			{
				item.Delete();
				Models.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (ModelViewModel item in Models)
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
		/// <summary>This method processes the new model command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelCommand()
		{
			ModelEventArgs message = new ModelEventArgs();
			message.Model = new Model();
			message.Model.ModelID = Guid.NewGuid();
			message.Model.SolutionID = Solution.SolutionID;
			message.Model.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.Model.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_EditModelRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies model updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelPerformed(ModelEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Model != null)
				{
					foreach (ModelViewModel item in Models)
					{
						if (item.Model.ModelID == data.Model.ModelID)
						{
							isItemMatch = true;
							item.Model.TransformDataFromObject(data.Model, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Model
						data.Model.Solution = Solution;
						ModelViewModel newItem = new ModelViewModel(data.Model, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Models.Add(newItem);
						Solution.ModelList.Add(newItem.Model);
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
		/// <summary>This method applies model deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelPerformed(ModelEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Model != null)
				{
					foreach (ModelViewModel item in Models.ToList<ModelViewModel>())
					{
						if (item.Model.ModelID == data.Model.ModelID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Model.ModelID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is EnumerationViewModel)
								{
									EnumerationViewModel child = item.Items[i] as EnumerationViewModel;
									EnumerationEventArgs childMessage = new EnumerationEventArgs();
									childMessage.Enumeration = child.Enumeration;
									childMessage.ModelID = item.Model.ModelID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.EnumerationsFolder.ProcessDeleteEnumerationPerformed(childMessage);
								}
								if (item.Items[i] is ModelObjectViewModel)
								{
									ModelObjectViewModel child = item.Items[i] as ModelObjectViewModel;
									ModelObjectEventArgs childMessage = new ModelObjectEventArgs();
									childMessage.ModelObject = child.ModelObject;
									childMessage.ModelID = item.Model.ModelID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ModelObjectsFolder.ProcessDeleteModelObjectPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Models.Remove(item);
							Solution.ModelList.Remove(item.Model);
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
		/// <summary>This property gets or sets Model lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelViewModel> Models { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Models into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModels(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Models == null)
			{
				Models = new EnterpriseDataObjectList<ModelViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Model item in solution.ModelList)
				{
					ModelViewModel itemView = new ModelViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Models.Add(itemView);
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
				foreach (ModelViewModel item in Models)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (ModelViewModel item in Models)
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
			if (Models != null)
			{
				foreach (ModelViewModel itemView in Models)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Models.Clear();
				Models = null;
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
			if (data is ModelEventArgs && (data as ModelEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (ModelViewModel model in Models)
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
		public ModelViewModel PasteModel(ModelViewModel copyItem, bool savePaste = true)
		{
			Model newItem = new Model();
			newItem.ReverseInstance = new Model();
			newItem.TransformDataFromObject(copyItem.Model, null, false);
			newItem.ModelID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			ModelViewModel newView = new ModelViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddModel(newView);

			// paste children
			foreach (EnumerationViewModel childView in copyItem.EnumerationsFolder.Enumerations)
			{
				newView.EnumerationsFolder.PasteEnumeration(childView, savePaste);
			}
			foreach (ModelObjectViewModel childView in copyItem.ModelObjectsFolder.ModelObjects)
			{
				newView.ModelObjectsFolder.PasteModelObject(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.ModelList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Model to the view model.</summary>
		/// 
		/// <param name="itemView">The Model to add.</param>
		///--------------------------------------------------------------------------------
		public void AddModel(ModelViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Models.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Model from the view model.</summary>
		/// 
		/// <param name="itemView">The Model to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteModel(ModelViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Models.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Models;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public ModelsViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Models;
			Solution = solution;
			LoadModels(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
