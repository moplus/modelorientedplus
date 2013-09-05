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
using System.Diagnostics;
using System.Windows.Input;
using MoPlus.ViewModel.Messaging;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class represents command whose sole purpose is to relay its functionality
	/// to other objects by invoking delegates. The default return value for the CanExecute
	/// method is 'true'.</summary>
	///--------------------------------------------------------------------------------
	public class CustomCommands
	{
		#region "Fields and Properties"

		private static RoutedUICommand newChildItem;
		private static RoutedUICommand openOutputSolution;
		private static RoutedUICommand updateOutputSolution;
		private static RoutedUICommand compileSolution;
		private static RoutedUICommand saveAs;
		private static RoutedUICommand saveAll;
		private static RoutedUICommand update;
		private static RoutedUICommand close;
		private static RoutedUICommand explicitOpen;
		private static RoutedUICommand closeTab;
		private static RoutedUICommand closeOtherTabs;
		private static RoutedUICommand nextTab;
		private static RoutedUICommand nextInnerTab;
		private static RoutedUICommand pasteTextTags;
		private static RoutedUICommand pasteSplitTextTags;
		private static RoutedUICommand pasteEvaluationTags;
		private static RoutedUICommand pastePropertyTags;
		private static RoutedUICommand pasteOutputTags;
		private static RoutedUICommand clearText;
		private static RoutedUICommand manageItem;
		private static RoutedUICommand deleteChildItem;
		private static RoutedUICommand cancelJobs;

		public static RoutedUICommand CancelJobs
		{
			get { return cancelJobs; }
		}

		public static RoutedUICommand ManageItem
		{
			get { return manageItem; }
		}

		public static RoutedUICommand DeleteChildItem
		{
			get { return deleteChildItem; }
		}

		public static RoutedUICommand NewChildItem
		{
			get { return newChildItem; }
		}

		public static RoutedUICommand OpenOutputSolution
		{
			get { return openOutputSolution; }
		}

		public static RoutedUICommand UpdateOutputSolution
		{
			get { return updateOutputSolution; }
		}

		public static RoutedUICommand CompileSolution
		{
			get { return compileSolution; }
		}

		public static RoutedUICommand SaveAs
		{
			get { return saveAs; }
		}

		public static RoutedUICommand SaveAll
		{
			get { return saveAll; }
		}

		public static RoutedUICommand Update
		{
			get { return update; }
		}

		public static RoutedUICommand Close
		{
			get { return close; }
		}

		public static RoutedUICommand ExplicitOpen
		{
			get { return explicitOpen; }
		}

		public static RoutedUICommand CloseTab
		{
			get { return closeTab; }
		}

		public static RoutedUICommand CloseOtherTabs
		{
			get { return closeOtherTabs; }
		}

		public static RoutedUICommand NextTab
		{
			get { return nextTab; }
		}

		public static RoutedUICommand NextInnerTab
		{
			get { return nextInnerTab; }
		}

		public static RoutedUICommand PasteTextTags
		{
			get { return pasteTextTags; }
		}

		public static RoutedUICommand PasteSplitTextTags
		{
			get { return pasteSplitTextTags; }
		}

		public static RoutedUICommand PasteEvaluationTags
		{
			get { return pasteEvaluationTags; }
		}

		public static RoutedUICommand PastePropertyTags
		{
			get { return pastePropertyTags; }
		}

		public static RoutedUICommand PasteOutputTags
		{
			get { return pasteOutputTags; }
		}

		public static RoutedUICommand ClearText
		{
			get { return clearText; }
		}

		#endregion "Fields and Properties"

		#region "Constructors"

		/// <summary>
		/// Creates a new command that can always execute.
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		static CustomCommands()
		{
			InputGestureCollection inputs = null;
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl+Q"));
			cancelJobs = new RoutedUICommand("Cmd_CancelJobs", "Cmd_CancelJobs", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.M, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+M"));
			manageItem = new RoutedUICommand("Cmd_ManageItem", "Cmd_ManageItem", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.Delete, ModifierKeys.None, "Del"));
			deleteChildItem = new RoutedUICommand("Cmd_DeleteChildItem", "Cmd_DeleteChildItem", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.N, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+N"));
			newChildItem = new RoutedUICommand("Cmd_NewChildItem", "Cmd_NewChildItem", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.O, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+O"));
			openOutputSolution = new RoutedUICommand("Cmd_OpenOutputSolution", "Cmd_OpenOutputSolution", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.U, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+U"));
			updateOutputSolution = new RoutedUICommand("Cmd_UpdateOutputSolution", "Cmd_UpdateOutputSolution", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.C, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+C"));
			compileSolution = new RoutedUICommand("Cmd_CompileSolution", "Cmd_CompileSolution", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.A, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+A"));
			saveAs = new RoutedUICommand("Cmd_SaveAs", "Cmd_SaveAs", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+S"));
			saveAll = new RoutedUICommand("Cmd_SaveAll", "Cmd_SaveAll", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E"));
			update = new RoutedUICommand("Cmd_Update", "Cmd_Update", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.X, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+X"));
			close = new RoutedUICommand("Cmd_Close", "Cmd_Close", typeof(CustomCommands), inputs);
			explicitOpen = new RoutedUICommand("Cmd_ExplicitOpen", "Cmd_ExplicitOpen", typeof(CustomCommands));
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
			closeTab = new RoutedUICommand("Cmd_CloseTab", "Cmd_CloseTab", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.T, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+T"));
			closeOtherTabs = new RoutedUICommand("Cmd_CloseOtherTabs", "Cmd_CloseOtherTabs", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.Z, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+Z"));
			nextTab = new RoutedUICommand("Cmd_NextTab", "Cmd_NextTab", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.X, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+X"));
			nextInnerTab = new RoutedUICommand("Cmd_NextInnerTab", "Cmd_NextInnerTab", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.A, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+A"));
			pasteTextTags = new RoutedUICommand("Cmd_PasteTextTags", "Cmd_PasteTextTags", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.D, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+D"));
			pasteSplitTextTags = new RoutedUICommand("Cmd_PasteSplitTextTags", "Cmd_PasteSplitTextTags", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.Q, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+Q"));
			pasteEvaluationTags = new RoutedUICommand("Cmd_PasteEvaluationTags", "Cmd_PasteEvaluationTags", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.W, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+W"));
			pastePropertyTags = new RoutedUICommand("Cmd_PastePropertyTags", "Cmd_PastePropertyTags", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+S"));
			pasteOutputTags = new RoutedUICommand("Cmd_PasteOutputTags", "Cmd_PasteOutputTags", typeof(CustomCommands), inputs);
			inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.X, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+X"));
			clearText = new RoutedUICommand("Cmd_ClearText", "Cmd_ClearText", typeof(CustomCommands), inputs);
		}

		#endregion "Constructors"
	}
}