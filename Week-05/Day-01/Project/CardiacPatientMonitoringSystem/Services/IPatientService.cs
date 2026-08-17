using CardiacPatientMonitoringSystem.DTOs;
using CardiacPatientMonitoringSystem.Models;

namespace CardiacPatientMonitoringSystem.Services;

public interface IPatientService
{
    Task<List<Patient>> GetAllPatientsAsync();

    Task<List<PatientVitalGroupDto>> GetPatientVitalGroupDtosAsync();

    Task<List<PatientMedicationSummaryDto>> GetPatientMedicationSummaryAsync();

    Task<List<PatientMedicationSummaryDto>> GetAllPatientMedicationsFlattenedAsync();

    List<string> DemonstrateDeferredExecution();

    Task<PatientHealthSummaryDto?> GetPatientHealthSummaryConcurrentAsync(
    int patientId,
    CancellationToken cancellationToken);
}