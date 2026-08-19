using CardiacPatientMonitoringSystem.Data;
using CardiacPatientMonitoringSystem.DTOs;
using CardiacPatientMonitoringSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CardiacPatientMonitoringSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MedicationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MedicationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMedications()
    {
        var medications = await _context.Medications
            .ToListAsync();

        return Ok(medications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicationById(int id)
    {
        var medication = await _context.Medications
            .FindAsync(id);

        if (medication == null)
        {
            return NotFound("Medication not found");
        }

        return Ok(medication);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetMedicationsByPatient(int patientId)
    {
        var patientExists = await _context.Patients
            .AnyAsync(p => p.Id == patientId);

        if (!patientExists)
        {
            return NotFound("Patient not found");
        }

        var medications = await _context.Medications
            .Where(m => m.PatientId == patientId)
            .OrderByDescending(m => m.StartDate)
            .ToListAsync();

        return Ok(medications);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMedication(CreateMedicationDto dto)
    {
        var patientExists = await _context.Patients
            .AnyAsync(p => p.Id == dto.PatientId);

        if (!patientExists)
        {
            return BadRequest("Patient does not exist");
        }

        var medication = new Medication
        {
            PatientId = dto.PatientId,
            Name = dto.Name,
            Dosage = dto.Dosage,
            Frequency = dto.Frequency,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetMedicationById),
            new { id = medication.Id },
            medication
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedication(
        int id,
        UpdateMedicationDto dto)
    {
        var medication = await _context.Medications
            .FindAsync(id);

        if (medication == null)
        {
            return NotFound("Medication not found");
        }

        medication.Name = dto.Name;
        medication.Dosage = dto.Dosage;
        medication.Frequency = dto.Frequency;
        medication.StartDate = dto.StartDate;
        medication.EndDate = dto.EndDate;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMedication(int id)
    {
        var medication = await _context.Medications
            .FindAsync(id);

        if (medication == null)
        {
            return NotFound("Medication not found");
        }

        _context.Medications.Remove(medication);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}