/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.IO;
using MoPlus.Interpreter.Resources;

namespace MoPlus.Interpreter.BLL.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the XmlSource class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/21/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class XmlSource : Solutions.SpecificationSource
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override string Name
		{
			get
			{
				return SourceFileName;
			}
			set
			{
				SourceFileName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the display name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DisplayName
		{
			get
			{
				return Name;
			}
		}

		private XmlDocument _specDocument = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the specification document.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlDocument SpecDocument
		{
			get
			{
				if (_specDocument == null)
				{
					LoadSpecificationSource();
				}
				if (_specDocument != null && _specDocument.XmlSource == null)
				{
					_specDocument.XmlSource = this;
				}
				return _specDocument;
			}
			set
			{
				_specDocument = value;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads a specification source with information from an
		/// xml document.</summary>
		///--------------------------------------------------------------------------------
		public void LoadSpecificationSource()
		{
			try
			{
				System.Xml.XmlDocument document = new System.Xml.XmlDocument();
				document.LoadXml(FileHelper.GetText(SourceFilePath));
				if (document.OuterXml == String.Empty)
				{
					SpecDocument = null;
					throw new ApplicationException(String.Format(DisplayValues.Exception_SourceXmlMissing, SourceFilePath));
				}
				else
				{
					// load the document information
					SpecDocument = new XmlDocument();
					SpecDocument.LoadDocument(document);
				}
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				Solution.ShowIssue(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public XmlSource GetForwardInstance()
		{
			XmlSource forwardItem = new XmlSource();
			forwardItem.TransformDataFromObject(this, null, false);
			return forwardItem;
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}