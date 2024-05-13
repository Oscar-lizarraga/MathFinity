using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALDebitCard
{

    public static async Task<List<BOL.DebitCard>> DebitCardGetAllAsync()
    {
        List<BOL.DebitCard> debitCards = new List<BOL.DebitCard>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.DebitCard>("[dbo].[DebitCardGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return debitCards;
        }
    }

    public static async Task<List<BOL.DebitCard>> DebitCardGetByIdAsync(string cardNumber)
    {
        List<BOL.DebitCard> debitCard = new List<BOL.DebitCard>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cardNumber", cardNumber);
                return (await connection.QueryAsync<BOL.DebitCard>("[dbo].[DebitCardGetById]", parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return debitCard;
        }
    }

    public static async Task<List<BOL.DebitCard>> DebitCardLogInAsync(BOL.DebitCard card)
    {
        List<BOL.DebitCard> debitCard = new List<BOL.DebitCard>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cardNumber", card.cardNumber);
                parameters.Add("@NIP", card.NIP);
                return (await connection.QueryAsync<BOL.DebitCard>("[dbo].[DebitCardLogIn]", parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return debitCard;
        }        
    }

    public static async Task<List<BOL.DebitCard>> DebitCardLogInAsyncTest(BOL.DebitCard card)
    {
        List<BOL.DebitCard> debitCard = new List<BOL.DebitCard>();
        string connectionString = new DALDataConnection().GetConnectionString();
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();
                string query = $"SELECT * FROM DebitCard WHERE cardNumber = '{card.cardNumber}' AND NIP = '{card.NIP}'";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        BOL.DebitCard debitCardItem = new BOL.DebitCard();
                        debitCardItem.cardNumber = reader["cardNumber"].ToString()!;
                        debitCardItem.NIP = reader["NIP"].ToString()!;
                        debitCard.Add(debitCardItem);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        return debitCard;
    }
   
}
