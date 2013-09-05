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
	/// <summary>This class provides views for Property instances.</summary>
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
	public partial class PropertyViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyToolTip;
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
				if (EditProperty.IsModified == true)
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
				return string.IsNullOrEmpty(PropertyNameValidationMessage + IsPrimaryKeyMemberValidationMessage + IsForeignKeyMemberValidationMessage + DataTypeCodeValidationMessage + LengthValidationMessage + PrecisionValidationMessage + ScaleValidationMessage + InitialValueValidationMessage + IdentityValidationMessage + IdentitySeedValidationMessage + IdentityIncrementValidationMessage + IsNullableValidationMessage + OrderValidationMessage + DescriptionValidationMessage + PropertyRelationshipListValidationMessage);
			}
		}
 
		private Property _editProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditProperty.</summary>
		///--------------------------------------------------------------------------------
		public Property EditProperty
		{
			get
			{
				if (_editProperty == null)
				{
					_editProperty = new Property();
					_editProperty.PropertyChanged += new PropertyChangedEventHandler(EditProperty_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Property != null)
					{
						_editProperty.TransformDataFromObject(Property, null, false);
						_editProperty.Solution = Property.Solution;
						_editProperty.DataType = Property.DataType;
						_editProperty.Entity = Property.Entity;
					}
					_editProperty.ResetModified(false);
				}
				return _editProperty;
			}
			set
			{
				_editProperty = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditProperty");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("PropertyName");
			OnPropertyChanged("PropertyNameCustomized");
			OnPropertyChanged("PropertyNameValidationMessage");
			
			OnPropertyChanged("IsPrimaryKeyMember");
			OnPropertyChanged("IsPrimaryKeyMemberCustomized");
			OnPropertyChanged("IsPrimaryKeyMemberValidationMessage");
			
			OnPropertyChanged("IsForeignKeyMember");
			OnPropertyChanged("IsForeignKeyMemberCustomized");
			OnPropertyChanged("IsForeignKeyMemberValidationMessage");
			
			OnPropertyChanged("DataTypeCode");
			OnPropertyChanged("DataTypeCodeCustomized");
			OnPropertyChanged("DataTypeCodeValidationMessage");
			
			OnPropertyChanged("Length");
			OnPropertyChanged("LengthCustomized");
			OnPropertyChanged("LengthValidationMessage");
			
			OnPropertyChanged("Precision");
			OnPropertyChanged("PrecisionCustomized");
			OnPropertyChanged("PrecisionValidationMessage");
			
			OnPropertyChanged("Scale");
			OnPropertyChanged("ScaleCustomized");
			OnPropertyChanged("ScaleValidationMessage");
			
			OnPropertyChanged("InitialValue");
			OnPropertyChanged("InitialValueCustomized");
			OnPropertyChanged("InitialValueValidationMessage");
			
			OnPropertyChanged("Identity");
			OnPropertyChanged("IdentityCustomized");
			OnPropertyChanged("IdentityValidationMessage");
			
			OnPropertyChanged("IdentitySeed");
			OnPropertyChanged("IdentitySeedCustomized");
			OnPropertyChanged("IdentitySeedValidationMessage");
			
			OnPropertyChanged("IdentityIncrement");
			OnPropertyChanged("IdentityIncrementCustomized");
			OnPropertyChanged("IdentityIncrementValidationMessage");
			
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
				return DisplayValues.Edit_PropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_PropertyHeader + " (" + EditName + ")";
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
				return EditProperty.PropertyRelationshipList;
			}
			set
			{
				EditProperty.PropertyRelationshipList = value;
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
				return EditProperty.PropertyName;
			}
			set
			{
				EditProperty.PropertyName = value;
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
				if (Property.ReverseInstance != null)
				{
					return PropertyName.GetString() != Property.ReverseInstance.PropertyName.GetString();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return PropertyName.GetString() != Property.PropertyName.GetString();
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
				return EditProperty.ValidatePropertyName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsPrimaryKeyMemberLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsPrimaryKeyMemberLabel
		{
			get
			{
				return DisplayValues.Edit_IsPrimaryKeyMemberProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsPrimaryKeyMember.</summary>
		///--------------------------------------------------------------------------------
		public bool IsPrimaryKeyMember
		{
			get
			{
				return EditProperty.IsPrimaryKeyMember;
			}
			set
			{
				EditProperty.IsPrimaryKeyMember = value;
				OnPropertyChanged("IsPrimaryKeyMember");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsPrimaryKeyMemberCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsPrimaryKeyMemberCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return IsPrimaryKeyMember.GetBool() != Property.ReverseInstance.IsPrimaryKeyMember.GetBool();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return IsPrimaryKeyMember.GetBool() != Property.IsPrimaryKeyMember.GetBool();
				}
				return IsPrimaryKeyMember != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsPrimaryKeyMemberValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsPrimaryKeyMemberValidationMessage
		{
			get
			{
				return EditProperty.ValidateIsPrimaryKeyMember();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsForeignKeyMemberLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsForeignKeyMemberLabel
		{
			get
			{
				return DisplayValues.Edit_IsForeignKeyMemberProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsForeignKeyMember.</summary>
		///--------------------------------------------------------------------------------
		public bool IsForeignKeyMember
		{
			get
			{
				return EditProperty.IsForeignKeyMember;
			}
			set
			{
				EditProperty.IsForeignKeyMember = value;
				OnPropertyChanged("IsForeignKeyMember");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsForeignKeyMemberCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsForeignKeyMemberCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return IsForeignKeyMember.GetBool() != Property.ReverseInstance.IsForeignKeyMember.GetBool();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return IsForeignKeyMember.GetBool() != Property.IsForeignKeyMember.GetBool();
				}
				return IsForeignKeyMember != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsForeignKeyMemberValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsForeignKeyMemberValidationMessage
		{
			get
			{
				return EditProperty.ValidateIsForeignKeyMember();
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
				return EditProperty.DataTypeCode;
			}
			set
			{
				EditProperty.DataTypeCode = value;
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
				if (Property.ReverseInstance != null)
				{
					return DataTypeCode.GetInt() != Property.ReverseInstance.DataTypeCode.GetInt();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return DataTypeCode.GetInt() != Property.DataTypeCode.GetInt();
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
				return EditProperty.ValidateDataTypeCode();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the LengthLabel.</summary>
		///--------------------------------------------------------------------------------
		public string LengthLabel
		{
			get
			{
				return DisplayValues.Edit_LengthProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Length.</summary>
		///--------------------------------------------------------------------------------
		public int? Length
		{
			get
			{
				return EditProperty.Length;
			}
			set
			{
				EditProperty.Length = value;
				OnPropertyChanged("Length");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets LengthCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool LengthCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return Length.GetInt() != Property.ReverseInstance.Length.GetInt();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Length.GetInt() != Property.Length.GetInt();
				}
				return Length != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets LengthValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string LengthValidationMessage
		{
			get
			{
				return EditProperty.ValidateLength();
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
				return EditProperty.Precision;
			}
			set
			{
				EditProperty.Precision = value;
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
				if (Property.ReverseInstance != null)
				{
					return Precision.GetInt() != Property.ReverseInstance.Precision.GetInt();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Precision.GetInt() != Property.Precision.GetInt();
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
				return EditProperty.ValidatePrecision();
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
				return EditProperty.Scale;
			}
			set
			{
				EditProperty.Scale = value;
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
				if (Property.ReverseInstance != null)
				{
					return Scale.GetInt() != Property.ReverseInstance.Scale.GetInt();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Scale.GetInt() != Property.Scale.GetInt();
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
				return EditProperty.ValidateScale();
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
				return EditProperty.InitialValue;
			}
			set
			{
				EditProperty.InitialValue = value;
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
				if (Property.ReverseInstance != null)
				{
					return InitialValue.GetString() != Property.ReverseInstance.InitialValue.GetString();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return InitialValue.GetString() != Property.InitialValue.GetString();
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
				return EditProperty.ValidateInitialValue();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IdentityLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IdentityLabel
		{
			get
			{
				return DisplayValues.Edit_IdentityProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Identity.</summary>
		///--------------------------------------------------------------------------------
		public bool? Identity
		{
			get
			{
				return EditProperty.Identity;
			}
			set
			{
				EditProperty.Identity = value;
				OnPropertyChanged("Identity");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentityCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IdentityCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return Identity.GetBool() != Property.ReverseInstance.Identity.GetBool();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Identity.GetBool() != Property.Identity.GetBool();
				}
				return Identity != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentityValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IdentityValidationMessage
		{
			get
			{
				return EditProperty.ValidateIdentity();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IdentitySeedLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IdentitySeedLabel
		{
			get
			{
				return DisplayValues.Edit_IdentitySeedProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IdentitySeed.</summary>
		///--------------------------------------------------------------------------------
		public long? IdentitySeed
		{
			get
			{
				return EditProperty.IdentitySeed;
			}
			set
			{
				EditProperty.IdentitySeed = value;
				OnPropertyChanged("IdentitySeed");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentitySeedCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IdentitySeedCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return IdentitySeed.GetLong() != Property.ReverseInstance.IdentitySeed.GetLong();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return IdentitySeed.GetLong() != Property.IdentitySeed.GetLong();
				}
				return IdentitySeed != DefaultValue.Long;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentitySeedValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IdentitySeedValidationMessage
		{
			get
			{
				return EditProperty.ValidateIdentitySeed();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IdentityIncrementLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IdentityIncrementLabel
		{
			get
			{
				return DisplayValues.Edit_IdentityIncrementProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IdentityIncrement.</summary>
		///--------------------------------------------------------------------------------
		public long? IdentityIncrement
		{
			get
			{
				return EditProperty.IdentityIncrement;
			}
			set
			{
				EditProperty.IdentityIncrement = value;
				OnPropertyChanged("IdentityIncrement");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentityIncrementCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IdentityIncrementCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return IdentityIncrement.GetLong() != Property.ReverseInstance.IdentityIncrement.GetLong();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return IdentityIncrement.GetLong() != Property.IdentityIncrement.GetLong();
				}
				return IdentityIncrement != DefaultValue.Long;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IdentityIncrementValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IdentityIncrementValidationMessage
		{
			get
			{
				return EditProperty.ValidateIdentityIncrement();
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
				return EditProperty.IsNullable;
			}
			set
			{
				EditProperty.IsNullable = value;
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
				if (Property.ReverseInstance != null)
				{
					return IsNullable.GetBool() != Property.ReverseInstance.IsNullable.GetBool();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return IsNullable.GetBool() != Property.IsNullable.GetBool();
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
				return EditProperty.ValidateIsNullable();
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
				return EditProperty.Order;
			}
			set
			{
				EditProperty.Order = value;
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
				if (Property.ReverseInstance != null)
				{
					return Order.GetInt() != Property.ReverseInstance.Order.GetInt();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Order.GetInt() != Property.Order.GetInt();
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
				return EditProperty.ValidateOrder();
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
				return EditProperty.Description;
			}
			set
			{
				EditProperty.Description = value;
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
				if (Property.ReverseInstance != null)
				{
					return Description.GetString() != Property.ReverseInstance.Description.GetString();
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Description.GetString() != Property.Description.GetString();
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
				return EditProperty.ValidateDescription();
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
				return EditProperty.SourceName;
			}
			set
			{
				EditProperty.SourceName = value;
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
				return EditProperty.SpecSourceName;
			}
			set
			{
				EditProperty.SpecSourceName = value;
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
				return EditProperty.Tags;
			}
			set
			{
				EditProperty.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Property.ReverseInstance != null)
				{
					return Tags != Property.ReverseInstance.Tags;
				}
				else if (Property.IsAutoUpdated == true)
				{
					return Tags != Property.Tags;
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
				return EditProperty.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditProperty.Name;
			}
			set
			{
				EditProperty.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditProperty.TransformDataFromObject(Property, null, false);
			EditProperty.ResetModified(false);
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
			if (Property.ReverseInstance != null)
			{
				EditProperty.TransformDataFromObject(Property.ReverseInstance, null, false);
			}
			else if (Property.IsAutoUpdated == true)
			{
				EditProperty.TransformDataFromObject(Property, null, false);
			}
			else
			{
				Property newProperty = new Property();
				newProperty.PropertyID = EditProperty.PropertyID;
				EditProperty.TransformDataFromObject(newProperty, null, false);
			}
			EditProperty.ResetModified(true);
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
		/// <summary>This method processes the new Property command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewPropertyCommand()
		{
			PropertyEventArgs message = new PropertyEventArgs();
			message.Property = new Property();
			message.Property.PropertyID = Guid.NewGuid();
			message.Property.EntityID = EntityID;
			message.Property.Entity = Solution.EntityList.FindByID((Guid)EntityID);
			if (message.Property.Entity != null)
			{
				message.Property.Order = message.Property.Entity.PropertyList.Count + 1;
			}
			message.Property.Solution = Solution;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyEventArgs>(MediatorMessages.Command_EditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditPropertyCommand()
		{
			PropertyEventArgs message = new PropertyEventArgs();
			message.Property = Property;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyEventArgs>(MediatorMessages.Command_EditPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyRelationship adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewPropertyRelationship()
		{
			PropertyRelationshipViewModel item = new PropertyRelationshipViewModel();
			item.PropertyRelationship = new PropertyRelationship();
			item.PropertyRelationship.PropertyRelationshipID = Guid.NewGuid();
			item.PropertyRelationship.PropertyBase = EditProperty;
			item.PropertyRelationship.PropertyID = EditProperty.PropertyID;
			item.PropertyRelationship.Solution = Solution;
			item.PropertyRelationship.Order = Property.PropertyRelationshipList.Count + 1;
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
			message.PropertyRelationship.PropertyBase = Property;
			message.PropertyRelationship.PropertyID = Property.PropertyID;
			message.PropertyID = Property.PropertyID;
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
				propertyRelationship.PropertyBase = Property;
				PropertyRelationshipViewModel newItem = new PropertyRelationshipViewModel(propertyRelationship, Solution);
				if (!newItem.PropertyRelationship.RelationshipID.IsNullOrEmpty())
				{
					newItem.PropertyRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)newItem.PropertyRelationship.RelationshipID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				PropertyRelationships.Add(newItem);
				Property.PropertyRelationshipList.Add(propertyRelationship);
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
					Property.PropertyRelationshipList.Remove(item.PropertyRelationship);
					Solution.PropertyRelationshipList.Remove(item.PropertyRelationship);
					Items.Remove(item);
					Property.ResetModified(true);
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
			ProcessNewPropertyCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Property.ReverseInstance == null && Property.IsAutoUpdated == true)
			{
				Property.ReverseInstance = new Property();
				Property.ReverseInstance.TransformDataFromObject(Property, null, false);

				// perform the update of EditProperty back to Property
				Property.TransformDataFromObject(EditProperty, null, false);
				Property.IsAutoUpdated = false;
			}
			else if (Property.ReverseInstance != null)
			{
				EditProperty.ResetModified(Property.ReverseInstance.IsModified);
				if (EditProperty.Equals(Property.ReverseInstance))
				{
					// perform the update of EditProperty back to Property
					Property.TransformDataFromObject(EditProperty, null, false);
					Property.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditProperty back to Property
					Property.TransformDataFromObject(EditProperty, null, false);
					Property.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditProperty back to Property
				Property.TransformDataFromObject(EditProperty, null, false);
				Property.IsAutoUpdated = false;
			}
			Property.ForwardInstance = null;
			if (PropertyNameCustomized || IsPrimaryKeyMemberCustomized || IsForeignKeyMemberCustomized || DataTypeCodeCustomized || LengthCustomized || PrecisionCustomized || ScaleCustomized || InitialValueCustomized || IdentityCustomized || IdentitySeedCustomized || IdentityIncrementCustomized || IsNullableCustomized || OrderCustomized || DescriptionCustomized || PropertyRelationshipListCustomized || TagsCustomized)
			{
				Property.ForwardInstance = new Property();
				Property.ForwardInstance.PropertyID = EditProperty.PropertyID;
				Property.SpecSourceName = Property.DefaultSourceName;
				if (PropertyNameCustomized)
				{
					Property.ForwardInstance.PropertyName = EditProperty.PropertyName;
				}
				if (IsPrimaryKeyMemberCustomized)
				{
					Property.ForwardInstance.IsPrimaryKeyMember = EditProperty.IsPrimaryKeyMember;
				}
				if (IsForeignKeyMemberCustomized)
				{
					Property.ForwardInstance.IsForeignKeyMember = EditProperty.IsForeignKeyMember;
				}
				if (DataTypeCodeCustomized)
				{
					Property.ForwardInstance.DataTypeCode = EditProperty.DataTypeCode;
				}
				if (LengthCustomized)
				{
					Property.ForwardInstance.Length = EditProperty.Length;
				}
				if (PrecisionCustomized)
				{
					Property.ForwardInstance.Precision = EditProperty.Precision;
				}
				if (ScaleCustomized)
				{
					Property.ForwardInstance.Scale = EditProperty.Scale;
				}
				if (InitialValueCustomized)
				{
					Property.ForwardInstance.InitialValue = EditProperty.InitialValue;
				}
				if (IdentityCustomized)
				{
					Property.ForwardInstance.Identity = EditProperty.Identity;
				}
				if (IdentitySeedCustomized)
				{
					Property.ForwardInstance.IdentitySeed = EditProperty.IdentitySeed;
				}
				if (IdentityIncrementCustomized)
				{
					Property.ForwardInstance.IdentityIncrement = EditProperty.IdentityIncrement;
				}
				if (IsNullableCustomized)
				{
					Property.ForwardInstance.IsNullable = EditProperty.IsNullable;
				}
				if (OrderCustomized)
				{
					Property.ForwardInstance.Order = EditProperty.Order;
				}
				if (DescriptionCustomized)
				{
					Property.ForwardInstance.Description = EditProperty.Description;
				}
				if (PropertyRelationshipListCustomized)
				{
					#region protected
					#endregion protected
					// Property.PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>(EditProperty.PropertyRelationshipList, null);
					// Property.ForwardInstance.PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>(EditProperty.PropertyRelationshipList, null);
				}
				if (TagsCustomized)
				{
					Property.ForwardInstance.Tags = EditProperty.Tags;
				}
			}
			EditProperty.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditPropertyPerformed();

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
		public void SendEditPropertyPerformed()
		{
			PropertyEventArgs message = new PropertyEventArgs();
			message.Property = Property;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyEventArgs>(MediatorMessages.Command_EditPropertyPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Property command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeletePropertyCommand()
		{
			PropertyEventArgs message = new PropertyEventArgs();
			message.Property = Property;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<PropertyEventArgs>(MediatorMessages.Command_DeletePropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeletePropertyCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyRelationshipViewModel> PropertyRelationships { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Property.</summary>
		///--------------------------------------------------------------------------------
		public Property Property { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid PropertyID
		{
			get
			{
				return Property.PropertyID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Property.Name;
			}
			set
			{
				Property.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return Property.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return Property.EntityID;
			}
			set
			{
				Property.EntityID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Property into the view model.</summary>
		/// 
		/// <param name="property">The Property to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadProperty(Property property, bool loadChildren = true)
		{
			// attach the Property
			Property = property;
			ItemID = Property.PropertyID;
			Items.Clear();
			
			// initialize PropertyRelationships
			if (PropertyRelationships == null)
			{
				PropertyRelationships = new EnterpriseDataObjectList<PropertyRelationshipViewModel>();
			}
			if (loadChildren == true)
			{
				// attach PropertyRelationships
				foreach (PropertyRelationship item in property.PropertyRelationshipList)
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
			
			HasErrors = !Property.IsValid;
			HasCustomizations = Property.IsAutoUpdated == false || Property.IsEmptyMetadata(Property.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Property.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Property.IsAutoUpdated = true;
				Property.SpecSourceName = Property.ReverseInstance.SpecSourceName;
				Property.ResetModified(Property.ReverseInstance.IsModified);
				Property.ResetLoaded(Property.ReverseInstance.IsLoaded);
				if (!Property.IsIdenticalMetadata(Property.ReverseInstance))
				{
					HasCustomizations = true;
					Property.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Property.ForwardInstance = null;
				Property.ReverseInstance = null;
				Property.IsAutoUpdated = true;
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
			if (_editProperty != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditProperty.PropertyChanged -= EditProperty_PropertyChanged;
				EditProperty = null;
			}
			Property = null;
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
			if (data is PropertyRelationshipEventArgs && (data as PropertyRelationshipEventArgs).PropertyID == Property.PropertyID)
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
		public PropertyViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="property">The Property to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public PropertyViewModel(Property property, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadProperty(property, loadChildren);
		}

		#endregion "Constructors"
	}
}
