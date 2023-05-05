using System.ComponentModel.DataAnnotations;

namespace HandleExceptionSample.Contracts.Requests;

public class CustomerRequest
{
    public string FullName { get; init; } 

    public string Email { get; init; } 

}
