using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NorthwindAPI.Auth;
using NorthwindAPI.Data;
using NorthwindAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthwindAPIDemo", Version = "v1" });
    c.AddSecurityDefinition("APIKey", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-API-Key",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "APIKey"
                        }
                    },
                    new string[] { }
                }});
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOption.DefaultScheme;
    options.DefaultChallengeScheme = ApiKeyAuthenticationOption.DefaultScheme;
})
.AddApiKeySupport(options => { options.ToString(); });



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
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
