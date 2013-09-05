/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Based on code written by Marlon Grech and Josh Smith, available at the MVVM Foundation (http://mvvmfoundation.codeplex.com/)
</copyright>*/

namespace MoPlus.ViewModel.Messaging
{
	///--------------------------------------------------------------------------------
	/// <summary>For use in passing messages using the Mediator.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/2/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public static class MediatorMessages
	{
		// general item messages
		#region protected
		public const string Command_ShowItemRequested = "Command_ShowItemRequested";
		public const string Command_ShowItem = "Command_ShowItem";
		public const string Command_ShowHelpRequested = "Command_ShowHelpRequested";
		public const string Command_CloseItemRequested = "Command_CloseItemRequested";
		public const string Command_CloseSolutionItemsRequested = "Command_CloseSolutionItemsRequested";
		public const string Command_RefreshSolutionRequested = "Command_RefreshSolutionRequested";
		public const string Command_RefreshSpecTemplatesRequested = "Command_RefreshSpecTemplatesRequested";
		public const string Command_RefreshCodeTemplatesRequested = "Command_RefreshCodeTemplatesRequested";
		public const string Command_SolutionEditItemCount = "Command_SolutionEditItemCount";
		public const string Command_CompileSolutionRequested = "Command_CompileSolutionRequested";
		public const string Command_UpdateSolutionRequested = "Command_UpdateSolutionRequested";
		public const string Command_OpenSolutionRequested = "Command_OpenSolutionRequested";
		public const string Command_SaveAllSolutionsRequested = "Command_SaveAllSolutionsRequested";
		public const string Command_ManageItemRequested = "Command_ManageItemRequested";
		public const string Command_BreakpointReached = "Command_BreakpointReached";
		public const string Command_DebugFinished = "Command_DebugFinished";
		public const string Command_ShowGettingStartedHelpRequested = "Command_ShowGettingStartedHelpRequested";
		public const string Command_ShowAboutHelpRequested = "Command_ShowAboutHelpRequested";
		#endregion protected
		
		// AuditProperty edit related messages
		public const string Command_EditAuditPropertyRequested = "Command_EditAuditPropertyRequested";
		public const string Command_DeleteAuditPropertyRequested = "Command_DeleteAuditPropertyRequested";
		public const string Command_EditAuditPropertyPerformed = "Command_EditAuditPropertyPerformed";
		
		// CodeTemplate edit related messages
		public const string Command_EditCodeTemplateRequested = "Command_EditCodeTemplateRequested";
		public const string Command_DeleteCodeTemplateRequested = "Command_DeleteCodeTemplateRequested";
		public const string Command_EditCodeTemplatePerformed = "Command_EditCodeTemplatePerformed";
		
		// Collection edit related messages
		public const string Command_EditCollectionRequested = "Command_EditCollectionRequested";
		public const string Command_DeleteCollectionRequested = "Command_DeleteCollectionRequested";
		public const string Command_EditCollectionPerformed = "Command_EditCollectionPerformed";
		
		// DatabaseSource edit related messages
		public const string Command_EditDatabaseSourceRequested = "Command_EditDatabaseSourceRequested";
		public const string Command_DeleteDatabaseSourceRequested = "Command_DeleteDatabaseSourceRequested";
		public const string Command_EditDatabaseSourcePerformed = "Command_EditDatabaseSourcePerformed";
		
		// DebugItem edit related messages
		public const string Command_EditDebugItemRequested = "Command_EditDebugItemRequested";
		public const string Command_DeleteDebugItemRequested = "Command_DeleteDebugItemRequested";
		public const string Command_EditDebugItemPerformed = "Command_EditDebugItemPerformed";
		
		// Diagram edit related messages
		public const string Command_EditDiagramRequested = "Command_EditDiagramRequested";
		public const string Command_DeleteDiagramRequested = "Command_DeleteDiagramRequested";
		public const string Command_EditDiagramPerformed = "Command_EditDiagramPerformed";
		
		// DiagramEntity edit related messages
		public const string Command_EditDiagramEntityRequested = "Command_EditDiagramEntityRequested";
		public const string Command_DeleteDiagramEntityRequested = "Command_DeleteDiagramEntityRequested";
		public const string Command_EditDiagramEntityPerformed = "Command_EditDiagramEntityPerformed";
		
		// Entity edit related messages
		public const string Command_EditEntityRequested = "Command_EditEntityRequested";
		public const string Command_DeleteEntityRequested = "Command_DeleteEntityRequested";
		public const string Command_EditEntityPerformed = "Command_EditEntityPerformed";
		
		// EntityReference edit related messages
		public const string Command_EditEntityReferenceRequested = "Command_EditEntityReferenceRequested";
		public const string Command_DeleteEntityReferenceRequested = "Command_DeleteEntityReferenceRequested";
		public const string Command_EditEntityReferencePerformed = "Command_EditEntityReferencePerformed";
		
		// Enumeration edit related messages
		public const string Command_EditEnumerationRequested = "Command_EditEnumerationRequested";
		public const string Command_DeleteEnumerationRequested = "Command_DeleteEnumerationRequested";
		public const string Command_EditEnumerationPerformed = "Command_EditEnumerationPerformed";
		
		// Feature edit related messages
		public const string Command_EditFeatureRequested = "Command_EditFeatureRequested";
		public const string Command_DeleteFeatureRequested = "Command_DeleteFeatureRequested";
		public const string Command_EditFeaturePerformed = "Command_EditFeaturePerformed";
		
		// Index edit related messages
		public const string Command_EditIndexRequested = "Command_EditIndexRequested";
		public const string Command_DeleteIndexRequested = "Command_DeleteIndexRequested";
		public const string Command_EditIndexPerformed = "Command_EditIndexPerformed";
		
		// IndexProperty edit related messages
		public const string Command_EditIndexPropertyRequested = "Command_EditIndexPropertyRequested";
		public const string Command_DeleteIndexPropertyRequested = "Command_DeleteIndexPropertyRequested";
		public const string Command_EditIndexPropertyPerformed = "Command_EditIndexPropertyPerformed";
		
		// Method edit related messages
		public const string Command_EditMethodRequested = "Command_EditMethodRequested";
		public const string Command_DeleteMethodRequested = "Command_DeleteMethodRequested";
		public const string Command_EditMethodPerformed = "Command_EditMethodPerformed";
		
		// MethodRelationship edit related messages
		public const string Command_EditMethodRelationshipRequested = "Command_EditMethodRelationshipRequested";
		public const string Command_DeleteMethodRelationshipRequested = "Command_DeleteMethodRelationshipRequested";
		public const string Command_EditMethodRelationshipPerformed = "Command_EditMethodRelationshipPerformed";
		
		// Model edit related messages
		public const string Command_EditModelRequested = "Command_EditModelRequested";
		public const string Command_DeleteModelRequested = "Command_DeleteModelRequested";
		public const string Command_EditModelPerformed = "Command_EditModelPerformed";
		
		// ModelObject edit related messages
		public const string Command_EditModelObjectRequested = "Command_EditModelObjectRequested";
		public const string Command_DeleteModelObjectRequested = "Command_DeleteModelObjectRequested";
		public const string Command_EditModelObjectPerformed = "Command_EditModelObjectPerformed";
		
		// ModelProperty edit related messages
		public const string Command_EditModelPropertyRequested = "Command_EditModelPropertyRequested";
		public const string Command_DeleteModelPropertyRequested = "Command_DeleteModelPropertyRequested";
		public const string Command_EditModelPropertyPerformed = "Command_EditModelPropertyPerformed";
		
		// ObjectInstance edit related messages
		public const string Command_EditObjectInstanceRequested = "Command_EditObjectInstanceRequested";
		public const string Command_DeleteObjectInstanceRequested = "Command_DeleteObjectInstanceRequested";
		public const string Command_EditObjectInstancePerformed = "Command_EditObjectInstancePerformed";
		
		// Parameter edit related messages
		public const string Command_EditParameterRequested = "Command_EditParameterRequested";
		public const string Command_DeleteParameterRequested = "Command_DeleteParameterRequested";
		public const string Command_EditParameterPerformed = "Command_EditParameterPerformed";
		
		// Project edit related messages
		public const string Command_EditProjectRequested = "Command_EditProjectRequested";
		public const string Command_DeleteProjectRequested = "Command_DeleteProjectRequested";
		public const string Command_EditProjectPerformed = "Command_EditProjectPerformed";
		
		// Property edit related messages
		public const string Command_EditPropertyRequested = "Command_EditPropertyRequested";
		public const string Command_DeletePropertyRequested = "Command_DeletePropertyRequested";
		public const string Command_EditPropertyPerformed = "Command_EditPropertyPerformed";
		
		// PropertyBase edit related messages
		public const string Command_EditPropertyBaseRequested = "Command_EditPropertyBaseRequested";
		public const string Command_DeletePropertyBaseRequested = "Command_DeletePropertyBaseRequested";
		public const string Command_EditPropertyBasePerformed = "Command_EditPropertyBasePerformed";
		
		// PropertyInstance edit related messages
		public const string Command_EditPropertyInstanceRequested = "Command_EditPropertyInstanceRequested";
		public const string Command_DeletePropertyInstanceRequested = "Command_DeletePropertyInstanceRequested";
		public const string Command_EditPropertyInstancePerformed = "Command_EditPropertyInstancePerformed";
		
		// PropertyReference edit related messages
		public const string Command_EditPropertyReferenceRequested = "Command_EditPropertyReferenceRequested";
		public const string Command_DeletePropertyReferenceRequested = "Command_DeletePropertyReferenceRequested";
		public const string Command_EditPropertyReferencePerformed = "Command_EditPropertyReferencePerformed";
		
		// PropertyRelationship edit related messages
		public const string Command_EditPropertyRelationshipRequested = "Command_EditPropertyRelationshipRequested";
		public const string Command_DeletePropertyRelationshipRequested = "Command_DeletePropertyRelationshipRequested";
		public const string Command_EditPropertyRelationshipPerformed = "Command_EditPropertyRelationshipPerformed";
		
		// RecentSolution edit related messages
		public const string Command_EditRecentSolutionRequested = "Command_EditRecentSolutionRequested";
		public const string Command_DeleteRecentSolutionRequested = "Command_DeleteRecentSolutionRequested";
		public const string Command_EditRecentSolutionPerformed = "Command_EditRecentSolutionPerformed";
		
		// Relationship edit related messages
		public const string Command_EditRelationshipRequested = "Command_EditRelationshipRequested";
		public const string Command_DeleteRelationshipRequested = "Command_DeleteRelationshipRequested";
		public const string Command_EditRelationshipPerformed = "Command_EditRelationshipPerformed";
		
		// RelationshipProperty edit related messages
		public const string Command_EditRelationshipPropertyRequested = "Command_EditRelationshipPropertyRequested";
		public const string Command_DeleteRelationshipPropertyRequested = "Command_DeleteRelationshipPropertyRequested";
		public const string Command_EditRelationshipPropertyPerformed = "Command_EditRelationshipPropertyPerformed";
		
		// Solution edit related messages
		public const string Command_EditSolutionRequested = "Command_EditSolutionRequested";
		public const string Command_DeleteSolutionRequested = "Command_DeleteSolutionRequested";
		public const string Command_EditSolutionPerformed = "Command_EditSolutionPerformed";
		
		// SpecificationSource edit related messages
		public const string Command_EditSpecificationSourceRequested = "Command_EditSpecificationSourceRequested";
		public const string Command_DeleteSpecificationSourceRequested = "Command_DeleteSpecificationSourceRequested";
		public const string Command_EditSpecificationSourcePerformed = "Command_EditSpecificationSourcePerformed";
		
		// SpecTemplate edit related messages
		public const string Command_EditSpecTemplateRequested = "Command_EditSpecTemplateRequested";
		public const string Command_DeleteSpecTemplateRequested = "Command_DeleteSpecTemplateRequested";
		public const string Command_EditSpecTemplatePerformed = "Command_EditSpecTemplatePerformed";
		
		// SqlColumn edit related messages
		public const string Command_EditSqlColumnRequested = "Command_EditSqlColumnRequested";
		public const string Command_DeleteSqlColumnRequested = "Command_DeleteSqlColumnRequested";
		public const string Command_EditSqlColumnPerformed = "Command_EditSqlColumnPerformed";
		
		// SqlDatabase edit related messages
		public const string Command_EditSqlDatabaseRequested = "Command_EditSqlDatabaseRequested";
		public const string Command_DeleteSqlDatabaseRequested = "Command_DeleteSqlDatabaseRequested";
		public const string Command_EditSqlDatabasePerformed = "Command_EditSqlDatabasePerformed";
		
		// SqlExtendedProperty edit related messages
		public const string Command_EditSqlExtendedPropertyRequested = "Command_EditSqlExtendedPropertyRequested";
		public const string Command_DeleteSqlExtendedPropertyRequested = "Command_DeleteSqlExtendedPropertyRequested";
		public const string Command_EditSqlExtendedPropertyPerformed = "Command_EditSqlExtendedPropertyPerformed";
		
		// SqlForeignKey edit related messages
		public const string Command_EditSqlForeignKeyRequested = "Command_EditSqlForeignKeyRequested";
		public const string Command_DeleteSqlForeignKeyRequested = "Command_DeleteSqlForeignKeyRequested";
		public const string Command_EditSqlForeignKeyPerformed = "Command_EditSqlForeignKeyPerformed";
		
		// SqlForeignKeyColumn edit related messages
		public const string Command_EditSqlForeignKeyColumnRequested = "Command_EditSqlForeignKeyColumnRequested";
		public const string Command_DeleteSqlForeignKeyColumnRequested = "Command_DeleteSqlForeignKeyColumnRequested";
		public const string Command_EditSqlForeignKeyColumnPerformed = "Command_EditSqlForeignKeyColumnPerformed";
		
		// SqlIndex edit related messages
		public const string Command_EditSqlIndexRequested = "Command_EditSqlIndexRequested";
		public const string Command_DeleteSqlIndexRequested = "Command_DeleteSqlIndexRequested";
		public const string Command_EditSqlIndexPerformed = "Command_EditSqlIndexPerformed";
		
		// SqlIndexedColumn edit related messages
		public const string Command_EditSqlIndexedColumnRequested = "Command_EditSqlIndexedColumnRequested";
		public const string Command_DeleteSqlIndexedColumnRequested = "Command_DeleteSqlIndexedColumnRequested";
		public const string Command_EditSqlIndexedColumnPerformed = "Command_EditSqlIndexedColumnPerformed";
		
		// SqlProperty edit related messages
		public const string Command_EditSqlPropertyRequested = "Command_EditSqlPropertyRequested";
		public const string Command_DeleteSqlPropertyRequested = "Command_DeleteSqlPropertyRequested";
		public const string Command_EditSqlPropertyPerformed = "Command_EditSqlPropertyPerformed";
		
		// SqlTable edit related messages
		public const string Command_EditSqlTableRequested = "Command_EditSqlTableRequested";
		public const string Command_DeleteSqlTableRequested = "Command_DeleteSqlTableRequested";
		public const string Command_EditSqlTablePerformed = "Command_EditSqlTablePerformed";
		
		// Stage edit related messages
		public const string Command_EditStageRequested = "Command_EditStageRequested";
		public const string Command_DeleteStageRequested = "Command_DeleteStageRequested";
		public const string Command_EditStagePerformed = "Command_EditStagePerformed";
		
		// StageTransition edit related messages
		public const string Command_EditStageTransitionRequested = "Command_EditStageTransitionRequested";
		public const string Command_DeleteStageTransitionRequested = "Command_DeleteStageTransitionRequested";
		public const string Command_EditStageTransitionPerformed = "Command_EditStageTransitionPerformed";
		
		// State edit related messages
		public const string Command_EditStateRequested = "Command_EditStateRequested";
		public const string Command_DeleteStateRequested = "Command_DeleteStateRequested";
		public const string Command_EditStatePerformed = "Command_EditStatePerformed";
		
		// StateModel edit related messages
		public const string Command_EditStateModelRequested = "Command_EditStateModelRequested";
		public const string Command_DeleteStateModelRequested = "Command_DeleteStateModelRequested";
		public const string Command_EditStateModelPerformed = "Command_EditStateModelPerformed";
		
		// StateTransition edit related messages
		public const string Command_EditStateTransitionRequested = "Command_EditStateTransitionRequested";
		public const string Command_DeleteStateTransitionRequested = "Command_DeleteStateTransitionRequested";
		public const string Command_EditStateTransitionPerformed = "Command_EditStateTransitionPerformed";
		
		// Step edit related messages
		public const string Command_EditStepRequested = "Command_EditStepRequested";
		public const string Command_DeleteStepRequested = "Command_DeleteStepRequested";
		public const string Command_EditStepPerformed = "Command_EditStepPerformed";
		
		// StepTransition edit related messages
		public const string Command_EditStepTransitionRequested = "Command_EditStepTransitionRequested";
		public const string Command_DeleteStepTransitionRequested = "Command_DeleteStepTransitionRequested";
		public const string Command_EditStepTransitionPerformed = "Command_EditStepTransitionPerformed";
		
		// Tag edit related messages
		public const string Command_EditTagRequested = "Command_EditTagRequested";
		public const string Command_DeleteTagRequested = "Command_DeleteTagRequested";
		public const string Command_EditTagPerformed = "Command_EditTagPerformed";
		
		// Template edit related messages
		public const string Command_EditTemplateRequested = "Command_EditTemplateRequested";
		public const string Command_DeleteTemplateRequested = "Command_DeleteTemplateRequested";
		public const string Command_EditTemplatePerformed = "Command_EditTemplatePerformed";
		
		// Value edit related messages
		public const string Command_EditValueRequested = "Command_EditValueRequested";
		public const string Command_DeleteValueRequested = "Command_DeleteValueRequested";
		public const string Command_EditValuePerformed = "Command_EditValuePerformed";
		
		// Workflow edit related messages
		public const string Command_EditWorkflowRequested = "Command_EditWorkflowRequested";
		public const string Command_DeleteWorkflowRequested = "Command_DeleteWorkflowRequested";
		public const string Command_EditWorkflowPerformed = "Command_EditWorkflowPerformed";
		
		// XmlAttribute edit related messages
		public const string Command_EditXmlAttributeRequested = "Command_EditXmlAttributeRequested";
		public const string Command_DeleteXmlAttributeRequested = "Command_DeleteXmlAttributeRequested";
		public const string Command_EditXmlAttributePerformed = "Command_EditXmlAttributePerformed";
		
		// XmlDocument edit related messages
		public const string Command_EditXmlDocumentRequested = "Command_EditXmlDocumentRequested";
		public const string Command_DeleteXmlDocumentRequested = "Command_DeleteXmlDocumentRequested";
		public const string Command_EditXmlDocumentPerformed = "Command_EditXmlDocumentPerformed";
		
		// XmlNode edit related messages
		public const string Command_EditXmlNodeRequested = "Command_EditXmlNodeRequested";
		public const string Command_DeleteXmlNodeRequested = "Command_DeleteXmlNodeRequested";
		public const string Command_EditXmlNodePerformed = "Command_EditXmlNodePerformed";
		
		// XmlSource edit related messages
		public const string Command_EditXmlSourceRequested = "Command_EditXmlSourceRequested";
		public const string Command_DeleteXmlSourceRequested = "Command_DeleteXmlSourceRequested";
		public const string Command_EditXmlSourcePerformed = "Command_EditXmlSourcePerformed";

		// event related messages
		public const string Event_StatusChanged = "Event_StatusChanged";
		public const string Event_OutputChanged = "Event_OutputChanged";
		public const string Event_ProgressChanged = "Event_ProgressChanged";
	}
}
