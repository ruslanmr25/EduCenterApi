using Microsoft.EntityFrameworkCore;

using EduCenterApi.Domain.Entities;
namespace EduCenterApi.Infrastructure.DatabaseContext;
public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Role>().HasData(
            new Role { Id=1, Name = "Teacher" },
            new Role { Id=2,Name = "CenterAdmin" },
            new Role { Id=3,Name = "SuperAdmin" }


            );


    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Center> Centers { get; set; }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Since> Sinces { get; set; }

}
