<CONFIG>
	NAME MDLPropertyReferenceModel
	CATEGORY PropertyReference
	NODE RelationshipProperty
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
CurrentRelationshipProperty = RelationshipProperty

// property reference should not be a self reference
if (ReferencedEntityID != CurrentEntity.EntityID && ReferencedEntityID != CurrentEntity.BaseEntityID)
{
	with (Entity from Solution.Find(ReferencedEntityID))
	{
		foreach (Property)
		{
			if (LIBIsCandidatePropertyReference == true)
			{
				// create property reference and add basic information
				CurrentPropertyReference = New()
				CurrentPropertyReference.Tags = "DB"
				with (CurrentRelationshipProperty)
				{
					CurrentPropertyReference.PropertyReferenceName = MDLPropertyReferenceName(baseName = ../PropertyName)
				}
				CurrentPropertyReference.EntityID = CurrentEntity.EntityID
				CurrentPropertyReference.ReferencedEntityID = ../EntityID
				CurrentPropertyReference.ReferencedPropertyID = PropertyID
				CurrentPropertyReference.Order = 200 + CurrentEntity.PropertyReferenceCount
				CurrentPropertyReference.IsNullable = IsNullable
				
				// set overrides from extended properties
				foreach (SqlExtendedProperty)
				{
					if (SqlExtendedPropertyName == "PropertyName")
					{
						CurrentPropertyReference.PropertyName = Value
					}
					else if (SqlExtendedPropertyName == "Order")
					{
						CurrentPropertyReference.Order = Value
					}
					else if (SqlExtendedPropertyName == "Description")
					{
						CurrentPropertyReference.Description = Value
					}
					else if (SqlExtendedPropertyName == "Tags")
					{
						CurrentPropertyReference.Tags = Value
					}
				}
				
				if (CurrentEntity.HasPropertyNamed(CurrentPropertyReference.PropertyReferenceName) == false)
				{
					add(CurrentPropertyReference)
				
					// add property relationship
					CurrentPropertyRelationship = New()
					CurrentPropertyRelationship.RelationshipID = CurrentRelationship.RelationshipID
					CurrentPropertyRelationship.PropertyID = CurrentPropertyReference.PropertyID
					CurrentPropertyRelationship.Order = 1
					add(CurrentPropertyRelationship)
				}
			}
		}
	}
}
%%></OUTPUT>