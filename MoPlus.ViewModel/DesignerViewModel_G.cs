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
using System.Collections.ObjectModel;
using MoPlus.Data;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Data;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Conventions;
using MoPlus.ViewModel.Diagrams;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Events.Interpreter;
using MoPlus.ViewModel.Models;
using MoPlus.ViewModel.Events.Models;
using MoPlus.ViewModel.Solutions;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.ViewModel.Workflows;
using MoPlus.ViewModel.Events.Workflows;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Interpreter;
using MoPlus.Interpreter.BLL.Models;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Interpreter.BLL.Specifications;
using MoPlus.Interpreter.BLL.Workflows;

namespace MoPlus.ViewModel
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides the view for the designer workspaces.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>1/22/2017</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public partial class DesignerViewModel : WorkspaceViewModel
	{
		#region "Command Processing"
		///--------------------------------------------------------------------------------
		/// <summary>This method processes show Help messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ShowHelpRequested, ParameterType = typeof(HelpEventArgs))]
		public void ProcessShowHelpRequested(HelpEventArgs data)
		{
			ProcessShowHelp(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the show Help command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessShowHelp(HelpEventArgs args)
		{
			bool itemExists = false;
			if (args.HelpViewModel == null)
				return;

			if (args.WorkspaceID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (HelpViewModel item in Items.OfType<HelpViewModel>())
				{
					if (item.WorkspaceID == args.WorkspaceID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					HelpViewModel view = new HelpViewModel(args.HelpViewModel.Title, args.HelpViewModel.Paragraph1, args.HelpViewModel.Paragraph2, args.HelpViewModel.Paragraph3, args.HelpViewModel.Paragraph4, args.HelpViewModel.Paragraph5, args.HelpViewModel.Paragraph6);
					view.Image = args.HelpViewModel.Image;
					view.ItemID = args.HelpViewModel.ItemID;
					view.WorkspaceID = args.HelpViewModel.WorkspaceID;
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes close item messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_CloseItemRequested, ParameterType = typeof(WorkspaceEventArgs))]
		public void ProcessCloseItemRequested(WorkspaceEventArgs data)
		{
			if (data != null)
			{
				CloseItem(data.ItemID);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes close solution item messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_CloseSolutionItemsRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessCloseSolutionItemsRequested(SolutionEventArgs data)
		{
			if (data != null && data.Solution != null)
			{
				CloseAllItemsForSolution(data.Solution.SolutionID, data.ForceClose);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes manage (tag) item messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_ManageItemRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessManageItemRequested(SolutionEventArgs data)
		{
			ProcessManageItem(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the manage (tag) item command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessManageItem(SolutionEventArgs args)
		{
			bool itemExists = false;
			if (args.Solution == null)
				return;

			if (args.Solution.SolutionID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (TagManagementViewModel item in Items.OfType<TagManagementViewModel>())
				{
					if (item.Solution.SolutionID == args.Solution.SolutionID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					TagManagementViewModel tagView = new TagManagementViewModel(args.Solution);
					SelectedItem = tagView;
					tagView.IsSelected = true;
					Items.Add(tagView);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes breakpoint reached messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_BreakpointReached, ParameterType = typeof(SolutionDebugEventArgs))]
		public void ProcessBreakpointReachedRequested(SolutionDebugEventArgs data)
		{
			ProcessBreakpointReached(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the breakpoint reached command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessBreakpointReached(SolutionDebugEventArgs args)
		{
			foreach (CodeTemplateViewModel item in Items.OfType<CodeTemplateViewModel>())
			{
				item.SetDebugVisibility(DebugAction.Breaking, args.InterpreterType, args.TemplateContext.TemplateID);
				if (item.TemplateID == args.TemplateContext.TemplateID)
				{
					item.IsSelected = true;
					item.HandleBreakpoint(args.InterpreterType, args.ModelContext, args.LineNumber);
				}
				else
				{
					item.IsSelected = false;
				}
			}
			foreach (SpecTemplateViewModel item in Items.OfType<SpecTemplateViewModel>())
			{
				item.SetDebugVisibility(DebugAction.Breaking, args.InterpreterType, args.TemplateContext.TemplateID);
				if (item.TemplateID == args.TemplateContext.TemplateID)
				{
					item.IsSelected = true;
					item.HandleBreakpoint(args.InterpreterType, args.ModelContext, args.LineNumber);
				}
				else
				{
					item.IsSelected = false;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes debug finished messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_DebugFinished, ParameterType = typeof(SolutionDebugEventArgs))]
		public void ProcessDebugFinishedRequested(SolutionDebugEventArgs data)
		{
			ProcessDebugFinished(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the debug finished command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessDebugFinished(SolutionDebugEventArgs args)
		{
			foreach (CodeTemplateViewModel item in Items.OfType<CodeTemplateViewModel>())
			{
				item.SetDebugVisibility(DebugAction.None, args.InterpreterType, args.TemplateContext.TemplateID);
				if (item.TemplateID == args.TemplateContext.TemplateID)
				{
					item.IsSelected = true;
				}
				else
				{
					item.IsSelected = false;
				}
			}
			foreach (SpecTemplateViewModel item in Items.OfType<SpecTemplateViewModel>())
			{
				item.SetDebugVisibility(DebugAction.None, args.InterpreterType, args.TemplateContext.TemplateID);
				if (item.TemplateID == args.TemplateContext.TemplateID)
				{
					item.IsSelected = true;
				}
				else
				{
					item.IsSelected = false;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit solution messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditSolutionRequested, ParameterType = typeof(SolutionEventArgs))]
		public void ProcessEditSolutionRequested(SolutionEventArgs data)
		{
			ProcessEditSolution(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit solution command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditSolution(SolutionEventArgs args)
		{
			bool itemExists = false;
			if (args.Solution == null)
				return;

			if (args.Solution.SolutionID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (SolutionViewModel item in Items.OfType<SolutionViewModel>())
				{
					if (item.Solution.SolutionID == args.Solution.SolutionID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					SolutionViewModel solutionView = new SolutionViewModel(args.Solution, false);

					// set as edit view model so that the solution model is not disposed
					solutionView.IsEditViewModel = true;
					SelectedItem = solutionView;
					solutionView.IsSelected = true;
					Items.Add(solutionView);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit AuditProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditAuditPropertyRequested, ParameterType = typeof(AuditPropertyEventArgs))]
		public void ProcessEditAuditPropertyRequested(AuditPropertyEventArgs data)
		{
			ProcessEditAuditProperty(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit AuditProperty command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditAuditProperty(AuditPropertyEventArgs args)
		{
			bool itemExists = false;
			if (args.AuditProperty == null)
				return;

			if (args.AuditProperty .PropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (AuditPropertyViewModel item in Items.OfType<AuditPropertyViewModel>())
				{
					if (item.AuditProperty.PropertyID == args.AuditProperty.PropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					AuditPropertyViewModel view = new AuditPropertyViewModel(args.AuditProperty, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit CodeTemplate messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditCodeTemplateRequested, ParameterType = typeof(CodeTemplateEventArgs))]
		public void ProcessEditCodeTemplateRequested(CodeTemplateEventArgs data)
		{
			ProcessEditCodeTemplate(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit CodeTemplate command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditCodeTemplate(CodeTemplateEventArgs args)
		{
			bool itemExists = false;
			if (args.CodeTemplate == null)
				return;

			if (args.CodeTemplate .TemplateID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (CodeTemplateViewModel item in Items.OfType<CodeTemplateViewModel>())
				{
					if (item.CodeTemplate.TemplateID == args.CodeTemplate.TemplateID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// load template if file path is specified
					if (!String.IsNullOrEmpty(args.CodeTemplate.FilePath))
					{
						args.CodeTemplate.LoadTemplateFileData();
					}

					// create new view model and add item to tabs
					CodeTemplateViewModel view = new CodeTemplateViewModel(args.CodeTemplate, args.Solution, args.Path);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Collection messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditCollectionRequested, ParameterType = typeof(CollectionEventArgs))]
		public void ProcessEditCollectionRequested(CollectionEventArgs data)
		{
			ProcessEditCollection(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Collection command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditCollection(CollectionEventArgs args)
		{
			bool itemExists = false;
			if (args.Collection == null)
				return;

			if (args.Collection .PropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (CollectionViewModel item in Items.OfType<CollectionViewModel>())
				{
					if (item.Collection.PropertyID == args.Collection.PropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					CollectionViewModel view = new CollectionViewModel(args.Collection, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit DatabaseSource messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditDatabaseSourceRequested, ParameterType = typeof(DatabaseSourceEventArgs))]
		public void ProcessEditDatabaseSourceRequested(DatabaseSourceEventArgs data)
		{
			ProcessEditDatabaseSource(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit DatabaseSource command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditDatabaseSource(DatabaseSourceEventArgs args)
		{
			bool itemExists = false;
			if (args.DatabaseSource == null)
				return;

			if (args.DatabaseSource .SpecificationSourceID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (DatabaseSourceViewModel item in Items.OfType<DatabaseSourceViewModel>())
				{
					if (item.DatabaseSource.SpecificationSourceID == args.DatabaseSource.SpecificationSourceID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					DatabaseSourceViewModel view = new DatabaseSourceViewModel(args.DatabaseSource, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Diagram messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditDiagramRequested, ParameterType = typeof(DiagramEventArgs))]
		public void ProcessEditDiagramRequested(DiagramEventArgs data)
		{
			ProcessEditDiagram(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Diagram command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditDiagram(DiagramEventArgs args)
		{
			bool itemExists = false;
			if (args.Diagram == null)
				return;

			if (args.Diagram .DiagramID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (DiagramViewModel item in Items.OfType<DiagramViewModel>())
				{
					if (item.Diagram.DiagramID == args.Diagram.DiagramID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					#region protected
					// create new view model and add item to tabs
					DiagramViewModel diagramView = new DiagramViewModel(args.Diagram, args.Entities, args.Solution);
					SelectedItem = diagramView;
					diagramView.IsSelected = true;
					Items.Add(diagramView);
					#endregion protected
					
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Entity messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEntityRequested, ParameterType = typeof(EntityEventArgs))]
		public void ProcessEditEntityRequested(EntityEventArgs data)
		{
			ProcessEditEntity(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Entity command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditEntity(EntityEventArgs args)
		{
			bool itemExists = false;
			if (args.Entity == null)
				return;

			if (args.Entity .EntityID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (EntityViewModel item in Items.OfType<EntityViewModel>())
				{
					if (item.Entity.EntityID == args.Entity.EntityID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					EntityViewModel view = new EntityViewModel(args.Entity, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit EntityReference messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEntityReferenceRequested, ParameterType = typeof(EntityReferenceEventArgs))]
		public void ProcessEditEntityReferenceRequested(EntityReferenceEventArgs data)
		{
			ProcessEditEntityReference(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit EntityReference command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditEntityReference(EntityReferenceEventArgs args)
		{
			bool itemExists = false;
			if (args.EntityReference == null)
				return;

			if (args.EntityReference .PropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (EntityReferenceViewModel item in Items.OfType<EntityReferenceViewModel>())
				{
					if (item.EntityReference.PropertyID == args.EntityReference.PropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					EntityReferenceViewModel view = new EntityReferenceViewModel(args.EntityReference, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Enumeration messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditEnumerationRequested, ParameterType = typeof(EnumerationEventArgs))]
		public void ProcessEditEnumerationRequested(EnumerationEventArgs data)
		{
			ProcessEditEnumeration(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Enumeration command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditEnumeration(EnumerationEventArgs args)
		{
			bool itemExists = false;
			if (args.Enumeration == null)
				return;

			if (args.Enumeration .EnumerationID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (EnumerationViewModel item in Items.OfType<EnumerationViewModel>())
				{
					if (item.Enumeration.EnumerationID == args.Enumeration.EnumerationID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					EnumerationViewModel view = new EnumerationViewModel(args.Enumeration, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Feature messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditFeatureRequested, ParameterType = typeof(FeatureEventArgs))]
		public void ProcessEditFeatureRequested(FeatureEventArgs data)
		{
			ProcessEditFeature(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Feature command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditFeature(FeatureEventArgs args)
		{
			bool itemExists = false;
			if (args.Feature == null)
				return;

			if (args.Feature .FeatureID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (FeatureViewModel item in Items.OfType<FeatureViewModel>())
				{
					if (item.Feature.FeatureID == args.Feature.FeatureID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					FeatureViewModel view = new FeatureViewModel(args.Feature, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Index messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditIndexRequested, ParameterType = typeof(IndexEventArgs))]
		public void ProcessEditIndexRequested(IndexEventArgs data)
		{
			ProcessEditIndex(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Index command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditIndex(IndexEventArgs args)
		{
			bool itemExists = false;
			if (args.Index == null)
				return;

			if (args.Index .IndexID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (IndexViewModel item in Items.OfType<IndexViewModel>())
				{
					if (item.Index.IndexID == args.Index.IndexID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					IndexViewModel view = new IndexViewModel(args.Index, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit IndexProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditIndexPropertyRequested, ParameterType = typeof(IndexPropertyEventArgs))]
		public void ProcessEditIndexPropertyRequested(IndexPropertyEventArgs data)
		{
			ProcessEditIndexProperty(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit IndexProperty command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditIndexProperty(IndexPropertyEventArgs args)
		{
			bool itemExists = false;
			if (args.IndexProperty == null)
				return;

			if (args.IndexProperty .IndexPropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (IndexPropertyViewModel item in Items.OfType<IndexPropertyViewModel>())
				{
					if (item.IndexProperty.IndexPropertyID == args.IndexProperty.IndexPropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					IndexPropertyViewModel view = new IndexPropertyViewModel(args.IndexProperty, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Method messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditMethodRequested, ParameterType = typeof(MethodEventArgs))]
		public void ProcessEditMethodRequested(MethodEventArgs data)
		{
			ProcessEditMethod(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Method command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditMethod(MethodEventArgs args)
		{
			bool itemExists = false;
			if (args.Method == null)
				return;

			if (args.Method .MethodID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (MethodViewModel item in Items.OfType<MethodViewModel>())
				{
					if (item.Method.MethodID == args.Method.MethodID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					MethodViewModel view = new MethodViewModel(args.Method, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Model messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelRequested, ParameterType = typeof(ModelEventArgs))]
		public void ProcessEditModelRequested(ModelEventArgs data)
		{
			ProcessEditModel(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Model command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditModel(ModelEventArgs args)
		{
			bool itemExists = false;
			if (args.Model == null)
				return;

			if (args.Model .ModelID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ModelViewModel item in Items.OfType<ModelViewModel>())
				{
					if (item.Model.ModelID == args.Model.ModelID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ModelViewModel view = new ModelViewModel(args.Model, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ModelObject messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelObjectRequested, ParameterType = typeof(ModelObjectEventArgs))]
		public void ProcessEditModelObjectRequested(ModelObjectEventArgs data)
		{
			ProcessEditModelObject(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit ModelObject command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditModelObject(ModelObjectEventArgs args)
		{
			bool itemExists = false;
			if (args.ModelObject == null)
				return;

			if (args.ModelObject .ModelObjectID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ModelObjectViewModel item in Items.OfType<ModelObjectViewModel>())
				{
					if (item.ModelObject.ModelObjectID == args.ModelObject.ModelObjectID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ModelObjectViewModel view = new ModelObjectViewModel(args.ModelObject, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ModelProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditModelPropertyRequested, ParameterType = typeof(ModelPropertyEventArgs))]
		public void ProcessEditModelPropertyRequested(ModelPropertyEventArgs data)
		{
			ProcessEditModelProperty(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit ModelProperty command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditModelProperty(ModelPropertyEventArgs args)
		{
			bool itemExists = false;
			if (args.ModelProperty == null)
				return;

			if (args.ModelProperty .ModelPropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ModelPropertyViewModel item in Items.OfType<ModelPropertyViewModel>())
				{
					if (item.ModelProperty.ModelPropertyID == args.ModelProperty.ModelPropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ModelPropertyViewModel view = new ModelPropertyViewModel(args.ModelProperty, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ObjectInstance messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditObjectInstanceRequested, ParameterType = typeof(ObjectInstanceEventArgs))]
		public void ProcessEditObjectInstanceRequested(ObjectInstanceEventArgs data)
		{
			ProcessEditObjectInstance(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit ObjectInstance command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditObjectInstance(ObjectInstanceEventArgs args)
		{
			bool itemExists = false;
			if (args.ObjectInstance == null)
				return;

			if (args.ObjectInstance .ObjectInstanceID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ObjectInstanceViewModel item in Items.OfType<ObjectInstanceViewModel>())
				{
					if (item.ObjectInstance.ObjectInstanceID == args.ObjectInstance.ObjectInstanceID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ObjectInstanceViewModel view = new ObjectInstanceViewModel(args.ObjectInstance, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Parameter messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditParameterRequested, ParameterType = typeof(ParameterEventArgs))]
		public void ProcessEditParameterRequested(ParameterEventArgs data)
		{
			ProcessEditParameter(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Parameter command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditParameter(ParameterEventArgs args)
		{
			bool itemExists = false;
			if (args.Parameter == null)
				return;

			if (args.Parameter .ParameterID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ParameterViewModel item in Items.OfType<ParameterViewModel>())
				{
					if (item.Parameter.ParameterID == args.Parameter.ParameterID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ParameterViewModel view = new ParameterViewModel(args.Parameter, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Project messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditProjectRequested, ParameterType = typeof(ProjectEventArgs))]
		public void ProcessEditProjectRequested(ProjectEventArgs data)
		{
			ProcessEditProject(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Project command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditProject(ProjectEventArgs args)
		{
			bool itemExists = false;
			if (args.Project == null)
				return;

			if (args.Project .ProjectID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ProjectViewModel item in Items.OfType<ProjectViewModel>())
				{
					if (item.Project.ProjectID == args.Project.ProjectID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ProjectViewModel view = new ProjectViewModel(args.Project, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Property messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyRequested, ParameterType = typeof(PropertyEventArgs))]
		public void ProcessEditPropertyRequested(PropertyEventArgs data)
		{
			ProcessEditProperty(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Property command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditProperty(PropertyEventArgs args)
		{
			bool itemExists = false;
			if (args.Property == null)
				return;

			if (args.Property .PropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (PropertyViewModel item in Items.OfType<PropertyViewModel>())
				{
					if (item.Property.PropertyID == args.Property.PropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					PropertyViewModel view = new PropertyViewModel(args.Property, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit PropertyInstance messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyInstanceRequested, ParameterType = typeof(PropertyInstanceEventArgs))]
		public void ProcessEditPropertyInstanceRequested(PropertyInstanceEventArgs data)
		{
			ProcessEditPropertyInstance(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit PropertyInstance command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditPropertyInstance(PropertyInstanceEventArgs args)
		{
			bool itemExists = false;
			if (args.PropertyInstance == null)
				return;

			if (args.PropertyInstance .PropertyInstanceID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (PropertyInstanceViewModel item in Items.OfType<PropertyInstanceViewModel>())
				{
					if (item.PropertyInstance.PropertyInstanceID == args.PropertyInstance.PropertyInstanceID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					PropertyInstanceViewModel view = new PropertyInstanceViewModel(args.PropertyInstance, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit PropertyReference messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditPropertyReferenceRequested, ParameterType = typeof(PropertyReferenceEventArgs))]
		public void ProcessEditPropertyReferenceRequested(PropertyReferenceEventArgs data)
		{
			ProcessEditPropertyReference(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit PropertyReference command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditPropertyReference(PropertyReferenceEventArgs args)
		{
			bool itemExists = false;
			if (args.PropertyReference == null)
				return;

			if (args.PropertyReference .PropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (PropertyReferenceViewModel item in Items.OfType<PropertyReferenceViewModel>())
				{
					if (item.PropertyReference.PropertyID == args.PropertyReference.PropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					PropertyReferenceViewModel view = new PropertyReferenceViewModel(args.PropertyReference, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Relationship messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditRelationshipRequested, ParameterType = typeof(RelationshipEventArgs))]
		public void ProcessEditRelationshipRequested(RelationshipEventArgs data)
		{
			ProcessEditRelationship(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Relationship command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditRelationship(RelationshipEventArgs args)
		{
			bool itemExists = false;
			if (args.Relationship == null)
				return;

			if (args.Relationship .RelationshipID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (RelationshipViewModel item in Items.OfType<RelationshipViewModel>())
				{
					if (item.Relationship.RelationshipID == args.Relationship.RelationshipID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					RelationshipViewModel view = new RelationshipViewModel(args.Relationship, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit RelationshipProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditRelationshipPropertyRequested, ParameterType = typeof(RelationshipPropertyEventArgs))]
		public void ProcessEditRelationshipPropertyRequested(RelationshipPropertyEventArgs data)
		{
			ProcessEditRelationshipProperty(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit RelationshipProperty command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditRelationshipProperty(RelationshipPropertyEventArgs args)
		{
			bool itemExists = false;
			if (args.RelationshipProperty == null)
				return;

			if (args.RelationshipProperty .RelationshipPropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (RelationshipPropertyViewModel item in Items.OfType<RelationshipPropertyViewModel>())
				{
					if (item.RelationshipProperty.RelationshipPropertyID == args.RelationshipProperty.RelationshipPropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					RelationshipPropertyViewModel view = new RelationshipPropertyViewModel(args.RelationshipProperty, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit SpecTemplate messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditSpecTemplateRequested, ParameterType = typeof(SpecTemplateEventArgs))]
		public void ProcessEditSpecTemplateRequested(SpecTemplateEventArgs data)
		{
			ProcessEditSpecTemplate(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit SpecTemplate command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditSpecTemplate(SpecTemplateEventArgs args)
		{
			bool itemExists = false;
			if (args.SpecTemplate == null)
				return;

			if (args.SpecTemplate .TemplateID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (SpecTemplateViewModel item in Items.OfType<SpecTemplateViewModel>())
				{
					if (item.SpecTemplate.TemplateID == args.SpecTemplate.TemplateID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// load template if file path is specified
					if (!String.IsNullOrEmpty(args.SpecTemplate.FilePath))
					{
						args.SpecTemplate.LoadTemplateFileData();
					}

					// create new view model and add item to tabs
					SpecTemplateViewModel view = new SpecTemplateViewModel(args.SpecTemplate, args.Solution, args.Path, args.SpecTemplate.SpecificationDirectory);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Stage messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStageRequested, ParameterType = typeof(StageEventArgs))]
		public void ProcessEditStageRequested(StageEventArgs data)
		{
			ProcessEditStage(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Stage command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditStage(StageEventArgs args)
		{
			bool itemExists = false;
			if (args.Stage == null)
				return;

			if (args.Stage .StageID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StageViewModel item in Items.OfType<StageViewModel>())
				{
					if (item.Stage.StageID == args.Stage.StageID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StageViewModel view = new StageViewModel(args.Stage, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StageTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStageTransitionRequested, ParameterType = typeof(StageTransitionEventArgs))]
		public void ProcessEditStageTransitionRequested(StageTransitionEventArgs data)
		{
			ProcessEditStageTransition(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit StageTransition command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditStageTransition(StageTransitionEventArgs args)
		{
			bool itemExists = false;
			if (args.StageTransition == null)
				return;

			if (args.StageTransition .StageTransitionID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StageTransitionViewModel item in Items.OfType<StageTransitionViewModel>())
				{
					if (item.StageTransition.StageTransitionID == args.StageTransition.StageTransitionID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StageTransitionViewModel view = new StageTransitionViewModel(args.StageTransition, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit State messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateRequested, ParameterType = typeof(StateEventArgs))]
		public void ProcessEditStateRequested(StateEventArgs data)
		{
			ProcessEditState(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit State command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditState(StateEventArgs args)
		{
			bool itemExists = false;
			if (args.State == null)
				return;

			if (args.State .StateID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StateViewModel item in Items.OfType<StateViewModel>())
				{
					if (item.State.StateID == args.State.StateID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StateViewModel view = new StateViewModel(args.State, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StateModel messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateModelRequested, ParameterType = typeof(StateModelEventArgs))]
		public void ProcessEditStateModelRequested(StateModelEventArgs data)
		{
			ProcessEditStateModel(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit StateModel command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditStateModel(StateModelEventArgs args)
		{
			bool itemExists = false;
			if (args.StateModel == null)
				return;

			if (args.StateModel .StateModelID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StateModelViewModel item in Items.OfType<StateModelViewModel>())
				{
					if (item.StateModel.StateModelID == args.StateModel.StateModelID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StateModelViewModel view = new StateModelViewModel(args.StateModel, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StateTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStateTransitionRequested, ParameterType = typeof(StateTransitionEventArgs))]
		public void ProcessEditStateTransitionRequested(StateTransitionEventArgs data)
		{
			ProcessEditStateTransition(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit StateTransition command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditStateTransition(StateTransitionEventArgs args)
		{
			bool itemExists = false;
			if (args.StateTransition == null)
				return;

			if (args.StateTransition .StateTransitionID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StateTransitionViewModel item in Items.OfType<StateTransitionViewModel>())
				{
					if (item.StateTransition.StateTransitionID == args.StateTransition.StateTransitionID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StateTransitionViewModel view = new StateTransitionViewModel(args.StateTransition, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Step messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStepRequested, ParameterType = typeof(StepEventArgs))]
		public void ProcessEditStepRequested(StepEventArgs data)
		{
			ProcessEditStep(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Step command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditStep(StepEventArgs args)
		{
			bool itemExists = false;
			if (args.Step == null)
				return;

			if (args.Step .StepID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StepViewModel item in Items.OfType<StepViewModel>())
				{
					if (item.Step.StepID == args.Step.StepID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StepViewModel view = new StepViewModel(args.Step, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit StepTransition messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditStepTransitionRequested, ParameterType = typeof(StepTransitionEventArgs))]
		public void ProcessEditStepTransitionRequested(StepTransitionEventArgs data)
		{
			ProcessEditStepTransition(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit StepTransition command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditStepTransition(StepTransitionEventArgs args)
		{
			bool itemExists = false;
			if (args.StepTransition == null)
				return;

			if (args.StepTransition .StepTransitionID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (StepTransitionViewModel item in Items.OfType<StepTransitionViewModel>())
				{
					if (item.StepTransition.StepTransitionID == args.StepTransition.StepTransitionID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					StepTransitionViewModel view = new StepTransitionViewModel(args.StepTransition, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Value messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditValueRequested, ParameterType = typeof(ValueEventArgs))]
		public void ProcessEditValueRequested(ValueEventArgs data)
		{
			ProcessEditValue(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Value command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditValue(ValueEventArgs args)
		{
			bool itemExists = false;
			if (args.Value == null)
				return;

			if (args.Value .ValueID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ValueViewModel item in Items.OfType<ValueViewModel>())
				{
					if (item.Value.ValueID == args.Value.ValueID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ValueViewModel view = new ValueViewModel(args.Value, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit View messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditViewRequested, ParameterType = typeof(ViewEventArgs))]
		public void ProcessEditViewRequested(ViewEventArgs data)
		{
			ProcessEditView(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit View command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditView(ViewEventArgs args)
		{
			bool itemExists = false;
			if (args.View == null)
				return;

			if (args.View .ViewID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ViewViewModel item in Items.OfType<ViewViewModel>())
				{
					if (item.View.ViewID == args.View.ViewID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ViewViewModel view = new ViewViewModel(args.View, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit ViewProperty messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditViewPropertyRequested, ParameterType = typeof(ViewPropertyEventArgs))]
		public void ProcessEditViewPropertyRequested(ViewPropertyEventArgs data)
		{
			ProcessEditViewProperty(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit ViewProperty command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditViewProperty(ViewPropertyEventArgs args)
		{
			bool itemExists = false;
			if (args.ViewProperty == null)
				return;

			if (args.ViewProperty .ViewPropertyID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (ViewPropertyViewModel item in Items.OfType<ViewPropertyViewModel>())
				{
					if (item.ViewProperty.ViewPropertyID == args.ViewProperty.ViewPropertyID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					ViewPropertyViewModel view = new ViewPropertyViewModel(args.ViewProperty, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit Workflow messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditWorkflowRequested, ParameterType = typeof(WorkflowEventArgs))]
		public void ProcessEditWorkflowRequested(WorkflowEventArgs data)
		{
			ProcessEditWorkflow(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit Workflow command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditWorkflow(WorkflowEventArgs args)
		{
			bool itemExists = false;
			if (args.Workflow == null)
				return;

			if (args.Workflow .WorkflowID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (WorkflowViewModel item in Items.OfType<WorkflowViewModel>())
				{
					if (item.Workflow.WorkflowID == args.Workflow.WorkflowID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					WorkflowViewModel view = new WorkflowViewModel(args.Workflow, args.Solution, false);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}
		
		///--------------------------------------------------------------------------------
		/// <summary>This method processes edit XmlSource messages.</summary>
		///--------------------------------------------------------------------------------
		[MediatorMessageSink(MediatorMessages.Command_EditXmlSourceRequested, ParameterType = typeof(XmlSourceEventArgs))]
		public void ProcessEditXmlSourceRequested(XmlSourceEventArgs data)
		{
			ProcessEditXmlSource(data);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the edit XmlSource command.</summary>
		///--------------------------------------------------------------------------------
		private void ProcessEditXmlSource(XmlSourceEventArgs args)
		{
			bool itemExists = false;
			if (args.XmlSource == null)
				return;

			if (args.XmlSource .SpecificationSourceID != Guid.Empty)
			{
				// check for existing item and display if found
				foreach (XmlSourceViewModel item in Items.OfType<XmlSourceViewModel>())
				{
					if (item.XmlSource.SpecificationSourceID == args.XmlSource.SpecificationSourceID)
					{
						SelectedItem = item;
						item.IsSelected = true;
						itemExists = true;
						break;
					}
				}
				if (itemExists == false)
				{
					// create new view model and add item to tabs
					XmlSourceViewModel view = new XmlSourceViewModel(args.XmlSource, args.Solution, true);
					SelectedItem = view;
					view.IsSelected = true;
					Items.Add(view);
				}
			}
		}

		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets SelectedItem, which is only used to get around
		/// an AvalonDock issue.</summary>
		///--------------------------------------------------------------------------------
		public IWorkspaceViewModel SelectedItem { get; set; }

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method closes all items without a prompt to save/cancel.</summary>
		/// 
		/// <param name="solutionID">The solution to close items for (null if all solutions).</param>
		///--------------------------------------------------------------------------------
		public void CloseNoPromptAllItems(Guid? solutionID = null)
		{
			IList<IEditWorkspaceViewModel> items = Items.OfType<IEditWorkspaceViewModel>().ToList<IEditWorkspaceViewModel>();
			foreach (IEditWorkspaceViewModel item in items)
			{
				if (solutionID == null || item.Solution.SolutionID == solutionID)
				{
					item.CloseCommand.Execute(null);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method requests all items other than the indicated one to close.</summary>
		/// 
		/// <param name="itemToKeepOpen">The tab to keep open.</param>
		///--------------------------------------------------------------------------------
		public void CloseAllItemsButThis(IEditWorkspaceViewModel itemToKeepOpen)
		{
			IList<IEditWorkspaceViewModel> items = Items.OfType<IEditWorkspaceViewModel>().ToList<IEditWorkspaceViewModel>();
			foreach (IEditWorkspaceViewModel item in items)
			{
				if (item != itemToKeepOpen)
				{
					item.CloseConfirmCommand.Execute(null);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method determines if there are any open edits.</summary>
		/// 
		/// <param name="solutionID">The solution to check for edits (null if all solutions).</param>
		///--------------------------------------------------------------------------------
		public bool HasEdits(Guid? solutionID = null)
		{
			foreach (IEditWorkspaceViewModel item in Items.OfType<IEditWorkspaceViewModel>().ToList<IEditWorkspaceViewModel>())
			{
				if (solutionID == null || item.Solution.SolutionID == solutionID)
				{
					if (item.IsEdited == true)
					{
						return true;
					}
				}
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method saves any open edits.</summary>
		/// 
		/// <param name="solutionID">The solution to check for edits (null if all solutions).</param>
		///--------------------------------------------------------------------------------
		public void SaveEdits(Guid? solutionID = null)
		{
			foreach (IEditWorkspaceViewModel item in Items.OfType<IEditWorkspaceViewModel>().ToList<IEditWorkspaceViewModel>())
			{
				if (solutionID == null || item.Solution.SolutionID == solutionID)
				{
					if (item.IsEdited == true)
					{
						item.UpdateCommand.Execute(null);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method requests all items for a solution to close.</summary>
		/// 
		/// <param name="solutionID">The solution to close items for.</param>
		///--------------------------------------------------------------------------------
		public void CloseAllItemsForSolution(Guid solutionID, bool forceClose)
		{
			foreach (IEditWorkspaceViewModel item in Items.OfType<IEditWorkspaceViewModel>().ToList<IEditWorkspaceViewModel>())
			{
				if (item.Solution != null && item.Solution.SolutionID == solutionID)
				{
					if (forceClose == true)
					{
						item.CloseForceSaveCommand.Execute(null);
					}
					else
					{
						item.CloseConfirmCommand.Execute(null);
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method closes a requested item.</summary>
		/// 
		/// <param name="itemID">The item to close.</param>
		///--------------------------------------------------------------------------------
		public void CloseItem(Guid itemID)
		{
			foreach (IEditWorkspaceViewModel item in Items.OfType<IEditWorkspaceViewModel>().ToList<IEditWorkspaceViewModel>())
			{
				if (item.ItemID == itemID)
				{
					item.CloseCommand.Execute(null);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles items changes.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Count != 0)
			{
				foreach (IEditWorkspaceViewModel item in e.NewItems)
				{
					item.RequestClose += this.OnItemRequestClose;
					SendEditItemsCountForSolution(item.SolutionID);
				}
			}
			if (e.OldItems != null && e.OldItems.Count != 0)
			{
				foreach (IEditWorkspaceViewModel item in e.OldItems)
				{
					item.RequestClose -= this.OnItemRequestClose;
					SendEditItemsCountForSolution(item.SolutionID);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends a message relating to how many items are being edited for a solution.</summary>
		/// 
		/// <param name="solution">The solution to send edit item counts for.</param>
		///--------------------------------------------------------------------------------
		private void SendEditItemsCountForSolution(Guid solutionID)
		{
			int solutionItemCount = (from item in Items.OfType<IEditWorkspaceViewModel>()
									 where item.SolutionID == solutionID
									 select item).ToList<IEditWorkspaceViewModel>().Count;
			SolutionEditEventArgs message = new SolutionEditEventArgs();
			message.SolutionID = solutionID;
			message.EditItemsCount = solutionItemCount;
			Mediator.NotifyColleagues<SolutionEditEventArgs>(MediatorMessages.Command_SolutionEditItemCount, message);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles closing of an item.</summary>
		/// 
		/// <param name="sender">Sender of the event.</param>
		/// <param name="args">Event arguments.</param>
		///--------------------------------------------------------------------------------
		private void OnItemRequestClose(object sender, EventArgs e)
		{
			if (DebugHelper.DebugAction != DebugAction.None && DebugHelper.DebugAction != DebugAction.Run)
			{
				if (sender is CodeTemplateViewModel || sender is SpecTemplateViewModel)
				{
					// prevent closing during debugging session
					return;
				}
			}
			WorkspaceViewModel workspace = sender as WorkspaceViewModel;
			workspace.Dispose();
			this.Items.Remove(workspace);
			workspace = null;
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor.</summary>
		///--------------------------------------------------------------------------------
		public DesignerViewModel()
		{
			// Register all decorated methods to the Mediator
			Mediator.Register(this);
			Items.CollectionChanged += this.OnItemsChanged;
		}

		#endregion "Constructors"
	}
}
