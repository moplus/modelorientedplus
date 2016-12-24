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
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Events;

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the ModelObjectViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/11/2014</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelDataViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObject lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelObjectDataViewModel> ModelObjectDataItems { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Model.</summary>
		///--------------------------------------------------------------------------------
		public Model Model { get; set; }
		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of ModelData into the view model.</summary>
		/// 
		/// <param name="model">The Model to load.</param>
		/// <param name="solution">The Solution to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadModelData(Model model, Solution solution, bool loadChildren = true)
		{
			// attach the model data
			Model = model;
			Solution = solution;
			ItemID = Model.ModelID;
			Items.Clear();
			if (loadChildren == true)
			{
				// attach ModelObjectDataItems
				if (ModelObjectDataItems == null)
				{
					ModelObjectDataItems = new EnterpriseDataObjectList<ModelObjectDataViewModel>();
					foreach (ModelObject loopObject in model.ModelObjectList)
					{
						if (loopObject.ParentModelObjectID == null)
						{
							ModelObjectDataViewModel modelObjectDataViewModel = new ModelObjectDataViewModel(model, loopObject, null, solution, loadChildren);
							modelObjectDataViewModel.Updated += new EventHandler(Children_Updated);
							ModelObjectDataItems.Add(modelObjectDataViewModel);
							Items.Add(modelObjectDataViewModel);
						}
					}
				}
				#region protected
				#endregion protected

				Refresh(false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			HasErrors = !IsValid;
			HasCustomizations = false;
			if (refreshChildren == true || refreshLevel > 0)
			{
				foreach (ModelObjectDataViewModel item in ModelObjectDataItems)
				{
					item.Refresh(refreshChildren, refreshLevel-1);
				}
			}
			foreach (ModelObjectDataViewModel item in ModelObjectDataItems)
			{
				if (item.HasCustomizations == true)
				{
					HasCustomizations = true;
				}
				if (item.HasErrors == true)
				{
					HasErrors = true;
				}
			}
			Items.Sort("Name", SortDirection.Ascending);
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (ModelObjectDataItems != null)
			{
				foreach (ModelObjectDataViewModel itemView in ModelObjectDataItems)
				{
					itemView.Updated -= Children_Updated;
					itemView.Dispose();
				}
				ModelObjectDataItems.Clear();
				ModelObjectDataItems = null;
			}
			Model = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method manages the update of this view when children are updated.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_Updated(object sender, EventArgs e)
		{
			Refresh(false, 1);
			OnUpdated(this, e);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method returns the parent view model corresponding to
		/// the input message.</summary>
		///
		/// <param name="data">The message data to find parent for.</param>
		///--------------------------------------------------------------------------------
		public EditWorkspaceViewModel FindParentViewModel(SolutionModelEventArgs data)
		{
			if (data is ModelObjectEventArgs && (data as ModelObjectEventArgs).ModelID == Model.ModelID)
			{
				return this;
			}
			EditWorkspaceViewModel parentModel = null;

			foreach (ModelObjectDataViewModel model in ModelObjectDataItems)
			{
				parentModel = model.FindParentViewModel(data);
				if (parentModel != null)
				{
					return parentModel;
				}
			}
			
			return null;
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public ModelDataViewModel()
		{
			Name = Resources.DisplayValues.NodeName_ModelData;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		///
		/// <param name="model">The model to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public ModelDataViewModel(Model model, Solution solution, bool loadChildren = true)
		{
			Name = Resources.DisplayValues.NodeName_ModelData;
			Solution = solution;
			Model = model;
			LoadModelData(model, solution, loadChildren);
		}

		#endregion "Constructors"
	}
}
