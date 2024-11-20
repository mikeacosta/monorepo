using Company.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    } 
    
    public DbSet<Entities.Company> Companies { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Entities.Company>()
            .HasData(
                new Entities.Company
                {
                    Id = 1,
                    Name = "Acme Widgets"
                },
                new Entities.Company
                {
                    Id = 2,
                    Name = "AWS"
                }
            ); 

        modelBuilder.Entity<Address>()
            .HasData(
                new Address
                {
                    Id = 1,
                    Address1 = "123 Main Street",
                    City = "Centerville",
                    State = "OH",
                    PostalCode = "12345",
                    Country = "USA",
                    CompanyId = 1
                },
                new Address
                {
                    Id = 2,
                    Address1 = "475 Sansome Street",
                    City = "San Francisco",
                    State = "CA",
                    PostalCode = "94111",
                    Country = "USA",
                    CompanyId = 2
                }
            );
        
        modelBuilder.Entity<Contact>()
            .HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Blow",
                    Email = "joe@blow.com",
                    CompanyId = 1
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Claudia",
                    LastName = "Cloud",
                    Email = "ccloud@aws.com",
                    CompanyId = 2
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Sarah",
                    LastName = "Serverless",
                    Email = "sarah@aws.com",
                    CompanyId = 2
                }                
            );         
        
        base.OnModelCreating(modelBuilder);
    }   
}