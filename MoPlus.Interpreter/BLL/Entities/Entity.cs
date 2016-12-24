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
using Microsoft.SqlServer.Management.Smo;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Entity class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/20/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Entity : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PrimaryKeyCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PrimaryKeyCount
		{
			get
			{
				int keyCount = 0;
				if (PropertyList != null)
				{
					foreach (Property property in PropertyList)
					{
						if (property.IsPrimaryKeyMember == true) keyCount++;
					}
				}
				return keyCount;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyReferenceCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PropertyReferenceCount
		{
			get
			{
				return PropertyReferenceList.Count;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PropertyCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int PropertyCount
		{
			get
			{
				return PropertyList.Count;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the CollectionCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CollectionCount
		{
			get
			{
				return CollectionList.Count;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EntityReferenceCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int EntityReferenceCount
		{
			get
			{
				return EntityReferenceList.Count;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MethodCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int MethodCount
		{
			get
			{
				return MethodList.Count;
			}
		}

		private EnterpriseDataObjectList<Entity> _extendingEntities;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of entities that extend this entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public EnterpriseDataObjectList<Entity> ExtendingEntites
		{
			get
			{
				if (_extendingEntities == null)
				{
					_extendingEntities = new EnterpriseDataObjectList<Entity>();
					foreach (Entity loopEntity in Solution.EntityList)
					{
						if (loopEntity.BaseEntity == this)
						{
							_extendingEntities.Add(loopEntity);
						}
					}
				}
				return _extendingEntities;
			}
			set
			{
				_extendingEntities = value;
			}
		}

		protected EnterpriseDataObjectList<BLL.Entities.Relationship> _pathRelationships = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of PathRelationships.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Entities.Relationship> PathRelationships
		{
			get
			{
				if (_pathRelationships == null)
				{
					_pathRelationships = new EnterpriseDataObjectList<BLL.Entities.Relationship>();
					Relationship relationshipPath = null;

					// set relationship paths and related aliases
					foreach (PropertyReference loopProperty in PropertyReferenceList)
					{
						if (loopProperty.PropertyRelationshipList.Count > 0)
						{
							// create or identify relationship path for property
							relationshipPath = null;

							// use existing path if all relationships in property relationship list are in existing path
							foreach (Relationship loopPath in _pathRelationships)
							{
								relationshipPath = loopPath;
								foreach (PropertyRelationship loopRelationship in loopProperty.PropertyRelationshipList)
								{
									if (loopPath.Relationships.FindByID(loopRelationship.RelationshipID) == null)
									{
										relationshipPath = null;
										break;
									}
								}
							}
							if (relationshipPath == null)
							{
								// add to existing path if all relationships in existing path are in property relationship list
								foreach (Relationship loopPath in _pathRelationships)
								{
									relationshipPath = loopPath;
									foreach (Relationship relationship in loopPath.Relationships)
									{
										if (loopProperty.PropertyRelationshipList.Find("RelationshipID", relationship.RelationshipID) == null)
										{
											relationshipPath = null;
											break;
										}
									}
									if (relationshipPath != null)
									{
										// add any remaining relationships to path
										foreach (PropertyRelationship loopRelationship in loopProperty.PropertyRelationshipList)
										{
											if (relationshipPath.Relationships.FindByID(loopRelationship.RelationshipID) == null)
											{
												relationshipPath.Relationships.Add(loopRelationship.Relationship);
											}
										}
										break;
									}
								}
							}
							if (relationshipPath == null)
							{
								// create new path
								relationshipPath = loopProperty.PropertyRelationshipList[0].Relationship;
								_pathRelationships.Add(relationshipPath);
								foreach (PropertyRelationship loopRelationship in loopProperty.PropertyRelationshipList)
								{
									relationshipPath.Relationships.Add(loopRelationship.Relationship);
								}

							}
						}

						// add property to identified relationship path
						if (relationshipPath != null)
						{
							foreach (Relationship loopRelationship in relationshipPath.Relationships)
							{
								if (loopRelationship.RelationshipID == loopProperty.PropertyRelationshipList[loopProperty.PropertyRelationshipList.Count - 1].RelationshipID)
								{
									loopRelationship.PropertyReferences.Add(loopProperty);
									break;
								}
							}
						}
					}
				}
				return _pathRelationships;
			}
			set
			{
				_pathRelationships = value;
			}
		}

		private Entity _baseEntity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BaseEntity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Entity BaseEntity
		{
			get
			{
				if (_baseEntity == null && BaseEntityID != null && Solution != null)
				{
					_baseEntity = Solution.EntityList.FindByID((Guid)BaseEntityID);
				}
				return _baseEntity;
			}
			set
			{
				_baseEntity = value;
			}
		}

		private Table _sqlTable;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SqlTable.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Table SqlTable
		{
			get
			{
				return _sqlTable;
			}
			set
			{
				_sqlTable = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DB table name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DBTableName
		{
			get
			{
				return "[dbo].[" + SpecSourceName + "]";
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method determines if a property name is already used.</summary>
		/// 
		/// <param name="propertyName">The input property name to test.</param>
		///--------------------------------------------------------------------------------
		public bool HasPropertyNamed(string propertyName)
		{
			if (Property.IsPropertyFound(propertyName, this, Solution, true) == true)
			{
				return true;
			}
			if (PropertyReference.IsPropertyFound(propertyName, this, Solution, true) == true)
			{
				return true;
			}
			if (Collection.IsPropertyFound(propertyName, this, Solution, true) == true)
			{
				return true;
			}
			if (EntityReference.IsPropertyFound(propertyName, this, Solution, true) == true)
			{
				return true;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns a default entity based on db table info.</summary>
		/// 
		/// <param name="table">The table information.</param>
		/// <param name="feature">The parent feature.</param>
		///--------------------------------------------------------------------------------
		public static Entity BuildEntityFromSqlTable(SqlTable table, Feature feature)
		{
			Entity entity = new Entity();
			entity.IsAutoUpdated = true;
			entity.EntityID = Guid.NewGuid();
			entity.EntityName = table.SqlTableName.Replace(" ", "_");
			entity.EntityTypeCode = 1;
			entity.Feature = feature;
			entity.Tags = "DB";
			entity.SourceName = table.SqlTableName;
	
			// set identifier type
			if (table.PrimaryKeyColumnCount == 1 && table.PrimaryAndForeignKeyColumnCount == 1)
			{
				entity.IdentifierTypeCode = 3; // ForeignKey
			}
			else if (table.PrimaryKeyColumnCount > 1)
			{
				entity.IdentifierTypeCode = 4; // MultipleColumn
			}
			else
			{
				foreach (SqlColumn column in table.SqlColumnList)
				{
					if (column.InPrimaryKey == true)
					{
						if (column.Identity == true || column.DataType == "uniqueidentifier")
						{
							entity.IdentifierTypeCode = 1; // Generated
						}
						else
						{
							entity.IdentifierTypeCode = 2; // Coded
						}
					}
				}
			}
			return entity;
		}
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}