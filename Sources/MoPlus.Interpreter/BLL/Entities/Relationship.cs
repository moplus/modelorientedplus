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

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Relationship class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/20/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Relationship : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PropertyCount
		{
			get
			{
				if (RelationshipPropertyList != null)
				{
					return RelationshipPropertyList.Count;
				}
				return 0;
			}
		}

		protected EnterpriseDataObjectList<BLL.Entities.Relationship> _relationships = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of Relationships.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Relationship> Relationships
		{
			get
			{
				if (_relationships == null)
				{
					_relationships = new EnterpriseDataObjectList<BLL.Entities.Relationship>();
				}
				return _relationships;
			}
			set
			{
				_relationships = value;
			}
		}

		protected EnterpriseDataObjectList<BLL.Entities.PropertyReference> _propertyReferences = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of PropertyReferences.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.PropertyReference> PropertyReferences
		{
			get
			{
				if (_propertyReferences == null)
				{
					_propertyReferences = new EnterpriseDataObjectList<BLL.Entities.PropertyReference>();
				}
				return _propertyReferences;
			}
			set
			{
				_propertyReferences = value;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns a default relationship based on db foreign key info.</summary>
		/// 
		/// <param name="key">The key information.</param>
		/// <param name="entity">The parent entity.</param>
		///--------------------------------------------------------------------------------
		public static Relationship BuildRelationshipFromSqlForeignKey(SqlForeignKey key, Entity entity)
		{
			Relationship relationship = new Relationship();
			relationship.IsAutoUpdated = true;
			relationship.RelationshipID = Guid.NewGuid();
			relationship.RelationshipName = key.SqlForeignKeyName.Replace(" ", "_");
			relationship.Entity = entity;
			relationship.Tags = "DB";
			relationship.SourceName = key.SqlForeignKeyName;
			relationship.ReferencedItemsMin = 1;
			relationship.ReferencedItemsMax = 1;
			relationship.ItemsMin = 0;
			relationship.ItemsMax = -1;
			relationship.IsNullable = false;
			foreach (Entity item in entity.Solution.EntityList)
			{
				if (item.SourceName == key.ReferencedTable)
				{
					relationship.ReferencedEntity = item;
					break;
				}
			}
			return relationship;
		}
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}