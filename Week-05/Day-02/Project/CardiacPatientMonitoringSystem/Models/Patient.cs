namespace CardiacPatientMonitoringSystem.Models;
public class Patient
{
    public int Id {get; set;}
    public string FullName {get; set;} = string.Empty;
    public DateTime DateOfBirth {get; set;}
    public string Gender {get; set;} = string.Empty;
    public string PhoneNumber {get; set;} = string.Empty;
     public string Email {get; set;} = string.Empty;
    public string EmergencyContact {get; set;} = string.Empty;
    
   //Relationships

   public ICollection<VitalSign> VitalSigns {get; set;} = new List<VitalSign>();
   public ICollection<Medication> Medications {get; set;} = new List<Medication>();
   public ICollection<Appointment> Appointments {get; set;} = new List<Appointment>();
   
}