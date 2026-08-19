namespace CardiacPatientMonitoringSystem.DTOs;

public record PatientBasicInfoDto(
    int Id,
    string FullName,
    string Email
);