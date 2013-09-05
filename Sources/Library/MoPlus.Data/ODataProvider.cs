/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using MoPlus.IO;
using System.IO;

namespace MoPlus.Data
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to provide OData based on EnterpriseDataObjectLists.</summary>
	/// 
	/// <remarks>TODO: This OData provider class is not finished, needs work.</remarks>
	///--------------------------------------------------------------------------------
	[Serializable()]
	[CollectionDataContract]
	public class ODataProvider<T> : IQueryProvider
	{
		#region "Fields and Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets the original List.</summary>
		///--------------------------------------------------------------------------------
		private IEnumerable<T> List { get; set; }

		#endregion "Fields and Properties"

		#region "Methods"
		#endregion "Methods"

		#region "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This constructor initializes the provider with an input list.</summary>
		///
		/// <param name="list">The input list.</param>
		///--------------------------------------------------------------------------------
		public ODataProvider(IEnumerable<T> list)
		{
			List = list;
		}

		#endregion "Constructors"
		///--------------------------------------------------------------------------------
		/// <summary>This method executes an OData expression.</summary>
		///
		/// <param name="expression">The input expression.</param>
		///--------------------------------------------------------------------------------
		public TResult Execute<TResult>(Expression expression)
		{
			// TODO: finish this out
			return (TResult)this.Execute(expression);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method executes an OData expression.</summary>
		///
		/// <param name="expression">The input expression.</param>
		///--------------------------------------------------------------------------------
		public virtual object Execute(Expression expression)
		{
			// TODO: finish this out
			return List;
		}

		public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
		{
			return (IQueryable<TResult>)this.CreateQuery(expression);
		}

		public IQueryable CreateQuery(Expression expression)
		{
			Type elementType = TypeSystem.GetElementType(expression.Type);
			try
			{
				return (IQueryable)Activator.CreateInstance(typeof(ODataQuery<>).MakeGenericType(elementType), new object[] { this, expression });
			}
			catch (System.Reflection.TargetInvocationException tie)
			{
				throw tie.InnerException;
			}
		}
	}

	internal static class TypeSystem
	{
		internal static Type GetElementType(Type seqType)
		{
			Type ienum = FindIEnumerable(seqType);
			if (ienum == null) return seqType;
			return ienum.GetGenericArguments()[0];
		}

		private static Type FindIEnumerable(Type seqType)
		{
			if (seqType == null || seqType == typeof(string))
				return null;

			if (seqType.IsArray)
				return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());

			if (seqType.IsGenericType)
			{
				foreach (Type arg in seqType.GetGenericArguments())
				{
					Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
					if (ienum.IsAssignableFrom(seqType))
					{
						return ienum;
					}
				}
			}

			Type[] ifaces = seqType.GetInterfaces();
			if (ifaces != null && ifaces.Length > 0)
			{
				foreach (Type iface in ifaces)
				{
					Type ienum = FindIEnumerable(iface);
					if (ienum != null) return ienum;
				}
			}

			if (seqType.BaseType != null && seqType.BaseType != typeof(object))
			{
				return FindIEnumerable(seqType.BaseType);
			}

			return null;
		}
	}
}
