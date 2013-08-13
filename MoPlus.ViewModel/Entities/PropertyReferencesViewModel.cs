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
using MoPlus.Interpreter.BLL.Entities;

namespace MoPlus.ViewModel.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the PropertyReferencesViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/8/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class PropertyReferencesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public PropertyReferenceViewModel PastePropertyReference(PropertyReferenceViewModel copyItem, bool savePaste = true)
		{
			PropertyReference newItem = new PropertyReference();
			newItem.ReverseInstance = new PropertyReference();
			newItem.TransformDataFromObject(copyItem.PropertyReference, null, false);
			newItem.PropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Entity by existing id first, second by old id, finally by name
			newItem.ReferencedEntity = Solution.EntityList.FindByID((Guid)copyItem.PropertyReference.ReferencedEntityID);
			if (newItem.ReferencedEntity == null && Solution.PasteNewGuids[copyItem.PropertyReference.ReferencedEntityID.ToString()] is Guid)
			{
				newItem.ReferencedEntity = Solution.EntityList.FindByID((Guid)Solution.PasteNewGuids[copyItem.PropertyReference.ReferencedEntityID.ToString()]);
			}
			if (newItem.ReferencedEntity == null)
			{
				newItem.ReferencedEntity = Entity.Feature.EntityList.Find("Name", copyItem.PropertyReference.Name);
			}
			if (newItem.ReferencedEntity == null)
			{
				newItem.OldReferencedEntityID = newItem.ReferencedEntityID;
				newItem.ReferencedEntityID = Guid.Empty;
			}

			// try to find referenced Property by existing id first, second by old id, finally by name
			newItem.ReferencedProperty = Solution.PropertyList.FindByID((Guid)copyItem.PropertyReference.ReferencedPropertyID);
			if (newItem.ReferencedProperty == null && Solution.PasteNewGuids[copyItem.PropertyReference.ReferencedPropertyID.ToString()] is Guid)
			{
				newItem.ReferencedProperty = Solution.PropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.PropertyReference.ReferencedPropertyID.ToString()]);
			}
			if (newItem.ReferencedProperty == null)
			{
				newItem.ReferencedProperty = Solution.PropertyList.Find("Name", copyItem.PropertyReference.Name);
			}
			if (newItem.ReferencedProperty == null && newItem.ReferencedEntity != null && copyItem.PropertyReference.ReferencedProperty != null)
			{
				newItem.ReferencedProperty = newItem.ReferencedEntity.PropertyList.Find(p => p.PropertyName == copyItem.PropertyReference.ReferencedProperty.PropertyName);
			}
			if (newItem.ReferencedProperty == null)
			{
				newItem.OldReferencedPropertyID = newItem.ReferencedPropertyID;
				newItem.ReferencedPropertyID = Guid.Empty;
			}
			newItem.Entity = Entity;
			newItem.Solution = Solution;
			PropertyReferenceViewModel newView = new PropertyReferenceViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddPropertyReference(newView);

			// paste children
			if (savePaste == true)
			{
				Solution.PropertyReferenceList.Add(newItem);
				Entity.PropertyReferenceList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}
			return newView;
		}

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
