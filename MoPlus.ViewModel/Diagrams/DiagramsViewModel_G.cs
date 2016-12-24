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

namespace MoPlus.ViewModel.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for collections of
	/// Diagram instances.</summary>
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
	public partial class DiagramsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagram.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagram
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagram;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagramToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagramToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramToolTip;
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
			foreach (DiagramViewModel item in Items.OfType<DiagramViewModel>())
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
			foreach (DiagramViewModel item in Diagrams)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (DiagramViewModel item in ItemsToAdd.OfType<DiagramViewModel>())
			{
				item.Update();
				Diagrams.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (DiagramViewModel item in ItemsToDelete.OfType<DiagramViewModel>())
			{
				item.Delete();
				Diagrams.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (DiagramViewModel item in Diagrams)
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
		/// <summary>This method processes the new diagram command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDiagramCommand()
		{
			DiagramEventArgs message = new DiagramEventArgs();
			message.Diagram = new Diagram();
			message.Diagram.DiagramID = Guid.NewGuid();
			message.Diagram.SolutionID = Solution.SolutionID;
			message.Diagram.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.Diagram.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			
			#region protected
			message.Entities = Entities;
			#endregion protected
			
			Mediator.NotifyColleagues<DiagramEventArgs>(MediatorMessages.Command_EditDiagramRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies diagram updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDiagramPerformed(DiagramEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Diagram != null)
				{
					foreach (DiagramViewModel item in Diagrams)
					{
						if (item.Diagram.DiagramID == data.Diagram.DiagramID)
						{
							isItemMatch = true;
							item.Diagram.TransformDataFromObject(data.Diagram, null, false);
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Diagram
						data.Diagram.Solution = Solution;
		
						#region protected
					DiagramViewModel newItem = new DiagramViewModel(data.Diagram, Entities, Solution);
					#endregion protected
						
						newItem.Updated += new EventHandler(Children_Updated);
						Diagrams.Add(newItem);
						Solution.DiagramList.Add(newItem.Diagram);
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
		/// <summary>This method applies diagram deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDiagramPerformed(DiagramEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Diagram != null)
				{
					foreach (DiagramViewModel item in Diagrams.ToList<DiagramViewModel>())
					{
						if (item.Diagram.DiagramID == data.Diagram.DiagramID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Diagram.DiagramID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is DiagramEntityViewModel)
								{
									DiagramEntityViewModel child = item.Items[i] as DiagramEntityViewModel;
									DiagramEntityEventArgs childMessage = new DiagramEntityEventArgs();
									childMessage.DiagramEntity = child.DiagramEntity;
									childMessage.DiagramID = item.Diagram.DiagramID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProcessDeleteDiagramEntityPerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Diagrams.Remove(item);
							Solution.DiagramList.Remove(item.Diagram);
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
		/// <summary>This property gets or sets Diagram lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramViewModel> Diagrams { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Diagrams into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDiagrams(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (Diagrams == null)
			{
				Diagrams = new EnterpriseDataObjectList<DiagramViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (Diagram item in solution.DiagramList)
				{
					DiagramViewModel itemView = new DiagramViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Diagrams.Add(itemView);
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
				foreach (DiagramViewModel item in Diagrams)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (DiagramViewModel item in Diagrams)
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
			if (Diagrams != null)
			{
				foreach (DiagramViewModel itemView in Diagrams)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Diagrams.Clear();
				Diagrams = null;
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
			if (data is DiagramEventArgs && (data as DiagramEventArgs).SolutionID == Solution.SolutionID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;
			
			foreach (DiagramViewModel model in Diagrams)
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
		public DiagramViewModel PasteDiagram(DiagramViewModel copyItem, bool savePaste = true)
		{
			Diagram newItem = new Diagram();
			newItem.ReverseInstance = new Diagram();
			newItem.TransformDataFromObject(copyItem.Diagram, null, false);
			newItem.DiagramID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			DiagramViewModel newView = new DiagramViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddDiagram(newView);

			// paste children
			foreach (DiagramEntityViewModel childView in copyItem.DiagramEntities)
			{
				newView.PasteDiagramEntity(childView, savePaste);
			}
			if (savePaste == true)
			{
				Solution.DiagramList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Diagram to the view model.</summary>
		/// 
		/// <param name="itemView">The Diagram to add.</param>
		///--------------------------------------------------------------------------------
		public void AddDiagram(DiagramViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Diagrams.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Diagram from the view model.</summary>
		/// 
		/// <param name="itemView">The Diagram to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteDiagram(DiagramViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Diagrams.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public DiagramsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Diagrams;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public DiagramsViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Diagrams;
			Solution = solution;
			LoadDiagrams(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
