using Application.Contracts;
using MediatR;

namespace Application.Features.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(UpdateProductDto UpdateProduct) : IRequest<Unit>;
    
}
