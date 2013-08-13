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
	/// <summary>This class provides views for XmlSource instances.</summary>
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
	public partial class XmlSourceViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewXmlSource.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewXmlSource
		{
			get
			{
				return DisplayValues.ContextMenu_NewXmlSource;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlXmlSourceToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelXmlSourceToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewXmlSourceToolTip;
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
				if (EditXmlSource.IsModified == true)
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
				return string.IsNullOrEmpty(SourceFileNameValidationMessage + SourceFilePathValidationMessage + TemplatePathValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private XmlSource _editXmlSource = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditXmlSource.</summary>
		///--------------------------------------------------------------------------------
		public XmlSource EditXmlSource
		{
			get
			{
				if (_editXmlSource == null)
				{
					_editXmlSource = new XmlSource();
					_editXmlSource.PropertyChanged += new PropertyChangedEventHandler(EditXmlSource_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (XmlSource != null)
					{
						_editXmlSource.TransformDataFromObject(XmlSource, null, false);
						_editXmlSource.Solution = XmlSource.Solution;
					}
					_editXmlSource.ResetModified(false);
				}
				return _editXmlSource;
			}
			set
			{
				_editXmlSource = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditXmlSource_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditXmlSource");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("SourceFileName");
			OnPropertyChanged("SourceFileNameCustomized");
			OnPropertyChanged("SourceFileNameValidationMessage");
			
			OnPropertyChanged("SourceFilePath");
			OnPropertyChanged("SourceFilePathCustomized");
			OnPropertyChanged("SourceFilePathValidationMessage");
			
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
				return DisplayValues.Edit_XmlSourceHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_XmlSourceHeader + " (" + EditName + ")";
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
		/// <summary>This property gets the SourceFileNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceFileNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceFileNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SourceFileName.</summary>
		///--------------------------------------------------------------------------------
		public string SourceFileName
		{
			get
			{
				return EditXmlSource.SourceFileName;
			}
			set
			{
				EditXmlSource.SourceFileName = value;
				OnPropertyChanged("SourceFileName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceFileNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceFileNameCustomized
		{
			get
			{
				if (XmlSource.ReverseInstance != null)
				{
					return SourceFileName.GetString() != XmlSource.ReverseInstance.SourceFileName.GetString();
				}
				else if (XmlSource.IsAutoUpdated == true)
				{
					return SourceFileName.GetString() != XmlSource.SourceFileName.GetString();
				}
				return SourceFileName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceFileNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceFileNameValidationMessage
		{
			get
			{
				return EditXmlSource.ValidateSourceFileName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SourceFilePathLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceFilePathLabel
		{
			get
			{
				return DisplayValues.Edit_SourceFilePathProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SourceFilePath.</summary>
		///--------------------------------------------------------------------------------
		public string SourceFilePath
		{
			get
			{
				return EditXmlSource.SourceFilePath;
			}
			set
			{
				EditXmlSource.SourceFilePath = value;
				OnPropertyChanged("SourceFilePath");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceFilePathCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceFilePathCustomized
		{
			get
			{
				if (XmlSource.ReverseInstance != null)
				{
					return SourceFilePath.GetString() != XmlSource.ReverseInstance.SourceFilePath.GetString();
				}
				else if (XmlSource.IsAutoUpdated == true)
				{
					return SourceFilePath.GetString() != XmlSource.SourceFilePath.GetString();
				}
				return SourceFilePath != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceFilePathValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceFilePathValidationMessage
		{
			get
			{
				return EditXmlSource.ValidateSourceFilePath();
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
				return EditXmlSource.TemplatePath;
			}
			set
			{
				EditXmlSource.TemplatePath = value;
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
				if (XmlSource.ReverseInstance != null)
				{
					return TemplatePath.GetString() != XmlSource.ReverseInstance.TemplatePath.GetString();
				}
				else if (XmlSource.IsAutoUpdated == true)
				{
					return TemplatePath.GetString() != XmlSource.TemplatePath.GetString();
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
				return EditXmlSource.ValidateTemplatePath();
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
				return EditXmlSource.Order;
			}
			set
			{
				EditXmlSource.Order = value;
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
				if (XmlSource.ReverseInstance != null)
				{
					return Order.GetInt() != XmlSource.ReverseInstance.Order.GetInt();
				}
				else if (XmlSource.IsAutoUpdated == true)
				{
					return Order.GetInt() != XmlSource.Order.GetInt();
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
				return EditXmlSource.ValidateOrder();
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
				return EditXmlSource.Description;
			}
			set
			{
				EditXmlSource.Description = value;
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
				if (XmlSource.ReverseInstance != null)
				{
					return Description.GetString() != XmlSource.ReverseInstance.Description.GetString();
				}
				else if (XmlSource.IsAutoUpdated == true)
				{
					return Description.GetString() != XmlSource.Description.GetString();
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
				return EditXmlSource.ValidateDescription();
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
				return EditXmlSource.SourceName;
			}
			set
			{
				EditXmlSource.SourceName = value;
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
				return EditXmlSource.SpecSourceName;
			}
			set
			{
				EditXmlSource.SpecSourceName = value;
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
				return EditXmlSource.Tags;
			}
			set
			{
				EditXmlSource.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (XmlSource.ReverseInstance != null)
				{
					return Tags != XmlSource.ReverseInstance.Tags;
				}
				else if (XmlSource.IsAutoUpdated == true)
				{
					return Tags != XmlSource.Tags;
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
				return EditXmlSource.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditXmlSource.Name;
			}
			set
			{
				EditXmlSource.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditXmlSource.TransformDataFromObject(XmlSource, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditXmlSource.ResetModified(false);
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
			if (XmlSource.ReverseInstance != null)
			{
				EditXmlSource.TransformDataFromObject(XmlSource.ReverseInstance, null, false);
			}
			else if (XmlSource.IsAutoUpdated == true)
			{
				EditXmlSource.TransformDataFromObject(XmlSource, null, false);
			}
			else
			{
				XmlSource newXmlSource = new XmlSource();
				newXmlSource.SpecificationSourceID = EditXmlSource.SpecificationSourceID;
				EditXmlSource.TransformDataFromObject(newXmlSource, null, false);
			}
			EditXmlSource.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new XmlSource command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewXmlSourceCommand()
		{
			XmlSourceEventArgs message = new XmlSourceEventArgs();
			message.XmlSource = new XmlSource();
			message.XmlSource.SpecificationSourceID = Guid.NewGuid();
			message.XmlSource.SolutionID = SolutionID;
			message.XmlSource.Solution = Solution;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<XmlSourceEventArgs>(MediatorMessages.Command_EditXmlSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditXmlSourceCommand()
		{
			XmlSourceEventArgs message = new XmlSourceEventArgs();
			message.XmlSource = XmlSource;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<XmlSourceEventArgs>(MediatorMessages.Command_EditXmlSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewXmlSourceCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (XmlSource.ReverseInstance == null && XmlSource.IsAutoUpdated == true)
			{
				XmlSource.ReverseInstance = new XmlSource();
				XmlSource.ReverseInstance.TransformDataFromObject(XmlSource, null, false);

				// perform the update of EditXmlSource back to XmlSource
				XmlSource.TransformDataFromObject(EditXmlSource, null, false);
				XmlSource.IsAutoUpdated = false;
			}
			else if (XmlSource.ReverseInstance != null)
			{
				EditXmlSource.ResetModified(XmlSource.ReverseInstance.IsModified);
				if (EditXmlSource.Equals(XmlSource.ReverseInstance))
				{
					// perform the update of EditXmlSource back to XmlSource
					XmlSource.TransformDataFromObject(EditXmlSource, null, false);
					XmlSource.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditXmlSource back to XmlSource
					XmlSource.TransformDataFromObject(EditXmlSource, null, false);
					XmlSource.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditXmlSource back to XmlSource
				XmlSource.TransformDataFromObject(EditXmlSource, null, false);
				XmlSource.IsAutoUpdated = false;
			}
			XmlSource.ForwardInstance = null;
			if (SourceFileNameCustomized || SourceFilePathCustomized || TemplatePathCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				XmlSource.ForwardInstance = new XmlSource();
				XmlSource.ForwardInstance.SpecificationSourceID = EditXmlSource.SpecificationSourceID;
				XmlSource.SpecSourceName = XmlSource.DefaultSourceName;
				if (SourceFileNameCustomized)
				{
					XmlSource.ForwardInstance.SourceFileName = EditXmlSource.SourceFileName;
				}
				if (SourceFilePathCustomized)
				{
					XmlSource.ForwardInstance.SourceFilePath = EditXmlSource.SourceFilePath;
				}
				if (TemplatePathCustomized)
				{
					XmlSource.ForwardInstance.TemplatePath = EditXmlSource.TemplatePath;
				}
				if (OrderCustomized)
				{
					XmlSource.ForwardInstance.Order = EditXmlSource.Order;
				}
				if (DescriptionCustomized)
				{
					XmlSource.ForwardInstance.Description = EditXmlSource.Description;
				}
				if (TagsCustomized)
				{
					XmlSource.ForwardInstance.Tags = EditXmlSource.Tags;
				}
			}
			EditXmlSource.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditXmlSourcePerformed();
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
		public void SendEditXmlSourcePerformed()
		{
			XmlSourceEventArgs message = new XmlSourceEventArgs();
			message.XmlSource = XmlSource;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<XmlSourceEventArgs>(MediatorMessages.Command_EditXmlSourcePerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete XmlSource command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteXmlSourceCommand()
		{
			XmlSourceEventArgs message = new XmlSourceEventArgs();
			message.XmlSource = XmlSource;
			message.SolutionID = SolutionID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<XmlSourceEventArgs>(MediatorMessages.Command_DeleteXmlSourceRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteXmlSourceCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the XmlSource.</summary>
		///--------------------------------------------------------------------------------
		public XmlSource XmlSource { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecificationSourceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid SpecificationSourceID
		{
			get
			{
				return XmlSource.SpecificationSourceID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return XmlSource.Name;
			}
			set
			{
				XmlSource.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return XmlSource.Order;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of XmlSource into the view model.</summary>
		/// 
		/// <param name="xmlSource">The XmlSource to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadXmlSource(XmlSource xmlSource, bool loadChildren = true)
		{
			// attach the XmlSource
			XmlSource = xmlSource;
			ItemID = XmlSource.SpecificationSourceID;
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
			
			HasErrors = !XmlSource.IsValid;
			HasCustomizations = XmlSource.IsAutoUpdated == false || XmlSource.IsEmptyMetadata(XmlSource.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && XmlSource.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				XmlSource.IsAutoUpdated = true;
				XmlSource.SpecSourceName = XmlSource.ReverseInstance.SpecSourceName;
				XmlSource.ResetModified(XmlSource.ReverseInstance.IsModified);
				XmlSource.ResetLoaded(XmlSource.ReverseInstance.IsLoaded);
				if (!XmlSource.IsIdenticalMetadata(XmlSource.ReverseInstance))
				{
					HasCustomizations = true;
					XmlSource.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				XmlSource.ForwardInstance = null;
				XmlSource.ReverseInstance = null;
				XmlSource.IsAutoUpdated = true;
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
			if (_editXmlSource != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditXmlSource.PropertyChanged -= EditXmlSource_PropertyChanged;
				EditXmlSource = null;
			}
			XmlSource = null;
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
		public XmlSourceViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="xmlSource">The XmlSource to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public XmlSourceViewModel(XmlSource xmlSource, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadXmlSource(xmlSource, loadChildren);
		}

		#endregion "Constructors"
	}
}
