using CardiacPatientMonitoringSystem.DTOs;
using FluentValidation;

namespace CardiacPatientMonitoringSystem.Validators;

public class UpdateAppointmentDtoValidator
    : AbstractValidator<UpdateAppointmentDto>
{
    public UpdateAppointmentDtoValidator()
    {
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