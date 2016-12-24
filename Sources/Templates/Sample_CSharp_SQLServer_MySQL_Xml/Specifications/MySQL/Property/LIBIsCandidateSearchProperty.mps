<CONFIG>
	NAME LIBIsCandidateSearchProperty
	CATEGORY LIB
	NODE Property
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
if (IsPrimaryKeyMember == true)
{
	// primary keys are not candidates
	<%%-false%%>
	return
}
with (AuditProperty from Solution.Find(PropertyName, PropertyName))
{
	// audit properties are not candidates
	<%%-false%%>
	return
}
switch (DataTypeCode)
{
	case 21: // IntTiny
	case 2: // IntShort
	case 3: // Int
	case 4: // IntLong
	case 22: // UIntTiny
	case 6: // UIntShort
	case 7: // UInt
	case 8: // UIntLong
		// numerics that may be used for business rules are candidates
		if (IsForeignKeyMember == true)
		{
			<%%-true%%>
			return
		}
		break
	case 16: // String
	case 17: // StringUnicode
		// general names are candidates
		if (PropertyName.ToLower().EndsWith("name") == true || PropertyName.ToLower().EndsWith("title") == true)
		{
			<%%-true%%>
			return
		}
		break
	case 24: // DateTime
		// dates are candidates
		if (PropertyName != "StartDate" && PropertyName != "EndDate")
		{
			<%%-true%%>
		}
		return
		break
}
<%%-false%%>
%%></CONTENT>