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

 ## UnitTests
 Install-package Moq

 ## EF Commands

 Default project : src\infrastructure

 Add-Migration InitialIdentity -Context AppIdentityDbContext -OutputDir "Identity/Migrations"
 Update-Database -Context AppIdentityDbContext
 Add-Migration InitialApp -Context ApplicationDbContext -OutputDir "Data/Migrations"
 Update-Database -Context ApplicationDbContext
 ## Links

 https://mdbootstrap.com/docs/b4/jquery/ecommerce/design-blocks/shopping-cart/

 https://stackoverflow.com/questions/65487984/asp-net-core-binding-to-a-dictionary