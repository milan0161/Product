using Application.Contracts;
using MediatR;


namespace Application.Features.Commands.CreateProduct
{
    public record CreateProductCommand(CreateProductDto Product) : IRequest<int>;
    
    
}
