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
	/// Solution instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/24/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSolution
		{
			get
			{
				return DisplayValues.ContextMenu_NewSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSolutionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSolutionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewSolutionToolTip;
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
			foreach (SolutionViewModel item in Items.OfType<SolutionViewModel>())
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
			foreach (SolutionViewModel item in Solutions)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (SolutionViewModel item in ItemsToAdd.OfType<SolutionViewModel>())
			{
				item.Update();
				Solutions.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (SolutionViewModel item in ItemsToDelete.OfType<SolutionViewModel>())
			{
				item.Delete();
				Solutions.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (SolutionViewModel item in Solutions)
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
		/// <summary>This method processes the new solution command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewSolutionCommand()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = new Solution();
			message.Solution.SolutionID = Guid.NewGuid();
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_EditSolutionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies solution updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditSolutionPerformed(SolutionEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Solution != null)
				{
					foreach (SolutionViewModel item in Solutions)
					{
						if (item.Solution.SolutionID == data.Solution.SolutionID)
						{
							isItemMatch = true;
							item.Solution.TransformDataFromObject(data.Solution, null, false);
								
							#region protected
							if (!String.IsNullOrEmpty(item.Solution.TemplatePath))
							{
								if (item.CodeTemplatesFolder.Items.Count == 0 || String.IsNullOrEmpty(item.OriginalTemplatePath) || System.IO.Directory.GetParent(item.OriginalTemplatePath).FullName != System.IO.Directory.GetParent(item.Solution.TemplateAbsolutePath).FullName)
								{
									item.CodeTemplatesFolder.LoadTemplateDirectories();
									item.OriginalTemplatePath = item.Solution.TemplatePath;
								}
							}
							#endregion protected
							
							item.OnUpdated(item, null);
							item.ShowInTreeView();
							break;
						}
					}
					if (isItemMatch == false)
					{
						// add new Solution
						SolutionViewModel newItem = new SolutionViewModel(data.Solution);
						newItem.Updated += new EventHandler(Children_Updated);
						Solutions.Add(newItem);
							
						#region protected
						if (String.IsNullOrEmpty(newItem.OriginalTemplatePath) || System.IO.Directory.GetParent(newItem.OriginalTemplatePath).FullName != System.IO.Directory.GetParent(newItem.Solution.TemplateAbsolutePath).FullName)
						{
							newItem.CodeTemplatesFolder.LoadTemplateDirectories();
							newItem.OriginalTemplatePath = newItem.Solution.TemplatePath;
						}
						#endregion protected
						
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
		/// <summary>This method applies solution deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteSolutionPerformed(SolutionEventArgs data)
		{
			try
			{
				bool isItemMatch = false;
				if (data != null && data.Solution != null)
				{
					foreach (SolutionViewModel item in Solutions.ToList<SolutionViewModel>())
					{
						if (item.Solution.SolutionID == data.Solution.SolutionID)
						{
							// remove item from tabs, if present
							WorkspaceEventArgs message = new WorkspaceEventArgs();
							message.ItemID = item.Solution.SolutionID;
							Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
	
							// delete children
							for (int i = item.Items.Count - 1; i >= 0; i--)
							{
								if (item.Items[i] is ViewViewModel)
								{
									ViewViewModel child = item.Items[i] as ViewViewModel;
									ViewEventArgs childMessage = new ViewEventArgs();
									childMessage.View = child.View;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ViewsFolder.ProcessDeleteViewPerformed(childMessage);
								}
								if (item.Items[i] is DatabaseSourceViewModel)
								{
									DatabaseSourceViewModel child = item.Items[i] as DatabaseSourceViewModel;
									DatabaseSourceEventArgs childMessage = new DatabaseSourceEventArgs();
									childMessage.DatabaseSource = child.DatabaseSource;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.SpecificationSourcesFolder.ProcessDeleteDatabaseSourcePerformed(childMessage);
								}
								if (item.Items[i] is XmlSourceViewModel)
								{
									XmlSourceViewModel child = item.Items[i] as XmlSourceViewModel;
									XmlSourceEventArgs childMessage = new XmlSourceEventArgs();
									childMessage.XmlSource = child.XmlSource;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.SpecificationSourcesFolder.ProcessDeleteXmlSourcePerformed(childMessage);
								}
								if (item.Items[i] is ProjectViewModel)
								{
									ProjectViewModel child = item.Items[i] as ProjectViewModel;
									ProjectEventArgs childMessage = new ProjectEventArgs();
									childMessage.Project = child.Project;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ProjectsFolder.ProcessDeleteProjectPerformed(childMessage);
								}
								if (item.Items[i] is FeatureViewModel)
								{
									FeatureViewModel child = item.Items[i] as FeatureViewModel;
									FeatureEventArgs childMessage = new FeatureEventArgs();
									childMessage.Feature = child.Feature;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.FeaturesFolder.ProcessDeleteFeaturePerformed(childMessage);
								}
								if (item.Items[i] is WorkflowViewModel)
								{
									WorkflowViewModel child = item.Items[i] as WorkflowViewModel;
									WorkflowEventArgs childMessage = new WorkflowEventArgs();
									childMessage.Workflow = child.Workflow;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.WorkflowsFolder.ProcessDeleteWorkflowPerformed(childMessage);
								}
								if (item.Items[i] is ModelViewModel)
								{
									ModelViewModel child = item.Items[i] as ModelViewModel;
									ModelEventArgs childMessage = new ModelEventArgs();
									childMessage.Model = child.Model;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.ModelsFolder.ProcessDeleteModelPerformed(childMessage);
								}
								if (item.Items[i] is DiagramViewModel)
								{
									DiagramViewModel child = item.Items[i] as DiagramViewModel;
									DiagramEventArgs childMessage = new DiagramEventArgs();
									childMessage.Diagram = child.Diagram;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.DiagramsFolder.ProcessDeleteDiagramPerformed(childMessage);
								}
								if (item.Items[i] is AuditPropertyViewModel)
								{
									AuditPropertyViewModel child = item.Items[i] as AuditPropertyViewModel;
									AuditPropertyEventArgs childMessage = new AuditPropertyEventArgs();
									childMessage.AuditProperty = child.AuditProperty;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.AuditPropertiesFolder.ProcessDeleteAuditPropertyPerformed(childMessage);
								}
								if (item.Items[i] is SpecTemplateViewModel)
								{
									SpecTemplateViewModel child = item.Items[i] as SpecTemplateViewModel;
									SpecTemplateEventArgs childMessage = new SpecTemplateEventArgs();
									childMessage.SpecTemplate = child.SpecTemplate;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.SpecTemplatesFolder.ProcessDeleteSpecTemplatePerformed(childMessage);
								}
								if (item.Items[i] is CodeTemplateViewModel)
								{
									CodeTemplateViewModel child = item.Items[i] as CodeTemplateViewModel;
									CodeTemplateEventArgs childMessage = new CodeTemplateEventArgs();
									childMessage.CodeTemplate = child.CodeTemplate;
									childMessage.SolutionID = item.Solution.SolutionID;
									childMessage.Solution = Solution;
									childMessage.WorkspaceID = child.WorkspaceID;
									item.CodeTemplatesFolder.ProcessDeleteCodeTemplatePerformed(childMessage);
								}
							}
	
							// delete item
							isItemMatch = true;
							Solutions.Remove(item);
							Items.Remove(item);
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
		/// <summary>This property gets or sets Solution lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<SolutionViewModel> Solutions { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads Solutions into the view model.</summary>
		///
		///--------------------------------------------------------------------------------
		public void LoadSolutions()
		{
			// attach the items
			Items.Clear();
			if (Solutions == null)
			{
				Solutions = new EnterpriseDataObjectList<SolutionViewModel>();
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
				foreach (SolutionViewModel item in Solutions)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (SolutionViewModel item in Solutions)
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
			if (Solutions != null)
			{
				foreach (SolutionViewModel itemView in Solutions)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				Solutions.Clear();
				Solutions = null;
			}
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
			EditWorkspaceViewModel parentModel = null;
			
			foreach (SolutionViewModel model in Solutions)
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
		/// <summary>This method adds an instance of Solution to the view model.</summary>
		/// 
		/// <param name="itemView">The Solution to add.</param>
		///--------------------------------------------------------------------------------
		public void AddSolution(SolutionViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Solutions.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Solution from the view model.</summary>
		/// 
		/// <param name="itemView">The Solution to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteSolution(SolutionViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Solutions.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SolutionsViewModel()
		{
			Name = Resources.DisplayValues.NodeName_Solutions;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public SolutionsViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_Solutions;
			Solution = solution;
			LoadSolutions();
		}

		#endregion "Constructors"
	}
}
