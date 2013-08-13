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
	/// <summary>This class provides views for Parameter instances.</summary>
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
	public partial class ParameterViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewParameter.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewParameter
		{
			get
			{
				return DisplayValues.ContextMenu_NewParameter;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlParameterToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelParameterToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewParameterToolTip;
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
				if (EditParameter.IsModified == true)
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
				return string.IsNullOrEmpty(ParameterNameValidationMessage + ReferencedEntityIDValidationMessage + ReferencedPropertyIDValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private Parameter _editParameter = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditParameter.</summary>
		///--------------------------------------------------------------------------------
		public Parameter EditParameter
		{
			get
			{
				if (_editParameter == null)
				{
					_editParameter = new Parameter();
					_editParameter.PropertyChanged += new PropertyChangedEventHandler(EditParameter_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Parameter != null)
					{
						_editParameter.TransformDataFromObject(Parameter, null, false);
						_editParameter.Solution = Parameter.Solution;
						_editParameter.Method = Parameter.Method;
						_editParameter.ReferencedEntity = Parameter.ReferencedEntity;
						_editParameter.ReferencedPropertyBase = Parameter.ReferencedPropertyBase;
					}
					_editParameter.ResetModified(false);
				
					#region protected
					RefreshProperties();
					#endregion protected

				}
				return _editParameter;
			}
			set
			{
				_editParameter = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditParameter_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditParameter");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("ParameterName");
			OnPropertyChanged("ParameterNameCustomized");
			OnPropertyChanged("ParameterNameValidationMessage");
			
			OnPropertyChanged("ReferencedEntityID");
			OnPropertyChanged("ReferencedEntityIDCustomized");
			OnPropertyChanged("ReferencedEntityIDValidationMessage");
			
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
				return DisplayValues.Edit_ParameterHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_ParameterHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParameterIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParameterIDLabel
		{
			get
			{
				return DisplayValues.Edit_ParameterIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParameterNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParameterNameLabel
		{
			get
			{
				return DisplayValues.Edit_ParameterNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ParameterName.</summary>
		///--------------------------------------------------------------------------------
		public string ParameterName
		{
			get
			{
				return EditParameter.ParameterName;
			}
			set
			{
				EditParameter.ParameterName = value;
				OnPropertyChanged("ParameterName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParameterNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ParameterNameCustomized
		{
			get
			{
				if (Parameter.ReverseInstance != null)
				{
					return ParameterName.GetString() != Parameter.ReverseInstance.ParameterName.GetString();
				}
				else if (Parameter.IsAutoUpdated == true)
				{
					return ParameterName.GetString() != Parameter.ParameterName.GetString();
				}
				return ParameterName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParameterNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ParameterNameValidationMessage
		{
			get
			{
				return EditParameter.ValidateParameterName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ReferencedEntityIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedEntityIDLabel
		{
			get
			{
				return DisplayValues.Edit_ReferencedEntityIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ReferencedEntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ReferencedEntityID
		{
			get
			{
				return EditParameter.ReferencedEntityID;
			}
			set
			{
				EditParameter.ReferencedEntityID = value;
				OnPropertyChanged("ReferencedEntityID");
				OnPropertyChanged("TabTitle");
			
				#region protected
				RefreshProperties();
				#endregion protected

			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedEntityIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ReferencedEntityIDCustomized
		{
			get
			{
				if (Parameter.ReverseInstance != null)
				{
					return ReferencedEntityID.GetGuid() != Parameter.ReverseInstance.ReferencedEntityID.GetGuid();
				}
				else if (Parameter.IsAutoUpdated == true)
				{
					return ReferencedEntityID.GetGuid() != Parameter.ReferencedEntityID.GetGuid();
				}
				return ReferencedEntityID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedEntityIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ReferencedEntityIDValidationMessage
		{
			get
			{
				return EditParameter.ValidateReferencedEntityID();
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
				return EditParameter.ReferencedPropertyID;
			}
			set
			{
				EditParameter.ReferencedPropertyID = value;
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
				if (Parameter.ReverseInstance != null)
				{
					return ReferencedPropertyID.GetGuid() != Parameter.ReverseInstance.ReferencedPropertyID.GetGuid();
				}
				else if (Parameter.IsAutoUpdated == true)
				{
					return ReferencedPropertyID.GetGuid() != Parameter.ReferencedPropertyID.GetGuid();
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
				return EditParameter.ValidateReferencedPropertyID();
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
				return EditParameter.Order;
			}
			set
			{
				EditParameter.Order = value;
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
				if (Parameter.ReverseInstance != null)
				{
					return Order.GetInt() != Parameter.ReverseInstance.Order.GetInt();
				}
				else if (Parameter.IsAutoUpdated == true)
				{
					return Order.GetInt() != Parameter.Order.GetInt();
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
				return EditParameter.ValidateOrder();
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
				return EditParameter.Description;
			}
			set
			{
				EditParameter.Description = value;
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
				if (Parameter.ReverseInstance != null)
				{
					return Description.GetString() != Parameter.ReverseInstance.Description.GetString();
				}
				else if (Parameter.IsAutoUpdated == true)
				{
					return Description.GetString() != Parameter.Description.GetString();
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
				return EditParameter.ValidateDescription();
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
				return EditParameter.SourceName;
			}
			set
			{
				EditParameter.SourceName = value;
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
				return EditParameter.SpecSourceName;
			}
			set
			{
				EditParameter.SpecSourceName = value;
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
				return EditParameter.Tags;
			}
			set
			{
				EditParameter.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Parameter.ReverseInstance != null)
				{
					return Tags != Parameter.ReverseInstance.Tags;
				}
				else if (Parameter.IsAutoUpdated == true)
				{
					return Tags != Parameter.Tags;
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
				return EditParameter.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditParameter.Name;
			}
			set
			{
				EditParameter.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditParameter.TransformDataFromObject(Parameter, null, false);
			ResetItems();
			
			#region protected
			RefreshProperties();
			#endregion protected

			EditParameter.ResetModified(false);
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
			if (Parameter.ReverseInstance != null)
			{
				EditParameter.TransformDataFromObject(Parameter.ReverseInstance, null, false);
			}
			else if (Parameter.IsAutoUpdated == true)
			{
				EditParameter.TransformDataFromObject(Parameter, null, false);
			}
			else
			{
				Parameter newParameter = new Parameter();
				newParameter.ParameterID = EditParameter.ParameterID;
				EditParameter.TransformDataFromObject(newParameter, null, false);
			}
			EditParameter.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Parameter command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewParameterCommand()
		{
			ParameterEventArgs message = new ParameterEventArgs();
			message.Parameter = new Parameter();
			message.Parameter.ParameterID = Guid.NewGuid();
			message.Parameter.MethodID = MethodID;
			message.Parameter.Method = Solution.MethodList.FindByID((Guid)MethodID);
			if (message.Parameter.Method != null)
			{
				message.Parameter.Order = message.Parameter.Method.ParameterList.Count + 1;
			}
			message.Parameter.Solution = Solution;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ParameterEventArgs>(MediatorMessages.Command_EditParameterRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditParameterCommand()
		{
			ParameterEventArgs message = new ParameterEventArgs();
			message.Parameter = Parameter;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ParameterEventArgs>(MediatorMessages.Command_EditParameterRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewParameterCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Parameter.ReverseInstance == null && Parameter.IsAutoUpdated == true)
			{
				Parameter.ReverseInstance = new Parameter();
				Parameter.ReverseInstance.TransformDataFromObject(Parameter, null, false);

				// perform the update of EditParameter back to Parameter
				Parameter.TransformDataFromObject(EditParameter, null, false);
				Parameter.IsAutoUpdated = false;
			}
			else if (Parameter.ReverseInstance != null)
			{
				EditParameter.ResetModified(Parameter.ReverseInstance.IsModified);
				if (EditParameter.Equals(Parameter.ReverseInstance))
				{
					// perform the update of EditParameter back to Parameter
					Parameter.TransformDataFromObject(EditParameter, null, false);
					Parameter.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditParameter back to Parameter
					Parameter.TransformDataFromObject(EditParameter, null, false);
					Parameter.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditParameter back to Parameter
				Parameter.TransformDataFromObject(EditParameter, null, false);
				Parameter.IsAutoUpdated = false;
			}
			Parameter.ForwardInstance = null;
			if (ParameterNameCustomized || ReferencedEntityIDCustomized || ReferencedPropertyIDCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				Parameter.ForwardInstance = new Parameter();
				Parameter.ForwardInstance.ParameterID = EditParameter.ParameterID;
				Parameter.SpecSourceName = Parameter.DefaultSourceName;
				if (ParameterNameCustomized)
				{
					Parameter.ForwardInstance.ParameterName = EditParameter.ParameterName;
				}
				if (ReferencedEntityIDCustomized)
				{
					Parameter.ForwardInstance.ReferencedEntityID = EditParameter.ReferencedEntityID;
				}
				if (ReferencedPropertyIDCustomized)
				{
					Parameter.ForwardInstance.ReferencedPropertyID = EditParameter.ReferencedPropertyID;
				}
				if (OrderCustomized)
				{
					Parameter.ForwardInstance.Order = EditParameter.Order;
				}
				if (DescriptionCustomized)
				{
					Parameter.ForwardInstance.Description = EditParameter.Description;
				}
				if (TagsCustomized)
				{
					Parameter.ForwardInstance.Tags = EditParameter.Tags;
				}
			}
			EditParameter.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditParameterPerformed();
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
		public void SendEditParameterPerformed()
		{
			ParameterEventArgs message = new ParameterEventArgs();
			message.Parameter = Parameter;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ParameterEventArgs>(MediatorMessages.Command_EditParameterPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Parameter command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteParameterCommand()
		{
			ParameterEventArgs message = new ParameterEventArgs();
			message.Parameter = Parameter;
			message.MethodID = MethodID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ParameterEventArgs>(MediatorMessages.Command_DeleteParameterRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteParameterCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Parameter.</summary>
		///--------------------------------------------------------------------------------
		public Parameter Parameter { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParameterID.</summary>
		///--------------------------------------------------------------------------------
		public Guid ParameterID
		{
			get
			{
				return Parameter.ParameterID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Parameter.Name;
			}
			set
			{
				Parameter.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return Parameter.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets MethodID.</summary>
		///--------------------------------------------------------------------------------
		public Guid MethodID
		{
			get
			{
				return Parameter.MethodID;
			}
			set
			{
				Parameter.MethodID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Parameter into the view model.</summary>
		/// 
		/// <param name="parameter">The Parameter to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadParameter(Parameter parameter, bool loadChildren = true)
		{
			// attach the Parameter
			Parameter = parameter;
			ItemID = Parameter.ParameterID;
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
			
			HasErrors = !Parameter.IsValid;
			HasCustomizations = Parameter.IsAutoUpdated == false || Parameter.IsEmptyMetadata(Parameter.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Parameter.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Parameter.IsAutoUpdated = true;
				Parameter.SpecSourceName = Parameter.ReverseInstance.SpecSourceName;
				Parameter.ResetModified(Parameter.ReverseInstance.IsModified);
				Parameter.ResetLoaded(Parameter.ReverseInstance.IsLoaded);
				if (!Parameter.IsIdenticalMetadata(Parameter.ReverseInstance))
				{
					HasCustomizations = true;
					Parameter.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Parameter.ForwardInstance = null;
				Parameter.ReverseInstance = null;
				Parameter.IsAutoUpdated = true;
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
			if (_editParameter != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditParameter.PropertyChanged -= EditParameter_PropertyChanged;
				EditParameter = null;
			}
			Parameter = null;
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
		public ParameterViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="parameter">The Parameter to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public ParameterViewModel(Parameter parameter, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadParameter(parameter, loadChildren);
		}

		#endregion "Constructors"
	}
}
