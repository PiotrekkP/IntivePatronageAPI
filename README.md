# IntivePatronageAPI

How to create database and run project
1. Clone repository and open solution in Visual Studio.
2. In Visual Studio go to Tools -> NuGet Package Manager -> Package Manager Console.
3. Run command Update-Database. It'll create database based on migration file created earlier and stored in Migrations folder.
4. If it's not working, go to appsettings.json and change Server name in "LibraryContext" string to server name that exist on your machine.
5. Then run commands Add-Migration Initial and Update-Database in Package Manager Console.
6. Run project.
