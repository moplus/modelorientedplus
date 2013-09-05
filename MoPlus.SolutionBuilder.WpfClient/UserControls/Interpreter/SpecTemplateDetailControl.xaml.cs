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
using MoPlus.SolutionBuilder.WpfClient.Library;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using System.IO;
using System.Xml;
using System.Windows.Threading;
using MoPlus.ViewModel.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Data;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using System.ComponentModel;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Messaging;
using MoPlus.Interpreter.BLL.Models;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit;
using System.Threading;

namespace MoPlus.SolutionBuilder.WpfClient.UserControls.Interpreter
{
	/// <summary>
	/// Interaction logic for SpecTemplateDetailControl.xaml
	/// </summary>
	public partial class SpecTemplateDetailControl : EditControl
	{
		FoldingManager contentFoldingManager;
		AbstractFoldingStrategy contentFoldingStrategy;
		FoldingManager outputFoldingManager;
		AbstractFoldingStrategy outputFoldingStrategy;
		FindReplaceMgr FRM = FindReplaceMgr.Instance;
		TextEditorAdapter contentAdapter;
		TextEditorAdapter outputAdapter;
		DispatcherTimer foldingUpdateTimer;
		List<SpecTemplateContentDialog> dialogs = new List<SpecTemplateContentDialog>();
		Solution ViewSolution { get; set; }
		CompletionWindow contentCompletionWindow;
		CompletionWindow outputCompletionWindow;
		BreakPointLineColorizer contentBreakpointColorizer;
		BreakPointLineColorizer outputBreakpointColorizer;

		public SpecTemplateDetailControl()
		{
		
			InitializeComponent();

			// set up folding strategy and updates
			foldingUpdateTimer = new DispatcherTimer();
			foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
			foldingUpdateTimer.Tick += foldingUpdateTimer_Tick;
			this.Unloaded += new RoutedEventHandler(TemplateControl_Unloaded);
			this.Loaded += new RoutedEventHandler(TemplateControl_Loaded);
			this.DataContextChanged += new DependencyPropertyChangedEventHandler(SpecTemplateDetailControl_DataContextChanged);
			ContentEditor.DocumentChanged += new EventHandler(ContentEditor_DocumentChanged);
			OutputEditor.DocumentChanged += new EventHandler(OutputEditor_DocumentChanged);
			ContentEditor.TextArea.TextEntering += new TextCompositionEventHandler(ContentEditor_TextEntering);
			ContentEditor.TextArea.TextEntered += new TextCompositionEventHandler(ContentEditor_TextEntered);
			OutputEditor.TextArea.TextEntering += new TextCompositionEventHandler(OutputEditor_TextEntering);
			OutputEditor.TextArea.TextEntered += new TextCompositionEventHandler(OutputEditor_TextEntered);
			contentBreakpointColorizer = new BreakPointLineColorizer(0);
			outputBreakpointColorizer = new BreakPointLineColorizer(0);

			// set up find and replace managers
			contentAdapter = new TextEditorAdapter(ContentEditor);
			outputAdapter = new TextEditorAdapter(OutputEditor);
			FRM.CurrentEditor = contentAdapter;
			FRM.ShowSearchIn = false;
			FRM.OwnerWindow = VisualItemHelper.FindParent<Window>(this);
			CommandBindings.Add(FRM.FindBinding);
			CommandBindings.Add(FRM.ReplaceBinding);
			CommandBindings.Add(FRM.FindNextBinding);

			// set up text editing hotkeys
			//ContentEditor.CommandBindings.Add(new CommandBinding(

			// set up breakpoint margins
			ContentEditor.TextArea.LeftMargins.Insert(0, new BreakPointMargin(true));
			OutputEditor.TextArea.LeftMargins.Insert(0, new BreakPointMargin(false));
		}

		private bool IsCaretInSection(TextEditor editor, string includeSections, string excludeSections)
		{
			DocumentHighlighter highlighter = editor.TextArea.GetService(typeof(IHighlighter)) as DocumentHighlighter;
			int off = editor.TextArea.Document.GetOffset(editor.TextArea.Caret.Line, editor.TextArea.Caret.Column);
			HighlightedLine result = highlighter.HighlightLine(editor.TextArea.Caret.Line);
			if (!String.IsNullOrEmpty(excludeSections))
			{
				foreach (string section in excludeSections.Split(','))
				{
					if (result.Sections.Any(s => s.Offset <= off && s.Offset + s.Length >= off && s.Color.Name == section))
					{
						return false;
					}
				}
			}
			bool isInSection = false;
			if (!String.IsNullOrEmpty(excludeSections))
			{
				foreach (string section in includeSections.Split(','))
				{
					if (result.Sections.Any(s => s.Offset <= off && s.Offset + s.Length >= off && s.Color.Name == section))
					{
						isInSection = true;
						break;
					}
				}
			}
			return isInSection;
		}

		void ContentEditor_TextEntered(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == "." && IsCaretInSection(ContentEditor, "ContentPropertyRecognized,Property", "Comment,Literal"))
			{
				if (contentCompletionWindow == null)
				{
					// provide completion to model context, properties, and methods
					contentCompletionWindow = new CompletionWindow(ContentEditor.TextArea);
					IList<ICompletionData> data = contentCompletionWindow.CompletionList.CompletionData;
					List<string> properties = new List<string>(GrammarHelper.SpecCompletionPropertiesAndMethods);
					if (ViewSolution != null)
					{
						foreach (string key in ViewSolution.ModelPropertyNames.AllKeys)
						{
							properties.Add(key);
						}
					}
					properties.Sort();
					foreach (string key in properties)
					{
						data.Add(new CodeCompletionElement(key));
					}
					contentCompletionWindow.Show();
					contentCompletionWindow.Closed += delegate
					{
						contentCompletionWindow = null;
					};
				}
			}
		}

