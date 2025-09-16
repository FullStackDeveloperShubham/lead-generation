using LeadGenerationApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LeadGenerationApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }
        // DbSets for each table
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<LeadAssign> LeadAssign { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Dashboard> Dashboard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserId);

            // Lead
            modelBuilder.Entity<Lead>()
                .HasKey(l => l.LeadId);

            // LeadAssign
            modelBuilder.Entity<LeadAssign>()
                .HasKey(la => la.LeadAssignId);

            modelBuilder.Entity<LeadAssign>()
                .HasOne(la => la.Lead)
                .WithMany(l => l.Assignments)
                .HasForeignKey(la => la.LeadAssignId)
                .OnDelete(DeleteBehavior.Cascade);   // Lead delete cascades

            modelBuilder.Entity<LeadAssign>()
                .HasOne(la => la.User)
                .WithMany(u => u.LeadAssignments)
                .HasForeignKey(la => la.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            //// 1️⃣ Seed Permissions first
            //modelBuilder.Entity<Permission>().HasData(
            //    new Permission { PermissionID = 1, Read = true, Write = true, Update = true, Insert = true },
            //    new Permission { PermissionID = 2, Read = true, Write = true, Update = true, Insert = false },
            //    new Permission { PermissionID = 3, Read = true, Write = false, Update = false, Insert = false }
            //);

            // 2️⃣ Seed Roles referencing those Permissions
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RollID = 1, RollName = "Admin", PermissionID = 1 },
                new Roles { RollID = 2, RollName = "Manager", PermissionID = 2 },
                new Roles { RollID = 3, RollName = "User", PermissionID = 3 }
            );

            // Seed Users
            modelBuilder.Entity<Users>().HasData(
                new Users { UserId = 1, UserName = "AliceAdmin", UserPassword = "admin123", RollID = 1 },
                new Users { UserId = 2, UserName = "BobManager", UserPassword = "manager123", RollID = 2 },
                new Users { UserId = 3, UserName = "CharlieTeam", UserPassword = "user123", RollID = 3 },
                new Users { UserId = 4, UserName = "DianaTeam", UserPassword = "user123", RollID = 3 }
            );
            // 4️⃣ Seed Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Development", UserId = 3, ManagerId = 2 },
                new Team { TeamId = 2, TeamName = "Marketing", UserId = 4, ManagerId = 2 }
            );

          


        }



    }
}
