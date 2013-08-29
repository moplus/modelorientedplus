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
using MoPlus.Interpreter.Resources;
using System.Threading;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of expressions.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public abstract class GrammarNodeBase : AstNode, IGrammarNode
	{
		private List<IGrammarNode> _childNodes;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ChildNodes.</summary>
		///--------------------------------------------------------------------------------
		public new List<IGrammarNode> ChildNodes
		{
			get
			{
				if (_childNodes == null)
				{
					_childNodes = new List<IGrammarNode>();
				}
				return _childNodes;
			}
			set
			{
				_childNodes = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public virtual string DisplayName
		{
			get
			{
				if (Term.AstNodeType != null)
				{
					return LineNumber.ToString() + ": "+ Term.AstNodeType.Name;
				}
				return LineNumber.ToString() + ": " + Term.GetType().Name;
			}
		}


		///--------------------------------------------------------------------------------
		/// <summary>This property gets the LineNumber where the template node originates.</summary>
		///--------------------------------------------------------------------------------
		public virtual int LineNumber { get; set; }

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
				LineNumber = treeNode.Span.Location.Line;
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
		/// <summary>This method is used to perform begin and end actions for a visitor.</summary>
		///--------------------------------------------------------------------------------
		public virtual void ExecuteVisitor(IGrammarNodeVisitor visitor)
		{
			visitor.BeginVisit(this);
			if (ChildNodes.Count > 0)
				foreach (IGrammarNode node in ChildNodes)
					node.ExecuteVisitor(visitor);
			visitor.EndVisit(this);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Throw an exception associated with this node.</summary>
		/// 
		/// <param name="ex">The exception to show.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ThrowParseException(System.Exception ex, bool showMessageBox = true)
		{
			StringBuilder message = new StringBuilder();
			message.Append(DisplayValues.Exception_Parsing);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_InnerMessageIntro);
			message.Append("\r\n");
			message.Append(ex.Message);
			ApplicationException appEx = new ApplicationException(message.ToString(), ex);
			throw appEx;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Throw an exception associated with this node.</summary>
		/// 
		/// <param name="ex">The exception to show.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ThrowASTException(System.Exception ex, bool showMessageBox = true)
		{
			StringBuilder message = new StringBuilder();
			message.Append(DisplayValues.Exception_AST);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_InnerMessageIntro);
			message.Append("\r\n");
			message.Append(ex.Message);
			ApplicationException appEx = new ApplicationException(message.ToString(), ex);
			throw appEx;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Log an exception associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="ex">The exception to show.</param>
		/// <param name="interpreterType">The interpreter type, such as content or output.</param>
		///--------------------------------------------------------------------------------
		public string LogException(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, System.Exception ex, InterpreterTypeCode interpreterType = InterpreterTypeCode.None)
		{
			return LogException(solutionContext, templateContext, modelContext, ex.Message + "\r\n" + ex.StackTrace, interpreterType);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Log an exception associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="messageBody">The main body message to show.</param>
		/// <param name="interpreterType">The interpreter type, such as content or output.</param>
		///--------------------------------------------------------------------------------
		public string LogException(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, string messageBody, InterpreterTypeCode interpreterType = InterpreterTypeCode.None)
		{
			return templateContext.LogException(solutionContext, modelContext, messageBody, LineNumber, interpreterType);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Show a debug message associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="messageBody">The main body message to show.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public string ShowDebugMessage(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, string messageBody, bool showMessageBox = false)
		{
			StringBuilder title = new StringBuilder();
			title.Append(DisplayValues.Debug_Intro);
			StringBuilder message = new StringBuilder();
			message.Append(messageBody);
			message.Append("\r\n");
			message.Append(DisplayValues.Debug_TemplateDetails);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_SolutionIntro);
			message.Append(" ");
			message.Append(solutionContext.SolutionName);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_NodeIntro);
			message.Append(" ");
			message.Append(templateContext.NodeName);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_TemplateIntro);
			message.Append(" ");
			message.Append(templateContext.TemplateName);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_LineNumberIntro);
			message.Append(" ");
			message.Append(LineNumber.ToString());
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_ModelContextIntro);
			message.Append(" ");
			message.Append(modelContext.GetType().Name);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_ModelIdIntro);
			message.Append(" ");
			message.Append(modelContext.ID.ToString());
			solutionContext.ShowOutput(message.ToString(), title.ToString(), true, showMessageBox);
			return message.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Show a trace message associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="messageBody">The main body message to show.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public string ShowTraceMessage(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, string messageBody, bool showMessageBox = false)
		{
			StringBuilder message = new StringBuilder();
			message.Append(messageBody);
			message.Append(", ");
			message.Append(DisplayValues.Exception_SolutionIntro);
			message.Append(" ");
			message.Append(solutionContext.SolutionName);
			message.Append(", ");
			message.Append(DisplayValues.Exception_NodeIntro);
			message.Append(" ");
			message.Append(templateContext.NodeName);
			message.Append(", ");
			message.Append(DisplayValues.Exception_TemplateIntro);
			message.Append(" ");
			message.Append(templateContext.TemplateName);
			message.Append(", ");
			message.Append(DisplayValues.Exception_LineNumberIntro);
			message.Append(" ");
			message.Append(LineNumber.ToString());
			message.Append(", ");
			message.Append(DisplayValues.Exception_ModelContextIntro);
			message.Append(" ");
			message.Append(modelContext.GetType().Name);
			message.Append(", ");
			message.Append(DisplayValues.Exception_ModelIdIntro);
			message.Append(" ");
			message.Append(modelContext.ID.ToString());
			solutionContext.ShowOutput(message.ToString(), null, true, showMessageBox);
			return message.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Handle debugging workflow.</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public bool HandleDebug(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			if (DebugHelper.DebugAction == DebugAction.Stop)
			{
				// cause subsequent statements to not execute
				return false;
			}
			if (solutionContext.IsSampleMode == true)  // only allow debugging from designer side using sample mode
			{
				if (interpreterType == InterpreterTypeCode.Content)
				{
					if (templateContext.ContentBreakpoints.Contains(LineNumber) == true && DebugHelper.DebugAction != DebugAction.Breaking)
					{
						// handle breakpoint
						lock (DebugHelper.DEBUG_OBJECT)
						{
							DebugHelper.DebugAction = DebugAction.Breaking;
						}
						// fire breaking event
						solutionContext.HandleBreakpoint(interpreterType, templateContext, modelContext, LineNumber);
						lock (DebugHelper.DEBUG_OBJECT)
						{
							while (DebugHelper.DebugAction == DebugAction.Breaking)
							{
								Monitor.Wait(DebugHelper.DEBUG_OBJECT);
							}
						}
						if (DebugHelper.DebugAction == DebugAction.Stop)
						{
							// cause subsequent statements to not execute
							return false;
						}
						lock (DebugHelper.DEBUG_OBJECT)
						{
							DebugHelper.DebugAction = DebugAction.Continue;
						}
					}
				}
				else if (interpreterType == InterpreterTypeCode.Output)
				{
					if (templateContext.OutputBreakpoints.Contains(LineNumber) == true && DebugHelper.DebugAction != DebugAction.Breaking)
					{
						// handle breakpoint
						lock (DebugHelper.DEBUG_OBJECT)
						{
							DebugHelper.DebugAction = DebugAction.Breaking;
						}
						// fire breaking event
						solutionContext.HandleBreakpoint(interpreterType, templateContext, modelContext, LineNumber);
						lock (DebugHelper.DEBUG_OBJECT)
						{
							while (DebugHelper.DebugAction == DebugAction.Breaking)
							{
								Monitor.Wait(DebugHelper.DEBUG_OBJECT);
							}
						}
						if (DebugHelper.DebugAction == DebugAction.Stop)
						{
							// cause subsequent statements to not execute
							return false;
						}
						lock (DebugHelper.DEBUG_OBJECT)
						{
							DebugHelper.DebugAction = DebugAction.Continue;
						}
					}
				}
			}
			return true;
		}
	}
}
