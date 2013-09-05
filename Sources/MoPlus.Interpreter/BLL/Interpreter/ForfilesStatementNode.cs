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
using System.Collections;
using MoPlus.Interpreter.BLL.Entities;
using System.Data.Common;
using MoPlus.IO;
using System.IO;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of forfiles statements.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ForfilesStatementNode : NonLeafGrammarNode, IStatementNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_ForfilesStatement;
			}
		}

		public ParameterNode DirectoryPath { get; set; }
		public string Extensions { get; set; }
		public List<IStatementNode> Statements { get; set; }

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
				Statements = new List<IStatementNode>();
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is ParameterNode)
					{
						DirectoryPath = node.AstNode as ParameterNode;
						ChildNodes.Add(node.AstNode as ParameterNode);
					}
					else if (node.AstNode is LiteralValueNode)
					{
						Extensions = node.FindToken().ValueString;
					}
					else if (node.AstNode is StatementListNode)
					{
						(node.AstNode as StatementListNode).GetStatements(node, Statements, ChildNodes);
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
		/// <summary>This method gets the collection context associated with this node.</summary>
		/// 
		/// <param name="directoryPath">The directory to get files from.</param>
		/// <param name="extensions">The set of valid file extensions to get.</param>
		///--------------------------------------------------------------------------------
		public List<String> GetFilePaths(string directoryPath, string extensions)
		{
			List<String> collection = new List<string>();
			if (Directory.Exists(directoryPath) == false)
			{
				directoryPath = Directory.GetParent(directoryPath).FullName;
				if (Directory.Exists(directoryPath) == false)
				{
					return collection;
				}
			}
			foreach (string directory in Directory.GetDirectories(directoryPath))
			{
				foreach (string file in GetFilePaths(directory, extensions))
				{
					collection.Add(file);
				}
			}
			foreach (string file in Directory.GetFiles(directoryPath))
			{
				foreach (string extension in extensions.Split(','))
				{
					if (!String.IsNullOrEmpty(extension) && file.EndsWith(extension) == true)
					{
						collection.Add(file);
						break;
					}
				}
			}
			return collection;
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
				int itemIndex = 0;
				templateContext.ItemIndex = itemIndex;
				string directoryPath = DirectoryPath.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
				foreach (string filePath in GetFilePaths(directoryPath, Extensions))
				{
					templateContext.IsBreaking = false;
					templateContext.IsContinuing = false;
					solutionContext.CurrentFilePath = filePath.Replace("\\\\", "\\");
					solutionContext.CurrentFileText = FileHelper.GetText(filePath);
					foreach (IStatementNode node in Statements)
					{
						if (node.HandleDebug(interpreterType, solutionContext, templateContext, modelContext) == false) return;
						if (templateContext.IsContinuing == true)
						{
							break;
						}
						if (templateContext.IsBreaking == true || templateContext.IsReturning == true)
						{
							templateContext.IsBreaking = false;
							break;
						}
						if (node is BreakStatementNode)
						{
							templateContext.IsBreaking = true;
							break;
						}
						if (node is ContinueStatementNode)
						{
							break;
						}
						if (node is ReturnStatementNode)
						{
							templateContext.IsReturning = true;
							break;
						}
						node.InterpretNode(interpreterType, solutionContext, templateContext, modelContext);
					}
					itemIndex++;
					templateContext.ItemIndex = itemIndex;
				}
				templateContext.ItemIndex = 0;
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
		}
	}
}
