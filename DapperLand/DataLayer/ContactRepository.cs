using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using Dapper;

namespace DataLayer;

public class ContactRepository : IContactRepository
{
    private IDbConnection db;

    public ContactRepository(string connString)
    {
        this.db = new SqlConnection(connString);
    }
    
    public Contact Find(int id)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetAll()
    {
        return this.db.Query<Contact>("SELECT * FROM Contacts").ToList();
    }

    public Contact Add(Contact contact)
    {
        var sql =
            "INSERT INTO Contacts (FirstName, LastName, Email, Company, Title) VALUES(@FirstName, @LastName, @Email, @Company, @Title); " +
            "SELECT CAST(SCOPE_IDENTITY() as int)";
        var id = this.db.Query<int>(sql, contact).Single();
        contact.Id = id;
        return contact;
    }

    public Contact Update(Contact contact)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}