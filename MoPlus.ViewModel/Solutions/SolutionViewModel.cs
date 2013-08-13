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
using System.IO;
using MoPlus.Data;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Workflows;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.ViewModel.Entities;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter;
using MoPlus.ViewModel.Models;
using System.Threading;
using MoPlus.Interpreter.Events;

namespace MoPlus.ViewModel.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SolutionViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/15/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionViewModel : DialogEditWorkspaceViewModel
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
		/// <summary>This property gets MenuLabelOpenOutputSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelOpenOutputSolution
		{
			get
			{
				return DisplayValues.ContextMenu_OpenOutputSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelOpenOutputSolutionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelOpenOutputSolutionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_OpenOutputSolutionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelUpdateOutputSolution.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelUpdateOutputSolution
		{
			get
			{
				return DisplayValues.ContextMenu_UpdateOutputSolution;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelUpdateOutputSolutionToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelUpdateOutputSolutionToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_UpdateOutputSolutionToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelCompileSpecificationSourceData.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCompileSpecificationSourceData
		{
			get
			{
				return DisplayValues.ContextMenu_CompileSpecificationSourceData;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelCompileSpecificationSourceDataToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCompileSpecificationSourceDataToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_CompileSpecificationSourceDataToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSave.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSave
		{
			get
			{
				return DisplayValues.ContextMenu_Save;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSaveToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSaveToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_SaveToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSaveAs.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSaveAs
		{
			get
			{
				return DisplayValues.ContextMenu_SaveAs;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelSaveAsToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelSaveAsToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_SaveAsToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelClose.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelClose
		{
			get
			{
				return DisplayValues.ContextMenu_Close;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelCloseToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelCloseToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_CloseToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelManageTags.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelManageTags
		{
			get
			{
				return DisplayValues.ContextMenu_ManageTags;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelManageTagsToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelManageTagsToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_ManageTagsToolTip;
			}
		}

		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsEditViewModel.</summary>
		///--------------------------------------------------------------------------------
		public bool IsEditViewModel { get; set; }

		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to close items for a solution.</summary>
		/// 
		/// <param name="forceClose">Indicating whether solution must close (lose saves if cancel).</param>
		///--------------------------------------------------------------------------------
		public void SendCloseItemsForSolutionMessage(bool forceClose)
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.WorkspaceID = WorkspaceID;
			message.Solution = Solution;
			message.ForceClose = forceClose;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_CloseSolutionItemsRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the manage item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessManageItemCommand()
		{
			SolutionEventArgs message = new SolutionEventArgs();
			message.WorkspaceID = WorkspaceID;
			message.Solution = Solution;
			Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_ManageItemRequested, message);
		}
		#endregion "Command Processing"

		#region "Properties"
		public string OriginalTemplatePath { get; set; }

		BackgroundWorker _solutionBuilderWorker = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the solution builder worker.</summary>
		///--------------------------------------------------------------------------------
		BackgroundWorker SolutionBuilderWorker
		{
			get
			{
				if (_solutionBuilderWorker == null)
				{
					_solutionBuilderWorker = new BackgroundWorker();
					_solutionBuilderWorker.WorkerReportsProgress = true;
					_solutionBuilderWorker.WorkerSupportsCancellation = true;
					_solutionBuilderWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(solutionBuilderWorker_ProgressCompleted);
					_solutionBuilderWorker.Disposed += new EventHandler(solutionBuilderWorker_Disposed);
					_solutionBuilderWorker.ProgressChanged += new ProgressChangedEventHandler(solutionBuilderWorker_ProgressChanged);
				}
				return _solutionBuilderWorker;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the solution work handler.</summary>
		///--------------------------------------------------------------------------------
		protected DoWorkEventHandler SolutionWorkHandler { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the solution work completed handler.</summary>
		///--------------------------------------------------------------------------------
		protected RunWorkerCompletedEventHandler SolutionWorkCompletedHandler { get; set; }

		protected BackgroundWorkerParameters _solutionWorkParameters = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the solution work parameters.</summary>
		///--------------------------------------------------------------------------------
		protected BackgroundWorkerParameters SolutionWorkParameters
		{
			get
			{
				if (_solutionWorkParameters == null)
				{
					_solutionWorkParameters = new BackgroundWorkerParameters();
				}
				return _solutionWorkParameters;
			}
			set
			{
				_solutionWorkParameters = value;
			}
		}

		protected class BackgroundWorkerParameters
		{
			public JobTypeCode JobType;
			public Solution Solution;
			public string SolutionDirectory;
			public bool IsInitialLoad;
		}
		protected enum JobTypeCode
		{
			None = 0,
			BuildModel = 2,
			UpdateSolution = 3
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the progress bar label.</summary>
		///--------------------------------------------------------------------------------
		public string ProgressBarLabel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the desired amount of progress bar to use
		/// for build model.</summary>
		///--------------------------------------------------------------------------------
		public int BuildModelProgress { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the solution path.</summary>
		///--------------------------------------------------------------------------------
		public string SolutionPath { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Entity lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityViewModel> Entities
		{
			get
			{
				EnterpriseDataObjectList<EntityViewModel> entities = new EnterpriseDataObjectList<EntityViewModel>();
				foreach (FeatureViewModel feature in FeaturesFolder.Features)
				{
					foreach (EntityViewModel entity in feature.Entities)
					{
						entities.Add(entity);
					}
				}
				return entities;
			}
		}

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
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		public void DisposeComplete()
		{
			if (Solution != null)
			{
				Solution.DisposeComplete();
			}
			OnDispose();
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
		/// <summary>This method loads a solution into the view model.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		/// <param name="isCompiledModel">Flag indicating if solution contains fully compiled information</param>
		///--------------------------------------------------------------------------------
		public void LoadSolution(Solution solution, bool isCompiledModel = true, bool loadChildren = true)
		{
			try
			{
				// attach the solution
				RefreshSolution(solution);
				ItemID = Solution.SolutionID;
				HasCustomizations = true;
				IsSelected = true;

				if (loadChildren == true)
				{
					// attach specification sources
					if (SpecificationSourcesFolder == null)
					{
						SpecificationSourcesFolder = new SpecificationSourcesViewModel(Solution);
						SpecificationSourcesFolder.Updated += new EventHandler(Children_Updated);
						Items.Add(SpecificationSourcesFolder);
					}

					// attach assemblies
					if (ProjectsFolder == null)
					{
						ProjectsFolder = new ProjectsViewModel(Solution);
						ProjectsFolder.Updated += new EventHandler(Children_Updated);
						Items.Add(ProjectsFolder);
					}

					// attach features
					if (FeaturesFolder == null)
					{
						FeaturesFolder = new FeaturesViewModel(Solution, isCompiledModel);
						FeaturesFolder.Updated += new EventHandler(Children_Updated);
						Items.Add(FeaturesFolder);
					}

					// attach diagrams
					if (DiagramsFolder == null)
					{
						DiagramsFolder = new DiagramsViewModel(Entities, Solution, isCompiledModel);
						DiagramsFolder.Updated += new EventHandler(Children_Updated);
						Items.Add(DiagramsFolder);
					}

					// attach workflows
					if (WorkflowsFolder == null)
					{
						WorkflowsFolder = new WorkflowsViewModel(Solution, isCompiledModel);
						WorkflowsFolder.Updated += new EventHandler(Children_Updated);
						Items.Add(WorkflowsFolder);
					}

					// attach audit properties
					if (AuditPropertiesFolder == null)
					{
						AuditPropertiesFolder = new AuditPropertiesViewModel(solution);
						AuditPropertiesFolder.Updated += new EventHandler(Children_Updated);
						Items.Add(AuditPropertiesFolder);
					}
					else
					{
						AuditPropertiesFolder.LoadAuditProperties(solution);
					}

					// attach spec templates
					if (SpecTemplatesFolder == null)
					{
						Solution.SpecTemplates.Clear();
						SpecTemplatesFolder = new SpecTemplatesViewModel(Solution, ModelContextTypeCode.Solution.ToString());
						SpecTemplatesFolder.Updated += new EventHandler(TemplatesFolder_Updated);
						Items.Add(SpecTemplatesFolder);
					}

					// attach code templates
					if (CodeTemplatesFolder == null)
					{
						CodeTemplatesFolder = new CodeTemplatesViewModel(Solution, ModelContextTypeCode.Solution.ToString());
						CodeTemplatesFolder.Updated += new EventHandler(TemplatesFolder_Updated);
						Items.Add(CodeTemplatesFolder);
					}
					//Solution.ResetModified(false);
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
		/// <summary>This method saves a solution to the specified path.</summary>
		///--------------------------------------------------------------------------------
		public void SaveSolution()
		{
			try
			{
				// save the solution
				if (String.IsNullOrEmpty(SolutionPath))
				{
					ShowIssue(Resources.DisplayValues.Issue_MissingFileName);
				}
				else
				{
					Solution forwardInstance = Solution.GetForwardInstance();
					forwardInstance.Save(SolutionPath);
					Solution.ResetModified(false);

					// add to recent solutions
					AddSolutionToRecentSolutions(Solution, SolutionPath);

					ShowOutput(String.Format(Resources.DisplayValues.Message_SolutionSaved, Solution.Name), Resources.DisplayValues.Task_SaveTitle, false);
					ShowStatus(Resources.DisplayValues.Status_Ready);
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
		/// <summary>This method builds the solution from its specification source data
		/// and updates the view models.</summary>
		/// 
		/// <param name="isInitialLoad">Flag indicating whether build is part of initial load
		/// into the view.</param>
		///--------------------------------------------------------------------------------
		public void BuildSolution(bool isInitialLoad = false)
		{
			RunBackgroundJob(JobTypeCode.BuildModel, isInitialLoad);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the output solution for the input solution node.</summary>
		///--------------------------------------------------------------------------------
		public void UpdateOutputSolution()
		{
			RunBackgroundJob(JobTypeCode.UpdateSolution);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the output solution for the input solution.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateOutputSolution(object sender, DoWorkEventArgs e)
		{
			try
			{
				// update the solution
				Solution solutionToGenerate = SolutionWorkParameters.Solution;
				SolutionBuilderWorker.ReportProgress(0);
				solutionToGenerate.CallbackWorker = SolutionBuilderWorker;
				solutionToGenerate.CurrentProgress = 0;
				solutionToGenerate.BuildModelProgress = BuildModelProgress;
				solutionToGenerate.SolutionDirectory = SolutionWorkParameters.SolutionDirectory;
				solutionToGenerate.BuildModelPercentage = 0;
				solutionToGenerate.CompileToOutputSolution(true, false);
				SolutionBuilderWorker.ReportProgress(100);
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
				SolutionBuilderWorker.CancelAsync();
			}
			catch (Exception ex)
			{
				ShowException(ex);
				SolutionBuilderWorker.CancelAsync();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method builds the model from its specification sources.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void BuildModel(object sender, DoWorkEventArgs e)
		{
			try
			{
				// build the model from specification sources
				Solution solutionToGenerate = SolutionWorkParameters.Solution;
				SolutionBuilderWorker.ReportProgress(0);
				solutionToGenerate.CallbackWorker = SolutionBuilderWorker;
				solutionToGenerate.CurrentProgress = 0;
				solutionToGenerate.BuildModelProgress = BuildModelProgress;
				solutionToGenerate.SolutionDirectory = SolutionWorkParameters.SolutionDirectory;
				solutionToGenerate.BuildModelPercentage = 100;
				solutionToGenerate.BuildModel();
				SolutionBuilderWorker.ReportProgress(100);
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
				SolutionBuilderWorker.CancelAsync();
			}
			catch (Exception ex)
			{
				ShowException(ex);
				SolutionBuilderWorker.CancelAsync();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method runs a job on the solution builder background worker.</summary>
		/// 
		/// <param name="isInitialLoad">Flag indicating whether build is part of initial load
		/// into the view.</param>
		///--------------------------------------------------------------------------------
		protected bool RunBackgroundJob(JobTypeCode jobType, bool isInitialLoad = false)
		{
			bool startedJob = false;
			try
			{
				if (SolutionBuilderWorker.IsBusy == false)
				{
					lock (DebugHelper.DEBUG_OBJECT)
					{
						DebugHelper.DebugAction = DebugAction.Run;
						Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
					}
					//Cursor.Current = Cursors.WaitCursor;
					if (SolutionWorkHandler != null)
					{
						// remove previous work
						SolutionBuilderWorker.DoWork -= SolutionWorkHandler;
						SolutionWorkHandler = null;
					}
					if (SolutionWorkCompletedHandler != null)
					{
						// remove completed handler
						SolutionBuilderWorker.RunWorkerCompleted -= SolutionWorkCompletedHandler;
						SolutionWorkCompletedHandler = null;
					}

					// get basic parameters
					SolutionWorkParameters = null;
					SolutionWorkParameters.JobType = jobType;
					SolutionWorkParameters.IsInitialLoad = isInitialLoad;

					if (jobType == JobTypeCode.UpdateSolution)
					{
						// update solution (compiler manages customizations)
						SolutionWorkParameters.Solution = Solution;  // update solution job should just read the model other than caching templates
						string solutionDirectory = SolutionPath;
						solutionDirectory = solutionDirectory.Substring(0, solutionDirectory.LastIndexOf("\\"));
						SolutionWorkParameters.SolutionDirectory = solutionDirectory;
						if (String.IsNullOrEmpty(SolutionWorkParameters.SolutionDirectory) || Directory.Exists(solutionDirectory) == false)
						{
							ShowIssue(String.Format(Resources.DisplayValues.Issue_SolutionDirectoryNotFound, solutionDirectory));
						}
						else
						{
							// initialize IDE progress bar and set up update solution job
							BuildModelProgress = 33;
							ReportProgress(1, "", 0, 0);
							ProgressBarLabel = Resources.DisplayValues.Progress_UpdatingOutputSolutionIntro + Solution.SolutionName + "...";
							SolutionWorkHandler = new DoWorkEventHandler(UpdateOutputSolution);
							SolutionBuilderWorker.DoWork += SolutionWorkHandler;
							SolutionWorkCompletedHandler = new RunWorkerCompletedEventHandler(solutionBuilderWorker_UpdateSolutionCompleted);
							SolutionBuilderWorker.RunWorkerCompleted += SolutionWorkCompletedHandler;
						}
					}
					else if (jobType == JobTypeCode.BuildModel)
					{
						// update solution (compiler manages customizations)
						string solutionDirectory = SolutionPath;
						if (solutionDirectory.Length > 0)
						{
							solutionDirectory = solutionDirectory.Substring(0, solutionDirectory.LastIndexOf("\\"));
						}
						SolutionWorkParameters.Solution = new Solution();
						SolutionWorkParameters.Solution.StatusChanged += new Solution.StatusEventHandler(Solution_StatusChanged);
						SolutionWorkParameters.Solution.OutputRequested += new Solution.StatusEventHandler(Solution_OutputRequested);
						_solutionWorkParameters.Solution.BreakpointReached += new Solution.DebugEventHandler(Solution_BreakpointReached);
						SolutionWorkParameters.Solution.Load(SolutionPath);

						// attach cached items to new solution
						SolutionWorkParameters.Solution.CodeTemplates = Solution.CodeTemplates;
						SolutionWorkParameters.Solution.SpecTemplates = Solution.SpecTemplates;
						SolutionWorkParameters.SolutionDirectory = solutionDirectory;
						//SolutionWorkParameters.Solution.CodeTemplateContentParser = Solution.CodeTemplateContentParser;
						//SolutionWorkParameters.Solution.CodeTemplatOutputParser = Solution.CodeTemplatOutputParser;
						SolutionWorkParameters.Solution.SpecTemplateContentParser = Solution.SpecTemplateContentParser;
						SolutionWorkParameters.Solution.SpecTemplateOutputParser = Solution.SpecTemplateOutputParser;
						SolutionWorkParameters.SolutionDirectory = solutionDirectory;
						if (String.IsNullOrEmpty(SolutionWorkParameters.SolutionDirectory) || Directory.Exists(solutionDirectory) == false)
						{
							ShowIssue(String.Format(Resources.DisplayValues.Issue_SolutionDirectoryNotFound, solutionDirectory));
						}
						else if (Solution.IsModified == true)
						{
							ShowIssue(Resources.DisplayValues.Issue_SolutionMustBeSaved);
						}
						else
						{
							// initialize IDE progress bar and set up compile model job
							BuildModelProgress = 100;
							ReportProgress(1, "", 0, 0);
							ProgressBarLabel = Resources.DisplayValues.Progress_CompilingModelIntro + Solution.SolutionName + "...";
							SolutionWorkHandler = new DoWorkEventHandler(BuildModel);
							SolutionBuilderWorker.DoWork += SolutionWorkHandler;
							SolutionWorkCompletedHandler = new RunWorkerCompletedEventHandler(solutionBuilderWorker_CompileModelCompleted);
							SolutionBuilderWorker.RunWorkerCompleted += SolutionWorkCompletedHandler;
						}
					}
					SolutionBuilderWorker.RunWorkerAsync(SolutionBuilderWorker);
					startedJob = true;
				}
				else
				{
					ShowIssue(String.Format(Resources.DisplayValues.Thread_ThreadBusy, SolutionWorkParameters.JobType.ToString()));
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
			finally
			{
				//System.GC.Collect();
				//Cursor.Current = Cursors.Default;
			}
			return startedJob;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reaching a breakpoint.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event args.</param>
		///--------------------------------------------------------------------------------
		void Solution_BreakpointReached(object sender, DebugEventArgs args)
		{
			SolutionDebugEventArgs message = new SolutionDebugEventArgs();
			message.Solution = args.SolutionContext;
			message.TemplateContext = args.TemplateContext;
			message.ModelContext = args.ModelContext;
			message.SolutionID = args.SolutionContext.SolutionID;
			message.InterpreterType = args.InterpreterType;
			message.LineNumber = args.LineNumber;
			Mediator.NotifyColleagues<SolutionDebugEventArgs>(MediatorMessages.Command_BreakpointReached, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the completion of an update solution job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event args.</param>
		///--------------------------------------------------------------------------------
		void solutionBuilderWorker_UpdateSolutionCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (DebugHelper.DebugAction == DebugAction.Stop)
			{
				ShowOutput(String.Format(DisplayValues.Progress_ModelSolutionAborted, SolutionWorkParameters.Solution.SolutionName, SolutionWorkParameters.Solution.TemplatesUsed.Count, SolutionWorkParameters.Solution.TemplatesExecuted, SolutionWorkParameters.Solution.CachedTemplatesExecuted), DisplayValues.Progress_SolutionBuilderTask, true);
			}
			else
			{
				ShowOutput(String.Format(DisplayValues.Progress_ModelSolutionUpdated, SolutionWorkParameters.Solution.SolutionName, SolutionWorkParameters.Solution.TemplatesUsed.Count, SolutionWorkParameters.Solution.TemplatesExecuted, SolutionWorkParameters.Solution.CachedTemplatesExecuted), DisplayValues.Progress_SolutionBuilderTask, true);
			}
			lock (DebugHelper.DEBUG_OBJECT)
			{
				DebugHelper.DebugAction = DebugAction.None;
				Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
			}
			CodeTemplatesFolder.Refresh(true);
			Refresh(false);
			OnUpdated(this, null);
			IsSelected = true;
			NeedsFocus = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the completion of an update solution job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event args.</param>
		///--------------------------------------------------------------------------------
		void solutionBuilderWorker_CompileModelCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// replace solution with newly compiled solution
			SolutionWorkParameters.Solution.StatusChanged -= Solution_StatusChanged;
			SolutionWorkParameters.Solution.OutputRequested -= Solution_OutputRequested;
			SolutionWorkParameters.Solution.BreakpointReached -= Solution_BreakpointReached;
			SolutionWorkParameters.Solution.CodeTemplateContentParser = null; // to reset the grammar based on model updates
			SolutionWorkParameters.Solution.CodeTemplatOutputParser = null; // to reset the grammar based on model updates
			ResetSolution(SolutionWorkParameters.Solution);
			SpecTemplatesFolder.Refresh(true);
			Refresh(true);
			OnUpdated(this, null);
			if (SolutionWorkParameters.IsInitialLoad == true)
			{
				OnLoaded(this, null);
			}
			else
			{
				OnUpdated(this, null);
			}
			if (DebugHelper.DebugAction == DebugAction.Stop)
			{
				ShowOutput(String.Format(DisplayValues.Progress_ModelAborted, SolutionWorkParameters.Solution.SolutionName, SolutionWorkParameters.Solution.TemplatesUsed.Count, SolutionWorkParameters.Solution.TemplatesExecuted, SolutionWorkParameters.Solution.CachedTemplatesExecuted), DisplayValues.Progress_SolutionBuilderTask, true);
			}
			else
			{
				ShowOutput(String.Format(DisplayValues.Progress_ModelUpdated, SolutionWorkParameters.Solution.SolutionName, SolutionWorkParameters.Solution.TemplatesUsed.Count, SolutionWorkParameters.Solution.TemplatesExecuted, SolutionWorkParameters.Solution.CachedTemplatesExecuted), DisplayValues.Progress_SolutionBuilderTask, true);
			}
			lock (DebugHelper.DEBUG_OBJECT)
			{
				DebugHelper.DebugAction = DebugAction.None;
				Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
			}
			IsSelected = true;
			NeedsFocus = true;
			Solution.ResetModified(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reporting ongoing progress of the solution builder job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void solutionBuilderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// report progress on the IDE progress bar
			ReportProgress(1, ProgressBarLabel, e.ProgressPercentage.GetUInt(), 100);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reporting completed progress of the solution builder job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void solutionBuilderWorker_ProgressCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// clear the IDE progress bar
			ReportProgress(0, "", 0, 0);
			ShowStatus(Resources.DisplayValues.Status_Ready);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles disposing of the background worker.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void solutionBuilderWorker_Disposed(object sender, EventArgs e)
		{
			_solutionBuilderWorker = null;
			System.GC.Collect();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method links the underlying solution to the view model, wiring up
		/// any necessary events, etc.</summary>
		/// 
		/// <param name="solution">The input solution.</param>
		///--------------------------------------------------------------------------------
		public void ResetSolution(Solution solution)
		{
			if (Solution != null)
			{
				Solution.StatusChanged -= Solution_StatusChanged;
				Solution.OutputRequested -= Solution_OutputRequested;
				Solution.BreakpointReached -= Solution_BreakpointReached;
			}
			Items.Clear();
			AuditPropertiesFolder.Dispose();
			AuditPropertiesFolder.Updated -= Children_Updated;
			AuditPropertiesFolder = null;
			AuditPropertiesFolder = new AuditPropertiesViewModel(solution);
			AuditPropertiesFolder.Updated += new EventHandler(Children_Updated);
			FeaturesFolder.Dispose();
			FeaturesFolder.Updated -= Children_Updated;
			FeaturesFolder = null;
			FeaturesFolder = new FeaturesViewModel(solution);
			FeaturesFolder.Updated += new EventHandler(Children_Updated);
			ProjectsFolder.Dispose();
			ProjectsFolder.Updated -= Children_Updated;
			ProjectsFolder = null;
			ProjectsFolder = new ProjectsViewModel(solution);
			ProjectsFolder.Updated += new EventHandler(Children_Updated);
			ModelsFolder.Dispose();
			ModelsFolder.Updated -= Children_Updated;
			ModelsFolder = null;
			ModelsFolder = new ModelsViewModel(solution);
			ModelsFolder.Updated += new EventHandler(Children_Updated);
			WorkflowsFolder.Dispose();
			WorkflowsFolder.Updated -= Children_Updated;
			WorkflowsFolder = null;
			WorkflowsFolder = new WorkflowsViewModel(solution);
			WorkflowsFolder.Updated += new EventHandler(Children_Updated);
			DiagramsFolder.Dispose();
			DiagramsFolder.Updated -= Children_Updated;
			DiagramsFolder = null;
			DiagramsFolder = new DiagramsViewModel(Entities, solution);
			DiagramsFolder.Updated += new EventHandler(Children_Updated);
			SpecificationSourcesFolder.Dispose();
			SpecificationSourcesFolder.Updated -= Children_Updated;
			SpecificationSourcesFolder = null;
			SpecificationSourcesFolder = new SpecificationSourcesViewModel(solution);
			SpecificationSourcesFolder.Updated += new EventHandler(Children_Updated);
			SpecificationSourcesFolder.UpdateSolution(solution);

			// retain template information
			SpecTemplatesFolder.UpdateSolution(solution);
			CodeTemplatesFolder.UpdateSolution(solution);

			// readd items
			Items.Add(SpecificationSourcesFolder);
			Items.Add(ProjectsFolder);
			Items.Add(FeaturesFolder);
			Items.Add(WorkflowsFolder);
			Items.Add(ModelsFolder);
			Items.Add(DiagramsFolder);
			Items.Add(AuditPropertiesFolder);
			Items.Add(SpecTemplatesFolder);
			Items.Add(CodeTemplatesFolder);

			// set up new solution
			Solution.StatusChanged -= Solution_StatusChanged;
			Solution.OutputRequested -= Solution_OutputRequested;
			Solution.BreakpointReached -= Solution_BreakpointReached;
			Solution.DisposeCore();
			Solution = null;
			Solution = solution;
			Solution.StatusChanged += new MoPlus.Interpreter.BLL.Solutions.Solution.StatusEventHandler(Solution_StatusChanged);
			Solution.OutputRequested += new MoPlus.Interpreter.BLL.Solutions.Solution.StatusEventHandler(Solution_OutputRequested);
			Solution.BreakpointReached += new Solution.DebugEventHandler(Solution_BreakpointReached);
			ShowInTreeView(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles solution output request information.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		void Solution_OutputRequested(object sender, MoPlus.Interpreter.Events.StatusEventArgs args)
		{
			if (args.IsException == true)
			{
				ShowIssue(args.Text, args.Title, args.ShowMessageBox);
			}
			else
			{
				ShowOutput(args.Text, args.Title, args.AppendText, args.ShowMessageBox);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles solution status change information.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		void Solution_StatusChanged(object sender, MoPlus.Interpreter.Events.StatusEventArgs args)
		{
			ShowStatus(args.Text, args.Title, args.AppendText, args.ShowMessageBox);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method manages the update of this view when templates are updated.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void TemplatesFolder_Updated(object sender, EventArgs e)
		{
			Refresh(false, 1);
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		/// <param name="solutionURL">The solution file path.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public SolutionViewModel(Solution solution, string solutionURL, bool loadChildren = true)
		{
			SolutionPath = solutionURL;
			OriginalTemplatePath = solution.TemplatePath;
			LoadSolution(solution, loadChildren);
			Solution.CallbackWorker = SolutionBuilderWorker;
			WorkspaceID = Guid.NewGuid();
		}
		#endregion "Constructors"
	}
}
