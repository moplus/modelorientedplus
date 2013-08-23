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
using System.Text.RegularExpressions;
using MoPlus.Common;
using MoPlus.Data;
using BLL = MoPlus.Interpreter.BLL;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.Interpreter.BLL.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to manage information and business rules for
	/// specific DiagramEntity instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/22/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[XmlRoot(Namespace="", ElementName="DiagramEntity")]
	[DataContract]
	[GeneratedCode("Intelligent Coding Solutions, LLC. Mo+ Solution Builder", "1.0")]
	public partial class DiagramEntity : BusinessObjectBase
	{
		#region "Validation"
		///--------------------------------------------------------------------------------
		/// <summary>This method returns validation errors for the input item.</param>
		/// 
		/// <returns>Validation errors (null by default).</returns>
		///--------------------------------------------------------------------------------
		public virtual string GetValidationErrors()
		{
			StringBuilder errors = new StringBuilder();
			string error = null;
			
			error = GetValidationError("DiagramID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("EntityID");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("PositionX");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("PositionY");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ShowPropertyArcs");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ShowPropertyReferenceArcs");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ShowCollectionArcs");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("ShowEntityReferenceArcs");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("IsAutoUpdated");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			error = GetValidationError("Description");
			if (!String.IsNullOrEmpty(error))
			{
				errors.Append("\r\n").Append(error);
			}
			
			return errors.ToString();
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method returns a validation error for the input property.</param>
		/// 
		/// <param name="fieldName">The name of the property.</param>
		/// <returns>Validation error (null by default).</returns>
		///--------------------------------------------------------------------------------
		public override string GetValidationError(string fieldName)
		{
			if (this.GetFieldInfo(fieldName) == null && this.GetPropertyInfo(fieldName) == null) return null;
			
			string error = null;
			
			switch (fieldName)
			{
				case "_diagramID":
				case "DiagramID":
					error = ValidateDiagramID();
					break;
				case "_entityID":
				case "EntityID":
					error = ValidateEntityID();
					break;
				case "_positionX":
				case "PositionX":
					error = ValidatePositionX();
					break;
				case "_positionY":
				case "PositionY":
					error = ValidatePositionY();
					break;
				case "_showPropertyArcs":
				case "ShowPropertyArcs":
					error = ValidateShowPropertyArcs();
					break;
				case "_showPropertyReferenceArcs":
				case "ShowPropertyReferenceArcs":
					error = ValidateShowPropertyReferenceArcs();
					break;
				case "_showCollectionArcs":
				case "ShowCollectionArcs":
					error = ValidateShowCollectionArcs();
					break;
				case "_showEntityReferenceArcs":
				case "ShowEntityReferenceArcs":
					error = ValidateShowEntityReferenceArcs();
					break;
				case "_isAutoUpdated":
				case "IsAutoUpdated":
					error = ValidateIsAutoUpdated();
					break;
				case "_description":
				case "Description":
					error = ValidateDescription();
					break;
				default:
					break;
			}
			
			return error;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates DiagramID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDiagramID()
		{
			if (DiagramID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "DiagramID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates EntityID and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateEntityID()
		{
			if (EntityID == Guid.Empty)
			{
				return String.Format(Resources.DisplayValues.Validation_SelectedValue, "EntityID");
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates PositionX and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePositionX()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates PositionY and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidatePositionY()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ShowPropertyArcs and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateShowPropertyArcs()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ShowPropertyReferenceArcs and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateShowPropertyReferenceArcs()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ShowCollectionArcs and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateShowCollectionArcs()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates ShowEntityReferenceArcs and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateShowEntityReferenceArcs()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates IsAutoUpdated and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateIsAutoUpdated()
		{
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method validates Description and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateDescription()
		{
			return null;
		}
		
		#endregion "Validation"
		
		#region "Fields and Properties"
		
		private DiagramEntity _forwardInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the forward engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public DiagramEntity ForwardInstance
		{
			get
			{
				return _forwardInstance;
			}
			set
			{
				_forwardInstance = value;
			}
		}
		
		private DiagramEntity _reverseInstance = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public new DiagramEntity ReverseInstance
		{
			get
			{
				return _reverseInstance;
			}
			set
			{
				_reverseInstance = value;
				base.ReverseInstance = value;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the ID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public override Guid ID
		{
			get
			{
				return DiagramEntityID;
			}
			set
			{
				DiagramEntityID = value;
			}
		}
		
		private string _defaultSourceName;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the default source name.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DefaultSourceName
		{
			get
			{
				
				#region protected
				if (String.IsNullOrEmpty(_defaultSourceName))
				{
					_defaultSourceName = DiagramName + "." + EntityName;
				}
				#endregion protected
				
				return _defaultSourceName;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets the source method, which may be the reverse instance
		/// (to get original values, etc.).</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public DiagramEntity SourceDiagramEntity
		{
			get
			{
				if (ReverseInstance != null)
				{
					return ReverseInstance;
				}
				return this;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldDiagramEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldDiagramEntityID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldDiagramID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldDiagramID { get; set; }
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the OldEntityID of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Guid OldEntityID { get; set; }
		
		private Solutions.Solution _solution;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Solution.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public Solutions.Solution Solution
		{
			get
			{
				return _solution;
			}
			set
			{
				_solution = value;
			}
		}
		
		protected Guid _diagramEntityID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DiagramEntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid DiagramEntityID
		{
			get
			{
				return _diagramEntityID;
			}
			set
			{
				if (_diagramEntityID != value)
				{
					_diagramEntityID = value;
					_isModified = true;
					base.OnPropertyChanged("DiagramEntityID");
				}
			}
		}
		
		protected Guid _diagramID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DiagramID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid DiagramID
		{
			get
			{
				return _diagramID;
			}
			set
			{
				if (_diagramID != value)
				{
					_diagramID = value;
					_isModified = true;
					base.OnPropertyChanged("DiagramID");
				}
			}
		}
		
		protected Guid _entityID = DefaultValue.Guid;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EntityID.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual Guid EntityID
		{
			get
			{
				return _entityID;
			}
			set
			{
				if (_entityID != value)
				{
					_entityID = value;
					_isModified = true;
					base.OnPropertyChanged("EntityID");
				}
			}
		}
		
		protected double _positionX = DefaultValue.Double;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PositionX.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Double)]
		public virtual double PositionX
		{
			get
			{
				return _positionX;
			}
			set
			{
				if (_positionX != value)
				{
					_positionX = value;
					_isModified = true;
					base.OnPropertyChanged("PositionX");
				}
			}
		}
		
		protected double _positionY = DefaultValue.Double;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PositionY.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Double)]
		public virtual double PositionY
		{
			get
			{
				return _positionY;
			}
			set
			{
				if (_positionY != value)
				{
					_positionY = value;
					_isModified = true;
					base.OnPropertyChanged("PositionY");
				}
			}
		}
		
		protected bool _showPropertyArcs = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ShowPropertyArcs.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool ShowPropertyArcs
		{
			get
			{
				return _showPropertyArcs;
			}
			set
			{
				if (_showPropertyArcs != value)
				{
					_showPropertyArcs = value;
					_isModified = true;
					base.OnPropertyChanged("ShowPropertyArcs");
				}
			}
		}
		
		protected bool _showPropertyReferenceArcs = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ShowPropertyReferenceArcs.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool ShowPropertyReferenceArcs
		{
			get
			{
				return _showPropertyReferenceArcs;
			}
			set
			{
				if (_showPropertyReferenceArcs != value)
				{
					_showPropertyReferenceArcs = value;
					_isModified = true;
					base.OnPropertyChanged("ShowPropertyReferenceArcs");
				}
			}
		}
		
		protected bool _showCollectionArcs = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ShowCollectionArcs.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool ShowCollectionArcs
		{
			get
			{
				return _showCollectionArcs;
			}
			set
			{
				if (_showCollectionArcs != value)
				{
					_showCollectionArcs = value;
					_isModified = true;
					base.OnPropertyChanged("ShowCollectionArcs");
				}
			}
		}
		
		protected bool _showEntityReferenceArcs = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ShowEntityReferenceArcs.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool ShowEntityReferenceArcs
		{
			get
			{
				return _showEntityReferenceArcs;
			}
			set
			{
				if (_showEntityReferenceArcs != value)
				{
					_showEntityReferenceArcs = value;
					_isModified = true;
					base.OnPropertyChanged("ShowEntityReferenceArcs");
				}
			}
		}
		
		protected bool _isAutoUpdated = DefaultValue.Bool;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsAutoUpdated.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(DefaultValue.Bool)]
		public virtual bool IsAutoUpdated
		{
			get
			{
				return _isAutoUpdated;
			}
			set
			{
				if (_isAutoUpdated != value)
				{
					_isAutoUpdated = value;
					base.OnPropertyChanged("IsAutoUpdated");
				}
			}
		}
		
		protected string _description = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Description.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataMember]
		[DataElement]
		[DefaultValue(null)]
		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				if (_description != value)
				{
					_description = value;
					_isModified = true;
					base.OnPropertyChanged("Description");
				}
			}
		}
		
		protected string _diagramName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the DiagramName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string DiagramName
		{
			get
			{
				return _diagramName;
			}
		}
		
		protected string _entityName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string EntityName
		{
			get
			{
				return _entityName;
			}
		}
		
		protected int _entityTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the EntityTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int EntityTypeCode
		{
			get
			{
				return _entityTypeCode;
			}
		}
		
		protected int _identifierTypeCode = DefaultValue.Int;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the IdentifierTypeCode.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int IdentifierTypeCode
		{
			get
			{
				return _identifierTypeCode;
			}
		}
		
		protected string _groupName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This read only property gets the GroupName.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string GroupName
		{
			get
			{
				return _groupName;
			}
		}
		
		protected BLL.Entities.Entity _entity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Entity.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Entities.Entity Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				if (value != null)
				{
					_entityName = value.EntityName;
					_entityTypeCode = value.EntityTypeCode;
					_identifierTypeCode = value.IdentifierTypeCode;
					_groupName = value.GroupName;
					if (_entity != null && _entity.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					EntityID = value.EntityID;
				}
				_entity = value;
			}
		}
		
		protected BLL.Diagrams.Diagram _diagram = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a reference to the Diagram.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BLL.Diagrams.Diagram Diagram
		{
			get
			{
				return _diagram;
			}
			set
			{
				if (value != null)
				{
					_diagramName = value.DiagramName;
					if (_diagram != null && _diagram.PrimaryKeyValues != value.PrimaryKeyValues)
					{
						_isModified = true;
					}
					DiagramID = value.DiagramID;
				}
				_diagram = value;
			}
		}
		
		///-------------------------------------------------------------------------------
		/// <summary>This property gets the primary key properties.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyProperties
		{
			get
			{
				return "DiagramEntityID";
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary key values.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.StringStr)]
		public override string PrimaryKeyValues
		{
			get
			{
				return DiagramEntityID.GetString();
			}
			set
			{
				string[] primaryKeyValues = value.Split(',');
				if (primaryKeyValues.Length > 0)
				{
					DiagramEntityID = primaryKeyValues[0].GetGuid();
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been modified since the
		/// last load from a resource such as a database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.Bool)]
		public override bool IsModified
		{
			get
			{
				if (base.IsModified == true) return true;
				if (_isModified == true) return true;
				return false;
			}
		}
		
		#region protected
		#endregion protected
		
		#endregion "Fields and Properties"
		
		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method adds a tag to TagList.</summary>
		///--------------------------------------------------------------------------------
		public override void AddTag(string tagName)
		{
			if (ReverseInstance == null && IsAutoUpdated == true)
			{
				ReverseInstance = new DiagramEntity();
				ReverseInstance.TransformDataFromObject(this, null, false);
				IsAutoUpdated = false;
			}
			base.AddTag(tagName);
			if (ForwardInstance == null)
			{
				ForwardInstance = new DiagramEntity();
				ForwardInstance.DiagramEntityID = DiagramEntityID;
			}
			if (ForwardInstance.TagList.Find(t => t.TagName == tagName) == null)
			{
				ForwardInstance.TagList.Add(new Tag(Guid.NewGuid(), tagName));
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method removes a tag from TagList.</summary>
		///--------------------------------------------------------------------------------
		public override void RemoveTag(string tagName)
		{
			base.RemoveTag(tagName);
			if (ForwardInstance != null)
			{
				Tag tag = ForwardInstance.TagList.Find(t => t.TagName == tagName);
				if (tag != null)
				{
					ForwardInstance.TagList.Remove(tag);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item's tags into a named tag dictionary.</summary>
		/// 
		/// <param name="usedTags">Input named tag dictionary.</param>
		///--------------------------------------------------------------------------------
		public virtual void AddItemToUsedTags(NameObjectCollection usedTags)
		{
			AddTagsToUsedTags(usedTags);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether or not any metadata is
		/// different between the input instance and the current instance.</summary>
		///
		/// <param name="inputDiagramEntity">The diagramentity to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsIdenticalMetadata(DiagramEntity inputDiagramEntity)
		{
			if (DiagramID.GetGuid() != inputDiagramEntity.DiagramID.GetGuid()) return false;
			if (EntityID.GetGuid() != inputDiagramEntity.EntityID.GetGuid()) return false;
			if (PositionX.GetDouble() != inputDiagramEntity.PositionX.GetDouble()) return false;
			if (PositionY.GetDouble() != inputDiagramEntity.PositionY.GetDouble()) return false;
			if (ShowPropertyArcs.GetBool() != inputDiagramEntity.ShowPropertyArcs.GetBool()) return false;
			if (ShowPropertyReferenceArcs.GetBool() != inputDiagramEntity.ShowPropertyReferenceArcs.GetBool()) return false;
			if (ShowCollectionArcs.GetBool() != inputDiagramEntity.ShowCollectionArcs.GetBool()) return false;
			if (ShowEntityReferenceArcs.GetBool() != inputDiagramEntity.ShowEntityReferenceArcs.GetBool()) return false;
			if (IsAutoUpdated.GetBool() != inputDiagramEntity.IsAutoUpdated.GetBool()) return false;
			if (Description.GetString() != inputDiagramEntity.Description.GetString()) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method determines whether the input instance metadata is
		/// effectively empty.</summary>
		///
		/// <param name="inputDiagramEntity">The diagramentity to compare metadata.</param>
		///--------------------------------------------------------------------------------
		public bool IsEmptyMetadata(DiagramEntity inputDiagramEntity)
		{
			if (inputDiagramEntity == null) return true;
			if (inputDiagramEntity.TagList.Count > 0) return false;
			if (DiagramID != inputDiagramEntity.DiagramID) return false;
			if (EntityID != inputDiagramEntity.EntityID) return false;
			if (PositionX != inputDiagramEntity.PositionX) return false;
			if (PositionY != inputDiagramEntity.PositionY) return false;
			if (ShowPropertyArcs != inputDiagramEntity.ShowPropertyArcs) return false;
			if (ShowPropertyReferenceArcs != inputDiagramEntity.ShowPropertyReferenceArcs) return false;
			if (ShowCollectionArcs != inputDiagramEntity.ShowCollectionArcs) return false;
			if (ShowEntityReferenceArcs != inputDiagramEntity.ShowEntityReferenceArcs) return false;
			if (IsAutoUpdated != inputDiagramEntity.IsAutoUpdated) return false;
			if (!String.IsNullOrEmpty(inputDiagramEntity.Description)) return false;
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method copies changed metadata between the input
		/// instance and the current instance.</summary>
		///
		/// <param name="inputDiagramEntity">The diagramentity to get metadata.</param>
		///--------------------------------------------------------------------------------
		public void CopyChangedMetadata(DiagramEntity inputDiagramEntity)
		{
			DiagramID = inputDiagramEntity.DiagramID;
			EntityID = inputDiagramEntity.EntityID;
			PositionX = inputDiagramEntity.PositionX;
			PositionY = inputDiagramEntity.PositionY;
			ShowPropertyArcs = inputDiagramEntity.ShowPropertyArcs;
			ShowPropertyReferenceArcs = inputDiagramEntity.ShowPropertyReferenceArcs;
			ShowCollectionArcs = inputDiagramEntity.ShowCollectionArcs;
			ShowEntityReferenceArcs = inputDiagramEntity.ShowEntityReferenceArcs;
			IsAutoUpdated = inputDiagramEntity.IsAutoUpdated;
			Description = inputDiagramEntity.Description;
			
			#region protected
			#endregion protected
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method sets or resets the ID, based on a known source, or a new
		/// source.</summary>
		///--------------------------------------------------------------------------------
		public virtual void SetID()
		{
			_defaultSourceName = null;
			if (Solution.UsedModelIDs[DefaultSourceName].GetGuid() != Guid.Empty)
			{
				DiagramEntityID = Solution.UsedModelIDs[DefaultSourceName].GetGuid();
			}
			else
			{
				if (DiagramEntityID == Guid.Empty)
				{
					DiagramEntityID = Guid.NewGuid();
				}
				Solution.UsedModelIDs[DefaultSourceName] = DiagramEntityID;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (ReverseInstance != null)
			{
				ReverseInstance.Dispose();
				ReverseInstance = null;
			}
			if (ForwardInstance != null)
			{
				ForwardInstance.Dispose();
				ForwardInstance = null;
			}
			Entity = null;
			Diagram = null;
			Solution = null;
			
			#region protected
			#endregion protected
			
			base.OnDispose();
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method assigns a value to a property, and updates corresponding
		/// forward and reverse engineering data.</summary>
		/// 
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		///--------------------------------------------------------------------------------
		public virtual bool AssignProperty(string propertyName, object propertyValue)
		{
			if (this.SetPropertyValue(propertyName, propertyValue) == true)
			{
				if (ReverseInstance == null)
				{
					ReverseInstance = new DiagramEntity();
					ReverseInstance.TransformDataFromObject(this, null, false);
				}
				else
				{
					ReverseInstance.SetPropertyValue(propertyName, propertyValue);
				}
				if (ForwardInstance != null)
				{
					this.TransformDataFromObject(ForwardInstance, null, false, true);
				}
			}
			else
			{
				return false;
			}
			
			#region protected
			#endregion protected
			
			return true;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method creates a collection item to be used as an ID reference that
		/// will be saved, so the ID of this instance is maintained.</summary>
		///--------------------------------------------------------------------------------
		public virtual CollectionItem CreateIDReference()
		{
			CollectionItem newItem = new CollectionItem();
			newItem.ItemID = DiagramEntityID;
			newItem.ItemName = DefaultSourceName;
			return newItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property returns a copy of the forward engineering data for the solution.</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntity GetForwardInstance(Solution forwardSolution)
		{
			bool isCustomized = false;
			DiagramEntity forwardItem = new DiagramEntity();
			if (ForwardInstance != null)
			{
				forwardItem.TransformDataFromObject(ForwardInstance, null, false);
				isCustomized = true;
			}
			else if (IsAutoUpdated == false)
			{
				forwardItem.TransformDataFromObject(this, null, false);
				isCustomized = true;
			}
			else
			{
				forwardItem.DiagramEntityID = DiagramEntityID;
			}
			if (isCustomized == false)
			{
				return null;
			}
			forwardItem.SpecSourceName = DefaultSourceName;
			if (forwardSolution.ReferencedModelIDs.Find("ItemName", forwardItem.SpecSourceName) == null)
			{
				forwardSolution.ReferencedModelIDs.Add(CreateIDReference());
			}
			
			#region protected
			if (Entity != null)
			{
				Entity.SpecSourceName = Entity.DefaultSourceName;
				if (forwardSolution.ReferencedModelIDs.Find("ItemName", Entity.SpecSourceName) == null)
				{
					forwardSolution.ReferencedModelIDs.Add(Entity.CreateIDReference());
				}
			}
			#endregion protected
			
			return forwardItem;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the current model context for the item.</summary>
		/// 
		/// <param name="parentModelContext">The parent model context from which to get current model context.</param>
		/// <param name="isValidContext">Output flag, signifying whether context returned is a valid one.</param>
		///--------------------------------------------------------------------------------
		public static IDomainEnterpriseObject GetModelContext(Solution solutionContext, IDomainEnterpriseObject parentModelContext, out bool isValidContext)
		{
			isValidContext = true;
			IDomainEnterpriseObject modelContext = parentModelContext;
			while (modelContext != null)
			{
				if (modelContext is DiagramEntity)
				{
					return modelContext;
				}
				else if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && modelContext is Diagram)
				{
					solutionContext.NeedsSample = false;
					Diagram parent = modelContext as Diagram;
					if (parent.DiagramEntityList.Count > 0)
					{
						return parent.DiagramEntityList[DataHelper.GetRandomInt(0, parent.DiagramEntityList.Count - 1)];
					}
				}
				#region protected
				#endregion protected
				
				if (modelContext is Solution) break;
				modelContext = modelContext.GetParentItem();
			}
			if (solutionContext.IsSampleMode == true && solutionContext.NeedsSample == true && solutionContext.DiagramEntityList.Count > 0)
			{
				solutionContext.NeedsSample = false;
				return solutionContext.DiagramEntityList[DataHelper.GetRandomInt(0, solutionContext.DiagramEntityList.Count - 1)];
			}
			isValidContext = false;
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the collection context associated with this item.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="modelContext">The associated model context.</param>
		///--------------------------------------------------------------------------------
		public static IEnterpriseEnumerable GetCollectionContext(Solution solutionContext, IDomainEnterpriseObject modelContext)
		{
			IDomainEnterpriseObject nodeContext = modelContext;
			while (nodeContext != null)
			{
				if (nodeContext is Diagram)
				{
					return (nodeContext as Diagram).DiagramEntityList;
				}
				else if (nodeContext is Solution)
				{
					return (nodeContext as Solution).DiagramEntityList;
				}
				
				#region protected
				#endregion protected
				
				nodeContext = nodeContext.GetParentItem();
			}
			return null;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parent item of this item.</summary>
		///--------------------------------------------------------------------------------
		public override IDomainEnterpriseObject GetParentItem()
		{
			return Diagram;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item to the parent, if not found.</summary>
		///--------------------------------------------------------------------------------
		public void AddToParent()
		{
			Diagram diagram = Solution.DiagramList.Find(i => i.DiagramID == DiagramID);
			if (diagram != null)
			{
				Diagram = diagram;
				SetID();  // id (from saved ids) may change based on parent info
				DiagramEntity diagramEntity = diagram.DiagramEntityList.Find(i => i.DiagramEntityID == DiagramEntityID);
				if (diagramEntity != null)
				{
					if (diagramEntity != this)
					{
						diagram.DiagramEntityList.Remove(diagramEntity);
						diagram.DiagramEntityList.Add(this);
					}
				}
				else
				{
					diagram.DiagramEntityList.Add(this);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method adds the current item to the solution, if it is valid
		/// and not already present in the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		/// <param name="templateContext">The associated template.</param>
		/// <param name="lineNumber">The line number of the associated statement.</param>
		///--------------------------------------------------------------------------------
		public static void AddCurrentItemToSolution(Solution solutionContext, ITemplate templateContext, int lineNumber)
		{
			if (solutionContext.CurrentDiagramEntity != null)
			{
				string validationErrors = solutionContext.CurrentDiagramEntity.GetValidationErrors();
				if (!String.IsNullOrEmpty(validationErrors))
				{
					templateContext.LogException(solutionContext, solutionContext.CurrentDiagramEntity, validationErrors, lineNumber, InterpreterTypeCode.Output);
				}
				// link item to known id, solution, and parent
				solutionContext.CurrentDiagramEntity.Solution = solutionContext;
				solutionContext.CurrentDiagramEntity.AddToParent();
				DiagramEntity existingItem = solutionContext.DiagramEntityList.Find(i => i.DiagramEntityID == solutionContext.CurrentDiagramEntity.DiagramEntityID);
				if (existingItem == null)
				{
					// add new item to solution
					solutionContext.CurrentDiagramEntity.AssignProperty("DiagramEntityID", solutionContext.CurrentDiagramEntity.DiagramEntityID);
					solutionContext.CurrentDiagramEntity.ReverseInstance.ResetModified(false);
					solutionContext.DiagramEntityList.Add(solutionContext.CurrentDiagramEntity);
				}
				else
				{
					// update existing item in solution
					if (existingItem.ForwardInstance == null && existingItem.IsAutoUpdated == false)
					{
						existingItem.ForwardInstance = new DiagramEntity();
						existingItem.ForwardInstance.TransformDataFromObject(existingItem, null, false);
					}
					existingItem.TransformDataFromObject(solutionContext.CurrentDiagramEntity, null, false);
					existingItem.AddToParent();
					existingItem.AssignProperty("DiagramEntityID", existingItem.DiagramEntityID);
					existingItem.ReverseInstance.ResetModified(false);
					solutionContext.CurrentDiagramEntity = existingItem;
				}
				#region protected
				#endregion protected
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method deletes the current DiagramEntity item from the solution.</summary>
		/// 
		/// <param name="solutionContext">The associated solution.</param>
		///--------------------------------------------------------------------------------
		public static void DeleteCurrentItemFromSolution(Solution solutionContext)
		{
			if (solutionContext.CurrentDiagramEntity != null)
			{
				DiagramEntity existingItem = solutionContext.DiagramEntityList.Find(i => i.DiagramEntityID == solutionContext.CurrentDiagramEntity.DiagramEntityID);
				if (existingItem != null)
				{
					solutionContext.DiagramEntityList.Remove(solutionContext.CurrentDiagramEntity);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method gets the DiagramEntity instance from an xml file.</summary>
		///
		/// <param name="inputFilePath">The path of the file to load from.</param>
		///--------------------------------------------------------------------------------
		public override void Load(string inputFilePath)
		{
			base.Load(inputFilePath);
			ResetLoaded(true);
			ResetModified(false);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method saves the DiagramEntity instance to an xml file.</summary>
		///
		/// <param name="inputFilePath">The path of the file to save to.</param>
		///--------------------------------------------------------------------------------
		public override void Save(string inputFilePath)
		{
			base.Save(inputFilePath);
			ResetLoaded(true);
			ResetModified(false);
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsLoaded state for the instance.</summary>
		///
		/// <param name="isLoaded">The reset value for the IsLoaded property.</param>
		///--------------------------------------------------------------------------------
		public override void ResetLoaded(bool isLoaded)
		{
			_isLoaded = isLoaded;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsModified state for the instance.</summary>
		///
		/// <param name="isLoaded">The reset value for the IsModified property.</param>
		///--------------------------------------------------------------------------------
		public override void ResetModified(bool isModified)
		{
			base.ResetModified(isModified);
			_isModified = isModified;
		}
		
		#region protected
		#endregion protected
		
		#endregion "Methods"
		
		#region "Constructors"
		
		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntity(){}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic DiagramEntity instance
		/// with primary key values.</summary>
		///
		/// <param name="primaryKeyValues">The primary key values to initialize the instance with.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntity(string primaryKeyValues)
		{
			PrimaryKeyValues = primaryKeyValues;
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This constructor creates a business logic DiagramEntity instance
		/// with primary key properties individually.</summary>
		///
		/// <param name="diagramEntityID">The input value for DiagramEntityID.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntity(Guid diagramEntityID)
		{
			DiagramEntityID = diagramEntityID;
		}
		#endregion "Constructors"
	}
}