using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GeorgianCollege.Models;
using Microsoft.AspNetCore.Identity;

namespace GeorgianCollege.Data
{
    public class GeorgianCollegeDbContext : IdentityDbContext<IdentityUser> 
    {
        public GeorgianCollegeDbContext(DbContextOptions<GeorgianCollegeDbContext> options)
            : base(options) { }

      
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Attachment>().ToTable("Attachments");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Status>().ToTable("Statuses");

          
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.Ticket)
                .WithMany(t => t.Attachments)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
