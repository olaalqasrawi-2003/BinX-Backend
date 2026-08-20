using CardiacPatientMonitoringSystem.Data;
using CardiacPatientMonitoringSystem.DTOs;
using CardiacPatientMonitoringSystem.Models;
using CardiacPatientMonitoringSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CardiacPatientMonitoringSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _context;
private readonly IPatientService _patientService;

public PatientsController(
    AppDbContext context,
    IPatientService patientService)
{
    _context = context;
    _patientService = patientService;
}

   [HttpGet]
   public async Task <IActionResult> GetPatients()
    {
        var patients = await _patientService.GetAllPatientsAsync();
        return Ok(patients);
    }

  [HttpGet("{id}")]
   public async Task <IActionResult> GetPatientById(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if(patient == null)
        {
            return NotFound("Patient not found");
        }
        return Ok(patient);
    }

   [HttpPost]
   public async Task <IActionResult> CreatePatient(CreatePatientDto dto)
    {
        var patient = new Patient
        {
            FullName = dto.FullName,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            EmergencyContact = dto.EmergencyContact
        };

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return CreatedAtAction(
            nameof(GetPatientById),
            new {id = patient.Id},
            patient
        );
    }

   [HttpPut("{id}")]
   public async Task <IActionResult> UpdatePatient(int id, UpdatePatientDto dto)
    {
        var patient = await _context.Patients.FindAsync(id);
        if(patient == null)
        {
            return NotFound("Patient not found");
        }
        patient.FullName = dto.FullName;
        patient.DateOfBirth = dto.DateOfBirth;
        patient.Gender = dto.Gender;
        patient.PhoneNumber = dto.PhoneNumber;
        patient.Email = dto.Email;
        patient.EmergencyContact = dto.EmergencyContact;

        await _context.SaveChangesAsync();
        return NoContent();
    }

  [HttpDelete("{id}")]
  [Authorize(Roles = "Admin")]
  public async Task <IActionResult> DeletePatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        
        if(patient == null)
        {
            return NotFound("Patient not found");
        }

         _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchPatients(string name)
    {
    var patients = await _context.Patients.Where(p => p.FullName.Contains(name))
            .ToListAsync();

        return Ok(patients);
    }
  
  [Authorize(Policy = "CanViewPatientSummary")]
  [HttpGet("{id}/summary")]
  public async Task<IActionResult> GetPatientHealthSummary(int id)
{
    var patient = await _context.Patients
        .Include(p => p.VitalSigns)
        .Include(p => p.Medications)
        .Include(p => p.Appointments)
        .FirstOrDefaultAsync(p => p.Id == id);

    if (patient == null)
    {
        return NotFound("Patient not found");
    }

    var latestVitalSign = patient.VitalSigns
        .OrderByDescending(v => v.RecordedAt)
        .FirstOrDefault();

    var currentMedications = patient.Medications
        .Where(m => m.EndDate == null || m.EndDate >= DateTime.Now)
        .Select(m => m.Name)
        .ToList();

    var nextAppointment = patient.Appointments
        .Where(a => a.AppointmentDate >= DateTime.Now &&
                    a.Status == "Scheduled")
        .OrderBy(a => a.AppointmentDate)
        .FirstOrDefault();

    var summary = new PatientHealthSummaryDto
    {
        PatientId = patient.Id,
        FullName = patient.FullName,

        LatestHeartRate = latestVitalSign?.HeartRate,
        LatestSystolicBloodPressure = latestVitalSign?.SystolicBloodPressure,
        LatestDiastolicBloodPressure = latestVitalSign?.DiastolicBloodPressure,

        CurrentMedications = currentMedications,

        NextAppointmentDate = nextAppointment?.AppointmentDate
    };

    return Ok(summary);
}

[HttpGet("vital-signs-summary")]
public async Task<ActionResult> GetPatientVitalGroups()
    {
        var result = await _patientService.GetPatientVitalGroupDtosAsync();

        return Ok(result);
    }

    [HttpGet("medications-summary")]
public async Task<IActionResult> GetPatientMedicationSummary()
{
    var result = await _patientService.GetPatientMedicationSummaryAsync();

    return Ok(result);
}

[HttpGet("all-medications")]
public async Task<IActionResult> GetAllPatientMedications()
{
    var result = await _patientService.GetAllPatientMedicationsFlattenedAsync();

    return Ok(result);
}

 [HttpGet("{id}/concurrent-summary")]
public async Task<IActionResult> GetConcurrentPatientHealthSummary(
    int id,
    CancellationToken cancellationToken)
{
    var summary = await _patientService
        .GetPatientHealthSummaryConcurrentAsync(id, cancellationToken);

    if (summary == null)
    {
        return NotFound("Patient not found");
    }

    return Ok(summary);
}

[HttpGet("test-exception")]
public IActionResult TestException()
    {
        throw new Exception("This is a test exception");
    }
}