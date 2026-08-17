namespace CardiacPatientMonitoringSystem.DTOs;

public class CreateAppointmentDto
{
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = "Scheduled";  
}