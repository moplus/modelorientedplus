<CONFIG>
	NAME MDLIndexModel
	CATEGORY Index
	NODE SqlIndex
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create index
CurrentIndex = New()
CurrentIndex.EntityID = CurrentEntity.EntityID
CurrentIndex.Tags = "DB"

// set basic properties
CurrentIndex.IndexName = MDLIndexName
CurrentIndex.IsUniqueIndex = IsUnique
CurrentIndex.IsPrimaryKeyIndex = IsClustered // assuming clustered index is primary key here...

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

// add index to model
add(CurrentIndex)

foreach (SqlIndexedColumn)
{
	// add index property
	<%%>MDLIndexPropertyModel%%>
}
%%></OUTPUT>