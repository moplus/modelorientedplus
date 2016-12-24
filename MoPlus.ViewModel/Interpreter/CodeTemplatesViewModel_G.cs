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

namespace MoPlus.ViewModel.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for collections of
	/// CodeTemplate instances.</summary>
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
	public partial class CodeTemplatesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCodeTemplate.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCodeTemplate
		{
			get
			{
				return DisplayValues.ContextMenu_NewCodeTemplate;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewCodeTemplateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewCodeTemplateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewCodeTemplateToolTip;
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
			foreach (CodeTemplateViewModel item in Items.OfType<CodeTemplateViewModel>())
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
			foreach (CodeTemplateViewModel item in CodeTemplates)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (CodeTemplateViewModel item in ItemsToAdd.OfType<CodeTemplateViewModel>())
			{
				item.Update();
				CodeTemplates.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (CodeTemplateViewModel item in ItemsToDelete.OfType<CodeTemplateViewModel>())
			{
				item.Delete();
				CodeTemplates.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (CodeTemplateViewModel item in CodeTemplates)
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
		/// <summary>This method processes the new codetemplate command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewCodeTemplateCommand()
		{
			CodeTemplateEventArgs message = new CodeTemplateEventArgs();
			message.CodeTemplate = new CodeTemplate();
			message.CodeTemplate.TemplateID = Guid.NewGuid();
			message.CodeTemplate.SolutionID = Solution.SolutionID;
			message.CodeTemplate.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.CodeTemplate.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			
			#region protected
			message.CodeTemplate.NodeName = TemplateModelNode;
			#endregion protected
			
			Mediator.NotifyColleagues<CodeTemplateEventArgs>(MediatorMessages.Command_EditCodeTemplateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies codetemplate updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditCodeTemplatePerformed(CodeTemplateEventArgs data)
		{
			try
			{						
				#region protected
			try
			{
				if (data != null && data.CodeTemplate != null)
				{
					data.CodeTemplate.SaveTemplateFile();
					data.CodeTemplate.HasErrors = false;
					if (!String.IsNullOrEmpty(data.CodeTemplate.TemplateContent))
					{
						data.CodeTemplate.ParseContent(false);
					}
					if (!String.IsNullOrEmpty(data.CodeTemplate.TemplateOutput))
					{
						data.CodeTemplate.ParseOutput(false);
					}
					RemoveTemplate(data.CodeTemplate.TemplateID, false);

					// new template view model
					CodeTemplateViewModel template = new CodeTemplateViewModel(data.CodeTemplate, Solution);
					AddTemplate(template);
					template.ShowInTreeView();
				}
			}
			catch (System.Exception ex)
			{
				ShowException(ex);
			}
			#endregion protected
			}
			catch (Exception ex)
			{
				ShowIssue(ex.Message + ex.StackTrace);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies codetemplate deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteCodeTemplatePerformed(CodeTemplateEventArgs data)
		{
			try
			{						
				#region protected
			if (data != null && data.CodeTemplate != null)
			{
				CodeTemplateViewModel template = RemoveTemplate(data.CodeTemplate.TemplateID);
				if (template != null && System.IO.File.Exists(template.CodeTemplate.FilePath))
				{
					// delete file
					System.IO.File.Delete(template.CodeTemplate.FilePath);

					// remove from solution
					Solution.CodeTemplates.Remove(template.CodeTemplate.TemplateKey);
					Solution.CodeTemplateList.Remove(template.CodeTemplate);
				}
				else
				{
					ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
				}
			}
			#endregion protected
			}
			catch (Exception ex)
			{
				ShowIssue(ex.Message + ex.StackTrace);
			}
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets CodeTemplate lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<CodeTemplateViewModel> CodeTemplates { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads CodeTemplates into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadCodeTemplates(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (CodeTemplates == null)
			{
				CodeTemplates = new EnterpriseDataObjectList<CodeTemplateViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (CodeTemplate item in solution.CodeTemplateList)
				{
					CodeTemplateViewModel itemView = new CodeTemplateViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					CodeTemplates.Add(itemView);
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
			#region protected
			HasErrors = !IsValid;
			HasCustomizations = Items.Count > 0;
			if (refreshChildren == true || refreshLevel > 0)
			{
				foreach (CodeTemplateViewModel template in Items.OfType<CodeTemplateViewModel>())
				{
					template.Refresh(refreshChildren, refreshLevel - 1);
				}
				foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
				{
					folder.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			foreach (CodeTemplateViewModel template in Items.OfType<CodeTemplateViewModel>())
			{
				if (template.HasErrors == true)
				{
					HasErrors = true;
				}
				if (template.HasCustomizations == true)
				{
					HasCustomizations = true;
				}
			}
			foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
			{
				if (folder.HasErrors == true)
				{
					HasErrors = true;
				}
				if (folder.HasCustomizations == true)
				{
					HasCustomizations = true;
				}
			}
			OnPropertyChanged("IsExpanded");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
			OnPropertyChanged("IsTemplateUtilized");
			OnPropertyChanged("ToolTipText");
			#endregion protected
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (CodeTemplates != null)
			{
				foreach (CodeTemplateViewModel itemView in CodeTemplates)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				CodeTemplates.Clear();
				CodeTemplates = null;
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
			if (data is CodeTemplateEventArgs && (data as CodeTemplateEventArgs).SolutionID == Solution.SolutionID)
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
		public CodeTemplateViewModel PasteCodeTemplate(CodeTemplateViewModel copyItem, bool savePaste = true)
		{
			CodeTemplate newItem = new CodeTemplate();
			newItem.ReverseInstance = new CodeTemplate();
			newItem.TransformDataFromObject(copyItem.CodeTemplate, null, false);
			newItem.TemplateID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			CodeTemplateViewModel newView = new CodeTemplateViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddCodeTemplate(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.CodeTemplateList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of CodeTemplate to the view model.</summary>
		/// 
		/// <param name="itemView">The CodeTemplate to add.</param>
		///--------------------------------------------------------------------------------
		public void AddCodeTemplate(CodeTemplateViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			CodeTemplates.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of CodeTemplate from the view model.</summary>
		/// 
		/// <param name="itemView">The CodeTemplate to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteCodeTemplate(CodeTemplateViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			CodeTemplates.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public CodeTemplatesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_CodeTemplates;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public CodeTemplatesViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_CodeTemplates;
			Solution = solution;
			LoadCodeTemplates(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
