/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Text;
using MoPlus.Common;
using MoPlus.Data;
using MoPlus.Interpreter.BLL.Solutions;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using MoPlus.Interpreter.BLL.Entities;

namespace MoPlus.Interpreter
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is the base business object implementation for this
	/// project.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	public abstract partial class BusinessObjectBase : EnterpriseBusinessObjectBase, IDomainEnterpriseObject
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Tags.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement(ElementName = "Tags")]
		[DataMember(Name = "Tags")]
		[DataElement(ElementName = "Tags")]
		public virtual string Tags
		{
			get
			{
				if (_tagList == null)
				{
					return String.Empty;
				}
				StringBuilder tags = new StringBuilder();
				foreach (Tag tag in TagList)
				{
					tags.Append(tag.TagName);
					tags.Append(" ");
				}
				return tags.ToString();
			}
			set
			{
				string tags = Tags;
				if (tags != value)
				{
					TagList.Clear();
				    if (!String.IsNullOrWhiteSpace(value))
				    {
				        foreach (string item in value.Split(' '))
				        {
				            if (!String.IsNullOrWhiteSpace(item))
				            {
				                Tag tag = new Tag();
				                tag.TagID = Guid.NewGuid();
				                tag.TagName = item;
				                TagList.Add(tag);
				            }
				        }
				    }
				    _isModified = true;
					base.OnPropertyChanged("Tags");
				}
			}
		}

		protected EnterpriseDataObjectList<BLL.Solutions.Tag> _tagList = null;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets a collection of TagList.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual EnterpriseDataObjectList<BLL.Solutions.Tag> TagList
		{
			get
			{
				if (_tagList == null)
				{
					_tagList = new EnterpriseDataObjectList<BLL.Solutions.Tag>();
				}
				return _tagList;
			}
			set
			{
				if (_tagList == null || _tagList.Equals(value) == false)
				{
					_tagList = value;
					if (value != null)
					{
						_isModified = true;
					}
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property determines if the data has been modified since the
		/// last load from a resource such as a database.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[DefaultValue(DefaultValue.Bool)]
		public override bool IsModified
		{
			get
			{
				if (_tagList != null && _tagList.IsModified == true) return true;
				return false;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the name of the instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string Name { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets the reverse engineering instance.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual BusinessObjectBase ReverseInstance { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the DefaultSourcePrefix.</summary>
		///--------------------------------------------------------------------------------
		public string DefaultSourcePrefix
		{
			get
			{
				if (this is Index)
				{
					return "IX_";
				}
				if (this is Relationship)
				{
					return "REL_";
				}
				return String.Empty;
			}
		}

		private int _currentTabIndent = 0;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the CurrentTabIndent, which signifies how much
		/// to indent generated code.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual int CurrentTabIndent
		{
			get
			{
				return _currentTabIndent;
			}
			set
			{
				_currentTabIndent = value;
				if (_currentTabIndent < 0)
				{
					_currentTabIndent = 0;
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets UseTabs.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool UseTabs { get; set; }

		private string _tabString = "\t";
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets TabString.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string TabString
		{
			get
			{
				return _tabString;
			}
			set
			{
				_tabString = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets UseProtectedAreas.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool UseProtectedAreas { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProtectedAreaStart.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string ProtectedAreaStart { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ProtectedAreaEnd.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string ProtectedAreaEnd { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets UseIgnoredAreas.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public bool UseIgnoredAreas { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IgnoredAreaStart.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string IgnoredAreaStart { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets IgnoredAreaEnd.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public string IgnoredAreaEnd { get; set; }

		private string _newlineString = "\r\n";
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets NewlineString.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual string NewlineString
		{
			get
			{
				return _newlineString;
			}
			set
			{
				_newlineString = value;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the is processed flag.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IsProcessed { get; set; }

		protected string _sourceName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SourceName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SourceName
		{
			get
			{
				return _sourceName;
			}
			set
			{
				if (_sourceName != value)
				{
					_sourceName = value;
				}
			}
		}

		protected string _specSourceName = DefaultValue.String;
		///--------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SpecSourceName.</summary>
		///--------------------------------------------------------------------------------
		[XmlElement()]
		[DataElement]
		[DefaultValue(DefaultValue.StringStr)]
		public virtual string SpecSourceName
		{
			get
			{
				return _specSourceName;
			}
			set
			{
				if (_specSourceName != value)
				{
					_specSourceName = value;
				}
			}
		}

		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method resets the IsModified state for the instance.</summary>
		///
		/// <param name="isLoaded">The reset value for the IsModified property.</param>
		///--------------------------------------------------------------------------------
		public override void ResetModified(bool isModified)
		{
			_isModified = isModified;
			if (_tagList != null) _tagList.ResetModified(isModified);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the parent item of this item.</summary>
		///--------------------------------------------------------------------------------
		public virtual IDomainEnterpriseObject GetParentItem()
		{
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method disposes of resources in the model.</summary>
		///--------------------------------------------------------------------------------
		protected override void OnDispose()
		{
			if (_tagList != null)
			{
				foreach (Tag tag in TagList)
				{
					tag.Dispose();
				}
				TagList.Clear();
				TagList = null;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method validates Tags and returns an error message if not valid.</param>
		///--------------------------------------------------------------------------------
		public string ValidateTags()
		{
			foreach (Tag loopTag in TagList)
			{
				if (Regex.IsMatch(loopTag.TagName, Resources.DisplayValues.Regex_Word) == false)
				{
					return Resources.DisplayValues.Validation_Tag;
				}
			}
			return null;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds this item's tags into a named tag dictionary.</summary>
		/// 
		/// <param name="usedTags">Input named tag dictionary.</param>
		///--------------------------------------------------------------------------------
		public void AddTagsToUsedTags(NameObjectCollection usedTags)
		{
			foreach (Tag tag in TagList)
			{
				if (usedTags[tag.TagName] is NameObjectCollection)
				{
					(usedTags[tag.TagName] as NameObjectCollection).Add(ID.ToString(), true);
				}
				else
				{
					usedTags[tag.TagName] = new NameObjectCollection();
					(usedTags[tag.TagName] as NameObjectCollection).Add(ID.ToString(), true);
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method adds a tag to TagList.</summary>
		///--------------------------------------------------------------------------------
		public virtual void AddTag(string tagName)
		{
			if (TagList.Find(t => t.TagName == tagName) == null)
			{
				TagList.Add(new Tag(Guid.NewGuid(), tagName));
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method removes a tag from TagList.</summary>
		///--------------------------------------------------------------------------------
		public virtual void RemoveTag(string tagName)
		{
			Tag tag = TagList.Find(t => t.TagName == tagName);
			if (tag != null)
			{
				TagList.Remove(tag);
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method formats the input code, chiefly supplying indents and new
		/// lines.</summary>
		///
		/// <param name="inputCode">The code to indent.</param>
		///
		/// <returns>Formatted output with one new line and current number of tabs.</returns>
		///--------------------------------------------------------------------------------
		public virtual string FormatCode(string inputCode)
		{
			return FormatCode(inputCode, 1);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method formats the input code, chiefly supplying indents and new
		/// lines.</summary>
		///
		/// <param name="inputCode">The code to indent.</param>
		/// <param name="newLineCount">The number of newlines to preappend the code with.</param>
		/// 
		/// <returns>Formatted output with input number of new lines and current number of tabs.</returns>
		///--------------------------------------------------------------------------------
		public virtual string FormatCode(string inputCode, int newLineCount)
		{
			return FormatCode(inputCode, newLineCount, CurrentTabIndent);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method formats the input code, chiefly supplying indents and new
		/// lines.</summary>
		///
		/// <param name="inputCode">The code to indent.</param>
		/// <param name="newLineCount">The number of newlines to preappend the code with.</param>
		/// <param name="tabIndent">The number of tabs to preappend the code with.</param>
		/// 
		/// <returns>Formatted output with input number of new lines and tabs.</returns>
		///--------------------------------------------------------------------------------
		public virtual string FormatCode(string inputCode, int newLineCount, int tabIndent)
		{
			StringBuilder outputCode = new StringBuilder();
			int formatCount = newLineCount;
			while (formatCount > 0)
			{
				outputCode.Append(NewlineString);
				formatCount--;
			}
			formatCount = tabIndent;
			while (formatCount > 0)
			{
				outputCode.Append(TabString);
				formatCount--;
			}
			outputCode.Append(inputCode);
			return outputCode.ToString();
		}
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor ensures that default DataAccessOptions are set up for
		/// collection manager operations.</summary>
		///--------------------------------------------------------------------------------
		public BusinessObjectBase()
		{
		}

		#endregion "Constructors"
	}
}
