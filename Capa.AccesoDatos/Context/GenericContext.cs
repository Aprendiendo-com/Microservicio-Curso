using Capa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.AccesoDatos.Context
{
    public class GenericContext: DbContext
    {
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Clase> Clases { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Foro> Foros { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        public GenericContext() { }


        public GenericContext(DbContextOptions<GenericContext> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database = MicroCurso ; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>( entity =>
            {
                entity.HasKey(x => x.CategoriaId);

                entity.Property(x => x.Descripcion).HasMaxLength(250).IsRequired();

                entity.HasData(
                    new Categoria { CategoriaId = 1, Descripcion = "Programacion"},
                    new Categoria { CategoriaId = 2, Descripcion = "Idiomas" },
                    new Categoria { CategoriaId = 3, Descripcion = "Ciencias exactas" }
                    );
            });


            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(x => x.ClaseId);

                entity.Property(x => x.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(x => x.Tema).HasMaxLength(250).IsRequired();
               

                entity.HasOne(x => x.CursoNavegacion)
                .WithMany(x => x.ClasesNavegacion)
                .HasForeignKey(x => x.CursoId);

                entity.HasOne(x => x.ForoNavegation)
                .WithOne(x => x.ClaseNavegation);

                entity.HasOne(x => x.VideoNavegation)
                .WithOne(x => x.ClaseNavegation);


            });


            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(x => x.ComentarioId);

                entity.Property(x => x.Texto).HasMaxLength(250).IsRequired();

                entity.HasOne(x => x.ForoNavegation)
                .WithMany(x => x.ComentariosNavegation)
                .HasForeignKey(x => x.ForoId);
            });


            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(x => x.CursoId);

                entity.Property(x => x.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(x => x.ProfesorId).HasMaxLength(250).IsRequired();

                entity.HasOne(x => x.CategoriaNavegacion)
                .WithMany(x => x.CursoNavegacion)
                .HasForeignKey(x => x.CategoriaId);

            });

            modelBuilder.Entity<Foro>(entity =>
            {
                entity.HasKey(x => x.ForoId);

                entity.Property(x => x.Texto).HasMaxLength(250).IsRequired();
            });


            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(x => x.VideoId);

                entity.Property(x => x.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(x => x.Link).HasMaxLength(100).IsRequired();
            });
        }
    }
}
