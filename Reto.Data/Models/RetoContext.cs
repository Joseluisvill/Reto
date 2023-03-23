using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reto.Data.Models
{
    public partial class RetoContext : DbContext
    {
        public RetoContext()
        {
        }

        public RetoContext(DbContextOptions<RetoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.Property(e => e.Estado).HasMaxLength(100);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Hora).HasMaxLength(50);

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Citas_Vehiculo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.Placa).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
