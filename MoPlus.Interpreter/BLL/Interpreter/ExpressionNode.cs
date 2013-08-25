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
using MoPlus.Data;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of expressions.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ExpressionNode : NonLeafGrammarNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_Expression;
			}
		}

		public LiteralNode Literal { get; set; }
		public ModelPropertyNode ModelProperty { get; set; }
		public ModelContextNode ModelContext { get; set; }
		public CurrentItemNode CurrentItem { get; set; }
		public SpecCurrentItemNode SpecCurrentItem { get; set; }
		public ExpressionNode Expression1 { get; set; }
		public ExpressionNode Expression2 { get; set; }
		public BinaryOperatorNode BinaryOperator { get; set; }
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
					if (node.AstNode is LiteralNode)
					{
						Literal = node.AstNode as LiteralNode;
						ChildNodes.Add(node.AstNode as LiteralNode);
					}
					else if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is ModelContextNode)
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
					else if (node.AstNode is ExpressionNode)
					{
						if (Expression1 == null)
						{
							Expression1 = node.AstNode as ExpressionNode;
						}
						else
						{
							Expression2 = node.AstNode as ExpressionNode;
						}
						ChildNodes.Add(node.AstNode as ExpressionNode);
					}
					else if (node.AstNode is BinaryOperatorNode)
					{
						BinaryOperator = node.AstNode as BinaryOperatorNode;
						ChildNodes.Add(node.AstNode as BinaryOperatorNode);
					}
					else if (node.AstNode is MathOperatorNode)
					{
						MathOperator = node.AstNode as MathOperatorNode;
						ChildNodes.Add(node.AstNode as MathOperatorNode);
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
		/// <summary>Evaluate expression associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public string GetExpressionValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, InterpreterTypeCode interpreterType)
		{
			string expression1Value = String.Empty;
			if (Expression1 != null)
			{
				expression1Value = Expression1.GetExpressionValue(solutionContext, templateContext, modelContext, interpreterType);
			}
			string expression2Value = String.Empty;
			if (Expression2 != null)
			{
				expression2Value = Expression2.GetExpressionValue(solutionContext, templateContext, modelContext, interpreterType);
			}
			if (String.IsNullOrEmpty(expression1Value))
			{
				expression1Value = "null";
			}
			if (String.IsNullOrEmpty(expression2Value))
			{
				expression2Value = "null";
			}
			long expression1Long;
			long expression2Long;
			double expression1Double;
			double expression2Double;
			if (Literal != null)
			{
				return Literal.RawValue;
			}
			if (ModelProperty != null)
			{
				return ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
			}
			if (ModelContext != null)
			{
				bool isValidContext;
				IDomainEnterpriseObject nodeContext = ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
				if (nodeContext == null)
				{
					return "null";
				}
				else
				{
					if (nodeContext.ID == Guid.Empty || nodeContext.ID == null)
					{
						return "null";
					}
					return nodeContext.ID.ToString();
				}
			}
			else if (CurrentItem != null)
			{
				IDomainEnterpriseObject nodeContext = CurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
				if (nodeContext == null)
				{
					return "null";
				}
				else
				{
					return nodeContext.ID.ToString();
				}
			}
			else if (SpecCurrentItem != null)
			{
				IDomainEnterpriseObject nodeContext = SpecCurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
				if (nodeContext == null)
				{
					return "null";
				}
				else
				{
					return nodeContext.ID.ToString();
				}
			}
			else if (Expression1 != null && Expression2 != null)
			{
				if (BinaryOperator != null)
				{
					switch (BinaryOperator.Operator)
					{
						case "||":
							if (Expression1.EvaluateExpression(solutionContext, templateContext, modelContext, interpreterType) || Expression2.EvaluateExpression(solutionContext, templateContext, modelContext, interpreterType))
							{
								return "true";
							}
							return "false";
						case "&&":
							if (Expression1.EvaluateExpression(solutionContext, templateContext, modelContext, interpreterType) && Expression2.EvaluateExpression(solutionContext, templateContext, modelContext, interpreterType))
							{
								return "true";
							}
							return "false";
						case "==":
							if (expression1Value == expression2Value)
							{
								return "true";
							}
							return "false";
						case "!=":
							if (expression1Value != expression2Value)
							{
								return "true";
							}
							return "false";
						case "<":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								if (expression1Long < expression2Long)
								{
									return "true";
								}
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								if (expression1Double < expression2Double)
								{
									return "true";
								}
							}
							else
							{
								if (expression1Value.Length < expression2Value.Length)
								{
									return "true";
								}
							}
							return "false";
						case ">":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								if (expression1Long > expression2Long)
								{
									return "true";
								}
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								if (expression1Double > expression2Double)
								{
									return "true";
								}
							}
							else
							{
								if (expression1Value.Length > expression2Value.Length)
								{
									return "true";
								}
							}
							return "false";
						case "<=":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								if (expression1Long <= expression2Long)
								{
									return "true";
								}
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								if (expression1Double <= expression2Double)
								{
									return "true";
								}
							}
							else
							{
								if (expression1Value.Length <= expression2Value.Length)
								{
									return "true";
								}
							}
							return "false";
						case ">=":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								if (expression1Long >= expression2Long)
								{
									return "true";
								}
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								if (expression1Double >= expression2Double)
								{
									return "true";
								}
							}
							else
							{
								if (expression1Value.Length >= expression2Value.Length)
								{
									return "true";
								}
							}
							return "false";
						default:
							return "false";
					}
				}
				else if (MathOperator != null)
				{
					switch (MathOperator.Operator)
					{
						case "+":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								return (expression1Long + expression2Long).ToString();
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								return (expression1Double + expression2Double).ToString();
							}
							else
							{
								return expression1Value + expression2Value;
							}
						case "-":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								return (expression1Long - expression2Long).ToString();
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								return (expression1Double - expression2Double).ToString();
							}
							else
							{
								return expression1Value.Replace(expression2Value, "");
							}
						case "*":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true)
							{
								return (expression1Long * expression2Long).ToString();
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true)
							{
								return (expression1Double * expression2Double).ToString();
							}
							break;
						case "/":
							if (long.TryParse(expression1Value, out expression1Long) == true && long.TryParse(expression2Value, out expression2Long) == true && expression2Long != 0)
							{
								return (expression1Long / expression2Long).ToString();
							}
							else if (double.TryParse(expression1Value, out expression1Double) == true && double.TryParse(expression2Value, out expression2Double) == true && expression2Double != 0.00)
							{
								return (expression1Double / expression2Double).ToString();
							}
							break;
						default:
							break;
					}
					return "null";
				}
			}
			else if (Expression1 != null)
			{
				return Expression1.GetExpressionValue(solutionContext, templateContext, modelContext, interpreterType);
			}
			return "null";
		}

		///--------------------------------------------------------------------------------
		/// <summary>Evaluate expression associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		///--------------------------------------------------------------------------------
		public bool EvaluateExpression(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, InterpreterTypeCode interpreterType)
		{
			string value = GetExpressionValue(solutionContext, templateContext, modelContext, interpreterType);
			if (String.IsNullOrEmpty(value) || value == "false")
			{
				return false;
			}
			return true;
		}
	}
}
