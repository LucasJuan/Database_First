# Database First Example

This is a sample project illustrating the Database First approach in Entity Framework Core.

## Setup

1. Clone the repository.
2. Run the following command to scaffold the database context:

    ```bash
    dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=VendasManha;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext
    ```

   Don't forget to add the packages EntityFrameworkCore.Design, SqlServer, SqlServerDesign, Tools.

3. Build and run the project.

For any additional instructions or details, refer to the project documentation.

---

**Note:** Be sure to customize these instructions according to the specific requirements of your project. Include any additional setup, dependencies, or relevant information so that other developers can understand and use your project.
