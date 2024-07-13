using Customers;

namespace CustomerService;

public interface ICustomerRepository
{
    void Create(Customer customer);

    void Delete(long customerId);

    IEnumerable<Customer> GetCustomers();
}