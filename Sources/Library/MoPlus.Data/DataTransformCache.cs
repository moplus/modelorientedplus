/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MoPlus.Common;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to perform data transform related operations between
	/// similar or dissimilar objects.</summary>
	///
	/// <remarks>The DataElement or DataArrayItem attribute cannot be put on a read only property, apply
	/// it to the corresponding field instead.</remarks>
	///--------------------------------------------------------------------------------
	public class DataTransformCache
	{
		private NameObjectCollection _genericEntityCache = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the cache for entities used in data transforms
		/// and other data operations.</summary>
		///--------------------------------------------------------------------------------
		public NameObjectCollection GenericEntityCache
		{
			get
			{
				if (_genericEntityCache == null)
				{
					_genericEntityCache = new NameObjectCollection();
				}
				return _genericEntityCache;
			}
			set
			{
				_genericEntityCache = value;
			}
		}

		private NameObjectCollection _propertyInfoCache = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the cache for properties used in data transforms
		/// and other data operations.</summary>
		///--------------------------------------------------------------------------------
		public NameObjectCollection PropertyInfoCache
		{
			get
			{
				if (_propertyInfoCache == null)
				{
					_propertyInfoCache = new NameObjectCollection();
				}
				return _propertyInfoCache;
			}
			set
			{
				_propertyInfoCache = value;
			}
		}

		private NameObjectCollection _fieldInfoCache = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the cache for fields used in data transforms
		/// and other data operations.</summary>
		///--------------------------------------------------------------------------------
		public NameObjectCollection FieldInfoCache
		{
			get
			{
				if (_fieldInfoCache == null)
				{
					_fieldInfoCache = new NameObjectCollection();
				}
				return _fieldInfoCache;
			}
			set
			{
				_fieldInfoCache = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Add a generic entity loaded with property and field info from reflection.</summary>
		///
		/// <param name="inputObject">The object with the input data.</param>
		/// 
		/// <returns>A GenericEntity with property/field info.</returns>
		///--------------------------------------------------------------------------------
		public GenericEntity AddNewEntityWithPropertyFieldInfo(IDataObject inputObject)
		{
			GenericEntity newEntity = new GenericEntity();

			try
			{
				newEntity.EntityName = inputObject.GetType().FullName;
				newEntity.PropertyList = new SortableDataObjectList<GenericProperty>();

				// add all public properties with the DataElement or DataArrayItem attribute to the entity
				foreach (PropertyInfo loopInfo in inputObject.GetType().GetProperties())
				{
					foreach (object loopAttribute in loopInfo.GetCustomAttributes(true))
					{
						if (loopAttribute is DataElementAttribute)
						{
							// get name of property to transform
							string transformName = (loopAttribute as DataElementAttribute).ElementName.GetString().Trim();
							if (transformName == String.Empty)
							{
								transformName = loopInfo.Name.Trim();
							}
							GenericProperty newProperty = new GenericProperty();
							newProperty.PropertyName = transformName;
							newProperty.GenericValue = loopInfo;
							PropertyInfoCache[newEntity.EntityName + "." + transformName] = loopInfo;
							newProperty.PropertyTypeCode = (int)DataTransformPropertyType.ElementProperty;
							newEntity.PropertyList.Add(newProperty);
						}
						else if (loopAttribute is DataArrayItemAttribute)
						{
							// get name of property to transform
							string transformName = (loopAttribute as DataArrayItemAttribute).ElementName.GetString().Trim();
							if (transformName == String.Empty)
							{
								transformName = loopInfo.Name.Trim();
							}
							GenericProperty newProperty = new GenericProperty();
							newProperty.PropertyName = transformName;
							newProperty.GenericValue = loopInfo;
							PropertyInfoCache[newEntity.EntityName + "." + transformName] = loopInfo;
							newProperty.PropertyTypeCode = (int)DataTransformPropertyType.ArrayItemProperty;
							newEntity.PropertyList.Add(newProperty);
						}
					}
				}

				// add all fields with the DataElement or DataArrayItem attribute to the entity
				foreach (FieldInfo loopInfo in inputObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance))
				{
					foreach (object loopAttribute in loopInfo.GetCustomAttributes(true))
					{
						if (loopAttribute is DataElementAttribute)
						{
							// get name of field to transform
							string transformName = (loopAttribute as DataElementAttribute).ElementName.GetString().Trim();
							if (transformName == String.Empty)
							{
								transformName = loopInfo.Name.Trim();
							}
							GenericProperty newProperty = new GenericProperty();
							newProperty.PropertyName = transformName;
							newProperty.GenericValue = loopInfo;
							FieldInfoCache[newEntity.EntityName + "." + transformName] = loopInfo;
							newProperty.PropertyTypeCode = (int)DataTransformPropertyType.ElementField;
							newEntity.PropertyList.Add(newProperty);
						}
						else if (loopAttribute is DataArrayItemAttribute)
						{
							// get name of field to transform
							string transformName = (loopAttribute as DataArrayItemAttribute).ElementName.GetString().Trim();
							if (transformName == String.Empty)
							{
								transformName = loopInfo.Name.Trim();
							}
							GenericProperty newProperty = new GenericProperty();
							newProperty.PropertyName = transformName;
							newProperty.GenericValue = loopInfo;
							FieldInfoCache[newEntity.EntityName + "." + transformName] = loopInfo;
							newProperty.PropertyTypeCode = (int)DataTransformPropertyType.ArrayItemField;
							newEntity.PropertyList.Add(newProperty);
						}
					}
				}
				GenericEntityCache[newEntity.EntityName] = newEntity;
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return newEntity;
		}

	}
}
