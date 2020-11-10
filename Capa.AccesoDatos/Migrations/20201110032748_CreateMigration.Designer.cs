﻿// <auto-generated />
using Capa.AccesoDatos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capa.AccesoDatos.Migrations
{
    [DbContext(typeof(GenericContext))]
    [Migration("20201110032748_CreateMigration")]
    partial class CreateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Capa.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descripcion = "Programacion"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Descripcion = "Idiomas"
                        },
                        new
                        {
                            CategoriaId = 3,
                            Descripcion = "Ciencias exactas"
                        });
                });

            modelBuilder.Entity("Capa.Domain.Entities.Clase", b =>
                {
                    b.Property<int>("ClaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.HasKey("ClaseId");

                    b.HasIndex("CursoId");

                    b.ToTable("Clases");

                    b.HasData(
                        new
                        {
                            ClaseId = 1,
                            CursoId = 1,
                            Descripcion = "Introduccion a la programacion orientada a objetos",
                            Tema = "La programación orientada a objetos es una evolución de la programación procedural basada en funciones. La POO nos permite agrupar secciones de código con funcionalidades comunes. Una de las principales desventajas de la programación procedural basada en funciones es su construcción, cuando una aplicación bajo este tipo de programación crece, la modificación del código se hace muy trabajosa y difícil debido a que el cambio de una sola línea en una función, puede acarrear la modificación de muchas otras líneas de código pertenecientes a otras funciones que estén relacionadas. Con la programación orientada a objetos se pretende agrupar el código encapsulándolo y haciéndolo independiente, de manera que una modificación debida al crecimiento de la aplicación solo afecte a unas pocas líneas."
                        },
                        new
                        {
                            ClaseId = 2,
                            CursoId = 1,
                            Descripcion = "Manejo de excepciones.",
                            Tema = "Las características de control de excepciones del lenguaje C# le ayudan a afrontar cualquier situación inesperada o excepcional que se produce cuando se ejecuta un programa. El control de excepciones usa las palabras clave try, catch y finally para intentar realizar acciones que pueden no completarse correctamente, para controlar errores cuando decide que es razonable hacerlo y para limpiar recursos más adelante."
                        },
                        new
                        {
                            ClaseId = 3,
                            CursoId = 1,
                            Descripcion = "Estructuras de datos: Grafos.",
                            Tema = "En matemáticas y ciencias de la computación, un grafo es un conjunto de objetos llamados vértices o nodos unidos por enlaces llamados aristas o arcos, que permiten representar relaciones binarias entre elementos de un conjunto. Son objeto de estudio de la teoría de grafos. Típicamente, un grafo se representa gráficamente como un conjunto de puntos(vértices o nodos) unidos por líneas(aristas)."
                        },
                        new
                        {
                            ClaseId = 4,
                            CursoId = 2,
                            Descripcion = "El verbo to be",
                            Tema = "En inglés, así como en cualquier idioma, los verbos cumplen una función muy importante dentro del proceso de comunicación: éstos son los encargados de expresar las acciones. Hay un verbo en inglés que es esencial para comunicarse, y por supuesto el más usado de todos los que existen. Éste es el verbo to be."
                        },
                        new
                        {
                            ClaseId = 5,
                            CursoId = 2,
                            Descripcion = "El present simple",
                            Tema = " En inglés, el presente simple también denominado presente indefinido  es el tiempo verbal presente (de aspecto no perfecto). Es uno de los tiempos verbales del presente utilizados en inglés, además del presente progresivo, el presente perfecto y el presente perfecto progresivo.Se utiliza para hablar de cosas, hábitos diarios o actividades que suelen hacerse todos los días y siempre son verdad."
                        },
                        new
                        {
                            ClaseId = 6,
                            CursoId = 2,
                            Descripcion = "El present continuous",
                            Tema = "El presente continuo o presente progresivo, es uno de los tiempos verbales del presente usados en el inglés, los otros son el presente simple y presente perfecto. Todos ellos pueden ser usados tanto en el modo indicativo como en el subjuntivo."
                        },
                        new
                        {
                            ClaseId = 7,
                            CursoId = 3,
                            Descripcion = "Campo electrico",
                            Tema = "Un campo eléctrico es un campo de fuerza creado por la atracción y repulsión de cargas eléctricas (la causa del flujo eléctrico) y se mide en Voltios por metro (V/m). El flujo decrece con la distancia a la fuente que provoca el campo."
                        },
                        new
                        {
                            ClaseId = 8,
                            CursoId = 3,
                            Descripcion = "Campo magnetico",
                            Tema = "Un campo magnético es una descripción matemática de la influencia magnética de las corrientes eléctricas y de los materiales magnéticos.​ El campo magnético en cualquier punto está especificado por dos valores, la dirección y la magnitud; de tal forma que es un campo vectorial."
                        },
                        new
                        {
                            ClaseId = 9,
                            CursoId = 3,
                            Descripcion = "Ecuaciones de Maxwell",
                            Tema = "Las ecuaciones de Maxwell representan una de las formas mas elegantes y concisas de establecer los fundamentos de la Electricidad y el Magnetismo. A partir de ellas, se pueden desarrollar la mayoría de las fórmulas de trabajo en el campo. Debido a su breve declaración, encierran un alto nivel de sofisticación matemática y por tanto no se introducen generalmente en el tratamiento inicial de la materia, excepto tal vez como un resúmen de fórmulas."
                        });
                });

            modelBuilder.Entity("Capa.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ForoId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.HasKey("ComentarioId");

                    b.HasIndex("ForoId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Capa.Domain.Entities.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int")
                        .HasMaxLength(250);

                    b.HasKey("CursoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            CursoId = 1,
                            Cantidad = 40,
                            CategoriaId = 1,
                            Descripcion = " Introducir a los estudiantes al paradigma de la programacion orientada a objetos para que puedan utilizar dicho paradigma en la realizacion de programas. Los estudiantesrecibiran una introduccion a los conceptos de TAD, recursion, manejos de excepciones y estructuras de datos compuestas.",
                            Imagen = "https://blogthinkbig.com/wp-content/uploads/sites/4/2015/07/shutterstock_148972376.jpg?resize=610%2C407",
                            Nombre = "Algoritmos y programacion.",
                            ProfesorId = 1
                        },
                        new
                        {
                            CursoId = 2,
                            Cantidad = 40,
                            CategoriaId = 2,
                            Descripcion = "Que los alumnos puedan familiarizarse con los patrones retóricos principales de la lengua inglesa en los usos y contextos de la comunicación académica,teniendo en cuenta el objetivo / complejidad / especificidad de cada situación comunicativa y la demanda de los interlocutores.",
                            Imagen = "https://www.altagracianoticias.com/wp-content/uploads/2019/06/ingles.jpg",
                            Nombre = "Ingles aplicado",
                            ProfesorId = 2
                        },
                        new
                        {
                            CursoId = 3,
                            Cantidad = 40,
                            CategoriaId = 3,
                            Descripcion = "Favorecer la comprensión de los conceptos generales y específicos de electricidad, magnetismo y fenómenos ópticos. Incentivar el análisis de los fenómenos físicos en su aplicación al campo de la ingeniería.",
                            Imagen = "https://img.freepik.com/vector-gratis/pizarra-fondo-formulas-fisica-ciencia_97886-4558.jpg?size=626&ext=jpg",
                            Nombre = "Fisica II",
                            ProfesorId = 3
                        },
                        new
                        {
                            CursoId = 4,
                            Cantidad = 40,
                            CategoriaId = 1,
                            Descripcion = "el estudiante tendrá los conocimientos de técnicas y herramientas que le permitan realizar software modular, reusable y extensible.Las técnicas mencionadas incluyen conocimientos teóricos y prácticos, habilidades,experiencias y sentido crítico, todas ellas fundamentadas en teorías y técnicas sólidas, comprobadas y bien establecidas.",
                            Imagen = "https://www.ingestructurada.com/Images/Diagram2.jpg",
                            Nombre = "Metodologias de programacion I",
                            ProfesorId = 4
                        },
                        new
                        {
                            CursoId = 5,
                            Cantidad = 40,
                            CategoriaId = 2,
                            Descripcion = "A lo largo de este curso gratuito, aprenderás vocabulario extenso de chino mandarín, para describir personas y objetos, realizar comparaciones y exponer sus propias perspectivas utilizando estructuras de oraciones complejas y variadas. El objetivo principal de este curso es que aprendas a hablar un nivel intermedio del idioma y para ello estudiarás los tonos y la entonación con prácticas diseñadas,y aprenderás a construir diálogos en un entorno empresarial.",
                            Imagen = "https://www.ubo.cl/wp-content/uploads/chino_mandarin.jpg",
                            Nombre = "Chino Mandarin",
                            ProfesorId = 5
                        });
                });

            modelBuilder.Entity("Capa.Domain.Entities.Foro", b =>
                {
                    b.Property<int>("ForoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("ForoId");

                    b.HasIndex("ClaseId")
                        .IsUnique();

                    b.ToTable("Foros");

                    b.HasData(
                        new
                        {
                            ForoId = 1,
                            ClaseId = 1,
                            Texto = "Foro de consulta, clase POO."
                        },
                        new
                        {
                            ForoId = 2,
                            ClaseId = 2,
                            Texto = "Foro de consulta, clase manejo de excepciones."
                        },
                        new
                        {
                            ForoId = 3,
                            ClaseId = 3,
                            Texto = "Foro de consulta, clase grafos."
                        },
                        new
                        {
                            ForoId = 4,
                            ClaseId = 4,
                            Texto = "Foro de consulta, clase verbo to be."
                        },
                        new
                        {
                            ForoId = 5,
                            ClaseId = 5,
                            Texto = "Foro de consulta, clase present simple."
                        },
                        new
                        {
                            ForoId = 6,
                            ClaseId = 6,
                            Texto = "Foro de consulta, clase present continuous."
                        },
                        new
                        {
                            ForoId = 7,
                            ClaseId = 7,
                            Texto = "Foro de consulta, clase campo electrico."
                        },
                        new
                        {
                            ForoId = 8,
                            ClaseId = 8,
                            Texto = "Foro de consulta, clase campo magnetico."
                        },
                        new
                        {
                            ForoId = 9,
                            ClaseId = 9,
                            Texto = "Foro de consulta, clase ecuaciones de Maxwell."
                        });
                });

            modelBuilder.Entity("Capa.Domain.Entities.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("VideoId");

                    b.HasIndex("ClaseId")
                        .IsUnique();

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            VideoId = 1,
                            ClaseId = 1,
                            Descripcion = "Video de introduccion a la POO",
                            Link = "https://www.youtube.com/embed/iliKayKaGtc"
                        },
                        new
                        {
                            VideoId = 2,
                            ClaseId = 2,
                            Descripcion = "Video de manejo de excepciones",
                            Link = "https://www.youtube.com/embed/sNTowPB4YHI"
                        },
                        new
                        {
                            VideoId = 3,
                            ClaseId = 3,
                            Descripcion = "Video estructuras de datos grafos",
                            Link = "https://www.youtube.com/embed/hoE38ao9m7c"
                        },
                        new
                        {
                            VideoId = 4,
                            ClaseId = 4,
                            Descripcion = "Video introduccion al verbo to be",
                            Link = "https://www.youtube.com/embed/dFJvNYdKGrA"
                        },
                        new
                        {
                            VideoId = 5,
                            ClaseId = 5,
                            Descripcion = "El present simple",
                            Link = "https://www.youtube.com/embed/m0kTGL6Flzg"
                        },
                        new
                        {
                            VideoId = 6,
                            ClaseId = 6,
                            Descripcion = "El present continuous",
                            Link = "https://www.youtube.com/embed/H7uJ2Pqu21U"
                        },
                        new
                        {
                            VideoId = 7,
                            ClaseId = 7,
                            Descripcion = "Video campo electrico",
                            Link = "https://www.youtube.com/embed/OT5U17c6DSk"
                        },
                        new
                        {
                            VideoId = 8,
                            ClaseId = 8,
                            Descripcion = "Video introduccion al campo magnetico",
                            Link = "https://www.youtube.com/embed/MZVKEZsUVpo"
                        },
                        new
                        {
                            VideoId = 9,
                            ClaseId = 9,
                            Descripcion = "Ecuaciones de maxwell",
                            Link = "https://www.youtube.com/embed/pTWhwzqTXtY"
                        });
                });

            modelBuilder.Entity("Capa.Domain.Entities.Clase", b =>
                {
                    b.HasOne("Capa.Domain.Entities.Curso", "CursoNavegacion")
                        .WithMany("ClasesNavegacion")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capa.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("Capa.Domain.Entities.Foro", "ForoNavegation")
                        .WithMany("ComentariosNavegation")
                        .HasForeignKey("ForoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capa.Domain.Entities.Curso", b =>
                {
                    b.HasOne("Capa.Domain.Entities.Categoria", "CategoriaNavegacion")
                        .WithMany("CursoNavegacion")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capa.Domain.Entities.Foro", b =>
                {
                    b.HasOne("Capa.Domain.Entities.Clase", "ClaseNavegation")
                        .WithOne("ForoNavegation")
                        .HasForeignKey("Capa.Domain.Entities.Foro", "ClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capa.Domain.Entities.Video", b =>
                {
                    b.HasOne("Capa.Domain.Entities.Clase", "ClaseNavegation")
                        .WithOne("VideoNavegation")
                        .HasForeignKey("Capa.Domain.Entities.Video", "ClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
