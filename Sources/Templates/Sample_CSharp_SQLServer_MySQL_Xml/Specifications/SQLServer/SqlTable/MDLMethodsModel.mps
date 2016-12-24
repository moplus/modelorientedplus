<CONFIG>
	NAME MDLMethodsModel
	CATEGORY Method
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
var hasNonPrimaryKeyParameter
var hasPrimaryKeyMembers

// add GetOneMethods
foreach (Index in CurrentEntity where IsUniqueIndex == true)
{
	CurrentMethod = New()
	CurrentMethod.MethodTypeCode = 1 // GetOne
	CurrentMethod.EntityID = CurrentEntity.EntityID
	CurrentMethod.MethodName = "GetOne" + CurrentEntity.EntityName
	hasNonPrimaryKeyParameter = false
	foreach (IndexProperty)
	{
		with (Property from CurrentEntity.Find(PropertyID))
		{
			if (IsPrimaryKeyMember == false)
			{
				hasNonPrimaryKeyParameter = true
			}
		}
	}
	
	// update method name based on parameters
	if (hasNonPrimaryKeyParameter== true)
	{
		CurrentMethod.MethodName = CurrentMethod.MethodName + "By"
		foreach (IndexProperty)
		{
			if (ItemIndex > 0)
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + "And"
			}
			with (Property from CurrentEntity.Find(PropertyID))
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + PropertyName
			}
		}
	}
	
	// add basic method
	add(CurrentMethod)
	
	// add parameters
	foreach (IndexProperty)
	{
		with (Property from CurrentEntity.Find(PropertyID))
		{
			CurrentParameter = New()
			CurrentParameter.MethodID = CurrentMethod.MethodID
			CurrentParameter.Order = CurrentMethod.ParameterCount + 1
			CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
			CurrentParameter.ReferencedPropertyID = PropertyID
			CurrentParameter.ParameterName = PropertyName
			add(CurrentParameter)
		}
	}
}

// add AddOne method
CurrentMethod = New()
CurrentMethod.MethodTypeCode = 8 // AddOne
CurrentMethod.EntityID = CurrentEntity.EntityID
CurrentMethod.MethodName = "AddOne" + CurrentEntity.EntityName
add(CurrentMethod)

// add UpdateOne method
CurrentMethod = New()
CurrentMethod.MethodTypeCode = 9 // UpdateOne
CurrentMethod.EntityID = CurrentEntity.EntityID
CurrentMethod.MethodName = "UpdateOne" + CurrentEntity.EntityName
add(CurrentMethod)

// add DeleteOne method
CurrentMethod = New()
CurrentMethod.MethodTypeCode = 10 // DeleteOne
CurrentMethod.EntityID = CurrentEntity.EntityID
CurrentMethod.MethodName = "DeleteOne" + CurrentEntity.EntityName
add(CurrentMethod)

