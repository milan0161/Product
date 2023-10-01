using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain;

namespace Persistence
{
    public class DataContext: DbContext, IDataContext
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}