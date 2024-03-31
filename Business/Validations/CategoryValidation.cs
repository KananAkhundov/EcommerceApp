using Business.Messages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class CategoryValidation : BaseFluentValidationValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(CategoryMessages.CategoryNameCannotBeEmpty)
                .MinimumLength(3)
                .WithMessage(CategoryMessages.CategoryMinimumLength)
                .MaximumLength(200)
                .WithMessage(CategoryMessages.CategoryMaximumLength);
        }

    }
}
