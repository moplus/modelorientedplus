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
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Entities;
using System.Text.RegularExpressions;
using Irony.Interpreter;
using Irony.Parsing;
using MoPlus.Interpreter.BLL.Models;
using System.Text;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class defines the grammar for the code template content.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/8/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class CodeTemplateContentGrammar : Grammar
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor sets up the overall grammar.</summary>
		/// 
		/// <param name="solution">The solution containing model structure to add to the grammar.</param>
		///--------------------------------------------------------------------------------
		public CodeTemplateContentGrammar(Solution solution)
		{
			bool isFirstItem = true;
			this.LanguageFlags |= LanguageFlags.CreateAst;
			this.GrammarComments = "This grammar is used to parse the CONTENT section of an M+ code template.";

			#region "Literals, Symbols, Operators, Punctuation, etc."

			// literals
			StringLiteral StringLiteral = TerminalFactory.CreateCSharpString("StringLiteral");
			NumberLiteral Number = TerminalFactory.CreateCSharpNumber("Number");
			Number.Options |= NumberOptions.AllowSign;
			IdentifierTerminal identifier = TerminalFactory.CreateCSharpIdentifier("Identifier");

			// symbols
			KeyTerm textOpen = ToTerm(LanguageTerms.TextOpenTag);
			KeyTerm evalOpen = ToTerm(LanguageTerms.EvalOpenTag);
			KeyTerm outputOpen = ToTerm(LanguageTerms.OutputOpenTag);
			KeyTerm propOpen = ToTerm(LanguageTerms.PropOpenTag);
			KeyTerm close = ToTerm(LanguageTerms.CloseTag);
			KeyTerm dot = ToTerm(".");
			KeyTerm comma = ToTerm(",");
			KeyTerm Lbr = ToTerm("{");
			KeyTerm Rbr = ToTerm("}");
			KeyTerm Lpar = ToTerm("(");
			KeyTerm Rpar = ToTerm(")");
			KeyTerm slash = ToTerm("/");

			// operators
			RegisterOperators(1, "||");
			RegisterOperators(2, "&&");
			RegisterOperators(3, "==", "!=");
			RegisterOperators(4, "<", ">", "<=", ">=");
			RegisterOperators(5, ".");
			RegisterOperators(6, "+", "-", "*", "/");

			// delimiters and punctuation
			this.Delimiters = "{}[](),:;+-*/%&|^!~<>=";
			this.MarkPunctuation("=", ";", ",", "(", ")", "{", "}", ".", LanguageTerms.ProgressTerm, LanguageTerms.TraceTerm, LanguageTerms.DebugTerm, LanguageTerms.WhileTerm, LanguageTerms.VarTerm, LanguageTerms.ParamTerm, LanguageTerms.IfTerm, LanguageTerms.ElseTerm, LanguageTerms.WithTerm, LanguageTerms.ForeachTerm, LanguageTerms.BreakTerm, LanguageTerms.ClearTerm, LanguageTerms.ReturnTerm, LanguageTerms.SwitchTerm, LanguageTerms.CaseTerm, LanguageTerms.DefaultTerm, LanguageTerms.WhereTerm, LanguageTerms.InTerm, LanguageTerms.LimitTerm, LanguageTerms.SortTerm, LanguageTerms.FromTerm, LanguageTerms.TextOpenTag, LanguageTerms.EvalOpenTag, LanguageTerms.OutputOpenTag, LanguageTerms.PropOpenTag, LanguageTerms.CloseTag);

			// whitespace and line terminators
			this.LineTerminators = "\r\n\u2085\u2028\u2029";
			this.WhitespaceChars = " \t\r\n\v\u2085\u2028\u2029";

			// comments
			CommentTerminal singleLineComment = new CommentTerminal("singleLineComment", "//", "\r", "\n", "\u2085", "\u2028", "\u2029");
			CommentTerminal delimitedComment = new CommentTerminal("delimitedComment", "/*", "*/");
			TextTerminal templateText = new TextTerminal("templateText", "<%%-", "%%>");
			NonGrammarTerminals.Add(singleLineComment);
			NonGrammarTerminals.Add(delimitedComment);
			#endregion

			#region "Nodes"
			// high level nodes
			var template = new NonTerminal("template", typeof(TemplateNode));
			var templateBlock = new NonTerminal("templateBlock");

			// statements
			var statementList = new NonTerminal("statementList", typeof(StatementListNode));
			var statement = new NonTerminal("statement");
			var ifStatement = new NonTerminal("ifStatement", typeof(IfStatementNode));
			var switchStatement = new NonTerminal("switchStatement", typeof(SwitchStatementNode));
			var foreachStatement = new NonTerminal("foreachStatement", typeof(ForeachStatementNode));
			var whileStatement = new NonTerminal("whileStatement", typeof(WhileStatementNode));
			var withStatement = new NonTerminal("withStatement", typeof(WithStatementNode));
			var breakStatement = new NonTerminal("breakStatement", typeof(BreakStatementNode));
			var clearStatement = new NonTerminal("clearStatement", typeof(ClearTextStatementNode));
			var returnStatement = new NonTerminal("returnStatement", typeof(ReturnStatementNode));
			var currentItemAssignmentStatement = new NonTerminal("currentItemAssignmentStatement", typeof(CurrentItemAssignmentStatementNode));
			var templatePropertyAssignmentStatement = new NonTerminal("templatePropertyAssignmentStatement", typeof(TemplatePropertyAssignmentStatementNode));
			var debugStatement = new NonTerminal("debugStatement", typeof(DebugStatementNode));
			var traceStatement = new NonTerminal("traceStatement", typeof(TraceStatementNode));
			var logStatement = new NonTerminal("logStatement", typeof(LogStatementNode));
			var progressStatement = new NonTerminal("progressStatement", typeof(ProgressStatementNode));
			var varStatement = new NonTerminal("varStatement", typeof(VarStatementNode));
			var paramStatement = new NonTerminal("paramStatement", typeof(ParamStatementNode));
			var assignmentStatement = new NonTerminal("assignmentStatement", typeof(AssignmentStatementNode));

			// clauses
			var elseClause = new NonTerminal("elseClause", typeof(ElseClauseNode));
			var elseIfList = new NonTerminal("elseIfList", typeof(ElseIfListNode));
			var elseIfClause = new NonTerminal("elseIfClause", typeof(ElseIfClauseNode));
			var caseList = new NonTerminal("caseList", typeof(CaseListNode));
			var caseClause = new NonTerminal("caseClause", typeof(CaseClauseNode));
			var defaultClause = new NonTerminal("defaultClause", typeof(DefaultClauseNode));
			var caseConditionList = new NonTerminal("caseConditionList", typeof(CaseConditionListNode));
			var caseCondition = new NonTerminal("caseCondition", typeof(CaseConditionNode));
			var foreachClause = new NonTerminal("foreachClause", typeof(ForeachClauseNode));
			var whereClause = new NonTerminal("whereClause", typeof(WhereClauseNode));
			var inClause = new NonTerminal("inClause", typeof(InClauseNode));
			var limitClause = new NonTerminal("limitClause", typeof(LimitClauseNode));
			var sortClause = new NonTerminal("sortClause", typeof(SortClauseNode));
			var sortDirectionClause = new NonTerminal("sortDirectionClause", typeof(SortDirectionClauseNode));
			var fromClause = new NonTerminal("fromClause", typeof(FromClauseNode));
			var templateParameterList = new NonTerminal("templateParameterList", typeof(TemplateParameterListNode));
			var templateParameter = new NonTerminal("templateParameter", typeof(TemplateParameterNode));

			// expressions
			var expression = new NonTerminal("expression", typeof(ExpressionNode));
			var binOp = new NonTerminal("binOp", "operator symbol", typeof(BinaryOperatorNode));
			var mathOp = new NonTerminal("mathOp", "operator symbol", typeof(MathOperatorNode));
			var literal = new NonTerminal("literal", typeof(LiteralNode));
			var popContext = new NonTerminal("popContext", typeof(PopContextNode));
			var thisContext = new NonTerminal("thisContext", typeof(ThisContextNode));

			// properties
			var property = new NonTerminal("property");
			var contentProperty = new NonTerminal("contentProperty");
			var templateProperty = new NonTerminal("templateProperty", typeof(TemplatePropertyNode));
			var inClauseItem = new NonTerminal("inClauseItem", typeof(InClauselItemNode));
			var modelContext = new NonTerminal("modelContext", typeof(ModelContextNode));
			var currentItem = new NonTerminal("currentItem", typeof(CurrentItemNode));
			var modelProperty = new NonTerminal("modelProperty", typeof(ModelPropertyNode));
			var assignableProperty = new NonTerminal("assignableProperty", typeof(AssignablePropertyNode));
			var configurationProperty = new NonTerminal("configurationProperty", typeof(ConfigurationPropertyNode));
			var contextHelper = new NonTerminal("contextHelper", typeof(ContextHelperNode));
			var collectionHelper = new NonTerminal("collectionHelper", typeof(CollectionHelperNode));
			var parameter = new NonTerminal("parameter", typeof(ParameterNode));
			#endregion

			#region "Rules"
			// a template consists of any number of template blocks
			template.Rule = MakeStarRule(template, null, templateBlock);

			// a template block is a property or an evaluation (a statement list surrounded by eval tags)
			templateBlock.Rule = property | evalOpen + statementList + close;

			// a statement list consists of any number of statements
			statementList.Rule = MakeStarRule(statementList, null, statement);

			// a statement can be an if, switch, foreach, with, or a property
			statement.Rule = ifStatement
							| switchStatement
							| foreachStatement
							| whileStatement
							| withStatement
							| breakStatement
							| clearStatement
							| returnStatement
							| currentItemAssignmentStatement
							| templatePropertyAssignmentStatement
							| traceStatement
							| logStatement
							| varStatement
							| paramStatement
							| assignmentStatement
							| property
							| progressStatement;

			// var statement
			varStatement.Rule = ToTerm(LanguageTerms.VarTerm) + identifier | ToTerm(LanguageTerms.VarTerm) + identifier + "=" + parameter;

			// param statement
			paramStatement.Rule = ToTerm(LanguageTerms.ParamTerm) + identifier;

			// assignment statement
			assignmentStatement.Rule = identifier + "=" + parameter;

			// if statement
			ifStatement.Rule = ToTerm(LanguageTerms.IfTerm) + Lpar + expression + Rpar + Lbr + statementList + Rbr + elseIfList + elseClause;
			elseIfList.Rule = MakeStarRule(elseIfList, null, elseIfClause);
			elseIfClause.Rule = ToTerm(LanguageTerms.ElseTerm) + LanguageTerms.IfTerm + Lpar + expression + Rpar + Lbr + statementList + Rbr;
			elseClause.Rule = Empty | ToTerm(LanguageTerms.ElseTerm) + Lbr + statementList + Rbr;

			// break and return statements, etc.
			breakStatement.Rule = ToTerm(LanguageTerms.BreakTerm);
			clearStatement.Rule = ToTerm(LanguageTerms.ClearTerm);
			returnStatement.Rule = ToTerm(LanguageTerms.ReturnTerm);
			popContext.Rule = dot + dot + slash;
			thisContext.Rule = ToTerm(LanguageTerms.ThisTerm);

			// switch statement
			switchStatement.Rule = ToTerm(LanguageTerms.SwitchTerm) + Lpar + modelProperty + Rpar + Lbr + caseList + defaultClause + Rbr;
			caseList.Rule = MakePlusRule(caseList, null, caseClause);
			caseClause.Rule = caseConditionList + statementList + breakStatement;
			defaultClause.Rule = Empty | ToTerm(LanguageTerms.DefaultTerm) + ":" + statementList;
			caseConditionList.Rule = MakePlusRule(caseConditionList, null, caseCondition);
			caseCondition.Rule = ToTerm(LanguageTerms.CaseTerm) + literal + ":";

			// a foreach statement consists of a foreach keyword, followed by a model context, 
			// optionally followed by a where clause, and includes a set of statements
			// or, a foreach statement consists of a Record item
			foreachStatement.Rule = ToTerm(LanguageTerms.ForeachTerm) + Lpar + foreachClause + Rpar + Lbr + statementList + Rbr;
			foreachClause.Rule = modelContext + inClause + whereClause + limitClause + sortClause | ToTerm(LanguageTerms.RecordItem) + limitClause;
			inClause.Rule = Empty | ToTerm(LanguageTerms.InTerm) + inClauseItem;
			whereClause.Rule = Empty | ToTerm(LanguageTerms.WhereTerm) + expression;
			limitClause.Rule = Empty | ToTerm(LanguageTerms.LimitTerm) + Number;
			sortClause.Rule = Empty | ToTerm(LanguageTerms.SortTerm) + modelProperty + sortDirectionClause;
			sortDirectionClause.Rule = Empty | ToTerm(LanguageTerms.AscTerm) | ToTerm(LanguageTerms.DescTerm);

			// a while statement consists of a while keyword, followed by an expression,
			// and includes a set of statements
			whileStatement.Rule = ToTerm(LanguageTerms.WhileTerm) + Lpar + expression + Rpar + Lbr + statementList + Rbr;

			// current item assignment statement
			currentItemAssignmentStatement.Rule = currentItem + "=" + modelContext | currentItem + "=" + "null";

			// template property assignment statement
			templatePropertyAssignmentStatement.Rule = ToTerm(LanguageTerms.TextProperty) + "=" + parameter;

			// debug statement
			debugStatement.Rule = ToTerm(LanguageTerms.DebugTerm) + Lpar + parameter + Rpar
									| ToTerm(LanguageTerms.DebugTerm) + Lpar + parameter + comma + parameter + Rpar;

			// trace statement
			traceStatement.Rule = ToTerm(LanguageTerms.TraceTerm) + Lpar + parameter + Rpar
									| ToTerm(LanguageTerms.TraceTerm) + Lpar + parameter + comma + parameter + Rpar;

			// log statement
			logStatement.Rule = ToTerm(LanguageTerms.LogTerm) + Lpar + parameter + comma + parameter + comma + parameter + Rpar;

			// a with statement consists of a with keyword, followed by a model context,
			// and includes a set of statements
			withStatement.Rule = ToTerm(LanguageTerms.WithTerm) + Lpar + modelContext + fromClause + Rpar + Lbr + statementList + Rbr | LanguageTerms.WithTerm + Lpar + currentItem + Rpar + Lbr + statementList + Rbr;
			fromClause.Rule = Empty | ToTerm(LanguageTerms.FromTerm) + contextHelper;

			// progress statement
			progressStatement.Rule = ToTerm(LanguageTerms.ProgressTerm) | LanguageTerms.ProgressTerm + Lpar + parameter + Rpar;

			// a context helper is one of the specifically supported internal methods to set model context
			contextHelper.Rule = modelContext + dot + LanguageTerms.FindMethod + Lpar + modelProperty + comma + parameter + Rpar
								| modelContext + dot + LanguageTerms.FindMethod + Lpar + parameter + Rpar
								| currentItem + dot + LanguageTerms.FindMethod + Lpar + modelProperty + comma + parameter + Rpar
								| currentItem + dot + LanguageTerms.FindMethod + Lpar + parameter + Rpar;

			// a property is a content property or an output property
			property.Rule = contentProperty | templateText;

			// a content property can be a template property, model property, or configuration property (template property is lowest precedence)
			contentProperty.Rule = propOpen + configurationProperty + close
									| propOpen + parameter + close;

			// a parameter is a model property or string literal
			parameter.Rule = modelProperty | literal | parameter + mathOp + parameter;

			// an in clause item is a collection from a model context, current item, or a special collection
			inClauseItem.Rule = modelContext
								| currentItem
								| collectionHelper;

			// a collection helper gets specialized collections
			collectionHelper.Rule = modelContext + dot + LanguageTerms.FindAllMethod + Lpar + modelProperty + comma + parameter + Rpar
								| currentItem + dot + LanguageTerms.FindAllMethod + Lpar + modelProperty + comma + parameter + Rpar
								| ToTerm(LanguageTerms.GetEntityAndBasesCollection)
								| ToTerm(LanguageTerms.GetBaseAndEntitiesCollection)
								| ToTerm(LanguageTerms.ExtendingEntitiesCollection)
								| ToTerm(LanguageTerms.PathRelationships);

			// a current item node is a valid name of a type of node in the model that can be assigned to
			isFirstItem = true;
			// add all CurrentItemTypeCode enums to currentItem rule
			foreach (string key in GrammarHelper.CurrentItemTypes.AllKeys)
			{
				if (isFirstItem == true)
				{
					currentItem.Rule = ToTerm(key);
					isFirstItem = false;
				}
				else
				{
					currentItem.Rule = currentItem.Rule | ToTerm(key);
				}
			}
			// add all ModelObject instances in model to currentItem rule
			if (solution != null)
			{
				foreach (string key in solution.ModelObjectNames.AllKeys)
				{
					currentItem.Rule = currentItem.Rule | ToTerm("Current" + key);
				}
			}

			// a model context node is a valid name of a type of node in the model or a pop context directive
			modelContext.Rule = popContext
								| popContext + modelContext
								| thisContext
								| thisContext + dot + modelContext;
			// add all ModelContextTypeCode enums to modelContext rule
			foreach (string key in GrammarHelper.ModelContextTypes.AllKeys)
			{
				modelContext.Rule = modelContext.Rule | ToTerm(key);
			}
			// add all OtherModelContextTypeCode enums to modelContext rule
			foreach (string key in GrammarHelper.OtherModelContextTypes.AllKeys)
			{
				modelContext.Rule = modelContext.Rule | ToTerm(key);
			}
			// add all ModelObject instances in model to modelContext rule
			if (solution != null)
			{
				foreach (string key in solution.ModelObjectNames.AllKeys)
				{
					modelContext.Rule = modelContext.Rule | ToTerm(key);
				}
			}

			// an assignable property is a model property that can have values assigned to it
			isFirstItem = true;
			// add all AssignablePropertyCode enums to assignableProperty rule
			foreach (string key in GrammarHelper.AssignableProperties.AllKeys)
			{
				if (isFirstItem == true)
				{
					assignableProperty.Rule = ToTerm(key);
					isFirstItem = false;
				}
				else
				{
					assignableProperty.Rule = assignableProperty.Rule | ToTerm(key);
				}
			}
			// add all ModelProperty instances in model to assignableProperty rule
			if (solution != null)
			{
				foreach (string key in solution.ModelPropertyNames.AllKeys)
				{
					assignableProperty.Rule = assignableProperty.Rule | ToTerm(key);
				}
			}

			// a model property is a valid property name of a node in the model (can refer to other nodes with the dot notation)
			modelProperty.Rule = assignableProperty
									| ToTerm(LanguageTerms.ItemIndexProperty)
									| ToTerm(LanguageTerms.TextProperty)
									| ToTerm(LanguageTerms.PathProperty)
									//| ToTerm(LanguageTerms.LibraryDirectoryProperty)
									| ToTerm(LanguageTerms.IsRelatedToProperty)
									| modelContext + dot + modelProperty
									| currentItem + dot + modelProperty
									| templateProperty
									| popContext + modelProperty
									| thisContext + dot + modelProperty
									| ToTerm(LanguageTerms.ColumnMethod) + Lpar + parameter + Rpar
									| ToTerm(LanguageTerms.FileMethod) + Lpar + parameter + Rpar
									| ToTerm(LanguageTerms.FileExistsMethod) + Lpar + parameter + Rpar
									| ToTerm(LanguageTerms.LogMethod) + Lpar + parameter + comma + parameter + Rpar
									| ToTerm(LanguageTerms.HasPropertyNamed) + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringStartsWith + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringEndsWith + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringContains + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringRegexReplace + Lpar + parameter + comma + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringRegexIsMatch + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringCamelCase + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringCapitalCase + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringCapitalWordCase + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringUnderscoreCase + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringToLower + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringToUpper + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringTrim + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringTrimStart + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringTrimEnd + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringReplace + Lpar + parameter + comma + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringFilter + Lpar + parameter + comma + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringFilterProtected + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringFilterIgnored + Lpar + Rpar
									| modelProperty + dot + LanguageTerms.StringSubstring + Lpar + parameter + comma + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringSubstring + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringIndexOf + Lpar + parameter + Rpar
									| modelProperty + dot + LanguageTerms.StringLength;
			// add all ReadOnlyPropertyCode enums to modelProperty rule
			foreach (string key in GrammarHelper.ReadOnlyProperties.AllKeys)
			{
				modelProperty.Rule = modelProperty.Rule | ToTerm(key);
			}

			// a configuration property is one of the specfically supported internal methods to process model data
			configurationProperty.Rule = ToTerm(LanguageTerms.TabMethod) + Number
									| ToTerm(LanguageTerms.UseTabsMethod) + "true"
									| ToTerm(LanguageTerms.UseTabsMethod) + "false"
									| ToTerm(LanguageTerms.TabStringMethod) + StringLiteral
									| ToTerm(LanguageTerms.UseProtectedAreasMethod) + "true"
									| ToTerm(LanguageTerms.UseProtectedAreasMethod) + "false"
									| ToTerm(LanguageTerms.ProtectedAreaStartMethod) + StringLiteral
									| ToTerm(LanguageTerms.ProtectedAreaEndMethod) + StringLiteral
									| ToTerm(LanguageTerms.UseIgnoredAreasMethod) + "true"
									| ToTerm(LanguageTerms.UseIgnoredAreasMethod) + "false"
									| ToTerm(LanguageTerms.IgnoredAreaStartMethod) + StringLiteral
									| ToTerm(LanguageTerms.IgnoredAreaEndMethod) + StringLiteral
									| ToTerm(LanguageTerms.UserMethod)
									| ToTerm(LanguageTerms.NowMethod);

			// a template property from the parser perspective is just an identifier, the interpreter will resolve template references
			templateProperty.Rule = identifier
									| identifier + Lpar + templateParameterList + Rpar;

			// a template parameter list consists of any number of template parameters delimited by commas
			templateParameterList.Rule = MakeStarRule(templateParameterList, comma, templateParameter);

			// template parameter
			templateParameter.Rule = identifier + "=" + parameter;

			// an expression can be a hierarchy of expressions with binary operators, model properties, and literals
			expression.Rule =	  literal
								| modelProperty
								| modelContext
								| currentItem
								| expression + binOp + expression
								| expression + mathOp + expression
			                    | Lpar + expression + Rpar;

			// a literal can be a number, string, character, true, false, or null
			literal.Rule = Number | StringLiteral | "true" | "false" | "null";

			// binary operator
			binOp.Rule = ToTerm("||") | "&&" | "==" | "!=" | "<" | ">" | "<=" | ">=";

			// math operator
			mathOp.Rule = ToTerm("+") | "-" | "*" | "/";

			#endregion

			// the template is the root of the grammar
			this.Root = template;

			// mark nodes to filter from the parse tree
			this.MarkTransient(statement, templateBlock, property, contentProperty);
		}
		#endregion "Constructors"
	}
}