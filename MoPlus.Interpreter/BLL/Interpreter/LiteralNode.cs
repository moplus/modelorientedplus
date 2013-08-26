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
using MoPlus.Data;
using Irony.Parsing;
using Irony.Interpreter.Ast;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of literals.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class LiteralNode : LeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + RawValue;
			}
		}

		public string StringValue { get; set; }
		public bool IsTrueValue { get; set; }
		public bool IsFalseValue { get; set; }
		public bool IsNullValue { get; set; }
		public string RawValue { get; set; }

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
					if (node.AstNode is LiteralValueNode)
					{
						RawValue = node.FindToken().ValueString;
						StringValue = RawValue;
					}
					else
					{
						RawValue = node.FindTokenAndGetText();
						String value = node.FindToken().ValueString;
						if (value == "true")
						{
							IsTrueValue = true;
						}
						else if (value == "false")
						{
							IsFalseValue = true;
						}
						else if (value == "null")
						{
							IsNullValue = true;
						}
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
		/// <summary>Get the string value for this parameter.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public string GetStringValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			if (IsTrueValue == true)
			{
				return "true";
			}
			if (IsFalseValue == true)
			{
				return "false";
			}
			if (IsNullValue == true)
			{
				return "null";
			}
			return StringValue;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Get the string value for this parameter.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public object GetObjectValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			if (IsTrueValue == true)
			{
				return true;
			}
			if (IsFalseValue == true)
			{
				return false;
			}
			if (IsNullValue == true)
			{
				return null;
			}
			return StringValue;
		}
	}
}
