using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// **************************************************************************************************
// ******************************** DEPENDENCY INJECTION ********************************************
// **************************************************************************************************
// When you register services to the services container, you can use depedency injection to inject that service to controller constructors

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; // Returns a HTTP 406 Not Acceptable response if the consumer of the API asks for a certain representation of data that we don't support.
}).AddXmlDataContractSerializerFormatters(); // This adds input/output XML formatters. Adds XML support to our API

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>(); // registers a service with a singleton lifetime in the container for file extension features

var app = builder.Build(); // returns of type WebApplicationf


// **************************************************************************************************
// ********************* Configure the HTTP request pipeline ****************************************
// **************************************************************************************************

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // important this is added before UseSwaggerUI(), as data is retrieved from calling this method
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Marks the position in the middleware pipeline where a *routing decision* is made
app.UseRouting(); 

app.UseAuthorization();

// Marks the position in the middleware pipeline where the selected endpoint is *executed*
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Adds endpoints for controller actions without specifying routes. Routes are specified via attribute-based routing in controller class
}); 

app.Run();
