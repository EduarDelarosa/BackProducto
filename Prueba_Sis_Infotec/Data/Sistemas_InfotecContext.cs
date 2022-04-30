using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba_Sis_Infotec.Models
{
    public partial class Sistemas_InfotecContext : DbContext
    {
        public Sistemas_InfotecContext()
        {
        }

        public Sistemas_InfotecContext(DbContextOptions<Sistemas_InfotecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CateogoriaId).HasColumnName("CateogoriaID");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.HasOne(d => d.Cateogoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CateogoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
