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
	/// Property instances.</summary>
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
	public partial class PropertiesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyToolTip;
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
			foreach (PropertyViewModel item in Items.OfType<PropertyViewModel>())
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
			foreach (PropertyViewModel item in Properties)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (PropertyViewModel item in ItemsToAdd.OfType<PropertyViewModel>())
			{
				item.Update();
				Properties.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (PropertyViewModel item in ItemsToDelete.OfType<PropertyViewModel>())
			{
				item.Delete();
				Properties.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (PropertyViewModel item in Properties)
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
		/// <summary>This method processes the new property command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyCommand()
		{
			PropertyEventArgs message = new PropertyEventArgs();
			message.Property = new Property();
			message.Property.PropertyID = Guid.NewGuid();
			message.Property.EntityID = Entity.EntityID;
			message.Property.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.Property.Solution = Solution;
			message.Solution = Solution;
			if (message.Property.Entity != null)
			{
				message.Property.Order = message.Property.Entity.PropertyList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyEventArgs>(MediatorMessages.Command_EditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies property updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyPerformed(PropertyEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Property != null)
				{
					foreach (PropertyViewModel item in Properties)
					{
						if (item.Property.PropertyID == data.Property.PropertyID)
						{
							isItemMatch = true;
							item.Property.TransformDataFromObject(data.Property, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Property
						data.Property.Entity = Entity;
						PropertyViewModel newItem = new PropertyViewModel(data.Property, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Properties.Add(newItem);
						Entity.PropertyList.Add(newItem.Property);
						Solution.PropertyList.Add(newItem.Property);
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
		/// <summary>This method applies property deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyPerformed(PropertyEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Property != null)
				{
					foreach (PropertyViewModel item in Properties.ToList<PropertyViewModel>())
					{
						if (item.Property.PropertyID == data.Property.PropertyID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Property.PropertyID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							Properties.Remove(item);
							Entity.PropertyList.Remove(item.Property);
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
		/// <summary>This property gets or sets Property lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyViewModel> Properties { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Properties into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadProperties(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Properties == null)
			{
				Properties = new EnterpriseDataObjectList<PropertyViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Property item in entity.PropertyList)
				{
					PropertyViewModel itemView = new PropertyViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Properties.Add(itemView);
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
				foreach (PropertyViewModel item in Properties)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (PropertyViewModel item in Properties)
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
			if (Properties != null)
			{
				foreach (PropertyViewModel itemView in Properties)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Properties.Clear();
				Properties = null;
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
			if (data is PropertyEventArgs && (data as PropertyEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (PropertyViewModel model in Properties)
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
		public PropertyViewModel PasteProperty(PropertyViewModel copyItem, bool savePaste = true)
		{
			Property newItem = new Property();
			newItem.ReverseInstance = new Property();
			newItem.TransformDataFromObject(copyItem.Property, null, false);
			newItem.PropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			PropertyViewModel newView = new PropertyViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddProperty(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.PropertyList.Add(newItem);
				Entity.PropertyList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Property to the view model.</summary>
		/// 
		/// <param name="itemView">The Property to add.</param>
		///--------------------------------------------------------------------------------
		public void AddProperty(PropertyViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Properties.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Property from the view model.</summary>
		/// 
		/// <param name="itemView">The Property to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteProperty(PropertyViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Properties.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public PropertiesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Properties;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public PropertiesViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Properties;
			Solution = solution;
			Entity = entity;
			LoadProperties(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
