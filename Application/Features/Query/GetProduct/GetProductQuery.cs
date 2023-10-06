using Application.Contracts;
using MediatR;


namespace Application.Features.Query.GetProduct
{
    public sealed record GetProductQuery(int Id) : IRequest<ProductDto>;
    
}
