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
	/// <summary>This class provides views for View instances.</summary>
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
	public partial class ViewViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewView.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewView
		{
			get
			{
				return DisplayValues.ContextMenu_NewView;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlViewToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelViewToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewViewToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewViewProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewViewProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewViewProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewViewPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewViewPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewViewPropertyToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEdit.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEdit
		{
			get
			{
				return DisplayValues.ContextMenu_Edit;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEditToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEditToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_EditToolTip;
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
				if (EditView.IsModified == true)
				{
					return true;
				}
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

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEditItemValid.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEditItemValid
		{
			get
			{
				return string.IsNullOrEmpty(ViewNameValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private View _editView = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditView.</summary>
		///--------------------------------------------------------------------------------
		public View EditView
		{
			get
			{
				if (_editView == null)
				{
					_editView = new View();
					_editView.PropertyChanged += new PropertyChangedEventHandler(EditView_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (View != null)
					{
						_editView.TransformDataFromObject(View, null, false);
						_editView.Solution = View.Solution;
					}
					_editView.ResetModified(false);
				}
				return _editView;
			}
			set
			{
				_editView = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditView_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditView");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ViewName");
			OnPropertyChanged("ViewNameCustomized");
			OnPropertyChanged("ViewNameValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");

			OnPropertyChanged("Tags");
			OnPropertyChanged("TagsCustomized");
			OnPropertyChanged("TagsValidationMessage");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title
		{
			get
			{
				return DisplayValues.Edit_ViewHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ViewHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ViewIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ViewIDLabel
		{
			get
			{
				return DisplayValues.Edit_ViewIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ViewNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ViewNameLabel
		{
			get
			{
				return DisplayValues.Edit_ViewNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ViewName.</summary>
		///--------------------------------------------------------------------------------
		public string ViewName
		{
			get
			{
				return EditView.ViewName;
			}
			set
			{
				EditView.ViewName = value;
				OnPropertyChanged("ViewName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ViewNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ViewNameCustomized
		{
			get
			{
				if (View.ReverseInstance != null)
				{
					return ViewName.GetString() != View.ReverseInstance.ViewName.GetString();
				}
				else if (View.IsAutoUpdated == true)
				{
					return ViewName.GetString() != View.ViewName.GetString();
				}
				return ViewName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ViewNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ViewNameValidationMessage
		{
			get
			{
				return EditView.ValidateViewName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DescriptionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionLabel
		{
			get
			{
				return DisplayValues.Edit_DescriptionProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Description.</summary>
		///--------------------------------------------------------------------------------
		public string Description
		{
			get
			{
				return EditView.Description;
			}
			set
			{
				EditView.Description = value;
				OnPropertyChanged("Description");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DescriptionCustomized
		{
			get
			{
				if (View.ReverseInstance != null)
				{
					return Description.GetString() != View.ReverseInstance.Description.GetString();
				}
				else if (View.IsAutoUpdated == true)
				{
					return Description.GetString() != View.Description.GetString();
				}
				return Description != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionValidationMessage
		{
			get
			{
				return EditView.ValidateDescription();
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SourceName
		{
			get
			{
				return EditView.SourceName;
			}
			set
			{
				EditView.SourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SpecSourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SpecSourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SpecSourceName
		{
			get
			{
				return EditView.SpecSourceName;
			}
			set
			{
				EditView.SpecSourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SpecSourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SpecSourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TagsLabel
		{
			get
			{
				return DisplayValues.Edit_TagsProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Tags.</summary>
		///--------------------------------------------------------------------------------
		public override string Tags
		{
			get
			{
				return EditView.Tags;
			}
			set
			{
				EditView.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (View.ReverseInstance != null)
				{
					return Tags != View.ReverseInstance.Tags;
				}
				else if (View.IsAutoUpdated == true)
				{
					return Tags != View.Tags;
				}
				return Tags != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TagsValidationMessage
		{
			get
			{
				return EditView.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditView.Name;
			}
			set
			{
				EditView.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditView.TransformDataFromObject(View, null, false);
			EditView.ResetModified(false);
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
			if (View.ReverseInstance != null)
			{
				EditView.TransformDataFromObject(View.ReverseInstance, null, false);
			}
			else if (View.IsAutoUpdated == true)
			{
				EditView.TransformDataFromObject(View, null, false);
			}
			else
			{
				View newView = new View();
				newView.ViewID = EditView.ViewID;
				EditView.TransformDataFromObject(newView, null, false);
			}
			EditView.ResetModified(true);
			foreach (ViewPropertyViewModel item in Items.OfType<ViewPropertyViewModel>())
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
		/// <summary>This method processes the new View command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewViewCommand()
		{
			ViewEventArgs message = new ViewEventArgs();
			message.View = new View();
			message.View.ViewID = Guid.NewGuid();
			message.View.SolutionID = SolutionID;
			message.View.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ViewEventArgs>(MediatorMessages.Command_EditViewRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditViewCommand()
		{
			ViewEventArgs message = new ViewEventArgs();
			message.View = View;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ViewEventArgs>(MediatorMessages.Command_EditViewRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to ViewProperty adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewViewProperty()
		{
			ViewPropertyViewModel item = new ViewPropertyViewModel();
			item.ViewProperty = new ViewProperty();
			item.ViewProperty.ViewPropertyID = Guid.NewGuid();
			item.ViewProperty.View = EditView;
			item.ViewProperty.ViewID = EditView.ViewID;
			item.ViewProperty.Solution = Solution;
			item.ViewProperty.Order = View.ViewPropertyList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new ViewProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewViewPropertyCommand()
		{
			ViewPropertyEventArgs message = new ViewPropertyEventArgs();
			message.ViewProperty = new ViewProperty();
			message.ViewProperty.ViewPropertyID = Guid.NewGuid();
			message.ViewProperty.View = View;
			message.ViewProperty.ViewID = View.ViewID;
			message.ViewID = View.ViewID;
			if (message.ViewProperty.View != null)
			{
				message.ViewProperty.Order = message.ViewProperty.View.ViewPropertyList.Count + 1;
			}
			message.ViewProperty.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ViewPropertyEventArgs>(MediatorMessages.Command_EditViewPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ViewProperty updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditViewPropertyPerformed(ViewPropertyEventArgs data)
		{
			if (data != null && data.ViewProperty != null)
			{
				UpdateEditViewProperty(data.ViewProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of ViewProperty.</summary>
		/// 
		/// <param name="viewProperty">The ViewProperty to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditViewProperty(ViewProperty viewProperty)
		{
			bool isItemMatch = false;
			foreach (ViewPropertyViewModel item in ViewProperties)
			{
				if (item.ViewProperty.ViewPropertyID == viewProperty.ViewPropertyID)
				{
					isItemMatch = true;
					item.ViewProperty.TransformDataFromObject(viewProperty, null, false);
					if (!item.ViewProperty.PropertyID.IsNullOrEmpty())
					{
						item.ViewProperty.Property = Solution.PropertyList.FindByID((Guid)item.ViewProperty.PropertyID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new ViewProperty
				viewProperty.View = View;
				ViewPropertyViewModel newItem = new ViewPropertyViewModel(viewProperty, Solution);
				if (!newItem.ViewProperty.PropertyID.IsNullOrEmpty())
				{
					newItem.ViewProperty.Property = Solution.PropertyList.FindByID((Guid)newItem.ViewProperty.PropertyID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				ViewProperties.Add(newItem);
				View.ViewPropertyList.Add(viewProperty);
				Solution.ViewPropertyList.Add(newItem.ViewProperty);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to ViewProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedViewProperties(ViewPropertyViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ViewProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteViewPropertyPerformed(ViewPropertyEventArgs data)
		{
			if (data != null && data.ViewProperty != null)
			{
				DeleteViewProperty(data.ViewProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of ViewProperty.</summary>
		/// 
		/// <param name="viewProperty">The ViewProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteViewProperty(ViewProperty viewProperty)
		{
			bool isItemMatch = false;
			foreach (ViewPropertyViewModel item in ViewProperties.ToList<ViewPropertyViewModel>())
			{
				if (item.ViewProperty.ViewPropertyID == viewProperty.ViewPropertyID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.ViewProperty.ViewPropertyID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete ViewProperty
					isItemMatch = true;
					ViewProperties.Remove(item);
					View.ViewPropertyList.Remove(item.ViewProperty);
					Solution.ViewPropertyList.Remove(item.ViewProperty);
					Items.Remove(item);
					View.ResetModified(true);
					OnUpdated(this, null);
					break;
				}
			}
			if (isItemMatch == false)
			{
				ShowIssue(DisplayValues.Issue_DeleteItemNotFound);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewViewCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (View.ReverseInstance == null && View.IsAutoUpdated == true)
			{
				View.ReverseInstance = new View();
				View.ReverseInstance.TransformDataFromObject(View, null, false);

				// perform the update of EditView back to View
				View.TransformDataFromObject(EditView, null, false);
				View.IsAutoUpdated = false;
			}
			else if (View.ReverseInstance != null)
			{
				EditView.ResetModified(View.ReverseInstance.IsModified);
				if (EditView.Equals(View.ReverseInstance))
				{
					// perform the update of EditView back to View
					View.TransformDataFromObject(EditView, null, false);
					View.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditView back to View
					View.TransformDataFromObject(EditView, null, false);
					View.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditView back to View
				View.TransformDataFromObject(EditView, null, false);
				View.IsAutoUpdated = false;
			}
			View.ForwardInstance = null;
			if (ViewNameCustomized || DescriptionCustomized || TagsCustomized)
			{
				View.ForwardInstance = new View();
				View.ForwardInstance.ViewID = EditView.ViewID;
				View.SpecSourceName = View.DefaultSourceName;
				if (ViewNameCustomized)
				{
					View.ForwardInstance.ViewName = EditView.ViewName;
				}
				if (DescriptionCustomized)
				{
					View.ForwardInstance.Description = EditView.Description;
				}
				if (TagsCustomized)
				{
					View.ForwardInstance.Tags = EditView.Tags;
				}
			}
			EditView.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditViewPerformed();

			// send update for any updated ViewProperties
			foreach (ViewPropertyViewModel item in ViewProperties)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new ViewProperties
			foreach (ViewPropertyViewModel item in ItemsToAdd.OfType<ViewPropertyViewModel>())
			{
				item.Update();
				ViewProperties.Add(item);
			}

			// send delete for any deleted ViewProperties
			foreach (ViewPropertyViewModel item in ItemsToDelete.OfType<ViewPropertyViewModel>())
			{
				item.Delete();
				ViewProperties.Remove(item);
			}

			// reset modified for ViewProperties
			foreach (ViewPropertyViewModel item in ViewProperties)
			{
				item.ResetModified(false);
			}
			ItemsToAdd.Clear();
			ItemsToDelete.Clear();
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
		/// <summary>This method sends the edit item performed message to have the
		/// update applied.</summary>
		///--------------------------------------------------------------------------------
		public void SendEditViewPerformed()
		{
			ViewEventArgs message = new ViewEventArgs();
			message.View = View;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ViewEventArgs>(MediatorMessages.Command_EditViewPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete View command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteViewCommand()
		{
			ViewEventArgs message = new ViewEventArgs();
			message.View = View;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ViewEventArgs>(MediatorMessages.Command_DeleteViewRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteViewCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ViewProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ViewPropertyViewModel> ViewProperties { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the View.</summary>
		///--------------------------------------------------------------------------------
		public View View { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ViewID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ViewID
		{
			get
			{
				return View.ViewID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return View.Name;
			}
			set
			{
				View.Name = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of View into the view model.</summary>
		/// 
		/// <param name="view">The View to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadView(View view, bool loadChildren = true)
		{
			// attach the View
			View = view;
			ItemID = View.ViewID;
			Items.Clear();
			
			// initialize ViewProperties
			if (ViewProperties == null)
			{
				ViewProperties = new EnterpriseDataObjectList<ViewPropertyViewModel>();
			}
			if (loadChildren == true)
			{
				// attach ViewProperties
				foreach (ViewProperty item in view.ViewPropertyList)
				{
					ViewPropertyViewModel itemView = new ViewPropertyViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					ViewProperties.Add(itemView);
					Items.Add(itemView);
				}
				#region protected
				#endregion protected
				
				Refresh(false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			if (refreshChildren == true || refreshLevel > 0)
			{
				foreach (ViewPropertyViewModel item in ViewProperties)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !View.IsValid;
			HasCustomizations = View.IsAutoUpdated == false || View.IsEmptyMetadata(View.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && View.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				View.IsAutoUpdated = true;
				View.SpecSourceName = View.ReverseInstance.SpecSourceName;
				View.ResetModified(View.ReverseInstance.IsModified);
				View.ResetLoaded(View.ReverseInstance.IsLoaded);
				if (!View.IsIdenticalMetadata(View.ReverseInstance))
				{
					HasCustomizations = true;
					View.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				View.ForwardInstance = null;
				View.ReverseInstance = null;
				View.IsAutoUpdated = true;
			}
			foreach (ViewPropertyViewModel item in ViewProperties)
			{
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
			if (ViewProperties != null)
			{
				for (int i = ViewProperties.Count - 1; i >= 0; i--)
				{
					ViewProperties[i].Updated -= Children_Updated;
					ViewProperties[i].Dispose();
					ViewProperties.Remove(ViewProperties[i]);
				}
				ViewProperties = null;
			}
			if (_editView != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditView.PropertyChanged -= EditView_PropertyChanged;
				EditView = null;
			}
			View = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (ViewPropertyViewModel item in ViewProperties)
			{
				if (item.HasCustomizations == true)
				{
					return true;
				}
			}
			return false;
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
		/// <summary>This method manages when changes occur to child collections.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("ViewPropertyList");
			OnPropertyChanged("ViewPropertyListCustomized");
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
			if (data is ViewPropertyEventArgs && (data as ViewPropertyEventArgs).ViewID == View.ViewID)
			{
				return this;
			}
			foreach (ViewPropertyViewModel model in ViewProperties)
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
		public ViewPropertyViewModel PasteViewProperty(ViewPropertyViewModel copyItem, bool savePaste = true)
		{
			ViewProperty newItem = new ViewProperty();
			newItem.ReverseInstance = new ViewProperty();
			newItem.TransformDataFromObject(copyItem.ViewProperty, null, false);
			newItem.ViewPropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Property by existing id first, second by old id, finally by name
			newItem.Property = Solution.PropertyList.FindByID((Guid)copyItem.ViewProperty.PropertyID);
			if (newItem.Property == null && Solution.PasteNewGuids[copyItem.ViewProperty.PropertyID.ToString()] is Guid)
			{
				newItem.Property = Solution.PropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.ViewProperty.PropertyID.ToString()]);
			}
			if (newItem.Property == null)
			{
				newItem.Property = Solution.PropertyList.Find("Name", copyItem.ViewProperty.Name);
			}
			if (newItem.Property == null)
			{
				newItem.OldPropertyID = newItem.PropertyID;
				newItem.PropertyID = Guid.Empty;
			}
			newItem.View = View;
			newItem.Solution = Solution;
			ViewPropertyViewModel newView = new ViewPropertyViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddViewProperty(newView);
			if (savePaste == true)
			{
				Solution.ViewPropertyList.Add(newItem);
				View.ViewPropertyList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of ViewProperty to the view model.</summary>
		/// 
		/// <param name="itemView">The ViewProperty to add.</param>
		///--------------------------------------------------------------------------------
		public void AddViewProperty(ViewPropertyViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			ViewProperties.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of ViewProperty from the view model.</summary>
		/// 
		/// <param name="itemView">The ViewProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteViewProperty(ViewPropertyViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			ViewProperties.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ViewViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="view">The View to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ViewViewModel(View view, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadView(view, loadChildren);
		}

		#endregion "Constructors"
	}
}
