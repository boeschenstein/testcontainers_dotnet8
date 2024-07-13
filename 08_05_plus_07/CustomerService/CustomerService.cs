using CustomerService;

namespace Customers;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        var customers = _customerRepository.GetCustomers();
        return customers;
    }

    public void Create(Customer customer)
    {
        _customerRepository.Create(customer);
        _customerRepository.SaveChanges();
    }

    public void Delete(long customerId)
    {
        _customerRepository.Delete(customerId);
        _customerRepository.SaveChanges();
    }
}