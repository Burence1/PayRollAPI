using PayrollAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json", true, true)
   .Build();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PayrollAPI", Version = "v1" });
});

builder.Services.AddDbContext<PayrollContext>(options => options.UseSqlServer(configuration.GetConnectionString("DevConnection")));

var app = builder.Build();
var env = builder.Environment;

// Configure the HTTP request pipeline.

app.UseAuthorization();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PayrollAPI v1"));
}


app.MapControllers();

app.Run();
