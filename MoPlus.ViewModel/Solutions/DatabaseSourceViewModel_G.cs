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
	/// <summary>This class provides views for DatabaseSource instances.</summary>
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
	public partial class DatabaseSourceViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDatabaseSource.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDatabaseSource
		{
			get
			{
				return DisplayValues.ContextMenu_NewDatabaseSource;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlDatabaseSourceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDatabaseSourceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDatabaseSourceToolTip;
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
				if (EditDatabaseSource.IsModified == true)
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
				return string.IsNullOrEmpty(SourceDbServerNameValidationMessage + SourceDbNameValidationMessage + DatabaseTypeCodeValidationMessage + UserNameValidationMessage + PasswordValidationMessage + TemplatePathValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private DatabaseSource _editDatabaseSource = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditDatabaseSource.</summary>
		///--------------------------------------------------------------------------------
		public DatabaseSource EditDatabaseSource
		{
			get
			{
				if (_editDatabaseSource == null)
				{
					_editDatabaseSource = new DatabaseSource();
					_editDatabaseSource.PropertyChanged += new PropertyChangedEventHandler(EditDatabaseSource_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (DatabaseSource != null)
					{
						_editDatabaseSource.TransformDataFromObject(DatabaseSource, null, false);
						_editDatabaseSource.Solution = DatabaseSource.Solution;
						_editDatabaseSource.DatabaseType = DatabaseSource.DatabaseType;
					}
					_editDatabaseSource.ResetModified(false);
				}
				return _editDatabaseSource;
			}
			set
			{
				_editDatabaseSource = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditDatabaseSource_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditDatabaseSource");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("SourceDbServerName");
			OnPropertyChanged("SourceDbServerNameCustomized");
			OnPropertyChanged("SourceDbServerNameValidationMessage");
			
			OnPropertyChanged("SourceDbName");
			OnPropertyChanged("SourceDbNameCustomized");
			OnPropertyChanged("SourceDbNameValidationMessage");
			
			OnPropertyChanged("DatabaseTypeCode");
			OnPropertyChanged("DatabaseTypeCodeCustomized");
			OnPropertyChanged("DatabaseTypeCodeValidationMessage");
			
			OnPropertyChanged("UserName");
			OnPropertyChanged("UserNameCustomized");
			OnPropertyChanged("UserNameValidationMessage");
			
			OnPropertyChanged("Password");
			OnPropertyChanged("PasswordCustomized");
			OnPropertyChanged("PasswordValidationMessage");
			
			OnPropertyChanged("TemplatePath");
			OnPropertyChanged("TemplatePathCustomized");
			OnPropertyChanged("TemplatePathValidationMessage");
			
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
				return DisplayValues.Edit_DatabaseSourceHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_DatabaseSourceHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SpecificationSourceIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SpecificationSourceIDLabel
		{
			get
			{
				return DisplayValues.Edit_SpecificationSourceIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SourceDbServerNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceDbServerNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceDbServerNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SourceDbServerName.</summary>
		///--------------------------------------------------------------------------------
		public string SourceDbServerName
		{
			get
			{
				return EditDatabaseSource.SourceDbServerName;
			}
			set
			{
				EditDatabaseSource.SourceDbServerName = value;
				OnPropertyChanged("SourceDbServerName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceDbServerNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceDbServerNameCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return SourceDbServerName.GetString() != DatabaseSource.ReverseInstance.SourceDbServerName.GetString();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return SourceDbServerName.GetString() != DatabaseSource.SourceDbServerName.GetString();
				}
				return SourceDbServerName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceDbServerNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceDbServerNameValidationMessage
		{
			get
			{
				return EditDatabaseSource.ValidateSourceDbServerName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SourceDbNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceDbNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceDbNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SourceDbName.</summary>
		///--------------------------------------------------------------------------------
		public string SourceDbName
		{
			get
			{
				return EditDatabaseSource.SourceDbName;
			}
			set
			{
				EditDatabaseSource.SourceDbName = value;
				OnPropertyChanged("SourceDbName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceDbNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceDbNameCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return SourceDbName.GetString() != DatabaseSource.ReverseInstance.SourceDbName.GetString();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return SourceDbName.GetString() != DatabaseSource.SourceDbName.GetString();
				}
				return SourceDbName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceDbNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceDbNameValidationMessage
		{
			get
			{
				return EditDatabaseSource.ValidateSourceDbName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DatabaseTypeCodeLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DatabaseTypeCodeLabel
		{
			get
			{
				return DisplayValues.Edit_DatabaseTypeCodeSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets DatabaseTypeCode.</summary>
		///--------------------------------------------------------------------------------
		public int DatabaseTypeCode
		{
			get
			{
				return EditDatabaseSource.DatabaseTypeCode;
			}
			set
			{
				EditDatabaseSource.DatabaseTypeCode = value;
				OnPropertyChanged("DatabaseTypeCode");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DatabaseTypeCodeCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DatabaseTypeCodeCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return DatabaseTypeCode.GetInt() != DatabaseSource.ReverseInstance.DatabaseTypeCode.GetInt();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return DatabaseTypeCode.GetInt() != DatabaseSource.DatabaseTypeCode.GetInt();
				}
				return DatabaseTypeCode != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DatabaseTypeCodeValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DatabaseTypeCodeValidationMessage
		{
			get
			{
				return EditDatabaseSource.ValidateDatabaseTypeCode();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the UserNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string UserNameLabel
		{
			get
			{
				return DisplayValues.Edit_UserNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets UserName.</summary>
		///--------------------------------------------------------------------------------
		public string UserName
		{
			get
			{
				return EditDatabaseSource.UserName;
			}
			set
			{
				EditDatabaseSource.UserName = value;
				OnPropertyChanged("UserName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets UserNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool UserNameCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return UserName.GetString() != DatabaseSource.ReverseInstance.UserName.GetString();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return UserName.GetString() != DatabaseSource.UserName.GetString();
				}
				return UserName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets UserNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string UserNameValidationMessage
		{
			get
			{
				return EditDatabaseSource.ValidateUserName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PasswordLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PasswordLabel
		{
			get
			{
				return DisplayValues.Edit_PasswordProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Password.</summary>
		///--------------------------------------------------------------------------------
		public string Password
		{
			get
			{
				return EditDatabaseSource.PasswordClearText;
			}
			set
			{
				EditDatabaseSource.PasswordClearText = value;
				OnPropertyChanged("Password");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PasswordCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PasswordCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return Password.GetString() != DatabaseSource.ReverseInstance.Password.GetString();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return Password.GetString() != DatabaseSource.Password.GetString();
				}
				return Password != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PasswordValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PasswordValidationMessage
		{
			get
			{
				return EditDatabaseSource.ValidatePassword();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplatePathLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePathLabel
		{
			get
			{
				return DisplayValues.Edit_TemplatePathProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplatePath.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePath
		{
			get
			{
				return EditDatabaseSource.TemplatePath;
			}
			set
			{
				EditDatabaseSource.TemplatePath = value;
				OnPropertyChanged("TemplatePath");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplatePathCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TemplatePathCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return TemplatePath.GetString() != DatabaseSource.ReverseInstance.TemplatePath.GetString();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return TemplatePath.GetString() != DatabaseSource.TemplatePath.GetString();
				}
				return TemplatePath != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplatePathValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePathValidationMessage
		{
			get
			{
				return EditDatabaseSource.ValidateTemplatePath();
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
				return EditDatabaseSource.Order;
			}
			set
			{
				EditDatabaseSource.Order = value;
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
				if (DatabaseSource.ReverseInstance != null)
				{
					return Order.GetInt() != DatabaseSource.ReverseInstance.Order.GetInt();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return Order.GetInt() != DatabaseSource.Order.GetInt();
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
				return EditDatabaseSource.ValidateOrder();
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
				return EditDatabaseSource.Description;
			}
			set
			{
				EditDatabaseSource.Description = value;
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
				if (DatabaseSource.ReverseInstance != null)
				{
					return Description.GetString() != DatabaseSource.ReverseInstance.Description.GetString();
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return Description.GetString() != DatabaseSource.Description.GetString();
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
				return EditDatabaseSource.ValidateDescription();
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
				return EditDatabaseSource.SourceName;
			}
			set
			{
				EditDatabaseSource.SourceName = value;
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
				return EditDatabaseSource.SpecSourceName;
			}
			set
			{
				EditDatabaseSource.SpecSourceName = value;
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
				return EditDatabaseSource.Tags;
			}
			set
			{
				EditDatabaseSource.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (DatabaseSource.ReverseInstance != null)
				{
					return Tags != DatabaseSource.ReverseInstance.Tags;
				}
				else if (DatabaseSource.IsAutoUpdated == true)
				{
					return Tags != DatabaseSource.Tags;
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
				return EditDatabaseSource.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditDatabaseSource.Name;
			}
			set
			{
				EditDatabaseSource.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditDatabaseSource.TransformDataFromObject(DatabaseSource, null, false);
			EditDatabaseSource.ResetModified(false);
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
			if (DatabaseSource.ReverseInstance != null)
			{
				EditDatabaseSource.TransformDataFromObject(DatabaseSource.ReverseInstance, null, false);
			}
			else if (DatabaseSource.IsAutoUpdated == true)
			{
				EditDatabaseSource.TransformDataFromObject(DatabaseSource, null, false);
			}
			else
			{
				DatabaseSource newDatabaseSource = new DatabaseSource();
				newDatabaseSource.SpecificationSourceID = EditDatabaseSource.SpecificationSourceID;
				EditDatabaseSource.TransformDataFromObject(newDatabaseSource, null, false);
			}
			EditDatabaseSource.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new DatabaseSource command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDatabaseSourceCommand()
		{
			DatabaseSourceEventArgs message = new DatabaseSourceEventArgs();
			message.DatabaseSource = new DatabaseSource();
			message.DatabaseSource.SpecificationSourceID = Guid.NewGuid();
			message.DatabaseSource.SolutionID = SolutionID;
			message.DatabaseSource.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DatabaseSourceEventArgs>(MediatorMessages.Command_EditDatabaseSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDatabaseSourceCommand()
		{
			DatabaseSourceEventArgs message = new DatabaseSourceEventArgs();
			message.DatabaseSource = DatabaseSource;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DatabaseSourceEventArgs>(MediatorMessages.Command_EditDatabaseSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewDatabaseSourceCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (DatabaseSource.ReverseInstance == null && DatabaseSource.IsAutoUpdated == true)
			{
				DatabaseSource.ReverseInstance = new DatabaseSource();
				DatabaseSource.ReverseInstance.TransformDataFromObject(DatabaseSource, null, false);

				// perform the update of EditDatabaseSource back to DatabaseSource
				DatabaseSource.TransformDataFromObject(EditDatabaseSource, null, false);
				DatabaseSource.IsAutoUpdated = false;
			}
			else if (DatabaseSource.ReverseInstance != null)
			{
				EditDatabaseSource.ResetModified(DatabaseSource.ReverseInstance.IsModified);
				if (EditDatabaseSource.Equals(DatabaseSource.ReverseInstance))
				{
					// perform the update of EditDatabaseSource back to DatabaseSource
					DatabaseSource.TransformDataFromObject(EditDatabaseSource, null, false);
					DatabaseSource.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditDatabaseSource back to DatabaseSource
					DatabaseSource.TransformDataFromObject(EditDatabaseSource, null, false);
					DatabaseSource.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditDatabaseSource back to DatabaseSource
				DatabaseSource.TransformDataFromObject(EditDatabaseSource, null, false);
				DatabaseSource.IsAutoUpdated = false;
			}
			DatabaseSource.ForwardInstance = null;
			if (SourceDbServerNameCustomized || SourceDbNameCustomized || DatabaseTypeCodeCustomized || UserNameCustomized || PasswordCustomized || TemplatePathCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				DatabaseSource.ForwardInstance = new DatabaseSource();
				DatabaseSource.ForwardInstance.SpecificationSourceID = EditDatabaseSource.SpecificationSourceID;
				DatabaseSource.SpecSourceName = DatabaseSource.DefaultSourceName;
				if (SourceDbServerNameCustomized)
				{
					DatabaseSource.ForwardInstance.SourceDbServerName = EditDatabaseSource.SourceDbServerName;
				}
				if (SourceDbNameCustomized)
				{
					DatabaseSource.ForwardInstance.SourceDbName = EditDatabaseSource.SourceDbName;
				}
				if (DatabaseTypeCodeCustomized)
				{
					DatabaseSource.ForwardInstance.DatabaseTypeCode = EditDatabaseSource.DatabaseTypeCode;
				}
				if (UserNameCustomized)
				{
					DatabaseSource.ForwardInstance.UserName = EditDatabaseSource.UserName;
				}
				if (PasswordCustomized)
				{
					DatabaseSource.ForwardInstance.Password = EditDatabaseSource.Password;
				}
				if (TemplatePathCustomized)
				{
					DatabaseSource.ForwardInstance.TemplatePath = EditDatabaseSource.TemplatePath;
				}
				if (OrderCustomized)
				{
					DatabaseSource.ForwardInstance.Order = EditDatabaseSource.Order;
				}
				if (DescriptionCustomized)
				{
					DatabaseSource.ForwardInstance.Description = EditDatabaseSource.Description;
				}
				if (TagsCustomized)
				{
					DatabaseSource.ForwardInstance.Tags = EditDatabaseSource.Tags;
				}
			}
			EditDatabaseSource.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditDatabaseSourcePerformed();
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
		public void SendEditDatabaseSourcePerformed()
		{
			DatabaseSourceEventArgs message = new DatabaseSourceEventArgs();
			message.DatabaseSource = DatabaseSource;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DatabaseSourceEventArgs>(MediatorMessages.Command_EditDatabaseSourcePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete DatabaseSource command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDatabaseSourceCommand()
		{
			DatabaseSourceEventArgs message = new DatabaseSourceEventArgs();
			message.DatabaseSource = DatabaseSource;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DatabaseSourceEventArgs>(MediatorMessages.Command_DeleteDatabaseSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteDatabaseSourceCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DatabaseSource.</summary>
		///--------------------------------------------------------------------------------
		public DatabaseSource DatabaseSource { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecificationSourceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid SpecificationSourceID
		{
			get
			{
				return DatabaseSource.SpecificationSourceID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return DatabaseSource.Name;
			}
			set
			{
				DatabaseSource.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return DatabaseSource.Order;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of DatabaseSource into the view model.</summary>
		/// 
		/// <param name="databaseSource">The DatabaseSource to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDatabaseSource(DatabaseSource databaseSource, bool loadChildren = true)
		{
			// attach the DatabaseSource
			DatabaseSource = databaseSource;
			ItemID = DatabaseSource.SpecificationSourceID;
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
			
			HasErrors = !DatabaseSource.IsValid;
			HasCustomizations = DatabaseSource.IsAutoUpdated == false || DatabaseSource.IsEmptyMetadata(DatabaseSource.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && DatabaseSource.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				DatabaseSource.IsAutoUpdated = true;
				DatabaseSource.SpecSourceName = DatabaseSource.ReverseInstance.SpecSourceName;
				DatabaseSource.ResetModified(DatabaseSource.ReverseInstance.IsModified);
				DatabaseSource.ResetLoaded(DatabaseSource.ReverseInstance.IsLoaded);
				if (!DatabaseSource.IsIdenticalMetadata(DatabaseSource.ReverseInstance))
				{
					HasCustomizations = true;
					DatabaseSource.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				DatabaseSource.ForwardInstance = null;
				DatabaseSource.ReverseInstance = null;
				DatabaseSource.IsAutoUpdated = true;
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
			if (_editDatabaseSource != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditDatabaseSource.PropertyChanged -= EditDatabaseSource_PropertyChanged;
				EditDatabaseSource = null;
			}
			DatabaseSource = null;
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
		public DatabaseSourceViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="databaseSource">The DatabaseSource to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public DatabaseSourceViewModel(DatabaseSource databaseSource, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadDatabaseSource(databaseSource, loadChildren);
		}

		#endregion "Constructors"
	}
}
