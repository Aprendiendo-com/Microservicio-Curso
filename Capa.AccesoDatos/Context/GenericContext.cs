using Capa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.AccesoDatos.Context
{
    public class GenericContext : DbContext
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
            modelBuilder.Entity<Categoria>(entity =>
           {
               entity.HasKey(x => x.CategoriaId);

               entity.Property(x => x.Descripcion).HasMaxLength(250).IsRequired();

               entity.HasData(
                   new Categoria { CategoriaId = 1, Descripcion = "Programacion" },
                   new Categoria { CategoriaId = 2, Descripcion = "Idiomas" },
                   new Categoria { CategoriaId = 3, Descripcion = "Ciencias exactas" }
                   );
           });


            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(x => x.ClaseId);

                entity.Property(x => x.Descripcion).HasMaxLength(4096).IsRequired();
                entity.Property(x => x.Tema).HasMaxLength(4096).IsRequired();


                entity.HasOne(x => x.CursoNavegacion)
                .WithMany(x => x.ClasesNavegacion)
                .HasForeignKey(x => x.CursoId);

                entity.HasOne(x => x.ForoNavegation)
                .WithOne(x => x.ClaseNavegation);

                entity.HasOne(x => x.VideoNavegation)
                .WithOne(x => x.ClaseNavegation);

                entity.HasData(
                    new Clase
                    {
                        ClaseId = 1,
                        CursoId = 1,
                        Descripcion = "Introduccion a la programacion orientada a objetos",
                        Tema = "La programación orientada a objetos es una evolución de la programación procedural basada en funciones. La POO nos permite agrupar secciones de código con funcionalidades comunes. " +
                    "Una de las principales desventajas de la programación procedural basada en funciones es su construcción, cuando una aplicación bajo este tipo de programación crece, la modificación del código se hace muy trabajosa y difícil debido a que el cambio de una sola línea en una función," +
                    " puede acarrear la modificación de muchas otras líneas de código pertenecientes a otras funciones que estén relacionadas. Con la programación orientada a objetos se pretende agrupar el código encapsulándolo y haciéndolo independiente, de manera que una modificación debida al crecimiento de la aplicación solo afecte a unas pocas líneas."
                    },
                    new Clase { ClaseId = 2, CursoId = 1, Descripcion = "Manejo de excepciones.", Tema = "Las características de control de excepciones del lenguaje C# le ayudan a afrontar cualquier situación inesperada o excepcional que se produce cuando se ejecuta un programa. El control de excepciones usa las palabras clave try, catch y finally para intentar realizar acciones que pueden no completarse correctamente, para controlar errores cuando decide que es razonable hacerlo y para limpiar recursos más adelante." },
                    new Clase { ClaseId = 3, CursoId = 1, Descripcion = "Estructuras de datos: Grafos.", Tema = "En matemáticas y ciencias de la computación, un grafo es un conjunto de objetos llamados vértices o nodos unidos por enlaces llamados aristas o arcos, que permiten representar relaciones binarias entre elementos de un conjunto. Son objeto de estudio de la teoría de grafos. Típicamente, un grafo se representa gráficamente como un conjunto de puntos(vértices o nodos) unidos por líneas(aristas)." },
                    new Clase { ClaseId = 4, CursoId = 2, Descripcion = "El verbo to be", Tema = "En inglés, así como en cualquier idioma, los verbos cumplen una función muy importante dentro del proceso de comunicación: éstos son los encargados de expresar las acciones. Hay un verbo en inglés que es esencial para comunicarse, y por supuesto el más usado de todos los que existen. Éste es el verbo to be." },
                    new Clase { ClaseId = 5, CursoId = 2, Descripcion = "El present simple", Tema = " En inglés, el presente simple también denominado presente indefinido  es el tiempo verbal presente (de aspecto no perfecto). Es uno de los tiempos verbales del presente utilizados en inglés, además del presente progresivo, el presente perfecto y el presente perfecto progresivo.Se utiliza para hablar de cosas, hábitos diarios o actividades que suelen hacerse todos los días y siempre son verdad." },
                    new Clase { ClaseId = 6, CursoId = 2, Descripcion = "El present continuous", Tema = "El presente continuo o presente progresivo, es uno de los tiempos verbales del presente usados en el inglés, los otros son el presente simple y presente perfecto. Todos ellos pueden ser usados tanto en el modo indicativo como en el subjuntivo." },
                    new Clase { ClaseId = 7, CursoId = 3, Descripcion = "Campo electrico", Tema = "Un campo eléctrico es un campo de fuerza creado por la atracción y repulsión de cargas eléctricas (la causa del flujo eléctrico) y se mide en Voltios por metro (V/m). El flujo decrece con la distancia a la fuente que provoca el campo." },
                    new Clase { ClaseId = 8, CursoId = 3, Descripcion = "Campo magnetico", Tema = "Un campo magnético es una descripción matemática de la influencia magnética de las corrientes eléctricas y de los materiales magnéticos.​ El campo magnético en cualquier punto está especificado por dos valores, la dirección y la magnitud; de tal forma que es un campo vectorial." },
                    new Clase { ClaseId = 9, CursoId = 3, Descripcion = "Ecuaciones de Maxwell", Tema = "Las ecuaciones de Maxwell representan una de las formas mas elegantes y concisas de establecer los fundamentos de la Electricidad y el Magnetismo. A partir de ellas, se pueden desarrollar la mayoría de las fórmulas de trabajo en el campo. Debido a su breve declaración, encierran un alto nivel de sofisticación matemática y por tanto no se introducen generalmente en el tratamiento inicial de la materia, excepto tal vez como un resúmen de fórmulas." },


                    new Clase { ClaseId = 10, CursoId = 4, Descripcion = "Patrones de diseño", Tema = "En esta primera clase se presenta una definición de lo que son los patrones de diseño, así como explicar en qué momentos podría ser necesario utilizarlos" },
                    new Clase { ClaseId = 11, CursoId = 5, Descripcion = "Introduccion a Chino Mandarin", Tema = "El chino mandarín, o simplemente mandarín, es el conjunto de dialectos del chino mutuamente inteligibles que se hablan en el norte, centro y suroeste de China. En este curso se propone a enseñar las bases de este idioma para que posteriormente los estudiantes puedan aprendelo de forma más avanzada." });

            });


            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(x => x.ComentarioId);

                entity.Property(x => x.Texto).HasMaxLength(4096).IsRequired();
                entity.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(x => x.Apellido).HasMaxLength(50).IsRequired();
                entity.Property(x => x.Rol).HasMaxLength(50).IsRequired();


                entity.HasOne(x => x.ForoNavegation)
                .WithMany(x => x.ComentariosNavegation)
                .HasForeignKey(x => x.ForoId);
            });


            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(x => x.CursoId);

                entity.Property(x => x.Descripcion).HasMaxLength(4096).IsRequired();
                entity.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(x => x.ProfesorId).HasMaxLength(250).IsRequired();
                entity.Property(x => x.Imagen).HasMaxLength(250).IsRequired();

                entity.HasOne(x => x.CategoriaNavegacion)
                .WithMany(x => x.CursoNavegacion)
                .HasForeignKey(x => x.CategoriaId);

                entity.HasData(
                    new Curso
                    {
                        Cantidad = 40,
                        CategoriaId = 1,
                        CursoId = 1,
                        Descripcion = " Introducir a los estudiantes al paradigma de la programacion orientada a objetos para que puedan utilizar dicho paradigma en la realizacion de programas. Los estudiantes" +
                    "recibiran una introduccion a los conceptos de TAD, recursion, manejos de excepciones y estructuras de datos compuestas.",
                        Imagen = "https://blogthinkbig.com/wp-content/uploads/sites/4/2015/07/shutterstock_148972376.jpg?resize=610%2C407",
                        Nombre = "Algoritmos y programacion.",
                        ProfesorId = 1
                    },
                    new Curso
                    {
                        Cantidad = 40,
                        CategoriaId = 2,
                        CursoId = 2,
                        Descripcion = "Que los alumnos puedan familiarizarse con los patrones retóricos principales de la lengua inglesa en los usos y contextos de la comunicación académica,teniendo en cuenta el objetivo" +
                    " / complejidad / especificidad de cada situación comunicativa y la demanda de los interlocutores.",
                        Imagen = "https://www.altagracianoticias.com/wp-content/uploads/2019/06/ingles.jpg",
                        Nombre = "Ingles aplicado",
                        ProfesorId = 2
                    },
                    new Curso
                    {
                        Cantidad = 40,
                        CategoriaId = 3,
                        CursoId = 3,
                        Descripcion = "Favorecer la comprensión de los conceptos generales y específicos de electricidad, magnetismo y fenómenos ópticos. Incentivar el análisis de los fenómenos físicos en su aplicación al campo de la ingeniería.",
                        Imagen = "https://img.freepik.com/vector-gratis/pizarra-fondo-formulas-fisica-ciencia_97886-4558.jpg?size=626&ext=jpg",
                        Nombre = "Fisica II",
                        ProfesorId = 3
                    },
                    new Curso
                    {
                        Cantidad = 4,
                        CategoriaId = 1,
                        CursoId = 4,
                        Descripcion = "el estudiante tendrá los conocimientos de técnicas y herramientas que le permitan realizar software modular, reusable y extensible.Las técnicas mencionadas incluyen conocimientos teóricos y prácticos, habilidades,experiencias y sentido crítico, " +
                    "todas ellas fundamentadas en teorías y técnicas sólidas, comprobadas y bien establecidas.",
                        Imagen = "https://www.ingestructurada.com/Images/Diagram2.jpg",
                        Nombre = "Metodologias de programacion I",
                        ProfesorId = 4
                    },
                    new Curso
                    {
                        Cantidad = 40,
                        CategoriaId = 2,
                        CursoId = 5,
                        Descripcion = "A lo largo de este curso gratuito, aprenderás vocabulario extenso de chino mandarín, para describir personas y objetos, realizar comparaciones y exponer sus propias perspectivas utilizando estructuras de oraciones complejas y variadas. " +
                    "El objetivo principal de este curso es que aprendas a hablar un nivel intermedio del idioma y para ello estudiarás los tonos y la entonación con prácticas diseñadas,y aprenderás a construir diálogos en un entorno empresarial.",
                        Imagen = "https://www.ubo.cl/wp-content/uploads/chino_mandarin.jpg",
                        Nombre = "Chino Mandarin",
                        ProfesorId = 5
                    },
                    new Curso
                    {
                        Cantidad = 4,
                        CategoriaId = 3,
                        CursoId = 6,
                        Descripcion = "En este curso de Química General, aprenderemos los conceptos fundamentales de la “Ciencia Química”. Estudiaremos el universo a través de la materia, su estructura, propiedades y características a nivel atómico, molecular y macromolecular. Los temas que puedes encontrar a través de nuestras lecciones son:" +
                    " unidades de materia y energía, estructura atómica, tabla periódica, unidades y fórmulas químicas, enlace químico, nomenclatura química, reacciones químicas, estequiometría, gases calorimetría y soluciones.",
                        Imagen = "https://hallearn.com/wp-content/uploads/2015/06/quimico.jpg",
                        Nombre = "Quimica",
                        ProfesorId = 3
                    });

            });

            modelBuilder.Entity<Foro>(entity =>
            {
                entity.HasKey(x => x.ForoId);

                entity.Property(x => x.Texto).HasMaxLength(250).IsRequired();

                entity.HasData(
                    new Foro { ForoId = 1, ClaseId = 1, Texto = "Foro de consulta, clase POO." },
                    new Foro { ForoId = 2, ClaseId = 2, Texto = "Foro de consulta, clase manejo de excepciones." },
                    new Foro { ForoId = 3, ClaseId = 3, Texto = "Foro de consulta, clase grafos." },
                    new Foro { ForoId = 4, ClaseId = 4, Texto = "Foro de consulta, clase verbo to be." },
                    new Foro { ForoId = 5, ClaseId = 5, Texto = "Foro de consulta, clase present simple." },
                    new Foro { ForoId = 6, ClaseId = 6, Texto = "Foro de consulta, clase present continuous." },
                    new Foro { ForoId = 7, ClaseId = 7, Texto = "Foro de consulta, clase campo electrico." },
                    new Foro { ForoId = 8, ClaseId = 8, Texto = "Foro de consulta, clase campo magnetico." },
                    new Foro { ForoId = 9, ClaseId = 9, Texto = "Foro de consulta, clase ecuaciones de Maxwell." },

                    new Foro { ForoId = 10, ClaseId = 10, Texto = "Foro de consulta, clase de patrones de diseño." },
                    new Foro { ForoId = 11, ClaseId = 11, Texto = "Foro de consulta, clase de Introducción al Chino Mandarin." });

            });


            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(x => x.VideoId);

                entity.Property(x => x.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(x => x.Link).HasMaxLength(100).IsRequired();

                entity.HasData(
                    new Video { ClaseId = 1, Descripcion = "Video de introduccion a la POO", Link = "https://www.youtube.com/embed/iliKayKaGtc", VideoId = 1 },
                    new Video { ClaseId = 2, Descripcion = "Video de manejo de excepciones", Link = "https://www.youtube.com/embed/sNTowPB4YHI", VideoId = 2 },
                    new Video { ClaseId = 3, Descripcion = "Video estructuras de datos grafos", Link = "https://www.youtube.com/embed/hoE38ao9m7c", VideoId = 3 },
                    new Video { ClaseId = 4, Descripcion = "Video introduccion al verbo to be", Link = "https://www.youtube.com/embed/dFJvNYdKGrA", VideoId = 4 },
                    new Video { ClaseId = 5, Descripcion = "El present simple", Link = "https://www.youtube.com/embed/m0kTGL6Flzg", VideoId = 5 },
                    new Video { ClaseId = 6, Descripcion = "El present continuous", Link = "https://www.youtube.com/embed/H7uJ2Pqu21U", VideoId = 6 },
                    new Video { ClaseId = 7, Descripcion = "Video campo electrico", Link = "https://www.youtube.com/embed/OT5U17c6DSk", VideoId = 7 },
                    new Video { ClaseId = 8, Descripcion = "Video introduccion al campo magnetico", Link = "https://www.youtube.com/embed/MZVKEZsUVpo", VideoId = 8 },
                    new Video { ClaseId = 9, Descripcion = "Ecuaciones de maxwell", Link = "https://www.youtube.com/embed/pTWhwzqTXtY", VideoId = 9 },

                    new Video { ClaseId = 10, Descripcion = "Patrones de diseño", Link = "https://www.youtube.com/embed/cwfuydUHZ7o", VideoId = 10 },
                    new Video { ClaseId = 11, Descripcion = "Chino Mandarín", Link = "https://www.youtube.com/embed/fTkPECi7tGQ", VideoId = 11 });


            });
        }
    }
}
