using WineHub.Api.Managers;
using WineHub.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// Replace AddOpenApi() with Swashbuckle setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection:
// Controller -> Manager -> Repository
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddScoped<IOrderManager, OrderManager>();

// Allow the Vue development server to call the API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueDevelopment", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetPreflightMaxAge(TimeSpan.FromSeconds(600));
    });
});

var app = builder.Build();

// CORS middleware MUST be before UseHttpsRedirection and other middleware
app.UseCors("VueDevelopment");

if (app.Environment.IsDevelopment())
{
    // Replace MapOpenApi() with the Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