// add DeleteAllBy, GetAllBy, and GetManyBy foreign key methods
foreach (Relationship in CurrentEntity)
{
	// make sure the relationship does not include primary key members
	hasPrimaryKeyMembers = false
	foreach (RelationshipProperty)
	{
		with (Property from Solution.Find(PropertyID))
		{
			if (IsPrimaryKeyMember == true && CurrentEntity.EntityTypeCode != 8 /* Relational*/)
			{
				hasPrimaryKeyMembers = true
				break
			}
		}
	}
	
	if (hasPrimaryKeyMembers == false)
	{
		// add DeleteAllBy foreign key method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 11 // DeleteAllByForeignKey
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "DeleteAll" + CurrentEntity.EntityName + "DataBy"
		foreach (RelationshipProperty)
		{
			if (ItemIndex > 0)
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + "And"
			}
			with (Property from Solution.Find(PropertyID))
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + PropertyName
			}
		}
		add(CurrentMethod)
		
		// add method relationship
		CurrentMethodRelationship = New()
		CurrentMethodRelationship.MethodID = CurrentMethod.MethodID
		CurrentMethodRelationship.RelationshipID = RelationshipID
		CurrentMethodRelationship.Order = 1
		add(CurrentMethodRelationship)
		
		// add parameters
		foreach (RelationshipProperty)
		{
			CurrentParameter = New()
			CurrentParameter.MethodID = CurrentMethod.MethodID
			CurrentParameter.Order = CurrentMethod.ParameterCount + 1
			CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
			CurrentParameter.ReferencedPropertyID = PropertyID
			with (Property from Solution.Find(PropertyID))
			{
				CurrentParameter.ParameterName = PropertyName
			}
			add(CurrentParameter)
		}
		
		// add GetAllBy foreign key method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 4// GetAllByForeignkey
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetAll" + CurrentEntity.EntityName + "DataBy"
		foreach (RelationshipProperty)
		{
			if (ItemIndex > 0)
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + "And"
			}
			with (Property from Solution.Find(PropertyID))
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + PropertyName
			}
		}
		add(CurrentMethod)
		
		// add method relationship
		CurrentMethodRelationship = New()
		CurrentMethodRelationship.MethodID = CurrentMethod.MethodID
		CurrentMethodRelationship.RelationshipID = RelationshipID
		CurrentMethodRelationship.Order = 1
		add(CurrentMethodRelationship)
		
		// add parameters
		foreach (RelationshipProperty)
		{
			CurrentParameter = New()
			CurrentParameter.MethodID = CurrentMethod.MethodID
			CurrentParameter.Order = CurrentMethod.ParameterCount + 1
			CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
			CurrentParameter.ReferencedPropertyID = PropertyID
			with (Property from Solution.Find(PropertyID))
			{
				CurrentParameter.ParameterName = PropertyName
			}
			add(CurrentParameter)
		}
		
		// add GetManyBy foreign key method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 6// GetManyByForeignKey
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetMany" + CurrentEntity.EntityName + "DataBy"
		foreach (RelationshipProperty)
		{
			if (ItemIndex > 0)
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + "And"
			}
			with (Property from Solution.Find(PropertyID))
			{
				CurrentMethod.MethodName = CurrentMethod.MethodName + PropertyName
			}
		}
		add(CurrentMethod)
		
		// add method relationship
		CurrentMethodRelationship = New()
		CurrentMethodRelationship.MethodID = CurrentMethod.MethodID
		CurrentMethodRelationship.RelationshipID = RelationshipID
		CurrentMethodRelationship.Order = 1
		add(CurrentMethodRelationship)
		
		// add parameters
		foreach (RelationshipProperty)
		{
			CurrentParameter = New()
			CurrentParameter.MethodID = CurrentMethod.MethodID
			CurrentParameter.Order = CurrentMethod.ParameterCount + 1
			CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
			CurrentParameter.ReferencedPropertyID = PropertyID
			with (Property from Solution.Find(PropertyID))
			{
				CurrentParameter.ParameterName = PropertyName
			}
			add(CurrentParameter)
		}
	}
}
	
// add GetAll and GetMany methods
switch (CurrentEntity.EntityTypeCode)
{
	case 1: // Lookup
	case 2: // LookupBusiness
	case 3: // Primary
	case 4: // PrimaryCoded
	case 5: // PrimaryBusiness
	case 6: // PrimaryLogging
		
		// add GetAll method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 2 // GetAll
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetAll" + CurrentEntity.EntityName + "Data"
		add(CurrentMethod)
		
		// add GetMany method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 3 // GetMany
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetMany" + CurrentEntity.EntityName + "Data"
		add(CurrentMethod)
		break
	default:
		
		// add GetMany method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 3 // GetMany
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetMany" + CurrentEntity.EntityName + "Data"
		add(CurrentMethod)
		break
}

