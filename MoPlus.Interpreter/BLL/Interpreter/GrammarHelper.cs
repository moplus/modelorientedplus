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
using System.Data;
using System.IO;
using System.Text;
using MoPlus.Interpreter.BLL.Solutions;
using System.Collections.Generic;
using System.Linq;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is for getting data convention information.  These conventions may
	/// eventually be stored in a database and be customizable.</summary>
	///--------------------------------------------------------------------------------
	public static class GrammarHelper
	{
		#region "Fields and Properties"
		public static readonly int MIN_COMPLETION_WORD_SIZE = 4;
		private static NameObjectCollection _languageKeyTerms = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of language terms.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection LanguageKeyTerms
		{
			get
			{
				if (_languageKeyTerms == null)
				{
					_languageKeyTerms = new NameObjectCollection();
					_languageKeyTerms[LanguageTerms.AddTerm] = LanguageTerms.AddTerm;
					_languageKeyTerms[LanguageTerms.AscTerm] = LanguageTerms.AscTerm;
					_languageKeyTerms[LanguageTerms.BreakTerm] = LanguageTerms.BreakTerm;
					_languageKeyTerms[LanguageTerms.CaseTerm] = LanguageTerms.CaseTerm;
					_languageKeyTerms[LanguageTerms.ClearTerm] = LanguageTerms.ClearTerm;
					_languageKeyTerms[LanguageTerms.CloseTag] = LanguageTerms.CloseTag;
					_languageKeyTerms[LanguageTerms.ColumnMethod] = LanguageTerms.ColumnMethod;
					_languageKeyTerms[LanguageTerms.DebugTerm] = LanguageTerms.DebugTerm;
					_languageKeyTerms[LanguageTerms.DefaultTerm] = LanguageTerms.DefaultTerm;
					_languageKeyTerms[LanguageTerms.DeleteTerm] = LanguageTerms.DeleteTerm;
					_languageKeyTerms[LanguageTerms.DescTerm] = LanguageTerms.DescTerm;
					_languageKeyTerms[LanguageTerms.ElseTerm] = LanguageTerms.ElseTerm;
					_languageKeyTerms[LanguageTerms.EvalOpenTag] = LanguageTerms.EvalOpenTag;
					_languageKeyTerms[LanguageTerms.ExtendingEntitiesCollection] = LanguageTerms.ExtendingEntitiesCollection;
					_languageKeyTerms[LanguageTerms.FileExistsMethod] = LanguageTerms.FileExistsMethod;
					_languageKeyTerms[LanguageTerms.FileMethod] = LanguageTerms.FileMethod;
					_languageKeyTerms[LanguageTerms.FindAllMethod] = LanguageTerms.FindAllMethod;
					_languageKeyTerms[LanguageTerms.FindMethod] = LanguageTerms.FindMethod;
					_languageKeyTerms[LanguageTerms.ForeachTerm] = LanguageTerms.ForeachTerm;
					_languageKeyTerms[LanguageTerms.ForfilesTerm] = LanguageTerms.ForfilesTerm;
					_languageKeyTerms[LanguageTerms.FromTerm] = LanguageTerms.FromTerm;
					_languageKeyTerms[LanguageTerms.GetBaseAndEntitiesCollection] = LanguageTerms.GetBaseAndEntitiesCollection;
					_languageKeyTerms[LanguageTerms.GetEntityAndBasesCollection] = LanguageTerms.GetEntityAndBasesCollection;
					_languageKeyTerms[LanguageTerms.HasPropertyNamed] = LanguageTerms.HasPropertyNamed;
					_languageKeyTerms[LanguageTerms.IfTerm] = LanguageTerms.IfTerm;
					_languageKeyTerms[LanguageTerms.IgnoredAreaEndMethod] = LanguageTerms.IgnoredAreaEndMethod;
					_languageKeyTerms[LanguageTerms.IgnoredAreaStartMethod] = LanguageTerms.IgnoredAreaStartMethod;
					_languageKeyTerms[LanguageTerms.InsertTerm] = LanguageTerms.InsertTerm;
					_languageKeyTerms[LanguageTerms.InTerm] = LanguageTerms.InTerm;
					_languageKeyTerms[LanguageTerms.IsRelatedToProperty] = LanguageTerms.IsRelatedToProperty;
					_languageKeyTerms[LanguageTerms.ItemFileProperty] = LanguageTerms.ItemFileProperty;
					_languageKeyTerms[LanguageTerms.ItemIndexProperty] = LanguageTerms.ItemIndexProperty;
					_languageKeyTerms[LanguageTerms.ItemPathProperty] = LanguageTerms.ItemPathProperty;
					//_languageKeyTerms[LanguageTerms.LibraryDirectoryProperty] = LanguageTerms.LibraryDirectoryProperty;
					_languageKeyTerms[LanguageTerms.LimitTerm] = LanguageTerms.LimitTerm;
					_languageKeyTerms[LanguageTerms.LogMethod] = LanguageTerms.LogMethod;
					_languageKeyTerms[LanguageTerms.LogTerm] = LanguageTerms.LogTerm;
					_languageKeyTerms[LanguageTerms.NowMethod] = LanguageTerms.NowMethod;
					_languageKeyTerms[LanguageTerms.OutputOpenTag] = LanguageTerms.OutputOpenTag;
					_languageKeyTerms[LanguageTerms.ParamTerm] = LanguageTerms.ParamTerm;
					_languageKeyTerms[LanguageTerms.PathProperty] = LanguageTerms.PathProperty;
					_languageKeyTerms[LanguageTerms.PathRelationships] = LanguageTerms.PathRelationships;
					_languageKeyTerms[LanguageTerms.ProgressTerm] = LanguageTerms.ProgressTerm;
					_languageKeyTerms[LanguageTerms.PropOpenTag] = LanguageTerms.PropOpenTag;
					_languageKeyTerms[LanguageTerms.ProtectedAreaEndMethod] = LanguageTerms.ProtectedAreaEndMethod;
					_languageKeyTerms[LanguageTerms.ProtectedAreaStartMethod] = LanguageTerms.ProtectedAreaStartMethod;
					_languageKeyTerms[LanguageTerms.RecordItem] = LanguageTerms.RecordItem;
					_languageKeyTerms[LanguageTerms.RemoveTerm] = LanguageTerms.RemoveTerm;
					_languageKeyTerms[LanguageTerms.ReturnTerm] = LanguageTerms.ReturnTerm;
					_languageKeyTerms[LanguageTerms.SortTerm] = LanguageTerms.SortTerm;
					_languageKeyTerms[LanguageTerms.StringCamelCase] = LanguageTerms.StringCamelCase;
					_languageKeyTerms[LanguageTerms.StringCapitalCase] = LanguageTerms.StringCapitalCase;
					_languageKeyTerms[LanguageTerms.StringContains] = LanguageTerms.StringContains;
					_languageKeyTerms[LanguageTerms.StringEndsWith] = LanguageTerms.StringEndsWith;
					_languageKeyTerms[LanguageTerms.StringFilter] = LanguageTerms.StringFilter;
					_languageKeyTerms[LanguageTerms.StringFilterIgnored] = LanguageTerms.StringFilterIgnored;
					_languageKeyTerms[LanguageTerms.StringFilterProtected] = LanguageTerms.StringFilterProtected;
					_languageKeyTerms[LanguageTerms.StringIndexOf] = LanguageTerms.StringIndexOf;
					_languageKeyTerms[LanguageTerms.StringLength] = LanguageTerms.StringLength;
					_languageKeyTerms[LanguageTerms.StringRegexIsMatch] = LanguageTerms.StringRegexIsMatch;
					_languageKeyTerms[LanguageTerms.StringRegexReplace] = LanguageTerms.StringRegexReplace;
					_languageKeyTerms[LanguageTerms.StringReplace] = LanguageTerms.StringReplace;
					_languageKeyTerms[LanguageTerms.StringStartsWith] = LanguageTerms.StringStartsWith;
					_languageKeyTerms[LanguageTerms.StringSubstring] = LanguageTerms.StringSubstring;
					_languageKeyTerms[LanguageTerms.StringToLower] = LanguageTerms.StringToLower;
					_languageKeyTerms[LanguageTerms.StringToUpper] = LanguageTerms.StringToUpper;
					_languageKeyTerms[LanguageTerms.StringTrim] = LanguageTerms.StringTrim;
					_languageKeyTerms[LanguageTerms.StringTrimEnd] = LanguageTerms.StringTrimEnd;
					_languageKeyTerms[LanguageTerms.StringTrimStart] = LanguageTerms.StringTrimStart;
					_languageKeyTerms[LanguageTerms.StringUnderscoreCase] = LanguageTerms.StringUnderscoreCase;
					_languageKeyTerms[LanguageTerms.SwitchTerm] = LanguageTerms.SwitchTerm;
					_languageKeyTerms[LanguageTerms.TabMethod] = LanguageTerms.TabMethod;
					_languageKeyTerms[LanguageTerms.TabStringMethod] = LanguageTerms.TabStringMethod;
					_languageKeyTerms[LanguageTerms.TemplateProperty] = LanguageTerms.TemplateProperty;
					_languageKeyTerms[LanguageTerms.TextOpenTag] = LanguageTerms.TextOpenTag;
					_languageKeyTerms[LanguageTerms.TextProperty] = LanguageTerms.TextProperty;
					_languageKeyTerms[LanguageTerms.TraceTerm] = LanguageTerms.TraceTerm;
					_languageKeyTerms[LanguageTerms.UpdateTerm] = LanguageTerms.UpdateTerm;
					_languageKeyTerms[LanguageTerms.UseIgnoredAreasMethod] = LanguageTerms.UseIgnoredAreasMethod;
					_languageKeyTerms[LanguageTerms.UseProtectedAreasMethod] = LanguageTerms.UseProtectedAreasMethod;
					_languageKeyTerms[LanguageTerms.UserMethod] = LanguageTerms.UserMethod;
					_languageKeyTerms[LanguageTerms.UseTabsMethod] = LanguageTerms.UseTabsMethod;
					_languageKeyTerms[LanguageTerms.VarTerm] = LanguageTerms.VarTerm;
					_languageKeyTerms[LanguageTerms.WhereTerm] = LanguageTerms.WhereTerm;
					_languageKeyTerms[LanguageTerms.WhileTerm] = LanguageTerms.WhileTerm;
					_languageKeyTerms[LanguageTerms.WithTerm] = LanguageTerms.WithTerm;
				}
				return _languageKeyTerms;
			}
		}

		private static NameObjectCollection _modelContextTypes = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of model context types.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection ModelContextTypes
		{
			get
			{
				if (_modelContextTypes == null)
				{
					_modelContextTypes = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(ModelContextTypeCode)))
					{
						if (key != "None")
						{
							_modelContextTypes[key] = key;
						}
					}
				}
				return _modelContextTypes;
			}
		}

		private static NameObjectCollection _otherModelContextTypes = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of other model context types.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection OtherModelContextTypes
		{
			get
			{
				if (_otherModelContextTypes == null)
				{
					_otherModelContextTypes = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(OtherModelContextTypeCode)))
					{
						if (key != "None")
						{
							_otherModelContextTypes[key] = key;
						}
					}
				}
				return _otherModelContextTypes;
			}
		}

		private static NameObjectCollection _specModelContextTypes = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of spec model context types.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection SpecModelContextTypes
		{
			get
			{
				if (_specModelContextTypes == null)
				{
					_specModelContextTypes = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(SpecModelContextTypeCode)))
					{
						if (key != "None")
						{
							_specModelContextTypes[key] = key;
						}
					}
				}
				return _specModelContextTypes;
			}
		}

		private static NameObjectCollection _currentItemTypes = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of current item types.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection CurrentItemTypes
		{
			get
			{
				if (_currentItemTypes == null)
				{
					_currentItemTypes = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(CurrentItemTypeCode)))
					{
						if (key != "None")
						{
							_currentItemTypes[key] = key;
						}
					}
				}
				return _currentItemTypes;
			}
		}

		private static NameObjectCollection _specCurrentItemTypes = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of spec current item types.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection SpecCurrentItemTypes
		{
			get
			{
				if (_specCurrentItemTypes == null)
				{
					_specCurrentItemTypes = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(SpecCurrentItemTypeCode)))
					{
						if (key != "None")
						{
							_specCurrentItemTypes[key] = key;
						}
					}
				}
				return _specCurrentItemTypes;
			}
		}

		private static NameObjectCollection _assignableProperties = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of assignable properties.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection AssignableProperties
		{
			get
			{
				if (_assignableProperties == null)
				{
					_assignableProperties = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(AssignablePropertyCode)))
					{
						if (key != "None")
						{
							_assignableProperties[key] = key;
						}
					}
				}
				return _assignableProperties;
			}
		}

		private static NameObjectCollection _readOnlyProperties = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of read only properties.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection ReadOnlyProperties
		{
			get
			{
				if (_readOnlyProperties == null)
				{
					_readOnlyProperties = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(ReadOnlyPropertyCode)))
					{
						if (key != "None")
						{
							_readOnlyProperties[key] = key;
						}
					}
				}
				return _readOnlyProperties;
			}
		}

		private static NameObjectCollection _specProperties = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the set of spec properties.</summary>
		///--------------------------------------------------------------------------------
		public static NameObjectCollection SpecProperties
		{
			get
			{
				if (_specProperties == null)
				{
					_specProperties = new NameObjectCollection();
					foreach (string key in Enum.GetNames(typeof(SpecPropertyCode)))
					{
						if (key != "None")
						{
							_specProperties[key] = key;
						}
					}
				}
				return _specProperties;
			}
		}

		private static List<string> _codeCompletionKeywords = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets CodeCompletionKeywords.</summary>
		///--------------------------------------------------------------------------------
		public static List<string> CodeCompletionKeywords
		{
			get
			{
				if (_codeCompletionKeywords == null)
				{
					_codeCompletionKeywords = new List<string>();
					foreach (string key in LanguageKeyTerms.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionKeywords.Add(key);
						}
					}
					foreach (string key in ModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionKeywords.Add(key);
						}
					}
					foreach (string key in OtherModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionKeywords.Add(key);
						}
					}
					foreach (string key in CurrentItemTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionKeywords.Add(key);
						}
					}
					foreach (string key in AssignableProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionKeywords.Add(key);
						}
					}
					foreach (string key in ReadOnlyProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionKeywords.Add(key);
						}
					}
					_codeCompletionKeywords.Sort();
				}
				return _codeCompletionKeywords;
			}
		}

		private static List<string> _codeCompletionPropertiesAndMethods = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets CodeCompletionPropertiesAndMethods.</summary>
		///--------------------------------------------------------------------------------
		public static List<string> CodeCompletionPropertiesAndMethods
		{
			get
			{
				if (_codeCompletionPropertiesAndMethods == null)
				{
					_codeCompletionPropertiesAndMethods = new List<string>();
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.ExtendingEntitiesCollection);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.FileExistsMethod);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.FileMethod);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.FindAllMethod);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.FindMethod);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.GetBaseAndEntitiesCollection);
					_codeCompletionPropertiesAndMethods.Add( LanguageTerms.GetEntityAndBasesCollection);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.HasPropertyNamed);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.IsRelatedToProperty);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.PathRelationships);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.SortTerm);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringCamelCase);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringCapitalCase);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringContains);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringEndsWith);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringFilter);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringFilterIgnored);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringFilterProtected);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringIndexOf);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringLength);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringRegexIsMatch);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringRegexReplace);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringReplace);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringStartsWith);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringSubstring);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringToLower);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringToUpper);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringTrim);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringTrimEnd);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringTrimStart);
					_codeCompletionPropertiesAndMethods.Add(LanguageTerms.StringUnderscoreCase);
					foreach (string key in ModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in OtherModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in AssignableProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in ReadOnlyProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_codeCompletionPropertiesAndMethods.Add(key);
						}
					}
					_codeCompletionPropertiesAndMethods.Sort();
				}
				return _codeCompletionPropertiesAndMethods;
			}
		}

		private static List<string> _specCompletionKeywords = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecCompletionKeywords.</summary>
		///--------------------------------------------------------------------------------
		public static List<string> SpecCompletionKeywords
		{
			get
			{
				if (_specCompletionKeywords == null)
				{
					_specCompletionKeywords = new List<string>();
					foreach (string key in LanguageKeyTerms.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in ModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in SpecModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in OtherModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in CurrentItemTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in SpecCurrentItemTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in AssignableProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in SpecProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					foreach (string key in ReadOnlyProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionKeywords.Add(key);
						}
					}
					_specCompletionKeywords.Sort();
				}
				return _specCompletionKeywords;
			}
		}

		private static List<string> _specCompletionPropertiesAndMethods = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecCompletionPropertiesAndMethods.</summary>
		///--------------------------------------------------------------------------------
		public static List<string> SpecCompletionPropertiesAndMethods
		{
			get
			{
				if (_specCompletionPropertiesAndMethods == null)
				{
					_specCompletionPropertiesAndMethods = new List<string>();
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.ExtendingEntitiesCollection);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.FileExistsMethod);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.FileMethod);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.FindAllMethod);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.FindMethod);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.GetBaseAndEntitiesCollection);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.GetEntityAndBasesCollection);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.HasPropertyNamed);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.IsRelatedToProperty);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.PathRelationships);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.SortTerm);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringCamelCase);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringCapitalCase);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringContains);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringEndsWith);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringFilter);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringFilterIgnored);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringFilterProtected);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringIndexOf);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringLength);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringRegexIsMatch);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringRegexReplace);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringReplace);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringStartsWith);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringSubstring);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringToLower);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringToUpper);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringTrim);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringTrimEnd);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringTrimStart);
					_specCompletionPropertiesAndMethods.Add(LanguageTerms.StringUnderscoreCase);
					foreach (string key in ModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in SpecModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in OtherModelContextTypes.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in AssignableProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in SpecProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionPropertiesAndMethods.Add(key);
						}
					}
					foreach (string key in ReadOnlyProperties.AllKeys)
					{
						if (key.Length >= MIN_COMPLETION_WORD_SIZE)
						{
							_specCompletionPropertiesAndMethods.Add(key);
						}
					}
					_specCompletionPropertiesAndMethods.Sort();
				}
				return _specCompletionPropertiesAndMethods;
			}
		}
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with a word in the language.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsLanguageWord(string word)
		{
			return LanguageKeyTerms[word].GetString() == word;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with a model context word.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsModelContextWord(string word)
		{
			if (ModelContextTypes[word].GetString() == word)
			{
				return true;
			}
			if (OtherModelContextTypes[word].GetString() == word)
			{
				return true;
			}
			if (SpecModelContextTypes[word].GetString() == word)
			{
				return true;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with a current item word.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsCurrentItemWord(string word)
		{
			if (CurrentItemTypes[word].GetString() == word)
			{
				return true;
			}
			if (SpecCurrentItemTypes[word].GetString() == word)
			{
				return true;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with an assignable property word.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsAssignablePropertyWord(string word)
		{
			return AssignableProperties[word].GetString() == word;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with a read only property word.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsReadOnlyPropertyWord(string word)
		{
			return ReadOnlyProperties[word].GetString() == word;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with a spec property word.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsSpecPropertyWord(string word)
		{
			return SpecProperties[word].GetString() == word;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if the input word clashes with a reserved word.</summary>
		/// 
		/// <param name="word">Input word for keyword match.</param>
		///--------------------------------------------------------------------------------
		public static bool IsReservedWord(string word)
		{
			return IsLanguageWord(word) || IsModelContextWord(word) || IsCurrentItemWord(word) || IsAssignablePropertyWord(word) || IsReadOnlyPropertyWord(word) || IsSpecPropertyWord(word);
		}
		#endregion "Methods"
	}
}