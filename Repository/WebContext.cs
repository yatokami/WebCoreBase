using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public partial class WebContext : DbContext
    {
        public WebContext()
        {
        }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
