using WebShop.Models.Dbo;
using WebShop.Models.Dbo.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public override int SaveChanges()
        {

            var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is IEntityBase && (
                          e.State == EntityState.Added
                          || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }
            return base.SaveChanges();

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntityBase && (
              e.State == EntityState.Added
              || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }



        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<FileStorage> FileStorage { get; set; }

    }
}