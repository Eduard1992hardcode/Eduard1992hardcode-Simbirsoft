using Microsoft.EntityFrameworkCore;
using SimbirSoftTask.Models;

namespace SimbirSoftTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<CheckedSite> CheckedSites { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CheckedSite>(o =>
            {
                o.HasMany(o => o.WordsInPage)
                .WithOne()
                .HasForeignKey(p => p.CheckedSiteId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Word>().Property(p => p.Name).HasMaxLength(200);
        }
    }
}
