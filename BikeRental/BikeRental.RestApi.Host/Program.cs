using System.Reflection;
using AutoMapper;
using BikeRental.Application;
using BikeRental.Application.Services;
using BikeRental.Contracts;
using BikeRental.Contracts.Bike;
using BikeRental.Contracts.Customer;
using BikeRental.Contracts.Rent;
using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DatabaseConfiguration;
using BikeRental.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.Services.AddLogging();

// Database context
builder.Services.AddDbContext<BikeRentMySqlContext>(options =>
{
    options
        .UseMySql(
            builder.Configuration.GetConnectionString("mysql"),
            new MySqlServerVersion(new Version(9, 0, 1)
            ));
});

// AutoMapper
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new ContractsMappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IRepository<Bike, int>, BikeRepository>();
builder.Services.AddScoped<IRepository<Customer, int>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Rent, int>, RentRepository>();

builder.Services.AddScoped<ICrudService<BikeDto, BikeCreateUpdateDto, int>, BikeService>();
builder.Services.AddScoped<ICrudService<CustomerDto, CustomerCreateUpdateDto, int>, CustomerService>();
builder.Services.AddScoped<ICrudService<RentDto, RentCreateUpdateDto, int>, RentService>();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => { policy.AllowAnyOrigin(); policy.AllowAnyMethod(); policy.AllowAnyHeader(); }));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();