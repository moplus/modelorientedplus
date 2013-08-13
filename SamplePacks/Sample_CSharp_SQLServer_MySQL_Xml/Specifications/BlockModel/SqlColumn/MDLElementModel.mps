<CONFIG>
	NAME MDLElementModel
	CATEGORY Element
	NODE SqlColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
param parentObjectInstanceID
param elementObjectID
param elementKeyPropertyID
param elementNamePropertyID
param elementTypePropertyID
param dataCategoryID
param columnNumber
var objectInstanceID

// create Element object instance and add to model
CurrentObjectInstance = New()
CurrentObjectInstance.SourceName = SqlTable.SqlTableName + "." + SqlColumnName
CurrentObjectInstance.ModelObjectID = elementObjectID
CurrentObjectInstance.ParentObjectInstanceID = parentObjectInstanceID
CurrentObjectInstance.Description = "This element instance is based on data from the MySQL column " + SqlColumnName + "."
CurrentObjectInstance.Tags = "DB"
add(CurrentObjectInstance)
objectInstanceID = CurrentObjectInstance.ObjectInstanceID

// create id property instance and add to model
CurrentPropertyInstance = New()
CurrentPropertyInstance.SourceName = SqlTable.SqlTableName + "." + SqlColumnName
CurrentPropertyInstance.ModelPropertyID = elementKeyPropertyID
CurrentPropertyInstance.ObjectInstanceID = objectInstanceID
CurrentPropertyInstance.Tags = "DB"
CurrentPropertyInstance.Order = 1
CurrentPropertyInstance.PropertyValue = columnNumber
add(CurrentPropertyInstance)

// create name property instance and add to model
CurrentPropertyInstance = New()
CurrentPropertyInstance.SourceName = SqlTable.SqlTableName + "." + SqlColumnName
CurrentPropertyInstance.ModelPropertyID = elementNamePropertyID
CurrentPropertyInstance.ObjectInstanceID = objectInstanceID
CurrentPropertyInstance.Tags = "DB"
CurrentPropertyInstance.Order = 2
CurrentPropertyInstance.PropertyValue = MDLElementName
add(CurrentPropertyInstance)

// create type property instance and add to model
CurrentPropertyInstance = New()
CurrentPropertyInstance.SourceName = SqlTable.SqlTableName + "." + SqlColumnName
CurrentPropertyInstance.ModelPropertyID = elementTypePropertyID
CurrentPropertyInstance.ObjectInstanceID = objectInstanceID
CurrentPropertyInstance.Tags = "DB"
CurrentPropertyInstance.Order = 3
CurrentPropertyInstance.PropertyValue = MDLElementType
add(CurrentPropertyInstance)
%%></OUTPUT>