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
using MoPlus.ViewModel.Events;

namespace MoPlus.ViewModel.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the CodeTemplatesViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/27/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class CodeTemplatesViewModel : EditWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		#endregion "Editing Support"

		#region "Command Processing"
		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets TemplateModelNode lists.</summary>
		///--------------------------------------------------------------------------------
		public string TemplateModelNode { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsTemplateUtilized.</summary>
		///--------------------------------------------------------------------------------
		public bool IsTemplateUtilized
		{
			get
			{
				foreach (CodeTemplateViewModel item in Items.OfType<CodeTemplateViewModel>())
				{
					if (item.IsTemplateUtilized == true) return true;
				}
				foreach (CodeTemplatesViewModel item in Items.OfType<CodeTemplatesViewModel>())
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
			foreach (CodeTemplateViewModel template in Items.OfType<CodeTemplateViewModel>())
			{
				template.UpdateSolution(solution);
			}
			foreach (CodeTemplatesViewModel template in Items.OfType<CodeTemplatesViewModel>())
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
		public void AddTemplate(CodeTemplateViewModel template, bool refresh = true)
		{
			ModelContextTypeCode modelContextTypeEnum = ModelContextTypeCode.None;
			Enum.TryParse<ModelContextTypeCode>(template.CodeTemplate.TemplateType, out modelContextTypeEnum);
			switch (TemplateModelNode)
			{
				case "Solution":
					string templateName = String.Empty;
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
						case ModelContextTypeCode.Project:
							templateName = Resources.DisplayValues.NodeName_Templates_Project;
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
						case ModelContextTypeCode.Model:
							templateName = Resources.DisplayValues.NodeName_Templates_Model;
							break;
						case ModelContextTypeCode.ModelObject:
							templateName = Resources.DisplayValues.NodeName_Templates_ModelObject;
							break;
						case ModelContextTypeCode.ModelProperty:
							templateName = Resources.DisplayValues.NodeName_Templates_ModelProperty;
							break;
						case ModelContextTypeCode.Enumeration:
							templateName = Resources.DisplayValues.NodeName_Templates_Enumeration;
							break;
						case ModelContextTypeCode.Value:
							templateName = Resources.DisplayValues.NodeName_Templates_Value;
							break;
						case ModelContextTypeCode.ObjectInstance:
							templateName = Resources.DisplayValues.NodeName_Templates_ObjectInstance;
							break;
						case ModelContextTypeCode.PropertyInstance:
							templateName = Resources.DisplayValues.NodeName_Templates_PropertyInstance;
							break;
						default:
							templateName = Resources.DisplayValues.NodeName_CodeTemplates;
							break;
					}
					if (modelContextTypeEnum == ModelContextTypeCode.Solution)
					{
						if (String.IsNullOrEmpty(template.CodeTemplate.CategoryName))
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
							foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
							{
								if (folder.Name == template.CodeTemplate.CategoryName)
								{
									folder.AddTemplate(template, refresh);
									foundCategory = true;
								}
							}
							if (foundCategory == false)
							{
								CodeTemplatesViewModel folder = new CodeTemplatesViewModel(Solution, ModelContextTypeCode.None.ToString());
								folder.Name = template.CodeTemplate.CategoryName;
								folder.AddTemplate(template);
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
						foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
						{
							if (folder.Name == templateName)
							{
								folder.AddTemplate(template, refresh);
								foundFolder = true;
							}
						}
						if (foundFolder == false)
						{
							CodeTemplatesViewModel folder = new CodeTemplatesViewModel(Solution, modelContextTypeEnum.ToString());
							folder.Name = templateName;
							folder.AddTemplate(template);
							Items.Add(folder);
							folder.Updated += new EventHandler(Children_Updated);
							if (refresh == true)
							{
								Items.Sort("Name", SortDirection.Ascending);
							}
						}
					}
					break;
				default:
					if (String.IsNullOrEmpty(template.CodeTemplate.CategoryName) || template.CodeTemplate.CategoryName == Name)
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
						foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
						{
							if (folder.Name == template.CodeTemplate.CategoryName)
							{
								folder.AddTemplate(template, refresh);
								foundCategory = true;
							}
						}
						if (foundCategory == false)
						{
							CodeTemplatesViewModel folder = new CodeTemplatesViewModel(Solution, modelContextTypeEnum.ToString());
							folder.Name = template.CodeTemplate.CategoryName;
							folder.AddTemplate(template);
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
		/// <summary>This method removes a template from the view models (and tree and designer).</summary>
		/// 
		/// <param name="templateID">The ID of the template to remove.</param>
		///--------------------------------------------------------------------------------
		public CodeTemplateViewModel RemoveTemplate(Guid templateID, bool removeFromTabs = true)
		{
			foreach (CodeTemplateViewModel template in Items.OfType<CodeTemplateViewModel>())
			{
				if (template.CodeTemplate.TemplateID == templateID)
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
			foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
			{
				CodeTemplateViewModel template = folder.RemoveTemplate(templateID, removeFromTabs);
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
		/// <summary>This method loads templates into the view model.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadTemplates(Solution solution)
		{
			Solution = solution;

			if (TemplateModelNode == ModelContextTypeCode.Solution.ToString())
			{
				// load template directories
				LoadTemplateDirectories();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from a directory into the view model.</summary>
		///--------------------------------------------------------------------------------
		public void LoadTemplateDirectories()
		{
			// clear out existing loaded templates
			Items.Clear();

			// load templates
			if (!String.IsNullOrEmpty(Solution.TemplatePath))
			{
				Solution.CodeTemplates.Clear();
				LoadTemplateDirectory(Directory.GetParent(Solution.TemplatePath).FullName, false);
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

			foreach (CodeTemplatesViewModel folder in Items.OfType<CodeTemplatesViewModel>())
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
			if (!String.IsNullOrEmpty(directory))
			{
				foreach (string file in Directory.GetFiles(directory, "*.mpt"))
				{
					CodeTemplate template = new CodeTemplate();
					template.TemplateID = Guid.NewGuid();
					template.Solution = Solution;
					template.FilePath = file;
					template.LoadTemplateFileData();
					Solution.CodeTemplates[template.TemplateKey] = template;
					AddTemplate(new CodeTemplateViewModel(template, Solution), refresh);
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
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		/// <param name="node">The node in the model the template is associated with.</param>
		///--------------------------------------------------------------------------------
		public CodeTemplatesViewModel(Solution solution, string node)
		{
			TemplateModelNode = node;
			Name = Resources.DisplayValues.NodeName_CodeTemplates;
			Solution = solution;
			LoadCodeTemplates(solution, false);
			LoadTemplates(solution);
		}

		#endregion "Constructors"
	}
}
