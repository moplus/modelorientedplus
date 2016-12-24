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
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using MoPlus.ViewModel;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Solutions;
using MoPlus.SolutionBuilder.WpfClient.Resources;
using System.IO;
using System.Runtime.Serialization;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter;

namespace MoPlus.SolutionBuilder.WpfClient.Library
{
	///--------------------------------------------------------------------------------
	/// <summary>This class provides some extra properties for a tree view item.</summary>
	///--------------------------------------------------------------------------------
	public class ModelTreeViewItem : TreeViewItem
	{
		private Point? dragStartPoint = null;
		bool isDragging = false;
		DateTime? hoverTime = null;

		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
			dragStartPoint = new Point?(e.GetPosition(this));
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.LeftButton != MouseButtonState.Pressed)
			{
				dragStartPoint = null;
				isDragging = false;
			}

			else if (dragStartPoint.HasValue && isDragging == false)
			{
				if (DataContext is ProjectViewModel
					|| DataContext is DatabaseSourceViewModel
					|| DataContext is AuditPropertyViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is CollectionViewModel
					|| DataContext is PropertyReferenceViewModel
					|| DataContext is PropertyViewModel
					|| DataContext is EntityReferenceViewModel
					|| DataContext is MethodViewModel
					|| DataContext is ParameterViewModel
					|| DataContext is IndexViewModel
					|| DataContext is IndexPropertyViewModel
					|| DataContext is RelationshipViewModel
					|| DataContext is RelationshipPropertyViewModel
					)
				{
					Point? currentPosition = new Point?(e.GetPosition(this));
					if (currentPosition.HasValue && (Math.Abs(currentPosition.Value.X - dragStartPoint.Value.X) > 2 || Math.Abs(currentPosition.Value.Y - dragStartPoint.Value.Y) > 2))
					{
						isDragging = true;
						DragDrop.DoDragDrop(this, DataContext, DragDropEffects.Copy);
						e.Handled = true;
					}
				}
			}
		}

		protected override void OnDragEnter(DragEventArgs e)
		{
			base.OnDragEnter(e);
			hoverTime = DateTime.Now;
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);
			BringIntoView();
			IsDragOver = true;
			if (hoverTime != null && DateTime.Now.Subtract((DateTime)hoverTime).TotalSeconds > .5)
			{
				foreach (string format in e.Data.GetFormats())
				{
					if (IsLogicalParent(format) == true)
					{
						IsExpanded = true;
					}
				}
			}
			e.Handled = true;
		}

		protected bool IsLogicalParent(string format)
		{
			// solutions and solution are logical parents of all pastables
			if (DataContext is SolutionsViewModel
				|| DataContext is SolutionViewModel)
			{
				return true;
			}
			// logical parents of db source
			if (format == typeof(DatabaseSourceViewModel).ToString())
			{
				if (DataContext is SpecificationSourcesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of assembly
			if (format == typeof(ProjectViewModel).ToString())
			{
				if (DataContext is ProjectsViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of audit property
			if (format == typeof(AuditPropertyViewModel).ToString())
			{
				if (DataContext is AuditPropertiesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of feature
			if (format == typeof(FeatureViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of entity
			if (format == typeof(EntityViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of collection entity property
			if (format == typeof(CollectionViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is CollectionsViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of derived entity data property
			if (format == typeof(PropertyReferenceViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is PropertyReferencesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of entity data property
			if (format == typeof(PropertyViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is PropertiesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of reference entity property
			if (format == typeof(EntityReferenceViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is EntityReferencesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of method
			if (format == typeof(MethodViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is MethodsViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of method parameter
			if (format == typeof(ParameterViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is MethodsViewModel
					|| DataContext is MethodViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of entity index
			if (format == typeof(IndexViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is IndexesViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of entity index property
			if (format == typeof(IndexPropertyViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is IndexesViewModel
					|| DataContext is IndexViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of entity relationship
			if (format == typeof(RelationshipViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is RelationshipsViewModel)
				{
					return true;
				}
				return false;
			}
			// logical parents of entity relationship property
			if (format == typeof(RelationshipPropertyViewModel).ToString())
			{
				if (DataContext is FeaturesViewModel
					|| DataContext is FeatureViewModel
					|| DataContext is EntityViewModel
					|| DataContext is RelationshipsViewModel
					|| DataContext is RelationshipViewModel)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		protected override void OnDragLeave(DragEventArgs e)
		{
			base.OnDragLeave(e);
			IsDragOver = false;
			e.Handled = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles dropping items onto the treeview.</summary>
		/// 
		/// <param name="e">Event arguments.</param>
		///--------------------------------------------------------------------------------
		protected override void OnDrop(DragEventArgs e)
		{
			base.OnDrop(e);
			IsDragOver = false;
			Paste(e.Data);
			e.Handled = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles dropping items onto the treeview.</summary>
		/// 
		/// <param name="data">The data as IDataObject.</param>
		///--------------------------------------------------------------------------------
		protected void Paste(IDataObject data)
		{
			if (data.GetDataPresent(typeof(ProjectViewModel)) == true)
			{
				// process assembly drop
				Paste(data.GetData(typeof(ProjectViewModel)) as ProjectViewModel);
			}
			else if (data.GetDataPresent(typeof(DatabaseSourceViewModel)) == true)
			{
				// process databaseSource drop
				Paste(data.GetData(typeof(DatabaseSourceViewModel)) as DatabaseSourceViewModel);
			}
			else if (data.GetDataPresent(typeof(AuditPropertyViewModel)) == true)
			{
				// process auditProperty drop
				Paste(data.GetData(typeof(AuditPropertyViewModel)) as AuditPropertyViewModel);
			}
			else if (data.GetDataPresent(typeof(FeatureViewModel)) == true)
			{
				// process feature drop
				Paste(data.GetData(typeof(FeatureViewModel)) as FeatureViewModel);
			}
			else if (data.GetDataPresent(typeof(EntityViewModel)) == true)
			{
				// process entity drop
				Paste(data.GetData(typeof(EntityViewModel)) as EntityViewModel);
			}
			else if (data.GetDataPresent(typeof(CollectionViewModel)) == true)
			{
				// process collectionProperty drop
				Paste(data.GetData(typeof(CollectionViewModel)) as CollectionViewModel);
			}
			else if (data.GetDataPresent(typeof(PropertyReferenceViewModel)) == true)
			{
				// process derivedProperty drop
				Paste(data.GetData(typeof(PropertyReferenceViewModel)) as PropertyReferenceViewModel);
			}
			else if (data.GetDataPresent(typeof(PropertyViewModel)) == true)
			{
				// process property drop
				Paste(data.GetData(typeof(PropertyViewModel)) as PropertyViewModel);
			}
			else if (data.GetDataPresent(typeof(EntityReferenceViewModel)) == true)
			{
				// process referenceProperty drop
				Paste(data.GetData(typeof(EntityReferenceViewModel)) as EntityReferenceViewModel);
			}
			else if (data.GetDataPresent(typeof(MethodViewModel)) == true)
			{
				// process method drop
				Paste(data.GetData(typeof(MethodViewModel)) as MethodViewModel);
			}
			else if (data.GetDataPresent(typeof(ParameterViewModel)) == true)
			{
				// process parameter drop
				Paste(data.GetData(typeof(ParameterViewModel)) as ParameterViewModel);
			}
			else if (data.GetDataPresent(typeof(IndexViewModel)) == true)
			{
				// process index drop
				Paste(data.GetData(typeof(IndexViewModel)) as IndexViewModel);
			}
			else if (data.GetDataPresent(typeof(IndexPropertyViewModel)) == true)
			{
				// process index drop
				Paste(data.GetData(typeof(IndexPropertyViewModel)) as IndexPropertyViewModel);
			}
			else if (data.GetDataPresent(typeof(RelationshipViewModel)) == true)
			{
				// process relationship drop
				Paste(data.GetData(typeof(RelationshipViewModel)) as RelationshipViewModel);
			}
			else if (data.GetDataPresent(typeof(RelationshipPropertyViewModel)) == true)
			{
				// process relationshipProperty drop
				Paste(data.GetData(typeof(RelationshipPropertyViewModel)) as RelationshipPropertyViewModel);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method handles dropping items onto the treeview.</summary>
		/// 
		/// <param name="data">The data as a viewmodel.</param>
		///--------------------------------------------------------------------------------
		protected void Paste(IWorkspaceViewModel data)
		{
			SolutionViewModel solution;
			ProjectViewModel assembly;
			DatabaseSourceViewModel databaseSource;
			AuditPropertyViewModel auditProperty;
			FeatureViewModel feature;
			EntityViewModel entity;
			CollectionViewModel collectionProperty;
			PropertyReferenceViewModel derivedProperty;
			PropertyViewModel property;
			EntityReferenceViewModel referenceProperty;
			MethodViewModel method;
			ParameterViewModel parameter;
			IndexViewModel index;
			IndexPropertyViewModel indexProperty;
			RelationshipViewModel relationship;
			RelationshipPropertyViewModel relationshipProperty;

			if (data is ProjectViewModel)
			{
				// process assembly drop
				assembly = data as ProjectViewModel;
				solution = DataContext as SolutionViewModel;
				if (solution == null)
				{
					// get parent solution
					solution = ViewModelHelper.FindParentView<SolutionViewModel>(this);
				}
				if (solution == null)
				{
					// invalid drop location
					HandleInvalidDrop(assembly);
				}
				else if (solution.ProjectsFolder.Projects.Find("Name", assembly.Name) != null)
				{
					// duplicate item found, cannot drop
					if (assembly != DataContext as ProjectViewModel)
					{
						HandleDuplicateDrop(assembly);
					}
				}
				else
				{
					// do the drop
					ProjectViewModel view = solution.ProjectsFolder.PasteProject(assembly, true);
					view.ShowInTreeView();
				}
			}
			else if (data is DatabaseSourceViewModel)
			{
				// process databaseSource drop
				databaseSource = data as DatabaseSourceViewModel;
				solution = DataContext as SolutionViewModel;
				if (solution == null)
				{
					// get parent solution
					solution = ViewModelHelper.FindParentView<SolutionViewModel>(this);
				}
				if (solution == null)
				{
					// invalid drop location
					HandleInvalidDrop(databaseSource);
				}
				else if (solution.SpecificationSourcesFolder.DatabaseSources.Find("Name", databaseSource.Name) != null)
				{
					// duplicate item found, cannot drop
					if (databaseSource != DataContext as DatabaseSourceViewModel)
					{
						HandleDuplicateDrop(databaseSource);
					}
				}
				else
				{
					// do the drop
					DatabaseSourceViewModel view = solution.SpecificationSourcesFolder.PasteDatabaseSource(databaseSource, true);
					view.ShowInTreeView();
				}
			}
			else if (data is AuditPropertyViewModel)
			{
				// process auditProperty drop
				auditProperty = data as AuditPropertyViewModel;
				solution = DataContext as SolutionViewModel;
				if (solution == null)
				{
					// get parent solution
					solution = ViewModelHelper.FindParentView<SolutionViewModel>(this);
				}
				if (solution == null)
				{
					// invalid drop location
					HandleInvalidDrop(auditProperty);
				}
				else if (solution.AuditPropertiesFolder.AuditProperties.Find("Name", auditProperty.Name) != null)
				{
					// duplicate item found, cannot drop
					if (auditProperty != DataContext as AuditPropertyViewModel)
					{
						HandleDuplicateDrop(auditProperty);
					}
				}
				else
				{
					// do the drop
					AuditPropertyViewModel view = solution.AuditPropertiesFolder.PasteAuditProperty(auditProperty, true);
					view.ShowInTreeView();
				}
			}
			else if (data is FeatureViewModel)
			{
				// process feature drop
				feature = data as FeatureViewModel;
				solution = DataContext as SolutionViewModel;
				if (solution == null)
				{
					// get parent solution
					solution = ViewModelHelper.FindParentView<SolutionViewModel>(this);
				}
				if (solution == null)
				{
					// invalid drop location
					HandleInvalidDrop(feature);
				}
				else if (solution.FeaturesFolder.Features.Find("Name", feature.Name) != null)
				{
					// duplicate item found, cannot drop
					if (feature != DataContext as FeatureViewModel)
					{
						HandleDuplicateDrop(feature);
					}
				}
				else
				{
					// do the drop
					Mouse.OverrideCursor = Cursors.Wait;
					FeatureViewModel view = solution.FeaturesFolder.PasteFeature(feature, true);
					view.ShowInTreeView();
					solution.Refresh(true);
					Mouse.OverrideCursor = null;
				}
			}
			else if (data is EntityViewModel)
			{
				// process entity drop
				entity = data as EntityViewModel;
				feature = DataContext as FeatureViewModel;
				if (feature == null)
				{
					// get parent feature
					feature = ViewModelHelper.FindParentView<FeatureViewModel>(this);
				}
				if (feature == null)
				{
					// invalid drop location
					HandleInvalidDrop(entity);
				}
				else if (feature.Entities.Find("Name", entity.Name) != null)
				{
					// duplicate item found, cannot drop
					if (entity != DataContext as EntityViewModel)
					{
						HandleDuplicateDrop(entity);
					}
				}
				else
				{
					// do the drop
					Mouse.OverrideCursor = Cursors.Wait;
					EntityViewModel view = feature.PasteEntity(entity, true);
					view.ShowInTreeView();
					solution = ViewModelHelper.FindParentView<SolutionViewModel>(this);
					if (solution != null)
					{
						solution.Refresh(true);
					}
					Mouse.OverrideCursor = null;
				}
			}
			else if (data is CollectionViewModel)
			{
				// process collectionProperty drop
				collectionProperty = data as CollectionViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(collectionProperty);
				}
				else if (entity.CollectionsFolder.Collections.Find("Name", collectionProperty.Name) != null)
				{
					// duplicate item found, cannot drop
					if (collectionProperty != DataContext as CollectionViewModel)
					{
						HandleDuplicateDrop(collectionProperty);
					}
				}
				else
				{
					// do the drop
					CollectionViewModel view = entity.CollectionsFolder.PasteCollection(collectionProperty, true);
					view.ShowInTreeView();
				}
			}
			else if (data is PropertyReferenceViewModel)
			{
				// process derivedProperty drop
				derivedProperty = data as PropertyReferenceViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(derivedProperty);
				}
				else if (entity.PropertyReferencesFolder.PropertyReferences.Find("Name", derivedProperty.Name) != null)
				{
					// duplicate item found, cannot drop
					if (derivedProperty != DataContext as PropertyReferenceViewModel)
					{
						HandleDuplicateDrop(derivedProperty);
					}
				}
				else
				{
					// do the drop
					PropertyReferenceViewModel view = entity.PropertyReferencesFolder.PastePropertyReference(derivedProperty, true);
					view.ShowInTreeView();
				}
			}
			else if (data is PropertyViewModel)
			{
				// process property drop
				property = data as PropertyViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(property);
				}
				else if (entity.PropertiesFolder.Properties.Find("Name", property.Name) != null)
				{
					// duplicate item found, cannot drop
					if (property != DataContext as PropertyViewModel)
					{
						HandleDuplicateDrop(property);
					}
				}
				else
				{
					// do the drop
					PropertyViewModel view = entity.PropertiesFolder.PasteProperty(property, true);
					solution = ViewModelHelper.FindParentView<SolutionViewModel>(this);
					if (solution != null)
					{
						solution.Refresh(true);
					}
					view.ShowInTreeView();
				}
			}
			else if (data is EntityReferenceViewModel)
			{
				// process referenceProperty drop
				referenceProperty = data as EntityReferenceViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(referenceProperty);
				}
				else if (entity.EntityReferencesFolder.EntityReferences.Find("Name", referenceProperty.Name) != null)
				{
					// duplicate item found, cannot drop
					if (referenceProperty != DataContext as EntityReferenceViewModel)
					{
						HandleDuplicateDrop(referenceProperty);
					}
				}
				else
				{
					// do the drop
					EntityReferenceViewModel view = entity.EntityReferencesFolder.PasteEntityReference(referenceProperty, true);
					view.ShowInTreeView();
				}
			}
			else if (data is MethodViewModel)
			{
				// process method drop
				method = data as MethodViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(method);
				}
				else if (entity.MethodsFolder.Methods.Find("Name", method.Name) != null)
				{
					// duplicate item found, cannot drop
					if (method != DataContext as MethodViewModel)
					{
						HandleDuplicateDrop(method);
					}
				}
				else
				{
					// do the drop
					MethodViewModel view = entity.MethodsFolder.PasteMethod(method, true);
					view.ShowInTreeView();
				}
			}
			else if (data is ParameterViewModel)
			{
				// process parameter drop
				parameter = data as ParameterViewModel;
				method = DataContext as MethodViewModel;
				if (method == null)
				{
					// get parent method
					method = ViewModelHelper.FindParentView<MethodViewModel>(this);
				}
				if (method == null)
				{
					// invalid drop location
					HandleInvalidDrop(parameter);
				}
				else if (method.Parameters.Find("Name", parameter.Name) != null)
				{
					// duplicate item found, cannot drop
					if (parameter != DataContext as ParameterViewModel)
					{
						HandleDuplicateDrop(parameter);
					}
				}
				else
				{
					// do the drop
					ParameterViewModel view = method.PasteParameter(parameter, true);
					view.ShowInTreeView();
				}
			}
			else if (data is IndexViewModel)
			{
				// process index drop
				index = data as IndexViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(index);
				}
				else if (entity.IndexesFolder.Indexes.Find("Name", index.Name) != null)
				{
					// duplicate item found, cannot drop
					if (index != DataContext as IndexViewModel)
					{
						HandleDuplicateDrop(index);
					}
				}
				else
				{
					// do the drop
					IndexViewModel view = entity.IndexesFolder.PasteIndex(index, true);
					view.ShowInTreeView();
				}
			}
			else if (data is IndexPropertyViewModel)
			{
				// process index drop
				indexProperty = data as IndexPropertyViewModel;
				index = DataContext as IndexViewModel;
				if (index == null)
				{
					// get parent index
					index = ViewModelHelper.FindParentView<IndexViewModel>(this);
				}
				if (index == null)
				{
					// invalid drop location
					HandleInvalidDrop(indexProperty);
				}
				else if (index.IndexProperties.Find("Name", indexProperty.Name) != null)
				{
					// duplicate item found, cannot drop
					if (indexProperty != DataContext as IndexPropertyViewModel)
					{
						HandleDuplicateDrop(indexProperty);
					}
				}
				else
				{
					// do the drop
					IndexPropertyViewModel view = index.PasteIndexProperty(indexProperty, true);
					view.ShowInTreeView();
				}
			}
			else if (data is RelationshipViewModel)
			{
				// process relationship drop
				relationship = data as RelationshipViewModel;
				entity = DataContext as EntityViewModel;
				if (entity == null)
				{
					// get parent entity
					entity = ViewModelHelper.FindParentView<EntityViewModel>(this);
				}
				if (entity == null)
				{
					// invalid drop location
					HandleInvalidDrop(relationship);
				}
				else if (entity.RelationshipsFolder.Relationships.Find("Name", relationship.Name) != null)
				{
					// duplicate item found, cannot drop
					if (relationship != DataContext as RelationshipViewModel)
					{
						HandleDuplicateDrop(relationship);
					}
				}
				else
				{
					// do the drop
					RelationshipViewModel view = entity.RelationshipsFolder.PasteRelationship(relationship, true);
					view.ShowInTreeView();
				}
			}
			else if (data is RelationshipPropertyViewModel)
			{
				// process relationshipProperty drop
				relationshipProperty = data as RelationshipPropertyViewModel;
				relationship = DataContext as RelationshipViewModel;
				if (relationship == null)
				{
					// get parent relationship
					relationship = ViewModelHelper.FindParentView<RelationshipViewModel>(this);
				}
				if (relationship == null)
				{
					// invalid drop location
					HandleInvalidDrop(relationshipProperty);
				}
				else if (relationship.RelationshipProperties.Find("Name", relationshipProperty.Name) != null)
				{
					// duplicate item found, cannot drop
					if (relationshipProperty != DataContext as RelationshipPropertyViewModel)
					{
						HandleDuplicateDrop(relationshipProperty);
					}
				}
				else
				{
					// do the drop
					RelationshipPropertyViewModel view = relationship.PasteRelationshipProperty(relationshipProperty, true);
					view.ShowInTreeView();
				}
			}
		}

		private void HandleInvalidDrop(IWorkspaceViewModel model)
		{
			model.ShowIssue(model.Name + DisplayValues.Message_DropNotAllowed);
		}

		private void HandleDuplicateDrop(IWorkspaceViewModel model)
		{
			model.ShowIssue(model.Name + DisplayValues.Message_DropDuplicate);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item is being dragged over.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty IsDragOverProperty = DependencyProperty.Register("IsDragOver", typeof(bool), typeof(ModelTreeViewItem));
		public bool IsDragOver
		{
			get
			{
				return (bool)GetValue(IsDragOverProperty);
			}
			set
			{
				SetValue(IsDragOverProperty, value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item needs focus.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty NeedsFocusProperty = DependencyProperty.Register("NeedsFocus", typeof(bool), typeof(ModelTreeViewItem));
		public bool NeedsFocus
		{
			get
			{
				return (bool)GetValue(NeedsFocusProperty);
			}
			set
			{
				SetValue(NeedsFocusProperty, value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item has customizations.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty HasCustomizationsProperty = DependencyProperty.Register("HasCustomizations", typeof(bool), typeof(ModelTreeViewItem));
		public bool HasCustomizations
		{
			get
			{
				return (bool)GetValue(HasCustomizationsProperty);
			}
			set
			{
				SetValue(HasCustomizationsProperty, value);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether the item has errors.</summary>
		///--------------------------------------------------------------------------------
		public static readonly DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors", typeof(bool), typeof(ModelTreeViewItem));
		public bool HasErrors
		{
			get
			{
				return (bool)GetValue(HasErrorsProperty);
			}
			set
			{
				SetValue(HasErrorsProperty, value);
			}
		}

		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ModelTreeViewItem();
		}

		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is ModelTreeViewItem;
		}

		public ModelTreeViewItem()
		{
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, CopyExecuted));
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, PasteExecuted));
		}

		void CopyExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			BuilderViewModel builderView = ViewModelHelper.FindParentView<BuilderViewModel>(this);
			if (builderView != null && DataContext is IWorkspaceViewModel)
			{
				builderView.PasteViewModel = DataContext as IWorkspaceViewModel;
			}
		}

		void PasteExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			BuilderViewModel builderView = ViewModelHelper.FindParentView<BuilderViewModel>(this);
			if (builderView != null)
			{
				Paste(builderView.PasteViewModel);
			}
		}
	}
}
