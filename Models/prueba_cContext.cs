using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiCuentaBanco.Models
{
    public partial class prueba_cContext : DbContext
    {
        public prueba_cContext()
        {
        }

        public prueba_cContext(DbContextOptions<prueba_cContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=172.16.1.64 ; database=prueba_c ; User Id=pmasivos;Password=Pmasivos2020*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Numcuenta)
                    .HasName("PK__cliente__DA34D5838A2EC437");

                entity.ToTable("cliente");

                entity.Property(e => e.Numcuenta)
                    .HasColumnName("numcuenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Activa)
                    .HasColumnName("activa")
                    .HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.Fechatransaccion)
                    .HasName("PK__cuenta__205C9F441956DAFE");

                entity.ToTable("cuenta");

                entity.Property(e => e.Fechatransaccion).HasColumnType("datetime");

                entity.Property(e => e.Numcuenta).HasColumnName("numcuenta");

                entity.Property(e => e.Saldo).HasColumnName("saldo");

                entity.Property(e => e.Sucursal)
                    .HasColumnName("sucursal")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tipotransaccion)
                    .HasColumnName("tipotransaccion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Valortransaccion).HasColumnName("valortransaccion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
