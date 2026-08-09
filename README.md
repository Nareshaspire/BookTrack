# BookTrack
# BookTrack Application 
1)models using er
2)Scaffolding
3)migrations
 
What this is
A small ASP.NET Core Razor Pages web app for tracking books with a simple EF Core-backed data model and scaffolded CRUD pages — intended for developers or hobbyists who want a lightweight book-tracking UI and codebase to extend.

Stack
Language(s): C#, HTML, CSS (minor JavaScript)
Framework / runtime: ASP.NET Core (Razor Pages)
Notable libraries / patterns: Entity Framework Core (DbContext + Migrations), Razor Pages / Tag Helpers, configuration via appsettings.json
How it's organized
Code
.gitattributes
.gitignore
BookTrack.sln                Solution file
README.md
BookTrack/                   Main web app project
  BookTrack.csproj           .NET project manifest
  Program.cs                 app startup (host + middleware)
  appsettings.json
  appsettings.Development.json
  Data/
    BookTrackContext.cs      EF Core DbContext (persistence)
  Migrations/                EF Core migrations (InitialCreate)
    20220818132631_InitialCreate.cs
    BookTrackContextModelSnapshot.cs
  Models/
    Book.cs                  Book entity/model
  Pages/                     Razor Pages UI
    Index.cshtml(.cs)        Home page
    Privacy.cshtml(.cs)
    Error.cshtml(.cs)
    Books/                   Scaffolded CRUD pages for Book
      Create.cshtml(.cs)
      Delete.cshtml(.cs)
      Details.cshtml(.cs)
      Edit.cshtml(.cs)
      Index.cshtml(.cs)
    Shared/
      _Layout.cshtml          Site layout
      _ValidationScriptsPartial.cshtml
      _Layout.cshtml.css
  Properties/
  wwwroot/
    css/
    js/
    lib/
    favicon.ico
How it fits together: Program.cs configures ASP.NET Core services and registers the EF Core DbContext from BookTrack/Data/BookTrackContext.cs. The Pages/Books folder contains scaffolded Razor Page handlers (Index/Create/Edit/Details/Delete) that use the Book model (Models/Book.cs) and the DbContext to perform CRUD. EF Core migrations in Migrations/ capture the database schema and let you apply it at runtime or via CLI.

How to run it
Shortest path from a fresh clone:

Install .NET SDK matching the project (any recent .NET 6/7+ SDK should work for Razor Pages projects).
From the repo root:
Code
cd BookTrack
dotnet restore
dotnet ef database update        # optional: apply EF migrations (requires dotnet-ef/tools & a configured connection string)
dotnet run
Or run the project directly:

Code
dotnet run --project BookTrack/BookTrack.csproj
Notes:

Check BookTrack/appsettings.json (and appsettings.Development.json) for the database connection string or other required configuration before running migrations.
If you don't have dotnet-ef installed globally, you can add the EF tools or run migrations via Visual Studio or dotnet tool approaches.
