namespace CardiacPatientMonitoringSystem.DTOs;

public class UpdateVitalSignDto
{
    public int HeartRate { get; set; }
    public int SystolicBloodPressure { get; set; }
    public int DiastolicBloodPressure { get; set; }
    public DateTime RecordedAt { get; set; }
    public string Notes { get; set; } = string.Empty;
    
}