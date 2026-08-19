using CardiacPatientMonitoringSystem.Data;
using CardiacPatientMonitoringSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace CardiacPatientMonitoringSystem.Tests;
public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if(descriptor != null)
            {
                services.Remove(descriptor);
            }

          services.AddDbContext<AppDbContext>(Options =>
          {
             Options.UseInMemoryDatabase("TestDataBase"); 
          }); 

          var serviceProvider = services.BuildServiceProvider();
          using var scope = serviceProvider.CreateScope();
          var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

          db.Database.EnsureCreated();
            if (!db.Patients.Any())
            {
                db.Patients.Add(new Patient
                {
                    Id = 1,
                    FullName = "Test Patient",
                    DateOfBirth = new DateTime(200, 1, 1),
                    Gender = "Female",
                    PhoneNumber = "0596824700",
                    Email = "test@example.com",
                    EmergencyContact = "0591128620"
                });
                db.SaveChanges();
            }
        });
    }
}