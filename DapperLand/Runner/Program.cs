using DataLayer;
using Microsoft.Extensions.Configuration;

class Program
{
    private static IConfigurationRoot config;
    
    static void Main(string[] args)
    {
        Console.WriteLine("hey");
    }
    
    private static void Initialize()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        config = builder.Build();
    }

    private static IContactRepository CreateRepository()
    {
        return new ContactRepository(config.GetConnectionString("DefaultConnection"));
    }
}