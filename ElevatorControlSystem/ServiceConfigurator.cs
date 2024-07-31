using Microsoft.Extensions.DependencyInjection;
using ElevatorControlSystem.Application.RequestHandling;
using ElevatorControlSystem.Entities;
using ElevatorControlSystem.Application.Controller;

namespace ElevatorControlSystem.ConsoleApp
{
    public static class ServiceConfigurator
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Register services
            services.AddSingleton<IElevatorController, ElevatorController>();
            services.AddSingleton<IRequestGeneratorService>(provider =>
            {
                var totalFloors = 10; // Pass the totalFloors
                return new RequestGeneratorService(totalFloors);
            });

            // Register the building service
            services.AddSingleton<Building>(provider =>
            {
                int totalFloors = 10;
                int elevatorCount = 4;
                return new Building(totalFloors, elevatorCount);
            });

            return services.BuildServiceProvider();
        }
    }
}
