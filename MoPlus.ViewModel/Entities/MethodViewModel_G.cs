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
	/// <summary>This class provides views for Method instances.</summary>
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
	public partial class MethodViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewMethod.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethod
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethod;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlMethodToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelMethodToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewMethodToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewParameterToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewParameterToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewParameterToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewMethodRelationshipToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewMethodRelationshipToolTip
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
				if (EditMethod.IsModified == true)
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
				return string.IsNullOrEmpty(MethodNameValidationMessage + MethodTypeCodeValidationMessage + DescriptionValidationMessage + ParameterListValidationMessage + MethodRelationshipListValidationMessage);
			}
		}
 
		private Method _editMethod = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditMethod.</summary>
		///--------------------------------------------------------------------------------
		public Method EditMethod
		{
			get
			{
				if (_editMethod == null)
				{
					_editMethod = new Method();
					_editMethod.PropertyChanged += new PropertyChangedEventHandler(EditMethod_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Method != null)
					{
						_editMethod.TransformDataFromObject(Method, null, false);
						_editMethod.Solution = Method.Solution;
						_editMethod.Entity = Method.Entity;
						_editMethod.MethodType = Method.MethodType;
					}
					_editMethod.ResetModified(false);
				}
				return _editMethod;
			}
			set
			{
				_editMethod = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditMethod_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditMethod");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("MethodName");
			OnPropertyChanged("MethodNameCustomized");
			OnPropertyChanged("MethodNameValidationMessage");
			
			OnPropertyChanged("MethodTypeCode");
			OnPropertyChanged("MethodTypeCodeCustomized");
			OnPropertyChanged("MethodTypeCodeValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("ParameterList");
			OnPropertyChanged("ParameterListCustomized");
			OnPropertyChanged("ParameterListValidationMessage");
			
			OnPropertyChanged("MethodRelationshipList");
			OnPropertyChanged("MethodRelationshipListCustomized");
			OnPropertyChanged("MethodRelationshipListValidationMessage");

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
				return DisplayValues.Edit_MethodHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_MethodHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string MethodIDLabel
		{
			get
			{
				return DisplayValues.Edit_MethodIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParameterListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParameterListLabel
		{
			get
			{
				return DisplayValues.Edit_ParameterListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ParameterList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Parameter> ParameterList
		{
			get
			{
				return EditMethod.ParameterList;
			}
			set
			{
				EditMethod.ParameterList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParameterListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ParameterListCustomized
		{
			get
			{
				#region protected
				foreach (ParameterViewModel item in Items.OfType<ParameterViewModel>())
				{
					if (item.HasCustomizations == true || item.Parameter.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParameterListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ParameterListValidationMessage
		{
			get
			{
				#region protected
				StringBuilder sb = new StringBuilder();
				if (Parameters != null)
				{
					foreach (ParameterViewModel item in Parameters)
					{
						sb.Append(item.EditParameter.GetValidationErrors());
					}
				}
				if (!String.IsNullOrEmpty(sb.ToString())) return sb.ToString();
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodRelationshipListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string MethodRelationshipListLabel
		{
			get
			{
				return DisplayValues.Edit_MethodRelationshipListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets MethodRelationshipList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<MethodRelationship> MethodRelationshipList
		{
			get
			{
				return EditMethod.MethodRelationshipList;
			}
			set
			{
				EditMethod.MethodRelationshipList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodRelationshipListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool MethodRelationshipListCustomized
		{
			get
			{
				#region protected
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodRelationshipListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string MethodRelationshipListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string MethodNameLabel
		{
			get
			{
				return DisplayValues.Edit_MethodNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets MethodName.</summary>
		///--------------------------------------------------------------------------------
		public string MethodName
		{
			get
			{
				return EditMethod.MethodName;
			}
			set
			{
				EditMethod.MethodName = value;
				OnPropertyChanged("MethodName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool MethodNameCustomized
		{
			get
			{
				if (Method.ReverseInstance != null)
				{
					return MethodName.GetString() != Method.ReverseInstance.MethodName.GetString();
				}
				else if (Method.IsAutoUpdated == true)
				{
					return MethodName.GetString() != Method.MethodName.GetString();
				}
				return MethodName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string MethodNameValidationMessage
		{
			get
			{
				return EditMethod.ValidateMethodName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodTypeCodeLabel.</summary>
		///--------------------------------------------------------------------------------
		public string MethodTypeCodeLabel
		{
			get
			{
				return DisplayValues.Edit_MethodTypeCodeSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets MethodTypeCode.</summary>
		///--------------------------------------------------------------------------------
		public int MethodTypeCode
		{
			get
			{
				return EditMethod.MethodTypeCode;
			}
			set
			{
				EditMethod.MethodTypeCode = value;
				OnPropertyChanged("MethodTypeCode");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodTypeCodeCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool MethodTypeCodeCustomized
		{
			get
			{
				if (Method.ReverseInstance != null)
				{
					return MethodTypeCode.GetInt() != Method.ReverseInstance.MethodTypeCode.GetInt();
				}
				else if (Method.IsAutoUpdated == true)
				{
					return MethodTypeCode.GetInt() != Method.MethodTypeCode.GetInt();
				}
				return MethodTypeCode != DefaultValue.Int;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodTypeCodeValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string MethodTypeCodeValidationMessage
		{
			get
			{
				return EditMethod.ValidateMethodTypeCode();
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
				return EditMethod.Description;
			}
			set
			{
				EditMethod.Description = value;
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
				if (Method.ReverseInstance != null)
				{
					return Description.GetString() != Method.ReverseInstance.Description.GetString();
				}
				else if (Method.IsAutoUpdated == true)
				{
					return Description.GetString() != Method.Description.GetString();
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
				return EditMethod.ValidateDescription();
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
				return EditMethod.SourceName;
			}
			set
			{
				EditMethod.SourceName = value;
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
				return EditMethod.SpecSourceName;
			}
			set
			{
				EditMethod.SpecSourceName = value;
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
				return EditMethod.Tags;
			}
			set
			{
				EditMethod.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Method.ReverseInstance != null)
				{
					return Tags != Method.ReverseInstance.Tags;
				}
				else if (Method.IsAutoUpdated == true)
				{
					return Tags != Method.Tags;
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
				return EditMethod.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditMethod.Name;
			}
			set
			{
				EditMethod.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditMethod.TransformDataFromObject(Method, null, false);
			ResetItems();
			
			#region protected
			_parameterItems = null;
			_methodRelationshipItems = null;
			OnPropertyChanged("ParameterItems");
			OnPropertyChanged("MethodRelationshipItems");
			#endregion protected

			EditMethod.ResetModified(false);
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
			if (Method.ReverseInstance != null)
			{
				EditMethod.TransformDataFromObject(Method.ReverseInstance, null, false);
			}
			else if (Method.IsAutoUpdated == true)
			{
				EditMethod.TransformDataFromObject(Method, null, false);
			}
			else
			{
				Method newMethod = new Method();
				newMethod.MethodID = EditMethod.MethodID;
				EditMethod.TransformDataFromObject(newMethod, null, false);
			}
			EditMethod.ResetModified(true);
			foreach (ParameterViewModel item in Items.OfType<ParameterViewModel>())
			{
				item.Defaults();
			}
			foreach (MethodRelationshipViewModel item in Items.OfType<MethodRelationshipViewModel>())
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
		/// <summary>This method processes the new Method command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewMethodCommand()
		{
			MethodEventArgs message = new MethodEventArgs();
			message.Method = new Method();
			message.Method.MethodID = Guid.NewGuid();
			message.Method.EntityID = EntityID;
			message.Method.Entity = Solution.EntityList.FindByID((Guid)EntityID);
			message.Method.Solution = Solution;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodEventArgs>(MediatorMessages.Command_EditMethodRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditMethodCommand()
		{
			MethodEventArgs message = new MethodEventArgs();
			message.Method = Method;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodEventArgs>(MediatorMessages.Command_EditMethodRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Parameter adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewParameter()
		{
			ParameterViewModel item = new ParameterViewModel();
			item.Parameter = new Parameter();
			item.Parameter.ParameterID = Guid.NewGuid();
			item.Parameter.Method = EditMethod;
			item.Parameter.MethodID = EditMethod.MethodID;
			item.Parameter.Solution = Solution;
			item.Parameter.Order = Method.ParameterList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			ParameterItems.Add(item);
			OnPropertyChanged("ParameterItems");
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new Parameter command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewParameterCommand()
		{
			ParameterEventArgs message = new ParameterEventArgs();
			message.Parameter = new Parameter();
			message.Parameter.ParameterID = Guid.NewGuid();
			message.Parameter.Method = Method;
			message.Parameter.MethodID = Method.MethodID;
			message.MethodID = Method.MethodID;
			if (message.Parameter.Method != null)
			{
				message.Parameter.Order = message.Parameter.Method.ParameterList.Count + 1;
			}
			message.Parameter.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<ParameterEventArgs>(MediatorMessages.Command_EditParameterRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Parameter updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditParameterPerformed(ParameterEventArgs data)
		{
			if (data != null && data.Parameter != null)
			{
				UpdateEditParameter(data.Parameter);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of Parameter.</summary>
		/// 
		/// <param name="parameter">The Parameter to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditParameter(Parameter parameter)
		{
			bool isItemMatch = false;
			foreach (ParameterViewModel item in Parameters)
			{
				if (item.Parameter.ParameterID == parameter.ParameterID)
				{
					isItemMatch = true;
					item.Parameter.TransformDataFromObject(parameter, null, false);
					if (!item.Parameter.ReferencedEntityID.IsNullOrEmpty())
					{
						item.Parameter.ReferencedEntity = Solution.EntityList.FindByID((Guid)item.Parameter.ReferencedEntityID);
					}
					if (!item.Parameter.ReferencedPropertyID.IsNullOrEmpty())
					{
						item.Parameter.ReferencedPropertyBase = Solution.PropertyBaseList.FindByID((Guid)item.Parameter.ReferencedPropertyID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new Parameter
				parameter.Method = Method;
				ParameterViewModel newItem = new ParameterViewModel(parameter, Solution);
				if (!newItem.Parameter.ReferencedEntityID.IsNullOrEmpty())
				{
					newItem.Parameter.ReferencedEntity = Solution.EntityList.FindByID((Guid)newItem.Parameter.ReferencedEntityID);
				}
				if (!newItem.Parameter.ReferencedPropertyID.IsNullOrEmpty())
				{
					newItem.Parameter.ReferencedPropertyBase = Solution.PropertyBaseList.FindByID((Guid)newItem.Parameter.ReferencedPropertyID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				Parameters.Add(newItem);
				Method.ParameterList.Add(parameter);
				Solution.ParameterList.Add(newItem.Parameter);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to Parameter deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedParameters(ParameterViewModel item)
		{
			#region protected
			ParameterItems.Remove(item);
			OnPropertyChanged("ParameterItems");
			#endregion protected
			
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies Parameter deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteParameterPerformed(ParameterEventArgs data)
		{
			if (data != null && data.Parameter != null)
			{
				DeleteParameter(data.Parameter);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Parameter.</summary>
		/// 
		/// <param name="parameter">The Parameter to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteParameter(Parameter parameter)
		{
			bool isItemMatch = false;
			foreach (ParameterViewModel item in Parameters.ToList<ParameterViewModel>())
			{
				if (item.Parameter.ParameterID == parameter.ParameterID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.Parameter.ParameterID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete Parameter
					isItemMatch = true;
					Parameters.Remove(item);
					Method.ParameterList.Remove(item.Parameter);
					Solution.ParameterList.Remove(item.Parameter);
					Items.Remove(item);
					Method.ResetModified(true);
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
		/// <summary>This method adds to MethodRelationship adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewMethodRelationship()
		{
			MethodRelationshipViewModel item = new MethodRelationshipViewModel();
			item.MethodRelationship = new MethodRelationship();
			item.MethodRelationship.MethodRelationshipID = Guid.NewGuid();
			item.MethodRelationship.Method = EditMethod;
			item.MethodRelationship.MethodID = EditMethod.MethodID;
			item.MethodRelationship.Solution = Solution;
			item.MethodRelationship.Order = Method.MethodRelationshipList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			MethodRelationshipItems.Add(item);
			OnPropertyChanged("MethodRelationshipItems");
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new MethodRelationship command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewMethodRelationshipCommand()
		{
			MethodRelationshipEventArgs message = new MethodRelationshipEventArgs();
			message.MethodRelationship = new MethodRelationship();
			message.MethodRelationship.MethodRelationshipID = Guid.NewGuid();
			message.MethodRelationship.Method = Method;
			message.MethodRelationship.MethodID = Method.MethodID;
			message.MethodID = Method.MethodID;
			if (message.MethodRelationship.Method != null)
			{
				message.MethodRelationship.Order = message.MethodRelationship.Method.MethodRelationshipList.Count + 1;
			}
			message.MethodRelationship.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodRelationshipEventArgs>(MediatorMessages.Command_EditMethodRelationshipRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies MethodRelationship updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditMethodRelationshipPerformed(MethodRelationshipEventArgs data)
		{
			if (data != null && data.MethodRelationship != null)
			{
				UpdateEditMethodRelationship(data.MethodRelationship);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of MethodRelationship.</summary>
		/// 
		/// <param name="methodRelationship">The MethodRelationship to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditMethodRelationship(MethodRelationship methodRelationship)
		{
			bool isItemMatch = false;
			foreach (MethodRelationshipViewModel item in MethodRelationships)
			{
				if (item.MethodRelationship.MethodRelationshipID == methodRelationship.MethodRelationshipID)
				{
					isItemMatch = true;
					item.MethodRelationship.TransformDataFromObject(methodRelationship, null, false);
					if (!item.MethodRelationship.RelationshipID.IsNullOrEmpty())
					{
						item.MethodRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)item.MethodRelationship.RelationshipID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new MethodRelationship
				methodRelationship.Method = Method;
				MethodRelationshipViewModel newItem = new MethodRelationshipViewModel(methodRelationship, Solution);
				if (!newItem.MethodRelationship.RelationshipID.IsNullOrEmpty())
				{
					newItem.MethodRelationship.Relationship = Solution.RelationshipList.FindByID((Guid)newItem.MethodRelationship.RelationshipID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				MethodRelationships.Add(newItem);
				Method.MethodRelationshipList.Add(methodRelationship);
				Solution.MethodRelationshipList.Add(newItem.MethodRelationship);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to MethodRelationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedMethodRelationships(MethodRelationshipViewModel item)
		{
			#region protected
			MethodRelationshipItems.Remove(item);
			OnPropertyChanged("MethodRelationshipItems");
			#endregion protected
			
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies MethodRelationship deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteMethodRelationshipPerformed(MethodRelationshipEventArgs data)
		{
			if (data != null && data.MethodRelationship != null)
			{
				DeleteMethodRelationship(data.MethodRelationship);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of MethodRelationship.</summary>
		/// 
		/// <param name="methodRelationship">The MethodRelationship to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteMethodRelationship(MethodRelationship methodRelationship)
		{
			bool isItemMatch = false;
			foreach (MethodRelationshipViewModel item in MethodRelationships.ToList<MethodRelationshipViewModel>())
			{
				if (item.MethodRelationship.MethodRelationshipID == methodRelationship.MethodRelationshipID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.MethodRelationship.MethodRelationshipID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete MethodRelationship
					isItemMatch = true;
					MethodRelationships.Remove(item);
					Method.MethodRelationshipList.Remove(item.MethodRelationship);
					Solution.MethodRelationshipList.Remove(item.MethodRelationship);
					Items.Remove(item);
					Method.ResetModified(true);
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
			ProcessNewMethodCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Method.ReverseInstance == null && Method.IsAutoUpdated == true)
			{
				Method.ReverseInstance = new Method();
				Method.ReverseInstance.TransformDataFromObject(Method, null, false);

				// perform the update of EditMethod back to Method
				Method.TransformDataFromObject(EditMethod, null, false);
				Method.IsAutoUpdated = false;
			}
			else if (Method.ReverseInstance != null)
			{
				EditMethod.ResetModified(Method.ReverseInstance.IsModified);
				if (EditMethod.Equals(Method.ReverseInstance))
				{
					// perform the update of EditMethod back to Method
					Method.TransformDataFromObject(EditMethod, null, false);
					Method.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditMethod back to Method
					Method.TransformDataFromObject(EditMethod, null, false);
					Method.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditMethod back to Method
				Method.TransformDataFromObject(EditMethod, null, false);
				Method.IsAutoUpdated = false;
			}
			Method.ForwardInstance = null;
			if (MethodNameCustomized || MethodTypeCodeCustomized || DescriptionCustomized || ParameterListCustomized || MethodRelationshipListCustomized || TagsCustomized)
			{
				Method.ForwardInstance = new Method();
				Method.ForwardInstance.MethodID = EditMethod.MethodID;
				Method.SpecSourceName = Method.DefaultSourceName;
				if (MethodNameCustomized)
				{
					Method.ForwardInstance.MethodName = EditMethod.MethodName;
				}
				if (MethodTypeCodeCustomized)
				{
					Method.ForwardInstance.MethodTypeCode = EditMethod.MethodTypeCode;
				}
				if (DescriptionCustomized)
				{
					Method.ForwardInstance.Description = EditMethod.Description;
				}
				if (ParameterListCustomized)
				{
					#region protected
					#endregion protected
					// Method.ParameterList = new EnterpriseDataObjectList<Parameter>(EditMethod.ParameterList, null);
					// Method.ForwardInstance.ParameterList = new EnterpriseDataObjectList<Parameter>(EditMethod.ParameterList, null);
				}
				if (MethodRelationshipListCustomized)
				{
					#region protected
					#endregion protected
					// Method.MethodRelationshipList = new EnterpriseDataObjectList<MethodRelationship>(EditMethod.MethodRelationshipList, null);
					// Method.ForwardInstance.MethodRelationshipList = new EnterpriseDataObjectList<MethodRelationship>(EditMethod.MethodRelationshipList, null);
				}
				if (TagsCustomized)
				{
					Method.ForwardInstance.Tags = EditMethod.Tags;
				}
			}
			EditMethod.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditMethodPerformed();

			// send update for any updated Parameters
			foreach (ParameterViewModel item in Parameters)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new Parameters
			foreach (ParameterViewModel item in ItemsToAdd.OfType<ParameterViewModel>())
			{
				item.Update();
				Parameters.Add(item);
			}

			// send delete for any deleted Parameters
			foreach (ParameterViewModel item in ItemsToDelete.OfType<ParameterViewModel>())
			{
				item.Delete();
				Parameters.Remove(item);
			}

			// reset modified for Parameters
			foreach (ParameterViewModel item in Parameters)
			{
				item.ResetModified(false);
			}

			// send update for any updated MethodRelationships
			foreach (MethodRelationshipViewModel item in MethodRelationships)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new MethodRelationships
			foreach (MethodRelationshipViewModel item in ItemsToAdd.OfType<MethodRelationshipViewModel>())
			{
				item.Update();
				MethodRelationships.Add(item);
			}

			// send delete for any deleted MethodRelationships
			foreach (MethodRelationshipViewModel item in ItemsToDelete.OfType<MethodRelationshipViewModel>())
			{
				item.Delete();
				MethodRelationships.Remove(item);
			}

			// reset modified for MethodRelationships
			foreach (MethodRelationshipViewModel item in MethodRelationships)
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
		public void SendEditMethodPerformed()
		{
			MethodEventArgs message = new MethodEventArgs();
			message.Method = Method;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodEventArgs>(MediatorMessages.Command_EditMethodPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Method command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteMethodCommand()
		{
			MethodEventArgs message = new MethodEventArgs();
			message.Method = Method;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<MethodEventArgs>(MediatorMessages.Command_DeleteMethodRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteMethodCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Parameter lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ParameterViewModel> Parameters { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets MethodRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<MethodRelationshipViewModel> MethodRelationships { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Method.</summary>
		///--------------------------------------------------------------------------------
		public Method Method { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodID.</summary>
		///--------------------------------------------------------------------------------
		public Guid MethodID
		{
			get
			{
				return Method.MethodID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Method.Name;
			}
			set
			{
				Method.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return Method.EntityID;
			}
			set
			{
				Method.EntityID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Method into the view model.</summary>
		/// 
		/// <param name="method">The Method to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadMethod(Method method, bool loadChildren = true)
		{
			// attach the Method
			Method = method;
			ItemID = Method.MethodID;
			Items.Clear();
			
			// initialize Parameters
			if (Parameters == null)
			{
				Parameters = new EnterpriseDataObjectList<ParameterViewModel>();
			}
			
			// initialize MethodRelationships
			if (MethodRelationships == null)
			{
				MethodRelationships = new EnterpriseDataObjectList<MethodRelationshipViewModel>();
			}
			if (loadChildren == true)
			{
				// attach Parameters
				foreach (Parameter item in method.ParameterList)
				{
					ParameterViewModel itemView = new ParameterViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					Parameters.Add(itemView);
					Items.Add(itemView);
				}
								
				// attach MethodRelationships
				foreach (MethodRelationship item in method.MethodRelationshipList)
				{
					MethodRelationshipViewModel itemView = new MethodRelationshipViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					MethodRelationships.Add(itemView);
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
				foreach (ParameterViewModel item in Parameters)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
				foreach (MethodRelationshipViewModel item in MethodRelationships)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Method.IsValid;
			HasCustomizations = Method.IsAutoUpdated == false || Method.IsEmptyMetadata(Method.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Method.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Method.IsAutoUpdated = true;
				Method.SpecSourceName = Method.ReverseInstance.SpecSourceName;
				Method.ResetModified(Method.ReverseInstance.IsModified);
				Method.ResetLoaded(Method.ReverseInstance.IsLoaded);
				if (!Method.IsIdenticalMetadata(Method.ReverseInstance))
				{
					HasCustomizations = true;
					Method.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Method.ForwardInstance = null;
				Method.ReverseInstance = null;
				Method.IsAutoUpdated = true;
			}
			foreach (ParameterViewModel item in Parameters)
			{
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			foreach (MethodRelationshipViewModel item in MethodRelationships)
			{
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			Items.Sort("ItemOrder", SortDirection.Ascending);
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
			if (Parameters != null)
			{
				for (int i = Parameters.Count - 1; i >= 0; i--)
				{
					Parameters[i].Updated -= Children_Updated;
					Parameters[i].Dispose();
					Parameters.Remove(Parameters[i]);
				}
				Parameters = null;
			}
			if (MethodRelationships != null)
			{
				for (int i = MethodRelationships.Count - 1; i >= 0; i--)
				{
					MethodRelationships[i].Updated -= Children_Updated;
					MethodRelationships[i].Dispose();
					MethodRelationships.Remove(MethodRelationships[i]);
				}
				MethodRelationships = null;
			}
			if (_editMethod != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditMethod.PropertyChanged -= EditMethod_PropertyChanged;
				EditMethod = null;
			}
			Method = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (ParameterViewModel item in Parameters)
			{
				if (item.HasCustomizations == true)
				{
					return true;
				}
			}
			foreach (MethodRelationshipViewModel item in MethodRelationships)
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
			OnPropertyChanged("ParameterList");
			OnPropertyChanged("ParameterListCustomized");
			OnPropertyChanged("MethodRelationshipList");
			OnPropertyChanged("MethodRelationshipListCustomized");
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
			if (data is ParameterEventArgs && (data as ParameterEventArgs).MethodID == Method.MethodID)
			{
				return this;
			}
			foreach (ParameterViewModel model in Parameters)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			if (data is MethodRelationshipEventArgs && (data as MethodRelationshipEventArgs).MethodID == Method.MethodID)
			{
				return this;
			}
			foreach (MethodRelationshipViewModel model in MethodRelationships)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of Parameter to the view model.</summary>
		/// 
		/// <param name="itemView">The Parameter to add.</param>
		///--------------------------------------------------------------------------------
		public void AddParameter(ParameterViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			Parameters.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of Parameter from the view model.</summary>
		/// 
		/// <param name="itemView">The Parameter to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteParameter(ParameterViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			Parameters.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public MethodViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="method">The Method to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public MethodViewModel(Method method, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadMethod(method, loadChildren);
		}

		#endregion "Constructors"
	}
}
