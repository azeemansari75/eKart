using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOcelot();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("Ocelot.Dev.json", optional: false, reloadOnChange: true);
}

builder.Configuration.AddJsonFile("Ocelot.json", optional:false, reloadOnChange:true);

var app = builder.Build();

await app.UseOcelot();

app.Run();
