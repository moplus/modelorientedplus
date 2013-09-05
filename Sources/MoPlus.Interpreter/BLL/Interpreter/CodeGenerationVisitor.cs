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
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.Resources;
using System.Data;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.IO;
using MoPlus.Interpreter.BLL.Diagrams;
using Irony.Parsing;
using MoPlus.IO;
using System.Text;
using MoPlus.Interpreter.BLL.Solutions;
using Irony.Interpreter.Ast;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This file is for implementing a code generation visitor.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>10/6/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class CodeGenerationVisitor : IGrammarNodeVisitor
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the TemplateContext.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Solution SolutionContext { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the TemplateContext.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public ITemplate TemplateContext { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ModelContext.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public IDomainEnterpriseObject ModelContext { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method executes code generation actions at the beginning of a node
		/// visit.</summary>
		/// 
		/// <param name="node">The node being visited.</param>
		///--------------------------------------------------------------------------------
		public void BeginVisit(IGrammarNode node)
		{
			//node.GenerateCode(SolutionContext, TemplateContext, ModelContext);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes code generation actions at the end of a node
		/// visit.</summary>
		/// 
		/// <param name="node">The node being visited.</param>
		///-------------------------------------------------------------------------------
		public void EndVisit(IGrammarNode node)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor sets the solution, template and model context.</summary>
		///--------------------------------------------------------------------------------
		public CodeGenerationVisitor(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			SolutionContext = solutionContext;
			TemplateContext = templateContext;
			ModelContext = modelContext;
		}
		#endregion "Methods"
	}
}