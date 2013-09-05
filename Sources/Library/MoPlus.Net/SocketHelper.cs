/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using MoPlus.Common;

namespace MoPlus.Net
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help support socket operations.</summary>
	///--------------------------------------------------------------------------------
	public static class SocketHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method sends data to a given socket connection, using InterNetwork
		/// and Tcp.</summary>
		///
		/// <param name="ipAddress">The ip address to connect to.</param>
		/// <param name="port">The port to connect to.</param>
		///--------------------------------------------------------------------------------
		public static Socket GetSocketConnection(string ipAddress, int port)
		{
			return GetSocketConnection(ipAddress, port, AddressFamily.InterNetwork, ProtocolType.Tcp);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends data to a given socket connection.</summary>
		///
		/// <param name="ipAddress">The ip address to connect to.</param>
		/// <param name="port">The port to connect to.</param>
		/// <param name="addressFamily">The address family (usually InterNetwork).</param>
		/// <param name="protocolType">The protocol (often tcp).</param>
		///--------------------------------------------------------------------------------
		public static Socket GetSocketConnection(string ipAddress, int port, AddressFamily addressFamily, ProtocolType protocolType)
		{
			Socket newSocket = null;
			try
			{
				// validate ip
				Regex myRegex = new Regex("^(([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.){3}([01]?\\d\\d?|25[0-5]|2[0-4]\\d)$");
				if (myRegex.IsMatch(ipAddress) == false)
				{
					throw new ValidationException("The input " + ipAddress + " is an invalid IP address.");
				}

				// get a socket connection for given ip and port
				newSocket = new Socket(addressFamily, SocketType.Stream, protocolType);
				IPAddress newIP = System.Net.IPAddress.Parse(ipAddress);
				IPEndPoint remoteEP = new IPEndPoint(newIP, port);
				newSocket.Connect(remoteEP);
			}
			catch (Exception ex)
			{
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return newSocket;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends data to a given socket connection.</summary>
		///
		/// <param name="socket">The socket connection.</param>
		/// <param name="buffer">The buffer of data to send.</param>
		/// <param name="offset">The location in the buffer (past bytes sent) to store received data.</param>
		/// <param name="size">The number of bytes to send.</param>
		/// <param name="timeout">The timeout in millisends to perform the operation.</param>
		///--------------------------------------------------------------------------------
		public static void SendSocketData(Socket socket, byte[] buffer, int offset, int size, int timeout)
		{
			int startTickCount = Environment.TickCount;
			int sent = 0;  // how many bytes is already sent
			do
			{
				if (Environment.TickCount > startTickCount + timeout)
					throw new Exception("Timeout in sending socket data.");
				try
				{
					sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
				}
				catch (SocketException ex)
				{
					if (ex.SocketErrorCode == SocketError.WouldBlock ||
						ex.SocketErrorCode == SocketError.IOPending ||
						ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
					{
						// socket buffer is probably full, wait and try again
						Thread.Sleep(30);
					}
					else
						throw;  // any serious error occurs
				}
			} while (sent < size);
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method sends data from a given socket connection.</summary>
		///
		/// <param name="socket">The socket connection.</param>
		/// <param name="buffer">The buffer of data to put received data into.</param>
		/// <param name="offset">The location in the buffer (past bytes already received) to store received data.</param>
		/// <param name="size">The number of bytes to receive.</param>
		/// <param name="timeout">The timeout in millisends to perform the operation.</param>
		///--------------------------------------------------------------------------------
		public static void ReceiveSocketData(Socket socket, byte[] buffer, int offset, int size, int timeout)
		{
			int startTickCount = Environment.TickCount;
			int received = 0;  // how many bytes is already received
			do
			{
				if (Environment.TickCount > startTickCount + timeout)
					throw new Exception("Timeout in receiving socket data.");
				try
				{
					received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
				}
				catch (SocketException ex)
				{
					if (ex.SocketErrorCode == SocketError.WouldBlock ||
						ex.SocketErrorCode == SocketError.IOPending ||
						ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
					{
						// socket buffer is probably empty, wait and try again
						Thread.Sleep(30);
					}
					else
						throw;  // any serious error occurs
				}
			} while (received < size);
		}
		#endregion "Methods"
	}
}
