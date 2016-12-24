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
	/// <summary>This class provides views for PropertyInstance instances.</summary>
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/6/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class PropertyCollectionItemViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewPropertyInstance.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewPropertyInstance
		{
			get
			{
				return DisplayValues.ContextMenu_NewPropertyInstance;
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

		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelPropertyName.</summary>
		///--------------------------------------------------------------------------------
		public ModelProperty ModelProperty { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyName.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyName
		{
			get
			{
				return ModelProperty.ModelPropertyName;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ModelPropertyNameLabel
		{
			get
			{
				return ModelPropertyName + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsObjectInstanceListVisible.</summary>
		///--------------------------------------------------------------------------------
		public bool IsObjectInstanceListVisible
		{
			get
			{
				return ModelProperty.DefinedByModelObjectID != null && ModelProperty.DefinedByModelObjectID != Guid.Empty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ObjectInstanceListVisiblity.</summary>
		///--------------------------------------------------------------------------------
		public string ObjectInstanceListVisiblity
		{
			get
			{
				if (IsObjectInstanceListVisible) return "Visible";
				return "Collapsed";
			}
		}

		private EnterpriseDataObjectList<ObjectInstance> _objectInstanceListItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ObjectInstanceListItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ObjectInstance> ObjectInstanceListItems
		{
			get
			{
				if (_objectInstanceListItems == null)
				{
					_objectInstanceListItems = new EnterpriseDataObjectList<ObjectInstance>();
					if (IsObjectInstanceListVisible == true)
					{
						foreach (ObjectInstance instance in Solution.ObjectInstanceList.FindAll(i => i.ModelObjectID == ModelProperty.DefinedByModelObjectID))
						{
							_objectInstanceListItems.Add(instance);
						}
						_objectInstanceListItems.Insert(0, new ObjectInstance());
					}
					OnPropertyChanged("ValueVisibility");
					OnPropertyChanged("ValueListVisibility");
					OnPropertyChanged("ObjectInstanceListVisibility");
				}
				return _objectInstanceListItems;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsValueListVisible.</summary>
		///--------------------------------------------------------------------------------
		public bool IsValueListVisible
		{
			get
			{
				return IsObjectInstanceListVisible == false
					&& ModelProperty.DefinedByEnumerationID != null
					&& ModelProperty.DefinedByEnumerationID != Guid.Empty
					&& (ModelProperty.DefinedByValueID == null || ModelProperty.DefinedByValueID == Guid.Empty);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ValueListVisiblity.</summary>
		///--------------------------------------------------------------------------------
		public string ValueListVisiblity
		{
			get
			{
				if (IsValueListVisible) return "Visible";
				return "Collapsed";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsValueVisible.</summary>
		///--------------------------------------------------------------------------------
		public bool IsValueVisible
		{
			get
			{
				return IsObjectInstanceListVisible == false && IsValueListVisible == false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ValueVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string ValueVisibility
		{
			get
			{
				if (IsValueVisible) return "Visible";
				return "Collapsed";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ObjectInstanceViewModel.</summary>
		///--------------------------------------------------------------------------------
		public ObjectInstanceViewModel ObjectInstanceViewModel { get; set; }

		private EnterpriseDataObjectList<PropertyInstanceViewModel> _propertyInstances = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PropertyInstanceViewModel.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<PropertyInstanceViewModel> PropertyInstances
		{
			get
			{
				if (_propertyInstances == null)
				{
					_propertyInstances = new EnterpriseDataObjectList<PropertyInstanceViewModel>();
				}
				return _propertyInstances;
			}
			set
			{
				_propertyInstances = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyInstance adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewPropertyInstance()
		{
			PropertyInstanceViewModel item = new PropertyInstanceViewModel();
			item.PropertyInstance = new PropertyInstance();
			item.PropertyInstance.PropertyInstanceID = Guid.NewGuid();
			item.PropertyInstance.ObjectInstance = ObjectInstanceViewModel.EditObjectInstance;
			item.PropertyInstance.ObjectInstanceID = ObjectInstanceViewModel.EditObjectInstance.ObjectInstanceID;
			item.PropertyInstance.ModelPropertyID = ModelProperty.ModelPropertyID;
			item.PropertyInstance.Solution = Solution;
			item.Solution = Solution;

			ObjectInstanceViewModel.ItemsToAdd.Add(item);
			PropertyInstances.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to PropertyInstance deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedPropertyInstances(PropertyInstanceViewModel item)
		{
			ObjectInstanceViewModel.ItemsToDelete.Add(item);
			PropertyInstances.Remove(item);
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="propertyInstances">The PropertyInstance items to load.</param>
		/// <param name="modelProperty">The model property.</param>
		/// <param name="objectInstanceViewModel">The associated object instance view model.</param>
		/// <param name="solution">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public PropertyCollectionItemViewModel(EnterpriseDataObjectList<PropertyInstanceViewModel> propertyInstances, ModelProperty modelProperty, ObjectInstanceViewModel objectInstanceViewModel, Solution solution)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			PropertyInstances = propertyInstances;
			ObjectInstanceViewModel = objectInstanceViewModel;
			ModelProperty = modelProperty;
		}

		#endregion "Constructors"
	}
}
