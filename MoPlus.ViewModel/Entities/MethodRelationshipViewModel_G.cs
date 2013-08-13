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
	/// <summary>This class provides views for MethodRelationship instances.</summary>
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
	public partial class MethodRelationshipViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewMethodRelationship.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethodRelationship
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethodRelationship;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlMethodRelationshipToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelMethodRelationshipToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethodRelationshipToolTip;
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
				if (EditMethodRelationship.IsModified == true)
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
				return string.IsNullOrEmpty(RelationshipIDValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private MethodRelationship _editMethodRelationship = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditMethodRelationship.</summary>
		///--------------------------------------------------------------------------------
		public MethodRelationship EditMethodRelationship
		{
			get
			{
				if (_editMethodRelationship == null)
				{
					_editMethodRelationship = new MethodRelationship();
					_editMethodRelationship.PropertyChanged += new PropertyChangedEventHandler(EditMethodRelationship_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (MethodRelationship != null)
					{
						_editMethodRelationship.TransformDataFromObject(MethodRelationship, null, false);
						_editMethodRelationship.Solution = MethodRelationship.Solution;
						_editMethodRelationship.Relationship = MethodRelationship.Relationship;
						_editMethodRelationship.Method = MethodRelationship.Method;
					}
					_editMethodRelationship.ResetModified(false);
				}
				return _editMethodRelationship;
			}
			set
			{
				_editMethodRelationship = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditMethodRelationship_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditMethodRelationship");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("RelationshipID");
			OnPropertyChanged("RelationshipIDCustomized");
			OnPropertyChanged("RelationshipIDValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
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
				return DisplayValues.Edit_MethodRelationshipHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_MethodRelationshipHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodRelationshipIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string MethodRelationshipIDLabel
		{
			get
			{
				return DisplayValues.Edit_MethodRelationshipIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the RelationshipIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipIDLabel
		{
			get
			{
				return DisplayValues.Edit_RelationshipIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets RelationshipID.</summary>
		///--------------------------------------------------------------------------------
		public Guid RelationshipID
		{
			get
			{
				return EditMethodRelationship.RelationshipID;
			}
			set
			{
				EditMethodRelationship.RelationshipID = value;
				OnPropertyChanged("RelationshipID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool RelationshipIDCustomized
		{
			get
			{
				if (MethodRelationship.ReverseInstance != null)
				{
					return RelationshipID.GetGuid() != MethodRelationship.ReverseInstance.RelationshipID.GetGuid();
				}
				else if (MethodRelationship.IsAutoUpdated == true)
				{
					return RelationshipID.GetGuid() != MethodRelationship.RelationshipID.GetGuid();
				}
				return RelationshipID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipIDValidationMessage
		{
			get
			{
				return EditMethodRelationship.ValidateRelationshipID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the OrderLabel.</summary>
		///--------------------------------------------------------------------------------
		public string OrderLabel
		{
			get
			{
				return DisplayValues.Edit_OrderProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Order.</summary>
		///--------------------------------------------------------------------------------
		public int Order
		{
			get
			{
				return EditMethodRelationship.Order;
			}
			set
			{
				EditMethodRelationship.Order = value;
				OnPropertyChanged("Order");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets OrderCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool OrderCustomized
		{
			get
			{
				if (MethodRelationship.ReverseInstance != null)
				{
					return Order.GetInt() != MethodRelationship.ReverseInstance.Order.GetInt();
				}
				else if (MethodRelationship.IsAutoUpdated == true)
				{
					return Order.GetInt() != MethodRelationship.Order.GetInt();
				}
				return Order != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets OrderValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string OrderValidationMessage
		{
			get
			{
				return EditMethodRelationship.ValidateOrder();
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
				return EditMethodRelationship.Description;
			}
			set
			{
				EditMethodRelationship.Description = value;
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
				if (MethodRelationship.ReverseInstance != null)
				{
					return Description.GetString() != MethodRelationship.ReverseInstance.Description.GetString();
				}
				else if (MethodRelationship.IsAutoUpdated == true)
				{
					return Description.GetString() != MethodRelationship.Description.GetString();
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
				return EditMethodRelationship.ValidateDescription();
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
				return EditMethodRelationship.SourceName;
			}
			set
			{
				EditMethodRelationship.SourceName = value;
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
				return EditMethodRelationship.SpecSourceName;
			}
			set
			{
				EditMethodRelationship.SpecSourceName = value;
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
				return EditMethodRelationship.Tags;
			}
			set
			{
				EditMethodRelationship.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (MethodRelationship.ReverseInstance != null)
				{
					return Tags != MethodRelationship.ReverseInstance.Tags;
				}
				else if (MethodRelationship.IsAutoUpdated == true)
				{
					return Tags != MethodRelationship.Tags;
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
				return EditMethodRelationship.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditMethodRelationship.Name;
			}
			set
			{
				EditMethodRelationship.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditMethodRelationship.TransformDataFromObject(MethodRelationship, null, false);
			EditMethodRelationship.ResetModified(false);
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
			if (MethodRelationship.ReverseInstance != null)
			{
				EditMethodRelationship.TransformDataFromObject(MethodRelationship.ReverseInstance, null, false);
			}
			else if (MethodRelationship.IsAutoUpdated == true)
			{
				EditMethodRelationship.TransformDataFromObject(MethodRelationship, null, false);
			}
			else
			{
				MethodRelationship newMethodRelationship = new MethodRelationship();
				newMethodRelationship.MethodRelationshipID = EditMethodRelationship.MethodRelationshipID;
				EditMethodRelationship.TransformDataFromObject(newMethodRelationship, null, false);
			}
			EditMethodRelationship.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new MethodRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewMethodRelationshipCommand()
		{
			MethodRelationshipEventArgs message = new MethodRelationshipEventArgs();
			message.MethodRelationship = new MethodRelationship();
			message.MethodRelationship.MethodRelationshipID = Guid.NewGuid();
			message.MethodRelationship.MethodID = MethodID;
			message.MethodRelationship.Method = Solution.MethodList.FindByID((Guid)MethodID);
			if (message.MethodRelationship.Method != null)
			{
				message.MethodRelationship.Order = message.MethodRelationship.Method.MethodRelationshipList.Count + 1;
			}
			message.MethodRelationship.Solution = Solution;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodRelationshipEventArgs>(MediatorMessages.Command_EditMethodRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditMethodRelationshipCommand()
		{
			MethodRelationshipEventArgs message = new MethodRelationshipEventArgs();
			message.MethodRelationship = MethodRelationship;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodRelationshipEventArgs>(MediatorMessages.Command_EditMethodRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewMethodRelationshipCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (MethodRelationship.ReverseInstance == null && MethodRelationship.IsAutoUpdated == true)
			{
				MethodRelationship.ReverseInstance = new MethodRelationship();
				MethodRelationship.ReverseInstance.TransformDataFromObject(MethodRelationship, null, false);

				// perform the update of EditMethodRelationship back to MethodRelationship
				MethodRelationship.TransformDataFromObject(EditMethodRelationship, null, false);
				MethodRelationship.IsAutoUpdated = false;
			}
			else if (MethodRelationship.ReverseInstance != null)
			{
				EditMethodRelationship.ResetModified(MethodRelationship.ReverseInstance.IsModified);
				if (EditMethodRelationship.Equals(MethodRelationship.ReverseInstance))
				{
					// perform the update of EditMethodRelationship back to MethodRelationship
					MethodRelationship.TransformDataFromObject(EditMethodRelationship, null, false);
					MethodRelationship.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditMethodRelationship back to MethodRelationship
					MethodRelationship.TransformDataFromObject(EditMethodRelationship, null, false);
					MethodRelationship.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditMethodRelationship back to MethodRelationship
				MethodRelationship.TransformDataFromObject(EditMethodRelationship, null, false);
				MethodRelationship.IsAutoUpdated = false;
			}
			MethodRelationship.ForwardInstance = null;
			if (RelationshipIDCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				MethodRelationship.ForwardInstance = new MethodRelationship();
				MethodRelationship.ForwardInstance.MethodRelationshipID = EditMethodRelationship.MethodRelationshipID;
				MethodRelationship.SpecSourceName = MethodRelationship.DefaultSourceName;
				if (RelationshipIDCustomized)
				{
					MethodRelationship.ForwardInstance.RelationshipID = EditMethodRelationship.RelationshipID;
				}
				if (OrderCustomized)
				{
					MethodRelationship.ForwardInstance.Order = EditMethodRelationship.Order;
				}
				if (DescriptionCustomized)
				{
					MethodRelationship.ForwardInstance.Description = EditMethodRelationship.Description;
				}
				if (TagsCustomized)
				{
					MethodRelationship.ForwardInstance.Tags = EditMethodRelationship.Tags;
				}
			}
			EditMethodRelationship.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditMethodRelationshipPerformed();
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
		public void SendEditMethodRelationshipPerformed()
		{
			MethodRelationshipEventArgs message = new MethodRelationshipEventArgs();
			message.MethodRelationship = MethodRelationship;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodRelationshipEventArgs>(MediatorMessages.Command_EditMethodRelationshipPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete MethodRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteMethodRelationshipCommand()
		{
			MethodRelationshipEventArgs message = new MethodRelationshipEventArgs();
			message.MethodRelationship = MethodRelationship;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodRelationshipEventArgs>(MediatorMessages.Command_DeleteMethodRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteMethodRelationshipCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MethodRelationship.</summary>
		///--------------------------------------------------------------------------------
		public MethodRelationship MethodRelationship { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodRelationshipID.</summary>
		///--------------------------------------------------------------------------------
		public Guid MethodRelationshipID
		{
			get
			{
				return MethodRelationship.MethodRelationshipID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return MethodRelationship.Name;
			}
			set
			{
				MethodRelationship.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return MethodRelationship.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets MethodID.</summary>
		///--------------------------------------------------------------------------------
		public Guid MethodID
		{
			get
			{
				return MethodRelationship.MethodID;
			}
			set
			{
				MethodRelationship.MethodID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of MethodRelationship into the view model.</summary>
		/// 
		/// <param name="methodRelationship">The MethodRelationship to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadMethodRelationship(MethodRelationship methodRelationship, bool loadChildren = true)
		{
			// attach the MethodRelationship
			MethodRelationship = methodRelationship;
			ItemID = MethodRelationship.MethodRelationshipID;
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
			
			HasErrors = !MethodRelationship.IsValid;
			HasCustomizations = MethodRelationship.IsAutoUpdated == false || MethodRelationship.IsEmptyMetadata(MethodRelationship.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && MethodRelationship.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				MethodRelationship.IsAutoUpdated = true;
				MethodRelationship.SpecSourceName = MethodRelationship.ReverseInstance.SpecSourceName;
				MethodRelationship.ResetModified(MethodRelationship.ReverseInstance.IsModified);
				MethodRelationship.ResetLoaded(MethodRelationship.ReverseInstance.IsLoaded);
				if (!MethodRelationship.IsIdenticalMetadata(MethodRelationship.ReverseInstance))
				{
					HasCustomizations = true;
					MethodRelationship.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				MethodRelationship.ForwardInstance = null;
				MethodRelationship.ReverseInstance = null;
				MethodRelationship.IsAutoUpdated = true;
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
			if (_editMethodRelationship != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditMethodRelationship.PropertyChanged -= EditMethodRelationship_PropertyChanged;
				EditMethodRelationship = null;
			}
			MethodRelationship = null;
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
		public MethodRelationshipViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="methodRelationship">The MethodRelationship to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public MethodRelationshipViewModel(MethodRelationship methodRelationship, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadMethodRelationship(methodRelationship, loadChildren);
		}

		#endregion "Constructors"
	}
}
