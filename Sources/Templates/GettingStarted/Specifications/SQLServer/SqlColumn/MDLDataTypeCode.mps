<CONFIG>
	NAME MDLDataTypeCode
	CATEGORY Property
	NODE SqlColumn
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:

// return data type
switch (DataType)
{
	case "sbyte":
		<%%=1%%>
		break
	case "smallint":
		<%%=2%%>
		break
	case "int":
		<%%=3%%>
		break
	case "bigint":
		<%%=4%%>
		break
	/*case "binary":
		<%%=5%%>
		break*/
	/* TODO: utilize constraints possibly to identify unsigned data types
	case "smallint":
		<%%=6%%>
		break
	case "int":
		<%%=7%%>
		break
	case "bigint":
		<%%=8%%>
		break*/
	case "real":
	case "float":
		<%%=9%%>
		break
	case "double":
		<%%=10%%>
		break
	case "decimal":
		<%%=11%%>
		break
	case "bit":
		<%%=12%%>
		break
	case "char":
		<%%=13%%>
		break
	case "nchar":
		<%%=17%%>
		break
	/*case "binary":
		<%%=15%%>
		break*/
	case "varchar":
		<%%=16%%>
		break
	case "nvarchar":
		<%%=17%%>
		break
	case "money":
		<%%=18%%>
		break
	case "text":
		<%%=19%%>
		break
	case "ntext":
		<%%=20%%>
		break
	case "tinyint":
		<%%=21%%>
		break
	/*case "tinyint":
		<%%=22%%>
		break*/
	case "image":
		<%%=27%%>
		break
	case "binary":
		<%%=23%%>
		break
	case "date":
		<%%=24%%>
		break
	case "datetime":
		<%%=24%%>
		break
	case "timestamp":
		<%%=25%%>
		break
	case "uniqueidentifier":
		<%%=26%%>
		break
	case "smalldatetime":
		<%%=29%%>
		break
	case "varbinary":
		<%%=37%%>
		break
	default:
		trace("ERROR: DataType '" + DataType + "' not supported!")
}%%></CONTENT>