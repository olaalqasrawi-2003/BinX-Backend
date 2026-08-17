namespace CardiacPatientMonitoringSystem.DTOs;

public class PatientHealthSummaryDto
{
    public int PatientId {get; set;}
    public string FullName {get; set;} = string.Empty;

    public int? LatestHeartRate {get; set;} 
    public int? LatestSystolicBloodPressure {get; set;}
    public int? LatestDiastolicBloodPressure {get; set;}

    public List<string> CurrentMedications {get; set;} = new();
    public DateTime? NextAppointmentDate {get; set;}

}