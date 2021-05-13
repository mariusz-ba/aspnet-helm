using Microsoft.EntityFrameworkCore;
using WebApplication.Infrastructure.Models;

namespace WebApplication.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PageView> PageViews { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}