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
using MoPlus.ViewModel.Events.Models;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Models;

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the ObjectInstanceViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>3/8/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ObjectInstanceViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		private EnterpriseDataObjectList<WorkspaceViewModel>_propertyItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items (children of any type).</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<WorkspaceViewModel> PropertyItems
		{
			get
			{
				if (_propertyItems == null)
				{
					_propertyItems = new EnterpriseDataObjectList<WorkspaceViewModel>();
					if (ObjectInstance.ModelObject == null)
					{
						ObjectInstance.ModelObject = Solution.ModelObjectList.Find(o => o.ModelObjectID == ObjectInstance.ModelObjectID);
					}
					foreach (ModelProperty property in ObjectInstance.ModelObject.ModelPropertyList)
					{
						if (property.IsCollection == true)
						{
							// create property collection item
							EnterpriseDataObjectList<PropertyInstanceViewModel> propertyInstances = new EnterpriseDataObjectList<PropertyInstanceViewModel>();
							foreach (PropertyInstanceViewModel instance in Items.OfType<PropertyInstanceViewModel>())
							{
								if (instance.ModelPropertyID == property.ModelPropertyID)
								{
									propertyInstances.Add(instance);
								}
							}
							PropertyCollectionItemViewModel propertyView = new PropertyCollectionItemViewModel(propertyInstances, property, this, Solution);
							PropertyItems.Add(propertyView);
						}
						else
						{
							// create property item
							PropertyInstanceViewModel propertyInstance = null;
							foreach (PropertyInstanceViewModel instance in Items.OfType<PropertyInstanceViewModel>())
							{
								if (instance.ModelPropertyID == property.ModelPropertyID)
								{
									propertyInstance = instance;
									break;
								}
							}
							if (propertyInstance == null)
							{
								PropertyInstance newProperty = new PropertyInstance();
								newProperty.Solution = Solution;
								newProperty.PropertyInstanceID = Guid.NewGuid();
								newProperty.ObjectInstance = ObjectInstance;
								newProperty.ModelProperty = property;
								newProperty.Order = property.Order;
								propertyInstance = new PropertyInstanceViewModel(newProperty, Solution, false);
								ItemsToAdd.Add(propertyInstance);
							}
							PropertyItemViewModel propertyView = new PropertyItemViewModel(propertyInstance, property, Solution);
							PropertyItems.Add(propertyView);
						}
					}
				}
				return _propertyItems;
			}
		}

		private EnterpriseDataObjectList<ObjectInstance> _parentObjectInstanceIDItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParentObjectInstanceIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ObjectInstance> ParentObjectInstanceIDItems
		{
			get
			{
				if (_parentObjectInstanceIDItems == null)
				{
					if (ObjectInstance.ModelObject == null)
					{
						ObjectInstance.ModelObject = Solution.ModelObjectList.Find(o => o.ModelObjectID == ObjectInstance.ModelObjectID);
					}
					_parentObjectInstanceIDItems = new EnterpriseDataObjectList<ObjectInstance>((from i in Solution.ObjectInstanceList
																					where i.ModelObjectID == ObjectInstance.ModelObject.ParentModelObjectID
																					select i).ToList<ObjectInstance>(), false);
					_parentObjectInstanceIDItems.Insert(0, new ObjectInstance());
				}
				return _parentObjectInstanceIDItems;
			}
		}

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
