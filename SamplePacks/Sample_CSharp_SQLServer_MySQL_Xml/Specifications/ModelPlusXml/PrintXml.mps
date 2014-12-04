<CONFIG>
	NAME PrintXml
	NODE SpecificationSource
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
foreach(XmlDocument)
{
	foreach(XmlNode)
	{
		<%%=NodeInfo%%>
		foreach(XmlNode)
		{
			<%%=NodeInfo%%>
			foreach(XmlNode)
			{
				<%%=NodeInfo%%>
			}
		}
	}
    foreach(XmlNode)
    {
    <%%=PrintChildRecursif%%>
    }
}
%%></CONTENT>