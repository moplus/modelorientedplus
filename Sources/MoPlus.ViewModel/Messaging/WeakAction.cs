/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Code written by Marlon Grech and Josh Smith, available at the MVVM Foundation (http://mvvmfoundation.codeplex.com/)
</copyright>*/
using System;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace MoPlus.ViewModel.Messaging
{
	/// <summary>
	/// This class is an implementation detail of the MessageToActionsMap class.
	/// </summary>
	///--------------------------------------------------------------------------------
	internal class WeakAction 
	{
		readonly MethodInfo method;
		readonly Type delegateType;
		readonly WeakReference weakRef;
		
		/// <summary>
		/// Constructs a WeakAction
		/// </summary>
		/// <param name="target">The instance to be stored as a weak reference</param>
		/// <param name="method">The Method Info to create the action for</param>
		/// <param name="parameterType">The type of parameter to be passed in the action. Pass null if there is not a paramater</param>
		internal WeakAction(object target, MethodInfo method, Type parameterType)
		{
			//create a Weakefernce to store the instance of the target in which the Method resides
			weakRef = new WeakReference(target);
			
			this.method = method;
			
			// JAS - Added logic to construct callback type.
			if (parameterType == null)
				this.delegateType = typeof(Action);
			else
				this.delegateType = typeof(Action<>).MakeGenericType(parameterType);
		}
			
		/// <summary>
		/// Creates a "throw away" delegate to invoke the method on the target
		/// </summary>
		/// <returns></returns>
		internal Delegate CreateAction()
		{
			object target = weakRef.Target;
			if (target != null)
			{		
				// Rehydrate into a real Action
				// object, so that the method
				// can be invoked on the target.
				return Delegate.CreateDelegate(
				this.delegateType,
				weakRef.Target,
				method);
			}
			else
			{
				return null;
			}
		}
			
		/// <summary>
		/// returns true if the target is still in memory
		/// </summary>
		public bool IsAlive
		{
			get
			{
				return weakRef.IsAlive;
			}
		}
	}
}
