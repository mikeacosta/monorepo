using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;
using CoreLibrary.Data.Dapper.Context;
using CoreLibrary.Data.Dapper.Query;
using Dapper;

namespace DataLayer;

public class ContactRepository : IContactRepository
{
    // private IDbConnection db;
    private readonly string _connString;

    public ContactRepository(string connString)
    {
        // this.db = new SqlConnection(connString);
        _connString = connString;
    }
    
    public Contact Find(int id)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetAll()
    {
        // return this.db.Query<Contact>("SELECT * FROM Contacts").ToList();
        var sql = "SELECT * FROM Contacts";
        var query = new QueryPacket(sql, "ContactsDB");
        var dataContext = new DataContext(_connString);
        var result = dataContext.GetRows<Contact>(query).ToList();
        return result;
    }

    public Contact Add(Contact contact)
    {
        // var sql =
        //     "INSERT INTO Contacts (FirstName, LastName, Email, Company, Title) VALUES(@FirstName, @LastName, @Email, @Company, @Title); " +
        //     "SELECT CAST(SCOPE_IDENTITY() as int)";
        // var id = this.db.Query<int>(sql, contact).Single();
        // contact.Id = id;
        // return contact;
        throw new NotImplementedException();
    }

    public Contact Update(Contact contact)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public int TestQuery(Table1 model)
    {
        var sql = @"BEGIN TRANSACTION;
                    UPDATE table1 SET name = @Name WHERE id = @Id
                    IF @@ROWCOUNT = 0
                        BEGIN
                            DECLARE @InsertedId table ( ID int )
                            DECLARE @Number int
                            INSERT INTO table1 (name) OUTPUT INSERTED.ID INTO @InsertedId VALUES (@Name)
                            SELECT @Number = (select ID from @InsertedId)
                            INSERT INTO table2 (name, number) VALUES (@Name, @Number)
                            SELECT @Number
                        END
                        COMMIT TRANSACTION;";
        
        var sql2 = @"UPDATE table1 SET name = @Name OUTPUT INSERTED.ID WHERE id = @Id
                    IF @@ROWCOUNT = 0
                        INSERT INTO table1 (name) OUTPUT INSERTED.ID VALUES (@Name)";        
        var query = new QueryPacket(sql, new { model.Id, model.Name }, "ContactsDB");
        var dataContext = new DataContext(_connString);
        var result = dataContext.ExecuteScalar<int>(query, CommandType.Text);
        return result;
    }

    public int AnotherTest(Table1 model)
    {
        var sql = "INSERT INTO table1 (name) OUTPUT INSERTED.ID VALUES (@Name)";
        var query = new QueryPacket(sql, new { model.Id, model.Name }, "ContactsDB");
        var dataContext = new DataContext(_connString);
        var result = dataContext.ExecuteScalar<int>(query, CommandType.Text);
        return result;
    }
}