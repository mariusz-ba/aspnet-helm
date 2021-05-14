using Microsoft.EntityFrameworkCore;
using WebApplication.Infrastructure.Models;

namespace WebApplication.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<PageView> PageViews { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}