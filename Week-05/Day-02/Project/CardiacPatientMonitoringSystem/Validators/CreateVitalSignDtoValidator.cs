using CardiacPatientMonitoringSystem.DTOs;
using FluentValidation;

namespace CardiacPatientMonitoringSystem.Validators;

public class CreateVitalSignDtoValidator : AbstractValidator<CreateVitalSignDto>
{
    public CreateVitalSignDtoValidator()
    {
        RuleFor(x => x.PatientId)
            .GreaterThan(0)
            .WithMessage("PatientId must be greater than 0.");

        RuleFor(x => x.HeartRate)
            .InclusiveBetween(30, 220)
            .WithMessage("Heart rate must be between 30 and 220.");

        RuleFor(x => x.SystolicBloodPressure)
            .InclusiveBetween(70, 250)
            .WithMessage("Systolic blood pressure must be between 70 and 250.");

        RuleFor(x => x.DiastolicBloodPressure)
            .InclusiveBetween(40, 150)
            .WithMessage("Diastolic blood pressure must be between 40 and 150.");

        RuleFor(x => x.RecordedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("RecordedAt cannot be in the future.");
    }
}