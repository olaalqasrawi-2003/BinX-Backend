using CardiacPatientMonitoringSystem.Models;
using CardiacPatientMonitoringSystem.Repositories;
using CardiacPatientMonitoringSystem.Services;
using Moq;

namespace CardiacPatientMonitoringSystem.Tests;
public class PatientServiceMockTests
{
    [Fact]
    public async Task GetAllPatientsAsync_ReturnsPatientFromRepository()
    {
        //Arrange
        var patients = new List<Patient>
        {
            new Patient
            {
                Id = 1,
                FullName = "Ahmad Khalil"
            },
            new Patient
            {
                Id = 2,
                FullName = "Sara Ahmad"
            },
        };
        var mockRepository = new Mock<IGenericRepository<Patient>>();
        mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(patients);
        
        var service = new PatientService(
             mockRepository.Object,
             null!,
             null!
        );

        //Act
        var result = await service.GetAllPatientsAsync();

        //Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Ahmad Khalil", result[0].FullName);
        Assert.Equal("Sara Ahmad", result[1].FullName);
    }

    [Fact]
    public async Task GetAllPatientsAsync_WhenRepositoryThrows_ThrowsException()
    {
        //Arrange
        var mockRepository = new Mock<IGenericRepository<Patient>>();
        mockRepository.Setup(repo => repo.GetAllAsync()).ThrowsAsync(new Exception("Repository error"));
        
        var service = new PatientService(
             mockRepository.Object,
             null!,
             null!
        );

        //Act & Assert
        await Assert.ThrowsAsync<Exception>(
            () => 
            service.GetAllPatientsAsync()
            );
    }

    [Fact]
    public async Task GetAllPatientsAsync_CallsRepositoryExactlyOnce()
    {
        //Arrange
        var mockRepository = new Mock<IGenericRepository<Patient>>();
        mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Patient>());
       
        var service = new PatientService(
             mockRepository.Object,
             null!,
             null!
        );

        //Act
        await service.GetAllPatientsAsync();

        //Assert
        mockRepository.Verify(
          repo => repo.GetAllAsync(),
          Times.Once
          );
    }
}