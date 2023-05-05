using HandleExceptionSample.Contracts.Requests;
using HandleExceptionSample.Domain;

namespace HandleExceptionSample.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CustomerRequest request)
    {
        return new Customer
        {
            Email = request.Email,
            FullName = request.FullName,
        };
    }

}
