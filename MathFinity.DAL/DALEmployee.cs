using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;


namespace MathFinity.DAL;

public class DALEmployee
{
    public static async Task<List<Employee>> EmployeeGetAllAsync()
    {
        List<Employee> employees = new List<Employee>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Employee>("EmployeeGetAll", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return employees;
        }
    }

    

}
