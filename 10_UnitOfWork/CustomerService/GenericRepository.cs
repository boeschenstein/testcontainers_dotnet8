using CustomerService.EF;

namespace CustomerService;

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    private readonly MyDBContext _myDBContext;

    public GenericRepository(MyDBContext myDBContext)
    {
        CreateCustomersTable();
        _myDBContext = myDBContext;
    }

    //public void SaveChanges()
    //{
    //    _myDBContext.SaveChanges();
    //}

    public IEnumerable<T> GetItems()
    {
        IEnumerable<T> customers;
        try
        {
            customers = _myDBContext.Set<T>().AsEnumerable();
            //customers = _myDBContext.Customers.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("vielleicht erst postgres-db mit cmd starten", ex);
        }
        return customers;
    }

    public void Create(T customer)
    {
        //_myDBContext.Customers.Add(customer);
        _myDBContext.Add(customer);
    }

    public void Delete(long customerId)
    {
        var customer = _myDBContext.Customers.Find(customerId);
        _myDBContext.Customers.Remove(customer);
    }

    private void CreateCustomersTable()
    {
        //using var connection = _dbConnectionProvider.GetConnection();
        //using var command = connection.CreateCommand();
        //command.CommandText = "CREATE TABLE IF NOT EXISTS customers (id BIGINT NOT NULL, name VARCHAR NOT NULL, PRIMARY KEY (id))";
        //command.Connection?.Open();
        //command.ExecuteNonQuery();
    }
}