namespace COMP2084_Assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameControllerModel : DbContext
    {
        public GameControllerModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<console> consoles { get; set; }
        public virtual DbSet<game> games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<console>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<console>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<console>()
                .Property(e => e.bio_link)
                .IsUnicode(false);

            modelBuilder.Entity<console>()
                .HasOptional(e => e.consoles1)
                .WithRequired(e => e.console1);

            modelBuilder.Entity<console>()
                .HasMany(e => e.games)
                .WithRequired(e => e.console)
                .HasForeignKey(e => e.console_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<game>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<game>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<game>()
                .Property(e => e.rating)
                .IsUnicode(false);
        }
    }
}
