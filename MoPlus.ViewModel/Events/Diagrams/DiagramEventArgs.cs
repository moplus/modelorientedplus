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
using System.Windows;
using MoPlus.ViewModel.Events;
using MoPlus.Data;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Entities;

namespace MoPlus.ViewModel.Events.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Diagram class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/19/2013</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class DiagramEventArgs : SolutionModelEventArgs
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Path.</summary>
		///--------------------------------------------------------------------------------
		public string Path { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityViewModel> Entities { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramEntityToAdd lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramEntityViewModel> DiagramEntitiesToAdd { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramEntityToDelete lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramEntityViewModel> DiagramEntitiesToDelete { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramRelationshipToAdd lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramRelationshipViewModel> DiagramRelationshipsToAdd { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramRelationshipToDelete lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramRelationshipViewModel> DiagramRelationshipsToDelete { get; set; }

		#endregion "Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		#endregion "Constructors"
	}
}
