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
using System.Windows.Input;
using System.ComponentModel;
using MoPlus.Interpreter;
using MoPlus.Interpreter.BLL.Solutions;
using MoPlus.Data;
using System.Collections.ObjectModel;
using MoPlus.ViewModel.Resources;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Events.Entities;
using MoPlus.ViewModel.Events.Solutions;
using MoPlus.Interpreter.BLL.Config;
using MoPlus.ViewModel.Events;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;

namespace MoPlus.ViewModel.Conventions
{
    ///--------------------------------------------------------------------------------
    /// <summary>This class provides the view for some basic help.</summary>
    /// 
    ///--------------------------------------------------------------------------------
	public class HelpViewModel : EditWorkspaceViewModel
    {
		#region "Properties"
		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Title.</summary>
		///--------------------------------------------------------------------------------
		public string Title { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets Name.</summary>
		///--------------------------------------------------------------------------------
		public override string Name
		{
			get
			{
				return Title;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets TabTitle.</summary>
		///--------------------------------------------------------------------------------
		public override string TabTitle
		{
			get
			{
				return Title;
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Image.</summary>
		///--------------------------------------------------------------------------------
		public BitmapImage Image { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets ImageVisibility.</summary>
		///--------------------------------------------------------------------------------
		public string ImageVisibility
		{
			get
			{
				if (Image == null)
				{
					return "Collapsed";
				}
				else
				{
					return "Visible";
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph1.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph1 { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph2.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph2 { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph2Visibility.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph2Visibility
		{
			get
			{
				if (String.IsNullOrEmpty(Paragraph2))
				{
					return "Collapsed";
				}
				else
				{
					return "Visible";
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph3.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph3 { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph3Visibility.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph3Visibility
		{
			get
			{
				if (String.IsNullOrEmpty(Paragraph3))
				{
					return "Collapsed";
				}
				else
				{
					return "Visible";
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph4.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph4 { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph4Visibility.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph4Visibility
		{
			get
			{
				if (String.IsNullOrEmpty(Paragraph4))
				{
					return "Collapsed";
				}
				else
				{
					return "Visible";
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph5.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph5 { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph5Visibility.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph5Visibility
		{
			get
			{
				if (String.IsNullOrEmpty(Paragraph5))
				{
					return "Collapsed";
				}
				else
				{
					return "Visible";
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph6.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph6 { get; set; }

		///--------------------------------------------------------------------------------
		/// <summary>This property gets/sets Paragraph6Visibility.</summary>
		///--------------------------------------------------------------------------------
		public string Paragraph6Visibility
		{
			get
			{
				if (String.IsNullOrEmpty(Paragraph6))
				{
					return "Collapsed";
				}
				else
				{
					return "Visible";
				}
			}
		}

		///--------------------------------------------------------------------------------
		/// <summary>This property gets MenuLabelShow.</summary>
		///--------------------------------------------------------------------------------
		public string MenuLabelShow
		{
			get
			{
				return DisplayValues.Help_Show;
			}
		}

		#endregion "Properties"

		#region "Methods"
		///--------------------------------------------------------------------------------
		/// <summary>This method refreshes the view model.</summary>
		/// 
		/// <param name="refreshChildren">Flag indicating whether children should be refreshed.</param>
		///--------------------------------------------------------------------------------
		public void Refresh(bool refreshChildren, int refreshLevel = 0)
		{
			HasErrors = false;
			HasCustomizations = false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method processes the ShowHelp command.</summary>
		///--------------------------------------------------------------------------------
		public void ProcessShowHelpCommand()
		{
			HelpEventArgs message = new HelpEventArgs();
			message.HelpViewModel = this;
			message.WorkspaceID = WorkspaceID;
			Mediator.NotifyColleagues<HelpEventArgs>(MediatorMessages.Command_ShowHelpRequested, message);
		}

		#endregion "Methods"

		#region "Constructors"

		///--------------------------------------------------------------------------------
		/// <summary>The default constructor (for reflection, etc.).</summary>
		///--------------------------------------------------------------------------------
		public HelpViewModel()
		{
			WorkspaceID = Guid.NewGuid();
		}

		///--------------------------------------------------------------------------------
		/// <summary>Create help content.</summary>
		/// 
		/// <param name="title">The title.</param>
		/// <param name="paragraph1">The first paragraph.</param>
		/// <param name="paragraph2">The second paragraph.</param>
		/// <param name="paragraph3">The third paragraph.</param>
		/// <param name="paragraph4">The fourth paragraph.</param>
		/// <param name="paragraph5">The fifth paragraph.</param>
		/// <param name="paragraph6">The sixth paragraph.</param>
		/// <param name="image">The image.</param>
		///--------------------------------------------------------------------------------
		public HelpViewModel(string title, string paragraph1, string paragraph2 = null, string paragraph3 = null, string paragraph4 = null, string paragraph5 = null, string paragraph6 = null, Bitmap image = null)
		{
			WorkspaceID = Guid.NewGuid();
			ItemID = Guid.NewGuid();
			Title = title;
			Paragraph1 = paragraph1;
			Paragraph2 = paragraph2;
			Paragraph3 = paragraph3;
			Paragraph4 = paragraph4;
			Paragraph5 = paragraph5;
			Paragraph6 = paragraph6;
			if (image != null)
			{
				using (MemoryStream memory = new MemoryStream())
				{
					image.Save(memory, ImageFormat.Png);
					memory.Position = 0;
					Image = new BitmapImage();
					Image.BeginInit();
					Image.StreamSource = memory;
					Image.CacheOption = BitmapCacheOption.OnLoad;
					Image.EndInit();
				}
			}
		}

		#endregion "Constructors"
    }
}
