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

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for PropertyInstance instances.</summary>
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
	public partial class PropertyInstanceViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstance;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlPropertyInstanceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelPropertyInstanceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstanceToolTip;
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
				if (EditPropertyInstance.IsModified == true)
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
				return string.IsNullOrEmpty(ModelPropertyIDValidationMessage + OrderValidationMessage + PropertyValueValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private PropertyInstance _editPropertyInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditPropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		public PropertyInstance EditPropertyInstance
		{
			get
			{
				if (_editPropertyInstance == null)
				{
					_editPropertyInstance = new PropertyInstance();
					_editPropertyInstance.PropertyChanged += new PropertyChangedEventHandler(EditPropertyInstance_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (PropertyInstance != null)
					{
						_editPropertyInstance.TransformDataFromObject(PropertyInstance, null, false);
						_editPropertyInstance.Solution = PropertyInstance.Solution;
						_editPropertyInstance.ModelProperty = PropertyInstance.ModelProperty;
						_editPropertyInstance.ObjectInstance = PropertyInstance.ObjectInstance;
					}
					_editPropertyInstance.ResetModified(false);
				}
				return _editPropertyInstance;
			}
			set
			{
				_editPropertyInstance = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditPropertyInstance_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditPropertyInstance");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ModelPropertyID");
			OnPropertyChanged("ModelPropertyIDCustomized");
			OnPropertyChanged("ModelPropertyIDValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("PropertyValue");
			OnPropertyChanged("PropertyValueCustomized");
			OnPropertyChanged("PropertyValueValidationMessage");
			
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
				return DisplayValues.Edit_PropertyInstanceHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_PropertyInstanceHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyInstanceIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyInstanceIDLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyInstanceIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelPropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelPropertyID
		{
			get
			{
				return EditPropertyInstance.ModelPropertyID;
			}
			set
			{
				EditPropertyInstance.ModelPropertyID = value;
				OnPropertyChanged("ModelPropertyID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelPropertyIDCustomized
		{
			get
			{
				if (PropertyInstance.ReverseInstance != null)
				{
					return ModelPropertyID.GetGuid() != PropertyInstance.ReverseInstance.ModelPropertyID.GetGuid();
				}
				else if (PropertyInstance.IsAutoUpdated == true)
				{
					return ModelPropertyID.GetGuid() != PropertyInstance.ModelPropertyID.GetGuid();
				}
				return ModelPropertyID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyIDValidationMessage
		{
			get
			{
				return EditPropertyInstance.ValidateModelPropertyID();
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
				return EditPropertyInstance.Order;
			}
			set
			{
				EditPropertyInstance.Order = value;
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
				if (PropertyInstance.ReverseInstance != null)
				{
					return Order.GetInt() != PropertyInstance.ReverseInstance.Order.GetInt();
				}
				else if (PropertyInstance.IsAutoUpdated == true)
				{
					return Order.GetInt() != PropertyInstance.Order.GetInt();
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
				return EditPropertyInstance.ValidateOrder();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyValueLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyValueLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyValueProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertyValue.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyValue
		{
			get
			{
				return EditPropertyInstance.PropertyValue;
			}
			set
			{
				EditPropertyInstance.PropertyValue = value;
				OnPropertyChanged("PropertyValue");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyValueCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PropertyValueCustomized
		{
			get
			{
				if (PropertyInstance.ReverseInstance != null)
				{
					return PropertyValue.GetString() != PropertyInstance.ReverseInstance.PropertyValue.GetString();
				}
				else if (PropertyInstance.IsAutoUpdated == true)
				{
					return PropertyValue.GetString() != PropertyInstance.PropertyValue.GetString();
				}
				return PropertyValue != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyValueValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyValueValidationMessage
		{
			get
			{
				return EditPropertyInstance.ValidatePropertyValue();
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
				return EditPropertyInstance.Description;
			}
			set
			{
				EditPropertyInstance.Description = value;
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
				if (PropertyInstance.ReverseInstance != null)
				{
					return Description.GetString() != PropertyInstance.ReverseInstance.Description.GetString();
				}
				else if (PropertyInstance.IsAutoUpdated == true)
				{
					return Description.GetString() != PropertyInstance.Description.GetString();
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
				return EditPropertyInstance.ValidateDescription();
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
				return EditPropertyInstance.SourceName;
			}
			set
			{
				EditPropertyInstance.SourceName = value;
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
				return EditPropertyInstance.SpecSourceName;
			}
			set
			{
				EditPropertyInstance.SpecSourceName = value;
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
				return EditPropertyInstance.Tags;
			}
			set
			{
				EditPropertyInstance.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (PropertyInstance.ReverseInstance != null)
				{
					return Tags != PropertyInstance.ReverseInstance.Tags;
				}
				else if (PropertyInstance.IsAutoUpdated == true)
				{
					return Tags != PropertyInstance.Tags;
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
				return EditPropertyInstance.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditPropertyInstance.Name;
			}
			set
			{
				EditPropertyInstance.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditPropertyInstance.TransformDataFromObject(PropertyInstance, null, false);
			EditPropertyInstance.ResetModified(false);
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
			if (PropertyInstance.ReverseInstance != null)
			{
				EditPropertyInstance.TransformDataFromObject(PropertyInstance.ReverseInstance, null, false);
			}
			else if (PropertyInstance.IsAutoUpdated == true)
			{
				EditPropertyInstance.TransformDataFromObject(PropertyInstance, null, false);
			}
			else
			{
				PropertyInstance newPropertyInstance = new PropertyInstance();
				newPropertyInstance.PropertyInstanceID = EditPropertyInstance.PropertyInstanceID;
				EditPropertyInstance.TransformDataFromObject(newPropertyInstance, null, false);
			}
			EditPropertyInstance.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new PropertyInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyInstanceCommand()
		{
			PropertyInstanceEventArgs message = new PropertyInstanceEventArgs();
			message.PropertyInstance = new PropertyInstance();
			message.PropertyInstance.PropertyInstanceID = Guid.NewGuid();
			message.PropertyInstance.ObjectInstanceID = ObjectInstanceID;
			message.PropertyInstance.ObjectInstance = Solution.ObjectInstanceList.FindByID((Guid)ObjectInstanceID);
			if (message.PropertyInstance.ObjectInstance != null)
			{
				message.PropertyInstance.Order = message.PropertyInstance.ObjectInstance.PropertyInstanceList.Count + 1;
			}
			message.PropertyInstance.Solution = Solution;
			message.ObjectInstanceID = ObjectInstanceID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyInstanceEventArgs>(MediatorMessages.Command_EditPropertyInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyInstanceCommand()
		{
			PropertyInstanceEventArgs message = new PropertyInstanceEventArgs();
			message.PropertyInstance = PropertyInstance;
			message.ObjectInstanceID = ObjectInstanceID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyInstanceEventArgs>(MediatorMessages.Command_EditPropertyInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewPropertyInstanceCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (PropertyInstance.ReverseInstance == null && PropertyInstance.IsAutoUpdated == true)
			{
				PropertyInstance.ReverseInstance = new PropertyInstance();
				PropertyInstance.ReverseInstance.TransformDataFromObject(PropertyInstance, null, false);

				// perform the update of EditPropertyInstance back to PropertyInstance
				PropertyInstance.TransformDataFromObject(EditPropertyInstance, null, false);
				PropertyInstance.IsAutoUpdated = false;
			}
			else if (PropertyInstance.ReverseInstance != null)
			{
				EditPropertyInstance.ResetModified(PropertyInstance.ReverseInstance.IsModified);
				if (EditPropertyInstance.Equals(PropertyInstance.ReverseInstance))
				{
					// perform the update of EditPropertyInstance back to PropertyInstance
					PropertyInstance.TransformDataFromObject(EditPropertyInstance, null, false);
					PropertyInstance.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditPropertyInstance back to PropertyInstance
					PropertyInstance.TransformDataFromObject(EditPropertyInstance, null, false);
					PropertyInstance.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditPropertyInstance back to PropertyInstance
				PropertyInstance.TransformDataFromObject(EditPropertyInstance, null, false);
				PropertyInstance.IsAutoUpdated = false;
			}
			PropertyInstance.ForwardInstance = null;
			if (ModelPropertyIDCustomized || OrderCustomized || PropertyValueCustomized || DescriptionCustomized || TagsCustomized)
			{
				PropertyInstance.ForwardInstance = new PropertyInstance();
				PropertyInstance.ForwardInstance.PropertyInstanceID = EditPropertyInstance.PropertyInstanceID;
				PropertyInstance.SpecSourceName = PropertyInstance.DefaultSourceName;
				if (ModelPropertyIDCustomized)
				{
					PropertyInstance.ForwardInstance.ModelPropertyID = EditPropertyInstance.ModelPropertyID;
				}
				if (OrderCustomized)
				{
					PropertyInstance.ForwardInstance.Order = EditPropertyInstance.Order;
				}
				if (PropertyValueCustomized)
				{
					PropertyInstance.ForwardInstance.PropertyValue = EditPropertyInstance.PropertyValue;
				}
				if (DescriptionCustomized)
				{
					PropertyInstance.ForwardInstance.Description = EditPropertyInstance.Description;
				}
				if (TagsCustomized)
				{
					PropertyInstance.ForwardInstance.Tags = EditPropertyInstance.Tags;
				}
			}
			EditPropertyInstance.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditPropertyInstancePerformed();
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
		public void SendEditPropertyInstancePerformed()
		{
			PropertyInstanceEventArgs message = new PropertyInstanceEventArgs();
			message.PropertyInstance = PropertyInstance;
			message.ObjectInstanceID = ObjectInstanceID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyInstanceEventArgs>(MediatorMessages.Command_EditPropertyInstancePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete PropertyInstance command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyInstanceCommand()
		{
			PropertyInstanceEventArgs message = new PropertyInstanceEventArgs();
			message.PropertyInstance = PropertyInstance;
			message.ObjectInstanceID = ObjectInstanceID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyInstanceEventArgs>(MediatorMessages.Command_DeletePropertyInstanceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeletePropertyInstanceCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		public PropertyInstance PropertyInstance { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyInstanceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyInstanceID
		{
			get
			{
				return PropertyInstance.PropertyInstanceID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return PropertyInstance.Name;
			}
			set
			{
				PropertyInstance.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return PropertyInstance.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ObjectInstanceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ObjectInstanceID
		{
			get
			{
				return PropertyInstance.ObjectInstanceID;
			}
			set
			{
				PropertyInstance.ObjectInstanceID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of PropertyInstance into the view model.</summary>
		/// 
		/// <param name="propertyInstance">The PropertyInstance to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadPropertyInstance(PropertyInstance propertyInstance, bool loadChildren = true)
		{
			// attach the PropertyInstance
			PropertyInstance = propertyInstance;
			ItemID = PropertyInstance.PropertyInstanceID;
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
			
			HasErrors = !PropertyInstance.IsValid;
			HasCustomizations = PropertyInstance.IsAutoUpdated == false || PropertyInstance.IsEmptyMetadata(PropertyInstance.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && PropertyInstance.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				PropertyInstance.IsAutoUpdated = true;
				PropertyInstance.SpecSourceName = PropertyInstance.ReverseInstance.SpecSourceName;
				PropertyInstance.ResetModified(PropertyInstance.ReverseInstance.IsModified);
				PropertyInstance.ResetLoaded(PropertyInstance.ReverseInstance.IsLoaded);
				if (!PropertyInstance.IsIdenticalMetadata(PropertyInstance.ReverseInstance))
				{
					HasCustomizations = true;
					PropertyInstance.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				PropertyInstance.ForwardInstance = null;
				PropertyInstance.ReverseInstance = null;
				PropertyInstance.IsAutoUpdated = true;
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
			if (_editPropertyInstance != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditPropertyInstance.PropertyChanged -= EditPropertyInstance_PropertyChanged;
				EditPropertyInstance = null;
			}
			PropertyInstance = null;
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
		public PropertyInstanceViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="propertyInstance">The PropertyInstance to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public PropertyInstanceViewModel(PropertyInstance propertyInstance, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadPropertyInstance(propertyInstance, loadChildren);
		}

		#endregion "Constructors"
	}
}
