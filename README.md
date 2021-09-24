 #  WatchShop

 A sample ASP.NET Project with Clean Architecture based on https://github.com/dotnet-architecture/eShopOnWeb

 ## Packages Installed

 ## Web

 ## Infrastructure

 Install-package Microsoft.EntityFrameworkCore\
 Install-package Npsql.EntityFrameworkCore.PostgreSQL\
 Install-Package Ardalis.Specification.EntityFrameworkCore\
 Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore


 ## ApplicationCore

 Install-package Ardalis.Specification
 ## EF Commands

 Default project : src\infrastructure

 Add-Migration InitialIdentity -Context AppIdentityDbContext -OutputDir "Identity/Migrations"
 Update-Database -Context AppIdentityDbContext
 Add-Migration InitialApp -Context ApplicationDbContext -OutputDir "Data/Migrations"
 Update-Database -Context ApplicationDbContext