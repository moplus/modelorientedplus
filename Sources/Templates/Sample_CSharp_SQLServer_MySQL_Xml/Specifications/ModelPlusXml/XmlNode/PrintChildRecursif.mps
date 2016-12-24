<CONFIG>
	NAME PrintChildRecursif
	NODE XmlNode
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
<%%-
    Node : %%><%%=XmlNodeName%%><%%-, %%><%%=XmlNodeID%%>

if(XmlNode.HasChild==true)
{
    foreach(XmlNode)
    {
      <%%=PrintChildRecursif%%>
    }
}
%%></CONTENT>