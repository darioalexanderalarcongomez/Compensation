
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Compensation.Models;
using Microsoft.AspNetCore.Identity;

namespace Compensation.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Compensation.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Compensation.Models.Event> Event { get; set; } = default!;
        public DbSet<Compensation.Models.Fare> Fare { get; set; } = default!;
        public DbSet<Compensation.Models.Venue> Venue { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Fare)
                .WithMany(f => f.Events)
                .HasForeignKey(e => e.Fare_Id);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Employee)
                .WithMany(emp => emp.Events)
                .HasForeignKey(e => e.Employee_Id);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.Venue_Id);
        }
        public DbSet<Compensation.Models.TypePayment> TypePayment { get; set; } = default!;
        public DbSet<Compensation.Models.Payment> Payment { get; set; } = default!;
    }
}
