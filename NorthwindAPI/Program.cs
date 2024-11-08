using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//set up to reach json config file appsettings.json
ConfigurationManager configuration = builder.Configuration; //set up to reach json config file 
//DI to inject our database settings based on the conn string
builder.Services.AddDbContext<NorthwindContext>(options => options.UseNpgsql(
    configuration["ConnectionStrings:NorthwindConnection"]));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
