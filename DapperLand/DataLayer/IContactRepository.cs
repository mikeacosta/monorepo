namespace DataLayer;

public interface IContactRepository
{
    Contact Find(int id);
    List<Contact> GetAll();
    Contact Add(Contact contact);
    Contact Update(Contact contact);
    void Remove(int id);
    int TestQuery(Table1 model);
    int AnotherTest(Table1 model);
}