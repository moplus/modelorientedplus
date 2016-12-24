/*<copyright>
Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
</copyright>*/
// Guids.cs
// MUST match guids.h
using System;

namespace MoPlus.SolutionBuilder.VSPackage
{
    static class GuidList
    {
		public const string guidMoPlusPkgString = "8fe4675c-3156-4a6a-9b35-d7cc6f4ee432";
        public const string guidMoPlusCmdSetString = "4ab55362-3ddd-4244-b8ba-bcab8cc2bbc7";
		public const string guidSolutionBuilderWindowPersistanceString = "b2a086f1-775d-4f60-bb81-202c23fea3af";
		public const string guidSolutionDesignerWindowPersistanceString = "D02CD70D-1F36-45cb-B837-BE33C62B5839";
		public const string guidInCodeMenuCmdString = "14DE0EFA-3C8D-429c-90D3-11FEF530A3CD";

        public static readonly Guid guidMoPlusCmdSet = new Guid(guidMoPlusCmdSetString);
		public static readonly Guid guidInCodeMenuCmdSet = new Guid(guidInCodeMenuCmdString);
	};
}