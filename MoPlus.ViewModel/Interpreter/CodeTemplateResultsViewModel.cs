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
using System.Windows.Input;
using System.ComponentModel;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Workflows;
using MoPlus.Data;
using System.Collections.ObjectModel;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using System.Data;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Diagrams;
using System.Collections.Specialized;
using MoPlus.ViewModel.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.ViewModel.Events.Interpreter;
using ICSharpCode.AvalonEdit.Document;
using Irony.Parsing;

namespace MoPlus.ViewModel.Interpreter
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for the template content and parse results.</summary>
    /// 
    ///--------------------------------------------------------------------------------
	public class CodeTemplateResultsViewModel : EditWorkspaceViewModel
	{
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the WindowCaption.</summary>
		///--------------------------------------------------------------------------------
		public string WindowCaption
		{
			get
			{
				return DisplayValues.Template_ParsingResultsLabel;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateType.</summary>
		///--------------------------------------------------------------------------------
		public InterpreterTypeCode TemplateType { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title
		{
			get
			{
				if (TemplateType == InterpreterTypeCode.Output)
				{
					return DisplayValues.Template_ParsingOutputIntro + DisplayValues.Edit_LabelColon + " " + Name;
				}
				else if (TemplateType == InterpreterTypeCode.Specification)
				{
					return DisplayValues.Template_ParsingSpecificationIntro + DisplayValues.Edit_LabelColon + " " + Name;
				}
				return DisplayValues.Template_ParsingContentIntro + DisplayValues.Edit_LabelColon + " " + Name;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ResultsAST.</summary>
		///--------------------------------------------------------------------------------
		public TemplateNode ResultsAST { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ResultsASTLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ResultsASTLabel
		{
			get
			{
				return DisplayValues.Template_ASTLabel;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SampleCode.</summary>
		///--------------------------------------------------------------------------------
		public string SampleCode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the SampleCodeLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SampleCodeLabel
		{
			get
			{
				return DisplayValues.Template_SampleCodeLabel;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			ResultsAST = null;
			base.OnDispose();
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public CodeTemplateResultsViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="templateName">The template name.</param>
		/// <param name="templateType">The template type.</param>
		/// <param name="ast">The abstract syntax tree reults.</param>
		/// <param name="sampleCode">Sample code from interpreter.</param>
		///--------------------------------------------------------------------------------
		public CodeTemplateResultsViewModel(string templateName, InterpreterTypeCode templateType, TemplateNode ast, string sampleCode)
		{
			Name = templateName;
			TemplateType = templateType;
			ResultsAST = ast;
			SampleCode = sampleCode;
			WorkspaceID = Guid.NewGuid();
		}
		#endregion "Constructors"
    }
}
