using Application.Contracts;
using MediatR;

namespace Application.Features.Query.GetProducts
{
    public record GetProductsQuery(int PageSize, int PageNumber) : IRequest<List<ProductsDto>>;

}
