using System.Diagnostics;

using CustomerService;

using MediatR;

namespace Customers;

public class CustomerService : ICustomerService
{
    //private readonly ICustomerRepository _customerRepository;
    private readonly IGenericRepository<Customer> _customerRepository;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    //public CustomerService(ICustomerRepository customerRepository)
    public CustomerService(IGenericRepository<Customer> customerRepository, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
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

    public async Task CreateAsync(Customer customer)
    {
        var response = await _mediator.Send(new Ping());
        Debug.WriteLine(response); // "Pong"

        _customerRepository.Create(customer);
        //_customerRepository.SaveChanges();
        await _unitOfWork.SaveChangesAsync();
    }

    public void Delete(long customerId)
    {
        _customerRepository.Delete(customerId);
        //_customerRepository.SaveChanges();
        _unitOfWork.SaveChanges();
    }
}

public class Ping : IRequest<string>
{ }

public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}