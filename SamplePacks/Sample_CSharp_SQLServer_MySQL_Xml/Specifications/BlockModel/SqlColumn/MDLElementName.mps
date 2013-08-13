<CONFIG>
	NAME MDLElementName
	CATEGORY Element
	NODE SqlColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%=SqlColumnName.CapitalCase().Replace("_","").Replace(" ", "")%%></CONTENT>