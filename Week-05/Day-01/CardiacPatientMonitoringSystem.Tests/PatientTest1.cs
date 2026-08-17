using CardiacPatientMonitoringSystem.Services;

namespace CardiacPatientMonitoringSystem.Tests;

public class PatientTests
{
    [Fact]
    public void IsHeartRateNormal_WithNormalRate_ReturnsTrue()
    {
        // Arrange
        var service = new PatientService(null!, null!, null!);
        int heartRate = 80;

        // Act
        var result = service.IsHeartRateNormal(heartRate);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsHeartRateNormal_WithLowRate_ReturnsFalse()
    {
        // Arrange
        var service = new PatientService(null!, null!, null!);
        int heartRate = 50;

        // Act
        var result = service.IsHeartRateNormal(heartRate);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsHeartRateNormal_WithHighRate_ReturnsFalse()
    {
        // Arrange
        var service = new PatientService(null!, null!, null!);
        int heartRate = 120;

        // Act
        var result = service.IsHeartRateNormal(heartRate);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(60, true)]
    [InlineData(80, true)]
    [InlineData(120, false)]
    public void IsHeartRateNormal_WithDifferentRates_ReturnsExpectedResult(
        int heartRate,
        bool expected)
    {
        // Arrange
        var service = new PatientService(null!, null!, null!);

        // Act
        var result = service.IsHeartRateNormal(heartRate);

        // Assert
        Assert.Equal(expected, result);
    }
}