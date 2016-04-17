/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using MoPlus.SolutionBuilder.WpfClient.UserControls;
using Microsoft.VisualStudio;
using System.Windows.Forms;
using System.Windows.Interop;
using MoPlus.SolutionBuilder.WpfClient.Library;

namespace MoPlus.SolutionBuilder.VSPackage
{
	///--------------------------------------------------------------------------------
	/// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsWindowPane interface.
    /// </summary>
	///--------------------------------------------------------------------------------
	[Guid("b2a086f1-775d-4f60-bb81-202c23fea3af")]
    public class SolutionBuilderWindow : ToolWindowPane, IVsWindowFrameNotify2
    {
		///--------------------------------------------------------------------------------
		// This is the user control hosted by the tool window; it is exposed to the base class 
        // using the Window property. Note that, even if this class implements IDispose, we are
        // not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
        // the object returned by the Window property.
		///--------------------------------------------------------------------------------
		public SolutionBuilderControl Control;
		public SolutionDesignerWindow DesignerWindow;

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public SolutionBuilderWindow() :
            base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = Resources.SolutionBuilderTitle;
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 300;
            this.BitmapIndex = 0;
			Control = new SolutionBuilderControl();
			base.Content = Control;
		}

		protected override bool PreProcessMessage(ref Message msg)
		{
			// send translated message via component dispatcher
			MSG dispatchMsg = new MSG();
			dispatchMsg.hwnd = msg.HWnd;
			dispatchMsg.lParam = msg.LParam;
			dispatchMsg.wParam = msg.WParam;
			dispatchMsg.message = msg.Msg;
			if (ComponentDispatcher.RaiseThreadMessage(ref dispatchMsg) == true)
			{
				msg.Result = (IntPtr)1;
				return true;
			}
			return base.PreProcessMessage(ref msg);
		}

		/// <summary>
		/// Manage the closing of the window.
		/// </summary>
		public int OnClose(ref uint pgrfSaveOptions)
		{
			// abort close if there are open solutions that are not saved
			if (CanClose() == false)
			{
				return VSConstants.E_ABORT;
			}
			if (DesignerWindow != null)
			{
				DesignerWindow.CloseNoPromptAllItems();
				IVsWindowFrame windowFrame = (IVsWindowFrame)DesignerWindow.Frame;
				windowFrame.Hide();
			}
			FindReplaceMgr.Instance.CloseWindow();

			Control.CloseAllSolutions(true, false);
			return VSConstants.S_OK;
		}

		/// <summary>
		/// Determine if window can close, prompt for saving changes or cancel changes.
		/// </summary>
		public bool CanClose()
		{
			// TODO: move this method body to the view model, probably cross referencing designer view model into builder view model
			if (DesignerWindow != null)
			{
				if (DesignerWindow.CanClose() == false)
				{
					return false;
				}
			}

			// Determine if any solutions are open and unsaved, prompt for global save or cancel
			if (Control.HasUnSavedSolutions() == true)
			{
				// Prompt a dialog
				MessageBoxResult result = System.Windows.MessageBox.Show(Resources.SolutionBuilderSaveSolutions, Resources.UnsavedChangesTitle, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
				if (result == MessageBoxResult.Yes)
				{
					// save solutions
					Control.SaveAllSolutions();
					return true;
				}
				else if (result == MessageBoxResult.Cancel)
				{
					// abort the close
					return false;
				}
			}
			return true;
		}
	}
}
