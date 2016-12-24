<CONFIG>
	NAME MDLAuditPropertiesModel
	CATEGORY AuditProperty
	NODE SpecificationSource
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
//
// this is an audit property test
//
foreach (AuditProperty in Solution)
{
	// don't recalculate audit properties if already present
 	return
}
foreach (SqlTable where LIBIsModelTable == true)
{
	CurrentSqlTable = SqlTable
	if (ItemIndex == 0)
	{
		foreach (SqlColumn)
		{
			CurrentAuditProperty = New()
			CurrentAuditProperty.PropertyName = MDLPropertyName
			if (CurrentAuditProperty.PropertyName.ToLower().Contains("creat") || CurrentAuditProperty.PropertyName.ToLower().Contains("add"))
			{
				CurrentAuditProperty.IsAddAuditProperty = true
			}
			else if (CurrentAuditProperty.PropertyName.ToLower().Contains("updat") || CurrentAuditProperty.PropertyName.ToLower().Contains("modif"))
			{
				CurrentAuditProperty.IsUpdateAuditProperty = true
			}
			CurrentAuditProperty.IsNullable = Nullable
//			CurrentAuditProperty.Count = MaximumLength
//			CurrentAuditProperty.Precision = NumericPrecision
//			CurrentAuditProperty.Scale = NumericScale
			CurrentAuditProperty.InitialValue = Default
			CurrentAuditProperty.Order = Order
			CurrentAuditProperty.DataTypeCode = MDLDataTypeCode
			if (CurrentAuditProperty.DataTypeCode == 24 /* DateTime */)
			{
				CurrentAuditProperty.IsValueGenerated = true
			}
			if (CurrentAuditProperty.DataTypeCode == 25 /* Timestamp */)
			{
				CurrentAuditProperty.IsAddAuditProperty = true
				CurrentAuditProperty.IsUpdateAuditProperty = true
				CurrentAuditProperty.IsValueGenerated = true
			}
			//trace("Adding audit property: " + SqlTable.SqlTableName + " " + CurrentAuditProperty.PropertyName)
			log("MDLAuditPropertiesModel", "PropertyFound", false)
			with (AuditProperty from Solution.Find(PropertyName, CurrentAuditProperty.PropertyName))
			{
				log("MDLAuditPropertiesModel", "PropertyFound", true)
			}
			if (LogValue("MDLAuditPropertiesModel", "PropertyFound") == false)
			{
	//			 trace("Adding audit property: " + CurrentAuditProperty.PropertyName)
				add (CurrentAuditProperty)
			}
		}
	}
	else
	{
		log("MDLAuditPropertiesModel", "AuditPropertyFound", true)
		while (LogValue("MDLAuditPropertiesModel", "AuditPropertyFound") == true)
		{
			log("MDLAuditPropertiesModel", "AuditPropertyFound", false)
			CurrentAuditProperty = null
			foreach (AuditProperty in Solution)
			{
				CurrentAuditProperty = AuditProperty
			//	trace("SqlTable is: " + CurrentSqlTable.SqlTableName)
				foreach (SqlColumn in CurrentSqlTable)
				{
					if (SqlColumnName == CurrentAuditProperty.PropertyName)
					{
						//trace("Found: " + CurrentSqlTable.SqlTableName + " " + CurrentAuditProperty.PropertyName)
						CurrentAuditProperty = null
						break
					}
				}
				// TODO: investigate why using with statement below doesn't always work
				/*with (SqlColumn from CurrentSqlTable.Find(SqlColumnName, CurrentAuditProperty.PropertyName))
				{
					trace("Found: " + CurrentSqlTable.SqlTableName + " " + CurrentAuditProperty.PropertyName)
					CurrentAuditProperty = null
				}*/
				if (CurrentAuditProperty != null)
				{
					break
				}
			}
			if (CurrentAuditProperty != null)
			{
				//trace("Removing audit property: " + CurrentSqlTable.SqlTableName + " " + CurrentAuditProperty.PropertyName)
	//			 trace("Removing audit property: " + CurrentAuditProperty.PropertyName)
				delete(CurrentAuditProperty)
				log("MDLAuditPropertiesModel", "AuditPropertyFound", true)
			}
		}
	}
}
%%></OUTPUT>