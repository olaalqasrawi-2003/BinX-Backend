namespace CardiacPatientMonitoringSystem.DTOs;

public class PatientVitalGroupDto
{
    public int PatientId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public int VitalSignsCount { get; set; }
}