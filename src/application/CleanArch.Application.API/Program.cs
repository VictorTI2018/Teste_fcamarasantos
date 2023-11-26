using CleanArch.Application.API.Filters;
using CleanArch.Infra.SQLServer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CleanArch.Core.Services;
using System.Text.Json.Serialization;
using CleanArch.Infra.RedisCache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<FilterException>())
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api Criada para estudo",
        Description = "Api Criada para estudo e pratica"
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#region redis configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
    options.InstanceName = "Estacionamento";
});
#endregion

#region DI
builder.Services.AddSingleton<CachingHelper>();
builder.Services.AddSqlServerModule(Environment.GetEnvironmentVariable("CONNECTION_STRING_SQL_SERVER"));
builder.Services.AddRepositoryModule();
builder.Services.AddUseCasesModules();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
