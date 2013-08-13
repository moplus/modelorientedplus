/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Events;
using MoPlus.Data;
using System.ComponentModel;
using System.Threading;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This abstract class requests to be removed from the UI when its CloseCommand executes.</summary>
	/// 
	/// <remarks>Derived from Microsoft MVVM design pattern example (http://msdn.microsoft.com/en-us/magazine/dd419663.aspx).</remarks>
	///--------------------------------------------------------------------------------
	public class WorkspaceViewModel : BusinessObjectBase, IWorkspaceViewModel
	{
		#region "Command Processing"
		public RoutedUICommand CloseTab
		{
			get
			{
				return CustomCommands.CloseTab;
			}
		}

		public RoutedUICommand CloseOtherTabs
		{
			get
			{
				return CustomCommands.CloseOtherTabs;
			}
		}

		public RoutedUICommand NextTab
		{
			get
			{
				return CustomCommands.NextTab;
			}
		}

		public RoutedUICommand NextInnerTab
		{
			get
			{
				return CustomCommands.NextInnerTab;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method requests to show this item in the tree view.</summary>
		///--------------------------------------------------------------------------------
		public void ShowInTreeView(bool needsFocus = true)
		{
			ShowItemInTreeView(this, needsFocus);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method requests the tree view to show the item.</summary>
		/// 
		/// <param name="itemToShow">The item to.</param>
		///--------------------------------------------------------------------------------
		public void ShowItemInTreeView(IWorkspaceViewModel itemToShow, bool needsFocus = true)
		{
			WorkspaceEventArgs message = new WorkspaceEventArgs();
			message.ItemID = itemToShow.ItemID;
			message.Workspace = itemToShow;
			message.NeedsFocus = needsFocus;
			Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_ShowItemRequested, message);
		}

		private RelayCommand _cancelJobsCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Cancel jobs.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand CancelJobsCommand
		{
			get
			{
				if (_cancelJobsCommand == null)
					_cancelJobsCommand = new RelayCommand(param => this.CancelJobs());

				return _cancelJobsCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method cancels active jobs.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void CancelJobs()
		{
			lock (DebugHelper.DEBUG_OBJECT)
			{
				if (DebugHelper.DebugAction == DebugAction.Continue || DebugHelper.DebugAction == DebugAction.Breaking)
				{
					DebugHelper.DebugAction = DebugAction.Stop;
					Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
				}
			}
		}

		#endregion "Command Processing"
		#region "Events"
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling general updates.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler Updated;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles update events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		public void OnUpdated(object sender, EventArgs args)
		{
			OnPropertyChanged("Name");
			OnPropertyChanged("Order");
			if (Updated != null)
			{
				Updated(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling initial loads.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler Loaded;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles load events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnLoaded(object sender, EventArgs args)
		{
			if (Loaded != null)
			{
				Loaded(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for requesting close confirmations.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler ConfirmClose;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles confirm close events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnConfirmClose(object sender, EventArgs args)
		{
			if (ConfirmClose != null)
			{
				ConfirmClose(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for requesting close force confirmations.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler ForceClose;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles force close events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnForceClose(object sender, EventArgs args)
		{
			if (ForceClose != null)
			{
				ForceClose(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling selections.</summary>
		///--------------------------------------------------------------------------------
		public event EventHandler Selected;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles load events.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnSelected(object sender, EventArgs args)
		{
			if (Selected != null)
			{
				Selected(sender, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling static property changes.</summary>
		///--------------------------------------------------------------------------------
		public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles static property changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected static void OnStaticPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			if (StaticPropertyChanged != null)
			{
				StaticPropertyChanged(sender, args);
			}
		}

		#endregion "Events"

		#region Fields

		RelayCommand _closeCommand;

		#endregion // Fields

		#region "Properties"
		private bool _hasErrors = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the view model has errors.</summary>
		///--------------------------------------------------------------------------------
		public bool HasErrors
		{
			get
			{
				return _hasErrors;
			}
			set
			{
				_hasErrors = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the view model has customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool HasCustomizations { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the workspace id.</summary>
		///--------------------------------------------------------------------------------
		public Guid WorkspaceID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the solution id.</summary>
		///--------------------------------------------------------------------------------
		public Guid SolutionID { get; set; }

		private Solution _solution;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Solution.</summary>
		///--------------------------------------------------------------------------------
		public Solution Solution
		{
			get
			{
				return _solution;
			}
			set
			{
				_solution = value;
				if (_solution != null && _solution.SolutionID != Guid.Empty)
				{
					SolutionID = _solution.SolutionID;
				}
				OnPropertyChanged("Solution");
			}
		}

		protected int _codeFontSize = BusinessConfiguration.CodeFontSize;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CodeFontSize.</summary>
		///--------------------------------------------------------------------------------
		public int CodeFontSize
		{
			get
			{
				return _codeFontSize;
			}
			set
			{
				if (_codeFontSize != value)
				{
					_codeFontSize = value;
					BusinessConfiguration.CodeFontSize = value;
					base.OnPropertyChanged("CodeFontSize");
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the item id, which is used to reference the
		/// corresponding instance in the model.  Not to be confused with WorkspaceID, which
		/// is the non persistent ID to this workspace view model.</summary>
		///--------------------------------------------------------------------------------
		public Guid ItemID { get; set; }

		static readonly Mediator mediator = new Mediator();
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the mediator for passing messages with data.</summary>
		///--------------------------------------------------------------------------------
		public Mediator Mediator
		{
			get { return mediator; }
		}

		private bool _isExpanded = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item is expanded.</summary>
		///--------------------------------------------------------------------------------
		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				if (_isExpanded != value)
				{
					if (value == false)
					{
						IsSelected = true;
						CollapseItems();
					}
					_isExpanded = value;
					OnPropertyChanged("IsExpanded");
				}
			}
		}

		private bool _isSelected = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item is selected.</summary>
		///--------------------------------------------------------------------------------
		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (_isSelected != value)
				{
					_isSelected = value;
					NeedsFocus = false;
					OnPropertyChanged("IsSelected");
					if (_isSelected == true)
					{
						OnSelected(this, null);
					}
				}
			}
		}

		private bool _isBreaking = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item is breaking.</summary>
		///--------------------------------------------------------------------------------
		public bool IsBreaking
		{
			get
			{
				return _isBreaking;
			}
			set
			{
				if (_isBreaking != value)
				{
					_isBreaking = value;
					OnPropertyChanged("IsBreaking");
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PropogateCurrentItem.</summary>
		///--------------------------------------------------------------------------------
		public bool PropogateCurrentItem { get; set; }

		bool _needsFocus = false;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item needs focus.</summary>
		///--------------------------------------------------------------------------------
		public bool NeedsFocus
		{
			get
			{
				return _needsFocus;
			}
			set
			{
				if (_needsFocus != value)
				{
					_needsFocus = value;
					OnPropertyChanged("NeedsFocus");
				}
			}
		}

		private readonly EnterpriseDataObjectList<WorkspaceViewModel> _items = new EnterpriseDataObjectList<WorkspaceViewModel>();
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of items (children of any type).</summary>
		///--------------------------------------------------------------------------------
		public virtual EnterpriseDataObjectList<WorkspaceViewModel> Items
		{
			get
			{
				return _items;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Item.</summary>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject Item { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the overall set of selected items (children of any type).</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<WorkspaceViewModel> SelectedItems
		{
			get
			{
				if (Items != null)
				{
					EnterpriseDataObjectList<WorkspaceViewModel> items = new EnterpriseDataObjectList<WorkspaceViewModel>();
					foreach (WorkspaceViewModel item in Items)
					{
						if (item.IsSelected == true)
						{
							items.Add(item);
						}
					}
					return items;
				}
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets UpdateButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string UpdateButtonLabel
		{
			get
			{
				return DisplayValues.Button_Update;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NewButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NewButtonLabel
		{
			get
			{
				return DisplayValues.Button_New;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ResetButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ResetButtonLabel
		{
			get
			{
				return DisplayValues.Button_Reset;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefaultsButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DefaultsButtonLabel
		{
			get
			{
				return DisplayValues.Button_Defaults;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CloseButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CloseButtonLabel
		{
			get
			{
				return DisplayValues.Button_Close;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CloseTabLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CloseTabLabel
		{
			get
			{
				return DisplayValues.ContextMenu_CloseTab;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CloseOtherTabsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CloseOtherTabsLabel
		{
			get
			{
				return DisplayValues.ContextMenu_CloseOtherTabs;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NextTabLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NextTabLabel
		{
			get
			{
				return DisplayValues.ContextMenu_NextTab;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NextInnerTabLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NextInnerTabLabel
		{
			get
			{
				return DisplayValues.ContextMenu_NextTab;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CloseTabToolTipLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CloseTabToolTipLabel
		{
			get
			{
				return DisplayValues.ContextMenu_CloseTabToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CloseOtherTabsToolTipLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CloseOtherTabsToolTipLabel
		{
			get
			{
				return DisplayValues.ContextMenu_CloseOtherTabsToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NextTabToolTipLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NextTabToolTipLabel
		{
			get
			{
				return DisplayValues.ContextMenu_NextTabToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets NextInnerTabToolTipLabel.</summary>
		///--------------------------------------------------------------------------------
		public string NextInnerTabToolTipLabel
		{
			get
			{
				return DisplayValues.ContextMenu_NextTabToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets OKButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string OKButtonLabel
		{
			get
			{
				return DisplayValues.Button_OK;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SelectButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SelectButtonLabel
		{
			get
			{
				return DisplayValues.Button_Select;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SelectNextButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SelectNextButtonLabel
		{
			get
			{
				return DisplayValues.Button_SelectNext;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CancelButtonLabel.</summary>
		///--------------------------------------------------------------------------------
		public string CancelButtonLabel
		{
			get
			{
				return DisplayValues.Button_Cancel;
			}
		}

		private IWorkspaceViewModel _currentItem = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentItem.</summary>
		///--------------------------------------------------------------------------------
		public IWorkspaceViewModel CurrentItem
		{
			get
			{
				return _currentItem;
			}
			set
			{
				_currentItem = value;
				OnPropertyChanged("CurrentItem");
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			// dispose of children
			foreach (IWorkspaceViewModel item in Items)
			{
				item.Dispose();
			}
			Items.CollectionChanged -= Items_CollectionChanged;
			Items.Clear();
			Solution = null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		public virtual void Reset()
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the solution in the view models.</summary>
		///--------------------------------------------------------------------------------
		public void RefreshSolution(Solution solution)
		{
			Solution = solution;
			OnPropertyChanged("Solution");
			foreach (WorkspaceViewModel item in Items)
			{
				item.RefreshSolution(solution);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles sets the item as (re)selected and triggers the
		/// OnSelected event.</summary>
		///--------------------------------------------------------------------------------
		public void SetSelected()
		{
			_isSelected = true;
			OnSelected(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles item collection changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Count != 0)
			{
				foreach (IWorkspaceViewModel item in e.NewItems)
				{
					item.Selected += item_Selected;
				}
			}
			if (e.OldItems != null && e.OldItems.Count != 0)
			{
				foreach (IWorkspaceViewModel item in e.OldItems)
				{
					item.Selected -= item_Selected;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles item selection.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		void item_Selected(object sender, EventArgs e)
		{
			if (sender is IWorkspaceViewModel && (sender as IWorkspaceViewModel).IsSelected == true && (sender as IWorkspaceViewModel).PropogateCurrentItem == true)
			{
				CurrentItem = sender as IWorkspaceViewModel;
			}
			OnSelected(sender, e);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method clears selected items.</summary>
		///--------------------------------------------------------------------------------
		public void ClearSelectedItems()
		{
			if (Items != null)
			{
				foreach (IWorkspaceViewModel item in Items)
				{
					item.IsSelected = false;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an exception.</summary>
		/// 
		/// <param name="ex">The exception to show.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ShowException(Exception ex, bool showMessageBox = true)
		{
			string errorMessage = ex.Message;
			string stackTrace = ex.StackTrace;
			Exception innerEx = ex.InnerException;

			// TODO: show inner exception for now, friendlier error messages later once better
			// exception management is in place
			while (innerEx != null)
			{
				errorMessage = innerEx.Message;
				stackTrace = innerEx.StackTrace;
				innerEx = innerEx.InnerException;
			}
			ShowOutput(errorMessage + "\r\n" + stackTrace, Resources.DisplayValues.Exception_Intro, true, true, showMessageBox);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an exception.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="statusTitle">The optional title to display</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ShowIssue(string statusMessage, string statusTitle = null, bool showMessageBox = true)
		{
			if (statusTitle == null)
			{
				ShowOutput(statusMessage, Resources.DisplayValues.Issue_Intro, true, true, showMessageBox);
			}
			else
			{
				ShowOutput(statusMessage, statusTitle, true, true, showMessageBox);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display a status message.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		///--------------------------------------------------------------------------------
		public void ShowStatus(string statusMessage)
		{
			ShowStatus(statusMessage, null, false, false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display a status message.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="statusTitle">The title for the message.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ShowStatus(string statusMessage, string statusTitle = null, bool appendMessage = true, bool showMessageBox = false)
		{
			StatusEventArgs args = new StatusEventArgs();
			args.Title = statusTitle;
			args.Text = statusMessage;
			args.AppendText = appendMessage;
			args.ShowMessageBox = showMessageBox;
			Mediator.NotifyColleagues<StatusEventArgs>(MediatorMessages.Event_StatusChanged, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an output message.</summary>
		/// 
		/// <param name="outputMessage">The message to show.</param>
		/// <param name="outputTitle">The title for the message.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ShowOutput(string outputMessage, string outputTitle, bool appendMessage, bool isException = false, bool showMessageBox = false)
		{
			StatusEventArgs args = new StatusEventArgs();
			args.Title = outputTitle;
			args.Text = outputMessage;
			args.IsException = isException;
			args.AppendText = appendMessage;
			args.ShowMessageBox = showMessageBox;
			Mediator.NotifyColleagues<StatusEventArgs>(MediatorMessages.Event_OutputChanged, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method reports progress in the status area.</summary>
		/// 
		/// <param name="inProgress">In progress.</param>
		/// <param name="statusLabel">The label for the progress bar.</param>
		/// <param name="completed">The amount of progress completed.</param>
		/// <param name="total">The total amount of work to do.</param>
		///--------------------------------------------------------------------------------
		public void ReportProgress(int inProgress, string statusLabel, uint completed, uint total)
		{
			StatusEventArgs args = new StatusEventArgs();
			args.Progress = inProgress;
			args.Title = statusLabel;
			args.CompletedWork = completed;
			args.TotalWork = total;
			Mediator.NotifyColleagues<StatusEventArgs>(MediatorMessages.Event_ProgressChanged, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets IsExpanded locally.</summary>
		///--------------------------------------------------------------------------------
		public void SetExpanded(bool expanded)
		{
			_isExpanded = expanded;
			OnUpdated(this, null);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method causes child items to be collapsed.</summary>
		///--------------------------------------------------------------------------------
		public void CollapseItems()
		{
			if (Items != null)
			{
				foreach (IWorkspaceViewModel item in Items.ToList<IWorkspaceViewModel>())
				{
					if (item != null)
					{
						if (item.IsExpanded == true)
						{
							item.SetExpanded(false);
						}
						item.CollapseItems();
					}
				}
			}
		}

		#endregion "Methods"

		#region Constructor

		public WorkspaceViewModel()
		{
			WorkspaceID = Guid.NewGuid();
			PropogateCurrentItem = true;
			Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Items_CollectionChanged);
		}

		public WorkspaceViewModel(Guid id, string name)
		{
			WorkspaceID = Guid.NewGuid();
			PropogateCurrentItem = true;
			Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Items_CollectionChanged);
			ItemID = id;
			Name = name;
		}

		#endregion // Constructor

		#region CloseCommand

		///--------------------------------------------------------------------------------
		/// <summary>
		/// Returns the command that, when invoked, attempts
		/// to remove this workspace from the user interface.
		/// </summary>
		///--------------------------------------------------------------------------------
		public ICommand CloseCommand
		{
			get
			{
				if (_closeCommand == null)
					_closeCommand = new RelayCommand(param => this.OnRequestClose());

				return _closeCommand;
			}
		}

		#endregion // CloseCommand

		#region RequestClose [event]

		/// <summary>
		/// Raised when this workspace should be removed from the UI.
		/// </summary>
		public event EventHandler RequestClose;

		protected void OnRequestClose()
		{
			EventHandler handler = this.RequestClose;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		public void Close()
		{
			OnRequestClose();
		}

		#endregion // RequestClose [event]
	}
}
