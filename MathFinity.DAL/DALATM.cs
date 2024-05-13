using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;


namespace MathFinity.DAL;

public class DALATM
{
    public static async Task<List<BOL.ATM>> GetAllATM()
    {
        List<BOL.ATM> atm = new List<BOL.ATM>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<ATM>("ATMGetAll", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return atm;
        }
    }

    public static async Task<List<ATM>> GetATMById(int id)
    {
        List<BOL.ATM> atm = new List<BOL.ATM>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ATMID", id);

                await connection.OpenAsync();
                return (await connection.QueryAsync<ATM>("ATMGetById", parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return atm;
        }
    }

    public static async Task<bool> InsertATMAsync(BOL.ATM atm)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@branchID", atm.branchID);
                parameters.Add("@cashInBox", atm.cashInBox);
                
                if (await connection.ExecuteAsync("ATMInsert", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
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
