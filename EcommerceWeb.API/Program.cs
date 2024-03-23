using AutoMapper;
using EcommerceWeb.API.Mapper;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Repositories;
using EcommerceWeb.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Register Mappers

builder.Services.AddSingleton(new MapperConfiguration(map =>
{
    map.AddProfile(new CityProfile());
    map.AddProfile(new CountryProfile());
    map.AddProfile(new CustomerProfile());
    map.AddProfile(new StateProfile());
    map.AddProfile(new SupplierProfile());
    map.AddProfile(new UserProfile());

}).CreateMapper());

#endregion

#region Dependency Resolver - Services

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

#endregion

#region Dependency Resolver - Respository

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

#endregion

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
