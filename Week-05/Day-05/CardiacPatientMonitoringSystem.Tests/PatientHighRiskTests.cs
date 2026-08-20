using CardiacPatientMonitoringSystem.Data;
using CardiacPatientMonitoringSystem.Models;
using CardiacPatientMonitoringSystem.Repositories;
using CardiacPatientMonitoringSystem.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CardiacPatientMonitoringSystem.Tests;

public class PatientHighRiskTests
{
    [Fact]
    public async Task GetPatientMedicationSummaryAsync_ReturnsCorrectMedicationSummary()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("MedicationSummaryTestDb")
            .Options;

        using var context = new AppDbContext(options);

        context.Patients.Add(new Patient
        {
            Id = 1,
            FullName = "Test Patient"
        });

        context.Medications.Add(new Medication
        {
            Id = 1,
            PatientId = 1,
            Name = "Aspirin",
            Dosage = "100mg",
            Frequency = "Once daily",
            StartDate = DateTime.Today
        });

        await context.SaveChangesAsync();

        var mockRepository = new Mock<IGenericRepository<Patient>>();

        var service = new PatientService(
            mockRepository.Object,
            context,
            null!
        );

        // Act
        var result = await service.GetPatientMedicationSummaryAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal(1, result[0].PatientId);
        Assert.Equal("Test Patient", result[0].PatientName);
        Assert.Equal("Aspirin", result[0].MedicationName);
        Assert.Equal("100mg", result[0].Dosage);
    }
}