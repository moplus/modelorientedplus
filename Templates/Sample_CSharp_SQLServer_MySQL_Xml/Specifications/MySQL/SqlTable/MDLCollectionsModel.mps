<CONFIG>
	NAME MDLCollectionsModel
	CATEGORY Entity
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
if (CurrentEntity.EntityTypeCode != 8 /* Relational */ && CurrentEntity.EntityTypeCode != 1 /* Lookup */ && CurrentEntity.EntityTypeCode != 2 /* Lookup Business */)
{
	// add collections
	foreach (Entity in Solution)
	{
		if (EntityID != CurrentEntity.EntityID && BaseEntityID != CurrentEntity.EntityID)
		{
			foreach (Relationship)
			{
				if (ReferencedEntityID == CurrentEntity.EntityID && ReferencedEntityID != EntityID)
				{
					<%%>MDLCollectionModel%%>
				}
			}
		}
	}
}
%%></OUTPUT>