using Customers;

namespace CustomerService;

public interface ICustomerRepository
{
    void SaveChanges();

    void Create(Customer customer);

    void Delete(long customerId);

    IEnumerable<Customer> GetCustomers();
}