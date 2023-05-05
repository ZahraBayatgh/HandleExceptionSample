using HandleExceptionSample.Contracts.Responses;
using HandleExceptionSample.Domain;

namespace HandleExceptionSample.Mapping;

public static class DomainToApiContractMapper
{
    public static CustomerResponse ToCustomerResponse(this Customer customer)
    {
        return new CustomerResponse
        {
            Email = customer.Email,
            FullName = customer.FullName,
        };
    }
    
}
