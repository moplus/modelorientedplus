/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter;

namespace MoPlus.Interpreter.BLL.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This enumeration is used to hold values used by business rules for
	/// specification properties.</summary>
	///
	/// This file is code generated and should not be modified by hand.
	/// If you need to customize this file outside of protected areas,
	/// change the Status value below to something other than
	/// Generated to prevent changes from being overwritten.
	///
	/// <CreatedByUserName>INCODE-1\Dave</CreatedByUserName>
	/// <CreatedDate>7/3/2013</CreatedDate>
	/// <Status>Generated</Status>
	///--------------------------------------------------------------------------------
	public enum SpecPropertyCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For BaseURI read only property.</summary>
		BaseURI = 1,
		/// <summary>For CreateDate read only property.</summary>
		CreateDate = 2,
		/// <summary>For DataType read only property.</summary>
		DataType = 3,
		/// <summary>For DateLastModified read only property.</summary>
		DateLastModified = 4,
		/// <summary>For DbID read only property.</summary>
		DbID = 5,
		/// <summary>For Default read only property.</summary>
		Default = 6,
		/// <summary>For DefaultFileGroup read only property.</summary>
		DefaultFileGroup = 7,
		/// <summary>For DefaultFullTextCatalog read only property.</summary>
		DefaultFullTextCatalog = 8,
		/// <summary>For DefaultSchema read only property.</summary>
		DefaultSchema = 9,
		/// <summary>For Descending read only property.</summary>
		Descending = 10,
		/// <summary>For DocumentType read only property.</summary>
		DocumentType = 11,
		/// <summary>For FileGroup read only property.</summary>
		FileGroup = 12,
		/// <summary>For InnerText read only property.</summary>
		InnerText = 13,
		/// <summary>For InnerXml read only property.</summary>
		InnerXml = 14,
		/// <summary>For InPrimaryKey read only property.</summary>
		InPrimaryKey = 15,
		/// <summary>For IsChecked read only property.</summary>
		IsChecked = 16,
		/// <summary>For IsClustered read only property.</summary>
		IsClustered = 17,
		/// <summary>For IsComputed read only property.</summary>
		IsComputed = 18,
		/// <summary>For IsForeignKey read only property.</summary>
		IsForeignKey = 19,
		/// <summary>For IsFullTextIndexed read only property.</summary>
		IsFullTextIndexed = 20,
		/// <summary>For IsFullTextKey read only property.</summary>
		IsFullTextKey = 21,
		/// <summary>For IsIncluded read only property.</summary>
		IsIncluded = 22,
		/// <summary>For IsSystemNamed read only property.</summary>
		IsSystemNamed = 23,
		/// <summary>For IsUnique read only property.</summary>
		IsUnique = 24,
		/// <summary>For IsXmlIndex read only property.</summary>
		IsXmlIndex = 25,
		/// <summary>For LocalName read only property.</summary>
		LocalName = 26,
		/// <summary>For MaximumLength read only property.</summary>
		MaximumLength = 27,
		/// <summary>For NamespaceURI read only property.</summary>
		NamespaceURI = 28,
		/// <summary>For NodeType read only property.</summary>
		NodeType = 29,
		/// <summary>For Nullable read only property.</summary>
		Nullable = 30,
		/// <summary>For NumericPrecision read only property.</summary>
		NumericPrecision = 31,
		/// <summary>For NumericScale read only property.</summary>
		NumericScale = 32,
		/// <summary>For OuterXml read only property.</summary>
		OuterXml = 33,
		/// <summary>For Owner read only property.</summary>
		Owner = 34,
		/// <summary>For ParentNodeID read only property.</summary>
		ParentNodeID = 35,
		/// <summary>For Prefix read only property.</summary>
		Prefix = 36,
		/// <summary>For PrimaryFilePath read only property.</summary>
		PrimaryFilePath = 37,
		/// <summary>For ReferencedColumn read only property.</summary>
		ReferencedColumn = 38,
		/// <summary>For ReferencedKey read only property.</summary>
		ReferencedKey = 39,
		/// <summary>For ReferencedTable read only property.</summary>
		ReferencedTable = 40,
		/// <summary>For ReferencedTableSchema read only property.</summary>
		ReferencedTableSchema = 41,
		/// <summary>For Schema read only property.</summary>
		Schema = 42,
		/// <summary>For SchemaInfo read only property.</summary>
		SchemaInfo = 43,
		/// <summary>For SqlColumnID read only property.</summary>
		SqlColumnID = 44,
		/// <summary>For SqlColumnName read only property.</summary>
		SqlColumnName = 45,
		/// <summary>For SqlDatabaseID read only property.</summary>
		SqlDatabaseID = 46,
		/// <summary>For SqlDatabaseName read only property.</summary>
		SqlDatabaseName = 47,
		/// <summary>For SqlExtendedPropertyID read only property.</summary>
		SqlExtendedPropertyID = 48,
		/// <summary>For SqlExtendedPropertyName read only property.</summary>
		SqlExtendedPropertyName = 49,
		/// <summary>For SqlForeignKeyColumnID read only property.</summary>
		SqlForeignKeyColumnID = 50,
		/// <summary>For SqlForeignKeyColumnName read only property.</summary>
		SqlForeignKeyColumnName = 51,
		/// <summary>For SqlForeignKeyID read only property.</summary>
		SqlForeignKeyID = 52,
		/// <summary>For SqlForeignKeyName read only property.</summary>
		SqlForeignKeyName = 53,
		/// <summary>For SqlIndexedColumnID read only property.</summary>
		SqlIndexedColumnID = 54,
		/// <summary>For SqlIndexedColumnName read only property.</summary>
		SqlIndexedColumnName = 55,
		/// <summary>For SqlIndexID read only property.</summary>
		SqlIndexID = 56,
		/// <summary>For SqlIndexName read only property.</summary>
		SqlIndexName = 57,
		/// <summary>For SqlPropertyID read only property.</summary>
		SqlPropertyID = 58,
		/// <summary>For SqlPropertyName read only property.</summary>
		SqlPropertyName = 59,
		/// <summary>For SqlTableID read only property.</summary>
		SqlTableID = 60,
		/// <summary>For SqlTableName read only property.</summary>
		SqlTableName = 61,
		/// <summary>For SqlType read only property.</summary>
		SqlType = 62,
		/// <summary>For SqlValue read only property.</summary>
		SqlValue = 63,
		/// <summary>For State read only property.</summary>
		State = 64,
		/// <summary>For Status read only property.</summary>
		Status = 65,
		/// <summary>For Urn read only property.</summary>
		Urn = 66,
		/// <summary>For UserName read only property.</summary>
		UserName = 67,
		/// <summary>For Value read only property.</summary>
		Value = 68,
		/// <summary>For XmlAttributeID read only property.</summary>
		XmlAttributeID = 69,
		/// <summary>For XmlAttributeName read only property.</summary>
		XmlAttributeName = 70,
		/// <summary>For XmlDocumentID read only property.</summary>
		XmlDocumentID = 71,
		/// <summary>For XmlDocumentName read only property.</summary>
		XmlDocumentName = 72,
		/// <summary>For XmlNodeID read only property.</summary>
		XmlNodeID = 73,
		/// <summary>For XmlNodeName read only property.</summary>
		XmlNodeName = 74,

		#region protected
		/// <summary>For SqlTableCount read only property.</summary>
		SqlTableCount = 501,
		/// <summary>For PrimaryKeyColumnCount read only property.</summary>
		PrimaryKeyColumnCount = 502,
		/// <summary>For ForeignKeyColumnCount read only property.</summary>
		ForeignKeyColumnCount = 503,
		/// <summary>For PrimaryAndForeignKeyColumnCount read only property.</summary>
		PrimaryAndForeignKeyColumnCount = 504,
		/// <summary>For Nullable read only property.</summary>
		#endregion protected
	}
}
