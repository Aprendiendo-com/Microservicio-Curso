using Microsoft.EntityFrameworkCore.Migrations;

namespace Capa.AccesoDatos.Migrations
{
    public partial class detalles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Comentarios",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Comentarios");
        }
    }
}
