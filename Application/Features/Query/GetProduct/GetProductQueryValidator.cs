using FluentValidation;

namespace Application.Features.Query.GetProduct
{
    public sealed class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Product Id must be provided");
        }
    }
}
