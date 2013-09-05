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
	/// <summary>This class provides views for Index instances.</summary>
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
	public partial class IndexViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewIndex.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndex
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndex;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlIndexToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelIndexToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewIndexToolTip;
			}
		}

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
		/// <summary>This property gets MenuLabelNewIndexPropertyToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewIndexPropertyToolTip
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
				if (EditIndex.IsModified == true)
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
				return string.IsNullOrEmpty(IndexNameValidationMessage + IsPrimaryKeyIndexValidationMessage + IsUniqueIndexValidationMessage + DescriptionValidationMessage + IndexPropertyListValidationMessage);
			}
		}
 
		private Index _editIndex = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditIndex.</summary>
		///--------------------------------------------------------------------------------
		public Index EditIndex
		{
			get
			{
				if (_editIndex == null)
				{
					_editIndex = new Index();
					_editIndex.PropertyChanged += new PropertyChangedEventHandler(EditIndex_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (Index != null)
					{
						_editIndex.TransformDataFromObject(Index, null, false);
						_editIndex.Solution = Index.Solution;
						_editIndex.Entity = Index.Entity;
					}
					_editIndex.ResetModified(false);
				}
				return _editIndex;
			}
			set
			{
				_editIndex = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditIndex_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditIndex");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("IndexName");
			OnPropertyChanged("IndexNameCustomized");
			OnPropertyChanged("IndexNameValidationMessage");
			
			OnPropertyChanged("IsPrimaryKeyIndex");
			OnPropertyChanged("IsPrimaryKeyIndexCustomized");
			OnPropertyChanged("IsPrimaryKeyIndexValidationMessage");
			
			OnPropertyChanged("IsUniqueIndex");
			OnPropertyChanged("IsUniqueIndexCustomized");
			OnPropertyChanged("IsUniqueIndexValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");
			
			OnPropertyChanged("IndexPropertyList");
			OnPropertyChanged("IndexPropertyListCustomized");
			OnPropertyChanged("IndexPropertyListValidationMessage");

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
				return DisplayValues.Edit_IndexHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_IndexHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IndexIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IndexIDLabel
		{
			get
			{
				return DisplayValues.Edit_IndexIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IndexPropertyListLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IndexPropertyListLabel
		{
			get
			{
				return DisplayValues.Edit_IndexPropertyListProperty + DisplayValues.Edit_LabelColon;
			}
		}

		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IndexPropertyList.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<IndexProperty> IndexPropertyList
		{
			get
			{
				return EditIndex.IndexPropertyList;
			}
			set
			{
				EditIndex.IndexPropertyList = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexPropertyListCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IndexPropertyListCustomized
		{
			get
			{
				#region protected
				foreach (IndexPropertyViewModel item in Items.OfType<IndexPropertyViewModel>())
				{
					if (item.HasCustomizations == true || item.IndexProperty.IsAutoUpdated == false)
					{
						return true;
					}
				}
				#endregion protected
			
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexPropertyListValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IndexPropertyListValidationMessage
		{
			get
			{
				#region protected
				#endregion protected
			
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IndexNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IndexNameLabel
		{
			get
			{
				return DisplayValues.Edit_IndexNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IndexName.</summary>
		///--------------------------------------------------------------------------------
		public string IndexName
		{
			get
			{
				return EditIndex.IndexName;
			}
			set
			{
				EditIndex.IndexName = value;
				OnPropertyChanged("IndexName");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IndexNameCustomized
		{
			get
			{
				if (Index.ReverseInstance != null)
				{
					return IndexName.GetString() != Index.ReverseInstance.IndexName.GetString();
				}
				else if (Index.IsAutoUpdated == true)
				{
					return IndexName.GetString() != Index.IndexName.GetString();
				}
				return IndexName != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IndexNameValidationMessage
		{
			get
			{
				return EditIndex.ValidateIndexName();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsPrimaryKeyIndexLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsPrimaryKeyIndexLabel
		{
			get
			{
				return DisplayValues.Edit_IsPrimaryKeyIndexProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsPrimaryKeyIndex.</summary>
		///--------------------------------------------------------------------------------
		public bool IsPrimaryKeyIndex
		{
			get
			{
				return EditIndex.IsPrimaryKeyIndex;
			}
			set
			{
				EditIndex.IsPrimaryKeyIndex = value;
				OnPropertyChanged("IsPrimaryKeyIndex");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsPrimaryKeyIndexCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsPrimaryKeyIndexCustomized
		{
			get
			{
				if (Index.ReverseInstance != null)
				{
					return IsPrimaryKeyIndex.GetBool() != Index.ReverseInstance.IsPrimaryKeyIndex.GetBool();
				}
				else if (Index.IsAutoUpdated == true)
				{
					return IsPrimaryKeyIndex.GetBool() != Index.IsPrimaryKeyIndex.GetBool();
				}
				return IsPrimaryKeyIndex != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsPrimaryKeyIndexValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsPrimaryKeyIndexValidationMessage
		{
			get
			{
				return EditIndex.ValidateIsPrimaryKeyIndex();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsUniqueIndexLabel.</summary>
		///--------------------------------------------------------------------------------
		public string IsUniqueIndexLabel
		{
			get
			{
				return DisplayValues.Edit_IsUniqueIndexProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsUniqueIndex.</summary>
		///--------------------------------------------------------------------------------
		public bool IsUniqueIndex
		{
			get
			{
				return EditIndex.IsUniqueIndex;
			}
			set
			{
				EditIndex.IsUniqueIndex = value;
				OnPropertyChanged("IsUniqueIndex");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsUniqueIndexCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsUniqueIndexCustomized
		{
			get
			{
				if (Index.ReverseInstance != null)
				{
					return IsUniqueIndex.GetBool() != Index.ReverseInstance.IsUniqueIndex.GetBool();
				}
				else if (Index.IsAutoUpdated == true)
				{
					return IsUniqueIndex.GetBool() != Index.IsUniqueIndex.GetBool();
				}
				return IsUniqueIndex != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsUniqueIndexValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string IsUniqueIndexValidationMessage
		{
			get
			{
				return EditIndex.ValidateIsUniqueIndex();
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
				return EditIndex.Description;
			}
			set
			{
				EditIndex.Description = value;
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
				if (Index.ReverseInstance != null)
				{
					return Description.GetString() != Index.ReverseInstance.Description.GetString();
				}
				else if (Index.IsAutoUpdated == true)
				{
					return Description.GetString() != Index.Description.GetString();
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
				return EditIndex.ValidateDescription();
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
				return EditIndex.SourceName;
			}
			set
			{
				EditIndex.SourceName = value;
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
				return EditIndex.SpecSourceName;
			}
			set
			{
				EditIndex.SpecSourceName = value;
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
				return EditIndex.Tags;
			}
			set
			{
				EditIndex.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (Index.ReverseInstance != null)
				{
					return Tags != Index.ReverseInstance.Tags;
				}
				else if (Index.IsAutoUpdated == true)
				{
					return Tags != Index.Tags;
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
				return EditIndex.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditIndex.Name;
			}
			set
			{
				EditIndex.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			EditIndex.TransformDataFromObject(Index, null, false);
			ResetItems();
			
			#region protected
			#endregion protected

			EditIndex.ResetModified(false);
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
			if (Index.ReverseInstance != null)
			{
				EditIndex.TransformDataFromObject(Index.ReverseInstance, null, false);
			}
			else if (Index.IsAutoUpdated == true)
			{
				EditIndex.TransformDataFromObject(Index, null, false);
			}
			else
			{
				Index newIndex = new Index();
				newIndex.IndexID = EditIndex.IndexID;
				EditIndex.TransformDataFromObject(newIndex, null, false);
			}
			EditIndex.ResetModified(true);
			foreach (IndexPropertyViewModel item in Items.OfType<IndexPropertyViewModel>())
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
		/// <summary>This method processes the new Index command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewIndexCommand()
		{
			IndexEventArgs message = new IndexEventArgs();
			message.Index = new Index();
			message.Index.IndexID = Guid.NewGuid();
			message.Index.EntityID = EntityID;
			message.Index.Entity = Solution.EntityList.FindByID((Guid)EntityID);
			message.Index.Solution = Solution;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexEventArgs>(MediatorMessages.Command_EditIndexRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditIndexCommand()
		{
			IndexEventArgs message = new IndexEventArgs();
			message.Index = Index;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexEventArgs>(MediatorMessages.Command_EditIndexRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to IndexProperty adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewIndexProperty()
		{
			IndexPropertyViewModel item = new IndexPropertyViewModel();
			item.IndexProperty = new IndexProperty();
			item.IndexProperty.IndexPropertyID = Guid.NewGuid();
			item.IndexProperty.Index = EditIndex;
			item.IndexProperty.IndexID = EditIndex.IndexID;
			item.IndexProperty.Solution = Solution;
			item.IndexProperty.Order = Index.IndexPropertyList.Count + 1;
			item.Solution = Solution;
			
			#region protected
			#endregion protected
			
			ItemsToAdd.Add(item);
			Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new IndexProperty command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewIndexPropertyCommand()
		{
			IndexPropertyEventArgs message = new IndexPropertyEventArgs();
			message.IndexProperty = new IndexProperty();
			message.IndexProperty.IndexPropertyID = Guid.NewGuid();
			message.IndexProperty.Index = Index;
			message.IndexProperty.IndexID = Index.IndexID;
			message.IndexID = Index.IndexID;
			if (message.IndexProperty.Index != null)
			{
				message.IndexProperty.Order = message.IndexProperty.Index.IndexPropertyList.Count + 1;
			}
			message.IndexProperty.Solution = Solution;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexPropertyEventArgs>(MediatorMessages.Command_EditIndexPropertyRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies IndexProperty updates.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditIndexPropertyPerformed(IndexPropertyEventArgs data)
		{
			if (data != null && data.IndexProperty != null)
			{
				UpdateEditIndexProperty(data.IndexProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates an item of IndexProperty.</summary>
		/// 
		/// <param name="indexProperty">The IndexProperty to update.</param>
		///--------------------------------------------------------------------------------
		public void UpdateEditIndexProperty(IndexProperty indexProperty)
		{
			bool isItemMatch = false;
			foreach (IndexPropertyViewModel item in IndexProperties)
			{
				if (item.IndexProperty.IndexPropertyID == indexProperty.IndexPropertyID)
				{
					isItemMatch = true;
					item.IndexProperty.TransformDataFromObject(indexProperty, null, false);
					if (!item.IndexProperty.PropertyID.IsNullOrEmpty())
					{
						item.IndexProperty.Property = Solution.PropertyList.FindByID((Guid)item.IndexProperty.PropertyID);
					}
					item.OnUpdated(item, null);
					item.ShowInTreeView();
					break;
				}
			}
			if (isItemMatch == false)
			{
				// add new IndexProperty
				indexProperty.Index = Index;
				IndexPropertyViewModel newItem = new IndexPropertyViewModel(indexProperty, Solution);
				if (!newItem.IndexProperty.PropertyID.IsNullOrEmpty())
				{
					newItem.IndexProperty.Property = Solution.PropertyList.FindByID((Guid)newItem.IndexProperty.PropertyID);
				}
				newItem.Updated += new EventHandler(Children_Updated);
				IndexProperties.Add(newItem);
				Index.IndexPropertyList.Add(indexProperty);
				Solution.IndexPropertyList.Add(newItem.IndexProperty);
				Items.Add(newItem);
				OnUpdated(this, null);
				newItem.ShowInTreeView();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to IndexProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedIndexProperties(IndexPropertyViewModel item)
		{
			ItemsToDelete.Add(item);
			Items.Remove(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies IndexProperty deletes.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteIndexPropertyPerformed(IndexPropertyEventArgs data)
		{
			if (data != null && data.IndexProperty != null)
			{
				DeleteIndexProperty(data.IndexProperty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of IndexProperty.</summary>
		/// 
		/// <param name="indexProperty">The IndexProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteIndexProperty(IndexProperty indexProperty)
		{
			bool isItemMatch = false;
			foreach (IndexPropertyViewModel item in IndexProperties.ToList<IndexPropertyViewModel>())
			{
				if (item.IndexProperty.IndexPropertyID == indexProperty.IndexPropertyID)
				{
					// remove item from tabs, if present
					WorkspaceEventArgs message = new WorkspaceEventArgs();
					message.ItemID = item.IndexProperty.IndexPropertyID;
					Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);

					// delete IndexProperty
					isItemMatch = true;
					IndexProperties.Remove(item);
					Index.IndexPropertyList.Remove(item.IndexProperty);
					Solution.IndexPropertyList.Remove(item.IndexProperty);
					Items.Remove(item);
					Index.ResetModified(true);
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
			ProcessNewIndexCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			// set up reverse engineering instance if not present
			if (Index.ReverseInstance == null && Index.IsAutoUpdated == true)
			{
				Index.ReverseInstance = new Index();
				Index.ReverseInstance.TransformDataFromObject(Index, null, false);

				// perform the update of EditIndex back to Index
				Index.TransformDataFromObject(EditIndex, null, false);
				Index.IsAutoUpdated = false;
			}
			else if (Index.ReverseInstance != null)
			{
				EditIndex.ResetModified(Index.ReverseInstance.IsModified);
				if (EditIndex.Equals(Index.ReverseInstance))
				{
					// perform the update of EditIndex back to Index
					Index.TransformDataFromObject(EditIndex, null, false);
					Index.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditIndex back to Index
					Index.TransformDataFromObject(EditIndex, null, false);
					Index.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditIndex back to Index
				Index.TransformDataFromObject(EditIndex, null, false);
				Index.IsAutoUpdated = false;
			}
			Index.ForwardInstance = null;
			if (IndexNameCustomized || IsPrimaryKeyIndexCustomized || IsUniqueIndexCustomized || DescriptionCustomized || IndexPropertyListCustomized || TagsCustomized)
			{
				Index.ForwardInstance = new Index();
				Index.ForwardInstance.IndexID = EditIndex.IndexID;
				Index.SpecSourceName = Index.DefaultSourceName;
				if (IndexNameCustomized)
				{
					Index.ForwardInstance.IndexName = EditIndex.IndexName;
				}
				if (IsPrimaryKeyIndexCustomized)
				{
					Index.ForwardInstance.IsPrimaryKeyIndex = EditIndex.IsPrimaryKeyIndex;
				}
				if (IsUniqueIndexCustomized)
				{
					Index.ForwardInstance.IsUniqueIndex = EditIndex.IsUniqueIndex;
				}
				if (DescriptionCustomized)
				{
					Index.ForwardInstance.Description = EditIndex.Description;
				}
				if (IndexPropertyListCustomized)
				{
					#region protected
					#endregion protected
					// Index.IndexPropertyList = new EnterpriseDataObjectList<IndexProperty>(EditIndex.IndexPropertyList, null);
					// Index.ForwardInstance.IndexPropertyList = new EnterpriseDataObjectList<IndexProperty>(EditIndex.IndexPropertyList, null);
				}
				if (TagsCustomized)
				{
					Index.ForwardInstance.Tags = EditIndex.Tags;
				}
			}
			EditIndex.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditIndexPerformed();

			// send update for any updated IndexProperties
			foreach (IndexPropertyViewModel item in IndexProperties)
			{
				if (item.IsEdited == true)
				{
					item.Update();
				}
			}
			// send update for any new IndexProperties
			foreach (IndexPropertyViewModel item in ItemsToAdd.OfType<IndexPropertyViewModel>())
			{
				item.Update();
				IndexProperties.Add(item);
			}

			// send delete for any deleted IndexProperties
			foreach (IndexPropertyViewModel item in ItemsToDelete.OfType<IndexPropertyViewModel>())
			{
				item.Delete();
				IndexProperties.Remove(item);
			}

			// reset modified for IndexProperties
			foreach (IndexPropertyViewModel item in IndexProperties)
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
		public void SendEditIndexPerformed()
		{
			IndexEventArgs message = new IndexEventArgs();
			message.Index = Index;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexEventArgs>(MediatorMessages.Command_EditIndexPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete Index command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteIndexCommand()
		{
			IndexEventArgs message = new IndexEventArgs();
			message.Index = Index;
			message.EntityID = EntityID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<IndexEventArgs>(MediatorMessages.Command_DeleteIndexRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteIndexCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IndexProperty lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<IndexPropertyViewModel> IndexProperties { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Index.</summary>
		///--------------------------------------------------------------------------------
		public Index Index { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexID.</summary>
		///--------------------------------------------------------------------------------
		public Guid IndexID
		{
			get
			{
				return Index.IndexID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Index.Name;
			}
			set
			{
				Index.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return Index.EntityID;
			}
			set
			{
				Index.EntityID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of Index into the view model.</summary>
		/// 
		/// <param name="index">The Index to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadIndex(Index index, bool loadChildren = true)
		{
			// attach the Index
			Index = index;
			ItemID = Index.IndexID;
			Items.Clear();
			
			// initialize IndexProperties
			if (IndexProperties == null)
			{
				IndexProperties = new EnterpriseDataObjectList<IndexPropertyViewModel>();
			}
			if (loadChildren == true)
			{
				// attach IndexProperties
				foreach (IndexProperty item in index.IndexPropertyList)
				{
					IndexPropertyViewModel itemView = new IndexPropertyViewModel(item, Solution);
					itemView.Updated += new EventHandler(Children_Updated);
					IndexProperties.Add(itemView);
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
				foreach (IndexPropertyViewModel item in IndexProperties)
				{
					item.Refresh(refreshChildren, refreshLevel - 1);
				}
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !Index.IsValid;
			HasCustomizations = Index.IsAutoUpdated == false || Index.IsEmptyMetadata(Index.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && Index.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				Index.IsAutoUpdated = true;
				Index.SpecSourceName = Index.ReverseInstance.SpecSourceName;
				Index.ResetModified(Index.ReverseInstance.IsModified);
				Index.ResetLoaded(Index.ReverseInstance.IsLoaded);
				if (!Index.IsIdenticalMetadata(Index.ReverseInstance))
				{
					HasCustomizations = true;
					Index.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				Index.ForwardInstance = null;
				Index.ReverseInstance = null;
				Index.IsAutoUpdated = true;
			}
			foreach (IndexPropertyViewModel item in IndexProperties)
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
			if (IndexProperties != null)
			{
				for (int i = IndexProperties.Count - 1; i >= 0; i--)
				{
					IndexProperties[i].Updated -= Children_Updated;
					IndexProperties[i].Dispose();
					IndexProperties.Remove(IndexProperties[i]);
				}
				IndexProperties = null;
			}
			if (_editIndex != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditIndex.PropertyChanged -= EditIndex_PropertyChanged;
				EditIndex = null;
			}
			Index = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			foreach (IndexPropertyViewModel item in IndexProperties)
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
			OnPropertyChanged("IndexPropertyList");
			OnPropertyChanged("IndexPropertyListCustomized");
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
			if (data is IndexPropertyEventArgs && (data as IndexPropertyEventArgs).IndexID == Index.IndexID)
			{
				return this;
			}
			foreach (IndexPropertyViewModel model in IndexProperties)
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
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public IndexPropertyViewModel PasteIndexProperty(IndexPropertyViewModel copyItem, bool savePaste = true)
		{
			IndexProperty newItem = new IndexProperty();
			newItem.ReverseInstance = new IndexProperty();
			newItem.TransformDataFromObject(copyItem.IndexProperty, null, false);
			newItem.IndexPropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Property by existing id first, second by old id, finally by name
			newItem.Property = Index.Entity.PropertyList.FindByID((Guid)copyItem.IndexProperty.PropertyID);
			if (newItem.Property == null && Solution.PasteNewGuids[copyItem.IndexProperty.PropertyID.ToString()] is Guid)
			{
				newItem.Property = Index.Entity.PropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.IndexProperty.PropertyID.ToString()]);
			}
			if (newItem.Property == null)
			{
				newItem.Property = Index.Entity.PropertyList.Find("Name", copyItem.IndexProperty.Name);
			}
			if (newItem.Property == null)
			{
				newItem.OldPropertyID = newItem.PropertyID;
				newItem.PropertyID = Guid.Empty;
			}
			newItem.Index = Index;
			newItem.Solution = Solution;
			IndexPropertyViewModel newView = new IndexPropertyViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddIndexProperty(newView);
			if (savePaste == true)
			{
				Solution.IndexPropertyList.Add(newItem);
				Index.IndexPropertyList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds an instance of IndexProperty to the view model.</summary>
		/// 
		/// <param name="itemView">The IndexProperty to add.</param>
		///--------------------------------------------------------------------------------
		public void AddIndexProperty(IndexPropertyViewModel itemView)
		{
			itemView.Updated += new EventHandler(Children_Updated);
			IndexProperties.Add(itemView);
			Add(itemView);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an instance of IndexProperty from the view model.</summary>
		/// 
		/// <param name="itemView">The IndexProperty to delete.</param>
		///--------------------------------------------------------------------------------
		public void DeleteIndexProperty(IndexPropertyViewModel itemView)
		{
			itemView.Updated -= Children_Updated;
			IndexProperties.Remove(itemView);
			Delete(itemView);
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public IndexViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="index">The Index to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public IndexViewModel(Index index, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadIndex(index, loadChildren);
		}

		#endregion "Constructors"
	}
}
