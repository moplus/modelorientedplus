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
	/// <summary>This class provides views for ModelProperty instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/19/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelPropertyViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewModelProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewModelProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlModelPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelModelPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewModelPropertyToolTip;
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
				if (EditModelProperty.IsModified == true)
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
				return string.IsNullOrEmpty(ModelPropertyNameValidationMessage + OrderValidationMessage + DefinedByModelObjectIDValidationMessage + DefinedByEnumerationIDValidationMessage + DefinedByValueIDValidationMessage + IsCollectionValidationMessage + IsDisplayPropertyValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private ModelProperty _editModelProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditModelProperty.</summary>
		///--------------------------------------------------------------------------------
		public ModelProperty EditModelProperty
		{
			get
			{
				if (_editModelProperty == null)
				{
					_editModelProperty = new ModelProperty();
					_editModelProperty.PropertyChanged += new PropertyChangedEventHandler(EditModelProperty_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (ModelProperty != null)
					{
						_editModelProperty.TransformDataFromObject(ModelProperty, null, false);
						_editModelProperty.Solution = ModelProperty.Solution;
						_editModelProperty.DefinedByEnumeration = ModelProperty.DefinedByEnumeration;
						_editModelProperty.DefinedByModelObject = ModelProperty.DefinedByModelObject;
						_editModelProperty.ModelObject = ModelProperty.ModelObject;
						_editModelProperty.DefinedByValue = ModelProperty.DefinedByValue;
					}
					_editModelProperty.ResetModified(false);
				
					#region protected
					RefreshValues();
					#endregion protected

				}
				return _editModelProperty;
			}
			set
			{
				_editModelProperty = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditModelProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditModelProperty");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ModelPropertyName");
			OnPropertyChanged("ModelPropertyNameCustomized");
			OnPropertyChanged("ModelPropertyNameValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("DefinedByModelObjectID");
			OnPropertyChanged("DefinedByModelObjectIDCustomized");
			OnPropertyChanged("DefinedByModelObjectIDValidationMessage");
			
			OnPropertyChanged("DefinedByEnumerationID");
			OnPropertyChanged("DefinedByEnumerationIDCustomized");
			OnPropertyChanged("DefinedByEnumerationIDValidationMessage");
			
			OnPropertyChanged("DefinedByValueID");
			OnPropertyChanged("DefinedByValueIDCustomized");
			OnPropertyChanged("DefinedByValueIDValidationMessage");
			
			OnPropertyChanged("IsCollection");
			OnPropertyChanged("IsCollectionCustomized");
			OnPropertyChanged("IsCollectionValidationMessage");
			
			OnPropertyChanged("IsDisplayProperty");
			OnPropertyChanged("IsDisplayPropertyCustomized");
			OnPropertyChanged("IsDisplayPropertyValidationMessage");
			
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
				return DisplayValues.Edit_ModelPropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyNameLabel
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelPropertyName.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyName
		{
			get
			{
				return EditModelProperty.ModelPropertyName;
			}
			set
			{
				EditModelProperty.ModelPropertyName = value;
				OnPropertyChanged("ModelPropertyName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ModelPropertyNameCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return ModelPropertyName.GetString() != ModelProperty.ReverseInstance.ModelPropertyName.GetString();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return ModelPropertyName.GetString() != ModelProperty.ModelPropertyName.GetString();
				}
				return ModelPropertyName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyNameValidationMessage
		{
			get
			{
				return EditModelProperty.ValidateModelPropertyName();
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
				return EditModelProperty.Order;
			}
			set
			{
				EditModelProperty.Order = value;
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
				if (ModelProperty.ReverseInstance != null)
				{
					return Order.GetInt() != ModelProperty.ReverseInstance.Order.GetInt();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return Order.GetInt() != ModelProperty.Order.GetInt();
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
				return EditModelProperty.ValidateOrder();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DefinedByModelObjectIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DefinedByModelObjectIDLabel
		{
			get
			{
				return DisplayValues.Edit_DefinedByModelObjectIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DefinedByModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? DefinedByModelObjectID
		{
			get
			{
				return EditModelProperty.DefinedByModelObjectID;
			}
			set
			{
				EditModelProperty.DefinedByModelObjectID = value;
				OnPropertyChanged("DefinedByModelObjectID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByModelObjectIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DefinedByModelObjectIDCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return DefinedByModelObjectID.GetGuid() != ModelProperty.ReverseInstance.DefinedByModelObjectID.GetGuid();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return DefinedByModelObjectID.GetGuid() != ModelProperty.DefinedByModelObjectID.GetGuid();
				}
				return DefinedByModelObjectID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByModelObjectIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DefinedByModelObjectIDValidationMessage
		{
			get
			{
				return EditModelProperty.ValidateDefinedByModelObjectID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DefinedByEnumerationIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DefinedByEnumerationIDLabel
		{
			get
			{
				return DisplayValues.Edit_DefinedByEnumerationIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DefinedByEnumerationID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? DefinedByEnumerationID
		{
			get
			{
				return EditModelProperty.DefinedByEnumerationID;
			}
			set
			{
				EditModelProperty.DefinedByEnumerationID = value;
				OnPropertyChanged("DefinedByEnumerationID");
				OnPropertyChanged("TabTitle");
			
				#region protected
				RefreshValues();
				#endregion protected

			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByEnumerationIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DefinedByEnumerationIDCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return DefinedByEnumerationID.GetGuid() != ModelProperty.ReverseInstance.DefinedByEnumerationID.GetGuid();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return DefinedByEnumerationID.GetGuid() != ModelProperty.DefinedByEnumerationID.GetGuid();
				}
				return DefinedByEnumerationID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByEnumerationIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DefinedByEnumerationIDValidationMessage
		{
			get
			{
				return EditModelProperty.ValidateDefinedByEnumerationID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DefinedByValueIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DefinedByValueIDLabel
		{
			get
			{
				return DisplayValues.Edit_DefinedByValueIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DefinedByValueID.</summary>
		///--------------------------------------------------------------------------------
		public Guid? DefinedByValueID
		{
			get
			{
				return EditModelProperty.DefinedByValueID;
			}
			set
			{
				EditModelProperty.DefinedByValueID = value;
				OnPropertyChanged("DefinedByValueID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByValueIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DefinedByValueIDCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return DefinedByValueID.GetGuid() != ModelProperty.ReverseInstance.DefinedByValueID.GetGuid();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return DefinedByValueID.GetGuid() != ModelProperty.DefinedByValueID.GetGuid();
				}
				return DefinedByValueID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByValueIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DefinedByValueIDValidationMessage
		{
			get
			{
				return EditModelProperty.ValidateDefinedByValueID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsCollectionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsCollectionLabel
		{
			get
			{
				return DisplayValues.Edit_IsCollectionProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsCollection.</summary>
		///--------------------------------------------------------------------------------
		public bool IsCollection
		{
			get
			{
				return EditModelProperty.IsCollection;
			}
			set
			{
				EditModelProperty.IsCollection = value;
				OnPropertyChanged("IsCollection");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsCollectionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsCollectionCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return IsCollection.GetBool() != ModelProperty.ReverseInstance.IsCollection.GetBool();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return IsCollection.GetBool() != ModelProperty.IsCollection.GetBool();
				}
				return IsCollection != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsCollectionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsCollectionValidationMessage
		{
			get
			{
				return EditModelProperty.ValidateIsCollection();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsDisplayPropertyLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsDisplayPropertyLabel
		{
			get
			{
				return DisplayValues.Edit_IsDisplayPropertyProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsDisplayProperty.</summary>
		///--------------------------------------------------------------------------------
		public bool IsDisplayProperty
		{
			get
			{
				return EditModelProperty.IsDisplayProperty;
			}
			set
			{
				EditModelProperty.IsDisplayProperty = value;
				OnPropertyChanged("IsDisplayProperty");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsDisplayPropertyCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsDisplayPropertyCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return IsDisplayProperty.GetBool() != ModelProperty.ReverseInstance.IsDisplayProperty.GetBool();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return IsDisplayProperty.GetBool() != ModelProperty.IsDisplayProperty.GetBool();
				}
				return IsDisplayProperty != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsDisplayPropertyValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsDisplayPropertyValidationMessage
		{
			get
			{
				return EditModelProperty.ValidateIsDisplayProperty();
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
				return EditModelProperty.Description;
			}
			set
			{
				EditModelProperty.Description = value;
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
				if (ModelProperty.ReverseInstance != null)
				{
					return Description.GetString() != ModelProperty.ReverseInstance.Description.GetString();
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return Description.GetString() != ModelProperty.Description.GetString();
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
				return EditModelProperty.ValidateDescription();
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
				return EditModelProperty.SourceName;
			}
			set
			{
				EditModelProperty.SourceName = value;
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
				return EditModelProperty.SpecSourceName;
			}
			set
			{
				EditModelProperty.SpecSourceName = value;
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
				return EditModelProperty.Tags;
			}
			set
			{
				EditModelProperty.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (ModelProperty.ReverseInstance != null)
				{
					return Tags != ModelProperty.ReverseInstance.Tags;
				}
				else if (ModelProperty.IsAutoUpdated == true)
				{
					return Tags != ModelProperty.Tags;
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
				return EditModelProperty.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditModelProperty.Name;
			}
			set
			{
				EditModelProperty.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditModelProperty.TransformDataFromObject(ModelProperty, null, false);
			ResetItems();
			
			#region protected
			RefreshValues();
			#endregion protected

			EditModelProperty.ResetModified(false);
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
			if (ModelProperty.ReverseInstance != null)
			{
				EditModelProperty.TransformDataFromObject(ModelProperty.ReverseInstance, null, false);
			}
			else if (ModelProperty.IsAutoUpdated == true)
			{
				EditModelProperty.TransformDataFromObject(ModelProperty, null, false);
			}
			else
			{
				ModelProperty newModelProperty = new ModelProperty();
				newModelProperty.ModelPropertyID = EditModelProperty.ModelPropertyID;
				EditModelProperty.TransformDataFromObject(newModelProperty, null, false);
			}
			EditModelProperty.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new ModelProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewModelPropertyCommand()
		{
			ModelPropertyEventArgs message = new ModelPropertyEventArgs();
			message.ModelProperty = new ModelProperty();
			message.ModelProperty.ModelPropertyID = Guid.NewGuid();
			message.ModelProperty.ModelObjectID = ModelObjectID;
			message.ModelProperty.ModelObject = Solution.ModelObjectList.FindByID((Guid)ModelObjectID);
			if (message.ModelProperty.ModelObject != null)
			{
				message.ModelProperty.Order = message.ModelProperty.ModelObject.ModelPropertyList.Count + 1;
			}
			message.ModelProperty.Solution = Solution;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelPropertyEventArgs>(MediatorMessages.Command_EditModelPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditModelPropertyCommand()
		{
			ModelPropertyEventArgs message = new ModelPropertyEventArgs();
			message.ModelProperty = ModelProperty;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelPropertyEventArgs>(MediatorMessages.Command_EditModelPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewModelPropertyCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (ModelProperty.ReverseInstance == null && ModelProperty.IsAutoUpdated == true)
			{
				ModelProperty.ReverseInstance = new ModelProperty();
				ModelProperty.ReverseInstance.TransformDataFromObject(ModelProperty, null, false);

				// perform the update of EditModelProperty back to ModelProperty
				ModelProperty.TransformDataFromObject(EditModelProperty, null, false);
				ModelProperty.IsAutoUpdated = false;
			}
			else if (ModelProperty.ReverseInstance != null)
			{
				EditModelProperty.ResetModified(ModelProperty.ReverseInstance.IsModified);
				if (EditModelProperty.Equals(ModelProperty.ReverseInstance))
				{
					// perform the update of EditModelProperty back to ModelProperty
					ModelProperty.TransformDataFromObject(EditModelProperty, null, false);
					ModelProperty.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditModelProperty back to ModelProperty
					ModelProperty.TransformDataFromObject(EditModelProperty, null, false);
					ModelProperty.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditModelProperty back to ModelProperty
				ModelProperty.TransformDataFromObject(EditModelProperty, null, false);
				ModelProperty.IsAutoUpdated = false;
			}
			ModelProperty.ForwardInstance = null;
			if (ModelPropertyNameCustomized || OrderCustomized || DefinedByModelObjectIDCustomized || DefinedByEnumerationIDCustomized || DefinedByValueIDCustomized || IsCollectionCustomized || IsDisplayPropertyCustomized || DescriptionCustomized || TagsCustomized)
			{
				ModelProperty.ForwardInstance = new ModelProperty();
				ModelProperty.ForwardInstance.ModelPropertyID = EditModelProperty.ModelPropertyID;
				ModelProperty.SpecSourceName = ModelProperty.DefaultSourceName;
				if (ModelPropertyNameCustomized)
				{
					ModelProperty.ForwardInstance.ModelPropertyName = EditModelProperty.ModelPropertyName;
				}
				if (OrderCustomized)
				{
					ModelProperty.ForwardInstance.Order = EditModelProperty.Order;
				}
				if (DefinedByModelObjectIDCustomized)
				{
					ModelProperty.ForwardInstance.DefinedByModelObjectID = EditModelProperty.DefinedByModelObjectID;
				}
				if (DefinedByEnumerationIDCustomized)
				{
					ModelProperty.ForwardInstance.DefinedByEnumerationID = EditModelProperty.DefinedByEnumerationID;
				}
				if (DefinedByValueIDCustomized)
				{
					ModelProperty.ForwardInstance.DefinedByValueID = EditModelProperty.DefinedByValueID;
				}
				if (IsCollectionCustomized)
				{
					ModelProperty.ForwardInstance.IsCollection = EditModelProperty.IsCollection;
				}
				if (IsDisplayPropertyCustomized)
				{
					ModelProperty.ForwardInstance.IsDisplayProperty = EditModelProperty.IsDisplayProperty;
				}
				if (DescriptionCustomized)
				{
					ModelProperty.ForwardInstance.Description = EditModelProperty.Description;
				}
				if (TagsCustomized)
				{
					ModelProperty.ForwardInstance.Tags = EditModelProperty.Tags;
				}
			}
			EditModelProperty.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditModelPropertyPerformed();
			
			#region protected
			Solution.CodeTemplateContentParser = null;
			Solution.CodeTemplatOutputParser = null;
			Solution.ModelObjectNames = null;
			Solution.ModelPropertyNames = null;

			// refresh solution
			ModelEventArgs message = new ModelEventArgs();
			message.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			message.ModelID = ModelProperty.ModelObject.ModelID;
			Mediator.NotifyColleagues<ModelEventArgs>(MediatorMessages.Command_ReloadModelDataRequested, message);
			#endregion protected
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
		public void SendEditModelPropertyPerformed()
		{
			ModelPropertyEventArgs message = new ModelPropertyEventArgs();
			message.ModelProperty = ModelProperty;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelPropertyEventArgs>(MediatorMessages.Command_EditModelPropertyPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete ModelProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteModelPropertyCommand()
		{
			ModelPropertyEventArgs message = new ModelPropertyEventArgs();
			message.ModelProperty = ModelProperty;
			message.ModelObjectID = ModelObjectID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ModelPropertyEventArgs>(MediatorMessages.Command_DeleteModelPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteModelPropertyCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelProperty.</summary>
		///--------------------------------------------------------------------------------
		public ModelProperty ModelProperty { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelPropertyID
		{
			get
			{
				return ModelProperty.ModelPropertyID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return ModelProperty.Name;
			}
			set
			{
				ModelProperty.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return ModelProperty.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObjectID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ModelObjectID
		{
			get
			{
				return ModelProperty.ModelObjectID;
			}
			set
			{
				ModelProperty.ModelObjectID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of ModelProperty into the view model.</summary>
		/// 
		/// <param name="modelProperty">The ModelProperty to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelProperty(ModelProperty modelProperty, bool loadChildren = true)
		{
			// attach the ModelProperty
			ModelProperty = modelProperty;
			ItemID = ModelProperty.ModelPropertyID;
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
			
			HasErrors = !ModelProperty.IsValid;
			HasCustomizations = ModelProperty.IsAutoUpdated == false || ModelProperty.IsEmptyMetadata(ModelProperty.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && ModelProperty.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				ModelProperty.IsAutoUpdated = true;
				ModelProperty.SpecSourceName = ModelProperty.ReverseInstance.SpecSourceName;
				ModelProperty.ResetModified(ModelProperty.ReverseInstance.IsModified);
				ModelProperty.ResetLoaded(ModelProperty.ReverseInstance.IsLoaded);
				if (!ModelProperty.IsIdenticalMetadata(ModelProperty.ReverseInstance))
				{
					HasCustomizations = true;
					ModelProperty.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				ModelProperty.ForwardInstance = null;
				ModelProperty.ReverseInstance = null;
				ModelProperty.IsAutoUpdated = true;
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
			if (_editModelProperty != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditModelProperty.PropertyChanged -= EditModelProperty_PropertyChanged;
				EditModelProperty = null;
			}
			ModelProperty = null;
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
		public ModelPropertyViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="modelProperty">The ModelProperty to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ModelPropertyViewModel(ModelProperty modelProperty, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadModelProperty(modelProperty, loadChildren);
		}

		#endregion "Constructors"
	}
}
