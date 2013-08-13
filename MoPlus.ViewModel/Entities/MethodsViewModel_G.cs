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
	/// Method instances.</summary>
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
	public partial class MethodsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewMethod.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethod
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethod;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewMethodToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethodToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethodToolTip;
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
			foreach (MethodViewModel item in Items.OfType<MethodViewModel>())
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
			foreach (MethodViewModel item in Methods)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (MethodViewModel item in ItemsToAdd.OfType<MethodViewModel>())
			{
				item.Update();
				Methods.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (MethodViewModel item in ItemsToDelete.OfType<MethodViewModel>())
			{
				item.Delete();
				Methods.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (MethodViewModel item in Methods)
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
		/// <summary>This method processes the new method command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewMethodCommand()
		{
			MethodEventArgs message = new MethodEventArgs();
			message.Method = new Method();
			message.Method.MethodID = Guid.NewGuid();
			message.Method.EntityID = Entity.EntityID;
			message.Method.Entity = Entity;
			message.EntityID = Entity.EntityID;
			message.Method.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodEventArgs>(MediatorMessages.Command_EditMethodRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies method updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditMethodPerformed(MethodEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Method != null)
				{
					foreach (MethodViewModel item in Methods)
					{
						if (item.Method.MethodID == data.Method.MethodID)
						{
							isItemMatch = true;
							item.Method.TransformDataFromObject(data.Method, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Method
						data.Method.Entity = Entity;
						MethodViewModel newItem = new MethodViewModel(data.Method, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Methods.Add(newItem);
						Entity.MethodList.Add(newItem.Method);
						Solution.MethodList.Add(newItem.Method);
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
		/// <summary>This method applies method deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteMethodPerformed(MethodEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Method != null)
				{
					foreach (MethodViewModel item in Methods.ToList<MethodViewModel>())
					{
						if (item.Method.MethodID == data.Method.MethodID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Method.MethodID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is ParameterViewModel)
								{
									ParameterViewModel child = item.Items[i] as ParameterViewModel;
									ParameterEventArgs childMessage = new ParameterEventArgs();
									childMessage.Parameter = child.Parameter;
									childMessage.MethodID = item.Method.MethodID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteParameterPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Methods.Remove(item);
							Entity.MethodList.Remove(item.Method);
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
		/// <summary>This property gets or sets Method lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<MethodViewModel> Methods { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity.</summary>
		///--------------------------------------------------------------------------------
		public Entity Entity { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Methods into the view model.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadMethods(Entity entity, Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Methods == null)
			{
				Methods = new EnterpriseDataObjectList<MethodViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Method item in entity.MethodList)
				{
					MethodViewModel itemView = new MethodViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Methods.Add(itemView);
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
				foreach (MethodViewModel item in Methods)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (MethodViewModel item in Methods)
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
			if (Methods != null)
			{
				foreach (MethodViewModel itemView in Methods)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Methods.Clear();
				Methods = null;
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
			if (data is MethodEventArgs && (data as MethodEventArgs).EntityID == Entity.EntityID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (MethodViewModel model in Methods)
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
		public MethodViewModel PasteMethod(MethodViewModel copyItem, bool savePaste = true)
		{
			Method newItem = new Method();
			newItem.ReverseInstance = new Method();
			newItem.TransformDataFromObject(copyItem.Method, null, false);
			newItem.MethodID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			MethodViewModel newView = new MethodViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddMethod(newView);

			// paste children
			foreach (ParameterViewModel childView in copyItem.Parameters)
			{
				newView.PasteParameter(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.MethodList.Add(newItem);
				Entity.MethodList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Method to the view model.</summary>
		/// 
		/// <param name="itemView">The Method to add.</param>
		///--------------------------------------------------------------------------------
		public void AddMethod(MethodViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Methods.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Method from the view model.</summary>
		/// 
		/// <param name="itemView">The Method to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteMethod(MethodViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Methods.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public MethodsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Methods;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="entity">The entity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public MethodsViewModel(Entity entity, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Methods;
			Solution = solution;
			Entity = entity;
			LoadMethods(entity, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
