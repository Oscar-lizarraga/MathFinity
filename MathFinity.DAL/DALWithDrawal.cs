using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALWithDrawal
{
    
    public static async Task<bool> InterestUpdateAsync(BOL.Interest interest)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@interestID", interest.interestID);
                parameters.Add("@approvedCreditCard", interest.approvedCreditCard);
                parameters.Add("@approvedDebitCard", interest.approvedDebitCard);
                
                if (await connection.ExecuteAsync("[dbo].[InterestUpdate]", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
                    return true;
                else
                    return false;    
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return false;
            }
        }
    }

    public static async Task<bool> InterestInsertAsync()
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                if (await connection.ExecuteAsync("[dbo].[InterestInsert]", commandType: System.Data.CommandType.StoredProcedure) == 1)
                    return true;
                else
                    return false;    
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return false;
            }
        }
    }

    public static async Task<List<Interest>> InterestGetAllAsync()
    {
        List<Interest> interests = new List<Interest>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Interest>("[dbo].[InterestGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return interests;
        }
    }
}
