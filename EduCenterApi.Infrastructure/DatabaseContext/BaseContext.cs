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
            new Role { Id=3, Name = "Teacher" },
            new Role { Id=2,Name = "CenterAdmin" },
            new Role { Id=1,Name = "SuperAdmin" }


            );


        modelBuilder.Entity<User>().HasData(

            new User {  Id=-1, FullName="Center Admin", Password = "123", RoleId = 2, Username = "ruslan" },
            new User {  Id=1, FullName="Teacher", Password = "123", RoleId =3, Username = "teacher" }

            );

        modelBuilder.Entity<Center>().HasData(
            new Center { Id = 1, Name = "Center 1", AdminId = -1 }
            );

        modelBuilder.Entity<Since>().HasData(
            new Since { Id = 1, Name = "matematika", CenterId=1 }
            );

        //modelBuilder.Entity<Group>().HasData(
        //    new Group
        //    {
        //        Id = 1,
        //        Name = "Group 1",
        //        TeacherId = 1,
        //        CenterId = 1,
        //        SinceId = 1,
        //        TeacherPortion = 50,
        //        Price = 1000,
        //        BeginDate = new DateOnly(2025, 4, 5),
        //        EndDate = new DateOnly(2025, 5, 5),
        //        IsCompleted = false,
        //        //Days = "Monday,Wednesday",
        //        //Times = "10:00,12:00"
        //    }
        //);



    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Center> Centers { get; set; }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Since> Sinces { get; set; }

    public DbSet<TeacherCenter> TeacherCenters { get; set; }

    public DbSet<Student> Students { get; set; }    

    public DbSet<StudentPaymentSycle> StudentPaymentSycles { get;set; }

    public DbSet<StudentPayment> StudentPayments { get; set; }

}
