using FluentValidation;

namespace Stockly.Application.UseCases.Categories.CreateCategoryUseCase;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MinimumLength(3).WithMessage("Category name must have at least 3 characters.")
            .MaximumLength(100).WithMessage("Category name must have at most 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(255).WithMessage("Category description must have at most 255 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}
