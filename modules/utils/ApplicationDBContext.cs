using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project.modules.foods;
using project.modules.orders.models;
using project.roles;
using project.users;

namespace project.utils
{
    public class ApplicationDBContext : IdentityDbContext<userEntity, rolEntity, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<orderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Food>(
                entity =>
                {
                    entity.HasKey(x => x.Id).HasName("PK_primary_foods");
                }
            );
            modelBuilder.Entity<Order>(
                entity =>
                {

                }
            );
            modelBuilder.Entity<orderItem>(
                entity =>
                {
                    entity.HasOne(x => x.Food).WithMany(x => x.OrderItems).HasForeignKey(x => x.FoodId);
                    entity.HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId);
                }
            );
        }

    }
}