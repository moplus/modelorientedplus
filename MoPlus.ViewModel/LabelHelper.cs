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
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using System.Collections.ObjectModel;
using MoPlus.Data;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Resources;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides labels.</summary>
	/// 
	/// <remarks>This class isn't static to enable binding as a static resource in XAML.</remarks>
	///--------------------------------------------------------------------------------
	public class LabelHelper
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DebugHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DebugHeader
		{
			get
			{
				return DisplayValues.Edit_DebugHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DebugExpressionHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DebugExpressionHeader
		{
			get
			{
				return DisplayValues.Edit_DebugExpressionHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DebugValueHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DebugValueHeader
		{
			get
			{
				return DisplayValues.Edit_DebugValueHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ZoomBoxHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ZoomBoxHeader
		{
			get
			{
				return DisplayValues.NodeName_ZoomBox;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string EntityNameHeader
		{
			get
			{
				return DisplayValues.NodeName_Entities;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramToolBoxHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DiagramToolBoxHeader
		{
			get
			{
				return DisplayValues.NodeName_Diagram;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertiesToolBoxHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertiesToolBoxHeader
		{
			get
			{
				return DisplayValues.NodeName_Properties;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertyNameHeader
		{
			get
			{
				return DisplayValues.Edit_PropertyNameProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CollectionNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string CollectionNameHeader
		{
			get
			{
				return DisplayValues.Edit_CollectionNameProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityReferenceNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string EntityReferenceNameHeader
		{
			get
			{
				return DisplayValues.Edit_EntityReferenceHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyReferenceNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertyReferenceNameHeader
		{
			get
			{
				return DisplayValues.Edit_PropertyReferenceHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DescriptionHeader
		{
			get
			{
				return DisplayValues.Edit_DescriptionProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets OrderHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string OrderHeader
		{
			get
			{
				return DisplayValues.Edit_OrderHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertiesHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertiesHeader
		{
			get
			{
				return DisplayValues.Edit_PropertiesHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertyHeader
		{
			get
			{
				return DisplayValues.Edit_PropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedPropertyHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ReferencedPropertyHeader
		{
			get
			{
				return DisplayValues.Edit_ReferencedPropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ReferencedEntityHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ReferencedEntityHeader
		{
			get
			{
				return DisplayValues.Edit_ReferencedEntityProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParametersHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ParametersHeader
		{
			get
			{
				return DisplayValues.Edit_ParametersHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ParameterNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ParameterNameHeader
		{
			get
			{
				return DisplayValues.Edit_ParameterNameProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string MethodNameHeader
		{
			get
			{
				return DisplayValues.Edit_MethodNameProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string IndexNameHeader
		{
			get
			{
				return DisplayValues.Edit_IndexNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IndexPropertyNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string IndexPropertyNameHeader
		{
			get
			{
				return DisplayValues.Edit_IndexPropertyNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MethodRelationshipsHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string MethodRelationshipsHeader
		{
			get
			{
				return DisplayValues.Edit_MethodRelationshipsHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyRelationshipsHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertyRelationshipsHeader
		{
			get
			{
				return DisplayValues.Edit_PropertyRelationshipsHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string RelationshipHeader
		{
			get
			{
				return DisplayValues.Edit_RelationshipHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string RelationshipNameHeader
		{
			get
			{
				return DisplayValues.Edit_RelationshipPropertyHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets RelationshipPropertyNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string RelationshipPropertyNameHeader
		{
			get
			{
				return DisplayValues.Edit_RelationshipPropertyNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValuesHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ValuesHeader
		{
			get
			{
				return DisplayValues.Edit_ValuesHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ValueNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ValueNameHeader
		{
			get
			{
				return DisplayValues.Edit_ValueNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EnumValueHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string EnumValueHeader
		{
			get
			{
				return DisplayValues.Edit_EnumValueHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertiesHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ModelPropertiesHeader
		{
			get
			{
				return DisplayValues.Edit_ModelPropertiesHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyInstancesHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertyInstancesHeader
		{
			get
			{
				return DisplayValues.Edit_PropertyInstancesHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ModelPropertyNameHeader
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ModelPropertyIDHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string ModelPropertyIDHeader
		{
			get
			{
				return DisplayValues.Edit_ModelPropertyIDHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PropertyValueHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string PropertyValueHeader
		{
			get
			{
				return DisplayValues.Edit_PropertyValueHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByModelObjectHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DefinedByModelObjectHeader
		{
			get
			{
				return DisplayValues.Edit_DefinedByModelObjectHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByValueHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DefinedByValueHeader
		{
			get
			{
				return DisplayValues.Edit_DefinedByValueHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DefinedByEnumerationHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string DefinedByEnumerationHeader
		{
			get
			{
				return DisplayValues.Edit_DefinedByEnumerationHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TransitionsHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string TransitionsHeader
		{
			get
			{
				return DisplayValues.Edit_TransitionsHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StepTransitionNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string StepTransitionNameHeader
		{
			get
			{
				return DisplayValues.Edit_StepTransitionNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStepHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string FromStepHeader
		{
			get
			{
				return DisplayValues.Edit_FromStepHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StageTransitionNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string StageTransitionNameHeader
		{
			get
			{
				return DisplayValues.Edit_StageTransitionNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStageHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string FromStageHeader
		{
			get
			{
				return DisplayValues.Edit_FromStageHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets StateTransitionNameHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string StateTransitionNameHeader
		{
			get
			{
				return DisplayValues.Edit_StateTransitionNameHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets FromStateHeader.</summary>
		///--------------------------------------------------------------------------------
		public static string FromStateHeader
		{
			get
			{
				return DisplayValues.Edit_FromStateHeader;
			}
		}

		#endregion "Properties"
	}
}
