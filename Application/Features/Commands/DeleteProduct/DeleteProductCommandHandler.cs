using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.DeleteProduct
{
    public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IDataContext _context;

        public DeleteProductCommandHandler(IDataContext context)
        {
            this._context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (product == null)
            {
                throw new NotFoundEntityException($"Could not find product with id {request.Id}");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}
