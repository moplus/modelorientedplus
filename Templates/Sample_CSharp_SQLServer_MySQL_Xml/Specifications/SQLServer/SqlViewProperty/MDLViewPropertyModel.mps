<CONFIG>
	NAME MDLViewPropertyModel
	CATEGORY ViewProperty
	NODE SqlViewProperty
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create property
//
// Note that this doesn't work well since SQL SMO currently doesn't provide table name parent
// for view column.  If table can't be found from parsing view text, property is not added and
// trace message is output.
param order
CurrentViewProperty = New()
CurrentViewProperty.ViewID = CurrentView.ViewID
CurrentViewProperty.Tags = "DB"
with (Entity from Solution.Find(SourceName, ReferencedTable))
{
	with (Property from Entity.Find(PropertyName, ../ReferencedColumn))
	{
		CurrentViewProperty.PropertyID = PropertyID
	}
}
CurrentViewProperty.Order = order

// add property to model
if (CurrentViewProperty.PropertyID == null || CurrentViewProperty.PropertyID == "00000000-0000-0000-0000-000000000000")
{
	trace("Property could not be found with Referenced Table: " + ReferencedTable + ", Referenced Column: " + ReferencedColumn)
}
else
{
	add(CurrentViewProperty)
}
%%></OUTPUT>