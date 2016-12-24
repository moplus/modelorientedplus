/*<copyright>
Mo+ Solution Updater is a model oriented programming language and command line tool, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter;
using MoPlus.Data;
using MoPlus.Common;
using MoPlus.IO;
using System.IO;
using MoPlus.Interpreter.BLL.Interpreter;

namespace MoPlus.SolutionUpdater.CommandUI
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class is used to provide the solution updater command line interface.</summary>
    ///--------------------------------------------------------------------------------
    public partial class SolutionUpdater
    {
        #region "Fields and Properties"
        #endregion "Fields and Properties"

 		#region "Methods"
       ///--------------------------------------------------------------------------------
        /// <summary>This is the main method to run the command updater.</summary>
        /// 
        /// <param name="args">The command arguments, which can include an output solution
		/// directory or a specification file path.</param>
        ///--------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            try
            {
				Console.WriteLine("Mo+ Solution Updater is a model oriented programming language and command line tool, used for building models and generating code and other documents in a model driven development process.");
				Console.WriteLine("Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC");
				Console.WriteLine("This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.");
				Console.WriteLine("This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.");
				Console.WriteLine("You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.");

				if (args == null || args.Length == 0)
				{
					// get a test solution from recent solutions
					foreach (RecentSolution loopSolution in BusinessConfiguration.RecentSolutionList)
					{
						if (loopSolution.RecentSolutionName.Contains("Test") == true)
						{
							Solution solutionToGenerate = new Solution();
							string solutionDir = loopSolution.RecentSolutionLocation.Substring(0, loopSolution.RecentSolutionLocation.LastIndexOf("\\"));
							solutionToGenerate.Load(loopSolution.RecentSolutionLocation);
							UpdateOutputSolution(solutionToGenerate, solutionDir);
							break;
						}
					}
				}
				else
				{
					// get solution to update from arguments
					foreach (string arg in args)
					{
						Console.WriteLine("Processing Directory: " + arg);

						Solution solutionToGenerate = new Solution();
						string specificationPath = String.Empty;
						string solutionDir = String.Empty;

						// process solution
						if (arg.EndsWith(".xml") == false)
						{
							// get corresponding spec for solution from recent solutions
							solutionDir = arg;
                            foreach (RecentSolution loopSolution in BusinessConfiguration.RecentSolutionList)
                            {
								string keyFilePath = loopSolution.RecentSolutionLocation;
								if (keyFilePath.ToLower().Replace("\\", "\"").Contains(arg.ToLower().Replace("\\", "\"")) == true)
								{
									specificationPath = keyFilePath;
									break;
								}
							}
						}
						else
						{
							specificationPath = arg;
							solutionDir = specificationPath.Substring(0, specificationPath.LastIndexOf("\\"));
						}
						if (specificationPath != String.Empty && File.Exists(specificationPath) == true)
						{
							solutionToGenerate.Load(specificationPath);
							UpdateOutputSolution(solutionToGenerate, solutionDir);
						}
						else
						{
							Console.WriteLine("Could not find solution specification: " + arg);
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
        }

        ///--------------------------------------------------------------------------------
        /// <summary>This method updates the output solution the input solution.</summary>
        /// 
        /// <param name="inputSolution">The solution to update.</param>
        /// <param name="solutionDirectory">The directory where the solution to update resides.</param>
        ///--------------------------------------------------------------------------------
        private static void UpdateOutputSolution(Solution inputSolution, string solutionDirectory)
        {
            try
            {
				// copy specification solution to new solution to build solution model upon
				Solution solutionToGenerate = new Solution();
				solutionToGenerate.TransformDataFromObject(inputSolution, null);

				// update the solution
				solutionToGenerate.SolutionDirectory = solutionDirectory;
				solutionToGenerate.LoadSpecTemplateDirectories();
				solutionToGenerate.LoadCodeTemplateDirectories();
				solutionToGenerate.CompileToOutputSolution(true, true);

				Console.WriteLine("Solution " + inputSolution.SolutionName + " is updated.");
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
        /// <summary>This method displays an exception in the console output.</summary>
        /// 
        /// <param name="ex">The exception to show.</param>
        ///--------------------------------------------------------------------------------
        protected static void ShowException(Exception ex)
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
            Console.WriteLine(errorMessage + "\r\n" + stackTrace);
        }
        #endregion "Methods"

    }
}
