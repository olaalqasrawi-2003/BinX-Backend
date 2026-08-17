using CardiacPatientMonitoringSystem.Models;
using CardiacPatientMonitoringSystem.Repositories;
using CardiacPatientMonitoringSystem.DTOs;
using CardiacPatientMonitoringSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CardiacPatientMonitoringSystem.Services;

public class PatientService : IPatientService
{
    private readonly IGenericRepository<Patient> _patientRepository;
    private readonly AppDbContext _context;
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public PatientService(
        IGenericRepository<Patient> patientRepository,
        AppDbContext context,
        IDbContextFactory<AppDbContext> contextFactory)
    {
        _patientRepository = patientRepository;
        _context = context;
        _contextFactory = contextFactory;
    }

    public async Task<List<Patient>> GetAllPatientsAsync()
    {
        var patients = await _patientRepository.GetAllAsync();

        return patients.ToList();
    }

    public async Task<List<PatientVitalGroupDto>> GetPatientVitalGroupDtosAsync()
    {
        var result = await _context.VitalSigns
            .GroupBy(v => v.PatientId)
            .Select(g => new PatientVitalGroupDto
            {
                PatientId = g.Key,

                PatientName = _context.Patients
                    .Where(p => p.Id == g.Key)
                    .Select(p => p.FullName)
                    .FirstOrDefault() ?? string.Empty,

                VitalSignsCount = g.Count()
            })
            .ToListAsync();

        return result;
    }

    public async Task<List<PatientMedicationSummaryDto>> GetPatientMedicationSummaryAsync()
{
    var result = await _context.Patients
        .Join(
            _context.Medications,
            patient => patient.Id,
            medication => medication.PatientId,
            (patient, medication) => new PatientMedicationSummaryDto
            {
                PatientId = patient.Id,
                PatientName = patient.FullName,
                MedicationName = medication.Name,
                Dosage = medication.Dosage
            }
        )
        .ToListAsync();

    return result;
} 

  public async Task<List<PatientMedicationSummaryDto>> GetAllPatientMedicationsFlattenedAsync()
{
    var patients = await _context.Patients
        .Include(p => p.Medications)
        .ToListAsync();

    var result = patients
        .SelectMany(
            patient => patient.Medications,
            (patient, medication) => new PatientMedicationSummaryDto
            {
                PatientId = patient.Id,
                PatientName = patient.FullName,
                MedicationName = medication.Name,
                Dosage = medication.Dosage
            }
        )
        .ToList();

    return result;
}

public List<string> DemonstrateDeferredExecution()
{
    var names = new List<string>
    {
        "Ahmad",
        "Lina",
        "Omar"
    };

    var query = names
        .Where(name => name.StartsWith("A"));

    names.Add("Ali");

    return query.ToList();
}

public async Task<PatientHealthSummaryDto?> GetPatientHealthSummaryConcurrentAsync(
    int patientId,
    CancellationToken cancellationToken)
{
    await using var patientContext =
        await _contextFactory.CreateDbContextAsync(cancellationToken);

    var patient = await patientContext.Patients
        .AsNoTracking()
        .FirstOrDefaultAsync(
            p => p.Id == patientId,
            cancellationToken
        );

    if (patient == null)
    {
        return null;
    }

    await using var vitalContext =
        await _contextFactory.CreateDbContextAsync(cancellationToken);

    await using var medicationContext =
        await _contextFactory.CreateDbContextAsync(cancellationToken);

    await using var appointmentContext =
        await _contextFactory.CreateDbContextAsync(cancellationToken);

    var vitalSignsTask = vitalContext.VitalSigns
        .AsNoTracking()
        .Where(v => v.PatientId == patientId)
        .OrderByDescending(v => v.RecordedAt)
        .FirstOrDefaultAsync(cancellationToken);

    var medicationsTask = medicationContext.Medications
        .AsNoTracking()
        .Where(m => m.PatientId == patientId)
        .ToListAsync(cancellationToken);

    var appointmentsTask = appointmentContext.Appointments
        .AsNoTracking()
        .Where(a => a.PatientId == patientId)
        .ToListAsync(cancellationToken);

    await Task.WhenAll(
        vitalSignsTask,
        medicationsTask,
        appointmentsTask
    );

    var latestVitalSign = await vitalSignsTask;
    var medications = await medicationsTask;
    var appointments = await appointmentsTask;

    var currentMedications = medications
        .Where(m => m.EndDate == null || m.EndDate >= DateTime.Now)
        .Select(m => m.Name)
        .ToList();

    var nextAppointment = appointments
        .Where(a => a.AppointmentDate >= DateTime.Now &&
                    a.Status == "Scheduled")
        .OrderBy(a => a.AppointmentDate)
        .FirstOrDefault();

    return new PatientHealthSummaryDto
    {
        PatientId = patient.Id,
        FullName = patient.FullName,

        LatestHeartRate = latestVitalSign?.HeartRate,
        LatestSystolicBloodPressure =
            latestVitalSign?.SystolicBloodPressure,
        LatestDiastolicBloodPressure =
            latestVitalSign?.DiastolicBloodPressure,

        CurrentMedications = currentMedications,
        NextAppointmentDate = nextAppointment?.AppointmentDate
    };
}

public bool IsHeartRateNormal(int heartRate)
    {
        return heartRate >= 60 && heartRate <= 100;
    }
}