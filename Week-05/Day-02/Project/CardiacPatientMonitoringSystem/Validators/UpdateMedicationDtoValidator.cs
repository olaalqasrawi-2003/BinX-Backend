using CardiacPatientMonitoringSystem.DTOs;
using FluentValidation;

namespace CardiacPatientMonitoringSystem.Validators;

public class UpdateMedicationDtoValidator : AbstractValidator<UpdateMedicationDto>
{
    public UpdateMedicationDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Medication name is required.");

        RuleFor(x => x.Dosage)
            .NotEmpty()
            .WithMessage("Dosage is required.");

        RuleFor(x => x.Frequency)
            .NotEmpty()
            .WithMessage("Frequency is required.");

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage("End date must be after or equal to start date.");
    }
}