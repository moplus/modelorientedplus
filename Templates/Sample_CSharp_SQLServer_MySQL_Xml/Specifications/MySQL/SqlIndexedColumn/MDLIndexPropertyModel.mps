<CONFIG>
	NAME MDLIndexPropertyModel
	CATEGORY IndexProperty
	NODE SqlIndexedColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create index property
CurrentIndexProperty = New()
CurrentIndexProperty.IndexID = CurrentIndex.IndexID
CurrentIndexProperty.Order = Order
CurrentIndexProperty.Tags = "DB"

with (Entity from Solution.Find(CurrentIndex.EntityID))
{
	with (Property from Entity.Find(OriginalName, ../SqlIndexedColumnName))
	{
		CurrentIndexProperty.PropertyID = PropertyID

		// add index property to model
		add(CurrentIndexProperty)
	}
}
%%></OUTPUT>