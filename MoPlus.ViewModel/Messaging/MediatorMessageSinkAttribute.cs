/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

Code written by Marlon Grech and Josh Smith, available at the MVVM Foundation (http://mvvmfoundation.codeplex.com/)
</copyright>*/
using System;

namespace MoPlus.ViewModel.Messaging
{
	///--------------------------------------------------------------------------------
	/// <summary>
	/// Attribute to decorate a method to be registered to the Mediator
	/// </summary>
	///--------------------------------------------------------------------------------
	[AttributeUsage(AttributeTargets.Method)]
	public class MediatorMessageSinkAttribute : Attribute
	{
		/// <summary>
		/// The message to register to 
		/// </summary>
		public string Message { get; private set; }
		
		/// <summary>
		/// The type of parameter for the Method
		/// </summary>
		public Type ParameterType { get; set; }
		
		/// <summary>
		/// Constructs a method
		/// </summary>
		/// <param name="message">The message to subscribe to</param>
		public MediatorMessageSinkAttribute(string message)
		{
			Message = message;
		}
	}
}
