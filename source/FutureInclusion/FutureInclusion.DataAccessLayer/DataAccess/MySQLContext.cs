using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class MySQLContext : DbContext
    {
        public MySQLContext(){}

        public MySQLContext(DbContextOptions<MySQLContext> options): base(options){}

        public virtual DbSet<Choice> Choice { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Mandate> Mandate { get; set; }
        public virtual DbSet<MandateVoter> MandateVoter { get; set; }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Power> Power { get; set; }
        public virtual DbSet<Sphere> Sphere { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Voter> Voter { get; set; }
        public virtual DbSet<VoterChoice> VoterChoice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=mysql.chapela.com.br;database=chapela;uid=chapela;pwd=mochilas123", x => x.ServerVersion("5.6.37-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>(entity =>
            {
                entity.HasIndex(e => e.PollId)
                    .HasName("fk_CHOICE_POLL1_idx");

                entity.Property(e => e.Text)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.Choice)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CHOICE_POLL1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.StateId)
                    .HasName("fk_CITY_STATE1_idx");

                entity.Property(e => e.Name)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CITY_STATE1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Mandate>(entity =>
            {
                entity.HasIndex(e => e.CityId)
                    .HasName("fk_MANDATE_CITY1_idx");

                entity.HasIndex(e => e.CountryId)
                    .HasName("fk_MANDATE_COUNTRY1_idx");

                entity.HasIndex(e => e.PowerId)
                    .HasName("fk_MANDATE_POWER1_idx");

                entity.HasIndex(e => e.StateId)
                    .HasName("fk_MANDATE_STATE1_idx");

                entity.Property(e => e.Title)
                    .HasComment("(Representative, Federal Deputy, State Deputy, Mayor, President, Senator)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Mandate)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MANDATE_CITY1");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Mandate)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MANDATE_COUNTRY1");

                entity.HasOne(d => d.Power)
                    .WithMany(p => p.Mandate)
                    .HasForeignKey(d => d.PowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MANDATE_POWER1");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Mandate)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MANDATE_STATE1");
            });

            modelBuilder.Entity<MandateVoter>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MandatesId)
                    .HasName("fk_VOTER_has_MANDATE_MANDATE1_idx");

                entity.HasIndex(e => e.VotersId)
                    .HasName("fk_VOTER_has_MANDATE_VOTER1_idx");

                entity.HasOne(d => d.Mandates)
                    .WithMany(p => p.MandateVoter)
                    .HasForeignKey(d => d.MandatesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VOTER_has_MANDATE_MANDATE1");

                entity.HasOne(d => d.Voters)
                    .WithMany(p => p.MandateVoter)
                    .HasForeignKey(d => d.VotersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VOTER_has_MANDATE_VOTER1");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MandateId)
                    .HasName("fk_POLL_MANDATE1_idx");

                entity.Property(e => e.Description)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Tag)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Mandate)
                    .WithMany(p => p.Poll)
                    .HasForeignKey(d => d.MandateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_POLL_MANDATE1");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MandateId)
                    .HasName("fk_POST_MANDATE1_idx");

                entity.HasIndex(e => e.PollId)
                    .HasName("fk_POST_POLL1_idx");

                entity.Property(e => e.Text)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Mandate)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.MandateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_POST_MANDATE1");

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_POST_POLL1");
            });

            modelBuilder.Entity<Power>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.SphereId)
                    .HasName("fk_POWER_SPHERE1_idx");

                entity.Property(e => e.Name)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Sphere)
                    .WithMany(p => p.Power)
                    .HasForeignKey(d => d.SphereId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_POWER_SPHERE1");
            });

            modelBuilder.Entity<Sphere>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasComment("(country, state, city)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasIndex(e => e.CountryId)
                    .HasName("fk_STATE_COUNTRY1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_STATE_COUNTRY1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MandateId)
                    .HasName("fk_USER_MANDATE1_idx");

                entity.Property(e => e.Email)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasComment(" (who manage the system)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Mandate)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.MandateId)
                    .HasConstraintName("fk_USER_MANDATE1");
            });

            modelBuilder.Entity<Voter>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Document)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<VoterChoice>(entity =>
            {
                entity.HasIndex(e => e.ChoicesId)
                    .HasName("fk_VOTE_CHOICE1_idx");

                entity.HasIndex(e => e.VotersId)
                    .HasName("fk_VOTE_VOTER1_idx");

                entity.Property(e => e.Time)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Choices)
                    .WithMany(p => p.VoterChoice)
                    .HasForeignKey(d => d.ChoicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VOTE_CHOICE1");

                entity.HasOne(d => d.Voters)
                    .WithMany(p => p.VoterChoice)
                    .HasForeignKey(d => d.VotersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VOTE_VOTER1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
