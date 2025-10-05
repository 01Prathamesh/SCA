using StudentAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register StudentDAL for DI
builder.Services.AddScoped<StudentDAL>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins("http://localhost:3000") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS policy to allow frontend connections
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
