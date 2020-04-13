using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pfeProject2020.Models
{
    public partial class BDStock1Context : DbContext
    {
        public BDStock1Context()
        {
        }

        public BDStock1Context(DbContextOptions<BDStock1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<SsmsColumn> SsmsColumn { get; set; }
        public virtual DbSet<SsmsDatabases> SsmsDatabases { get; set; }
        public virtual DbSet<SsmsDbroles> SsmsDbroles { get; set; }
        public virtual DbSet<SsmsDbuserRole88Dbusers88Dbroles> SsmsDbuserRole88Dbusers88Dbroles { get; set; }
        public virtual DbSet<SsmsDbusers> SsmsDbusers { get; set; }
        public virtual DbSet<SsmsInstances> SsmsInstances { get; set; }
        public virtual DbSet<SsmsProcedures> SsmsProcedures { get; set; }
        public virtual DbSet<SsmsTable> SsmsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ZIZOU-PC\\SQLEXPRESS; Database = BDStock1; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SsmsColumn>(entity =>
            {
                entity.ToTable("SSMS__Column");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdTab).HasColumnName("ID____Tab");

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.IdTabNavigation)
                    .WithMany(p => p.SsmsColumn)
                    .HasForeignKey(d => d.IdTab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSMS__Column_SSMS__Table");
            });

            modelBuilder.Entity<SsmsDatabases>(entity =>
            {
                entity.ToTable("SSMS__Databases");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdInstances).HasColumnName("ID____Instances");

                entity.Property(e => e.InstanceName).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdInstancesNavigation)
                    .WithMany(p => p.SsmsDatabases)
                    .HasForeignKey(d => d.IdInstances)
                    .HasConstraintName("FK_SSMS__Databases_SSMS__Instances");



                
               

            });

            modelBuilder.Entity<SsmsDbroles>(entity =>
            {
                entity.ToTable("SSMS__DBRoles");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SsmsDbuserRole88Dbusers88Dbroles>(entity =>
            {
                entity.ToTable("SSMS__DBUserRole____88____DBUsers__88__DBRoles");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdDbrole).HasColumnName("ID____DBRole");

                entity.Property(e => e.IdDbuser).HasColumnName("ID____DBUser");
            });

            modelBuilder.Entity<SsmsDbusers>(entity =>
            {
                entity.ToTable("SSMS__DBUsers");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdBd).HasColumnName("ID____BD");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SsmsInstances>(entity =>
            {
                entity.ToTable("SSMS__Instances");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SsmsProcedures>(entity =>
            {
                entity.ToTable("SSMS__Procedures");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdBd).HasColumnName("ID____BD");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DBName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdBdNavigation)
                    .WithMany(p => p.SsmsProcedures)
                    .HasForeignKey(d => d.IdBd)
                    .HasConstraintName("FK_SSMS__Procedures_SSMS__Databases");
            });

            modelBuilder.Entity<SsmsTable>(entity =>
            {
                entity.ToTable("SSMS__Table");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdBds).HasColumnName("ID____BDs");

                entity.Property(e => e.Title).HasMaxLength(50);
                entity.Property(e => e.DBName).HasMaxLength(50);

                entity.HasOne(d => d.IdBdsNavigation)
                    .WithMany(p => p.SsmsTable)
                    .HasForeignKey(d => d.IdBds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSMS__Table_SSMS__Databases");
            });
        }
    }
}
