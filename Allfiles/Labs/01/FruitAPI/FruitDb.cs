using Microsoft.EntityFrameworkCore;

class FruitDb : DbContext
{
    public FruitDb(DbContextOptions<FruitDb> options)
        : base(options) { }

    public DbSet<Fruit> Fruits => Set<Fruit>();
}