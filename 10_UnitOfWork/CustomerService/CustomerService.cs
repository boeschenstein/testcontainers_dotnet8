using CustomerService;

namespace Customers;

public class CustomerService : ICustomerService
{
    //private readonly ICustomerRepository _customerRepository;
    private readonly IGenericRepository<Customer> _customerRepository;

    private readonly IUnitOfWork _unitOfWork;

    //public CustomerService(ICustomerRepository customerRepository)
    public CustomerService(IGenericRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        var customers = _customerRepository.GetItems();
        return customers;
    }

    public void Create(Customer customer)
    {
        _customerRepository.Create(customer);
        //_customerRepository.SaveChanges();
        _unitOfWork.SaveChanges();
    }

    public void Delete(long customerId)
    {
        _customerRepository.Delete(customerId);
        //_customerRepository.SaveChanges();
        _unitOfWork.SaveChanges();
    }
}