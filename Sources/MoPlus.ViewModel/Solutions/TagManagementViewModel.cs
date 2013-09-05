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
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using System.Collections.ObjectModel;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Resources;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the TagManagementViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>2/13/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class TagManagementViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title
		{
			get
			{
				return DisplayValues.Edit_TagManagementHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_TagManagementHeader + " (" + Solution.SolutionName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TagLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TagLabel
		{
			get
			{
				return DisplayValues.Edit_TagProperty + DisplayValues.Edit_LabelColon;
			}
		}

		private SortableObservableCollection<string> _availableTags = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets AvailableTags.</summary>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection<string> AvailableTags
		{
			get
			{
				if (_availableTags == null)
				{
					_availableTags = new SortableObservableCollection<string>();
					if (UsedTags is NameObjectCollection)
					{
						NameObjectCollection tags = UsedTags as NameObjectCollection;
						foreach (string tag in tags.AllKeys)
						{
							_availableTags.Add(tag);
						}
					}
					_availableTags.Sort(s => s, ListSortDirection.Ascending);
				}
				return _availableTags;
			}
		}

		private string _selectedTag = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SelectedTag.</summary>
		///--------------------------------------------------------------------------------
		public string SelectedTag
		{
			get
			{
				return _selectedTag;
			}
			set
			{
				_selectedTag = value;
				OnPropertyChanged("SelectedTag");
				UpdateItemsToTag();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TagNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TagNameLabel
		{
			get
			{
				return DisplayValues.Edit_TagNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		private string _tagName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets TagName.</summary>
		///--------------------------------------------------------------------------------
		public string TagName
		{
			get
			{
				return _tagName;
			}
			set
			{
				_tagName = value;
				OnPropertyChanged("TagName");
				OnPropertyChanged("TagNameValidationMessage");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets TagNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TagNameValidationMessage
		{
			get
			{
				if (!String.IsNullOrEmpty(TagName) && TagName.Contains(" ") == true)
				{
					return DisplayValues.Validation_TagName;
				}
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the NodeNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NodeNameLabel
		{
			get
			{
				return DisplayValues.Edit_NodeNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		public SortableObservableCollection<string> _nodes = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets Nodes.</summary>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection<string> Nodes
		{
			get
			{
				if (_nodes == null)
				{
					_nodes = new SortableObservableCollection<string>(DataConventionHelper.CodeTemplateNodes);
					_nodes.Sort(s => s, ListSortDirection.Ascending);
				}
				return _nodes;
			}
		}

		private string _selectedNode = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SelectedNode.</summary>
		///--------------------------------------------------------------------------------
		public string SelectedNode
		{
			get
			{
				return _selectedNode;
			}
			set
			{
				_selectedNode = value;
				OnPropertyChanged("SelectedNode");
				UpdateItemsToTag();
			}
		}


		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TaggedItemsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TaggedItemsLabel
		{
			get
			{
				return DisplayValues.Edit_TaggedItemsProperty + DisplayValues.Edit_LabelColon;
			}
		}

		private SortableObservableCollection<WorkspaceViewModel> _itemsToTag = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ItemsToTag.</summary>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection<WorkspaceViewModel> ItemsToTag
		{
			get
			{
				if (_itemsToTag == null)
				{
					_itemsToTag = new SortableObservableCollection<WorkspaceViewModel>();
				}
				return _itemsToTag;
			}
			set
			{
				_itemsToTag = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ItemsTagged.</summary>
		///--------------------------------------------------------------------------------
		public NameObjectCollection ItemsTagged { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SelectAllLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SelectAllLabel
		{
			get
			{
				return DisplayValues.Select_All;
			}
		}

		private bool _selectAll = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets SelectAll.</summary>
		///--------------------------------------------------------------------------------
		public bool SelectAll
		{
			get
			{
				return _selectAll;
			}
			set
			{
				_selectAll = value;
				OnPropertyChanged("SelectAll");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the AddButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string AddButtonLabel
		{
			get
			{
				return DisplayValues.Button_Add;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if an update can be done.</summary>
		///--------------------------------------------------------------------------------
		protected override bool CanUpdate()
		{
			return ItemsToTag.Count > 0;
		}

		#endregion "Editing Support"

		#region "Command Processing"
		private RelayCommand _addCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to initiate adds.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand AddCommand
		{
			get
			{
				if (_addCommand == null)
				{
					_addCommand = new RelayCommand(param => this.OnAdd(), param => this.CanAdd());
				}

				return _addCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the tag can be added to the list.</summary>
		///--------------------------------------------------------------------------------
		protected bool CanAdd()
		{
			return !String.IsNullOrEmpty(TagName) && String.IsNullOrEmpty(TagNameValidationMessage);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a tag to the list of tags (not to the solution).</summary>
		///--------------------------------------------------------------------------------
		protected void OnAdd()
		{
			if (AvailableTags.Contains(TagName) == false)
			{
				AvailableTags.Add(TagName);
			}
			AvailableTags.Sort(s => s, ListSortDirection.Ascending);
			TagName = null;
			OnPropertyChanged("AvailableTags");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			foreach (WorkspaceViewModel view in ItemsToTag)
			{
				if (view.IsSelected == true)
				{
					if (ItemsTagged[view.ItemID.ToString()] == null)
					{
						// add tag
						view.Item.AddTag(SelectedTag);
						AddTagToUsedTags(view.ItemID, SelectedTag);
					}
				}
				else
				{
					if (ItemsTagged[view.ItemID.ToString()] != null)
					{
						// remove tag
						view.Item.RemoveTag(SelectedTag);
						RemoveTagFromUsedTags(view.ItemID, SelectedTag);
					}
				}
			}
			ItemsTagged = null;
			SelectedTag = null;
			SelectAll = false;

			// refresh solution
			SolutionEventArgs message = new SolutionEventArgs();
			message.Solution = Solution;
			message.SolutionID = Solution.SolutionID;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_RefreshSolutionRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		public void Update()
		{
			OnUpdate();
		}

		#endregion "Command Processing"

		#region "Properties"
		private NameObjectCollection _usedTags = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the set of UsedTags.</summary>
		///--------------------------------------------------------------------------------
		public NameObjectCollection UsedTags
		{
			get
			{
				if (_usedTags == null)
				{
					_usedTags = new NameObjectCollection();
				}
				return _usedTags;
			}
			set
			{
				_usedTags = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method determines if an item has a particular tag in UsedTags.</summary>
		/// 
		/// <param name="tagName">The named tag dictionary.</param>
		/// <param name="itemID">The ID for the item in the named tag dictionary.</param>
		///--------------------------------------------------------------------------------
		public bool ItemHasTag(string tagName, Guid itemID)
		{
			if (UsedTags[tagName] is NameObjectCollection && (UsedTags[tagName] as NameObjectCollection)[itemID.ToString()] != null)
			{
				return true;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an item's tag to the UsedTags.</summary>
		/// 
		/// <param name="itemID">Input item id.</param>
		/// <param name="tagName">Input tag name.</param>
		///--------------------------------------------------------------------------------
		public void AddTagToUsedTags(Guid itemID, string tagName)
		{
			if (UsedTags[tagName] is NameObjectCollection)
			{
				(UsedTags[tagName] as NameObjectCollection).Add(itemID.ToString(), true);
			}
			else
			{
				UsedTags[tagName] = new NameObjectCollection();
				(UsedTags[tagName] as NameObjectCollection).Add(itemID.ToString(), true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an item's tag to the UsedTags.</summary>
		/// 
		/// <param name="itemID">Input item id.</param>
		/// <param name="tagName">Input tag name.</param>
		///--------------------------------------------------------------------------------
		public void RemoveTagFromUsedTags(Guid itemID, string tagName)
		{
			if (UsedTags[tagName] is NameObjectCollection)
			{
				(UsedTags[tagName] as NameObjectCollection)[itemID.ToString()] = null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an item to the list of items to tag.</summary>
		/// 
		/// <param name="itemID">The ID of the item.</param>
		/// <param name="itemName">The name of the item.</param>
		/// <param name="item">The item.</param>
		///--------------------------------------------------------------------------------
		public void AddItemToTag(Guid itemID, string itemName, IDomainEnterpriseObject item)
		{
			WorkspaceViewModel view = new WorkspaceViewModel(itemID, itemName);
			view.Item = item;
			if (ItemHasTag(SelectedTag, itemID) == true)
			{
				view.IsSelected = true;
				ItemsTagged[itemID.ToString()] = true;
			}
			ItemsToTag.Add(view);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		public void AddTag()
		{
			if (TagNameValidationMessage != String.Empty && TagName != String.Empty)
			{
				if (AvailableTags.Contains(TagName) == false)
				{
					AvailableTags.Add(TagName);
				}
				TagName = String.Empty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		public void UpdateItemsToTag()
		{
			ItemsToTag = null;
			ItemsTagged = new NameObjectCollection();
			if (Solution != null && !String.IsNullOrEmpty(SelectedTag) && !String.IsNullOrEmpty(SelectedNode))
			{
				if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.AuditProperty))
				{
					foreach (AuditProperty item in Solution.AuditPropertyList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Collection))
				{
					foreach (Collection item in Solution.CollectionList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Entity))
				{
					foreach (Entity item in Solution.EntityList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.EntityReference))
				{
					foreach (EntityReference item in Solution.EntityReferenceList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Enumeration))
				{
					foreach (Enumeration item in Solution.EnumerationList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Feature))
				{
					foreach (Feature item in Solution.FeatureList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Index))
				{
					foreach (Index item in Solution.IndexList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.IndexProperty))
				{
					foreach (IndexProperty item in Solution.IndexPropertyList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Method))
				{
					foreach (Method item in Solution.MethodList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Model))
				{
					foreach (Model item in Solution.ModelList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelObject))
				{
					foreach (ModelObject item in Solution.ModelObjectList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelProperty))
				{
					foreach (ModelProperty item in Solution.ModelPropertyList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Parameter))
				{
					foreach (Parameter item in Solution.ParameterList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Project))
				{
					foreach (Project item in Solution.ProjectList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Property))
				{
					foreach (Property item in Solution.PropertyList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyReference))
				{
					foreach (PropertyReference item in Solution.PropertyReferenceList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Relationship))
				{
					foreach (Relationship item in Solution.RelationshipList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.RelationshipProperty))
				{
					foreach (RelationshipProperty item in Solution.RelationshipPropertyList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Solution))
				{
					AddItemToTag(Solution.ID, Solution.DisplayName, Solution);
				}
				else if (SelectedNode == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SpecificationSource))
				{
					foreach (SpecificationSource item in Solution.SpecificationSourceList)
					{
						AddItemToTag(item.ID, item.Name, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Stage))
				{
					foreach (Stage item in Solution.StageList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StageTransition))
				{
					foreach (StageTransition item in Solution.StageTransitionList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.State))
				{
					foreach (State item in Solution.StateList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateModel))
				{
					foreach (StateModel item in Solution.StateModelList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateTransition))
				{
					foreach (StateTransition item in Solution.StateTransitionList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Step))
				{
					foreach (Step item in Solution.StepList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StepTransition))
				{
					foreach (StepTransition item in Solution.StepTransitionList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Value))
				{
					foreach (Value item in Solution.ValueList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Workflow))
				{
					foreach (Workflow item in Solution.WorkflowList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Model))
				{
					foreach (Model item in Solution.ModelList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelObject))
				{
					foreach (ModelObject item in Solution.ModelObjectList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelProperty))
				{
					foreach (ModelProperty item in Solution.ModelPropertyList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Enumeration))
				{
					foreach (Enumeration item in Solution.EnumerationList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Value))
				{
					foreach (Value item in Solution.ValueList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ObjectInstance))
				{
					foreach (ObjectInstance item in Solution.ObjectInstanceList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
				else if (SelectedNode == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyInstance))
				{
					foreach (PropertyInstance item in Solution.PropertyInstanceList)
					{
						AddItemToTag(item.ID, item.DisplayName, item);
					}
				}
			}
			ItemsToTag.Sort(s => s.Name, ListSortDirection.Ascending);
			OnPropertyChanged("ItemsToTag");
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solution">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public TagManagementViewModel(Solution solution)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			Solution.AddItemToUsedTags(UsedTags);
		}

		#region protected
		#endregion protected
		
		#endregion "Constructors"
	}
}
