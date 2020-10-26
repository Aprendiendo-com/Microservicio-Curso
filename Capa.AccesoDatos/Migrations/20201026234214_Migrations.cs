using Microsoft.EntityFrameworkCore.Migrations;

namespace Capa.AccesoDatos.Migrations
{
    public partial class Migrations : Migration
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
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
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
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Tema = table.Column<string>(maxLength: 250, nullable: false),
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
                    Texto = table.Column<string>(maxLength: 250, nullable: false),
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