		void ContentEditor_TextEntering(object sender, TextCompositionEventArgs e)
		{
			if (e.Text.Length > 0 && contentCompletionWindow != null)
			{
				if (!char.IsLetterOrDigit(e.Text[0]))
				{
					// Whenever a non-letter is typed while the completion window is open,
					// insert the currently selected element.
					contentCompletionWindow.CompletionList.RequestInsertion(e);
				}
			}
			// Do not set e.Handled=true.
			// We still want to insert the character that was typed.
		}

		void OutputEditor_TextEntered(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == ".")
			{
				if (outputCompletionWindow == null && IsCaretInSection(OutputEditor, "ContentPropertyRecognized,Property", "Comment,Literal"))
				{
					// provide completion to model context, properties, and methods
					outputCompletionWindow = new CompletionWindow(OutputEditor.TextArea);
					IList<ICompletionData> data = outputCompletionWindow.CompletionList.CompletionData;
					List<string> properties = new List<string>(GrammarHelper.SpecCompletionPropertiesAndMethods);
					if (ViewSolution != null)
					{
						foreach (string key in ViewSolution.ModelPropertyNames.AllKeys)
						{
							properties.Add(key);
						}
					}
					properties.Sort();
					foreach (string key in properties)
					{
						data.Add(new CodeCompletionElement(key));
					}
					outputCompletionWindow.Show();
					outputCompletionWindow.Closed += delegate
					{
						outputCompletionWindow = null;
					};
				}
			}
		}

		void OutputEditor_TextEntering(object sender, TextCompositionEventArgs e)
		{
			if (e.Text.Length > 0 && outputCompletionWindow != null)
			{
				if (!char.IsLetterOrDigit(e.Text[0]))
				{
					// Whenever a non-letter is typed while the completion window is open,
					// insert the currently selected element.
					outputCompletionWindow.CompletionList.RequestInsertion(e);
				}
			}
			// Do not set e.Handled=true.
			// We still want to insert the character that was typed.
		}

		BackgroundWorker _templateWorker = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the template worker.</summary>
		///--------------------------------------------------------------------------------
		BackgroundWorker TemplateWorker
		{
			get
			{
				if (_templateWorker == null)
				{
					_templateWorker = new BackgroundWorker();
					_templateWorker.WorkerReportsProgress = true;
					_templateWorker.WorkerSupportsCancellation = true;
					_templateWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(templateWorker_ProgressCompleted);
					_templateWorker.Disposed += new EventHandler(templateWorker_Disposed);
					_templateWorker.ProgressChanged += new ProgressChangedEventHandler(templateWorker_ProgressChanged);
				}
				return _templateWorker;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the template work handler.</summary>
		///--------------------------------------------------------------------------------
		protected DoWorkEventHandler TemplateWorkHandler { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the template work completed handler.</summary>
		///--------------------------------------------------------------------------------
		protected RunWorkerCompletedEventHandler TemplateWorkCompletedHandler { get; set; }

		protected BackgroundWorkerParameters _templateWorkParameters = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the template work parameters.</summary>
		///--------------------------------------------------------------------------------
		protected BackgroundWorkerParameters TemplateWorkParameters
		{
			get
			{
				if (_templateWorkParameters == null)
				{
					_templateWorkParameters = new BackgroundWorkerParameters();
				}
				return _templateWorkParameters;
			}
			set
			{
				_templateWorkParameters = value;
			}
		}

		protected class BackgroundWorkerParameters
		{
			public JobTypeCode JobType;
			public Solution Solution;
			public SpecTemplate Template;
			public SpecTemplateViewModel View;
			public string Content;
			public string Output;
		}
		protected enum JobTypeCode
		{
			None = 0,
			Content = 2,
			Output = 3
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles context changes.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void SpecTemplateDetailControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null && view.Solution != null && view.Solution != ViewSolution)
			{
				ViewSolution = view.Solution;
				UpdateTextHighlighting();
			}
			if (view != null)
			{
				ContentEditor.ScrollToVerticalOffset(view.ContentOffset);
				OutputEditor.ScrollToVerticalOffset(view.OutputOffset);
				view.ShowDialog -= view_ShowDialog;
				view.ShowDialog += new EventHandler(view_ShowDialog);
			}
		}

		void view_ShowDialog(object sender, EventArgs e)
		{
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null)
			{
				System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
				System.Windows.Forms.DialogResult result = dialog.ShowDialog();
				if (result == System.Windows.Forms.DialogResult.OK && !String.IsNullOrEmpty(dialog.SelectedPath))
				{
					view.SpecTemplate.SuggestedDirectory = dialog.SelectedPath;
					view.UpdateCommand.Execute(null);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the text highlighting rules.</summary>
		///--------------------------------------------------------------------------------
		protected void UpdateTextHighlighting()
		{
			string content;

			// Load content highlighting definition
			IHighlightingDefinition contentHighlighting;
			using (Stream s = typeof(SpecTemplateDetailControl).Assembly.GetManifestResourceStream("MoPlus.SolutionBuilder.WpfClient.Resources.SpecContentHighlighting.xshd"))
			{
				if (s == null)
					throw new InvalidOperationException("Could not find embedded resource");
				using (TextReader textReader = new StreamReader(s))
				{
					content = HighlightingHelper.AddSpecHighlighting(textReader.ReadToEnd(), ViewSolution);
				}
			}
			using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
			{
				using (XmlReader reader = new XmlTextReader(ms))
				{
					contentHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
				}
			}
			// and register it in the HighlightingManager
			HighlightingManager.Instance.RegisterHighlighting("Content Highlighting", new string[] { ".cool" }, contentHighlighting);

			// Load output highlighting definition
			IHighlightingDefinition outputHighlighting;
			using (Stream s = typeof(SpecTemplateDetailControl).Assembly.GetManifestResourceStream("MoPlus.SolutionBuilder.WpfClient.Resources.SpecOutputHighlighting.xshd"))
			{
				if (s == null)
					throw new InvalidOperationException("Could not find embedded resource");
				using (TextReader textReader = new StreamReader(s))
				{
					content = HighlightingHelper.AddSpecHighlighting(textReader.ReadToEnd(), ViewSolution);
				}
			}
			using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
			{
				using (XmlReader reader = new XmlTextReader(ms))
				{
					outputHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
				}
			}
			// and register it in the HighlightingManager
			HighlightingManager.Instance.RegisterHighlighting("Output Highlighting", new string[] { ".cool" }, outputHighlighting);

			// set up highlighting and indentation
			ContentEditor.SyntaxHighlighting = contentHighlighting;
			//ContentEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(ContentEditor.Options);
			OutputEditor.SyntaxHighlighting = outputHighlighting;
			//OutputEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(OutputEditor.Options);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reporting ongoing progress of the template job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void templateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles reporting completed progress of the template job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void templateWorker_ProgressCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles disposing of the background worker.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void templateWorker_Disposed(object sender, EventArgs e)
		{
			_templateWorker = null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method runs a job on the template background worker.</summary>
		/// 
		/// <param name="isInitialLoad">Flag indicating whether build is part of initial load
		/// into the view.</param>
		///--------------------------------------------------------------------------------
		protected bool RunBackgroundJob(JobTypeCode jobType, bool isInitialLoad = false)
		{
			bool startedJob = false;
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null && view.Solution != null)
			{
				try
				{
					if (TemplateWorker.IsBusy == false)
					{
						lock (DebugHelper.DEBUG_OBJECT)
						{
							DebugHelper.DebugAction = DebugAction.None;
							Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
						}
						//Cursor.Current = Cursors.WaitCursor;
						if (TemplateWorkHandler != null)
						{
							// remove previous work
							TemplateWorker.DoWork -= TemplateWorkHandler;
							TemplateWorkHandler = null;
						}
						if (TemplateWorkCompletedHandler != null)
						{
							// remove completed handler
							TemplateWorker.RunWorkerCompleted -= TemplateWorkCompletedHandler;
							TemplateWorkCompletedHandler = null;
						}

						// get basic parameters
						TemplateWorkParameters = null;
						TemplateWorkParameters.JobType = jobType;

						if (jobType == JobTypeCode.Content)
						{
							// send mostly empty solution for sample to create model elements
							ViewSolution = view.EditSpecTemplate.Solution;
							TemplateWorkParameters.View = view;
							TemplateWorkParameters.Solution = new Solution();
							TemplateWorkParameters.Solution.StatusChanged += new Solution.StatusEventHandler(Solution_StatusChanged);
							TemplateWorkParameters.Solution.OutputRequested += new Solution.StatusEventHandler(Solution_OutputRequested);
							TemplateWorkParameters.Solution.BreakpointReached += new Solution.DebugEventHandler(Solution_BreakpointReached);
							TemplateWorkParameters.Solution.SolutionID = Guid.NewGuid();
							TemplateWorkParameters.Solution.CodeTemplates = ViewSolution.CodeTemplates;
							TemplateWorkParameters.Solution.SpecTemplates = ViewSolution.SpecTemplates;
							TemplateWorkParameters.Solution.DatabaseSourceList = ViewSolution.DatabaseSourceList;
							TemplateWorkParameters.Solution.XmlSourceList = ViewSolution.XmlSourceList;
							TemplateWorkParameters.Solution.IsSampleMode = true;
							TemplateWorkParameters.Solution.LoggedValues.Clear();
							TemplateWorkParameters.Solution.CurrentErrorCount = 0;
							TemplateWorkParameters.Solution.ClearSpecTemplateCallData();
							TemplateWorkParameters.Solution.BuildSampleModelFromSolution(ViewSolution);
							view.EditSpecTemplate.Solution = TemplateWorkParameters.Solution;
							TemplateWorkParameters.Template = view.EditSpecTemplate;
							TemplateWorkParameters.Template.ContentBreakpoints = view.SpecTemplate.ContentBreakpoints;
							TemplateWorkHandler = new DoWorkEventHandler(UpdateContent);
							TemplateWorker.DoWork += TemplateWorkHandler;
							TemplateWorkCompletedHandler = new RunWorkerCompletedEventHandler(templateWorker_ContentCompleted);
							TemplateWorker.RunWorkerCompleted += TemplateWorkCompletedHandler;
						}
						else if (jobType == JobTypeCode.Output)
						{
							// send mostly empty solution for sample to create model elements
							ViewSolution = view.EditSpecTemplate.Solution;
							TemplateWorkParameters.View = view;
							TemplateWorkParameters.Solution = new Solution();
							TemplateWorkParameters.Solution.StatusChanged += new Solution.StatusEventHandler(Solution_StatusChanged);
							TemplateWorkParameters.Solution.OutputRequested += new Solution.StatusEventHandler(Solution_OutputRequested);
							TemplateWorkParameters.Solution.BreakpointReached += new Solution.DebugEventHandler(Solution_BreakpointReached);
							TemplateWorkParameters.Solution.SolutionID = Guid.NewGuid();
							TemplateWorkParameters.Solution.CodeTemplates = ViewSolution.CodeTemplates;
							TemplateWorkParameters.Solution.SpecTemplates = ViewSolution.SpecTemplates;
							TemplateWorkParameters.Solution.DatabaseSourceList = ViewSolution.DatabaseSourceList;
							TemplateWorkParameters.Solution.XmlSourceList = ViewSolution.XmlSourceList;
							TemplateWorkParameters.Solution.IsSampleMode = true;
							TemplateWorkParameters.Solution.LoggedValues.Clear();
							TemplateWorkParameters.Solution.CurrentErrorCount = 0;
							TemplateWorkParameters.Solution.ClearSpecTemplateCallData();
							TemplateWorkParameters.Solution.BuildSampleModelFromSolution(ViewSolution);
							view.EditSpecTemplate.Solution = TemplateWorkParameters.Solution;
							TemplateWorkParameters.Template = view.EditSpecTemplate;
							TemplateWorkParameters.Template.OutputBreakpoints = view.SpecTemplate.OutputBreakpoints;
							TemplateWorkHandler = new DoWorkEventHandler(UpdateOutput);
							TemplateWorker.DoWork += TemplateWorkHandler;
							TemplateWorkCompletedHandler = new RunWorkerCompletedEventHandler(templateWorker_OutputCompleted);
							TemplateWorker.RunWorkerCompleted += TemplateWorkCompletedHandler;
						}
						TemplateWorker.RunWorkerAsync(TemplateWorker);
						startedJob = true;
					}
					else
					{
						view.ShowIssue(String.Format(DisplayValues.Thread_ThreadBusy, view.EditSpecTemplate.TemplateName + " " + TemplateWorkParameters.JobType.ToString()));
					}
				}
				catch (ApplicationException ex)
				{
					view.ShowException(ex);
				}
				catch (Exception ex)
				{
					view.ShowException(ex);
				}
			}
			return startedJob;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the content for the template.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateContent(object sender, DoWorkEventArgs e)
		{
			if (TemplateWorkParameters.View != null && TemplateWorkParameters.View.Solution != null)
			{
				try
				{
					if (TemplateWorkParameters.Template.ParseContent() == true)
					{
						// interpret template content and produce sample code
						TemplateWorkParameters.Template.MessageBuilder.Clear();
						TemplateWorkParameters.Content = TemplateWorkParameters.Template.GetContent();
					}
				}
				catch (ApplicationException ex)
				{
					TemplateWorkParameters.View.ShowException(ex);
				}
				catch (Exception ex)
				{
					TemplateWorkParameters.View.ShowException(ex);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the completion of a job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event args.</param>
		///--------------------------------------------------------------------------------
		void templateWorker_ContentCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				ContentEditor.TextArea.TextView.LineTransformers.Remove(contentBreakpointColorizer);
				OutputEditor.TextArea.TextView.LineTransformers.Remove(outputBreakpointColorizer);
			}));
			lock (DebugHelper.DEBUG_OBJECT)
			{
				DebugHelper.DebugAction = DebugAction.None;
				Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
			}
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null)
			{
				view.IsBreaking = false;
				view.SetDebugVisibility(DebugAction.None, InterpreterTypeCode.Content, view.TemplateID);
			}
			if (view != null && view.Solution != null)
			{
				TemplateWorkParameters.Solution.ReportErrors();
				TemplateWorkParameters.Solution.StatusChanged -= Solution_StatusChanged;
				TemplateWorkParameters.Solution.OutputRequested -= Solution_OutputRequested;
				SpecTemplateContentDialog dialog = new SpecTemplateContentDialog(new SpecTemplateResultsViewModel(TemplateWorkParameters.View.TemplateName, InterpreterTypeCode.Content, TemplateWorkParameters.Template.ContentAST, TemplateWorkParameters.Content));
				dialogs.Add(dialog);
				dialog.Closed += new EventHandler(dialog_Closed);
				dialog.Show();
				TemplateWorkParameters.Solution.CodeTemplates = null;
				TemplateWorkParameters.Solution.SpecTemplates = null;
				TemplateWorkParameters.Solution.DatabaseSourceList = null;
				TemplateWorkParameters.Solution.XmlSourceList = null;
				TemplateWorkParameters.Solution.Dispose();
				TemplateWorkParameters.Solution = null;
				view.EditSpecTemplate.Solution = ViewSolution;
				SolutionEventArgs message = new SolutionEventArgs();
				message.Solution = view.Solution;
				view.Solution.AddSpecTemplateCallData();
				view.Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_RefreshSpecTemplatesRequested, message);
				SolutionDebugEventArgs debugMessage = new SolutionDebugEventArgs();
				debugMessage.Solution = view.Solution;
				debugMessage.TemplateContext = view.SpecTemplate;
				debugMessage.SolutionID = view.Solution.SolutionID;
				view.Mediator.NotifyColleagues<SolutionDebugEventArgs>(MediatorMessages.Command_DebugFinished, debugMessage);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the output for the template.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void UpdateOutput(object sender, DoWorkEventArgs e)
		{
			if (TemplateWorkParameters.View != null && TemplateWorkParameters.View.Solution != null)
			{
				try
				{
					if (TemplateWorkParameters.Template.ParseOutput() == true)
					{
						// interpret template output and produce sample code
						TemplateWorkParameters.Output = TemplateWorkParameters.Template.GenerateContentAndOutput();
					}
				}
				catch (ApplicationException ex)
				{
					TemplateWorkParameters.View.ShowException(ex);
				}
				catch (Exception ex)
				{
					TemplateWorkParameters.View.ShowException(ex);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles the completion of a job.</summary>
		/// 
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event args.</param>
		///--------------------------------------------------------------------------------
		void templateWorker_OutputCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				ContentEditor.TextArea.TextView.LineTransformers.Remove(contentBreakpointColorizer);
				OutputEditor.TextArea.TextView.LineTransformers.Remove(outputBreakpointColorizer);
			}));
			lock (DebugHelper.DEBUG_OBJECT)
			{
				DebugHelper.DebugAction = DebugAction.None;
				Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
			}
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null)
			{
				view.IsBreaking = false;
				view.SetDebugVisibility(DebugAction.None, InterpreterTypeCode.Output, view.TemplateID);
			}
			if (view != null && view.Solution != null)
			{
				TemplateWorkParameters.Solution.ReportErrors();
				TemplateWorkParameters.Solution.StatusChanged -= Solution_StatusChanged;
				TemplateWorkParameters.Solution.OutputRequested -= Solution_OutputRequested;
				SpecTemplateContentDialog dialog = new SpecTemplateContentDialog(new SpecTemplateResultsViewModel(TemplateWorkParameters.View.TemplateName, InterpreterTypeCode.Output, TemplateWorkParameters.Template.OutputAST, TemplateWorkParameters.Output));
				dialogs.Add(dialog);
				dialog.Closed += new EventHandler(dialog_Closed);
				dialog.Show();
				TemplateWorkParameters.Solution.CodeTemplates = null;
				TemplateWorkParameters.Solution.SpecTemplates = null;
				TemplateWorkParameters.Solution.DatabaseSourceList = null;
				TemplateWorkParameters.Solution.XmlSourceList = null;
				TemplateWorkParameters.Solution.DisposeCore();
				TemplateWorkParameters.Solution = null;
				view.EditSpecTemplate.Solution = ViewSolution;
				SolutionEventArgs message = new SolutionEventArgs();
				message.Solution = view.Solution;
				view.Solution.AddSpecTemplateCallData();
				view.Mediator.NotifyColleagues<SolutionEventArgs>(MediatorMessages.Command_RefreshSpecTemplatesRequested, message);
				SolutionDebugEventArgs debugMessage = new SolutionDebugEventArgs();
				debugMessage.Solution = view.Solution;
				debugMessage.TemplateContext = view.SpecTemplate;
				debugMessage.SolutionID = view.Solution.SolutionID;
				view.Mediator.NotifyColleagues<SolutionDebugEventArgs>(MediatorMessages.Command_DebugFinished, debugMessage);
			}
		}

		void TemplateControl_Loaded(object sender, RoutedEventArgs e)
		{
			foldingUpdateTimer.Start();
		}

		void TemplateControl_Unloaded(object sender, RoutedEventArgs e)
		{
			foldingUpdateTimer.Stop();
			while (dialogs.Count > 0)
			{
				dialogs[0].Close();
			}
		}

		void OutputEditor_DocumentChanged(object sender, EventArgs e)
		{
			if (DataContext is SpecTemplateViewModel)
			{
				outputFoldingStrategy = new TemplateFoldingStrategy();
				if (outputFoldingManager != null)
				{
					FoldingManager.Uninstall(outputFoldingManager);
					outputFoldingManager = null;
				}
				outputFoldingManager = FoldingManager.Install(OutputEditor.TextArea);
				outputFoldingStrategy.UpdateFoldings(outputFoldingManager, OutputEditor.Document);
			}
		}

		void ContentEditor_DocumentChanged(object sender, EventArgs e)
		{
			if (DataContext is SpecTemplateViewModel)
			{
				contentFoldingStrategy = new TemplateFoldingStrategy();
				if (contentFoldingManager != null)
				{
					FoldingManager.Uninstall(contentFoldingManager);
					contentFoldingManager = null;
				}
				contentFoldingManager = FoldingManager.Install(ContentEditor.TextArea);
				contentFoldingStrategy.UpdateFoldings(contentFoldingManager, ContentEditor.Document);
			}
		}

		private void foldingUpdateTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (contentFoldingStrategy != null && contentFoldingManager != null)
				{
					contentFoldingStrategy.UpdateFoldings(contentFoldingManager, ContentEditor.Document);
				}
				if (outputFoldingStrategy != null && outputFoldingManager != null)
				{
					outputFoldingStrategy.UpdateFoldings(outputFoldingManager, OutputEditor.Document);
				}
			}
			catch { }
		}

		private void ContentEditor_GotFocus(object sender, RoutedEventArgs e)
		{
			FRM.CurrentEditor = contentAdapter;
		}

		private void OutputEditor_GotFocus(object sender, RoutedEventArgs e)
		{
			FRM.CurrentEditor = outputAdapter;
		}

		private void ContentEditorCanPaste(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ContentEditor.TextArea.IsFocused;
		}

		private void PasteContentTextTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = ContentEditor.CaretOffset;
			ContentEditor.TextArea.Document.Insert(ContentEditor.CaretOffset, LanguageTerms.TextOpenTag + LanguageTerms.CloseTag);
			ContentEditor.CaretOffset = offset + LanguageTerms.TextOpenTag.Length;
		}

		private void PasteContentSplitTextTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = ContentEditor.CaretOffset;
			ContentEditor.TextArea.Document.Insert(ContentEditor.CaretOffset, LanguageTerms.CloseTag + LanguageTerms.TextOpenTag);
			ContentEditor.CaretOffset = offset + LanguageTerms.CloseTag.Length;
		}

		private void PasteContentEvaluationTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = ContentEditor.CaretOffset;
			ContentEditor.TextArea.Document.Insert(ContentEditor.CaretOffset, LanguageTerms.EvalOpenTag + LanguageTerms.CloseTag);
			ContentEditor.CaretOffset = offset + LanguageTerms.EvalOpenTag.Length;
		}

		private void PasteContentPropertyTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = ContentEditor.CaretOffset;
			ContentEditor.TextArea.Document.Insert(ContentEditor.CaretOffset, LanguageTerms.PropOpenTag + LanguageTerms.CloseTag);
			ContentEditor.CaretOffset = offset + LanguageTerms.PropOpenTag.Length;
		}

		private void OutputEditorCanPaste(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = OutputEditor.TextArea.IsFocused;
		}

		private void PasteOutputTextTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = OutputEditor.CaretOffset;
			OutputEditor.TextArea.Document.Insert(OutputEditor.CaretOffset, LanguageTerms.TextOpenTag + LanguageTerms.CloseTag);
			OutputEditor.CaretOffset = offset + LanguageTerms.TextOpenTag.Length;
		}

		private void PasteOutputSplitTextTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = OutputEditor.CaretOffset;
			OutputEditor.TextArea.Document.Insert(OutputEditor.CaretOffset, LanguageTerms.CloseTag + LanguageTerms.TextOpenTag);
			OutputEditor.CaretOffset = offset + LanguageTerms.CloseTag.Length;
		}

		private void PasteOutputEvaluationTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = OutputEditor.CaretOffset;
			OutputEditor.TextArea.Document.Insert(OutputEditor.CaretOffset, LanguageTerms.EvalOpenTag + LanguageTerms.CloseTag);
			OutputEditor.CaretOffset = offset + LanguageTerms.EvalOpenTag.Length;
		}

		private void PasteOutputPropertyTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = OutputEditor.CaretOffset;
			OutputEditor.TextArea.Document.Insert(OutputEditor.CaretOffset, LanguageTerms.PropOpenTag + LanguageTerms.CloseTag);
			OutputEditor.CaretOffset = offset + LanguageTerms.PropOpenTag.Length;
		}

		private void PasteOutputOutputTags(object sender, ExecutedRoutedEventArgs e)
		{
			int offset = OutputEditor.CaretOffset;
			OutputEditor.TextArea.Document.Insert(OutputEditor.CaretOffset, LanguageTerms.OutputOpenTag + LanguageTerms.CloseTag);
			OutputEditor.CaretOffset = offset + LanguageTerms.OutputOpenTag.Length;
		}

		private void Content_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			while (dialogs.Count > 0)
			{
				dialogs[0].Close();
			}
			if (DataContext is SpecTemplateViewModel)
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				view.ContentContinued -= EditControl_ContentContinued;
				view.OutputContinued -= EditControl_OutputContinued;
				view.ContentStopped -= EditControl_ContentStopped;
				view.OutputStopped -= EditControl_OutputStopped;
				view.ContentBreakpointReached -= EditControl_ContentBreakpointReached;
				view.OutputBreakpointReached -= EditControl_OutputBreakpointReached;
				view.ContentContinued += new EventHandler(EditControl_ContentContinued);
				view.OutputContinued += new EventHandler(EditControl_OutputContinued);
				view.ContentStopped += new EventHandler(EditControl_ContentStopped);
				view.OutputStopped += new EventHandler(EditControl_OutputStopped);
				view.ContentBreakpointReached += new SpecTemplateViewModel.DebugEventHandler(EditControl_ContentBreakpointReached);
				view.OutputBreakpointReached += new SpecTemplateViewModel.DebugEventHandler(EditControl_OutputBreakpointReached);
				if (view.IsConfigTabActive == false && view.IsContentTabActive == false && view.IsOutputTabActive == false)
				{
					view.IsConfigTabActive = true;
				}
			}
		}

		void EditControl_ContentBreakpointReached(object sender, SolutionDebugEventArgs args)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null)
				{
					view.IsBreaking = true;
					view.SetDebugVisibility(DebugAction.Breaking, InterpreterTypeCode.Content, view.TemplateID);
					view.CurrentModelContext = args.ModelContext;
					view.SpecTemplate.UpdateContentWatches(view.CurrentModelContext);
				}
				ContentEditor.TextArea.TextView.LineTransformers.Remove(contentBreakpointColorizer);
				contentBreakpointColorizer.LineNumber = args.LineNumber;
				ContentEditor.TextArea.TextView.LineTransformers.Add(contentBreakpointColorizer);
				ContentEditor.ScrollToLine(Math.Min(args.LineNumber + 1, ContentEditor.LineCount));
			}));
		}

		private void EditControl_ContentDebugItemChanged(object sender, DataGridCellEditEndingEventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null)
				{
					view.SpecTemplate.UpdateContentWatches(view.CurrentModelContext);
				}
			}));
		}

		private void EditControl_OutputDebugItemChanged(object sender, DataGridCellEditEndingEventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null)
				{
					view.SpecTemplate.UpdateOutputWatches(view.CurrentModelContext);
				}
			}));
		}

		void EditControl_OutputBreakpointReached(object sender, SolutionDebugEventArgs args)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null)
				{
					view.IsBreaking = true;
					view.SetDebugVisibility(DebugAction.Breaking, InterpreterTypeCode.Output, view.TemplateID);
					view.CurrentModelContext = args.ModelContext;
					view.SpecTemplate.UpdateOutputWatches(view.CurrentModelContext);
				}
				OutputEditor.TextArea.TextView.LineTransformers.Remove(outputBreakpointColorizer);
				outputBreakpointColorizer.LineNumber = args.LineNumber;
				OutputEditor.TextArea.TextView.LineTransformers.Add(outputBreakpointColorizer);
				OutputEditor.ScrollToLine(Math.Min(args.LineNumber + 1, OutputEditor.LineCount));
			}));
		}

		void EditControl_ContentStopped(object sender, EventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				ContentEditor.TextArea.TextView.LineTransformers.Remove(contentBreakpointColorizer);
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null) view.IsBreaking = false;
				if (view != null && view.ContentDebugStopVisibility != "Visible") return;
				if (DebugHelper.DebugAction == DebugAction.Breaking)
				{
					lock (DebugHelper.DEBUG_OBJECT)
					{
						DebugHelper.DebugAction = DebugAction.Stop;
						Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
					}
				}
			}));
		}

		void EditControl_OutputStopped(object sender, EventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				OutputEditor.TextArea.TextView.LineTransformers.Remove(outputBreakpointColorizer);
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null) view.IsBreaking = false;
				if (view != null && view.OutputDebugStopVisibility != "Visible") return;
				if (DebugHelper.DebugAction == DebugAction.Breaking)
				{
					lock (DebugHelper.DEBUG_OBJECT)
					{
						DebugHelper.DebugAction = DebugAction.Stop;
						Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
					}
				}
			}));
		}

		void EditControl_ContentContinued(object sender, EventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				ContentEditor.TextArea.TextView.LineTransformers.Remove(contentBreakpointColorizer);
			}));
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null) view.IsBreaking = false;
			if (view != null && view.ContentDebugGoVisibility != "Visible") return;
			if (DebugHelper.DebugAction == DebugAction.Breaking)
			{
				lock (DebugHelper.DEBUG_OBJECT)
				{
					DebugHelper.DebugAction = DebugAction.Continue;
					Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
				}
			}
			else if ((DebugHelper.DebugAction == DebugAction.None || DebugHelper.DebugAction == DebugAction.Run) && DataContext is SpecTemplateViewModel)
			{
				try
				{
					if (view != null)
					{
						// parse template content
						view.TemplateContent = view.TemplateContentDocument.Text;
						bool foundSource = false;
						foreach (DatabaseSource source in view.Solution.DatabaseSourceList)
						{
							if (source.TemplateAbsolutePath == view.SpecTemplate.FilePath)
							{
								BusinessConfiguration.CurrentSpecificationSource = source;
								foundSource = true;
								break;
							}
						}
						if (foundSource == false)
						{
							foreach (XmlSource source in view.Solution.XmlSourceList)
							{
								if (source.TemplateAbsolutePath == view.SpecTemplate.FilePath)
								{
									BusinessConfiguration.CurrentSpecificationSource = source;
									foundSource = true;
									break;
								}
							}
						}
						if (foundSource == false)
						{
							if (view.Solution.DatabaseSourceList.Count > 0)
							{
								BusinessConfiguration.CurrentSpecificationSource = view.Solution.DatabaseSourceList[DataHelper.GetRandomInt(0, view.Solution.DatabaseSourceList.Count - 1)]; // to get a random source in sample mode
							}
							else if (view.Solution.XmlSourceList.Count > 0)
							{
								BusinessConfiguration.CurrentSpecificationSource = view.Solution.XmlSourceList[DataHelper.GetRandomInt(0, view.Solution.XmlSourceList.Count - 1)]; // to get a random source in sample mode
							}
						}
						RunBackgroundJob(JobTypeCode.Content);
					}
				}
				catch (System.Exception ex)
				{
					if (view != null && view.Solution != null)
					{
						view.Solution.ShowIssue(ex.Message);
					}
					else
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		void EditControl_OutputContinued(object sender, EventArgs e)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				OutputEditor.TextArea.TextView.LineTransformers.Remove(outputBreakpointColorizer);
			}));
			SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
			if (view != null) view.IsBreaking = false;
			if (view != null && view.OutputDebugGoVisibility != "Visible") return;
			if (DebugHelper.DebugAction == DebugAction.Breaking)
			{
				lock (DebugHelper.DEBUG_OBJECT)
				{
					DebugHelper.DebugAction = DebugAction.Continue;
					Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
				}
			}
			else if ((DebugHelper.DebugAction == DebugAction.None || DebugHelper.DebugAction == DebugAction.Run) && DataContext is SpecTemplateViewModel)
			{
				try
				{
					if (view != null)
					{
						// parse template output
						view.TemplateOutput = view.TemplateOutputDocument.Text;
						bool foundSource = false;
						foreach (DatabaseSource source in view.Solution.DatabaseSourceList)
						{
							if (source.TemplateAbsolutePath == view.SpecTemplate.FilePath)
							{
								BusinessConfiguration.CurrentSpecificationSource = source;
								foundSource = true;
								break;
							}
						}
						if (foundSource == false)
						{
							foreach (XmlSource source in view.Solution.XmlSourceList)
							{
								if (source.TemplateAbsolutePath == view.SpecTemplate.FilePath)
								{
									BusinessConfiguration.CurrentSpecificationSource = source;
									foundSource = true;
									break;
								}
							}
						}
						if (foundSource == false)
						{
							if (view.Solution.DatabaseSourceList.Count > 0)
							{
								BusinessConfiguration.CurrentSpecificationSource = view.Solution.DatabaseSourceList[DataHelper.GetRandomInt(0, view.Solution.DatabaseSourceList.Count - 1)]; // to get a random source in sample mode
							}
							else if (view.Solution.XmlSourceList.Count > 0)
							{
								BusinessConfiguration.CurrentSpecificationSource = view.Solution.XmlSourceList[DataHelper.GetRandomInt(0, view.Solution.XmlSourceList.Count - 1)]; // to get a random source in sample mode
							}
						}
						RunBackgroundJob(JobTypeCode.Output);
					}
				}
				catch (System.Exception ex)
				{
					if (view != null && view.Solution != null)
					{
						view.Solution.ShowIssue(ex.Message);
					}
					else
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		void dialog_Closed(object sender, EventArgs e)
		{
			if (sender is SpecTemplateContentDialog)
			{
				dialogs.Remove(sender as SpecTemplateContentDialog);
			}
		}

		void Solution_BreakpointReached(object sender, MoPlus.Interpreter.Events.DebugEventArgs args)
		{
			this.Dispatcher.Invoke((Action)(() =>
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null)
				{
					SolutionDebugEventArgs message = new SolutionDebugEventArgs();
					message.Solution = args.SolutionContext;
					message.TemplateContext = args.TemplateContext;
					message.ModelContext = args.ModelContext;
					message.SolutionID = args.SolutionContext.SolutionID;
					message.InterpreterType = args.InterpreterType;
					message.LineNumber = args.LineNumber;
					view.Mediator.NotifyColleagues<SolutionDebugEventArgs>(MediatorMessages.Command_BreakpointReached, message);
				}
			}));
		}

		delegate void StatusViewModel_StatusChangedCallback(object sender, MoPlus.Interpreter.Events.StatusEventArgs args);
		void Solution_OutputRequested(object sender, MoPlus.Interpreter.Events.StatusEventArgs args)
		{
			if (Dispatcher.Thread != System.Threading.Thread.CurrentThread)
			{
				StatusViewModel_StatusChangedCallback callback = new StatusViewModel_StatusChangedCallback(Solution_OutputRequested);
				Dispatcher.Invoke(callback, new object[] { sender, args });
			}
			else
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null && view.Solution != null)
				{
					if (args.IsException == true)
					{
						try
						{
							view.Solution.ShowIssue(args.Text, args.Title, args.ShowMessageBox);
						}
						catch { } // issue should already be sent
					}
					else
					{
						view.Solution.ShowOutput(args.Text, args.Title, args.AppendText, args.ShowMessageBox);
					}
				}
				else
				{
					MessageBox.Show(args.Text, args.Title);
				}
			}
		}

		void Solution_StatusChanged(object sender, MoPlus.Interpreter.Events.StatusEventArgs args)
		{
			if (Dispatcher.Thread != System.Threading.Thread.CurrentThread)
			{
				StatusViewModel_StatusChangedCallback callback = new StatusViewModel_StatusChangedCallback(Solution_StatusChanged);
				Dispatcher.Invoke(callback, new object[] { sender, args });
			}
			else
			{
				SpecTemplateViewModel view = DataContext as SpecTemplateViewModel;
				if (view != null && view.Solution != null)
				{
					view.Solution.ShowStatus(args.Text, args.Title, args.AppendText, args.ShowMessageBox);
				}
				else
				{
					MessageBox.Show(args.Text, args.Title);
				}
			}
		}

		private void NextInnerTabExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (tabDesigner.SelectedIndex + 1 >= tabDesigner.Items.Count)
			{
				tabDesigner.SelectedIndex = 0;
			}
			else
			{
				tabDesigner.SelectedIndex++;
			}
		}

		private void ContentEditor_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			if (DataContext is SpecTemplateViewModel)
			{
				(DataContext as SpecTemplateViewModel).ContentOffset = ContentEditor.VerticalOffset;
			}
		}

		private void OutputEditor_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			if (DataContext is SpecTemplateViewModel)
			{
				(DataContext as SpecTemplateViewModel).OutputOffset = OutputEditor.VerticalOffset;
			}
		}
	}
}
