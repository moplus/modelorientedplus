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
using MoPlus.Interpreter.BLL.Solutions;
using System.Data;
using MoPlus.Data;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This interface defines required members for templates.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public interface ITemplate
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the CurrentTabIndent, which signifies how much
		/// to indent generated code.</summary>
		///--------------------------------------------------------------------------------
		int CurrentTabIndent { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Solution.</summary>
		///--------------------------------------------------------------------------------
		Solution Solution { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ContentCodeBuilder.</summary>
		///--------------------------------------------------------------------------------
		StringBuilder ContentCodeBuilder { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the OutputCodeBuilder.</summary>
		///--------------------------------------------------------------------------------
		StringBuilder OutputCodeBuilder { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MessageBuilder.  Messages should only be
		/// generated when the solution is in sample mode.</summary>
		///--------------------------------------------------------------------------------
		StringBuilder MessageBuilder { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateID.</summary>
		///--------------------------------------------------------------------------------
		Guid TemplateID { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NodeName.</summary>
		///--------------------------------------------------------------------------------
		string NodeName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateName.</summary>
		///--------------------------------------------------------------------------------
		string TemplateName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FilePath.</summary>
		///--------------------------------------------------------------------------------
		string FilePath { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CategoryName.</summary>
		///--------------------------------------------------------------------------------
		string CategoryName { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsTopLevelTemplate.</summary>
		///--------------------------------------------------------------------------------
		bool IsTopLevelTemplate { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the HasErrors.</summary>
		///--------------------------------------------------------------------------------
		bool HasErrors { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsTemplateUtilized.</summary>
		///--------------------------------------------------------------------------------
		bool IsTemplateUtilized { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateCallInfo.</summary>
		///--------------------------------------------------------------------------------
		string TemplateCallInfo { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the TemplateCalls.</summary>
		///--------------------------------------------------------------------------------
		SortedList<string, int> TemplateCalls { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ContentBreakpoints.</summary>
		///--------------------------------------------------------------------------------
		List<int> ContentBreakpoints { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets OutputBreakpoints.</summary>
		///--------------------------------------------------------------------------------
		List<int> OutputBreakpoints { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateContent.</summary>
		///--------------------------------------------------------------------------------
		string TemplateContent { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TemplateOutput.</summary>
		///--------------------------------------------------------------------------------
		string TemplateOutput { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateKey.</summary>
		///--------------------------------------------------------------------------------
		String TemplateKey { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ItemIndex.</summary>
		///--------------------------------------------------------------------------------
		int ItemIndex { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Variables.</summary>
		///--------------------------------------------------------------------------------
		StrongNameObjectCollection Variables { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Parameters.</summary>
		///--------------------------------------------------------------------------------
		StrongNameObjectCollection Parameters { get; set; }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the IncludesProjectContext.</summary>
        ///--------------------------------------------------------------------------------
        bool IncludesProjectContext { get; set; }

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the HasRelativeSettings.</summary>
        ///--------------------------------------------------------------------------------
        bool HasRelativeSettings { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the IsBreaking.</summary>
		///--------------------------------------------------------------------------------
		bool IsBreaking { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the IsContinuing.</summary>
		///--------------------------------------------------------------------------------
		bool IsContinuing { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsWatchTemplate.</summary>
		///--------------------------------------------------------------------------------
		bool IsWatchTemplate { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the IsReturning.</summary>
		///--------------------------------------------------------------------------------
		bool IsReturning { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the DbReader.</summary>
		///--------------------------------------------------------------------------------
		IDataReader DbReader { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ModelContextStack.</summary>
		///--------------------------------------------------------------------------------
		List<IDomainEnterpriseObject> ModelContextStack { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StackSize.</summary>
		///--------------------------------------------------------------------------------
		int StackSize { get; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the PopCount.</summary>
		///--------------------------------------------------------------------------------
		int PopCount { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the template key, to be used to store the template
		/// in the solution template dictionary.</summary>
		///--------------------------------------------------------------------------------
		string GetTemplateKey(IDomainEnterpriseObject modelContext, string templateName);

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a model context to the model context stack.</summary>
		/// 
		/// <param name="modelContext">The model context to add to the stack.</param>
		///--------------------------------------------------------------------------------
		IDomainEnterpriseObject PushModelContext(IDomainEnterpriseObject modelContext);

		///--------------------------------------------------------------------------------
		/// <summary>This method pops a model context off of the model context stack.</summary>
		///--------------------------------------------------------------------------------
		IDomainEnterpriseObject PopModelContext();

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a model context off of the model context stack.</summary>
		/// 
		/// <param name="popCount">Count indicating how far up the stack to get the context,
		/// 0 being the current template context.</param>
		///--------------------------------------------------------------------------------
		IDomainEnterpriseObject GetModelContext(int popCount);
	
		///--------------------------------------------------------------------------------
		/// <summary>This method loads the template file data into this instance.</summary>
		/// 
		/// <param name="includeContentAndOutput">Flag indicating if content and output should
		/// be loaded.</param>
		///--------------------------------------------------------------------------------
		void LoadTemplateFileData(bool includeContentAndOutput = true);

		///--------------------------------------------------------------------------------
		/// <summary>This method parses the template content into an abstract syntax tree.</summary>
		/// 
		/// <returns>Parser error and other messages.</returns>
		///--------------------------------------------------------------------------------
		bool ParseContent(bool showDialog = true);

		///--------------------------------------------------------------------------------
		/// <summary>This method parses the template output into a parse tree.</summary>
		/// 
		/// <returns>A ParseTree with the parsing results.</returns>
		///--------------------------------------------------------------------------------
		bool ParseOutput(bool showDialog = true);

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the updated content for the template.  By not
		/// supplying a model context, the generated code is generally suitable as a
		/// sample only.</summary>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		string GetContent();
			
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the updated content for the template.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		string GetContent(IDomainEnterpriseObject parentModelContext);

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce content.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="appendToTemplateContext">Flag to append content.</param>
		/// <param name="parameters">Template parameters.</param>
		///--------------------------------------------------------------------------------
		void GenerateContent(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, bool appendToTemplateContext, NameObjectCollection parameters);

			///--------------------------------------------------------------------------------
		/// <summary>This method generates the associated output path for the template.  By not
		/// supplying a model context, the generated code is generally suitable as a
		/// sample only.</summary>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		string GenerateContentAndOutput();
			
		///--------------------------------------------------------------------------------
		/// <summary>This method generates the associated output path for the code template.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to generate code.</param>
		/// 
		/// <returns>A string representing the generated code for the template.</returns>
		///--------------------------------------------------------------------------------
		string GenerateContentAndOutput(IDomainEnterpriseObject parentModelContext);

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="appendToTemplateContext">Flag to append content.</param>
		/// <param name="parameters">Template parameters.</param>
		///--------------------------------------------------------------------------------
		void GenerateOutput(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, bool appendToTemplateContext, NameObjectCollection parameters);

		///--------------------------------------------------------------------------------
		/// <summary>This method saves the template to a file.</summary>
		///--------------------------------------------------------------------------------
		bool SaveTemplateFile();

		///--------------------------------------------------------------------------------
		/// <summary>Add a template to the list of templates called by this template.</summary>
		/// 
		/// <param name="template">The template call to add.</param>
		///--------------------------------------------------------------------------------
		void AddToTemplateCalls(ITemplate template);

		///--------------------------------------------------------------------------------
		/// <summary>Add a template to the list of templates calling this template.</summary>
		/// 
		/// <param name="template">The template call to add.</param>
		///--------------------------------------------------------------------------------
		void AddToTemplateCalledBy(ITemplate template);

			///--------------------------------------------------------------------------------
		/// <summary>Log an exception associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="ex">The exception to show.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		/// <param name="interpreterType">The interpreter type, such as content or output.</param>
		///--------------------------------------------------------------------------------
		string LogException(Solution solutionContext, IDomainEnterpriseObject modelContext, System.Exception ex, int lineNumber, InterpreterTypeCode interpreterType = InterpreterTypeCode.None);

		///--------------------------------------------------------------------------------
		/// <summary>Log an exception associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="messageBody">The main body message to show.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		/// <param name="interpreterType">The interpreter type, such as content or output.</param>
		///--------------------------------------------------------------------------------
		string LogException(Solution solutionContext, IDomainEnterpriseObject modelContext, string messageBody, int lineNumber, InterpreterTypeCode interpreterType = InterpreterTypeCode.None);
	}
}
