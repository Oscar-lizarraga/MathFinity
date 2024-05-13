using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;


namespace MathFinity.DAL;

public class DALBranch
{
    public static async Task<List<BOL.Branch>> GetAllBranchAsync()
    {
        List<BOL.Branch> branch = new List<BOL.Branch>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Branch>("BranchGetAll", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return branch;
        }
    }

    public static async Task<List<Branch>> GetBranchByIdAsync(int id)
    {
        List<BOL.Branch> branch = new List<BOL.Branch>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@branchID", id);
                return (await connection.QueryAsync<Branch>("BranchGetById", parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return branch;
        }
    }

    public static async Task<bool> InsertBranchAsync(BOL.Branch branch)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@address", branch.address);
                parameters.Add("@name", branch.address);

                if (await connection.ExecuteAsync("BranchInsert", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
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
