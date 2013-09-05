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
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Diagrams;
using MoPlus.Data;
using MoPlus.ViewModel.Entities;
using MoPlus.Interpreter.BLL.Diagrams;
using MoPlus.ViewModel.Resources;
using System.Windows;
using MoPlus.Interpreter.BLL.Entities;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.ViewModel.Diagrams
{
	///--------------------------------------------------------------------------------
	/// <summary></summary>
	///
	/// This file is for adding customizations to the DiagramViewModel view
	/// (change the Status below to something other than Generated).
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>12/19/2012</CreatedDate>
	/// <Status>Customized</Status>
	///--------------------------------------------------------------------------------
	public partial class DiagramViewModel : DiagramWorkspaceViewModel
	{
		#region "Menus"
		#endregion "Menus"

		#region "Editing Support"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelRemove.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelRemove
		{
			get
			{
				return DisplayValues.ContextMenu_RemoveFromDiagram;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelNewEntity.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelNewEntity
		{
			get
			{
				return DisplayValues.ContextMenu_NewEntity;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IsDiagramEdited.</summary>
		///--------------------------------------------------------------------------------
		public bool IsDiagramEdited { get; set; }

		#endregion "Editing Support"

		#region "Command Processing"
		private RelayCommand _newEntityCommand = null;
		///--------------------------------------------------------------------------------
		/// <summary>Command to create a new entity.</summary>
		///--------------------------------------------------------------------------------
		public virtual ICommand NewEntityCommand
		{
			get
			{
				if (_newEntityCommand == null)
					_newEntityCommand = new RelayCommand(param => this.OnNewEntity());

				return _newEntityCommand;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method creates a new entity.</summary>
		///--------------------------------------------------------------------------------
		protected virtual void OnNewEntity()
		{
			Mediator.NotifyColleagues<EventArgs>(MediatorMessages.Command_ShowGettingStartedHelpRequested, null);
		}

		#endregion "Command Processing"

		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets HorizontalOffset.</summary>
		///--------------------------------------------------------------------------------
		public double HorizontalOffset { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets VerticalOffset.</summary>
		///--------------------------------------------------------------------------------
		public double VerticalOffset { get; set; }

		double _scale = 1;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Scale.</summary>
		///--------------------------------------------------------------------------------
		public double Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		private EnterpriseDataObjectList<EntityViewModel> _entities = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets Entity lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityViewModel> Entities
		{
			get
			{
				if (_entities == null)
				{
					_entities = new EnterpriseDataObjectList<EntityViewModel>();
				}
				return _entities;
			}
			set
			{
				_entities = value;
			}
		}

		private EnterpriseDataObjectList<EntityViewModel> _entitiesRemoved = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets EntitiesRemoved lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<EntityViewModel> EntitiesRemoved
		{
			get
			{
				if (_entitiesRemoved == null)
				{
					_entitiesRemoved = new EnterpriseDataObjectList<EntityViewModel>();
				}
				return _entitiesRemoved;
			}
			set
			{
				_entitiesRemoved = value;
			}
		}

		private EnterpriseDataObjectList<DiagramRelationshipViewModel> _diagramRelationships = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets DiagramRelationship lists.</summary>
		///--------------------------------------------------------------------------------
		public EnterpriseDataObjectList<DiagramRelationshipViewModel> DiagramRelationships
		{
			get
			{
				if (_diagramRelationships == null)
				{
					_diagramRelationships = new EnterpriseDataObjectList<DiagramRelationshipViewModel>();
				}
				return _diagramRelationships;
			}
			set
			{
				_diagramRelationships = value;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method loads a solution into the view model.</summary>
		/// 
		/// <param name="solution">The solution to load.</param>
		///--------------------------------------------------------------------------------
		public void LoadDiagram(Diagram solutionDiagram)
		{
			try
			{
				// attach the solution diagram
				Diagram = solutionDiagram;
				ItemID = Diagram.DiagramID;

				// attach diagram entities
				DiagramRelationships.Clear();
				DiagramEntities.Clear();
				if (Entities.Count >= 0)
				{
					IList<DiagramEntity> missingEntities = new List<DiagramEntity>();
					foreach (DiagramEntity entity in solutionDiagram.DiagramEntityList)
					{
						if (entity.Entity == null)
						{
							entity.Entity = Solution.EntityList.FindByID(entity.EntityID);
						}
						if (entity.Entity != null)
						{
							EntityViewModel entityView = Entities.Find("EntityID", entity.EntityID);
							if (entityView == null)
							{
								// entity may be removed from Entities already
								Entity foundEntity = Solution.EntityList.FindByID(entity.EntityID);
								if (foundEntity != null)
								{
									entityView = new EntityViewModel(foundEntity, Solution, true);
								}
							}
							if (entityView != null)
							{
								Point position = new Point();
								position.X = entity.PositionX;
								position.Y = entity.PositionY;
								AddEntity(entityView, position, false);
							}
							else
							{
								missingEntities.Add(entity);
							}
						}
						else
						{
							missingEntities.Add(entity);
						}
					}

					// remove missing entities
					if (missingEntities.Count > 0)
					{
						foreach (DiagramEntity entity in missingEntities)
						{
							solutionDiagram.DiagramEntityList.Remove(entity);
							Solution.ResetModified(true);
						}
						ShowIssue(DisplayValues.Issue_MissingDiagramEntities);
					}
				}

				Items.Clear();
				foreach (var item in DiagramEntities)
				{
					Items.Add(item);
				}
				foreach (var item in DiagramRelationships)
				{
					Items.Add(item);
				}
				Refresh(false);
				ResetModified(false);
			}
			catch (ApplicationException ex)
			{
				ShowException(ex);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method creates an entity and adds to the view model.</summary>
		/// 
		/// <param name="entity">The entity to add.</param>
		/// <param name="position">The desired position to place the entity.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel CreateEntity(EntityViewModel entity, Point position)
		{
			// create diagram entity and add to solution diagram
			DiagramEntity dropDiagram = new DiagramEntity();
			dropDiagram.DiagramEntityID = Guid.NewGuid();
			DiagramEntityViewModel diagramEntity = new DiagramEntityViewModel(dropDiagram, entity, this);
			diagramEntity.X = Math.Max(0, position.X);
			diagramEntity.Y = Math.Max(0, position.Y);
			diagramEntity.Width = Double.NaN;
			diagramEntity.Height = Double.NaN;
			DiagramEntities.Add(diagramEntity);
			Items.Add(diagramEntity);
			ClearSelectedItems();
			diagramEntity.IsSelected = true;
			diagramEntity.ZIndex = ++ZIndex;

			// add to diagram entites to add list
			ItemsToAdd.Add(diagramEntity);
			Refresh(false);
			return diagramEntity;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds an entity to the view model.</summary>
		/// 
		/// <param name="entity">The entity to add.</param>
		/// <param name="position">The desired position to place the entity.</param>
		///--------------------------------------------------------------------------------
		public DiagramEntityViewModel AddEntity(EntityViewModel entity, Point position, bool isNewEntity = false)
		{
			DiagramEntity dropDiagram = new DiagramEntity();
			dropDiagram.DiagramID = DiagramID;
			dropDiagram.DiagramEntityID = Guid.NewGuid();
			EntityViewModel entityView = entity;
			DiagramEntityViewModel diagramEntity = new DiagramEntityViewModel(dropDiagram, entityView, this);
			diagramEntity.X = Math.Max(0, position.X);
			diagramEntity.Y = Math.Max(0, position.Y);
			diagramEntity.Width = Double.NaN;
			diagramEntity.Height = Double.NaN;
			diagramEntity.Updated += new EventHandler(Children_Updated);
			diagramEntity.DiagramEntity.Entity = diagramEntity.EntityViewModel.Entity;
			diagramEntity.ResetModified(false);
			diagramEntity.EditDiagramEntity.ResetModified(false);
			if (isNewEntity == true)
			{
				AddDiagramEntity(diagramEntity);
			}
			else
			{
				DiagramEntities.Add(diagramEntity);
				Items.Add(diagramEntity);
			}
			ClearSelectedItems();
			diagramEntity.IsSelected = true;
			diagramEntity.ZIndex = ++ZIndex;
			Entities.Remove(entity);
			EntitiesRemoved.Add(entity);
			diagramEntity.PositionChanged += new EventHandler(diagramEntity_PositionChanged);

			AddRelationships(diagramEntity);

			return diagramEntity;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds relationships for an entity to the view model.</summary>
		/// 
		/// <param name="entity">The entity to add.</param>
		///--------------------------------------------------------------------------------
		public void AddRelationships(DiagramEntityViewModel diagramEntity)
		{
			NameObjectCollection relationshipsAdded = new NameObjectCollection();

			// add relationships this entity is the source of
			foreach (Relationship relationship in diagramEntity.EntityViewModel.Entity.RelationshipList)
			{
				bool isDeletedRelationship = false;
				foreach (DiagramRelationshipViewModel diagramRelationship in ItemsToDelete.OfType<DiagramRelationshipViewModel>())
				{
					if (diagramRelationship.RelationshipViewModel.Relationship.RelationshipID == relationship.RelationshipID)
					{
						isDeletedRelationship = true;
						break;
					}
				}
				if (isDeletedRelationship == false && relationshipsAdded[relationship.RelationshipID.ToString()] == null)
				{
					foreach (DiagramEntityViewModel loopEntity in DiagramEntities)
					{
						if (relationship.ReferencedEntityID == loopEntity.EntityViewModel.Entity.EntityID)
						{
							RelationshipViewModel relationshipViewModel = new RelationshipViewModel(relationship, Solution);
							AddRelationship(diagramEntity, loopEntity, relationshipViewModel);
							relationshipsAdded[relationship.RelationshipID.ToString()] = true;
						}
					}
				}
			}

			// add relationships this entity is the sink of
			foreach (DiagramEntityViewModel loopEntity in DiagramEntities)
			{
				foreach (Relationship relationship in loopEntity.EntityViewModel.Entity.RelationshipList)
				{
					if (relationship.ReferencedEntityID == diagramEntity.EntityViewModel.Entity.EntityID)
					{
						bool isDeletedRelationship = false;
						foreach (DiagramRelationshipViewModel diagramRelationship in ItemsToDelete.OfType<DiagramRelationshipViewModel>())
						{
							if (diagramRelationship.RelationshipViewModel.Relationship.RelationshipID == relationship.RelationshipID)
							{
								isDeletedRelationship = true;
								break;
							}
						}
						if (isDeletedRelationship == false && relationshipsAdded[relationship.RelationshipID.ToString()] == null)
						{
							RelationshipViewModel relationshipViewModel = new RelationshipViewModel(relationship, Solution);
							AddRelationship(loopEntity, diagramEntity, relationshipViewModel);
							relationshipsAdded[relationship.RelationshipID.ToString()] = true;
						}
					}
				}
			}

			Refresh(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method marks the diagram as edited when a diagram entity
		/// position changes.</summary>
		/// 
		/// <param name="sender">The sender of the collection changed event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void diagramEntity_PositionChanged(object sender, EventArgs e)
		{
			IsDiagramEdited = true;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes an entity from the view model.</summary>
		/// 
		/// <param name="diagramEntity">The diagram entity to remove.</param>
		///--------------------------------------------------------------------------------
		public void RemoveEntity(DiagramEntityViewModel diagramEntity, bool isDeleted = false)
		{
			// remove diagram entity
			DiagramEntities.Remove(diagramEntity);
			Items.Remove(diagramEntity);
			//diagramEntity.Dispose();
			ClearSelectedItems();
			if (isDeleted == false)
			{
				EntityViewModel entity = EntitiesRemoved.Find("EntityID", diagramEntity.EntityViewModel.EntityID);
				if (entity != null)
				{
					EntitiesRemoved.Remove(entity);
					Entities.Add(entity);
					Entities.Sort("DisplayName", SortDirection.Ascending);
				}
			}
			IList<DiagramRelationshipViewModel> relationshipsToRemove = new List<DiagramRelationshipViewModel>();
			foreach (DiagramRelationshipViewModel diagramRelationship in DiagramRelationships)
			{
				if (diagramRelationship.SinkDiagramEntityViewModel.EntityID == diagramEntity.EntityID || diagramRelationship.SourceDiagramEntityViewModel.EntityID == diagramEntity.EntityID)
				{
					relationshipsToRemove.Add(diagramRelationship);
				}
			}
			foreach (DiagramRelationshipViewModel diagramRelationship in relationshipsToRemove)
			{
				DiagramRelationships.Remove(diagramRelationship);
				Items.Remove(diagramRelationship);
			}
			Refresh(false);
		}


		///--------------------------------------------------------------------------------
		/// <summary>This method deletes an entity from the view model and solution.</summary>
		/// 
		/// <param name="entity">The entity to remove.</param>
		///--------------------------------------------------------------------------------
		public void DeleteEntity(DiagramEntityViewModel entity)
		{
			// remove diagram entity
			RemoveEntity(entity, true);

			// add to deleted entity list
			ItemsToDelete.Add(entity);
			Refresh(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a relationship to the view model.</summary>
		/// 
		/// <param name="relationship">The relationship to add.</param>
		///--------------------------------------------------------------------------------
		public void CreateRelationship(DiagramRelationshipViewModel relationship)
		{
			// add diagram relationship to solution diagram
			DiagramRelationships.Add(relationship);
			Items.Add(relationship);

			// add to diagram relationships to add list
			ItemsToAdd.Add(relationship);
			Refresh(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a relationship to the view model.</summary>
		/// 
		/// <param name="sourceEntity">The source entity of the relationship to add.</param>
		/// <param name="sinkEntity">The sink entity of the relationship to add.</param>
		/// <param name="entityRelationship">The associated entity relationship.</param>
		///--------------------------------------------------------------------------------
		public void AddRelationship(DiagramEntityViewModel sourceEntity, DiagramEntityViewModel sinkEntity, RelationshipViewModel entityRelationship)
		{
			// add diagram relationship to solution diagram
			DiagramRelationshipViewModel relationship = new DiagramRelationshipViewModel(sourceEntity, sinkEntity, sourceEntity.Diagram, entityRelationship);
			DiagramRelationships.Add(relationship);
			Items.Add(relationship);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a relationship to the view model.</summary>
		/// 
		/// <param name="relationship">The relationship to add.</param>
		///--------------------------------------------------------------------------------
		public void RemoveRelationship(DiagramRelationshipViewModel relationship)
		{
			// remove diagram relationship from solution diagram
			DiagramRelationships.Remove(relationship);
			Items.Remove(relationship);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a relationship to the view model.</summary>
		/// 
		/// <param name="relationship">The relationship to add.</param>
		///--------------------------------------------------------------------------------
		public void DeleteRelationship(DiagramRelationshipViewModel relationship)
		{
			// remove diagram relationship from solution diagram
			RemoveRelationship(relationship);

			// add to deleted relationship list
			ItemsToDelete.Add(relationship);
			Refresh(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes Items when the diagram entities collection changes.</summary>
		/// 
		/// <param name="sender">The sender of the collection changed event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void DiagramEntities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			IsDiagramEdited = true;
			Refresh(false);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes Items when the diagram relationships collection changes.</summary>
		/// 
		/// <param name="sender">The sender of the collection changed event.</param>
		/// <param name="e">The event arguments.</param>
		///--------------------------------------------------------------------------------
		void DiagramRelationships_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			IsDiagramEdited = true;
		}

		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>Create the instance with the designer view and other data.</summary>
		/// 
		/// <param name="solutionDiagram">The solution diagram to load.</param>
		/// <param name="entities">The solution entities that could be added to the diagram.</param>
		/// <param name="solution">The associated solution.</param>
		/// <param name="loadChildren">Flag indicating if child information should be loaded.</param>
		///--------------------------------------------------------------------------------
		public DiagramViewModel(Diagram solutionDiagram, EnterpriseDataObjectList<EntityViewModel> entities, Solution solution, bool loadChildren = true)
		{
			Entities = new EnterpriseDataObjectList<EntityViewModel>();
			if (entities != null)
			{
				foreach (EntityViewModel entity in entities)
				{
					if (loadChildren == true)
					{
						Entities.Add(new EntityViewModel(entity.Entity, solution, loadChildren));
					}
					else
					{
						Entities.Add(entity);
					}
				}
			}
			else
			{
				foreach (Entity entity in solution.EntityList)
				{
					Entities.Add(new EntityViewModel(entity, solution, loadChildren));
				}
			}
			WorkspaceID = Guid.NewGuid();
			Solution = solution;
			DiagramEntities = new EnterpriseDataObjectList<DiagramEntityViewModel>();
			DiagramRelationships = new EnterpriseDataObjectList<DiagramRelationshipViewModel>();
			LoadDiagram(solutionDiagram);
			DiagramEntities.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(DiagramEntities_CollectionChanged);
			DiagramRelationships.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(DiagramRelationships_CollectionChanged);
		}
		#endregion "Constructors"
	}
}
