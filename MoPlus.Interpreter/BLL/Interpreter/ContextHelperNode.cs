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
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.Resources;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of context helpers.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ContextHelperNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + MethodName;
			}
		}

		public string MethodName { get; set; }
		public ModelContextNode ModelContext { get; set; }
		public CurrentItemNode CurrentItem { get; set; }
		public SpecCurrentItemNode SpecCurrentItem { get; set; }
		public ModelPropertyNode ModelProperty { get; set; }
		public ParameterNode Parameter { get; set; }

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
					else if (node.AstNode is CurrentItemNode)
					{
						CurrentItem = node.AstNode as CurrentItemNode;
						ChildNodes.Add(node.AstNode as CurrentItemNode);
					}
					else if (node.AstNode is SpecCurrentItemNode)
					{
						SpecCurrentItem = node.AstNode as SpecCurrentItemNode;
						ChildNodes.Add(node.AstNode as SpecCurrentItemNode);
					}
					else if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is ParameterNode)
					{
						Parameter = node.AstNode as ParameterNode;
						ChildNodes.Add(node.AstNode as ParameterNode);
					}
					else
					{
						MethodName = node.FindTokenAndGetText();
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				ThrowASTException(ex, true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the model context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="helperModelContext">The associated helper model context node.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, ModelContextNode helperModelContext, InterpreterTypeCode interpreterType)
		{
			IDomainEnterpriseObject parentContext = modelContext;
			if (ModelContext != null)
			{
				bool isValidContext;
				parentContext = ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
			}
			else if (CurrentItem != null)
			{
				parentContext = CurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
			}
			if (MethodName == LanguageTerms.FindMethod)
			{
				IEnterpriseEnumerable collection = helperModelContext.GetCollection(solutionContext, templateContext, parentContext);
				if (collection != null)
				{
					if (ModelProperty != null)
					{
						return collection.FindItem(ModelProperty.ModelPropertyName, Parameter.GetObjectValue(solutionContext, templateContext, modelContext, interpreterType)) as IDomainEnterpriseObject;
					}
					else
					{
						string parameterValue = Parameter.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
						Guid parameterID = Guid.Empty;
						if (Guid.TryParse(parameterValue, out parameterID))
						{
							return collection.FindItemByID(parameterID) as IDomainEnterpriseObject;
						}
						else
						{
							LogException(solutionContext, templateContext, modelContext, DisplayValues.Message_InterpreterBadFindParameter, interpreterType);
						}
					}
				}
				return null;
			}
			return modelContext;
		}
	}
}
