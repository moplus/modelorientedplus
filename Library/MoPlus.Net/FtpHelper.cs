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
using System.IO;
using System.Net;
using MoPlus.Common;
using MoPlus.IO;

namespace MoPlus.Net
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help support ftp operations.</summary>
	///--------------------------------------------------------------------------------
	public abstract class FtpHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method uploads a file to an ftp server location.</summary>
		///
		/// <param name="localFilePath">The path of the file to upload.</param>
		/// <param name="ftpServer">The name of the upload ftp server.</param>
		/// <param name="ftpFilePath">The path of the file to copy to on the ftp server.</param>
		/// <param name="ftpUserName">The user name for upload credentials.</param>
		/// <param name="ftpPassword">The password for upload credentials.</param>
		/// 
		/// <remarks>This version replaces the upload file, no questions asked, add a method
		/// to prompt for file replacement operations.</remarks>
		/// 
		/// <returns>Response from the upload.</returns>
		///--------------------------------------------------------------------------------
		public string UploadFile(string localFilePath, string ftpServer, string ftpFilePath, string ftpUserName, string ftpPassword)
		{
			string ftpResponse = string.Empty;
			try
			{
				// get the object used to communicate with the server
				string ftpURL = "ftp:" + ftpServer;
				if (ftpServer.EndsWith("/") == false && ftpFilePath.StartsWith("/") == false)
				{
					ftpURL += "/";
				}
				ftpURL += ftpFilePath;
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
				request.Method = WebRequestMethods.Ftp.UploadFile;

				// get the credentials
				request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

				// copy the contents of the file to the request stream
				StreamReader sourceStream = new StreamReader(localFilePath);
				byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
				sourceStream.Close();
				request.ContentLength = fileContents.Length;

				Stream requestStream = request.GetRequestStream();
				requestStream.Write(fileContents, 0, fileContents.Length);
				requestStream.Close();

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();

				ftpResponse = "Upload of file " + localFilePath + " complete: " + response.StatusDescription;

				response.Close();
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return ftpResponse;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method downloads a file from an ftp server location.</summary>
		///
		/// <param name="localFilePath">The path of the file to upload.</param>
		/// <param name="downloadServer">The name of the upload ftp server.</param>
		/// <param name="downloadFilePath">The path of the file to copy to on the ftp server.</param>
		/// <param name="ftpUserName">The user name for upload credentials.</param>
		/// <param name="ftpPassword">The password for upload credentials.</param>
		/// 
		/// <remarks>This version replaces the local file, no questions asked, add a method
		/// to prompt for file replacement operations.</remarks>
		/// 
		/// <returns>Response from the upload.</returns>
		///--------------------------------------------------------------------------------
		public string DownloadFile(string localFilePath, string downloadServer, string downloadFilePath, string ftpUserName, string ftpPassword)
		{
			string ftpResponse = string.Empty;
			try
			{
				// get the object used to communicate with the server
				string ftpURL = "ftp:" + downloadServer;
				if (downloadServer.EndsWith("/") == false && downloadFilePath.StartsWith("/") == false)
				{
					ftpURL += "/";
				}
				ftpURL += downloadFilePath;
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
				request.Method = WebRequestMethods.Ftp.DownloadFile;

				// get the credentials
				request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

				// get the file
				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(responseStream);
				FileHelper.ReplaceFile(localFilePath, reader.ReadToEnd());

				ftpResponse = "download of file " + localFilePath + " complete: " + response.StatusDescription;

				reader.Close();
				response.Close();
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return ftpResponse;
		}
		#endregion "Methods"
	}
}
