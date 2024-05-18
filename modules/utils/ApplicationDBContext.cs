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

    }
}