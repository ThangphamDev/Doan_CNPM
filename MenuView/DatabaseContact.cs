using System;

public class DatabaseContact
{
	public DatabaseContact()
	{

        public class AppDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDbContext() : base(new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderDb")
            .Options)
        {
            SeedData();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            SeedData();
        }

        private void SeedData()
        {
            if (!Categories.Any())
            {
                Categories.AddRange(
                    new Category { Id = 1, Name = "Món chính" },
                    new Category { Id = 2, Name = "Món phụ" }
                );
                SaveChanges();
            }

            if (!MenuItems.Any())
            {
                MenuItems.AddRange(
                    new MenuItem { Id = 1, Name = "Phở", Price = 50000, CategoryId = 1 },
                    new MenuItem { Id = 2, Name = "Bún bò", Price = 60000, CategoryId = 1 },
                    new MenuItem { Id = 3, Name = "Cơm tấm", Price = 40000, CategoryId = 1 }
                );
                SaveChanges();
            }
        }
    }
}
