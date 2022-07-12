using Microsoft.EntityFrameworkCore;
using EatSmart.Models;
using EatSmart.Services;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInputValidation, InputValidation>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<ISpoonacularService, SpoonacularService>();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("EatSmartApi");
// AWS credentials
var awsDbPassword = builder.Configuration["AWS-MYSQL-Db-password"];
var awsCredentialsBuilder = new MySqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("EatSmartAWSContext"));
awsCredentialsBuilder.Password = builder.Configuration["AWS-MYSQL-Db-password"];
var awsDbConnection = awsCredentialsBuilder.ConnectionString;

builder.Services.AddDbContext<UserContext>(option => option.UseMySQL(awsDbConnection));

//builder.Services.AddDbContext<UserContext>(option =>
//option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure Swagger/OpenAPI Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add health Check
builder.Services.AddHealthChecks().AddDbContextCheck<UserContext>("AWS Database");
builder.Services.AddHealthChecks().AddCheck<HealthCheck>("Azure Services");



var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheck.WriteResponse
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||
app.Environment.EnvironmentName == "Testing" ||
true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

