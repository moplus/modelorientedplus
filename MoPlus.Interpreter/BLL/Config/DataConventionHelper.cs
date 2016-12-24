/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using MoPlus.Common;
using MoPlus.Data;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using MoPlus.Interpreter.BLL.Solutions;
using System.Collections.Generic;
using System.Linq;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.Resources;

namespace MoPlus.Interpreter.BLL.Config
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is for getting data convention information.  These conventions may
	/// eventually be stored in a database and be customizable.</summary>
	///--------------------------------------------------------------------------------
	public static class DataConventionHelper
	{
		#region "Fields and Properties"

		private static EnterpriseDataObjectList<IdentifierType> _identifierTypes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of identifier types from the convention spec.</summary>
		///--------------------------------------------------------------------------------
		public static EnterpriseDataObjectList<IdentifierType> IdentifierTypes
		{
			get
			{
				if (_identifierTypes == null)
				{
					_identifierTypes = new EnterpriseDataObjectList<IdentifierType>();
					_identifierTypes.LoadFromText(ModelValues.IdentifierTypes);
					_identifierTypes.Sort(i => i.IdentifierTypeName, SortDirection.Ascending);
					IdentifierType blankItem = new IdentifierType(0);
					blankItem.IdentifierTypeName = "-- None --";
					_identifierTypes.Insert(0, blankItem);
				}
				return _identifierTypes;
			}
		}

		private static EnterpriseDataObjectList<EntityType> _entityTypes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of entity types from the convention spec.</summary>
		///--------------------------------------------------------------------------------
		public static EnterpriseDataObjectList<EntityType> EntityTypes
		{
			get
			{
				if (_entityTypes == null)
				{
					_entityTypes = new EnterpriseDataObjectList<EntityType>();
					_entityTypes.LoadFromText(ModelValues.EntityTypes);
					_entityTypes.Sort(e => e.EntityTypeName, SortDirection.Ascending);
					EntityType blankItem = new EntityType(0);
					blankItem.EntityTypeName = "-- None --";
					_entityTypes.Insert(0, blankItem);
				}
				return _entityTypes;
			}
		}

		private static EnterpriseDataObjectList<MethodType> _methodTypes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of method types from the convention spec.</summary>
		///--------------------------------------------------------------------------------
		public static EnterpriseDataObjectList<MethodType> MethodTypes
		{
			get
			{
				if (_methodTypes == null)
				{
					_methodTypes = new EnterpriseDataObjectList<MethodType>();
					_methodTypes.LoadFromText(ModelValues.MethodTypes);
					_methodTypes.Sort(m => m.MethodTypeName, SortDirection.Ascending);
					MethodType blankItem = new MethodType(0);
					blankItem.MethodTypeName = "-- None --";
					_methodTypes.Insert(0, blankItem);
				}
				return _methodTypes;
			}
		}

		private static EnterpriseDataObjectList<DataType> _dataTypes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of data types from the convention spec.</summary>
		///--------------------------------------------------------------------------------
		public static EnterpriseDataObjectList<DataType> DataTypes
		{
			get
			{
				if (_dataTypes == null)
				{
					_dataTypes = new EnterpriseDataObjectList<DataType>();
					_dataTypes.LoadFromText(ModelValues.DataTypes);
					_dataTypes.Sort(d => d.DataTypeName, SortDirection.Ascending);
					DataType blankItem = new DataType(0);
					blankItem.DataTypeName = "-- None --";
					_dataTypes.Insert(0, blankItem);
				}
				return _dataTypes;
			}
		}

		private static EnterpriseDataObjectList<DatabaseType> _databaseTypes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of database types from the convention spec.</summary>
		///--------------------------------------------------------------------------------
		public static EnterpriseDataObjectList<DatabaseType> DatabaseTypes
		{
			get
			{
				if (_databaseTypes == null)
				{
					_databaseTypes = new EnterpriseDataObjectList<DatabaseType>();
					foreach (DatabaseTypeCode node in Enum.GetValues(typeof(DatabaseTypeCode)))
					{
						DatabaseType type = new DatabaseType();
						type.DatabaseTypeCode = (int)node;
						type.DatabaseTypeName = Enum.GetName(typeof(DatabaseTypeCode), node);
						_databaseTypes.Add(type);
					}
					_databaseTypes.Sort(d => d.DatabaseTypeName, SortDirection.Ascending);
				}
				return _databaseTypes;
			}
		}

		private static SortableObservableCollection<string> _codeTemplateNodes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of code template nodes.</summary>
		///--------------------------------------------------------------------------------
		public static SortableObservableCollection<string> CodeTemplateNodes
		{
			get
			{
				if (_codeTemplateNodes == null)
				{
					_codeTemplateNodes = new SortableObservableCollection<string>();
					foreach (ModelContextTypeCode node in Enum.GetValues(typeof(ModelContextTypeCode)))
					{
						if ((int)node > 0 && (int)node < 100)
						{
							_codeTemplateNodes.Add(Enum.GetName(typeof(ModelContextTypeCode), node));
						}
					}
					_codeTemplateNodes.Sort(t => t, ListSortDirection.Ascending);
				}
				return _codeTemplateNodes;
			}
		}

		private static SortableObservableCollection<string> _specTemplateNodes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the list of code template nodes.</summary>
		///--------------------------------------------------------------------------------
		public static SortableObservableCollection<string> SpecTemplateNodes
		{
			get
			{
				if (_specTemplateNodes == null)
				{
					_specTemplateNodes = new SortableObservableCollection<string>();
					foreach (ModelContextTypeCode node in Enum.GetValues(typeof(ModelContextTypeCode)))
					{
						if ((int)node > 0 && node != ModelContextTypeCode.Solution && node != ModelContextTypeCode.Project)
						{
							_specTemplateNodes.Add(Enum.GetName(typeof(ModelContextTypeCode), node));
						}
					}
					foreach (SpecModelContextTypeCode node in Enum.GetValues(typeof(SpecModelContextTypeCode)))
					{
						if ((int)node > 0)
						{
							_specTemplateNodes.Add(Enum.GetName(typeof(SpecModelContextTypeCode), node));
						}
					}
					_specTemplateNodes.Sort(t => t, ListSortDirection.Ascending);
				}
				return _specTemplateNodes;
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"
	}
}