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
	/// <CreatedDate>7/18/2014</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class PropertyInstanceCollectionViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstance;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstanceToolTip;
			}
		}

		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new PropertyInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyInstanceCommand()
		{
			PropertyInstanceEventArgs message = new PropertyInstanceEventArgs();
			message.PropertyInstance = new PropertyInstance();
			message.PropertyInstance.PropertyInstanceID = Guid.NewGuid();
			message.PropertyInstance.ObjectInstance = ObjectInstance;
			message.PropertyInstance.ObjectInstanceID = ObjectInstance.ObjectInstanceID;
			message.ObjectInstanceID = ObjectInstance.ObjectInstanceID;
			message.PropertyInstance.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyInstanceEventArgs>(MediatorMessages.Command_EditPropertyInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyInstance updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyInstancePerformed(PropertyInstanceEventArgs data)
		{
			if (data != null && data.PropertyInstance != null)
			{
				UpdateEditPropertyInstance(data.PropertyInstance);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of PropertyInstance.</summary>
		/// 
		/// <param name="propertyInstance">The PropertyInstance to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditPropertyInstance(PropertyInstance propertyInstance)
		{
			bool isItemMatch = false;
			foreach (PropertyInstanceViewModel item in PropertyInstances)
			{
				if (item.PropertyInstance.PropertyInstanceID == propertyInstance.PropertyInstanceID)
				{
					isItemMatch = true;
					item.PropertyInstance.TransformDataFromObject(propertyInstance, null, false);
					if (!item.PropertyInstance.ModelPropertyID.IsNullOrEmpty())
					{
						item.PropertyInstance.ModelProperty = Solution.ModelPropertyList.FindByID((Guid)item.PropertyInstance.ModelPropertyID);
					}
					item.OnUpdated(item, null);
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new PropertyInstance
				propertyInstance.ObjectInstance = ObjectInstance;
				PropertyInstanceViewModel newItem = new PropertyInstanceViewModel(propertyInstance, Solution);
				if (!newItem.PropertyInstance.ModelPropertyID.IsNullOrEmpty())
				{
					newItem.PropertyInstance.ModelProperty = Solution.ModelPropertyList.FindByID((Guid)newItem.PropertyInstance.ModelPropertyID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				PropertyInstances.Add(newItem);
				ObjectInstance.PropertyInstanceList.Add(propertyInstance);
				Solution.PropertyInstanceList.Add(newItem.PropertyInstance);
				Items.Add(newItem);
				OnUpdated(this, null);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyInstance deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedPropertyInstances(PropertyInstanceViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyInstance deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyInstancePerformed(PropertyInstanceEventArgs data)
		{
			if (data != null && data.PropertyInstance != null)
			{
				DeletePropertyInstance(data.PropertyInstance);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of PropertyInstance.</summary>
		/// 
		/// <param name="propertyInstance">The PropertyInstance to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeletePropertyInstance(PropertyInstance propertyInstance)
		{
			bool isItemMatch = false;
			foreach (PropertyInstanceViewModel item in PropertyInstances.ToList<PropertyInstanceViewModel>())
			{
				if (item.PropertyInstance.PropertyInstanceID == propertyInstance.PropertyInstanceID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.PropertyInstance.PropertyInstanceID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete PropertyInstance
					isItemMatch = true;
					PropertyInstances.Remove(item);
					ObjectInstance.PropertyInstanceList.Remove(item.PropertyInstance);
					Solution.PropertyInstanceList.Remove(item.PropertyInstance);
					Items.Remove(item);
					ObjectInstance.ResetModified(true);
					OnUpdated(this, null);
					break;
				}
			}
			if (isItemMatch == false)
			{
				ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
			}
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyInstance lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyInstanceViewModel> PropertyInstances { get; set; }

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
		/// <summary>This property gets or sets ModelProperty.</summary>
		///--------------------------------------------------------------------------------
		public ModelProperty ModelProperty { get; set; }

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
		/// <param name="modelProperty">The ModelProperty to load.</param>
		/// <param name="objectInstance">The ObjectInstance to load.</param>
		/// <param name="solution">The Solution to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelPropertyData(Model model, ModelObject modelObject, ModelProperty modelProperty, ObjectInstance objectInstance, Solution solution, bool loadChildren = true)
		{
			// attach the ModelObject
			Model = model;
			ModelObject = modelObject;
			ModelProperty = modelProperty;
			ObjectInstance = objectInstance;
			Solution = solution;
			ItemID = ModelProperty.ModelPropertyID;
			Items.Clear();
			if (loadChildren == true)
			{

				// attach PropertyInstances
				if (PropertyInstances == null)
				{
					PropertyInstances = new EnterpriseDataObjectList<PropertyInstanceViewModel>();
					foreach (PropertyInstance item in objectInstance.PropertyInstanceList)
					{
						if (item.Solution == null)
						{
							// TODO: this is a hack
							item.Solution = solution;
						}
						if (objectInstance == null || item.ModelPropertyID == modelProperty.ModelPropertyID)
						{
							PropertyInstanceViewModel itemView = new PropertyInstanceViewModel(item, solution);
							itemView.Updated += new EventHandler(Children_Updated);
							PropertyInstances.Add(itemView);
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
				foreach (PropertyInstanceViewModel item in PropertyInstances)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			foreach (PropertyInstanceViewModel item in PropertyInstances)
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
			if (PropertyInstances != null)
			{
				foreach (PropertyInstanceViewModel itemView in PropertyInstances)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				PropertyInstances.Clear();
				PropertyInstances = null;
			}
			Model = null;
			ModelObject = null;
			ObjectInstance = null;
			ModelProperty = null;
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

			foreach (PropertyInstanceViewModel instance in PropertyInstances)
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
		public PropertyInstanceCollectionViewModel()
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="modelObject">The model object to load.</param>
		/// <param name="modelProperty">The model property to load.</param>
		/// <param name="objectInstance">The ObjectInstance to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public PropertyInstanceCollectionViewModel(Model model, ModelObject modelObject, ModelProperty modelProperty, ObjectInstance objectInstance, Solution solution, bool loadChildren = true)
		{
			Name = modelProperty.ModelPropertyName + " " + Resources.DisplayValues.NodeName_PropertyCollection;
			Solution = solution;
			ModelObject = modelObject;
			ModelProperty = modelProperty;
			LoadModelPropertyData(model, modelObject, modelProperty, objectInstance, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
