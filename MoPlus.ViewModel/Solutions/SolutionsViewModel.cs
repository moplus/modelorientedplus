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
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter;
using MoPlus.Data;
using System.IO;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SolutionsViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/27/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionsViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelOpenSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelOpenSolution
		{
			get
			{
				return DisplayValues.ContextMenu_OpenSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelOpenSolutionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelOpenSolutionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_OpenSolutionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelRecentSolutions.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRecentSolutions
		{
			get
			{
				return DisplayValues.ContextMenu_RecentSolutions;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelRecentSolutionsToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRecentSolutionsToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_RecentSolutionsToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSaveAll.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSaveAll
		{
			get
			{
				return DisplayValues.ContextMenu_SaveAll;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSaveAllToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSaveAllToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_SaveAllToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelCancelJobs.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCancelJobs
		{
			get
			{
				return DisplayValues.ContextMenu_CancelJobs;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelCancelJobsToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCancelJobsToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_CancelJobsToolTip;
			}
		}

		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RecentSolution lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<RecentSolution> RecentSolutions
		{
			get
			{
				return BusinessConfiguration.RecentSolutionList;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method checks to see if any solutions need saving.</summary>
		///--------------------------------------------------------------------------------
		public bool HasUnSavedSolutions()
		{
			try
			{
				foreach (SolutionViewModel solution in Solutions)
				{
					if (solution.Solution.IsModified == true)
					{
						return true;
					}
				}
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method saves all solutions that need saving.</summary>
		///--------------------------------------------------------------------------------
		public void SaveAllSolutions()
		{
			try
			{
				foreach (SolutionViewModel solution in Solutions)
				{
					if (solution.Solution.IsModified == true)
					{
						solution.SaveSolution(); ;
					}
				}
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method opens the currently opened VS solution as a solution builder
		/// solution, if applicable.</summary>
		///--------------------------------------------------------------------------------
		public SolutionViewModel CheckOpenCurrentSolution(string solutionDir)
		{
			SolutionViewModel solutionView = null;
			try
			{
				// open up currently open .net solution, if applicable
				foreach (RecentSolution loopSolution in BusinessConfiguration.RecentSolutionList)
				{
					string keyFilePath = loopSolution.RecentSolutionLocation;
					if (keyFilePath.ToLower().Replace("\\", "\"").Contains(solutionDir.ToLower().Replace("\\", "\"")) == true)
					{
						foreach (SolutionViewModel solution in Solutions)
						{
							if (solution.SolutionName == loopSolution.RecentSolutionName)
							{
								solutionView = solution;
								break;
							}
						}
						if (solutionView == null)
						{
							solutionView = LoadSolution(keyFilePath);
						}
					}
				}
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
			return solutionView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes a solution from the view model.</summary>
		/// 
		/// <param name="solution">The solution to close.</param>
		///--------------------------------------------------------------------------------
		public void CloseSolution(SolutionViewModel solution)
		{
			Solutions.Remove(solution);
			Items.Remove(solution);
			solution.DisposeComplete();
			System.GC.Collect();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads a solution into the view model.</summary>
		/// 
		/// <param name="solutionURL">The solution file path.</param>
		///--------------------------------------------------------------------------------
		public SolutionViewModel LoadSolution(string solutionURL = null)
		{
			SolutionViewModel solutionView = null;
			try
			{
				// create a solution under solution
				if (solutionURL != null)
				{
					if (File.Exists(solutionURL))
					{
						// load solution from xml
						Solution solution = new Solution();
						if (solutionURL != null)
						{
							solution.Load(solutionURL);
						}
						solution.ResetModified(false);
						solutionView = new SolutionViewModel(solution, solutionURL, true);
						solutionView.Updated += new EventHandler(Children_Updated);
						solutionView.Loaded += new EventHandler(solutionView_Loaded);
						solutionView.IsSelected = true;

						// compile and load into view
						solutionView.BuildSolution(true);

						// add to recent solutions
						AddSolutionToRecentSolutions(solution, solutionURL);
					}
					else
					{
						// display bad path issue
						ShowIssue(String.Format(DisplayValues.Issue_SolutionFileNotFound, solutionURL));
					}
				}
				else
				{
					// create new solution
					Solution solution = new Solution();
					solution.SolutionID = Guid.NewGuid();
					solution.Name = Resources.DisplayValues.NodeName_SolutionDefault;
					solutionView = new SolutionViewModel(solution, solutionURL);
					solutionView.Updated += new EventHandler(Children_Updated);
					solutionView.Loaded += new EventHandler(solutionView_Loaded);
					solutionView.IsSelected = true;
					Solutions.Add(solutionView);
					Items.Add(solutionView);
					Refresh(false);
				}
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
			return solutionView;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds the input solution to the recent solutions list in the
		/// registry.</summary>
		/// 
		/// <param name="inputSolution">The solution to add to the registry.</param>
		/// <param name="filePath">The path to get to the solution xml file.</param>
		///--------------------------------------------------------------------------------
		protected void AddSolutionToRecentSolutions(Solution inputSolution, string filePath)
		{
			RecentSolution existingSolution = (from s in BusinessConfiguration.RecentSolutionList
											   where s.RecentSolutionLocation.ToLower() == filePath.ToLower()
											   select s).FirstOrDefault<RecentSolution>();
			if (existingSolution == null)
			{
				RecentSolution newSolution = new RecentSolution();
				newSolution.RecentSolutionName = inputSolution.Name;
				newSolution.RecentSolutionLocation = filePath;
				newSolution.LastAccessedDate = DateTime.Now;
				BusinessConfiguration.RecentSolutionList.Add(newSolution);
				BusinessConfiguration.SaveRecentSolutions();
			}
			else
			{
				UpdateRecentSolution(existingSolution);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the input solution access date in the
		/// registry.</summary>
		/// 
		/// <param name="existingSolution">The solution to remove from the registry.</param>
		///--------------------------------------------------------------------------------
		protected void UpdateRecentSolution(RecentSolution existingSolution)
		{
			existingSolution.LastAccessedDate = DateTime.Now;
			BusinessConfiguration.SaveRecentSolutions();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes the input solution from the recent solutions list in the
		/// registry.</summary>
		/// 
		/// <param name="existingSolution">The solution to remove from the registry.</param>
		///--------------------------------------------------------------------------------
		protected void RemoveFromRecentSolutions(RecentSolution existingSolution)
		{
			RecentSolutions.Remove(existingSolution);
			BusinessConfiguration.RecentSolutionList.Remove(existingSolution);
			BusinessConfiguration.SaveRecentSolutions();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method manages the update of this view when the solution is loaded.</summary>
		/// 
		/// <param name="sender">The sender of the loaded event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void solutionView_Loaded(object sender, EventArgs e)
		{
			if (sender is SolutionViewModel)
			{
				Solutions.Add(sender as SolutionViewModel);
				Items.Add(sender as SolutionViewModel);
				Refresh(true);
				IsExpanded = true;
			}
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create solutions, optionally with recent solutions.</summary>
		/// 
		/// <param name="loadRecentSolutions">Flag indicating whether to load recent solutions.</param>
		///--------------------------------------------------------------------------------
		public SolutionsViewModel(bool loadRecentSolutions)
		{
			Name = Resources.DisplayValues.NodeName_Solutions;
			LoadSolutions();
			if (loadRecentSolutions == true)
			{
				List<RecentSolution> solutionsToRemove = new List<RecentSolution>();
				foreach (RecentSolution solution in RecentSolutions)
				{
					if (File.Exists(solution.RecentSolutionLocation) == false)
					{
						solutionsToRemove.Add(solution);
					}
					if (solution.LastAccessedDate < DateTime.Today.AddDays(-90))
					{
						solutionsToRemove.Add(solution);
					}
				}
				foreach (RecentSolution solution in solutionsToRemove)
				{
					RemoveFromRecentSolutions(solution);
				}
			}
		}
		#endregion "Constructors"
	}
}
