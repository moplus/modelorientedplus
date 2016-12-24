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
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.Server;
using System.IO;
using MoPlus.Data;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Conventions;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Events.Models;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Workflows;
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides the view for the entire model.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize, change the Status value below to something
	/// other than Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/10/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class BuilderViewModel : WorkspaceViewModel
	{
		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method processes show getting started help messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ShowGettingStartedHelpRequested, ParameterType = typeof(EventArgs))]
		public void ProcessGettingStartedHelpRequested(EventArgs data)
		{
			ResourcesFolder.ShowGettingStartedHelp();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes show about help messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ShowAboutHelpRequested, ParameterType = typeof(EventArgs))]
		public void ProcessAboutHelpRequested(EventArgs data)
		{
			ResourcesFolder.ShowAboutHelp();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes open solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_OpenSolutionRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessOpenSolutionRequested(SolutionEventArgs data)
		{
			SolutionsFolder.LoadSolution(data.Path);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes save all solutions messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_SaveAllSolutionsRequested, ParameterType = typeof(EventArgs))]
		public void SaveAllSolutionsRequested(EventArgs data)
		{
			SolutionsFolder.SaveAllSolutions();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes reload model data messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ReloadModelDataRequested, ParameterType = typeof(ModelEventArgs))]
		public void ProcessReloadModelDataRequested(ModelEventArgs args)
		{
			if (args != null && args.Solution != null)
			{
				foreach (SolutionViewModel item in SolutionsFolder.Solutions)
				{
					if (item.Solution.SolutionID == args.Solution.SolutionID)
					{
						foreach (ModelViewModel model in item.ModelsFolder.Models)
						{
							if (model.ModelID == args.ModelID)
							{
								model.ModelDataFolder.ModelObjectDataItems = null;
								model.ModelDataFolder.LoadModelData(model.Model, item.Solution, true);
							}
						}
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies ObjectInstance updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditObjectInstancePerformed, ParameterType = typeof(ObjectInstanceEventArgs))]
		public void ProcessEditObjectInstancePerformed(ObjectInstanceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelObjectDataViewModel)
						{
							(parentView as ModelObjectDataViewModel).ProcessEditObjectInstancePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete ObjectInstance messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteObjectInstanceRequested, ParameterType = typeof(ObjectInstanceEventArgs))]
		public void ProcessDeleteObjectInstanceRequested(ObjectInstanceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is ModelObjectDataViewModel)
						{
							(parentView as ModelObjectDataViewModel).ProcessDeleteObjectInstancePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies DatabaseSource updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditDatabaseSourcePerformed, ParameterType = typeof(DatabaseSourceEventArgs))]
		public void ProcessEditDatabaseSourcePerformed(DatabaseSourceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is SpecificationSourcesViewModel)
						{
							(parentView as SpecificationSourcesViewModel).ProcessEditDatabaseSourcePerformed(data);
							solution.SpecTemplatesFolder.LoadSpecDirectories();
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete DatabaseSource messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteDatabaseSourceRequested, ParameterType = typeof(DatabaseSourceEventArgs))]
		public void ProcessDeleteDatabaseSourceRequested(DatabaseSourceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is SpecificationSourcesViewModel)
						{
							(parentView as SpecificationSourcesViewModel).ProcessDeleteDatabaseSourcePerformed(data);
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method applies XmlSource updates.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditXmlSourcePerformed, ParameterType = typeof(XmlSourceEventArgs))]
		public void ProcessEditXmlSourcePerformed(XmlSourceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is SpecificationSourcesViewModel)
						{
							(parentView as SpecificationSourcesViewModel).ProcessEditXmlSourcePerformed(data);
							solution.SpecTemplatesFolder.LoadSpecDirectories();
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes delete XmlSource messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DeleteXmlSourceRequested, ParameterType = typeof(XmlSourceEventArgs))]
		public void ProcessDeleteXmlSourceRequested(XmlSourceEventArgs data)
		{
			if (SolutionsFolder != null)
			{
				foreach (SolutionViewModel solution in SolutionsFolder.Solutions)
				{
					if (solution.Solution.SolutionID == data.Solution.SolutionID)
					{
						EditWorkspaceViewModel parentView = solution.FindParentViewModel(data);
						if (parentView is SpecificationSourcesViewModel)
						{
							(parentView as SpecificationSourcesViewModel).ProcessDeleteXmlSourcePerformed(data);
						}
						break;
					}
				}
			}
		}

		#endregion "Command Processing"

		#region "Events"
		#endregion "Events"

		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
