using Application.Contracts;
using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Query.GetProducts
{
    public sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsDto>>
    {
        private readonly IDataContext _context;
        private readonly IPerfumeHttpClient _perfumeHttpClient;

        public GetProductsQueryHandler(IDataContext context, IPerfumeHttpClient perfumeHttpClient)
        {
            this._context = context;
            this._perfumeHttpClient = perfumeHttpClient;
        }
        async Task<List<ProductsDto>> IRequestHandler<GetProductsQuery, List<ProductsDto>>.Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await  _context.Products.Skip((request.PageNumber - 1)  * request.PageSize).Take(request.PageSize).ToArrayAsync(cancellationToken); ;
                
            var ids = products.Select(x => x.PerfumeId).ToArray();

            var perfumes = await _perfumeHttpClient.GetPerfumesAsync(ids);

            if (perfumes is null || perfumes.Count == 0)
            {
                throw new NotFoundEntityException("Perfumes not found");
            }

            List<ProductsDto> productsDtos = new List<ProductsDto>();

           for(int i = 0; i < products.Length; i++)
            {
                var productDto = ProductsDto.ToProductsDto(perfumes.Where(x => x.Id == products[i].PerfumeId).SingleOrDefault()!, products[i]);
                productsDtos.Add(productDto);
            }
            return productsDtos;
           
        }
    }
}
