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
	/// <summary>This class is used to help perform typical media operations.</summary>
	///--------------------------------------------------------------------------------
	public static class MediaHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the input file is a valid media file.</summary>
		///
		/// <param name="inputFilePath">The input media file path.</param>
		///--------------------------------------------------------------------------------
		public static bool IsValidMediaFile(string inputFilePath)
		{
			return File.Exists(inputFilePath);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a media file for basic media operations.</summary>
		///
		/// <param name="inputFilePath">The input media file path.</param>
		///--------------------------------------------------------------------------------
		public static MediaFile GetMediaFile(string inputFilePath)
		{
			if (IsValidMediaFile(inputFilePath) == true)
			{
				MediaFile newMediaFile = new MediaFile(inputFilePath);
				return newMediaFile;
			}
			return null;
		}

		#endregion "Methods"

	}
}
