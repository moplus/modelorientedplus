/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.IO;
using System.Text;

namespace MoPlus.IO
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to help perform typical directory operations.</summary>
	///--------------------------------------------------------------------------------
	public static class DirectoryHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method creates a directory if it does not exist.</summary>
		///
		/// <param name="inputDirectoryPath">The input directory path to create.</param>
		///--------------------------------------------------------------------------------
		public static void CreateDirectory(string inputDirectoryPath)
		{
			// create directory if it does not exist
			if (Directory.Exists(inputDirectoryPath) == false)
			{
				Directory.CreateDirectory(inputDirectoryPath);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method deletes a directory if it exists.</summary>
		///
		/// <param name="inputDirectoryPath">The input directory path to delete.</param>
		/// <param name="recursive">Delete subdirectories.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteDirectory(string inputDirectoryPath, bool recursive)
		{
			// delete directory if it does exist
			if (Directory.Exists(inputDirectoryPath) == true)
			{
				Directory.Delete(inputDirectoryPath, recursive);
			}
		}
		#endregion "Methods"

	}
}
