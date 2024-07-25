namespace CustomerService;

public interface IGenericRepository<T>
{
    //void SaveChanges();

    void Create(T item);

    void Delete(long itemId);

    IEnumerable<T> GetItems();
}