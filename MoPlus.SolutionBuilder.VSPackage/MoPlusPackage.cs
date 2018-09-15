/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;
using EnvDTE90;
using EnvDTE100;
using Microsoft.VisualStudio.CommandBars;
using System.Threading;
using MoPlus.Data;
using MoPlus.SolutionBuilder.WpfClient.UserControls;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Solutions;
using System.Data;
using System.Windows;
using System.IO;
using MoPlus.ViewModel;
using System.Reflection;

namespace MoPlus.SolutionBuilder.VSPackage
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // A Visual Studio component can be registered under different regitry roots; for instance
    // when you debug your package you want to register it in the experimental hive. This
    // attribute specifies the registry root to use if no one is provided to regpkg.exe with
    // the /root switch.
    //[DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\10.0")]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 301)]
    // In order be loaded inside Visual Studio in a machine that has not the VS SDK installed, 
    // package needs to have a valid load key (it can be requested at 
    // http://msdn.microsoft.com/vstudio/extend/). This attributes tells the shell that this 
    // package has a load key embedded in its resources.
    [ProvideLoadKey("Standard", "1.0", "Mo+ Solution Builder", "Intelligent Coding Solutions, LLC", 104)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    // These attributes registers tool windows exposed by this package.
    [ProvideToolWindow(typeof(SolutionBuilderWindow))]
    [ProvideToolWindow(typeof(SolutionDesignerWindow))]
	[ProvideAutoLoad(Microsoft.VisualStudio.Shell.Interop.UIContextGuids80.SolutionExists)]
	[Guid(GuidList.guidMoPlusPkgString)]
	[ProvideBindingPath]
	public sealed class MoPlusPackage : Package, IVsPackage2
    {
        #region "Fields and Properties"
        private DTE2 _applicationObject = null;
        ///--------------------------------------------------------------------------------
        /// <summary>This property gets the visual studio IDE application object.</summary>
        ///--------------------------------------------------------------------------------
        public DTE2 ApplicationObject
        {
            get
            {
                if (_applicationObject == null)
                {
                    // Get an instance of the currently running Visual Studio IDE
                    DTE dte = (DTE)GetService(typeof(DTE));
                    _applicationObject = dte as DTE2;
                }
                return _applicationObject;
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the package windows events.</summary>
        /// 
        /// Events should be stored as a property to prevent garbage collection from getting
        /// rid of them.
        ///--------------------------------------------------------------------------------
        private WindowEvents PackageWindowEvents { get; set; }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the package document events.</summary>
        /// 
        /// Events should be stored as a property to prevent garbage collection from getting
        /// rid of them.
        ///--------------------------------------------------------------------------------
        private DocumentEvents PackageDocumentEvents { get; set; }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the package solution events.</summary>
        /// 
        /// Events should be stored as a property to prevent garbage collection from getting
        /// rid of them.
        ///--------------------------------------------------------------------------------
        private SolutionEvents PackageSolutionEvents { get; set; }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the package DTE events.</summary>
        /// 
        /// Events should be stored as a property to prevent garbage collection from getting
        /// rid of them.
        ///--------------------------------------------------------------------------------
        private DTEEvents PackageDTEEvents { get; set; }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets the solution builder output pane.</summary>
        ///--------------------------------------------------------------------------------
        private Guid _solutionBuilderPaneGuid = Guid.Empty;
        private IVsOutputWindowPane _solutionBuilderPane = null;
        private IVsOutputWindowPane SolutionBuilderPane
        {
            get
            {
                if (_solutionBuilderPane == null)
                {
                    IVsOutputWindow outputWindow = GetService(typeof(SVsOutputWindow)) as IVsOutputWindow;
                    if (outputWindow != null)
                    {
                        // look for existing solution updater pane
                        if (_solutionBuilderPaneGuid == Guid.Empty || ErrorHandler.Failed(outputWindow.GetPane(ref _solutionBuilderPaneGuid, out _solutionBuilderPane)) || _solutionBuilderPane == null)
                        {
                            // create a new solution updater pane
                            outputWindow.CreatePane(ref _solutionBuilderPaneGuid, "Solution Builder", 1, 1);
                            if (ErrorHandler.Failed(outputWindow.GetPane(ref _solutionBuilderPaneGuid, out _solutionBuilderPane)) || _solutionBuilderPane == null)
                            {
                                // pane could not be created and retrieved, throw exception
                                throw new ApplicationException("Solution Updater pane could not be created and/or retrieved");
                            }
                        }
                    }
                }
                if (_solutionBuilderPane != null)
                {
                    _solutionBuilderPane.Activate();
                }
                return _solutionBuilderPane;
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets the solution updater output pane.</summary>
        ///--------------------------------------------------------------------------------
        private Guid _solutionUpdaterPaneGuid = Guid.Empty;
        private IVsOutputWindowPane _solutionUpdaterPane = null;
        private IVsOutputWindowPane SolutionUpdaterPane
        {
            get
            {
                if (_solutionUpdaterPane == null)
                {
                    IVsOutputWindow outputWindow = GetService(typeof(SVsOutputWindow)) as IVsOutputWindow;
                    if (outputWindow != null)
                    {
                        // look for existing solution updater pane
                        if (_solutionUpdaterPaneGuid == Guid.Empty || ErrorHandler.Failed(outputWindow.GetPane(ref _solutionUpdaterPaneGuid, out _solutionUpdaterPane)) || _solutionUpdaterPane == null)
                        {
                            // create a new solution updater pane
                            outputWindow.CreatePane(ref _solutionUpdaterPaneGuid, "Solution Updater", 1, 1);
                            if (ErrorHandler.Failed(outputWindow.GetPane(ref _solutionUpdaterPaneGuid, out _solutionUpdaterPane)) || _solutionUpdaterPane == null)
                            {
                                // pane could not be created and retrieved, throw exception
                                throw new ApplicationException("Solution Updater pane could not be created and/or retrieved");
                            }
                        }
                    }
                }
                if (_solutionUpdaterPane != null)
                {
                    _solutionUpdaterPane.Activate();
                }
                return _solutionUpdaterPane;
            }
        }

        private IVsStatusbar _statusBar = null;
        ///--------------------------------------------------------------------------------
        /// <summary>This property gets the Visual Studio IDE status bar.</summary>
        ///--------------------------------------------------------------------------------
        public IVsStatusbar StatusBar
        {
            get
            {
                if (_statusBar == null)
                {
                    _statusBar = (IVsStatusbar)GetService(typeof(SVsStatusbar));
                }
                return _statusBar;
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the progress bar cookie.</summary>
        ///--------------------------------------------------------------------------------
        private uint _progressBarCookie = 0;

        private IVsSolution _solutionService = null;
        ///--------------------------------------------------------------------------------
        /// <summary>This property gets the Visual Studio IDE status bar.</summary>
        ///--------------------------------------------------------------------------------
        public IVsSolution SolutionService
        {
            get
            {
                if (_solutionService == null)
                {
                    _solutionService = (IVsSolution)GetService(typeof(IVsSolution));
                }
                return _solutionService;
            }
        }

        #endregion "Fields and Properties"

        #region "Methods"
        ///--------------------------------------------------------------------------------
        /// <summary>This method handles progress changes from the solution model control.</summary>
        /// 
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        ///--------------------------------------------------------------------------------
        void SolutionBuilderControl_ProgressChanged(object sender, StatusEventArgs args)
        {
            StatusBar.Progress(ref _progressBarCookie, args.Progress, args.Title, args.CompletedWork, args.TotalWork);
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles output changes from the solution model control.</summary>
        /// 
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        ///--------------------------------------------------------------------------------
        void SolutionBuilderControl_OutputChanged(object sender, StatusEventArgs args)
        {
			ShowOutput(args.Text, args.Title, args.AppendText);
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles status changes from the solution model control.</summary>
        /// 
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        ///--------------------------------------------------------------------------------
        void SolutionBuilderControl_StatusChanged(object sender, StatusEventArgs args)
        {
            ShowStatus(args.Text, args.AppendText);
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles a request to show the solution designer.</summary>
        /// 
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        ///--------------------------------------------------------------------------------
        void SolutionBuilderControl_ShowSolutionDesignerRequested(object sender, SolutionEventArgs args)
        {
			ShowSolutionDesigner();
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles a request to open an output solution.</summary>
        /// 
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        ///--------------------------------------------------------------------------------
        void SolutionBuilderControl_OpenOutputSolutionRequested(object sender, SolutionEventArgs args)
        {
            OpenOutputSolution(args.Path);
        }

        ///--------------------------------------------------------------------------------
        /// <summary>
        /// This function is the callback used to execute the solution builder when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        ///--------------------------------------------------------------------------------
        private void SolutionBuilderCallback(object sender, EventArgs e)
        {
            ShowSolutionBuilderWindow(sender, e);
        }

        ///--------------------------------------------------------------------------------
        /// <summary>
        /// This function is the callback used to execute the solution updater when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        ///--------------------------------------------------------------------------------
        private void SolutionUpdaterCallback(object sender, EventArgs e)
        {
            // update the solution
            UpdateSolution();
        }

        ///--------------------------------------------------------------------------------
        /// <summary>
        /// This function is called when the user clicks the menu item that shows the 
        /// tool window. See the Initialize method to see how the menu item is associated to 
        /// this function using the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        ///--------------------------------------------------------------------------------
        private void ShowSolutionBuilderWindow(object sender, EventArgs e)
        {
            try
            {
                // show solution builder
                SolutionBuilderPane.Clear();

                // Get the instance number 0 of this tool window. This window is single instance so this instance
                // is actually the only one.
                // The last flag is set to true so that if the tool window does not exists it will be created.
                SolutionBuilderWindow window = this.FindToolWindow(typeof(SolutionBuilderWindow), 0, false) as SolutionBuilderWindow;
                if (window == null)
                {
                    window = this.CreateToolWindow(typeof(SolutionBuilderWindow), 0) as SolutionBuilderWindow;
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException(Resources.CanNotCreateWindow);
                    }
                }

                // wire up solution builder window events
				window.Control.ProgressChanged -= SolutionBuilderControl_ProgressChanged;
				window.Control.ProgressChanged += new SolutionBuilderControl.StatusChangeEventHandler(SolutionBuilderControl_ProgressChanged);
				window.Control.StatusChanged -= SolutionBuilderControl_StatusChanged;
				window.Control.StatusChanged += new SolutionBuilderControl.StatusChangeEventHandler(SolutionBuilderControl_StatusChanged);
				window.Control.OutputChanged -= SolutionBuilderControl_OutputChanged;
				window.Control.OutputChanged += new SolutionBuilderControl.StatusChangeEventHandler(SolutionBuilderControl_OutputChanged);
				window.Control.OpenOutputSolutionRequested -= SolutionBuilderControl_OpenOutputSolutionRequested;
				window.Control.OpenOutputSolutionRequested += new SolutionBuilderControl.SolutionEventHandler(SolutionBuilderControl_OpenOutputSolutionRequested);
				window.Control.ShowSolutionDesignerRequested -= SolutionBuilderControl_ShowSolutionDesignerRequested;
				window.Control.ShowSolutionDesignerRequested += new SolutionBuilderControl.SolutionEventHandler(SolutionBuilderControl_ShowSolutionDesignerRequested);

                // show designer window
                ShowSolutionDesignerWindow();

				// show getting started help
				if (window.Control.DataContext is BuilderViewModel)
				{
					(window.Control.DataContext as BuilderViewModel).ResourcesFolder.ShowGettingStartedHelp();
				}

				// TODO: remove this later
				window.DesignerWindow = this.FindToolWindow(typeof(SolutionDesignerWindow), 0, false) as SolutionDesignerWindow;

                // if solution is already open, load it
                CheckOpenCurrentSolution();

                IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
                Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());

                // put solution builder output to output pane
                SolutionBuilderPane.OutputString("Solution Builder shown.");
            }
            catch (System.Exception ex)
            {
				Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Error showing solution builder: {0}", ex.ToString()));
				// put exception message in output pane
				string message = ex.Message;
				System.Exception exception = ex.InnerException;
				while (exception != null)
				{
					message += "\r\n" + exception.Message;
					exception = exception.InnerException;
				}
				SolutionBuilderPane.OutputString(message);
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method is used to show the solution designer window.</summary>
        ///--------------------------------------------------------------------------------
        private void ShowSolutionDesignerWindow()
        {
            try
            {
                // Get the instance number 0 of this tool window. This window is single instance so this instance
                // is actually the only one.
                SolutionDesignerWindow window = this.FindToolWindow(typeof(SolutionDesignerWindow), 0, false) as SolutionDesignerWindow;
                if (window == null)
                {
                    window = this.CreateToolWindow(typeof(SolutionDesignerWindow), 0) as SolutionDesignerWindow;
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException(Resources.CanNotCreateWindow);
                    }
                }

                // dock the window as an mdi child, user can override
                IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
                ((IVsWindowFrame)window.Frame).SetProperty((int)__VSFPROPID.VSFPROPID_FrameMode, VSFRAMEMODE.VSFM_MdiChild);
                Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
            }
            catch (System.Exception ex)
            {
				Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Error showing solution designer: {0}", ex.ToString()));
				// put exception message in output pane
                SolutionBuilderPane.OutputString(ex.Message);
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>
        /// This function is called when the user clicks the menu item that shows the 
        /// tool window. See the Initialize method to see how the menu item is associated to 
        /// this function using the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        ///--------------------------------------------------------------------------------
        public void ShowSolutionBuilder()
        {
            ShowSolutionBuilderWindow(null, null);
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method is used to show the solution designer window.</summary>
         ///--------------------------------------------------------------------------------
        public void ShowSolutionDesigner()
        {
            ShowSolutionDesignerWindow();
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method displays a message in the status area.</summary>
        /// 
        /// <param name="statusMessage">The message to show.</param>
        /// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
        ///--------------------------------------------------------------------------------
        public void ShowStatus(string statusMessage, bool appendMessage)
        {
            int frozen;

            StatusBar.IsFrozen(out frozen);

            if (frozen == 0)
            {
                if (appendMessage == true)
                {
                    if (statusMessage != "Ready")
                    {
                        // add status message to job message
                        string text;
                        StatusBar.GetText(out text);
                        if (text != String.Empty)
                        {
                            text = "; " + text;
                        }
                        StatusBar.SetText(statusMessage + text);
                        StatusBar.FreezeOutput(0);
                    }
                }
                else
                {
                    // replace status message with current message
                    StatusBar.SetText(statusMessage);
                    StatusBar.FreezeOutput(0);
                }
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method displays a message in the output area.</summary>
        /// 
		/// <param name="outputMessage">The message to show.</param>
		/// <param name="outputTitle">The title for the message.</param>
         /// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
        ///--------------------------------------------------------------------------------
		public void ShowOutput(string outputMessage, string outputTitle, bool appendMessage)
        {
            if (appendMessage == false)
            {
                // clear output pane
                SolutionBuilderPane.Clear();
            }

            if (outputTitle != string.Empty)
            {
                // put output title to output pane
                SolutionBuilderPane.OutputString("\r\n" + outputTitle);
            }

            // put output message to output pane
			SolutionBuilderPane.OutputString("\r\n" + outputMessage + "\r\n");
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method launches the solution updater to update the solution.</summary>
        ///--------------------------------------------------------------------------------
        private void UpdateSolution()
        {
            try
            {
                // Get the instance number 0 of this tool window. This window is single instance so this instance
                // is actually the only one.
                // The last flag is set to true so that if the tool window does not exists it will be created.
                SolutionBuilderWindow window = this.FindToolWindow(typeof(SolutionBuilderWindow), 0, false) as SolutionBuilderWindow;
				if (window == null)
				{
					SolutionUpdaterPane.OutputString("Please open the Solution Builder window prior to updating the solution.");
				}
                else
                {
                    // wire up solution builder window events
                    //window.Control.ProgressChanged += new SolutionBuilderControl.StatusChangeEventHandler(SolutionBuilderControl_ProgressChanged);
                    //window.Control.StatusChanged += new SolutionBuilderControl.StatusChangeEventHandler(SolutionBuilderControl_StatusChanged);
                    //window.Control.OutputChanged += new SolutionBuilderControl.StatusChangeEventHandler(SolutionBuilderControl_OutputChanged);
                    //window.Control.OpenOutputSolutionRequested += new SolutionBuilderControl.SolutionEventHandler(SolutionBuilderControl_OpenOutputSolutionRequested);
                    //window.Control.ShowSolutionDesignerRequested += new SolutionBuilderControl.SolutionEventHandler(SolutionBuilderControl_ShowSolutionDesignerRequested);

                    // execute the solution updater
                    SolutionUpdaterPane.Clear();
                    if (ApplicationObject.Solution != null && ApplicationObject.Solution.FullName != String.Empty)
                    {
                        string solutionDir = System.IO.Path.GetDirectoryName(ApplicationObject.Solution.FullName);
                        SolutionViewModel solutionView = window.Control.TreeViewModel.SolutionsFolder.CheckOpenCurrentSolution(solutionDir);
						if (solutionView != null)
						{
							solutionView.UpdateOutputSolution();
						}

                        // put solution updater output to output pane
                        SolutionUpdaterPane.OutputString("Solution update complete.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionUpdaterPane.OutputString(ex.Message);
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method opens the output solution for a solution.</summary>
        /// 
        /// <param name="solutionPath">Path to the solution to open.</param>
        ///--------------------------------------------------------------------------------
        public void OpenOutputSolution(string solutionPath)
        {
            try
            {
				if (solutionPath.EndsWith(".sln") == true)
				{
					// open the .net solution if not already open
					if (SolutionService != null && ApplicationObject.Solution.FullName.ToLower() != solutionPath.ToLower())
					{
						SolutionService.OpenSolutionFile((uint)__VSSLNOPENOPTIONS.SLNOPENOPT_Silent, solutionPath);
					}
					// Bring the solution explorer window to the front and give it focus
					ApplicationObject.ToolWindows.SolutionExplorer.Parent.Activate();
					ApplicationObject.ToolWindows.SolutionExplorer.Parent.SetFocus();
				}
				else
				{
					// open other solution type
					if (File.Exists(solutionPath))
					{
						ProcessStartInfo info = new ProcessStartInfo();
						info.FileName = solutionPath;
						using (System.Diagnostics.Process p = new System.Diagnostics.Process())
						{
							p.StartInfo = info;
							p.Start();
						}
					}
				}
            }
            catch (ApplicationException ex)
            {
                // put exception message in output pane
                SolutionBuilderPane.OutputString(ex.Message);
            }
            catch (Exception ex)
            {
                // put exception message in output pane
                SolutionBuilderPane.OutputString(ex.Message);
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles clicking on the Launch Solution Builder submenu.</summary>
        /// 
        /// <param term='inputCommandBarControl'>The control that is source of the click.</param>
        /// <param term='handled'>Handled flag.</param>
        /// <param term='cancelDefault'>Cancel default flag.</param>
        ///--------------------------------------------------------------------------------
        private void launchSolutionBuilder_Click(object inputCommandBarControl, ref bool handled, ref bool cancelDefault)
        {
            // show solution builder
            ShowSolutionBuilderWindow(null, null);
            handled = true;
        }

        // the event handlers for the solution submenu items
        CommandBarEvents updateSolutionMenuItemHandler;
        CommandBarEvents launchSolutionBuilderMenuItemHandler;

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles clicking on the Update Solution submenu.</summary>
        /// 
        /// <param term='inputCommandBarControl'>The control that is source of the click.</param>
        /// <param term='handled'>Handled flag.</param>
        /// <param term='cancelDefault'>Cancel default flag.</param>
        ///--------------------------------------------------------------------------------
        private void updateSolution_Click(object inputCommandBarControl, ref bool handled, ref bool cancelDefault)
        {
            try
            {
                // set up and execute solution updater thread
                UpdateSolution();
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionUpdaterPane.OutputString(ex.Message);
            }
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method handles opening a solution builder solution when an output
        /// solution is opened.</summary>
        ///--------------------------------------------------------------------------------
        private void CheckOpenCurrentSolution()
        {
            try
            {
                SolutionBuilderWindow window = this.FindToolWindow(typeof(SolutionBuilderWindow), 0, false) as SolutionBuilderWindow;
                if (window != null)
                {
                    if (ApplicationObject.Solution.FullName != string.Empty)
                    {
                        window.Control.TreeViewModel.SolutionsFolder.CheckOpenCurrentSolution(System.IO.Path.GetDirectoryName(ApplicationObject.Solution.FullName));
                        IVsWindowFrame frame = window.Frame as IVsWindowFrame;
                        if (frame == null)
                        {
                            throw new COMException(this.GetResourceString("@102"));
                        }
                        // Bring the tool window to the front and give it focus
                        ErrorHandler.ThrowOnFailure(frame.Show());
                    }
                }
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionBuilderPane.OutputString(ex.Message);
            }
        }

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if visual studio can close.</summary>
		///--------------------------------------------------------------------------------
		protected override int QueryClose(out bool canClose)
		{
			return get_CanClose(out canClose);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if visual studio can close.</summary>
		///--------------------------------------------------------------------------------
		public int get_CanClose(out bool pfCanClose)
		{
			pfCanClose = true;
			try
			{
				// cancel close if either solution designer or solution builder cannot close
				SolutionDesignerWindow solutionDesigner = this.FindToolWindow(typeof(SolutionDesignerWindow), 0, false) as SolutionDesignerWindow;
				if (solutionDesigner != null)
				{
					if (solutionDesigner.CanClose() == false)
					{
						pfCanClose = false;
						return VSConstants.E_ABORT;
					}
					solutionDesigner.Control.DesignerView.CloseNoPromptAllItems();
					IVsWindowFrame windowFrame = (IVsWindowFrame)solutionDesigner.Frame;
					windowFrame.Hide();
				}
				SolutionBuilderWindow solutionBuilder = this.FindToolWindow(typeof(SolutionBuilderWindow), 0, false) as SolutionBuilderWindow;
				if (solutionBuilder != null)
				{
					if (solutionBuilder.CanClose() == false)
					{
						pfCanClose = false;
						return VSConstants.E_ABORT;
					}
					solutionBuilder.Control.CloseAllSolutions(true);
					IVsWindowFrame windowFrame = (IVsWindowFrame)solutionBuilder.Frame;
					windowFrame.Hide();
				}
			}
			catch (System.Exception ex)
			{
				// put exception message in output pane
				SolutionBuilderPane.OutputString(ex.Message);
			}
			return VSConstants.S_OK;
		}

		private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			path = Path.GetDirectoryName(path);

			if (args.Name.ToLower().Contains("system.windows.interactivity"))
			{
				path = Path.Combine(path, "system.windows.interactivity.dll");
				Assembly ret = Assembly.LoadFrom(path);
				return ret;
			}
			return null;
		}
		///--------------------------------------------------------------------------------
        /// <summary>
        /// This method loads a localized string based on the specified resource.
        /// </summary>
        /// <param name="resourceName">Resource to load</param>
        /// <returns>String loaded for the specified resource</returns>
        ///--------------------------------------------------------------------------------
        internal string GetResourceString(string resourceName)
        {
            string resourceValue;
            IVsResourceManager resourceManager = (IVsResourceManager)GetService(typeof(SVsResourceManager));
            if (resourceManager == null)
            {
                throw new InvalidOperationException("Could not get SVsResourceManager service. Make sure the package is Sited before calling this method");
            }
            Guid packageGuid = this.GetType().GUID;
            int hr = resourceManager.LoadResourceString(ref packageGuid, -1, resourceName, out resourceValue);
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);
            return resourceValue;
        }

        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
                base.Initialize();

                // Add our command handlers for menu (commands must exist in the .vsct file)
                OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
                if (mcs != null)
                {
                     // Create the solution builder command for the Mo+ Menu
                    CommandID incodeBuilderCommandID = new CommandID(GuidList.guidInCodeMenuCmdSet, (int)PkgCmdIDList.cmdidSolutionBuilderControl);
                    MenuCommand incodeBuilderToolWin = new MenuCommand(SolutionBuilderCallback, incodeBuilderCommandID);
                    mcs.AddCommand(incodeBuilderToolWin);

                    // Create the solution updater command for the Mo+ Menu
                    CommandID incodeUpdaterCommandID = new CommandID(GuidList.guidInCodeMenuCmdSet, (int)PkgCmdIDList.cmdidSolutionUpdaterControl);
                    MenuCommand incodeUpdaterToolWin = new MenuCommand(SolutionUpdaterCallback, incodeUpdaterCommandID);
                    mcs.AddCommand(incodeUpdaterToolWin);
                }
                else
                {
                    SolutionBuilderPane.OutputString("Could not get IMenuCommandService.");
                }

                // add the handler for tracking solution opens and closes
                if (ApplicationObject != null)
                {
                    // wire up solution events
                    PackageSolutionEvents = ApplicationObject.Events.SolutionEvents;
                    PackageSolutionEvents.Opened += new _dispSolutionEvents_OpenedEventHandler(CheckOpenCurrentSolution);

                    // get the solution command bar
                    CommandBar solutionCommandBar = ((CommandBars)ApplicationObject.CommandBars)["Solution"];

                    // set up the main Mo+ context menu
                    CommandBarPopup solutionPopup = (CommandBarPopup)solutionCommandBar.Controls.Add(MsoControlType.msoControlPopup, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 3, true);
                    solutionPopup.Caption = "Mo+";

                    // add solution builder submenu
                    CommandBarControl solutionBuilderControl = solutionPopup.Controls.Add(MsoControlType.msoControlButton, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
                    solutionBuilderControl.Caption = "Solution Builder";
                    launchSolutionBuilderMenuItemHandler = (CommandBarEvents)ApplicationObject.Events.get_CommandBarEvents(solutionBuilderControl);
                    launchSolutionBuilderMenuItemHandler.Click += new _dispCommandBarControlEvents_ClickEventHandler(launchSolutionBuilder_Click);

                    // add solution updater submenu
                    CommandBarControl solutionUpdaterControl = solutionPopup.Controls.Add(MsoControlType.msoControlButton, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
                    solutionUpdaterControl.Caption = "Update Solution";
                    updateSolutionMenuItemHandler = (CommandBarEvents)ApplicationObject.Events.get_CommandBarEvents(solutionUpdaterControl);
                    updateSolutionMenuItemHandler.Click += new _dispCommandBarControlEvents_ClickEventHandler(updateSolution_Click);

                    // if solution is already open, load it
                    CheckOpenCurrentSolution();
                }
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionBuilderPane.OutputString(ex.Message);
            }
        }
		#endregion

        #endregion "Methods"

        #region "Constructors"
        ///--------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        ///--------------------------------------------------------------------------------
        public MoPlusPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
			AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
		}

        #endregion "Constructors"

	}
}
