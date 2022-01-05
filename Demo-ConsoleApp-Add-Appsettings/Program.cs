using Microsoft.Extensions.Configuration;
using System;

namespace Demo_ConsoleApp_Add_Appsettings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"{nameof(environmentVariable)} : {environmentVariable}");

            var currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine($"{nameof(currentDirectory)} : {currentDirectory}");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentVariable}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var environment = configuration["Environment"];
            Console.WriteLine($"get setting : {environment}");

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
