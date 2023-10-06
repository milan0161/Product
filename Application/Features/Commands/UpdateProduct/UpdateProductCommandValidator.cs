using FluentValidation;

namespace Application.Features.Commands.UpdateProduct
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            When(x => x.UpdateProduct.Price is not null, () => 
            {
                RuleFor(x => x.UpdateProduct.Price).GreaterThan(0);
            });

            When(x => x.UpdateProduct.Quantity is not null, () =>
            {
                RuleFor(x => x.UpdateProduct.Quantity).GreaterThan(0);
            });
                
        }
    }
}
