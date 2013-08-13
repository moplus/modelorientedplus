/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.ServiceModel.Web;
using MoPlus.Common;
using MoPlus.Data;

namespace MoPlus.Net
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help support web operations.</summary>
	///--------------------------------------------------------------------------------
	public static class WebHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method creates a directory if it does not exist.</summary>
		///
		/// <param name="inputURL">The input http or https URL to test for a response.</param>
		/// <param name="responseTimeout">The time in milliseconds allowed before response timeout.</param>
		/// 
		/// <returns>True if response received, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		public static bool IsURLResponding(string inputURL, int responseTimeout)
		{
			bool responseReceived = false;

			try
			{
				// create request and get response
				WebRequest webRequest = WebRequest.Create(inputURL);
				webRequest.Timeout = responseTimeout;
				WebResponse webResponse = webRequest.GetResponse();
				responseReceived = true;
			}
			catch (WebException) { }
			return responseReceived;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a post http request.</summary>
		///
		/// <param name="requestURL">The url to sent request to.</param>
		/// <param name="postData">The data to post (in query string format).</param>
		/// <param name="timeout">Timeout in milliseconds (if specified).</param>
		/// <param name="userName">User name for credentials (if needed).</param>
		/// <param name="password">The password for credentials (if needed).</param>
		/// 
		/// <returns>Response if successful.</returns>
		///--------------------------------------------------------------------------------
		public static string SendPostHttpRequest(string requestURL, string postData, int timeout, string userName, string password)
		{
			string response = string.Empty;
			try
			{
				byte[] data = Encoding.UTF8.GetBytes(postData);

				// prepare web request
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestURL);
				webRequest.Method = "POST";
				webRequest.ContentType = "application/x-www-form-urlencoded";
				webRequest.ContentLength = data.Length;
				if (timeout > 0)
				{
					webRequest.Timeout = timeout;
				}
				if (userName != string.Empty)
				{
					webRequest.Credentials = new NetworkCredential(userName, password);
				}
				Stream newStream = webRequest.GetRequestStream();

				// send the data
				newStream.Write(data, 0, data.Length);
				newStream.Close();

				// get the response
				System.IO.StreamReader reader = new StreamReader(((HttpWebResponse)webRequest.GetResponse()).GetResponseStream());
				response = reader.ReadLine();
				reader.Close();
			}
			catch (Exception ex)
			{
				response = "Http post request failed for: " + requestURL;
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return response;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a get http request.</summary>
		///
		/// <param name="requestURL">The url to sent request to (including query string if needed).</param>
		/// <param name="timeout">Timeout in milliseconds (if specified).</param>
		/// <param name="userName">User name for credentials (if needed).</param>
		/// <param name="password">The password for credentials (if needed).</param>
		/// 
		/// <returns>Response if successful.</returns>
		///--------------------------------------------------------------------------------
		public static string SendGetHttpRequest(string requestURL, int timeout, string userName, string password)
		{
			string response = string.Empty;
			try
			{
				// prepare web request
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestURL);
				webRequest.Method = "GET";
				if (timeout > 0)
				{
					webRequest.Timeout = timeout;
				}
				if (userName != string.Empty)
				{
					webRequest.Credentials = new NetworkCredential(userName, password);
				}

				// send the request and get the response
				System.IO.StreamReader reader = new StreamReader(((HttpWebResponse)webRequest.GetResponse()).GetResponseStream());
				response = reader.ReadLine();
				reader.Close();
			}
			catch (Exception ex)
			{
				response = "Http get request failed for: " + requestURL;
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return response;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a query string parameter value as a string.</summary>
		///
		/// <param name="parameterName">The name of the query string parameter.</param>
		///--------------------------------------------------------------------------------
		static public string GetQueryStringParameter(string parameterName)
		{
			if (WebOperationContext.Current != null)
			{
				return WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters[parameterName];
			}
			if (HttpContext.Current != null)
			{
				return HttpContext.Current.Request.QueryString[parameterName];
			}

			throw new InvalidOperationException("WebOperationContext and HttpContext is null, this query string operation cannot be completed.");

		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the outgoing response status (as a bad request).</summary>
		///
		/// <param name="statusDescription">The description of the status.</param>
		///--------------------------------------------------------------------------------
		public static void SetOutgoingResponseBadRequest(string statusDescription)
		{
			SetOutgoingResponseStatus(HttpStatusCode.BadRequest, statusDescription, true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the outgoing response status.</summary>
		///
		/// <param name="statusCode">The http status code.</param>
		/// <param name="statusDescription">The description of the status.</param>
		/// <param name="suppressEntityBody">Flag to suppress response.</param>
		///--------------------------------------------------------------------------------
		public static void SetOutgoingResponseStatus(HttpStatusCode statusCode, string statusDescription, bool suppressEntityBody)
		{
			if (WebOperationContext.Current != null)
			{
				WebOperationContext.Current.OutgoingResponse.StatusDescription = statusDescription;
				WebOperationContext.Current.OutgoingResponse.StatusCode = statusCode;
				WebOperationContext.Current.OutgoingResponse.SuppressEntityBody = suppressEntityBody;
			}
			else if (HttpContext.Current != null)
			{
				HttpContext.Current.Response.StatusDescription = statusDescription;
				HttpContext.Current.Response.StatusCode = (int)statusCode;
				HttpContext.Current.Response.SuppressContent = suppressEntityBody;
			}
			else
			{
				throw new InvalidOperationException("WebOperationContext and HttpContext is null, this outgoing response status operation cannot be completed.");
			}

		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads the input data access options properties with params found
		/// in the query string, if found.</summary>
		/// 
		/// <param name="dataAccessOptions">The data access options to populate.</param>
		///--------------------------------------------------------------------------------
		public static void LoadDataAccessOptionsWithQueryStringParams(DataAccessOptions dataAccessOptions)
		{
			int pageSize = WebHelper.GetQueryStringParameter("pageSize").GetInt();
			if (pageSize != DefaultValue.Int)
			{
				dataAccessOptions.PageSize = pageSize;
			}
			int startIndex = WebHelper.GetQueryStringParameter("startIndex").GetInt();
			if (startIndex != DefaultValue.Int)
			{
				dataAccessOptions.StartIndex = startIndex;
			}
			int maximumListSize = WebHelper.GetQueryStringParameter("maximumListSize").GetInt();
			if (maximumListSize != DefaultValue.Int)
			{
				dataAccessOptions.MaximumListSize = maximumListSize;
			}
			string sortColumn = WebHelper.GetQueryStringParameter("sortColumn");
			if (string.IsNullOrEmpty(sortColumn) == false)
			{
				dataAccessOptions.SortColumn = sortColumn;
			}
			string sortDirection = WebHelper.GetQueryStringParameter("sortDirection");
			if (string.IsNullOrEmpty(sortDirection) == false)
			{
				if (sortDirection.ToLower().StartsWith("asc") == true)
				{
					dataAccessOptions.SortDirection = SortDirection.Ascending;
				}
				else if (sortDirection.ToLower().StartsWith("des") == true)
				{
					dataAccessOptions.SortDirection = SortDirection.Descending;
				}
				else if (sortDirection.ToLower().StartsWith("ran") == true)
				{
					dataAccessOptions.SortDirection = SortDirection.Random;
				}
			}
		}
		#endregion "Methods"
	}
}
