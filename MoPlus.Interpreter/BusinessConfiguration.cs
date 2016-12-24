/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using MoPlus.Common;
using MoPlus.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Specialized;
using MoPlus.Interpreter.Properties;
using MoPlus.Interpreter.BLL.Config;

namespace MoPlus.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class manages overall business configuration values.</summary>
	///--------------------------------------------------------------------------------
	public class BusinessConfiguration : IEnterpriseBusinessConfiguration
	{
		#region "Constants"
		// This requires deployment of Microsoft Enterprise Library 4.1, with an exception policy
		// of "Library Layer Policy" defined.
		public const string BUSINESS_EXCEPTION_POLICY = "Business Logic Layer Policy";

		// the company name
		public const string COMPANY_NAME = "Intelligent Coding Solutions, LLC";

		// the company short name
		public const string COMPANY_SHORT_NAME = "InCode";

		// the product name
		public const string PRODUCT_NAME = "Mo+ Solution Builder";

		// the product version
		public const string PRODUCT_VERSION = "0.7";
		#endregion "Constants"

		#region "Fields and Properties"

		private static BLL.Solutions.Project _currentProject = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentProject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static BLL.Solutions.Project CurrentProject
		{
			get
			{
				return _currentProject;
			}
			set
			{
				_currentProject = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentSpecificationSource.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static BLL.Solutions.SpecificationSource CurrentSpecificationSource { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets UseTemplateCache.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static bool UseTemplateCache
		{
			get
			{
				return Settings.Default.UseTemplateCache;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateCacheMaxContentSize.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static int TemplateCacheMaxContentSize
		{
			get
			{
				return Settings.Default.TemplateCacheMaxContentSize;
			}
		}

		private static EnterpriseDataObjectList<RecentSolution> _recentSolutionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the library directory.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static EnterpriseDataObjectList<RecentSolution> RecentSolutionList
		{
			get
			{
				if (_recentSolutionList == null)
				{
					_recentSolutionList = new EnterpriseDataObjectList<RecentSolution>();
					if (Settings.Default.RecentSolutionList != null && Settings.Default.RecentSolutionList.Count > 0)
					{
						foreach (string loopSolution in Settings.Default.RecentSolutionList)
						{
							string[] names = loopSolution.Split(',');
							if (names.Length > 1)
							{
								RecentSolution solution = new RecentSolution();
								solution.RecentSolutionName = names[0];
								solution.RecentSolutionLocation = names[1];
								solution.LastAccessedDate = DateTime.Parse(names[2]);
								_recentSolutionList.Add(solution);
							}
						}
					}
				}
				return _recentSolutionList;
			}
			set
			{
				_recentSolutionList = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets an EncryptionKey.</summary>
		/// 
		/// <remarks>This key is not to be used for highly sensitive operations, as the key
		/// itself is not encrypted or securely stored.</remarks>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static string EncryptionKey
		{
			get
			{
				return Settings.Default.EncryptionKey;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database connection string.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DbConnectionString
		{
			get
			{
				return Settings.Default.DbConnectionString;
			}
			set
			{
				Settings.Default.DbConnectionString = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database command timeout.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int DbCommandTimeout
		{
			get
			{
				return Settings.Default.DbCommandTimeout;
			}
			set
			{
				Settings.Default.DbCommandTimeout = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database (search) page size.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int DbPageSize
		{
			get
			{
				return Settings.Default.DbPageSize;
			}
			set
			{
				Settings.Default.DbPageSize = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the database (search) maximum list size.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int DbMaximumListSize
		{
			get
			{
				return Settings.Default.DbMaximumListSize;
			}
			set
			{
				Settings.Default.DbMaximumListSize = value;
				Settings.Default.Save();
			}
		}

		/// TODO: the app settings should be moved up a layer
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsWindowMaximized.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static bool IsWindowMaximized
		{
			get
			{
				return Settings.Default.IsWindowMaximized;
			}
			set
			{
				Settings.Default.IsWindowMaximized = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets WindowWidth.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static double WindowWidth
		{
			get
			{
				return Settings.Default.WindowWidth;
			}
			set
			{
				Settings.Default.WindowWidth = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets WindowHeight.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static double WindowHeight
		{
			get
			{
				return Settings.Default.WindowHeight;
			}
			set
			{
				Settings.Default.WindowHeight = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets WindowX.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static double WindowX
		{
			get
			{
				return Settings.Default.WindowX;
			}
			set
			{
				Settings.Default.WindowX = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets WindowY.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static double WindowY
		{
			get
			{
				return Settings.Default.WindowY;
			}
			set
			{
				Settings.Default.WindowY = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ControlSize.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static float ControlSize
		{
			get
			{
				return Settings.Default.ControlSize;
			}
			set
			{
				Settings.Default.ControlSize = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CodeFontSize.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static int CodeFontSize
		{
			get
			{
				return Settings.Default.CodeFontSize;
			}
			set
			{
				Settings.Default.CodeFontSize = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SolutionBuilderPanel.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static int SolutionBuilderPanel
		{
			get
			{
				return Settings.Default.SolutionBuilderPanel;
			}
			set
			{
				Settings.Default.SolutionBuilderPanel = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SolutionBuilderSplitterDistance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static int SolutionBuilderSplitterDistance
		{
			get
			{
				return Settings.Default.SolutionBuilderSplitterDistance;
			}
			set
			{
				Settings.Default.SolutionBuilderSplitterDistance = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ModelSplitterDistance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static int ModelSplitterDistance
		{
			get
			{
				return Settings.Default.ModelSplitterDistance;
			}
			set
			{
				Settings.Default.ModelSplitterDistance = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets MaxOutputSizeInBytes.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static long MaxOutputSizeInBytes
		{
			get
			{
				return Settings.Default.MaxOutputSizeInBytes;
			}
			set
			{
				Settings.Default.MaxOutputSizeInBytes = value;
				Settings.Default.Save();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets MaxErrorsBeforeAbort.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public static int MaxErrorsBeforeAbort
		{
			get
			{
				return Settings.Default.MaxErrorsBeforeAbort;
			}
			set
			{
				Settings.Default.MaxErrorsBeforeAbort = value;
				Settings.Default.Save();
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>Execute the business logic layer exception policy.</summary>
		///
		/// <param name="ex">The exception to handle.</param>
		///
		/// <returns>True if exception is handled.</returns>
		///--------------------------------------------------------------------------------
		public static bool HandleException(Exception ex)
		{
			return false;
			// don't handle or log exceptions for now...
			//return ExceptionHandler.HandleException(ex, BUSINESS_EXCEPTION_POLICY);
		}

		///--------------------------------------------------------------------------------
		/// <summary>Save recent solutions.</summary>
		///--------------------------------------------------------------------------------
		public static void SaveRecentSolutions()
		{
			StringCollection solutions = new StringCollection();
			foreach (RecentSolution loopSolution in RecentSolutionList)
			{
				solutions.Add(loopSolution.RecentSolutionName + "," + loopSolution.RecentSolutionLocation + "," + loopSolution.LastAccessedDate.ToString());
			}
			Settings.Default.RecentSolutionList = solutions;
			Settings.Default.Save();
		}

		#endregion "Methods"
	}
}
