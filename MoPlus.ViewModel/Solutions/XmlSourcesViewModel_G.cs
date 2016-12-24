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
	/// XmlSource instances.</summary>
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
	public partial class XmlSourcesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewXmlSource.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewXmlSource
		{
			get
			{
				return DisplayValues.ContextMenu_NewXmlSource;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewXmlSourceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewXmlSourceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewXmlSourceToolTip;
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
			foreach (XmlSourceViewModel item in Items.OfType<XmlSourceViewModel>())
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
			foreach (XmlSourceViewModel item in XmlSources)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (XmlSourceViewModel item in ItemsToAdd.OfType<XmlSourceViewModel>())
			{
				item.Update();
				XmlSources.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (XmlSourceViewModel item in ItemsToDelete.OfType<XmlSourceViewModel>())
			{
				item.Delete();
				XmlSources.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (XmlSourceViewModel item in XmlSources)
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
		/// <summary>This method processes the new xmlsource command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewXmlSourceCommand()
		{
			XmlSourceEventArgs message = new XmlSourceEventArgs();
			message.XmlSource = new XmlSource();
			message.XmlSource.SpecificationSourceID = Guid.NewGuid();
			message.XmlSource.SolutionID = Solution.SolutionID;
			message.XmlSource.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.XmlSource.Solution = Solution;
			message.Solution = Solution;
			if (message.XmlSource.Solution != null)
			{
				message.XmlSource.Order = message.XmlSource.Solution.XmlSourceList.Count + 1;
			}
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<XmlSourceEventArgs>(MediatorMessages.Command_EditXmlSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies xmlsource updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditXmlSourcePerformed(XmlSourceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.XmlSource != null)
				{
					foreach (XmlSourceViewModel item in XmlSources)
					{
						if (item.XmlSource.SpecificationSourceID == data.XmlSource.SpecificationSourceID)
						{
							isItemMatch = true;
							item.XmlSource.TransformDataFromObject(data.XmlSource, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new XmlSource
						data.XmlSource.Solution = Solution;
						XmlSourceViewModel newItem = new XmlSourceViewModel(data.XmlSource, Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						XmlSources.Add(newItem);
						Solution.XmlSourceList.Add(newItem.XmlSource);
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
		/// <summary>This method applies xmlsource deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteXmlSourcePerformed(XmlSourceEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.XmlSource != null)
				{
					foreach (XmlSourceViewModel item in XmlSources.ToList<XmlSourceViewModel>())
					{
						if (item.XmlSource.SpecificationSourceID == data.XmlSource.SpecificationSourceID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.XmlSource.SpecificationSourceID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
							}
	
							// delete item
							isItemMatch = true;
							XmlSources.Remove(item);
							Solution.XmlSourceList.Remove(item.XmlSource);
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
		/// <summary>This property gets or sets XmlSource lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<XmlSourceViewModel> XmlSources { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads XmlSources into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadXmlSources(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (XmlSources == null)
			{
				XmlSources = new EnterpriseDataObjectList<XmlSourceViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (XmlSource item in solution.XmlSourceList)
				{
					XmlSourceViewModel itemView = new XmlSourceViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					XmlSources.Add(itemView);
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
				foreach (XmlSourceViewModel item in XmlSources)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (XmlSourceViewModel item in XmlSources)
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
			if (XmlSources != null)
			{
				foreach (XmlSourceViewModel itemView in XmlSources)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				XmlSources.Clear();
				XmlSources = null;
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
			if (data is XmlSourceEventArgs && (data as XmlSourceEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public XmlSourceViewModel PasteXmlSource(XmlSourceViewModel copyItem, bool savePaste = true)
		{
			XmlSource newItem = new XmlSource();
			newItem.ReverseInstance = new XmlSource();
			newItem.TransformDataFromObject(copyItem.XmlSource, null, false);
			newItem.SpecificationSourceID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			XmlSourceViewModel newView = new XmlSourceViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddXmlSource(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.XmlSourceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of XmlSource to the view model.</summary>
		/// 
		/// <param name="itemView">The XmlSource to add.</param>
		///--------------------------------------------------------------------------------
		public void AddXmlSource(XmlSourceViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			XmlSources.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of XmlSource from the view model.</summary>
		/// 
		/// <param name="itemView">The XmlSource to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteXmlSource(XmlSourceViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			XmlSources.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public XmlSourcesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_XmlSources;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public XmlSourcesViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_XmlSources;
			Solution = solution;
			LoadXmlSources(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
