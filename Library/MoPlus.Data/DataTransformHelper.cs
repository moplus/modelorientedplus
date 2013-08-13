/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;
using MoPlus.Data;
using System.Xml.Serialization;
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
	public static class DataTransformHelper
	{
		#region "Fields and Properties"

		private static DataTransformCache _entityPropertyFieldInfoCache = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/creates/caches the data transform entities encountered
		/// in a generic package format.</summary>
		///--------------------------------------------------------------------------------
		public static DataTransformCache EntityPropertyFieldInfoCache
		{
			get
			{
				if (_entityPropertyFieldInfoCache == null)
				{
					_entityPropertyFieldInfoCache = new DataTransformCache();
				}
				return _entityPropertyFieldInfoCache;
			}
			set
			{
				_entityPropertyFieldInfoCache = value;
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>Transform data from the input data reader into the output object.  Each
		/// element to be transformed must have the DataElement attribute associated with
		/// it.</summary>
		///
		/// <param name="inputReader">The database reader with the input data.</param>
		/// <param name="outputObject">The output object to be populated with the input data.</param>
		/// <param name="filterElements">Data elements to filter out of the transformation.</param>
		///--------------------------------------------------------------------------------
		public static void TransformDataFromDbReader(DbDataReader inputReader, IDataObject outputObject, NameObjectCollection filterElements)
		{
			try
			{
				// add all public properties with the DataElement attribute to the output object
				foreach (PropertyInfo loopInfo in outputObject.GetType().GetProperties())
				{
					foreach (object loopAttribute in loopInfo.GetCustomAttributes(true))
					{
						if (loopAttribute is DataElementAttribute)
						{
							// get name of property to transform
							string transformName = (loopAttribute as DataElementAttribute).ElementName.GetString().Trim().ToLower();
							if (transformName == String.Empty)
							{
								transformName = loopInfo.Name.Trim().ToLower();
							}

							// do transform if not in filter field list
							if (filterElements == null || filterElements[transformName].GetString() == String.Empty)
							{
								for (int i = 0; i < inputReader.FieldCount; i++)
								{
									if (inputReader.GetName(i).Trim().ToLower() == transformName)
									{
										// set value, based on system type
										loopInfo.SetValue(outputObject, DataHelper.GetValueFromSystemType(inputReader[i], loopInfo.PropertyType.UnderlyingSystemType.FullName, false), null);
										break;
									}
								}
							}
						}
					}
				}

				// add all fields with the DataElement attribute to the output object
				foreach (FieldInfo loopInfo in outputObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance))
				{
					foreach (object loopAttribute in loopInfo.GetCustomAttributes(true))
					{
						if (loopAttribute is DataElementAttribute)
						{
							// get name of field to transform
							string transformName = (loopAttribute as DataElementAttribute).ElementName.GetString().Trim().ToLower();
							if (transformName == String.Empty)
							{
								transformName = loopInfo.Name.Trim().ToLower();
							}

							// do transform if not in filter field list
							if (filterElements == null || filterElements[transformName].GetString() == String.Empty)
							{
								for (int i = 0; i < inputReader.FieldCount; i++)
								{
									if (inputReader.GetName(i).Trim().ToLower() == transformName)
									{
										// set value, based on system type
										loopInfo.SetValue(outputObject, DataHelper.GetValueFromSystemType(inputReader[i], loopInfo.FieldType.UnderlyingSystemType.FullName, false));
										break;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Transform data from the input object into the output object.  Each
		/// element to be transformed must have the DataElement or DataArrayItem attribute
		/// associated with it.</summary>
		///
		/// <param name="inputObject">The object with the input data.</param>
		/// <param name="outputObject">The output object to be populated with the input data.</param>
		/// <param name="filterElements">Data elements to filter out of the transformation.</param>
		///--------------------------------------------------------------------------------
		public static void TransformDataFromObject(IDataObject inputObject, IDataObject outputObject, NameObjectCollection filterElements)
		{
			TransformDataFromObject(inputObject, outputObject, filterElements, true, false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Transform data from the input object into the output object.  Each
		/// element to be transformed must have the DataElement or DataArrayItem attribute
		/// associated with it.</summary>
		///
		/// <param name="inputObject">The object with the input data.</param>
		/// <param name="outputObject">The output object to be populated with the input data.</param>
		/// <param name="filterElements">Data elements to filter out of the transformation.</param>
		/// <param name="includeCollections">Flag indicating whether or not to include collections in the transform.</param>
		/// <param name="getNonDefaultValuesOnly">If true, only return a value if not null and not a default value.</param>
		///--------------------------------------------------------------------------------
		public static void TransformDataFromObject(IDataObject inputObject, IDataObject outputObject, NameObjectCollection filterElements, bool includeCollections, bool getNonDefaultValuesOnly)
		{
			GenericEntity inputEntity = null;
			GenericEntity outputEntity = null;
			PropertyInfo inputPropertyInfo = null;
			PropertyInfo outputPropertyInfo = null;
			FieldInfo inputFieldInfo = null;
			FieldInfo outputFieldInfo = null;
			object inputArrayValue = null;
			object inputValue = null;
			Type inputType = null;
			string inputTypeName = String.Empty;
			string outputTypeName = String.Empty;

			try
			{
				if (inputObject != null && outputObject != null)
				{
					// get input and output entities that contain property and field info information
					// add new input and output objects encountered to the entity property/field info cache
					inputTypeName = inputObject.GetType().FullName;
					if (EntityPropertyFieldInfoCache.GenericEntityCache[inputTypeName] is GenericEntity)
					{
						inputEntity = EntityPropertyFieldInfoCache.GenericEntityCache[inputTypeName] as GenericEntity;
					}
					else
					{
						inputEntity = EntityPropertyFieldInfoCache.AddNewEntityWithPropertyFieldInfo(inputObject);
					}
					outputTypeName = outputObject.GetType().FullName;
					if (EntityPropertyFieldInfoCache.GenericEntityCache[outputTypeName] is GenericEntity)
					{
						outputEntity = EntityPropertyFieldInfoCache.GenericEntityCache[outputTypeName] as GenericEntity;
					}
					else
					{
						outputEntity = EntityPropertyFieldInfoCache.AddNewEntityWithPropertyFieldInfo(outputObject);
					}

					// go through transform elements and perform transform where applicable/allowed
					foreach (GenericProperty loopOutputProperty in outputEntity.PropertyList)
					{
						if (filterElements == null || filterElements[loopOutputProperty.PropertyName].GetString() == String.Empty)
						{
							bool transformPerformed = false;
							foreach (GenericProperty loopInputProperty in inputEntity.PropertyList)
							{
								if (loopOutputProperty.PropertyName == loopInputProperty.PropertyName)
								{
									switch (loopInputProperty.PropertyTypeCode)
									{
										case (int)DataTransformPropertyType.ElementProperty:
											switch (loopOutputProperty.PropertyTypeCode)
											{
												case (int)DataTransformPropertyType.ElementProperty:
													// transform property to property
													inputPropertyInfo = loopInputProperty.GenericValue as PropertyInfo;
													outputPropertyInfo = loopOutputProperty.GenericValue as PropertyInfo;
													inputValue = DataHelper.GetValueFromSystemType(inputObject.GetPropertyValueString(inputPropertyInfo.Name), outputPropertyInfo.PropertyType.UnderlyingSystemType.FullName, getNonDefaultValuesOnly);
													if (inputValue != null || getNonDefaultValuesOnly == false)
													{
														outputPropertyInfo.SetValue(outputObject, inputValue, null);
													}
													transformPerformed = true;
													break;
												case (int)DataTransformPropertyType.ElementField:
													// transform property to field
													inputPropertyInfo = loopInputProperty.GenericValue as PropertyInfo;
													outputFieldInfo = loopOutputProperty.GenericValue as FieldInfo;
													inputValue = DataHelper.GetValueFromSystemType(inputObject.GetPropertyValueString(inputPropertyInfo.Name), outputFieldInfo.FieldType.UnderlyingSystemType.FullName, getNonDefaultValuesOnly);
													if (inputValue != null || getNonDefaultValuesOnly == false)
													{
														outputFieldInfo.SetValue(outputObject, inputValue);
													}
													transformPerformed = true;
													break;
												default:
													break;
											}
											break;
										case (int)DataTransformPropertyType.ElementField:
											switch (loopOutputProperty.PropertyTypeCode)
											{
												case (int)DataTransformPropertyType.ElementProperty:
													// transform field to property
													inputFieldInfo = loopInputProperty.GenericValue as FieldInfo;
													outputPropertyInfo = loopOutputProperty.GenericValue as PropertyInfo;
													inputValue = DataHelper.GetValueFromSystemType(inputObject.GetFieldValueString(inputFieldInfo.Name), outputPropertyInfo.PropertyType.UnderlyingSystemType.FullName, getNonDefaultValuesOnly);
													if (inputValue != null || getNonDefaultValuesOnly == false)
													{
														outputPropertyInfo.SetValue(outputObject, inputValue, null);
													}
													transformPerformed = true;
													break;
												case (int)DataTransformPropertyType.ElementField:
													// transform field to field
													inputFieldInfo = loopInputProperty.GenericValue as FieldInfo;
													outputFieldInfo = loopOutputProperty.GenericValue as FieldInfo;
													inputValue = DataHelper.GetValueFromSystemType(inputObject.GetFieldValueString(inputFieldInfo.Name), outputFieldInfo.FieldType.UnderlyingSystemType.FullName, getNonDefaultValuesOnly);
													if (inputValue != null || getNonDefaultValuesOnly == false)
													{
														outputFieldInfo.SetValue(outputObject, inputValue);
													}
													transformPerformed = true;
													break;
												default:
													break;
											}
											break;
										case (int)DataTransformPropertyType.ArrayItemProperty:
											if (includeCollections == true)
											{
												inputType = null;
												inputPropertyInfo = loopInputProperty.GenericValue as PropertyInfo;
												inputArrayValue = inputPropertyInfo.GetValue(inputObject, null);
												if (inputArrayValue != null)
												{
													if (inputPropertyInfo.PropertyType.IsGenericType && inputPropertyInfo.PropertyType.GetProperty("Item") != null)
													{
														inputType = inputPropertyInfo.PropertyType.GetProperty("Item").PropertyType;
													}
													if (inputType != null)
													{
														switch (loopOutputProperty.PropertyTypeCode)
														{
															case (int)DataTransformPropertyType.ArrayItemProperty:
																// create array item and transfer property to property
																outputPropertyInfo = loopOutputProperty.GenericValue as PropertyInfo;
																outputPropertyInfo.SetValue(outputObject, Activator.CreateInstance(outputPropertyInfo.PropertyType, inputType, inputArrayValue, filterElements), null);
																transformPerformed = true;
																break;
															case (int)DataTransformPropertyType.ArrayItemField:
																// create array item and transfer property to field
																outputFieldInfo = loopOutputProperty.GenericValue as FieldInfo;
																outputFieldInfo.SetValue(outputObject, Activator.CreateInstance(outputFieldInfo.FieldType, inputType, inputArrayValue, filterElements));
																transformPerformed = true;
																break;
															default:
																break;
														}
													}
												}
											}
											else
											{
												transformPerformed = true;
											}
											break;
										case (int)DataTransformPropertyType.ArrayItemField:
											if (includeCollections == true)
											{
												inputType = null;
												inputFieldInfo = loopInputProperty.GenericValue as FieldInfo;
												inputArrayValue = inputFieldInfo.GetValue(inputObject);
												if (inputArrayValue != null)
												{
													if (inputFieldInfo.FieldType.IsGenericType && inputFieldInfo.FieldType.GetProperty("Item") != null)
													{
														inputType = inputFieldInfo.FieldType.GetProperty("Item").PropertyType;
													}
													if (inputType != null)
													{
														switch (loopOutputProperty.PropertyTypeCode)
														{
															case (int)DataTransformPropertyType.ArrayItemProperty:
																// create array item and transfer field to property
																outputPropertyInfo = loopOutputProperty.GenericValue as PropertyInfo;
																outputPropertyInfo.SetValue(outputObject, Activator.CreateInstance(outputPropertyInfo.PropertyType, inputType, inputArrayValue, filterElements), null);
																transformPerformed = true;
																break;
															case (int)DataTransformPropertyType.ArrayItemField:
																// create array item and transfer field to field
																outputFieldInfo = loopOutputProperty.GenericValue as FieldInfo;
																outputFieldInfo.SetValue(outputObject, Activator.CreateInstance(outputFieldInfo.FieldType, inputType, inputArrayValue, filterElements));
																transformPerformed = true;
																break;
															default:
																break;
														}
													}
												}
											}
											else
											{
												transformPerformed = true;
											}
											break;
										default:
											break;
									}
								}
								if (transformPerformed == true)
								{
									break;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			finally
			{
				inputEntity = null;
				outputEntity = null;
				inputPropertyInfo = null;
				outputPropertyInfo = null;
				inputFieldInfo = null;
				outputFieldInfo = null;
			}
		}

		#endregion "Methods"
	}
}
