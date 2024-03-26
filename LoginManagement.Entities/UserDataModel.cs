using LoginManagement.Entities.Migrations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginManagement.Entities
{
    [Table("Users")]
    [PrimaryKey("UserId")]
    [Index("UserName",IsUnique = true)]
    public class User
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MinLength(5)]
        public string UserName { get; set; }

        [MinLength(8)]
        [RegularExpression(@"^(?=.[a-zA-Z])(?=.\d).{8,}$", ErrorMessage = "Password must contain at least one letter and one digit")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
    [Table("Roles")]
    [PrimaryKey("RoleId")]
    [Index("RoleName", IsUnique = true)]
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [MinLength(5)]
        public string RoleName { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
    [Table("UserRole")]
    [PrimaryKey("UserId","RoleId")]
    public class UserRole
    {
        public User User { get; set; }
        public Role Role { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public bool IsActive { get; set; }
    }

    public class UserDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer(
               @"server=(local);database=UserDB;integrated security=sspi;trustservercertificate=true");

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Book>().HasKey(c => c.BookId);
            
        // }
     }
    }
