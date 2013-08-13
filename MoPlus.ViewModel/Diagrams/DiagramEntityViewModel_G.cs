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
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Events.Models;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.ViewModel.Workflows;

namespace MoPlus.ViewModel.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides views for DiagramEntity instances.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>8/7/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class DiagramEntityViewModel : DiagramEntityWorkspaceViewModel
	{
		#region "Menus"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewDiagramEntity.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewDiagramEntity
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramEntity;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabeNewlDiagramEntityToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDiagramEntityToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_NewDiagramEntityToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEdit.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEdit
		{
			get
			{
				return DisplayValues.ContextMenu_Edit;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelEditToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelEditToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_EditToolTip;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelDelete.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDelete
		{
			get
			{
				return DisplayValues.ContextMenu_Delete;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelDeleteToolTip.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelDeleteToolTip
		{
			get
			{
				return DisplayValues.ContextMenu_DeleteToolTip;
			}
		}

		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEdited.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEdited
		{
			get
			{
				if (EditDiagramEntity.IsModified == true)
				{
					return true;
				}
				if (ItemsToAdd.Count > 0)
				{
					return true;
				}
				if (ItemsToDelete.Count > 0)
				{
					return true;
				}
				foreach (IEditWorkspaceViewModel item in Items)
				{
					if (item.IsEdited == true)
					{
						return true;
					}
				}

				#region protected
				if (EntityViewModel.IsEdited == true)
				{
					return true;
				}
				#endregion protected
				
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets IsEditItemValid.</summary>
		///--------------------------------------------------------------------------------
		public override bool IsEditItemValid
		{
			get
			{
				return string.IsNullOrEmpty(EntityIDValidationMessage + PositionXValidationMessage + PositionYValidationMessage + ShowPropertyArcsValidationMessage + ShowPropertyReferenceArcsValidationMessage + ShowCollectionArcsValidationMessage + ShowEntityReferenceArcsValidationMessage + DescriptionValidationMessage);
			}
		}
 
		private DiagramEntity _editDiagramEntity = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditDiagramEntity.</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntity EditDiagramEntity
		{
			get
			{
				if (_editDiagramEntity == null)
				{
					_editDiagramEntity = new DiagramEntity();
					_editDiagramEntity.PropertyChanged += new PropertyChangedEventHandler(EditDiagramEntity_PropertyChanged);
					Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Children_CollectionChanged);
					if (DiagramEntity != null)
					{
						_editDiagramEntity.TransformDataFromObject(DiagramEntity, null, false);
						_editDiagramEntity.Solution = DiagramEntity.Solution;
						_editDiagramEntity.Diagram = DiagramEntity.Diagram;
						_editDiagramEntity.Entity = DiagramEntity.Entity;
					}
					_editDiagramEntity.ResetModified(false);
				}
				return _editDiagramEntity;
			}
			set
			{
				_editDiagramEntity = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets view model property changes upon property change of
		/// the edit entity.</summary>
		///--------------------------------------------------------------------------------
		void EditDiagramEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("EditDiagramEntity");
			OnPropertyChanged("TabTitle");
			
			OnPropertyChanged("EntityID");
			OnPropertyChanged("EntityIDCustomized");
			OnPropertyChanged("EntityIDValidationMessage");
			
			OnPropertyChanged("PositionX");
			OnPropertyChanged("PositionXCustomized");
			OnPropertyChanged("PositionXValidationMessage");
			
			OnPropertyChanged("PositionY");
			OnPropertyChanged("PositionYCustomized");
			OnPropertyChanged("PositionYValidationMessage");
			
			OnPropertyChanged("ShowPropertyArcs");
			OnPropertyChanged("ShowPropertyArcsCustomized");
			OnPropertyChanged("ShowPropertyArcsValidationMessage");
			
			OnPropertyChanged("ShowPropertyReferenceArcs");
			OnPropertyChanged("ShowPropertyReferenceArcsCustomized");
			OnPropertyChanged("ShowPropertyReferenceArcsValidationMessage");
			
			OnPropertyChanged("ShowCollectionArcs");
			OnPropertyChanged("ShowCollectionArcsCustomized");
			OnPropertyChanged("ShowCollectionArcsValidationMessage");
			
			OnPropertyChanged("ShowEntityReferenceArcs");
			OnPropertyChanged("ShowEntityReferenceArcsCustomized");
			OnPropertyChanged("ShowEntityReferenceArcsValidationMessage");
			
			OnPropertyChanged("Description");
			OnPropertyChanged("DescriptionCustomized");
			OnPropertyChanged("DescriptionValidationMessage");

			OnPropertyChanged("Tags");
			OnPropertyChanged("TagsCustomized");
			OnPropertyChanged("TagsValidationMessage");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title
		{
			get
			{
				return DisplayValues.Edit_DiagramEntityHeader;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return DisplayValues.Edit_DiagramEntityHeader + " (" + EditName + ")";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DiagramEntityIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DiagramEntityIDLabel
		{
			get
			{
				return DisplayValues.Edit_DiagramEntityIDProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the EntityIDLabel.</summary>
		///--------------------------------------------------------------------------------
		public string EntityIDLabel
		{
			get
			{
				return DisplayValues.Edit_EntityIDSelection + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets EntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid EntityID
		{
			get
			{
				return EditDiagramEntity.EntityID;
			}
			set
			{
				EditDiagramEntity.EntityID = value;
				OnPropertyChanged("EntityID");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityIDCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool EntityIDCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return EntityID.GetGuid() != DiagramEntity.ReverseInstance.EntityID.GetGuid();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return EntityID.GetGuid() != DiagramEntity.EntityID.GetGuid();
				}
				return EntityID != DefaultValue.Guid;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets EntityIDValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string EntityIDValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateEntityID();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PositionXLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PositionXLabel
		{
			get
			{
				return DisplayValues.Edit_PositionXProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PositionX.</summary>
		///--------------------------------------------------------------------------------
		public double PositionX
		{
			get
			{
				return EditDiagramEntity.PositionX;
			}
			set
			{
				EditDiagramEntity.PositionX = value;
				OnPropertyChanged("PositionX");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PositionXCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PositionXCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return PositionX.GetDouble() != DiagramEntity.ReverseInstance.PositionX.GetDouble();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return PositionX.GetDouble() != DiagramEntity.PositionX.GetDouble();
				}
				return PositionX != DefaultValue.Double;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PositionXValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PositionXValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidatePositionX();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the PositionYLabel.</summary>
		///--------------------------------------------------------------------------------
		public string PositionYLabel
		{
			get
			{
				return DisplayValues.Edit_PositionYProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets PositionY.</summary>
		///--------------------------------------------------------------------------------
		public double PositionY
		{
			get
			{
				return EditDiagramEntity.PositionY;
			}
			set
			{
				EditDiagramEntity.PositionY = value;
				OnPropertyChanged("PositionY");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets PositionYCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool PositionYCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return PositionY.GetDouble() != DiagramEntity.ReverseInstance.PositionY.GetDouble();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return PositionY.GetDouble() != DiagramEntity.PositionY.GetDouble();
				}
				return PositionY != DefaultValue.Double;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets PositionYValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string PositionYValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidatePositionY();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ShowPropertyArcsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ShowPropertyArcsLabel
		{
			get
			{
				return DisplayValues.Edit_ShowPropertyArcsProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ShowPropertyArcs.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowPropertyArcs
		{
			get
			{
				return EditDiagramEntity.ShowPropertyArcs;
			}
			set
			{
				EditDiagramEntity.ShowPropertyArcs = value;
				OnPropertyChanged("ShowPropertyArcs");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowPropertyArcsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowPropertyArcsCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return ShowPropertyArcs.GetBool() != DiagramEntity.ReverseInstance.ShowPropertyArcs.GetBool();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return ShowPropertyArcs.GetBool() != DiagramEntity.ShowPropertyArcs.GetBool();
				}
				return ShowPropertyArcs != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowPropertyArcsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ShowPropertyArcsValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateShowPropertyArcs();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ShowPropertyReferenceArcsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ShowPropertyReferenceArcsLabel
		{
			get
			{
				return DisplayValues.Edit_ShowPropertyReferenceArcsProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ShowPropertyReferenceArcs.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowPropertyReferenceArcs
		{
			get
			{
				return EditDiagramEntity.ShowPropertyReferenceArcs;
			}
			set
			{
				EditDiagramEntity.ShowPropertyReferenceArcs = value;
				OnPropertyChanged("ShowPropertyReferenceArcs");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowPropertyReferenceArcsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowPropertyReferenceArcsCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return ShowPropertyReferenceArcs.GetBool() != DiagramEntity.ReverseInstance.ShowPropertyReferenceArcs.GetBool();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return ShowPropertyReferenceArcs.GetBool() != DiagramEntity.ShowPropertyReferenceArcs.GetBool();
				}
				return ShowPropertyReferenceArcs != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowPropertyReferenceArcsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ShowPropertyReferenceArcsValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateShowPropertyReferenceArcs();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ShowCollectionArcsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ShowCollectionArcsLabel
		{
			get
			{
				return DisplayValues.Edit_ShowCollectionArcsProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ShowCollectionArcs.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowCollectionArcs
		{
			get
			{
				return EditDiagramEntity.ShowCollectionArcs;
			}
			set
			{
				EditDiagramEntity.ShowCollectionArcs = value;
				OnPropertyChanged("ShowCollectionArcs");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowCollectionArcsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowCollectionArcsCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return ShowCollectionArcs.GetBool() != DiagramEntity.ReverseInstance.ShowCollectionArcs.GetBool();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return ShowCollectionArcs.GetBool() != DiagramEntity.ShowCollectionArcs.GetBool();
				}
				return ShowCollectionArcs != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowCollectionArcsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ShowCollectionArcsValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateShowCollectionArcs();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the ShowEntityReferenceArcsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string ShowEntityReferenceArcsLabel
		{
			get
			{
				return DisplayValues.Edit_ShowEntityReferenceArcsProperty;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ShowEntityReferenceArcs.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowEntityReferenceArcs
		{
			get
			{
				return EditDiagramEntity.ShowEntityReferenceArcs;
			}
			set
			{
				EditDiagramEntity.ShowEntityReferenceArcs = value;
				OnPropertyChanged("ShowEntityReferenceArcs");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowEntityReferenceArcsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool ShowEntityReferenceArcsCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return ShowEntityReferenceArcs.GetBool() != DiagramEntity.ReverseInstance.ShowEntityReferenceArcs.GetBool();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return ShowEntityReferenceArcs.GetBool() != DiagramEntity.ShowEntityReferenceArcs.GetBool();
				}
				return ShowEntityReferenceArcs != DefaultValue.Bool;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ShowEntityReferenceArcsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string ShowEntityReferenceArcsValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateShowEntityReferenceArcs();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the DescriptionLabel.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionLabel
		{
			get
			{
				return DisplayValues.Edit_DescriptionProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Description.</summary>
		///--------------------------------------------------------------------------------
		public string Description
		{
			get
			{
				return EditDiagramEntity.Description;
			}
			set
			{
				EditDiagramEntity.Description = value;
				OnPropertyChanged("Description");
				OnPropertyChanged("TabTitle");
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool DescriptionCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return Description.GetString() != DiagramEntity.ReverseInstance.Description.GetString();
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return Description.GetString() != DiagramEntity.Description.GetString();
				}
				return Description != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DescriptionValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string DescriptionValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateDescription();
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SourceName
		{
			get
			{
				return EditDiagramEntity.SourceName;
			}
			set
			{
				EditDiagramEntity.SourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameLabel.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameLabel
		{
			get
			{
				return DisplayValues.Edit_SpecSourceNameProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the SpecSourceName.</summary>
		///--------------------------------------------------------------------------------
		public override string SpecSourceName
		{
			get
			{
				return EditDiagramEntity.SpecSourceName;
			}
			set
			{
				EditDiagramEntity.SpecSourceName = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool SpecSourceNameCustomized
		{
			get
			{
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameVisibility
		{
			get
			{
				if (String.IsNullOrEmpty(SpecSourceName))
				{
					return "Collapsed";
				}
				return "Visible";
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets SpecSourceNameValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string SpecSourceNameValidationMessage
		{
			get
			{
				return String.Empty;
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsLabel.</summary>
		///--------------------------------------------------------------------------------
		public string TagsLabel
		{
			get
			{
				return DisplayValues.Edit_TagsProperty + DisplayValues.Edit_LabelColon;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the Tags.</summary>
		///--------------------------------------------------------------------------------
		public override string Tags
		{
			get
			{
				return EditDiagramEntity.Tags;
			}
			set
			{
				EditDiagramEntity.Tags = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsCustomized.</summary>
		///--------------------------------------------------------------------------------
		public bool TagsCustomized
		{
			get
			{
				if (DiagramEntity.ReverseInstance != null)
				{
					return Tags != DiagramEntity.ReverseInstance.Tags;
				}
				else if (DiagramEntity.IsAutoUpdated == true)
				{
					return Tags != DiagramEntity.Tags;
				}
				return Tags != DefaultValue.String;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TagsValidationMessage.</summary>
		///--------------------------------------------------------------------------------
		public string TagsValidationMessage
		{
			get
			{
				return EditDiagramEntity.ValidateTags();
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EditName.</summary>
		///--------------------------------------------------------------------------------
		public string EditName
		{
			get
			{
				return EditDiagramEntity.Name;
			}
			set
			{
				EditDiagramEntity.Name = value;
			}
		}
		
		#endregion "Editing Support"

		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnReset()
		{
			#region protected
			EditDiagramEntity.TransformDataFromObject(DiagramEntity, null, false);
			EditDiagramEntity.ResetModified(false);
			#endregion protected
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resets the data.</summary>
		///--------------------------------------------------------------------------------
		public override void Reset()
		{
			OnReset();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnSetDefaults()
		{
			if (DiagramEntity.ReverseInstance != null)
			{
				EditDiagramEntity.TransformDataFromObject(DiagramEntity.ReverseInstance, null, false);
			}
			else if (DiagramEntity.IsAutoUpdated == true)
			{
				EditDiagramEntity.TransformDataFromObject(DiagramEntity, null, false);
			}
			else
			{
				DiagramEntity newDiagramEntity = new DiagramEntity();
				newDiagramEntity.DiagramEntityID = EditDiagramEntity.DiagramEntityID;
				EditDiagramEntity.TransformDataFromObject(newDiagramEntity, null, false);
			}
			EditDiagramEntity.ResetModified(true);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sets the default values.</summary>
		///--------------------------------------------------------------------------------
		public void Defaults()
		{
			OnSetDefaults();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the new DiagramEntity command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessNewDiagramEntityCommand()
		{
			DiagramEntityEventArgs message = new DiagramEntityEventArgs();
			message.DiagramEntity = new DiagramEntity();
			message.DiagramEntity.DiagramEntityID = Guid.NewGuid();
			message.DiagramEntity.DiagramID = DiagramID;
			message.DiagramEntity.Diagram = Solution.DiagramList.FindByID((Guid)DiagramID);
			message.DiagramEntity.Solution = Solution;
			message.DiagramID = DiagramID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEntityEventArgs>(MediatorMessages.Command_EditDiagramEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit item command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessEditDiagramEntityCommand()
		{
			DiagramEntityEventArgs message = new DiagramEntityEventArgs();
			message.DiagramEntity = DiagramEntity;
			message.DiagramID = DiagramID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEntityEventArgs>(MediatorMessages.Command_EditDiagramEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method initiates editing a new item.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnNew()
		{
			ProcessNewDiagramEntityCommand();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnUpdate()
		{
			#region protected
			// set up reverse engineering instance if not present
			if (DiagramEntity.ReverseInstance == null && DiagramEntity.IsAutoUpdated == true)
			{
				DiagramEntity.ReverseInstance = new DiagramEntity();
				DiagramEntity.ReverseInstance.TransformDataFromObject(DiagramEntity, null, false);

				// perform the update of EditDiagramEntity back to DiagramEntity
				DiagramEntity.TransformDataFromObject(EditDiagramEntity, null, false);
				DiagramEntity.IsAutoUpdated = false;
			}
			else if (DiagramEntity.ReverseInstance != null)
			{
				EditDiagramEntity.ResetModified(DiagramEntity.ReverseInstance.IsModified);
				if (EditDiagramEntity.Equals(DiagramEntity.ReverseInstance))
				{
					// perform the update of EditDiagramEntity back to DiagramEntity
					DiagramEntity.TransformDataFromObject(EditDiagramEntity, null, false);
					DiagramEntity.IsAutoUpdated = true;
				}
				else
				{
					// perform the update of EditDiagramEntity back to DiagramEntity
					DiagramEntity.TransformDataFromObject(EditDiagramEntity, null, false);
					DiagramEntity.IsAutoUpdated = false;
				}
			}
			else
			{
				// perform the update of EditDiagramEntity back to DiagramEntity
				DiagramEntity.TransformDataFromObject(EditDiagramEntity, null, false);
				DiagramEntity.IsAutoUpdated = false;
			}
			DiagramEntity.ForwardInstance = null;
			if (EntityIDCustomized || PositionXCustomized || PositionYCustomized || ShowPropertyArcsCustomized || ShowPropertyReferenceArcsCustomized || ShowCollectionArcsCustomized || ShowEntityReferenceArcsCustomized || DescriptionCustomized || TagsCustomized)
			{
				DiagramEntity.ForwardInstance = new DiagramEntity();
				DiagramEntity.ForwardInstance.DiagramEntityID = EditDiagramEntity.DiagramEntityID;
				DiagramEntity.SpecSourceName = DiagramEntity.DefaultSourceName;
				if (EntityIDCustomized)
				{
					DiagramEntity.ForwardInstance.EntityID = EditDiagramEntity.EntityID;
				}
				if (PositionXCustomized)
				{
					DiagramEntity.ForwardInstance.PositionX = EditDiagramEntity.PositionX;
				}
				if (PositionYCustomized)
				{
					DiagramEntity.ForwardInstance.PositionY = EditDiagramEntity.PositionY;
				}
				if (ShowPropertyArcsCustomized)
				{
					DiagramEntity.ForwardInstance.ShowPropertyArcs = EditDiagramEntity.ShowPropertyArcs;
				}
				if (ShowPropertyReferenceArcsCustomized)
				{
					DiagramEntity.ForwardInstance.ShowPropertyReferenceArcs = EditDiagramEntity.ShowPropertyReferenceArcs;
				}
				if (ShowCollectionArcsCustomized)
				{
					DiagramEntity.ForwardInstance.ShowCollectionArcs = EditDiagramEntity.ShowCollectionArcs;
				}
				if (ShowEntityReferenceArcsCustomized)
				{
					DiagramEntity.ForwardInstance.ShowEntityReferenceArcs = EditDiagramEntity.ShowEntityReferenceArcs;
				}
				if (DescriptionCustomized)
				{
					DiagramEntity.ForwardInstance.Description = EditDiagramEntity.Description;
				}
				if (TagsCustomized)
				{
					DiagramEntity.ForwardInstance.Tags = EditDiagramEntity.Tags;
				}
			}
			EditDiagramEntity.ResetModified(false);
			OnUpdated(this, null);

			// send update back to solution builder
			SendEditDiagramEntityPerformed();
			#endregion protected
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method updates the view model data and sends update command back
		/// to the solution builder.</summary>
		///--------------------------------------------------------------------------------
		public void Update()
		{
			OnUpdate();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends the edit item performed message to have the
		/// update applied.</summary>
		///--------------------------------------------------------------------------------
		public void SendEditDiagramEntityPerformed()
		{
			DiagramEntityEventArgs message = new DiagramEntityEventArgs();

			#region protected
			#endregion protected

			message.DiagramEntity = DiagramEntity;
			message.DiagramID = DiagramID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEntityEventArgs>(MediatorMessages.Command_EditDiagramEntityPerformed, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the delete DiagramEntity command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessDeleteDiagramEntityCommand()
		{
			DiagramEntityEventArgs message = new DiagramEntityEventArgs();
			message.DiagramEntity = DiagramEntity;
			message.DiagramID = DiagramID;
			message.Solution = Solution;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<DiagramEntityEventArgs>(MediatorMessages.Command_DeleteDiagramEntityRequested, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes a delete of the item.</summary>
		///--------------------------------------------------------------------------------
		public void Delete()
		{
			ProcessDeleteDiagramEntityCommand();
		}

		#endregion "Command Processing"

		#region "Properties"

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DiagramEntity.</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntity DiagramEntity { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets DiagramEntityID.</summary>
		///--------------------------------------------------------------------------------
		public Guid DiagramEntityID
		{
			get
			{
				return DiagramEntity.DiagramEntityID;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return DiagramEntity.Name;
			}
			set
			{
				DiagramEntity.Name = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramID.</summary>
		///--------------------------------------------------------------------------------
		public Guid DiagramID
		{
			get
			{
				return DiagramEntity.DiagramID;
			}
			set
			{
				DiagramEntity.DiagramID = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads an item of DiagramEntity into the view model.</summary>
		/// 
		/// <param name="diagramEntity">The DiagramEntity to load.</param>
		/// <param name="loadChildren">Flag indicating whether to perform a deeper load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDiagramEntity(DiagramEntity diagramEntity, bool loadChildren = true)
		{
			// attach the DiagramEntity
			DiagramEntity = diagramEntity;
			ItemID = DiagramEntity.DiagramEntityID;
			Items.Clear();
			if (loadChildren == true)
			{
				#region protected
				#endregion protected
				
				Refresh(false);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			if (refreshChildren == true || refreshLevel > 0)
			{
			}
			
			#region protected
			#endregion protected
			
			HasErrors = !DiagramEntity.IsValid;
			HasCustomizations = DiagramEntity.IsAutoUpdated == false || DiagramEntity.IsEmptyMetadata(DiagramEntity.ForwardInstance) == false || ChildrenHaveAnyCustomizations();
			if (HasCustomizations == false && DiagramEntity.ReverseInstance != null)
			{
				// remove customizations if solely due to child customizations no longer present
				DiagramEntity.IsAutoUpdated = true;
				DiagramEntity.SpecSourceName = DiagramEntity.ReverseInstance.SpecSourceName;
				DiagramEntity.ResetModified(DiagramEntity.ReverseInstance.IsModified);
				DiagramEntity.ResetLoaded(DiagramEntity.ReverseInstance.IsLoaded);
				if (!DiagramEntity.IsIdenticalMetadata(DiagramEntity.ReverseInstance))
				{
					HasCustomizations = true;
					DiagramEntity.IsAutoUpdated = false;
				}
			}
			if (HasCustomizations == false)
			{
				// clear customizations
				DiagramEntity.ForwardInstance = null;
				DiagramEntity.ReverseInstance = null;
				DiagramEntity.IsAutoUpdated = true;
			}
			OnPropertyChanged("Items");
			OnPropertyChanged("HasCustomizations");
			OnPropertyChanged("HasErrors");
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the view model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			#region protected
			if (EntityViewModel != null)
			{
				EntityViewModel.PropertyChanged -= EntityViewModel_PropertyChanged;
				EntityViewModel = null;
			}
			#endregion protected
			
			if (_editDiagramEntity != null)
			{
				Items.CollectionChanged -= Children_CollectionChanged;
				EditDiagramEntity.PropertyChanged -= EditDiagramEntity_PropertyChanged;
				EditDiagramEntity = null;
			}
			DiagramEntity = null;
			base.OnDispose();
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns whether or not the method or its children have any customizations.</summary>
		///--------------------------------------------------------------------------------
		public bool ChildrenHaveAnyCustomizations()
		{
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method manages the update of this view when children are updated.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_Updated(object sender, EventArgs e)
		{
			Refresh(false, 1);
			OnUpdated(this, e);
		}
	
		///--------------------------------------------------------------------------------
		/// <summary>This method manages when changes occur to child collections.</summary>
		/// 
		/// <param name="sender">The sender of the updated event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method returns the parent view model corresponding to
		/// the input message.</summary>
		///
		/// <param name="data">The message data to find parent for.</param>
		///--------------------------------------------------------------------------------
		public EditWorkspaceViewModel FindParentViewModel(SolutionModelEventArgs data)
		{
			#region protected
			#endregion protected
		
			return null;
		}
		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="diagramEntity">The DiagramEntity to load.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel(DiagramEntity diagramEntity, Solution solution, bool loadChildren = true)
		{
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			LoadDiagramEntity(diagramEntity, loadChildren);
		}

		#endregion "Constructors"
	}
}
