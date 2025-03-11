using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductName).MinimumLength(2);
            RuleFor(x => x.ProductName).Must(StartsWithA).WithMessage("Product name must begin with A");
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(20).When(x => x.CategoryId == 2);
        }

        private bool StartsWithA(string productName)
        {
            return productName.StartsWith("A");
        }
    }
}
