using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALCurrentAccount
{
    public static async Task<List<BOL.CurrentAccount>> CurrentAccountGetAllAsync()
    {
        List<BOL.CurrentAccount> currentAccount = new List<BOL.CurrentAccount>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.CurrentAccount>("[dbo].[CurrentAccountGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return currentAccount;
        }
    }

    public static async Task<List<BOL.CurrentAccount>> CurrentAccountGetByIdAsync(string accountNumber)
    {
        List<BOL.CurrentAccount> currentAccount = new List<BOL.CurrentAccount>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@accountNumber", accountNumber);
                return (await connection.QueryAsync<BOL.CurrentAccount>("[dbo].[CurrentAccountGetById]",  parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return currentAccount;
        }
    }


    
}
