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
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Models;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the ModelObjectViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/11/2014</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelObjectDataViewModel : DialogEditWorkspaceViewModel
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
		/// <summary>This property gets MenuLabeNewlObjectInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelObjectInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewObjectInstanceToolTip;
			}
		}

		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new ObjectInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewObjectInstanceCommand()
		{
			ObjectInstanceEventArgs message = new ObjectInstanceEventArgs();
			message.ObjectInstance = new ObjectInstance();
			message.ObjectInstance.ObjectInstanceID = Guid.NewGuid();
			message.ObjectInstance.ModelObjectID = ModelObjectID;
			message.ObjectInstance.ModelObject = Solution.ModelObjectList.FindByID(ModelObjectID);
			message.ObjectInstance.Solution = Solution;
			message.ModelObjectID = ModelObjectID;
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
		/// <summary>This property gets or sets Model.</summary>
		///--------------------------------------------------------------------------------
		public Model Model { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ObjectInstance.</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstance ObjectInstance { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObject.</summary>
		///--------------------------------------------------------------------------------
		public ModelObject ModelObject { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelObjectID
		{
			get
			{
				if (ModelObject != null)
				{
					return ModelObject.ModelObjectID;
				}
				return Guid.Empty;
			}
		}
		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of ModelObjectData into the view model.</summary>
		/// 
		/// <param name="model">The Model to load.</param>
		/// <param name="modelObject">The ModelObject to load.</param>
		/// <param name="objectInstance">The ObjectInstance to load.</param>
		/// <param name="solution">The Solution to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelObjectData(Model model, ModelObject modelObject, ObjectInstance objectInstance, Solution solution, bool loadChildren = true)
		{
			// attach the ModelObject
			Model = model;
			ModelObject = modelObject;
			ObjectInstance = objectInstance;
			Solution = solution;
			ItemID = ModelObject.ModelID;
			Items.Clear();
			if (loadChildren == true)
			{

				// attach ObjectInstances
				if (ObjectInstances == null)
				{
					ObjectInstances = new EnterpriseDataObjectList<ObjectInstanceViewModel>();
					foreach (ObjectInstance item in modelObject.ObjectInstanceList)
					{
						if (item.Solution == null)
						{
							// TODO: this is a hack
							item.Solution = solution;
						}
						if (objectInstance == null || item.ParentObjectInstanceID == objectInstance.ObjectInstanceID)
						{
							ObjectInstanceViewModel itemView = new ObjectInstanceViewModel(item, solution);
							itemView.Updated += new EventHandler(Children_Updated);
							ObjectInstances.Add(itemView);
							Items.Add(itemView);
						}
					}
				}
				#region protected
				#endregion protected

				Refresh(false);
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
					item.Refresh(refreshChildren, refreshLevel - 1);
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
			Model = null;
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
			if (data is ObjectInstanceEventArgs && ObjectInstance != null && (data as ObjectInstanceEventArgs).ObjectInstance.ParentObjectInstanceID == ObjectInstance.ObjectInstanceID)
			{
				return this;
			}
			if (data is ObjectInstanceEventArgs && ObjectInstance != null && (data as ObjectInstanceEventArgs).ObjectInstance.ParentObjectInstanceID == null && (data as ObjectInstanceEventArgs).ModelObjectID == ModelObjectID)
			{
				return this;
			}
			if (data is ObjectInstanceEventArgs && ObjectInstance == null && (data as ObjectInstanceEventArgs).ModelObjectID == ModelObjectID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;

			foreach (ObjectInstanceViewModel instance in ObjectInstances)
			{
				parentModel = instance.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}

			return null;
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelObjectDataViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Instances;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="modelObject">The model object to load.</param>
		/// <param name="objectInstance">The ObjectInstance to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public ModelObjectDataViewModel(Model model, ModelObject modelObject, ObjectInstance objectInstance, Solution solution, bool loadChildren = true)
		{
			Name = modelObject.ModelObjectName + " " + Resources.DisplayValues.NodeName_Instances;
			Solution = solution;
			ModelObject = modelObject;
			LoadModelObjectData(model, modelObject, objectInstance, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
