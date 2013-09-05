/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.Resources;
using Microsoft.SqlServer.Management.Smo;
using System.IO;

namespace MoPlus.Interpreter.BLL.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Project class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/21/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Project : BusinessObjectBase
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the primary source db.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string TemplateAbsolutePath
		{
			get
			{
				if (!String.IsNullOrEmpty(TemplatePath))
				{
					if (File.Exists(TemplatePath))
					{
						return TemplatePath;
					}
					if (Solution != null && !String.IsNullOrEmpty(Solution.SolutionDirectory))
					{
						Uri uri = new Uri(Path.Combine(Solution.SolutionDirectory, TemplatePath));
						string path = Path.GetFullPath(uri.AbsolutePath).ToString();
						return path;
					}
					return TemplatePath;
				}
				return null;
			}
		}

		private EnterpriseDataObjectList<Project> _projectReferences = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProjectReferences.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public EnterpriseDataObjectList<Project> ProjectReferences
		{
			get
			{
				if (_projectReferences == null || _projectReferences.Count != ProjectReferenceList.Count)
				{
					_projectReferences = new EnterpriseDataObjectList<Project>();
					foreach (ProjectReference reference in ProjectReferenceList)
					{
						_projectReferences.Add(Solution.ProjectList.FindByID(reference.ReferencedProjectID));
					}
				}
				return _projectReferences;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProjectReferenceCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int ProjectReferenceCount
		{
			get
			{
				if (ProjectReferenceList != null)
				{
					return ProjectReferenceList.Count;
				}
				return 0;
			}
		}

		private SqlDatabase _outputDatabase = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the output database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlDatabase OutputDatabase
		{
			get
			{
				if (_outputDatabase == null && !String.IsNullOrEmpty(DbServerName) && !String.IsNullOrEmpty(DbName))
				{
					LoadOutputDB();
				}
				return _outputDatabase;
			}
			set
			{
				_outputDatabase = value;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Project GetForwardInstance()
		{
			Project forwardItem = new Project();
			forwardItem.TransformDataFromObject(this, null, false);
			forwardItem.ProjectReferenceList = new EnterpriseDataObjectList<ProjectReference>();
			foreach (ProjectReference reference in ProjectReferenceList)
			{
				ProjectReference newReference = new ProjectReference();
				newReference.TransformDataFromObject(reference, null, false);
				forwardItem.ProjectReferenceList.Add(newReference);
			}
			return forwardItem;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads an output db with information from a
		/// SQL database.</summary>
		///--------------------------------------------------------------------------------
		public void LoadOutputDB()
		{
			try
			{
				if (!String.IsNullOrEmpty(DbServerName) && !String.IsNullOrEmpty(DbName))
				{
					Database sqlDatabase = null;
					Server sqlServer = new Server(DbServerName);
					sqlServer.SetDefaultInitFields(true);
					sqlServer.ConnectionContext.LoginSecure = true;
					sqlServer.ConnectionContext.Connect();
					foreach (Database loopDb in sqlServer.Databases)
					{
						if (loopDb.Name == DbName)
						{
							sqlDatabase = loopDb;
							break;
						}
					}
					if (sqlDatabase == null)
					{
						OutputDatabase = null;
						throw new ApplicationException(String.Format(DisplayValues.Exception_SourceDbNotFound, DbName));
					}
					else
					{
						// load the database information
						OutputDatabase = new SqlDatabase();
						OutputDatabase.SqlDatabaseID = Guid.NewGuid();
						OutputDatabase.LoadSqlServerDatabase(sqlDatabase);
					}
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				Solution.ShowIssue(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}