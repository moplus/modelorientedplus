/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using MoPlus.Common;

namespace MoPlus.Net
{
	///--------------------------------------------------------------------------------
	/// <summary>The methods in this class are to be used to help support mail operations.</summary>
	///--------------------------------------------------------------------------------
	public static class MailHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method sends a mail message, including attachments if provided.
		/// HTML content is allowed.</summary>
		///
		/// <param name="sendFrom">The email address of the sender.</param>
		/// <param name="sendTo">The email addresses of the recipients.</param>
		/// <param name="subject">The subject of the message.</param>
		/// <param name="message">The message body (HTML allowed).</param>
		/// <param name="attachmentPaths">An array of paths to the attachments, if any.</param>
		/// 
		/// <returns>True if successful.</returns>
		///--------------------------------------------------------------------------------
		public static bool SendMail(string sendFrom, string sendTo, string subject, string message, string[] attachmentPaths)
        {
			bool isMessageSent = true;
            try
            {                
                // create the mail message
				MailMessage mailMessage = new MailMessage(sendFrom, sendTo);
				mailMessage.BodyEncoding = Encoding.UTF8;
				mailMessage.Subject = subject;
				mailMessage.Body = message;
				mailMessage.Priority = MailPriority.High;
				mailMessage.IsBodyHtml = true;

				// add attachments, if any
				foreach (string loopAttachmentURL in attachmentPaths)
				{
					Attachment at = new Attachment(HttpContext.Current.Server.MapPath(loopAttachmentURL));
					mailMessage.Attachments.Add(at);
				}

                //prepare to send mail via SMTP transport
                SmtpClient smtpClient = new SmtpClient();
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
				smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
				isMessageSent = false;
				bool reThrow = ExceptionHandler.HandleException(ex);
				if (reThrow) throw;
			}
			return isMessageSent;
        }
	
		#endregion "Methods"
	}
}
