using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;


namespace MathFinity.DAL;

public class DALProspect
{
    public static async Task<List<BOL.Prospect>> GetAllProspectAsync()
    {
        List<BOL.Prospect> prospect = new List<BOL.Prospect>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.Prospect>("ProspectGetAll", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return prospect;
        }
    }

    public static async Task<List<BOL.Prospect>> GetByIdProspectAsync(int id)
    {
        List<BOL.Prospect> prospect = new List<BOL.Prospect>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@prospectID",id);
                return (await connection.QueryAsync<BOL.Prospect>("ProspectGetById", parameters,  commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return prospect;
        }
    }

    public static async Task<bool> InsertPropectAsync(BOL.Prospect prospect)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@age", prospect.age);
                parameters.Add("@gender", prospect.gender);
                parameters.Add("@married", prospect.married);    
                parameters.Add("@driversLicense", prospect.driversLicense);    
                parameters.Add("@employed", prospect.employed);  
                parameters.Add("@zipCode", prospect.zipCode);  
                parameters.Add("@debt", prospect.debt);  
                parameters.Add("@bankCustomer", prospect.bankCustomer);  
                parameters.Add("@industry", prospect.industry);  
                parameters.Add("@ethnicity", prospect.Ethnicity) ;  
                parameters.Add("@yearsEmployed", prospect.yearsEmployed);  
                parameters.Add("@priorDefault", prospect.priorDefault);  
                parameters.Add("@creditScore", prospect.creditScore);  
                parameters.Add("@citizen", prospect.citizen);  

                if (await connection.ExecuteAsync("ProspectInsert", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
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
