using FluentValidation;
using FluentValidation.AspNetCore;
using HandleExceptionSample.Contracts.Requests;
using HandleExceptionSample.Services;
using HandleExceptionSample.Validation;
using System;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services.AddValidatorsFromAssemblyContaining<CustomerRequestValidator>();

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<Program>();
    x.DisableDataAnnotationsValidation = true;
}); ;
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IValidator<CustomerRequest>, CustomerRequestValidator>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
