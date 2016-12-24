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
	/// SpecTemplate instances.</summary>
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
	public partial class SpecTemplatesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSpecTemplate.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSpecTemplate
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecTemplate;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewSpecTemplateToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewSpecTemplateToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewSpecTemplateToolTip;
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
			foreach (SpecTemplateViewModel item in Items.OfType<SpecTemplateViewModel>())
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
			foreach (SpecTemplateViewModel item in SpecTemplates)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new children
			foreach (SpecTemplateViewModel item in ItemsToAdd.OfType<SpecTemplateViewModel>())
			{
				item.Update();
				SpecTemplates.Add(item);
			}
			ItemsToAdd.Clear();

			// send delete for any deleted children
			foreach (SpecTemplateViewModel item in ItemsToDelete.OfType<SpecTemplateViewModel>())
			{
				item.Delete();
				SpecTemplates.Remove(item);
			}
			ItemsToDelete.Clear();

			// reset modified for children
			foreach (SpecTemplateViewModel item in SpecTemplates)
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
		/// <summary>This method processes the new spectemplate command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewSpecTemplateCommand()
		{
			SpecTemplateEventArgs message = new SpecTemplateEventArgs();
			message.SpecTemplate = new SpecTemplate();
			message.SpecTemplate.TemplateID = Guid.NewGuid();
			message.SpecTemplate.SolutionID = Solution.SolutionID;
			message.SpecTemplate.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.SpecTemplate.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			
			#region protected
			message.SpecTemplate.SpecificationDirectory = SpecificationDirectory;
            if (String.IsNullOrEmpty(message.SpecTemplate.SpecificationDirectory))
            {
                message.SpecTemplate.SpecificationDirectory = Solution.SpecTemplatesDirectory;
            }
            if (TemplateModelNode == ModelContextTypeCode.Solution.ToString())
			{
				message.SpecTemplate.NodeName = SpecModelContextTypeCode.SpecificationSource.ToString();
			}
			else
			{
				ModelContextTypeCode modelContextType = ModelContextTypeCode.None;
				Enum.TryParse<ModelContextTypeCode>(TemplateModelNode, out modelContextType);
				if (modelContextType != ModelContextTypeCode.None)
				{
					message.SpecTemplate.NodeName = modelContextType.ToString();
				}
				else
				{
					SpecModelContextTypeCode specModelContextType = SpecModelContextTypeCode.None;
					Enum.TryParse<SpecModelContextTypeCode>(TemplateModelNode, out specModelContextType);
					if (specModelContextType != SpecModelContextTypeCode.None)
					{
						message.SpecTemplate.NodeName = specModelContextType.ToString();
					}
				}
			}
			#endregion protected
			
			Mediator.NotifyColleagues<SpecTemplateEventArgs>(MediatorMessages.Command_EditSpecTemplateRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies spectemplate updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditSpecTemplatePerformed(SpecTemplateEventArgs data)
		{
			try
			{						
				#region protected
			try
			{
				if (data != null && data.SpecTemplate != null)
				{
					data.SpecTemplate.SaveTemplateFile();
					data.SpecTemplate.HasErrors = false;
					if (!String.IsNullOrEmpty(data.SpecTemplate.TemplateContent))
					{
						data.SpecTemplate.ParseContent(false);
					}
					if (!String.IsNullOrEmpty(data.SpecTemplate.TemplateOutput))
					{
						data.SpecTemplate.ParseOutput(false);
					}
					RemoveTemplate(data.SpecTemplate.TemplateID, false);

					// new template view model
					SpecTemplateViewModel template = new SpecTemplateViewModel(data.SpecTemplate, Solution);
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
		/// <summary>This method applies spectemplate deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteSpecTemplatePerformed(SpecTemplateEventArgs data)
		{
			try
			{						
				#region protected
			if (data != null && data.SpecTemplate != null)
			{
				SpecTemplateViewModel template = RemoveTemplate(data.SpecTemplate.TemplateID);
				if (template != null && System.IO.File.Exists(template.SpecTemplate.FilePath))
				{
					// delete file
					System.IO.File.Delete(template.SpecTemplate.FilePath);
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
		/// <summary>This property gets or sets SpecTemplate lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<SpecTemplateViewModel> SpecTemplates { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads SpecTemplates into the view model.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadSpecTemplates(Solution solution, bool loadChildren = true)
		{
			// attach the items
			Items.Clear();
			if (SpecTemplates == null)
			{
				SpecTemplates = new EnterpriseDataObjectList<SpecTemplateViewModel>();
			}
			if (loadChildren == true)
			{
				foreach (SpecTemplate item in solution.SpecTemplateList)
				{
					SpecTemplateViewModel itemView = new SpecTemplateViewModel(item, solution);
					itemView.Updated += new EventHandler(Children_Updated);
					SpecTemplates.Add(itemView);
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
				foreach (SpecTemplateViewModel template in Items.OfType<SpecTemplateViewModel>())
				{
					template.Refresh(refreshChildren, refreshLevel - 1);
				}
				foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
				{
					folder.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			foreach (SpecTemplateViewModel template in Items.OfType<SpecTemplateViewModel>())
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
			foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
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
			if (SpecTemplates != null)
			{
				foreach (SpecTemplateViewModel itemView in SpecTemplates)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				SpecTemplates.Clear();
				SpecTemplates = null;
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
			if (data is SpecTemplateEventArgs && (data as SpecTemplateEventArgs).SolutionID == Solution.SolutionID)
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
		public SpecTemplateViewModel PasteSpecTemplate(SpecTemplateViewModel copyItem, bool savePaste = true)
		{
			SpecTemplate newItem = new SpecTemplate();
			newItem.ReverseInstance = new SpecTemplate();
			newItem.TransformDataFromObject(copyItem.SpecTemplate, null, false);
			newItem.TemplateID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;
			
			newItem.Solution = Solution;
			newItem.Solution = Solution;
			SpecTemplateViewModel newView = new SpecTemplateViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddSpecTemplate(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.SpecTemplateList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of SpecTemplate to the view model.</summary>
		/// 
		/// <param name="itemView">The SpecTemplate to add.</param>
		///--------------------------------------------------------------------------------
		public void AddSpecTemplate(SpecTemplateViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			SpecTemplates.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of SpecTemplate from the view model.</summary>
		/// 
		/// <param name="itemView">The SpecTemplate to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteSpecTemplate(SpecTemplateViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			SpecTemplates.Remove(itemView);
			Delete(itemView);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public SpecTemplatesViewModel()
		{
			Name = Resources.DisplayValues.NodeName_SpecTemplates;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public SpecTemplatesViewModel(Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_SpecTemplates;
			Solution = solution;
			LoadSpecTemplates(solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
