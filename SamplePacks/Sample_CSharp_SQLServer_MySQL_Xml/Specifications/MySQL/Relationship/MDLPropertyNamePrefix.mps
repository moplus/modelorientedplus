<CONFIG>
	NAME MDLPropertyNamePrefix
	CATEGORY LIB
	NODE Relationship
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
var propertyPrefix
var prefix

foreach (RelationshipProperty)
{
	with (Property from Solution.Find(PropertyID))
	{
		with (Property from Solution.Find(../ReferencedPropertyID))
		{
			if (../PropertyName.EndsWith(PropertyName) == true)
			{
				prefix = ../PropertyName.Replace(PropertyName, "")
				if (prefix != null)
				{
					if (propertyPrefix == null)
					{
						propertyPrefix = prefix
					}
					else
					{
						if (propertyPrefix != prefix)
						{
							Text = ""
							return
						}
					}
				}
			}
		}
	}
}
Text = propertyPrefix
%%></CONTENT>