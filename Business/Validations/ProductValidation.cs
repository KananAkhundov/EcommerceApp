using Business.Messages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ProductValidation : BaseFluentValidationValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(ProductMessages.ProductNameCannotBeEmpty)
               .MinimumLength(3)
               .WithMessage(ProductMessages.ProductNameMinimumLength)
               .MaximumLength(200)
               .WithMessage(ProductMessages.ProductNameMaximumLength);

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ProductMessages.ProductDescriptionCannotBeEmpty)
                .MinimumLength(3)
                .WithMessage(ProductMessages.ProductDescriptionMinimumLength)
                .MaximumLength(200)
                .WithMessage(ProductMessages.ProductDescriptionMaximumLength);

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage(ProductMessages.ProductPriceCannotBeEmpty);

            RuleFor(x => x.PhotoUrl)
               .NotEmpty()
               .WithMessage(ProductMessages.ProductPhotoUrlCannotBeEmpty);

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage(ProductMessages.ProductCategoryIdCannotBeEmpty);
        }
    }
}
