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
	/// <summary>This class provides views for IndexProperty instances.</summary>
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
	public partial class IndexPropertyViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewIndexProperty.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndexProperty
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndexProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlIndexPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelIndexPropertyToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndexPropertyToolTip;
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
				if (EditIndexProperty.IsModified == true)
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
				return string.IsNullOrEmpty(PropertyIDValidationMessage + OrderValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private IndexProperty _editIndexProperty = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditIndexProperty.</summary>
		///--------------------------------------------------------------------------------
		public IndexProperty EditIndexProperty
		{
			get
			{
				if (_editIndexProperty == null)
				{
					_editIndexProperty = new IndexProperty();
					_editIndexProperty.PropertyChanged += new PropertyChangedEventHandler(EditIndexProperty_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (IndexProperty != null)
					{
						_editIndexProperty.TransformDataFromObject(IndexProperty, null, false);
						_editIndexProperty.Solution = IndexProperty.Solution;
						_editIndexProperty.Property = IndexProperty.Property;
						_editIndexProperty.Index = IndexProperty.Index;
					}
					_editIndexProperty.ResetModified(false);
				}
				return _editIndexProperty;
			}
			set
			{
				_editIndexProperty = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditIndexProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditIndexProperty");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("PropertyID");
			OnPropertyChanged("PropertyIDCustomized");
			OnPropertyChanged("PropertyIDValidationMessage");
			
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
				return DisplayValues.Edit_IndexPropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_IndexPropertyHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IndexPropertyIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IndexPropertyIDLabel
		{
			get
			{
				return DisplayValues.Edit_IndexPropertyIDProperty + DisplayValues.Edit_LabelColon;
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
				return EditIndexProperty.PropertyID;
			}
			set
			{
				EditIndexProperty.PropertyID = value;
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
				if (IndexProperty.ReverseInstance != null)
				{
					return PropertyID.GetGuid() != IndexProperty.ReverseInstance.PropertyID.GetGuid();
				}
				else if (IndexProperty.IsAutoUpdated == true)
				{
					return PropertyID.GetGuid() != IndexProperty.PropertyID.GetGuid();
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
				return EditIndexProperty.ValidatePropertyID();
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
				return EditIndexProperty.Order;
			}
			set
			{
				EditIndexProperty.Order = value;
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
				if (IndexProperty.ReverseInstance != null)
				{
					return Order.GetInt() != IndexProperty.ReverseInstance.Order.GetInt();
				}
				else if (IndexProperty.IsAutoUpdated == true)
				{
					return Order.GetInt() != IndexProperty.Order.GetInt();
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
				return EditIndexProperty.ValidateOrder();
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
				return EditIndexProperty.Description;
			}
			set
			{
				EditIndexProperty.Description = value;
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
				if (IndexProperty.ReverseInstance != null)
				{
					return Description.GetString() != IndexProperty.ReverseInstance.Description.GetString();
				}
				else if (IndexProperty.IsAutoUpdated == true)
				{
					return Description.GetString() != IndexProperty.Description.GetString();
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
				return EditIndexProperty.ValidateDescription();
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
				return EditIndexProperty.SourceName;
			}
			set
			{
				EditIndexProperty.SourceName = value;
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
				return EditIndexProperty.SpecSourceName;
			}
			set
			{
				EditIndexProperty.SpecSourceName = value;
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
				return EditIndexProperty.Tags;
			}
			set
			{
				EditIndexProperty.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (IndexProperty.ReverseInstance != null)
				{
					return Tags != IndexProperty.ReverseInstance.Tags;
				}
				else if (IndexProperty.IsAutoUpdated == true)
				{
					return Tags != IndexProperty.Tags;
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
				return EditIndexProperty.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditIndexProperty.Name;
			}
			set
			{
				EditIndexProperty.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditIndexProperty.TransformDataFromObject(IndexProperty, null, false);
			EditIndexProperty.ResetModified(false);
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
			if (IndexProperty.ReverseInstance != null)
			{
				EditIndexProperty.TransformDataFromObject(IndexProperty.ReverseInstance, null, false);
			}
			else if (IndexProperty.IsAutoUpdated == true)
			{
				EditIndexProperty.TransformDataFromObject(IndexProperty, null, false);
			}
			else
			{
				IndexProperty newIndexProperty = new IndexProperty();
				newIndexProperty.IndexPropertyID = EditIndexProperty.IndexPropertyID;
				EditIndexProperty.TransformDataFromObject(newIndexProperty, null, false);
			}
			EditIndexProperty.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new IndexProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewIndexPropertyCommand()
		{
			IndexPropertyEventArgs message = new IndexPropertyEventArgs();
			message.IndexProperty = new IndexProperty();
			message.IndexProperty.IndexPropertyID = Guid.NewGuid();
			message.IndexProperty.IndexID = IndexID;
			message.IndexProperty.Index = Solution.IndexList.FindByID((Guid)IndexID);
			if (message.IndexProperty.Index != null)
			{
				message.IndexProperty.Order = message.IndexProperty.Index.IndexPropertyList.Count + 1;
			}
			message.IndexProperty.Solution = Solution;
			message.IndexID = IndexID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexPropertyEventArgs>(MediatorMessages.Command_EditIndexPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditIndexPropertyCommand()
		{
			IndexPropertyEventArgs message = new IndexPropertyEventArgs();
			message.IndexProperty = IndexProperty;
			message.IndexID = IndexID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexPropertyEventArgs>(MediatorMessages.Command_EditIndexPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewIndexPropertyCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (IndexProperty.ReverseInstance == null && IndexProperty.IsAutoUpdated == true)
			{
				IndexProperty.ReverseInstance = new IndexProperty();
				IndexProperty.ReverseInstance.TransformDataFromObject(IndexProperty, null, false);

				// perform the update of EditIndexProperty back to IndexProperty
				IndexProperty.TransformDataFromObject(EditIndexProperty, null, false);
				IndexProperty.IsAutoUpdated = false;
			}
			else if (IndexProperty.ReverseInstance != null)
			{
				EditIndexProperty.ResetModified(IndexProperty.ReverseInstance.IsModified);
				if (EditIndexProperty.Equals(IndexProperty.ReverseInstance))
				{
					// perform the update of EditIndexProperty back to IndexProperty
					IndexProperty.TransformDataFromObject(EditIndexProperty, null, false);
					IndexProperty.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditIndexProperty back to IndexProperty
					IndexProperty.TransformDataFromObject(EditIndexProperty, null, false);
					IndexProperty.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditIndexProperty back to IndexProperty
				IndexProperty.TransformDataFromObject(EditIndexProperty, null, false);
				IndexProperty.IsAutoUpdated = false;
			}
			IndexProperty.ForwardInstance = null;
			if (PropertyIDCustomized || OrderCustomized || DescriptionCustomized || TagsCustomized)
			{
				IndexProperty.ForwardInstance = new IndexProperty();
				IndexProperty.ForwardInstance.IndexPropertyID = EditIndexProperty.IndexPropertyID;
				IndexProperty.SpecSourceName = IndexProperty.DefaultSourceName;
				if (PropertyIDCustomized)
				{
					IndexProperty.ForwardInstance.PropertyID = EditIndexProperty.PropertyID;
				}
				if (OrderCustomized)
				{
					IndexProperty.ForwardInstance.Order = EditIndexProperty.Order;
				}
				if (DescriptionCustomized)
				{
					IndexProperty.ForwardInstance.Description = EditIndexProperty.Description;
				}
				if (TagsCustomized)
				{
					IndexProperty.ForwardInstance.Tags = EditIndexProperty.Tags;
				}
			}
			EditIndexProperty.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditIndexPropertyPerformed();
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
		public void SendEditIndexPropertyPerformed()
		{
			IndexPropertyEventArgs message = new IndexPropertyEventArgs();
			message.IndexProperty = IndexProperty;
			message.IndexID = IndexID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexPropertyEventArgs>(MediatorMessages.Command_EditIndexPropertyPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete IndexProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteIndexPropertyCommand()
		{
			IndexPropertyEventArgs message = new IndexPropertyEventArgs();
			message.IndexProperty = IndexProperty;
			message.IndexID = IndexID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexPropertyEventArgs>(MediatorMessages.Command_DeleteIndexPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteIndexPropertyCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IndexProperty.</summary>
		///--------------------------------------------------------------------------------
		public IndexProperty IndexProperty { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexPropertyID.</summary>
		///--------------------------------------------------------------------------------
		public Guid IndexPropertyID
		{
			get
			{
				return IndexProperty.IndexPropertyID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return IndexProperty.Name;
			}
			set
			{
				IndexProperty.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ItemOrder.</summary>
		///--------------------------------------------------------------------------------
		public int ItemOrder
		{
			get
			{
				return IndexProperty.Order;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IndexID.</summary>
		///--------------------------------------------------------------------------------
		public Guid IndexID
		{
			get
			{
				return IndexProperty.IndexID;
			}
			set
			{
				IndexProperty.IndexID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of IndexProperty into the view model.</summary>
		/// 
		/// <param name="indexProperty">The IndexProperty to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadIndexProperty(IndexProperty indexProperty, bool loadChildren = true)
		{
			// attach the IndexProperty
			IndexProperty = indexProperty;
			ItemID = IndexProperty.IndexPropertyID;
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
			
			HasErrors = !IndexProperty.IsValid;
			HasCustomizations = IndexProperty.IsAutoUpdated == false || IndexProperty.IsEmptyMetadata(IndexProperty.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && IndexProperty.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				IndexProperty.IsAutoUpdated = true;
				IndexProperty.SpecSourceName = IndexProperty.ReverseInstance.SpecSourceName;
				IndexProperty.ResetModified(IndexProperty.ReverseInstance.IsModified);
				IndexProperty.ResetLoaded(IndexProperty.ReverseInstance.IsLoaded);
				if (!IndexProperty.IsIdenticalMetadata(IndexProperty.ReverseInstance))
				{
					HasCustomizations = true;
					IndexProperty.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				IndexProperty.ForwardInstance = null;
				IndexProperty.ReverseInstance = null;
				IndexProperty.IsAutoUpdated = true;
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
			if (_editIndexProperty != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditIndexProperty.PropertyChanged -= EditIndexProperty_PropertyChanged;
				EditIndexProperty = null;
			}
			IndexProperty = null;
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
		public IndexPropertyViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="indexProperty">The IndexProperty to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public IndexPropertyViewModel(IndexProperty indexProperty, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadIndexProperty(indexProperty, loadChildren);
		}

		#endregion "Constructors"
	}
}
