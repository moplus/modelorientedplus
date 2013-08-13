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
using MoPlus.Data;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using System.IO;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Events;

namespace MoPlus.ViewModel.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the SpecTemplatesViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/27/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class SpecTemplatesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets TemplateModelNode.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateModelNode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SpecificationDirectory.</summary>
		///--------------------------------------------------------------------------------
		public string SpecificationDirectory { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsTemplateUtilized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsTemplateUtilized
		{
			get
			{
				foreach (SpecTemplateViewModel item in Items.OfType<SpecTemplateViewModel>())
				{
					if (item.IsTemplateUtilized == true) return true;
				}
				foreach (SpecTemplatesViewModel item in Items.OfType<SpecTemplatesViewModel>())
				{
					if (item.IsTemplateUtilized == true) return true;
				}
				return false;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method updates the corresponding solution.</summary>
		/// 
		/// <param name="solution">The corresponding solution.</param>
		///--------------------------------------------------------------------------------
		public void UpdateSolution(Solution solution)
		{
			Solution = solution;
			foreach (SpecTemplateViewModel template in Items.OfType<SpecTemplateViewModel>())
			{
				template.UpdateSolution(solution);
			}
			foreach (SpecTemplatesViewModel template in Items.OfType<SpecTemplatesViewModel>())
			{
				template.UpdateSolution(solution);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a template to the view models (and tree).</summary>
		/// 
		/// <param name="template">The template to add.</param>
		/// <param name="refresh">Flag whether to refresh view.</param>
		///--------------------------------------------------------------------------------
		public void AddTemplate(SpecTemplateViewModel template, bool refresh = true)
		{
			switch (TemplateModelNode)
			{
				case "Solution":
					bool folderFound = false;
					foreach (SpecTemplatesViewModel view in Items.OfType<SpecTemplatesViewModel>())
					{
						if (view.SpecificationDirectory == template.SpecTemplate.SpecificationDirectory)
						{
							view.AddTemplate(template, refresh);
							folderFound = true;
							break;
						}
					}
					if (folderFound == false)
					{
						AddSpecTemplate(template, refresh);
					}
					break;
				case "SpecificationSource":
						AddSpecTemplate(template, refresh);
					break;
				default:
					if (String.IsNullOrEmpty(template.SpecTemplate.CategoryName) || template.SpecTemplate.CategoryName == Name)
					{
						Items.Add(template);
						template.Updated += new EventHandler(Children_Updated);
						if (refresh == true)
						{
							Items.Sort("Name", SortDirection.Ascending);
						}
					}
					else
					{
						bool foundCategory = false;
						foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
						{
							if (folder.Name == template.SpecTemplate.CategoryName)
							{
								folder.AddTemplate(template, refresh);
								foundCategory = true;
							}
						}
						if (foundCategory == false)
						{
							SpecTemplatesViewModel folder = new SpecTemplatesViewModel(Solution, template.SpecTemplate.TemplateType, SpecificationDirectory);
							folder.Name = template.SpecTemplate.CategoryName;
							folder.AddTemplate(template, refresh);
							Items.Add(folder);
							folder.Updated += new EventHandler(Children_Updated);
							if (refresh == true)
							{
								Items.Sort("Name", SortDirection.Ascending);
							}
						}
					}
					break;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a template to the view models (and tree).</summary>
		/// 
		/// <param name="template">The template to add.</param>
		/// <param name="refresh">Flag whether to refresh view.</param>
		///--------------------------------------------------------------------------------
		public void AddSpecTemplate(SpecTemplateViewModel template, bool refresh = true)
		{
			string templateName = String.Empty;
			ModelContextTypeCode modelContextTypeEnum = ModelContextTypeCode.None;
			Enum.TryParse<ModelContextTypeCode>(template.SpecTemplate.TemplateType, out modelContextTypeEnum);
			switch (modelContextTypeEnum)
			{
				case ModelContextTypeCode.AuditProperty:
					templateName = Resources.DisplayValues.NodeName_Templates_AuditProperty;
					break;
				case ModelContextTypeCode.Collection:
					templateName = Resources.DisplayValues.NodeName_Templates_Collection;
					break;
				case ModelContextTypeCode.Entity:
					templateName = Resources.DisplayValues.NodeName_Templates_Entity;
					break;
				case ModelContextTypeCode.EntityReference:
					templateName = Resources.DisplayValues.NodeName_Templates_EntityReference;
					break;
				case ModelContextTypeCode.Feature:
					templateName = Resources.DisplayValues.NodeName_Templates_Feature;
					break;
				case ModelContextTypeCode.Index:
					templateName = Resources.DisplayValues.NodeName_Templates_Index;
					break;
				case ModelContextTypeCode.IndexProperty:
					templateName = Resources.DisplayValues.NodeName_Templates_IndexProperty;
					break;
				case ModelContextTypeCode.Method:
					templateName = Resources.DisplayValues.NodeName_Templates_Method;
					break;
				case ModelContextTypeCode.Parameter:
					templateName = Resources.DisplayValues.NodeName_Templates_Parameter;
					break;
				case ModelContextTypeCode.Property:
					templateName = Resources.DisplayValues.NodeName_Templates_Property;
					break;
				case ModelContextTypeCode.PropertyReference:
					templateName = Resources.DisplayValues.NodeName_Templates_PropertyReference;
					break;
				case ModelContextTypeCode.Relationship:
					templateName = Resources.DisplayValues.NodeName_Templates_Relationship;
					break;
				case ModelContextTypeCode.RelationshipProperty:
					templateName = Resources.DisplayValues.NodeName_Templates_RelationshipProperty;
					break;
				case ModelContextTypeCode.Workflow:
					templateName = Resources.DisplayValues.NodeName_Templates_Workflow;
					break;
				case ModelContextTypeCode.Stage:
					templateName = Resources.DisplayValues.NodeName_Templates_Stage;
					break;
				case ModelContextTypeCode.StageTransition:
					templateName = Resources.DisplayValues.NodeName_Templates_StageTransition;
					break;
				case ModelContextTypeCode.Step:
					templateName = Resources.DisplayValues.NodeName_Templates_Step;
					break;
				case ModelContextTypeCode.StepTransition:
					templateName = Resources.DisplayValues.NodeName_Templates_StepTransition;
					break;
				case ModelContextTypeCode.StateModel:
					templateName = Resources.DisplayValues.NodeName_Templates_StateModel;
					break;
				case ModelContextTypeCode.State:
					templateName = Resources.DisplayValues.NodeName_Templates_State;
					break;
				case ModelContextTypeCode.StateTransition:
					templateName = Resources.DisplayValues.NodeName_Templates_StateTransition;
					break;
				default:
					SpecModelContextTypeCode specModelContextTypeEnum = SpecModelContextTypeCode.None;
					Enum.TryParse<SpecModelContextTypeCode>(template.SpecTemplate.TemplateType, out specModelContextTypeEnum);
					switch (specModelContextTypeEnum)
					{
						case SpecModelContextTypeCode.SqlColumn:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlColumn;
							break;
						case SpecModelContextTypeCode.SqlDatabase:
							Name = Resources.DisplayValues.NodeName_Templates_SqlDatabase;
							break;
						case SpecModelContextTypeCode.SqlExtendedProperty:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlExtendedProperty;
							break;
						case SpecModelContextTypeCode.SqlForeignKey:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlForeignKey;
							break;
						case SpecModelContextTypeCode.SqlForeignKeyColumn:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlForeignKeyColumn;
							break;
						case SpecModelContextTypeCode.SqlIndex:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlIndex;
							break;
						case SpecModelContextTypeCode.SqlIndexedColumn:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlIndexedColumn;
							break;
						case SpecModelContextTypeCode.SqlProperty:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlProperty;
							break;
						case SpecModelContextTypeCode.SqlTable:
							templateName = Resources.DisplayValues.NodeName_Templates_SqlTable;
							break;
						case SpecModelContextTypeCode.XmlAttribute:
							templateName = Resources.DisplayValues.NodeName_Templates_XmlAttribute;
							break;
						case SpecModelContextTypeCode.XmlDocument:
							templateName = Resources.DisplayValues.NodeName_Templates_XmlDocument;
							break;
						case SpecModelContextTypeCode.XmlNode:
							templateName = Resources.DisplayValues.NodeName_Templates_XmlNode;
							break;
						default:
							templateName = Resources.DisplayValues.NodeName_SpecTemplates;
							break;
					}
					break;
			}
			if (template.SpecTemplate.TemplateType == SpecModelContextTypeCode.SpecificationSource.ToString())
			{
				if (String.IsNullOrEmpty(template.SpecTemplate.CategoryName))
				{
					Items.Add(template);
					template.Updated += new EventHandler(Children_Updated);
					if (refresh == true)
					{
						Items.Sort("Name", SortDirection.Ascending);
					}
				}
				else
				{
					bool foundCategory = false;
					foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
					{
						if (folder.Name == template.SpecTemplate.CategoryName)
						{
							folder.AddTemplate(template, refresh);
							foundCategory = true;
						}
					}
					if (foundCategory == false)
					{
						SpecTemplatesViewModel folder = new SpecTemplatesViewModel(Solution, ModelContextTypeCode.None.ToString(), SpecificationDirectory);
						folder.Name = template.SpecTemplate.CategoryName;
						folder.AddTemplate(template, refresh);
						Items.Add(folder);
						folder.Updated += new EventHandler(Children_Updated);
						if (refresh == true)
						{
							Items.Sort("Name", SortDirection.Ascending);
						}
					}
				}
			}
			else
			{
				bool foundFolder = false;
				foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
				{
					if (folder.Name == templateName)
					{
						folder.AddTemplate(template, refresh);
						foundFolder = true;
					}
				}
				if (foundFolder == false)
				{
					SpecTemplatesViewModel folder = new SpecTemplatesViewModel(Solution, template.SpecTemplate.TemplateType, SpecificationDirectory);
					folder.Name = templateName;
					folder.AddTemplate(template, refresh);
					Items.Add(folder);
					folder.Updated += new EventHandler(Children_Updated);
					if (refresh == true)
					{
						Items.Sort("Name", SortDirection.Ascending);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes a template from the view models (and tree and designer).</summary>
		/// 
		/// <param name="templateID">The ID of the template to remove.</param>
		///--------------------------------------------------------------------------------
		public SpecTemplateViewModel RemoveTemplate(Guid templateID, bool removeFromTabs = true)
		{
			foreach (SpecTemplateViewModel template in Items.OfType<SpecTemplateViewModel>())
			{
				if (template.SpecTemplate.TemplateID == templateID)
				{
					if (removeFromTabs == true)
					{
						// remove item from tabs, if present
						WorkspaceEventArgs message = new WorkspaceEventArgs();
						message.ItemID = templateID;
						Mediator.NotifyColleagues<WorkspaceEventArgs>(MediatorMessages.Command_CloseItemRequested, message);
					}

					// remove item from Items and tree
					Items.Remove(template);
					template.Updated -= Children_Updated;
					return template;
				}
			}
			foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
			{
				SpecTemplateViewModel template = folder.RemoveTemplate(templateID, removeFromTabs);
				if (template != null)
				{
					if (folder.TemplateModelNode != ModelContextTypeCode.Solution.ToString() && folder.Items.Count == 0)
					{
						Items.Remove(folder);
						folder.Updated -= Children_Updated;
					}
					return template;
				}
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from a directory into the view model.</summary>
		///--------------------------------------------------------------------------------
		public void LoadTemplateDirectories()
		{
			// clear out existing loaded templates
			Items.Clear();

			// load templates
			if (!String.IsNullOrEmpty(SpecificationDirectory))
			{
				LoadTemplateDirectory(SpecificationDirectory, false);
			}
			SortTemplateDirectories();
			Refresh(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sorts the overall template list.</summary>
		///--------------------------------------------------------------------------------
		public void SortTemplateDirectories()
		{
			Items.Sort("Name", SortDirection.Ascending);

			foreach (SpecTemplatesViewModel folder in Items.OfType<SpecTemplatesViewModel>())
			{
				folder.SortTemplateDirectories();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from a directory into the view model.</summary>
		/// 
		/// <param name="directory">The directory to load.</param>
		/// <param name="refresh">Flag whether to refresh view.</param>
		///--------------------------------------------------------------------------------
		public void LoadTemplateDirectory(string directory, bool refresh = true)
		{
			if (!String.IsNullOrEmpty(directory) && Directory.Exists(directory))
			{
				foreach (string file in Directory.GetFiles(directory, "*.mps"))
				{
					SpecTemplate template = new SpecTemplate();
					template.TemplateID = Guid.NewGuid();
					template.Solution = Solution;
					template.FilePath = file;
					template.LoadTemplateFileData();
					Solution.SpecTemplates[template.TemplateKey] = template;
					template.SpecificationDirectory = SpecificationDirectory;
					AddTemplate(new SpecTemplateViewModel(template, Solution, null, SpecificationDirectory), refresh);
				}
				foreach (string subDirectory in Directory.GetDirectories(directory))
				{
					LoadTemplateDirectory(subDirectory, refresh);
				}
			}

			if (refresh == true)
			{
				Refresh(true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from each unique specification directory
		/// in the specification sources.</summary>
		///--------------------------------------------------------------------------------
		public void LoadSpecDirectories()
		{
			NameObjectCollection directories = new NameObjectCollection();
			Items.Clear();
			foreach (DatabaseSource source in Solution.DatabaseSourceList)
			{
				if (!String.IsNullOrEmpty(source.TemplatePath) && !String.IsNullOrEmpty(Directory.GetParent(source.TemplatePath).FullName))
				{
					directories[Directory.GetParent(source.TemplatePath).FullName] = Directory.GetParent(source.TemplatePath).FullName;
				}
			}
			foreach (XmlSource source in Solution.XmlSourceList)
			{
				if (!String.IsNullOrEmpty(source.TemplatePath) && !String.IsNullOrEmpty(Directory.GetParent(source.TemplatePath).FullName))
				{
					directories[Directory.GetParent(source.TemplatePath).FullName] = Directory.GetParent(source.TemplatePath).FullName;
				}
			}
			for (int i = 0; i < directories.Count; i++)
			{
				if (Directory.Exists(directories[i].ToString()) == true)
				{
					string folderName = (directories[i].ToString()).Substring(directories[i].ToString().LastIndexOf("\\") + 1);
					SpecTemplatesViewModel spec = new SpecTemplatesViewModel(Solution, SpecModelContextTypeCode.SpecificationSource.ToString(), directories[i].ToString(), folderName);
					Items.Add(spec);
				}
				else
				{
					ShowIssue(String.Format(DisplayValues.Issue_SpecTemplateDirectoryNotFound, directories[i].ToString()));
				}
			}
			Items.Sort("Name", SortDirection.Ascending);
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		/// <param name="node">The node in the model the template is associated with.</param>
		///--------------------------------------------------------------------------------
		public SpecTemplatesViewModel(Solution solution, string node, string specificationDirectory = null, string folderName = null)
		{
			TemplateModelNode = node;
			SpecificationDirectory = specificationDirectory;
			Solution = solution;
			if (SpecTemplates == null)
			{
				SpecTemplates = new EnterpriseDataObjectList<SpecTemplateViewModel>();
			}
			switch (TemplateModelNode)
			{
				case "Solution":
					Name = Resources.DisplayValues.NodeName_SpecTemplates;

					// load templates from each unique specification directory
					LoadSpecDirectories();
					break;
				case "SpecificationSource":
					if (!String.IsNullOrEmpty(folderName))
					{
						Name = folderName;
					}
					else
					{
						Name = Resources.DisplayValues.NodeName_SpecTemplates;
					}
					LoadTemplateDirectories();
					break;
				default:
					Name = Resources.DisplayValues.NodeName_SpecTemplates;
					break;
			}
		}

		#endregion "Constructors"
	}
}
