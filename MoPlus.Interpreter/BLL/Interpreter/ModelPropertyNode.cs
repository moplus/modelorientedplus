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
using Irony.Parsing;
using Irony.Interpreter.Ast;
using MoPlus.Interpreter.Resources;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Data;
using System.Text.RegularExpressions;
using MoPlus.IO;
using System.IO;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Models;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class implements necessary members for interpretation of model property level properties.</summary>
	///
	/// <CreatedByUserName>DAVE\JavaDave</CreatedByUserName>
	/// <CreatedDate>9/29/2011</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public class ModelPropertyNode : NonLeafGrammarNode, IPropertyNode
	{
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DisplayName, for display purposes, etc.</summary>
		///--------------------------------------------------------------------------------
		public override string DisplayName
		{
			get
			{
				if (!String.IsNullOrEmpty(ModelPropertyName))
				{
					return LineNumber.ToString() + ": " + ModelPropertyName;
				}
				return LineNumber.ToString() + ": " + DisplayValues.TemplateNode_ModelProperty;
			}
		}

		public string ModelPropertyName { get; set; }
		public ParameterNode Parameter1 { get; set; }
		public ParameterNode Parameter2 { get; set; }
		public PopContextNode PopContext { get; set; }
		public ThisContextNode ThisContext { get; set; }
		public ModelPropertyNode ModelProperty { get; set; }
		public ModelContextNode ModelContext { get; set; }
		public CurrentItemNode CurrentItem { get; set; }
		public SpecCurrentItemNode SpecCurrentItem { get; set; }
		public TemplatePropertyNode TemplateProperty { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method sets up the AST node and its children in the AST.</summary>
		/// 
		/// <param name="context">The parsing context.</param>
		/// <param name="treeNode">The corresponding node in the parse tree.</param>
		///--------------------------------------------------------------------------------
		public override void Init(ParsingContext context, ParseTreeNode treeNode)
		{
			try
			{
				base.Init(context, treeNode);
				foreach (ParseTreeNode node in treeNode.ChildNodes)
				{
					if (node.AstNode is ModelContextNode)
					{
						ModelContext = node.AstNode as ModelContextNode;
						ChildNodes.Add(node.AstNode as ModelContextNode);
					}
					else if (node.AstNode is CurrentItemNode)
					{
						CurrentItem = node.AstNode as CurrentItemNode;
						ChildNodes.Add(node.AstNode as CurrentItemNode);
					}
					else if (node.AstNode is SpecCurrentItemNode)
					{
						SpecCurrentItem = node.AstNode as SpecCurrentItemNode;
						ChildNodes.Add(node.AstNode as SpecCurrentItemNode);
					}
					else if (node.AstNode is AssignablePropertyNode)
					{
						// collapse assignable property, just get the assignable property name
						AssignablePropertyNode AssignableProperty = node.AstNode as AssignablePropertyNode;
						ModelPropertyName = AssignableProperty.PropertyName;
						ChildNodes.Add(AssignableProperty);
					}
					else if (node.AstNode is PopContextNode)
					{
						PopContext = node.AstNode as PopContextNode;
						ChildNodes.Add(node.AstNode as PopContextNode);
					}
					else if (node.AstNode is ThisContextNode)
					{
						ThisContext = node.AstNode as ThisContextNode;
						ChildNodes.Add(node.AstNode as ThisContextNode);
					}
					else if (node.AstNode is ModelPropertyNode)
					{
						ModelProperty = node.AstNode as ModelPropertyNode;
						ChildNodes.Add(node.AstNode as ModelPropertyNode);
					}
					else if (node.AstNode is TemplatePropertyNode)
					{
						TemplateProperty = node.AstNode as TemplatePropertyNode;
						ChildNodes.Add(node.AstNode as TemplatePropertyNode);
					}
					else if (node.AstNode is ParameterNode)
					{
						if (Parameter1 == null)
						{
							Parameter1 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
						else if (Parameter2 == null)
						{
							Parameter2 = node.AstNode as ParameterNode;
							ChildNodes.Add(node.AstNode as ParameterNode);
						}
					}
					else
					{
						ModelPropertyName = node.FindTokenAndGetText();
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				ThrowASTException(ex, true);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public void InterpretNode(InterpreterTypeCode interpreterType, Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			try
			{
				StringBuilder output = null;
				if (interpreterType == InterpreterTypeCode.Output)
				{
					output = templateContext.OutputCodeBuilder;
				}
				else
				{
					output = templateContext.ContentCodeBuilder;
				}
				string propertyValue = GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
				if (!String.IsNullOrEmpty(propertyValue))
				{
					output.Append(propertyValue);
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="parameterModelContext">The associated model context for parameters.</param>
		///--------------------------------------------------------------------------------
		public string GetPropertyStringValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, IDomainEnterpriseObject parameterModelContext, InterpreterTypeCode interpreterType)
		{
			string propertyValue = null;
			try
			{
				if (ThisContext != null)
				{
					templateContext.PopCount = templateContext.ModelContextStack.Count - 1;
				}
				else if (PopContext != null)
				{
					templateContext.PopCount++;
				}
				if (ModelProperty != null)
				{
					IDomainEnterpriseObject propertyModelContext = GetModelContext(solutionContext, templateContext, modelContext);
					if (propertyModelContext == null)
					{
						return "null";
					}
					propertyValue = ModelProperty.GetPropertyStringValue(solutionContext, templateContext, propertyModelContext, modelContext, interpreterType);
					string parameter1Value = String.Empty;
					if (Parameter1 != null)
					{
						parameter1Value = Parameter1.GetStringValue(solutionContext, templateContext, propertyModelContext, interpreterType);
					}
					string parameter2Value = String.Empty;
					if (Parameter2 != null)
					{
						parameter2Value = Parameter2.GetStringValue(solutionContext, templateContext, propertyModelContext, interpreterType);
					}
					if (ModelPropertyName == LanguageTerms.StringToLower)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.ToLower();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringToUpper)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.ToUpper();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringTrim)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.Trim();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringTrimStart)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.TrimStart();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringTrimEnd)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.TrimEnd();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringCamelCase)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.CamelCase();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringCapitalCase)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.CapitalCase();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringUnderscoreCase)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.UnderscoreCase();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringReplace)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.Replace(parameter1Value, parameter2Value);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringFilter)
					{
						if (!String.IsNullOrEmpty(propertyValue) && propertyValue.IndexOf(parameter1Value) >= 0 && propertyValue.IndexOf(parameter2Value) > propertyValue.IndexOf(parameter1Value))
						{
							propertyValue = propertyValue.Substring(0, propertyValue.IndexOf(parameter1Value)) + propertyValue.Substring(propertyValue.IndexOf(parameter2Value) + parameter2Value.Length);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringFilterProtected)
					{
						if (solutionContext.UseProtectedAreas == true && !String.IsNullOrEmpty(solutionContext.ProtectedAreaStart) && !String.IsNullOrEmpty(solutionContext.ProtectedAreaEnd))
						{
							int currentTextIndex = 0;
							StringBuilder filteredText = new StringBuilder();

							while (currentTextIndex < (propertyValue.Length - 1))
							{
								if (propertyValue.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex) >= 0 && propertyValue.IndexOf(solutionContext.ProtectedAreaEnd, propertyValue.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex)) >= 0)
								{
									// append text to next protected block
									filteredText.Append(propertyValue.Substring(currentTextIndex, propertyValue.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex) - currentTextIndex));

									// skip protected block
									currentTextIndex = propertyValue.IndexOf(solutionContext.ProtectedAreaEnd, propertyValue.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex)) + solutionContext.ProtectedAreaEnd.Length;
								}
								else
								{
									// append remainder of text
									filteredText.Append(propertyValue.Substring(currentTextIndex));
									currentTextIndex = propertyValue.Length - 1;
								}
							}
							propertyValue = filteredText.ToString();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringFilterIgnored)
					{
						if (solutionContext.UseProtectedAreas == true && !String.IsNullOrEmpty(solutionContext.IgnoredAreaStart) && !String.IsNullOrEmpty(solutionContext.IgnoredAreaEnd))
						{
							int currentTextIndex = 0;
							StringBuilder filteredText = new StringBuilder();

							while (currentTextIndex < (propertyValue.Length - 1))
							{
								if (propertyValue.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex) >= 0 && propertyValue.IndexOf(solutionContext.IgnoredAreaEnd, propertyValue.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex)) >= 0)
								{
									// append text to next protected block
									filteredText.Append(propertyValue.Substring(currentTextIndex, propertyValue.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex) - currentTextIndex));

									// skip protected block
									currentTextIndex = propertyValue.IndexOf(solutionContext.IgnoredAreaEnd, propertyValue.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex)) + solutionContext.IgnoredAreaEnd.Length;
								}
								else
								{
									// append remainder of text
									filteredText.Append(propertyValue.Substring(currentTextIndex));
									currentTextIndex = propertyValue.Length - 1;
								}
							}
							propertyValue = filteredText.ToString();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringSubstring)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							int startIndex = parameter1Value.GetInt();
							if (startIndex < 0) startIndex = 0;
							if (startIndex > propertyValue.Length) startIndex = propertyValue.Length;
							if (parameter2Value != String.Empty)
							{
								int length = parameter2Value.GetInt();
								if (length < 0) length = 0;
								if (startIndex + length > propertyValue.Length) length = propertyValue.Length - startIndex;
								propertyValue = (propertyValue as String).Substring(startIndex, length);
							}
							else
							{
								propertyValue = propertyValue.Substring(startIndex);
							}
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringIndexOf)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.IndexOf(parameter1Value).ToString();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringStartsWith)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							if (propertyValue.StartsWith(parameter1Value))
							{
								propertyValue = "true";
							}
							else
							{
								propertyValue = "false";
							}
						}
						else
						{
							propertyValue = "false";
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringEndsWith)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							if (propertyValue.EndsWith(parameter1Value))
							{
								propertyValue = "true";
							}
							else
							{
								propertyValue = "false";
							}
						}
						else
						{
							propertyValue = "false";
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringContains)
					{
						if (ModelProperty != null && ModelProperty.ModelPropertyName == "Tags")
						{
							propertyValue = "false";
							foreach (Tag loopTag in modelContext.TagList)
							{
								if (loopTag.TagName == parameter1Value)
								{
									propertyValue = "true";
									break;
								}
							}
						}
						else
						{
							if (!String.IsNullOrEmpty(propertyValue))
							{
								if (propertyValue.Contains(parameter1Value))
								{
									propertyValue = "true";
								}
								else
								{
									propertyValue = "false";
								}
							}
							else
							{
								propertyValue = "false";
							}
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringRegexIsMatch)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							if (Regex.IsMatch(propertyValue, parameter1Value))
							{
								propertyValue = "true";
							}
							else
							{
								propertyValue = "false";
							}
						}
						else
						{
							propertyValue = "false";
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringRegexReplace)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = Regex.Replace(propertyValue, parameter1Value, parameter2Value);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringLength)
					{
						if (!String.IsNullOrEmpty(propertyValue))
						{
							propertyValue = propertyValue.Length.ToString();
						}
						else
						{
							propertyValue = "0";
						}
					}
					else if (ModelPropertyName == LanguageTerms.ColumnMethod)
					{
						string dbField = ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
						try
						{
							propertyValue = templateContext.DbReader[dbField].GetString();
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileMethod)
					{
						string path = ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
						try
						{
							propertyValue = FileHelper.GetText(path);
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileExistsMethod)
					{
						string path = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
						if (File.Exists(path))
						{
							propertyValue = "true";
						}
						else
						{
							propertyValue = "false";
						}
					}
				}
				else
				{
					string parameter1Value = String.Empty;
					if (Parameter1 != null)
					{
						parameter1Value = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
					}
					string parameter2Value = String.Empty;
					if (Parameter2 != null)
					{
						parameter2Value = Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
					}
					if (ModelPropertyName == LanguageTerms.ColumnMethod)
					{
						try
						{
							propertyValue = templateContext.DbReader[parameter1Value].GetString();
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileMethod)
					{
						try
						{
							propertyValue = FileHelper.GetText(parameter1Value);
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileExistsMethod)
					{
						string path = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
						if (File.Exists(path))
						{
							propertyValue = "true";
						}
						else
						{
							propertyValue = "false";
						}
					}
					else if (ModelPropertyName == LanguageTerms.LogMethod)
					{
						propertyValue = solutionContext.GetStringLoggedValue(parameter1Value, parameter2Value);
					}
					else if (ModelPropertyName == LanguageTerms.HasPropertyNamed)
					{
						if (modelContext is Entity)
						{
							if ((modelContext as Entity).HasPropertyNamed(parameter1Value) == true)
							{
								propertyValue = "true";
							}
							else
							{
								propertyValue = "false";
							}
						}
						else
						{
							propertyValue = "null";
						}
					}
					else if (ModelPropertyName == LanguageTerms.IsRelatedToProperty)
					{
						bool isRelatedToProperty = false;
						if (modelContext is Method)
						{
							// look for a property in the context stack
							Property propertyContext = null;
							int popCount = 0;
							while (popCount < templateContext.StackSize && propertyContext == null)
							{
								popCount++;
								propertyContext = templateContext.GetModelContext(popCount) as Property;
							}
							if (propertyContext != null)
							{
								// check to see if property and method have a corresponding relationship
								foreach (MethodRelationship loopRelationship in (modelContext as Method).MethodRelationshipList)
								{
									if (propertyContext.PropertyRelationshipList.Find("RelationshipID", loopRelationship.RelationshipID) != null)
									{
										isRelatedToProperty = true;
										break;
									}
								}
							}
						}
						if (isRelatedToProperty == true)
						{
							propertyValue = "true";
						}
						else
						{
							propertyValue = "false";
						}
					}
					else if (ModelPropertyName == LanguageTerms.TextProperty)
					{
						propertyValue = templateContext.ContentCodeBuilder.ToString();
					}
					else if (ModelPropertyName == LanguageTerms.PathProperty)
					{
						propertyValue = templateContext.OutputCodeBuilder.ToString();
					}
					//else if (ModelPropertyName == LanguageTerms.LibraryDirectoryProperty)
					//{
					//    propertyValue = BusinessConfiguration.LibraryDirectory;
					//}
					else if (ModelPropertyName == LanguageTerms.ItemFileProperty)
					{
						propertyValue = solutionContext.CurrentFileText;
					}
					else if (ModelPropertyName == LanguageTerms.ItemPathProperty)
					{
						propertyValue = solutionContext.CurrentFilePath;
					}
					else
					{
						IDomainEnterpriseObject initialContext = modelContext;
						if (templateContext.PopCount > 0)
						{
							initialContext = templateContext.GetModelContext(templateContext.PopCount);
							templateContext.PopCount = 0;
						}
						IDomainEnterpriseObject propertyModelContext = GetModelContext(solutionContext, templateContext, initialContext);
						if (TemplateProperty != null && String.IsNullOrEmpty(ModelPropertyName))
						{
							// if value is from a declared variable or parameter, return that value first
							if (templateContext.Variables.HasKey(TemplateProperty.TemplateName) == true)
							{
								return templateContext.Variables[TemplateProperty.TemplateName].GetString();
							}
							else if (templateContext.Parameters.HasKey(TemplateProperty.TemplateName) == true)
							{
								return templateContext.Parameters[TemplateProperty.TemplateName].GetString();
							}
							return TemplateProperty.GetCode(solutionContext, templateContext, GetModelContext(solutionContext, templateContext, propertyModelContext), parameterModelContext, interpreterType);
						}
						else
						{
							IDomainEnterpriseObject currentModelContext = propertyModelContext;
							bool isPropertyFound = false;
							while (propertyModelContext != null && propertyValue == null)
							{
								if (ModelPropertyName != null)
								{
									if (ModelPropertyName == LanguageTerms.ItemIndexProperty)
									{
										propertyValue = templateContext.ItemIndex.ToString();
										isPropertyFound = true;
									}
									else if (ModelPropertyName == LanguageTerms.TemplateProperty)
									{
										isPropertyFound = true;
										if (propertyModelContext is Project)
										{
											try
											{
												ITemplate template = null;
												if (templateContext is SpecTemplate)
												{
													template = new SpecTemplate();
												}
												else
												{
													template = new CodeTemplate();
												}
												template.FilePath = (propertyModelContext as Project).TemplatePath;
												template.LoadTemplateFileData(false);
												string templateName = template.TemplateName;
												string code = String.Empty;
												if (templateContext is SpecTemplate)
												{
													template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(propertyModelContext, templateName)] as SpecTemplate;
												}
												else
												{
													template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(propertyModelContext, templateName)] as CodeTemplate;
												}
												if (template != null)
												{
													template.GenerateContent(solutionContext, template, modelContext, false, null);
													propertyValue = template.ContentCodeBuilder.ToString();
												}
												propertyValue = "<" + templateName + ">";
											}
											catch (ApplicationAbortException ex)
											{
												throw ex;
											}
											catch (System.Exception ex)
											{
												LogException(solutionContext, templateContext, propertyModelContext, ex, interpreterType);
											}
										}
									}
									else if (propertyModelContext.GetPropertyInfo(ModelPropertyName) != null)
									{
										isPropertyFound = true;
										propertyValue = propertyModelContext.GetPropertyValueString(ModelPropertyName);
									}
									else if (propertyModelContext is ObjectInstance && solutionContext.ModelPropertyNames[ModelPropertyName].GetString() == ModelPropertyName)
									{
										propertyValue = (propertyModelContext as ObjectInstance).GetStringValue(ModelPropertyName, out isPropertyFound);
									}
								}
								else
								{
									if (ModelContext != null)
									{
										propertyValue = ModelContext.GetPropertyStringValue(solutionContext, templateContext, modelContext);
									}
									else if (CurrentItem != null)
									{
										propertyValue = CurrentItem.GetPropertyStringValue(solutionContext, templateContext, modelContext);
									}
									else if (SpecCurrentItem != null)
									{
										propertyValue = SpecCurrentItem.GetPropertyStringValue(solutionContext, templateContext, modelContext);
									}
								}
								if (propertyValue == null)
								{
									propertyModelContext = propertyModelContext.GetParentItem();
								}
							}
							if (ModelPropertyName != null && isPropertyFound == false)
							{
								string contextName = currentModelContext.GetType().Name;
								if (currentModelContext is ObjectInstance)
								{
									contextName = contextName + "(" + (currentModelContext as ObjectInstance).ModelObjectName + ")";
								}
								LogException(solutionContext, templateContext, propertyModelContext, String.Format(DisplayValues.Exception_PropertyNotFound, ModelPropertyName, contextName), interpreterType);
							}
							if (propertyValue == null)
							{
								if (!String.IsNullOrEmpty(ModelPropertyName) || (ModelContext == null && CurrentItem == null && SpecCurrentItem == null))
								{
									propertyValue = String.Empty;
								}
								else
								{
									propertyValue = "null";
								}

							}
							if (propertyValue == "True")
							{
								propertyValue = "true";
							}
							if (propertyValue == "False")
							{
								propertyValue = "false";
							}
						}
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
			return propertyValue;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Interpret this node to produce code, output, or model data..</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="parameterModelContext">The associated model context for parameters.</param>
		///--------------------------------------------------------------------------------
		public object GetPropertyObjectValue(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext, IDomainEnterpriseObject parameterModelContext, InterpreterTypeCode interpreterType)
		{
			object propertyValue = null;
			try
			{
				if (ThisContext != null)
				{
					templateContext.PopCount = templateContext.ModelContextStack.Count - 1;
				}
				else if (PopContext != null)
				{
					templateContext.PopCount++;
				}
				if (ModelProperty != null)
				{
					IDomainEnterpriseObject propertyModelContext = GetModelContext(solutionContext, templateContext, modelContext);
					if (propertyModelContext == null)
					{
						return null;
					}
					propertyValue = ModelProperty.GetPropertyStringValue(solutionContext, templateContext, propertyModelContext, modelContext, interpreterType);
					string parameter1Value = String.Empty;
					if (Parameter1 != null)
					{
						parameter1Value = Parameter1.GetStringValue(solutionContext, templateContext, propertyModelContext, interpreterType);
					}
					string parameter2Value = String.Empty;
					if (Parameter2 != null)
					{
						parameter2Value = Parameter2.GetStringValue(solutionContext, templateContext, propertyModelContext, interpreterType);
					}
					if (ModelPropertyName == LanguageTerms.StringToLower)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).ToLower();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringToUpper)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).ToUpper();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringTrim)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).Trim();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringTrimStart)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).TrimStart();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringTrimEnd)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).TrimEnd();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringCamelCase)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).CamelCase();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringCapitalCase)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).CapitalCase();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringUnderscoreCase)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).UnderscoreCase();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringReplace)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).Replace(parameter1Value, parameter2Value);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringFilter)
					{
						string propertyValueStr = propertyValue as String;
						if (!String.IsNullOrEmpty(propertyValueStr) && propertyValueStr.IndexOf(parameter1Value) >= 0 && propertyValueStr.IndexOf(parameter2Value) > propertyValueStr.IndexOf(parameter1Value))
						{
							propertyValue = propertyValueStr.Substring(0, propertyValueStr.IndexOf(parameter1Value)) + propertyValueStr.Substring(propertyValueStr.IndexOf(parameter2Value) + parameter2Value.Length);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringFilterProtected)
					{
						string propertyValueStr = propertyValue as String;
						if (!String.IsNullOrEmpty(propertyValueStr) && solutionContext.UseProtectedAreas == true && !String.IsNullOrEmpty(solutionContext.ProtectedAreaStart) && !String.IsNullOrEmpty(solutionContext.ProtectedAreaEnd))
						{
							int currentTextIndex = 0;
							StringBuilder filteredText = new StringBuilder();

							while (currentTextIndex < (propertyValueStr.Length - 1))
							{
								if (propertyValueStr.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex) >= 0 && propertyValueStr.IndexOf(solutionContext.ProtectedAreaEnd, propertyValueStr.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex)) >= 0)
								{
									// append text to next protected block
									filteredText.Append(propertyValueStr.Substring(currentTextIndex, propertyValueStr.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex) - currentTextIndex));

									// skip protected block
									currentTextIndex = propertyValueStr.IndexOf(solutionContext.ProtectedAreaEnd, propertyValueStr.IndexOf(solutionContext.ProtectedAreaStart, currentTextIndex)) + solutionContext.ProtectedAreaEnd.Length;
								}
								else
								{
									// append remainder of text
									filteredText.Append(propertyValueStr.Substring(currentTextIndex));
									currentTextIndex = propertyValueStr.Length - 1;
								}
							}
							propertyValue = filteredText.ToString();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringFilterIgnored)
					{
						string propertyValueStr = propertyValue as String;
						if (!String.IsNullOrEmpty(propertyValueStr) && solutionContext.UseProtectedAreas == true && !String.IsNullOrEmpty(solutionContext.IgnoredAreaStart) && !String.IsNullOrEmpty(solutionContext.IgnoredAreaEnd))
						{
							int currentTextIndex = 0;
							StringBuilder filteredText = new StringBuilder();

							while (currentTextIndex < (propertyValueStr.Length - 1))
							{
								if (propertyValueStr.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex) >= 0 && propertyValueStr.IndexOf(solutionContext.IgnoredAreaEnd, propertyValueStr.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex)) >= 0)
								{
									// append text to next protected block
									filteredText.Append(propertyValueStr.Substring(currentTextIndex, propertyValueStr.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex) - currentTextIndex));

									// skip protected block
									currentTextIndex = propertyValueStr.IndexOf(solutionContext.IgnoredAreaEnd, propertyValueStr.IndexOf(solutionContext.IgnoredAreaStart, currentTextIndex)) + solutionContext.IgnoredAreaEnd.Length;
								}
								else
								{
									// append remainder of text
									filteredText.Append(propertyValueStr.Substring(currentTextIndex));
									currentTextIndex = propertyValueStr.Length - 1;
								}
							}
							propertyValue = filteredText.ToString();
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringSubstring)
					{
						if (propertyValue != null && propertyValue is String)
						{
							int startIndex = parameter1Value.GetInt();
							if (startIndex < 0) startIndex = 0;
							if (startIndex > (propertyValue as String).Length) startIndex = (propertyValue as String).Length;
							if (parameter2Value != String.Empty)
							{
								int length = parameter2Value.GetInt();
								if (length < 0) length = 0;
								if (startIndex + length > (propertyValue as String).Length) length = (propertyValue as String).Length - startIndex;
								propertyValue = (propertyValue as String).Substring(startIndex, length);
							}
							else
							{
								propertyValue = (propertyValue as String).Substring(startIndex);
							}
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringIndexOf)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).IndexOf(parameter1Value);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringStartsWith)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).StartsWith(parameter1Value);
						}
						else
						{
							propertyValue = false;
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringEndsWith)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).EndsWith(parameter1Value);
						}
						else
						{
							propertyValue = false;
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringContains)
					{
						if (ModelProperty != null && ModelProperty.ModelPropertyName == "Tags")
						{
							propertyValue = false;
							foreach (Tag loopTag in modelContext.TagList)
							{
								if (loopTag.TagName == parameter1Value)
								{
									propertyValue = true;
									break;
								}
							}
						}
						else
						{
							if (propertyValue != null && propertyValue is String)
							{
								propertyValue = (propertyValue as String).Contains(parameter1Value);
							}
							else
							{
								propertyValue = false;
							}
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringRegexIsMatch)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = Regex.IsMatch(propertyValue as String, parameter1Value);
						}
						else
						{
							propertyValue = false;
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringRegexReplace)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = Regex.Replace(propertyValue as String, parameter1Value, parameter2Value);
						}
					}
					else if (ModelPropertyName == LanguageTerms.StringLength)
					{
						if (propertyValue != null && propertyValue is String)
						{
							propertyValue = (propertyValue as String).Length;
						}
						else
						{
							propertyValue = 0;
						}
					}
					else if (ModelPropertyName == LanguageTerms.ColumnMethod)
					{
						string dbField = ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
						try
						{
							propertyValue = templateContext.DbReader[dbField].GetString();
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileMethod)
					{
						string path = ModelProperty.GetPropertyStringValue(solutionContext, templateContext, modelContext, modelContext, interpreterType);
						try
						{
							propertyValue = FileHelper.GetText(path);
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileExistsMethod)
					{
						string path = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
						propertyValue = File.Exists(path);
					}
				}
				else
				{
					string parameter1Value = String.Empty;
					if (Parameter1 != null)
					{
						parameter1Value = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
					}
					string parameter2Value = String.Empty;
					if (Parameter2 != null)
					{
						parameter2Value = Parameter2.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
					}
					if (ModelPropertyName == LanguageTerms.ColumnMethod)
					{
						try
						{
							propertyValue = templateContext.DbReader[parameter1Value].GetString();
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileMethod)
					{
						try
						{
							propertyValue = FileHelper.GetText(parameter1Value);
						}
						catch
						{
							propertyValue = "<" + TemplateProperty.TemplateName + ">";
						}
					}
					else if (ModelPropertyName == LanguageTerms.FileExistsMethod)
					{
						string path = Parameter1.GetStringValue(solutionContext, templateContext, modelContext, interpreterType);
						propertyValue = File.Exists(path);
					}
					else if (ModelPropertyName == LanguageTerms.LogMethod)
					{
						propertyValue = solutionContext.GetStringLoggedValue(parameter1Value, parameter2Value);
					}
					else if (ModelPropertyName == LanguageTerms.HasPropertyNamed)
					{
						if (modelContext is Entity)
						{
							propertyValue = (modelContext as Entity).HasPropertyNamed(parameter1Value);
						}
						else
						{
							propertyValue = null;
						}
					}
					else if (ModelPropertyName == LanguageTerms.IsRelatedToProperty)
					{
						bool isRelatedToProperty = false;
						if (modelContext is Method)
						{
							// look for a property in the context stack
							Property propertyContext = null;
							int popCount = 0;
							while (popCount < templateContext.StackSize && propertyContext == null)
							{
								popCount++;
								propertyContext = templateContext.GetModelContext(popCount) as Property;
							}
							if (propertyContext != null)
							{
								// check to see if property and method have a corresponding relationship
								foreach (MethodRelationship loopRelationship in (modelContext as Method).MethodRelationshipList)
								{
									if (propertyContext.PropertyRelationshipList.Find("RelationshipID", loopRelationship.RelationshipID) != null)
									{
										isRelatedToProperty = true;
										break;
									}
								}
							}
						}
						propertyValue = isRelatedToProperty;
					}
					else if (ModelPropertyName == LanguageTerms.TextProperty)
					{
						propertyValue = templateContext.ContentCodeBuilder.ToString();
					}
					else if (ModelPropertyName == LanguageTerms.PathProperty)
					{
						propertyValue = templateContext.OutputCodeBuilder.ToString();
					}
					//else if (ModelPropertyName == LanguageTerms.LibraryDirectoryProperty)
					//{
					//    propertyValue = BusinessConfiguration.LibraryDirectory;
					//}
					else if (ModelPropertyName == LanguageTerms.ItemFileProperty)
					{
						propertyValue = solutionContext.CurrentFileText;
					}
					else if (ModelPropertyName == LanguageTerms.ItemPathProperty)
					{
						propertyValue = solutionContext.CurrentFilePath;
					}
					else
					{
						IDomainEnterpriseObject initialContext = modelContext;
						if (templateContext.PopCount > 0)
						{
							initialContext = templateContext.GetModelContext(templateContext.PopCount);
							templateContext.PopCount = 0;
						}
						IDomainEnterpriseObject propertyModelContext = GetModelContext(solutionContext, templateContext, initialContext);
						if (TemplateProperty != null && String.IsNullOrEmpty(ModelPropertyName))
						{
							// if value is from a declared variable or parameter, return that value first
							if (templateContext.Variables.HasKey(TemplateProperty.TemplateName) == true)
							{
								return templateContext.Variables[TemplateProperty.TemplateName];
							}
							else if (templateContext.Parameters.HasKey(TemplateProperty.TemplateName) == true)
							{
								return templateContext.Parameters[TemplateProperty.TemplateName];
							}
							return TemplateProperty.GetCode(solutionContext, templateContext, GetModelContext(solutionContext, templateContext, propertyModelContext), parameterModelContext, interpreterType);
						}
						else
						{
							IDomainEnterpriseObject currentModelContext = propertyModelContext;
							bool isPropertyFound = false;
							while (propertyModelContext != null && propertyValue == null)
							{
								if (ModelPropertyName != null)
								{
									if (ModelPropertyName == LanguageTerms.ItemIndexProperty)
									{
										propertyValue = templateContext.ItemIndex.ToString();
										isPropertyFound = true;
									}
									else if (ModelPropertyName == LanguageTerms.TemplateProperty)
									{
										isPropertyFound = true;
										if (propertyModelContext is Project)
										{
											try
											{
												ITemplate template = null;
												if (templateContext is SpecTemplate)
												{
													template = new SpecTemplate();
												}
												else
												{
													template = new CodeTemplate();
												}
												template.FilePath = (propertyModelContext as Project).TemplatePath;
												template.LoadTemplateFileData(false);
												string templateName = template.TemplateName;
												string code = String.Empty;
												if (templateContext is SpecTemplate)
												{
													template = solutionContext.SpecTemplates[templateContext.GetTemplateKey(propertyModelContext, templateName)] as SpecTemplate;
												}
												else
												{
													template = solutionContext.CodeTemplates[templateContext.GetTemplateKey(propertyModelContext, templateName)] as CodeTemplate;
												}
												if (template != null)
												{
													template.GenerateContent(solutionContext, template, modelContext, false, null);
													propertyValue = template.ContentCodeBuilder.ToString();
												}
												propertyValue = "<" + templateName + ">";
											}
											catch (ApplicationAbortException ex)
											{
												throw ex;
											}
											catch (System.Exception ex)
											{
												LogException(solutionContext, templateContext, propertyModelContext, ex, interpreterType);
											}
										}
									}
									else if (propertyModelContext.GetPropertyInfo(ModelPropertyName) != null)
									{
										isPropertyFound = true;
										propertyValue = propertyModelContext.GetPropertyValue(ModelPropertyName);
									}
									else if (propertyModelContext is ObjectInstance && solutionContext.ModelPropertyNames[ModelPropertyName].GetString() == ModelPropertyName)
									{
										propertyValue = (propertyModelContext as ObjectInstance).GetStringValue(ModelPropertyName, out isPropertyFound);
									}
								}
								else
								{
									if (ModelContext != null)
									{
										propertyValue = ModelContext.GetPropertyObjectValue(solutionContext, templateContext, modelContext);
									}
									else if (CurrentItem != null)
									{
										propertyValue = CurrentItem.GetPropertyObjectValue(solutionContext, templateContext, modelContext);
									}
									else if (SpecCurrentItem != null)
									{
										propertyValue = SpecCurrentItem.GetPropertyObjectValue(solutionContext, templateContext, modelContext);
									}
								}
								if (propertyValue == null)
								{
									propertyModelContext = propertyModelContext.GetParentItem();
								}
							}
							if (ModelPropertyName != null && isPropertyFound == false)
							{
								LogException(solutionContext, templateContext, propertyModelContext, String.Format(DisplayValues.Exception_PropertyNotFound, ModelPropertyName, currentModelContext.GetType().Name), interpreterType);
							}
							if (propertyValue != null && propertyValue.ToString() == "True")
							{
								propertyValue = true;
							}
							if (propertyValue != null && propertyValue.ToString() == "False")
							{
								propertyValue = false;
							}
						}
					}
				}
			}
			catch (ApplicationAbortException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				LogException(solutionContext, templateContext, modelContext, ex, interpreterType);
			}
			return propertyValue;
		}

		///--------------------------------------------------------------------------------
		/// <summary>Get the model context associated with this node.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The parent model context.</param>
		///--------------------------------------------------------------------------------
		public IDomainEnterpriseObject GetModelContext(Solution solutionContext, ITemplate templateContext, IDomainEnterpriseObject modelContext)
		{
			if (ModelContext != null)
			{
				bool isValidContext;
				return ModelContext.GetModelContext(solutionContext, templateContext, modelContext, out isValidContext);
			}
			else if (CurrentItem != null)
			{
				return CurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
			}
			else if (SpecCurrentItem != null)
			{
				return SpecCurrentItem.GetModelContext(solutionContext, templateContext, modelContext);
			}
			return modelContext;
		}
	}
}
