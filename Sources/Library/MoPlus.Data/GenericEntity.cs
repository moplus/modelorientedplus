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
	/// generic entities.  Entities can have properties, methods, and associated method
	/// parameters.</summary>
	///
	/// <remarks>This class should not be used directly for enterprise objects that
	/// have data that needs to be managed in a database, etc.  Enterprise objects
	/// should derive from IEnterpriseDataObject.</remarks>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[IgnoreProperties("PropertyList", "MethodList")]
	public class GenericEntity : DataObjectBase
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
				return EntityID;
			}
			set
			{
				EntityID = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the id of the entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public Guid EntityID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public string EntityName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the entity type.  Valid entity types depend
		/// entirely on the set provided by the user of this entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue(DefaultValue.Int)]
		[DataElement]
		public int EntityTypeCode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the entity type.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DefaultValue("")]
		[DataElement]
		public string EntityTypeName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the description of the entity.</summary>
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
		/// <summary>This property gets/sets the list of properties for the entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlArrayItem(ElementName = "PropertyList", Type = typeof(GenericProperty))]
		[DataArrayItem]
		public SortableDataObjectList<GenericProperty> PropertyList { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the list of methods for the entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlArrayItem(ElementName = "MethodList", Type = typeof(GenericMethod))]
		[DataArrayItem]
		public SortableDataObjectList<GenericMethod> MethodList { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public GenericEntity(){}
		#endregion "Constructors"
	}
}
