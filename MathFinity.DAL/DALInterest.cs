using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALInterest
{
    public static async Task<List<Interest>> GetAllInterestAsync()
    {
        List<Interest> interest = new List<Interest>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Interest>("InterestGetAll", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return interest;
        }
    }
        
    public static async Task<bool> UpdateInterest(BOL.Interest interest)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@interestID", interest.interestID);
                parameters.Add("@approvedDebitCard", interest.approvedDebitCard);
                parameters.Add("@approvedCreditCard", interest.approvedCreditCard);
                
                if (await connection.ExecuteAsync("InterestUpdate", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
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


}
