using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALTransaction
{
    
    public static async Task<List<BOL.Transaction>> TransactionGetAllAsync()
    {
        List<BOL.Transaction> transactions = new List<BOL.Transaction>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.Transaction>("[dbo].[DebitCardGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return transactions;
        }
    }
}
