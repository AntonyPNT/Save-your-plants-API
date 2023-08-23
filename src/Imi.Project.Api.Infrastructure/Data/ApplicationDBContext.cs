using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; //hier using nog toevoegen
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data
{ //demijne
    public class ApplicationDBContext: /*DbContext, */IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantAction> PlantActions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>()
            .HasOne(p => p.ApplicationUser);

            modelBuilder.Entity<ApplicationUser>().HasKey(s => s.Id);
            modelBuilder.Entity<Plant>().HasKey(s => s.Id);
            modelBuilder.Entity<PlantAction>().HasKey(s => s.Id);
            modelBuilder.Entity<Schedule>().HasKey(s => s.Id);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.PlantAction);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.ApplicationUser);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Plant);

            ApplicationUserSeeder.Seed(modelBuilder);
            PlantSeeder.Seed(modelBuilder);
            PlantActionSeeder.Seed(modelBuilder);
            ScheduleSeeder.Seed(modelBuilder);
        }
    }
}
