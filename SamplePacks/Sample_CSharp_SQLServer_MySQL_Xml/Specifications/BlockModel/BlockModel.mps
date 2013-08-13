<CONFIG>
	NAME BlockModel
	NODE SpecificationSource
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
progress(SqlDatabase.SqlTableCount)
var blockObjectID
var blockKeyPropertyID
var blockNamePropertyID
var elementObjectID
var elementKeyPropertyID
var elementNamePropertyID
var elementTypePropertyID
var dataCategoryID
var stringID
var numericID
var tableNumber = 0
//
// create a Model with Blocks and Elements
//
CurrentModel = New()
CurrentModel.SourceName = "MyModel"
CurrentModel.ModelName = "MyModel"
CurrentModel.Tags = "DB"
add(CurrentModel)
with (CurrentModel)
{
	//
	// create a Block ModelObject
	//
	CurrentModelObject = New()
	CurrentModelObject.SourceName = "Block"
	CurrentModelObject.ModelObjectName = "Block"
	CurrentModelObject.ModelID = CurrentModel.ModelID
	CurrentModelObject.Description = "A Block, analagous to an Entity or Class, is a package that can hold elements."
	CurrentModelObject.Tags = "DB"
	add(CurrentModelObject)
	blockObjectID = CurrentModelObject.ModelObjectID
	//
	// create an Element ModelObject, a child of Block
	//
	CurrentModelObject = New()
	CurrentModelObject.SourceName = "Element"
	CurrentModelObject.ModelObjectName = "Element"
	CurrentModelObject.ModelID = CurrentModel.ModelID
	CurrentModelObject.Description = "An Element, analagous to a Property, can hold some string or numeric data."
	CurrentModelObject.Tags = "DB"
	CurrentModelObject.ParentModelObjectID = blockObjectID
	add(CurrentModelObject)
	elementObjectID = CurrentModelObject.ModelObjectID
	//
	// create an DataCategory Enumeration
	//
	CurrentEnumeration = New()
	CurrentEnumeration.SourceName = "DataCategory"
	CurrentEnumeration.EnumerationName = "DataCategory"
	CurrentEnumeration.ModelID = CurrentModel.ModelID
	CurrentEnumeration.Description = "A DataCategory defines what kind of data an element can hold."
	CurrentEnumeration.Tags = "DB"
	add(CurrentEnumeration)
	dataCategoryID = CurrentEnumeration.EnumerationID
	//
	// create a String Value
	//
	CurrentValue = New()
	CurrentValue.SourceName = "String"
	CurrentValue.ValueName = "String"
	CurrentValue.EnumValue = "String"
	CurrentValue.Order = 1
	CurrentValue.EnumerationID = dataCategoryID
	CurrentValue.Description = "A String supports elements that hold string values."
	CurrentValue.Tags = "DB"
	add(CurrentValue)
	stringID = CurrentValue.ValueID
	//
	// create a Numeric Value
	//
	CurrentValue = New()
	CurrentValue.SourceName = "Numeric"
	CurrentValue.ValueName = "Numeric"
	CurrentValue.EnumValue = "Numeric"
	CurrentValue.Order = 2
	CurrentValue.EnumerationID = dataCategoryID
	CurrentValue.Description = "A Numeric supports elements that hold numeric values."
	CurrentValue.Tags = "DB"
	add(CurrentValue)
	numericID = CurrentValue.ValueID
	//
	// create a BlockID ModelProperty under Block
	//
	CurrentModelProperty = New()
	CurrentModelProperty.SourceName = "BlockID"
	CurrentModelProperty.ModelPropertyName = "BlockID"
	CurrentModelProperty.ModelObjectID = blockObjectID
	CurrentModelProperty.DefinedByEnumerationID = dataCategoryID
	CurrentModelProperty.DefinedByValueID = numericID
	CurrentModelProperty.Order = 1
	CurrentModelProperty.Description = "The identifier for a property of Block."
	CurrentModelProperty.IsCollection = false
	CurrentModelProperty.IsDisplayProperty = false
	CurrentModelProperty.Tags = "DB"
	add(CurrentModelProperty)
	blockKeyPropertyID = CurrentModelProperty.ModelPropertyID
	//
	// create a BlockName ModelProperty under Block
	//
	CurrentModelProperty = New()
	CurrentModelProperty.SourceName = "BlockName"
	CurrentModelProperty.ModelPropertyName = "BlockName"
	CurrentModelProperty.ModelObjectID = blockObjectID
	CurrentModelProperty.DefinedByEnumerationID = dataCategoryID
	CurrentModelProperty.DefinedByValueID = stringID
	CurrentModelProperty.Order = 2
	CurrentModelProperty.Description = "The name for a property of Block."
	CurrentModelProperty.IsCollection = false
	CurrentModelProperty.IsDisplayProperty = true
	CurrentModelProperty.Tags = "DB"
	add(CurrentModelProperty)
	blockNamePropertyID = CurrentModelProperty.ModelPropertyID
	//
	// create an ElementID ModelProperty under Element
	//
	CurrentModelProperty = New()
	CurrentModelProperty.SourceName = "ElementID"
	CurrentModelProperty.ModelPropertyName = "ElementID"
	CurrentModelProperty.ModelObjectID = elementObjectID
	CurrentModelProperty.DefinedByEnumerationID = dataCategoryID
	CurrentModelProperty.DefinedByValueID = numericID
	CurrentModelProperty.Order = 1
	CurrentModelProperty.Description = "The identifier for a property of Element."
	CurrentModelProperty.IsCollection = false
	CurrentModelProperty.IsDisplayProperty = false
	CurrentModelProperty.Tags = "DB"
	add(CurrentModelProperty)
	elementKeyPropertyID = CurrentModelProperty.ModelPropertyID
	//
	// create an ElementName ModelProperty under Element
	//
	CurrentModelProperty = New()
	CurrentModelProperty.SourceName = "ElementName"
	CurrentModelProperty.ModelPropertyName = "ElementName"
	CurrentModelProperty.ModelObjectID = elementObjectID
	CurrentModelProperty.DefinedByEnumerationID = dataCategoryID
	CurrentModelProperty.DefinedByValueID = stringID
	CurrentModelProperty.Order = 2
	CurrentModelProperty.Description = "The name for a property of Element."
	CurrentModelProperty.IsCollection = false
	CurrentModelProperty.IsDisplayProperty = true
	CurrentModelProperty.Tags = "DB"
	add(CurrentModelProperty)
	elementNamePropertyID = CurrentModelProperty.ModelPropertyID
	//
	// create an ElementDataType ModelProperty under Element
	//
	CurrentModelProperty = New()
	CurrentModelProperty.SourceName = "ElementDataType"
	CurrentModelProperty.ModelPropertyName = "ElementDataType"
	CurrentModelProperty.ModelObjectID = elementObjectID
	CurrentModelProperty.DefinedByEnumerationID = dataCategoryID
	CurrentModelProperty.Order = 3
	CurrentModelProperty.Description = "The data category for a property of Element."
	CurrentModelProperty.Tags = "DB"
	add(CurrentModelProperty)
	elementTypePropertyID = CurrentModelProperty.ModelPropertyID
}
//
// create instances of Block and Element
//
foreach(SqlTable)
{
	tableNumber = tableNumber + 1
	// create/update the block and associated elements
	<%%>MDLBlockModel(		blockObjectID=blockObjectID,
							blockKeyPropertyID=blockKeyPropertyID,
							blockNamePropertyID=blockNamePropertyID,
							elementObjectID=elementObjectID,
							elementKeyPropertyID=elementKeyPropertyID,
							elementNamePropertyID=elementNamePropertyID,
							elementTypePropertyID=elementTypePropertyID,
							dataCategoryID=dataCategoryID,
							tableNumber=tableNumber)%%>
	progress
}
%%></OUTPUT>