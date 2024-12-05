using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurneroMedico.Migrations
{
    public partial class RemoveApellidoFromPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "Doctores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "Doctores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
