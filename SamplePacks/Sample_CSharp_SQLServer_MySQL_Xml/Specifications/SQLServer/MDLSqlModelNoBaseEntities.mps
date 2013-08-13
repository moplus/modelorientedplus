<CONFIG>
	NAME MDLSqlModelNoBaseEntities
	NODE SpecificationSource
	TOPLEVEL True
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
progress(SqlDatabase.SqlTableCount * 5)
foreach(SqlTable where LIBIsModelTable == true)
{
	// create/update feature
	<%%>MDLFeatureModel%%>
	progress
}
foreach(SqlTable where LIBIsModelTable == true)
{
	// create/update basic entity
	<%%>MDLEntityCoreModel%%>
	progress
}

log("MDLSqlModel", "EntityProcessed", true)
while(LogValue("MDLSqlModel", "EntityProcessed") == true)
{
	log("MDLSqlModel", "EntityProcessed", false)
	foreach(SqlTable where LIBIsModelTable == true)
	{
		CurrentEntity = null
		with (Entity from Solution.Find(SourceName, SqlTableName))
		{
			CurrentEntity = Entity
		}
		if (CurrentEntity == null)
		{
			trace("Couldn't find Entity for: " + SqlTableName)
		}
		if (CurrentEntity != null && LogValue("MDLSqlModel", CurrentEntity.EntityID) != true && (CurrentEntity.BaseEntityID == null || LogValue("MDLSqlModel", CurrentEntity.BaseEntityID) == true))
		{
			log("MDLSqlModel", "EntityProcessed", true)
			log("MDLSqlModel", CurrentEntity.EntityID, true)
	
			// create extended entity information
			<%%>MDLEntityExtendedModel%%>
			progress
		}
	}
}

log("MDLSqlModel", "EntityProcessed", true)
while(LogValue("MDLSqlModel", "EntityProcessed") == true)
{
	log("MDLSqlModel", "EntityProcessed", false)
	foreach(SqlTable where LIBIsModelTable == true)
	{
		CurrentEntity = null
		with (Entity from Solution.Find(SourceName, SqlTableName))
		{
			CurrentEntity = Entity
		}
		if (CurrentEntity != null && LogValue("MDLSqlModel2", CurrentEntity.EntityID) != true && (CurrentEntity.BaseEntityID == null || LogValue("MDLSqlModel2", CurrentEntity.BaseEntityID) == true))
		{
			log("MDLSqlModel", "EntityProcessed", true)
			log("MDLSqlModel2", CurrentEntity.EntityID, true)
	
			// create entity collection information
			<%%>MDLCollectionsModel%%>
			progress
		}
	}
}
%%></OUTPUT>