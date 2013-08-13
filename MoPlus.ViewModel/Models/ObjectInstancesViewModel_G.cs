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
	/// ObjectInstance instances.</summary>
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
	public partial class ObjectInstancesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewObjectInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstance;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewObjectInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewObjectInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstanceToolTip;
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
			foreach (ObjectInstanceViewModel item in Items.OfType<ObjectInstanceViewModel>())
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
			foreach (ObjectInstanceViewModel item in ObjectInstances)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (ObjectInstanceViewModel item in ItemsToAdd.OfType<ObjectInstanceViewModel>())
			{
				item.Update();
				ObjectInstances.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (ObjectInstanceViewModel item in ItemsToDelete.OfType<ObjectInstanceViewModel>())
			{
				item.Delete();
				ObjectInstances.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (ObjectInstanceViewModel item in ObjectInstances)
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
		/// <summary>This method processes the new objectinstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewObjectInstanceCommand()
		{
			ObjectInstanceEventArgs message = new ObjectInstanceEventArgs();
			message.ObjectInstance = new ObjectInstance();
			message.ObjectInstance.ObjectInstanceID = Guid.NewGuid();
			message.ObjectInstance.ModelObjectID = ModelObject.ModelObjectID;
			message.ObjectInstance.ModelObject = ModelObject;
			message.ModelObjectID = ModelObject.ModelObjectID;
			message.ObjectInstance.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ObjectInstanceEventArgs>(MediatorMessages.Command_EditObjectInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies objectinstance updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditObjectInstancePerformed(ObjectInstanceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.ObjectInstance != null)
				{
					foreach (ObjectInstanceViewModel item in ObjectInstances)
					{
						if (item.ObjectInstance.ObjectInstanceID == data.ObjectInstance.ObjectInstanceID)
						{
							isItemMatch = true;
							item.ObjectInstance.TransformDataFromObject(data.ObjectInstance, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new ObjectInstance
						data.ObjectInstance.ModelObject = ModelObject;
						ObjectInstanceViewModel newItem = new ObjectInstanceViewModel(data.ObjectInstance, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						ObjectInstances.Add(newItem);
						ModelObject.ObjectInstanceList.Add(newItem.ObjectInstance);
						Solution.ObjectInstanceList.Add(newItem.ObjectInstance);
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
		/// <summary>This method applies objectinstance deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteObjectInstancePerformed(ObjectInstanceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.ObjectInstance != null)
				{
					foreach (ObjectInstanceViewModel item in ObjectInstances.ToList<ObjectInstanceViewModel>())
					{
						if (item.ObjectInstance.ObjectInstanceID == data.ObjectInstance.ObjectInstanceID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.ObjectInstance.ObjectInstanceID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is PropertyInstanceViewModel)
								{
									PropertyInstanceViewModel child = item.Items[i] as PropertyInstanceViewModel;
									PropertyInstanceEventArgs childMessage = new PropertyInstanceEventArgs();
									childMessage.PropertyInstance = child.PropertyInstance;
									childMessage.ObjectInstanceID = item.ObjectInstance.ObjectInstanceID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeletePropertyInstancePerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							ObjectInstances.Remove(item);
							ModelObject.ObjectInstanceList.Remove(item.ObjectInstance);
							Items.Remove(item);
							ModelObject.ResetModified(true);
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
		/// <summary>This property gets or sets ObjectInstance lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ObjectInstanceViewModel> ObjectInstances { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObject.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject ModelObject { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads ObjectInstances into the view model.</summary>
		///
		/// <param name="modelObject">The modelObject to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadObjectInstances(ModelObject modelObject, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (ObjectInstances == null)
			{
				ObjectInstances = new EnterpriseDataObjectList<ObjectInstanceViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (ObjectInstance item in modelObject.ObjectInstanceList)
				{
					ObjectInstanceViewModel itemView = new ObjectInstanceViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					ObjectInstances.Add(itemView);
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
				foreach (ObjectInstanceViewModel item in ObjectInstances)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (ObjectInstanceViewModel item in ObjectInstances)
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
			if (ObjectInstances != null)
			{
				foreach (ObjectInstanceViewModel itemView in ObjectInstances)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				ObjectInstances.Clear();
				ObjectInstances = null;
			}
			ModelObject = null;
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
			if (data is ObjectInstanceEventArgs && (data as ObjectInstanceEventArgs).ModelObjectID == ModelObject.ModelObjectID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (ObjectInstanceViewModel model in ObjectInstances)
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
		public ObjectInstanceViewModel PasteObjectInstance(ObjectInstanceViewModel copyItem, bool savePaste = true)
		{
			ObjectInstance newItem = new ObjectInstance();
			newItem.ReverseInstance = new ObjectInstance();
			newItem.TransformDataFromObject(copyItem.ObjectInstance, null, false);
			newItem.ObjectInstanceID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.ModelObject = ModelObject;
			newItem.Solution = Solution;
			ObjectInstanceViewModel newView = new ObjectInstanceViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddObjectInstance(newView);

			// paste children
			foreach (PropertyInstanceViewModel childView in copyItem.PropertyInstances)
			{
				newView.PastePropertyInstance(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.ObjectInstanceList.Add(newItem);
				ModelObject.ObjectInstanceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of ObjectInstance to the view model.</summary>
		/// 
		/// <param name="itemView">The ObjectInstance to add.</param>
		///--------------------------------------------------------------------------------
		public void AddObjectInstance(ObjectInstanceViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			ObjectInstances.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of ObjectInstance from the view model.</summary>
		/// 
		/// <param name="itemView">The ObjectInstance to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteObjectInstance(ObjectInstanceViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			ObjectInstances.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstancesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_ObjectInstances;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="modelObject">The modelObject to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public ObjectInstancesViewModel(ModelObject modelObject, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_ObjectInstances;
			Solution = solution;
			ModelObject = modelObject;
			LoadObjectInstances(modelObject, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
