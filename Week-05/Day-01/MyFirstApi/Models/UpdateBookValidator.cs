using FluentValidation;
namespace MyFirstApi.Models;

public class UpdateBookValidator : AbstractValidator <UpdateBookRequest>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters.");

        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.")
             .MinimumLength(3).WithMessage("Author must be at least 3 characters.");

        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.")
             .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
    }

}