For proper running of EF migrations is necessary to install
also package `Microsoft.EntityFrameworkCore.Design` to `RrNetBack.API` project

Create migration:  
`dotnet ef migrations add init -s ./RrNetBack.API/  -p ./RrNetBack.DAL`