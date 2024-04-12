namespace AtArchitects.DataAccess.Context
{
    using AtArchitects.Domain.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Architect> Architects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectReviews> ProjectReviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(x => x.ProjectReviews)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Architect>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.Architect)
                .HasForeignKey(x => x.ArchitectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Architect>()
                .Property(a => a.Email)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .HasMany(x => x.ProjectReviews)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Architect)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.ArchitectId);

            modelBuilder.Entity<ProjectReviews>()
                .HasOne(x => x.User)
                .WithMany(x => x.ProjectReviews)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.User)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserProject>()
            .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId);

            modelBuilder.Entity<ProjectArchitect>()
        .HasKey(pa => new { pa.ProjectId, pa.ArchitectId });

            modelBuilder.Entity<ProjectArchitect>()
                .HasOne(pa => pa.Project)
                .WithMany(p => p.ProjectArchitects)
                .HasForeignKey(pa => pa.ProjectId);

            modelBuilder.Entity<ProjectArchitect>()
                .HasOne(pa => pa.Architect)
                .WithMany(a => a.ProjectArchitects)
                .HasForeignKey(pa => pa.ArchitectId);
        }
    }
}
