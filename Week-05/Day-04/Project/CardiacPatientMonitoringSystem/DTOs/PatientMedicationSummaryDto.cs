namespace CardiacPatientMonitoringSystem.DTOs;

public class PatientMedicationSummaryDto
{
    public int PatientId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public string MedicationName { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
}