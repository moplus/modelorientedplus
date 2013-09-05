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
using MoPlus.Common;
using System.Web;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MoPlus.Net
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help wrap web response,
	/// especially as xml.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace = "", ElementName = "WebResults")]
	[DataContract]
	public class WebResults
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the status code.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue(0)]
		[DataMember]
		public int StatusCode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the status description.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataMember]
		public string StatusDescription { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method sets the results and outgoing response status.</summary>
		///
		/// <param name="statusCode">The http status code.</param>
		/// <param name="statusDescription">The description of the status.</param>
		///--------------------------------------------------------------------------------
		public void SetWebResponseAndStatus(HttpStatusCode statusCode, string statusDescription)
		{
			// show outgoing response with status even if there is a problem
			WebHelper.SetOutgoingResponseStatus(statusCode, statusDescription, false);
			StatusCode = (int)statusCode;
			StatusDescription = statusDescription;
		}

		#endregion "Methods"
	}
}
