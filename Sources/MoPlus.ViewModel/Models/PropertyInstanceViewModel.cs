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
	/// This file is for adding customizations to the PropertyInstanceViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>3/7/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class PropertyInstanceViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsObjectInstanceListVisible.</summary>
		///--------------------------------------------------------------------------------
		public bool IsObjectInstanceListVisible
		{
			get
			{
				if (EditPropertyInstance.ModelProperty == null)
				{
					EditPropertyInstance.ModelProperty = Solution.ModelPropertyList.Find(p => p.ModelPropertyID == EditPropertyInstance.ModelPropertyID);
				}
				return EditPropertyInstance.ModelProperty.DefinedByModelObjectID != null && EditPropertyInstance.ModelProperty.DefinedByModelObjectID != Guid.Empty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the IsValueListVisible.</summary>
		///--------------------------------------------------------------------------------
		public bool IsValueListVisible
		{
			get
			{
				if (EditPropertyInstance.ModelProperty == null)
				{
					EditPropertyInstance.ModelProperty = Solution.ModelPropertyList.Find(p => p.ModelPropertyID == EditPropertyInstance.ModelPropertyID);
				}
				return IsObjectInstanceListVisible == false
					&& EditPropertyInstance.ModelProperty.DefinedByEnumerationID != null
					&& EditPropertyInstance.ModelProperty.DefinedByEnumerationID != Guid.Empty
					&& (EditPropertyInstance.ModelProperty.DefinedByValueID == null || EditPropertyInstance.ModelProperty.DefinedByValueID == Guid.Empty);
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

		private EnterpriseDataObjectList<ModelProperty> _modelPropertyIDItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelProperty> ModelPropertyIDItems
		{
			get
			{
				if (_modelPropertyIDItems == null)
				{
					_modelPropertyIDItems = new EnterpriseDataObjectList<ModelProperty>(Solution.ModelPropertyList.FindAll(p => p.ModelObjectID == PropertyInstance.ObjectInstance.ModelObjectID), false);
				}
				return _modelPropertyIDItems;
			}
		}

		private EnterpriseDataObjectList<Value> _valueListItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ValueListItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Value> ValueListItems
		{
			get
			{
				if (_valueListItems == null && IsValueListVisible == true)
				{
					_valueListItems = new EnterpriseDataObjectList<Value>();
					if (EditPropertyInstance.ModelProperty != null)
					{
						foreach (Value value in Solution.ValueList.FindAll(v => v.EnumerationID == EditPropertyInstance.ModelProperty.DefinedByEnumerationID))
						{
							_valueListItems.Add(value);
						}
						_valueListItems.Insert(0, new Value());
					}
				}
				return _valueListItems;
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
				if (_objectInstanceListItems == null && IsObjectInstanceListVisible == true)
				{
					_objectInstanceListItems = new EnterpriseDataObjectList<ObjectInstance>();
					if (EditPropertyInstance.ModelProperty != null)
					{
						foreach (ObjectInstance instance in Solution.ObjectInstanceList.FindAll(i => i.ModelObjectID == EditPropertyInstance.ModelProperty.DefinedByModelObjectID))
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
		/// <summary>This property gets/sets the SelectedObjectInstanceID.</summary>
		///--------------------------------------------------------------------------------
		public Guid SelectedObjectInstanceID
		{
			get
			{
				Guid selectedObjectInstanceID = Guid.Empty;
				Guid.TryParse(EditPropertyInstance.PropertyValue, out selectedObjectInstanceID);
				return selectedObjectInstanceID;
			}
			set
			{
				EditPropertyInstance.PropertyValue = value.ToString();
				OnPropertyChanged("SelectedObjectInstanceID");
			}
		}

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
