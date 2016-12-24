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
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Entities;
using MoPlus.Data;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the FeaturesViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>4/82013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class FeaturesViewModel : EditWorkspaceViewModel
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
		public FeatureViewModel PasteFeature(FeatureViewModel copyItem, bool savePaste = true)
		{
			Feature newItem = new Feature();
			newItem.ReverseInstance = new Feature();
			newItem.TransformDataFromObject(copyItem.Feature, null, false);
			newItem.FeatureID = Guid.NewGuid();
			newItem.IsAutoUpdated = false;

			newItem.Solution = Solution;
			newItem.Solution = Solution;
			FeatureViewModel newView = new FeatureViewModel(newItem, Solution);
			newView.ResetModified(true);
			AddFeature(newView);

			// paste children
			List<EntityViewModel> entityViews = new List<EntityViewModel>();
			NameObjectCollection copyViews = new NameObjectCollection();
			foreach (EntityViewModel childView in copyItem.Entities)
			{
				EntityViewModel entityView = newView.PasteEntityBasicData(childView, savePaste);
				entityViews.Add(entityView);
				copyViews[entityView.WorkspaceID.ToString()] = childView;
			}
			foreach (EntityViewModel childView in entityViews)
			{
				newView.PasteEntityExtendedData(childView, copyViews[childView.WorkspaceID.ToString()] as EntityViewModel, savePaste);
			}
			if (savePaste == true)
			{
				Solution.FeatureList.Add(newItem);
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
