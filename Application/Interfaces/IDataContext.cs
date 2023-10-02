using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Product> Products { get; set; }
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken token);

        Task<int> SaveChangesAsync(bool test, CancellationToken token);
    }
}
