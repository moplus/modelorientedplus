<CONFIG>
	NAME MDLCollectionModel
	CATEGORY Collection
	NODE Relationship
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
var entityName
CurrentRelationship = Relationship

// entity  reference should not be a self reference
if (ReferencedEntityID == CurrentEntity.EntityID && ReferencedEntityID != EntityID)
{
	with (Entity from Solution.Find(EntityID))
	{
		entityName = EntityName
		if (HasPropertyNamed(CurrentRelationship.MDLCollectionName(baseName = entityName)) == false)
		{
			// create collection and add basic information
			CurrentCollection = New()
			CurrentCollection.Tags = "DB"
			CurrentCollection.CollectionName = CurrentRelationship.MDLCollectionName(baseName = entityName)
			CurrentCollection.EntityID = CurrentEntity.EntityID
			CurrentCollection.ReferencedEntityID = EntityID
			CurrentCollection.IsNullable = CurrentRelationship.IsNullable
			CurrentCollection.Order = 400 + CurrentEntity.EntityReferenceCount
			
			add(CurrentCollection)
			
			// add property relationship
			CurrentPropertyRelationship = New()
			CurrentPropertyRelationship.RelationshipID = ../RelationshipID
			CurrentPropertyRelationship.PropertyID = CurrentCollection.PropertyID
			CurrentPropertyRelationship.Order = 1
			add(CurrentPropertyRelationship)
		}
		foreach (Entity in ExtendingEntities)
		{
			entityName = EntityName
			if (HasPropertyNamed(CurrentRelationship.MDLCollectionName(baseName = entityName)) == false)
			{
				// create collection and add basic information
				CurrentCollection = New()
				CurrentCollection.Tags = "DB"
				CurrentCollection.CollectionName = CurrentRelationship.MDLCollectionName(baseName = entityName)
				CurrentCollection.EntityID = CurrentEntity.EntityID
				CurrentCollection.ReferencedEntityID = EntityID
				CurrentCollection.IsNullable = CurrentRelationship.IsNullable
				CurrentCollection.Order = 400 + CurrentEntity.EntityReferenceCount
				
				add(CurrentCollection)
				
				// add property relationship
				CurrentPropertyRelationship = New()
				CurrentPropertyRelationship.RelationshipID = CurrentRelationship.RelationshipID
				CurrentPropertyRelationship.PropertyID = CurrentCollection.PropertyID
				CurrentPropertyRelationship.Order = 1
				add(CurrentPropertyRelationship)
			}
		}
	}
}
%%></OUTPUT>