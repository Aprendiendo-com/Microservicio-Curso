using Microsoft.EntityFrameworkCore.Migrations;

namespace Capa.AccesoDatos.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1,
                column: "Imagen",
                value: "https://blogthinkbig.com/wp-content/uploads/sites/4/2015/07/shutterstock_148972376.jpg?resize=610%2C407");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2,
                column: "Imagen",
                value: "https://www.altagracianoticias.com/wp-content/uploads/2019/06/ingles.jpg");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 3,
                column: "Imagen",
                value: "https://img.freepik.com/vector-gratis/pizarra-fondo-formulas-fisica-ciencia_97886-4558.jpg?size=626&ext=jpg");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 4,
                columns: new[] { "Imagen", "Nombre" },
                values: new object[] { "https://www.ingestructurada.com/Images/Diagram2.jpg", "Metodologias de programacion I" });

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 5,
                column: "Imagen",
                value: "https://www.ubo.cl/wp-content/uploads/chino_mandarin.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 3,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 4,
                columns: new[] { "Imagen", "Nombre" },
                values: new object[] { "", "Metodologias de progrmacion I" });

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 5,
                column: "Imagen",
                value: "");
        }
    }
}
