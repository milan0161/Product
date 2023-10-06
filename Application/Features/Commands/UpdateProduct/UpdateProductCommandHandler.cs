using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.UpdateProduct
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IDataContext _context;

        public UpdateProductCommandHandler(IDataContext context)
        {
            this._context = context;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.UpdateProduct.Id);
            
            if (product == null)
            {
                throw new NotFoundEntityException($"Product with id {request.UpdateProduct.Id} is not found");
            }

            if (request.UpdateProduct.Price is not null)
            {
                product.Price = (int)request.UpdateProduct.Price;
            }

            if(request.UpdateProduct.Quantity is not null)
            {
                product.Quantity = (int) request.UpdateProduct.Quantity;
            }

            _context.Products.Update(product);

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();

        }
    }
}
