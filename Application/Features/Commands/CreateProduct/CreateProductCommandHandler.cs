
using Application.Interfaces;
using MediatR;

namespace Application.Features.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IDataContext _context;
        private readonly IPerfumeHttpClient _httpClient;

        public CreateProductCommandHandler(IDataContext context, IPerfumeHttpClient httpClient)
        {
            this._context = context;
            this._httpClient = httpClient;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var perfume = await _httpClient.GetPerfumeAsync(request.Product.PerfumeId);

            if (perfume is null) 
            {
                throw new Exception($"Perfume with id {request.Product.PerfumeId} doesn't exist");
            }

            var product = request.Product.ToProduct();
            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;

        }
    }
}
