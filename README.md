# Database_First
Database First example
Command:
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=VendasManha;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext

Dont forget to add the packages EntityFrameworkCore.Design, SqlServer, SqlServerDesign, Tools