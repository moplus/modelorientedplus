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
	/// <summary>This class provides views for RelationshipProperty instances.</summary>
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
	public partial class RelationshipPropertyViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewRelationshipProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewRelationshipProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlRelationshipPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRelationshipPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewRelationshipPropertyToolTip;
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
				if (EditRelationshipProperty.IsModified == true)
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
				return string.IsNullOrEmpty(PropertyIDValidationMessage + ReferencedPropertyIDValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private RelationshipProperty _editRelationshipProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditRelationshipProperty.</summary>
		///--------------------------------------------------------------------------------
		public RelationshipProperty EditRelationshipProperty
		{
			get
			{
				if (_editRelationshipProperty == null)
				{
					_editRelationshipProperty = new RelationshipProperty();
					_editRelationshipProperty.PropertyChanged += new PropertyChangedEventHandler(EditRelationshipProperty_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (RelationshipProperty != null)
					{
						_editRelationshipProperty.TransformDataFromObject(RelationshipProperty, null, false);
						_editRelationshipProperty.Solution = RelationshipProperty.Solution;
						_editRelationshipProperty.Property = RelationshipProperty.Property;
						_editRelationshipProperty.ReferencedProperty = RelationshipProperty.ReferencedProperty;
						_editRelationshipProperty.Relationship = RelationshipProperty.Relationship;
					}
					_editRelationshipProperty.ResetModified(false);
				}
				return _editRelationshipProperty;
			}
			set
			{
				_editRelationshipProperty = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditRelationshipProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditRelationshipProperty");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("PropertyID");
			OnPropertyChanged("PropertyIDCustomized");
			OnPropertyChanged("PropertyIDValidationMessage");
			
			OnPropertyChanged("ReferencedPropertyID");
			OnPropertyChanged("ReferencedPropertyIDCustomized");
			OnPropertyChanged("ReferencedPropertyIDValidationMessage");
			
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
				return DisplayValues.Edit_RelationshipPropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_RelationshipPropertyHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the RelationshipPropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string RelationshipPropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_RelationshipPropertyIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyID
		{
			get
			{
				return EditRelationshipProperty.PropertyID;
			}
			set
			{
				EditRelationshipProperty.PropertyID = value;
				OnPropertyChanged("PropertyID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PropertyIDCustomized
		{
			get
			{
				if (RelationshipProperty.ReverseInstance != null)
				{
					return PropertyID.GetGuid() != RelationshipProperty.ReverseInstance.PropertyID.GetGuid();
				}
				else if (RelationshipProperty.IsAutoUpdated == true)
				{
					return PropertyID.GetGuid() != RelationshipProperty.PropertyID.GetGuid();
				}
				return PropertyID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyIDValidationMessage
		{
			get
			{
				return EditRelationshipProperty.ValidatePropertyID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ReferencedPropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedPropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_ReferencedPropertyIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ReferencedPropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ReferencedPropertyID
		{
			get
			{
				return EditRelationshipProperty.ReferencedPropertyID;
			}
			set
			{
				EditRelationshipProperty.ReferencedPropertyID = value;
				OnPropertyChanged("ReferencedPropertyID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedPropertyIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ReferencedPropertyIDCustomized
		{
			get
			{
				if (RelationshipProperty.ReverseInstance != null)
				{
					return ReferencedPropertyID.GetGuid() != RelationshipProperty.ReverseInstance.ReferencedPropertyID.GetGuid();
				}
				else if (RelationshipProperty.IsAutoUpdated == true)
				{
					return ReferencedPropertyID.GetGuid() != RelationshipProperty.ReferencedPropertyID.GetGuid();
				}
				return ReferencedPropertyID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedPropertyIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedPropertyIDValidationMessage
		{
			get
			{
				return EditRelationshipProperty.ValidateReferencedPropertyID();
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
				return EditRelationshipProperty.Order;
			}
			set
			{
				EditRelationshipProperty.Order = value;
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
				if (RelationshipProperty.ReverseInstance != null)
				{
					return Order.GetInt() != RelationshipProperty.ReverseInstance.Order.GetInt();
				}
				else if (RelationshipProperty.IsAutoUpdated == true)
				{
					return Order.GetInt() != RelationshipProperty.Order.GetInt();
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
				return EditRelationshipProperty.ValidateOrder();
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
				return EditRelationshipProperty.Description;
			}
			set
			{
				EditRelationshipProperty.Description = value;
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
				if (RelationshipProperty.ReverseInstance != null)
				{
					return Description.GetString() != RelationshipProperty.ReverseInstance.Description.GetString();
				}
				else if (RelationshipProperty.IsAutoUpdated == true)
				{
					return Description.GetString() != RelationshipProperty.Description.GetString();
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
				return EditRelationshipProperty.ValidateDescription();
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
				return EditRelationshipProperty.SourceName;
			}
			set
			{
				EditRelationshipProperty.SourceName = value;
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
				return EditRelationshipProperty.SpecSourceName;
			}
			set
			{
				EditRelationshipProperty.SpecSourceName = value;
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
				return EditRelationshipProperty.Tags;
			}
			set
			{
				EditRelationshipProperty.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (RelationshipProperty.ReverseInstance != null)
				{
					return Tags != RelationshipProperty.ReverseInstance.Tags;
				}
				else if (RelationshipProperty.IsAutoUpdated == true)
				{
					return Tags != RelationshipProperty.Tags;
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
				return EditRelationshipProperty.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditRelationshipProperty.Name;
			}
			set
			{
				EditRelationshipProperty.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditRelationshipProperty.TransformDataFromObject(RelationshipProperty, null, false);
			EditRelationshipProperty.ResetModified(false);
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
			if (RelationshipProperty.ReverseInstance != null)
			{
				EditRelationshipProperty.TransformDataFromObject(RelationshipProperty.ReverseInstance, null, false);
			}
			else if (RelationshipProperty.IsAutoUpdated == true)
			{
				EditRelationshipProperty.TransformDataFromObject(RelationshipProperty, null, false);
			}
			else
			{
				RelationshipProperty newRelationshipProperty = new RelationshipProperty();
				newRelationshipProperty.RelationshipPropertyID = EditRelationshipProperty.RelationshipPropertyID;
				EditRelationshipProperty.TransformDataFromObject(newRelationshipProperty, null, false);
			}
			EditRelationshipProperty.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new RelationshipProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewRelationshipPropertyCommand()
		{
			RelationshipPropertyEventArgs message = new RelationshipPropertyEventArgs();
			message.RelationshipProperty = new RelationshipProperty();
			message.RelationshipProperty.RelationshipPropertyID = Guid.NewGuid();
			message.RelationshipProperty.RelationshipID = RelationshipID;
			message.RelationshipProperty.Relationship = Solution.RelationshipList.FindByID((Guid)RelationshipID);
			if (message.RelationshipProperty.Relationship != null)
			{
				message.RelationshipProperty.Order = message.RelationshipProperty.Relationship.RelationshipPropertyList.Count + 1;
			}
			message.RelationshipProperty.Solution = Solution;
			message.RelationshipID = RelationshipID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipPropertyEventArgs>(MediatorMessages.Command_EditRelationshipPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditRelationshipPropertyCommand()
		{
			RelationshipPropertyEventArgs message = new RelationshipPropertyEventArgs();
			message.RelationshipProperty = RelationshipProperty;
			message.RelationshipID = RelationshipID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipPropertyEventArgs>(MediatorMessages.Command_EditRelationshipPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewRelationshipPropertyCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (RelationshipProperty.ReverseInstance == null && RelationshipProperty.IsAutoUpdated == true)
			{
				RelationshipProperty.ReverseInstance = new RelationshipProperty();
				RelationshipProperty.ReverseInstance.TransformDataFromObject(RelationshipProperty, null, false);

				// perform the update of EditRelationshipProperty back to RelationshipProperty
				RelationshipProperty.TransformDataFromObject(EditRelationshipProperty, null, false);
				RelationshipProperty.IsAutoUpdated = false;
			}
			else if (RelationshipProperty.ReverseInstance != null)
			{
				EditRelationshipProperty.ResetModified(RelationshipProperty.ReverseInstance.IsModified);
				if (EditRelationshipProperty.Equals(RelationshipProperty.ReverseInstance))
				{
					// perform the update of EditRelationshipProperty back to RelationshipProperty
					RelationshipProperty.TransformDataFromObject(EditRelationshipProperty, null, false);
					RelationshipProperty.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditRelationshipProperty back to RelationshipProperty
					RelationshipProperty.TransformDataFromObject(EditRelationshipProperty, null, false);
					RelationshipProperty.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditRelationshipProperty back to RelationshipProperty
				RelationshipProperty.TransformDataFromObject(EditRelationshipProperty, null, false);
				RelationshipProperty.IsAutoUpdated = false;
			}
			RelationshipProperty.ForwardInstance = null;
			if (PropertyIDCustomized || ReferencedPropertyIDCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				RelationshipProperty.ForwardInstance = new RelationshipProperty();
				RelationshipProperty.ForwardInstance.RelationshipPropertyID = EditRelationshipProperty.RelationshipPropertyID;
				RelationshipProperty.SpecSourceName = RelationshipProperty.DefaultSourceName;
				if (PropertyIDCustomized)
				{
					RelationshipProperty.ForwardInstance.PropertyID = EditRelationshipProperty.PropertyID;
				}
				if (ReferencedPropertyIDCustomized)
				{
					RelationshipProperty.ForwardInstance.ReferencedPropertyID = EditRelationshipProperty.ReferencedPropertyID;
				}
				if (OrderCustomized)
				{
					RelationshipProperty.ForwardInstance.Order = EditRelationshipProperty.Order;
				}
				if (DescriptionCustomized)
				{
					RelationshipProperty.ForwardInstance.Description = EditRelationshipProperty.Description;
				}
				if (TagsCustomized)
				{
					RelationshipProperty.ForwardInstance.Tags = EditRelationshipProperty.Tags;
				}
			}
			EditRelationshipProperty.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditRelationshipPropertyPerformed();
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
		public void SendEditRelationshipPropertyPerformed()
		{
			RelationshipPropertyEventArgs message = new RelationshipPropertyEventArgs();
			message.RelationshipProperty = RelationshipProperty;
			message.RelationshipID = RelationshipID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipPropertyEventArgs>(MediatorMessages.Command_EditRelationshipPropertyPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete RelationshipProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteRelationshipPropertyCommand()
		{
			RelationshipPropertyEventArgs message = new RelationshipPropertyEventArgs();
			message.RelationshipProperty = RelationshipProperty;
			message.RelationshipID = RelationshipID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<RelationshipPropertyEventArgs>(MediatorMessages.Command_DeleteRelationshipPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteRelationshipPropertyCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the RelationshipProperty.</summary>
		///--------------------------------------------------------------------------------
		public RelationshipProperty RelationshipProperty { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipPropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid RelationshipPropertyID
		{
			get
			{
				return RelationshipProperty.RelationshipPropertyID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return RelationshipProperty.Name;
			}
			set
			{
				RelationshipProperty.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return RelationshipProperty.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RelationshipID.</summary>
		///--------------------------------------------------------------------------------
		public Guid RelationshipID
		{
			get
			{
				return RelationshipProperty.RelationshipID;
			}
			set
			{
				RelationshipProperty.RelationshipID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of RelationshipProperty into the view model.</summary>
		/// 
		/// <param name="relationshipProperty">The RelationshipProperty to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadRelationshipProperty(RelationshipProperty relationshipProperty, bool loadChildren = true)
		{
			// attach the RelationshipProperty
			RelationshipProperty = relationshipProperty;
			ItemID = RelationshipProperty.RelationshipPropertyID;
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
			
			HasErrors = !RelationshipProperty.IsValid;
			HasCustomizations = RelationshipProperty.IsAutoUpdated == false || RelationshipProperty.IsEmptyMetadata(RelationshipProperty.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && RelationshipProperty.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				RelationshipProperty.IsAutoUpdated = true;
				RelationshipProperty.SpecSourceName = RelationshipProperty.ReverseInstance.SpecSourceName;
				RelationshipProperty.ResetModified(RelationshipProperty.ReverseInstance.IsModified);
				RelationshipProperty.ResetLoaded(RelationshipProperty.ReverseInstance.IsLoaded);
				if (!RelationshipProperty.IsIdenticalMetadata(RelationshipProperty.ReverseInstance))
				{
					HasCustomizations = true;
					RelationshipProperty.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				RelationshipProperty.ForwardInstance = null;
				RelationshipProperty.ReverseInstance = null;
				RelationshipProperty.IsAutoUpdated = true;
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
			if (_editRelationshipProperty != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditRelationshipProperty.PropertyChanged -= EditRelationshipProperty_PropertyChanged;
				EditRelationshipProperty = null;
			}
			RelationshipProperty = null;
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
		public RelationshipPropertyViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="relationshipProperty">The RelationshipProperty to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public RelationshipPropertyViewModel(RelationshipProperty relationshipProperty, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadRelationshipProperty(relationshipProperty, loadChildren);
		}

		#endregion "Constructors"
	}
}
