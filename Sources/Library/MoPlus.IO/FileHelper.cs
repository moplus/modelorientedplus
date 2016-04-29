/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MoPlus.IO
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to help perform typical file operations.</summary>
	///--------------------------------------------------------------------------------
	public static class FileHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method creates a file if it does not exist.</summary>
		///
		/// <param name="inputFilePath">The input file path to create.</param>
		///--------------------------------------------------------------------------------
		public static void CreateFile(string inputFilePath)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			// create file if it does not exist
			if (fi.Exists == false)
			{
				fi.Create();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method creates a file if it does not exist and there is text to write to it.</summary>
		///
		/// <param name="inputFilePath">The input file path to create.</param>
		/// <param name="inputText">The information to append to the file.</param>
		///--------------------------------------------------------------------------------
		public static void CreateFile(string inputFilePath, string inputText)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			// create file with text if it does not exist
			if (fi.Exists == false && inputText != String.Empty)
			{
				AppendToFile(inputFilePath, inputText);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method renames a file.</summary>
		///
		/// <param name="inputFilePath">The input file path.</param>
		/// <param name="newFilePath">The new file path.</param>
		///--------------------------------------------------------------------------------
		public static void RenameFile(string inputFilePath, string newFilePath)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			FileInfo fiNew = new FileInfo(newFilePath);
			// move file if it exists and destination file doesn't exist
			if (fi.Exists == true && fiNew.Exists == false)
			{
				fi.MoveTo(fiNew.FullName);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method appends information to a file.</summary>
		///
		/// <param name="inputFilePath">The input file path.</param>
		/// <param name="inputText">The information to append to the file.</param>
		///--------------------------------------------------------------------------------
		public static void AppendToFile(string inputFilePath, string inputText)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			if (fi.Exists == true)
			{
				using (StreamWriter writer = fi.AppendText())
				{
					writer.Write(inputText);
				}
			}
			else
			{
				ReplaceFile(inputFilePath, inputText);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method replaces a file with the input information.</summary>
		///
		/// <param name="inputFilePath">The input file path.</param>
		/// <param name="inputText">The information to append to the file.</param>
		///--------------------------------------------------------------------------------
		public static void ReplaceFile(string inputFilePath, string inputText)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			if (fi.Exists == true)
			{
				fi.Delete();
			}
			TextWriter outputFile = new System.IO.StreamWriter(fi.OpenWrite());
			outputFile.Write(inputText);
			outputFile.Close();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the text from a file.</summary>
		///
		/// <param name="inputFilePath">The input file path.</param>
		///--------------------------------------------------------------------------------
		public static string GetText(string inputFilePath)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			string outputText = String.Empty;
			if (fi.Exists == true)
			{
				TextReader inputFile = new System.IO.StreamReader(fi.OpenRead());
				outputText = inputFile.ReadToEnd();
				inputFile.Close();
			}
			return outputText;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the contents of a file as a byte array.</summary>
		///
		/// <param name="inputFilePath">The input file path.</param>
		///--------------------------------------------------------------------------------
		public static byte[] GetBytes(string inputFilePath)
		{
			FileInfo fi = new FileInfo(inputFilePath);
			byte[] outputText = null;
			TextReader inputFile = new System.IO.StreamReader(fi.OpenRead());
			outputText = Encoding.UTF8.GetBytes(inputFile.ReadToEnd());
			inputFile.Close();
			return outputText;
		}

		#endregion "Methods"

	}
}