// add GetAllByCriteria and GetAllByCriteria methods
switch (CurrentEntity.EntityTypeCode)
{
	case 3: // Primary
	case 4: // PrimaryCoded
	case 5: // PrimaryBusiness
	case 6: // PrimaryLogging
	
		// add GetAllByCriteria method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 5 // GetAllByCriteria
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetAll" + CurrentEntity.EntityName + "DataByCriteria"
		add(CurrentMethod)
		
		// add parameters
		with (CurrentEntity)
		{
			foreach (Entity in EntityAndBaseEntities)
			{
				foreach (Property)
				{
					if (LIBIsCandidateSearchProperty == true)
					{
						if (DataTypeCode == 24 /* DateTime */)
						{
							CurrentParameter = New()
							CurrentParameter.MethodID = CurrentMethod.MethodID
							CurrentParameter.Order = CurrentMethod.ParameterCount + 1
							CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
							CurrentParameter.ReferencedPropertyID = PropertyID
							CurrentParameter.ParameterName = PropertyName + "Start"
							add(CurrentParameter)
							CurrentParameter = New()
							CurrentParameter.MethodID = CurrentMethod.MethodID
							CurrentParameter.Order = CurrentMethod.ParameterCount + 1
							CurrentParameter.ReferencedPropertyID = PropertyID
							CurrentParameter.ParameterName = PropertyName + "End"
							add(CurrentParameter)
						}
						else
						{
							CurrentParameter = New()
							CurrentParameter.MethodID = CurrentMethod.MethodID
							CurrentParameter.Order = CurrentMethod.ParameterCount + 1
							CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
							CurrentParameter.ReferencedPropertyID = PropertyID
							CurrentParameter.ParameterName = PropertyName
							with (Parameter from CurrentMethod.Find(ParameterName, PropertyName))
							{
								// append entity name to duplicate parameter name
								CurrentParameter.ParameterName = ../Entity.EntityName + ParameterName
							}
							add(CurrentParameter)
						}
					}
				}
			}
		}
	
		// add GetManyByCriteria method
		CurrentMethod = New()
		CurrentMethod.MethodTypeCode = 7 // GetManyByCriteria
		CurrentMethod.EntityID = CurrentEntity.EntityID
		CurrentMethod.MethodName = "GetMany" + CurrentEntity.EntityName + "DataByCriteria"
		add(CurrentMethod)
		
		// add parameters
		with (CurrentEntity)
		{
			foreach (Entity in EntityAndBaseEntities)
			{
				foreach (Property)
				{
					if (LIBIsCandidateSearchProperty == true)
					{
						if (DataTypeCode == 24 /* DateTime */)
						{
							CurrentParameter = New()
							CurrentParameter.MethodID = CurrentMethod.MethodID
							CurrentParameter.Order = CurrentMethod.ParameterCount + 1
							CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
							CurrentParameter.ReferencedPropertyID = PropertyID
							CurrentParameter.ParameterName = PropertyName + "Start"
							add(CurrentParameter)
							CurrentParameter = New()
							CurrentParameter.MethodID = CurrentMethod.MethodID
							CurrentParameter.Order = CurrentMethod.ParameterCount + 1
							CurrentParameter.ReferencedPropertyID = PropertyID
							CurrentParameter.ParameterName = PropertyName + "End"
							add(CurrentParameter)
						}
						else
						{
							CurrentParameter = New()
							CurrentParameter.MethodID = CurrentMethod.MethodID
							CurrentParameter.Order = CurrentMethod.ParameterCount + 1
							CurrentParameter.ReferencedEntityID = CurrentEntity.EntityID
							CurrentParameter.ReferencedPropertyID = PropertyID
							CurrentParameter.ParameterName = PropertyName
							with (Parameter from CurrentMethod.Find(ParameterName, PropertyName))
							{
								// append entity name to duplicate parameter name
								CurrentParameter.ParameterName = ../Entity.EntityName + ParameterName
							}
							add(CurrentParameter)
						}
					}
				}
			}
		}
		
		break
}

%%></OUTPUT>