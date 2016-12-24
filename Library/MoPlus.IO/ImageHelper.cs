/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MoPlus.IO
{
	///--------------------------------------------------------------------------------
	/// <summary>This class is used to help perform typical image operations.</summary>
	///--------------------------------------------------------------------------------
	public static class ImageHelper
	{
		#region "Fields and Properties"
		#endregion "Fields and Properties"

		#region "Methods"

		///--------------------------------------------------------------------------------
		/// <summary>This method gets an image from a file.</summary>
		///
		/// <param name="inputFilePath">The input image file path.</param>
		///--------------------------------------------------------------------------------
		public static Image GetImageFromFile(string inputFilePath)
		{
			Image newImage = null;
			try
			{
				newImage = Image.FromFile(inputFilePath);
			}
			catch (OutOfMemoryException)
			{
				throw new ApplicationException("The input file (" + inputFilePath + ") is not a valid image file.");
			}
			return newImage;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resizes an image to the given width and height.</summary>
		///
		/// <param name="inputFilePath">The input image file path.</param>
		/// <param name="newWidth">The new width of the image.</param>
		/// <param name="newHeight">The new height of the image.</param>
		/// <param name="outputFilePath">The output image file path.</param>
		/// 
		/// <returns>Returns true if image is resized.</returns>
		///--------------------------------------------------------------------------------
		public static bool ResizeImage(string inputFilePath, int newWidth, int newHeight, string outputFilePath)
		{
			Image resizedImage = ResizeImage(inputFilePath, newWidth, newHeight);
			if (resizedImage != null)
			{
				resizedImage.Save(outputFilePath);
				return true;
			}
			return false;
		}

		///--------------------------------------------------------------------------------
		/// <summary>This method resizes an image to the given width and height.</summary>
		///
		/// <param name="inputFilePath">The input image file path.</param>
		/// <param name="newWidth">The new width of the image.</param>
		/// <param name="newHeight">The new height of the image.</param>
		///--------------------------------------------------------------------------------
		public static Image ResizeImage(string inputFilePath, int newWidth, int newHeight)
		{
			// get the image
			Image image = GetImageFromFile(inputFilePath);
			Image thumbnail = null;

			if (image != null)
			{
				// set up thumbnail and graphic for resizing
				thumbnail = new Bitmap(newWidth, newHeight);
				Graphics graphic = Graphics.FromImage(thumbnail);

				// set graphic settings for higher quality resizing
				graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphic.SmoothingMode = SmoothingMode.HighQuality;
				graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphic.CompositingQuality = CompositingQuality.HighQuality;

				// draw the resized image
				graphic.DrawImage(image, 0, 0, newWidth, newHeight);
			}

			// return image
			return thumbnail;
		}
		#endregion "Methods"

	}
}
