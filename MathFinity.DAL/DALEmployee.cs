using System.Data.SqlClient;
using MathFinity.BOL;
using Dapper;


namespace MathFinity.DAL;

public class DALEmployee
{
    public static async Task<List<Employee>> GetAllEmployessAsync()
    {
        List<Employee> employees = new List<Employee>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Employee>("EmployeeGetAll", commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return employees;
        }
    }

    public static async Task<List<Employee>> GetEmployeeByIdAsync(int id)
    {
        List<Employee> employees = new List<Employee>();
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@employeeID", id);
                await connection.OpenAsync();
                return (await connection.QueryAsync<Employee>("EmployeeGetById", parameters, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return employees;
        }
    }

    public static async Task<bool> InsertEmployeeAsync(BOL.Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@branchID", employee.branchID);
                parameters.Add("@rol", employee.rol);
                parameters.Add("@hiredDate", employee.hiredDate);
                parameters.Add("@firstName", employee.firstName);
                parameters.Add("@lastName", employee.lastName);
                parameters.Add("@birthDate", employee.birthDate);
                parameters.Add("@sex", employee.sex);
                
                if (await connection.ExecuteAsync("EmployeeInsert", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
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

    public static async Task<bool> UpdateEmployee(BOL.Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(new DALDataConnection().GetConnectionString()))
        {
            try
            {
                await connection.OpenAsync();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@employeeID", employee.branchID);
                parameters.Add("@branchID", employee.branchID);
                parameters.Add("@rol", employee.rol);
                parameters.Add("@hiredDate", employee.hiredDate);
                parameters.Add("@firstName", employee.firstName);
                parameters.Add("@lastName", employee.lastName);
                parameters.Add("@birthDate", employee.birthDate);
                parameters.Add("@sex", employee.sex);
                
                if (await connection.ExecuteAsync("EmployeeUpdate", parameters, commandType: System.Data.CommandType.StoredProcedure) == 1)
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
