<CONFIG>
	NAME MDLBlockModel
	CATEGORY Block
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
param blockObjectID
param blockKeyPropertyID
param blockNamePropertyID
param elementObjectID
param elementKeyPropertyID
param elementNamePropertyID
param elementTypePropertyID
param dataCategoryID
param tableNumber
var objectInstanceID
var columnNumber = tableNumber*1000

// create Block object instance and add to model
CurrentObjectInstance = New()
CurrentObjectInstance.SourceName = SqlTableName
CurrentObjectInstance.ModelObjectID = blockObjectID
CurrentObjectInstance.Description = "This block instance is based on data from the MySQL table " + SqlTableName + "."
CurrentObjectInstance.Tags = "DB"
add(CurrentObjectInstance)
objectInstanceID = CurrentObjectInstance.ObjectInstanceID

// create id property instance and add to model
CurrentPropertyInstance = New()
CurrentPropertyInstance.SourceName = SqlTableName
CurrentPropertyInstance.ModelPropertyID = blockKeyPropertyID
CurrentPropertyInstance.ObjectInstanceID = objectInstanceID
CurrentPropertyInstance.Tags = "DB"
CurrentPropertyInstance.Order = 1
CurrentPropertyInstance.PropertyValue = tableNumber
add(CurrentPropertyInstance)

// create name property instance and add to model
CurrentPropertyInstance = New()
CurrentPropertyInstance.SourceName = SqlTableName
CurrentPropertyInstance.ModelPropertyID = blockNamePropertyID
CurrentPropertyInstance.ObjectInstanceID = objectInstanceID
CurrentPropertyInstance.Tags = "DB"
CurrentPropertyInstance.Order = 2
CurrentPropertyInstance.PropertyValue = MDLBlockName
add(CurrentPropertyInstance)

// add elements
foreach (SqlColumn)
{
	columnNumber = columnNumber + 1
	<%%>MDLElementModel(	parentObjectInstanceID=objectInstanceID,
							elementObjectID=elementObjectID,
							elementKeyPropertyID=elementKeyPropertyID,
							elementNamePropertyID=elementNamePropertyID,
							elementTypePropertyID=elementTypePropertyID,
							dataCategoryID=dataCategoryID,
							columnNumber=columnNumber)%%>
}
%%></OUTPUT>