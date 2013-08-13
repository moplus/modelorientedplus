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
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.Resources;
using Microsoft.SqlServer.Management.Smo;
using MySql.Data.MySqlClient;

namespace MoPlus.Interpreter.BLL.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the DatabaseSource class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/21/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class DatabaseSource : Solutions.SpecificationSource
	{
		#region "Constants"
		#endregion "Constants"
		
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override string Name
		{
			get
			{
				if (SourceDbServerName == String.Empty && SourceDbName == String.Empty)
				{
					return String.Empty;
				}
				return SourceDbServerName + "." + SourceDbName;
			}
			set
			{
				bool isFirstItem = true;
				char[] splitChar = { '.' };
				foreach (string loopItem in value.Split(splitChar, 2))
				{
					if (isFirstItem == true)
					{
						SourceDbServerName = loopItem;
					}
					else
					{
						SourceDbName = loopItem;
					}
					isFirstItem = false;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the display name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string DisplayName
		{
			get
			{
				return Name;
			}
		}

		private SqlDatabase _specDatabase = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the specification database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public SqlDatabase SpecDatabase
		{
			get
			{
				if (_specDatabase == null)
				{
					LoadSpecificationSource();
				}
				if (_specDatabase != null && _specDatabase.DatabaseSource == null)
				{
					_specDatabase.DatabaseSource = this;
				}
				return _specDatabase;
			}
			set
			{
				_specDatabase = value;
			}
		}

		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public DatabaseSource GetForwardInstance()
		{
			DatabaseSource forwardItem = new DatabaseSource();
			forwardItem.TransformDataFromObject(this, null, false);
			return forwardItem;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads a specification source with information from a
		/// SQL database.</summary>
		///--------------------------------------------------------------------------------
		public void LoadSpecificationSource()
		{
			try
			{
				switch (DatabaseTypeCode)
				{
					case (int)BLL.Config.DatabaseTypeCode.SqlServer:
						Database sqlDatabase = null;
						Server sqlServer = new Server(SourceDbServerName);
						sqlServer.SetDefaultInitFields(true);
						if (!String.IsNullOrEmpty(PasswordClearText) && !String.IsNullOrEmpty(UserName))
						{
							// sql server authentication
							sqlServer.ConnectionContext.Login = UserName;
							sqlServer.ConnectionContext.Password = PasswordClearText;
							sqlServer.ConnectionContext.LoginSecure = false;
						}
						else
						{
							// windows authentication
							sqlServer.ConnectionContext.LoginSecure = true;
						}
						sqlServer.ConnectionContext.Connect();
						if (sqlServer.ConnectionContext.IsOpen == false)
						{
							SpecDatabase = null;
							ApplicationException ex = new ApplicationException(String.Format(DisplayValues.Exception_SourceDbServerConnection, SourceDbServerName));
							Solution.ShowIssue(ex.Message + "\r\n" + ex.StackTrace);
							throw ex;
						}
						StringBuilder databases = new StringBuilder();
						foreach (Database loopDb in sqlServer.Databases)
						{
							if (!String.IsNullOrEmpty(databases.ToString())) databases.Append(", ");
							databases.Append(loopDb.Name);
							if (loopDb.Name.ToLower() == SourceDbName.ToLower())
							{
								sqlDatabase = loopDb;
								break;
							}
						}
						if (sqlDatabase == null)
						{
							SpecDatabase = null;
							ApplicationException ex = new ApplicationException(String.Format(DisplayValues.Exception_SourceDbNotFound, SourceDbName, databases.ToString()));
							Solution.ShowIssue(ex.Message + "\r\n" + ex.StackTrace);
							throw ex;
						}
						else
						{
							// load the database information
							SpecDatabase = new SqlDatabase();
							SpecDatabase.SqlDatabaseID = Guid.NewGuid();
							SpecDatabase.Solution = Solution;
							SpecDatabase.LoadSqlServerDatabase(sqlDatabase);
						}
						databases = null;
						break;
					case (int)BLL.Config.DatabaseTypeCode.MySQL:
						string myConnectionString = "SERVER=" + SourceDbServerName + ";" +
							"DATABASE=" + SourceDbName + ";" +
							"UID=" + UserName + ";" +
							"PASSWORD=" + PasswordClearText + ";";
						MySqlConnection connection = new MySqlConnection(myConnectionString);
						using (connection)
						{
							try
							{
								connection.Open();
							}
							catch
							{
								SpecDatabase = null;
								ApplicationException ex = new ApplicationException(String.Format(DisplayValues.Exception_MySQLConnection, SourceDbName, SourceDbServerName));
								Solution.ShowIssue(ex.Message + "\r\n" + ex.StackTrace);
								throw ex;
							}
							// load the database information
							SpecDatabase = new SqlDatabase();
							SpecDatabase.SqlDatabaseID = Guid.NewGuid();
							SpecDatabase.Solution = Solution;
							SpecDatabase.LoadMySQLDatabase(connection);
							connection.Close();
						}
						break;
					default:
						break;
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
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