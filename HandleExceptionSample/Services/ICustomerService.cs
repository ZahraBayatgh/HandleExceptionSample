using HandleExceptionSample.Contracts.Requests;
using HandleExceptionSample.Domain;

namespace HandleExceptionSample.Services;

public interface ICustomerService
{
    Customer Create(CustomerRequest customerRequest);
    Customer? Get(string email);
}

 
