using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;

namespace MathFinity.DAL;

public class DALCustomer
{
    public static async Task<List<BOL.Customer>> CustomerGetAllAsync()
    {
        List<BOL.Customer> customer = new List<BOL.Customer>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<BOL.Customer>("[dbo].[CustomerGetAll]", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return customer;
        }
    }

    public static async Task<List<BOL.Customer>> CustomerGetByIdAsync(string id)
    {
        List<BOL.Customer> customer = new List<BOL.Customer>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customerID", id);
                return (await connection.QueryAsync<BOL.Customer>("CustomerGetById",  parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return customer;
        }
    }

    public static async Task<bool> EditCustomerAsync(BOL.Customer customer)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customerID", customer.customerID);
                parameters.Add("@phone", customer.phone);
                parameters.Add("@address", customer.address);

                if (await connection.ExecuteAsync("CustomerEdit",  parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
                    return true;
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return true;
        }
    }





}
