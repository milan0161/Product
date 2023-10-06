using FluentValidation;


namespace Application.Features.Commands.CreateProduct
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            When(x => x.Product is not null, () =>
            {
                RuleFor(x => x.Product.Price)
                    .GreaterThan(0)
                    .WithMessage("Product price must be provided and greater then 0");

                RuleFor(x => x.Product.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Product quantity must be provided and greater then 0");

                RuleFor(x => x.Product.PerfumeId)
                    .GreaterThan(0)
                    .WithMessage("Perfume Id must be provided");
               
            
            });
        }
    }
}
