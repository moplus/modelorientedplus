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
	/// <summary>This class provides views for StageTransition instances.</summary>
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
	public partial class StageTransitionViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewStageTransition.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewStageTransition
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageTransition;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlStageTransitionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelStageTransitionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewStageTransitionToolTip;
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
				if (EditStageTransition.IsModified == true)
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
				return string.IsNullOrEmpty(StageTransitionNameValidationMessage + FromStageIDValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private StageTransition _editStageTransition = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditStageTransition.</summary>
		///--------------------------------------------------------------------------------
		public StageTransition EditStageTransition
		{
			get
			{
				if (_editStageTransition == null)
				{
					_editStageTransition = new StageTransition();
					_editStageTransition.PropertyChanged += new PropertyChangedEventHandler(EditStageTransition_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (StageTransition != null)
					{
						_editStageTransition.TransformDataFromObject(StageTransition, null, false);
						_editStageTransition.Solution = StageTransition.Solution;
						_editStageTransition.FromStage = StageTransition.FromStage;
						_editStageTransition.ToStage = StageTransition.ToStage;
					}
					_editStageTransition.ResetModified(false);
				}
				return _editStageTransition;
			}
			set
			{
				_editStageTransition = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditStageTransition_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditStageTransition");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("StageTransitionName");
			OnPropertyChanged("StageTransitionNameCustomized");
			OnPropertyChanged("StageTransitionNameValidationMessage");
			
			OnPropertyChanged("FromStageID");
			OnPropertyChanged("FromStageIDCustomized");
			OnPropertyChanged("FromStageIDValidationMessage");
			
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
				return DisplayValues.Edit_StageTransitionHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_StageTransitionHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StageTransitionIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StageTransitionIDLabel
		{
			get
			{
				return DisplayValues.Edit_StageTransitionIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StageTransitionNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string StageTransitionNameLabel
		{
			get
			{
				return DisplayValues.Edit_StageTransitionNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets StageTransitionName.</summary>
		///--------------------------------------------------------------------------------
		public string StageTransitionName
		{
			get
			{
				return EditStageTransition.StageTransitionName;
			}
			set
			{
				EditStageTransition.StageTransitionName = value;
				OnPropertyChanged("StageTransitionName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageTransitionNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool StageTransitionNameCustomized
		{
			get
			{
				if (StageTransition.ReverseInstance != null)
				{
					return StageTransitionName.GetString() != StageTransition.ReverseInstance.StageTransitionName.GetString();
				}
				else if (StageTransition.IsAutoUpdated == true)
				{
					return StageTransitionName.GetString() != StageTransition.StageTransitionName.GetString();
				}
				return StageTransitionName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageTransitionNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string StageTransitionNameValidationMessage
		{
			get
			{
				return EditStageTransition.ValidateStageTransitionName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the FromStageIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string FromStageIDLabel
		{
			get
			{
				return DisplayValues.Edit_FromStageIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets FromStageID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? FromStageID
		{
			get
			{
				return EditStageTransition.FromStageID;
			}
			set
			{
				EditStageTransition.FromStageID = value;
				OnPropertyChanged("FromStageID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStageIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool FromStageIDCustomized
		{
			get
			{
				if (StageTransition.ReverseInstance != null)
				{
					return FromStageID.GetGuid() != StageTransition.ReverseInstance.FromStageID.GetGuid();
				}
				else if (StageTransition.IsAutoUpdated == true)
				{
					return FromStageID.GetGuid() != StageTransition.FromStageID.GetGuid();
				}
				return FromStageID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStageIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string FromStageIDValidationMessage
		{
			get
			{
				return EditStageTransition.ValidateFromStageID();
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
				return EditStageTransition.Description;
			}
			set
			{
				EditStageTransition.Description = value;
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
				if (StageTransition.ReverseInstance != null)
				{
					return Description.GetString() != StageTransition.ReverseInstance.Description.GetString();
				}
				else if (StageTransition.IsAutoUpdated == true)
				{
					return Description.GetString() != StageTransition.Description.GetString();
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
				return EditStageTransition.ValidateDescription();
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
				return EditStageTransition.SourceName;
			}
			set
			{
				EditStageTransition.SourceName = value;
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
				return EditStageTransition.SpecSourceName;
			}
			set
			{
				EditStageTransition.SpecSourceName = value;
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
				return EditStageTransition.Tags;
			}
			set
			{
				EditStageTransition.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (StageTransition.ReverseInstance != null)
				{
					return Tags != StageTransition.ReverseInstance.Tags;
				}
				else if (StageTransition.IsAutoUpdated == true)
				{
					return Tags != StageTransition.Tags;
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
				return EditStageTransition.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditStageTransition.Name;
			}
			set
			{
				EditStageTransition.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditStageTransition.TransformDataFromObject(StageTransition, null, false);
			EditStageTransition.ResetModified(false);
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
			if (StageTransition.ReverseInstance != null)
			{
				EditStageTransition.TransformDataFromObject(StageTransition.ReverseInstance, null, false);
			}
			else if (StageTransition.IsAutoUpdated == true)
			{
				EditStageTransition.TransformDataFromObject(StageTransition, null, false);
			}
			else
			{
				StageTransition newStageTransition = new StageTransition();
				newStageTransition.StageTransitionID = EditStageTransition.StageTransitionID;
				EditStageTransition.TransformDataFromObject(newStageTransition, null, false);
			}
			EditStageTransition.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new StageTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewStageTransitionCommand()
		{
			StageTransitionEventArgs message = new StageTransitionEventArgs();
			message.StageTransition = new StageTransition();
			message.StageTransition.StageTransitionID = Guid.NewGuid();
			message.StageTransition.ToStageID = ToStageID;
			message.StageTransition.ToStage = Solution.StageList.FindByID((Guid)ToStageID);
			message.StageTransition.Solution = Solution;
			message.ToStageID = ToStageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageTransitionEventArgs>(MediatorMessages.Command_EditStageTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditStageTransitionCommand()
		{
			StageTransitionEventArgs message = new StageTransitionEventArgs();
			message.StageTransition = StageTransition;
			message.ToStageID = ToStageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageTransitionEventArgs>(MediatorMessages.Command_EditStageTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewStageTransitionCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (StageTransition.ReverseInstance == null && StageTransition.IsAutoUpdated == true)
			{
				StageTransition.ReverseInstance = new StageTransition();
				StageTransition.ReverseInstance.TransformDataFromObject(StageTransition, null, false);

				// perform the update of EditStageTransition back to StageTransition
				StageTransition.TransformDataFromObject(EditStageTransition, null, false);
				StageTransition.IsAutoUpdated = false;
			}
			else if (StageTransition.ReverseInstance != null)
			{
				EditStageTransition.ResetModified(StageTransition.ReverseInstance.IsModified);
				if (EditStageTransition.Equals(StageTransition.ReverseInstance))
				{
					// perform the update of EditStageTransition back to StageTransition
					StageTransition.TransformDataFromObject(EditStageTransition, null, false);
					StageTransition.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditStageTransition back to StageTransition
					StageTransition.TransformDataFromObject(EditStageTransition, null, false);
					StageTransition.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditStageTransition back to StageTransition
				StageTransition.TransformDataFromObject(EditStageTransition, null, false);
				StageTransition.IsAutoUpdated = false;
			}
			StageTransition.ForwardInstance = null;
			if (StageTransitionNameCustomized || FromStageIDCustomized || DescriptionCustomized || TagsCustomized)
			{
				StageTransition.ForwardInstance = new StageTransition();
				StageTransition.ForwardInstance.StageTransitionID = EditStageTransition.StageTransitionID;
				StageTransition.SpecSourceName = StageTransition.DefaultSourceName;
				if (StageTransitionNameCustomized)
				{
					StageTransition.ForwardInstance.StageTransitionName = EditStageTransition.StageTransitionName;
				}
				if (FromStageIDCustomized)
				{
					StageTransition.ForwardInstance.FromStageID = EditStageTransition.FromStageID;
				}
				if (DescriptionCustomized)
				{
					StageTransition.ForwardInstance.Description = EditStageTransition.Description;
				}
				if (TagsCustomized)
				{
					StageTransition.ForwardInstance.Tags = EditStageTransition.Tags;
				}
			}
			EditStageTransition.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditStageTransitionPerformed();
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
		public void SendEditStageTransitionPerformed()
		{
			StageTransitionEventArgs message = new StageTransitionEventArgs();
			message.StageTransition = StageTransition;
			message.ToStageID = ToStageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageTransitionEventArgs>(MediatorMessages.Command_EditStageTransitionPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete StageTransition command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteStageTransitionCommand()
		{
			StageTransitionEventArgs message = new StageTransitionEventArgs();
			message.StageTransition = StageTransition;
			message.ToStageID = ToStageID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<StageTransitionEventArgs>(MediatorMessages.Command_DeleteStageTransitionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteStageTransitionCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StageTransition.</summary>
		///--------------------------------------------------------------------------------
		public StageTransition StageTransition { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageTransitionID.</summary>
		///--------------------------------------------------------------------------------
		public Guid StageTransitionID
		{
			get
			{
				return StageTransition.StageTransitionID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return StageTransition.Name;
			}
			set
			{
				StageTransition.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ToStageID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ToStageID
		{
			get
			{
				return StageTransition.ToStageID;
			}
			set
			{
				StageTransition.ToStageID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of StageTransition into the view model.</summary>
		/// 
		/// <param name="stageTransition">The StageTransition to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadStageTransition(StageTransition stageTransition, bool loadChildren = true)
		{
			// attach the StageTransition
			StageTransition = stageTransition;
			ItemID = StageTransition.StageTransitionID;
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
			
			HasErrors = !StageTransition.IsValid;
			HasCustomizations = StageTransition.IsAutoUpdated == false || StageTransition.IsEmptyMetadata(StageTransition.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && StageTransition.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				StageTransition.IsAutoUpdated = true;
				StageTransition.SpecSourceName = StageTransition.ReverseInstance.SpecSourceName;
				StageTransition.ResetModified(StageTransition.ReverseInstance.IsModified);
				StageTransition.ResetLoaded(StageTransition.ReverseInstance.IsLoaded);
				if (!StageTransition.IsIdenticalMetadata(StageTransition.ReverseInstance))
				{
					HasCustomizations = true;
					StageTransition.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				StageTransition.ForwardInstance = null;
				StageTransition.ReverseInstance = null;
				StageTransition.IsAutoUpdated = true;
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
			if (_editStageTransition != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditStageTransition.PropertyChanged -= EditStageTransition_PropertyChanged;
				EditStageTransition = null;
			}
			StageTransition = null;
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
		public StageTransitionViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="stageTransition">The StageTransition to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public StageTransitionViewModel(StageTransition stageTransition, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadStageTransition(stageTransition, loadChildren);
		}

		#endregion "Constructors"
	}
}
