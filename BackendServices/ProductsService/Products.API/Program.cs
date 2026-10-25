using FluentValidation.AspNetCore;
using Products.API.APIEndpoints;
using Products.BLL;
using Products.DAL;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.ConfigureHttpJsonOptions(opt =>
{
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddBusinessLogicLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);

var app = builder.Build();
app.MapProductAPIEndpoints();

app.Run();
