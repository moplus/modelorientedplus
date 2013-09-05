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
	/// Feature instances.</summary>
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
	public partial class FeaturesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewFeature.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewFeature
		{
			get
			{
				return DisplayValues.ContextMenu_NewFeature;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewFeatureToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewFeatureToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewFeatureToolTip;
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
			foreach (FeatureViewModel item in Items.OfType<FeatureViewModel>())
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
			foreach (FeatureViewModel item in Features)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (FeatureViewModel item in ItemsToAdd.OfType<FeatureViewModel>())
			{
				item.Update();
				Features.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (FeatureViewModel item in ItemsToDelete.OfType<FeatureViewModel>())
			{
				item.Delete();
				Features.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (FeatureViewModel item in Features)
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
		/// <summary>This method processes the new feature command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewFeatureCommand()
		{
			FeatureEventArgs message = new FeatureEventArgs();
			message.Feature = new Feature();
			message.Feature.FeatureID = Guid.NewGuid();
			message.Feature.SolutionID = Solution.SolutionID;
			message.Feature.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.Feature.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<FeatureEventArgs>(MediatorMessages.Command_EditFeatureRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies feature updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditFeaturePerformed(FeatureEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Feature != null)
				{
					foreach (FeatureViewModel item in Features)
					{
						if (item.Feature.FeatureID == data.Feature.FeatureID)
						{
							isItemMatch = true;
							item.Feature.TransformDataFromObject(data.Feature, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Feature
						data.Feature.Solution = Solution;
						FeatureViewModel newItem = new FeatureViewModel(data.Feature, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Features.Add(newItem);
						Solution.FeatureList.Add(newItem.Feature);
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
		/// <summary>This method applies feature deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteFeaturePerformed(FeatureEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Feature != null)
				{
					foreach (FeatureViewModel item in Features.ToList<FeatureViewModel>())
					{
						if (item.Feature.FeatureID == data.Feature.FeatureID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Feature.FeatureID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is EntityViewModel)
								{
									EntityViewModel child = item.Items[i] as EntityViewModel;
									EntityEventArgs childMessage = new EntityEventArgs();
									childMessage.Entity = child.Entity;
									childMessage.FeatureID = item.Feature.FeatureID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteEntityPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Features.Remove(item);
							Solution.FeatureList.Remove(item.Feature);
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
		/// <summary>This property gets or sets Feature lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<FeatureViewModel> Features { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Features into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadFeatures(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Features == null)
			{
				Features = new EnterpriseDataObjectList<FeatureViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Feature item in solution.FeatureList)
				{
					FeatureViewModel itemView = new FeatureViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Features.Add(itemView);
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
				foreach (FeatureViewModel item in Features)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (FeatureViewModel item in Features)
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
			if (Features != null)
			{
				foreach (FeatureViewModel itemView in Features)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Features.Clear();
				Features = null;
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
			if (data is FeatureEventArgs && (data as FeatureEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (FeatureViewModel model in Features)
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
		/// <summary>This method adds an instance of Feature to the view model.</summary>
		/// 
		/// <param name="itemView">The Feature to add.</param>
		///--------------------------------------------------------------------------------
		public void AddFeature(FeatureViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Features.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Feature from the view model.</summary>
		/// 
		/// <param name="itemView">The Feature to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteFeature(FeatureViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Features.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public FeaturesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Features;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public FeaturesViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Features;
			Solution = solution;
			LoadFeatures(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
