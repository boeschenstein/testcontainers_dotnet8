namespace Customers;

public interface ICustomerService
{
    void Create(Customer customer);

    void Delete(long customerId);

    IEnumerable<Customer> GetCustomers();
}