<CONFIG>
	NAME LIBIsModelTable
	CATEGORY LIB
	NODE SqlTable
</CONFIG>
<CONTENT>
<%%:
if (MDLTableName.StartsWith("sys") == false)
{
	<%%-true%%>
}
else
{
	<%%-false%%>
}
%%></CONTENT>