<CONFIG>
	NAME MDLEntityExtendedModel
	CATEGORY Entity
	NODE SqlTable
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// add relationships
foreach (SqlForeignKey)
{
	<%%>MDLRelationshipModel%%>
}

// add property references
foreach (Relationship in CurrentEntity)
{
	CurrentRelationship = Relationship
	foreach (RelationshipProperty)
	{
		<%%>MDLPropertyReferenceModel%%>
	}
}

// add entity references
foreach (Relationship in CurrentEntity)
{
	<%%>MDLEntityReferenceModel%%>
}

// add methods
<%%>MDLMethodsModel%%>

%%></OUTPUT>