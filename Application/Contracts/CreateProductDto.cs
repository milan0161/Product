using Domain;

namespace Application.Contracts
{
    public record CreateProductDto(int PerfumeId, int Price, int Quantity)
    {
        public Product ToProduct()
            => new Product() { PerfumeId = PerfumeId, Price = Price, Quantity = Quantity };
    }
   
}
