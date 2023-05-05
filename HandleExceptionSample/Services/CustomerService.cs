using HandleExceptionSample.Contracts.Requests;
using HandleExceptionSample.Domain;
using HandleExceptionSample.Mapping;
using System.ComponentModel.DataAnnotations;

namespace HandleExceptionSample.Services;

public class CustomerService : ICustomerService
{

    private readonly List<Customer> Customers = new List<Customer>
    {
        new()
        {
            Email = "BytZahra@gmail.Com"
        },
        new Customer()
        {
            FullName = "Sara Smith",
            Email = "Sara.Smith@gmail.Com"
        },
        new Customer()
        {
            FullName = "Jeo Deu",
            Email = "Jeo.Deu@gmail.Com"
        },
    };

    public Customer Create(CustomerRequest customerRequest)
    {
        var existingUser = Customers.FirstOrDefault(x => x.Email == customerRequest.Email);
        if (existingUser is not null)
        {
            var message = $"A user with email {customerRequest.Email} already exists";
            throw new ValidationException(message);
        }
        var customer = customerRequest.ToCustomer();

        Customers.Add(customer);

        return customer;
    }

    public Customer? Get(string email)
    {
        var customerDto = Customers.FirstOrDefault(x => x.Email == email);
        return customerDto;
    }

}
