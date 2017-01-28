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
	/// ModelObject instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/20/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelObjectsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelObject.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelObject
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObject;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelObjectToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelObjectToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelObjectToolTip;
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
			foreach (ModelObjectViewModel item in Items.OfType<ModelObjectViewModel>())
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
			foreach (ModelObjectViewModel item in ModelObjects)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (ModelObjectViewModel item in ItemsToAdd.OfType<ModelObjectViewModel>())
			{
				item.Update();
				ModelObjects.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (ModelObjectViewModel item in ItemsToDelete.OfType<ModelObjectViewModel>())
			{
				item.Delete();
				ModelObjects.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (ModelObjectViewModel item in ModelObjects)
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
		/// <summary>This method processes the new modelobject command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelObjectCommand()
		{
			ModelObjectEventArgs message = new ModelObjectEventArgs();
			message.ModelObject = new ModelObject();
			message.ModelObject.ModelObjectID = Guid.NewGuid();
			message.ModelObject.ModelID = Model.ModelID;
			message.ModelObject.Model = Model;
			message.ModelID = Model.ModelID;
			message.ModelObject.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelObjectEventArgs>(MediatorMessages.Command_EditModelObjectRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies modelobject updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelObjectPerformed(ModelObjectEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.ModelObject != null)
				{
					foreach (ModelObjectViewModel item in ModelObjects)
					{
						if (item.ModelObject.ModelObjectID == data.ModelObject.ModelObjectID)
						{
							isItemMatch = true;
							item.ModelObject.TransformDataFromObject(data.ModelObject, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new ModelObject
						data.ModelObject.Model = Model;
						ModelObjectViewModel newItem = new ModelObjectViewModel(data.ModelObject, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						ModelObjects.Add(newItem);
						Model.ModelObjectList.Add(newItem.ModelObject);
						Solution.ModelObjectList.Add(newItem.ModelObject);
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
		/// <summary>This method applies modelobject deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelObjectPerformed(ModelObjectEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.ModelObject != null)
				{
					foreach (ModelObjectViewModel item in ModelObjects.ToList<ModelObjectViewModel>())
					{
						if (item.ModelObject.ModelObjectID == data.ModelObject.ModelObjectID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.ModelObject.ModelObjectID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is ModelPropertyViewModel)
								{
									ModelPropertyViewModel child = item.Items[i] as ModelPropertyViewModel;
									ModelPropertyEventArgs childMessage = new ModelPropertyEventArgs();
									childMessage.ModelProperty = child.ModelProperty;
									childMessage.ModelObjectID = item.ModelObject.ModelObjectID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteModelPropertyPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							ModelObjects.Remove(item);
							Model.ModelObjectList.Remove(item.ModelObject);
							Items.Remove(item);
							Model.ResetModified(true);
							OnUpdated(this, null);
							#region protected

							// refresh solution
							ModelEventArgs deleteMessage = new ModelEventArgs();
							deleteMessage.Solution = Solution;
							deleteMessage.SolutionID = Solution.SolutionID;
							deleteMessage.ModelID = item.ModelID;
							Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_ReloadModelDataRequested, deleteMessage);
							#endregion protected
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
		/// <summary>This property gets or sets ModelObject lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelObjectViewModel> ModelObjects { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Model.</summary>
		///--------------------------------------------------------------------------------
		public Model Model { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads ModelObjects into the view model.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelObjects(Model model, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (ModelObjects == null)
			{
				ModelObjects = new EnterpriseDataObjectList<ModelObjectViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (ModelObject item in model.ModelObjectList)
				{
					ModelObjectViewModel itemView = new ModelObjectViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					ModelObjects.Add(itemView);
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
				foreach (ModelObjectViewModel item in ModelObjects)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (ModelObjectViewModel item in ModelObjects)
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
			if (ModelObjects != null)
			{
				foreach (ModelObjectViewModel itemView in ModelObjects)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				ModelObjects.Clear();
				ModelObjects = null;
			}
			Model = null;
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
			if (data is ModelObjectEventArgs && (data as ModelObjectEventArgs).ModelID == Model.ModelID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (ModelObjectViewModel model in ModelObjects)
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
		public ModelObjectViewModel PasteModelObject(ModelObjectViewModel copyItem, bool savePaste = true)
		{
			ModelObject newItem = new ModelObject();
			newItem.ReverseInstance = new ModelObject();
			newItem.TransformDataFromObject(copyItem.ModelObject, null, false);
			newItem.ModelObjectID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			// try to find referenced ModelObject by existing id first, second by old id, finally by name
			newItem.ParentModelObject = Solution.ModelObjectList.FindByID((Guid)copyItem.ModelObject.ParentModelObjectID);
			if (newItem.ParentModelObject == null && Solution.PasteNewGuids[copyItem.ModelObject.ParentModelObjectID.ToString()] is Guid)
			{
				newItem.ParentModelObject = Solution.ModelObjectList.FindByID((Guid)Solution.PasteNewGuids[copyItem.ModelObject.ParentModelObjectID.ToString()]);
			}
			if (newItem.ParentModelObject == null)
			{
				newItem.ParentModelObject = Solution.ModelObjectList.Find("Name", copyItem.ModelObject.Name);
			}
			if (newItem.ParentModelObject == null)
			{
				newItem.OldParentModelObjectID = newItem.ParentModelObjectID;
				newItem.ParentModelObjectID = Guid.Empty;
			}
			newItem.Model = Model;
			newItem.Solution = Solution;
			ModelObjectViewModel newView = new ModelObjectViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddModelObject(newView);

			// paste children
			foreach (ModelPropertyViewModel childView in copyItem.ModelProperties)
			{
				newView.PasteModelProperty(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.ModelObjectList.Add(newItem);
				Model.ModelObjectList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of ModelObject to the view model.</summary>
		/// 
		/// <param name="itemView">The ModelObject to add.</param>
		///--------------------------------------------------------------------------------
		public void AddModelObject(ModelObjectViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			ModelObjects.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of ModelObject from the view model.</summary>
		/// 
		/// <param name="itemView">The ModelObject to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteModelObject(ModelObjectViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			ModelObjects.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelObjectsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_ModelObjects;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public ModelObjectsViewModel(Model model, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_ModelObjects;
			Solution = solution;
			Model = model;
			LoadModelObjects(model, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
