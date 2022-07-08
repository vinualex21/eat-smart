using Microsoft.EntityFrameworkCore;
using EatSmart.Models;
using EatSmart.Services;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
<<<<<<< HEAD
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<ISpoonacularService, SpoonacularService>();

=======
builder.Services.AddScoped<IInputValidation, InputValidation>();
>>>>>>> 2ea1774a218117c781236ea65400d187eb5a01af
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("EatSmartApi");


builder.Services.AddDbContext<UserContext>(option =>
    option.UseInMemoryDatabase("UserDb"));

//builder.Services.AddDbContext<UserContext>(option =>
 //  option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure Swagger/OpenAPI Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||
app.Environment.EnvironmentName == "Testing")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

