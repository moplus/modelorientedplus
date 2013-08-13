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
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.ViewModel.Workflows
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the StageViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/18/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class StageViewModel : DialogEditWorkspaceViewModel
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
		/// <summary>This method adds to StageTransition adds.</summary>
		///--------------------------------------------------------------------------------
		public void AddNewStageTransition()
		{
			StageTransitionViewModel item = new StageTransitionViewModel();
			item.StageTransition = new StageTransition();
			item.StageTransition.StageTransitionID = Guid.NewGuid();
			item.StageTransition.ToStage = Stage;
			item.StageTransition.ToStageID = Stage.StageID;
			item.StageTransition.Solution = Solution;
			item.Solution = Solution;

			#region protected
			#endregion protected

			StageTransitionsFolder.ItemsToAdd.Add(item);
			StageTransitionsFolder.Items.Add(item);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds to StageTransition deletes.</summary>
		///--------------------------------------------------------------------------------
		public void AddToDeletedStageTransitions(StageTransitionViewModel item)
		{
			StageTransitionsFolder.ItemsToDelete.Add(item);
			StageTransitionsFolder.Items.Remove(item);
		}

		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
