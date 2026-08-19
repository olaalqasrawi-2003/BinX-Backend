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
public class VitalSignsController : ControllerBase
{
    private readonly AppDbContext _context;

    public VitalSignsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetVitalSigns()
    {
        var vitalSigns = await _context.VitalSigns
            .ToListAsync();

        return Ok(vitalSigns);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVitalSignById(int id)
    {
        var vitalSign = await _context.VitalSigns
            .FindAsync(id);

        if (vitalSign == null)
        {
            return NotFound("Vital sign not found");
        }

        return Ok(vitalSign);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetVitalSignsByPatient(int patientId)
    {
        var patientExists = await _context.Patients
            .AnyAsync(p => p.Id == patientId);

        if (!patientExists)
        {
            return NotFound("Patient not found");
        }

        var vitalSigns = await _context.VitalSigns
            .Where(v => v.PatientId == patientId)
            .OrderByDescending(v => v.RecordedAt)
            .ToListAsync();

        return Ok(vitalSigns);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVitalSign(CreateVitalSignDto dto)
    {
        var patientExists = await _context.Patients
            .AnyAsync(p => p.Id == dto.PatientId);

        if (!patientExists)
        {
            return BadRequest("Patient does not exist");
        }

        var vitalSign = new VitalSign
        {
           PatientId = dto.PatientId,
           HeartRate = dto.HeartRate,
           SystolicBloodPressure = dto.SystolicBloodPressure,
           DiastolicBloodPressure = dto.DiastolicBloodPressure,
           RecordedAt = dto.RecordedAt,
           Notes = dto.Notes
        };

        _context.VitalSigns.Add(vitalSign);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetVitalSignById),
            new { id = vitalSign.Id },
            vitalSign
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVitalSign(
        int id,
        UpdateVitalSignDto dto)
    {
        var vitalSign = await _context.VitalSigns
            .FindAsync(id);

        if (vitalSign == null)
        {
            return NotFound("Vital sign not found");
        }

        vitalSign.HeartRate = dto.HeartRate;
        vitalSign.SystolicBloodPressure = dto.SystolicBloodPressure;
        vitalSign.DiastolicBloodPressure = dto.DiastolicBloodPressure;
        vitalSign.RecordedAt = dto.RecordedAt;
        vitalSign.Notes = dto.Notes;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteVitalSign(int id)
    {
        var vitalSign = await _context.VitalSigns
            .FindAsync(id);

        if (vitalSign == null)
        {
            return NotFound("Vital sign not found");
        }

        _context.VitalSigns.Remove(vitalSign);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}