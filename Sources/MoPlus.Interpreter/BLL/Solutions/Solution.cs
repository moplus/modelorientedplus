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
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Diagrams;
using Irony.Parsing;
using MoPlus.Interpreter.Resources;
using MoPlus.Interpreter.Events;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using MoPlus.IO;

namespace MoPlus.Interpreter.BLL.Solutions
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the Solution class
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/20/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class Solution : BusinessObjectBase
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
					if (!String.IsNullOrEmpty(SolutionDirectory))
					{		
						Uri uri = new Uri(Path.Combine(SolutionDirectory, TemplatePath));
						string path = Path.GetFullPath(uri.AbsolutePath).ToString();  
						return path;
					}
				}
				return null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EntityCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int EntityCount
		{
			get
			{
				if (EntityList != null)
				{
					return EntityList.Count;
				}
				return 0;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ProjectCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int ProjectCount
		{
			get
			{
				if (ProjectList != null)
				{
					return ProjectList.Count;
				}
				return 0;
			}
		}

		protected string _sourceDbServerName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the primary source db server.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string SourceDbServerName
		{
			get
			{
				if (_sourceDbServerName == null)
				{
					// TODO: expand this to handle multiple database sources
					foreach (DatabaseSource loopSource in DatabaseSourceList)
					{
						_sourceDbServerName = loopSource.SourceDbServerName;
						break;
					}
				}
				return _sourceDbServerName;
			}
			set
			{
				_sourceDbServerName = value;
			}
		}

		protected string _sourceDbName = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the primary source db.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string SourceDbName
		{
			get
			{
				if (_sourceDbName == null)
				{
					// TODO: expand this to handle multiple database sources
					foreach (DatabaseSource loopSource in DatabaseSourceList)
					{
						_sourceDbName = loopSource.SourceDbName;
						break;
					}
				}
				return _sourceDbName;
			}
			set
			{
				_sourceDbName = value;
			}
		}

		private NameObjectCollection _modelObjectNames = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelObjectNames.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection ModelObjectNames
		{
			get
			{
				if (_modelObjectNames == null)
				{
					_modelObjectNames = new NameObjectCollection();
					foreach (ModelObject modelObject in ModelObjectList)
					{
						_modelObjectNames[modelObject.ModelObjectName] = modelObject.ModelObjectName;
					}
				}
				return _modelObjectNames;
			}
			set
			{
				_modelObjectNames = value;
			}
		}

		private NameObjectCollection _modelPropertyNames = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ModelPropertyNames.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection ModelPropertyNames
		{
			get
			{
				if (_modelPropertyNames == null)
				{
					_modelPropertyNames = new NameObjectCollection();
					foreach (ModelProperty modelProperty in ModelPropertyList)
					{
						_modelPropertyNames[modelProperty.ModelPropertyName] = modelProperty.ModelPropertyName;
					}
				}
				return _modelPropertyNames;
			}
			set
			{
				_modelObjectNames = value;
			}
		}

		private Parser _codeTemplateContentParser = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CodeTemplateContentParser.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Parser CodeTemplateContentParser
		{
			get
			{
				if (_codeTemplateContentParser == null)
				{
					CodeTemplateContentGrammar grammar = new CodeTemplateContentGrammar(this);
					_codeTemplateContentParser = new Parser(grammar);
				}
				return _codeTemplateContentParser;
			}
			set
			{
				_codeTemplateContentParser = value;
			}
		}

		private Parser _codeTemplateOutputParser = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CodeTemplatOutputParser.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Parser CodeTemplatOutputParser
		{
			get
			{
				if (_codeTemplateOutputParser == null)
				{
					CodeTemplateOutputGrammar grammar = new CodeTemplateOutputGrammar(this);
					_codeTemplateOutputParser = new Parser(grammar);
				}
				return _codeTemplateOutputParser;
			}
			set
			{
				_codeTemplateOutputParser = value;
			}
		}

		private Parser _specTemplateContentParser = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SpecTemplateContentParser.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Parser SpecTemplateContentParser
		{
			get
			{
				if (_specTemplateContentParser == null)
				{
					SpecTemplateContentGrammar grammar = new SpecTemplateContentGrammar();
					_specTemplateContentParser = new Parser(grammar);
				}
				return _specTemplateContentParser;
			}
			set
			{
				_specTemplateContentParser = value;
			}
		}

		private Parser _specTemplateOutputParser = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SpecTemplateOutputParser.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Parser SpecTemplateOutputParser
		{
			get
			{
				if (_specTemplateOutputParser == null)
				{
					SpecTemplateOutputGrammar grammar = new SpecTemplateOutputGrammar();
					_specTemplateOutputParser = new Parser(grammar);
				}
				return _specTemplateOutputParser;
			}
			set
			{
				_specTemplateOutputParser = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StopContentParsing.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool StopContentParsing { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StopOutputParsing.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool StopOutputParsing { get; set; }

		protected EnterpriseDataObjectList<Entity> _entityList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Entity> EntityList
		{
			get
			{
				if (_entityList == null)
				{
					_entityList = new EnterpriseDataObjectList<Entity>();
				}
				return _entityList;
			}
			set
			{
				_entityList = value;
			}
		}

		protected EnterpriseDataObjectList<Index> _indexList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Index lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Index> IndexList
		{
			get
			{
				if (_indexList == null)
				{
					_indexList = new EnterpriseDataObjectList<Index>();
				}
				return _indexList;
			}
			set
			{
				_indexList = value;
			}
		}

		protected EnterpriseDataObjectList<IndexProperty> _indexPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IndexProperty lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<IndexProperty> IndexPropertyList
		{
			get
			{
				if (_indexPropertyList == null)
				{
					_indexPropertyList = new EnterpriseDataObjectList<IndexProperty>();
				}
				return _indexPropertyList;
			}
			set
			{
				_indexPropertyList = value;
			}
		}

		protected EnterpriseDataObjectList<Relationship> _relationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Relationship lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Relationship> RelationshipList
		{
			get
			{
				if (_relationshipList == null)
				{
					_relationshipList = new EnterpriseDataObjectList<Relationship>();
				}
				return _relationshipList;
			}
			set
			{
				_relationshipList = value;
			}
		}

		protected EnterpriseDataObjectList<RelationshipProperty> _relationshipPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RelationshipProperty lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<RelationshipProperty> RelationshipPropertyList
		{
			get
			{
				if (_relationshipPropertyList == null)
				{
					_relationshipPropertyList = new EnterpriseDataObjectList<RelationshipProperty>();
				}
				return _relationshipPropertyList;
			}
			set
			{
				_relationshipPropertyList = value;
			}
		}

		protected EnterpriseDataObjectList<Method> _methodList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Method lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Method> MethodList
		{
			get
			{
				if (_methodList == null)
				{
					_methodList = new EnterpriseDataObjectList<Method>();
				}
				return _methodList;
			}
			set
			{
				_methodList = value;
			}
		}

		protected EnterpriseDataObjectList<Parameter> _parameterList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Parameter lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Parameter> ParameterList
		{
			get
			{
				if (_parameterList == null)
				{
					_parameterList = new EnterpriseDataObjectList<Parameter>();
				}
				return _parameterList;
			}
			set
			{
				_parameterList = value;
			}
		}

		protected EnterpriseDataObjectList<PropertyRelationship> _propertyRelationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<PropertyRelationship> PropertyRelationshipList
		{
			get
			{
				if (_propertyRelationshipList == null)
				{
					_propertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>();
				}
				return _propertyRelationshipList;
			}
			set
			{
				_propertyRelationshipList = value;
			}
		}

		protected EnterpriseDataObjectList<MethodRelationship> _methodRelationshipList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets MethodRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<MethodRelationship> MethodRelationshipList
		{
			get
			{
				if (_methodRelationshipList == null)
				{
					_methodRelationshipList = new EnterpriseDataObjectList<MethodRelationship>();
				}
				return _methodRelationshipList;
			}
			set
			{
				_methodRelationshipList = value;
			}
		}

		protected EnterpriseDataObjectList<Stage> _stageList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Stage lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Stage> StageList
		{
			get
			{
				if (_stageList == null)
				{
					_stageList = new EnterpriseDataObjectList<Stage>();
				}
				return _stageList;
			}
			set
			{
				_stageList = value;
			}
		}

		protected EnterpriseDataObjectList<StageTransition> _stageTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StageTransition lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StageTransition> StageTransitionList
		{
			get
			{
				if (_stageTransitionList == null)
				{
					_stageTransitionList = new EnterpriseDataObjectList<StageTransition>();
				}
				return _stageTransitionList;
			}
			set
			{
				_stageTransitionList = value;
			}
		}

		protected EnterpriseDataObjectList<Step> _stepList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Step lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Step> StepList
		{
			get
			{
				if (_stepList == null)
				{
					_stepList = new EnterpriseDataObjectList<Step>();
				}
				return _stepList;
			}
			set
			{
				_stepList = value;
			}
		}

		protected EnterpriseDataObjectList<StepTransition> _stepTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StepTransition lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StepTransition> StepTransitionList
		{
			get
			{
				if (_stepTransitionList == null)
				{
					_stepTransitionList = new EnterpriseDataObjectList<StepTransition>();
				}
				return _stepTransitionList;
			}
			set
			{
				_stepTransitionList = value;
			}
		}

		protected EnterpriseDataObjectList<StateModel> _stateModelList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateModel lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StateModel> StateModelList
		{
			get
			{
				if (_stateModelList == null)
				{
					_stateModelList = new EnterpriseDataObjectList<StateModel>();
				}
				return _stateModelList;
			}
			set
			{
				_stateModelList = value;
			}
		}

		protected EnterpriseDataObjectList<State> _stateList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets State lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<State> StateList
		{
			get
			{
				if (_stateList == null)
				{
					_stateList = new EnterpriseDataObjectList<State>();
				}
				return _stateList;
			}
			set
			{
				_stateList = value;
			}
		}

		protected EnterpriseDataObjectList<StateTransition> _stateTransitionList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateTransition lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StateTransition> StateTransitionList
		{
			get
			{
				if (_stateTransitionList == null)
				{
					_stateTransitionList = new EnterpriseDataObjectList<StateTransition>();
				}
				return _stateTransitionList;
			}
			set
			{
				_stateTransitionList = value;
			}
		}

		protected EnterpriseDataObjectList<ModelObject> _modelObjectList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObject lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<ModelObject> ModelObjectList
		{
			get
			{
				if (_modelObjectList == null)
				{
					_modelObjectList = new EnterpriseDataObjectList<ModelObject>();
				}
				return _modelObjectList;
			}
			set
			{
				_modelObjectList = value;
			}
		}

		protected EnterpriseDataObjectList<ObjectInstance> _objectInstanceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ObjectInstance lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<ObjectInstance> ObjectInstanceList
		{
			get
			{
				if (_objectInstanceList == null)
				{
					_objectInstanceList = new EnterpriseDataObjectList<ObjectInstance>();
				}
				return _objectInstanceList;
			}
			set
			{
				_objectInstanceList = value;
			}
		}

		protected EnterpriseDataObjectList<ModelProperty> _modelPropertyList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelProperty lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<ModelProperty> ModelPropertyList
		{
			get
			{
				if (_modelPropertyList == null)
				{
					_modelPropertyList = new EnterpriseDataObjectList<ModelProperty>();
				}
				return _modelPropertyList;
			}
			set
			{
				_modelPropertyList = value;
			}
		}

		protected EnterpriseDataObjectList<PropertyInstance> _propertyInstanceList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyInstance lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<PropertyInstance> PropertyInstanceList
		{
			get
			{
				if (_propertyInstanceList == null)
				{
					_propertyInstanceList = new EnterpriseDataObjectList<PropertyInstance>();
				}
				return _propertyInstanceList;
			}
			set
			{
				_propertyInstanceList = value;
			}
		}

		protected EnterpriseDataObjectList<Enumeration> _enumerationList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Enumeration lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Enumeration> EnumerationList
		{
			get
			{
				if (_enumerationList == null)
				{
					_enumerationList = new EnterpriseDataObjectList<Enumeration>();
				}
				return _enumerationList;
			}
			set
			{
				_enumerationList = value;
			}
		}

		protected EnterpriseDataObjectList<Value> _valueList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Value lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Value> ValueList
		{
			get
			{
				if (_valueList == null)
				{
					_valueList = new EnterpriseDataObjectList<Value>();
				}
				return _valueList;
			}
			set
			{
				_valueList = value;
			}
		}

		protected EnterpriseDataObjectList<DiagramEntity> _diagramEntityList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramEntity lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<DiagramEntity> DiagramEntityList
		{
			get
			{
				if (_diagramEntityList == null)
				{
					_diagramEntityList = new EnterpriseDataObjectList<DiagramEntity>();
				}
				return _diagramEntityList;
			}
			set
			{
				_diagramEntityList = value;
			}
		}

		protected NameObjectCollection _usedModelIDs = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the collection of IDs used in the model.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection UsedModelIDs
		{
			get
			{
				if (_usedModelIDs == null)
				{
					_usedModelIDs = new NameObjectCollection();
				}
				return _usedModelIDs;
			}
			set
			{
				_usedModelIDs = value;
			}
		}

		protected EnterpriseDataObjectList<CollectionItem> _referencedModelIDs = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the collection of reverse engineering item IDs
		/// referenced by forward engineering items.</summary>
		///--------------------------------------------------------------------------------
		[XmlArray(ElementName = "ReferencedModelIDs")]
		[XmlArrayItem(typeof(CollectionItem), ElementName = "CollectionItem")]
		[DataArrayItem(ElementName = "ReferencedModelIDs")]
		public EnterpriseDataObjectList<CollectionItem> ReferencedModelIDs
		{
			get
			{
				if (_referencedModelIDs == null)
				{
					_referencedModelIDs = new EnterpriseDataObjectList<CollectionItem>();
				}
				return _referencedModelIDs;
			}
			set
			{
				_referencedModelIDs = value;
			}
		}

		private NameObjectCollection _pasteNewGuids = new NameObjectCollection();
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PasteNewGuids for paste operations.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection PasteNewGuids
		{
			get
			{
				return _pasteNewGuids;
			}
			set
			{
				_pasteNewGuids = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the callback worker, to report progress, etc.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public BackgroundWorker CallbackWorker { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the current progress percentage, to report progress, etc.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CurrentProgress { get; set; }

		private int _buildModelProgress = 0;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the desired amount of progress bar to use
		/// for build model.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int BuildModelProgress
		{
			get
			{
				return _buildModelProgress;
			}
			set
			{
				_buildModelProgress = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the current user name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string CurrentUserName
		{
			get
			{
				return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the solution directory.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		private string _solutionDirectory;
		public string SolutionDirectory
		{
			get
			{
				return _solutionDirectory;
			}
			set
			{
				_solutionDirectory = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the output solution file path.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string OutputSolutionFilePath
		{
			get
			{
				return SolutionDirectory + "\\" + OutputSolutionFileName;
			}
		}

		protected EnterpriseDataObjectList<Entity> _forwardEntityList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets forward Entity lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Entity> ForwardEntityList
		{
			get
			{
				if (_forwardEntityList == null)
				{
					_forwardEntityList = new EnterpriseDataObjectList<Entity>();
				}
				return _forwardEntityList;
			}
			set
			{
				_forwardEntityList = value;
			}
		}

		protected EnterpriseDataObjectList<Feature> _forwardFeatureList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets forward Feature lists.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Feature> ForwardFeatureList
		{
			get
			{
				if (_forwardFeatureList == null)
				{
					_forwardFeatureList = new EnterpriseDataObjectList<Feature>();
				}
				return _forwardFeatureList;
			}
			set
			{
				_forwardFeatureList = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets FeaturesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Feature> FeaturesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntitiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Entity> EntitiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IndexPropertiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<IndexProperty> IndexPropertiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets IndexesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Index> IndexesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RelationshipsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Relationship> RelationshipsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets RelationshipPropertiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<RelationshipProperty> RelationshipPropertiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets MethodsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Method> MethodsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ParametersToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Parameter> ParametersToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyRelationshipsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<PropertyRelationship> PropertyRelationshipsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets MethodRelationshipsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<MethodRelationship> MethodRelationshipsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets CollectionsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Collection> CollectionsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyReferencesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<PropertyReference> PropertyReferencesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Property> PropertiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntityReferencesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<EntityReference> EntityReferencesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateModelsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StateModel> StateModelsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StatesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<State> StatesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StateTransitionsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StateTransition> StateTransitionsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets WorkflowsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Workflow> WorkflowsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StagesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Stage> StagesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StepsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Step> StepsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StageTransitionsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StageTransition> StageTransitionsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets StepTransitionsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<StepTransition> StepTransitionsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets AuditPropertiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<AuditProperty> AuditPropertiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Model> ModelsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelObjectsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<ModelObject> ModelObjectsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ObjectInstanceToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<ObjectInstance> ObjectInstancesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ModelPropertiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<ModelProperty> ModelPropertiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyInstancesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<PropertyInstance> PropertyInstancesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EnumerationsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Enumeration> EnumerationsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ValuesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Value> ValuesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DatabaseSourcesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<DatabaseSource> DatabaseSourcesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets XmlSourcesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<XmlSource> XmlSourcesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets ProjectsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Project> ProjectsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets PropertyBasesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<PropertyBase> PropertyBasesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramsToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<Diagram> DiagramsToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramEntitiesToMerge.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<DiagramEntity> DiagramEntitiesToMerge { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentProject.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Project CurrentProject
		{
			get
			{
				return BusinessConfiguration.CurrentProject;
			}
			set
			{
				BusinessConfiguration.CurrentProject = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentDatabaseSource.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public DatabaseSource CurrentDatabaseSource { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentXmlSource.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public XmlSource CurrentXmlSource { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentDiagram.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Diagram CurrentDiagram { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentDiagramEntity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public DiagramEntity CurrentDiagramEntity { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrentPropertyBase.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public PropertyBase CurrentPropertyBase { get; set; }

		private StrongNameObjectCollection _codeTemplates = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the set of preparsed CodeTemplates.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StrongNameObjectCollection CodeTemplates
		{
			get
			{
				if (_codeTemplates == null)
				{
					_codeTemplates = new StrongNameObjectCollection();
				}
				return _codeTemplates;
			}
			set
			{
				_codeTemplates = value;
			}
		}

		private StrongNameObjectCollection _specTemplates = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the set of preparsed SpecTemplates.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public StrongNameObjectCollection SpecTemplates
		{
			get
			{
				if (_specTemplates == null)
				{
					_specTemplates = new StrongNameObjectCollection();
				}
				return _specTemplates;
			}
			set
			{
				_specTemplates = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the set of project Templates.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public EnterpriseDataObjectList<Template> ProjectTemplates
		{
			get
			{
				EnterpriseDataObjectList<Template> _projectTemplates = new EnterpriseDataObjectList<Template>();
				for (int i = 0; i < CodeTemplates.Count; i++)
				{
					if (CodeTemplates[i] is Template)
					{
						Template templateItem = CodeTemplates[i] as Template;
						if (templateItem.NodeName == Enum.GetName(typeof(ModelContextTypeCode), ModelContextTypeCode.Project) && templateItem.IsTopLevelTemplate == true && !String.IsNullOrEmpty(templateItem.TemplateOutput))
						{
							_projectTemplates.Add(templateItem);
						}
					}
				}
				return _projectTemplates;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsSampleMode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		private bool _isSampleMode = false;
		public bool IsSampleMode
		{
			get
			{
				return _isSampleMode;
			}
			set
			{
				_isSampleMode = value;
				NeedsSample = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets NeedsSample (whether template gets a random data sample).</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool NeedsSample { get; set; }

		private NameObjectCollection _logggedValues = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the set of LoggedValues.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection LoggedValues
		{
			get
			{
				if (_logggedValues == null)
				{
					_logggedValues = new NameObjectCollection();
				}
				return _logggedValues;
			}
			set
			{
				_logggedValues = value;
			}
		}

		private NameObjectCollection _logggedErrors = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the set of LoggedErrors.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection LoggedErrors
		{
			get
			{
				if (_logggedErrors == null)
				{
					_logggedErrors = new NameObjectCollection();
				}
				return _logggedErrors;
			}
			set
			{
				_logggedErrors = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentFilePath.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string CurrentFilePath { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentFileText.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string CurrentFileText { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EntityProgressAmount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public double EntityProgressAmount { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets OutputSolutionProgress.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public double OutputSolutionProgress { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets BuildModelPercentage.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int BuildModelPercentage { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets BuildModelWork.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int BuildModelWork { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentBuildModelProgress.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CurrentBuildModelProgress { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets BuildCodeWork.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int BuildCodeWork { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentBuildCodeProgress.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CurrentBuildCodeProgress { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplatesExecuted.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int TemplatesExecuted { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CachedTemplatesExecuted.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CachedTemplatesExecuted { get; set; }

		private NameObjectCollection _templatesUsed = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TemplatesUsed.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public NameObjectCollection TemplatesUsed
		{
			get
			{
				if (_templatesUsed == null)
				{
					_templatesUsed = new NameObjectCollection();
				}
				return _templatesUsed;
			}
			set
			{
				_templatesUsed = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets CurrentTotalProgress.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CurrentTotalProgress
		{
			get
			{
				int progress = 0;
				if (progress > 100)
				{
					progress = 100;
				}
				if (BuildModelPercentage > 0 && BuildModelWork > 0)
				{
					progress = (BuildModelPercentage * CurrentBuildModelProgress) / BuildModelWork;
				}
				if ((100 - BuildModelPercentage) > 0 && BuildCodeWork > 0)
				{
					progress += ((100 - BuildModelPercentage) * CurrentBuildCodeProgress) / BuildCodeWork;
				}
				if (progress < 0)
				{
					progress = 0;
				}
				return progress;
			}
		}

		private int _currentErrorCount = 0;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets CurrentErrorCount.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int CurrentErrorCount
		{
			get
			{
				return _currentErrorCount;
			}
			set
			{
				_currentErrorCount = value;
				if (_currentErrorCount > BusinessConfiguration.MaxErrorsBeforeAbort)
				{
					lock (DebugHelper.DEBUG_OBJECT)
					{
						if (DebugHelper.DebugAction == DebugAction.Run || DebugHelper.DebugAction == DebugAction.Continue || DebugHelper.DebugAction == DebugAction.Breaking)
						{
							DebugHelper.DebugAction = DebugAction.Stop;
							Monitor.Pulse(DebugHelper.DEBUG_OBJECT);
						}
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets UseTemplateCache.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool UseTemplateCache
		{
			get
			{
				return BusinessConfiguration.UseTemplateCache;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TemplateCacheMaxContentSize.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public int TemplateCacheMaxContentSize
		{
			get
			{
				return BusinessConfiguration.TemplateCacheMaxContentSize;
			}
		}

        public string SpecTemplatesDirectory { get; set; }
        public string CodeTemplatesDirectory { get; set; }

		#endregion "Fields and Properties"

		#region "Events"
		public delegate void StatusEventHandler(object sender, StatusEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to show status information.</summary>
		///--------------------------------------------------------------------------------
		public event StatusEventHandler StatusChanged;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles show status information.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnStatusChanged(object sender, StatusEventArgs args)
		{
			if (StatusChanged != null)
			{
				StatusChanged(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling requests to request output information.</summary>
		///--------------------------------------------------------------------------------
		public event StatusEventHandler OutputRequested;

		///--------------------------------------------------------------------------------
		/// <summary>This method handles output requested information.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnOutputRequested(object sender, StatusEventArgs args)
		{
			if (OutputRequested != null)
			{
				OutputRequested(this, args);
			}
		}

		public delegate void DebugEventHandler(object sender, DebugEventArgs args);
		///--------------------------------------------------------------------------------
		/// <summary>This event is for handling breakpoints.</summary>
		///--------------------------------------------------------------------------------
		public event DebugEventHandler BreakpointReached;

		///--------------------------------------------------------------------------------
		/// <summary>This method breakpoints.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected void OnBreakpointReached(object sender, DebugEventArgs args)
		{
			if (BreakpointReached != null)
			{
				BreakpointReached(this, args);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>Handle breakpoint.</summary>
		/// 
		/// <param name="interpreterType">The type of interpretation to perform.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="modelContext">The associated model context.</param>
		/// <param name="lineNumber">The associated line number.</param>
		///--------------------------------------------------------------------------------
		public void HandleBreakpoint(InterpreterTypeCode interpreterType, ITemplate templateContext, IDomainEnterpriseObject modelContext, int lineNumber)
		{
			DebugEventArgs args = new DebugEventArgs();
			args.InterpreterType = interpreterType;
			args.SolutionContext = this;
			args.TemplateContext = templateContext;
			args.ModelContext = modelContext;
			args.LineNumber = lineNumber;
			OnBreakpointReached(this, args);
		}

		#endregion "Events"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from a directory into the solutin.</summary>
		///--------------------------------------------------------------------------------
		public void LoadSpecTemplateDirectories()
		{
			foreach (DatabaseSource source in DatabaseSourceList)
			{
				// load templates
				if (!String.IsNullOrEmpty(source.TemplatePath))
				{
					LoadSpecTemplateDirectory(Directory.GetParent(source.TemplateAbsolutePath).FullName, Directory.GetParent(source.TemplateAbsolutePath).FullName);
				}
			}
			foreach (XmlSource source in XmlSourceList)
			{
				// load templates
				if (!String.IsNullOrEmpty(source.TemplatePath))
				{
					LoadSpecTemplateDirectory(Directory.GetParent(source.TemplateAbsolutePath).FullName, Directory.GetParent(source.TemplateAbsolutePath).FullName);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from a directory into the solution.</summary>
		/// 
		/// <param name="directory">The directory to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadSpecTemplateDirectory(string specificationDirectory, string directory)
		{
			if (!String.IsNullOrEmpty(directory))
			{
				foreach (string file in Directory.GetFiles(directory, "*.mps"))
				{
					SpecTemplate template = new SpecTemplate();
					template.TemplateID = Guid.NewGuid();
					template.Solution = this;
					template.FilePath = file;
					template.LoadTemplateFileData();
					SpecTemplates[template.TemplateKey] = template;
					template.SpecificationDirectory = specificationDirectory;
				}
				foreach (string subDirectory in Directory.GetDirectories(directory))
				{
					LoadSpecTemplateDirectory(specificationDirectory, subDirectory);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads code templates from a directory into the solution.</summary>
		///--------------------------------------------------------------------------------
		public void LoadCodeTemplateDirectories()
		{
			// load templates
			if (!String.IsNullOrEmpty(TemplatePath))
			{
				CodeTemplates.Clear();
				LoadCodeTemplateDirectory(Directory.GetParent(TemplateAbsolutePath).FullName);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads templates from a directory into the solution.</summary>
		/// 
		/// <param name="directory">The directory to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadCodeTemplateDirectory(string directory)
		{
			if (!String.IsNullOrEmpty(directory))
			{
				foreach (string file in Directory.GetFiles(directory, "*.mpt"))
				{
					CodeTemplate template = new CodeTemplate();
					template.TemplateID = Guid.NewGuid();
					template.Solution = this;
					template.FilePath = file;
					template.LoadTemplateFileData();
					CodeTemplates[template.TemplateKey] = template;
				}
				foreach (string subDirectory in Directory.GetDirectories(directory))
				{
					LoadCodeTemplateDirectory(subDirectory);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public Solution GetForwardInstance()
		{
			Solution forwardItem = new Solution();
			forwardItem.TransformDataFromObject(this, null, false);
			foreach (CollectionItem item in ReferencedModelIDs)
			{
				CollectionItem forwardChildItem = new CollectionItem();
				forwardChildItem.TransformDataFromObject(item, null, false);
				forwardItem.ReferencedModelIDs.Add(forwardChildItem);
			}
			foreach (Project item in ProjectList)
			{
				item.Solution = this;
				Project forwardChildItem = item.GetForwardInstance();
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.ProjectList.Add(forwardChildItem);
				}
			}
			foreach (AuditProperty item in AuditPropertyList)
			{
				item.Solution = this;
				AuditProperty forwardChildItem = item.GetForwardInstance(forwardItem);
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.AuditPropertyList.Add(forwardChildItem);
				}
			}
			foreach (DatabaseSource item in DatabaseSourceList)
			{
				item.Solution = this;
				DatabaseSource forwardChildItem = item.GetForwardInstance();
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.DatabaseSourceList.Add(forwardChildItem);
				}
			}
			foreach (XmlSource item in XmlSourceList)
			{
				item.Solution = this;
				XmlSource forwardChildItem = item.GetForwardInstance();
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.XmlSourceList.Add(forwardChildItem);
				}
			}
			foreach (Feature item in FeatureList)
			{
				item.Solution = this;
				Feature forwardChildItem = item.GetForwardInstance(forwardItem);
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.FeatureList.Add(forwardChildItem);
				}
			}
			foreach (Diagram item in DiagramList)
			{
				item.Solution = this;
				Diagram forwardChildItem = item.GetForwardInstance(forwardItem);
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.DiagramList.Add(forwardChildItem);
				}
			}
			foreach (Model item in ModelList)
			{
				item.Solution = this;
				Model forwardChildItem = item.GetForwardInstance(forwardItem);
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.ModelList.Add(forwardChildItem);
				}
			}
			foreach (Workflow item in WorkflowList)
			{
				item.Solution = this;
				Workflow forwardChildItem = item.GetForwardInstance(forwardItem);
				if (forwardChildItem != null)
				{
					forwardChildItem.Solution = forwardItem;
					forwardItem.WorkflowList.Add(forwardChildItem);
				}
			}
			return forwardItem;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method clears the code template cache.</summary>
		///--------------------------------------------------------------------------------
		public void ClearSpecTemplateCache()
		{
			LoggedValues.Clear();
			LoggedValues = null;
			for (int i = 0; i < SpecTemplates.Count; i++)
			{
				if (SpecTemplates[i] is SpecTemplate)
				{
					SpecTemplate template = SpecTemplates[i] as SpecTemplate;
					template.CachedContent = null;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method clears the run time call data for the set of spec templates.</summary>
		///--------------------------------------------------------------------------------
		public void ClearSpecTemplateCallData()
		{
			for (int i = 0; i < SpecTemplates.Count; i++)
			{
				SpecTemplate template = SpecTemplates[i] as SpecTemplate;
				if (template != null)
				{
					template.CachedContent.Clear();
					template.HasErrors = false;
					template.IsTemplateUtilized = false;
					template.TemplateCallInfo = template.TemplateName;
					template.TemplateCalls.Clear();
					template.TemplateCalledBy.Clear();
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds the run time call data for the set of spec templates.</summary>
		///--------------------------------------------------------------------------------
		public void AddSpecTemplateCallData()
		{
			for (int i = 0; i < SpecTemplates.Count; i++)
			{
				if (SpecTemplates[i] is SpecTemplate)
				{
					SpecTemplate template = SpecTemplates[i] as SpecTemplate;
					if (template.TemplateCalls.Count > 0 || template.TemplateCalledBy.Count > 0)
					{
						StringBuilder templateCallInfo = new StringBuilder();
						if (template.TemplateCalls.Count > 0)
						{
							templateCallInfo.Append(DisplayValues.Template_CallIntro);
							foreach (KeyValuePair<string, int> item in template.TemplateCalls)
							{
								templateCallInfo.Append("\r\n").Append(item.Key).Append("(").Append(item.Value.ToString()).Append(")");
							}
						}
						if (template.TemplateCalledBy.Count > 0)
						{
							if (template.TemplateCalls.Count > 0)
							{
								templateCallInfo.Append("\r\n");
							}
							templateCallInfo.Append(DisplayValues.Template_CalledByIntro);
							foreach (KeyValuePair<string, int> item in template.TemplateCalledBy)
							{
								templateCallInfo.Append("\r\n").Append(item.Key).Append("(").Append(item.Value.ToString()).Append(")");
							}
						}
						template.TemplateCallInfo = templateCallInfo.ToString();
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method clears the code template cache.</summary>
		///--------------------------------------------------------------------------------
		public void ClearCodeTemplateCache()
		{
			LoggedValues.Clear();
			LoggedValues = null;
			for (int i = 0; i < CodeTemplates.Count; i++)
			{
				if (CodeTemplates[i] is CodeTemplate)
				{
					CodeTemplate template = CodeTemplates[i] as CodeTemplate;
					template.CachedContent = null;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method clears the run time call data for the set of code templates.</summary>
		///--------------------------------------------------------------------------------
		public void ClearCodeTemplateCallData()
		{
			for (int i = 0; i < CodeTemplates.Count; i++)
			{
				if (CodeTemplates[i] is CodeTemplate)
				{
					CodeTemplate template = CodeTemplates[i] as CodeTemplate;
					template.Solution = this;
					template.CachedContent = null;
					template.HasErrors = false;
					template.IsTemplateUtilized = false;
					template.TemplateCallInfo = template.TemplateName;
					template.TemplateCalls.Clear();
					template.TemplateCalledBy.Clear();
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds the run time call data for the set of code templates.</summary>
		///--------------------------------------------------------------------------------
		public void AddCodeTemplateCallData()
		{
			for (int i = 0; i < CodeTemplates.Count; i++)
			{
				if (CodeTemplates[i] is CodeTemplate)
				{
					CodeTemplate template = CodeTemplates[i] as CodeTemplate;
					if (template.TemplateCalls.Count > 0 || template.TemplateCalledBy.Count > 0)
					{
						StringBuilder templateCallInfo = new StringBuilder();
						if (template.TemplateCalls.Count > 0)
						{
							templateCallInfo.Append(DisplayValues.Template_CallIntro);
							foreach (KeyValuePair<string, int> item in template.TemplateCalls)
							{
								templateCallInfo.Append("\r\n").Append(item.Key).Append("(").Append(item.Value.ToString()).Append(")");
							}
						}
						if (template.TemplateCalledBy.Count > 0)
						{
							if (template.TemplateCalls.Count > 0)
							{
								templateCallInfo.Append("\r\n");
							}
							templateCallInfo.Append(DisplayValues.Template_CalledByIntro);
							foreach (KeyValuePair<string, int> item in template.TemplateCalledBy)
							{
								templateCallInfo.Append("\r\n").Append(item.Key).Append("(").Append(item.Value.ToString()).Append(")");
							}
						}
						template.TemplateCallInfo = templateCallInfo.ToString();
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method clears the model of reverse engineering items for the
		/// solution in order for it to be rebuilt.</summary>
		///--------------------------------------------------------------------------------
		protected void ClearModel()
		{
			try
			{
				// add referenced IDs to used IDs
				foreach (CollectionItem loopItem in ReferencedModelIDs)
				{
					UsedModelIDs[loopItem.ItemName] = loopItem.ItemID;
				}

				// set up forward engineering hierarchy
				foreach (Project loopProject in ProjectList)
				{
					loopProject.Solution = this;
				}
				foreach (DatabaseSource loopSource in DatabaseSourceList)
				{
					loopSource.Solution = this;
				}
				foreach (Feature loopFeature in FeatureList)
				{
					if (loopFeature.IsAutoUpdated == false || loopFeature.ForwardInstance != null)
					{
						// add feature to list
						Feature forwardFeature = loopFeature;
						if (loopFeature.ForwardInstance != null)
						{
							forwardFeature = loopFeature.ForwardInstance;
						}
						forwardFeature.Solution = this;
						ForwardFeatureList.Add(forwardFeature);
						FeaturesToMerge.Add(forwardFeature);
						EnterpriseDataObjectList<Entity> forwardEntityList = new EnterpriseDataObjectList<Entity>();
						foreach (Entity loopEntity in forwardFeature.EntityList)
						{
							if (loopEntity.IsAutoUpdated == false || loopEntity.ForwardInstance != null)
							{
								// add entity to feature
								Entity forwardEntity = loopEntity;
								if (loopEntity.ForwardInstance != null)
								{
									forwardEntity = loopEntity.ForwardInstance;
								}
								forwardEntity.Feature = forwardFeature;
								forwardEntity.Solution = this;
								forwardEntityList.Add(forwardEntity);
								EntitiesToMerge.Add(forwardEntity);
								EnterpriseDataObjectList<Property> forwardPropertyList = new EnterpriseDataObjectList<Property>();
								foreach (Property loopProperty in forwardEntity.PropertyList)
								{
									if (loopProperty.IsAutoUpdated == false || loopProperty.ForwardInstance != null)
									{
										// add entity data property to entity
										Property forwardProperty = loopProperty;
										if (loopProperty.ForwardInstance != null)
										{
											forwardProperty = loopProperty.ForwardInstance;
										}
										forwardProperty.Entity = forwardEntity;
										forwardProperty.Solution = this;
										forwardPropertyList.Add(forwardProperty);
										PropertiesToMerge.Add(forwardProperty);
									}
								}
								forwardEntity.PropertyList = forwardPropertyList;
								EnterpriseDataObjectList<PropertyReference> forwardPropertyReferenceList = new EnterpriseDataObjectList<PropertyReference>();
								foreach (PropertyReference loopProperty in forwardEntity.PropertyReferenceList)
								{
									if (loopProperty.IsAutoUpdated == false || loopProperty.ForwardInstance != null)
									{
										// add derived entity data property to entity
										PropertyReference forwardProperty = loopProperty;
										if (loopProperty.ForwardInstance != null)
										{
											forwardProperty = loopProperty.ForwardInstance;
										}
										forwardProperty.Entity = forwardEntity;
										forwardProperty.Solution = this;
										forwardPropertyReferenceList.Add(forwardProperty);
										PropertyReferencesToMerge.Add(forwardProperty);
										EnterpriseDataObjectList<PropertyRelationship> forwardPropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>();
										foreach (PropertyRelationship loopPropertyRelationship in forwardProperty.PropertyRelationshipList)
										{
											if (loopPropertyRelationship.IsAutoUpdated == false || loopPropertyRelationship.ForwardInstance != null)
											{
												// add property relationship to property
												PropertyRelationship forwardPropertyRelationship = loopPropertyRelationship;
												if (loopPropertyRelationship.ForwardInstance != null)
												{
													forwardPropertyRelationship = loopPropertyRelationship.ForwardInstance;
												}
												forwardPropertyRelationship.PropertyBase = forwardProperty;
												forwardPropertyRelationship.Solution = this;
												forwardPropertyRelationshipList.Add(forwardPropertyRelationship);
												PropertyRelationshipsToMerge.Add(forwardPropertyRelationship);
											}
										}
										forwardProperty.PropertyRelationshipList = forwardPropertyRelationshipList;
									}
								}
								forwardEntity.PropertyReferenceList = forwardPropertyReferenceList;
								EnterpriseDataObjectList<Collection> forwardCollectionList = new EnterpriseDataObjectList<Collection>();
								foreach (Collection loopProperty in forwardEntity.CollectionList)
								{
									if (loopProperty.IsAutoUpdated == false || loopProperty.ForwardInstance != null)
									{
										// add collection entity property to entity
										Collection forwardProperty = loopProperty;
										if (loopProperty.ForwardInstance != null)
										{
											forwardProperty = loopProperty.ForwardInstance;
										}
										forwardProperty.Entity = forwardEntity;
										forwardProperty.Solution = this;
										forwardCollectionList.Add(forwardProperty);
										CollectionsToMerge.Add(forwardProperty);
										EnterpriseDataObjectList<PropertyRelationship> forwardPropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>();
										foreach (PropertyRelationship loopPropertyRelationship in forwardProperty.PropertyRelationshipList)
										{
											if (loopPropertyRelationship.IsAutoUpdated == false || loopPropertyRelationship.ForwardInstance != null)
											{
												// add property relationship to property
												PropertyRelationship forwardPropertyRelationship = loopPropertyRelationship;
												if (loopPropertyRelationship.ForwardInstance != null)
												{
													forwardPropertyRelationship = loopPropertyRelationship.ForwardInstance;
												}
												forwardPropertyRelationship.PropertyBase = forwardProperty;
												forwardPropertyRelationship.Solution = this;
												forwardPropertyRelationshipList.Add(forwardPropertyRelationship);
												PropertyRelationshipsToMerge.Add(forwardPropertyRelationship);
											}
										}
										forwardProperty.PropertyRelationshipList = forwardPropertyRelationshipList;
									}
								}
								forwardEntity.CollectionList = forwardCollectionList;
								EnterpriseDataObjectList<EntityReference> forwardEntityReferenceList = new EnterpriseDataObjectList<EntityReference>();
								foreach (EntityReference loopProperty in forwardEntity.EntityReferenceList)
								{
									if (loopProperty.IsAutoUpdated == false || loopProperty.ForwardInstance != null)
									{
										// add reference entity property to entity
										EntityReference forwardProperty = loopProperty;
										if (loopProperty.ForwardInstance != null)
										{
											forwardProperty = loopProperty.ForwardInstance;
										}
										forwardProperty.Entity = forwardEntity;
										forwardProperty.Solution = this;
										forwardEntityReferenceList.Add(forwardProperty);
										EntityReferencesToMerge.Add(forwardProperty);
										EnterpriseDataObjectList<PropertyRelationship> forwardPropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>();
										foreach (PropertyRelationship loopPropertyRelationship in forwardProperty.PropertyRelationshipList)
										{
											if (loopPropertyRelationship.IsAutoUpdated == false || loopPropertyRelationship.ForwardInstance != null)
											{
												// add property relationship to property
												PropertyRelationship forwardPropertyRelationship = loopPropertyRelationship;
												if (loopPropertyRelationship.ForwardInstance != null)
												{
													forwardPropertyRelationship = loopPropertyRelationship.ForwardInstance;
												}
												forwardPropertyRelationship.PropertyBase = forwardProperty;
												forwardPropertyRelationship.Solution = this;
												forwardPropertyRelationshipList.Add(forwardPropertyRelationship);
												PropertyRelationshipsToMerge.Add(forwardPropertyRelationship);
											}
										}
										forwardProperty.PropertyRelationshipList = forwardPropertyRelationshipList;
									}
								}
								forwardEntity.EntityReferenceList = forwardEntityReferenceList;
								EnterpriseDataObjectList<Method> forwardMethodList = new EnterpriseDataObjectList<Method>();
								foreach (Method loopMethod in forwardEntity.MethodList)
								{
									if (loopMethod.IsAutoUpdated == false || loopMethod.ForwardInstance != null)
									{
										// add method to entity
										Method forwardMethod = loopMethod;
										if (loopMethod.ForwardInstance != null)
										{
											forwardMethod = loopMethod.ForwardInstance;
										}
										forwardMethod.Entity = forwardEntity;
										forwardMethod.Solution = this;
										forwardMethodList.Add(forwardMethod);
										MethodsToMerge.Add(forwardMethod);
										EnterpriseDataObjectList<Parameter> forwardParameterList = new EnterpriseDataObjectList<Parameter>();
										foreach (Parameter loopParameter in forwardMethod.ParameterList)
										{
											if (loopParameter.IsAutoUpdated == false || loopParameter.ForwardInstance != null)
											{
												// add method parameter to method
												Parameter forwardParameter = loopParameter;
												if (loopParameter.ForwardInstance != null)
												{
													forwardParameter = loopParameter.ForwardInstance;
												}
												forwardParameter.Method = forwardMethod;
												forwardParameter.Solution = this;
												forwardParameterList.Add(forwardParameter);
												ParametersToMerge.Add(forwardParameter);
											}
										}
										forwardMethod.ParameterList = forwardParameterList;
										EnterpriseDataObjectList<MethodRelationship> forwardMethodRelationshipList = new EnterpriseDataObjectList<MethodRelationship>();
										foreach (MethodRelationship loopMethodRelationship in forwardMethod.MethodRelationshipList)
										{
											if (loopMethodRelationship.IsAutoUpdated == false || loopMethodRelationship.ForwardInstance != null)
											{
												// add method relationship to method
												MethodRelationship forwardMethodRelationship = loopMethodRelationship;
												if (loopMethodRelationship.ForwardInstance != null)
												{
													forwardMethodRelationship = loopMethodRelationship.ForwardInstance;
												}
												forwardMethodRelationship.Method = forwardMethod;
												forwardMethodRelationship.Solution = this;
												forwardMethodRelationshipList.Add(forwardMethodRelationship);
												MethodRelationshipsToMerge.Add(forwardMethodRelationship);
											}
										}
										forwardMethod.MethodRelationshipList = forwardMethodRelationshipList;
									}
								}
								forwardEntity.MethodList = forwardMethodList;
								EnterpriseDataObjectList<Index> forwardIndexList = new EnterpriseDataObjectList<Index>();
								foreach (Index loopIndex in forwardEntity.IndexList)
								{
									if (loopIndex.IsAutoUpdated == false || loopIndex.ForwardInstance != null)
									{
										// add entity index to entity
										Index forwardIndex = loopIndex;
										if (loopIndex.ForwardInstance != null)
										{
											forwardIndex = loopIndex.ForwardInstance;
										}
										forwardIndex.Entity = forwardEntity;
										forwardIndex.Solution = this;
										forwardIndexList.Add(forwardIndex);
										IndexesToMerge.Add(forwardIndex);
										EnterpriseDataObjectList<IndexProperty> forwardIndexPropertyList = new EnterpriseDataObjectList<IndexProperty>();
										foreach (IndexProperty loopIndexProperty in forwardIndex.IndexPropertyList)
										{
											if (loopIndexProperty.IsAutoUpdated == false || loopIndexProperty.ForwardInstance != null)
											{
												// add entity index property to entity index
												IndexProperty forwardIndexProperty = loopIndexProperty;
												if (loopIndexProperty.ForwardInstance != null)
												{
													forwardIndexProperty = loopIndexProperty.ForwardInstance;
												}
												forwardIndexProperty.Index = forwardIndex;
												forwardIndexProperty.Solution = this;
												forwardIndexPropertyList.Add(forwardIndexProperty);
												IndexPropertiesToMerge.Add(forwardIndexProperty);
											}
										}
										forwardIndex.IndexPropertyList = forwardIndexPropertyList;
									}
								}
								forwardEntity.IndexList = forwardIndexList;
								EnterpriseDataObjectList<Relationship> forwardRelationshipList = new EnterpriseDataObjectList<Relationship>();
								foreach (Relationship loopRelationship in forwardEntity.RelationshipList)
								{
									if (loopRelationship.IsAutoUpdated == false || loopRelationship.ForwardInstance != null)
									{
										// add entity relationship to entity
										Relationship forwardRelationship = loopRelationship;
										if (loopRelationship.ForwardInstance != null)
										{
											forwardRelationship = loopRelationship.ForwardInstance;
										}
										forwardRelationship.Entity = forwardEntity;
										forwardRelationship.Solution = this;
										forwardRelationshipList.Add(forwardRelationship);
										RelationshipsToMerge.Add(forwardRelationship);
										EnterpriseDataObjectList<RelationshipProperty> forwardRelationshipPropertyList = new EnterpriseDataObjectList<RelationshipProperty>();
										foreach (RelationshipProperty loopRelationshipProperty in forwardRelationship.RelationshipPropertyList)
										{
											if (loopRelationshipProperty.IsAutoUpdated == false || loopRelationshipProperty.ForwardInstance != null)
											{
												// add entity index relationship to entity index
												RelationshipProperty forwardRelationshipProperty = loopRelationshipProperty;
												if (loopRelationshipProperty.ForwardInstance != null)
												{
													forwardRelationshipProperty = loopRelationshipProperty.ForwardInstance;
												}
												forwardRelationshipProperty.Relationship = forwardRelationship;
												forwardRelationshipProperty.Solution = this;
												forwardRelationshipPropertyList.Add(forwardRelationshipProperty);
												RelationshipPropertiesToMerge.Add(forwardRelationshipProperty);
											}
										}
										forwardRelationship.RelationshipPropertyList = forwardRelationshipPropertyList;
									}
								}
								forwardEntity.RelationshipList = forwardRelationshipList;
								EnterpriseDataObjectList<StateModel> forwardStateModelList = new EnterpriseDataObjectList<StateModel>();
								foreach (StateModel loopStateModel in forwardEntity.StateModelList)
								{
									// add entity state model to entity
									StateModel forwardStateModel = loopStateModel;
									forwardStateModel.Entity = forwardEntity;
									forwardStateModel.Solution = this;
									forwardStateModelList.Add(forwardStateModel);
									StateModelsToMerge.Add(forwardStateModel);
									EnterpriseDataObjectList<State> forwardStateList = new EnterpriseDataObjectList<State>();
									foreach (State loopState in forwardStateModel.StateList)
									{
										// add entity state to entity state model
										State forwardState = loopState;
										forwardState.StateModel = forwardStateModel;
										forwardState.Solution = this;
										forwardStateList.Add(forwardState);
										StatesToMerge.Add(forwardState);
										EnterpriseDataObjectList<StateTransition> forwardStateTransitionList = new EnterpriseDataObjectList<StateTransition>();
										foreach (StateTransition loopStateTransition in forwardState.ToStateTransitionList)
										{
											// add entity state transition to entity state
											StateTransition forwardStateTransition = loopStateTransition;
											forwardStateTransition.ToState = forwardState;
											forwardStateTransition.Solution = this;
											forwardStateTransitionList.Add(forwardStateTransition);
											StateTransitionsToMerge.Add(forwardStateTransition);
										}
										forwardState.ToStateTransitionList = forwardStateTransitionList;
									}
									forwardStateModel.StateList = forwardStateList;
								}
								forwardEntity.StateModelList = forwardStateModelList;
							}
						}
						forwardFeature.EntityList = forwardEntityList;
					}
				}

				foreach (Model loopModel in ModelList)
				{
					if (loopModel.IsAutoUpdated == false || loopModel.ForwardInstance != null)
					{
						// add model to list
						Model forwardModel = loopModel;
						if (loopModel.ForwardInstance != null)
						{
							forwardModel = loopModel.ForwardInstance;
						}
						forwardModel.Solution = this;
						ModelsToMerge.Add(forwardModel);
						EnterpriseDataObjectList<ModelObject> forwardModelObjectList = new EnterpriseDataObjectList<ModelObject>();
						foreach (ModelObject loopModelObject in forwardModel.ModelObjectList)
						{
							if (loopModelObject.IsAutoUpdated == false || loopModelObject.ForwardInstance != null)
							{
								// add model object to list
								ModelObject forwardModelObject = loopModelObject;
								if (loopModelObject.ForwardInstance != null)
								{
									forwardModelObject = loopModelObject.ForwardInstance;
								}
								forwardModelObject.Model = forwardModel;
								forwardModelObject.Solution = this;
								forwardModelObjectList.Add(forwardModelObject);
								ModelObjectsToMerge.Add(forwardModelObject);
								EnterpriseDataObjectList<ModelProperty> forwardModelPropertyList = new EnterpriseDataObjectList<ModelProperty>();
								foreach (ModelProperty loopModelProperty in forwardModelObject.ModelPropertyList)
								{
									if (loopModelProperty.IsAutoUpdated == false || loopModelProperty.ForwardInstance != null)
									{
										// add model property to list
										ModelProperty forwardModelProperty = loopModelProperty;
										if (loopModelProperty.ForwardInstance != null)
										{
											forwardModelProperty = loopModelProperty.ForwardInstance;
										}
										forwardModelProperty.ModelObject = forwardModelObject;
										forwardModelProperty.Solution = this;
										forwardModelPropertyList.Add(forwardModelProperty);
										ModelPropertiesToMerge.Add(forwardModelProperty);
									}
								}
								forwardModelObject.ModelPropertyList = forwardModelPropertyList;
								EnterpriseDataObjectList<ObjectInstance> forwardObjectInstanceList = new EnterpriseDataObjectList<ObjectInstance>();
								foreach (ObjectInstance loopObjectInstance in forwardModelObject.ObjectInstanceList)
								{
									if (loopObjectInstance.IsAutoUpdated == false || loopObjectInstance.ForwardInstance != null)
									{
										// add object instance to list
										ObjectInstance forwardObjectInstance = loopObjectInstance;
										if (loopObjectInstance.ForwardInstance != null)
										{
											forwardObjectInstance = loopObjectInstance.ForwardInstance;
										}
										forwardObjectInstance.ModelObject = forwardModelObject;
										forwardObjectInstance.Solution = this;
										forwardObjectInstanceList.Add(forwardObjectInstance);
										ObjectInstancesToMerge.Add(forwardObjectInstance);
										EnterpriseDataObjectList<PropertyInstance> forwardPropertyInstanceList = new EnterpriseDataObjectList<PropertyInstance>();
										foreach (PropertyInstance loopPropertyInstance in forwardObjectInstance.PropertyInstanceList)
										{
											if (loopPropertyInstance.IsAutoUpdated == false || loopPropertyInstance.ForwardInstance != null)
											{
												// add object instance to list
												PropertyInstance forwardPropertyInstance = loopPropertyInstance;
												if (loopPropertyInstance.ForwardInstance != null)
												{
													forwardPropertyInstance = loopPropertyInstance.ForwardInstance;
												}
												forwardPropertyInstance.ObjectInstance = forwardObjectInstance;
												forwardPropertyInstance.Solution = this;
												forwardPropertyInstanceList.Add(forwardPropertyInstance);
												PropertyInstancesToMerge.Add(forwardPropertyInstance);
											}
										}
										forwardObjectInstance.PropertyInstanceList = forwardPropertyInstanceList;
									}
								}
								forwardModelObject.ObjectInstanceList = forwardObjectInstanceList;
							}
						}
						forwardModel.ModelObjectList = forwardModelObjectList;

						EnterpriseDataObjectList<Enumeration> forwardEnumerationList = new EnterpriseDataObjectList<Enumeration>();
						foreach (Enumeration loopEnumeration in forwardModel.EnumerationList)
						{
							if (loopEnumeration.IsAutoUpdated == false || loopEnumeration.ForwardInstance != null)
							{
								// add enumeration to list
								Enumeration forwardEnumeration = loopEnumeration;
								if (loopEnumeration.ForwardInstance != null)
								{
									forwardEnumeration = loopEnumeration.ForwardInstance;
								}
								forwardEnumeration.Model = forwardModel;
								forwardEnumeration.Solution = this;
								forwardEnumerationList.Add(forwardEnumeration);
								EnumerationsToMerge.Add(forwardEnumeration);
								EnterpriseDataObjectList<Value> forwardValueList = new EnterpriseDataObjectList<Value>();
								foreach (Value loopValue in forwardEnumeration.ValueList)
								{
									if (loopValue.IsAutoUpdated == false || loopValue.ForwardInstance != null)
									{
										// add value to list
										Value forwardValue = loopValue;
										if (loopValue.ForwardInstance != null)
										{
											forwardValue = loopValue.ForwardInstance;
										}
										forwardValue.Enumeration = forwardEnumeration;
										forwardValue.Solution = this;
										forwardValueList.Add(forwardValue);
										ValuesToMerge.Add(forwardValue);
									}
								}
								forwardEnumeration.ValueList = forwardValueList;
							}
						}
						forwardModel.EnumerationList = forwardEnumerationList;
					}
				}

				foreach (Workflow loopWorkflow in WorkflowList)
				{
					if (loopWorkflow.IsAutoUpdated == false || loopWorkflow.ForwardInstance != null)
					{
						// add workflow to list
						Workflow forwardWorkflow = loopWorkflow;
						if (loopWorkflow.ForwardInstance != null)
						{
							forwardWorkflow = loopWorkflow.ForwardInstance;
						}
						WorkflowsToMerge.Add(forwardWorkflow);
						EnterpriseDataObjectList<Stage> forwardStageList = new EnterpriseDataObjectList<Stage>();
						foreach (Stage loopStage in forwardWorkflow.StageList)
						{
							if (loopStage.IsAutoUpdated == false || loopStage.ForwardInstance != null)
							{
								// add stage to list
								Stage forwardStage = loopStage;
								if (loopStage.ForwardInstance != null)
								{
									forwardStage = loopStage.ForwardInstance;
								}
								forwardStage.Workflow = forwardWorkflow;
								forwardStage.Solution = this;
								forwardStageList.Add(forwardStage);
								StagesToMerge.Add(forwardStage);
								EnterpriseDataObjectList<StageTransition> forwardStageTransitionList = new EnterpriseDataObjectList<StageTransition>();
								foreach (StageTransition loopStageTransition in forwardStage.ToStageTransitionList)
								{
									if (loopStageTransition.IsAutoUpdated == false || loopStageTransition.ForwardInstance != null)
									{
										// add stage transition to list
										StageTransition forwardStageTransition = loopStageTransition;
										if (loopStageTransition.ForwardInstance != null)
										{
											forwardStageTransition = loopStageTransition.ForwardInstance;
										}
										forwardStageTransition.ToStage = forwardStage;
										forwardStageTransition.Solution = this;
										forwardStageTransitionList.Add(forwardStageTransition);
										StageTransitionsToMerge.Add(forwardStageTransition);
									}
								}
								forwardStage.ToStageTransitionList = forwardStageTransitionList;
								EnterpriseDataObjectList<Step> forwardStepList = new EnterpriseDataObjectList<Step>();
								foreach (Step loopStep in forwardStage.StepList)
								{
									if (loopStep.IsAutoUpdated == false || loopStep.ForwardInstance != null)
									{
										// add step to list
										Step forwardStep = loopStep;
										if (loopStep.ForwardInstance != null)
										{
											forwardStep = loopStep.ForwardInstance;
										}
										forwardStep.Stage = forwardStage;
										forwardStep.Solution = this;
										forwardStepList.Add(forwardStep);
										StepsToMerge.Add(forwardStep);
										EnterpriseDataObjectList<StepTransition> forwardStepTransitionList = new EnterpriseDataObjectList<StepTransition>();
										foreach (StepTransition loopStepTransition in forwardStep.ToStepTransitionList)
										{
											if (loopStepTransition.IsAutoUpdated == false || loopStepTransition.ForwardInstance != null)
											{
												// add step transition to list
												StepTransition forwardStepTransition = loopStepTransition;
												if (loopStepTransition.ForwardInstance != null)
												{
													forwardStepTransition = loopStepTransition.ForwardInstance;
												}
												forwardStepTransition.ToStep = forwardStep;
												forwardStepTransition.Solution = this;
												forwardStepTransitionList.Add(forwardStepTransition);
												StepTransitionsToMerge.Add(forwardStepTransition);
											}
										}
										forwardStep.ToStepTransitionList = forwardStepTransitionList;
									}
								}
								forwardStage.StepList = forwardStepList;
							}
						}
						forwardWorkflow.StageList = forwardStageList;
					}
				}

				// clear main lists and add forward engineering data into model;
				FeatureList = FeaturesToMerge;
				EntityList = new EnterpriseDataObjectList<Entity>();
				foreach (Entity item in EntitiesToMerge)
				{
					EntityList.Add(item);
				}
				PropertyList = new EnterpriseDataObjectList<Property>();
				foreach (Property item in PropertiesToMerge)
				{
					PropertyList.Add(item);
				}
				PropertyReferenceList = new EnterpriseDataObjectList<PropertyReference>();
				foreach (PropertyReference item in PropertyReferencesToMerge)
				{
					PropertyReferenceList.Add(item);
				}
				EntityReferenceList = new EnterpriseDataObjectList<EntityReference>();
				foreach (EntityReference item in EntityReferencesToMerge)
				{
					EntityReferenceList.Add(item);
				}
				CollectionList = new EnterpriseDataObjectList<Collection>();
				foreach (Collection item in CollectionsToMerge)
				{
					CollectionList.Add(item);
				}
				IndexList = new EnterpriseDataObjectList<Index>();
				foreach (Index item in IndexesToMerge)
				{
					IndexList.Add(item);
				}
				IndexPropertyList = new EnterpriseDataObjectList<IndexProperty>();
				foreach (IndexProperty item in IndexPropertiesToMerge)
				{
					IndexPropertyList.Add(item);
				}
				RelationshipList = new EnterpriseDataObjectList<Relationship>();
				foreach (Relationship item in RelationshipsToMerge)
				{
					RelationshipList.Add(item);
				}
				RelationshipPropertyList = new EnterpriseDataObjectList<RelationshipProperty>();
				foreach (RelationshipProperty item in RelationshipPropertiesToMerge)
				{
					RelationshipPropertyList.Add(item);
				}
				MethodList = new EnterpriseDataObjectList<Method>();
				foreach (Method item in MethodsToMerge)
				{
					MethodList.Add(item);
				}
				ParameterList = new EnterpriseDataObjectList<Parameter>();
				foreach (Parameter item in ParametersToMerge)
				{
					ParameterList.Add(item);
				}
				PropertyRelationshipList = new EnterpriseDataObjectList<PropertyRelationship>();
				foreach (PropertyRelationship item in PropertyRelationshipsToMerge)
				{
					PropertyRelationshipList.Add(item);
				}
				MethodRelationshipList = new EnterpriseDataObjectList<MethodRelationship>();
				foreach (MethodRelationship item in MethodRelationshipsToMerge)
				{
					MethodRelationshipList.Add(item);
				}
				WorkflowList = WorkflowsToMerge;
				StageList = new EnterpriseDataObjectList<Stage>();
				foreach (Stage item in StagesToMerge)
				{
					StageList.Add(item);
				}
				StageTransitionList = new EnterpriseDataObjectList<StageTransition>();
				foreach (StageTransition item in StageTransitionsToMerge)
				{
					StageTransitionList.Add(item);
				}
				StepList = new EnterpriseDataObjectList<Step>();
				foreach (Step item in StepsToMerge)
				{
					StepList.Add(item);
				}
				StepTransitionList = new EnterpriseDataObjectList<StepTransition>();
				foreach (StepTransition item in StepTransitionsToMerge)
				{
					StepTransitionList.Add(item);
				}
				StateModelList = new EnterpriseDataObjectList<StateModel>();
				foreach (StateModel item in StateModelsToMerge)
				{
					StateModelList.Add(item);
				}
				StateList = new EnterpriseDataObjectList<State>();
				foreach (State item in StatesToMerge)
				{
					StateList.Add(item);
				}
				StateTransitionList = new EnterpriseDataObjectList<StateTransition>();
				foreach (StateTransition item in StateTransitionsToMerge)
				{
					StateTransitionList.Add(item);
				}
				ModelList = ModelsToMerge;
				ModelObjectList = new EnterpriseDataObjectList<ModelObject>();
				foreach (ModelObject item in ModelObjectsToMerge)
				{
					ModelObjectList.Add(item);
				}
				ObjectInstanceList = new EnterpriseDataObjectList<ObjectInstance>();
				foreach (ObjectInstance item in ObjectInstancesToMerge)
				{
					ObjectInstanceList.Add(item);
				}
				ModelPropertyList = new EnterpriseDataObjectList<ModelProperty>();
				foreach (ModelProperty item in ModelPropertiesToMerge)
				{
					ModelPropertyList.Add(item);
				}
				PropertyInstanceList = new EnterpriseDataObjectList<PropertyInstance>();
				foreach (PropertyInstance item in PropertyInstancesToMerge)
				{
					PropertyInstanceList.Add(item);
				}
				EnumerationList = new EnterpriseDataObjectList<Enumeration>();
				foreach (Enumeration item in EnumerationsToMerge)
				{
					EnumerationList.Add(item);
				}
				ValueList = new EnterpriseDataObjectList<Value>();
				foreach (Value item in ValuesToMerge)
				{
					ValueList.Add(item);
				}
			}
			catch (ApplicationAbortException)
			{
				throw;
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method builds the platform independent, tier indepenent
		/// model of the solution.  This model is then used to generate code and
		/// other solution elements.</summary>
		///--------------------------------------------------------------------------------
		public void BuildModel()
		{
			try
			{
				// load existing info from the specification source and build entity hierarchy
				CurrentErrorCount = 0;
				ClearSpecTemplateCallData();
				TemplatesUsed.Clear();
				TemplatesExecuted = 0;
				CachedTemplatesExecuted = 0;
				LoggedValues.Clear();
				LoggedValues = null;
				CurrentBuildModelProgress = 0;
				ForwardFeatureList = new EnterpriseDataObjectList<Feature>();
				AuditPropertiesToMerge = new EnterpriseDataObjectList<AuditProperty>();
				FeaturesToMerge = new EnterpriseDataObjectList<Feature>();
				EntitiesToMerge = new EnterpriseDataObjectList<Entity>();
				CollectionsToMerge = new EnterpriseDataObjectList<Collection>();
				PropertiesToMerge = new EnterpriseDataObjectList<Property>();
				PropertyReferencesToMerge = new EnterpriseDataObjectList<PropertyReference>();
				EntityReferencesToMerge = new EnterpriseDataObjectList<EntityReference>();
				PropertyRelationshipsToMerge = new EnterpriseDataObjectList<PropertyRelationship>();
				MethodsToMerge = new EnterpriseDataObjectList<Method>();
				ParametersToMerge = new EnterpriseDataObjectList<Parameter>();
				MethodRelationshipsToMerge = new EnterpriseDataObjectList<MethodRelationship>();
				IndexesToMerge = new EnterpriseDataObjectList<Index>();
				IndexPropertiesToMerge = new EnterpriseDataObjectList<IndexProperty>();
				RelationshipsToMerge = new EnterpriseDataObjectList<Relationship>();
				RelationshipPropertiesToMerge = new EnterpriseDataObjectList<RelationshipProperty>();
				StateModelsToMerge = new EnterpriseDataObjectList<StateModel>();
				StatesToMerge = new EnterpriseDataObjectList<State>();
				StateTransitionsToMerge = new EnterpriseDataObjectList<StateTransition>();
				WorkflowsToMerge = new EnterpriseDataObjectList<Workflow>();
				StagesToMerge = new EnterpriseDataObjectList<Stage>();
				StageTransitionsToMerge = new EnterpriseDataObjectList<StageTransition>();
				StepsToMerge = new EnterpriseDataObjectList<Step>();
				StepTransitionsToMerge = new EnterpriseDataObjectList<StepTransition>();
				ModelsToMerge = new EnterpriseDataObjectList<Model>();
				ModelObjectsToMerge = new EnterpriseDataObjectList<ModelObject>();
				ModelPropertiesToMerge = new EnterpriseDataObjectList<ModelProperty>();
				ObjectInstancesToMerge = new EnterpriseDataObjectList<ObjectInstance>();
				PropertyInstancesToMerge = new EnterpriseDataObjectList<PropertyInstance>();
				EnumerationsToMerge = new EnterpriseDataObjectList<Enumeration>();
				ValuesToMerge = new EnterpriseDataObjectList<Value>();
				ClearModel();

				foreach (DatabaseSource item in DatabaseSourceList)
				{
					item.Solution = this;
				}
				foreach (XmlSource item in XmlSourceList)
				{
					item.Solution = this;
				}
				foreach (Project loopProject in ProjectList)
				{
					loopProject.Solution = this;
					foreach (ProjectReference loopReference in loopProject.ProjectReferenceList)
					{
						loopReference.Project = loopProject;
						loopReference.ReferencedProject = ProjectList.FindByID(loopReference.ReferencedProjectID);
					}
				}

				OutputSolutionProgress = 0;
				EntityProgressAmount = (100.0 - BuildModelProgress) / (ProjectList.Count * EntityList.Count);
				for (int i = 0; i < SpecTemplates.Count; i++)
				{
					if (SpecTemplates[i] is SpecTemplate)
					{
						(SpecTemplates[i] as SpecTemplate).Solution = this;
						(SpecTemplates[i] as SpecTemplate).CachedContent = null;
					}
				}

				// set up ordered specification sources
				SpecificationSourceList.Clear();
				foreach (DatabaseSource source in DatabaseSourceList)
				{
					source.DatabaseType = DataConventionHelper.DatabaseTypes.Find(d => d.DatabaseTypeCode == source.DatabaseTypeCode);
					SpecificationSourceList.Add(source);
				}
				foreach (XmlSource source in XmlSourceList)
				{
					SpecificationSourceList.Add(source);
				}
				SpecificationSourceList.Sort("SpecificationOrder", Data.SortDirection.Ascending);

				try
				{
					foreach (SpecificationSource source in SpecificationSourceList)
					{
						// add reverse engineering data to model
						if (String.IsNullOrEmpty(source.TemplatePath))
						{
							if (source is DatabaseSource)
							{
								// perform default load of database information
								LoadDefaultDbInfo(source as DatabaseSource);
							}
						}
						else
						{
							SpecTemplate template = new SpecTemplate();
							template.FilePath = source.TemplateAbsolutePath;
							template.LoadTemplateFileData(false);
							string templateName = template.TemplateName;
							string code = String.Empty;
							template = SpecTemplates[template.GetTemplateKey(source, templateName)] as SpecTemplate;
							if (template != null)
							{
								if (source is DatabaseSource && (source as DatabaseSource).SpecDatabase != null)
								{
								}
								template.GenerateContentAndOutput();
							}
						}
					}
				}
				catch (ApplicationAbortException)
				{
					// errors should already be logged before this final catch
					// just continue with presenting the rest of the model
				}

				// link model references and sort
				FeatureList.Sort("FeatureName", Data.SortDirection.Ascending);
				foreach (Feature loopFeature in FeatureList)
				{
					loopFeature.EntityList.Sort("EntityName", Data.SortDirection.Ascending);
					loopFeature.Solution = this;
					foreach (Entity loopEntity in loopFeature.EntityList)
					{
						if (loopEntity.IdentifierType == null)
						{
							loopEntity.IdentifierType = DataConventionHelper.IdentifierTypes.Find("IdentifierTypeCode", loopEntity.IdentifierTypeCode);
						}
						if (loopEntity.EntityType == null)
						{
							loopEntity.EntityType = DataConventionHelper.EntityTypes.Find("EntityTypeCode", loopEntity.EntityTypeCode);
						}
						loopEntity.Feature = loopFeature;
						loopEntity.Solution = this;
						loopEntity.PropertyList.Sort("Order", Data.SortDirection.Ascending);
						foreach (Property loopProperty in loopEntity.PropertyList)
						{
							loopProperty.Entity = loopEntity;
							loopProperty.Solution = this;
						}
						loopEntity.PropertyReferenceList.Sort("Order", Data.SortDirection.Ascending);
						foreach (PropertyReference loopProperty in loopEntity.PropertyReferenceList)
						{
							if (loopProperty.ReferencedProperty == null)
							{
								loopProperty.ReferencedProperty = PropertyList.FindByID(loopProperty.ReferencedPropertyID);
							}
							loopProperty.Entity = loopEntity;
							loopProperty.Solution = this;
							loopProperty.PropertyRelationshipList.Sort("Order", Data.SortDirection.Ascending);
							foreach (PropertyRelationship loopRelationship in loopProperty.PropertyRelationshipList)
							{
								loopRelationship.PropertyBase = loopProperty;
								loopRelationship.Relationship = RelationshipList.FindByID(loopRelationship.RelationshipID);
							}
						}
						loopEntity.CollectionList.Sort("Order", Data.SortDirection.Ascending);
						foreach (Collection loopProperty in loopEntity.CollectionList)
						{
							if (loopProperty.ReferencedEntity == null)
							{
								loopProperty.ReferencedEntity = EntityList.FindByID(loopProperty.ReferencedEntityID);
							}
							loopProperty.Entity = loopEntity;
							loopProperty.Solution = this;
							loopProperty.PropertyRelationshipList.Sort("Order", Data.SortDirection.Ascending);
							foreach (PropertyRelationship loopRelationship in loopProperty.PropertyRelationshipList)
							{
								loopRelationship.PropertyBase = loopProperty;
								loopRelationship.Relationship = RelationshipList.FindByID(loopRelationship.RelationshipID);
							}
						}
						loopEntity.EntityReferenceList.Sort("Order", Data.SortDirection.Ascending);
						foreach (EntityReference loopProperty in loopEntity.EntityReferenceList)
						{
							if (loopProperty.ReferencedEntity == null)
							{
								loopProperty.ReferencedEntity = EntityList.FindByID(loopProperty.ReferencedEntityID);
							}
							loopProperty.Entity = loopEntity;
							loopProperty.Solution = this;
							loopProperty.PropertyRelationshipList.Sort("Order", Data.SortDirection.Ascending);
							foreach (PropertyRelationship loopRelationship in loopProperty.PropertyRelationshipList)
							{
								loopRelationship.PropertyBase = loopProperty;
								loopRelationship.Relationship = RelationshipList.FindByID(loopRelationship.RelationshipID);
							}
						}
						loopEntity.MethodList.Sort("MethodName", Data.SortDirection.Ascending);
						foreach (Method loopMethod in loopEntity.MethodList)
						{
							if (loopMethod.MethodType == null)
							{
								loopMethod.MethodType = DataConventionHelper.MethodTypes.Find("MethodTypeCode", loopMethod.MethodTypeCode);
							}
							loopMethod.Entity = loopEntity;
							loopMethod.Solution = this;
							loopMethod.ParameterList.Sort("Order", Data.SortDirection.Ascending);
							foreach (Parameter loopParameter in loopMethod.ParameterList)
							{
								if (loopParameter.ReferencedPropertyBase == null)
								{
									loopParameter.ReferencedPropertyBase = PropertyList.FindByID(loopParameter.ReferencedPropertyID);
								}
								loopParameter.Method = loopMethod;
								loopParameter.Solution = this;
							}
							loopMethod.MethodRelationshipList.Sort("Order", Data.SortDirection.Ascending);
							foreach (MethodRelationship loopRelationship in loopMethod.MethodRelationshipList)
							{
								loopRelationship.Method = loopMethod;
								loopRelationship.Relationship = RelationshipList.FindByID(loopRelationship.RelationshipID);
							}
						}
						loopEntity.IndexList.Sort("IndexName", Data.SortDirection.Ascending);
						foreach (Index loopIndex in loopEntity.IndexList)
						{
							loopIndex.Entity = loopEntity;
							loopIndex.Solution = this;
							loopIndex.IndexPropertyList.Sort("Order", Data.SortDirection.Ascending);
							foreach (IndexProperty loopIndexProperty in loopIndex.IndexPropertyList)
							{
								if (loopIndexProperty.Property == null)
								{
									loopIndexProperty.Property = PropertyList.FindByID(loopIndexProperty.PropertyID);
								}
								loopIndexProperty.Index = loopIndex;
								loopIndexProperty.Solution = this;
							}
						}
						loopEntity.RelationshipList.Sort("RelationshipName", Data.SortDirection.Ascending);
						foreach (Relationship loopRelationship in loopEntity.RelationshipList)
						{
							loopRelationship.Entity = loopEntity;
							loopRelationship.Solution = this;
							if (loopRelationship.ReferencedEntity == null)
							{
								loopRelationship.ReferencedEntity = EntityList.FindByID(loopRelationship.ReferencedEntityID);
							}
							loopRelationship.RelationshipPropertyList.Sort("Order", Data.SortDirection.Ascending);
							foreach (RelationshipProperty loopRelationshipProperty in loopRelationship.RelationshipPropertyList)
							{
								if (loopRelationshipProperty.Property == null)
								{
									loopRelationshipProperty.Property = PropertyList.FindByID(loopRelationshipProperty.PropertyID);
								}
								if (loopRelationshipProperty.ReferencedProperty == null)
								{
									loopRelationshipProperty.ReferencedProperty = PropertyList.FindByID(loopRelationshipProperty.ReferencedPropertyID);
								}
								loopRelationshipProperty.Relationship = loopRelationship;
								loopRelationshipProperty.Solution = this;
							}
						}
						loopEntity.StateModelList.Sort("StateModelName", Data.SortDirection.Ascending);
						foreach (StateModel loopStateModel in loopEntity.StateModelList)
						{
							loopStateModel.Entity = loopEntity;
							loopStateModel.Solution = this;
							loopStateModel.StateList.Sort("Order", Data.SortDirection.Ascending);
							foreach (State loopState in loopStateModel.StateList)
							{
								loopState.StateModel = loopStateModel;
								loopState.Solution = this;
								loopState.ToStateTransitionList.Sort("StateTransitionName", Data.SortDirection.Ascending);
								foreach (StateTransition loopStateTransition in loopState.ToStateTransitionList)
								{
									loopStateTransition.ToState = loopState;
									loopStateTransition.Solution = this;
									if (loopStateTransition.FromState == null && loopStateTransition.FromStateID != null)
									{
										loopStateTransition.FromState = StateList.FindByID((Guid)loopStateTransition.FromStateID);
									}
								}
							}
						}
					}
				}
				foreach (Model loopModel in ModelList)
				{
					loopModel.Solution = this;
					loopModel.ModelObjectList.Sort("ModelObjectName", Data.SortDirection.Ascending);
					foreach (ModelObject loopModelObject in loopModel.ModelObjectList)
					{
						loopModelObject.Model = loopModel;
						loopModelObject.Solution = this;
						loopModelObject.ModelPropertyList.Sort("Order", Data.SortDirection.Ascending);
						foreach (ModelProperty loopModelProperty in loopModelObject.ModelPropertyList)
						{
							loopModelProperty.ModelObject = loopModelObject;
							loopModelProperty.Solution = this;
						}
						foreach (ObjectInstance loopObjectInstance in loopModelObject.ObjectInstanceList)
						{
							loopObjectInstance.ModelObject = loopModelObject;
							loopObjectInstance.Solution = this;
							foreach (PropertyInstance loopPropertyInstance in loopObjectInstance.PropertyInstanceList)
							{
								loopPropertyInstance.ObjectInstance = loopObjectInstance;
								loopPropertyInstance.ModelProperty = ModelPropertyList.Find(p => p.ModelPropertyID == loopPropertyInstance.ModelPropertyID);
								loopPropertyInstance.Solution = this;
							}
						}
					}
					loopModel.EnumerationList.Sort("EnumerationName", Data.SortDirection.Ascending);
					foreach (Enumeration loopEnumeration in loopModel.EnumerationList)
					{
						loopEnumeration.Model = loopModel;
						loopEnumeration.Solution = this;
						loopEnumeration.ValueList.Sort("Order", Data.SortDirection.Ascending);
						foreach (Value loopValue in loopEnumeration.ValueList)
						{
							loopValue.Enumeration = loopEnumeration;
							loopValue.Solution = this;
						}
					}
				}
				WorkflowList.Sort("WorkflowName", Data.SortDirection.Ascending);
				foreach (Workflow loopWorkflow in WorkflowList)
				{
					loopWorkflow.Solution = this;
					loopWorkflow.StageList.Sort("Order", Data.SortDirection.Ascending);
					foreach (Stage loopStage in loopWorkflow.StageList)
					{
						loopStage.Workflow = loopWorkflow;
						loopStage.Solution = this;
						loopStage.ToStageTransitionList.Sort("StageTransitionName", Data.SortDirection.Ascending);
						foreach (StageTransition loopStageTransition in loopStage.ToStageTransitionList)
						{
							loopStageTransition.ToStage = loopStage;
							loopStageTransition.Solution = this;
						}
						loopStage.StepList.Sort("Order", Data.SortDirection.Ascending);
						foreach (Step loopStep in loopStage.StepList)
						{
							loopStep.Stage = loopStage;
							loopStep.Solution = this;
							loopStep.ToStepTransitionList.Sort("StepTransitionName", Data.SortDirection.Ascending);
							foreach (StepTransition loopStepTransition in loopStep.ToStepTransitionList)
							{
								loopStepTransition.ToStep = loopStep;
								loopStepTransition.Solution = this;
							}
						}
					}
				}

				// add run time template usage data
				AddSpecTemplateCallData();

				// report errors
				ReportErrors();

				// set to IsLoaded state
				ResetLoaded(true);
				ResetModified(false);
				CurrentProgress = BuildModelProgress;

				// show errors
				if (LoggedErrors.Count > 0)
				{
					StringBuilder message = new StringBuilder();
					for (int i = 0; i < LoggedErrors.Count; i++)
					{
						message.Append(LoggedErrors[i].ToString()).Append("\r\n").Append("\r\n");
					}
					ShowIssue(message.ToString(), DisplayValues.Exception_BuildModelTitle);
					LoggedErrors.Clear();
				}
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
			finally
			{
				ClearSpecTemplateCache();
				ForwardFeatureList = null;
				AuditPropertiesToMerge = null;
				FeaturesToMerge = null;
				EntitiesToMerge = null;
				CollectionsToMerge = null;
				PropertiesToMerge = null;
				PropertyReferencesToMerge = null;
				EntityReferencesToMerge = null;
				PropertyRelationshipsToMerge = null;
				MethodsToMerge = null;
				ParametersToMerge = null;
				MethodRelationshipsToMerge = null;
				IndexesToMerge = null;
				IndexPropertiesToMerge = null;
				RelationshipsToMerge = null;
				RelationshipPropertiesToMerge = null;
				StateModelsToMerge = null;
				StatesToMerge = null;
				StateTransitionsToMerge = null;
				WorkflowsToMerge = null;
				StagesToMerge = null;
				StageTransitionsToMerge = null;
				StepsToMerge = null;
				StepTransitionsToMerge = null;
				ModelsToMerge = null;
				ModelObjectsToMerge = null;
				ModelPropertiesToMerge = null;
				ObjectInstancesToMerge = null;
				PropertyInstancesToMerge = null;
				EnumerationsToMerge = null;
				ValuesToMerge = null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method loads default database info into the solution.</summary>
		/// 
		///	<param name="source">The database source to load the default model information with.</param>
		///--------------------------------------------------------------------------------
		public void LoadDefaultDbInfo(DatabaseSource source)
		{
			SpecTemplate template = new SpecTemplate();
			if (FeatureList.Count == 0)
			{
				Feature feature = new Feature();
				feature.FeatureID = Guid.NewGuid();
				feature.FeatureName = "Domain";
				feature.IsAutoUpdated = true;
				feature.Solution = this;
				CurrentFeature = feature;
				Feature.AddCurrentItemToSolution(this, template, 1);
			}
			else
			{
				CurrentFeature = FeatureList[0];
			}
			foreach (SqlTable table in source.SpecDatabase.SqlTableList)
			{
				CurrentEntity = Entity.BuildEntityFromSqlTable(table, CurrentFeature);
				CurrentEntity.Solution = this;
				Entity.AddCurrentItemToSolution(this, template, 1);
				foreach (SqlColumn column in table.SqlColumnList)
				{
					CurrentProperty = Property.BuildPropertyFromSqlColumn(column, CurrentEntity);
					CurrentProperty.Solution = this;
					Property.AddCurrentItemToSolution(this, template, 1);
				}
				foreach (SqlIndex index in table.SqlIndexList)
				{
					CurrentIndex = Index.BuildIndexFromSqlIndex(index, CurrentEntity);
					CurrentIndex.Solution = this;
					Index.AddCurrentItemToSolution(this, template, 1);
					foreach (SqlIndexedColumn column in index.SqlIndexedColumnList)
					{
						CurrentIndexProperty = IndexProperty.BuildIndexPropertyFromSqlIndexedColumn(column, CurrentIndex);
						CurrentIndexProperty.Solution = this;
						IndexProperty.AddCurrentItemToSolution(this, template, 1);
					}
				}
			}
			foreach (SqlTable table in source.SpecDatabase.SqlTableList)
			{
				foreach (Entity entity in EntityList)
				{
					if (entity.SourceName == table.SqlTableName)
					{
						foreach (SqlForeignKey key in table.SqlForeignKeyList)
						{
							CurrentRelationship = Relationship.BuildRelationshipFromSqlForeignKey(key, entity);
							CurrentRelationship.Solution = this;
							Relationship.AddCurrentItemToSolution(this, template, 1);
							foreach (SqlForeignKeyColumn column in key.SqlForeignKeyColumnList)
							{
								CurrentRelationshipProperty = RelationshipProperty.BuildRelationshipPropertyFromSqlForeignKeyColumn(column, CurrentRelationship);
								CurrentRelationshipProperty.Solution = this;
								RelationshipProperty.AddCurrentItemToSolution(this, template, 1);
							}
						}
						break;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method compiles the solution model into an output solution.</summary>
		/// 
		///	<param name="generateDomainFiles">Flag indicating the domain files should also
		///	be generated/updated.</param>
		///	<param name="buildModel">Flag indicating whether the solution model should be updated
		///	prior to generating code.</param>
		///--------------------------------------------------------------------------------
		public void CompileToOutputSolution(bool generateDomainFiles, bool buildModel)
		{
			try
			{
				CurrentErrorCount = 0;
				for (int i = 0; i < CodeTemplates.Count; i++)
				{
					CodeTemplate template = CodeTemplates[i] as CodeTemplate;
					if (template != null)
					{
						template.CachedContent.Clear();
					}
				}
				TemplatesUsed.Clear();
				TemplatesExecuted = 0;
				CachedTemplatesExecuted = 0;
				LoggedValues.Clear();
				LoggedValues = null;
				if (buildModel == true || (EntityList.Count < 1 && ModelList.Count < 1))
				{
					// build the model from the specification sources
					BuildModel();
				}

				CurrentBuildCodeProgress = 0;
				OutputSolutionProgress = 0;
				EntityProgressAmount = (100.0 - BuildModelProgress) / (ProjectList.Count * EntityList.Count);

				// initialize template data
				ClearCodeTemplateCallData();

				if (string.IsNullOrEmpty(TemplatePath))
				{
					// perform default code generation of text file
					StringBuilder defaultText = new StringBuilder();
					defaultText.Append("This default text is being generated since you do not have a template specified for this solution.");
					defaultText.Append("\r\nSolution: ").Append(SolutionName);
					foreach (DatabaseSource source in DatabaseSourceList)
					{
						defaultText.Append("\r\n\tDatabase: ").Append(source.SourceDbName);
					}
					foreach (Feature feature in FeatureList)
					{
						defaultText.Append("\r\n\tFeature: ").Append(feature.FeatureName);
						foreach (Entity entity in feature.EntityList)
						{
							defaultText.Append("\r\n\t\tEntity: ").Append(entity.EntityName);
							foreach (Property property in entity.PropertyList)
							{
								defaultText.Append("\r\n\t\t\tProperty: ").Append(property.PropertyName);
							}
							foreach (Index index in entity.IndexList)
							{
								defaultText.Append("\r\n\t\t\tIndex: ").Append(index.IndexName);
								foreach (IndexProperty property in index.IndexPropertyList)
								{
									defaultText.Append("\r\n\t\t\t\tProperty: ").Append(property.PropertyName);
								}
							}
							foreach (Relationship relationship in entity.RelationshipList)
							{
								defaultText.Append("\r\n\t\t\tRelationship: ").Append(relationship.RelationshipName);
								foreach (RelationshipProperty property in relationship.RelationshipPropertyList)
								{
									defaultText.Append("\r\n\t\t\t\tProperty: ").Append(property.PropertyName).Append("-").Append(property.ReferencedPropertyName);
								}
							}
						}
					}
					FileHelper.ReplaceFile(SolutionDirectory + "\\Default.txt", defaultText.ToString());
				}
				else
				{
					CodeTemplate template2 = new CodeTemplate();
					template2.FilePath = TemplateAbsolutePath;
					template2.LoadTemplateFileData(false);
					string templateName = template2.TemplateName;
					string code = String.Empty;
					template2 = CodeTemplates[template2.GetTemplateKey(this, templateName)] as CodeTemplate;
					if (template2 != null)
					{
						try
						{
							template2.GenerateContentAndOutput();
						}
						catch (ApplicationAbortException)
						{
							// errors should be logged at lower levels
							// continue to report errors and template call data
						}
					}
				}

				// add run time template usage data
				AddCodeTemplateCallData();

				// report errors
				ReportErrors();
			}
			catch (Exception ex)
			{
				BusinessConfiguration.HandleException(ex);
				throw;
			}
			finally
			{
				// clear out template cache
				ClearCodeTemplateCache();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method builds up a sample solution from input solution data.</summary>
		/// 
		/// <param name="inputSolution">The input solution.</param>
		///--------------------------------------------------------------------------------
		public void BuildSampleModelFromSolution(Solution inputSolution)
		{
			try
			{
				// load existing sample info from the input solution
				CurrentErrorCount = 0;
				CurrentBuildModelProgress = 0;
				AuditPropertiesToMerge = new EnterpriseDataObjectList<AuditProperty>();
				FeaturesToMerge = new EnterpriseDataObjectList<Feature>();
				EntitiesToMerge = new EnterpriseDataObjectList<Entity>();
				CollectionsToMerge = new EnterpriseDataObjectList<Collection>();
				PropertiesToMerge = new EnterpriseDataObjectList<Property>();
				PropertyReferencesToMerge = new EnterpriseDataObjectList<PropertyReference>();
				EntityReferencesToMerge = new EnterpriseDataObjectList<EntityReference>();
				PropertyRelationshipsToMerge = new EnterpriseDataObjectList<PropertyRelationship>();
				MethodsToMerge = new EnterpriseDataObjectList<Method>();
				ParametersToMerge = new EnterpriseDataObjectList<Parameter>();
				MethodRelationshipsToMerge = new EnterpriseDataObjectList<MethodRelationship>();
				IndexesToMerge = new EnterpriseDataObjectList<Index>();
				IndexPropertiesToMerge = new EnterpriseDataObjectList<IndexProperty>();
				RelationshipsToMerge = new EnterpriseDataObjectList<Relationship>();
				RelationshipPropertiesToMerge = new EnterpriseDataObjectList<RelationshipProperty>();
				StateModelsToMerge = new EnterpriseDataObjectList<StateModel>();
				StatesToMerge = new EnterpriseDataObjectList<State>();
				StateTransitionsToMerge = new EnterpriseDataObjectList<StateTransition>();
				WorkflowsToMerge = new EnterpriseDataObjectList<Workflow>();
				StagesToMerge = new EnterpriseDataObjectList<Stage>();
				StageTransitionsToMerge = new EnterpriseDataObjectList<StageTransition>();
				StepsToMerge = new EnterpriseDataObjectList<Step>();
				StepTransitionsToMerge = new EnterpriseDataObjectList<StepTransition>();
				ModelsToMerge = new EnterpriseDataObjectList<Model>();
				ModelObjectsToMerge = new EnterpriseDataObjectList<ModelObject>();
				ModelPropertiesToMerge = new EnterpriseDataObjectList<ModelProperty>();
				ObjectInstancesToMerge = new EnterpriseDataObjectList<ObjectInstance>();
				PropertyInstancesToMerge = new EnterpriseDataObjectList<PropertyInstance>();
				EnumerationsToMerge = new EnterpriseDataObjectList<Enumeration>();
				ValuesToMerge = new EnterpriseDataObjectList<Value>();

				foreach (Feature feature in inputSolution.FeatureList)
				{
					if (DataHelper.GetRandomInt(0, 10) > 8)
					{
						Feature newFeature = new Feature();
						newFeature.TransformDataFromObject(feature, null, false);
						FeatureList.Add(newFeature);
						foreach (Entity entity in feature.EntityList)
						{
							if (DataHelper.GetRandomInt(0, 10) > 6)
							{
								Entity newEntity = new Entity();
								newEntity.TransformDataFromObject(entity, null, false);
								newEntity.Feature = newFeature;
								newEntity.Solution = this;
								newFeature.EntityList.Add(newEntity);
								EntityList.Add(newEntity);
								foreach (Property property in entity.PropertyList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										Property newProperty = new Property();
										newProperty.TransformDataFromObject(property, null, false);
										newProperty.Entity = newEntity;
										newProperty.Solution = this;
										newEntity.PropertyList.Add(newProperty);
										PropertyList.Add(newProperty);
									}
								}
								foreach (PropertyReference property in entity.PropertyReferenceList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										PropertyReference newProperty = new PropertyReference();
										newProperty.TransformDataFromObject(property, null, false);
										newProperty.Entity = newEntity;
										newProperty.Solution = this;
										newEntity.PropertyReferenceList.Add(newProperty);
										PropertyReferenceList.Add(newProperty);
									}
								}
								foreach (Collection property in entity.CollectionList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										Collection newProperty = new Collection();
										newProperty.TransformDataFromObject(property, null, false);
										newProperty.Entity = newEntity;
										newProperty.Solution = this;
										newEntity.CollectionList.Add(newProperty);
										CollectionList.Add(newProperty);
									}
								}
								foreach (EntityReference property in entity.EntityReferenceList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										EntityReference newProperty = new EntityReference();
										newProperty.TransformDataFromObject(property, null, false);
										newProperty.Entity = newEntity;
										newProperty.Solution = this;
										newEntity.EntityReferenceList.Add(newProperty);
										EntityReferenceList.Add(newProperty);
									}
								}
								foreach (Method method in entity.MethodList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										Method newMethod = new Method();
										newMethod.TransformDataFromObject(method, null, false);
										newMethod.Entity = newEntity;
										newMethod.Solution = this;
										newEntity.MethodList.Add(newMethod);
										MethodList.Add(newMethod);
										foreach (Parameter parameter in method.ParameterList)
										{
											if (DataHelper.GetRandomInt(0, 10) > 3)
											{
												Parameter newParameter = new Parameter();
												newParameter.TransformDataFromObject(parameter, null, false);
												newParameter.Method = newMethod;
												newParameter.Solution = this;
												newMethod.ParameterList.Add(newParameter);
												ParameterList.Add(newParameter);
											}
										}
									}
								}
								foreach (Index index in entity.IndexList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										Index newIndex = new Index();
										newIndex.TransformDataFromObject(index, null, false);
										newIndex.Entity = newEntity;
										newIndex.Solution = this;
										newEntity.IndexList.Add(newIndex);
										IndexList.Add(newIndex);
										foreach (IndexProperty property in index.IndexPropertyList)
										{
											if (DataHelper.GetRandomInt(0, 10) > 3)
											{
												IndexProperty newProperty = new IndexProperty();
												newProperty.TransformDataFromObject(property, null, false);
												newProperty.Index = newIndex;
												newProperty.Solution = this;
												newIndex.IndexPropertyList.Add(newProperty);
												IndexPropertyList.Add(newProperty);
											}
										}
									}
								}
								foreach (Relationship relationship in entity.RelationshipList)
								{
									if (DataHelper.GetRandomInt(0, 10) > 5)
									{
										Relationship newRelationship = new Relationship();
										newRelationship.TransformDataFromObject(relationship, null, false);
										newRelationship.Entity = newEntity;
										newRelationship.Solution = this;
										newEntity.RelationshipList.Add(newRelationship);
										RelationshipList.Add(newRelationship);
										foreach (RelationshipProperty property in relationship.RelationshipPropertyList)
										{
											if (DataHelper.GetRandomInt(0, 10) > 3)
											{
												RelationshipProperty newProperty = new RelationshipProperty();
												newProperty.TransformDataFromObject(property, null, false);
												newProperty.Relationship = newRelationship;
												newProperty.Solution = this;
												newRelationship.RelationshipPropertyList.Add(newProperty);
												RelationshipPropertyList.Add(newProperty);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				bool reThrow = BusinessConfiguration.HandleException(ex);
				if (reThrow) throw;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the model.</summary>
		///--------------------------------------------------------------------------------
		public void DisposeComplete()
		{
			CodeTemplateContentParser = null;
			CodeTemplatOutputParser = null;
			SpecTemplateContentParser = null;
			SpecTemplateOutputParser = null;
			if (_codeTemplateList != null)
			{
				foreach (CodeTemplate item in CodeTemplateList)
				{
					item.Dispose();
				}
				CodeTemplateList.Clear();
				CodeTemplateList = null;
			}
			if (_specTemplateList != null)
			{
				foreach (SpecTemplate item in SpecTemplateList)
				{
					item.Dispose();
				}
				SpecTemplateList.Clear();
				SpecTemplateList = null;
			}
			DisposeCore();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the model.</summary>
		///--------------------------------------------------------------------------------
		public void DisposeCore()
		{
			if (ReverseInstance != null)
			{
				ReverseInstance.Dispose();
				ReverseInstance = null;
			}
			if (_auditPropertyList != null)
			{
				foreach (AuditProperty item in AuditPropertyList)
				{
					item.Dispose();
				}
				AuditPropertyList.Clear();
				AuditPropertyList = null;
			}
			CallbackWorker = null;
			_specTemplateContentParser = null;
			_specTemplateOutputParser = null;
			SpecTemplates = null;
			_codeTemplateContentParser = null;
			_codeTemplateOutputParser = null;
			CodeTemplates = null;
			if (LoggedValues != null)
			{
				LoggedValues.Clear();
				LoggedValues = null;
			}
			if (CollectionsToMerge != null)
			{
				CollectionsToMerge.Clear();
				CollectionsToMerge = null;
			}
			if (_collectionList != null)
			{
				foreach (Collection item in CollectionList)
				{
					item.Dispose();
				}
				CollectionList.Clear();
				CollectionList = null;
			}
			CurrentAuditProperty = null;
			CurrentCollection = null;
			CurrentEntity = null;
			CurrentEntityReference = null;
			CurrentFeature = null;
			CurrentIndex = null;
			CurrentIndexProperty = null;
			CurrentMethod = null;
			CurrentMethodRelationship = null;
			CurrentParameter = null;
			CurrentProject = null;
			CurrentProperty = null;
			CurrentPropertyReference = null;
			CurrentPropertyRelationship = null;
			CurrentRelationship = null;
			CurrentRelationshipProperty = null;
			CurrentSqlColumn = null;
			CurrentSqlDatabase = null;
			CurrentSqlExtendedProperty = null;
			CurrentSqlForeignKey = null;
			CurrentSqlForeignKeyColumn = null;
			CurrentSqlIndex = null;
			CurrentSqlIndexedColumn = null;
			CurrentSqlProperty = null;
			CurrentSqlTable = null;
			CurrentXmlAttribute = null;
			CurrentXmlDocument = null;
			CurrentXmlNode = null;
			if (_databaseSourceList != null)
			{
				foreach (DatabaseSource item in DatabaseSourceList)
				{
					item.Dispose();
				}
				DatabaseSourceList.Clear();
				DatabaseSourceList = null;
			}
			if (PropertyReferencesToMerge != null)
			{
				foreach (PropertyReference item in PropertyReferencesToMerge)
				{
					item.Dispose();
				}
				PropertyReferencesToMerge.Clear();
				PropertyReferencesToMerge = null;
			}
			if (_propertyReferenceList != null)
			{
				foreach (PropertyReference item in PropertyReferenceList)
				{
					item.Dispose();
				}
				PropertyReferenceList.Clear();
				PropertyReferenceList = null;
			}
			if (EntitiesToMerge != null)
			{
				foreach (Entity item in EntitiesToMerge)
				{
					item.Dispose();
				}
				EntitiesToMerge.Clear();
				EntitiesToMerge = null;
			}
			if (PropertiesToMerge != null)
			{
				foreach (Property item in PropertiesToMerge)
				{
					item.Dispose();
				}
				PropertiesToMerge.Clear();
				PropertiesToMerge = null;
			}
			if (_propertyList != null)
			{
				foreach (Property item in PropertyList)
				{
					item.Dispose();
				}
				PropertyList.Clear();
				PropertyList = null;
			}
			if (IndexesToMerge != null)
			{
				foreach (Index item in IndexesToMerge)
				{
					item.Dispose();
				}
				IndexesToMerge.Clear();
				IndexesToMerge = null;
			}
			if (_indexList != null)
			{
				foreach (Index item in IndexList)
				{
					item.Dispose();
				}
				IndexList.Clear();
				IndexList = null;
			}
			if (IndexPropertiesToMerge != null)
			{
				foreach (IndexProperty item in IndexPropertiesToMerge)
				{
					item.Dispose();
				}
				IndexPropertiesToMerge.Clear();
				IndexPropertiesToMerge = null;
			}
			if (_indexPropertyList != null)
			{
				foreach (IndexProperty item in IndexPropertyList)
				{
					item.Dispose();
				}
				IndexPropertyList.Clear();
				IndexPropertyList = null;
			}
			if (_entityList != null)
			{
				foreach (Entity item in EntityList)
				{
					item.Dispose();
				}
				if (EntityList != null)
				{
					EntityList.Clear();
				}
				EntityList = null;
			}
			if (_relationshipList != null)
			{
				foreach (Relationship item in RelationshipList)
				{
					item.Dispose();
				}
				RelationshipList.Clear();
				RelationshipList = null;
			}
			if (RelationshipPropertiesToMerge != null)
			{
				foreach (RelationshipProperty item in RelationshipPropertiesToMerge)
				{
					item.Dispose();
				}
				RelationshipPropertiesToMerge.Clear();
				RelationshipPropertiesToMerge = null;
			}
			if (_relationshipPropertyList != null)
			{
				foreach (RelationshipProperty item in RelationshipPropertyList)
				{
					item.Dispose();
				}
				RelationshipPropertyList.Clear();
				RelationshipPropertyList = null;
			}
			if (RelationshipsToMerge != null)
			{
				foreach (Relationship item in RelationshipsToMerge)
				{
					item.Dispose();
				}
				RelationshipsToMerge.Clear();
				RelationshipsToMerge = null;
			}
			if (FeatureList != null)
			{
				foreach (Feature item in FeatureList)
				{
					item.Dispose();
				}
				FeatureList.Clear();
				FeatureList = null;
			}
			if (FeaturesToMerge != null)
			{
				foreach (Feature item in FeaturesToMerge)
				{
					item.Dispose();
				}
				FeaturesToMerge.Clear();
				FeaturesToMerge = null;
			}
			if (_forwardFeatureList != null)
			{
				foreach (Feature item in ForwardFeatureList)
				{
					item.Dispose();
				}
				ForwardFeatureList.Clear();
				ForwardFeatureList = null;
			}
			if (_forwardEntityList != null)
			{
				foreach (Entity item in ForwardEntityList)
				{
					item.Dispose();
				}
				ForwardEntityList.Clear();
				ForwardEntityList = null;
			}
			if (_methodList != null)
			{
				foreach (Method item in MethodList)
				{
					item.Dispose();
				}
				MethodList.Clear();
				MethodList = null;
			}
			if (_parameterList != null)
			{
				foreach (Parameter item in ParameterList)
				{
					item.Dispose();
				}
				ParameterList.Clear();
				ParameterList = null;
			}
			if (ParametersToMerge != null)
			{
				foreach (Parameter item in ParametersToMerge)
				{
					item.Dispose();
				}
				ParametersToMerge.Clear();
				ParametersToMerge = null;
			}
			if (_methodRelationshipList != null)
			{
				foreach (MethodRelationship item in MethodRelationshipList)
				{
					item.Dispose();
				}
				MethodRelationshipList.Clear();
				MethodRelationshipList = null;
			}
			if (MethodRelationshipsToMerge != null)
			{
				foreach (MethodRelationship item in MethodRelationshipsToMerge)
				{
					item.Dispose();
				}
				MethodRelationshipsToMerge.Clear();
				MethodRelationshipsToMerge = null;
			}
			if (MethodsToMerge != null)
			{
				foreach (Method item in MethodsToMerge)
				{
					item.Dispose();
				}
				MethodsToMerge.Clear();
				MethodsToMerge = null;
			}
			if (_propertyList != null)
			{
				foreach (Property item in PropertyList)
				{
					item.Dispose();
				}
				PropertyList.Clear();
				PropertyList = null;
			}
			if (_propertyRelationshipList != null)
			{
				foreach (PropertyRelationship item in PropertyRelationshipList)
				{
					item.Dispose();
				}
				PropertyRelationshipList.Clear();
				PropertyRelationshipList = null;
			}
			if (PropertyRelationshipsToMerge != null)
			{
				foreach (PropertyRelationship item in PropertyRelationshipsToMerge)
				{
					item.Dispose();
				}
				PropertyRelationshipsToMerge.Clear();
				PropertyRelationshipsToMerge = null;
			}
			if (EntityReferencesToMerge != null)
			{
				foreach (EntityReference item in EntityReferencesToMerge)
				{
					item.Dispose();
				}
				EntityReferencesToMerge.Clear();
				EntityReferencesToMerge = null;
			}
			if (_entityReferenceList != null)
			{
				foreach (EntityReference item in EntityReferenceList)
				{
					item.Dispose();
				}
				EntityReferenceList.Clear();
				EntityReferenceList = null;
			}
			if (StateModelsToMerge != null)
			{
				foreach (StateModel item in StateModelsToMerge)
				{
					item.Dispose();
				}
				StateModelsToMerge.Clear();
				StateModelsToMerge = null;
			}
			if (_stateModelList != null)
			{
				foreach (StateModel item in StateModelList)
				{
					item.Dispose();
				}
				StateModelList.Clear();
				StateModelList = null;
			}
			if (StatesToMerge != null)
			{
				foreach (State item in StatesToMerge)
				{
					item.Dispose();
				}
				StatesToMerge.Clear();
				StatesToMerge = null;
			}
			if (_stateList != null)
			{
				foreach (State item in StateList)
				{
					item.Dispose();
				}
				StateList.Clear();
				StateList = null;
			}
			if (StateTransitionsToMerge != null)
			{
				foreach (StateTransition item in StateTransitionsToMerge)
				{
					item.Dispose();
				}
				StateTransitionsToMerge.Clear();
				StateTransitionsToMerge = null;
			}
			if (_stateTransitionList != null)
			{
				foreach (StateTransition item in StateTransitionList)
				{
					item.Dispose();
				}
				StateTransitionList.Clear();
				StateTransitionList = null;
			}
			if (ModelsToMerge != null)
			{
				foreach (Model item in ModelsToMerge)
				{
					item.Dispose();
				}
				ModelsToMerge.Clear();
				ModelsToMerge = null;
			}
			if (_modelList != null)
			{
				foreach (Model item in ModelList)
				{
					item.Dispose();
				}
				ModelList.Clear();
				ModelList = null;
			}
			if (ModelObjectsToMerge != null)
			{
				foreach (ModelObject item in ModelObjectsToMerge)
				{
					item.Dispose();
				}
				ModelObjectsToMerge.Clear();
				ModelObjectsToMerge = null;
			}
			if (_modelObjectList != null)
			{
				foreach (ModelObject item in ModelObjectList)
				{
					item.Dispose();
				}
				ModelObjectList.Clear();
				ModelObjectList = null;
			}
			if (ObjectInstancesToMerge != null)
			{
				foreach (ObjectInstance item in ObjectInstancesToMerge)
				{
					item.Dispose();
				}
				ObjectInstancesToMerge.Clear();
				ObjectInstancesToMerge = null;
			}
			if (_objectInstanceList != null)
			{
				foreach (ObjectInstance item in ObjectInstanceList)
				{
					item.Dispose();
				}
				ObjectInstanceList.Clear();
				ObjectInstanceList = null;
			}
			if (ModelPropertiesToMerge != null)
			{
				foreach (ModelProperty item in ModelPropertiesToMerge)
				{
					item.Dispose();
				}
				ModelPropertiesToMerge.Clear();
				ModelPropertiesToMerge = null;
			}
			if (_modelPropertyList != null)
			{
				foreach (ModelProperty item in ModelPropertyList)
				{
					item.Dispose();
				}
				ModelPropertyList.Clear();
				ModelPropertyList = null;
			}
			if (PropertyInstancesToMerge != null)
			{
				foreach (PropertyInstance item in PropertyInstancesToMerge)
				{
					item.Dispose();
				}
				PropertyInstancesToMerge.Clear();
				PropertyInstancesToMerge = null;
			}
			if (_propertyInstanceList != null)
			{
				foreach (PropertyInstance item in PropertyInstanceList)
				{
					item.Dispose();
				}
				PropertyInstanceList.Clear();
				PropertyInstanceList = null;
			}
			if (EnumerationsToMerge != null)
			{
				foreach (Enumeration item in EnumerationsToMerge)
				{
					item.Dispose();
				}
				EnumerationsToMerge.Clear();
				EnumerationsToMerge = null;
			}
			if (_enumerationList != null)
			{
				foreach (Enumeration item in EnumerationList)
				{
					item.Dispose();
				}
				EnumerationList.Clear();
				EnumerationList = null;
			}
			if (ValuesToMerge != null)
			{
				foreach (Value item in ValuesToMerge)
				{
					item.Dispose();
				}
				ValuesToMerge.Clear();
				ValuesToMerge = null;
			}
			if (_valueList != null)
			{
				foreach (Value item in ValueList)
				{
					item.Dispose();
				}
				ValueList.Clear();
				ValueList = null;
			}
			if (WorkflowsToMerge != null)
			{
				foreach (Workflow item in WorkflowsToMerge)
				{
					item.Dispose();
				}
				WorkflowsToMerge.Clear();
				WorkflowsToMerge = null;
			}
			if (_workflowList != null)
			{
				foreach (Workflow item in WorkflowList)
				{
					item.Dispose();
				}
				WorkflowList.Clear();
				WorkflowList = null;
			}
			if (StagesToMerge != null)
			{
				foreach (Stage item in StagesToMerge)
				{
					item.Dispose();
				}
				StagesToMerge.Clear();
				StagesToMerge = null;
			}
			if (_stageList != null)
			{
				foreach (Stage item in StageList)
				{
					item.Dispose();
				}
				StageList.Clear();
				StageList = null;
			}
			if (StageTransitionsToMerge != null)
			{
				foreach (StageTransition item in StageTransitionsToMerge)
				{
					item.Dispose();
				}
				StageTransitionsToMerge.Clear();
				StageTransitionsToMerge = null;
			}
			if (_stageTransitionList != null)
			{
				foreach (StageTransition item in StageTransitionList)
				{
					item.Dispose();
				}
				StageTransitionList.Clear();
				StageTransitionList = null;
			}
			if (StepsToMerge != null)
			{
				foreach (Step item in StepsToMerge)
				{
					item.Dispose();
				}
				StepsToMerge.Clear();
				StepsToMerge = null;
			}
			if (_stepList != null)
			{
				foreach (Step item in StepList)
				{
					item.Dispose();
				}
				StepList.Clear();
				StepList = null;
			}
			if (StepTransitionsToMerge != null)
			{
				foreach (StepTransition item in StepTransitionsToMerge)
				{
					item.Dispose();
				}
				StepTransitionsToMerge.Clear();
				StepTransitionsToMerge = null;
			}
			if (_stepTransitionList != null)
			{
				foreach (StepTransition item in StepTransitionList)
				{
					item.Dispose();
				}
				StepTransitionList.Clear();
				StepTransitionList = null;
			}
			if (_diagramList != null)
			{
				foreach (Diagram item in DiagramList)
				{
					item.Dispose();
				}
				DiagramList.Clear();
				DiagramList = null;
			}
			if (_specificationSourceList != null)
			{
				foreach (SpecificationSource item in SpecificationSourceList)
				{
					item.Dispose();
				}
				SpecificationSourceList.Clear();
				SpecificationSourceList = null;
			}
			if (_xmlSourceList != null)
			{
				foreach (XmlSource item in XmlSourceList)
				{
					item.Dispose();
				}
				XmlSourceList.Clear();
				XmlSourceList = null;
			}
			base.OnDispose();
			System.GC.Collect();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the amount of progress work for building the model.</summary>
		/// 
		/// <param name="progressWork">The amount of progress work.</param>
		///--------------------------------------------------------------------------------
		public void SetModelProgressWork(int progressWork)
		{
			BuildModelWork = progressWork;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method increments the current model progress and reports it.</summary>
		///--------------------------------------------------------------------------------
		public void IncrementModelProgress()
		{
			CurrentBuildModelProgress += 1;
			if (CallbackWorker != null)
			{
				CallbackWorker.ReportProgress(CurrentTotalProgress);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the amount of progress work for building code.</summary>
		/// 
		/// <param name="progressWork">The amount of progress work.</param>
		///--------------------------------------------------------------------------------
		public void SetCodeProgressWork(int progressWork)
		{
			BuildCodeWork = progressWork;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method increments the current code progress and reports it.</summary>
		///--------------------------------------------------------------------------------
		public void IncrementCodeProgress()
		{
			CurrentBuildCodeProgress += 1;
			if (CallbackWorker != null)
			{
				CallbackWorker.ReportProgress(CurrentTotalProgress);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method puts a string value into a named log dictionary in LoggedValues.</summary>
		/// 
		/// <param name="logName">The named log dictionary.</param>
		/// <param name="key">The key for the item in the named log dictionary.</param>
		/// <param name="value">The value for the item in the named log dictionary.</param>
		///--------------------------------------------------------------------------------
		public void PutStringLoggedValue(string logName, string key, string value)
		{
			if (LoggedValues[logName] is NameObjectCollection)
			{
				(LoggedValues[logName] as NameObjectCollection)[key] = value;
			}
			else
			{
				LoggedValues[logName] = new NameObjectCollection();
				(LoggedValues[logName] as NameObjectCollection)[key] = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets a string value from a named log dictionary in LoggedValues.</summary>
		/// 
		/// <param name="logName">The named log dictionary.</param>
		/// <param name="key">The key for the item in the named log dictionary.</param>
		///--------------------------------------------------------------------------------
		public string GetStringLoggedValue(string logName, string key)
		{
			if (LoggedValues[logName] is NameObjectCollection)
			{
				return (LoggedValues[logName] as NameObjectCollection)[key].GetString();
			}
			return String.Empty;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an exception.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="statusTitle">The optional title to display.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		/// <param name="throwAbortException">Flag to override abort (exception throwing).</param>
		///--------------------------------------------------------------------------------
		public void ShowIssue(string statusMessage, string statusTitle = null, bool showMessageBox = true, bool throwAbortException = true, int numberOfErrors = 1)
		{
			StatusEventArgs args = new StatusEventArgs();
			args.IsException = true;
			args.Title = statusTitle;
			args.Text = statusMessage;
			args.AppendText = true;
			args.ShowMessageBox = showMessageBox;
			OnOutputRequested(this, args);
			if (numberOfErrors > 0)
			{
				CurrentErrorCount += numberOfErrors;
			}
			if (_currentErrorCount > BusinessConfiguration.MaxErrorsBeforeAbort)
			{
				if (throwAbortException == true)
				{
					throw new ApplicationAbortException(statusMessage);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display an output message.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ShowOutput(string statusMessage, string statusTitle = null, bool appendMessage = true, bool showMessageBox = false)
		{
			StatusEventArgs args = new StatusEventArgs();
			args.Text = statusMessage;
			args.Title = statusTitle;
			args.AppendText = appendMessage;
			args.ShowMessageBox = showMessageBox;
			OnOutputRequested(this, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message to display a status message.</summary>
		/// 
		/// <param name="statusMessage">The message to show.</param>
		/// <param name="appendMessage">Flag indicating whether message should be appended to existing message.</param>
		/// <param name="showMessageBox">Flag indicating whether message box should be displayed in addition to output area.</param>
		///--------------------------------------------------------------------------------
		public void ShowStatus(string statusMessage, string statusTitle = null, bool appendMessage = true, bool showMessageBox = false)
		{
			StatusEventArgs args = new StatusEventArgs();
			args.Text = statusMessage;
			args.Title = statusTitle;
			args.AppendText = appendMessage;
			args.ShowMessageBox = showMessageBox;
			OnStatusChanged(this, args);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method reports any logged errors (and clears the logged errors).</summary>
		///--------------------------------------------------------------------------------
		public void ReportErrors()
		{
			// show errors
			if (LoggedErrors.Count > 0)
			{
				StringBuilder message = new StringBuilder();
				for (int i = 0; i < LoggedErrors.Count; i++)
				{
					message.Append(LoggedErrors[i].ToString()).Append("\r\n").Append("\r\n");
				}
				ShowIssue(message.ToString(), DisplayValues.Exception_CodeGenerationTitle, true, false, 0);
				LoggedErrors.Clear();
			}
		}

		#endregion "Methods"
		
		#region "Constructors"
		#endregion "Constructors"
	}
}