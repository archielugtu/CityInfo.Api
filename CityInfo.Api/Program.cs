var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// **************************************************************************************************
// ******************************** DEPENDENCY INJECTION ********************************************
// **************************************************************************************************
// When you register services to the services container, you can use depedency injection to inject that service to controller constructors

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // returns of type WebApplication


// **************************************************************************************************
// ********************* Configure the HTTP request pipeline ****************************************
// **************************************************************************************************

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
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
