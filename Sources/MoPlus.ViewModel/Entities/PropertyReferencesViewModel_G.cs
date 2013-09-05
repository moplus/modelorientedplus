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
	/// PropertyReference instances.</summary>
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
	public partial class PropertyReferencesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyReference.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyReference
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyReference;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyReferenceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyReferenceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyReferenceToolTip;
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
			foreach (PropertyReferenceViewModel item in Items.OfType<PropertyReferenceViewModel>())
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
			foreach (PropertyReferenceViewModel item in PropertyReferences)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (PropertyReferenceViewModel item in ItemsToAdd.OfType<PropertyReferenceViewModel>())
			{
				item.Update();
				PropertyReferences.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (PropertyReferenceViewModel item in ItemsToDelete.OfType<PropertyReferenceViewModel>())
			{
				item.Delete();
				PropertyReferences.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (PropertyReferenceViewModel item in PropertyReferences)
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
		/// <summary>This method processes the new propertyreference command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyReferenceCommand()
		{
			PropertyReferenceEventArgs message = new PropertyReferenceEventArgs();
			message.PropertyReference = new PropertyReference();
			message.PropertyReference.PropertyID = Guid.NewGuid();
			message.PropertyReference.EntityID = Entity.EntityID;
			message.PropertyReference.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.PropertyReference.Solution = Solution;
			message.Solution = Solution;
			if (message.PropertyReference.Entity != null)
			{
				message.PropertyReference.Order = message.PropertyReference.Entity.PropertyReferenceList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyReferenceEventArgs>(MediatorMessages.Command_EditPropertyReferenceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies propertyreference updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyReferencePerformed(PropertyReferenceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.PropertyReference != null)
				{
					foreach (PropertyReferenceViewModel item in PropertyReferences)
					{
						if (item.PropertyReference.PropertyID == data.PropertyReference.PropertyID)
						{
							isItemMatch = true;
							item.PropertyReference.TransformDataFromObject(data.PropertyReference, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new PropertyReference
						data.PropertyReference.Entity = Entity;
						PropertyReferenceViewModel newItem = new PropertyReferenceViewModel(data.PropertyReference, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						PropertyReferences.Add(newItem);
						Entity.PropertyReferenceList.Add(newItem.PropertyReference);
						Solution.PropertyReferenceList.Add(newItem.PropertyReference);
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
		/// <summary>This method applies propertyreference deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyReferencePerformed(PropertyReferenceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.PropertyReference != null)
				{
					foreach (PropertyReferenceViewModel item in PropertyReferences.ToList<PropertyReferenceViewModel>())
					{
						if (item.PropertyReference.PropertyID == data.PropertyReference.PropertyID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.PropertyReference.PropertyID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							PropertyReferences.Remove(item);
							Entity.PropertyReferenceList.Remove(item.PropertyReference);
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
		/// <summary>This property gets or sets PropertyReference lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyReferenceViewModel> PropertyReferences { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads PropertyReferences into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadPropertyReferences(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (PropertyReferences == null)
			{
				PropertyReferences = new EnterpriseDataObjectList<PropertyReferenceViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (PropertyReference item in entity.PropertyReferenceList)
				{
					PropertyReferenceViewModel itemView = new PropertyReferenceViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					PropertyReferences.Add(itemView);
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
				foreach (PropertyReferenceViewModel item in PropertyReferences)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (PropertyReferenceViewModel item in PropertyReferences)
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
			if (PropertyReferences != null)
			{
				foreach (PropertyReferenceViewModel itemView in PropertyReferences)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				PropertyReferences.Clear();
				PropertyReferences = null;
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
			if (data is PropertyReferenceEventArgs && (data as PropertyReferenceEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (PropertyReferenceViewModel model in PropertyReferences)
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
		/// <summary>This method adds an instance of PropertyReference to the view model.</summary>
		/// 
		/// <param name="itemView">The PropertyReference to add.</param>
		///--------------------------------------------------------------------------------
		public void AddPropertyReference(PropertyReferenceViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			PropertyReferences.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of PropertyReference from the view model.</summary>
		/// 
		/// <param name="itemView">The PropertyReference to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeletePropertyReference(PropertyReferenceViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			PropertyReferences.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public PropertyReferencesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_PropertyReferences;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public PropertyReferencesViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_PropertyReferences;
			Solution = solution;
			Entity = entity;
			LoadPropertyReferences(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
