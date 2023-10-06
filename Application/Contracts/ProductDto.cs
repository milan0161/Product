using Domain;

namespace Application.Contracts
{
    public record ProductDto(int Id, PerfumeDto Perfume, int Price, int Quantity)
    {
        //public static ProductDto ToProductDto(PerfumeDto perfume, Product product)
        //{
        //    return new ProductDto(product.Id, perfume, product.Price, product.Quantity);
        //}
    }
}
