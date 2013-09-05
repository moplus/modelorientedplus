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

namespace MoPlus.Interpreter.BLL.Entities
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Collection class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/21/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Collection : Solutions.PropertyBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the primary Relationship of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Relationship Relationship
		{
			get
			{
				if (PropertyRelationshipList.Count > 0)
				{
					return PropertyRelationshipList[0].Relationship;
				}
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsBaseProperty.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsBaseProperty
		{
			get
			{
				return IsPropertyFound(CollectionName, Entity, Solution, false);
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method determined if a collection entity property is
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
				// look for collection in base entity
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
				// look for collection in current entity
				foreach (Collection loopProperty in inputEntity.CollectionList)
				{
					if (loopProperty.CollectionName == inputPropertyName)
					{
						return true;
					}
				}
			}

			return false;
		}
		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}