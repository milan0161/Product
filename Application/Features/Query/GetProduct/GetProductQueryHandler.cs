using Application.Contracts;
using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Query.GetProduct
{
    public sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IDataContext _context;
        private readonly IPerfumeHttpClient _perfumeHttpClient;

        public GetProductQueryHandler(IDataContext context, IPerfumeHttpClient perfumeHttpClient)
        {
            this._context = context;
            this._perfumeHttpClient = perfumeHttpClient;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                 
            if (product is null)
            {
                throw new NotFoundEntityException($"Product with {request.Id} not found");
            }
            
            var perfume = await _perfumeHttpClient.GetPerfumeAsync(product.Id);

            if(perfume is null)
            {
                throw new NotFoundEntityException($"Perfume with id {product.Id} doesn't exist");
            }
           
            return new ProductDto(product.Id, perfume, product.Price, product.Quantity);

        }
    }
}
