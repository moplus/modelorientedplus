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

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for collections of
	/// AuditProperty instances.</summary>
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
	public partial class AuditPropertiesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewAuditProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewAuditProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewAuditPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewAuditPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewAuditPropertyToolTip;
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
			foreach (AuditPropertyViewModel item in Items.OfType<AuditPropertyViewModel>())
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
			foreach (AuditPropertyViewModel item in AuditProperties)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (AuditPropertyViewModel item in ItemsToAdd.OfType<AuditPropertyViewModel>())
			{
				item.Update();
				AuditProperties.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (AuditPropertyViewModel item in ItemsToDelete.OfType<AuditPropertyViewModel>())
			{
				item.Delete();
				AuditProperties.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (AuditPropertyViewModel item in AuditProperties)
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
		/// <summary>This method processes the new auditproperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewAuditPropertyCommand()
		{
			AuditPropertyEventArgs message = new AuditPropertyEventArgs();
			message.AuditProperty = new AuditProperty();
			message.AuditProperty.PropertyID = Guid.NewGuid();
			message.AuditProperty.SolutionID = Solution.SolutionID;
			message.AuditProperty.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.AuditProperty.Solution = Solution;
			message.Solution = Solution;
			if (message.AuditProperty.Solution != null)
			{
				message.AuditProperty.Order = message.AuditProperty.Solution.AuditPropertyList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<AuditPropertyEventArgs>(MediatorMessages.Command_EditAuditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies auditproperty updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditAuditPropertyPerformed(AuditPropertyEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.AuditProperty != null)
				{
					foreach (AuditPropertyViewModel item in AuditProperties)
					{
						if (item.AuditProperty.PropertyID == data.AuditProperty.PropertyID)
						{
							isItemMatch = true;
							item.AuditProperty.TransformDataFromObject(data.AuditProperty, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new AuditProperty
						data.AuditProperty.Solution = Solution;
						AuditPropertyViewModel newItem = new AuditPropertyViewModel(data.AuditProperty, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						AuditProperties.Add(newItem);
						Solution.AuditPropertyList.Add(newItem.AuditProperty);
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
		/// <summary>This method applies auditproperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteAuditPropertyPerformed(AuditPropertyEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.AuditProperty != null)
				{
					foreach (AuditPropertyViewModel item in AuditProperties.ToList<AuditPropertyViewModel>())
					{
						if (item.AuditProperty.PropertyID == data.AuditProperty.PropertyID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.AuditProperty.PropertyID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							AuditProperties.Remove(item);
							Solution.AuditPropertyList.Remove(item.AuditProperty);
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
		/// <summary>This property gets or sets AuditProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<AuditPropertyViewModel> AuditProperties { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads AuditProperties into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadAuditProperties(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (AuditProperties == null)
			{
				AuditProperties = new EnterpriseDataObjectList<AuditPropertyViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (AuditProperty item in solution.AuditPropertyList)
				{
					AuditPropertyViewModel itemView = new AuditPropertyViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					AuditProperties.Add(itemView);
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
				foreach (AuditPropertyViewModel item in AuditProperties)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (AuditPropertyViewModel item in AuditProperties)
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
			if (AuditProperties != null)
			{
				foreach (AuditPropertyViewModel itemView in AuditProperties)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				AuditProperties.Clear();
				AuditProperties = null;
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
			if (data is AuditPropertyEventArgs && (data as AuditPropertyEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (AuditPropertyViewModel model in AuditProperties)
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
		public AuditPropertyViewModel PasteAuditProperty(AuditPropertyViewModel copyItem, bool savePaste = true)
		{
			AuditProperty newItem = new AuditProperty();
			newItem.ReverseInstance = new AuditProperty();
			newItem.TransformDataFromObject(copyItem.AuditProperty, null, false);
			newItem.PropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			AuditPropertyViewModel newView = new AuditPropertyViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddAuditProperty(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.AuditPropertyList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of AuditProperty to the view model.</summary>
		/// 
		/// <param name="itemView">The AuditProperty to add.</param>
		///--------------------------------------------------------------------------------
		public void AddAuditProperty(AuditPropertyViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			AuditProperties.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of AuditProperty from the view model.</summary>
		/// 
		/// <param name="itemView">The AuditProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteAuditProperty(AuditPropertyViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			AuditProperties.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public AuditPropertiesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_AuditProperties;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public AuditPropertiesViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_AuditProperties;
			Solution = solution;
			LoadAuditProperties(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
