<CONFIG>
	NAME MDLElementType
	CATEGORY Element
	NODE SqlColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
// return data type
switch (DataType)
{
	case "char":
	case "nchar":
	case "varchar":
	case "nvarchar":
	case "text":
	case "ntext":
	case "smalldatetime":
	case "time":
	case "year":
	case "enum":
	case "set":
	case "tinytext":
	case "mediumtext":
	case "longtext":
	case "blob":
	case "tinyblob":
	case "mediumblob":
	case "longblob":
		<%%-String%%>
		break
	default:
		<%%-Numeric%%>
		break
}%%></CONTENT>