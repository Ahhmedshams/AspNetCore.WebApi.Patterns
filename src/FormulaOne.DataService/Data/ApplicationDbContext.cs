using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService.Data
{
    public class ApplicationDbContext :DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(d => d.Driver)
                .WithMany(p => p.Achievements)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achivement_Driver");
            });
        }

    }
}
