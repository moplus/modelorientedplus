*************************************************************************************

License

*************************************************************************************

Mo+ Solution Builder is a model oriented programming language and IDE, used for building models and generating code and other documents in a model driven development process.

Copyright (C) 2013 Dave Clemmer, Intelligent Coding Solutions, LLC


This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.


*************************************************************************************

Sample Packs

*************************************************************************************

Sample packs contain libraries of code templates that allow you to generate various types of applications and compoents, and spec templates that allow you to automatically load your models from sources such as databases and xml.

Sample packs are a quick way to get started using the Mo+ Solution Builder to start generating some code.  You can use these templates as a starting point to create or modify templates to suit your needs.

The sample packs do not fall under the Mo+ GPL licensed software.  As with any other materials generated using Mo+ tools, you are free to use, modify, and repurpose for any of your needs, public and private.


*************************************************************************************

Code Templates

*************************************************************************************

Code templates are found in the Templates folder within a sample pack, further organized by language and/or platform, etc.  Code templates have an extension of .mpt.

To load a set of code templates into a new solution for viewing, editing, debugging, and general use:

- In the Mo+ Solution Builder, create a new solution (right click on Solutions folder).

- For the Template Path, select a solution level code template found at the highest level in a template folder (such as SolutionFile.mpt or ReportingTest.mpt).

- Update the solution (save the edits).

Mo+ Solution Builder will then load all of the code templates from the selected template directory (including sub directories).  You can see these templates under the Code Templates folder for your solution in the tree view.

Each time you open a solution that is already linked to a code template, the code templates will be automatically loaded.


*************************************************************************************

Spec Templates

*************************************************************************************

Spec templates are found in the Specifications folder within a sample pack, further organized by source type, etc.  Spec templates have an extension of .mps.

To load a set of database spec templates into a solution for viewing, editing, debugging, and general use:

- In the Mo+ Solution Builder, open a solution and create a database source (right click on Specification Sources folder).

- For the Template Path, select a specification source level spec template found at the highest level in a MySQL or SQLServer folder (such as MDLSqlModel.mps).

- Update the database source (save the edits).

Mo+ Solution Builder will then load all of the spec templates from the selected specification directory (including sub directories).  You can see these templates under the Spec Templates folder for your solution in the tree view.

Each time you open a solution that is already linked to spec templates, the spec templates will be automatically loaded.