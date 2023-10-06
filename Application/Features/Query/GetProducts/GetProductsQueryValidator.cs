using FluentValidation;


namespace Application.Features.Query.GetProducts
{
    public sealed class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page number must be greater then 0");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(5,25)
                .WithMessage("Page size can not be less then 5 and greater then 25");
        }
    }
}
