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
using System.Windows.Input;
using System.ComponentModel;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Models;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Models;

namespace MoPlus.ViewModel.Models
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the ModelPropertyViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/18/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelPropertyViewModel : DialogEditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		private EnterpriseDataObjectList<ModelObject> _definedByModelObjectIDItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByModelObjectIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<ModelObject> DefinedByModelObjectIDItems
		{
			get
			{
				if (_definedByModelObjectIDItems == null)
				{
					if (ModelProperty.ModelObject == null)
					{
						ModelProperty.ModelObject = Solution.ModelObjectList.Find(o => o.ModelObjectID == ModelProperty.ModelObjectID);
					}
					_definedByModelObjectIDItems = new EnterpriseDataObjectList<ModelObject>((from v in Solution.ModelObjectList
																							  where v.ModelID == ModelProperty.ModelObject.ModelID
																							  select v).ToList<ModelObject>(), false);
					_definedByModelObjectIDItems.Insert(0, new ModelObject());
				}
				return _definedByModelObjectIDItems;
			}
			set
			{
				_definedByModelObjectIDItems = value;
			}
		}

		private EnterpriseDataObjectList<Enumeration> _definedByEnumerationIDItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByEnumerationIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Enumeration> DefinedByEnumerationIDItems
		{
			get
			{
				if (_definedByEnumerationIDItems == null)
				{
					_definedByEnumerationIDItems = new EnterpriseDataObjectList<Enumeration>((from v in Solution.EnumerationList
																							  where v.ModelID == ModelProperty.ModelObject.ModelID
																							  select v).ToList<Enumeration>(), false);
					_definedByEnumerationIDItems.Insert(0, new Enumeration());
				}
				return _definedByEnumerationIDItems;
			}
			set
			{
				_definedByEnumerationIDItems = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByValueIDItems.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<Value> DefinedByValueIDItems { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the set of Properties.</summary>
		///--------------------------------------------------------------------------------
		public void RefreshValues()
		{
			if (Solution != null)
			{
				DefinedByValueIDItems = new EnterpriseDataObjectList<Value>((from v in Solution.ValueList
																					where v.EnumerationID == DefinedByEnumerationID
																					select v).ToList<Value>(), false);
				DefinedByValueIDItems.Insert(0, new Value());
				OnPropertyChanged("DefinedByValueIDItems");
				OnPropertyChanged("DefinedByValueID");
			}
		}

		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
