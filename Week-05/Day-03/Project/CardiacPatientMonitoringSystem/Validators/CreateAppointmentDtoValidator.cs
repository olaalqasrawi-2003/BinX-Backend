using CardiacPatientMonitoringSystem.DTOs;
using FluentValidation;

namespace CardiacPatientMonitoringSystem.Validators;

public class CreateAppointmentDtoValidator
    : AbstractValidator<CreateAppointmentDto>
{
    public CreateAppointmentDtoValidator()
    {
        RuleFor(x => x.PatientId)
            .GreaterThan(0)
            .WithMessage("PatientId must be greater than 0.");

        RuleFor(x => x.AppointmentDate)
            .GreaterThan(DateTime.Now)
            .WithMessage("Appointment date must be in the future.");

        RuleFor(x => x.Reason)
            .NotEmpty()
            .WithMessage("Appointment reason is required.");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status is required.")
            .Must(status =>
                status == "Scheduled" || status == "Completed" || status == "Cancelled")
            .WithMessage(
                "Status must be Scheduled, Completed, or Cancelled.");
    }
}