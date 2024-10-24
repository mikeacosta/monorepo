using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerRoleId = "1bffdba1-090f-4812-a4b9-5dfa73b69433";
        var writerRoleId = "e72b640d-0ea6-4f4a-834a-97ec616d9c52";

        var roles = new List<IdentityRole>
        {
            new IdentityRole()
            {
                Id = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper(),
                ConcurrencyStamp = readerRoleId
            },
            new IdentityRole()
            {
                Id = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper(),
                ConcurrencyStamp = writerRoleId
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);
        
        // create admin user
        var adminUserId = "173ce7bf-c3e6-4e86-a8d2-11a2b77a93de";
        var admin = new IdentityUser()
        {
            Id = adminUserId,
            UserName = "admin@codepulse.com",
            Email = "admin@codepulse.com",
            NormalizedEmail = "admin@codepulse.com".ToUpper()
        };

        admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

        builder.Entity<IdentityUser>().HasData(admin);

        var adminRoles = new List<IdentityUserRole<string>>()
        {
            new()
            {
                UserId = adminUserId,
                RoleId = readerRoleId
            },
            new()
            {
                UserId = adminUserId,
                RoleId = writerRoleId
            }
        };
        
        builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
    }
}