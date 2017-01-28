<CONFIG>
	NAME MDLViewModel
	CATEGORY View
	NODE SqlView
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
	CurrentView = New()
	CurrentView.SourceName = SqlViewName
	CurrentView.ViewName = SqlViewName
	CurrentView.Tags = "DB"
	
	// add view to model
	add(CurrentView)
	
	// add properties
	var order = 0
	foreach (SqlViewProperty)
	{
		order = order + 1
		<%%>MDLViewPropertyModel(order=order)%%>
	}
%%></OUTPUT>