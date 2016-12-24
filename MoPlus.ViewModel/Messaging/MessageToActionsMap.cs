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
	/// This class is an implementation detail of the Mediator class.
	/// This will store all actions to be invoked
	/// </summary>
	///--------------------------------------------------------------------------------
	internal class MessageToActionsMap
	{
		//store a hash where the key is the message and the value is the list of Actions to call
		readonly Dictionary<string, List<WeakAction>> map = new Dictionary<string, List<WeakAction>>();

        /// <summary>
        /// Watch out. This method clears the map. This way we can startover in tests.
        /// </summary>
	    internal void Clear()
	    {
	        map.Clear();
	    }
        
		
		/// <summary>
		/// Adds an action to the list
		/// </summary>
		/// <param name="message">The message to register to </param>
		/// <param name="target">The target object to invoke</param>
		/// <param name="method">The method in the target object to invoke</param>
		/// <param name="actionType">The Type of the action</param>
		internal void AddAction(string message, object target, MethodInfo method, Type actionType)		
		{
			if (message == null)
			throw new ArgumentNullException("message");
			
			if (method == null)
			throw new ArgumentNullException("method");
			
			lock (map)//lock on the dictionary 
			{
				if (!map.ContainsKey(message))
					map[message] = new List<WeakAction>();
				
				map[message].Add(new WeakAction(target, method, actionType));
			}
		}
		
		/// <summary>
		/// Gets the list of actions to be invoked for the specified message
		/// </summary>
		/// <param name="message">The message to get the actions for</param>
		/// <returns>Returns a list of actions that are registered to the specified message</returns>
		internal List<Delegate> GetActions(string message)
		{
			if (message == null)
				throw new ArgumentNullException("message");
			
			List<Delegate> actions;
			lock (map)
			{
				if (!map.ContainsKey(message))
					return null;
				
				List<WeakAction> weakActions = map[message];
				actions = new List<Delegate>(weakActions.Count);
				for (int i = weakActions.Count - 1; i > -1; --i)
				{
					WeakAction weakAction = weakActions[i];
					if (!weakAction.IsAlive)
						weakActions.RemoveAt(i);
					else
						actions.Add(weakAction.CreateAction());
				}
		
				//delete the list from the hash if it is now empty
				if (weakActions.Count == 0)
				map.Remove(message);
			}
			return actions;
		}
	}
}
