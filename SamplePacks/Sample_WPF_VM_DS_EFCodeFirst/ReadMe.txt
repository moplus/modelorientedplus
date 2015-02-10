This template library provides the ability to generate a working solution with either a forward and/or reverse engineered model with the following layers:
1) An Entity Framework code first layer.
2) A WCF Data Services layer using entity framework.
3) A View Model layer that is a client of the WCF service layer.
4) A WPF Admin ui that uses the view model layer to perform admin operations.
5) Optionally, a unit test layer that tests entity framework operations.

To use this template library:

1) Create a solution in Mo+, choose the SolutionFile template.
2) Create an entity framework project, tag as "BLL", and use EFCF template.
3) Create a wcf data services project, tag as "DS", reference project above, and use EFDataServices template.
4) Create a view model project, tag as "VM", reference project above, and use VMEFDS template.
5) Create a wpf ui project, reference project above, and use WPFUI template.
6) Optionally, create unit test project, reference entity framework project, and use EFCFUnitTests template.
7) Create and/or load your model, and generate your solution!  You will likely need to compile your data services project first, and then update service reference in your view model project to get the solution going.  Nuget packages should be updated automatically.

Note: See configuration parameters in SolutionFile template if you want to generate a solution for earlier versions of Visual Studio.

Comment on the contribution post if you have any issues or suggestions on improving this template library!