<CONFIG>
	NAME MDLRelationshipModel
	CATEGORY Relationship
	NODE SqlForeignKey
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create relationship
CurrentSqlForeignKey = SqlForeignKey
CurrentRelationship = New()
CurrentRelationship.EntityID = CurrentEntity.EntityID
CurrentRelationship.Tags = "DB"
CurrentRelationship.ReferencedItemsMin = 1
CurrentRelationship.ReferencedItemsMax = 1
CurrentRelationship.ItemsMin = 0
CurrentRelationship.ItemsMax = -1

// set basic properties
CurrentRelationship.RelationshipName = MDLRelationshipName.Replace(".", "__DOT__")
CurrentRelationship.IsNullable = false
var foundEntity = false
var isUniqueIndex
var isPropertyFound

with (Entity from Solution.Find(SourceName, ReferencedTable))
{
	CurrentRelationship.ReferencedEntityID = Entity.EntityID
	foundEntity = true
}
if (foundEntity == false)
{
	trace("Did not find table for: " + ReferencedTable)
}

// set overrides from extended properties
foreach (SqlExtendedProperty)
{
	if (SqlExtendedPropertyName == "IndexName")
	{
		CurrentIndex.IndexName = Value
	}
	else if (SqlExtendedPropertyName == "Description")
	{
		CurrentIndex.Description = Value
	}
	else if (SqlExtendedPropertyName == "Tags")
	{
		CurrentIndex.Tags = Value
	}
}

// set relationship cardinality
foreach (SqlForeignKeyColumn)
{
	with (Property from CurrentEntity.Find(OriginalName, MDLPropertyName))
	{
		if (IsNullable == true)
		{
			CurrentRelationship.ReferencedItemsMin = 0
		}
	}
}
foreach (Index in CurrentEntity where IsUniqueIndex == true  && PropertyCount == CurrentSqlForeignKey.PropertyCount)
{
	CurrentIndex = Index
	isUniqueIndex = true
	foreach (SqlForeignKeyColumn in CurrentSqlForeignKey)
	{
		with (Property from CurrentEntity.Find(OriginalName, MDLPropertyName))
		{
			isPropertyFound = false
			foreach (IndexProperty in CurrentIndex)
			{
				if (PropertyID == ../PropertyID)
				{
					isPropertyFound = true
					break
				}
			}
			if (isPropertyFound == false)
			{
				isUniqueIndex = false
			}
		}
	}
	if (isUniqueIndex == true)
	{
		CurrentRelationship.ItemsMax = 1
	}
}

// add relationship to model
add(CurrentRelationship)

foreach (SqlForeignKeyColumn)
{
	// add relationship property
	<%%>MDLRelationshipPropertyModel%%>
}
%%></OUTPUT>