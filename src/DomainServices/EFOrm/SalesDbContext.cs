using Microsoft.EntityFrameworkCore;

namespace EFOrm
{
    public class SalesDbContext : DbContext
    {
        public DbSet<CustomerData> Customers { get; set; }
    }
}