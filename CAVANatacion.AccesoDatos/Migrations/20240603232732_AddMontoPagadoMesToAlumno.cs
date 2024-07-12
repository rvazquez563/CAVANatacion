using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAVANatacion.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddMontoPagadoMesToAlumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoPagadoMes",
                table: "Alumnos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoPagadoMes",
                table: "Alumnos");
        }
    }
}
