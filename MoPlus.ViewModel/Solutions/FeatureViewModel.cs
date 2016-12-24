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
using MoPlus.ViewModel.Entities;
using MoPlus.Interpreter.BLL.Entities;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the FeatureViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/17/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class FeatureViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste a new item.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public EntityViewModel PasteEntity(EntityViewModel copyItem, bool savePaste = true)
		{
			EntityViewModel newView = PasteEntityBasicData(copyItem, savePaste);
			PasteEntityExtendedData(newView, copyItem, savePaste);
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste the basic info for an entity, saving
		/// entity and property ids that can be referred to in the extended entity paste.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public EntityViewModel PasteEntityBasicData(EntityViewModel copyItem, bool savePaste = true)
		{
			Entity newItem = new Entity();
			newItem.ReverseInstance = new Entity();
			newItem.TransformDataFromObject(copyItem.Entity, null, false);
			newItem.EntityID = Guid.NewGuid();
			Solution.PasteNewGuids[copyItem.Entity.EntityID.ToString()] = newItem.EntityID;
			newItem.IsAutoUpdated = false;
			newItem.Feature = Feature;
			newItem.Solution = Solution;
			EntityViewModel newView = new EntityViewModel(newItem, Solution);
			newView.ResetModified(true);
			Entities.Add(newView);
			Add(newView);
			if (savePaste == true)
			{
				Solution.EntityList.Add(newItem);
				Feature.EntityList.Add(newItem);
				newView.OnUpdated(this, null);
				Solution.ResetModified(true);
			}

			// paste children
			foreach (PropertyViewModel childView in copyItem.PropertiesFolder.Properties)
			{
				newView.PropertiesFolder.PasteProperty(childView, savePaste);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method is used to copy/paste the extended info for an entity, utilizing
		/// new entity and property ids that are created in the basic entity paste.</summary>
		///
		/// <param name="copyItem">The item to copy/paste.</param>
		/// <param name="savePaste">Flag to determine whether to save the results of the paste.</param>
		///--------------------------------------------------------------------------------
		public EntityViewModel PasteEntityExtendedData(EntityViewModel newView, EntityViewModel copyItem, bool savePaste = true)
		{
			// paste children
			foreach (CollectionViewModel childView in copyItem.CollectionsFolder.Collections)
			{
				newView.CollectionsFolder.PasteCollection(childView, savePaste);
			}
			foreach (PropertyReferenceViewModel childView in copyItem.PropertyReferencesFolder.PropertyReferences)
			{
				newView.PropertyReferencesFolder.PastePropertyReference(childView, savePaste);
			}
			foreach (EntityReferenceViewModel childView in copyItem.EntityReferencesFolder.EntityReferences)
			{
				newView.EntityReferencesFolder.PasteEntityReference(childView, savePaste);
			}
			foreach (MethodViewModel childView in copyItem.MethodsFolder.Methods)
			{
				newView.MethodsFolder.PasteMethod(childView, savePaste);
			}
			foreach (IndexViewModel childView in copyItem.IndexesFolder.Indexes)
			{
				newView.IndexesFolder.PasteIndex(childView, savePaste);
			}
			foreach (RelationshipViewModel childView in copyItem.RelationshipsFolder.Relationships)
			{
				newView.RelationshipsFolder.PasteRelationship(childView, savePaste);
			}
			return newView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds the entity view to the feature.</summary>
		/// 
		/// <param name="entityView">The entity view to add.</param>
		///--------------------------------------------------------------------------------
		public void AddEntityView(EntityViewModel entityView)
		{
			Entities.Add(entityView);
			Feature.EntityList.Add(entityView.Entity);
			Items.Add(entityView);
			OnUpdated(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes the entity view from the feature.</summary>
		/// 
		/// <param name="entityView">The entity view to remove.</param>
		///--------------------------------------------------------------------------------
		public void RemoveEntityView(EntityViewModel entityView)
		{
			Feature.EntityList.Remove(entityView.Entity);
			Entities.Remove(entityView);
			Items.Remove(entityView);
			OnUpdated(this, null);
		}
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
