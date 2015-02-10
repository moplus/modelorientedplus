/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.Resources;
using System.Data;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.IO;
using MoPlus.Interpreter.BLL.Diagrams;
using Irony.Parsing;
using MoPlus.IO;
using System.Text;
using MoPlus.Interpreter.BLL.Solutions;
using System.Data.Common;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.Events;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This file is for metadata management properties and methods to support the
	/// Solution class.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>11/11/2009</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Template : BusinessObjectBase
	{
		#region "Fields and Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ItemValue.</summary>
		///--------------------------------------------------------------------------------
		public string ItemValue
		{
			get
			{
				return FilePath;
			}
			set
			{
				FilePath = value;
			}
		}

		private StrongNameObjectCollection _variables = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Variables.</summary>
		///--------------------------------------------------------------------------------
		public StrongNameObjectCollection Variables
		{
			get
			{
				if (_variables == null) _variables = new StrongNameObjectCollection();
				return _variables;
			}
			set
			{
				_variables = value;
			}
		}

		private StrongNameObjectCollection _parameters = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Parameters.</summary>
		///--------------------------------------------------------------------------------
		public StrongNameObjectCollection Parameters
		{
			get
			{
				if (_parameters == null) _parameters = new StrongNameObjectCollection();
				return _parameters;
			}
			set
			{
				_parameters = value;
			}
		}

        ///--------------------------------------------------------------------------------
        /// <summary>This property gets/sets the HasRelativeSettings.</summary>
        ///--------------------------------------------------------------------------------
        public bool HasRelativeSettings { get; set; }

        private List<int> _contentBreakpoints = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ContentBreakpoints.</summary>
		///--------------------------------------------------------------------------------
		public List<int> ContentBreakpoints
		{
			get
			{
				if (_contentBreakpoints == null)
				{
					_contentBreakpoints = new List<int>();
				}
				return _contentBreakpoints;
			}
			set
			{
				_contentBreakpoints = value;
			}
		}

		private List<int> _outputBreakpoints = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets OutputBreakpoints.</summary>
		///--------------------------------------------------------------------------------
		public List<int> OutputBreakpoints
		{
			get
			{
				if (_outputBreakpoints == null)
				{
					_outputBreakpoints = new List<int>();
				}
				return _outputBreakpoints;
			}
			set
			{
				_outputBreakpoints = value;
			}
		}

		protected EnterpriseDataObjectList<DebugItem> _contentDebugItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of DebugItem.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<DebugItem> ContentDebugItems
		{
			get
			{
				if (_contentDebugItems == null)
				{
					_contentDebugItems = new EnterpriseDataObjectList<DebugItem>();
				}
				return _contentDebugItems;
			}
			set
			{
				if (_contentDebugItems == null || _contentDebugItems.Equals(value) == false)
				{
					_contentDebugItems = value;
				}
			}
		}

		protected EnterpriseDataObjectList<DebugItem> _outputDebugItems = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of DebugItem.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<DebugItem> OutputDebugItems
		{
			get
			{
				if (_outputDebugItems == null)
				{
					_outputDebugItems = new EnterpriseDataObjectList<DebugItem>();
				}
				return _outputDebugItems;
			}
			set
			{
				if (_outputDebugItems == null || _outputDebugItems.Equals(value) == false)
				{
					_outputDebugItems = value;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IsWatchTemplate.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsWatchTemplate { get; set; }

		private SortedList<string, int> _templateCalls = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the TemplateCalls.</summary>
		///--------------------------------------------------------------------------------
		public SortedList<string, int> TemplateCalls
		{
			get
			{
				if (_templateCalls == null) _templateCalls = new SortedList<string, int>();
				return _templateCalls;
			}
			set
			{
				_templateCalls = value;
			}
		}

		private SortedList<string, int> _templateCalledBy = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the TemplateCalledBy.</summary>
		///--------------------------------------------------------------------------------
		public SortedList<string, int> TemplateCalledBy
		{
			get
			{
				if (_templateCalledBy == null) _templateCalledBy = new SortedList<string, int>();
				return _templateCalledBy;
			}
			set
			{
				_templateCalledBy = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateType.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string TemplateType
		{
			get
			{
				if (GrammarHelper.ModelContextTypes[NodeName].GetString() == NodeName)
				{
					return NodeName;
				}
				if (GrammarHelper.SpecModelContextTypes[NodeName].GetString() == NodeName)
				{
					return NodeName;
				}
				return "None";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ContentAST.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public TemplateNode ContentAST { get; set; }

		private StringBuilder _contentCodeBuilder;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ContentCodeBuilder.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StringBuilder ContentCodeBuilder
		{
			get
			{
				if (_contentCodeBuilder == null)
				{
					_contentCodeBuilder = new StringBuilder();
				}
				return _contentCodeBuilder;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ContentCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public String ContentCode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OutputAST.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public TemplateNode OutputAST { get; set; }

		private StringBuilder _outputCodeBuilder;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the OutputCodeBuilder.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StringBuilder OutputCodeBuilder
		{
			get
			{
				if (_outputCodeBuilder == null)
				{
					_outputCodeBuilder = new StringBuilder();
				}
				return _outputCodeBuilder;
			}
		}

		private StringBuilder _messageBuilder;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the MessageBuilder.  Messages should only be
		/// generated when the solution is in sample mode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StringBuilder MessageBuilder
		{
			get
			{
				if (_messageBuilder == null)
				{
					_messageBuilder = new StringBuilder();
				}
				return _messageBuilder;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OutputCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public String OutputCode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateKey.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public String TemplateKey
		{
			get
			{
				return NodeName + ":" + TemplateName;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the TemplateFileText.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string TemplateFileText
		{
			get
			{
				StringBuilder text = new StringBuilder();
				text.Append("<CONFIG>\r\n");
				text.Append("\tNAME ");
				text.Append(TemplateName).Append("\r\n");
				if (!String.IsNullOrEmpty(CategoryName))
				{
					text.Append("\tCATEGORY ");
					text.Append(CategoryName).Append("\r\n");
				}
				text.Append("\tNODE ");
				text.Append(NodeName).Append("\r\n");
				text.Append("\tTOPLEVEL ");
				text.Append(IsTopLevelTemplate.ToString()).Append("\r\n");
				text.Append("</CONFIG>\r\n");
				text.Append("<CONTENT>\r\n");
				text.Append(TemplateContent);
				text.Append("</CONTENT>");
				if (!String.IsNullOrEmpty(TemplateOutput))
				{
					text.Append("<OUTPUT>\r\n");
					text.Append(TemplateOutput);
					text.Append("</OUTPUT>");
				}
				return text.ToString();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ItemIndex.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int ItemIndex { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the IsBreaking.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsBreaking { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the IsContinuing.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsContinuing { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the IsReturning.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool IsReturning { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the DbReader.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public IDataReader DbReader { get; set; }

		private List<IDomainEnterpriseObject> _modelContextStack = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ModelContextStack.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public List<IDomainEnterpriseObject> ModelContextStack
		{
			get
			{
				if (_modelContextStack == null)
				{
					_modelContextStack = new List<IDomainEnterpriseObject>();
				}
				return _modelContextStack;
			}
			set
			{
				_modelContextStack = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the StackSize.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int StackSize
		{
			get
			{
				return _modelContextStack.Count;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the PopCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		private int _popCount = 0;
		public int PopCount
		{
			get
			{
				return _popCount;
			}
			set
			{
				_popCount = value;
			}
		}

		private NameObjectCollection _cachedContent = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the CachedContent.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection CachedContent
		{
			get
			{
				if (_cachedContent == null)
				{
					_cachedContent = new NameObjectCollection();
				}
				return _cachedContent;
			}
			set
			{
				_cachedContent = value;
			}
		}
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>Add a template to the list of templates called by this template.</summary>
		/// 
		/// <param name="template">The template call to add.</param>
		///--------------------------------------------------------------------------------
		public void AddToTemplateCalls(ITemplate template)
		{
			if (template.IsWatchTemplate == true) return;
			if (!String.IsNullOrEmpty(template.CategoryName))
			{
				if (TemplateCalls.ContainsKey(template.NodeName + "." + template.CategoryName + "." + template.TemplateName) == false)
				{
					TemplateCalls[template.NodeName + "." + template.CategoryName + "." + template.TemplateName] = 1;
				}
				else
				{
					TemplateCalls[template.NodeName + "." + template.CategoryName + "." + template.TemplateName] += 1;
				}
			}
			else
			{
				if (TemplateCalls.ContainsKey(template.NodeName + "." + template.TemplateName) == false)
				{
					TemplateCalls[template.NodeName + "." + template.TemplateName] = 1;
				}
				else
				{
					TemplateCalls[template.NodeName + "." + template.TemplateName] += 1;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Add a template to the list of templates calling this template.</summary>
		/// 
		/// <param name="template">The template call to add.</param>
		///--------------------------------------------------------------------------------
		public void AddToTemplateCalledBy(ITemplate template)
		{
			if (template.IsWatchTemplate == true) return;
			if (!String.IsNullOrEmpty(template.CategoryName))
			{
				if (TemplateCalledBy.ContainsKey(template.NodeName + "." + template.CategoryName + "." + template.TemplateName) == false)
				{
					TemplateCalledBy[template.NodeName + "." + template.CategoryName + "." + template.TemplateName] = 1;
				}
				else
				{
					TemplateCalledBy[template.NodeName + "." + template.CategoryName + "." + template.TemplateName] += 1;
				}
			}
			else
			{
				if (TemplateCalledBy.ContainsKey(template.NodeName + "." + template.TemplateName) == false)
				{
					TemplateCalledBy[template.NodeName + "." + template.TemplateName] = 1;
				}
				else
				{
					TemplateCalledBy[template.NodeName + "." + template.TemplateName] += 1;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Log an exception associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="ex">The exception to show.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		/// <param name="interpreterType">The interpreter type, such as content or output.</param>
		///--------------------------------------------------------------------------------
		public string LogException(Solution solutionContext, IDomainEnterpriseObject modelContext, System.Exception ex, int lineNumber, InterpreterTypeCode interpreterType = InterpreterTypeCode.None)
		{
			return LogException(solutionContext, modelContext, ex.Message + "\r\n" + ex.StackTrace, lineNumber, interpreterType);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Log an exception associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="messageBody">The main body message to show.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		/// <param name="interpreterType">The interpreter type, such as content or output.</param>
		///--------------------------------------------------------------------------------
		public string LogException(Solution solutionContext, IDomainEnterpriseObject modelContext, string messageBody, int lineNumber, InterpreterTypeCode interpreterType = InterpreterTypeCode.None)
		{
			HasErrors = true;
			if (IsWatchTemplate == true)
			{
				// don't log message detail
				return String.Empty;
			}

			StringBuilder message = new StringBuilder();
			message.Append(DisplayValues.Exception_TemplateProcessing);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_SolutionIntro);
			message.Append(" ");
			message.Append(solutionContext.SolutionName);
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_NodeIntro);
			message.Append(" ");
			message.Append(NodeName);
			message.Append("\r\n");
			if (!String.IsNullOrEmpty(CategoryName))
			{
				message.Append(DisplayValues.Exception_CategoryIntro);
				message.Append(" ");
				message.Append(CategoryName);
				message.Append("\r\n");
			}
			message.Append(DisplayValues.Exception_TemplateIntro);
			message.Append(" ");
			message.Append(TemplateName);
			if (interpreterType == InterpreterTypeCode.Content)
			{
				message.Append("\r\n");
				message.Append(DisplayValues.Exception_ContentLocation);
			}
			else if (interpreterType == InterpreterTypeCode.Output)
			{
				message.Append("\r\n");
				message.Append(DisplayValues.Exception_OutputLocation);
			}
			message.Append("\r\n");
			message.Append(DisplayValues.Exception_LineNumberIntro);
			message.Append(" ");
			message.Append(lineNumber.ToString());
			message.Append("\r\n");
			if (modelContext != null)
			{
				message.Append(DisplayValues.Exception_ModelContextIntro);
				message.Append(" ");
				message.Append(modelContext.GetType().Name);
				message.Append("\r\n");
				message.Append(DisplayValues.Exception_ModelIdIntro);
				message.Append(" ");
				message.Append(modelContext.ID.ToString());
				message.Append("\r\n");
				message.Append(DisplayValues.Exception_ModelNameIntro);
				message.Append(" ");
				message.Append(modelContext.Name);
				message.Append("\r\n");
			}
			message.Append(DisplayValues.Exception_InnerMessageIntro);
			message.Append("\r\n");
			message.Append(messageBody);
			solutionContext.LoggedErrors[TemplateName + NodeName + lineNumber.ToString()] = message.ToString();
			solutionContext.CurrentErrorCount++;
			return message.ToString();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a model context to the model context stack.</summary>
		/// 
		/// <param name="modelContext">The model context to add to the stack.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject PushModelContext(IDomainEnterpriseObject modelContext)
		{
			ModelContextStack.Insert(0, modelContext);
			return ModelContextStack[0];
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method pops a model context off of the model context stack.</summary>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject PopModelContext()
		{
			if (ModelContextStack.Count > 0)
			{
				IDomainEnterpriseObject modelContext = ModelContextStack[0];
				ModelContextStack.Remove(ModelContextStack[0]);
				return modelContext;
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a model context off of the model context stack.</summary>
		/// 
		/// <param name="popCount">Count indicating how far up the stack to get the context,
		/// 0 being the current template context.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(int popCount)
		{
			if (ModelContextStack.Count > 0)
			{
				if (popCount >= ModelContextStack.Count)
				{
					return ModelContextStack[ModelContextStack.Count - 1];
				}
				if (popCount <= 0)
				{
					return ModelContextStack[0];
				}
				return ModelContextStack[popCount];
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the template key, to be used to store the template
		/// in the solution template dictionary.</summary>
		///--------------------------------------------------------------------------------
		public string GetTemplateKey(IDomainEnterpriseObject modelContext, string templateName)
		{
			if (modelContext is Solution)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Solution) + ":" + templateName;
			}
			else if (modelContext is Project)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Project) + ":" + templateName;
			}
			else if (modelContext is SpecificationSource)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SpecificationSource) + ":" + templateName;
			}
			else if (modelContext is Feature)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Feature) + ":" + templateName;
			}
			else if (modelContext is Entity)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Entity) + ":" + templateName;
			}
			else if (modelContext is MoPlus.Interpreter.BLL.Entities.Property)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Property) + ":" + templateName;
			}
			else if (modelContext is PropertyReference)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyReference) + ":" + templateName;
			}
			else if (modelContext is Collection)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Collection) + ":" + templateName;
			}
			else if (modelContext is EntityReference)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.EntityReference) + ":" + templateName;
			}
			else if (modelContext is Method)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Method) + ":" + templateName;
			}
			else if (modelContext is MoPlus.Interpreter.BLL.Entities.Parameter)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Parameter) + ":" + templateName;
			}
			else if (modelContext is MoPlus.Interpreter.BLL.Entities.Index)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Index) + ":" + templateName;
			}
			else if (modelContext is IndexProperty)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.IndexProperty) + ":" + templateName;
			}
			else if (modelContext is Relationship)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Relationship) + ":" + templateName;
			}
			else if (modelContext is RelationshipProperty)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.RelationshipProperty) + ":" + templateName;
			}
			else if (modelContext is AuditProperty)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.AuditProperty) + ":" + templateName;
			}
			else if (modelContext is Workflow)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Workflow) + ":" + templateName;
			}
			else if (modelContext is Stage)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Stage) + ":" + templateName;
			}
			else if (modelContext is StageTransition)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StageTransition) + ":" + templateName;
			}
			else if (modelContext is Step)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Step) + ":" + templateName;
			}
			else if (modelContext is StepTransition)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StepTransition) + ":" + templateName;
			}
			else if (modelContext is StateModel)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateModel) + ":" + templateName;
			}
			else if (modelContext is State)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.State) + ":" + templateName;
			}
			else if (modelContext is StateTransition)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateTransition) + ":" + templateName;
			}
			else if (modelContext is Model)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Model) + ":" + templateName;
			}
			else if (modelContext is ModelObject)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelObject) + ":" + templateName;
			}
			else if (modelContext is ModelProperty)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelProperty) + ":" + templateName;
			}
			else if (modelContext is Enumeration)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Enumeration) + ":" + templateName;
			}
			else if (modelContext is Value)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Value) + ":" + templateName;
			}
			else if (modelContext is ObjectInstance)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ObjectInstance) + ":" + templateName;
			}
			else if (modelContext is PropertyInstance)
			{
				return Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyInstance) + ":" + templateName;
			}
			else if (modelContext is SqlColumn)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlColumn) + ":" + templateName;
			}
			else if (modelContext is SqlDatabase)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlDatabase) + ":" + templateName;
			}
			else if (modelContext is SqlExtendedProperty)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlExtendedProperty) + ":" + templateName;
			}
			else if (modelContext is SqlForeignKey)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKey) + ":" + templateName;
			}
			else if (modelContext is SqlForeignKeyColumn)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKeyColumn) + ":" + templateName;
			}
			else if (modelContext is SqlIndex)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndex) + ":" + templateName;
			}
			else if (modelContext is SqlIndexedColumn)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndexedColumn) + ":" + templateName;
			}
			else if (modelContext is SqlProperty)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlProperty) + ":" + templateName;
			}
			else if (modelContext is SqlTable)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlTable) + ":" + templateName;
			}
			else if (modelContext is MoPlus.Interpreter.BLL.Specifications.XmlAttribute)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlAttribute) + ":" + templateName;
			}
			else if (modelContext is MoPlus.Interpreter.BLL.Specifications.XmlDocument)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlDocument) + ":" + templateName;
			}
			else if (modelContext is MoPlus.Interpreter.BLL.Specifications.XmlNode)
			{
				return Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlNode) + ":" + templateName;
			}
			return String.Empty;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the current model context for the item.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to get current model context.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetTemplateModelContext(IDomainEnterpriseObject parentModelContext, string modelContextName = "")
		{
			bool isValidContext;
			if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.AuditProperty))
			{
				return AuditProperty.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Collection))
			{
				return Collection.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Entity))
			{
				return Entity.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.EntityReference))
			{
				return EntityReference.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Feature))
			{
				return Feature.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Index))
			{
				return MoPlus.Interpreter.BLL.Entities.Index.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.IndexProperty))
			{
				return IndexProperty.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Method))
			{
				return Method.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Parameter))
			{
				return MoPlus.Interpreter.BLL.Entities.Parameter.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Project))
			{
				return Project.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Property))
			{
				return MoPlus.Interpreter.BLL.Entities.Property.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyReference))
			{
				return PropertyReference.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Relationship))
			{
				return Relationship.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.RelationshipProperty))
			{
				return RelationshipProperty.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Solution))
			{
				return Solution.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Workflow))
			{
				return Workflow.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Stage))
			{
				return Stage.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StageTransition))
			{
				return StageTransition.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Step))
			{
				return Step.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StepTransition))
			{
				return StepTransition.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateModel))
			{
				return StateModel.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.State))
			{
				return State.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.StateTransition))
			{
				return StateTransition.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Model))
			{
				return Model.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelObject))
			{
				return ModelObject.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ModelProperty))
			{
				return ModelProperty.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Enumeration))
			{
				return Enumeration.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Value))
			{
				return Value.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.ObjectInstance))
			{
				return ObjectInstance.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.PropertyInstance))
			{
				return PropertyInstance.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlColumn))
			{
				return SqlColumn.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlDatabase))
			{
				return SqlDatabase.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlExtendedProperty))
			{
				return SqlExtendedProperty.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKey))
			{
				return SqlForeignKey.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlForeignKeyColumn))
			{
				return SqlForeignKeyColumn.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndex))
			{
				return SqlIndex.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlIndexedColumn))
			{
				return SqlIndexedColumn.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlProperty))
			{
				return SqlProperty.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SqlTable))
			{
				return SqlTable.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlAttribute))
			{
				return MoPlus.Interpreter.BLL.Specifications.XmlAttribute.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlDocument))
			{
				return MoPlus.Interpreter.BLL.Specifications.XmlDocument.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.XmlNode))
			{
				return MoPlus.Interpreter.BLL.Specifications.XmlNode.GetModelContext(Solution, parentModelContext, out isValidContext);
			}
			else if (NodeName == Enum.GetName(typeof(SpecModelContextTypeCode), SpecModelContextTypeCode.SpecificationSource))
			{
				if (parentModelContext is XmlSource)
				{
					return XmlSource.GetModelContext(Solution, parentModelContext, out isValidContext);
				}
				else if (parentModelContext is DatabaseSource)
				{
					return DatabaseSource.GetModelContext(Solution, parentModelContext, out isValidContext);
				}
				else
				{
					return Solution.GetModelContext(Solution, parentModelContext, out isValidContext);
				}
			}
			else if (!String.IsNullOrEmpty(modelContextName) && Solution.ModelObjectNames.AllKeys.Contains(modelContextName) == true)
			{
				return ObjectInstance.GetModelContext(Solution, modelContextName, parentModelContext, out isValidContext);
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads the template file data into this instance.</summary>
		/// 
		/// <param name="includeContentAndOutput">Flag indicating if content and output should
		/// be loaded.</param>
		///--------------------------------------------------------------------------------
		public void LoadTemplateFileData(bool includeContentAndOutput = true)
		{
			try
			{
				if (File.Exists(FilePath) == false)
					throw new FileNotFoundException(DisplayValues.Template_MissingFile);
				string templateText = FileHelper.GetText(FilePath);
				int configBeginIndex = templateText.IndexOf("<CONFIG>");
				int configEndIndex = templateText.IndexOf("</CONFIG>");

				// process configuration information
				if (configBeginIndex < 0 || configBeginIndex >= configEndIndex)
				{
					throw new ApplicationException(DisplayValues.Template_BadConfiguration);
				}
				else
				{
					ConfigurationType getMode = ConfigurationType.None;
					foreach (string word in templateText.Substring(configBeginIndex + 8, configEndIndex - configBeginIndex - 8).GetWords())
					{
						switch (getMode)
						{
							case ConfigurationType.Name:
								TemplateName = word;
								getMode = ConfigurationType.None;
								break;
							case ConfigurationType.Category:
								CategoryName = word;
								getMode = ConfigurationType.None;
								break;
							case ConfigurationType.Node:
								NodeName = word;
								getMode = ConfigurationType.None;
								break;
							case ConfigurationType.TopLevel:
								if (word.ToLower() == "true")
								{
									IsTopLevelTemplate = true;
								}
								else
								{
									IsTopLevelTemplate = false;
								}
								getMode = ConfigurationType.None;
								break;
							default:
								switch (word)
								{
									case "NAME":
										getMode = ConfigurationType.Name;
										break;
									case "CATEGORY":
										getMode = ConfigurationType.Category;
										break;
									case "NODE":
										getMode = ConfigurationType.Node;
										break;
									case "TOPLEVEL":
										getMode = ConfigurationType.TopLevel;
										break;
									default:
										break;
								}
								break;
						}
					}
					if (String.IsNullOrEmpty(TemplateName) || String.IsNullOrEmpty(NodeName))
					{
						throw new ApplicationException(DisplayValues.Template_BadConfiguration);
					}
				}

				if (includeContentAndOutput == true)
				{
					int contentBeginIndex = templateText.IndexOf("<CONTENT>");
					int contentEndIndex = templateText.LastIndexOf("</CONTENT>");
					int outputBeginIndex = templateText.LastIndexOf("<OUTPUT>");
					int outputEndIndex = templateText.LastIndexOf("</OUTPUT>");

					// process content information
					if (contentBeginIndex < 0 || (contentBeginIndex + 9 >= contentEndIndex))
					{
						throw new ApplicationException(DisplayValues.Template_BadContent);
					}
					else
					{
						TemplateContent = templateText.Substring(contentBeginIndex + 9, contentEndIndex - contentBeginIndex - 9);
					}

					// process output information (missing output section is OK)
					if (outputBeginIndex > 0 && (outputBeginIndex + 8 < outputEndIndex))
					{
						TemplateOutput = templateText.Substring(outputBeginIndex + 8, outputEndIndex - outputBeginIndex - 8);
					}
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
			    if (Solution != null)
			    {
			        Solution.ShowIssue(ex.Message, DisplayValues.Exception_TemplateTitle, true);
			    }
			    throw;
			}
		}
		#endregion "Methods"
	}
}