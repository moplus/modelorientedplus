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
	/// <summary>This class provides views for AuditProperty instances.</summary>
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
	public partial class AuditPropertyViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewAuditProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewAuditProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlAuditPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelAuditPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewAuditPropertyToolTip;
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
				if (EditAuditProperty.IsModified == true)
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
				return string.IsNullOrEmpty(PropertyNameValidationMessage + IsAddAuditPropertyValidationMessage + IsUpdateAuditPropertyValidationMessage + IsValueGeneratedValidationMessage + DataTypeCodeValidationMessage + PrecisionValidationMessage + ScaleValidationMessage + InitialValueValidationMessage + IsNullableValidationMessage + OrderValidationMessage + DescriptionValidationMessage + PropertyRelationshipListValidationMessage);
			}
		}
 
		private AuditProperty _editAuditProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public AuditProperty EditAuditProperty
		{
			get
			{
				if (_editAuditProperty == null)
				{
					_editAuditProperty = new AuditProperty();
					_editAuditProperty.PropertyChanged += new PropertyChangedEventHandler(EditAuditProperty_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (AuditProperty != null)
					{
						_editAuditProperty.TransformDataFromObject(AuditProperty, null, false);
						_editAuditProperty.Solution = AuditProperty.Solution;
						_editAuditProperty.DataType = AuditProperty.DataType;
					}
					_editAuditProperty.ResetModified(false);
				}
				return _editAuditProperty;
			}
			set
			{
				_editAuditProperty = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditAuditProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditAuditProperty");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("PropertyName");
			OnPropertyChanged("PropertyNameCustomized");
			OnPropertyChanged("PropertyNameValidationMessage");
			
			OnPropertyChanged("IsAddAuditProperty");
			OnPropertyChanged("IsAddAuditPropertyCustomized");
			OnPropertyChanged("IsAddAuditPropertyValidationMessage");
			
			OnPropertyChanged("IsUpdateAuditProperty");
			OnPropertyChanged("IsUpdateAuditPropertyCustomized");
			OnPropertyChanged("IsUpdateAuditPropertyValidationMessage");
			
			OnPropertyChanged("IsValueGenerated");
			OnPropertyChanged("IsValueGeneratedCustomized");
			OnPropertyChanged("IsValueGeneratedValidationMessage");
			
			OnPropertyChanged("DataTypeCode");
			OnPropertyChanged("DataTypeCodeCustomized");
			OnPropertyChanged("DataTypeCodeValidationMessage");
			
			OnPropertyChanged("Precision");
			OnPropertyChanged("PrecisionCustomized");
			OnPropertyChanged("PrecisionValidationMessage");
			
			OnPropertyChanged("Scale");
			OnPropertyChanged("ScaleCustomized");
			OnPropertyChanged("ScaleValidationMessage");
			
			OnPropertyChanged("InitialValue");
			OnPropertyChanged("InitialValueCustomized");
			OnPropertyChanged("InitialValueValidationMessage");
			
			OnPropertyChanged("IsNullable");
			OnPropertyChanged("IsNullableCustomized");
			OnPropertyChanged("IsNullableValidationMessage");
			
			OnPropertyChanged("Order");
			OnPropertyChanged("OrderCustomized");
			OnPropertyChanged("OrderValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("PropertyRelationshipList");
			OnPropertyChanged("PropertyRelationshipListCustomized");
			OnPropertyChanged("PropertyRelationshipListValidationMessage");

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
				return DisplayValues.Edit_AuditPropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_AuditPropertyHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyRelationshipListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyRelationshipListLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyRelationshipListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertyRelationshipList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyRelationship> PropertyRelationshipList
		{
			get
			{
				return EditAuditProperty.PropertyRelationshipList;
			}
			set
			{
				EditAuditProperty.PropertyRelationshipList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyRelationshipListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PropertyRelationshipListCustomized
		{
			get
			{
				#region protected
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyRelationshipListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyRelationshipListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyNameLabel
		{
			get
			{
				return DisplayValues.Edit_PropertyNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropertyName.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyName
		{
			get
			{
				return EditAuditProperty.PropertyName;
			}
			set
			{
				EditAuditProperty.PropertyName = value;
				OnPropertyChanged("PropertyName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PropertyNameCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return PropertyName.GetString() != AuditProperty.ReverseInstance.PropertyName.GetString();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return PropertyName.GetString() != AuditProperty.PropertyName.GetString();
				}
				return PropertyName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PropertyNameValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidatePropertyName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsAddAuditPropertyLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsAddAuditPropertyLabel
		{
			get
			{
				return DisplayValues.Edit_IsAddAuditPropertyProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsAddAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public bool IsAddAuditProperty
		{
			get
			{
				return EditAuditProperty.IsAddAuditProperty;
			}
			set
			{
				EditAuditProperty.IsAddAuditProperty = value;
				OnPropertyChanged("IsAddAuditProperty");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsAddAuditPropertyCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsAddAuditPropertyCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return IsAddAuditProperty.GetBool() != AuditProperty.ReverseInstance.IsAddAuditProperty.GetBool();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return IsAddAuditProperty.GetBool() != AuditProperty.IsAddAuditProperty.GetBool();
				}
				return IsAddAuditProperty != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsAddAuditPropertyValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsAddAuditPropertyValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateIsAddAuditProperty();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsUpdateAuditPropertyLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsUpdateAuditPropertyLabel
		{
			get
			{
				return DisplayValues.Edit_IsUpdateAuditPropertyProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsUpdateAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public bool IsUpdateAuditProperty
		{
			get
			{
				return EditAuditProperty.IsUpdateAuditProperty;
			}
			set
			{
				EditAuditProperty.IsUpdateAuditProperty = value;
				OnPropertyChanged("IsUpdateAuditProperty");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsUpdateAuditPropertyCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsUpdateAuditPropertyCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return IsUpdateAuditProperty.GetBool() != AuditProperty.ReverseInstance.IsUpdateAuditProperty.GetBool();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return IsUpdateAuditProperty.GetBool() != AuditProperty.IsUpdateAuditProperty.GetBool();
				}
				return IsUpdateAuditProperty != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsUpdateAuditPropertyValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsUpdateAuditPropertyValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateIsUpdateAuditProperty();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsValueGeneratedLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsValueGeneratedLabel
		{
			get
			{
				return DisplayValues.Edit_IsValueGeneratedProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsValueGenerated.</summary>
		///--------------------------------------------------------------------------------
		public bool IsValueGenerated
		{
			get
			{
				return EditAuditProperty.IsValueGenerated;
			}
			set
			{
				EditAuditProperty.IsValueGenerated = value;
				OnPropertyChanged("IsValueGenerated");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsValueGeneratedCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsValueGeneratedCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return IsValueGenerated.GetBool() != AuditProperty.ReverseInstance.IsValueGenerated.GetBool();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return IsValueGenerated.GetBool() != AuditProperty.IsValueGenerated.GetBool();
				}
				return IsValueGenerated != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsValueGeneratedValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsValueGeneratedValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateIsValueGenerated();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DataTypeCodeLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DataTypeCodeLabel
		{
			get
			{
				return DisplayValues.Edit_DataTypeCodeSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DataTypeCode.</summary>
		///--------------------------------------------------------------------------------
		public int DataTypeCode
		{
			get
			{
				return EditAuditProperty.DataTypeCode;
			}
			set
			{
				EditAuditProperty.DataTypeCode = value;
				OnPropertyChanged("DataTypeCode");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DataTypeCodeCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DataTypeCodeCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return DataTypeCode.GetInt() != AuditProperty.ReverseInstance.DataTypeCode.GetInt();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return DataTypeCode.GetInt() != AuditProperty.DataTypeCode.GetInt();
				}
				return DataTypeCode != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DataTypeCodeValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DataTypeCodeValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateDataTypeCode();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PrecisionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PrecisionLabel
		{
			get
			{
				return DisplayValues.Edit_PrecisionProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Precision.</summary>
		///--------------------------------------------------------------------------------
		public int? Precision
		{
			get
			{
				return EditAuditProperty.Precision;
			}
			set
			{
				EditAuditProperty.Precision = value;
				OnPropertyChanged("Precision");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PrecisionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PrecisionCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return Precision.GetInt() != AuditProperty.ReverseInstance.Precision.GetInt();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return Precision.GetInt() != AuditProperty.Precision.GetInt();
				}
				return Precision != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PrecisionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PrecisionValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidatePrecision();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ScaleLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ScaleLabel
		{
			get
			{
				return DisplayValues.Edit_ScaleProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Scale.</summary>
		///--------------------------------------------------------------------------------
		public int? Scale
		{
			get
			{
				return EditAuditProperty.Scale;
			}
			set
			{
				EditAuditProperty.Scale = value;
				OnPropertyChanged("Scale");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ScaleCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ScaleCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return Scale.GetInt() != AuditProperty.ReverseInstance.Scale.GetInt();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return Scale.GetInt() != AuditProperty.Scale.GetInt();
				}
				return Scale != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ScaleValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ScaleValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateScale();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the InitialValueLabel.</summary>
		///--------------------------------------------------------------------------------
		public string InitialValueLabel
		{
			get
			{
				return DisplayValues.Edit_InitialValueProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets InitialValue.</summary>
		///--------------------------------------------------------------------------------
		public string InitialValue
		{
			get
			{
				return EditAuditProperty.InitialValue;
			}
			set
			{
				EditAuditProperty.InitialValue = value;
				OnPropertyChanged("InitialValue");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets InitialValueCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool InitialValueCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return InitialValue.GetString() != AuditProperty.ReverseInstance.InitialValue.GetString();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return InitialValue.GetString() != AuditProperty.InitialValue.GetString();
				}
				return InitialValue != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets InitialValueValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string InitialValueValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateInitialValue();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsNullableLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsNullableLabel
		{
			get
			{
				return DisplayValues.Edit_IsNullableProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsNullable.</summary>
		///--------------------------------------------------------------------------------
		public bool IsNullable
		{
			get
			{
				return EditAuditProperty.IsNullable;
			}
			set
			{
				EditAuditProperty.IsNullable = value;
				OnPropertyChanged("IsNullable");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsNullableCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsNullableCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return IsNullable.GetBool() != AuditProperty.ReverseInstance.IsNullable.GetBool();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return IsNullable.GetBool() != AuditProperty.IsNullable.GetBool();
				}
				return IsNullable != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsNullableValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsNullableValidationMessage
		{
			get
			{
				return EditAuditProperty.ValidateIsNullable();
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
				return EditAuditProperty.Order;
			}
			set
			{
				EditAuditProperty.Order = value;
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
				if (AuditProperty.ReverseInstance != null)
				{
					return Order.GetInt() != AuditProperty.ReverseInstance.Order.GetInt();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return Order.GetInt() != AuditProperty.Order.GetInt();
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
				return EditAuditProperty.ValidateOrder();
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
				return EditAuditProperty.Description;
			}
			set
			{
				EditAuditProperty.Description = value;
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
				if (AuditProperty.ReverseInstance != null)
				{
					return Description.GetString() != AuditProperty.ReverseInstance.Description.GetString();
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return Description.GetString() != AuditProperty.Description.GetString();
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
				return EditAuditProperty.ValidateDescription();
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
				return EditAuditProperty.SourceName;
			}
			set
			{
				EditAuditProperty.SourceName = value;
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
				return EditAuditProperty.SpecSourceName;
			}
			set
			{
				EditAuditProperty.SpecSourceName = value;
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
				return EditAuditProperty.Tags;
			}
			set
			{
				EditAuditProperty.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (AuditProperty.ReverseInstance != null)
				{
					return Tags != AuditProperty.ReverseInstance.Tags;
				}
				else if (AuditProperty.IsAutoUpdated == true)
				{
					return Tags != AuditProperty.Tags;
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
				return EditAuditProperty.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditAuditProperty.Name;
			}
			set
			{
				EditAuditProperty.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditAuditProperty.TransformDataFromObject(AuditProperty, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditAuditProperty.ResetModified(false);
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
			if (AuditProperty.ReverseInstance != null)
			{
				EditAuditProperty.TransformDataFromObject(AuditProperty.ReverseInstance, null, false);
			}
			else if (AuditProperty.IsAutoUpdated == true)
			{
				EditAuditProperty.TransformDataFromObject(AuditProperty, null, false);
			}
			else
			{
				AuditProperty newAuditProperty = new AuditProperty();
				newAuditProperty.PropertyID = EditAuditProperty.PropertyID;
				EditAuditProperty.TransformDataFromObject(newAuditProperty, null, false);
			}
			EditAuditProperty.ResetModified(true);
			foreach (PropertyRelationshipViewModel item in Items.OfType<PropertyRelationshipViewModel>())
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
		/// <summary>This method processes the new AuditProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewAuditPropertyCommand()
		{
			AuditPropertyEventArgs message = new AuditPropertyEventArgs();
			message.AuditProperty = new AuditProperty();
			message.AuditProperty.PropertyID = Guid.NewGuid();
			message.AuditProperty.SolutionID = SolutionID;
			message.AuditProperty.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<AuditPropertyEventArgs>(MediatorMessages.Command_EditAuditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditAuditPropertyCommand()
		{
			AuditPropertyEventArgs message = new AuditPropertyEventArgs();
			message.AuditProperty = AuditProperty;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<AuditPropertyEventArgs>(MediatorMessages.Command_EditAuditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyRelationship adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewPropertyRelationship()
		{
			PropertyRelationshipViewModel item = new PropertyRelationshipViewModel();
			item.PropertyRelationship = new PropertyRelationship();
			item.PropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
			item.PropertyRelationship.PropertyBase = EditAuditProperty;
			item.PropertyRelationship.PropertyID = EditAuditProperty.PropertyID;
			item.PropertyRelationship.Solution = Solution;
			item.PropertyRelationship.Order = AuditProperty.PropertyRelationshipList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new PropertyRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyRelationshipCommand()
		{
			PropertyRelationshipEventArgs message = new PropertyRelationshipEventArgs();
			message.PropertyRelationship = new PropertyRelationship();
			message.PropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
			message.PropertyRelationship.PropertyBase = AuditProperty;
			message.PropertyRelationship.PropertyID = AuditProperty.PropertyID;
			message.PropertyID = AuditProperty.PropertyID;
			if (message.PropertyRelationship.PropertyBase != null)
			{
				message.PropertyRelationship.Order = message.PropertyRelationship.PropertyBase.PropertyRelationshipList.Count + 1;
			}
			message.PropertyRelationship.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyRelationshipEventArgs>(MediatorMessages.Command_EditPropertyRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyRelationship updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyRelationshipPerformed(PropertyRelationshipEventArgs data)
		{
			if (data != null && data.PropertyRelationship != null)
			{
				UpdateEditPropertyRelationship(data.PropertyRelationship);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of PropertyRelationship.</summary>
		/// 
		/// <param name="propertyRelationship">The PropertyRelationship to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditPropertyRelationship(PropertyRelationship propertyRelationship)
		{
			bool isItemMatch = false;
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
			{
				if (item.PropertyRelationship.PropertyRelationshipID == propertyRelationship.PropertyRelationshipID)
				{
					isItemMatch = true;
					item.PropertyRelationship.TransformDataFromObject(propertyRelationship, null, false);
					if (!item.PropertyRelationship.RelationshipID.IsNullOrEmpty())
					{
						item.PropertyRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)item.PropertyRelationship.RelationshipID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new PropertyRelationship
				propertyRelationship.PropertyBase = AuditProperty;
				PropertyRelationshipViewModel newItem = new PropertyRelationshipViewModel(propertyRelationship, Solution);
				if (!newItem.PropertyRelationship.RelationshipID.IsNullOrEmpty())
				{
					newItem.PropertyRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)newItem.PropertyRelationship.RelationshipID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				PropertyRelationships.Add(newItem);
				AuditProperty.PropertyRelationshipList.Add(propertyRelationship);
				Solution.PropertyRelationshipList.Add(newItem.PropertyRelationship);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyRelationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedPropertyRelationships(PropertyRelationshipViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies PropertyRelationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyRelationshipPerformed(PropertyRelationshipEventArgs data)
		{
			if (data != null && data.PropertyRelationship != null)
			{
				DeletePropertyRelationship(data.PropertyRelationship);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of PropertyRelationship.</summary>
		/// 
		/// <param name="propertyRelationship">The PropertyRelationship to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeletePropertyRelationship(PropertyRelationship propertyRelationship)
		{
			bool isItemMatch = false;
			foreach (PropertyRelationshipViewModel item in PropertyRelationships.ToList<PropertyRelationshipViewModel>())
			{
				if (item.PropertyRelationship.PropertyRelationshipID == propertyRelationship.PropertyRelationshipID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.PropertyRelationship.PropertyRelationshipID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete PropertyRelationship
					isItemMatch = true;
					PropertyRelationships.Remove(item);
					AuditProperty.PropertyRelationshipList.Remove(item.PropertyRelationship);
					Solution.PropertyRelationshipList.Remove(item.PropertyRelationship);
					Items.Remove(item);
					AuditProperty.ResetModified(true);
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
			ProcessNewAuditPropertyCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (AuditProperty.ReverseInstance == null && AuditProperty.IsAutoUpdated == true)
			{
				AuditProperty.ReverseInstance = new AuditProperty();
				AuditProperty.ReverseInstance.TransformDataFromObject(AuditProperty, null, false);

				// perform the update of EditAuditProperty back to AuditProperty
				AuditProperty.TransformDataFromObject(EditAuditProperty, null, false);
				AuditProperty.IsAutoUpdated = false;
			}
			else if (AuditProperty.ReverseInstance != null)
			{
				EditAuditProperty.ResetModified(AuditProperty.ReverseInstance.IsModified);
				if (EditAuditProperty.Equals(AuditProperty.ReverseInstance))
				{
					// perform the update of EditAuditProperty back to AuditProperty
					AuditProperty.TransformDataFromObject(EditAuditProperty, null, false);
					AuditProperty.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditAuditProperty back to AuditProperty
					AuditProperty.TransformDataFromObject(EditAuditProperty, null, false);
					AuditProperty.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditAuditProperty back to AuditProperty
				AuditProperty.TransformDataFromObject(EditAuditProperty, null, false);
				AuditProperty.IsAutoUpdated = false;
			}
			AuditProperty.ForwardInstance = null;
			if (PropertyNameCustomized || IsAddAuditPropertyCustomized || IsUpdateAuditPropertyCustomized || IsValueGeneratedCustomized || DataTypeCodeCustomized || PrecisionCustomized || ScaleCustomized || InitialValueCustomized || IsNullableCustomized || OrderCustomized || DescriptionCustomized || PropertyRelationshipListCustomized || TagsCustomized)
			{
				AuditProperty.ForwardInstance = new AuditProperty();
				AuditProperty.ForwardInstance.PropertyID = EditAuditProperty.PropertyID;
				AuditProperty.SpecSourceName = AuditProperty.DefaultSourceName;
				if (PropertyNameCustomized)
				{
					AuditProperty.ForwardInstance.PropertyName = EditAuditProperty.PropertyName;
				}
				if (IsAddAuditPropertyCustomized)
				{
					AuditProperty.ForwardInstance.IsAddAuditProperty = EditAuditProperty.IsAddAuditProperty;
				}
				if (IsUpdateAuditPropertyCustomized)
				{
					AuditProperty.ForwardInstance.IsUpdateAuditProperty = EditAuditProperty.IsUpdateAuditProperty;
				}
				if (IsValueGeneratedCustomized)
				{
					AuditProperty.ForwardInstance.IsValueGenerated = EditAuditProperty.IsValueGenerated;
				}
				if (DataTypeCodeCustomized)
				{
					AuditProperty.ForwardInstance.DataTypeCode = EditAuditProperty.DataTypeCode;
				}
				if (PrecisionCustomized)
				{
					AuditProperty.ForwardInstance.Precision = EditAuditProperty.Precision;
				}
				if (ScaleCustomized)
				{
					AuditProperty.ForwardInstance.Scale = EditAuditProperty.Scale;
				}
				if (InitialValueCustomized)
				{
					AuditProperty.ForwardInstance.InitialValue = EditAuditProperty.InitialValue;
				}
				if (IsNullableCustomized)
				{
					AuditProperty.ForwardInstance.IsNullable = EditAuditProperty.IsNullable;
				}
				if (OrderCustomized)
				{
					AuditProperty.ForwardInstance.Order = EditAuditProperty.Order;
				}
				if (DescriptionCustomized)
				{
					AuditProperty.ForwardInstance.Description = EditAuditProperty.Description;
				}
				if (PropertyRelationshipListCustomized)
				{
					#region protected
					#endregion protected
					// AuditProperty.PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>(EditAuditProperty.PropertyRelationshipList, null);
					// AuditProperty.ForwardInstance.PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>(EditAuditProperty.PropertyRelationshipList, null);
				}
				if (TagsCustomized)
				{
					AuditProperty.ForwardInstance.Tags = EditAuditProperty.Tags;
				}
			}
			EditAuditProperty.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditAuditPropertyPerformed();

			// send update for any updated PropertyRelationships
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new PropertyRelationships
			foreach (PropertyRelationshipViewModel item in ItemsToAdd.OfType<PropertyRelationshipViewModel>())
			{
				item.Update();
				PropertyRelationships.Add(item);
			}

			// send delete for any deleted PropertyRelationships
			foreach (PropertyRelationshipViewModel item in ItemsToDelete.OfType<PropertyRelationshipViewModel>())
			{
				item.Delete();
				PropertyRelationships.Remove(item);
			}

			// reset modified for PropertyRelationships
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
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
		public void SendEditAuditPropertyPerformed()
		{
			AuditPropertyEventArgs message = new AuditPropertyEventArgs();
			message.AuditProperty = AuditProperty;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<AuditPropertyEventArgs>(MediatorMessages.Command_EditAuditPropertyPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete AuditProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteAuditPropertyCommand()
		{
			AuditPropertyEventArgs message = new AuditPropertyEventArgs();
			message.AuditProperty = AuditProperty;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<AuditPropertyEventArgs>(MediatorMessages.Command_DeleteAuditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteAuditPropertyCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyRelationshipViewModel> PropertyRelationships { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AuditProperty.</summary>
		///--------------------------------------------------------------------------------
		public AuditProperty AuditProperty { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyID
		{
			get
			{
				return AuditProperty.PropertyID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return AuditProperty.Name;
			}
			set
			{
				AuditProperty.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return AuditProperty.Order;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of AuditProperty into the view model.</summary>
		/// 
		/// <param name="auditProperty">The AuditProperty to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadAuditProperty(AuditProperty auditProperty, bool loadChildren = true)
		{
			// attach the AuditProperty
			AuditProperty = auditProperty;
			ItemID = AuditProperty.PropertyID;
			Items.Clear();
			
			// initialize PropertyRelationships
			if (PropertyRelationships == null)
			{
				PropertyRelationships = new EnterpriseDataObjectList<PropertyRelationshipViewModel>();
			}
			if (loadChildren == true)
			{
				// attach PropertyRelationships
				foreach (PropertyRelationship item in auditProperty.PropertyRelationshipList)
				{
					PropertyRelationshipViewModel itemView = new PropertyRelationshipViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					PropertyRelationships.Add(itemView);
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
				foreach (PropertyRelationshipViewModel item in PropertyRelationships)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !AuditProperty.IsValid;
			HasCustomizations = AuditProperty.IsAutoUpdated == false || AuditProperty.IsEmptyMetadata(AuditProperty.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && AuditProperty.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				AuditProperty.IsAutoUpdated = true;
				AuditProperty.SpecSourceName = AuditProperty.ReverseInstance.SpecSourceName;
				AuditProperty.ResetModified(AuditProperty.ReverseInstance.IsModified);
				AuditProperty.ResetLoaded(AuditProperty.ReverseInstance.IsLoaded);
				if (!AuditProperty.IsIdenticalMetadata(AuditProperty.ReverseInstance))
				{
					HasCustomizations = true;
					AuditProperty.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				AuditProperty.ForwardInstance = null;
				AuditProperty.ReverseInstance = null;
				AuditProperty.IsAutoUpdated = true;
			}
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
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
			if (PropertyRelationships != null)
			{
				for (int i = PropertyRelationships.Count - 1; i >= 0; i--)
				{
					PropertyRelationships[i].Updated -= Children_Updated;
					PropertyRelationships[i].Dispose();
					PropertyRelationships.Remove(PropertyRelationships[i]);
				}
				PropertyRelationships = null;
			}
			if (_editAuditProperty != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditAuditProperty.PropertyChanged -= EditAuditProperty_PropertyChanged;
				EditAuditProperty = null;
			}
			AuditProperty = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (PropertyRelationshipViewModel item in PropertyRelationships)
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
			OnPropertyChanged("PropertyRelationshipList");
			OnPropertyChanged("PropertyRelationshipListCustomized");
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
			if (data is PropertyRelationshipEventArgs && (data as PropertyRelationshipEventArgs).PropertyID == AuditProperty.PropertyID)
			{
				return this;
			}
			foreach (PropertyRelationshipViewModel model in PropertyRelationships)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public AuditPropertyViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="auditProperty">The AuditProperty to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public AuditPropertyViewModel(AuditProperty auditProperty, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadAuditProperty(auditProperty, loadChildren);
		}

		#endregion "Constructors"
	}
}
