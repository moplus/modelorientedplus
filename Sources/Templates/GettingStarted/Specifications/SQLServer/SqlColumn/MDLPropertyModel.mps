<CONFIG>
	NAME MDLPropertyModel
	CATEGORY Property
	NODE SqlColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
// create property
CurrentProperty = New()
CurrentProperty.EntityID = CurrentEntity.EntityID
CurrentProperty.Tags = "DB"

// set basic properties
CurrentProperty.PropertyName = MDLPropertyName
CurrentProperty.SourceName = SqlColumnName
CurrentProperty.IsNullable = Nullable
CurrentProperty.Length = MaximumLength
if (CurrentProperty.Length < 0) {
	CurrentProperty.Length = 0
}
CurrentProperty.Precision = NumericPrecision
CurrentProperty.Scale = NumericScale
CurrentProperty.InitialValue = Default
CurrentProperty.IsPrimaryKeyMember = InPrimaryKey
CurrentProperty.IsForeignKeyMember = IsForeignKey
CurrentProperty.Order = Order
CurrentProperty.DataTypeCode = MDLDataTypeCode
CurrentProperty.Identity = Identity
CurrentProperty.IdentityIncrement = IdentityIncrement
CurrentProperty.IdentitySeed = IdentitySeed

// set overrides from extended properties
foreach (SqlExtendedProperty)
{
	if (SqlExtendedPropertyName == "PropertyName")
	{
		CurrentProperty.PropertyName = Value
	}
	else if (SqlExtendedPropertyName == "PropertyDefaultValue")
	{
		CurrentProperty.InitialValue = Value
	}
	else if (SqlExtendedPropertyName == "Order")
	{
		CurrentProperty.Order = Value
	}
	else if (SqlExtendedPropertyName == "DataTypeCode")
	{
		CurrentProperty.DataTypeCode = Value
	}
	else if (SqlExtendedPropertyName == "Description")
	{
		CurrentProperty.Description = Value
	}
	else if (SqlExtendedPropertyName == "Tags")
	{
		CurrentProperty.Tags = Value
	}
}

// add property to model
add(CurrentProperty)
%%></OUTPUT>