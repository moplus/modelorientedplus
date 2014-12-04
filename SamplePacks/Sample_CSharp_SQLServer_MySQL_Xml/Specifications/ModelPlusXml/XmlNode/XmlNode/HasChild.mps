<CONFIG>
	NAME HasChild
	NODE XmlNode
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
if(XmlNode.InnerXml.Contains("<") && XmlNode.InnerXml.Contains("</") && XmlNode.InnerXml.Contains(">") )
{
    <%%-true%%>
}
else
{
    <%%-false%%>
}
%%></CONTENT>