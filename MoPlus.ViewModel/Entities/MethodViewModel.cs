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
using MoPlus.ViewModel.Events.Entities;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the MethodViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/1/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class MethodViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodTypeCodeItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<MethodType> MethodTypeCodeItems
		{
			get
			{
				return DataConventionHelper.MethodTypes;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CustomItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ParameterViewModel> CustomItems
		{
			get
			{
				return Parameters;
			}
		}

		private EnterpriseDataObjectList<ParameterViewModel> _parameterItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ParameterItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ParameterViewModel> ParameterItems
		{
			get
			{
				if (_parameterItems == null)
				{
					_parameterItems = new EnterpriseDataObjectList<ParameterViewModel>(Parameters, false);
				}
				return _parameterItems;
			}
		}

		private EnterpriseDataObjectList<MethodRelationshipViewModel> _methodRelationshipItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodRelationshipItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<MethodRelationshipViewModel> MethodRelationshipItems
		{
			get
			{
				if (_methodRelationshipItems == null)
				{
					_methodRelationshipItems = new EnterpriseDataObjectList<MethodRelationshipViewModel>(MethodRelationships, false);
				}
				return _methodRelationshipItems;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public ParameterViewModel PasteParameter(ParameterViewModel copyItem, bool savePaste = true)
		{
			Parameter newItem = new Parameter();
			newItem.ReverseInstance = new Parameter();
			newItem.TransformDataFromObject(copyItem.Parameter, null, false);
			newItem.ParameterID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Entity by existing id first, second by old id, finally by name
			newItem.ReferencedEntity = Method.Entity.Feature.EntityList.FindByID((Guid)copyItem.Parameter.ReferencedEntityID);
			if (newItem.ReferencedEntity == null && Solution.PasteNewGuids[copyItem.Parameter.ReferencedEntityID.ToString()] is Guid)
			{
				newItem.ReferencedEntity = Method.Entity.Feature.EntityList.FindByID((Guid)Solution.PasteNewGuids[copyItem.Parameter.ReferencedEntityID.ToString()]);
			}
			if (newItem.ReferencedEntity == null)
			{
				newItem.ReferencedEntity = Method.Entity.Feature.EntityList.Find("Name", copyItem.Parameter.Name);
			}
			if (newItem.ReferencedEntity == null)
			{
				newItem.OldReferencedEntityID = newItem.ReferencedEntityID;
				newItem.ReferencedEntityID = Guid.Empty;
			}

			// try to find Property by existing id first, second by old id, finally by name
			if (newItem.ReferencedEntity != null)
			{
				newItem.ReferencedPropertyBase = newItem.ReferencedEntity.PropertyList.FindByID((Guid)copyItem.Parameter.ReferencedPropertyID);
				if (newItem.ReferencedPropertyBase == null && Solution.PasteNewGuids[copyItem.Parameter.ReferencedPropertyID.ToString()] is Guid)
				{
					newItem.ReferencedPropertyBase = newItem.ReferencedEntity.PropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.Parameter.ReferencedPropertyID.ToString()]);
				}
				if (newItem.ReferencedPropertyBase == null)
				{
					newItem.ReferencedPropertyBase = Solution.PropertyList.FindByID((Guid)copyItem.Parameter.ReferencedPropertyID);
					if (newItem.ReferencedPropertyBase != null && newItem.ReferencedPropertyBase is Property)
					{
						newItem.ReferencedPropertyBase = newItem.ReferencedEntity.PropertyList.Find(p => p.PropertyName == (newItem.ReferencedPropertyBase as Property).PropertyName);
					}
					if (newItem.ReferencedPropertyBase == null && copyItem.Parameter.ReferencedPropertyBase is Property)
					{
						newItem.ReferencedPropertyBase = newItem.ReferencedEntity.PropertyList.Find(p => p.PropertyName == (copyItem.Parameter.ReferencedPropertyBase as Property).PropertyName);
					}
				}
			}
			if (newItem.ReferencedPropertyBase == null)
			{
				newItem.OldReferencedPropertyID = newItem.ReferencedPropertyID;
				newItem.ReferencedPropertyID = Guid.Empty;
			}
			newItem.Method = Method;
			newItem.Solution = Solution;
			ParameterViewModel newView = new ParameterViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddParameter(newView);
			if (savePaste == true)
			{
				Solution.ParameterList.Add(newItem);
				Method.ParameterList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
