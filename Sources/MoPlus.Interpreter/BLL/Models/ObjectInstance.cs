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

namespace MoPlus.Interpreter.BLL.Models
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the ObjectInstance class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>3/7/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ObjectInstance : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override string Name
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(ShortName);
				if (String.IsNullOrEmpty(sb.ToString()))
				{
					sb.Append(ObjectInstanceID.ToString());
				}
				return sb.ToString();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the short name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string ShortName
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				if (ParentObjectInstance != null)
				{
					sb.Append(ParentObjectInstance.ShortName);
					if (!String.IsNullOrEmpty(sb.ToString()))
					{
						sb.Append(".");
					}
				}
				if (ModelObject != null && PropertyInstanceList != null)
				{
					bool isFirstItem = true;
					foreach (ModelProperty property in ModelObject.ModelPropertyList.FindAll(p => p.IsDisplayProperty == true))
					{
						foreach (PropertyInstance instance in PropertyInstanceList)
						{
							if (instance.ModelPropertyID == property.ModelPropertyID)
							{
								if (isFirstItem == false)
								{
									sb.Append(", ");
								}
								isFirstItem = false;
								sb.Append(instance.PropertyValue);
							}
						}
					}
				}
				return sb.ToString();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DisplayName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DisplayName
		{
			get
			{
				return Name;
			}
		}

		private ObjectInstance _parentObjectInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DisplayName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ObjectInstance ParentObjectInstance
		{
			get
			{
				if (_parentObjectInstance == null && ParentObjectInstanceID != null)
				{
					_parentObjectInstance = Solution.ObjectInstanceList.Find(i => i.ObjectInstanceID == ParentObjectInstanceID);
				}
				return _parentObjectInstance;
			}
		}
		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the property value for the input property name.</summary>
		/// 
		/// <param name="propertyName">The name of the property to get the value of.</param>
		/// <param name="propertyFound">Output flag, indicating whether property was found or not.</param>
		///--------------------------------------------------------------------------------
		public string GetStringValue(string propertyName, out bool propertyFound)
		{
			StringBuilder value = new StringBuilder();
			propertyFound = false;
			ModelProperty property = ModelObject.ModelPropertyList.Find(p => p.ModelPropertyName == propertyName);
			if (property != null && PropertyInstanceList.Count > 0)
			{
				propertyFound = true;
				foreach (PropertyInstance instance in PropertyInstanceList.FindAll(i => i.ModelPropertyID == property.ModelPropertyID))
				{
					if (value.ToString() != String.Empty) // && property.IsCollection == true)
					{
						value.Append(", ").Append(instance.PropertyValue);
					}
					else
					{
						value.Append(instance.PropertyValue);
					}
				}
			}
			return value.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the current model context for the item.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="objectName">The name of the model object type.</param>
		/// <param name="parentModelContext">The parent model context from which to get current model context.</param>
		/// <param name="isValidContext">Output flag, signifying whether context returned is a valid one.</param>
		///--------------------------------------------------------------------------------
		public static IDomainEnterpriseObject GetModelContext(Solution solutionContext, string objectName, IDomainEnterpriseObject parentModelContext, out bool isValidContext)
		{
			isValidContext = true;
			IDomainEnterpriseObject modelContext = parentModelContext;
			while (modelContext != null)
			{
				if (modelContext is ObjectInstance && (modelContext as ObjectInstance).ModelObjectName == objectName)
				{
					return modelContext as ObjectInstance;
				}

				if (modelContext is Solution) break;
				if (modelContext is ObjectInstance)
				{
					modelContext = (modelContext as ObjectInstance).GetParentItem(objectName);
				}
				else
				{
					modelContext = modelContext.GetParentItem();
				}
			}
			if (solutionContext.IsSampleMode == true)
			{
				if (solutionContext.ObjectInstanceList.Count > 0)
				{
					return solutionContext.ObjectInstanceList[DataHelper.GetRandomInt(0, solutionContext.ObjectInstanceList.Count - 1)];
				}
			}

			isValidContext = false;
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this item.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="objectName">The name of the model object type.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public static IEnterpriseEnumerable GetCollectionContext(Solution solutionContext, string objectName, IDomainEnterpriseObject modelContext)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			while (nodeContext != null)
			{
				if (nodeContext is ObjectInstance)
				{
					ObjectInstance modelObjectContext = modelContext as ObjectInstance;
					if (solutionContext.ObjectInstanceList.Find(i => i.ModelObjectName == objectName && i.ParentObjectInstanceID == modelObjectContext.ObjectInstanceID) != null)
					{
						return new EnterpriseDataObjectList<ObjectInstance>(solutionContext.ObjectInstanceList.FindAll(i => i.ModelObjectName == objectName && i.ParentObjectInstanceID == modelObjectContext.ObjectInstanceID), false);
					}
				}
				if (nodeContext is ModelObject)
				{
					if ((nodeContext as ModelObject).ModelObjectName == objectName)
					{
						return (nodeContext as ModelObject).ObjectInstanceList;
					}
					else
					{
						return new EnterpriseDataObjectList<ObjectInstance>();
					}
				}
				if (nodeContext is Solution)
				{
					return new EnterpriseDataObjectList<ObjectInstance>(solutionContext.ObjectInstanceList.FindAll(i => i.ModelObjectName == objectName), false);
				}
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parent item of this item.</summary>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetParentItem(string objectName)
		{
			if (ParentObjectInstance != null)
			{
				return ParentObjectInstance;
			}

			return ModelObject;
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}