using ConsoleAppEFC;
using ConsoleAppEFC.Contexts;
using ConsoleAppEFC.Repositories;
using ConsoleAppEFC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Databaslagring\ConsoleAppEFC\ConsoleAppEFC\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<CustomerRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<ProductService>();
    services.AddScoped<RoleService>();
    services.AddScoped<CustomerService>();

    services.AddSingleton<ConsoleUI>();

}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();


consoleUI.MainMenu();
