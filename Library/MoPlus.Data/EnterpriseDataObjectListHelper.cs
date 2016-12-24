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
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used for operations on strongly typed sortable lists of
	/// enterprise objects, in particular for operations that involve 2 different types.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	public static class EnterpriseDataObjectListHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method takes in an enterprise data object list of an input type
		/// and transforms it to a list of the output type.</summary>
		/// 
		///	<param name="inputEnterpriseDataObjectList">The input list to transform to this list.</param>
		///	<param name="filterElements">Field and property values to exclude from transform.</param>
		/// 
		/// <returns>An enterprise data object list of type TOutput.</returns>
		///--------------------------------------------------------------------------------
		public static EnterpriseDataObjectList<TOutput> CreateList<TInput, TOutput>(EnterpriseDataObjectList<TInput> inputEnterpriseDataObjectList, NameObjectCollection filterElements)
			where TInput : IEnterpriseDataObject, new()
			where TOutput : IEnterpriseDataObject, new()
		{
			if (inputEnterpriseDataObjectList != null)
			{
				EnterpriseDataObjectList<TOutput> outputEnterpriseDataObjectList = new EnterpriseDataObjectList<TOutput>();
				foreach (TInput loopItem in inputEnterpriseDataObjectList)
				{
					TOutput newItem = new TOutput();
					newItem.TransformDataFromObject(loopItem, filterElements);
					outputEnterpriseDataObjectList.Add(newItem);
				}
				return outputEnterpriseDataObjectList;
			}
			return null;
		}

		#endregion "Methods"
	}
}
