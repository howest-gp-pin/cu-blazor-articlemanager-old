# Howest - Graduaat Programmeren
## Programming Innovation
### Blazor: ArticleManager

#### Installing database

* Open Powershell in solution folder
* Entity framework tools
    * install
  
    `dotnet tool install --global dotnet-ef`
    * or update

    `dotnet tool update --global dotnet-ef`

* Create Entity Framework Migration

`dotnet ef migrations add "InitialMigration" -s .\ArticleManager.Api\ -p .\ArticleManager.Infrastructure\`

* Create database

`dotnet ef database update -s .\ArticleManager.Api\ -p .\ArticleManager.Infrastructure\`