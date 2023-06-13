using System.Diagnostics;
using System.Reflection;
using DataLayer;
using Microsoft.Extensions.Configuration;

namespace Runner;

class Program
{
    private static IConfigurationRoot config;
    
    static void Main(string[] args)
    {
        Initialize();
        
        GetAllContacts();
    }
    
    static void GetAllContacts()
    {
        // arrange
        var repository = CreateRepository();

        // act
        var contacts = repository.GetAll();

        // assert
        Console.WriteLine($"Count: {contacts.Count}");
        Debug.Assert(contacts.Count == 6);
        contacts.Output();
    }
    
    private static void Initialize()
    {
        var workingDir = Environment.CurrentDirectory;  // /bin/Debug
        var basePath = Directory.GetParent(workingDir).Parent.Parent.FullName;  // project dir
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        config = builder.Build();
    }

    private static IContactRepository CreateRepository()
    {
        var connStr = config.GetConnectionString("DefaultConnection");
        return new ContactRepository(connStr);
    }
}