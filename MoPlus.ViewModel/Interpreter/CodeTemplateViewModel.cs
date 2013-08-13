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
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using ICSharpCode.AvalonEdit.Document;
using MoPlus.ViewModel.Resources;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Data;
using MoPlus.Interpreter;
using MoPlus.ViewModel.Events.Solutions;

namespace MoPlus.ViewModel.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the CodeTemplateViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/19/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class CodeTemplateViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParseContentButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParseContentButtonLabel
		{
			get
			{
				return DisplayValues.Button_ParseContent;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParseOutputButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ParseOutputButtonLabel
		{
			get
			{
				return DisplayValues.Button_ParseOutput;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Nodes.</summary>
		///--------------------------------------------------------------------------------
		public SortableObservableCollection<string> Nodes
		{
			get
			{
				return DataConventionHelper.CodeTemplateNodes;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateContentHeader.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateContentHeader
		{
			get
			{
				return DisplayValues.Edit_TemplateContentProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateOutputHeader.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateOutputHeader
		{
			get
			{
				return DisplayValues.Edit_TemplateOutputProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateConfigurationHeader.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateConfigurationHeader
		{
			get
			{
				return DisplayValues.Edit_Configuration;
			}
		}

		#endregion "Editing Support"

		#region "Events"
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling content parses.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler ContentContinued;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles content parsed events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnContentContinued(object sender, EventArgs args)
		{
			if (ContentContinued != null)
			{
				ContentContinued(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling output parses.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler OutputContinued;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles output parsed events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnOutputContinued(object sender, EventArgs args)
		{
			if (OutputContinued != null)
			{
				OutputContinued(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling stopping of content parses.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler ContentStopped;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling stopping of content parses.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnContentStopped(object sender, EventArgs args)
		{
			if (ContentStopped != null)
			{
				ContentStopped(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling stopping of output parses.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler OutputStopped;

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling stopping of output parses.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnOutputStopped(object sender, EventArgs args)
		{
			if (OutputStopped != null)
			{
				OutputStopped(this, args);
			}
		}

		public delegate void DebugEventHandler(object sender, SolutionDebugEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling breakpoints.</summary>
		///--------------------------------------------------------------------------------
		public event DebugEventHandler ContentBreakpointReached;

		///--------------------------------------------------------------------------------
		/// <summary>This method breakpoints.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnContentBreakpointReached(object sender, SolutionDebugEventArgs args)
		{
			if (ContentBreakpointReached != null)
			{
				ContentBreakpointReached(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling breakpoints.</summary>
		///--------------------------------------------------------------------------------
		public event DebugEventHandler OutputBreakpointReached;

		///--------------------------------------------------------------------------------
		/// <summary>This method breakpoints.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnOutputBreakpointReached(object sender, SolutionDebugEventArgs args)
		{
			if (OutputBreakpointReached != null)
			{
				OutputBreakpointReached(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Handle breakpoint.</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="lineNumber">The associated line number.</param>
		///--------------------------------------------------------------------------------
		public void HandleBreakpoint(InterpreterTypeCode interpreterType, IDomainEnterpriseObject modelContext, int lineNumber)
		{
			SolutionDebugEventArgs args = new SolutionDebugEventArgs();
			args.InterpreterType = interpreterType;
			args.Solution = Solution;
			args.TemplateContext = CodeTemplate;
			args.ModelContext = modelContext;
			args.LineNumber = lineNumber;
			if (interpreterType == InterpreterTypeCode.Content)
			{
				OnContentBreakpointReached(this, args);
			}
			else if (interpreterType == InterpreterTypeCode.Output)
			{
				OnOutputBreakpointReached(this, args);
			}
		}

		#endregion

		#region "Command Processing"
		private RelayCommand _parseContentCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Parse the content.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand ParseContentCommand
		{
			get
			{
				if (_parseContentCommand == null)
					_parseContentCommand = new RelayCommand(param => this.ParseContent());

				return _parseContentCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method parses the content.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void ParseContent()
		{
			OnContentContinued(this, null);
		}

		private RelayCommand _parseOutputCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Parse the output.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand ParseOutputCommand
		{
			get
			{
				if (_parseOutputCommand == null)
					_parseOutputCommand = new RelayCommand(param => this.ParseOutput());

				return _parseOutputCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method parses the output.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void ParseOutput()
		{
			OnOutputContinued(this, null);
		}

		private RelayCommand _stopContentCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Stop parsing the content.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand StopContentCommand
		{
			get
			{
				if (_stopContentCommand == null)
					_stopContentCommand = new RelayCommand(param => this.StopContent());

				return _stopContentCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method stops parsing the content.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void StopContent()
		{
			OnContentStopped(this, null);
		}

		private RelayCommand _stopOutputCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Stop parsing the output.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand StopOutputCommand
		{
			get
			{
				if (_stopOutputCommand == null)
					_stopOutputCommand = new RelayCommand(param => this.StopOutput());

				return _stopOutputCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method stops parsing the content.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void StopOutput()
		{
			OnOutputStopped(this, null);
		}

		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets GoButtonToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string GoButtonToolTip
		{
			get
			{
				return DisplayValues.Button_Go_ToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StopButtonToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string StopButtonToolTip
		{
			get
			{
				return DisplayValues.Button_Stop_ToolTip;
			}
		}

		private bool _isDebuggerRunning = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsDebuggerRunning.</summary>
		///--------------------------------------------------------------------------------
		public bool IsDebuggerRunning
		{
			get
			{
				return _isDebuggerRunning;
			}
			set
			{
				if (_isDebuggerRunning != value)
				{
					_isDebuggerRunning = value;
					OnPropertyChanged("IsDebuggerRunning");
				}
			}
		}

		private bool _isContentWatchReadOnly = true;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsContentWatchReadOnly.</summary>
		///--------------------------------------------------------------------------------
		public bool IsContentWatchReadOnly
		{
			get
			{
				return _isContentWatchReadOnly;
			}
			set
			{
				if (_isContentWatchReadOnly != value)
				{
					_isContentWatchReadOnly = value;
					OnPropertyChanged("IsContentWatchReadOnly");
				}
			}
		}

		private bool _isOutputWatchReadOnly = true;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsOutputWatchReadOnly.</summary>
		///--------------------------------------------------------------------------------
		public bool IsOutputWatchReadOnly
		{
			get
			{
				return _isOutputWatchReadOnly;
			}
			set
			{
				if (_isOutputWatchReadOnly != value)
				{
					_isOutputWatchReadOnly = value;
					OnPropertyChanged("IsOutputWatchReadOnly");
				}
			}
		}

		private string _contentDebugGoVisibility;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ContentDebugGoVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string ContentDebugGoVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(_contentDebugGoVisibility))
				{
					if (DebugHelper.DebugAction == DebugAction.None || DebugHelper.DebugAction == DebugAction.Run)
					{
						_contentDebugGoVisibility = "Visible";
					}
					else
					{
						_contentDebugGoVisibility = "Collapsed";
					}
				}
				return _contentDebugGoVisibility;
			}
			set
			{
				_contentDebugGoVisibility = value;
				OnPropertyChanged("ContentDebugGoVisibility");
			}
		}

		private string _contentDebugStopVisibility = "Collapsed";
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ContentDebugStopVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string ContentDebugStopVisibility
		{
			get
			{
				return _contentDebugStopVisibility;
			}
			set
			{
				_contentDebugStopVisibility = value;
				OnPropertyChanged("ContentDebugStopVisibility");
			}
		}

		private string _contentWatchesVisibility = "Collapsed";
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ContentWatchesVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string ContentWatchesVisibility
		{
			get
			{
				return _contentWatchesVisibility;
			}
			set
			{
				_contentWatchesVisibility = value;
				OnPropertyChanged("ContentWatchesVisibility");
			}
		}

		private string _outputDebugGoVisibility;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets OutputDebugGoVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string OutputDebugGoVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(_outputDebugGoVisibility))
				{
					if (DebugHelper.DebugAction == DebugAction.None || DebugHelper.DebugAction == DebugAction.Run)
					{
						_outputDebugGoVisibility = "Visible";
					}
					else
					{
						_outputDebugGoVisibility = "Collapsed";
					}
				}
				return _outputDebugGoVisibility;
			}
			set
			{
				_outputDebugGoVisibility = value;
				OnPropertyChanged("OutputDebugGoVisibility");
			}
		}

		private string _outputDebugStopVisibility = "Collapsed";
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets OutputDebugStopVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string OutputDebugStopVisibility
		{
			get
			{
				return _outputDebugStopVisibility;
			}
			set
			{
				_outputDebugStopVisibility = value;
				OnPropertyChanged("OutputDebugStopVisibility");
			}
		}

		private string _outputWatchesVisibility = "Collapsed";
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets OutputWatchesVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string OutputWatchesVisibility
		{
			get
			{
				return _outputWatchesVisibility;
			}
			set
			{
				_outputWatchesVisibility = value;
				OnPropertyChanged("OutputWatchesVisibility");
			}
		}

		private bool _isConfigTabActive = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsConfigTabActive.</summary>
		///--------------------------------------------------------------------------------
		public bool IsConfigTabActive
		{
			get
			{
				return _isConfigTabActive;
			}
			set
			{
				if (value == true || IsOutputTabActive == true || IsContentTabActive == true)
				{
					_isConfigTabActive = value;
				}
				if (_isConfigTabActive == true)
				{
					IsContentTabActive = false;
					IsOutputTabActive = false;
					OnPropertyChanged("IsConfigTabActive");
					OnPropertyChanged("IsContentTabActive");
					OnPropertyChanged("IsOutputTabActive");
				}
			}
		}

		private bool _isContentTabActive = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsContentTabActive.</summary>
		///--------------------------------------------------------------------------------
		public bool IsContentTabActive
		{
			get
			{
				return _isContentTabActive;
			}
			set
			{
				if (value == true || IsOutputTabActive == true || IsConfigTabActive == true)
				{
					_isContentTabActive = value;
				}
				if (_isContentTabActive == true)
				{
					IsConfigTabActive = false;
					IsOutputTabActive = false;
					OnPropertyChanged("IsConfigTabActive");
					OnPropertyChanged("IsContentTabActive");
					OnPropertyChanged("IsOutputTabActive");
				}
			}
		}

		private bool _isOutputTabActive = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsOutputTabActive.</summary>
		///--------------------------------------------------------------------------------
		public bool IsOutputTabActive
		{
			get
			{
				return _isOutputTabActive;
			}
			set
			{
				if (value == true || IsConfigTabActive == true || IsContentTabActive == true)
				{
					_isOutputTabActive = value;
				}
				if (_isOutputTabActive == true)
				{
					IsConfigTabActive = false;
					IsContentTabActive = false;
					OnPropertyChanged("IsConfigTabActive");
					OnPropertyChanged("IsContentTabActive");
					OnPropertyChanged("IsOutputTabActive");
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Template path.</summary>
		///--------------------------------------------------------------------------------
		public string TemplatePath { get; set; }

		TextDocument _templateContentDocument = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplateContentDocument.</summary>
		///--------------------------------------------------------------------------------
		public TextDocument TemplateContentDocument
		{
			get
			{
				if (_templateContentDocument == null)
				{
					_templateContentDocument = new TextDocument();
					_templateContentDocument.Text = EditCodeTemplate.TemplateContent;
					_templateContentDocument.TextChanged += new EventHandler(_templateContentDocument_TextChanged);
				}
				return _templateContentDocument;
			}
			set
			{
				_templateContentDocument = value;
			}
		}
		private void _templateContentDocument_TextChanged(object sender, EventArgs e)
		{
			OnPropertyChanged("TemplateContent");
			EditCodeTemplate.ResetModified(true);
		}

		TextDocument _templateOutputDocument = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplateOutputDocument.</summary>
		///--------------------------------------------------------------------------------
		public TextDocument TemplateOutputDocument
		{
			get
			{
				if (_templateOutputDocument == null)
				{
					_templateOutputDocument = new TextDocument();
					_templateOutputDocument.Text = EditCodeTemplate.TemplateOutput;
					_templateOutputDocument.TextChanged += new EventHandler(_templateOutputDocument_TextChanged);
				}
				return _templateOutputDocument;
			}
			set
			{
				_templateOutputDocument = value;
			}
		}
		private void _templateOutputDocument_TextChanged(object sender, EventArgs e)
		{
			OnPropertyChanged("TemplateOutput");
			EditCodeTemplate.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsTemplateUtilized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsTemplateUtilized
		{
			get
			{
				return CodeTemplate.IsTemplateUtilized && CodeTemplate.HasErrors == false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ToolTipText.</summary>
		///--------------------------------------------------------------------------------
		public string ToolTipText
		{
			get
			{
				return CodeTemplate.TemplateCallInfo;
			}
		}

		private double _contenttOffset = 0.0;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ContentOffset.</summary>
		///--------------------------------------------------------------------------------
		public double ContentOffset
		{
			get
			{
				return _contenttOffset;
			}
			set
			{
				_contenttOffset = value;
				OnPropertyChanged("ContentOffset");
			}
		}

		private double _outputOffset = 0.0;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets OutputOffset.</summary>
		///--------------------------------------------------------------------------------
		public double OutputOffset
		{
			get
			{
				return _outputOffset;
			}
			set
			{
				_outputOffset = value;
				OnPropertyChanged("OutputOffset");
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ContentDebugItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DebugItem> ContentDebugItems
		{
			get
			{
				return CodeTemplate.ContentDebugItems;
			}
			set
			{
				CodeTemplate.ContentDebugItems = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets OutputDebugItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DebugItem> OutputDebugItems
		{
			get
			{
				return CodeTemplate.OutputDebugItems;
			}
			set
			{
				CodeTemplate.OutputDebugItems = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentModelContext.</summary>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject CurrentModelContext { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method updates visibility based on current debug state.</summary>
		/// 
		/// <param name="solution">The corresponding solution.</param>
		///--------------------------------------------------------------------------------
		public void SetDebugVisibility(DebugAction debugAction, InterpreterTypeCode debugType, Guid templateID)
		{
			switch (debugAction)
			{
				case DebugAction.Breaking:
				case DebugAction.Continue:
					IsDebuggerRunning = true;
					break;
				default:
					IsDebuggerRunning = false;
					break;
			}
			switch (debugType)
			{
				case InterpreterTypeCode.Content:
					if (TemplateID != templateID)
					{
						// make everything invisible
						ContentDebugGoVisibility = "Collapsed";
						ContentDebugStopVisibility = "Collapsed";
						ContentWatchesVisibility = "Collapsed";
						OutputDebugGoVisibility = "Collapsed";
						OutputDebugStopVisibility = "Collapsed";
						OutputWatchesVisibility = "Collapsed";
						IsContentWatchReadOnly = true;
						IsOutputWatchReadOnly = true;
					}
					else
					{
						OutputDebugGoVisibility = "Collapsed";
						OutputDebugStopVisibility = "Collapsed";
						OutputWatchesVisibility = "Collapsed";
						IsOutputWatchReadOnly = true;
						switch (debugAction)
						{
							case DebugAction.Breaking:
								ContentDebugGoVisibility = "Visible";
								ContentDebugStopVisibility = "Visible";
								ContentWatchesVisibility = "Visible";
								IsContentWatchReadOnly = false;
								break;
							case DebugAction.Continue:
								ContentDebugGoVisibility = "Collapsed";
								ContentDebugStopVisibility = "Visible";
								ContentWatchesVisibility = "Visible";
								IsContentWatchReadOnly = true;
								break;
							default:
								OutputDebugGoVisibility = "Visible";
								ContentDebugGoVisibility = "Visible";
								ContentDebugStopVisibility = "Collapsed";
								ContentWatchesVisibility = "Collapsed";
								IsContentWatchReadOnly = true;
								break;
						}
					}
					break;
				case InterpreterTypeCode.Output:
					if (TemplateID != templateID)
					{
						// make everything invisible
						ContentDebugGoVisibility = "Collapsed";
						ContentDebugStopVisibility = "Collapsed";
						ContentWatchesVisibility = "Collapsed";
						OutputDebugGoVisibility = "Collapsed";
						OutputDebugStopVisibility = "Collapsed";
						OutputWatchesVisibility = "Collapsed";
						IsContentWatchReadOnly = true;
						IsOutputWatchReadOnly = true;
					}
					else
					{
						ContentDebugGoVisibility = "Collapsed";
						ContentDebugStopVisibility = "Collapsed";
						ContentWatchesVisibility = "Collapsed";
						IsContentWatchReadOnly = true;
						switch (debugAction)
						{
							case DebugAction.Breaking:
								OutputDebugGoVisibility = "Visible";
								OutputDebugStopVisibility = "Visible";
								OutputWatchesVisibility = "Visible";
								IsOutputWatchReadOnly = false;
								break;
							case DebugAction.Continue:
								OutputDebugGoVisibility = "Collapsed";
								OutputDebugStopVisibility = "Visible";
								OutputWatchesVisibility = "Visible";
								IsOutputWatchReadOnly = true;
								break;
							default:
								ContentDebugGoVisibility = "Visible";
								OutputDebugGoVisibility = "Visible";
								OutputDebugStopVisibility = "Collapsed";
								OutputWatchesVisibility = "Collapsed";
								IsOutputWatchReadOnly = true;
								break;
						}
					}
					break;
				default:
					// assume debugging is done, set to initial state
					ContentDebugGoVisibility = "Visible";
					ContentDebugStopVisibility = "Collapsed";
					ContentWatchesVisibility = "Collapsed";
					OutputDebugGoVisibility = "Visible";
					OutputDebugStopVisibility = "Collapsed";
					OutputWatchesVisibility = "Collapsed";
					IsContentWatchReadOnly = true;
					IsOutputWatchReadOnly = true;
					break;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the corresponding solution.</summary>
		/// 
		/// <param name="solution">The corresponding solution.</param>
		///--------------------------------------------------------------------------------
		public void UpdateSolution(Solution solution)
		{
			Solution = solution;
			CodeTemplate.Solution = solution;
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="codeTemplate">The CodeTemplate to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="templateURL">The Template file path.</param>
		///--------------------------------------------------------------------------------
		public CodeTemplateViewModel(CodeTemplate codeTemplate, Solution solution, string templateURL)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadCodeTemplate(codeTemplate);

			if (!String.IsNullOrEmpty(templateURL))
			{
				CodeTemplate.FilePath = templateURL;
			}
			TemplatePath = CodeTemplate.FilePath;
			IsConfigTabActive = true;
		}

		#endregion "Constructors"
	}
}
