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
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Data;
using System.Collections;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.Interpreter.Resources;
using MoPlus.Interpreter.BLL.Models;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of model context nodes.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class ModelContextNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + ModelContextName;
			}
		}

		public string ModelContextName { get; set; }
		public ModelContextNode ModelContext { get; set; }
		public PopContextNode PopContext { get; set; }
		public ThisContextNode ThisContext { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method sets up the AST node and its children in the AST.</summary>
		/// 
		/// <param name="context">The parsing context.</param>
		/// <param name="treeNode">The corresponding node in the parse tree.</param>
		///--------------------------------------------------------------------------------
		public override void Init(ParsingContext context, ParseTreeNode treeNode)
		{
			try
			{
				base.Init(context, treeNode);
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is ModelContextNode)
					{
						ModelContext = node.AstNode as ModelContextNode;
						ChildNodes.Add(node.AstNode as ModelContextNode);
					}
					else if (node.AstNode is PopContextNode)
					{
						PopContext = node.AstNode as PopContextNode;
						ChildNodes.Add(node.AstNode as PopContextNode);
					}
					else if (node.AstNode is ThisContextNode)
					{
						ThisContext = node.AstNode as ThisContextNode;
						ChildNodes.Add(node.AstNode as ThisContextNode);
					}
					else
					{
						ModelContextName = node.FindTokenAndGetText();
					}
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				ThrowASTException(ex, true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public string GetPropertyStringValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			bool isValidContext;
			IDomainEnterpriseObject nodeContext = GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
			if (nodeContext != null)
			{
				return nodeContext.ID.ToString();
			}
			return "null";
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public object GetPropertyObjectValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			bool isValidContext;
			IDomainEnterpriseObject nodeContext = GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
			if (nodeContext != null)
			{
				return nodeContext.ID;
			}
			return null;
		}
	}
}
