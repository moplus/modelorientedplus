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

namespace MoPlus.ViewModel.Workflows
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for StepTransition instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/7/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class StepTransitionViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStepTransition.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStepTransition
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepTransition;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlStepTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStepTransitionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStepTransitionToolTip;
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
				if (EditStepTransition.IsModified == true)
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
				return string.IsNullOrEmpty(StepTransitionNameValidationMessage + FromStepIDValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private StepTransition _editStepTransition = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditStepTransition.</summary>
		///--------------------------------------------------------------------------------
		public StepTransition EditStepTransition
		{
			get
			{
				if (_editStepTransition == null)
				{
					_editStepTransition = new StepTransition();
					_editStepTransition.PropertyChanged += new PropertyChangedEventHandler(EditStepTransition_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (StepTransition != null)
					{
						_editStepTransition.TransformDataFromObject(StepTransition, null, false);
						_editStepTransition.Solution = StepTransition.Solution;
						_editStepTransition.FromStep = StepTransition.FromStep;
						_editStepTransition.ToStep = StepTransition.ToStep;
					}
					_editStepTransition.ResetModified(false);
				}
				return _editStepTransition;
			}
			set
			{
				_editStepTransition = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditStepTransition_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditStepTransition");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StepTransitionName");
			OnPropertyChanged("StepTransitionNameCustomized");
			OnPropertyChanged("StepTransitionNameValidationMessage");
			
			OnPropertyChanged("FromStepID");
			OnPropertyChanged("FromStepIDCustomized");
			OnPropertyChanged("FromStepIDValidationMessage");
			
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
				return DisplayValues.Edit_StepTransitionHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StepTransitionHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StepTransitionIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StepTransitionIDLabel
		{
			get
			{
				return DisplayValues.Edit_StepTransitionIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StepTransitionNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StepTransitionNameLabel
		{
			get
			{
				return DisplayValues.Edit_StepTransitionNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StepTransitionName.</summary>
		///--------------------------------------------------------------------------------
		public string StepTransitionName
		{
			get
			{
				return EditStepTransition.StepTransitionName;
			}
			set
			{
				EditStepTransition.StepTransitionName = value;
				OnPropertyChanged("StepTransitionName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepTransitionNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StepTransitionNameCustomized
		{
			get
			{
				if (StepTransition.ReverseInstance != null)
				{
					return StepTransitionName.GetString() != StepTransition.ReverseInstance.StepTransitionName.GetString();
				}
				else if (StepTransition.IsAutoUpdated == true)
				{
					return StepTransitionName.GetString() != StepTransition.StepTransitionName.GetString();
				}
				return StepTransitionName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepTransitionNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StepTransitionNameValidationMessage
		{
			get
			{
				return EditStepTransition.ValidateStepTransitionName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the FromStepIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string FromStepIDLabel
		{
			get
			{
				return DisplayValues.Edit_FromStepIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets FromStepID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? FromStepID
		{
			get
			{
				return EditStepTransition.FromStepID;
			}
			set
			{
				EditStepTransition.FromStepID = value;
				OnPropertyChanged("FromStepID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStepIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool FromStepIDCustomized
		{
			get
			{
				if (StepTransition.ReverseInstance != null)
				{
					return FromStepID.GetGuid() != StepTransition.ReverseInstance.FromStepID.GetGuid();
				}
				else if (StepTransition.IsAutoUpdated == true)
				{
					return FromStepID.GetGuid() != StepTransition.FromStepID.GetGuid();
				}
				return FromStepID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStepIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string FromStepIDValidationMessage
		{
			get
			{
				return EditStepTransition.ValidateFromStepID();
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
				return EditStepTransition.Description;
			}
			set
			{
				EditStepTransition.Description = value;
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
				if (StepTransition.ReverseInstance != null)
				{
					return Description.GetString() != StepTransition.ReverseInstance.Description.GetString();
				}
				else if (StepTransition.IsAutoUpdated == true)
				{
					return Description.GetString() != StepTransition.Description.GetString();
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
				return EditStepTransition.ValidateDescription();
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
				return EditStepTransition.SourceName;
			}
			set
			{
				EditStepTransition.SourceName = value;
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
				return EditStepTransition.SpecSourceName;
			}
			set
			{
				EditStepTransition.SpecSourceName = value;
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
				return EditStepTransition.Tags;
			}
			set
			{
				EditStepTransition.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (StepTransition.ReverseInstance != null)
				{
					return Tags != StepTransition.ReverseInstance.Tags;
				}
				else if (StepTransition.IsAutoUpdated == true)
				{
					return Tags != StepTransition.Tags;
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
				return EditStepTransition.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditStepTransition.Name;
			}
			set
			{
				EditStepTransition.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditStepTransition.TransformDataFromObject(StepTransition, null, false);
			EditStepTransition.ResetModified(false);
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
			if (StepTransition.ReverseInstance != null)
			{
				EditStepTransition.TransformDataFromObject(StepTransition.ReverseInstance, null, false);
			}
			else if (StepTransition.IsAutoUpdated == true)
			{
				EditStepTransition.TransformDataFromObject(StepTransition, null, false);
			}
			else
			{
				StepTransition newStepTransition = new StepTransition();
				newStepTransition.StepTransitionID = EditStepTransition.StepTransitionID;
				EditStepTransition.TransformDataFromObject(newStepTransition, null, false);
			}
			EditStepTransition.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new StepTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStepTransitionCommand()
		{
			StepTransitionEventArgs message = new StepTransitionEventArgs();
			message.StepTransition = new StepTransition();
			message.StepTransition.StepTransitionID = Guid.NewGuid();
			message.StepTransition.ToStepID = ToStepID;
			message.StepTransition.ToStep = Solution.StepList.FindByID((Guid)ToStepID);
			message.StepTransition.Solution = Solution;
			message.ToStepID = ToStepID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepTransitionEventArgs>(MediatorMessages.Command_EditStepTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStepTransitionCommand()
		{
			StepTransitionEventArgs message = new StepTransitionEventArgs();
			message.StepTransition = StepTransition;
			message.ToStepID = ToStepID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepTransitionEventArgs>(MediatorMessages.Command_EditStepTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewStepTransitionCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (StepTransition.ReverseInstance == null && StepTransition.IsAutoUpdated == true)
			{
				StepTransition.ReverseInstance = new StepTransition();
				StepTransition.ReverseInstance.TransformDataFromObject(StepTransition, null, false);

				// perform the update of EditStepTransition back to StepTransition
				StepTransition.TransformDataFromObject(EditStepTransition, null, false);
				StepTransition.IsAutoUpdated = false;
			}
			else if (StepTransition.ReverseInstance != null)
			{
				EditStepTransition.ResetModified(StepTransition.ReverseInstance.IsModified);
				if (EditStepTransition.Equals(StepTransition.ReverseInstance))
				{
					// perform the update of EditStepTransition back to StepTransition
					StepTransition.TransformDataFromObject(EditStepTransition, null, false);
					StepTransition.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditStepTransition back to StepTransition
					StepTransition.TransformDataFromObject(EditStepTransition, null, false);
					StepTransition.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditStepTransition back to StepTransition
				StepTransition.TransformDataFromObject(EditStepTransition, null, false);
				StepTransition.IsAutoUpdated = false;
			}
			StepTransition.ForwardInstance = null;
			if (StepTransitionNameCustomized || FromStepIDCustomized || DescriptionCustomized || TagsCustomized)
			{
				StepTransition.ForwardInstance = new StepTransition();
				StepTransition.ForwardInstance.StepTransitionID = EditStepTransition.StepTransitionID;
				StepTransition.SpecSourceName = StepTransition.DefaultSourceName;
				if (StepTransitionNameCustomized)
				{
					StepTransition.ForwardInstance.StepTransitionName = EditStepTransition.StepTransitionName;
				}
				if (FromStepIDCustomized)
				{
					StepTransition.ForwardInstance.FromStepID = EditStepTransition.FromStepID;
				}
				if (DescriptionCustomized)
				{
					StepTransition.ForwardInstance.Description = EditStepTransition.Description;
				}
				if (TagsCustomized)
				{
					StepTransition.ForwardInstance.Tags = EditStepTransition.Tags;
				}
			}
			EditStepTransition.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStepTransitionPerformed();
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
		public void SendEditStepTransitionPerformed()
		{
			StepTransitionEventArgs message = new StepTransitionEventArgs();
			message.StepTransition = StepTransition;
			message.ToStepID = ToStepID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepTransitionEventArgs>(MediatorMessages.Command_EditStepTransitionPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete StepTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStepTransitionCommand()
		{
			StepTransitionEventArgs message = new StepTransitionEventArgs();
			message.StepTransition = StepTransition;
			message.ToStepID = ToStepID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StepTransitionEventArgs>(MediatorMessages.Command_DeleteStepTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStepTransitionCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StepTransition.</summary>
		///--------------------------------------------------------------------------------
		public StepTransition StepTransition { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepTransitionID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StepTransitionID
		{
			get
			{
				return StepTransition.StepTransitionID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return StepTransition.Name;
			}
			set
			{
				StepTransition.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ToStepID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ToStepID
		{
			get
			{
				return StepTransition.ToStepID;
			}
			set
			{
				StepTransition.ToStepID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of StepTransition into the view model.</summary>
		/// 
		/// <param name="stepTransition">The StepTransition to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStepTransition(StepTransition stepTransition, bool loadChildren = true)
		{
			// attach the StepTransition
			StepTransition = stepTransition;
			ItemID = StepTransition.StepTransitionID;
			Items.Clear();
			if (loadChildren == true)
			{
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
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !StepTransition.IsValid;
			HasCustomizations = StepTransition.IsAutoUpdated == false || StepTransition.IsEmptyMetadata(StepTransition.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && StepTransition.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				StepTransition.IsAutoUpdated = true;
				StepTransition.SpecSourceName = StepTransition.ReverseInstance.SpecSourceName;
				StepTransition.ResetModified(StepTransition.ReverseInstance.IsModified);
				StepTransition.ResetLoaded(StepTransition.ReverseInstance.IsLoaded);
				if (!StepTransition.IsIdenticalMetadata(StepTransition.ReverseInstance))
				{
					HasCustomizations = true;
					StepTransition.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				StepTransition.ForwardInstance = null;
				StepTransition.ReverseInstance = null;
				StepTransition.IsAutoUpdated = true;
			}
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (_editStepTransition != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditStepTransition.PropertyChanged -= EditStepTransition_PropertyChanged;
				EditStepTransition = null;
			}
			StepTransition = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
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
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns the parent view model corresponding to
		/// the input message.</summary>
		///
		/// <param name="data">The message data to find parent for.</param>
		///--------------------------------------------------------------------------------
		public EditWorkspaceViewModel FindParentViewModel(SolutionModelEventArgs data)
		{
			#region protected
			#endregion protected
		
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public StepTransitionViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="stepTransition">The StepTransition to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StepTransitionViewModel(StepTransition stepTransition, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadStepTransition(stepTransition, loadChildren);
		}

		#endregion "Constructors"
	}
}
