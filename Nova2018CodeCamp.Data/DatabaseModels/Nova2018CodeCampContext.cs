using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nova2018CodeCamp.Data.DatabaseModels
{
    public partial class Nova2018CodeCampContext : DbContext
    {
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }

        public Nova2018CodeCampContext(DbContextOptions<Nova2018CodeCampContext> options)
            : base(options)
        {


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=Nova2018CodeCamp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                RelationalReferenceCollectionBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) entity.HasOne(d => d.Location)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull), "FK_Coach_Location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) entity, "Location", "pwso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                RelationalReferenceCollectionBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull), "FK_Location_Sport");
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) entity, "Sport", "pwso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });
        }
    }
}
