using EnergyEndpoint.ConsoleApp.Interfaces;
using EnergyEndpoint.ConsoleApp.Pages;
using EnergyEndpoint.Infra.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


IConfigurationRoot _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

var services = new ServiceCollection()
        .AddInfrastructure()
        .AddTransient<IInsert, Insert>()
        .AddTransient<IDelete, Delete>()
        .AddTransient<IEdit, Edit>()
        .AddTransient<ISelect, Select>()
        .AddTransient<IHome, Home>()
        .BuildServiceProvider();

var home = services.GetService<IHome>();

home.InitialOptions();