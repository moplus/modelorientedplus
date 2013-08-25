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
using MoPlus.Interpreter.Resources;
using MoPlus.Interpreter.BLL.Solutions;
using System.IO;
using MoPlus.IO;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of parameters.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ParameterNode : NonLeafGrammarNode, IPropertyNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_Parameter;
			}
		}

		public ModelPropertyNode ModelProperty { get; set; }
		public LiteralNode Literal { get; set; }
		public ParameterNode Parameter1 { get; set; }
		public ParameterNode Parameter2 { get; set; }
		public MathOperatorNode MathOperator { get; set; }

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
					if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is LiteralNode)
					{
						Literal = node.AstNode as LiteralNode;
						ChildNodes.Add(node.AstNode as LiteralNode);
					}
					else if (node.AstNode is MathOperatorNode)
					{
						MathOperator = node.AstNode as MathOperatorNode;
						ChildNodes.Add(node.AstNode as MathOperatorNode);
					}
					else if (node.AstNode is ParameterNode)
					{
						if (Parameter1 == null)
						{
							Parameter1 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
						else if (Parameter2 == null)
						{
							Parameter2 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
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
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public void InterpretNode(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			try
			{
				StringBuilder output = null;
				if (interpreterType == InterpreterTypeCode.Output)
				{
					output = templateContext.OutputCodeBuilder;
				}
				else
				{
					output = templateContext.ContentCodeBuilder;
				}
				string propertyValue = GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				if (!String.IsNullOrEmpty(propertyValue))
				{
					output.Append(propertyValue);
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Get the string value for this parameter.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public string GetStringValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, InterpreterTypeCode interpreterType)
		{
			if (ModelProperty != null)
			{
				return ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
			}
			else if (Literal != null)
			{
				return Literal.GetStringValue(solutionContext, templateContext, modelContext);
			}
			else if (Parameter1 != null && Parameter2 != null)
			{
				string parameter1Value = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				string parameter2Value = Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				long parameter1Long;
				long parameter2Long;
				double parameter1Double;
				double parameter2Double;
				switch (MathOperator.Operator)
				{
					case "+":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true)
						{
							return (parameter1Long + parameter2Long).ToString();
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true)
						{
							return (parameter1Double + parameter2Double).ToString();
						}
						else
						{
							return parameter1Value + parameter2Value;
						}
					case "-":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true)
						{
							return (parameter1Long - parameter2Long).ToString();
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true)
						{
							return (parameter1Double - parameter2Double).ToString();
						}
						else
						{
							return parameter1Value.Replace(parameter2Value, "");
						}
					case "*":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true)
						{
							return (parameter1Long * parameter2Long).ToString();
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true)
						{
							return (parameter1Double * parameter2Double).ToString();
						}
						break;
					case "/":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true && parameter2Long != 0)
						{
							return (parameter1Long / parameter2Long).ToString();
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true && parameter2Double != 0.00)
						{
							return (parameter1Double / parameter2Double).ToString();
						}
						break;
					default:
						break;
				}
			}
			return String.Empty;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Get the string value for this parameter.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public object GetObjectValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, InterpreterTypeCode interpreterType)
		{
			if (ModelProperty != null)
			{
				return ModelProperty.GetPropertyObjectValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
			}
			else if (Literal != null)
			{
				return Literal.GetObjectValue(solutionContext, templateContext, modelContext);
			}
			else if (Parameter1 != null && Parameter2 != null)
			{
				string parameter1Value = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				string parameter2Value = Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				long parameter1Long;
				long parameter2Long;
				double parameter1Double;
				double parameter2Double;
				switch (MathOperator.Operator)
				{
					case "+":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true)
						{
							return parameter1Long + parameter2Long;
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true)
						{
							return parameter1Double + parameter2Double;
						}
						else
						{
							return parameter1Value + parameter2Value;
						}
					case "-":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true)
						{
							return parameter1Long - parameter2Long;
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true)
						{
							return parameter1Double - parameter2Double;
						}
						else
						{
							return parameter1Value.Replace(parameter2Value, "");
						}
					case "*":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true)
						{
							return parameter1Long * parameter2Long;
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true)
						{
							return parameter1Double * parameter2Double;
						}
						break;
					case "/":
						if (long.TryParse(parameter1Value, out parameter1Long) == true && long.TryParse(parameter2Value, out parameter2Long) == true  && parameter2Long != 0)
						{
							return parameter1Long / parameter2Long;
						}
						else if (double.TryParse(parameter1Value, out parameter1Double) == true && double.TryParse(parameter2Value, out parameter2Double) == true && parameter2Double != 0.00)
						{
							return parameter1Double / parameter2Double;
						}
						break;
					default:
						break;
				}
			}
			return null;
		}
	}
}
