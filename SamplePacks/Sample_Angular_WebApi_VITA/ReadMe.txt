This Mo+ template library provides support for developing applications with the VITA ORM and .net Application Framework (vita.codeplex.com).

The template library provides the ability to generate a working solution with either a forward and/or reverse engineered model with the following layers:
1) An MVC/AngularJS single page web application (admin tool) (VITAUI project template).
2) A VITA WebApi data services layer (VITADataServices project template).
3) A Test layer to test VITA ORM operations (VITAUnitTests project template).
4) A VITA ORM data management layer (VITA project template).
5) Optionally, an MVC/AngularJS single page web application public site (stubs) (VITAPublicUI project template).

To use this template library to create a working application with tests:

1) Download and install Mo+ if you have not already done so.  Downloads available at moplus.codeplex.com.  This site also has links to articles and videos to learn more.
1) Create a solution in Mo+, choose the SolutionFile template (you can use the attached BasicVITA.xml file as a starting point).
2) Create a VITA ORM data management project, tag as "BLL", and use VITA project template.
3) Create a VITA Web Api project, tag as "DS", reference project above, and use VITADataServices template.
4) Create an MVC/AngularJS SPA project, reference project above, and use VITAUI template.
5) Create a test project, reference VITA ORM project, and use VITAUnitTests template.
6) Create and/or load your model, and generate your solution!  For the first time you generate your solution, you will need to restore angular and other javascript files by using the following command in the package manager console: "update-package -reinstall -project NNN", where NNN is the name of your ui project.

View CONFIG category templates that can enable you to tailor how your solution is generated.  VITA_ADD_NNN_MODULE templates allow you to choose which VITA modules to include.  BRACE_SAMELINE allows you to tailor the bracing style you prefer.

These templates are meant to be a good starting point for the work you need to do on real projects.  You are encouraged to modify and add to these templates as you need to.  Tag elements in your model to trigger exceptions in how your code needs to be generated.  Make use of partial classes and protected areas to integrate with your custom code.

Finally, become a member at modelorientedplus.com if you are not already!  As a Mo+ member, you have free access to additional support and additional items contributed by Mo+ members.