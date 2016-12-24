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
	/// <summary>This class provides views for PropertyRelationship instances.</summary>
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
	public partial class PropertyRelationshipViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyRelationship.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyRelationship
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyRelationship;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlPropertyRelationshipToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelPropertyRelationshipToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyRelationshipToolTip;
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
				if (EditPropertyRelationship.IsModified == true)
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
 
		private PropertyRelationship _editPropertyRelationship = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditPropertyRelationship.</summary>
		///--------------------------------------------------------------------------------
		public PropertyRelationship EditPropertyRelationship
		{
			get
			{
				if (_editPropertyRelationship == null)
				{
					_editPropertyRelationship = new PropertyRelationship();
					_editPropertyRelationship.PropertyChanged += new PropertyChangedEventHandler(EditPropertyRelationship_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (PropertyRelationship != null)
					{
						_editPropertyRelationship.TransformDataFromObject(PropertyRelationship, null, false);
						_editPropertyRelationship.Solution = PropertyRelationship.Solution;
						_editPropertyRelationship.Relationship = PropertyRelationship.Relationship;
						_editPropertyRelationship.PropertyBase = PropertyRelationship.PropertyBase;
					}
					_editPropertyRelationship.ResetModified(false);
				}
				return _editPropertyRelationship;
			}
			set
			{
				_editPropertyRelationship = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditPropertyRelationship_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditPropertyRelationship");
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
				return DisplayValues.Edit_PropertyRelationshipHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_PropertyRelationshipHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyRelationshipIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyRelationshipIDLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyRelationshipIDProperty + DisplayValues.Edit_LabelColon;
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
				return EditPropertyRelationship.RelationshipID;
			}
			set
			{
				EditPropertyRelationship.RelationshipID = value;
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
				if (PropertyRelationship.ReverseInstance != null)
				{
					return RelationshipID.GetGuid() != PropertyRelationship.ReverseInstance.RelationshipID.GetGuid();
				}
				else if (PropertyRelationship.IsAutoUpdated == true)
				{
					return RelationshipID.GetGuid() != PropertyRelationship.RelationshipID.GetGuid();
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
				return EditPropertyRelationship.ValidateRelationshipID();
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
				return EditPropertyRelationship.Order;
			}
			set
			{
				EditPropertyRelationship.Order = value;
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
				if (PropertyRelationship.ReverseInstance != null)
				{
					return Order.GetInt() != PropertyRelationship.ReverseInstance.Order.GetInt();
				}
				else if (PropertyRelationship.IsAutoUpdated == true)
				{
					return Order.GetInt() != PropertyRelationship.Order.GetInt();
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
				return EditPropertyRelationship.ValidateOrder();
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
				return EditPropertyRelationship.Description;
			}
			set
			{
				EditPropertyRelationship.Description = value;
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
				if (PropertyRelationship.ReverseInstance != null)
				{
					return Description.GetString() != PropertyRelationship.ReverseInstance.Description.GetString();
				}
				else if (PropertyRelationship.IsAutoUpdated == true)
				{
					return Description.GetString() != PropertyRelationship.Description.GetString();
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
				return EditPropertyRelationship.ValidateDescription();
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
				return EditPropertyRelationship.SourceName;
			}
			set
			{
				EditPropertyRelationship.SourceName = value;
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
				return EditPropertyRelationship.SpecSourceName;
			}
			set
			{
				EditPropertyRelationship.SpecSourceName = value;
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
				return EditPropertyRelationship.Tags;
			}
			set
			{
				EditPropertyRelationship.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (PropertyRelationship.ReverseInstance != null)
				{
					return Tags != PropertyRelationship.ReverseInstance.Tags;
				}
				else if (PropertyRelationship.IsAutoUpdated == true)
				{
					return Tags != PropertyRelationship.Tags;
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
				return EditPropertyRelationship.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditPropertyRelationship.Name;
			}
			set
			{
				EditPropertyRelationship.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditPropertyRelationship.TransformDataFromObject(PropertyRelationship, null, false);
			EditPropertyRelationship.ResetModified(false);
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
			if (PropertyRelationship.ReverseInstance != null)
			{
				EditPropertyRelationship.TransformDataFromObject(PropertyRelationship.ReverseInstance, null, false);
			}
			else if (PropertyRelationship.IsAutoUpdated == true)
			{
				EditPropertyRelationship.TransformDataFromObject(PropertyRelationship, null, false);
			}
			else
			{
				PropertyRelationship newPropertyRelationship = new PropertyRelationship();
				newPropertyRelationship.PropertyRelationshipID = EditPropertyRelationship.PropertyRelationshipID;
				EditPropertyRelationship.TransformDataFromObject(newPropertyRelationship, null, false);
			}
			EditPropertyRelationship.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new PropertyRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyRelationshipCommand()
		{
			PropertyRelationshipEventArgs message = new PropertyRelationshipEventArgs();
			message.PropertyRelationship = new PropertyRelationship();
			message.PropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
			message.PropertyRelationship.PropertyID = PropertyID;
			message.PropertyRelationship.PropertyBase = Solution.PropertyBaseList.FindByID((Guid)PropertyID);
			if (message.PropertyRelationship.PropertyBase != null)
			{
				message.PropertyRelationship.Order = message.PropertyRelationship.PropertyBase.PropertyRelationshipList.Count + 1;
			}
			message.PropertyRelationship.Solution = Solution;
			message.PropertyID = PropertyID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyRelationshipEventArgs>(MediatorMessages.Command_EditPropertyRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyRelationshipCommand()
		{
			PropertyRelationshipEventArgs message = new PropertyRelationshipEventArgs();
			message.PropertyRelationship = PropertyRelationship;
			message.PropertyID = PropertyID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyRelationshipEventArgs>(MediatorMessages.Command_EditPropertyRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewPropertyRelationshipCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (PropertyRelationship.ReverseInstance == null && PropertyRelationship.IsAutoUpdated == true)
			{
				PropertyRelationship.ReverseInstance = new PropertyRelationship();
				PropertyRelationship.ReverseInstance.TransformDataFromObject(PropertyRelationship, null, false);

				// perform the update of EditPropertyRelationship back to PropertyRelationship
				PropertyRelationship.TransformDataFromObject(EditPropertyRelationship, null, false);
				PropertyRelationship.IsAutoUpdated = false;
			}
			else if (PropertyRelationship.ReverseInstance != null)
			{
				EditPropertyRelationship.ResetModified(PropertyRelationship.ReverseInstance.IsModified);
				if (EditPropertyRelationship.Equals(PropertyRelationship.ReverseInstance))
				{
					// perform the update of EditPropertyRelationship back to PropertyRelationship
					PropertyRelationship.TransformDataFromObject(EditPropertyRelationship, null, false);
					PropertyRelationship.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditPropertyRelationship back to PropertyRelationship
					PropertyRelationship.TransformDataFromObject(EditPropertyRelationship, null, false);
					PropertyRelationship.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditPropertyRelationship back to PropertyRelationship
				PropertyRelationship.TransformDataFromObject(EditPropertyRelationship, null, false);
				PropertyRelationship.IsAutoUpdated = false;
			}
			PropertyRelationship.ForwardInstance = null;
			if (RelationshipIDCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				PropertyRelationship.ForwardInstance = new PropertyRelationship();
				PropertyRelationship.ForwardInstance.PropertyRelationshipID = EditPropertyRelationship.PropertyRelationshipID;
				PropertyRelationship.SpecSourceName = PropertyRelationship.DefaultSourceName;
				if (RelationshipIDCustomized)
				{
					PropertyRelationship.ForwardInstance.RelationshipID = EditPropertyRelationship.RelationshipID;
				}
				if (OrderCustomized)
				{
					PropertyRelationship.ForwardInstance.Order = EditPropertyRelationship.Order;
				}
				if (DescriptionCustomized)
				{
					PropertyRelationship.ForwardInstance.Description = EditPropertyRelationship.Description;
				}
				if (TagsCustomized)
				{
					PropertyRelationship.ForwardInstance.Tags = EditPropertyRelationship.Tags;
				}
			}
			EditPropertyRelationship.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditPropertyRelationshipPerformed();
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
		public void SendEditPropertyRelationshipPerformed()
		{
			PropertyRelationshipEventArgs message = new PropertyRelationshipEventArgs();
			message.PropertyRelationship = PropertyRelationship;
			message.PropertyID = PropertyID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyRelationshipEventArgs>(MediatorMessages.Command_EditPropertyRelationshipPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete PropertyRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyRelationshipCommand()
		{
			PropertyRelationshipEventArgs message = new PropertyRelationshipEventArgs();
			message.PropertyRelationship = PropertyRelationship;
			message.PropertyID = PropertyID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyRelationshipEventArgs>(MediatorMessages.Command_DeletePropertyRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeletePropertyRelationshipCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyRelationship.</summary>
		///--------------------------------------------------------------------------------
		public PropertyRelationship PropertyRelationship { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyRelationshipID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyRelationshipID
		{
			get
			{
				return PropertyRelationship.PropertyRelationshipID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return PropertyRelationship.Name;
			}
			set
			{
				PropertyRelationship.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return PropertyRelationship.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyID
		{
			get
			{
				return PropertyRelationship.PropertyID;
			}
			set
			{
				PropertyRelationship.PropertyID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of PropertyRelationship into the view model.</summary>
		/// 
		/// <param name="propertyRelationship">The PropertyRelationship to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadPropertyRelationship(PropertyRelationship propertyRelationship, bool loadChildren = true)
		{
			// attach the PropertyRelationship
			PropertyRelationship = propertyRelationship;
			ItemID = PropertyRelationship.PropertyRelationshipID;
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
			
			HasErrors = !PropertyRelationship.IsValid;
			HasCustomizations = PropertyRelationship.IsAutoUpdated == false || PropertyRelationship.IsEmptyMetadata(PropertyRelationship.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && PropertyRelationship.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				PropertyRelationship.IsAutoUpdated = true;
				PropertyRelationship.SpecSourceName = PropertyRelationship.ReverseInstance.SpecSourceName;
				PropertyRelationship.ResetModified(PropertyRelationship.ReverseInstance.IsModified);
				PropertyRelationship.ResetLoaded(PropertyRelationship.ReverseInstance.IsLoaded);
				if (!PropertyRelationship.IsIdenticalMetadata(PropertyRelationship.ReverseInstance))
				{
					HasCustomizations = true;
					PropertyRelationship.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				PropertyRelationship.ForwardInstance = null;
				PropertyRelationship.ReverseInstance = null;
				PropertyRelationship.IsAutoUpdated = true;
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
			if (_editPropertyRelationship != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditPropertyRelationship.PropertyChanged -= EditPropertyRelationship_PropertyChanged;
				EditPropertyRelationship = null;
			}
			PropertyRelationship = null;
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
		public PropertyRelationshipViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="propertyRelationship">The PropertyRelationship to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public PropertyRelationshipViewModel(PropertyRelationship propertyRelationship, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadPropertyRelationship(propertyRelationship, loadChildren);
		}

		#endregion "Constructors"
	}
}
