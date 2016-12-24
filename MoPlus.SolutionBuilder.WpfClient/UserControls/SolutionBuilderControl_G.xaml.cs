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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.SolutionBuilder.WpfClient.Library;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Events;
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

namespace MoPlus.SolutionBuilder.WpfClient.UserControls
{
	///--------------------------------------------------------------------------------
	/// Interaction logic for SolutionBuilderControl.xaml
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/2/2013</CreatedDate>
	/// <Status>Customized (customized OpenExecuted)</Status>
	///--------------------------------------------------------------------------------
	public partial class SolutionBuilderControl : UserControl
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the progress bar label.</summary>
		///--------------------------------------------------------------------------------
		public string ProgressBarLabel { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the desired amount of progress bar to use
		/// for build model.</summary>
		///--------------------------------------------------------------------------------
		public int BuildModelProgress { get; set; }

		public static readonly DependencyProperty TreeViewModelProperty = DependencyProperty.Register("TreeViewModel", typeof(BuilderViewModel), typeof(SolutionBuilderControl));
		public BuilderViewModel TreeViewModel
		{
			get
			{
				return (BuilderViewModel)GetValue(TreeViewModelProperty);
			}
			set
			{
				SetValue(TreeViewModelProperty, value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets OutputView for passing along output events.</summary>
		///--------------------------------------------------------------------------------
		public OutputViewModel OutputView { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StatusView for passing along status events.</summary>
		///--------------------------------------------------------------------------------
		public StatusViewModel StatusView { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the parent solutions model, based on the selected item.</summary>
		///--------------------------------------------------------------------------------
		public SolutionViewModel ParentSolutionViewModel
		{
			get
			{
				if (solutionsModel != null && solutionsModel.SelectedItem != null)
				{
					if (solutionsModel.SelectedItem is SolutionViewModel)
					{
						return solutionsModel.SelectedItem as SolutionViewModel;
					}
					if (solutionsModel.SelectedItem is IWorkspaceViewModel && (solutionsModel.SelectedItem as IWorkspaceViewModel).Solution != null)
					{
						if (DataContext is BuilderViewModel)
						{
							foreach (SolutionViewModel solution in (DataContext as BuilderViewModel).SolutionsFolder.Solutions)
							{
								if (solution.SolutionID == (solutionsModel.SelectedItem as IWorkspaceViewModel).Solution.SolutionID)
								{
									return solution;
								}
							}
						}
					}
				}
				return null;
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method handles focus requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void TreeViewModel_FocusRequested(object sender, EventArgs e)
		{
			solutionsModel.Focus();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the open command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the open command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
		{
            SolutionViewModel solution = null;
			if (e != null && e.Parameter is String)
			{
				Mouse.OverrideCursor = Cursors.Wait;
                solution = TreeViewModel.SolutionsFolder.LoadSolution(e.Parameter as String);
				Mouse.OverrideCursor = null;
			}
			else
			{
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.DefaultExt = ".xml";
				dialog.Filter = "Xml Documents (.xml)|*.xml";
				bool? result = dialog.ShowDialog();
				if (result == true)
				{
					solution = TreeViewModel.SolutionsFolder.LoadSolution(dialog.FileName);
                }
			}
            // check for multiple solutions with same ids
            if (solution != null && TreeViewModel.SolutionsFolder.Solutions.Find(i => i.SolutionID == solution.SolutionID) != null)
            {
                MessageBox.Show(DisplayValues.Message_DuplicateSolutions);
            }
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the new command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the new command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (solutionsModel.SelectedItem is IWorkspaceViewModel)
			{
				TreeViewModel.ProcessNewCommand(solutionsModel.SelectedItem as IWorkspaceViewModel);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the save command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the save command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (ParentSolutionViewModel != null)
			{
				// save solution
				SaveSolution(ParentSolutionViewModel, false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a file path for saving.</summary>
		/// 
		/// <param name="solution">Solution view model containing solution to save.</param>
		/// <param name="promptForNewFileName">Flag to prompt "Save As".</param>
		///--------------------------------------------------------------------------------
		private void SaveSolution(SolutionViewModel solution, bool promptForNewFileName)
		{
			// save the solution
			if (String.IsNullOrEmpty(solution.SolutionPath) || promptForNewFileName == true)
			{
				string newPath = GetFilePath();
				if (!String.IsNullOrEmpty(newPath)) solution.SolutionPath = newPath;
			}
			if (!String.IsNullOrEmpty(solution.SolutionPath))
			{
				solution.SaveSolution();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a file path for saving.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private string GetFilePath()
		{
			// get file path from dialog
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = DisplayValues.Message_SaveSolutionFilter;
			saveFileDialog.Title = DisplayValues.Message_SaveSolutionCaption;
			saveFileDialog.DefaultExt = DisplayValues.Message_SolutionFileExtension;
			if (saveFileDialog.ShowDialog() == true)
			{
				return saveFileDialog.FileName;
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the new child item command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewChildItemCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the new child item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void NewChildItemExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (solutionsModel.SelectedItem is IWorkspaceViewModel)
			{
				TreeViewModel.ProcessNewChildItemCommand(solutionsModel.SelectedItem as IWorkspaceViewModel);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the open output solution command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenOutputSolutionCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the open output solution command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OpenOutputSolutionExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (ParentSolutionViewModel != null)
			{
				// open output solution
				OpenOutputSolution(ParentSolutionViewModel);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method opens the output solution for a solution.</summary>
		///--------------------------------------------------------------------------------
		private void OpenOutputSolution(SolutionViewModel solution)
		{
			try
			{
				Solution solutionToGenerate = solution.Solution;
				string solutionDirectory = solution.SolutionPath;
				solutionDirectory = solutionDirectory.Substring(0, solutionDirectory.LastIndexOf("\\"));
				solutionToGenerate.SolutionDirectory = solutionDirectory;
				if (solutionToGenerate.SolutionDirectory == String.Empty)
				{
					MessageBox.Show(DisplayValues.Message_SolutionFileMustBeSaved);
				}
				else
				{
					// open the output solution if not already open
					SolutionEventArgs args = new SolutionEventArgs();
					args.Path = solutionToGenerate.OutputSolutionFilePath;
					OnOpenOutputSolutionRequested(this, args);
				}
			}
			catch (ApplicationException ex)
			{
				TreeViewModel.ShowException(ex);
			}
			catch (Exception ex)
			{
				TreeViewModel.ShowException(ex);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the update output solution command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateOutputSolutionCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the update output solution command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateOutputSolutionExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter != null && e.Parameter is SolutionViewModel)
			{
				(e.Parameter as SolutionViewModel).UpdateOutputSolution();
			}
			else if (ParentSolutionViewModel != null)
			{
				ParentSolutionViewModel.UpdateOutputSolution();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the compile solution command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CompileSolutionCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the compile solution command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CompileSolutionExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (ParentSolutionViewModel != null)
			{
				ParentSolutionViewModel.BuildSolution();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the save all command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SaveAllCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the save all command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SaveAllExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (solutionsModel.SelectedItem != null)
			{
				if (solutionsModel.SelectedItem is SolutionsViewModel)
				{
					// save all solutions
					foreach (SolutionViewModel view in (solutionsModel.SelectedItem as SolutionsViewModel).Solutions)
					{
						SaveSolution(view, false);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the cancel jobs command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CancelJobsCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the cancel jobs command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CancelJobsExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			lock (DebugHelper.DEBUG_OBJECT)
			{
				DebugHelper.DebugAction = DebugAction.Stop;
				Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the save as command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SaveAsCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the save as command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void SaveAsExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (ParentSolutionViewModel != null)
			{
				// save solution as ...
				SaveSolution(ParentSolutionViewModel, true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the update command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the update item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (solutionsModel.SelectedItem != null)
			{
				if (solutionsModel.SelectedItem is SolutionViewModel)
				{
					SolutionViewModel view = solutionsModel.SelectedItem as SolutionViewModel;
					view.OnUpdated(this, null);
					view.ProcessEditSolutionCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is AuditPropertyViewModel)
				{
					(solutionsModel.SelectedItem as AuditPropertyViewModel).ProcessEditAuditPropertyCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is CodeTemplateViewModel)
				{
					(solutionsModel.SelectedItem as CodeTemplateViewModel).ProcessEditCodeTemplateCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is CollectionViewModel)
				{
					(solutionsModel.SelectedItem as CollectionViewModel).ProcessEditCollectionCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is DatabaseSourceViewModel)
				{
					(solutionsModel.SelectedItem as DatabaseSourceViewModel).ProcessEditDatabaseSourceCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is DiagramViewModel)
				{
					(solutionsModel.SelectedItem as DiagramViewModel).ProcessEditDiagramCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is DiagramEntityViewModel)
				{
					(solutionsModel.SelectedItem as DiagramEntityViewModel).ProcessEditDiagramEntityCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is EntityViewModel)
				{
					(solutionsModel.SelectedItem as EntityViewModel).ProcessEditEntityCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is EntityReferenceViewModel)
				{
					(solutionsModel.SelectedItem as EntityReferenceViewModel).ProcessEditEntityReferenceCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is EnumerationViewModel)
				{
					(solutionsModel.SelectedItem as EnumerationViewModel).ProcessEditEnumerationCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is FeatureViewModel)
				{
					(solutionsModel.SelectedItem as FeatureViewModel).ProcessEditFeatureCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is IndexViewModel)
				{
					(solutionsModel.SelectedItem as IndexViewModel).ProcessEditIndexCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is IndexPropertyViewModel)
				{
					(solutionsModel.SelectedItem as IndexPropertyViewModel).ProcessEditIndexPropertyCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is MethodViewModel)
				{
					(solutionsModel.SelectedItem as MethodViewModel).ProcessEditMethodCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ModelViewModel)
				{
					(solutionsModel.SelectedItem as ModelViewModel).ProcessEditModelCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ModelObjectViewModel)
				{
					(solutionsModel.SelectedItem as ModelObjectViewModel).ProcessEditModelObjectCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ModelPropertyViewModel)
				{
					(solutionsModel.SelectedItem as ModelPropertyViewModel).ProcessEditModelPropertyCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ObjectInstanceViewModel)
				{
					(solutionsModel.SelectedItem as ObjectInstanceViewModel).ProcessEditObjectInstanceCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ParameterViewModel)
				{
					(solutionsModel.SelectedItem as ParameterViewModel).ProcessEditParameterCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ProjectViewModel)
				{
					(solutionsModel.SelectedItem as ProjectViewModel).ProcessEditProjectCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is PropertyViewModel)
				{
					(solutionsModel.SelectedItem as PropertyViewModel).ProcessEditPropertyCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is PropertyInstanceViewModel)
				{
					(solutionsModel.SelectedItem as PropertyInstanceViewModel).ProcessEditPropertyInstanceCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is PropertyReferenceViewModel)
				{
					(solutionsModel.SelectedItem as PropertyReferenceViewModel).ProcessEditPropertyReferenceCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is RelationshipViewModel)
				{
					(solutionsModel.SelectedItem as RelationshipViewModel).ProcessEditRelationshipCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is RelationshipPropertyViewModel)
				{
					(solutionsModel.SelectedItem as RelationshipPropertyViewModel).ProcessEditRelationshipPropertyCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is SpecTemplateViewModel)
				{
					(solutionsModel.SelectedItem as SpecTemplateViewModel).ProcessEditSpecTemplateCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StageViewModel)
				{
					(solutionsModel.SelectedItem as StageViewModel).ProcessEditStageCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StageTransitionViewModel)
				{
					(solutionsModel.SelectedItem as StageTransitionViewModel).ProcessEditStageTransitionCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StateViewModel)
				{
					(solutionsModel.SelectedItem as StateViewModel).ProcessEditStateCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StateModelViewModel)
				{
					(solutionsModel.SelectedItem as StateModelViewModel).ProcessEditStateModelCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StateTransitionViewModel)
				{
					(solutionsModel.SelectedItem as StateTransitionViewModel).ProcessEditStateTransitionCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StepViewModel)
				{
					(solutionsModel.SelectedItem as StepViewModel).ProcessEditStepCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is StepTransitionViewModel)
				{
					(solutionsModel.SelectedItem as StepTransitionViewModel).ProcessEditStepTransitionCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ValueViewModel)
				{
					(solutionsModel.SelectedItem as ValueViewModel).ProcessEditValueCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is WorkflowViewModel)
				{
					(solutionsModel.SelectedItem as WorkflowViewModel).ProcessEditWorkflowCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is XmlSourceViewModel)
				{
					(solutionsModel.SelectedItem as XmlSourceViewModel).ProcessEditXmlSourceCommand();
					return;
				}
				else if (solutionsModel.SelectedItem is ViewModel.Conventions.HelpViewModel)
				{
					(solutionsModel.SelectedItem as ViewModel.Conventions.HelpViewModel).ProcessShowHelpCommand();
					return;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the manage item command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void ManageItemCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = solutionsModel.SelectedItem != null && solutionsModel.SelectedItem is SolutionViewModel;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the manage item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void ManageItemExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (solutionsModel.SelectedItem != null && solutionsModel.SelectedItem is SolutionViewModel)
			{
				SolutionViewModel view = solutionsModel.SelectedItem as SolutionViewModel;
				view.ProcessManageItemCommand();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the delete command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the delete item command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (solutionsModel.SelectedItem is IWorkspaceViewModel)
			{
				if (MessageBox.Show(DisplayValues.Message_DeleteItemConfirmation, DisplayValues.Message_DeleteItemConfirmationCaption, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
				{
					TreeViewModel.ProcessDeleteCommand(solutionsModel.SelectedItem as IWorkspaceViewModel);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the close command can execute.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CloseCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = TreeViewModel != null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes the close command.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (ParentSolutionViewModel != null)
			{
				// close solution
				CloseSolution(ParentSolutionViewModel, false, false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method closes all solutions, and saves if specified.</summary>
		/// 
		/// <param name="forceClose">Flag indicating whether close must happen (no cancel save).</param>
		/// <param name="promptForceSave">Flag indicating whether prompt for save should occur.</param>
		///--------------------------------------------------------------------------------
		public bool CloseAllSolutions(bool forceClose, bool promptForceSave = true)
		{
			if (TreeViewModel == null || TreeViewModel.SolutionsFolder == null || TreeViewModel.SolutionsFolder.Solutions == null)
			{
				return true;
			}
			IList<SolutionViewModel> solutions = TreeViewModel.SolutionsFolder.Solutions.ToList<SolutionViewModel>();
			foreach (SolutionViewModel solution in solutions)
			{
				CloseSolution(solution, true, forceClose, promptForceSave);
			}
			if (TreeViewModel.SolutionsFolder.Solutions.Count == 0)
			{
				return true;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method saves all solutions.</summary>
		///--------------------------------------------------------------------------------
		public void SaveAllSolutions()
		{
			if (TreeViewModel != null)
			{
				TreeViewModel.SolutionsFolder.SaveAllSolutions();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method checks to see if any solutions need saving.</summary>
		///--------------------------------------------------------------------------------
		public bool HasUnSavedSolutions()
		{
			if (TreeViewModel != null)
			{
				return TreeViewModel.SolutionsFolder.HasUnSavedSolutions();
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method closes the solution, and saves if specified.</summary>
		/// 
		/// <param name="solution">The solution node to close.</param>
		/// <param name="appendMessage">Flag indicating whether status message should be appended to.</param>
		/// <param name="forceClose">Flag indicating whether close must happen (no cancel save).</param>
		/// <param name="promptForceSave">Flag indicating whether prompt for save should occur.</param>
		///--------------------------------------------------------------------------------
		public bool CloseSolution(SolutionViewModel solution, bool appendMessage, bool forceClose, bool promptForceSave = true)
		{
			bool solutionsClosed = true;
			try
			{
				Solution currentSolution = solution.Solution;
				bool closeSolutionOK = true;
				if (appendMessage == false)
				{
					TreeViewModel.ShowStatus("");
				}

				// close all tabs associated with the solution
				solution.SendCloseItemsForSolutionMessage(forceClose);
				if (solution.EditItemsCount > 0)
				{
					closeSolutionOK = false;
				}

				if (closeSolutionOK == false)
				{
					MessageBox.Show(DisplayValues.Message_ClosingSolutionIntro + currentSolution.Name + DisplayValues.Message_ClosingSolutionEnd, DisplayValues.Message_ClosingSolutionCaption, MessageBoxButton.OK);
					solutionsClosed = false;
					TreeViewModel.ShowStatus(DisplayValues.Status_Ready);
				}
				else
				{
					if (currentSolution.IsModified == true)
					{
						if (forceClose == true)
						{
							if (promptForceSave == true && MessageBox.Show(DisplayValues.Message_SaveSolutionIntro + currentSolution.Name + DisplayValues.Message_SaveSolutionChangesLostEnd, DisplayValues.Message_SaveSolutionCaption, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
							{
								SaveSolution(solution, false);
							}
						}
						else
						{
							MessageBoxResult result = MessageBox.Show(DisplayValues.Message_SaveSolutionIntro + currentSolution.Name + DisplayValues.Message_SaveSolutionChangesAbortEnd, DisplayValues.Message_SaveSolutionCaption, MessageBoxButton.YesNoCancel);
							if (result == MessageBoxResult.Yes)
							{
								SaveSolution(solution, false);
							}
							else if (result == MessageBoxResult.Cancel)
							{
								solutionsClosed = false;
								closeSolutionOK = false;
							}
						}
					}
					if (closeSolutionOK == true)
					{
						TreeViewModel.SolutionsFolder.CloseSolution(solution);
						TreeViewModel.Refresh(true);
						TreeViewModel.ShowStatus(DisplayValues.Message_Solution + currentSolution.SolutionName + DisplayValues.Message_SolutionClosed, null, false, false);
					}
				}
			}
			catch (ApplicationException ex)
			{
				TreeViewModel.ShowException(ex);
			}
			catch (Exception ex)
			{
				TreeViewModel.ShowException(ex);
			}
			return solutionsClosed;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method selects a tree view item on right mouse down.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			ModelTreeViewItem treeViewItem = VisualItemHelper.VisualUpwardSearch<ModelTreeViewItem>(e.OriginalSource as DependencyObject) as ModelTreeViewItem;
			if (treeViewItem != null)
			{
				treeViewItem.Focus();
				e.Handled = true;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method performs tasks after loading the tree view such as setting
		/// initial focus.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void solutionsModel_Loaded(object sender, RoutedEventArgs e)
		{
			if (TreeViewModel != null && TreeViewModel.SolutionsFolder != null)
			{
				TreeViewModel.SolutionsFolder.IsSelected = true;
				TreeViewModel.SolutionsFolder.NeedsFocus = true;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method passes along status changed events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void StatusView_StatusChanged(object sender, StatusEventArgs args)
		{
			OnStatusChanged(sender, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method passes along progress changed events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void StatusView_ProgressChanged(object sender, StatusEventArgs args)
		{
			OnProgressChanged(sender, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method passes along output changed events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OutputView_OutputChanged(object sender, StatusEventArgs args)
		{
			OnOutputChanged(sender, args);
			OutputViewModel_OutputChanged(sender, args);
		}
		List<OKDialog> dialogs = new List<OKDialog>();
		void Output_Unloaded(object sender, RoutedEventArgs e)
		{
			while (dialogs.Count > 0)
			{
				dialogs[0].Close();
			}
		}
		delegate void OutputViewModel_OutputChangedCallback(object sender, StatusEventArgs args);
		void OutputViewModel_OutputChanged(object sender, StatusEventArgs args)
		{
			if (Dispatcher.Thread != System.Threading.Thread.CurrentThread)
			{
				OutputViewModel_OutputChangedCallback callback = new OutputViewModel_OutputChangedCallback(OutputViewModel_OutputChanged);
				Dispatcher.Invoke(callback, new object[] { sender, args });
			}
			else
			{
				if (args != null && args.ShowMessageBox == true)
				{
					DialogViewModel dialogView = new DialogViewModel();
					dialogView.Text = args.Text;
					if (String.IsNullOrEmpty(args.Title))
					{
						dialogView.Title = DisplayValues.Message_IssueCaption;
					}
					else
					{
						dialogView.Title = args.Title;
					}
					if (dialogs.Count > 0 && dialogs[dialogs.Count - 1].IsVisible == true)
					{
						dialogs[dialogs.Count - 1].LoadViewModel(dialogView);
					}
					else
					{
						OKDialog dialog = new OKDialog(dialogView);
						//dialog.Owner = VisualItemHelper.FindParent<Window>(this);
						dialogs.Add(dialog);
						dialog.Closed += new EventHandler(dialog_Closed);
						dialog.Show();
					}
				}
			}
		}
		void dialog_Closed(object sender, EventArgs e)
		{
			if (sender is OKDialog)
			{
				dialogs.Remove(sender as OKDialog);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method passes along show designer requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void TreeViewModel_ShowSolutionDesignerRequested(object sender, SolutionEventArgs args)
		{
			OnShowSolutionDesignerRequested(sender, args);
		}

		#endregion "Methods"

		#region "Events"
		public delegate void StatusChangeEventHandler(object sender, StatusEventArgs args);
		public delegate void SolutionEventHandler(object sender, SolutionEventArgs args);

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling progress changes.</summary>
		///--------------------------------------------------------------------------------
		public event StatusChangeEventHandler ProgressChanged;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles progress changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnProgressChanged(object sender, StatusEventArgs args)
		{
			if (ProgressChanged != null)
			{
				ProgressChanged(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling status changes.</summary>
		///--------------------------------------------------------------------------------
		public event StatusChangeEventHandler StatusChanged;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles status changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnStatusChanged(object sender, StatusEventArgs args)
		{
			if (StatusChanged != null)
			{
				StatusChanged(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling output changes.</summary>
		///--------------------------------------------------------------------------------
		public event StatusChangeEventHandler OutputChanged;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles output changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnOutputChanged(object sender, StatusEventArgs args)
		{
			if (OutputChanged != null)
			{
				OutputChanged(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to open an output solution.</summary>
		///--------------------------------------------------------------------------------
		public event SolutionEventHandler OpenOutputSolutionRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles open output solution requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnOpenOutputSolutionRequested(object sender, SolutionEventArgs args)
		{
			if (OpenOutputSolutionRequested != null)
			{
				OpenOutputSolutionRequested(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to show the solution designer.</summary>
		///--------------------------------------------------------------------------------
		public event SolutionEventHandler ShowSolutionDesignerRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles show solution designer requests.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnShowSolutionDesignerRequested(object sender, SolutionEventArgs args)
		{
			if (ShowSolutionDesignerRequested != null)
			{
				ShowSolutionDesignerRequested(this, args);
			}
		}

		#endregion "Events"

		#region "Constructors"
		public SolutionBuilderControl()
		{
			InitializeComponent();
			string testMessage = "";
			DataContext = testMessage;
			TreeViewModel = new BuilderViewModel();
			TreeViewModel.FocusRequested += new EventHandler(TreeViewModel_FocusRequested);
			TreeViewModel.ShowSolutionDesignerRequested += new BuilderViewModel.SolutionEventHandler(TreeViewModel_ShowSolutionDesignerRequested);
			DataContext = TreeViewModel;
			OutputView = new OutputViewModel();
			OutputView.OutputChanged += new OutputViewModel.StatusChangeEventHandler(OutputView_OutputChanged);
			StatusView = new StatusViewModel();
			StatusView.ProgressChanged += new StatusViewModel.StatusChangeEventHandler(StatusView_ProgressChanged);
			StatusView.StatusChanged += new StatusViewModel.StatusChangeEventHandler(StatusView_StatusChanged);
			this.Unloaded += new RoutedEventHandler(Output_Unloaded);
		}

		#endregion "Constructors"
	}
}
