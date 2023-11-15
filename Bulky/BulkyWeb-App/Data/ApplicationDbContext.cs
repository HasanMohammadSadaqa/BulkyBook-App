using BulkyWeb_App.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category>  Categories { get; set; }
    }
}
