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
using Irony.Parsing;
using Irony.Interpreter.Ast;
using MoPlus.Data;
using System.Collections;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of spec current item nodes.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/26/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class SpecCurrentItemNode : LeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the model context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlColumn))
			{
				modelContext = solutionContext.CurrentSqlColumn;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlDatabase))
			{
				modelContext = solutionContext.CurrentSqlDatabase;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlExtendedProperty))
			{
				modelContext = solutionContext.CurrentSqlExtendedProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKey))
			{
				modelContext = solutionContext.CurrentSqlForeignKey;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKeyColumn))
			{
				modelContext = solutionContext.CurrentSqlForeignKeyColumn;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndex))
			{
				modelContext = solutionContext.CurrentSqlIndex;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndexedColumn))
			{
				modelContext = solutionContext.CurrentSqlIndexedColumn;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlProperty))
			{
				modelContext = solutionContext.CurrentSqlProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlTable))
			{
				modelContext = solutionContext.CurrentSqlTable;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlView))
			{
				modelContext = solutionContext.CurrentSqlView;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlViewProperty))
			{
				modelContext = solutionContext.CurrentSqlViewProperty;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlAttribute))
			{
				modelContext = solutionContext.CurrentXmlAttribute;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlDocument))
			{
				modelContext = solutionContext.CurrentXmlDocument;
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlNode))
			{
				modelContext = solutionContext.CurrentXmlNode;
			}
			#region protected
			#endregion protected
			return modelContext;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public IEnterpriseEnumerable GetCollection(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlColumn))
			{
				return SqlColumn.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlDatabase))
			{
				return SqlDatabase.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlExtendedProperty))
			{
				return SqlExtendedProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKey))
			{
				return SqlForeignKey.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlForeignKeyColumn))
			{
				return SqlForeignKeyColumn.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndex))
			{
				return SqlIndex.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlIndexedColumn))
			{
				return SqlIndexedColumn.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlProperty))
			{
				return SqlProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlTable))
			{
				return SqlTable.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlView))
			{
				return SqlView.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentSqlViewProperty))
			{
				return SqlViewProperty.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlAttribute))
			{
				return XmlAttribute.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlDocument))
			{
				return XmlDocument.GetCollectionContext(solutionContext, nodeContext);
			}
			else if (CurrentItemName == Enum.GetName(typeof(SpecCurrentItemTypeCode), SpecCurrentItemTypeCode.CurrentXmlNode))
			{
				return XmlNode.GetCollectionContext(solutionContext, nodeContext);
			}
			#region protected
			#endregion protected
			return null;
		}
	}
}
