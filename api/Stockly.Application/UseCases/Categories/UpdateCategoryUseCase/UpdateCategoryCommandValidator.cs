using FluentValidation;

namespace Stockly.Application.UseCases.Categories.UpdateCategoryUseCase;

public class UpdateCategoryCommandValidator
    : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MinimumLength(3).WithMessage("Category name must have at least 3 characters.")
            .MaximumLength(100).WithMessage("Category name must have at most 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithMessage("Description must have at most 255 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
        ;
    }
}
