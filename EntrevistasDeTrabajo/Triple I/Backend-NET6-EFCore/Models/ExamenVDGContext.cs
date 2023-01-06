using Microsoft.EntityFrameworkCore;

namespace ExamenVDG.Models
{
    public class ExamenVDGContext : DbContext
    {
        public ExamenVDGContext()
        {
        }

        public ExamenVDGContext(DbContextOptions<ExamenVDGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consola> Consolas => Set<Consola>();
        public virtual DbSet<Genero> Generos => Set<Genero>();
        public virtual DbSet<Videojuego> Videojuegos => Set<Videojuego>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AI");

            modelBuilder.Entity<Consola>(entity =>
            {
                entity.HasKey(e => e.IdTipoConsola);
                entity.ToTable("TipoConsola");
                entity.Property(e => e.IdTipoConsola).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(256)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdTipoGenero);
                entity.ToTable("TipoGenero");
                entity.Property(e => e.IdTipoGenero).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(256)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Videojuego>(entity =>
            {
                entity.HasKey(e => e.IdVideojuego);
                entity.ToTable("Videojuego");
                entity.Property(e => e.Descripcion).IsRequired();
                entity.Property(e => e.Anio).IsRequired();
                entity.Property(e => e.Calificacion).IsRequired();
                entity.Property(e => e.Cantidad).IsRequired();

                entity.Property(e => e.Titulo)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.HasOne(d => d.Consola)
                      .WithMany(p => p.Videojuegos)
                      .HasForeignKey(d => d.IdTipoConsola)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Videojuego_TipoConsola");

                entity.HasOne(d => d.Genero)
                      .WithMany(p => p.Videojuegos)
                      .HasForeignKey(d => d.IdTipoGenero)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Videojuego_TipoGenero");
            });
        }
    }
}