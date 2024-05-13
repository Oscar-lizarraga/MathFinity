using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALCreditCard
{

    public static async Task<List<BOL.CreditCard>> CreditCardGetAllAsync()
    {
        List<BOL.CreditCard> creditCards = new List<BOL.CreditCard>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.CreditCard>("[dbo].[CreditCardGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return creditCards;
        }
    }

    public static async Task<List<BOL.CreditCard>> CreditCardGetByIdAsync(string cardNumber)
    {
        List<BOL.CreditCard> creditCard = new List<BOL.CreditCard>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cardNumber", cardNumber);
                return (await connection.QueryAsync<BOL.CreditCard>("[dbo].[CreditCardGetById]", parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return creditCard;
        }
    }

    


}
