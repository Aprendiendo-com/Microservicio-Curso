﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Capa.AccesoDatos.Migrations
{
    public partial class createmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 4096, nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ProfesorId = table.Column<int>(maxLength: 250, nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    ClaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 4096, nullable: false),
                    Tema = table.Column<string>(maxLength: 4096, nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.ClaseId);
                    table.ForeignKey(
                        name: "FK_Clases_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foros",
                columns: table => new
                {
                    ForoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(maxLength: 250, nullable: false),
                    ClaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foros", x => x.ForoId);
                    table.ForeignKey(
                        name: "FK_Foros_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "ClaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Link = table.Column<string>(maxLength: 100, nullable: false),
                    ClaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "ClaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(maxLength: 4096, nullable: false),
                    ForoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Foros_ForoId",
                        column: x => x.ForoId,
                        principalTable: "Foros",
                        principalColumn: "ForoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion" },
                values: new object[] { 1, "Programacion" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion" },
                values: new object[] { 2, "Idiomas" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion" },
                values: new object[] { 3, "Ciencias exactas" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Cantidad", "CategoriaId", "Descripcion", "Imagen", "Nombre", "ProfesorId" },
                values: new object[,]
                {
                    { 1, 40, 1, " Introducir a los estudiantes al paradigma de la programacion orientada a objetos para que puedan utilizar dicho paradigma en la realizacion de programas. Los estudiantesrecibiran una introduccion a los conceptos de TAD, recursion, manejos de excepciones y estructuras de datos compuestas.", "", "Algoritmos y programacion.", 1 },
                    { 4, 40, 1, "el estudiante tendrá los conocimientos de técnicas y herramientas que le permitan realizar software modular, reusable y extensible.Las técnicas mencionadas incluyen conocimientos teóricos y prácticos, habilidades,experiencias y sentido crítico, todas ellas fundamentadas en teorías y técnicas sólidas, comprobadas y bien establecidas.", "", "Metodologias de progrmacion I", 4 },
                    { 2, 40, 2, "Que los alumnos puedan familiarizarse con los patrones retóricos principales de la lengua inglesa en los usos y contextos de la comunicación académica,teniendo en cuenta el objetivo / complejidad / especificidad de cada situación comunicativa y la demanda de los interlocutores.", "", "Ingles aplicado", 2 },
                    { 5, 40, 2, "A lo largo de este curso gratuito, aprenderás vocabulario extenso de chino mandarín, para describir personas y objetos, realizar comparaciones y exponer sus propias perspectivas utilizando estructuras de oraciones complejas y variadas. El objetivo principal de este curso es que aprendas a hablar un nivel intermedio del idioma y para ello estudiarás los tonos y la entonación con prácticas diseñadas,y aprenderás a construir diálogos en un entorno empresarial.", "", "Chino Mandarin", 5 },
                    { 3, 40, 3, "Favorecer la comprensión de los conceptos generales y específicos de electricidad, magnetismo y fenómenos ópticos. Incentivar el análisis de los fenómenos físicos en su aplicación al campo de la ingeniería.", "", "Fisica II", 3 }
                });

            migrationBuilder.InsertData(
                table: "Clases",
                columns: new[] { "ClaseId", "CursoId", "Descripcion", "Tema" },
                values: new object[,]
                {
                    { 1, 1, "Introduccion a la programacion orientada a objetos", "La programación orientada a objetos es una evolución de la programación procedural basada en funciones. La POO nos permite agrupar secciones de código con funcionalidades comunes. Una de las principales desventajas de la programación procedural basada en funciones es su construcción, cuando una aplicación bajo este tipo de programación crece, la modificación del código se hace muy trabajosa y difícil debido a que el cambio de una sola línea en una función, puede acarrear la modificación de muchas otras líneas de código pertenecientes a otras funciones que estén relacionadas. Con la programación orientada a objetos se pretende agrupar el código encapsulándolo y haciéndolo independiente, de manera que una modificación debida al crecimiento de la aplicación solo afecte a unas pocas líneas." },
                    { 2, 1, "Manejo de excepciones.", "Las características de control de excepciones del lenguaje C# le ayudan a afrontar cualquier situación inesperada o excepcional que se produce cuando se ejecuta un programa. El control de excepciones usa las palabras clave try, catch y finally para intentar realizar acciones que pueden no completarse correctamente, para controlar errores cuando decide que es razonable hacerlo y para limpiar recursos más adelante." },
                    { 3, 1, "Estructuras de datos: Grafos.", "En matemáticas y ciencias de la computación, un grafo es un conjunto de objetos llamados vértices o nodos unidos por enlaces llamados aristas o arcos, que permiten representar relaciones binarias entre elementos de un conjunto. Son objeto de estudio de la teoría de grafos. Típicamente, un grafo se representa gráficamente como un conjunto de puntos(vértices o nodos) unidos por líneas(aristas)." },
                    { 4, 2, "El verbo to be", "En inglés, así como en cualquier idioma, los verbos cumplen una función muy importante dentro del proceso de comunicación: éstos son los encargados de expresar las acciones. Hay un verbo en inglés que es esencial para comunicarse, y por supuesto el más usado de todos los que existen. Éste es el verbo to be." },
                    { 5, 2, "El present simple", " En inglés, el presente simple también denominado presente indefinido  es el tiempo verbal presente (de aspecto no perfecto). Es uno de los tiempos verbales del presente utilizados en inglés, además del presente progresivo, el presente perfecto y el presente perfecto progresivo.Se utiliza para hablar de cosas, hábitos diarios o actividades que suelen hacerse todos los días y siempre son verdad." },
                    { 6, 2, "El present continuous", "El presente continuo o presente progresivo, es uno de los tiempos verbales del presente usados en el inglés, los otros son el presente simple y presente perfecto. Todos ellos pueden ser usados tanto en el modo indicativo como en el subjuntivo." },
                    { 7, 3, "Campo electrico", "Un campo eléctrico es un campo de fuerza creado por la atracción y repulsión de cargas eléctricas (la causa del flujo eléctrico) y se mide en Voltios por metro (V/m). El flujo decrece con la distancia a la fuente que provoca el campo." },
                    { 8, 3, "Campo magnetico", "Un campo magnético es una descripción matemática de la influencia magnética de las corrientes eléctricas y de los materiales magnéticos.​ El campo magnético en cualquier punto está especificado por dos valores, la dirección y la magnitud; de tal forma que es un campo vectorial." },
                    { 9, 3, "Ecuaciones de Maxwell", "Las ecuaciones de Maxwell representan una de las formas mas elegantes y concisas de establecer los fundamentos de la Electricidad y el Magnetismo. A partir de ellas, se pueden desarrollar la mayoría de las fórmulas de trabajo en el campo. Debido a su breve declaración, encierran un alto nivel de sofisticación matemática y por tanto no se introducen generalmente en el tratamiento inicial de la materia, excepto tal vez como un resúmen de fórmulas." }
                });

            migrationBuilder.InsertData(
                table: "Foros",
                columns: new[] { "ForoId", "ClaseId", "Texto" },
                values: new object[,]
                {
                    { 1, 1, "Foro de consulta, clase POO." },
                    { 8, 8, "Foro de consulta, clase campo magnetico." },
                    { 7, 7, "Foro de consulta, clase campo electrico." },
                    { 6, 6, "Foro de consulta, clase present continuous." },
                    { 9, 9, "Foro de consulta, clase ecuaciones de Maxwell." },
                    { 4, 4, "Foro de consulta, clase verbo to be." },
                    { 5, 5, "Foro de consulta, clase present simple." },
                    { 3, 3, "Foro de consulta, clase grafos." },
                    { 2, 2, "Foro de consulta, clase manejo de excepciones." }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "ClaseId", "Descripcion", "Link" },
                values: new object[,]
                {
                    { 4, 4, "Video introduccion al verbo to be", "https://www.youtube.com/embed/dFJvNYdKGrA" },
                    { 5, 5, "El present simple", "https://www.youtube.com/embed/m0kTGL6Flzg" },
                    { 2, 2, "Video de manejo de excepciones", "https://www.youtube.com/embed/sNTowPB4YHI" },
                    { 6, 6, "El present continuous", "https://www.youtube.com/embed/H7uJ2Pqu21U" },
                    { 7, 7, "Video campo electrico", "https://www.youtube.com/embed/OT5U17c6DSk" },
                    { 1, 1, "Video de introduccion a la POO", "https://www.youtube.com/embed/iliKayKaGtc" },
                    { 8, 8, "Video introduccion al campo magnetico", "https://www.youtube.com/embed/MZVKEZsUVpo" },
                    { 3, 3, "Video estructuras de datos grafos", "https://www.youtube.com/embed/hoE38ao9m7c" },
                    { 9, 9, "Ecuaciones de maxwell", "https://www.youtube.com/embed/pTWhwzqTXtY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clases_CursoId",
                table: "Clases",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ForoId",
                table: "Comentarios",
                column: "ForoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaId",
                table: "Cursos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Foros_ClaseId",
                table: "Foros",
                column: "ClaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ClaseId",
                table: "Videos",
                column: "ClaseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Foros");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
