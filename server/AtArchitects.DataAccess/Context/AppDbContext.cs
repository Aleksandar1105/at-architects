namespace AtArchitects.DataAccess.Context
{
    using AtArchitects.Domain.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectReviews> ProjectReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.ProjectReviews)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectReviews>()
                .HasOne(x => x.User)
                .WithMany(x => x.ProjectReviews)
                .HasForeignKey(x => x.UserId);

        }
    }
}
