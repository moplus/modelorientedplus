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
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.ViewModel.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the RelationshipViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/1/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class RelationshipViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedEntityIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Entity> ReferencedEntityIDItems
		{
			get
			{
				return Solution.EntityList;
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
		public RelationshipPropertyViewModel PasteRelationshipProperty(RelationshipPropertyViewModel copyItem, bool savePaste = true)
		{
			RelationshipProperty newItem = new RelationshipProperty();
			newItem.ReverseInstance = new RelationshipProperty();
			newItem.TransformDataFromObject(copyItem.RelationshipProperty, null, false);
			newItem.RelationshipPropertyID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			// try to find Property by existing id first, second by old id, finally by name
			newItem.Property = Relationship.Entity.PropertyList.FindByID((Guid)copyItem.RelationshipProperty.PropertyID);
			if (newItem.Property == null && Solution.PasteNewGuids[copyItem.RelationshipProperty.PropertyID.ToString()] is Guid)
			{
				newItem.Property = Relationship.Entity.PropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.RelationshipProperty.PropertyID.ToString()]);
			}
			if (newItem.Property == null)
			{
				newItem.Property = Relationship.Entity.PropertyList.Find("Name", copyItem.RelationshipProperty.PropertyName);
			}
			if (newItem.Property == null)
			{
				newItem.OldPropertyID = newItem.PropertyID;
				newItem.PropertyID = Guid.Empty;
			}

			// try to find Property by existing id first, second by old id, finally by name
			newItem.ReferencedProperty = Relationship.Entity.PropertyList.FindByID((Guid)copyItem.RelationshipProperty.ReferencedPropertyID);
			if (Relationship.ReferencedEntity == null)
			{
				Relationship.ReferencedEntity = Solution.EntityList.FindByID(Relationship.ReferencedEntityID);
			}
			if (Relationship.ReferencedEntity == null && copyItem.RelationshipProperty.Relationship.ReferencedEntity != null)
			{
				Feature feature = Solution.FeatureList.Find(f => f.FeatureName == copyItem.RelationshipProperty.Relationship.ReferencedEntity.FeatureName);
				if (feature != null)
				{
					Relationship.ReferencedEntity = feature.EntityList.Find(e => e.EntityName == copyItem.RelationshipProperty.Relationship.ReferencedEntity.EntityName);
				}
				else
				{
					Relationship.ReferencedEntity = Solution.EntityList.Find(e => e.EntityName == copyItem.RelationshipProperty.Relationship.ReferencedEntity.EntityName);
				}
			}
			if (Relationship.ReferencedEntity != null)
			{
				if (newItem.ReferencedProperty == null && Solution.PasteNewGuids[copyItem.RelationshipProperty.ReferencedPropertyID.ToString()] is Guid)
				{
					newItem.ReferencedProperty = Relationship.ReferencedEntity.PropertyList.FindByID((Guid)Solution.PasteNewGuids[copyItem.RelationshipProperty.ReferencedPropertyID.ToString()]);
				}
				if (newItem.ReferencedProperty == null)
				{
					newItem.ReferencedProperty = Relationship.ReferencedEntity.PropertyList.Find("Name", copyItem.RelationshipProperty.ReferencedPropertyName);
				}
				if (newItem.ReferencedProperty == null && copyItem.RelationshipProperty.ReferencedProperty != null)
				{
					newItem.ReferencedProperty = Relationship.ReferencedEntity.PropertyList.Find(p => p.PropertyName == copyItem.RelationshipProperty.ReferencedProperty.PropertyName);
				}
			}
			if (newItem.ReferencedProperty == null)
			{
				newItem.OldReferencedPropertyID = newItem.ReferencedPropertyID;
				newItem.ReferencedPropertyID = Guid.Empty;
			}
			newItem.Relationship = Relationship;
			newItem.Solution = Solution;
			RelationshipPropertyViewModel newView = new RelationshipPropertyViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddRelationshipProperty(newView);
			if (savePaste == true)
			{
				Solution.RelationshipPropertyList.Add(newItem);
				Relationship.RelationshipPropertyList.Add(newItem);
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
