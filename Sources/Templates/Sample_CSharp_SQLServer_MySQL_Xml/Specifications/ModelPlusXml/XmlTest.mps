<CONFIG>
	NAME XmlTest
	NODE SpecificationSource
</CONFIG>
<CONTENT>
// this is a test, going through xml nodes and attributes fg
<%%:
with (Entity from Solution.Find(EntityName, "RecentSolution"))
{
	CurrentEntity = Entity
}
<%%=CurrentEntity.EntityName%%>
<%%-
%%><%%=CurrentEntity.EntityID%%><%%-, %%><%%=CurrentFeature.FeatureID%%>
<%%-
%%><%%=CurrentEntity.EntityID%%><%%-, %%><%%=CurrentEntity.EntityName%%><%%-, %%><%%=CurrentEntity.EntityTypeCode%%>
foreach (Entity in Solution)
{
<%%-
%%><%%=EntityName%%>
}
foreach (XmlNode)
{
<%%-
Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
	foreach (XmlAttribute)
	{
	<%%-
	Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
	}
	foreach (XmlNode)
	{
	<%%-
	Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
		foreach (XmlAttribute)
		{
		<%%-
		Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
		}
		foreach (XmlNode)
		{
		<%%-
		Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
			foreach (XmlAttribute)
			{
			<%%-
			Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
			}
			foreach (XmlNode)
			{
			<%%-
			Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
				foreach (XmlAttribute)
				{
				<%%-
				Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
				}
				foreach (XmlNode)
				{
				<%%-
				Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
					foreach (XmlAttribute)
					{
					<%%-
					Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
					}
					foreach (XmlNode)
					{
					<%%-
					Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
						foreach (XmlAttribute)
						{
						<%%-
						Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
						}
					}
				}
			}
		}
	}
}
%%></CONTENT><OUTPUT>
// this is a test, going through xml nodes and attributes fg
<%%:
with (Entity from Solution.Find(EntityName, "RecentSolution"))
{
	CurrentEntity = Entity
}
<%%=CurrentEntity.EntityName%%>
CurrentEntity = New()
CurrentFeature = New()
<%%-
%%><%%=CurrentEntity.EntityID%%><%%-, %%><%%=CurrentFeature.FeatureID%%>
CurrentEntity.EntityID = CurrentFeature.FeatureID
CurrentEntity.EntityName = "Test"
CurrentEntity.EntityTypeCode = 3
<%%-
%%><%%=CurrentEntity.EntityID%%><%%-, %%><%%=CurrentEntity.EntityName%%><%%-, %%><%%=CurrentEntity.EntityTypeCode%%>
foreach (Entity in Solution)
{
<%%-
%%><%%=EntityName%%>
}
foreach (XmlNode)
{
<%%-
Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
	foreach (XmlAttribute)
	{
	<%%-
	Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
	}
	foreach (XmlNode)
	{
	<%%-
	Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
		foreach (XmlAttribute)
		{
		<%%-
		Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
		}
		foreach (XmlNode)
		{
		<%%-
		Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
			foreach (XmlAttribute)
			{
			<%%-
			Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
			}
			foreach (XmlNode)
			{
			<%%-
			Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
				foreach (XmlAttribute)
				{
				<%%-
				Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
				}
				foreach (XmlNode)
				{
				<%%-
				Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
					foreach (XmlAttribute)
					{
					<%%-
					Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
					}
					foreach (XmlNode)
					{
					<%%-
					Node:%%><%%=XmlNodeName%%><%%- - %%><%%=Value%%>
						foreach (XmlAttribute)
						{
						<%%-
						Attribute:%%><%%=XmlAttributeName%%><%%- - %%><%%=Value%%>
						}
					}
				}
			}
		}
	}
}
%%></OUTPUT>