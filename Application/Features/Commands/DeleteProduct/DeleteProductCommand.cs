using MediatR;

namespace Application.Features.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(int Id) : IRequest<Unit>;
    
}
