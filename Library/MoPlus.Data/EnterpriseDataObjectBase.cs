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
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is a base implementation of the IEnterpriseDataObject
	/// interface.  Database related methods are empty and need implementation in actual
	/// enterprise objects.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[DataContract]
	public abstract class EnterpriseDataObjectBase : DataObjectBase, IEnterpriseDataObject
	{
		#region "Fields and Properties"
		[DataMember(Name = "IsLoaded")]
		[DataElement(ElementName = "IsLoaded")]
		protected bool _isLoaded = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been loaded from a resource
		/// such as a database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IsLoaded
		{
			get
			{
				return _isLoaded;
			}
		}

		[DataMember(Name = "IsModified")]
		[DataElement(ElementName = "IsModified")]
		protected bool __isModified = DefaultValue.Bool;
		protected bool _isModified
		{
			get { return __isModified; }
			set { __isModified = value; }
		}
		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been modified since the
		/// last load from a resource such as a database.</summary>
		/// 
		/// <remarks>This property should be extended to check collections to see if anything is modified.</remarks>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IsModified
		{
			get
			{
				return _isModified;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary key.  This property should be
		/// overridden.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public virtual string PrimaryKeyValues
		{
			get
			{
				
				return (RandomInt.GetString());
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					RandomInt = primaryKeyValues[0].GetInt();
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the primary key columns (names).  This property
		/// should be overridden.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public virtual string PrimaryKeyProperties
		{
			get
			{
				return "RandomInt";
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsLoaded state for the instance.</summary>
		///
		/// <remarks>This should only be used if special business rules override normal loading behavior.
		/// This method may need to be extended to reset collections.</remarks>
		/// 
		/// <param name="isLoaded">The reset value for the IsLoaded property.</param>
		///--------------------------------------------------------------------------------
		public virtual void ResetLoaded(bool isLoaded)
		{
			_isLoaded = isLoaded;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsModified state for the instance.</summary>
		///
		/// <remarks>This should only be used if special business rules override normal modified behavior.
		/// This method may need to be extended to reset collections.</remarks>
		/// 
		/// <param name="isModified">The reset value for the IsModified property.</param>
		///--------------------------------------------------------------------------------
		public virtual void ResetModified(bool isModified)
		{
			_isModified = isModified;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input enterprise data object is equal to
		/// (in key values) to the current instance.</summary>
		/// 
		/// <param name="inputObject">The item to compare.</param>
		/// 
		/// <returns>True if two instances compare as equal, false otherwise.</returns>
		///--------------------------------------------------------------------------------
		public override bool Equals(object inputObject)
		{
			if (inputObject == null)
			{
				return false;
			}

			if (inputObject is IEnterpriseDataObject && GetType().Name == inputObject.GetType().Name)
			{
				IEnterpriseDataObject inputEnterpriseDataObject = (IEnterpriseDataObject)inputObject;

				// compare primary key values for equality
				if (PrimaryKeyValues != inputEnterpriseDataObject.PrimaryKeyValues)
				{
					return false;
				}

				// compare all public property values for equality
				GenericEntity inputEntity = null;
				if (DataTransformHelper.EntityPropertyFieldInfoCache.GenericEntityCache[inputEnterpriseDataObject.GetType().FullName] is GenericEntity)
				{
					inputEntity = DataTransformHelper.EntityPropertyFieldInfoCache.GenericEntityCache[inputEnterpriseDataObject.GetType().FullName] as GenericEntity;
				}
				else
				{
					inputEntity = DataTransformHelper.EntityPropertyFieldInfoCache.AddNewEntityWithPropertyFieldInfo(inputEnterpriseDataObject);
				}
				foreach (GenericProperty loopProperty in inputEntity.PropertyList)
				{
					if (loopProperty.PropertyTypeCode == (int)DataTransformPropertyType.ElementProperty || loopProperty.PropertyTypeCode == (int)DataTransformPropertyType.ElementField)
					{
						if (inputEnterpriseDataObject.IsPropertyValueMatch(loopProperty.PropertyName, GetPropertyValue(loopProperty.PropertyName)) == false)
						{
							return false;
						}
					}
				}

				return true;
			}

			return false;
		}


		///--------------------------------------------------------------------------------
		/// <summary>This override of GetHashCode uses the primary key values to determine
		/// an identifying instance.</summary>
		/// 
		/// <returns>The hash code as primary key values.</returns>
		///--------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			return PrimaryKeyValues.GetHashCode();
		}
		#endregion "Methods"
	}
}
