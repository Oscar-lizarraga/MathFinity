using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALTransfer
{
    public static async Task<List<BOL.Transfer>> TransactionGetAllAsync()
    {
        List<BOL.Transfer> transactions = new List<BOL.Transfer>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.Transfer>("[dbo].[TransferGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return transactions;
        }
    }

    public static async Task<List<BOL.Transfer>> TransactionGetById(int id)
    {
        List<BOL.Transfer> transactions = new List<BOL.Transfer>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.Transfer>("[dbo].[TransactionGetById]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return transactions;
        }
    }







}
