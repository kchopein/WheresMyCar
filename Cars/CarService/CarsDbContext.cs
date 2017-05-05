using CarService.Model;
using Microsoft.EntityFrameworkCore;

namespace CarService
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarsDbContext(DbContextOptions<CarsDbContext> contextOptions) : base(contextOptions)
        {

        }
    }
}