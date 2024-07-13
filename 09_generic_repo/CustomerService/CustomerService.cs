using CustomerService;

namespace Customers;

public class CustomerService : ICustomerService
{
    //private readonly ICustomerRepository _customerRepository;
    private readonly IGenericRepository<Customer> _customerRepository;

    //public CustomerService(ICustomerRepository customerRepository)
    public CustomerService(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        var customers = _customerRepository.GetItems();
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