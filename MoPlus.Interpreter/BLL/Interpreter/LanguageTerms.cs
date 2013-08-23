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

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class defines language terms for templates and code generation.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/28/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public static class LanguageTerms
	{
		public const string TextOpenTag = "<%%-";
		public const string EvalOpenTag = "<%%:";
		public const string OutputOpenTag = "<%%>";
		public const string PropOpenTag = "<%%=";
		public const string CloseTag = "%%>";
		public const string TemplateProperty = "Template";
		public const string ItemIndexProperty = "ItemIndex";
		public const string TabMethod = "TAB";
		public const string UseTabsMethod = "USETABS";
		public const string TabStringMethod = "TABSTRING";
		public const string UseProtectedAreasMethod = "USEPROTECTEDAREAS";
		public const string ProtectedAreaStartMethod = "PROTECTEDAREASTART";
		public const string ProtectedAreaEndMethod = "PROTECTEDAREAEND";
		public const string UseIgnoredAreasMethod = "USEIGNOREDAREAS";
		public const string IgnoredAreaStartMethod = "IGNOREDAREASTART";
		public const string IgnoredAreaEndMethod = "IGNOREDAREAEND";
		public const string NowMethod = "NOW";
		public const string UserMethod = "USER";
		public const string FindMethod = "Find";
		public const string FindAllMethod = "FindAll";
		public const string ColumnMethod = "Column";
		public const string FileMethod = "File";
		public const string LogMethod = "LogValue";
		public const string HasPropertyNamed = "HasPropertyNamed";
		public const string FileExistsMethod = "FileExists";
		public const string TextProperty = "Text";
		public const string PathProperty = "Path";
		public const string ItemFileProperty = "ItemFile";
		public const string ItemPathProperty = "ItemPath";
		//public const string LibraryDirectoryProperty = "LibraryDirectory";
		public const string IsRelatedToProperty = "IsRelatedToProperty";
		public const string RecordItem = "Record";
		public const string StringSubstring = "Substring";
		public const string StringIndexOf = "IndexOf";
		public const string StringReplace = "Replace";
		public const string StringToLower = "ToLower";
		public const string StringToUpper = "ToUpper";
		public const string StringStartsWith = "StartsWith";
		public const string StringEndsWith = "EndsWith";
		public const string StringContains = "Contains";
		public const string StringLength = "Length";
		public const string StringCamelCase = "CamelCase";
		public const string StringCapitalCase = "CapitalCase";
		public const string StringCapitalWordCase = "CapitalWordCase";
		public const string StringUnderscoreCase = "UnderscoreCase";
		public const string StringFilter = "Filter";
		public const string StringFilterProtected = "FilterProtected";
		public const string StringFilterIgnored = "FilterIgnored";
		public const string StringTrim = "Trim";
		public const string StringTrimStart = "TrimStart";
		public const string StringTrimEnd = "TrimEnd";
		public const string StringRegexReplace = "RegexReplace";
		public const string StringRegexIsMatch = "RegexIsMatch";
		public const string GetEntityAndBasesCollection = "EntityAndBaseEntities";
		public const string GetBaseAndEntitiesCollection = "BaseAndEntityEntities";
		public const string ExtendingEntitiesCollection = "ExtendingEntities";
		public const string PathRelationships = "PathRelationships";
		public const string VarTerm = "var";
		public const string ParamTerm = "param";
		public const string IfTerm = "if";
		public const string ElseTerm = "else";
		public const string BreakTerm = "break";
		public const string ClearTerm = "clear";
		public const string ReturnTerm = "return";
		public const string SwitchTerm = "switch";
		public const string DefaultTerm = "default";
		public const string CaseTerm = "case";
		public const string ForeachTerm = "foreach";
		public const string InTerm = "in";
		public const string WhereTerm = "where";
		public const string LimitTerm = "limit";
		public const string SortTerm = "sort";
		public const string AscTerm = "asc";
		public const string DescTerm = "desc";
		public const string WhileTerm = "while";
		public const string DebugTerm = "debug";
		public const string TraceTerm = "trace";
		public const string LogTerm = "log";
		public const string WithTerm = "with";
		public const string FromTerm = "from";
		public const string ProgressTerm = "progress";
		public const string UpdateTerm = "update";
		public const string AddTerm = "add";
		public const string DeleteTerm = "delete";
		public const string RemoveTerm = "remove";
		public const string InsertTerm = "insert";
		public const string ForfilesTerm = "forfiles";
		public const string ThisTerm = "this";

	}
}