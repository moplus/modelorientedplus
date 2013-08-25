/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Code written by Marlon Grech and Josh Smith, available at the MVVM Foundation (http://mvvmfoundation.codeplex.com/)
</copyright>*/
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MoPlus.ViewModel.Messaging
{
	///--------------------------------------------------------------------------------
	/// <summary>
	/// Provides loosely-coupled messaging between
	/// various colleagues.  All references to objects
	/// are stored weakly, to prevent memory leaks.
	/// </summary>
	///--------------------------------------------------------------------------------
	public class Mediator
	{
		readonly MessageToActionsMap invocationList = new MessageToActionsMap();

        /// <summary>
        /// Be careful, this method resets the InvocationList. That way all registered handlers are removed.
        /// </summary>
	    internal void Clear()
	    {
	        invocationList.Clear();
	    }

		/// <summary>
		/// Register a ViewModel to the mediator notifications
		/// This will iterate through all methods of the target passed and will register all methods that are decorated with the MediatorMessageSink Attribute
		/// </summary>
		/// <param name="target">The ViewModel instance to register</param>
		public void Register(object target)
		{
			if (target == null)
				throw new ArgumentNullException("target");

			//Inspect the attributes on all methods and check if there are RegisterMediatorMessageAttribute
			foreach (var methodInfo in target.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
				foreach (MediatorMessageSinkAttribute attribute in methodInfo.GetCustomAttributes(typeof(MediatorMessageSinkAttribute), true))
					if (methodInfo.GetParameters().Length == 1)
						invocationList.AddAction(attribute.Message, target, methodInfo, attribute.ParameterType);
					else
						throw new InvalidOperationException("The registered method should only have 1 parameter since the Mediator has only 1 argument to pass");
		}

		/// <summary>
		/// Registers a specific method to the Mediator notifications
		/// </summary>
		/// <param name="message">The message to register to</param>
		/// <param name="callback">The callback function to be called when this message is broadcasted</param>
		public void Register(string message, Delegate callback)
		{
			//This method is not supported in Silverlight
#if SILVERLIGHT
            throw new InvalidOperationException("This method is not supported in Silverlight");
#endif

            // we use the callback.Target value as the target of a WeakReference to automatically remove 
            // registered actions when the containing objects are garbage collected.
			if (callback.Target == null)
				throw new InvalidOperationException("Delegate cannot be static");

			ParameterInfo[] parameters = callback.Method.GetParameters();

			// JAS - Changed this logic to allow for 0 or 1 parameter.
			if (parameters != null && parameters.Length > 1)
				throw new InvalidOperationException("The registered delegate should only have 0 or 1 parameter since the Mediator has up to 1 argument to pass");

			// JAS - Pass in the parameter type.
			Type parameterType = (parameters == null || parameters.Length == 0) ? null : parameters[0].ParameterType;
			invocationList.AddAction(message, callback.Target, callback.Method, parameterType);
		}

		/// <summary>
		/// Notify all registered parties that a specific message was broadcasted
		/// </summary>
		/// <typeparam name="T">The Type of parameter to be passed</typeparam>
		/// <param name="message">The message to broadcast</param>
		/// <param name="parameter">The parameter to pass together with the message</param>
		public void NotifyColleagues<T>(string message, T parameter)
		{
		    DoNotifyColleagues<T>(message, new object[]
		                                   {
		                                       parameter
		                                   });
		}

		/// <summary>
		/// Notify all registered parties that a specific message was broadcasted
		/// </summary>
		/// <typeparam name="T">The Type of parameter to be passed</typeparam>
		/// <param name="message">The message to broadcast</param>
		public void NotifyColleagues<T>(string message)
		{
		    DoNotifyColleagues<T>(message, null);
		}

	    private void DoNotifyColleagues<T>(string message, object[] arguments)
	    {
            var actions = invocationList.GetActions(message);

	        bool handled = false;
	        if (actions != null)
	        {
	            actions.ForEach(action =>
	                            {
	                                handled = true;
	                                action.DynamicInvoke(arguments);
	                            });
	        }
	        if (!handled)
	        {
	            var handler = MessageUnhandled;
	            if (handler != null)
	            {
	                handler(typeof(T), message, arguments);
	            }
	        }
	    }

	    public event Action<Type, string, object[]> MessageUnhandled;
	}
}
