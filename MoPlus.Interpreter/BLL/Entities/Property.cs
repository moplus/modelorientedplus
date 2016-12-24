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
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Property class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/21/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Property : Solutions.PropertyBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsBaseProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsBaseProperty
		{
			get
			{
				return IsPropertyFound(PropertyName, Entity, Solution, false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsAuditProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsAuditProperty
		{
			get
			{
				if (Solution.AuditPropertyList != null && Solution.AuditPropertyList.Find("PropertyName", PropertyName) != null)
				{
					return true;
				}
				return false;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method determined if an entity data property is
		/// already part of the input entity.</summary>
		///
		/// <param name="inputPropertyName">The name of the property to look for a duplicate.</param>
		/// <param name="inputEntity">The entity to look for reference entity properties.</param>
		/// <param name="inputSolution">The solution associated with the metadata.</param>
		///--------------------------------------------------------------------------------
		public static bool IsPropertyFound(string inputPropertyName, Entity inputEntity, Solution inputSolution, bool checkInputEntity)
		{
			if (inputEntity.BaseEntityID != null)
			{
				// look for property in base entity
				Entity baseEntity = null;
				if (inputEntity.BaseEntityID != null)
				{
					baseEntity = inputSolution.EntityList.FindByID((Guid)inputEntity.BaseEntityID);
				}
				if (baseEntity != null)
				{
					if (IsPropertyFound(inputPropertyName, baseEntity, inputSolution, true) == true)
					{
						return true;
					}
				}
			}

			if (checkInputEntity == true)
			{
				// look for property in current entity
				foreach (Property loopProperty in inputEntity.PropertyList)
				{
					if (loopProperty.PropertyName == inputPropertyName)
					{
						return true;
					}
				}
			}

			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns a default property based on db column info.</summary>
		/// 
		/// <param name="column">The column information.</param>
		/// <param name="entity">The parent entity.</param>
		///--------------------------------------------------------------------------------
		public static Property BuildPropertyFromSqlColumn(SqlColumn column, Entity entity)
		{
			Property property = new Property();
			property.IsAutoUpdated = true;
			property.PropertyID = Guid.NewGuid();
			property.PropertyName = column.SqlColumnName.Replace(" ", "_");
			property.Entity = entity;
			property.Tags = "DB";
			property.SourceName = column.SqlColumnName;
			property.IsNullable = column.Nullable ?? false;
			if (column.MaximumLength > 0)
			{
				property.Length = column.MaximumLength;
			}
			property.Precision = column.NumericPrecision;
			property.Scale = column.NumericScale;
			property.InitialValue = column.Default;
			property.IsPrimaryKeyMember = column.InPrimaryKey ?? false;
			property.IsForeignKeyMember = column.IsForeignKey ?? false;
			property.Order = column.Order;
			switch (column.DataType)
			{
				case "sbyte":
					property.DataTypeCode = 1;
					break;
				case "smallint":
					property.DataTypeCode = 2;
					break;
				case "int":
					property.DataTypeCode = 3;
					break;
				case "bigint":
					property.DataTypeCode = 4;
					break;
				/*case "binary":
					property.DataTypeCode = 5;
					break*/
				/* TODO: utilize constraints possibly to identify unsigned data types
				case "smallint":
					property.DataTypeCode = 6;
					break
				case "int":
					property.DataTypeCode = 7;
					break
				case "bigint":
					property.DataTypeCode = 8;
					break*/
				case "real":
				case "float":
					property.DataTypeCode = 9;
					break;
				case "double":
					property.DataTypeCode = 10;
					break;
				case "decimal":
					property.DataTypeCode = 11;
					break;
				case "bit":
					property.DataTypeCode = 12;
					break;
				case "char":
					property.DataTypeCode = 13;
					break;
				case "nchar":
					property.DataTypeCode = 17;
					break;
				/*case "binary":
					property.DataTypeCode = 15;
					break*/
				case "varchar":
					property.DataTypeCode = 16;
					break;
				case "nvarchar":
					property.DataTypeCode = 17;
					break;
				case "money":
					property.DataTypeCode = 18;
					break;
				case "text":
					property.DataTypeCode = 19;
					break;
				case "ntext":
					property.DataTypeCode = 20;
					break;
				case "tinyint":
					property.DataTypeCode = 21;
					break;
				/*case "tinyint":
					property.DataTypeCode = 22;
					break*/
				case "image":
					property.DataTypeCode = 27;
					break;
				case "binary":
					property.DataTypeCode = 23;
					break;
				case "date":
					property.DataTypeCode = 24;
					break;
				case "datetime":
					property.DataTypeCode = 24;
					break;
				case "timestamp":
					property.DataTypeCode = 25;
					break;
				case "uniqueidentifier":
					property.DataTypeCode = 26;
					break;
				default:
					property.DataTypeCode = 16;
					break;
			}
			property.Identity = column.Identity;
			property.IdentityIncrement = column.IdentityIncrement;
			property.IdentitySeed = column.IdentitySeed;
			return property;
		}
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}