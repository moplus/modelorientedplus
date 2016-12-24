/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.IO;
using System.IO;
using System.Linq.Expressions;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to provide an OData queryable list.</summary>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[CollectionDataContract]
	public class ODataQuery<T> : IOrderedQueryable<T>
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets Provider.</summary>
		///--------------------------------------------------------------------------------
		public IQueryProvider Provider { get; private set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Expression.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public Expression Expression { get; private set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets ElementType.</summary>
		///--------------------------------------------------------------------------------
		[XmlIgnore]
		[IgnoreDataMember]
		public Type ElementType
		{
			get { return typeof(T); }
		}
		#endregion "Fields and Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method gets the provider based query expression.</summary>
		///--------------------------------------------------------------------------------
		public IEnumerator<T> GetEnumerator()
		{
			return (Provider.Execute<IEnumerable<T>>(Expression) ?? new List<T>()).GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a new instance of the ODataQuery class..</summary>
		///
		/// <param name="provider">A provider that implements the <see cref="IQueryProvider"/> contract.</param>
		///--------------------------------------------------------------------------------
		public ODataQuery(ODataProvider<T> provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			Provider = provider;
			Expression = Expression.Constant(this);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a new instance of the ODataQuery class..</summary>
		///
		/// <param name="provider">A provider that implements the <see cref="IQueryProvider"/> contract.</param>
		/// <param name="expression">An OData <see cref="Expression"/>.</param>
		///--------------------------------------------------------------------------------
		public ODataQuery(ODataProvider<T> provider, Expression expression)
			: this(provider)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			Expression = expression;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes a new instance of the ODataQuery class..</summary>
		///--------------------------------------------------------------------------------
		public ODataQuery()
		{
		}

		#endregion "Constructors"
	}
}
