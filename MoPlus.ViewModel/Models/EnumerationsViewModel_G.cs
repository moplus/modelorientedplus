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
	/// Enumeration instances.</summary>
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
	public partial class EnumerationsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEnumeration.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEnumeration
		{
			get
			{
				return DisplayValues.ContextMenu_NewEnumeration;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEnumerationToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEnumerationToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewEnumerationToolTip;
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
			foreach (EnumerationViewModel item in Items.OfType<EnumerationViewModel>())
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
			foreach (EnumerationViewModel item in Enumerations)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (EnumerationViewModel item in ItemsToAdd.OfType<EnumerationViewModel>())
			{
				item.Update();
				Enumerations.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (EnumerationViewModel item in ItemsToDelete.OfType<EnumerationViewModel>())
			{
				item.Delete();
				Enumerations.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (EnumerationViewModel item in Enumerations)
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
		/// <summary>This method processes the new enumeration command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewEnumerationCommand()
		{
			EnumerationEventArgs message = new EnumerationEventArgs();
			message.Enumeration = new Enumeration();
			message.Enumeration.EnumerationID = Guid.NewGuid();
			message.Enumeration.ModelID = Model.ModelID;
			message.Enumeration.Model = Model;
			message.ModelID = Model.ModelID;
			message.Enumeration.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<EnumerationEventArgs>(MediatorMessages.Command_EditEnumerationRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies enumeration updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditEnumerationPerformed(EnumerationEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Enumeration != null)
				{
					foreach (EnumerationViewModel item in Enumerations)
					{
						if (item.Enumeration.EnumerationID == data.Enumeration.EnumerationID)
						{
							isItemMatch = true;
							item.Enumeration.TransformDataFromObject(data.Enumeration, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Enumeration
						data.Enumeration.Model = Model;
						EnumerationViewModel newItem = new EnumerationViewModel(data.Enumeration, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Enumerations.Add(newItem);
						Model.EnumerationList.Add(newItem.Enumeration);
						Solution.EnumerationList.Add(newItem.Enumeration);
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
		/// <summary>This method applies enumeration deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteEnumerationPerformed(EnumerationEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Enumeration != null)
				{
					foreach (EnumerationViewModel item in Enumerations.ToList<EnumerationViewModel>())
					{
						if (item.Enumeration.EnumerationID == data.Enumeration.EnumerationID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Enumeration.EnumerationID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is ValueViewModel)
								{
									ValueViewModel child = item.Items[i] as ValueViewModel;
									ValueEventArgs childMessage = new ValueEventArgs();
									childMessage.Value = child.Value;
									childMessage.EnumerationID = item.Enumeration.EnumerationID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteValuePerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Enumerations.Remove(item);
							Model.EnumerationList.Remove(item.Enumeration);
							Items.Remove(item);
							Model.ResetModified(true);
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
		/// <summary>This property gets or sets Enumeration lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EnumerationViewModel> Enumerations { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Model.</summary>
		///--------------------------------------------------------------------------------
		public Model Model { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Enumerations into the view model.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadEnumerations(Model model, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Enumerations == null)
			{
				Enumerations = new EnterpriseDataObjectList<EnumerationViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Enumeration item in model.EnumerationList)
				{
					EnumerationViewModel itemView = new EnumerationViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Enumerations.Add(itemView);
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
				foreach (EnumerationViewModel item in Enumerations)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (EnumerationViewModel item in Enumerations)
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
			if (Enumerations != null)
			{
				foreach (EnumerationViewModel itemView in Enumerations)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Enumerations.Clear();
				Enumerations = null;
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
			if (data is EnumerationEventArgs && (data as EnumerationEventArgs).ModelID == Model.ModelID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (EnumerationViewModel model in Enumerations)
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
		public EnumerationViewModel PasteEnumeration(EnumerationViewModel copyItem, bool savePaste = true)
		{
			Enumeration newItem = new Enumeration();
			newItem.ReverseInstance = new Enumeration();
			newItem.TransformDataFromObject(copyItem.Enumeration, null, false);
			newItem.EnumerationID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Model = Model;
			newItem.Solution = Solution;
			EnumerationViewModel newView = new EnumerationViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddEnumeration(newView);

			// paste children
			foreach (ValueViewModel childView in copyItem.Values)
			{
				newView.PasteValue(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.EnumerationList.Add(newItem);
				Model.EnumerationList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Enumeration to the view model.</summary>
		/// 
		/// <param name="itemView">The Enumeration to add.</param>
		///--------------------------------------------------------------------------------
		public void AddEnumeration(EnumerationViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Enumerations.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Enumeration from the view model.</summary>
		/// 
		/// <param name="itemView">The Enumeration to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteEnumeration(EnumerationViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Enumerations.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public EnumerationsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Enumerations;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public EnumerationsViewModel(Model model, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Enumerations;
			Solution = solution;
			Model = model;
			LoadEnumerations(model, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
