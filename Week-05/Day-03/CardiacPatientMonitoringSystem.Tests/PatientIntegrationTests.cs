using Microsoft.AspNetCore.Mvc.Testing;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using CardiacPatientMonitoringSystem.Models;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace CardiacPatientMonitoringSystem.Tests;
public class PatientIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    public PatientIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
        var token = CreateTestJwt();

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);   
    }

     private string CreateTestJwt()
{
    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
            "CardiacPatientMonitoringSystem_SuperSecretKey_2026!"
        )
    );

    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256
    );

    var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, "test-user"),
        new Claim(ClaimTypes.Email, "test@cardiac.com"),
        new Claim(ClaimTypes.Role, "User")
    };

    var token = new JwtSecurityToken(
        issuer: "CardiacPatientMonitoringSystem",
        audience: "CardiacPatientMonitoringSystemUsers",
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(15),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}

    [Fact]
    public async Task GetPatientById_WhenPatientExists_ReturnsSuccess()
    {
        //Arrange
        int PatientId = 1;

        //Act
        var response = await _client.GetAsync($"/api/Patients/{PatientId}");

        //Assert
        var content = await response.Content.ReadAsStringAsync();

        var patient = JsonSerializer.Deserialize<Patient>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        Assert.NotNull(patient);
        Assert.Equal(1, patient.Id);
        Assert.Equal("Test Patient", patient.FullName);
        Assert.Equal("Test Patient", patient.FullName);
        Assert.Equal("Test Patient", patient.FullName);
        Assert.Equal("Test Patient", patient.FullName);
        Assert.Equal(new DateTime(200, 1, 1), patient.DateOfBirth);
        Assert.Equal("Female", patient.Gender);
        Assert.Equal("0596824700", patient.PhoneNumber);
        Assert.Equal("test@example.com", patient.Email);
        Assert.Equal("0591128620", patient.EmergencyContact);
    }

    [Fact]
    public async Task GetPatientById_WhenPatientDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        int patientId = 666;

        //Act
        var response = await _client.GetAsync($"/api/Patients/{patientId}");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  
  [Fact]
    public async Task ProtectedEndpoint_WuthValidJwt_ReturnsSuccess()
    {
        //Act
        var response = await _client.GetAsync($"/api/Patients/1");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

}