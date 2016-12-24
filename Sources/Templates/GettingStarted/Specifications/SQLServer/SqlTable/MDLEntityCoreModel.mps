<CONFIG>
	NAME MDLEntityCoreModel
	CATEGORY Entity
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
if (LIBIsModelTable == true)
{
	CurrentEntity = New()
	CurrentEntity.SourceName = SqlTableName
	CurrentEntity.EntityName = MDLEntityName
	CurrentEntity.Tags = "DB"
	
	// set feature
	with (Feature from Solution.Find(FeatureName, MDLFeatureName))
	{
		CurrentEntity.FeatureID = Feature.FeatureID
	}
	
	// set identifier type
	if (PrimaryKeyColumnCount == 1 && PrimaryAndForeignKeyColumnCount == 1)
	{
		CurrentEntity.IdentifierTypeCode = 3 // ForeignKey
	}
	else if (PrimaryKeyColumnCount > 1)
	{
		CurrentEntity.IdentifierTypeCode = 4 // MultipleColumn
	}
	else
	{
		foreach (SqlColumn where InPrimaryKey == true limit 1)
		{
			if (Identity == true || DataType == "uniqueidentifier")
			{
				CurrentEntity.IdentifierTypeCode = 1 // Generated
			}
			else
			{
				CurrentEntity.IdentifierTypeCode = 2 // Coded
			}
		}
	}
	
	// set entity type
	if (PrimaryAndForeignKeyColumnCount > 1)
	{
		// relational entity
		CurrentEntity.EntityTypeCode = 8 // Relational
	}
	else if (MDLTableName.EndsWith("Log") == true || MDLTableName.EndsWith("History") == true)
	{
		// primary logging entity
		CurrentEntity.EntityTypeCode = 6 // PrimaryLogging
	}
	else
	{
		// check identifier type for special primary entity types
		switch (CurrentEntity.IdentifierTypeCode)
		{
			case 2: // Coded
				CurrentEntity.EntityTypeCode = 4 // PrimaryCoded
				break
			default:
				CurrentEntity.EntityTypeCode = 3 // Primary
				break
		}
	}
	
	// set overrides from extended properties
	foreach (SqlExtendedProperty)
	{
		if (SqlExtendedPropertyName == "FeatureName")
		{
			with (Feature from Solution.Find(FeatureName, SqlValue))
			{
				CurrentEntity.FeatureID = Feature.FeatureID
			}
		}
		else if (SqlExtendedPropertyName == "EntityTypeCode")
		{
			CurrentEntity.EntityTypeCode = SqlValue
		}
		else if (SqlExtendedPropertyName == "IdentifierTypeCode")
		{
			CurrentEntity.IdentifierTypeCode = SqlValue
		}
		else if (SqlExtendedPropertyName == "Description")
		{
			CurrentEntity.Description = SqlValue
		}
		else if (SqlExtendedPropertyName == "Tags")
		{
			CurrentEntity.Tags = SqlValue
		}
	}

	// add entity to model
	add(CurrentEntity)
	
	// add properties
	foreach (SqlColumn)
	{
		<%%>MDLPropertyModel%%>
	}
}
%%></OUTPUT>