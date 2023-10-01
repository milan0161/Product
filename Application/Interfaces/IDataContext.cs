using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
