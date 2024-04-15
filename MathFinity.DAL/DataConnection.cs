using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;


namespace MathFinity.DAL;

public class DataConnection
{
    private readonly string _connectionString;

    public DataConnection()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("SQLserverconnection")!;
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Cadena de conexión no encontrada en el archivo de configuración.");
        }
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }
}
