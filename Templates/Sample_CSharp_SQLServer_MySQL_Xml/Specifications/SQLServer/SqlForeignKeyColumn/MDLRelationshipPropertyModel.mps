<CONFIG>
	NAME MDLRelationshipPropertyModel
	CATEGORY RelationshipProperty
	NODE SqlForeignKeyColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create relationship property
CurrentRelationshipProperty = New()
CurrentRelationshipProperty.RelationshipID = CurrentRelationship.RelationshipID
CurrentRelationshipProperty.Order = Order
CurrentRelationshipProperty.Tags = "DB"

// add (source) property
with (Entity from Solution.Find(CurrentRelationship.EntityID))
{
	with (Property from Entity.Find(PropertyName, ../MDLPropertyName))
	{
		CurrentRelationshipProperty.PropertyID = PropertyID
	}
}

// add referenced (primary) property
with (Entity from Solution.Find(CurrentRelationship.ReferencedEntityID))
{
	with (Property from Entity.Find(PropertyName, ../MDLReferencedPropertyName))
	{
		CurrentRelationshipProperty.ReferencedPropertyID = PropertyID
	}
}

// add relationship property to model
add(CurrentRelationshipProperty)
%%></OUTPUT>