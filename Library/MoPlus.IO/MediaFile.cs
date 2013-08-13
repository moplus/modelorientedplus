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
using System.Runtime.InteropServices;

namespace MoPlus.IO
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to hold a media file to perform some basic media
	/// player operations.</summary>
	/// 
	/// <remarks>This utilizes the windows multi media api, which only performs some
	/// basic operations.  For more in depth media operations, use something like the
	/// windows media sdk and other packages.</remarks>
	///--------------------------------------------------------------------------------
	public class MediaFile
	{
		#region "Fields and Properties"
		// media flags, check mmsystem.h for more
		public int SND_ASYNC = 0x0001; // play asynchronously
		public int SND_FILENAME = 0x00020000; // use file name
		public int SND_PURGE = 0x0040; // purge non-static events

		public string MediaFilePath { get; set; }
		#endregion "Fields and Properties"

		#region "Methods"

		[DllImport("WinMM.dll")]
		private static extern bool PlaySound(string fname, int Mod, int flag);

		///--------------------------------------------------------------------------------
		/// <summary>This method plays a wav file.</summary>
		///--------------------------------------------------------------------------------
		public void PlayWavSound()
		{
			PlaySound(MediaFilePath, 0, SND_FILENAME | SND_ASYNC);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method plays a wav file.</summary>
		///
		/// <param name="mediaFlags">The input media flags.</param>
		///--------------------------------------------------------------------------------
		public void PlayWavSound(int mediaFlags)
		{
			PlaySound(MediaFilePath, 0, mediaFlags);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method stops playing a wav file.</summary>
		///--------------------------------------------------------------------------------
		public void StopWavSound()
		{
			PlaySound(null, 0, SND_PURGE);
		}
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a media file with the input path.</summary>
		///
		/// <param name="mediaFilePath">The path to the media file.</param>
		///--------------------------------------------------------------------------------
		public MediaFile(string mediaFilePath)
		{
			MediaFilePath = mediaFilePath;
		}
		#endregion "Constructors"
	}
}
