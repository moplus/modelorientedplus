<CONFIG>
	NAME MDLFeatureModel
	CATEGORY Feature
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create feature if it does not exist in the model
CurrentFeature = null
with (Feature from Solution.Find(FeatureName, MDLFeatureName))
{
	CurrentFeature = Feature
}
if (CurrentFeature == null)
{
	CurrentFeature = New()
	CurrentFeature.FeatureName = MDLFeatureName
	CurrentFeature.Tags = "DB"
	add(CurrentFeature)
}
%%></OUTPUT>