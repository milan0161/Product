using Domain;

namespace Application.Contracts
{
    public sealed record ProductsDto(int Id, string Name, string Brand, int Price, int Quantity)
    {
        public static ProductsDto ToProductsDto(PerfumeDto perfume, Product product)
        {
            return new ProductsDto(product.Id, perfume.Name, perfume.Brand, product.Price, product.Quantity);
        }
    };
  
}
