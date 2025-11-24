using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHG.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrosDiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmocaoPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelIntensidade = table.Column<int>(type: "int", nullable: false),
                    DescricaoGatilho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotasAdicionais = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDiarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosDiarios");
        }
    }
}
