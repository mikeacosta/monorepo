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
        
        // GetAllContacts();
        InsertContact();
    }

    static int InsertContact()
    {
        // arrange
        var repository = CreateRepository();
        var contact = new Contact()
        {
            FirstName = "Joe",
            LastName = "Blow",
            Email = "joe.blow@gmail.com",
            Company = "Microsoft",
            Title = "Developer"
        };

        // act
        repository.Add(contact);
        
        // assert
        Debug.Assert(contact.Id != 0);
        Console.WriteLine("*** Contact inserted ***");
        Console.WriteLine($"New ID: {contact.Id}");
        return contact.Id;
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