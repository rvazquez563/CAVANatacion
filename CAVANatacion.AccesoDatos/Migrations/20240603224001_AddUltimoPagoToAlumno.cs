using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAVANatacion.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddUltimoPagoToAlumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MesPago",
                table: "Alumnos",
                newName: "PagoMes");

            migrationBuilder.RenameColumn(
                name: "FechaPago",
                table: "Alumnos",
                newName: "UltimoPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoPago",
                table: "Alumnos",
                newName: "FechaPago");

            migrationBuilder.RenameColumn(
                name: "PagoMes",
                table: "Alumnos",
                newName: "MesPago");
        }
    }
}
