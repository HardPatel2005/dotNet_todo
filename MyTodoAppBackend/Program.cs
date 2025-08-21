// Import necessary libraries at the top
using Microsoft.EntityFrameworkCore;
using MyTodoAppBackend.Models;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure the database context to use an in-memory database.
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

// Add a CORS policy to allow the frontend to access the API.
// This is done once in the services collection.
builder.Services.AddCors(options =>
{
    // You can name your policy or use the default one.
    options.AddDefaultPolicy(
        policy =>
        {
            // IMPORTANT: Allow the specific origin of your frontend.
            // Replace with your actual frontend URL (e.g., from Live Server).
            policy.WithOrigins("http://localhost:5093", "http://127.0.0.1:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services for API documentation (Swagger/OpenAPI).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application. This must happen only once.
var app = builder.Build();

// --- HTTP Request Pipeline Configuration ---

// Enable Swagger UI for API documentation in the development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Use the CORS policy. This must be called before app.MapControllers().
app.UseCors();

// Enable authorization middleware.
app.UseAuthorization();

// Maps controller routes to the application.
app.MapControllers();

// Starts the application.
app.Run();

