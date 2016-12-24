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
	/// This file is for adding customizations to the ModelObjectViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>3/6/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelObjectViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		private EnterpriseDataObjectList<ModelPropertyViewModel> _modelPropertyItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ModelPropertyItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelPropertyViewModel> ModelPropertyItems
		{
			get
			{
				if (_modelPropertyItems == null)
				{
					_modelPropertyItems = new EnterpriseDataObjectList<ModelPropertyViewModel>(ModelProperties, false);
				}
				return _modelPropertyItems;
			}
		}

		private EnterpriseDataObjectList<ModelObject> _parentModelObjectIDItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParentModelObjectIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelObject> ParentModelObjectIDItems
		{
			get
			{
				if (_parentModelObjectIDItems == null)
				{
					_parentModelObjectIDItems = new EnterpriseDataObjectList<ModelObject>(Solution.ModelObjectList.FindAll(m => m.ModelID == ModelID), false);
					_parentModelObjectIDItems.Insert(0, new ModelObject());
				}
				return _parentModelObjectIDItems;
			}
		}

		#endregion "Properties"

		#region "Methods"
		/////--------------------------------------------------------------------------------
		///// <summary>This method adds to ModelProperty adds.</summary>
		/////--------------------------------------------------------------------------------
		//public void AddNewModelProperty()
		//{
		//    ModelPropertyViewModel item = new ModelPropertyViewModel();
		//    item.ModelProperty = new ModelProperty();
		//    item.ModelProperty.ModelPropertyID = Guid.NewGuid();
		//    item.ModelProperty.ModelObject = EditModelObject;
		//    item.ModelProperty.ModelObjectID = EditModelObject.ModelObjectID;
		//    item.ModelProperty.Solution = Solution;
		//    item.Solution = Solution;

		//    ModelPropertiesFolder.ItemsToAdd.Add(item);
		//    ModelPropertiesFolder.Items.Add(item);
		//    ModelPropertyItems.Add(item);
		//}

		/////--------------------------------------------------------------------------------
		///// <summary>This method adds to ModelProperty deletes.</summary>
		/////--------------------------------------------------------------------------------
		//public void AddToDeletedModelProperties(ModelPropertyViewModel item)
		//{
		//    ModelPropertiesFolder.ItemsToDelete.Add(item);
		//    ModelPropertiesFolder.Items.Remove(item);
		//    ModelPropertyItems.Remove(item);
		//}

		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
