using AutoCarApp.Application;
using AutoCarApp.Application.Interfaces;
using AutoCarApp.Presentation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        // Register services
        services.AddSingleton<IUserInput, ConsoleInput>(); 
        services.AddSingleton<IOutput, ConsoleOutput>();
        services.AddSingleton<IAutoDrivingCarService, AutoDrivingCarService>();
        services.AddScoped<AutoDrivingCarSimulator>();
    });

var host = builder.Build();

// Resolve and run the AutoDrivingSimulator
var simulator = host.Services.GetRequiredService<AutoDrivingCarSimulator>();
simulator.RunSimulation();
