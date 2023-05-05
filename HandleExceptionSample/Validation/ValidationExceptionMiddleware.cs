using System.ComponentModel.DataAnnotations;
using System.Net;

namespace HandleExceptionSample.Validation;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsJsonAsync(new
            {
                Status = (int)HttpStatusCode.Unauthorized,
                Message = "Unauthorized access."
            });
        }
        catch (KeyNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(new
            {
                Status = (int)HttpStatusCode.NotFound,
                Message = "Resource not found."
            });
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Status = (int)HttpStatusCode.BadRequest,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Message = "An unexpected error occurred. Please try again later."
            });
        }
    }
}

