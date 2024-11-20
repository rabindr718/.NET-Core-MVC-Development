using Microsoft.EntityFrameworkCore;
namespace ProjectJob.Data;
using ProjectJob.Models.Entitiy;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        

    }
    public DbSet<Admin> Admins { get; set; }
}

