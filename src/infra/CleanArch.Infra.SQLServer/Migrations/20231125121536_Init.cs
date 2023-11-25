using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    QuantidadeVagasMotos = table.Column<int>(type: "int", nullable: false),
                    QuantidadeVagasCarros = table.Column<int>(type: "int", nullable: false),
                    _created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    _updated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEntity", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_EnderecoEntity_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntity_EmpresaId",
                table: "EnderecoEntity",
                column: "EmpresaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoEntity");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
