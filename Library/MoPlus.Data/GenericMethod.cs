/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Data.Services;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to support general needs for creating and managing
	/// generic methods.  Entities can have associated method parameters.</summary>
	///
	/// <remarks>This class should not be used directly for enterprise objects that
	/// have data that needs to be managed in a database, etc.  Enterprise objects
	/// should derive from IEnterpriseDataObject.</remarks>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[IgnoreProperties("MethodParameterList")]
	public class GenericMethod : DataObjectBase
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override Guid ID
		{
			get
			{
				return MethodID;
			}
			set
			{
				MethodID = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the id of the method.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public Guid MethodID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the method.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public string MethodName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the method type.  Valid method types depend
		/// entirely on the set provided by the user of this method.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue(DefaultValue.Int)]
		[DataElement]
		public int MethodTypeCode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the method type.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public string MethodTypeName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the description of the method.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public string Description { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets a generic value.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public object GenericValue { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the list of parameters for the method.</summary>
		///--------------------------------------------------------------------------------
		[XmlArrayItem(ElementName = "MethodParameterList", Type = typeof(GenericParameter))]
		[DataArrayItem]
		public SortableDataObjectList<GenericParameter> MethodParameterList { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public GenericMethod(){}
		#endregion "Constructors"
	}
}
